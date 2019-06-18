<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras004.aspx.cs" Inherits="estras004" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
   <script src="jquery.js"></script>
    <%--<script src="s003/tinymce.min.js"></script>--%>
   <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
 
    <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
     <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />
 
     <%--<link rel="stylesheet" href="css/paginacion.css">--%>
   <style>
        body {
            font-family: arial;
        }

        fieldset {
            padding: 10px;
        }

        table.border td, table.border th {
           border: 1px solid;
            margin: 0;
            padding: 0;
        }

        table.border tr, table.border {
            margin: 0;
            padding: 0;
        }

        .width-100 {
            width: 100%;
        }

        .width-40 {
            width: 40px;
        }

        table.padding tr, table.padding {
            padding: 5px;
            margin: 5px;
        }

        .width-90 {
            width: 90%;
        }

 /*
        .pagination li {
  display: inline-block;
  border-radius: 2px;
  text-align: center;
  vertical-align: top;
  height: 30px;
}

.pagination li a {
  color: #444;
  display: inline-block;
  font-size: 1rem;
  padding: 0 10px;
  line-height: 30px;
}

.pagination li.active a {
  color: #fff;
}

.pagination li.active {
  background-color: #ee6e73;
}

.pagination li.disabled a {
  cursor: default;
  color: #999;
}

.pagination li i {
  font-size: 2rem;
}

.pagination li.pages ul li {
  display: inline-block;
  float: none;
}

@media only screen and (max-width: 992px) {
  .pagination {
    width: 100%;
  }
  .pagination li.prev,
  .pagination li.next {
    width: 10%;
  }
  .pagination li.pages {
    width: 80%;
    overflow: hidden;
    white-space: nowrap;
  }*/
}

    </style>

    <script>
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);

        var total = 1;
        var codigoestrategia;
        var sesion;
        var codmemoria;
        var insert;
        var idred;
        $(document).ready(function () {

            verificarPaginado();

            reset();
            $("#add").click(function () {

                if ($.trim($("#pregunta" + total).val()) != '') {

                    total = parseInt(total) + 1;
                    // alert(total);
                    if ($("#remove")) {
                        $("#remove").remove();
                    }
                    html = '<tr id="campus' + total + '">';


                    html += '<td>' + total + '.</td>';
                    html += '<td id="radiotr' + total + '"><input type="text" id="pregunta' + total + '" name="pregunta' + total + '" class="width-90 TextBox"><button id="remove" onclick="fRemove(' + total + ')" class="btn btn-danger">-</button></td></tr>';
                    $("#tablecampus").append(html);
                }
                else {
                    alert("ingrese la pregunta No. " + total + ", para poder agregar una nueva");
                    $("#pregunta" + total).focus();
                }
            });

            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/cargarnomasesor',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "nombre") {
                        $("#nombreapellidorelator").val(resp[1]);
                    }
                }
            });

            //Cargar departamento
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/cargarDepartamentoMagdalena',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "departamento") {
                        $("#departamento").html(resp[1]);
                    }
                }
            });

            $("#departamento").on("change", function () {
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estras004.aspx/cargarMunicipioMagdalena',
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
                var codMunicipio = $("#municipio").val();
                cargarinstituciones(codMunicipio);
            });
            



            //cargando sedes segun institucion seleccionada
            $("#institucion").change(function () {
                //reset();
                var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras004.aspx/cargarsedes',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "sedes") {
                            $("#sede").html(resp[1]);
                        }
                    }
                });
            });

            //cargando redes segun sede seleccionada
            $("#sede").change(function () {
                //reset();
                var jsonData = '{ "codsede":"' + $("#sede").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras004.aspx/cargarRedtematica',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "redtematica") {
                            $("#redtematica").append(resp[1]);
                        }
                    }
                });
            });
            
            //$("#redtematica").change(function () {
            //    reset();
            //    loadInstrumento($("#redtematica").val());
            //});

            $(".datepicker").datepicker({ changeYear: true, changeMonth: true });
        });

        function buscarSesionMemoria(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/buscarSesionMemoria',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    var resp = response.d.split("@");
                    $("#infosesion").html(resp[1]);
                    sesion = resp[0];
                    codmemoria = codigo;
                }
            });
        }

        function guardarSesion() {
            var jsondata = "{'codmemoria':'" + codmemoria + "', 'sesion':'" + $("#sesion").val() + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/guardarSesion',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    alert("Sesión modificada con éxito");
                    $("#modificarsesion").hide();
                    $("#formTable").hide();
                    $("#listTable").fadeIn(500);
                    cargarListadoMemorias();
                }
            });
        }

        function verificarPaginado() {

            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/verificarPaginado',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    if (response.d === "1") {
                        cargarListadoMemorias();
                    } else {
                        cargarListadoMemorias();
                    }
                }
            });
        }

        function cargarTemas() {

            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/cargarTemas',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#temasesion").val(response.d);
                }
            });
        }

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

        function cargarListadoMemorias() {
            //$("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            //var jsondata = "{'page':'" + page + "'}";

            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/cargarListadoMemoriaAsesor',
                //data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {

                    var resp = response.d.split("@");

                    $("#infoListTable tbody").html(resp[0]);
                    //$("#paginacion").html(resp[1]);
                },
                complete: function () {
                    cargarDataTable();
                }
            });
        }

        function fRemove(data) {
            // alert(data);
            var ant = data - 1;
            total = total - 1;
            $("#campus" + data).remove();
            $("#radiotr" + ant).append('<button id="remove" onclick="fRemove(' + ant + ')" class="btn btn-danger">-</button>');
        }


        function cargarinstituciones(codMunicipio) {
            var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/cargarInstituciones',
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
        }

        function reset() {
            //$("#departamento").val('');
            //$("#municipio").val('');
            //$("#institucion").val('');
            //$("#sede").val('');
            $("#nombresesion").val('GÓZATE LA CIENCIA Y MEJORA TUS CAPACIDADES INVESTIGATIVAS A TRAVÉS DE COMUNIDADES VIRTUALES COMO ESTRATEGIA PARA CONFORMAR LA COMUNIDAD DE PRÁCTICA, APRENDIZAJE, SABER, CONOCIMIENTO Y TRANSFORMACIÓN');
            $("#temasesion").val('Conformación de la comunidad de estudiantes que se gozan la ciencia y mejoran sus capacidades investigativas a través de comunidades virtuales');
            $("#informacionadicional").val('');
            $("#fechaelaboracion").val('');

            $("#horasesion").val('');
            $("#horasesionfinal").val('');
            //$("#pregunta1").val('');
            $("#nombreapellidorelator").val('');
            $("#nohoras").val('');
            //$("#nosesiones").val('');

            document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_desarrollo1_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_compromisos_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';

            html = '<tr>';
            html += '<th>No.</th>';
            html += '<th></th>';
            html += '</th>';
            html += '</tr>';
            html += '<tr >';
            html += '<td>1.</td>';
            //html += '<td><input type="text" class="TextBox width-90" id="pregunta1" name="pregunta1" ></td>';
            html += '</tr>';
            $("#tablecampus").html(html);
            total = 1;
        }


        function enviarestras004(event) {
            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione Nombre de la entidad y / o Institución Educativa: ");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione Sede");
                $("#sede").focus();
            }
            //else if ($.trim($("#redtematica").val()) == '') {
            //    alert("Por favor, seleccione Red Temática");
            //    $("#redtematica").focus();
            //}
            else if ($.trim($("#nombresesion").val()) == '') {
                alert("Por favor, ingrese Nombre de sesión o actividad de formación");
                $("#nombresesion").focus();
            } else if ($.trim($("#temasesion").val()) == '') {
                alert("Por favor, ingrese Tema de la sesión o actividad de formación");
                $("#temasesion").focus();
            }
                //else if ($.trim($("#informacionadicional").val()) == '') {
                //    alert("Por favor, ingrese Información adicional: ");
                //    $("#informacionadicional").focus();
                //}
            else if ($.trim($("#fechaelaboracion").val()) == '') {
                alert("Por favor, ingrese Fecha de la elaboración de la memoría");
                $("#fechaelaboracion").focus();
            } else if ($.trim($("#horasesion").val()) == '') {
                alert("Por favor, ingrese Hora Inicial de la sesión de formación");
                $("#horasesion").focus();
            } else if ($.trim($("#horasesionfinal").val()) == '') {
                alert("Por favor, ingrese Hora Final de formación");
                $("#horasesionfinal").focus();
            } else if ($.trim($("#nombreapellidorelator").val()) == '') {
                alert("Por favor, ingrese Nombres y apellidos del docente Asesor");
                $("#nombreapellidorelator").focus();
                //} else if ($.trim($("#pregunta" + total).val()) == '') {
                //    alert("ingrese la pregunta No. " + total + "");
                //    $("#pregunta" + total).focus();
            } else if ($.trim($("#nohoras").val()) == '') {
                alert("Por favor, ingrese el número de horas presenciales de esta(s) red(es)");
                $("#nohoras").focus();
            }
            //else if ($.trim($("#nosesiones").val()) == '') {
            //    alert("Por favor, ingrese el número de sesiones realizadas");
            //    $("#nohoras").focus();
            //}
            else if ($.trim(document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese el punto 2. del Desarrollo de la Memoria");
            } else if ($.trim(document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese conclusiones");
            } else if ($.trim(document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Recursos Pedagogicos ");
            } else if ($.trim(document.getElementById('MainContent_desarrollo1_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese el punto 1. del Desarrollo de la Memoria ");
            } else if ($.trim(document.getElementById('MainContent_compromisos_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Compromisos ");
            } else if ($.trim(document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Evaluación de la Sesión ");
            }
            else {
                var aspectosdesarrollados = document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var conclusiones = document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var bibliografia = document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var desarrollo1 = document.getElementById('MainContent_desarrollo1_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var compromisos = document.getElementById('MainContent_compromisos_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var evaluacionsesion = document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML;

                if (event == 'insert') {
                    var save;
                    var check = $("input[type='checkbox']:checked").length;
                    $("input[name=redestematicas]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData = "{ 'redtematica':'" + $(this).val() + "', 'nombresesion':'" + $("#nombresesion").val() + "', 'temasesion':'" + $("#temasesion").val() + "', 'informacionadicional':'" + $("#informacionadicional").val() + "', 'fechaelaboracion':'" + $("#fechaelaboracion").val() + "', 'nombrerelator':'" + $("#nombreapellidorelator").val() + "', 'horasesion':'" + $("#horasesion").val() + "', 'horasesionfinal':'" + $("#horasesionfinal").val() + "', 'aspectosdesarrollados':'" + aspectosdesarrollados + "', 'conclusiones':'" + conclusiones + "', 'bibliografia':'" + bibliografia + "', 'desarrollo1':'" + desarrollo1 + "', 'compromisos':'" + compromisos + "', 'evaluacionsesion':'" + evaluacionsesion + "', 'nohoras':'" + $("#nohoras").val() + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'estras004.aspx/insertestras004',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData,
                                success: function (json) {
                                    var resp = json.d.split("@");
                                    if (resp[0] === "true") {
                                        codigoestrategia = resp[1];
                                        //$("#formTable").hide();
                                        //$("#listTable").fadeIn(500);
                                        //cargarListadoMemorias("1");
                                        //reset();
                                        insert = parseInt(insert) + 1;
                                        save = "true";
                                    } else {
                                        alert(resp[1]);
                                    }   
                                }
                                //, complete: function () {
                                //    finsertpreguntas();
                                //}
                            });
                        }
                    });

                    if (check == "") {
                        alert("Seleccione por lo menos una red temática para continuar.");
                    } else {
                        alert("instrumento insertado exitosamente");
                        btnregresar();
                    }
                    //if (insert == 0) {
                       
                    //}
                    //else {
                    //    alert("instrumento insertado exitosamente");
                    //    insert = 0;
                    //    btnregresar();
                    //}

                } else if (event == 'update') {
                    var jsonData = "{  'codigoestrategia':'" + codigoestrategia + "', 'redtematica':'" + $("#redtematica_" + idred).val() + "', 'nombresesion':'" + $("#nombresesion").val() + "', 'temasesion':'" + $("#temasesion").val() + "', 'informacionadicional':'" + $("#informacionadicional").val() + "', 'fechaelaboracion':'" + $("#fechaelaboracion").val() + "', 'nombrerelator':'" + $("#nombreapellidorelator").val() + "', 'horasesion':'" + $("#horasesion").val() + "', 'horasesionfinal':'" + $("#horasesionfinal").val() + "', 'aspectosdesarrollados':'" + aspectosdesarrollados + "', 'conclusiones':'" + conclusiones + "', 'bibliografia':'" + bibliografia + "', 'desarrollo1':'" + desarrollo1 + "', 'compromisos':'" + compromisos + "', 'evaluacionsesion':'" + evaluacionsesion + "', 'nohoras':'" + $("#nohoras").val() + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estras004.aspx/updateestras004',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                //codigoestrategia = codigoestrategia;
                                alert("instrumento actualizado exitosamente");
                                btnregresar();
                                //$("#formTable").hide();
                                //$("#listTable").fadeIn(500);
                                //cargarListadoMemorias("1");
                                //reset();
                            } else {
                                alert(resp[1]);
                            }
                        }
                        //, complete: function () {
                        //    finsertpreguntas();
                        //}
                    });
                }
                //$("#redtematica").remove();
            }
        }


        function loadInstrumento(codigo) {
            var jsonData = "{ 'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/loadestras004',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    //console.log(json);
                    loadSelectInstrumento(codigo);
                    //loadEvidencias(codigo)
                    var resp = json.d.split("estras004p");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];
                        $("#nombresesion").val(resp[2]);
                        $("#temasesion").val(resp[3]);
                        $("#informacionadicional").val(resp[4]);
                        //var fechahora = resp[5].split(" ");

                        $("#fechaelaboracion").val(resp[5]);
                        //var hora = fechahora[1].split(":");
                        //if (hora[0] < 10) {
                        //    hora[0] = "0" + hora[0];
                        //}
                        $("#horasesion").val(resp[13]);
                        $("#horasesionfinal").val(resp[14]);
                        $("#nombreapellidorelator").val(resp[6]);

                        document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[7];
                        document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[8];
                        document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[9];
                        document.getElementById('MainContent_desarrollo1_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[10];
                        document.getElementById('MainContent_compromisos_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[11];
                        document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[12];

                        $("#nohoras").val(resp[15]);
                        //$("#nosesiones").val(resp[16]);

                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestras004(\'update\')');
                        //loadSelectInstrumento(codigo);
                        //floadPreguntaas(codigoestrategia);


                    } else if (resp[0] === "vacio") {
                        html = '<tr>';
                        html += '<th>No.</th>';
                        html += '<th></th>';
                        html += '</th>';
                        html += '</tr>';
                        html += '<tr >';
                        html += '<td>1.</td>';
                        html += '<td><input type="text" class="TextBox width-90" id="pregunta1" name="pregunta1" ></td>';
                        html += '</tr>';
                        $("#tablecampus").html(html);
                        total = 1;

                        $('#btn-guardar').attr('value', 'Guardar todo');
                        $('#btn-guardar').attr('onclick', 'enviarestras004(\'insert\')');
                    } else {
                        alert("Ocurrio un error");
                    }
                }
            });
        }

        function loadSelectInstrumento(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/loadSelectInstrumento',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "loadSelect") {
                        $("#departamento").html(resp[1]);
                        $("#municipio").html(resp[2]);
                        $("#institucion").html(resp[3]);
                        $("#sede").html(resp[4]);
                        //$('#redtematica').add();
                        $("#redtematica").append(resp[5]);
                        idred = resp[6];
                    }
                }
            });
        }

        function btnregresar() {
            $.ajax({
                type: "POST",
                url: "estras004.aspx/regresar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    window.location.href = "estras004.aspx?e=" + resp[0] + "&m=" + resp[1] + "&s=" + resp[2];
                }
            });
        }

        function finsertpreguntas() {
            var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '"}';
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/deletePreguntass004',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {

                        for (var i = 1; i <= total; i++) {
                            var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "nopregunta":"' + i + '", "pregunta":"' + $("#pregunta" + i).val() + '"}';
                            $.ajax({
                                type: 'POST',
                                url: 'estras004.aspx/insertPreguntas',
                                data: jsonData,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    var resp = data.d.split("@");
                                    if (resp[0] === "true") {
                                        console.log("pregunta " + i + "insertado exitosamente");
                                    } else {
                                        console.error(data.d + " " + i);
                                        //console.error(data.d);
                                    }
                                    //alert("registro guardado exitosamente");
                                    btnregresar();
                                }
                            });
                        }

                    } else {
                        alert(data.d);
                    }
                }
                //,
                //complete: function () {
                    
                //    //$('#btn-guardar').attr('value', 'Actualizar');
                //    //$('#btn-guardar').attr('onclick', 'enviarestras004(\'update\')');
                //    //$("#formTable").hide();
                //    //$("#listTable").fadeIn(500);
                //    $.ajax({
                //        type: "POST",
                //        url: "estras004.aspx/regresar",
                //        contentType: "application/json; charset=utf-8",
                //        dataType: "json",
                //        success: function (json) {
                //            var resp = json.d.split("@");
                //            window.location.href = "estras004.aspx?e=" + resp[0] + "&m=" + resp[1] + "&s=" + resp[2];
                //        }
                //    });
                //    //cargarListadoMemorias("1");
                //    //reset();
                //}
            });
        }

        //funcion para traer todo los materiales
        function floadPreguntaas(codigoestrategia) {
            total = 1;
            var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "total":' + total + '}';
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/loadPreguntass004',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "mat") {
                        $("#tablecampus").html(resp[1]);
                        total = resp[2];
                    } else {
                        $("#tablecampus").html(resp[1]);
                    }
                }
            });
        }

        function loadEvidencias(codigo) {
            var jsonData = '{ "codigo":"' + codigo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estras004.aspx/loadEvidencias',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#evidencias").show();
                    var resp = data.d.split("@");
                    if (resp[0] === "evidencias") {
                        $("#tbodyinfo").html(resp[1]);
                    } else if (resp[0] === "vacio") {
                        $("#tbodyinfo").html(resp[1]);
                    }
                }
            });
        }

        function resetSelect(){
            $("#departamento").val("");
            $("#municipio").val("");
            $("#institucion").val("");
            $("#sede").val("");
           
            $('#btn-guardar').attr('value', 'Guardar todo');
            $('#btn-guardar').attr('onclick', 'enviarestras004(\'insert\')');
        }

       

        //Modal subir evidencias
        //function uploadImagen() {
        //    $("#dialog").dialog({
        //        height: "auto",
        //        width: "auto",
        //        modal: true,
        //        buttons: {
        //            "Subir imagen": function (e) {

        //                var actividades = $('input:radio[name=actividad]:checked').val();
        //                var trepador = $('input[type=file]')[0].id;
                        
        //                //console.log(trepador);
        //                uploadFileServer(actividades, trepador);
        //            }
        //        }
        //    });
        //}

        //Subir evidencias al server
        //function uploadFileServer(actividad, trepador) {
        //    //var datajson = "{'fileName':'" + name + "', 'fileSize': '" + size + "', 'fileType': '" + type + "', 'fileExt': '" + ext + "', 'actividades':'" + actividad + "'}";
        //    var jsondata = "{'actividades':'" + actividad + "', 'trepador': '" + trepador + "'}";
        //    $.ajax({
        //        type: "POST",
        //        url: "estras004.aspx/uploadFileServer",
        //        data: jsondata,
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (response) {
        //            var resp = response.d.split("@");
        //            if (resp[0] == "uploadImage") {
        //                alert(resp[1]);
        //                $("#dialog").dialog("close");
        //            }
        //        }
        //    });
        //}
    </script>

   
     <script type="text/javascript">
       

         function evidencias(codigo) {
             $("#listTable").hide();
             $("#evidencias").fadeIn(500);

             //alert(codigo);
             var jsonData = '{ "codigo":"' + codigo + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'estras004.aspx/evidencias',
                 data: jsonData,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json"
                
             });
         }

         function eliminar(codigo) {
             if (confirm('¿Estás seguro de eliminar esta Memoria?')) {
                 var jsonData = "{ 'codigo':'" + codigo + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'estras004.aspx/deleteestras004',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     data: jsonData,
                     success: function (json) {
                         var resp = json.d.split("@");
                         if (resp[0] === "delete") {
                             var jsonData = "{ 'codigoestrategia':'" + codigo + "'}";
                             $.ajax({
                                 type: 'POST',
                                 url: 'estras004.aspx/deletePreguntass004',
                                 data: jsonData,
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 success: function (data) {
                                     //cargarListadoMemorias();
                                     alert('Dato eliminado correctamente.');
                                     btnregresar();

                                     } 
                             });
                            
                         }
                     }
                 });
             }
            
         }

         function isNumberKey(e) {
             var charCode = (e.which) ? e.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 75))
                 return false;
             return true;
         }

     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. <asp:Label runat="server" ID="lblEstrategia" Visible="true"></asp:Label> -  S004: Memoria de los espacios de formación o apropiación social</h2>
    <asp:Label ID="lblCodMomento" runat="server" Visible="false"></asp:Label>
<asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodRedTematicaSede" Visible="true"></asp:Label>

    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
    <div id="listTable">
        <%--<button class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500)">Nueva memoria</button>--%>
        <a class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500), resetSelect(); cargarTemas();">Nueva memoria</a>
        <br /><br /><br />
        <fieldset>
            <table class="mGridTesoreria" id="infoListTable">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Departamento</th>
                        <th>Municipio</th>
                        <th>Institucion</th>
                        <th>Sede</th>
                        <th>Sesión</th>
                        <th>Red tematica</th>
                        <th>Fecha elaboración</th>
                        <th>Momento</th>
                        <th>Sesión</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody >

                </tbody>
            </table>
            <%--<ul id="paginacion" class="pagination">
            </ul>--%>
        </fieldset>
    </div>
    <div id="formTable" style="display:none;">
        <fieldset>
    <table width="100%">
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Departamento </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="departamento" id="departamento">
                                <option value="">Seleccione departamento</option>
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Municipio </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="municipio" id="municipio">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de la entidad y / o Institución Educativa: </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="institucion" id="institucion">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Sede: </td>
                        <td width="70%">
                            <select name="sede" id="sede" class="width-100 TextBox">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%"><asp:label ID="lblTipoGrupo" runat="server" Visible="true"></asp:label>: </td>
                        <td width="70%">
                            <div id="redtematica"></div>
                           <%-- <select name="redtematica" id="redtematica" class="width-100 TextBox">
                                <option value="">Seleccione...</option>
                            </select>--%></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Número de sesiones realizadas </td>
                        <td width="70%">
                        <select id="nosesiones" class="TextBox" style="width:100px;">
                            <option value="" disabled>Seleccione sesión</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                        </select>    
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de sesión o actividad de formación: </td>
                        <td width="70%">
                            <input type="text" id="nombresesion" name="nombresesion" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Tema de la sesión o actividad de formación: </td>
                        <td width="70%">
                            <input type="text" id="temasesion" name="temasesion" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td width="100%" colspan="2" style="display:none">
                <table width="100%">
                    <tr>
                        <td width="30%">Información adicional: </td>
                        <td width="70%">
                            <input  type="hidden" id="informacionadicional" name="informacionadicional" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="55%">
                <table width="100%">
                    <tr>
                        <td width="30%">Fecha de la formación: </td>
                        <td width="100%">
                            <input type="text" id="fechaelaboracion" name="fechaelaboracion" class="width-100 TextBox datepicker" /></td>
                    </tr>
                </table>
            </td>
    </tr>
    <tr>
        <td width="100%" colspan="2">
            <table width="100%">
                <tr>
                    <td width="30%">No. Horas presencial por red: </td>
                    <td width="70%">
                        <input type="text" id="nohoras" name="nohoras" class="width-100 TextBox" style="width:50px;" onkeypress="return isNumberKey(event);" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>  
            <table>
       <td width="30%">Hora de formación presencial en la Sede: </td>
       <td width="0%">
            <td width="23%">
                <table width="100%">
                    <tr>
                        <td width="50%">Hora Inicial:</td>
                        <td width="100%">
                            <select class="TextBox width-50" name="horasesion" id="horasesion">
                                <option value="">Seleccione hora</option>
                                <option value="00:00">00:00</option>
                                <option value="00:15">00:15</option>
                                <option value="00:30">00:30</option>
                                <option value="00:45">00:45</option>

                                <option value="01:00">01:00</option>
                                <option value="01:15">01:15</option>
                                <option value="01:30">01:30</option>
                                <option value="01:45">01:45</option>

                                <option value="02:00">02:00</option>
                                <option value="02:15">02:15</option>
                                <option value="02:30">02:30</option>
                                <option value="02:45">02:45</option>

                                <option value="03:00">03:00</option>
                                <option value="03:15">03:15</option>
                                <option value="03:30">03:30</option>
                                <option value="03:45">03:45</option>

                                <option value="04:00">04:00</option>
                                <option value="04:15">04:15</option>
                                <option value="04:30">04:30</option>
                                <option value="04:45">04:45</option>

                                <option value="05:00">05:00</option>
                                <option value="05:15">05:15</option>
                                <option value="05:30">05:30</option>
                                <option value="05:45">05:45</option>

                                <option value="06:00">06:00</option>
                                <option value="06:15">06:15</option>
                                <option value="06:30">06:30</option>
                                <option value="06:45">06:45</option>

                                <option value="07:00">07:00</option>
                                <option value="07:15">07:15</option>
                                <option value="07:30">07:30</option>
                                <option value="07:45">07:45</option>

                                <option value="08:00">08:00</option>
                                <option value="08:15">08:15</option>
                                <option value="08:30">08:30</option>
                                <option value="08:45">08:45</option>

                                <option value="09:00">09:00</option>
                                <option value="09:15">09:15</option>
                                <option value="09:30">09:30</option>
                                <option value="09:45">09:45</option>

                                <option value="10:00">10:00</option>
                                <option value="10:15">10:15</option>
                                <option value="10:30">10:30</option>
                                <option value="10:45">10:45</option>

                                <option value="11:00">11:00</option>
                                <option value="11:15">11:15</option>
                                <option value="11:30">11:30</option>
                                <option value="11:45">11:45</option>

                                <option value="12:00">12:00</option>
                                <option value="12:15">12:15</option>
                                <option value="12:30">12:30</option>
                                <option value="12:45">12:45</option>

                                <option value="13:00">13:00</option>
                                <option value="13:15">13:15</option>
                                <option value="13:30">13:30</option>
                                <option value="13:45">13:45</option>

                                <option value="14:00">14:00</option>
                                <option value="14:15">14:15</option>
                                <option value="14:30">14:30</option>
                                <option value="14:45">14:45</option>

                                <option value="15:00">15:00</option>
                                <option value="15:15">15:15</option>
                                <option value="15:30">15:30</option>
                                <option value="15:45">15:45</option>

                                <option value="16:00">16:00</option>
                                <option value="16:15">16:15</option>
                                <option value="16:30">16:30</option>
                                <option value="16:45">16:45</option>

                                <option value="17:00">17:00</option>
                                <option value="17:15">17:15</option>
                                <option value="17:30">17:30</option>
                                <option value="17:45">17:45</option>

                                <option value="18:00">18:00</option>
                                <option value="18:15">18:15</option>
                                <option value="18:30">18:30</option>
                                <option value="18:45">18:45</option>

                                <option value="19:00">19:00</option>
                                <option value="19:15">19:15</option>
                                <option value="19:30">19:30</option>
                                <option value="19:45">19:45</option>

                                <option value="20:00">20:00</option>
                                <option value="20:15">20:15</option>
                                <option value="20:30">20:30</option>
                                <option value="20:45">20:45</option>

                                <option value="21:00">21:00</option>
                                <option value="21:15">21:15</option>
                                <option value="21:30">21:30</option>
                                <option value="21:45">21:45</option>

                                <option value="22:00">22:00</option>
                                <option value="22:15">22:15</option>
                                <option value="22:30">22:30</option>
                                <option value="22:45">22:45</option>

                                <option value="23:00">23:00</option>
                                <option value="23:15">23:15</option>
                                <option value="23:30">23:30</option>
                                <option value="23:45">23:45</option>

                            </select>
                        </td>
                    </tr>
                </table>
            </td>

       

              <td width="100%">
                  <table>
            <td width="50%">
                <table width="55%">                  
                    <tr>
                        <td width="50%">Hora Final: </td>
                        <td width="100%">
                            <select class="TextBox width-50" name="horasesionfinal" id="horasesionfinal">
                                <option value="">Seleccione hora</option>
                                <option value="00:00">00:00</option>
                                <option value="00:15">00:15</option>
                                <option value="00:30">00:30</option>
                                <option value="00:45">00:45</option>

                                <option value="01:00">01:00</option>
                                <option value="01:15">01:15</option>
                                <option value="01:30">01:30</option>
                                <option value="01:45">01:45</option>

                                <option value="02:00">02:00</option>
                                <option value="02:15">02:15</option>
                                <option value="02:30">02:30</option>
                                <option value="02:45">02:45</option>

                                <option value="03:00">03:00</option>
                                <option value="03:15">03:15</option>
                                <option value="03:30">03:30</option>
                                <option value="03:45">03:45</option>

                                <option value="04:00">04:00</option>
                                <option value="04:15">04:15</option>
                                <option value="04:30">04:30</option>
                                <option value="04:45">04:45</option>

                                <option value="05:00">05:00</option>
                                <option value="05:15">05:15</option>
                                <option value="05:30">05:30</option>
                                <option value="05:45">05:45</option>

                                <option value="06:00">06:00</option>
                                <option value="06:15">06:15</option>
                                <option value="06:30">06:30</option>
                                <option value="06:45">06:45</option>

                                <option value="07:00">07:00</option>
                                <option value="07:15">07:15</option>
                                <option value="07:30">07:30</option>
                                <option value="07:45">07:45</option>

                                <option value="08:00">08:00</option>
                                <option value="08:15">08:15</option>
                                <option value="08:30">08:30</option>
                                <option value="08:45">08:45</option>

                                <option value="09:00">09:00</option>
                                <option value="09:15">09:15</option>
                                <option value="09:30">09:30</option>
                                <option value="09:45">09:45</option>

                                <option value="10:00">10:00</option>
                                <option value="10:15">10:15</option>
                                <option value="10:30">10:30</option>
                                <option value="10:45">10:45</option>

                                <option value="11:00">11:00</option>
                                <option value="11:15">11:15</option>
                                <option value="11:30">11:30</option>
                                <option value="11:45">11:45</option>

                                <option value="12:00">12:00</option>
                                <option value="12:15">12:15</option>
                                <option value="12:30">12:30</option>
                                <option value="12:45">12:45</option>

                                <option value="13:00">13:00</option>
                                <option value="13:15">13:15</option>
                                <option value="13:30">13:30</option>
                                <option value="13:45">13:45</option>

                                <option value="14:00">14:00</option>
                                <option value="14:15">14:15</option>
                                <option value="14:30">14:30</option>
                                <option value="14:45">14:45</option>

                                <option value="15:00">15:00</option>
                                <option value="15:15">15:15</option>
                                <option value="15:30">15:30</option>
                                <option value="15:45">15:45</option>

                                <option value="16:00">16:00</option>
                                <option value="16:15">16:15</option>
                                <option value="16:30">16:30</option>
                                <option value="16:45">16:45</option>

                                <option value="17:00">17:00</option>
                                <option value="17:15">17:15</option>
                                <option value="17:30">17:30</option>
                                <option value="17:45">17:45</option>

                                <option value="18:00">18:00</option>
                                <option value="18:15">18:15</option>
                                <option value="18:30">18:30</option>
                                <option value="18:45">18:45</option>

                                <option value="19:00">19:00</option>
                                <option value="19:15">19:15</option>
                                <option value="19:30">19:30</option>
                                <option value="19:45">19:45</option>

                                <option value="20:00">20:00</option>
                                <option value="20:15">20:15</option>
                                <option value="20:30">20:30</option>
                                <option value="20:45">20:45</option>

                                <option value="21:00">21:00</option>
                                <option value="21:15">21:15</option>
                                <option value="21:30">21:30</option>
                                <option value="21:45">21:45</option>

                                <option value="22:00">22:00</option>
                                <option value="22:15">22:15</option>
                                <option value="22:30">22:30</option>
                                <option value="22:45">22:45</option>

                                <option value="23:00">23:00</option>
                                <option value="23:15">23:15</option>
                                <option value="23:30">23:30</option>
                                <option value="23:45">23:45</option>

                            </select>
                        </td>
                    </tr>
                </table>
            </td>
                      </table>
                  </td>
           </td>
        </table>

        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombres y apellidos del docente Asesor: </td>
                        <td width="70%">
                            <input type="text" id="nombreapellidorelator" name="nombreapellidorelator" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br/>

    <fieldset>

        <h2 style="display: block; text-align: center">DESARROLLO DE LA MEMORIA</h2>

        <span>1. Realice una descripción de las actividades de formación realizadas en la sesión/nivel, destacando aspectos metodológicos y didácticos. Recupere las actividades de manera cronológica.<br />
           <%-- -	Realice una descripción de las actividades de formación realizadas en la sesión / nivel, destacando aspectos metodológicos y didácticos en el grupo.<br />
            -	La respuesta del grupo frente a la actividad desarrollada. Asocie los productos de la sesión: cuadros, relatos, esquemas, dibujos u otros.--%>
</span><br/>
        <br/>
        <%--<table width="100%" class="border" id="tablecampus">
            <tr>
                <th width="5%">No.</th>
                <th></th>
            </tr>
            <tr>
                <td>1.</td>
                <td>
                    <input type="text" id="pregunta1" name="pregunta1" class="width-90 TextBox"></td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td colspan="3" align="right">
                    <button id="add" type="button" class="btn btn-success">+ Add</button></td>
            </tr>
        </table>--%>
        <cc1:Editor ID="desarrollo1" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <%--<h2 style="display: block; text-align: center">ASPECTOS DESARROLLADOS</h2>--%>
        <span>2.	Síntesis de los aportes, comentarios y apreciaciones de estudiantes de la red temática durante el desarrollo de la sesión presencial y virtual.
            <br>

        </span>
        <br>
        <br>
        <%--<textarea name="aspectosdesarrollados" id="aspectosdesarrollados" class="editor" cols="30" rows="10"></textarea>--%>
        <cc1:Editor ID="aspectosdesarrollados" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <h2 style="display: block; text-align: center">PRODUCTOS DE LA SESIÓN</h2>
        <span>Relacione la producción de la red durante la sesión, ejemplo cuadros, relatos, esquemas, dibujos u otros.</span><br>
        <br>
        <%--<textarea name="conclusiones" id="conclusiones" class="editor" cols="30" rows="10"></textarea>--%>
        <cc1:Editor ID="conclusiones" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <h2 style="display: block; text-align: center">RECURSOS PEDAGOGICOS
        </h2>
        <span> Relacione la bibliografía, infografía, webgrafía utilizada. </span><br>
        <br>
        <%--<textarea name="bibliografia" id="bibliografia" class="editor" cols="30" rows="10"></textarea>--%>
        <%--<asp:TextBox ID="htmlEditorTxt" runat="server" ClientIDMode="Static"
                TextMode="MultiLine" Rows="30" style="width:95%" CssClass="tinymce" />--%>
        <%--<textarea id="htmlEditorTxt" runat="server" class="tinymce"  Rows="30"></textarea>--%>
        <%--<asp:TextBox runat="server" ID="htmlEditorTxt" class="tinymce" TextMode="MultiLine" Rows="25" Columns="50"></asp:TextBox>--%>
        <cc1:Editor ID="bibliografia" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <h2 style="display: block; text-align: center">COMPROMISOS
        </h2>
        <span> Actividades y tareas para la siguiente sesión. </span><br>
        <br>
        <cc1:Editor ID="compromisos" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
         <h2 style="display: block; text-align: center">EVALUACIÓN DE LA SESIÓN
        </h2>
        <span> Describa los aspectos por mejorar, fortalezas y debilidades. </span><br>
        <br>
        <cc1:Editor ID="evaluacionsesion" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
    </fieldset>

    <br>
        <%--<fieldset id="evidencias" style="display:none">
            <legend>Listado de evidencias</legend>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Nombre del archivo</th>
                        <th>Tipo</th>
                        <th>Tamaño</th>
                        <th>Fecha</th>
                        <th>Asesor</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="tbodyinfo">

                </tbody>
            </table>
        </fieldset>--%>

        <%--<div id="dialog" style="display:none">
            <fieldset>
                <legend>Subir imagen</legend>
                <fieldset>
                    <legend>Actividades</legend>
                    <table>
                        <tr>
                            <td><input type="radio" id="actividad1" name="actividad" value="1"/></td>
                            <td>1. Fotos</td>
                        </tr>
                        <tr>
                            <td><input type="radio" id="actividad2" name="actividad" value="2"/></td>
                            <td>2. Listado de asistencia</td>
                        </tr>
                        <tr>
                            <td><input type="radio" id="actividad3" name="actividad" value="3"/></td>
                            <td>3. Formatos de evaluación</td>
                        </tr>
                    </table>
                </fieldset>
                <asp:FileUpload ID="trepador" runat="server" />
                <input type="file" id="uploadFile"/>
                <br />
                <p>Tamaño maximo: 4MB</p>
            </fieldset>
        </div>--%>

        <%--<asp:Button ID="btnBuscarEvidencias" runat="server" Text="Ver evidencias" CssClass="btn btn-primary" OnClick="btnBuscarEvidencias_Onclik" />--%>

    
 </fieldset>
        <div class="button">
        <%--<a class="btn btn-primary" onclick="$('#listTable').fadeIn(500), $('#formTable').hide(), $('#evidencias').hide(), reset(); ">Regresar</a>--%>
        <a class="btn btn-primary" onclick="btnregresar()">Regresar</a>
        <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviarestras004('insert'); ">
       <%-- <a class="btn btn-danger" onclick="uploadImagen()">Subir evidencia</a>--%>
        <%--<asp:Button ID="btnSubirFirmaPop" runat="server" Text="Subir Imagen" CssClass="btn btn-danger" OnClick="btnSubirFirmaPop_Click" />--%>
        <%--<asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar todo" runat="server" OnClick="btnGuardarSede_Click" />--%>
    </div>
    </div>
    
  
    <style type="text/css">
        .button {
            background: rgba(255,255,255,.7);
            bottom:0;
            display:block;
            left: 0;
            padding: 15px;
            position: fixed;
            right: 0;
            text-align:right;
        }
    </style>

    
</ContentTemplate>
</asp:UpdatePanel>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                    <h6> <p style="text-align:center"> <b>Procesando Datos, Espere por favor... <br /><br /></b> </p> </h6>
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>
     
    

    <%-- <ajx:ModalPopupExtender ID="PanelEdicion_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnSubirFirmaPop" PopupControlID="PanelEdicion" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>--%>
       <asp:Label ID="lblDatos" runat="server" Visible="false"></asp:Label>
<div id="evidencias" style="display:none">
   <%-- <asp:Panel ID="PanelEdicion" runat="server" CssClass="modalPopup">--%>
        <asp:Label runat="server" Visible="false" ID="lblCodUsuario"></asp:Label>
          <%--<header class="headerpopup">
          <div style="float: left; margin-right: 15px" id="tituloPopup">
                Subir Imagen
            </div>
           <%-- <div style="float: right;">
                <asp:Label ID="btnCancelar" runat="server" Text="Cerrar" CssClass="botones"></asp:Label>
            </div>
        </header>--%>
        <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>

                 <fieldset>
                <legend>Actividades</legend>
                <asp:Label ID="lblEncabezados" runat="server" Visible="true" ></asp:Label>
         <asp:Panel runat="server" ID="PanelMomento0" Visible="true">
              <asp:RadioButtonList runat="server" ID="rbtActividades">
                    <asp:ListItem>Fotos</asp:ListItem>
                    <asp:ListItem>Listado de asistencia</asp:ListItem>
                    <asp:ListItem>Formatos de evaluación</asp:ListItem>
                    
                </asp:RadioButtonList>
         </asp:Panel>
          
         <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades" Display="Dynamic" ControlToValidate="rbtActividades" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
  
         </fieldset>

                <asp:FileUpload ID="trepador" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer >
            <div style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Subir Imagen" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
                 <asp:Button ID="Button2" runat="server" Text="Ver evidencias" CssClass="btn btn-danger"  OnClick="btnBuscarEvidencias_Onclik" />
                 <asp:Button ID="Button3" runat="server" Text="Volver" CssClass="btn btn-primary"  OnClick="btnVolver_Onclik" />
            </div>
        </footer>
    <%--</asp:Panel>--%>
  
     <fieldset>
     <legend>Listado de evidencias</legend>
        
      <asp:GridView ID="GridEvidencias" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                            <asp:BoundField DataField="nombrearchivo" HeaderText="Nombre archivo">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tamano"  HeaderText="Tamaño" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="estrategia" HeaderText="Estrategia">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="momento" HeaderText="Momento">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sesion" HeaderText="Sesión">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="actividad" HeaderText="Actividad">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="fechacreado" HeaderText="Fecha subida">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombreguardado" HeaderText="Guardado" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="path" HeaderText="Path" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                            </asp:BoundField>


                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/down.png" Height="20px" Width="20px" OnClick="imgDescargar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
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

         </fieldset>

</div>

    <div id="modificarsesion" style="display:none">
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>Red temática</th>
                    <th>Sesión</th>
                </tr>
            </thead>
            <tbody id="infosesion"></tbody>
        </table>

        <table align="center">
            <tr>
                <td><select id="sesion" class="TextBox">
                    <option value="0" disabled>Seleccione una Sesión</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                    </select></td>
            </tr>
            <tr>
                <td><a onclick="guardarSesion();" class="btn btn-success">Modificar Sesión</a>
                    <a onclick="$('#modificarsesion').hide();$('#formTable').hide();$('#listTable').fadeIn(500);" class="btn btn-primary">Regresar</a>
                </td>
            </tr>
        </table>

    </div>

       

</asp:Content>

