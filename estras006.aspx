<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras006.aspx.cs" Inherits="estras006" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
   <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
	<style> 
		body{
			font-family: arial;
		}
		fieldset{
			padding: 10px;
		}
		table.border td, table.border th{
			/*border: 1px solid;*/
			margin: 0;
			padding: 0;
		}
		table.border tr,table.border{
			margin: 0;
			padding: 0;
		}
		.width-100{
			width: 100%;
		}
		.width-40{
			width: 40px;
		}
		table.padding tr,table.padding{
			padding: 5px;
			margin: 5px;
		}
		.width-90{
			width: 90%;
		}
	</style>
	<script>
	    
	    var total = 1;
	    var total1 = 1;
	    var total2 = 1;

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
	        reset();

	        cargarinstituciones();

	        $("#add").click(function () {
	            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
	            if ($.trim($("#nombresapellidosexpositores" + total).val()) == '') {

	                alert("ingrese la pregunta Nombres y apellido del expositor No." + total);
	                $("#nombresapellidosexpositores" + total).focus();
	            }
	            else if ($.trim($("#correoexpositores" + total).val()) == '') {
	                alert("ingrese la pregunta Correo electrónico del expositor No." + total);
	                $("#correoexpositores" + total).focus();
	            }
	            else if (!regex.test($('#correoexpositores' + total).val().trim())) {
	                alert("Por favor, ingrese un E-Mail valido");
	                $("#correoexpositores" + total).focus();
	            }
	            else {
	                total = parseInt(total) + 1;
	                // alert(total);
	                if ($("#remove")) {
	                    $("#remove").remove();
	                }
	                html = '<tr id="campus' + total + '">';
	                html += '<td>' + total + '.</td>';
	                html += '<td><input type="text" id="nombresapellidosexpositores' + total + '" name="nombresapellidosexpositores' + total + '" class="width-90 TextBox"></td>';
	                html += '<td id="radiotr' + total + '"><input type="text" id="correoexpositores' + total + '" name="correoexpositores' + total + '" class="width-90 TextBox"><button id="remove" class="btn btn-danger" onclick="fRemove(' + total + ')">-</button></td></tr>';
	                $("#tablecampus").append(html);
	            }
	        });

	        $("#add1").click(function () {
	            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;

	            if ($.trim($("#nombreapellidosintegrantes" + total1).val()) == '') {

	                alert("ingrese la pregunta Nombres y apellidos de los integrantes del grupo  No." + total1);
	                $("#nombreapellidosintegrantes" + total1).focus();
	            }
	            else if ($.trim($("#correointegrantes" + total1).val()) == '') {
	                alert("Correo electrónico de los integrantes del grupo No." + total1);
	                $("#correointegrantes" + total1).focus();
	            }
	            else if (!regex.test($('#correointegrantes' + total1).val().trim())) {
	                alert("Por favor, ingrese un E-Mail valido");
	                $("#correointegrantes" + total).focus();
	            }
	            else {
	                total1 = parseInt(total1) + 1;

	                // alert(total1);
	                if ($("#oRemove")) {
	                    $("#oRemove").remove();
	                }
	                html = '<tr id="oCampus' + total1 + '">';
	                html += '<td>' + total1 + '.</td>';
	                html += '<td><input type="text" id="nombreapellidosintegrantes' + total1 + '" name="nombreapellidosintegrantes' + total1 + '" class="width-90 TextBox"></td>';
	                html += '<td id="oRadiotr' + total1 + '"><input type="text" id="correointegrantes' + total1 + '" name="correointegrantes' + total1 + '" class="width-90 TextBox"><button id="oRemove" class="btn btn-danger" onclick="foRemove(' + total1 + ')">-</button></td></tr>';
	                $("#oTablecampus").append(html);
	            }
	        });

	        $("#add2").click(function () {

	            if ($.trim($("#pregunta" + total2).val()) != '') {

	                total2 = parseInt(total2) + 1;
	                // alert(total);
	                if ($("#remove1")) {
	                    $("#remove1").remove();
	                }
	                html = '<tr id="campus1' + total2 + '">';


	                html += '<td>' + total2 + '.</td>';
	                html += '<td id="radiotr1' + total2 + '"><input type="text" id="pregunta' + total2 + '" name="pregunta' + total2 + '" class="width-90 TextBox"><button id="remove1" class="btn btn-danger" onclick="fRemove1(' + total2 + ')">-</button></td></tr>';
	                $("#oTablecampus1").append(html);
	            }
	            else {
	                alert("ingrese la pregunta No. " + total2 + ", para poder agregar una nueva");
	                $("#pregunta" + total2).focus();
	            }
	        });

	        
	        $("#institucion").change(function () {
	            reset();
	            var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estras006.aspx/cargarsedes',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    var resp = json.d.split("&");
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
	                url: 'estras006.aspx/loadestras006',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    //console.log(json);
	                    var resp = json.d.split("@");
	                    if (resp[0] === "datosintrumento") {
	                        codigoestrategia = resp[1];

	                        $("#nombresesion").val(resp[2]);
	                        $("#temasesion").val(resp[3]);
	                        $("#informacionadicional").val(resp[4]);
	                        var fechahora = resp[5].split(" ");

	                        $("#fechaelaboracion").val(fechahora[0]);
	                        $("#horasesion").val(resp[6]);
	                        $("#nombresapellidosmoderador").val(resp[7]);
	                        $("#nombresapellidosrelator").val(resp[8]);


	                        document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[9];
	                        document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[10];
	                        document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[11];

	                        $('#btn-guardar').attr('value', 'Actualizar');
	                        $('#btn-guardar').attr('onclick', 'enviars006(\'update\')');

	                        floadExpositores(codigoestrategia);
	                        floadIntegrantes(codigoestrategia);
	                        floadPreguntas(codigoestrategia);

	                    } else if (resp[0] === "vacio") {
	                        $('#btn-guardar').attr('value', 'Guardar todo');
	                        $('#btn-guardar').attr('onclick', 'enviars006(\'insert\')');
	                    } else {
	                        alert("Ocurrio un error");
	                    }
	                }
	            });
	        });



	        $("input[type='date']").datepicker();



	    });

	    function fRemove(data) {
	        // alert(data);
	        var ant = data - 1;
	        total = total - 1;
	        $("#campus" + data).remove();
	        $("#radiotr" + ant).append('<button id="remove" class="btn btn-danger" onclick="fRemove(' + ant + ')">-</button>');
	    }

	    function foRemove(data) {
	        // alert(data);
	        var ant = data - 1;
	        total1 = total1 - 1;
	        $("#oCampus" + data).remove();
	        $("#oRadiotr" + ant).append('<button id="oRemove" class="btn btn-danger" onclick="foRemove(' + ant + ')">-</button>');
	    }

	    function fRemove1(data) {
	        // alert(data);
	        var ant = data - 1;
	        total2 = total2 - 1;
	        $("#campus1" + data).remove();
	        $("#radiotr1" + ant).append('<button id="remove1" class="btn btn-danger" onclick="fRemove1(' + ant + ')">-</button>');
	    }

	    function cargarinstituciones() {
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/cargarInstituciones',
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
	        $("#nombresesion").val('');
	        $("#temasesion").val('');
	        $("#informacionadicional").val('');

	        $("#fechaelaboracion").val('');
	        $("#horasesion").val('');
	        $("#nombresapellidosmoderador").val('');
	        $("#nombresapellidosrelator").val('');

	        document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';
	        document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';
	        document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';

	        html = "<tr>";
	        html += "<th width=\"5%\"> No. </th>";
	        html += "<th>Pregunta</th>";
	        html += "</tr>";
	        html += "<tr>";
	        html += "<td>1.</td>";
	        html += "<td><input type=\"text\" id=\"pregunta1\" name=\"pregunta1\" class=\"width-90 TextBox\"></td>";
	        html += "</tr>";
	        $("#oTablecampus1").html(html);

	        html1 = "<tr>";
	        html1 += "<th width=\"5%\"> No. </th>";
	        html1 += "<th width=\"50%\"> Nombres y apellidos de los integrantes del grupo </th>";
	        html1 += "<th>Correo electrónico de los integrantes del grupo</th>";
	        html1 += "</tr>";
	        html1 += "<tr>";
	        html1 += "<td>1.</td>";
	        html1 += "<td><input type=\"text\" id=\"nombreapellidosintegrantes1\" name=\"nombreapellidosintegrantes1\" class=\"width-90 TextBox\"></td>";
	        html1 += "<td><input type=\"text\" id=\"correointegrantes1\" name=\"correointegrantes1\" class=\"width-90 TextBox\"></td>";
	        html1 += "</tr>";
	        $("#oTablecampus").html(html1);

	        html2 = "<tr><th width=\"5%\"> No. </th>";
	        html2 += "<th width=\"50%\"> Nombres y apellidos de los expositores</th>";
	        html2 += "<th>Correo electrónico de los expositores</th>";
	        html2 += "</tr> ";
	        html2 += "<tr>";
	        html2 += "<td>1.</td>";
	        html2 += "<td><input type=\"text\" id=\"nombresapellidosexpositores1\" name=\"nombresapellidosexpositores1\" class=\"width-90 TextBox\"></td>";
	        html2 += "<td><input type=\"text\" id=\"correoexpositores1\" name=\"correoexpositores1\" class=\"width-90 TextBox\"></td>";
	        html2 += "</tr>";
	        $("#tablecampus").html(html2);

	        total = 1;
	        total1 = 1;
	        total2 = 1;

	    }

	    

	    function enviars006(event) {

	        var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
	         if ($.trim($("#institucion").val()) == '') {
	            alert("Por favor, ingrese Nombre de la entidad y / o Institución Educativa: ");
	            $("#institucion").focus();
	        } else if ($.trim($("#sede").val()) == '') {
	            alert("Por favor, ingrese Sede");
	            $("#sede").focus();
	        } else if ($.trim($("#nombresesion").val()) == '') {
	            alert("Por favor, ingrese Nombre de sesión o actividad de formación");
	            $("#nombresesion").focus();
	        } else if ($.trim($("#temasesion").val()) == '') {
	            alert("Por favor, ingrese Tema de la sesión o actividad de formación");
	            $("#temasesion").focus();
	        }  else if ($.trim($("#informacionadicional").val()) == '') {
	            alert("Por favor, ingrese Información adicional: ");
	            $("#informacionadicional").focus();
	        } else if ($.trim($("#fechaelaboracion").val()) == '') {
	            alert("Por favor, ingrese Fecha de la elaboración de la memoría");
	            $("#fechaelaboracion").focus();
	        } else if ($.trim($("#horasesion").val()) == '') {
	            alert("Por favor, ingrese Hora de la sesión de formación");
	            $("#horasesion").focus();
	        } else if ($.trim($("#nombresapellidosmoderador").val()) == '') {
	            alert("Por favor, ingrese Nombres y apellidos del moderador");
	            $("#nombresapellidosmoderador").focus();
	        } else if ($.trim($("#nombresapellidosrelator").val()) == '') {
	            alert("Por favor, ingrese Nombres y apellidos del relator");
	            $("#nombresapellidosrelator").focus();
	        }
	        else if ($.trim($("#nombresapellidosexpositores" + total).val()) == '') {
	            alert("ingrese la pregunta Nombres y apellido del expositor No." + total + "");
	            $("#nombresapellidosexpositores" + total).focus();
	        }
	        else if ($.trim($("#correoexpositores" + total).val()) == '') {
	            alert("ingrese la pregunta Correo electrónico del expositor No." + total + "");
	            $("#correoexpositores" + total).focus();
	        }
	        else if (!regex.test($('#correoexpositores' + total).val().trim())) {
	            alert("Por favor, ingrese un E-Mail valido");
	            $("#correoexpositores" + total).focus();
	        }



	        else if ($.trim($("#nombreapellidosintegrantes" + total1).val()) == '') {
	            alert("ingrese la pregunta Nombres y apellidos de los integrantes del grupo  No." + total1);
	            $("#nombreapellidosintegrantes" + total1).focus();
	        }
	        else if ($.trim($("#correointegrantes" + total1).val()) == '') {
	            alert("Correo electrónico de los integrantes del grupo No." + total1);
	            $("#correointegrantes" + total1).focus();
	        }
	        else if (!regex.test($('#correointegrantes' + total1).val().trim())) {
	            alert("Por favor, ingrese un E-Mail valido");
	            $("#correointegrantes" + total).focus();
	        }

	        else if ($.trim($("#pregunta" + total2).val()) == '') {
	            alert("ingrese la pregunta No. " + total2 + "");
	            $("#pregunta" + total2).focus();
	        } 

	        else if ($.trim(document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

	            alert("por favor ingrese Aspectos Desarrollados");
	        }
	        else if ($.trim(document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

	            alert("por favor ingrese Conclusiones");

	        }

	        else if ($.trim(document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

	            alert("por favor ingrese Bibliografia");

	        }
	        else {
	            $('body').append('<div class="desactivarC" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:15%;position: fixed;height:100%"></div>');

	            
	            var aspectosdesarrollados = document.getElementById('MainContent_aspectosdesarrollados_ctl02_ctl00').contentWindow.document.body.innerHTML;
	            var conclusiones = document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML;
	            var bibliografia = document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML;

	            if (event == 'insert') {
	                var jsonData = "{'sede': '" + $("#sede").val() + "', 'nombresesion': '" + $("#nombresesion").val() + "', 'temasesion': '" + $("#temasesion").val() + "', 'informacionadicional':'" + $("#informacionadicional").val() + "', 'fechaelaboracion': '" + $("#fechaelaboracion").val() + "', 'horasesion' : '" + $("#horasesion").val() + "', 'nombresapellidosmoderador': '" + $("#nombresapellidosmoderador").val() + "', 'nombresapellidosrelator' : '" + $("#nombresapellidosrelator").val() + "', 'aspectosdesarrollados' : '" + aspectosdesarrollados + "', 'conclusiones' : '" + conclusiones + "', 'bibliografia' : '" + bibliografia + "'}";
	                //console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'estras006.aspx/insertests006',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            codigoestrategia = resp[1];
	                            //alert("registro insertado exitosamente");
	                            $('#btn-guardar').attr('value', 'Actualizar');
	                            $('#btn-guardar').attr('onclick', 'enviars006(\'update\')');
	                        } else {
	                            alert(json.d);
	                        }
	                    }, complete: function () {
	                        finsertexpositores();
	                        finsertintegrantes();
	                        finsertPreguntas();
	                    }
	                });
	            }
	            else if (event == 'update') {
	                var jsonData = "{'codigoestrategia':'" + codigoestrategia + "', 'nombresesion': '" + $("#nombresesion").val() + "', 'temasesion': '" + $("#temasesion").val() + "', 'informacionadicional':'" + $("#informacionadicional").val() + "', 'fechaelaboracion': '" + $("#fechaelaboracion").val() + "', 'horasesion' : '" + $("#horasesion").val() + "', 'nombresapellidosmoderador': '" + $("#nombresapellidosmoderador").val() + "', 'nombresapellidosrelator' : '" + $("#nombresapellidosrelator").val() + "', 'aspectosdesarrollados' : '" + aspectosdesarrollados + "', 'conclusiones' : '" + conclusiones + "', 'bibliografia' : '" + bibliografia + "'}";

	                //console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'estras006.aspx/updateests006',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            //alert("registro guardado exitosamente");
	                            $('#btn-guardar').attr('value', 'Actualizar');
	                            $('#btn-guardar').attr('onclick', 'enviars006(\'update\')');
	                        } else {
	                            alert(resp[1]);
	                        }
	                    }, complete: function () {
	                        finsertexpositores();
	                        finsertintegrantes();
	                        finsertPreguntas();
	                    }
	                });
	            } else {
	                alert("error no hay event");
	            }
	        }


	    }

	    function finsertexpositores() {
	        $('body').append('<div class="desactivarC2" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:15%;position: fixed;height:100%"></div>');

	        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/deleteExpositoress006',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                k1 = 1;
	                var resp = data.d.split("@");
	                if (resp[0] === "true") {

	                    for (var i = 1; i <= total; i++) {
	                        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "numero":"' + i + '", "nombresapellidosexpositores":"' + $("#nombresapellidosexpositores" + i).val() + '", "correoexpositores":"' + $("#correoexpositores" + i).val() + '"}';
	                        $.ajax({
	                            type: 'POST',
	                            url: 'estras006.aspx/insertExpositoress006',
	                            data: jsonData,
	                            contentType: "application/json; charset=utf-8",
	                            dataType: "json",
	                            success: function (data) {
	                                var resp = data.d.split("@");
	                                if (resp[0] === "true") {
	                                    console.log("expositor " + i + "insertado exitosamente");
	                                } else {
	                                    console.error(data.d + " " + i);
	                                    //console.error(data.d);
	                                }
	                            },
	                            complete: function () {
	                                if (k1 == total) {
	                                    $('.desactivarC2').remove().fadeOut(500);
	                                }
	                                k1++;
	                            }
	                        });
	                    }

	                } else {
	                    alert(data.d);
	                }
	            },
	            complete: function () {
	                //alert("registro guardado exitosamente");
	                $('#btn-guardar').attr('value', 'Actualizar');
	                $('#btn-guardar').attr('onclick', 'enviars006(\'update\')');
	            }
	        });
	    }

	    function floadExpositores(codigoestrategia) {
	        total = 1;
	        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "total":' + total + '}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/loadExpositoress006',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                console.log(data);
	                var resp = data.d.split("&");
	                if (resp[0] === "exp") {
	                    $("#tablecampus").html(resp[1]);
	                    total = resp[2];
	                } else {
	                    $("#tablecampus").html(resp[1]);
	                }
	            }
	        });
	    }


        //integrantes
	    function finsertintegrantes() {
	        $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:15%;position: fixed;height:100%"></div>');
	        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/deleteIntegrantess006',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                var resp = data.d.split("@");
	                if (resp[0] === "true") {
	                    k2 = 1;
	                    for (var i = 1; i <= total1; i++) {
	                        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "numero":"' + i + '", "nombreapellidosintegrantes":"' + $("#nombreapellidosintegrantes" + i).val() + '", "correointegrantes":"' + $("#correointegrantes" + i).val() + '"}';
	                        $.ajax({
	                            type: 'POST',
	                            url: 'estras006.aspx/insertIntegrantess006',
	                            data: jsonData,
	                            contentType: "application/json; charset=utf-8",
	                            dataType: "json",
	                            success: function (data) {
	                                var resp = data.d.split("@");
	                                if (resp[0] === "true") {
	                                    console.log("integrante " + i + "insertado exitosamente");
	                                } else {
	                                    console.error(data.d + " " + i);
	                                    //console.error(data.d);
	                                }
	                            }, complete: function () {
	                                
	                                if (k2 == total1) {
	                                    $('.desactivarC1').remove().fadeOut(500);
	                                } 
	                                k2++;
	                            }
	                        });
                            
	                    }

	                } else {
	                    alert(data.d);
	                }
	            },
	            complete: function () {
	                //alert("registro guardado exitosamente");
	                $('#btn-guardar').attr('value', 'Actualizar');
	                $('#btn-guardar').attr('onclick', 'enviars006(\'update\')');
	            }
	        });
	    }

	    function floadIntegrantes(codigoestrategia) {
	        total1 = 1;
	        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "total":' + total1 + '}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/loadIntegrantess006',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                console.log(data);
	                var resp = data.d.split("&");
	                if (resp[0] === "exp") {
	                    $("#oTablecampus").html(resp[1]);
	                    total1 = resp[2];
	                } else {
	                    $("#oTablecampus").html(resp[1]);
	                }
	            }
	        });
	    }


	    //preguntas
	    function finsertPreguntas() {
	        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/deletePreguntass006',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                var resp = data.d.split("@");
	                if (resp[0] === "true") {
	                    k3 = 1;
	                    for (var i = 1; i <= total2; i++) {
	                        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "nopregunta":"' + i + '", "pregunta":"' + $("#pregunta" + i).val() + '"}';
	                        $.ajax({
	                            type: 'POST',
	                            url: 'estras006.aspx/insertPreguntass006',
	                            data: jsonData,
	                            contentType: "application/json; charset=utf-8",
	                            dataType: "json",
	                            success: function (data) {
	                                var resp = data.d.split("@");
	                                if (resp[0] === "true") {
	                                    console.log("pregunta " + i + "insertado exitosamente");
	                                } else {
	                                    console.error(data.d + " " + i);
	                                }
	                            }, complete: function () {

	                                if (k3 == total2) {
	                                    $('.desactivarC').remove().fadeOut(500);
	                                }
	                                k3++;
	                            }
	                        });

	                    }

	                } else {
	                    alert(data.d);
	                }
	            },
	            complete: function () {
	                alert("registro guardado exitosamente");
	                $('#btn-guardar').attr('value', 'Actualizar');
	                $('#btn-guardar').attr('onclick', 'enviars006(\'update\')');
	            }
	        });
	    }

	    function floadPreguntas(codigoestrategia) {
	        total2 = 1;
	        var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "total":' + total2 + '}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras006.aspx/loadPreguntass006',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                console.log(data);
	                var resp = data.d.split("&");
	                if (resp[0] === "preg") {
	                    $("#oTablecampus1").html(resp[1]);
	                    total2 = resp[2];
	                } else {
	                    $("#oTablecampus1").html(resp[1]);
	                }
	            }
	        });
	    }
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Estrategia No <asp:Label runat="server" ID="lblEstrategia" Visible="true"></asp:Label> S006: Relatoría institucional</h2>
    <asp:Label id="lblMomento" runat="server" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="lblActividad" Visible="false"></asp:Label>
  <fieldset>
		    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
		    <table width="100%">
                <tr>
		    		<td width="100%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Nombre de la entidad y / o Institución Educativa: </td>
			    				<td width="70%">
                                    <select name="institucion" id="institucion"  class="width-100 TextBox"><option value="">Seleccione...</option></select>
			    				</td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Sede: </td>
			    				<td width="70%"><select name="sede" id="sede"  class="width-100 TextBox"><option value="">Seleccione...</option></select></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Nombre de sesión o actividad de formación: </td>
			    				<td width="70%"><input type="text" id="nombresesion" name="nombresesion"  class="width-100 TextBox"/></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Tema de la sesión o actividad de formación: </td>
			    				<td width="70%"><input type="text" id="temasesion" name="temasesion"  class="width-100 TextBox"/></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    	
		    	<tr>
		    		<td width="100%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Información adicional: </td>
			    				<td width="70%">
                                    <input type="text" id="informacionadicional" name="informacionadicional"  class="width-100 TextBox"/>
			    				</td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="50%">
		    			<table width="100%">
			    			<tr>
			    				<td width="50%">Fecha de la elaboración de la relatoría institucional: </td>
			    				<td width="50%"><input type="date" id="fechaelaboracion" name="fechaelaboracion"  class="width-100 TextBox"/></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%">
		    			<table width="100%">
			    			<tr>
			    				<td width="50%">Hora de la sesión de formación: </td>
			    				<td width="50%">
                                    <select class="TextBox width-100" name="horasesion" id="horasesion">
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
		    	</tr>
		    	<tr>
		    		<td width="50%" >
		    			<table width="100%">
			    			<tr>
			    				<td width="50%">Nombres y apellidos del moderador: </td>
			    				<td width="50%"><input type="text" id="nombresapellidosmoderador" name="nombresapellidosmoderador"  class="width-100 TextBox"/></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%" >
		    			<table width="100%">
			    			<tr>
			    				<td width="50%">Nombres y apellidos del relator: </td>
			    				<td width="50%"><input type="text" id="nombresapellidosrelator" name="nombresapellidosrelator"  class="width-100 TextBox"/></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>

		    </table>	    
		</fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
		<br>

		<fieldset >

			<!-- <h2 style="display:block; text-align:center">DESARROLLO DEL RELATO INDIVIDUAL</h2> -->
			
		    <table width="100%" class="border" id="tablecampus">
		    	<tr>
		    		<th width="5%">No. </th>
		    		<th width="50%">Nombres y apellidos de los expositores</th>
		    		<th>Correo electrónico de los expositores</th>
		    	</tr>
		    	<tr>
		    		<td>1.</td>
		    		<td><input type="text" id="nombresapellidosexpositores1" name="nombresapellidosexpositores1" class="width-90 TextBox"></td>
		    		<td><input type="text" id="correoexpositores1" name="correoexpositores1" class="width-90 TextBox"></td>
		    	</tr>
		    </table>
		    <table width="100%" >
		    	<tr>
					<td colspan="3" align="right"><button id="add" type="button" class="btn btn-success">+ Add</button></td>
		    	</tr>
		    </table>

		   
		</fieldset>
		<br>
		<fieldset >
		    <table width="100%" class="border" id="oTablecampus">
		    	<tr>
		    		<th width="5%">No. </th>
		    		<th width="50%">Nombres y apellidos de los integrantes del grupo </th>
		    		<th>Correo electrónico de los integrantes del grupo</th>
		    	</tr>
		    	<tr>
		    		<td>1.</td>
		    		<td><input type="text" id="nombreapellidosintegrantes1" name="nombreapellidosintegrantes1" class="width-90 TextBox"></td>
		    		<td><input type="text" id="correointegrantes1" name="correointegrantes1" class="width-90 TextBox"></td>
		    	</tr>
		    </table>
		    <table width="100%" >
		    	<tr>
					<td colspan="3" align="right"><button id="add1" type="button" class="btn btn-success">+ Add</button></td>
		    	</tr>
		    </table>
		</fieldset>

		<br>
		
		<fieldset >

			<h2 style="display:block; text-align:center">DESARROLLO DE LA RELATORÍA INSTITUCIONAL</h2>
			
			<span>1. Relacione las preguntas orientadoras o aspectos fundamentales que se proponen analizar en la sesión o actividad de formación</span><br><br>
		    <table width="100%" class="border" id="oTablecampus1">
		    	<tr>
		    		<th width="5%">No.</th>
		    		<th>Pregunta</th>
		    	</tr>
		    	<tr>
		    		<td>1.</td>
		    		<td><input type="text" id="pregunta1" name="pregunta1" class="width-90 TextBox"></td>
		    	</tr>
		    </table>
		    <table width="100%" >
		    	<tr>
					<td colspan="3" align="right"><button id="add2" type="button" class="btn btn-success">+ Add</button></td>
		    	</tr>
		    </table>

		    <br>
		    <br>
		    <span>2.	Realice una síntesis de los aspectos desarrollados en el trabajo en grupo por cada sesión, destacando aquellos aspectos que el grupo decidió son más relevantes y los aportes recibidos durante la plenaria.
			<br>Ubique aquí los productos solicitados en la sesión de formación: relato, diagrama, cuadro u otros
				</span><br><br>
                <cc1:Editor ID="aspectosdesarrollados" runat="server" Width="100%" Height="250" />
			<br><br>
		    <br>

		    <span>3. Relacione las conclusiones a las que se llegó en la sesión de formación</span><br><br>
                <cc1:Editor ID="conclusiones" runat="server" Width="100%" Height="250" />
		    <br><br>
		    <br>
		    <span>4. Relacione la bibliografía utilizada</span><br><br>
                <cc1:Editor ID="bibliografia" runat="server" Width="100%" Height="250" />
		    <br><br>
		    <br>
		</fieldset>


		<br><br><br><br>
		<style>
			.button{
				background: rgb(255, 255, 255);
			    bottom: 0;
			    display: block;
			    left: 0;
			    padding: 15px;
			    position: fixed;
			    right: 0;
			    text-align: right;
			}
		</style>

		<div class="button">
			<input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviars006('insert')">
            <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
		</div>

</asp:Content>

