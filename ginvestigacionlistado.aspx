<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="ginvestigacionlistado.aspx.cs" Inherits="ginvestigacionlistado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
      <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

     <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">



     <script type="text/javascript">
         $(document).ready(function () {
             cargarlista();
             cargarlistamunicipios();
             cargarlistainstituciones();
             cargarlistasedes();
         });

         function cargarlista() {
             //$("#listado").html("");
             $.ajax({
                 type: 'POST',
                 url: 'ginvestigacionlistado.aspx/cargarlista',
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

         function btncargarmunicipios() {
             $("#instituciones").hide();
             $("#sedes").hide();
             $("#municipios").fadeIn(500);
         }

         function btncargarinstituciones() {
             $("#instituciones").fadeIn(500);
             $("#sedes").hide();
             $("#municipios").hide();
         }

         function btncargarsedes() {
             $("#instituciones").hide(500);
             $("#sedes").fadeIn(500);
             $("#municipios").hide();
         }

         function cargarlistamunicipios() {
             //$("#listado").html("");
             $.ajax({
                 type: 'POST',
                 url: 'ginvestigacionlistado.aspx/cargarlistamunicipios',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (json) {
                     var resp = json.d.split("_list@");
                     if (resp[0] === "true") {
                         $("#listadomunicipios tbody").html(resp[1]);
                     }
                 }, complete: function () {
                     cargarDataTable2();
                 }
             });
         }

         function cargarlistainstituciones() {
             //$("#listado").html("");
             $.ajax({
                 type: 'POST',
                 url: 'ginvestigacionlistado.aspx/cargarlistainstituciones',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (json) {
                     var resp = json.d.split("_list@");
                     if (resp[0] === "true") {
                         $("#listadoinstituciones tbody").html(resp[1]);
                     }
                 }, complete: function () {
                     cargarDataTable4();
                 }
             });
         }
         

             function cargarlistasedes() {
                 //$("#listado").html("");
                 $.ajax({
                     type: 'POST',
                     url: 'ginvestigacionlistado.aspx/cargarlistasedes',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (json) {
                         var resp = json.d.split("_list@");
                         if (resp[0] === "true") {
                             $("#listadosedes tbody").html(resp[1]);
                         }
                     }, complete: function () {
                         cargarDataTable3();
                     }
                 });
             }

         //No funka
         function ver(codigo) {
             var jsonData = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'ginvestigacionlistado.aspx/ver',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 data: jsonData,
                 success: function (json) {
                     var resp = json.d.split("_see@");
                     if (resp[0] === "true") {
                         $('#formevidencias').dialog({
                             modal: true,
                             height: 'auto',
                             width: 'auto'
                         });
                         $("#evidencias").html(resp[1]);
                     }
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
                 }
             });

         }

         function cargarDataTable2() {
             $('#listadomunicipios').DataTable({
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

         function cargarDataTable3() {
             $('#listadosedes').DataTable({
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

         function cargarDataTable4() {
             $('#listadoinstituciones').DataTable({
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

         
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. 1 -  Planeación y divulgación de la convocatoria</h2>
    <asp:Label ID="lblCodGrupoInvestigacion" runat="server" Visible="false"></asp:Label>

    <fieldset>
        <legend>Listado</legend>

        <table class="mGridTesoreria" id="listado">
         <thead>
             <tr>
                 <th>No.</th>
                 <th>Municipio</th>
                 <th>Institucion</th>
                 <th>Sede</th>
                 <th>Pregunta</th>
                 <th>Tipo de <br />proyecto</th>
                 <th>Línea de <br />investigación</th>
                 <th>Concepto</th>
                 <th></th>
             </tr>
         </thead>
         <tbody>
             <tr><td colspan='9' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>
         </tbody>
     </table>

    </fieldset>

    <center>
        <a href="javascript:void(0)" onclick="btncargarmunicipios()" class="btn btn-success">Total Municipios</a>
        <a href="javascript:void(0)" onclick="btncargarinstituciones()" class="btn btn-success">Total Instituciones</a>
        <a href="javascript:void(0)" onclick="btncargarsedes()" class="btn btn-success">Total Sedes</a>
    </center>

    <div id="municipios" style="display:none">

         <fieldset>
        <legend>Total en municipios</legend>

        <table class="mGridTesoreria" id="listadomunicipios">
         <thead>
             <tr>
                 <th>No.</th>
                 <th>Municipio</th>
                 <th>Total</th>
             </tr>
         </thead>
         <tbody>
             <tr><td colspan='3' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>
         </tbody>
     </table>

    </fieldset>

    </div>

     <div id="instituciones" style="display:none">

         <fieldset>
        <legend>Total en instituciones</legend>

        <table class="mGridTesoreria" id="listadoinstituciones">
         <thead>
             <tr>
                 <th>No.</th>
                 <th>Municipio</th>
                 <th>Instituciones</th>
                 <th>Total</th>
             </tr>
         </thead>
         <tbody>
             <tr><td colspan='4' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>
         </tbody>
     </table>

    </fieldset>

    </div>

     <div id="sedes" style="display:none">

         <fieldset>
        <legend>Total en sedes</legend>

        <table class="mGridTesoreria" id="listadosedes">
         <thead>
             <tr>
                 <th>No.</th>
                 <th>Municipio</th>
                 <th>Instituciones</th>
                 <th>Sedes</th>
                 <th>Total</th>
             </tr>
         </thead>
         <tbody>
             <tr><td colspan='5' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>
         </tbody>
     </table>

    </fieldset>

    </div>

   
</asp:Content>

