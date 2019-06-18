<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estracincomatriculados.aspx.cs" Inherits="estracincomatriculados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
      <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

     <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <script src="js/jquery.table2excel.js"></script>
    <script src="js/dataTables.buttons.min.js"></script>
    <script src="js/jszip.min.js"></script>
    <script src="js/buttons.html5.min.js"></script>


     <script type="text/javascript">
         $(document).ready(function () {
             cargarlista();
            
         });

         function cargarlista() {
             //$("#listado").html("");
             $.ajax({
                 type: 'POST',
                 url: 'estracincomatriculados.aspx/cargarlista',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (json) {
                     var resp = json.d.split("_list@");
                     if (resp[0] === "true") {
                         $("#listado tbody").html(resp[1]);
                     }
                 }, complete: function () {
                     cargarDataTable();
                 }
             });
         }

         function cargarDataTable() {
             $('#listado').DataTable({
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
                 },
                 dom: 'Bfrtip',
                 buttons: [
                     'excel'
                     // 'copy', 'csv', 'excel', 'pdf'
                 ]
             });

         }

    </script>

    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }

        .dt-button{
              background: #004b96 none repeat scroll 0 0;
                border-radius: 5px;
                color: #fff;
                margin-left: 5px;
                padding: 10px;
                border: none;
        }

        .textos2 {
            font-size: 17px;
            font-weight: bold;
            letter-spacing: 0.5px;
        }

        .cajausuario {
            background-color: #e6e6e6;
            border: 1px solid #d5d5d5;
            border-radius: 5px;
            -moz-border-radius: 5px;
            padding: 3px;
            border-spacing: 5px;
            margin: 2px auto 8px;
        }

        .border th {
            background: #507cd1;
            color: #fff;
            font-size: 15px;
            padding: 10px;
        }
        .center{
            text-align:center;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
        }
         table.border th {
            /*border: 1px solid;*/
            margin: 0;
            padding: 0;
        }
         table.border td,  .border th{
            /*border: 1px solid;*/
            margin: 0;
            padding: 5px;
            border-right: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
        }
          table.border td:last-child{
            border-right: 0;

          }

         
        table.border tr, table.border {
            margin: 0;
            padding: 0;
            /*border: 1px solid #ccc;*/
            background: #fff;
        }

        .width-100 {
            width: 100%;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. 5 -  Matriculados diplomado</h2>
    <asp:Label ID="lblCodGrupoInvestigacion" runat="server" Visible="false"></asp:Label>

    <fieldset>
        <legend>Listado</legend>

        <table class="mGridTesoreria" id="listado">
         <thead>
             <tr>
                 <th>No.</th>
                 <th>Nombre</th>
                 <th>Apellido</th>
                 <th>Identificación</th>
                 <th>Dirección</th>
                 <th>Teléfono</th>
                 <th>Municipio</th>
                 <th>Correo</th>
                 <th>Institución</th>
                 <th>Cargo</th>
             </tr>
         </thead>
         <tbody>
             <tr><td colspan='9' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>
         </tbody>
     </table>

    </fieldset>

</asp:Content>

