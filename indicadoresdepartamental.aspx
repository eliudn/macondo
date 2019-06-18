<%@ Page Title="Indicadores Departamentales " Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="indicadoresdepartamental.aspx.cs" Inherits="indicadoresdepartamental" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

      <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <script src="js/jquery.table2excel.js"></script>
     <script src="js/dataTables.buttons.min.js"></script>
    <script src="js/jszip.min.js"></script>
   <script src="js/buttons.html5.min.js"></script>


    <script src="js/highcharts.js"></script>
    <script src="js/exporting.js"></script>

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

     <script type="text/javascript">
        $(document).ready(function () {
            floadDetalles();
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%"></div>');
            //Cargar departamento
            //$("#tableList tbody").html("<tr><td colspan=\"7\" style=\"text-align:center;\">Cargando...</td></tr>");
            $.ajax({
                type: 'POST',
                url: 'indicadoresdepartamental.aspx/cargarDepartamentoMagdalena',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "departamento") {
                        $("#departamento").html(resp[1]);
                    }
                }, complete: function () {
                    //$("#institucion").html("");
                    //$("#municipio").html("");
                    //var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                    //$.ajax({
                    //    type: 'POST',
                    //    url: 'indicadoresdepartamental.aspx/cargarMunicipios',
                    //    data: jsondata,
                    //    contentType: 'application/json; charset=utf-8',
                    //    dataType: 'JSON',
                    //    success: function (response) {
                    //        var resp = response.d.split("@");
                    //        if (resp[0] === "municipio") {
                    //            $("#municipio").html(resp[1]);

                    $("#title-report").html("Estudiantes participantes del Departamento del Magdalena");

                            filtro();
                            //}
                    //    }
                    //});
                }
            });

            $("#departamento").on("change", function () {
                //$("#institucion").html("");
                $("#municipio").html("");
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'indicadoresdepartamental.aspx/cargarMunicipios',
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
            //$("#municipio").on("change", function () {
            //    $("#institucion").html("");
            //    $("#sede").html("");
            //    var codMunicipio = $("#municipio").val();
            //    var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
            //    $.ajax({
            //        type: 'POST',
            //        url: 'indicadoresdepartamental.aspx/cargarInstituciones',
            //        data: jsondata,
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        //data:frmserialize,
            //        success: function (json) {
            //            var resp = json.d.split("@");
            //            if (resp[0] === "inst") {
            //                $("#institucion").html(resp[1]);
            //                //alert(resp[0]);

            //            }
            //        }
            //    });
            //});

            //cargando sedes educativas
            //$("#institucion").on("change", function () {
                
            //});



            



        });

        function cargarDataTable() {
            $('#tableList').DataTable({
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
                    "searching": false,
                    "aaSorting" : [[0, 'desc']],
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
              "columns": [ //agregar configuraciones a cada una de las columnas de las tablas
                    { "orderable": false },//column 1
                    { "orderable": false },//column 2
                    { "orderable": false },//column 3
                    { "orderable": false },//column 4
                    { "orderable": false },//column 5
                    { "orderable": false },//column 6
                    { "orderable": false }//column 7
              ],
                dom: 'Bfrtip',
                buttons: [
                    'excel'
                    // 'copy', 'csv', 'excel', 'pdf'
                ]
            });

        }

        function floadDetalles() {
            //$.ajax({
            //    type: 'POST',
            //    url: 'indicadoresdepartamental.aspx/loadreport',
            //    contentType: 'application/json; charset=utf-8',
            //    dataType: 'JSON',
            //    success: function (response) {
            //        //var resp = response.d.split("@");
            //        //if (resp[0] === "lleno") {
            //        $("#tableList tbody").html(response.d);
            //        //}
            //    }, complete: function () {
                    cargarDataTable();
            //    }
            //});
        }


        // realizar busqueda
        function filtro() {
            var table = $('#tableList').DataTable();
            table.destroy();
            //$("#tableList tbody").html("<tr><td colspan=\"8\" style=\"text-align:center;\">Cargando...</td></tr>");
            var codDepartamento = $("#departamento").val();
            var codMunicipio = '';
            var codInstitucion = '';
            var codSede = '';
            var jsondata = "{'coddepartamento':'" + codDepartamento + "', 'codmuncipio':'" + codMunicipio + "', 'codinstitucion':'" + codInstitucion + "', 'codsede':'" + codSede + "'}";
            $.ajax({
                type: 'POST',
                url: 'indicadoresdepartamental.aspx/realizarBusquedaloadreport',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] == "lleno") {
                        $("#tableList tbody").html(resp[1]);

                        var vall = resp[2].split(",");
                        var por = parseFloat(vall[0] + "." + vall[1]);
                        var restante = 100 - por;
                        if (restante < 0) {
                            restante = 0;
                        }
                        //alert(por);
                        Highcharts.chart('container', {
                            chart: {
                                plotBackgroundColor: null,
                                plotBorderWidth: null,
                                plotShadow: false,
                                type: 'pie'
                            },
                            title: {
                                text: 'Porcentaje de ejecución '+ por.toFixed(1)+'% <br/> <span><b>Estudiantes matriculados: </b> ' + resp[4] + ' <br/> <b>Estudiantes en formación:</b> ' + resp[3] + '</span>'
                            },
                            tooltip: {
                                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                            },
                            plotOptions: {
                                pie: {
                                    allowPointSelect: true,
                                    cursor: 'pointer',
                                    dataLabels: {
                                        enabled: true,
                                        format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                                        style: {
                                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                                        }
                                    },
                                    showInLegend: true
                                }
                            },
                            series: [{
                                name: 'Brands',
                                colorByPoint: true,
                                data: [{
                                    name: 'Ejecutado',
                                    y: por
                                },
                                {
                                    name: 'No Ejecutado',
                                    y: restante,
                                    sliced: true,
                                    selected: true
                                }]
                            }]
                        });
                        

                    } else {
                        $("#tableList tbody").html(json.d);
                    }
                }, complete: function () {
                    cargarDataTable();
                    $('.desactivarC1').remove().fadeOut(500);
                }
            });
        }


        function exportExcel() {
            /*var index = this.cellIndex;
            $(this).closest('table').find('tr').each(function () {
                this.removeChild(this.cells[index]);
            });*/

            $("#tableList").table2excel({
                exclude: ".noExl",
                name: "indicadoresdepartamental",
                filename: "indicadoresdepartamental",
                fileext: ".xls"//,
                //exclude_img: true,
                //exclude_links: true,
                //exclude_inputs: true
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <asp:Label Visible="false" runat="server" ID="lblCodUsuario"></asp:Label>

    <div id="mensaje" runat="server"></div><br /><br />
    <h2 >Proyecto Fortalecimiento de una cultura ciudadana y democrática en CT+I a través de la IEP apoyada en TIC en el Departamento del Magdalena </h2>
    <div style="float:right;margin-top:-30px;"><%--<asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" />--%></div>
    <%--<h4 >Sedes educativas que inscribieron grupo de investigación en la convocatoria de Ciclón </h4>--%>
    <%--<p>Miden el número de sedes educativas en las que se organizaron e inscribieron grupos de investigación infantiles y juveniles en Ciclón y diligenciaron la bitácora 01</p>--%>
    
    <br />
    <fieldset>
         <legend>Realizar Búsqueda</legend>
         <table>
                <tr>
                    <td>Departamento: </td>
                    <%--<td>Municipio: </td>--%>
                    <%--<td>Institución Educativa: </td>--%>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <select class="TextBox width-100" name="departamento" id="departamento" style="width: 200px" disabled="true">
                        </select>
                    </td>
                    <td>
                        <%--<select class="TextBox width-100" name="municipio" id="municipio" style="width: 200px">
                        </select>--%>
                    </td>
                    <td>
                        <%--<select class="TextBox width-100" name="institucion" id="institucion" style="width: 200px">
                        </select>--%>
                    </td>
                    <td><input type="button" value="Buscar..." class="btn btn-primary" id="btn-guardar" onclick="filtro();" /></td>
                </tr>
            </table>
     </fieldset>
    <br />
    <h2 id="title-report" style="text-align:center;width: 63%;margin: 0 auto;padding: 15px;"></h2>
    <fieldset>
        <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
    </fieldset>
    <br />
 <fieldset>



     <b>Exportar a:</b>
     <%--<input type="button" value="Excel" class="dt-button" id="btn-exportExcel" onclick="exportExcel();" />--%><br />
     <br />

     <legend>Listado de evidencias</legend>
     
      
     <table width="100%" class="border" id="tableList">
         <thead>
		    <tr>
                <th>No.</th>
		        <th style="width:45%">Municipio</th>
                <th>Total de estudiantes</th>
                <th>Ejecución</th>
                <th>% Ejecución</th>
                <th style="width:15%">Peso</th>
		        <th class="noExl">Detalles</th>
		    </tr>
        </thead>
         <tbody>

         </tbody>
	</table>
      
 </fieldset>
    

</asp:Content>

