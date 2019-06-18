<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="menusegestrategia2.aspx.cs" Inherits="menusegestrategia2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">


     <script src="./js/jquery.table2excel.js"></script>
    <style type="text/css">
        img.res {
            width: 100%;
            max-width: 600px;
        }

        .navegadores {
            background-color: #BECECE;
            float: right;
            border-top:2px solid #8FA9A9;
            border-left:2px solid #8FA9A9;
            border-collapse: collapse;
            border-radius: 4px 4px 4px 4px;
            position: absolute;
            width: 250px;
            bottom: 0;
            right:0;
            font-size:14px;
            }

         .auto-style1 {
            color: #FF0000;
        }

        .dt-button{
              background: #004b96 none repeat scroll 0 0;
                border-radius: 5px;
                color: #fff;
                margin-left: 5px;
                padding: 10px;
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

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
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
        table.border{
            border-collapse: separate;
            border-spacing: 0;

        }
        table.border td{
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;

        }
         table.border th {
            border: 0px solid;
            margin: 0;
            padding: 10px;
        }
         table.border td,  .border th{
            /*border: 1px solid;*/
            margin: 0;
            padding: 10px !important;
            border-right: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
        }
          table.border td:last-child{
            /*border-right: 0;*/

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

     <script>
         function abrir(panel) {
             var p = parseInt(panel);
             $(function () {
                 $("#MainContent_accordion").accordion({
                     heightStyle: "content",
                     active: p
                 });
             });
         }
    </script>

     <script src="./js/jquery.table2excel.js"></script>

    <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
     <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />

     <script>
        
         $(document).ready(function () {

             cargardatos();

            $("#MainContent_accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#MainContent_accordion").attr("style", "visibility:visible;");

         });

         function exportarExcel(id, namexls) {
             //excel
             $("#" + id).table2excel({
                 exclude: ".noExl",
                 name: "Excel Document Name",
                 filename: namexls,
                 fileext: ".xls",
                 exclude_img: true,
                 exclude_links: true,
                 exclude_inputs: true
             });
         }

         function cargarDataTable(tableList) {

             table = $(tableList).DataTable({
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

         function cargardatos() {
             $("#tableList tbody").html('<td colspan="6" style="text-align:center;">Cargando...</td>');
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia2.aspx/cargardatos',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     $("#tableList tbody").html(resp);
                 }, complete: function () {

                 }
             });
         }

         function back() {
             $("#maestrosmatriculadosestra2Det").hide();
             $("#maestrosmatriculadosestra2").hide();
             $("#cargarDocentesBeneficiadosIndicador3").hide();
             $("#cargarDocentesInscritosComitesEspApro").hide();
             $("#maestrosredestematicasIndicador5").hide();
             $("#sesionformacionMaestros").hide();
             $("#asistentesSesionMaestros").hide();
             $("#sesionesformacionevaluadas").hide();
             $("#totalgruposinvestigacionfinanciados").hide();
             $("#cargarListadointroiepEstraDos").hide();
             $("#cargarApropiacionDocentesEncabezado").hide();
             $("#cargarApropiacionDocentesSeleccionados").hide();
             $("#cargarEntregaMaterialesCoordEstra2").hide();
             $("#cargarInstrmentoS003").hide();
             $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
             $("#cargarDocentesEstra1_Estra2Where").hide();
             $("#cargarDocentesRedestematicasWhere").hide();
             $("#cargarDocentesApropiacionSocialWhere").hide();
             $("#table").fadeIn(500);

         }

         function maestrosmatriculadosestra2() {
             $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
             $("#maestrosmatriculadosestra2").fadeIn(500);
             $("#sesionesformacionevaluadas").hide();
             $("#asistentesSesionMaestros").hide();
             $("#sesionformacionMaestros").hide();
             $("#maestrosmatriculadosestra2Det").hide();
             $("#cargarDocentesBeneficiadosIndicador3").hide();
             $("#cargarDocentesInscritosComitesEspApro").hide();
             $("#maestrosredestematicasIndicador5").hide();
             $("#totalgruposinvestigacionfinanciados").hide();
             $("#cargarListadointroiepEstraDos").hide();
             $("#cargarApropiacionDocentesEncabezado").hide();
             $("#cargarApropiacionDocentesSeleccionados").hide();
             $("#cargarEntregaMaterialesCoordEstra2").hide();
             $("#cargarInstrmentoS003").hide();
             $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
             $("#cargarDocentesEstra1_Estra2Where").hide();
             $("#cargarDocentesRedestematicasWhere").hide();
             $("#cargarDocentesApropiacionSocialWhere").hide();
             $("#table").hide();
             var table = $('#tablemaestrosmatriculadosestra2').DataTable();
             table.destroy();
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia2.aspx/maestrosmatriculadosestra2',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     $("#tablemaestrosmatriculadosestra2 tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablemaestrosmatriculadosestra2");
                     $(".desactivarC1").fadeOut(500);
                 }
             });
         }

         function maestrosmatriculadosestra2Det() {
             $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
             $("#maestrosmatriculadosestra2Det").fadeIn(500);
             $("#sesionesformacionevaluadas").hide();
             $("#sesionformacionMaestros").hide();
             $("#asistentesSesionMaestros").hide();
             $("#maestrosmatriculadosestra2").hide();
             $("#cargarDocentesBeneficiadosIndicador3").hide();
             $("#cargarDocentesInscritosComitesEspApro").hide();
             $("#maestrosredestematicasIndicador5").hide();
             $("#totalgruposinvestigacionfinanciados").hide();
             $("#cargarListadointroiepEstraDos").hide();
             $("#cargarApropiacionDocentesEncabezado").hide();
             $("#cargarApropiacionDocentesSeleccionados").hide();
             $("#cargarEntregaMaterialesCoordEstra2").hide();
             $("#cargarInstrmentoS003").hide();
             $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
             $("#cargarDocentesEstra1_Estra2Where").hide();
             $("#cargarDocentesRedestematicasWhere").hide();
             $("#cargarDocentesApropiacionSocialWhere").hide();
             $("#table").hide();
             var table = $('#tablemaestrosmatriculadosestra2Det').DataTable();
             table.destroy();
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia2.aspx/maestrosmatriculadosestra2Det',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     $("#tablemaestrosmatriculadosestra2Det tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablemaestrosmatriculadosestra2Det");
                     $(".desactivarC1").fadeOut(500);
                 }
             });
         }

         function cargarDocentesBeneficiadosIndicador3() {
             $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
             $("#cargarDocentesBeneficiadosIndicador3").fadeIn(500);
             $("#sesionesformacionevaluadas").hide();
             $("#sesionformacionMaestros").hide();
             $("#asistentesSesionMaestros").hide();
             $("#maestrosmatriculadosestra2").hide();
             $("#maestrosmatriculadosestra2Det").hide();
             $("#cargarDocentesInscritosComitesEspApro").hide();
             $("#maestrosredestematicasIndicador5").hide();
             $("#totalgruposinvestigacionfinanciados").hide();
             $("#cargarListadointroiepEstraDos").hide();
             $("#cargarApropiacionDocentesEncabezado").hide();
             $("#cargarApropiacionDocentesSeleccionados").hide();
             $("#cargarEntregaMaterialesCoordEstra2").hide();
             $("#cargarInstrmentoS003").hide();
             $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
             $("#cargarDocentesEstra1_Estra2Where").hide();
             $("#cargarDocentesRedestematicasWhere").hide();
             $("#cargarDocentesApropiacionSocialWhere").hide();
             $("#table").hide();
             var table = $('#tablecargarDocentesBeneficiadosIndicador3').DataTable();
             table.destroy();
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia2.aspx/cargarDocentesBeneficiadosIndicador3',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     $("#tablecargarDocentesBeneficiadosIndicador3 tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablecargarDocentesBeneficiadosIndicador3");
                     $(".desactivarC1").fadeOut(500);
                 }
             });
         }

         function cargarDocentesInscritosComitesEspApro() {
             $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
             $("#cargarDocentesInscritosComitesEspApro").fadeIn(500);
             $("#sesionesformacionevaluadas").hide();
             $("#sesionformacionMaestros").hide();
             $("#asistentesSesionMaestros").hide();
             $("#cargarDocentesBeneficiadosIndicador3").hide();
             $("#maestrosmatriculadosestra2").hide();
             $("#maestrosmatriculadosestra2Det").hide();
             $("#maestrosredestematicasIndicador5").hide();
             $("#totalgruposinvestigacionfinanciados").hide();
             $("#cargarListadointroiepEstraDos").hide();
             $("#cargarApropiacionDocentesEncabezado").hide();
             $("#cargarApropiacionDocentesSeleccionados").hide();
             $("#cargarEntregaMaterialesCoordEstra2").hide();
             $("#cargarInstrmentoS003").hide();
             $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
             $("#cargarDocentesEstra1_Estra2Where").hide();
             $("#cargarDocentesRedestematicasWhere").hide();
             $("#cargarDocentesApropiacionSocialWhere").hide();
             $("#table").hide();
             var table = $('#tablecargarDocentesInscritosComitesEspApro').DataTable();
             table.destroy();
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia2.aspx/cargarDocentesInscritosComitesEspApro',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     $("#tablecargarDocentesInscritosComitesEspApro tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablecargarDocentesInscritosComitesEspApro");
                     $(".desactivarC1").fadeOut(500);
                 }
             });
         }
         

        function maestrosredestematicasIndicador5() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#maestrosredestematicasIndicador5").fadeIn(500);
            $("#sesionesformacionevaluadas").hide();
            $("#sesionformacionMaestros").hide();
            $("#asistentesSesionMaestros").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablemaestrosredestematicasIndicador5').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/maestrosredestematicasIndicador5',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablemaestrosredestematicasIndicador5 tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablemaestrosredestematicasIndicador5");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function sesionformacionMaestros(momento, sesion, indicador) {
            $("#indicador_sesion").html(indicador);
            var jsonData = '{ "momento":"' + momento + '", "sesion":"' + sesion + '"}';
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#sesionformacionMaestros").fadeIn(500);
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablesesionformacionMaestros').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/sesionformacionMaestros',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsonData,
                success: function (response) {
                    var resp = response.d;
                    $("#tablesesionformacionMaestros tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablesesionformacionMaestros");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function asistentesSesionMaestros(momento, sesion, jornada, indicador) {
            $("#indicador_asistentes").html(indicador);
            var jsonData = '{ "momento":"' + momento + '", "sesion":"' + sesion + '", "jornada":"' + jornada + '"}';
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#asistentesSesionMaestros").fadeIn(500);
            $("#sesionesformacionevaluadas").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tableasistentesSesionMaestros').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/asistentesSesionMaestros',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsonData,
                success: function (response) {
                    var resp = response.d;
                    $("#tableasistentesSesionMaestros tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tableasistentesSesionMaestros");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function sesionesformacionevaluadas(momento, sesion, indicador, tipo) {
            $("#indicador_sesionesformacionevaluadas").html(indicador);
            var jsonData = '{ "momento":"' + momento + '", "sesion":"' + sesion + '", "tipo":"' + tipo + '"}';
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#sesionesformacionevaluadas").fadeIn(500);
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablesesionesformacionevaluadas').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/sesionesformacionevaluadas',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsonData,
                success: function (response) {
                    var resp = response.d;
                    $("#tablesesionesformacionevaluadas tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablesesionesformacionevaluadas");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function totalgruposinvestigacionfinanciados() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#totalgruposinvestigacionfinanciados").fadeIn(500);
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tabletotalgruposinvestigacionfinanciados').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/totalgruposinvestigacionfinanciados',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tabletotalgruposinvestigacionfinanciados tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tabletotalgruposinvestigacionfinanciados");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarListadointroiepEstraDos() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarListadointroiepEstraDos").fadeIn(500);
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarListadointroiepEstraDos').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarListadointroiepEstraDos',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarListadointroiepEstraDos tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarListadointroiepEstraDos");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarApropiacionDocentesEncabezado() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarApropiacionDocentesEncabezado").fadeIn(500);
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarApropiacionDocentesEncabezado').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarApropiacionDocentesEncabezado',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarApropiacionDocentesEncabezado tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarApropiacionDocentesEncabezado");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarApropiacionDocentesSeleccionados() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarApropiacionDocentesSeleccionados").fadeIn(500);
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarApropiacionDocentesSeleccionados').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarApropiacionDocentesSeleccionados',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarApropiacionDocentesSeleccionados tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarApropiacionDocentesSeleccionados");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarEntregaMaterialesCoordEstra2(estado, titulo) {
            var jsonData = '{ "estado":"' + estado + '"}';
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarEntregaMaterialesCoordEstra2Estado").html(titulo);
            $("#cargarEntregaMaterialesCoordEstra2").fadeIn(500);
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarEntregaMaterialesCoordEstra2').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarEntregaMaterialesCoordEstra2',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsonData,
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarEntregaMaterialesCoordEstra2 tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarEntregaMaterialesCoordEstra2");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarInstrmentoS003() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarInstrmentoS003").fadeIn(500);
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarInstrmentoS003').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarInstrmentoS003',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarInstrmentoS003 tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarInstrmentoS003");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarListadocontenidodigitalEstraDosActualizado() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarListadocontenidodigitalEstraDosActualizado").fadeIn(500);
            $("#cargarInstrmentoS003").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarListadocontenidodigitalEstraDosActualizado').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarListadocontenidodigitalEstraDosActualizado',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarListadocontenidodigitalEstraDosActualizado tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarListadocontenidodigitalEstraDosActualizado");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarDocentesEstra1_Estra2Where() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarDocentesEstra1_Estra2Where").fadeIn(500);
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarDocentesEstra1_Estra2Where').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarDocentesEstra1_Estra2Where',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarDocentesEstra1_Estra2Where tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarDocentesEstra1_Estra2Where");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarDocentesRedestematicasWhere() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarDocentesRedestematicasWhere").fadeIn(500);
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#cargarDocentesApropiacionSocialWhere").hide();
            $("#table").hide();
            var table = $('#tablecargarDocentesRedestematicasWhere').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarDocentesRedestematicasWhere',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarDocentesRedestematicasWhere tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarDocentesRedestematicasWhere");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

        function cargarDocentesApropiacionSocialWhere() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255, .8);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Cargando listado, por favor espere...<br /><img src="Imagenes/loading.gif"  width="50" /></div>');
            $("#cargarDocentesApropiacionSocialWhere").fadeIn(500);
            $("#cargarDocentesRedestematicasWhere").hide();
            $("#cargarDocentesEstra1_Estra2Where").hide();
            $("#cargarListadocontenidodigitalEstraDosActualizado").hide();
            $("#cargarInstrmentoS003").hide();
            $("#cargarEntregaMaterialesCoordEstra2").hide();
            $("#cargarApropiacionDocentesSeleccionados").hide();
            $("#cargarApropiacionDocentesEncabezado").hide();
            $("#cargarListadointroiepEstraDos").hide();
            $("#totalgruposinvestigacionfinanciados").hide();
            $("#sesionesformacionevaluadas").hide();
            $("#asistentesSesionMaestros").hide();
            $("#sesionformacionMaestros").hide();
            $("#maestrosredestematicasIndicador5").hide();
            $("#cargarDocentesBeneficiadosIndicador3").hide();
            $("#cargarDocentesInscritosComitesEspApro").hide();
            $("#maestrosmatriculadosestra2").hide();
            $("#maestrosmatriculadosestra2Det").hide();
            $("#table").hide();
            var table = $('#tablecargarDocentesApropiacionSocialWhere').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'menusegestrategia2.aspx/cargarDocentesApropiacionSocialWhere',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tablecargarDocentesApropiacionSocialWhere tbody").html(resp);
                }, complete: function () {
                    cargarDataTable("#tablecargarDocentesApropiacionSocialWhere");
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }

    </script>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>

    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false" ></asp:Label>

 <br /><br />
    <h2>Estrategia</h2>

     Exportar a 
        <a href="javascript:void(0);" class="btn btn-success" style="padding: 5px 12px;" onclick="exportarExcel('tableList','Estrategia No. 2')">Excel</a>
        <br /><br />

    <div id="table">
        <fieldset>
        <legend>No. 2</legend>

        <table width="100%" class="border" id="tableList">
                 <thead>
		            <tr>
		                <th>Nombre indicador</th>
		                <th>Meta</th>
                        <th>Ejecución</th>
                        <th>% Ejecución</th>
                        <th>Peso</th>
		                <th class="noExl">Detalles</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="6" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>
    </div>

    <div id="maestrosmatriculadosestra2" style="display:none">

        <fieldset>
        <legend>Maestros y maestras matriculados en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablemaestrosmatriculadosestra2">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>ID. Docente</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="maestrosmatriculadosestra2Det" style="display:none">

        <fieldset>
        <legend>Maestros y maestras acompañantes / investigadores matriculados en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablemaestrosmatriculadosestra2Det">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>ID. Docente</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarDocentesBeneficiadosIndicador3" style="display:none">

        <fieldset>
        <legend>Maestros y maestras coinvestigadores que se forman en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarDocentesBeneficiadosIndicador3">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>ID. Docente</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarDocentesInscritosComitesEspApro" style="display:none">

        <fieldset>
        <legend>Maestros y maestras inscritos en los comités de los espacios de apropiacion social institucionales que se forman en estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarDocentesInscritosComitesEspApro">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>ID. Docente</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="maestrosredestematicasIndicador5" style="display:none">

        <fieldset>
        <legend>Maestros y maestras lideres de las redes temáticas formados en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica.</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablemaestrosredestematicasIndicador5">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>ID. Docente</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="sesionformacionMaestros" style="display:none">

        <fieldset>
        <legend><b id="indicador_sesion"></b></legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablesesionformacionMaestros">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="asistentesSesionMaestros" style="display:none">

        <fieldset>
        <legend><b id="indicador_asistentes"></b></legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tableasistentesSesionMaestros">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>ID. Docente</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="sesionesformacionevaluadas" style="display:none">

        <fieldset>
        <legend><b id="indicador_sesionesformacionevaluadas"></b></legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablesesionesformacionevaluadas">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="totalgruposinvestigacionfinanciados" style="display:none">

        <fieldset>
        <legend> Grupos de Investigación Financiados</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tabletotalgruposinvestigacionfinanciados">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td></td>
		                <td></td>
                        <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarListadointroiepEstraDos" style="display:none">

        <fieldset>
        <legend> Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarListadointroiepEstraDos">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución</th>
                        <th>Sede</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                        <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarApropiacionDocentesEncabezado" style="display:none">

        <fieldset>
        <legend> Espacios de reflexión, producción y apropiación de maestros que aprenden de maestros, denominados: “El maestro tiene la palabra”.</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarApropiacionDocentesEncabezado">
                 <thead>
		            <tr>
		                <th>Tipo evento</th>
		                <th>Fecha </th>
                        <th>Hora inicio</th>
                        <th>Hora fin</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarApropiacionDocentesSeleccionados" style="display:none">

        <fieldset>
        <legend> Ponencias realizadas</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarApropiacionDocentesSeleccionados">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución </th>
                        <th>Sede</th>
                        <th>Identificación</th>
                        <th>Nombre del docente</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

     <div id="cargarEntregaMaterialesCoordEstra2" style="display:none">

        <fieldset>
        <legend><p id="cargarEntregaMaterialesCoordEstra2Estado"></p></legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarEntregaMaterialesCoordEstra2">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución </th>
                        <th>Sede</th>
                        <th>Coordinador</th>
                        <th>Quien recibe</th>
                        <th>Fecha entrega</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarInstrmentoS003" style="display:none">

        <fieldset>
        <legend> Sistematizaciones y/o Investigaciones de grupos de maestros(as) acompañantes investigadores terminadas</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarInstrmentoS003">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución </th>
                        <th>Sede</th>
                        <th>Grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarListadocontenidodigitalEstraDosActualizado" style="display:none">

        <fieldset>
        <legend>Contenidos educativos digitales para introducir la investigación en cada una de las 6 areas del curriculo para 10 niveles escolares. Contrapartida CUC.</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarListadocontenidodigitalEstraDosActualizado">
                 <thead>
		            <tr>
		                <th>Año</th>
		                <th>Coordinador </th>
                        <th>Tema</th>
                        <th>Fecha</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

    <div id="cargarDocentesEstra1_Estra2Where" style="display:none">

        <fieldset>
        <legend> Maestros y maestras acompañantes de los grupos de investigación infantiles y juveniles que no están en la estrategia No 2. de formación</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarDocentesEstra1_Estra2Where">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución </th>
                        <th>Sede</th>
                        <th>Identificación</th>
                        <th>Docente</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                         <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

     <div id="cargarDocentesRedestematicasWhere" style="display:none">

        <fieldset>
        <legend> Maestros y maestras acompañantes de las redes temáticas infantiles y juveniles que no están en la estrategia No 2. de formación.</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarDocentesRedestematicasWhere">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución </th>
                        <th>Sede</th>
                        <th>Identificación</th>
                        <th>Docente</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                         <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>

     <div id="cargarDocentesApropiacionSocialWhere" style="display:none">

        <fieldset>
        <legend>  Maestros y maestras acompañantes de procesos de apropiación social que no están en la estrategia No 2. de formación.</legend>
            <a href="javascript:void(0)" onclick="back()" class="btn btn-primary">Regresar</a><br /><br />
        <table width="100%" class="border" id="tablecargarDocentesApropiacionSocialWhere">
                 <thead>
		            <tr>
		                <th>Municipio</th>
		                <th>Institución </th>
                        <th>Sede</th>
                        <th>Identificación</th>
                        <th>Docente</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
		                <td></td>
                         <td></td>
                        <td></td>
                         <td></td>
                         <td></td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>

    </div>
</asp:Content>

