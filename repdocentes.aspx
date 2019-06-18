<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="repdocentes.aspx.cs" Inherits="repdocentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script>

        $(document).ready(function () {
            cargarAnios();

            $("#anio").on("change", function () {
                var codanio = $('#anio').val();
                cargarDocentes(codanio);
            });
        });

        function cargarAnios() {

            $.ajax({
                type: 'POST',
                url: 'repdocentes.aspx/cargaranios',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#anio").html(response.d);
                }
            });
        }

        function cargarDocentes(codanio) {
            $("#infolist").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'codanio': '" + codanio + "'}";
           $.ajax({
               type: 'POST',
               url: 'repdocentes.aspx/cargardocentes',
               data: jsondata,
               contentType: 'application/json; charset=utf-8',
               dataType: 'JSON',
               success: function (response) {
                   //var resp = response.d.split("@");
                   //if (resp[0] === "docentes") {
                   $("#infolist").html(response.d);
                   //}
               }
           });
        }
    </script>

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div><br /><br />
    <h2 style="text-decoration: underline;">Reporte de Docentes</h2>
    <br />
  
    <table style="display:none">
        <tr>
            <td>Seleccione año</td>
            <td>
                <select id="anio" name="anio" class="TextBox"></select>
            </td>
        </tr>
    </table>

    <table class="mGridTesoreria" style="display:none">
        <thead>
            <tr>
                <th>Departamento</th>
                <th>Municipio</th>
                <th>Institución</th>
                <th>Dane Institución</th>
                <th>Sede</th>
                <th>Dane Sede</th>
                <th>Identificación</th>
                <th>Docente</th>
            </tr>
        </thead>
        <tbody id="infolist"></tbody>
    </table>

    Seleccione el año
    <asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropAnio_OnSelectedIndexChanged"></asp:DropDownList>
    <br />
    <asp:Button runat="server" ID="btnExportar" Visible="false" CssClass="btn btn-success" OnClick="btnExportExcel_Click" Text="Exportar" />

    <asp:Panel runat="server" ID="Panel">
        <asp:Label runat="server" ID="lblAnio"></asp:Label>
      <asp:GridView ID="GridDocentes" runat="server" CellPadding="4"  CssClass="mGridTesoreria"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen docentes."
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="departamento" HeaderText="Departamento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="municipio" HeaderText="Municipio">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="institucion" HeaderText="Institucion">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="daneinstitucion" HeaderText="Dane Institucion">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="sede" HeaderText="Sede">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="danesede" HeaderText="Dane Sede">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="identificacion" HeaderText="Identificacion">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="nomdoc" HeaderText="Docente">
                            <ItemStyle HorizontalAlign="Left" />
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
</asp:Panel>
  
</asp:Content>


