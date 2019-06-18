<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunogruposlineatematica.aspx.cs" Inherits="estraunogruposlineatematica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <script src="jquery.js"></script>
   <%-- <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">--%>

     <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>



    <style>
        fieldset {
            padding: 10px;
        }

        table.border td, table.border th {
            /*border: 1px solid;*/
            margin: 0;
            padding: 0;
        }

        table.border tr, table.border {
            margin: 0;
            padding: 0;
        }
    </style>
    <script>
      
    </script>
     
    <script>
        $(function () {
            listarAreas();
        });
        var table;
        function cargarDataTable() {
            
          table =  $('#infolistado').DataTable({
                "language": {
                    "url": "dataTables.spanish.lang",
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "NingÚn dato disponible en esta tabla",
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
                        "sLast": "Último",
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

        function listarAreas() {
            $("#form").hide();
            $("#table").fadeIn(500);

            $.ajax({
                type: 'POST',
                url: 'estraunogruposlineatematica.aspx/listarareas',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function loadProyectosAsociados(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estraunogruposlineatematica.aspx/loadProyectos',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "loadSelect" && resp[1] !== "") {
                        $("#infolistado tbody").html(resp[2]);
                        $("#area").html(resp[1]);
                    }
                }, complete: function () {
                    cargarDataTable();
                }
            });
        }

        function btnRegresar() {
            $("#form").hide();
            $("#table").fadeIn(500);
            $("#area").html('');
            table.destroy();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia Nro. 1 - Grupos de investigación por línea temática: <strong id="area"></strong></h2>
    <div id="table">
      <br />
     <fieldset >
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Línea temática</th>
                    <th>Total grupos</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
</div>

    <div id="form" style="display:none">
        <a href="javascript:void(0)" onclick="btnRegresar()" class="btn btn-primary" style="float:right">Regresar</a><br />
         <table class="mGridTesoreria" id="infolistado">
            <thead>
                <tr>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Institución</th>
                    <th>Dane</th>
                    <th>Sede</th>
                    <th>Grupo de Investigación</th>
                    <th>Tipo de proyecto</th>
                </tr>
            </thead>
            <tbody ></tbody>
        </table>

    </div>

</asp:Content>

