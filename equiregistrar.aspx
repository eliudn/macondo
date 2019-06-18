<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="equiregistrar.aspx.cs" Inherits="equiregistrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

        .auto-style1 {
            color: #FF0000;
        }
            a.tooltip {
            position: relative;
        }

            a.tooltip::before {
                content: attr(data-tooltip);
                font-size: 12px;
                position: absolute;
                z-index: 999;
                white-space: nowrap;
                bottom: 9999px;
                left: 0;
                background: #000;
                color: #e0e0e0;
                padding: 0px 7px;
                line-height: 24px;
                height: 24px;
                opacity: 0;
            }

            a.tooltip:hover::before {
                opacity: 1;
                top: 22px;
            }

            a.tooltip:hover::after {
                content: "";
                opacity: 1;
                width: 0;
                height: 0;
                border-left: 5px solid transparent;
                border-right: 5px solid transparent;
                border-bottom: 5px solid black;
                z-index: 999;
                position: absolute;
                white-space: nowrap;
                top: 17px;
                left: 0px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Gestión de Equipos.</h2>
    <br />
    <fieldset>
        <legend>Campos Obligatorios*</legend>
        <fieldset>
            <legend>Datos del Equipo</legend>
            <table cellpadding="4" align="center">
                <tr>
                    <td class="primeracolumna">Modelo o Nombre<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtModelo" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtModelo" runat="server" ErrorMessage="Digite el nombre del Equipo"
                            Text="*" Display="None" ControlToValidate="txtModelo" ValidationGroup="add">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtModelo"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td class="primeracolumna">Descripción
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
                           <a href="#" class="tooltip" data-tooltip="Aqui puedes colocar algún dato que identifique el equipo">
                          <img src="Imagenes/help.png" width="20px" /></a>
                    </td>

                </tr>
                <tr>
                    <td class="primeracolumna">Fabricante<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropFabricante" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropFabricante" runat="server" ErrorMessage="Seleccione el fabricante" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropFabricante" ValidationGroup="add">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropFabricante"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td class="primeracolumna">Categoria<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropCategoria" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropCategoria" runat="server" ErrorMessage="Seleccione la categoria" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropCategoria" ValidationGroup="add">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropCategoria"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnAgregarEquipo" Text="Agregar Equipo" runat="server" CssClass="btn btn-success" ValidationGroup="add" OnClick="btnAgregarEquipo_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend>Listado de equipos</legend>
            <asp:GridView ID="GridEquipos" runat="server" CellPadding="4" DataKeyNames="cod"
                EmptyDataText="No Existen Equipos"
                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                GridLines="None" OnRowDeleting="GridEquipos_RowDeleting">
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
                    <asp:BoundField DataField="nombre" HeaderText="Modelo">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="categoria" HeaderText="Categoria">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fabricante" HeaderText="Fabricante">
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
        </fieldset>
    </fieldset>

</asp:Content>

