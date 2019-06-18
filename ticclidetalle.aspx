<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="ticclidetalle.aspx.cs" Inherits="ticclidetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(function () {
            $("#accordion").accordion({
                heightStyle: "content"

            });
        });
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

    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Seguimiento de Ticket</h2>
        </div>

        <div style="float: right;">
            <a href="ticclimonitor.aspx" runat="server" id="btnRegresar" class="btn btn-primary">Volver</a>
        </div>
    </div>
    <div id="accordion">
        <h3>Seguimiento</h3>
        <div>
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
                               
                     <div style="margin: 0 auto; text-align: center; padding-top: 5px; margin-top: 5px;">
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
                       <asp:BoundField DataField="descripcion" HeaderText="Decripcion">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                          <asp:BoundField DataField="cantidad" HeaderText="Duracion Horas">
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="startday" HeaderText="Fecha Comienzo" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="endday" HeaderText="Fecha Final" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="createdday" HeaderText="Fecha Creacion" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Left"/>
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

