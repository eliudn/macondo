<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="menusegestrategia1.aspx.cs" Inherits="menusegestrategia1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">

    <script src="./js/jquery.table2excel.js"></script>

    <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
     <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />


     <script>
         var table;
         $(document).ready(function () {
             cargarDataTable("");
             cargardatos();

            $("#MainContent_accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#MainContent_accordion").attr("style", "visibility:visible;");


             $.ajax({
                 type: 'POST',
                 url: 'indicadoresestudiantes.aspx/cargarDepartamentoMagdalena',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "departamento") {
                         $("#departamento").html(resp[1]);
                     }
                 }, complete: function () {
                     $("#institucion").html("");
                     var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                     $.ajax({
                         type: 'POST',
                         url: 'menusegestrategia1.aspx/cargarInsMun',
                         data: jsondata,
                         contentType: 'application/json; charset=utf-8',
                         dataType: 'JSON',
                         success: function (response) {
                             var resp = response.d.split("@");
                             if (resp[0] == "mun") {
                                 $("#municipio").html(resp[1]);
                             }
                         }
                     });
                 }
             });

            $("#departamento").on("change", function () {
                $("#institucion").html("");
                $("#municipio").html("");
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'indicadoresestudiantes.aspx/cargarMunicipios',
                    data: jsondata,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        var resp = response.d.split("@");
                        if (resp[0] === "municipio") {
                            $("#municipio").html(resp[1]);

                        }
                    }
                });
            });

             //cargando las instituciones
            $("#municipio").on("change", function () {
                $("#institucion").html("");
                $("#sede").html("");
                var codMunicipio = $("#municipio").val();
                var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'indicadoresestudiantes.aspx/cargarInstituciones',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //data:frmserialize,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "inst") {
                            $("#institucion").html(resp[1]);
                            //alert(resp[0]);

                        }
                    }
                });
            });

             //cargando sedes educativas
            $("#institucion").on("change", function () {
                var codInstitucion = $("#institucion").val();
                var codSede = $("#sede").val();
                var jsondata = "{'codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'indicadoresestudiantes.aspx/cargarSedesxInstitucion',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "sede") {
                            $("#sede").html(resp[1]);

                        }
                    }
                });
            });

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
                 url: 'menusegestrategia1.aspx/cargardatos',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     $("#tableList tbody").html(resp);
                 }, complete: function () {
                     
                 }
             });
         }

         function inscribieronconvocatoria() {
             $('#inscribieronconvocatoria').fadeIn(500);
             //$('#filtro').show();
             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#ninosinscribieronconvocatoria').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#tablePrincipal').hide(500);
             $("#tableInscribieronconvocatoria tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/inscribieronconvocatoria',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tableInscribieronconvocatoria tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tableInscribieronconvocatoria");
                 }
             });
         }

         function ninosinscribieronconvocatoria() {
             $('#ninosinscribieronconvocatoria').fadeIn(500);
             //$('#filtro').show();
             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#inscribieronconvocatoria').hide();
             $('#grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#tablePrincipal').hide(500);

             $("#tableNinosInscribieronconvocatoria tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/ninosinscribieronconvocatoria',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tableNinosInscribieronconvocatoria tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tableNinosInscribieronconvocatoria");
                 }
             });
         }

         function grupoinvestigacionpregunta() {
             $('#grupoinvestigacionpregunta').fadeIn(500);
             $('#filtro').show();
             $('#btn_grupoinvestigacionpregunta').show();
             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();
             $('#tablePrincipal').hide();

             $("#tablegrupoinvestigacionpregunta tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacionpregunta',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     table.destroy();
                     var resp = response.d;
                     $("#tablegrupoinvestigacionpregunta tbody").html(resp);
                     
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacionpregunta");
                 }
             });
         }

         function grupoinvestigacionproblema() {
             $('#grupoinvestigacionproblema').fadeIn(500);
             $('#btn_grupoinvestigacionproblema').show();
             $('#filtro').show();

             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();
             $('#tablePrincipal').hide();

             $("#tablegrupoinvestigacionproblema tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacionproblema',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegrupoinvestigacionproblema tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacionproblema");
                 }
             });
         }

         function grupoinvestigacionrecursos() {
             $('#grupoinvestigacionrecursos').fadeIn(500);
             $('#btn_grupoinvestigacionrecursos').show();
             $('#filtro').show();
             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();

             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#tablePrincipal').hide(500);

             $("#tablegrupoinvestigacionrecursos tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacionrecursos',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegrupoinvestigacionrecursos tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacionrecursos");
                 }
             });
         }

         function grupoinvestigacionavancepresupuesto() {
             $('#grupoinvestigacionavancepresupuesto').fadeIn(500);
             $('#btn_grupoinvestigacionavancepresupuesto').show();
             $('#filtro').show();
             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionavancepresupuesto2desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();

             $('#tablePrincipal').hide(500);

             $("#tablegrupoinvestigacionavancepresupuesto tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacionavancepresupuesto',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegrupoinvestigacionavancepresupuesto tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacionavancepresupuesto");
                 }
             });
         }

         function grupoinvestigacionavancepresupuesto2desembolso() {
             $('#grupoinvestigacionavancepresupuesto2desembolso').fadeIn(500);
             $('#btn_grupoinvestigacionavancepresupuesto2desembolso').show();
             $('#filtro').show();
             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();

             $('#tablePrincipal').hide(500);

             $("#tablegrupoinvestigacionavancepresupuesto2desembolso tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacionavancepresupuesto2desembolso',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegrupoinvestigacionavancepresupuesto2desembolso tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacionavancepresupuesto2desembolso");
                 }
             });
         }

         function grupoinvestigacionavancepresupuesto3desembolso() {
             $('#grupoinvestigacionavancepresupuesto3desembolso').fadeIn(500);
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').show();
             $('#filtro').show();
             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();

             $('#tablePrincipal').hide(500);

             $("#tablegrupoinvestigacionavancepresupuesto3desembolso tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacionavancepresupuesto3desembolso',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegrupoinvestigacionavancepresupuesto3desembolso tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacionavancepresupuesto3desembolso");
                 }
             });
         }

         function grupoinvestigacioninformesinvestigacion() {
             $('#grupoinvestigacioninformesinvestigacion').fadeIn(500);
             $('#btn_grupoinvestigacioninformesinvestigacion').show();
             $('#filtro').show();
             $('#btn_gruposinvestigacionasesoriasrealizadas').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#gruposinvestigacionasesoriasrealizadas').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();

             $('#tablePrincipal').hide(500);

             $("#tablegrupoinvestigacioninformesinvestigacion tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/grupoinvestigacioninformesinvestigacion',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegrupoinvestigacioninformesinvestigacion tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegrupoinvestigacioninformesinvestigacion");
                 }
             });
         }

         function gruposinvestigacionasesoriasrealizadas() {
             $('#gruposinvestigacionasesoriasrealizadas').fadeIn(500);
             $('#btn_gruposinvestigacionasesoriasrealizadas').show();
             $('#filtro').show();
             $('#btn_grupoinvestigacioninformesinvestigacion').hide();
             $('#btn_grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#btn_grupoinvestigacionavancepresupuesto').hide();
             $('#btn_grupoinvestigacionrecursos').hide();
             $('#btn_grupoinvestigacionproblema').hide();
             $('#btn_grupoinvestigacionpregunta').hide();
             $('#btn_inscribieronconvocatoria').hide();
             $('#btn_ninosinscribieronconvocatoria').hide();

             $('#grupoinvestigacioninformesinvestigacion').hide();
             $('#grupoinvestigacionavancepresupuesto3desembolso').hide();
             $('#grupoinvestigacionavancepresupuesto').hide();
             $('#grupoinvestigacionrecursos').hide();
             $('#grupoinvestigacionproblema').hide();
             $('#grupoinvestigacionpregunta').hide();
             $('#inscribieronconvocatoria').hide();
             $('#ninosinscribieronconvocatoria').hide();

             $('#tablePrincipal').hide(500);

             $("#tablegruposinvestigacionasesoriasrealizadas tbody").html('<td colspan="8" style="text-align:center;">Cargando...</td>');
             var jsonData = "{'codDepartamento': '" + $("#departamento").val() + "','codMunicipio': '" + $("#municipio").val() + "', 'codInstitucion': '" + $("#institucion").val() + "', 'codSede': '" + $("#sede").val() + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'menusegestrategia1.aspx/gruposinvestigacionasesoriasrealizadas',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 data: jsonData,
                 success: function (response) {
                     var resp = response.d;
                     table.destroy();
                     $("#tablegruposinvestigacionasesoriasrealizadas tbody").html(resp);
                 }, complete: function () {
                     cargarDataTable("#tablegruposinvestigacionasesoriasrealizadas");
                 }
             });
         }

    </script>
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

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>

    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false" ></asp:Label>

 <br /><br />
    <h2>Estrategia</h2>
    <div id="accordion" runat="server" >
         
     </div>
    Exportar a 
        <a href="javascript:void(0);" class="btn btn-success" style="padding: 5px 12px;" onclick="exportarExcel('tableList','Estrategia No. 1')">Excel</a>
        <br />
        <br />

    <div id="filtro" style="display:none">

        <fieldset>
         <legend>Realizar Búsqueda</legend>
         <table>
                <tr>
                    <td>Departamento: </td>
                    <td>Municipio: </td>
                    <td>Institución Educativa: </td>
                    <td>Sede Educativa: </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <select class="TextBox width-100" name="departamento" id="departamento" style="width: 200px" disabled="true">
                        </select>
                    </td>
                    <td>
                        <select class="TextBox width-100" name="municipio" id="municipio" style="width: 200px">
                        </select>
                    </td>
                    <td>
                        <select class="TextBox width-100" name="institucion" id="institucion" style="width: 200px">
                        </select>
                    </td>
                    <td>
                        <select class="TextBox width-100" name="sede" id="sede" style="width: 200px">
                        </select>
                    </td>
                    <td>
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacionpregunta" onclick="grupoinvestigacionpregunta();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacionproblema" onclick="grupoinvestigacionproblema();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacionrecursos" onclick="grupoinvestigacionrecursos();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacionavancepresupuesto" onclick="grupoinvestigacionavancepresupuesto();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacionavancepresupuesto2desembolso" onclick="grupoinvestigacionavancepresupuesto2desembolso();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacionavancepresupuesto3desembolso" onclick="grupoinvestigacionavancepresupuesto3desembolso();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_grupoinvestigacioninformesinvestigacion" onclick="grupoinvestigacioninformesinvestigacion();" />
                        <input type="button" value="Buscar..." class="btn btn-primary" style="display:none" id="btn_gruposinvestigacionasesoriasrealizadas" onclick="gruposinvestigacionasesoriasrealizadas();" />
                    </td>
                </tr>
            </table>
     </fieldset>

    </div>

    <div id="tablePrincipal">
        <fieldset>

         <legend>No. 1</legend>
     
      
              <table width="100%" class="border" id="tableList">
                 <thead>
		            <tr>
		                <th>Nombre indicador</th>
                        <th>Meta</th>
                        <th>Ejecución</th>
                        <th> % Ejecución</th>
                        <th>Peso</th>
		                <th class="noExl">Detalles</th>
		                <%--<th>Cantidad</th>
                        <th>Ejecución</th>
                        <th>Peso</th>
		                <th class="noExl">Detalles</th>--%>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="5" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

    </fieldset>
    </div>

    <div id="inscribieronconvocatoria" style="display:none">
        <fieldset>

         <legend>Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón</legend>
     
              <a href="javascript:void(0)" onclick="$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tableInscribieronconvocatoria">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Pregunta</th>
                        <th>Tipo</th>
		                <th>Línea</th>
		                <th>Concepto</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="ninosinscribieronconvocatoria" style="display:none">
        <fieldset>

         <legend>Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles en la convocatoria Ciclón</legend>
     
              <a href="javascript:void(0)" onclick="$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tableNinosInscribieronconvocatoria">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Identificación</th>
                        <th>Nombre</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="grupoinvestigacionpregunta" style="display:none">
        <fieldset>

         <legend>Grupos de investigación con preguntas y grupos preestructurados con avances</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacionpregunta">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="grupoinvestigacionproblema" style="display:none">
        <fieldset>

         <legend>Grupos de investigación con problemas y grupos preestructurados con avances</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacionproblema">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="grupoinvestigacionrecursos" style="display:none">
        <fieldset>

         <legend>Grupos de investigación con recursos aportados por Ciclón</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacionrecursos">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>
    
    <div id="grupoinvestigacionavancepresupuesto" style="display:none">
        <fieldset>

         <legend>Grupos de investigación con registro de avance del presupuesto</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacionavancepresupuesto">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="grupoinvestigacionavancepresupuesto2desembolso" style="display:none">
        <fieldset>

         <legend>Grupos de investigación con registro de avance segundo desembolso</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacionavancepresupuesto2desembolso">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="grupoinvestigacionavancepresupuesto3desembolso" style="display:none">
        <fieldset>

         <legend>Grupos de investigación con registro de avance tercer desembolso</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacionavancepresupuesto3desembolso">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="grupoinvestigacioninformesinvestigacion" style="display:none">
        <fieldset>

         <legend>Informes de investigación elaborados por los grupos de investigación infantiles y juveniles</legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegrupoinvestigacioninformesinvestigacion">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>

    <div id="gruposinvestigacionasesoriasrealizadas" style="display:none">
        <fieldset>

         <legend>Asesorias realizadas a cada uno de los grupos de investigación </legend>
     
              <a href="javascript:void(0)" onclick="$('#filtro').hide();$('#gruposinvestigacionasesoriasrealizadas').hide();$('#grupoinvestigacioninformesinvestigacion').hide();$('#grupoinvestigacionavancepresupuesto3desembolso').hide();$('#grupoinvestigacionavancepresupuesto2desembolso').hide();$('#grupoinvestigacionavancepresupuesto').hide();$('#grupoinvestigacionrecursos').hide();$('#grupoinvestigacionproblema').hide();$('#grupoinvestigacionpregunta').hide();$('#ninosinscribieronconvocatoria').hide();$('#inscribieronconvocatoria').hide();$('#tablePrincipal').fadeIn(500);" class="btn btn-primary">Regresar</a>
            <br /><br />  
            <table width="100%" class="border" id="tablegruposinvestigacionasesoriasrealizadas">
                 <thead>
		            <tr>
		                <th>No.</th>
                        <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Nombre grupo</th>
		            </tr>
                </thead>
                 <tbody>
                     <tr>
                         <td colspan="8" style="text-align:center;">Sin resultados</td>
                     </tr>

                 </tbody>
	        </table>

        </fieldset>
    </div>
</asp:Content>

