<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="replineabasegeneraldet.aspx.cs" Inherits="replineabasegeneraldet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
    <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />
     <script>
         $(document).ready(function () {
             $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando, por favor espere...</div>');
             $.ajax({
                 type: 'POST',
                 url: 'replineabasegeneraldet.aspx/validarpregunta',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                 },
                 complete: function () {
                     cargarDataTable()
                     $(".desactivarC1").fadeOut(500);
                 }
             });
         });

         var table;

         function cargarDataTable() {
             table = $('#infoListTable').DataTable({
                 //"scrollX": 400,   // For Scrolling
                 "language": {
                     "url": "dataTables.spanish.lang",
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
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

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Reporte General Línea Base detallado</h2>
     <a class="btn btn-primary" href="replineabaseGeneral.aspx" style="float:right" >Regresar</a><br /><br /><br />
    <table class='mGridTesoreria' id='infoListTable'></table>

</asp:Content>

