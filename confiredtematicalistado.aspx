<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiredtematicalistado.aspx.cs" Inherits="confiredtematicalistado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

     <script type="text/javascript">
        $(document).ready(function () {
            cargarDataTable();
        });

        function cargarDataTable() {
            $('#GridRedesTematicas').DataTable({
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

        function VerGradosRedTematica(codigo) {
            var jsondata = "{'codredtematicasede': '" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'confiredtematicalistado.aspx/vergrados',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    var resp = response.d.split("@");
                    $('#dialog-formgrados').dialog({
                        modal: true,
                        height: 'auto',
                        width: 'auto',
                    });
                    if (resp[0] === "lleno") {
                        $("#listgrados").html(resp[1]);
                    }
                    else {
                        $("#listgrados").html('<tr><td colspan="3">No se cargó ningún grado</td></tr>');
                    }
                }
            });
        }

        function eliminargrado(codigo) {
            if (confirm('¿Estás seguro de eliminar este grado?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'confiredtematicalistado.aspx/deletegrado',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        $("#dialog-formgrados").dialog('close');
                        alert('Dato eliminado correctamente.');
                    }
                });
            }

        }
    </script>
 
     <!-- Para el ModalPopup del editar estudiante -->

     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
        <br /><br />
    <h2>Listado de Redes Temáticas</h2>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>

            <div style="float: right;margin-top:-20px;">
                <asp:Button ID="lnkAgregarRedTematica" runat="server" CssClass="btn btn-primary" OnClick="lnkAgregarRedTematica_Click" Text="Agregar" />
            </div>
            <br />
            Año <asp:DropDownList ID="dropAnio" runat="server" CssClass="TextBox"></asp:DropDownList>
            Asesor: <asp:DropDownList runat="server" ID="dropAsesores" CssClass="TextBox"></asp:DropDownList>
            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-success" Text="Buscar" runat="server" />
             <br />
            <div id="listado">

                 <asp:GridView ID="GridRedesTematicas" runat="server" CellPadding="4" DataKeyNames="codredtematicasede" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  AutoGenerateColumns="false" Style="margin: 0 auto" 
                        GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="codredtematicasede" HeaderText="Cod. Para el masivo" >
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="codasesorcoordinador" HeaderText="codasesorcoordinador" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                             <asp:BoundField DataField="asesor" HeaderText="Asesor" >
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="coddepartamento" HeaderText="coddepartamento" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="departamento" HeaderText="Departamento">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="codmunicipio" HeaderText="codmunicipio" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="municipio" HeaderText="Municipio">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="codinstitucion" HeaderText="codinstitucion" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="institucion" HeaderText="Institución">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="codsede" HeaderText="codsede" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sede" HeaderText="Sede">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="redtematica"  HeaderText="Red Temática" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="fechacreacion" HeaderText="Fecha creación">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                           <asp:BoundField DataField="aniored" HeaderText="Año de la Red Temática">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                             <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/add.png" Height="20px" Width="20px" OnClick="addGradosRedTematica_Click" />
                                 </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <a href="#" onclick="VerGradosRedTematica(<%# Eval("codredtematicasede") %>)"><img src="Imagenes/ver.png" width="20" /></a>
                                             <%--<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerGradosRedTematica_Click" />--%>
                                 </ItemTemplate>
                            </asp:TemplateField>

                         <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="imgEliminarRedTematica_Click" />
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

             <div id="dialog-formgrados" style="display:none;" title="Grados participantes">

                 <asp:Label ID="lblGrados" runat="server" Visible="false"></asp:Label>

               <table  class='mGridTesoreria'>
                   <thead>
                         <tr>
                           <th>Nro</th>
                           <th>Grado</th>
                           <th></th>
                         </tr>
                   </thead>
                   <tbody id="listgrados"></tbody>
                </table>
             

                 </div>

        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

