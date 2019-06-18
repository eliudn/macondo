<%@ Page Title="Indicadores de Maestros " Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="indicadoresmaestros.aspx.cs" Inherits="indicadoresmaestros" MaintainScrollPositionOnPostback="true" %>

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

     <script type="text/javascript">


         (function ($) {
             $.get = function (key) {
                 key = key.replace(/[\[]/, '\\[');
                 key = key.replace(/[\]]/, '\\]');
                 var pattern = "[\\?&]" + key + "=([^&#]*)";
                 var regex = new RegExp(pattern);
                 var url = unescape(window.location.href);
                 var results = regex.exec(url);
                 if (results === null) {
                     return null;
                 } else {
                     return results[1];
                 }
             }
         })(jQuery);


        $(document).ready(function () {
            //floadDetalles();

            //Cargar departamento
            $("#tableList tbody").html("<tr><td colspan=\"6\" style=\"text-align:center;\">Seleccione Sede Educativa</td></tr>");
            $.ajax({
                type: 'POST',
                url: 'indicadoresmaestros.aspx/cargarDepartamentoMagdalena',
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
                    var jsondata = "{'codDepartamento': '" + $.get("d") + "','codMunicipio': '" + $.get("m") + "', 'codInstitucion': '" + $.get("i") + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'indicadoresmaestros.aspx/cargarInsMun',
                        data: jsondata,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'JSON',
                        success: function (response) {
                            var resp = response.d.split("@");
                            if (resp[0] == "inst") {
                                $("#municipio").html(resp[3]);
                                $("#institucion").html(resp[1]);
                                filtro();

                                var jsondata = "{'codInstitucion':'" + $.get("i") + "','codSede':'" + $.get("s") + "'}";
                                    $.ajax({
                                        type: 'POST',
                                        url: 'indicadoresmaestros.aspx/cargarSedesxInstitucion',
                                        data: jsondata,
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: function (json) {
                                            var resp = json.d.split("@");
                                            if (resp[0] === "sede") {
                                                $("#sede").html(resp[1]);

                                            }
                                        }
                                        , complete: function () {
                                            filtro();
                                        }
                                    });

                                
                                    
                            }
                        }
                    });
                }
            });

            //$("#departamento").on("change", function () {
            //    $("#institucion").html("");
            //    $("#municipio").html("");
            //    var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
            //    $.ajax({
            //        type: 'POST',
            //        url: 'indicadoresmaestros.aspx/cargarMunicipios',
            //        data: jsondata,
            //        contentType: 'application/json; charset=utf-8',
            //        dataType: 'JSON',
            //        success: function (response) {
            //            var resp = response.d.split("@");
            //            if (resp[0] === "municipio") {
            //                $("#municipio").html(resp[1]);

            //            }
            //        }
            //    });
            //});

            //cargando las instituciones
            $("#municipio").on("change", function () {
                $("#institucion").html("");
                $("#sede").html("");
                var codMunicipio = $("#municipio").val();
                var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'indicadoresmaestros.aspx/cargarInstituciones',
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
                    url: 'indicadoresmaestros.aspx/cargarSedesxInstitucion',
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

            //$("#sede").on("change", function () {
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
                    { "orderable": false, "class":"center" },//column 1
                    { "orderable": false },//column 2
                    { "orderable": false },//column 3
                    { "orderable": false },//column 4
                    { "orderable": false },//column 5
                    { "orderable": false }//column 6
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
            //    url: 'indicadoresmaestros.aspx/loadreport',
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
           
            var codDepartamento = $("#departamento").val();
            var codMunicipio = $("#municipio").val();
            var codInstitucion = $("#institucion").val();
            var codSede = $("#sede").val();

            //if (codSede != null) {
            //    if (codSede != "0") {
                    //var table = $('#tableList').DataTable();
                    //table.destroy();
                    $("#tableList tbody").html("<tr><td colspan=\"6\" style=\"text-align:center;\">Cargando...</td></tr>");

                    var jsondata = "{'coddepartamento':'" + codDepartamento + "', 'codmuncipio':'" + codMunicipio + "', 'codinstitucion':'" + codInstitucion + "', 'codsede':'" + codSede + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'indicadoresmaestros.aspx/realizarBusquedaloadreport',
                        data: jsondata,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "lleno") {
                                $("#tableList tbody").html(resp[1]);
                                console.log("true");
                                //alert(resp[2]);

                                var vall = resp[2].split(",");
                                var por = parseFloat(vall[0] + "." + vall[1]);

                                var est = resp[3].split(",");
                                var totalest = parseFloat(est[0] + "." + est[1]);

                                var totall = (por + totalest);

                                var restante = 100 - totall;
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
                                        text: 'Porcentaje de ejecución ' + totall.toFixed(1) + '%'
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
                                            name: 'Docentes',
                                            y: por
                                        },
                                        {
                                            name: 'No Ejecutado',
                                            y: restante,
                                            sliced: true,
                                            selected: true
                                        },
                                        {
                                            name: 'Estudiantes',
                                            y: totalest
                                        }
                                        ]
                                    }]
                                });


                            } else {
                                $("#tableList tbody").html(json.d);
                            }
                        }, complete: function () {
                            
                            if ($("#departamento").val() == "20" && $("#municipio").val() == "") {
                                $("#title-report").html("Maestros y maestras participantes en el departamento del Magdalena");
                            }
                            else if ($("#departamento").val() == "20" && $("#municipio").val() != "" && $("#institucion").val() == "") {
                                $("#title-report").html("Maestros y maestras participantes en el municipio: " + $("#municipio option:selected").text());
                            }
                            else if ($("#departamento").val() == "20" && $("#municipio").val() != "" && $("#institucion").val() != "" && $("#sede").val() == "") {
                                $("#title-report").html("Maestros y maestras participantes en la institución: " + $("#institucion option:selected").text());
                            }
                            else if ($("#departamento").val() == "20" && $("#municipio").val() != "" && $("#institucion").val() != "" && $("#sede").val() != "") {
                                $("#title-report").html("Maestros y maestras participantes en la sede: " + $("#sede option:selected").text());
                            }
                            
                            //cargarDataTable();

                        }
                    });

                //} else {
                //    alert("Seleccione Sede Educativa");
                //}
            //} else {
            //    alert("Seleccione Sede Educativa");
            //}
            
        }
        function indicadoresgeneral() {
            window.location.href = "indicadoresgeneral.aspx";
        }
        function indicadoresestudiantes() {
            window.location.href = "indicadoresestudiantes.aspx?d=" + $("#departamento").val() + "&m=" + $("#municipio").val() + "&i=" + $("#institucion").val() + "&s=" + $("#sede").val();
        }
        function indicadoresmaestros() {
            window.location.href = "indicadoresmaestros.aspx?d=" + $("#departamento").val() + "&m=" + $("#municipio").val() + "&i=" + $("#institucion").val() + "&s=" + $("#sede").val();
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
                    <td><input type="button" value="Buscar..." class="btn btn-primary" id="btn-guardar" onclick="filtro();" /></td>
                </tr>
            </table>
     </fieldset>
    <br />
    <center>
             <a href="javascript:void(0)" class="btn btn-success" onclick="indicadoresgeneral()">Ver general</a>
             <a href="javascript:void(0)" class="btn btn-success" onclick="indicadoresestudiantes()" >Ver indicadores Estudiantes</a>
             <a href="javascript:void(0)" class="btn btn-success" onclick="indicadoresmaestros()" >Ver indicadores Docentes</a>
     </center>
    <br />
    <h2 id="title-report" style="text-align:center;"></h2>
    <fieldset>
        <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
    </fieldset>
    <br />,
   
 <fieldset>

     

     <b>Exportar a:</b>
     <%--<input type="button" value="Excel" class="dt-button" id="btn-exportExcel" onclick="exportExcel();" />--%><br />
     <br />

     <legend>Listado de evidencias</legend>
     
      
     <table width="100%" class="border" id="tableList">
         <thead>
		    <tr>
                <th style="width: 5%;">No.</th>
		        <th style="width: 80%;">Indicador Maestros(as)</th>
                <th>Meta</th>
		        <th>Ejecución</th>
                <th>% Ejecución</th>
                <th style="width: 10%;">Peso</th>
		    </tr>
        </thead>
         <tbody>
         </tbody>
	</table>
      
 </fieldset>
    

</asp:Content>

