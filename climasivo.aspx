<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="climasivo.aspx.cs" Inherits="climasivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .obligatorio {
            background-color: #91dd69;
            border: 1px solid black;
        }

        .opcional {
            background-color: #e4ed76;
            border: 1px solid black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <h2>Creación de cliente masivos</h2>
    <hr />
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td>&nbsp;1.
                    Primer Paso:
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;2.
                    Segundo Paso:
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir Archivo" CssClass="botones" Width="135px" />
                </td>
            </tr>
            <tr>
                <td>3.
                    Delimitado por:
                </td>
                <td>
                    <asp:DropDownList ID="dropDelimitador" runat="server" CssClass="TextBox">
                        <asp:ListItem Selected="True" Value=";">punto y coma</asp:ListItem>
                        <asp:ListItem Value=",">coma</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>4. Cuarto Paso:
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Cargar Datos-Tabla" OnClick="Button2_Click" CssClass="btn btn-primary" Width="135px" />
                </td>
            </tr>
            <tr>
                <td>5. Quinto Paso:
                </td>
                <td>
                    <asp:Button ID="btnActualizarPagos" runat="server" Text="Registrar Clientes" ValidationGroup="Agregar" CssClass="btn btn-success" Width="140px" OnClick="btnActualizarPagos_Click" />
                </td>
            </tr>
        </table>

        <div>
            <table>
            </table>
        </div>

    </div>
    <asp:Label ID="lblOculto" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblNumero" runat="server"  Text="0" Visible="false"></asp:Label>
    <br />
    <div style="background-color: #efefef; padding: 8px; max-width: 410px; text-align: center">
        <p>El documento .csv debe contener la siguiente estructura</p>
        <p><table>
            <tr>
                <td style="background-color:#91dd69">Obligatorio</td>
                <td style="background-color:#e4ed76">Opcional</td>
            </tr>
           </table></p>
        <table border="1" cellpadding="4" style="border-collapse: collapse; border-spacing: 5px;" align="center">
            <tr>
                <td class="obligatorio">NIT O DANE
                </td>
                <td class="obligatorio">PNOMBRE
                </td>
                <td class="opcional">PAPELLIDO
                </td>
                <td class="obligatorio">TIPOCLIENTE
                </td>
                <td class="opcional">EMAIL
                </td>
                <td class="opcional">TELEFONO
                </td>
                <td class="opcional">CELULAR
                </td>
                <td class="opcional">nitsede
                </td>
                <td class="obligatorio">SEDE
                </td>
                <td class="obligatorio">NOMBRE	
                </td>
                <td class="opcional">TELEFONO
                </td>
                <td class="opcional">DIRECCION
                </td>
                <td class="obligatorio">MUNICIPIO
                </td>

            </tr>
        </table>
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <table>
        <tr>
            <td colspan="2">Seleccione Proyecto:
            </td>
            <td colspan="2">
                <asp:DropDownList ID="DropProyecto" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="DropProyecto_SelectedIndexChanged"
                    Width="235px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDropProyecto" runat="server" ErrorMessage="Seleccione Proyecto"
                    Text="*" Display="None" ControlToValidate="DropProyecto" InitialValue="Seleccione"
                    ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVDropProyecto"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
            </td>

        </tr>
        <tr>
            <td>Fecha Inicio
            </td>
            <td>
                <asp:TextBox ID="txtFechaIni" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaIni"
                    Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                <asp:RegularExpressionValidator ID="REVtxtFechaIni" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                    ControlToValidate="txtFechaIni" ValidationGroup="Agregar" Text="*"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                    Style="color: #FF0000"></asp:RegularExpressionValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21"
                    runat="server" Enabled="True" TargetControlID="REVtxtFechaIni"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite Fecha de Inicio del Periodo"
                    ControlToValidate="txtFechaIni" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RFVtxtFechaIni"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
            </td>
            <td>Fecha Cierre
            </td>
            <td>
                <asp:TextBox ID="txtFechaFin" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                <ajx:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaFin"
                    Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                <asp:RegularExpressionValidator ID="REVtxtFechaFin" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                    ControlToValidate="txtFechaFin" ValidationGroup="Agregar" Text="*"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                    Style="color: #FF0000"></asp:RegularExpressionValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                    runat="server" Enabled="True" TargetControlID="REVtxtFechaFin"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                <asp:RequiredFieldValidator ID="RFVtxtFechaFin" runat="server" Display="None" ErrorMessage="Digite Fecha de Cierre del Periodo"
                    ControlToValidate="txtFechaFin" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVtxtFechaFin"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
            </td>
        </tr>

    </table>
    

    <div style="margin: 0 auto; text-align: center">
        <asp:Label ID="lblNroEnTabla" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMensajeMalos" Visible="false" runat="server"></asp:Label>
    </div>
    <asp:GridView ID="GridView1" runat="server" Height="251px" Width="420px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="0" HeaderText="Nit O Dane">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="1" HeaderText="PNombres">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="2" HeaderText="PApellido">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:BoundField DataField="3" HeaderText="Tipo Cliente">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="4" HeaderText="Email">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="5" HeaderText="Telefono">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="6" HeaderText="Celular">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="7" HeaderText="Nit S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="8" HeaderText="Sede">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="9" HeaderText="Nombre S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="10" HeaderText="Telefono S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="11" HeaderText="Direccion S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="12" HeaderText="Municipio S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
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
</asp:Content>

