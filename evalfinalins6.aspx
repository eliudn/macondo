<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="evalfinalins6.aspx.cs" Inherits="evalfinalins6" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
    <script>
        var codasesor;
        $(document).ready(function () {
            cargarinfoinstitucion();
        });

        function cargarinfoinstitucion() {
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/cargarinfoinstitucion',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("&");
                    if (resp[0] === "true") {
                        codinstitucion = resp[1];
                        buscarasesor(resp[1]);
                    }
                }
            });
        }
        function buscarasesor(codinstitucion) {
            var jsonData = '{ "codinstitucion":"' + codinstitucion + '"}';
           
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/buscarasesor',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("&");
                    if (resp[1] === "true") {
                        //$("#asesor").html(resp[0]);
                        codasesor = resp[0];
                    }
                    //else {
                    //    cargarasesores();
                    //}
                }
            });
        }
        

        function enviar() {
            
             if ($.trim($("#fechacues").val()) == '') {
                 alert("Por favor, responda la pregunta No. 1");
                 $("#fechacues").focus();
             }
             else if ($.trim($("#edadcues").val()) == '') {
                 alert("Por favor, responda la pregunta No. 3");
                 $("#edadcues").focus();
             }
             else if (!$("input[name=p10]:checked").val()) {
                alert("Por favor, seleccione una opción de la pregunta No. 4");
             }
             else if ($.trim($("#gradocursa").val()) == '') {
                 alert("Por favor, responda la pregunta No. 5");
                 $("#fechacues").focus();
             }
             else if ($.trim($("#nombreinst").val()) == '') {
                 alert("Por favor, responda la pregunta No. 6");
                 $("#nombreinst").focus();
             }
             
             else if (!$("input[name=vinculacion]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 10");
             }
             else if (!$("input[name=comunidad]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.1");
             }
             else if (!$("input[name=conocimiento]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.2");
             }
             else if (!$("input[name=lvive]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.3");
             }
             else if (!$("input[name=investi]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.4");
             }
             else if (!$("input[name=ferias]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.5");
             }
             else if (!$("input[name=jgc]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.6");
             }
             else if (!$("input[name=otro1]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 11.7");
             }
             else if (!$("input[name=ltematica]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 12.1");
             }
             else if (!$("input[name=linstitucion]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 12.2");
             }
             else if (!$("input[name=compañeros]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 12.3");
             }
             else if (!$("input[name=a16]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 13.1");
             }
             else if (!$("input[name=a17]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 13.2");
             }
             else if (!$("input[name=a18]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 13.3");
             }
             else if (!$("input[name=leer]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.1");
             }
             else if (!$("input[name=fpreguntas]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.2");
             }
             else if (!$("input[name=hexperi]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.3");
             }
             else if (!$("input[name=escribir]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.4");
             }
             else if (!$("input[name=entrevista]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.5");
             }
             else if (!$("input[name=observar]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.6");
             }
             else if (!$("input[name=analizar]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.7");
             }
             else if (!$("input[name=rdatos]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.8");
             }
             else if (!$("input[name=sconclusion]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.9");
             }
             else if (!$("input[name=cresultados]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.10");
             }
             else if (!$("input[name=tgrupo]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 14.11");
             }
             else if (!$("input[name=djornada]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 15.1");
             }
             else if (!$("input[name=fjornada]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 15.2");
             }
             else if (!$("input[name=entregamateriales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.1");
             }
             else if (!$("input[name=tallerinves]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.2");
             }
             else if (!$("input[name=asignacionasesor]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.3");
             }
             else if (!$("input[name=participaferias]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.4");
             }
             else if (!$("input[name=apoyoeconomico]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.5");
             }
             else if (!$("input[name=plataformapago]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.6");
             }
             else if (!$("input[name=otros17]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 17.7");
             }
             else if (!$("input[name=guias]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.1");
             }
             else if (!$("input[name=laboratorio]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.2");
             }
             else if (!$("input[name=recursosdidacticos]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.3");
             }
             else if (!$("input[name=tabletas]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.4");
             }
             else if (!$("input[name=computadores]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.5");
             }
             else if (!$("input[name=videobeam]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.6");
             }
             else if (!$("input[name=amplificador]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.7");
             }
             else if (!$("input[name=discuduro]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.8");
             }
             else if (!$("input[name=camara]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.9");
             }
             else if (!$("input[name=otrosmateriales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 18.10");
             }
             else if (!$("input[name=feriasinstitucionales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 19.1");
             }
             else if (!$("input[name=feriasmunicipales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 19.2");
             }
             else if (!$("input[name=feriasdepartamentales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 19.3");
             }
             else if (!$("input[name=feriasregionales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 19.4");
             }
             else if (!$("input[name=feriasnacionales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 19.5");
             }
             else if (!$("input[name=feriasinternacionales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 19.6");
             }
             else if (!$("input[name=talleresorganizados]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 20");
             }
             else if (!$("input[name=alcalde]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.1");
             }
             else if (!$("input[name=rector]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.2");
             }
             else if (!$("input[name=maestroacompana]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.3");
             }
             else if (!$("input[name=asesorproyecto]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.4");
             }
             else if (!$("input[name=funcionariosoperadoras]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.5");
             }
             else if (!$("input[name=investigau]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.6");
             }
             else if (!$("input[name=evaluadorferia]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.7");
             }
             else if (!$("input[name=docenteasesorredes]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.8");
             }
             else if (!$("input[name=otros229]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 22.9");
             }
             else if (!$("input[name=secredeparta]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.1");
             }
             else if (!$("input[name=operadoras]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.2");
             }
             else if (!$("input[name=universidades]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.3");
             }
             else if (!$("input[name=escuelasnormales]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.4");
             }
             else if (!$("input[name=alcaldia]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.5");
             }
             else if (!$("input[name=umata]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.6");
             }
             else if (!$("input[name=icbf]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.7");
             }
             else if (!$("input[name=corpomag]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.8");
             }
             else if (!$("input[name=sena]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.9");
             }
             else if (!$("input[name=otras23]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 23.10");
             }
             else if (!$("input[name=ciencia]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.1");
             }
             else if (!$("input[name=concepto]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.2");
             }
             else if (!$("input[name=aumentoparticipa]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.3");
             }
             else if (!$("input[name=preguntasacerca]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.4");
             }
             else if (!$("input[name=soluciones]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.5");
             }
             else if (!$("input[name=comunidad]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.6");
             }
             else if (!$("input[name=calificaciones]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.7");
             }
             else if (!$("input[name=leesmas]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.8");
             }
             else if (!$("input[name=escribemas]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.9");
             }
             else if (!$("input[name=trabajamas]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.10");
             }
             else if (!$("input[name=argumentas]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.11");
             }
             else if (!$("input[name=comunica]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 24.12");
             }
             else if (!$("input[name=actividad]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 25.1");
             }
             else if (!$("input[name=hacerclase]:checked").val()) {
                 alert("Por favor, seleccione una opción de la pregunta No. 25.2");
             }
            else {
                
                guardarpreguntaNo1();

            }
            
        }

        function guardarpreguntaNo1() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Las respuestas están siendo guardadas, por favor espere...</div>');
            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $("#fechacues").val() + '", "pregunta": "1", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1 guardada");
                    //$(".desactivarC1").delay(15000).fadeOut(500);
                    //alert("datos actualizado exitosamente");
                },
                complete: function () {
                    guardarpreguntaNo3();
                }
            });
        }

        function guardarpreguntaNo3() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $("#edadcues").val() + '", "pregunta": "2", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2 guardada");
                },
                complete: function () {
                    guardarpreguntaNo4();
                }
            });
        }

        function guardarpreguntaNo4() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=p10]:checked').val() + '", "pregunta": "4", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 4 guardada");
                },
                complete: function () {
                    guardarpreguntaNo5();
                }
            });
        }

        function guardarpreguntaNo5() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#gradocursa').val() + '", "pregunta": "5", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 5 guardada");
                },
                complete: function () {
                    guardarpreguntaNo6();
                }
            });
        }

        function guardarpreguntaNo6() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#nombreinst').val() + '", "pregunta": "6", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 6 guardada");
                },
                complete: function () {
                    guardarpreguntaNo9();
                }
            });
        }

        // function guardarpreguntaNo7() {

        //     var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#nombremunicipio').val() + '", "pregunta": "7", "subpregunta": "0"}';
        //     $.ajax({
        //         type: 'POST',
        //         url: 'evalfinalins6.aspx/insertarevaluacion',
        //         data: jsonData,
        //         contentType: "application/json; charset=utf-8",
        //         dataType: "json",
        //         success: function (data) {
        //             console.log("pregunta 7 guardada");
        //         },
        //         complete: function () {
        //             guardarpreguntaNo8();
        //         }
        //     });
        // }

        // function guardarpreguntaNo8() {

        //     var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#nombrearea').val() + '", "pregunta": "8", "subpregunta": "0"}';
        //     $.ajax({
        //         type: 'POST',
        //         url: 'evalfinalins6.aspx/insertarevaluacion',
        //         data: jsonData,
        //         contentType: "application/json; charset=utf-8",
        //         dataType: "json",
        //         success: function (data) {
        //             console.log("pregunta 8 guardada");
        //         },
        //         complete: function () {
        //             guardarpreguntaNo9();
        //         }
        //     });
        // }

        function guardarpreguntaNo9() {

            //var k = 0;
            //$("input[name=p]").each(function (index) {
                //if ($(this).is(':checked')) {
                    var jsonData3 = "{'codasesor':'" + codasesor + "', 'codinstitucion':'" + codinstitucion + "', 'respuesta':'" + $('input:checkbox[name=p]:checked').val() + "', 'pregunta':'9', 'subpregunta':'1'}";

                    $.ajax({
                        type: 'POST',
                        url: 'evalfinalins6.aspx/insertarevaluacion',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData3,
                        success: function () {
                            //console.log("Pregunta 5 guardarda, item: " + $(this).val());
                        },
                        complete: function () {
                            //console.log(k);
                            //if (k == 2) {
                                guardarpreguntaNo92();
                            //}
                        }
                    });
                //}
                //k++;
            //});

        }

                function guardarpreguntaNo92() {

            //var k = 0;
            //$("input[name=p]").each(function (index) {
                //if ($(this).is(':checked')) {
                    var jsonData3 = "{'codasesor':'" + codasesor + "', 'codinstitucion':'" + codinstitucion + "', 'respuesta':'" + $('input:checkbox[name=rtematica]:checked').val() + "', 'pregunta':'9', 'subpregunta':'1'}";

                    $.ajax({
                        type: 'POST',
                        url: 'evalfinalins6.aspx/insertarevaluacion',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData3,
                        success: function () {
                            //console.log("Pregunta 5 guardarda, item: " + $(this).val());
                        },
                        complete: function () {
                            //console.log(k);
                            //if (k == 2) {
                                guardarpreguntaNo93();
                            //}
                        }
                    });
                //}
                //k++;
            //});

        }

                        function guardarpreguntaNo93() {

            //var k = 0;
            //$("input[name=p]").each(function (index) {
                //if ($(this).is(':checked')) {
                    var jsonData3 = "{'codasesor':'" + codasesor + "', 'codinstitucion':'" + codinstitucion + "', 'respuesta':'" + $('input:checkbox[name=espacioa]:checked').val() + "', 'pregunta':'9', 'subpregunta':'1'}";

                    $.ajax({
                        type: 'POST',
                        url: 'evalfinalins6.aspx/insertarevaluacion',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData3,
                        success: function () {
                            //console.log("Pregunta 5 guardarda, item: " + $(this).val());
                        },
                        complete: function () {
                            //console.log(k);
                            //if (k == 2) {
                                guardarpreguntaNo10();
                            //}
                        }
                    });
                //}
                //k++;
            //});

        }

        function guardarpreguntaNo10() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=vinculacion]:checked').val() + '", "pregunta": "10", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 10 guardada");
                },
                complete: function () {
                    guardarpreguntaNo111();
                }
            });
        }

        function guardarpreguntaNo111() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=comunidad]:checked').val() + '", "pregunta": "11", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 111 guardada");
                },
                complete: function () {
                    guardarpreguntaNo112();
                }
            });
        }

        function guardarpreguntaNo112() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=conocimiento]:checked').val() + '", "pregunta": "11", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 112 guardada");
                },
                complete: function () {
                    guardarpreguntaNo113();
                }
            });
        }

        function guardarpreguntaNo113() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=lvive]:checked').val() + '", "pregunta": "11", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 113 guardada");
                },
                complete: function () {
                    guardarpreguntaNo114();
                }
            });
        }

        function guardarpreguntaNo114() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=investi]:checked').val() + '", "pregunta": "11", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 114 guardada");
                },
                complete: function () {
                    guardarpreguntaNo115();
                }
            });
        }

        function guardarpreguntaNo115() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=ferias]:checked').val() + '", "pregunta": "11", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 115 guardada");
                },
                complete: function () {
                    guardarpreguntaNo116();
                }
            });
        }

        function guardarpreguntaNo116() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=jgc]:checked').val() + '", "pregunta": "11", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 116 guardada");
                },
                complete: function () {
                    guardarpreguntaNo117();
                }
            });
        }

        function guardarpreguntaNo117() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=otro1]:checked').val() + '", "pregunta": "11", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 117 guardada");
                },
                complete: function () {
                    guardarpreguntaNo118();
                }
            });
        }

        function guardarpreguntaNo118() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#txtotro1').val() + '", "pregunta": "11", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 118 guardada");
                },
                complete: function () {
                    guardarpreguntaNo121();
                }
            });
        }

        function guardarpreguntaNo121() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=ltematica]:checked').val() + '", "pregunta": "12", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 121 guardada");
                },
                complete: function () {
                    guardarpreguntaNo122();
                }
            });
        }

        function guardarpreguntaNo122() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=linstitucion]:checked').val() + '", "pregunta": "12", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 122 guardada");
                },
                complete: function () {
                    guardarpreguntaNo123();
                }
            });
        }

        function guardarpreguntaNo123() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=compañeros]:checked').val() + '", "pregunta": "12", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 123 guardada");
                },
                complete: function () {
                    guardarpreguntaNo124();
                }
            });
        }

        function guardarpreguntaNo124() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#otro2').val() + '", "pregunta": "12", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1171 guardada");
                },
                complete: function () {
                    guardarpreguntaNo131();
                }
            });
        }

        function guardarpreguntaNo131() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=a16]:checked').val() + '", "pregunta": "13", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 131 guardada");
                },
                complete: function () {
                    guardarpreguntaNo132();
                }
            });
        }

        function guardarpreguntaNo132() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=a17]:checked').val() + '", "pregunta": "13", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 132 guardada");
                },
                complete: function () {
                    guardarpreguntaNo133();
                }
            });
        }

        function guardarpreguntaNo133() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=a18]:checked').val() + '", "pregunta": "13", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 133 guardada");
                },
                complete: function () {
                    guardarpreguntaNo141();
                }
            });
        }

        function guardarpreguntaNo141() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=leer]:checked').val() + '", "pregunta": "14", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 141 guardada");
                },
                complete: function () {
                    guardarpreguntaNo142();
                }
            });
        }

        function guardarpreguntaNo142() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=fpreguntas]:checked').val() + '", "pregunta": "14", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 142 guardada");
                },
                complete: function () {
                    guardarpreguntaNo143();
                }
            });
        }

        function guardarpreguntaNo143() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=hexperi]:checked').val() + '", "pregunta": "14", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 143 guardada");
                },
                complete: function () {
                    guardarpreguntaNo144();
                }
            });
        }

        function guardarpreguntaNo144() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=escribir]:checked').val() + '", "pregunta": "14", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 144 guardada");
                },
                complete: function () {
                    guardarpreguntaNo145();
                }
            });
        }

        function guardarpreguntaNo145() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=entrevista]:checked').val() + '", "pregunta": "14", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 145 guardada");
                },
                complete: function () {
                    guardarpreguntaNo146();
                }
            });
        }

        function guardarpreguntaNo146() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=observar]:checked').val() + '", "pregunta": "14", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 146 guardada");
                },
                complete: function () {
                    guardarpreguntaNo147();
                }
            });
        }

        function guardarpreguntaNo147() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=analizar]:checked').val() + '", "pregunta": "14", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 147 guardada");
                },
                complete: function () {
                    guardarpreguntaNo148();
                }
            });
        }

        function guardarpreguntaNo148() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=rdatos]:checked').val() + '", "pregunta": "14", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 148 guardada");
                },
                complete: function () {
                    guardarpreguntaNo149();
                }
            });
        }

        function guardarpreguntaNo149() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=sconclusion]:checked').val() + '", "pregunta": "14", "subpregunta": "9"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 149 guardada");
                },
                complete: function () {
                    guardarpreguntaNo1410();
                }
            });
        }

        function guardarpreguntaNo1410() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=cresultados]:checked').val() + '", "pregunta": "14", "subpregunta": "10"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1410 guardada");
                },
                complete: function () {
                    guardarpreguntaNo1411();
                }
            });
        }

        function guardarpreguntaNo1411() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=tgrupo]:checked').val() + '", "pregunta": "14", "subpregunta": "11"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1411 guardada");
                },
                complete: function () {
                    guardarpreguntaNo1412();
                }
            });
        }

        function guardarpreguntaNo1412() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=tgrupo]:checked').val() + '", "pregunta": "14", "subpregunta": "12"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1412 guardada");
                },
                complete: function () {
                    guardarpreguntaNo1413();
                }
            });
        }

        function guardarpreguntaNo1413() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#cuales1').val() + '", "pregunta": "14", "subpregunta": "13"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1413 guardada");
                },
                complete: function () {
                    guardarpreguntaNo151();
                }
            });
        }

        function guardarpreguntaNo151() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=djornada]:checked').val() + '", "pregunta": "15", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 151 guardada");
                },
                complete: function () {
                    guardarpreguntaNo152();
                }
            });
        }

        function guardarpreguntaNo152() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=fjornada]:checked').val() + '", "pregunta": "15", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 152 guardada");
                },
                complete: function () {
                    guardarpreguntaNo16();
                }
            });
        }

        function guardarpreguntaNo16() {

            //var k = 0;
            //$("input[name=horassemanales]").each(function (index) {
                //if ($(this).is(':checked')) {
                    var jsonData3 = "{'codasesor':'" + codasesor + "', 'codinstitucion':'" + codinstitucion + "', 'respuesta':'" + $('input:radio[name=horassemanales]:checked').val() + "', 'pregunta':'16', 'subpregunta':'1'}";

                    $.ajax({
                        type: 'POST',
                        url: 'evalfinalins6.aspx/insertarevaluacion',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData3,
                        success: function () {
                            //console.log("Pregunta 5 guardarda, item: " + $(this).val());
                        },
                        complete: function () {
                            //console.log(k);
                            //if (k == 4) {
                                guardarpreguntaNo171();
                            //}
                        }
                    });
                //}
            //    k++;
            //});
           
        }

        function guardarpreguntaNo171() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=entregamateriales]:checked').val() + '", "pregunta": "17", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 171 guardada");
                },
                complete: function () {
                    guardarpreguntaNo172();
                }
            });
        }

        function guardarpreguntaNo172() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=tallerinves]:checked').val() + '", "pregunta": "17", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 172 guardada");
                },
                complete: function () {
                    guardarpreguntaNo173();
                }
            });
        }

        function guardarpreguntaNo173() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=asignacionasesor]:checked').val() + '", "pregunta": "17", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 173 guardada");
                },
                complete: function () {
                    guardarpreguntaNo174();
                }
            });
        }

        function guardarpreguntaNo174() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=participaferias]:checked').val() + '", "pregunta": "17", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 174 guardada");
                },
                complete: function () {
                    guardarpreguntaNo175();
                }
            });
        }

        function guardarpreguntaNo175() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=apoyoeconomico]:checked').val() + '", "pregunta": "17", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 175 guardada");
                },
                complete: function () {
                    guardarpreguntaNo176();
                }
            });
        }

        function guardarpreguntaNo176() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=plataformapago]:checked').val() + '", "pregunta": "17", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 176 guardada");
                },
                complete: function () {
                    guardarpreguntaNo177();
                }
            });
        }

        function guardarpreguntaNo177() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=otros17]:checked').val() + '", "pregunta": "17", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 177 guardada");
                },
                complete: function () {
                    guardarpreguntaNo178();
                }
            });
        }

        function guardarpreguntaNo178() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#cuales17').val() + '", "pregunta": "17", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 178 guardada");
                },
                complete: function () {
                    guardarpreguntaNo181();
                }
            });
        }

        function guardarpreguntaNo181() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=guias]:checked').val() + '", "pregunta": "18", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 181 guardada");
                },
                complete: function () {
                    guardarpreguntaNo182();
                }
            });
        }

        function guardarpreguntaNo182() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=laboratorio]:checked').val() + '", "pregunta": "18", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 182 guardada");
                },
                complete: function () {
                    guardarpreguntaNo183();
                }
            });
        }

        function guardarpreguntaNo183() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=recursosdidacticos]:checked').val() + '", "pregunta": "18", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 183 guardada");
                },
                complete: function () {
                    guardarpreguntaNo184();
                }
            });
        }

        function guardarpreguntaNo184() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=tabletas]:checked').val() + '", "pregunta": "18", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 184 guardada");
                },
                complete: function () {
                    guardarpreguntaNo185();
                }
            });
        }

        function guardarpreguntaNo185() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=computadores]:checked').val() + '", "pregunta": "18", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 185 guardada");
                },
                complete: function () {
                    guardarpreguntaNo186();
                }
            });
        }

        function guardarpreguntaNo186() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=videobeam]:checked').val() + '", "pregunta": "18", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 186 guardada");
                },
                complete: function () {
                    guardarpreguntaNo187();
                }
            });
        }

        function guardarpreguntaNo187() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=amplificador]:checked').val() + '", "pregunta": "18", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 187 guardada");
                },
                complete: function () {
                    guardarpreguntaNo188();
                }
            });
        }

        function guardarpreguntaNo188() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=discuduro]:checked').val() + '", "pregunta": "18", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 188 guardada");
                },
                complete: function () {
                    guardarpreguntaNo189();
                }
            });
        }

        function guardarpreguntaNo189() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=camara]:checked').val() + '", "pregunta": "18", "subpregunta": "9"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 189 guardada");
                },
                complete: function () {
                    guardarpreguntaNo1810();
                }
            });
        }

        function guardarpreguntaNo1810() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=otrosmateriales]:checked').val() + '", "pregunta": "18", "subpregunta": "10"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1810 guardada");
                },
                complete: function () {
                    guardarpreguntaNo1811();
                }
            });
        }

        function guardarpreguntaNo1811() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#cuales1810').val() + '", "pregunta": "18", "subpregunta": "11"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 1810 guardada");
                },
                complete: function () {
                    guardarpreguntaNo191();
                }
            });
        }

        function guardarpreguntaNo191() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=feriasinstitucionales]:checked').val() + '", "pregunta": "19", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 191 guardada");
                },
                complete: function () {
                    guardarpreguntaNo192();
                }
            });
        }

        function guardarpreguntaNo192() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=feriasmunicipales]:checked').val() + '", "pregunta": "19", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 192 guardada");
                },
                complete: function () {
                    guardarpreguntaNo193();
                }
            });
        }

        function guardarpreguntaNo193() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=feriasdepartamentales]:checked').val() + '", "pregunta": "19", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 193 guardada");
                },
                complete: function () {
                    guardarpreguntaNo194();
                }
            });
        }

        function guardarpreguntaNo194() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=feriasregionales]:checked').val() + '", "pregunta": "19", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 194 guardada");
                },
                complete: function () {
                    guardarpreguntaNo195();
                }
            });
        }

        function guardarpreguntaNo195() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=feriasnacionales]:checked').val() + '", "pregunta": "19", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 195 guardada");
                },
                complete: function () {
                    guardarpreguntaNo196();
                }
            });
        }

        function guardarpreguntaNo196() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=feriasinternacionales]:checked').val() + '", "pregunta": "19", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 196 guardada");
                },
                complete: function () {
                    guardarpreguntaNo20();
                }
            });
        }

        function guardarpreguntaNo20() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=talleresorganizados]:checked').val() + '", "pregunta": "20", "subpregunta": "0"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 20 guardada");
                },
                complete: function () {
                    guardarpreguntaNo21();
                }
            });
        }

        function guardarpreguntaNo21() {

            var k = 0;
            //$("input[name=talleshasparticipado]").each(function (index) {
                //if ($(this).is(':checked')) {
                    var jsonData3 = "{'codasesor':'" + codasesor + "', 'codinstitucion':'" + codinstitucion + "', 'respuesta':'" + $('input:radio[name=talleresorganizados]:checked').val() + "', 'pregunta':'21', 'subpregunta':'0'}";

                    $.ajax({
                        type: 'POST',
                        url: 'evalfinalins6.aspx/insertarevaluacion',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData3,
                        success: function () {
                            //console.log("Pregunta 5 guardarda, item: " + $(this).val());
                        },
                        complete: function () {
                            //console.log(k);
                            //if (k == 4) {
                                guardarpreguntaNo221();
                            //}
                        }
                    });
                //}
                //k++;
            //});
        }

        function guardarpreguntaNo221() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=alcalde]:checked').val() + '", "pregunta": "22", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 221 guardada");
                },
                complete: function () {
                    guardarpreguntaNo222();
                }
            });
        }

        function guardarpreguntaNo222() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=rector]:checked').val() + '", "pregunta": "22", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 222 guardada");
                },
                complete: function () {
                    guardarpreguntaNo223();
                }
            });
        }

        function guardarpreguntaNo223() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=maestroacompana]:checked').val() + '", "pregunta": "22", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 223 guardada");
                },
                complete: function () {
                    guardarpreguntaNo224();
                }
            });
        }

        function guardarpreguntaNo224() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=asesorproyecto]:checked').val() + '", "pregunta": "22", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 224 guardada");
                },
                complete: function () {
                    guardarpreguntaNo225();
                }
            });
        }

        function guardarpreguntaNo225() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=funcionariosoperadoras]:checked').val() + '", "pregunta": "22", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 225 guardada");
                },
                complete: function () {
                    guardarpreguntaNo226();
                }
            });
        }

        function guardarpreguntaNo226() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=investigau]:checked').val() + '", "pregunta": "22", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 226 guardada");
                },
                complete: function () {
                    guardarpreguntaNo227();
                }
            });
        }

        function guardarpreguntaNo227() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=evaluadorferia]:checked').val() + '", "pregunta": "22", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 227 guardada");
                },
                complete: function () {
                    guardarpreguntaNo228();
                }
            });
        }

        function guardarpreguntaNo228() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=docenteasesorredes]:checked').val() + '", "pregunta": "22", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 228 guardada");
                },
                complete: function () {
                    guardarpreguntaNo229();
                }
            });
        }

        function guardarpreguntaNo229() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=otros229]:checked').val() + '", "pregunta": "22", "subpregunta": "9"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 229 guardada");
                },
                complete: function () {
                    guardarpreguntaNo2210();
                }
            });
        }

        function guardarpreguntaNo2210() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#txtquienes229').val() + '", "pregunta": "22", "subpregunta": "10"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2210 guardada");
                },
                complete: function () {
                    guardarpreguntaNo231();
                }
            });
        }

        function guardarpreguntaNo231() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=secredeparta]:checked').val() + '", "pregunta": "23", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 231 guardada");
                },
                complete: function () {
                    guardarpreguntaNo232();
                }
            });
        }

        function guardarpreguntaNo232() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=operadoras]:checked').val() + '", "pregunta": "23", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 232 guardada");
                },
                complete: function () {
                    guardarpreguntaNo233();
                }
            });
        }

        function guardarpreguntaNo233() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=universidades]:checked').val() + '", "pregunta": "23", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 233 guardada");
                },
                complete: function () {
                    guardarpreguntaNo234();
                }
            });
        }

        function guardarpreguntaNo234() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=escuelasnormales]:checked').val() + '", "pregunta": "23", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 234 guardada");
                },
                complete: function () {
                    guardarpreguntaNo235();
                }
            });
        }

        function guardarpreguntaNo235() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=alcaldia]:checked').val() + '", "pregunta": "23", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 235 guardada");
                },
                complete: function () {
                    guardarpreguntaNo236();
                }
            });
        }

        function guardarpreguntaNo236() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=umata]:checked').val() + '", "pregunta": "23", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 236 guardada");
                },
                complete: function () {
                    guardarpreguntaNo237();
                }
            });
        }

        function guardarpreguntaNo237() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=icbf]:checked').val() + '", "pregunta": "23", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 237 guardada");
                },
                complete: function () {
                    guardarpreguntaNo238();
                }
            });
        }

        function guardarpreguntaNo238() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=corpomag]:checked').val() + '", "pregunta": "23", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 238 guardada");
                },
                complete: function () {
                    guardarpreguntaNo239();
                }
            });
        }

        function guardarpreguntaNo239() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=sena]:checked').val() + '", "pregunta": "23", "subpregunta": "9"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 239 guardada");
                },
                complete: function () {
                    guardarpreguntaNo2310();
                }
            });
        }

        function guardarpreguntaNo2310() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=otras23]:checked').val() + '", "pregunta": "23", "subpregunta": "10"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2310 guardada");
                },
                complete: function () {
                    guardarpreguntaNo2311();
                }
            });
        }

        function guardarpreguntaNo2311() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('#txtquienes2310').val() + '", "pregunta": "23", "subpregunta": "11"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2311 guardada");
                },
                complete: function () {
                    guardarpreguntaNo241();
                }
            });
        }

        function guardarpreguntaNo241() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=ciencia]:checked').val() + '", "pregunta": "24", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 241 guardada");
                },
                complete: function () {
                    guardarpreguntaNo242();
                }
            });
        }

        function guardarpreguntaNo242() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=concepto]:checked').val() + '", "pregunta": "24", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 242 guardada");
                },
                complete: function () {
                    guardarpreguntaNo243();
                }
            });
        }

        function guardarpreguntaNo243() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=aumentoparticipa]:checked').val() + '", "pregunta": "24", "subpregunta": "3"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 243 guardada");
                },
                complete: function () {
                    guardarpreguntaNo244();
                }
            });
        }

        function guardarpreguntaNo244() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=preguntasacerca]:checked').val() + '", "pregunta": "24", "subpregunta": "4"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 244 guardada");
                },
                complete: function () {
                    guardarpreguntaNo245();
                }
            });
        }

        function guardarpreguntaNo245() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=soluciones]:checked').val() + '", "pregunta": "24", "subpregunta": "5"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 245 guardada");
                },
                complete: function () {
                    guardarpreguntaNo246();
                }
            });
        }

        function guardarpreguntaNo246() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=comunidad]:checked').val() + '", "pregunta": "24", "subpregunta": "6"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 246 guardada");
                },
                complete: function () {
                    guardarpreguntaNo247();
                }
            });
        }

        function guardarpreguntaNo247() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=calificaciones]:checked').val() + '", "pregunta": "24", "subpregunta": "7"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 247 guardada");
                },
                complete: function () {
                    guardarpreguntaNo248();
                }
            });
        }

        function guardarpreguntaNo248() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=leesmas]:checked').val() + '", "pregunta": "24", "subpregunta": "8"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 248 guardada");
                },
                complete: function () {
                    guardarpreguntaNo249();
                }
            });
        }

        function guardarpreguntaNo249() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=escribemas]:checked').val() + '", "pregunta": "24", "subpregunta": "9"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 249 guardada");
                },
                complete: function () {
                    guardarpreguntaNo2410();
                }
            });
        }

        function guardarpreguntaNo2410() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=trabajamas]:checked').val() + '", "pregunta": "24", "subpregunta": "10"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2410 guardada");
                },
                complete: function () {
                    guardarpreguntaNo2411();
                }
            });
        }

        function guardarpreguntaNo2411() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=argumentas]:checked').val() + '", "pregunta": "24", "subpregunta": "11"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2411 guardada");
                },
                complete: function () {
                    guardarpreguntaNo2412();
                }
            });
        }

        function guardarpreguntaNo2412() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=comunica]:checked').val() + '", "pregunta": "24", "subpregunta": "12"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 2412 guardada");
                },
                complete: function () {
                    guardarpreguntaNo251();
                }
            });
        }

        function guardarpreguntaNo251() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=actividad]:checked').val() + '", "pregunta": "25", "subpregunta": "1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 251 guardada");
                },
                complete: function () {
                    guardarpreguntaNo252();
                }
            });
        }

        function guardarpreguntaNo252() {

            var jsonData = '{ "codasesor":"' + codasesor + '", "codinstitucion": "' + codinstitucion + '", "respuesta": "' + $('input:radio[name=hacerclase]:checked').val() + '", "pregunta": "25", "subpregunta": "2"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins6.aspx/insertarevaluacion',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log("pregunta 252 guardada");
                },
                complete: function () {
                    $(".desactivarC1").fadeOut(500);
                }
            });
        }
         function valida(e){
            tecla = (document.all) ? e.keyCode : e.which;

            //Tecla de retroceso para borrar, siempre la permite
            if (tecla==8){
                return true;
            }
                
            // Patron de entrada, en este caso solo acepta numeros
            patron =/[0-9]/;
            tecla_final = String.fromCharCode(tecla);
            return patron.test(tecla_final);
        }
    </script>

        <style type="text/css">
        .txtlabel{
            display: block;
            
        }
        .pregunt{
            margin-left: 30px;
        }



    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>


    <div id="mensaje" runat="server"></div><br /><br />
    <h2 style="text-decoration: none;"><center>FORTALECIMIENTO DE LA CULTURA CIUDADANA Y DEMOCRÁTICA EN CT+I </center><br /><center>A TRAVÉS DE LA IEP APOYADA EN TIC EN EL DPTO DEL MAGDALENA</center><br /><br /><br /><center>Evaluación Final</center></h2>
    <br />
    <asp:Label ID="lblCodDANE" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblCodInstAsesor" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodRol" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodInstitucion" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodAsesor" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblBack" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblLineaBaseSede" runat="server" Visible="False"></asp:Label>


    <center>
        <h2>
            Instrumento No. 06 
            <br />
            <br />
            Percepciones de los estudiantes sobre el programa Ciclón
 
        </h2>
    </center>

        <p>
            <b>Introducción:</b><br /><br />

            <b>Objetivo del cuestionario:</b> Obtener información acerca de la percepción de los estudiantes beneficiados sobre el Programa Ciclón, que permita medir su impacto en estos actores. 
            <br />
            <br />
             Está dirigido a estudiantes beneficiarios de más de dos (2) estrategias del programa Ciclón:
            <br /><br />
            1.	Grupos de investigación.
            <br /><br />
            2.	Redes temáticas institucionales
            <br /><br />
            3.	Espacios de apropiación social (ferias municipales, departamentales, regionales, nacionales e internacionales).
            <br><br>
            Complete la información solicitada e indique con una <b>X</b>, donde corresponda.
   
        </p>

        <fieldset>
            <legend>DATOS GENERALES</legend>
            <table style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;">
                <tr>
                    <td> 
                        <label class="txtlabel">1.  Fecha de realización del cuestionario:</label>
                        <input type="date" class="TextBox pregunt" id="fechacues" name="nombre" />
                    </td>
                </tr>
                <tr>
                    <td> 
                        <label class="txtlabel">2.  Edad:</label>
                         <input type="text" class="TextBox pregunt" id="edadcues" name="telefono" width="50" onkeypress="return valida(event)"  maxlength="2"/>
                     </td>
                </tr>
                    
                </tr>
                 <tr>
                    <td> 
                        <label class="txtlabel">3. Seleccione el sexo:</label>
                        <table align="left" class="mGridTesoreria pregunt">
                            
                            <thead>

                                <th>4. Género</th>
                                <th>Seleccione</th>

                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        Masculino
                                    </td>
                                    <td
                                        style="text-align:center; vertical-align: middle;">

                                        <input type="radio" name="p10" id="M" value="m">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Femenino
                                    </td>
                                    <td
                                        style="text-align:center; vertical-align: middle;">

                                        <input type="radio" name="p10" id="F" value="f">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td> 
                        <label class="txtlabel">4.  Grado que cursa actualmente:</label>
                       <input type="text" class="TextBox pregunt" id="gradocursa" name="email" onkeypress="return valida(event)"  maxlength="2"/>
                   </td>
                </tr>
                <tr>
                    <td> 
                        <label class="txtlabel">5.  Nombre de la Institución Educativa en la que estudia actualmente:</label>
                         <input type="text" class="TextBox pregunt" id="nombreinst" name="nombreinst" />
                     </td>
                </tr>


                <tr>
                    <td> 
                        <label class="txtlabel">6.  Indique ¿En qué estrategia(s) del programa Ciclón participaste?:</label>
                    </td>

                </tr>

                 <tr>
                    <td>
                        <table align="left" class="mGridTesoreria pregunt">
                            
                            <thead>
                                <tr>
                                    <th>Estrategia programa Ciclón</th>
                                    <th>Señale</th>
                                </tr>
                            </thead>
                            <tr>
                                <td>Grupos de investigación</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p" id="pp1" value="Grupos de investigación"  /></td>
                                

                            </tr>
                            <tr>
                                <td>Redes temáticas institucionales</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="rtematica" id="pp2" value="Redes temáticas institucionales"  /></td>
                                
                            </tr>

                            <tr>
                                <td>Espacios de apropiación social (ferias)</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="espacioa" id="pp3" value="Espacios de apropiación social (ferias)"  /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>

        <fieldset>
            <legend>DATOS RELACIONADOS CON LA PARTICIPACIÓN DE LOS ESTUDIANTES EN EL PROGRAMA CICLÓN</legend>
            <table>
                <tr>
                    <td class="bold">
                        <b>10. ¿Cómo ha sido tu vinculación al programa Ciclón?:
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="vincu_si" name="vinculacion" type="radio" value="si" />Voluntaria (interés personal)  <input id="vincu_no" type="radio" name="vinculacion" value="no" />Obligatoria (impuesta por una persona)
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <h3>11. ¿Qué te motivó a participar en el programa Ciclón?:
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>11.1.   La necesidad de resolver un problema de su comunidad o municipio
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="comunidad_si" name="comunidad" type="radio" value="si" />Si<input id="comunidad_no" type="radio" name="comunidad" value="no" />No
                    </td>
                </tr>
                 <tr>
                    <td class="bold"><br>
                        <b>11.2.    El interés por profundizar en el conocimiento de un tema
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="conoci_si" name="conocimiento" type="radio" value="si" />Si<input id="conoci_no" type="radio" name="conocimiento" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>11.3.    La necesidad de mejorar el lugar donde se vive
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="vive_si" name="lvive" type="radio" value="si" />Si<input id="vive_no" type="radio" name="lvive" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>11.4.    El interés de aprender a investigar
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="inves_si" name="investi" type="radio" value="si" />Si<input id="inves_no" type="radio" name="investi" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>11.5.    El interés de participar en las ferias
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="ferias_si" name="ferias" type="radio" value="si" />Si<input id="ferias_no" type="radio" name="ferias" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>11.6.    El interés de participar en el Juego Gózate la Ciencia
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="jgc_si" name="jgc" type="radio" value="si" />Si<input id="jgc_no" type="radio" name="jgc" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>11.7.    Otro aspecto
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="otro1_si" name="otro1" type="radio" value="si" />Si<input id="otro1_no" type="radio" name="otro1" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea rows="5" cols="50" id="txtotro1" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <h3>12.  Si eres un estudiante, miembro de una Red temática de investigación, indica qué motivó la selección de la línea temática (ambiental, bienestar infantil, energía, historia):
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>12.1.    Interés personal por la línea temática:
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="ltematica_si" name="ltematica" type="radio" value="si" />Si<input id="ltematica_no" type="radio" name="ltematica" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>12.2.    El tema de la línea se ha venido trabajando en la institución:
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="linstitucion_si" name="linstitucion" type="radio" value="si" />Si<input id="linstitucion_no" type="radio" name="linstitucion" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>12.3.    Porque el tema es de interés de mis compañeros(as)
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="compa_si" name="compañeros" type="radio" value="si" />Si<input id="compa_no" type="radio" name="compañeros" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>12.4.    Otro
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea  rows="5" cols="50" id="otro2" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <h3> 13.  En cuáles años estuviste vinculado al Programa Ciclón:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>13.1.    Año 2016
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="a16_si" name="a16" type="radio" value="si" />Si<input id="a16_no" type="radio" name="a16" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>13.2.    Año 2017 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="a17_si" name="a17" type="radio" value="si" />Si<input id="a17_no" type="radio" name="a17" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>13.3.    Año 2018
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="a18_si" name="a18" type="radio" value="si" />Si<input id="a18_no" type="radio" name="a18" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 14.  Las actividades que has realizado dentro del Programa Ciclón han sido:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.1.    Leer
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="leer_si" name="leer" type="radio" value="si" />Si<input id="leer_no" type="radio" name="leer" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.2.    Formular preguntas
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="fpregutnas_si" name="fpreguntas" type="radio" value="si" />Si<input id="fpregutnas_no" type="radio" name="fpreguntas" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.3.    Hacer experimentos
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="hexperi_si" name="hexperi" type="radio" value="si" />Si<input id="hexperi_no" type="radio" name="hexperi" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.4.    Escribir
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="escribir_si" name="escribir" type="radio" value="si" />Si<input id="escribir_no" type="radio" name="escribir" value="no" />No
                    </td>
                </tr>
                 <tr>
                    <td class="bold"><br>
                        <b>14.5.    Entrevistar
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="entrevista_si" name="entrevista" type="radio" value="si" />Si<input id="entrevista_no" type="radio" name="entrevista" value="no" />No
                    </td>
                </tr>
                 <tr>
                    <td class="bold"><br>
                        <b>14.6.    Observar
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="observar_si" name="observar" type="radio" value="si" />Si<input id="observar_no" type="radio" name="observar" value="no" />No
                    </td>
                </tr>
                 <tr>
                    <td class="bold"><br>
                        <b>14.7.    Analizar
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="analizar_si" name="analizar" type="radio" value="si" />Si<input id="analizar_no" type="radio" name="analizar" value="no" />No
                    </td>
                </tr>
                 <tr>
                    <td class="bold"><br>
                        <b>14.8.    Registrar datos
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="rdatos_si" name="rdatos" type="radio" value="si" />Si<input id="rdatos_no" type="radio" name="rdatos" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.9.    Sacar conclusiones
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="sconclusion_si" name="sconclusion" type="radio" value="si" />Si<input id="sconclusion_no" type="radio" name="sconclusion" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.10.   Comunicar resultados
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="cresultados_si" name="cresultados" type="radio" value="si" />Si<input id="cresultados_no" type="radio" name="cresultados" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>14.11.   Trabajar en grupo
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="tgrupo_si" name="tgrupo" type="radio" value="si" />Si<input id="tgrupo_no" type="radio" name="tgrupo" value="no" />No
                    </td>
                </tr>
                 <tr>
                    <td class="bold"><br>
                        <b>14.12.   Otras
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="otras1_si" name="otras1" type="radio" value="si" />Si<input id="otras1_no" type="radio" name="otras1" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        ¿Cuales?
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea rows="5" cols="50" id="cuales1" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 15. Las actividades del programa Ciclón las has desarrollo:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>15.1.    Durante la jornada escolar
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="djornada_si" name="djornada" type="radio" value="si" />Si<input id="djornada_no" type="radio" name="djornada" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>15.2.    Fuera de la jornada escolar
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="fjornada_si" name="fjornada" type="radio" value="si" />Si<input id="fjornada_no" type="radio" name="fjornada" value="no" />No
                    </td>
                </tr> 
                <tr>
                    <td class="bold"><br>
                        <b>16. Cuántas horas semanales dedicas al programa Ciclón:
                    </td>
                            <tbody>
                                <tr>
                                    <td>
                                        <input id="uhora" type="radio" name="horassemanales" value="Una hora" />
                                        <label for="MainContent_chkJornadas_0">Una hora</label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <input id="dhoras" type="radio" name="horassemanales" value="Dos horas" />
                                        <label for="MainContent_chkJornadas_0">Dos horas</label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <input id="thoras" type="radio" name="horassemanales" value="Tres horas" />
                                        <label for="MainContent_chkJornadas_0">Tres horas</label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <input id="mthoras" type="radio" name="horassemanales" value="Mas de tres horas" />
                                        <label for="MainContent_chkJornadas_0">Mas de tres horas</label>
                                    </td>
                                </tr>
                            </tbody>
                        </tr>
                 <tr>
                    <td class="bold"><br>
                       <h3> 17. Cuáles son los apoyos que has recibido del programa Ciclón:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.1.    Entrega de materiales
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="entregamateriales_si" name="entregamateriales" type="radio" value="si" />Si<input id="entregamateriales_no" type="radio" name="entregamateriales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.2.    Realización de talleres de investigación
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="tallerinves_si" name="tallerinves" type="radio" value="si" />Si<input id="tallerinves_no" type="radio" name="tallerinves" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.3.    Asignación de un asesor o formador
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="asignacionasesor_si" name="asignacionasesor" type="radio" value="si" />Si<input id="asignacionasesor_no" type="radio" name="asignacionasesor" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.4.    Participación en eventos de ferias
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="participaferias_si" name="participaferias" type="radio" value="si" />Si<input id="participaferias_no" type="radio" name="participaferias" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.5.    Apoyo económico
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="apoyoeconomico_si" name="apoyoeconomico" type="radio" value="si" />Si<input id="apoyoeconomico_no" type="radio" name="apoyoeconomico" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.6.   Plataforma de juego
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="plataformapago_si" name="plataformapago" type="radio" value="si" />Si<input id="plataformapago_no" type="radio" name="plataformapago" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>17.7.   Otros
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="otros17_si" name="otros17" type="radio" value="si" />Si<input id="otros17_no" type="radio" name="otros17" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        ¿Cuales?
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea rows="5" cols="50" id="cuales17" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 18. Los materiales que utilizaste en el fueron:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.1.    Guías de investigación
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="guias_si" name="guias" type="radio" value="si" />Si<input id="guias_no" type="radio" name="guias" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.2.    Instrumentos de laboratorio
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="laboratorio_si" name="laboratorio" type="radio" value="si" />Si<input id="laboratorio_no" type="radio" name="laboratorio" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.3.    Recursos didácticos (papel bond, marcadores, fólderes, Borradores y otros)

                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="recursosdidacticos_si" name="recursosdidacticos" type="radio" value="si" />Si<input id="recursosdidacticos_no" type="radio" name="recursosdidacticos" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.4.    Tabletas
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="tabletas_si" name="tabletas" type="radio" value="si" />Si<input id="tabletas_no" type="radio" name="tabletas" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.5.    Computadores
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="computadores_si" name="computadores" type="radio" value="si" />Si<input id="computadores_no" type="radio" name="computadores" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.6.    Video Beam 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="videobeam_si" name="videobeam" type="radio" value="si" />Si<input id="videobeam_no" type="radio" name="videobeam" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.7.    Amplificador de sonido 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="amplificador_si" name="amplificador" type="radio" value="si" />Si<input id="amplificador_no" type="radio" name="amplificador" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.8.    Disco duro externo 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="discuduro_si" name="discuduro" type="radio" value="si" />Si<input id="discuduro_no" type="radio" name="discuduro" value="no" />No
                    </td>
                </tr> 
                <tr>
                    <td class="bold"><br>
                        <b>18.9.    Cámara fotográfica 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="camara_si" name="camara" type="radio" value="si" />Si<input id="camara_no" type="radio" name="camara" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>18.10.   Otros materiales 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="otrosmateriales_si" name="otrosmateriales" type="radio" value="si" />Si<input id="otrosmateriales_no" type="radio" name="otrosmateriales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        ¿Cuales?
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea rows="5" cols="50" id="cuales1810" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 19. Como miembro de un grupo de investigación, indica en cuáles eventos organizados por el programa Ciclón has participado:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>19.1.    Ferias institucionales: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="feriasinstitucionales_si" name="feriasinstitucionales" type="radio" value="si" />Si<input id="feriasinstitucionales_no" type="radio" name="feriasinstitucionales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>19.2.    Ferias municipales: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="feriasmunicipales_si" name="feriasmunicipales" type="radio" value="si" />Si<input id="feriasmunicipales_no" type="radio" name="feriasmunicipales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>19.3.    Ferias departamentales: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="feriasdepartamentales_si" name="feriasdepartamentales" type="radio" value="si" />Si<input id="feriasdepartamentales_no" type="radio" name="feriasdepartamentales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>19.4.    Ferias regionales: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="feriasregionales_si" name="feriasregionales" type="radio" value="si" />Si<input id="feriasregionales_no" type="radio" name="feriasregionales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>19.5.    Ferias Nacionales: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="feriasnacionales_si" name="feriasnacionales" type="radio" value="si" />Si<input id="feriasnacionales_no" type="radio" name="feriasnacionales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>19.6.    Ferias Internacionales: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="feriasinternacionales_si" name="feriasinternacionales" type="radio" value="si" />Si<input id="feriasinternacionales_no" type="radio" name="feriasinternacionales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>20.  ¿Has participado en talleres organizados por el programa Ciclón para aprender a investigar? 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="talleresorganizados_si" name="talleresorganizados" type="radio" value="si" />Si<input id="talleresorganizados_no" type="radio" name="talleresorganizados" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>21.  Si tu respuesta anterior es positiva, indica ¿En cuántos talleres has participado? 
                    </td>
                            <tbody>
                                <tr>
                                    <td>
                                        <input  type="radio" name="talleshasparticipado" value="Una taller" />
                                        <label for="MainContent_chkJornadas_0">Una taller</label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <input  type="radio" name="talleshasparticipado" value=" Dos talleres" />
                                        <label for="MainContent_chkJornadas_0">Dos talleres</label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <input  type="radio" name="talleshasparticipado" value="Tres talleres" />
                                        <label for="MainContent_chkJornadas_0">Tres talleres</label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <input  type="radio" name="talleshasparticipado" value="Mas de tres talleres" />
                                        <label for="MainContent_chkJornadas_0">Mas de tres talleres</label>
                                    </td>
                                </tr>
                            </tbody>
                        </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 22. Durante tu participación en el Programa Ciclón, ¿Con cuáles de las siguientes personas te has relacionado?:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.1.    El alcalde 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="alcalde_si" name="alcalde" type="radio" value="si" />Si<input id="alcalde_no" type="radio" name="alcalde" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.2.    El rector de la institución 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="rector_si" name="rector" type="radio" value="si" />Si<input id="rector_no" type="radio" name="rector" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.3.    El maestro acompañante 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="maestroacompana_si" name="maestroacompana" type="radio" value="si" />Si<input id="maestroacompana_no" type="radio" name="maestroacompana" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.4.    El asesor del proyecto  de investigación 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="asesorproyecto_si" name="asesorproyecto" type="radio" value="si" />Si<input id="vasesorproyecto_no" type="radio" name="asesorproyecto" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.5.    Entidades operadoras (Funtics, Unimag, CUC y MAFERPI) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="funcionariosoperadoras_si" name="funcionariosoperadoras" type="radio" value="si" />Si<input id="funcionariosoperadoras_no" type="radio" name="funcionariosoperadoras" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.6.    Los Investigadores de las universidades 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="investigau_si" name="investigau" type="radio" value="si" />Si<input id="investigau_no" type="radio" name="investigau" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.7.    El evaluador durante la feria 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="evaluadorferia_si" name="evaluadorferia" type="radio" value="si" />Si<input id="evaluadorferia_no" type="radio" name="evaluadorferia" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.8.    CORPAMAG (Corporación Autónoma Regional del Magdalena) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="docenteasesorredes_si" name="docenteasesorredes" type="radio" value="si" />Si<input id="docenteasesorredes_no" type="radio" name="docenteasesorredes" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>22.9.   Otros 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="otros229_si" name="otros229" type="radio" value="si" />Si<input id="otros229_no" type="radio" name="otros229" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        ¿Quiénes?
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea rows="5" cols="50" id="txtquienes229" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 23. Para la realización de tu proyecto han colaborado instituciones como:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.1.    Secretaría de Educación Departamental 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="secredeparta_si" name="secredeparta" type="radio" value="si" />Si<input id="secredeparta_no" type="radio" name="secredeparta" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.2.    Entidades operadoras del Programa Ciclón (Unimagdalena, CUC, MAFERPI y FUNTICS)
 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="operadoras_si" name="operadoras" type="radio" value="si" />Si<input id="operadoras_no" type="radio" name="operadoras" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.3.    Universidades (Unimagdalena, CUC): 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="universidades_si" name="universidades" type="radio" value="si" />Si<input id="universidades_no" type="radio" name="universidades" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.4.    Escuelas Normales Superiores 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="escuelasnormales_si" name="escuelasnormales" type="radio" value="si" />Si<input id="escuelasnormales_no" type="radio" name="escuelasnormales" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.5.    Alcaldía 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="alcaldia_si" name="alcaldia" type="radio" value="si" />Si<input id="alcaldia_no" type="radio" name="alcaldia" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.6.    UMATA (Unidades Departamentales de Asistencia Técnica Agropecuaria) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="umata_si" name="umata" type="radio" value="si" />Si<input id="umata_no" type="radio" name="umata" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.7.    ICBF (Instituto de Bienestar Familiar) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="icbf_si" name="icbf" type="radio" value="si" />Si<input id="icbf_no" type="radio" name="icbf" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.8.    CORPOMAG (Corporación Autónoma Regional del Magdalena) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="corpomag_si" name="corpomag" type="radio" value="si" />Si<input id="corpomag_no" type="radio" name="corpomag" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.9.   SENA: (Servicio Nacional de Aprendizaje) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="sena_si" name="sena" type="radio" value="si" />Si<input id="sena_no" type="radio" name="sena" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>23.10.  Otras: 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="otras23_si" name="otras23" type="radio" value="si" />Si<input id="otras23_no" type="radio" name="otras23" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        ¿Quiénes?
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea rows="5" cols="50" id="txtquienes2310" class="TextBox"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 24. Con tu participación en el Programa Ciclón, tu:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.1.    Has cambiado tu interés por la ciencia (sociales, naturales) 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="ciencia_si" name="ciencia" type="radio" value="si" />Si<input id="ciencia_no" type="radio" name="ciencia" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.2.    Has cambiado tu concepto de investigación 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="concepto_si" name="concepto" type="radio" value="si" />Si<input id="concepto_no" type="radio" name="concepto" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.3.    Ha aumentado tu participación en actividades científicas y de investigación
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="aumentoparticipa_si" name="aumentoparticipa" type="radio" value="si" />Si<input id="aumentoparticipa_no" type="radio" name="aumentoparticipa" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.4.    Haces preguntas acerca de lo que ocurre en el entorno  
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="preguntasacerca_si" name="preguntasacerca" type="radio" value="si" />Si<input id="preguntasacerca_no" type="radio" name="preguntasacerca" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.5.    Has buscado soluciones a los problemas de su institución 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="soluciones_si" name="soluciones" type="radio" value="si" />Si<input id="soluciones_no" type="radio" name="soluciones" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.6.    Has contribuido a la solución de problemas en la comunidad 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="comunidad_si" name="comunidad" type="radio" value="si" />Si<input id="comunidad_no" type="radio" name="comunidad" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.7.    Han mejorado tus calificaciones 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="calificaciones_si" name="calificaciones" type="radio" value="si" />Si<input id="calificaciones_no" type="radio" name="calificaciones" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.8.    Lees más que antes 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="leesmas_si" name="leesmas" type="radio" value="si" />Si<input id="leesmas_no" type="radio" name="leesmas" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.9.    Escribes más que antes 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="escribemas_si" name="escribemas" type="radio" value="si" />Si<input id="escribemas_no" type="radio" name="escribemas" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.10.   Trabajas más en equipo 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="trabajamas_si" name="trabajamas" type="radio" value="si" />Si<input id="trabajamas_no" type="radio" name="trabajamas" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.11.   Argumentas mejor tus ideas 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="argumentas_si" name="argumentas" type="radio" value="si" />Si<input id="argumentas_no" type="radio" name="argumentas" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>24.12.   Comunicas los resultados de tu trabajo a tus compañeros y en la comunidad 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="comunica_si" name="comunica" type="radio" value="si" />Si<input id="comunica_no" type="radio" name="comunica" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                       <h3> 25. Con la ejecución del programa Ciclón:</h3>
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>25.1.    Su institución educativa, ha realizado más actividades científicas que antes 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="actividad_si" name="actividad" type="radio" value="si" />Si<input id="actividad_no" type="radio" name="actividad" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br>
                        <b>25.2.    Su maestro(a) ha cambiado la forma de hacer la clase 
                    </td>
                </tr>
                <tr>
                    <td>
                      <input id="hacerclase_si" name="hacerclase" type="radio" value="si" />Si<input id="hacerclase_no" type="radio" name="hacerclase" value="no" />No
                    </td>
                </tr>
            </table>
            <div class="center"><br /><a href="javascript:void(0)" class="btn btn-success" onclick="enviar()">Guardar</a></div>
        </fieldset>
        
       
</asp:Content>

