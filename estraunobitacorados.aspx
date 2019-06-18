<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunobitacorados.aspx.cs" Inherits="estraunobitacorados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

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
        var total = 1;
        var codigobitacora;
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
        $(document).ready(function () {

            cargarDepartamentoMagdalena();
            //cargarinstituciones();
            reset();

            $("#departamento").change(function () {
                reset();
                var jsonData = '{ "departamento":"' + $("#departamento").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunobitacorados.aspx/cargarMunicipios',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "municipio") {
                            $("#municipio").html(resp[1]);
                        }
                        else if (resp[0] === "vacio") {
                            $("#municipio").html(json.d);

                        } else {
                            console.error(json.d);
                        }
                    }
                });
            });

            $("#municipio").change(function () {
                reset();
                var jsonData = '{ "codmunicipio":"' + $("#municipio").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunobitacorados.aspx/cargarInstituciones',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "inst") {
                            $("#institucion").html(resp[1]);
                        }
                    }
                });
            });

            $("#institucion").change(function () {
                reset();
                var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunobitacorados.aspx/cargarsedes',
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

            $("#sede").change(function () {
                reset();
                var jsonData = '{ "codigosede":"' + $("#sede").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunobitacorados.aspx/grupoInvestigacion',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "gruposinvestigacion") {
                            $("#grupoinvestigacion").html(resp[1]);
                        }
                        else if (resp[0] === "vacio") {
                            $("#grupoinvestigacion").html(json.d);

                        } else {
                            console.error(json.d);
                        }
                    }
                });
            });

            $("#grupoinvestigacion").change(function () {
                cargarBitacora2($('#grupoinvestigacion').val());
            });

            $("input[type='date']").datepicker();


            //////////////////////////////////////////
            $("#btn-guardar").keypress(function () {
                $("#target").click();
            });

        });

        function fRemove(data) {
            // alert(data);
            var ant = data - 1;
            total = total - 1;
            $("#campus" + data).remove();
            $("#radiotr" + ant).append('<td><button id="remove"  class="btn btn-danger" onclick="fRemove(' + ant + ')">-</button></td>');
        }

        function cargarDepartamentoMagdalena() {
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/cargarDepartamentoMagdalena',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //data:frmserialize,
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "depar") {
                        $("#departamento").html(resp[1]);
                        //alert(resp[0]);
                    }
                }
            });
        }

        function cargarinstituciones() {
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/cargarInstituciones',
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

            $('#btn-guardar').val('Guardar');
            $('#btn-guardar').attr('onclick', 'enviarbitacora2(\'insert\')');
            $("#preguntainvestigacion").val('');
            $("#resumen").val('');
            k = 1;
            for (var i = 1; i <= 5; i++) {
                $("#pregunta" + i).val('');
                for (var j = 1; j <= 3; j++) {
                    $("#p" + k + "respuesta" + j).val('');
                    $("#p" + k + "fuente" + j).val('');
                }
                k++;
            }
        }

        function enviarbitacora2(event) {
            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione institución");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione sede");
                $("#sede").focus();
            } else if ($.trim($("#grupoinvestigacion").val()) == '') {
                alert("Por favor, seleccione grupo investigacion");
                $("#grupoinvestigacion").focus();
            }
            else if ($.trim($("#preguntainvestigacion").val()) == '') {
                alert("Por favor, ingrese pregunta de investigacion seleccionada");
                $("#preguntainvestigacion").focus();
            }
            else if ($.trim($("#preguntainvestigacion").val()) == '') {
                alert("Por favor, ingrese pregunta de investigacion seleccionada");
                $("#preguntainvestigacion").focus();
            }
            else if ($.trim($("#resumen").val()) == '') {
                alert("Por favor, ingrese resumen de la discusión");
                $("#resumen").focus();
            }
            else if ($.trim($("#pregunta1").val()) == '') {
                alert("Por favor, ingrese pregunta No. 1");
                $("#pregunta1").focus();
            } else if ($.trim($("#pregunta2").val()) == '') {
                alert("Por favor, ingrese pregunta No. 2");
                $("#pregunta2").focus();
            }
            else if ($.trim($("#pregunta3").val()) == '') {
                alert("Por favor, ingrese pregunta No. 3");
                $("#pregunta3").focus();
            }
            else if ($.trim($("#pregunta4").val()) == '') {
                alert("Por favor, ingrese pregunta No. 4");
                $("#pregunta4").focus();
            }
            else if ($.trim($("#pregunta5").val()) == '') {
                alert("Por favor, ingrese pregunta No. 5");
                $("#pregunta5").focus();
            }

            //pregunta 1
            //else if ($.trim($("#p1respuesta1").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 1");
            //    $("#p1respuesta1").focus();
            //}
            //else if ($.trim($("#p1fuente1").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 1");
            //    $("#p1fuente1").focus();
            //}
            //else if ($.trim($("#p1respuesta2").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 2");
            //    $("#p1respuesta2").focus();
            //}
            //else if ($.trim($("#p1fuente2").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 2");
            //    $("#p1fuente2").focus();
            //}
            //else if ($.trim($("#p1respuesta3").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 3");
            //    $("#p1respuesta3").focus();
            //}
            //else if ($.trim($("#p1fuente3").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 3");
            //    $("#p1fuente3").focus();
            //}
            //pregunta 2
            //else if ($.trim($("#p2respuesta1").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 1");
            //    $("#p2respuesta1").focus();
            //}
            //else if ($.trim($("#p2fuente1").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 1");
            //    $("#p2fuente1").focus();
            //}
            //else if ($.trim($("#p2respuesta2").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 2");
            //    $("#p2respuesta2").focus();
            //}
            //else if ($.trim($("#p2fuente2").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 2");
            //    $("#p2fuente2").focus();
            //}
            //else if ($.trim($("#p2respuesta3").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 3");
            //    $("#p2respuesta3").focus();
            //}
            //else if ($.trim($("#p2fuente3").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 3");
            //    $("#p2fuente3").focus();
            //}


            //pregunta 3

            //else if ($.trim($("#p3respuesta1").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 1");
            //    $("#p3respuesta1").focus();
            //}
            //else if ($.trim($("#p3fuente1").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 1");
            //    $("#p3fuente1").focus();
            //}
            //else if ($.trim($("#p3respuesta2").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 2");
            //    $("#p3respuesta2").focus();
            //}
            //else if ($.trim($("#p3fuente2").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 2");
            //    $("#p3fuente2").focus();
            //}
            //else if ($.trim($("#p3respuesta3").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 3");
            //    $("#p3respuesta3").focus();
            //}
            //else if ($.trim($("#p3fuente3").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 3");
            //    $("#p3fuente3").focus();
            //}
            
            //pregunta 4
            //else if ($.trim($("#p4respuesta1").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 1");
            //    $("#p4respuesta1").focus();
            //}
            //else if ($.trim($("#p4fuente1").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 1");
            //    $("#p4fuente1").focus();
            //}
            //else if ($.trim($("#p4respuesta2").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 2");
            //    $("#p4respuesta2").focus();
            //}
            //else if ($.trim($("#p4fuente2").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 2");
            //    $("#p4fuente2").focus();
            //}
            //else if ($.trim($("#p4respuesta3").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 3");
            //    $("#p4respuesta3").focus();
            //}
            //else if ($.trim($("#p4fuente3").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 3");
            //    $("#p4fuente3").focus();
            //}

            //pregunta 5
            //else if ($.trim($("#p5respuesta1").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 1");
            //    $("#p5respuesta1").focus();
            //}
            //else if ($.trim($("#p5fuente1").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 1");
            //    $("#p5fuente1").focus();
            //}
            //else if ($.trim($("#p5respuesta2").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 2");
            //    $("#p5respuesta2").focus();
            //}
            //else if ($.trim($("#p5fuente2").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 2");
            //    $("#p5fuente2").focus();
            //}
            //else if ($.trim($("#p5respuesta3").val()) == '') {
            //    alert("Por favor, ingrese respuesta No. 3");
            //    $("#p5respuesta3").focus();
            //}
            //else if ($.trim($("#p5fuente3").val()) == '') {
            //    alert("Por favor, ingrese Fuente o lugar donde se encontró No. 3");
            //    $("#p5fuente3").focus();
            //}
            else {
                
                var grupoinvestigacion = $("#grupoinvestigacion").val();
                var preguntainvestigacion = $("#preguntainvestigacion").val();
                var resumen = $("#resumen").val();
                //var relato = $("#relato").val();

                if (event == 'insert') {
                    finsertbitacora2(grupoinvestigacion, preguntainvestigacion, resumen);
                } else if (event == 'update') {
                    fupdatebitacora2(grupoinvestigacion, preguntainvestigacion, resumen);
                }
                
            }
        }

        function finsertbitacora2(grupoinvestigacion, preguntainvestigacion, resumen) {

            var jsonData = '{ "grupoinvestigacion":"' + grupoinvestigacion + '", "preguntainvestigacion": "' + preguntainvestigacion + '", "resumen": "' + resumen + '"}';
            //var jsonData = '{ "grupoinvestigacion":"' + grupoinvestigacion + '", "preguntainvestigacion": "' + preguntainvestigacion + '", "resumen": "' + resumen + '", "relato":"' + relato + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/insertbitacora2',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        console.log("bitacora insertado exitosamente" + resp[1]);
                        codigobitacora = resp[1];
                        alert("instrumento insertado exitosamente");

                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarbitacora2(\'update\')');
                        finsertPreguntas();
                        /*modificado 2016-10-24*/
                        listarBitacoraDos();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function fupdatebitacora2(grupoinvestigacion, preguntainvestigacion, resumen) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigobitacora":"' + codigobitacora + '", "grupoinvestigacion":"' + grupoinvestigacion + '", "preguntainvestigacion": "' + preguntainvestigacion + '", "resumen": "' + resumen + '"}';
            //var jsonData = '{ "codigobitacora":"' + codigobitacora + '", "grupoinvestigacion":"' + grupoinvestigacion + '", "preguntainvestigacion": "' + preguntainvestigacion + '", "resumen": "' + resumen + '", "relato":"' + relato + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/updatebitacora2',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        console.log("bitacora 2 actualizada exitosamente " + codigobitacora);
                        /*modificado 2016-10-24*/
                        alert("bitacora 2 actualizada exitosamente ");
                        finsertPreguntas();
                        listarBitacoraDos();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function cargarBitacora2(codigogrupo) {
            
            var jsonData = '{ "codproyecto":"' + codigogrupo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/loadBitacora2',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        codigobitacora = resp[1];
                        fcargarPreguntas(codigobitacora);
                        
                        $("#preguntainvestigacion").val(resp[2]);
                        $("#resumen").val(resp[3]);
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarbitacora2(\'update\')');

                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        html = "<tr>";
                        html += "    <td>1.</td>";
                        html += "    <td>";
                        html += "        <input type=\"text\" class=\"TextBox\" id=\"pregunta1\" name=\"pregunta1\" style=\"width: 350px;\">";
                        html += "    </td>";
                        html += "</tr>";
                        html += "<tr>";
                        html += "    <td>2.</td>";
                        html += "    <td><input type=\"text\" class=\"TextBox\" id=\"pregunta2\" name=\"pregunta2\" style=\"width: 350px;\"></td>";
                        html += "</tr>";
                        html += "<tr>";
                        html += "    <td>3.</td>";
                        html += "    <td><input type=\"text\" class=\"TextBox\" id=\"pregunta3\" name=\"pregunta3\" style=\"width: 350px;\"></td>";
                        html += "</tr>";
                        html += " <tr>";
                        html += "    <td>4.</td>";
                        html += "    <td><input type=\"text\" class=\"TextBox\" id=\"pregunta4\" name=\"pregunta4\" style=\"width: 350px;\"></td>";
                        html += " </tr>";
                        html += "<tr>";
                        html += "    <td>5.</td>";
                        html += "    <td><input type=\"text\" class=\"TextBox\" id=\"pregunta5\" name=\"pregunta5\" style=\"width: 350px;\"></td>";
                        html += "</tr>";
                        $("#tblpreguntas").html(html);
                        $("#preguntainvestigacion").val('');
                        $("#resumen").val('');
                        $('#btn-guardar').val('Guardar');
                        $("#fechaentrega").val('');
                        $("#nombre").val('');
                        $('#btn-guardar').attr('onclick', 'enviarbitacora2(\'insert\')');

                        k = 1;
                        for (var i = 1; i <= 5; i++) {
                            $("#pregunta" + i).val('');
                            for (var j = 1; j <= 3; j++) {
                                $("#p" + k + "respuesta" + j).val('');
                                $("#p" + k + "fuente" + j).val('');
                            }
                            k++;
                        }
                        //alert(data.d);
                        //console.error(data.d);
                    }
                }
            });
        }

        function fcargarPreguntas() {
            var jsonData = '{ "codigobitacora":"' + codigobitacora + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/loadpreguntas',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        fcargarRespuestas();
                        $("#tblpreguntas").html(resp[1]);
                    }
                }
            });
        }

        function fcargarRespuestas() {
            var jsonData = '{ "codigobitacora":"' + codigobitacora + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/loadRespuestas',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    console.log(resp.length);
                    for (var i = 1; i < resp.length-1; i++) {
                        $("#tblrespuesta" + i).html(resp[i]);
                    }
                    //if (resp[0] === "true") {
                    //    $("#tblpreguntas").html(resp[1]);
                    //}
                }
            });
        }


        //funcion para insertar los preguntas
        function finsertPreguntas() {
            var jsonData = '{ "codigobitacora":"' + codigobitacora + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/deletePreguntas',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        var k = 1;
                        for (var i = 1; i <= 5; i++) {
                            //alert(k);
                            
                            var jsonData = '{ "codigobitacora":"' + codigobitacora + '", "pregunta":"' + $("#pregunta" + i).val() + '", "numpregunta" : "' + i + '"}';
                            $.ajax({
                                type: 'POST',
                                url: 'estraunobitacorados.aspx/insertPreguntas',
                                data: jsonData,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    var resp = data.d.split("@");
                                    if (resp[0] === "true") {
                                        
                                        console.log("cod pregunta " + k + " " + resp[1]);

                                        //for (var j = 1; j <= 3; j++) {
                                            
                                        //    var jsonData1 = '{ "codigopregunta":"' + resp[1] + '", "respuesta":"' + $("#p" + k + "respuesta" + j).val() + '", "fuente" : "' + $("#p" + k + "fuente" + j).val() + '", "numrespuesta" : "' + j + '"}';
                                        //    //console.log(jsonData1);
                                        //    $.ajax({
                                        //        type: 'POST',
                                        //        url: 'estraunobitacorados.aspx/insertRespuesta',
                                        //        data: jsonData1,
                                        //        contentType: "application/json; charset=utf-8",
                                        //        dataType: "json",
                                        //        success: function (data) {
                                        //            var resp = data.d.split("@");
                                        //            if (resp[0] === "true") {
                                        //                console.log("respuesta insertada exitosamente " + j);
                                        //            } else {
                                        //                console.error(data.d + " " + j);
                                        //                //console.error(data.d);
                                        //            }
                                        //        }
                                        //    });
                                        //}
                                        console.log("pregunta insertada exitosamente " + k);
                                    } else {
                                        console.error(data.d + " " + i);
                                        //console.error(data.d);
                                    }
                                }, complete: function () {
                                    k++;
                                    if (k == 5) {
                                        /*modificado 2016-10-24*/
                                       // alert("registro guardado exitosamente");
                                    }
                                }
                            });

                            
                        }

                    } else {
                        alert(data.d);
                    }
                },
                complete: function () {
                    
                    $('#btn-guardar').attr('value', 'Actualizar');
                    $('#btn-guardar').attr('onclick', 'enviarbitacora2(\'update\')');
                }
            });
        }

        function valideKey(evt) {
            var code = (evt.which) ? evt.which : evt.keyCode;
            if (code == 8) {
                //backspace
                return true;
            }
            else if (code >= 48 && code <= 57) {
                //is a number
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <!--2016-10-24 JONNY PACHECO metodo para  listar las bitacoras-->
    <script>
        $(function () {
            listarBitacoraDos()
        });

        function listarBitacoraDos() {
            $("#form").hide();
            $("#table").fadeIn(500);

            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/listarBitacoraDos',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });  
        }

        function loadSelectBitacoraDos(codProyecto){
            var jsondata = "{'codProyecto':'" + codProyecto + "'}";
            $.ajax({
                type: 'POST',
                url: 'estraunobitacorados.aspx/loadSelectBitacoraDos',
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
                        $("#grupoinvestigacion").html(resp[5]);
                    }
                }
            });
        }

        function btnRegresar() {
            $("#form").hide();
            $("#table").fadeIn(500);
        }

        function nuevaBitacora() {
            $("#table").hide();
            $("#form").fadeIn(500);
            $("#municipio").html("<option value=''>Seleccione municipio...</option>");
            $("#institucion").html("<option value=''>Seleccione institucion...</option>");
            $("#sede").html("<option value=''>Seleccione sede...</option>");
            $("#grupoinvestigacion").html("<option value=''>Seleccione sede...</option>");
            reset();
            cargarDepartamentoMagdalena();
            
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsondata = "{'codigo':'" + codigo + "'}";

                $.ajax({
                    type: 'POST',
                    url: 'estraunobitacorados.aspx/eliminar',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsondata,
                    success: function (json) {
                        alert("Registro eliminado correctamente");
                        listarBitacoraDos();
                    }
                });
            }
           
        }
            
    </script>

</asp:Content >

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia Nro. 1 - Bitácora Nro. 2</h2>
<div id="table">
     <a href="#" class="btn btn-primary" style="float:right;" onclick="nuevaBitacora()">Nueva bitácora</a>
      <br />
      <br />
     <fieldset >
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede</th>
                    <th>Pregunta<br/>investigación</th>
                    <th>Grupo<br/>investigación</th>
                    <th>Fecha<br/>Creación</th>
                    <th>Momento<br />Pedagógico</th>
                    <th>Sesión</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
</div>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false"></asp:Label>
     <asp:Label runat="server" ID="lblTipoGrupo" Visible="false"></asp:Label>
     <asp:Label runat="server" ID="lblCodUsuario" Visible="false"></asp:Label>

<div id="form" style="display:none">
    <!-- DATOS DE LA INSTITUCIÓN -->
    <fieldset>
        <legend>DATOS DE LA INSTITUCIÓN</legend>
        <table width="100%">

            <tr>
                <td width="60%">
                    <table width="100%">
                         <tr width="100%">
                            <td style="width: 150px;">Departamento:</td>
                            <td >
                                <select class="TextBox" name="departamento" id="departamento" >
                                    <option value="">Seleccione departamento...</option>
                                </select></td>
                            </tr>
                          <tr width="100%">
                            <td style="width: 150px;">Municipio:</td>
                            <td >
                                <select class="TextBox" name="municipio" id="municipio" >
                                    <option value="">Seleccione municipio...</option>
                                </select></td>
                            </tr>
                        <tr width="100%">
                            <td style="width: 150px;">Institución Educativa:</td>
                            <td >
                                <select class="TextBox" name="institucion" id="institucion" >
                                    <option value="">Seleccione institución...</option>
                                </select></td>
                            </tr>
                            <tr>
                            <td style="width: 150px;">Sede: </td>
                            <td>
                                <select class="TextBox" name="sede" id="sede" >
                                    <option value='' selected>Seleccione sede...</option>
                                </select></td>
                            <td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td width="34%">Nombre del grupo de investigación: </td>
                            <td width="68%">
                                <select class="TextBox" name="grupoinvestigacion" id="grupoinvestigacion" >
                                    <option value="">Seleccione grupo investigación...</option>
                                </select></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </fieldset>
    <!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br>
    <fieldset>
        <legend>Datos de las preguntas</legend>
        <table border="0" align="" class="tabla">
            <tr>
                <td>Digite en este espacio cinco de las preguntas que más les interesaron a los integrantes del grupo de investigación.</td>
            </tr>
            <tr>
                <td>
                    <table id="tblpreguntas">
                        <tr>
                            <td>1.</td>
                            <td>
                                <input type="text" class="TextBox" id="pregunta1" name="pregunta1" style="width: 350px;">
                            </td>
                        </tr>
                        <tr>
                            <td>2.</td>
                            <td><input type="text" class="TextBox" id="pregunta2" name="pregunta2" style="width: 350px;"></td>
                        </tr>
                        <tr>
                            <td>3.</td>
                            <td><input type="text" class="TextBox" id="pregunta3" name="pregunta3" style="width: 350px;"></td>
                        </tr>
                        <tr>
                            <td>4.</td>
                            <td><input type="text" class="TextBox" id="pregunta4" name="pregunta4" style="width: 350px;"></td>
                        </tr>
                        <tr>
                            <td>5.</td>
                            <td><input type="text" class="TextBox" id="pregunta5" name="pregunta5" style="width: 350px;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
           <%-- <tr>
                <td>En el siguiente cuadro anotar las respuestas resultado de  la búsqueda para cada una de las preguntas:</td>
            </tr>
            <tr>
                <td>
                    <table id="tblrespuesta1"  >
                        <tr>
                            <td style="font-weight:bold;">Pregunta formulada 1.</td>
                        </tr>
                        <tr>
                            <td>
                                <table  >
                                    <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                                        <td>Respuesta que se encontraron</td>
                                        <td>Fuente (documento, persona) o lugar donde se encontró</td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p1respuesta1" name="p1respuesta1" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p1fuente1" name="p1fuente1" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p1respuesta2" name="p1respuesta2" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p1fuente2" name="p1fuente2" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p1respuesta3" name="p1respuesta3" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p1fuente3" name="p1fuente3" style="width: 98%;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table  id="tblrespuesta2">
                        <tr>
                            <td style="font-weight:bold;">Pregunta formulada 2.</td>
                        </tr>
                        <tr>
                            <td>
                                <table >
                                    <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                                        <td>Respuesta que se encontraron</td>
                                        <td>Fuente (documento, persona) o lugar donde se encontró</td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p2respuesta1" name="p2respuesta1" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p2fuente1" name="p2fuente1" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p2respuesta2" name="p2respuesta2" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p2fuente2" name="p2fuente2" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p2respuesta3" name="p2respuesta3" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p2fuente3" name="p2fuente3" style="width: 98%;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table  id="tblrespuesta3">
                        <tr>
                            <td style="font-weight:bold;">Pregunta formulada 3.</td>
                        </tr>
                        <tr>
                            <td>
                                <table >
                                    <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                                        <td>Respuesta que se encontraron</td>
                                        <td>Fuente (documento, persona) o lugar donde se encontró</td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p3respuesta1" name="p3respuesta1"  style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p3fuente1" name="p3fuente1"  style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p3respuesta2" name="p3respuesta2" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p3fuente2" name="p3fuente2" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p3respuesta3" name="p3respuesta3" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p3fuente3" name="p3fuente3" style="width: 98%;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table  id="tblrespuesta4">
                        <tr>
                            <td style="font-weight:bold;">Pregunta formulada 4.</td>
                        </tr>
                        <tr>
                            <td>
                                <table >
                                    <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                                        <td>Respuesta que se encontraron</td>
                                        <td>Fuente (documento, persona) o lugar donde se encontró</td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p4respuesta1" name="p4respuesta1" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p4fuente1" name="p4fuente1" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p4respuesta2" name="p4respuesta2" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p4fuente2" name="p4fuente2" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p4respuesta3" name="p4respuesta3" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p4fuente3" name="p4fuente3" style="width: 98%;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table  id="tblrespuesta5" >
                        <tr>
                            <td style="font-weight:bold;">Pregunta formulada 5.</td>
                        </tr>
                        <tr>
                            <td>
                                <table >
                                    <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                                        <td>Respuesta que se encontraron</td>
                                        <td>Fuente (documento, persona) o lugar donde se encontró</td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p5respuesta1" name="p5respuesta1" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p5fuente1" name="p5fuente1" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p5respuesta2" name="p5respuesta2" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p5fuente2" name="p5fuente2" style="width: 98%;"></td>
                                    </tr>
                                    <tr>
                                        <td><input type="text" class="TextBox" id="p5respuesta3" name="p5respuesta3" style="width: 98%;"></td>
                                        <td><input type="text" class="TextBox" id="p5fuente3" name="p5fuente3" style="width: 98%;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
              <tr>
                <td>Señor docente haga un relato</td>
            </tr>
           <%-- <tr>
                <td>
                    <textarea cols="200" rows="5" style="width:100%;" id="relato" name="relato" class="TextBox"></textarea>
                </td>
            </tr>--%>
            <tr>
                <td>Digite en este espacio la pregunta de investigacion seleccionada</td>
            </tr>
            <tr>
                <td>
                    <textarea cols="200" rows="5" style="width:100%;" id="preguntainvestigacion" name="preguntainvestigacion" class="TextBox"></textarea>
                </td>
            </tr>
            <tr>
                <td>Haga un resumen de la discusión que se dio en el grupo para seleccionar la o las preguntas de investigación y enuncien los argumentos que se expusieron para ello.<br/>
                    Explique sobre la importancia de las preguntas para generar una práctica de aula.
                </td>
            </tr>
            <tr>
                <td>
                    <textarea cols="200" rows="5" style="width:100%;" class="TextBox" id="resumen" name="resumen"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <style>
                        .btn-float{
                            background: #fff none repeat scroll 0 0;
                            bottom: 0;
                            left: 0;
                            overflow: hidden;
                            padding: 14px 30px 14px 14px;
                            position: fixed;
                            right: 0;
                            text-align: right;
                            width: 98%;
                        }
                    </style>
                    <div class="btn-float">
                        <input type="button" id="btn-guardar" value="Guardar" onclick="enviarbitacora2('insert')" class="btn btn-success">
                        <a href="#" Class="btn btn-primary" onclick="btnRegresar();">Regresar</a>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    </div>
        <br>
</asp:Content>

