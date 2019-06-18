<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="bitacora4_1reporte.aspx.cs" Inherits="bitacora4_1reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

    <style>
        fieldset {
            padding: 10px;
            width: 100%;
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
        .width-100{
			width: 95%;
		}
		.width-50{
			width: 47%;
			float: left;
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
	        dateFormat: 'yy-mm-dd',
	        firstDay: 1,
	        isRTL: false,
	        showMonthAfterYear: false,
	        yearSuffix: ''
	    };
	    $.datepicker.setDefaults($.datepicker.regional['es']);
		
		
	    var total = 1;
	    var total2 = 1;
	    var total3 = 1;
	    var total4 = 1;
	    var total5 = 1;
	    var total6 = 1;
	    var codigoinstrumento;
	    $(document).ready(function () {
	        cargarasesores();

	        $("#listasesores").change(function () {
	            listarbitacora4_1reporte($("#listasesores").val());
	        });

	        //nuevaBitacora();

	        $("input[type='datetime']").datepicker({changeYear: true, changeMonth: true });
	       

	        $("#lineainvestigacion").change(function () {
	            $("#fechagasto1").val('');
	            $("#nombreproveedor1").val('');
	            $("#descripciongasto1").val('');
	            $("#valorunitario1").val('');
	            $("#valortotal1").val('');
	            $("#firmamaestro").val('');
	            $("#firmanino").val('');
	            $("#fechadiligenciamiento").val('');
	        });
	        
	        $("#calc").click(function () {
	            calculartotal();
	        });


	    });

	    function cargarasesores() {

	        $.ajax({
	            type: 'POST',
	            dataType: 'JSON',
	            url: 'bitacora4_1reporte.aspx/cargarlistasesores',
	            contentType: 'application/json; charset=utf-8',
	            success: function (response) {
	                if (response.d != null) {
	                    $("#listasesores").html(response.d);
	                }
	            }
	        });
	    }

	    function fRemove(num, data) {
	        // alert(data);
	        
	        var ant = data - 1;
	        
	        if (num == 1) {
	            total = total - 1;
	        } else if (num == 2) {
	            total2 = total2 - 1;
	        } else if (num == 3) {
	            total3 = total3 - 1;
	        } else if (num == 4) {
	            total4 = total4 - 1;
	        } else if (num == 5) {
	            total5 = total5 - 1;
	        } else if (num == 6) {
	            total6 = total6 - 1;
	        }
	        $("#campus" + num + "_" + data).remove();

	        if (ant != 1) {
	            $("#radiotr" + num + "_" + ant).append('<td><button id="remove' + num + '" onclick="fRemove(' + num + ',' + ant + ')" class="btn btn-danger">-</button></td>');
	        }


	        calculartotal();
	    }

	    function returnpuntitos(valor, caracter) {
	        pat = /[\*,\+,\(,\),\?,\,$,\[,\],\^]/;
	        // valor = donde.value;
	        valorfinal = 0;
	        largo = valor.length;
	        crtr = true;
	        if (isNaN(valor) || pat.test(valor) == true) {
	            if (pat.test(valor) == true) {
	                valor = "\"" + valor;
	            }
	            carcter = new RegExp(valor, "g");
	            valor = valor.replace(carcter, "");
	            valorfinal = valor;
	            crtr = false;
	        }
	        else {
	            var nums = new Array();
	            cont = 0;
	            for (m = 0; m < largo; m++) {
	                if (valor.charAt(m) == "." || valor.charAt(m) == " ")
	                { continue; }
	                else {
	                    nums[cont] = valor.charAt(m);
	                    cont++;
	                }
	            }
	        }
	        var cad1 = "", cad2 = "", tres = 0;
	        if (largo > 3 && crtr == true) {
	            for (k = nums.length - 1; k >= 0; k--) {
	                cad1 = nums[k];
	                cad2 = cad1 + cad2;
	                tres++;
	                if ((tres % 3) == 0) {
	                    if (k != 0) {
	                        cad2 = "." + cad2;
	                    }
	                }
	            }
	            valorfinal = cad2;
	        }
	        return valorfinal;
	    }

	    function calculartotal() {
	        var valortotal = 0;
	        for (var i = 1; i <= 6; i++) {
	            if (i == 1) {
	                for (var j = 1; j <= total; j++) {
	                    valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i + '_' + j).val());
	                }
	            } else if (i == 2) {
	                for (var j = 1; j <= total2; j++) {
	                    valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i + '_' + j).val());
	                }
	            } else if (i == 3) {
	                for (var j = 1; j <= total3; j++) {
	                    valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i + '_' + j).val());
	                }
	            } else if (i == 4) {
	                for (var j = 1; j <= total4; j++) {
	                    valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i + '_' + j).val());
	                }
	            } else if (i == 5) {
	                for (var j = 1; j <= total5; j++) {
	                    valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i + '_' + j).val());
	                }
	            } else if (i == 6) {
	                for (var j = 1; j <= total6; j++) {
	                    valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i + '_' + j).val());
	                }
	            }
	        }
	        

	        $('#total').val("$ " + returnpuntitos(valortotal.toString()) + ",00");
	    }

	    function reset() {
	        
	        $("#total").val('0');
	        total = 1;
	        total2 = 1;
	        total3 = 1;
	        total4 = 1;
	        total5 = 1;
	        total6 = 1;

	        $("#grupoinvestigacion").val('');

	        //--
	        $("#tablecampus1 tbody").html('<tr><td><input type="datetime" id="fechagasto1_1" name="fechagasto1_1" class="width-100 TextBox"/></td><td><input type="text" id="nombreproveedor1_1" name="nombreproveedor1_1" class="width-100 TextBox"/></td><td><input type="text" id="ccnit1_1" name="ccnit1_1" class="width-100 TextBox"/></td><td><input type="text" id="cantidad1_1" onblur="valortotal(1,1)" name="cantidad1_1" onkeypress="return valideKey(event);" class="width-100 TextBox"/></td><td><input type="text" id="descripciongasto1_1" name="descripciongasto1_1" class="width-100 TextBox"/></td><td><input type="text" id="valorunitario1_1" name="valorunitario1_1"  onkeypress="return valideKey(event);" onblur="valortotal(1,1)" class="width-100 TextBox"/></td><td><input type="text" id="valortotal1_1" name="valortotal1_1" class="width-100 TextBox" disabled /></td></tr>');

	        //------
	        $("#tablecampus2 tbody").html('<tr><td><input type="datetime" id="fechagasto2_1" name="fechagasto2_1" class="width-100 TextBox"/></td><td><input type="text" id="nombreproveedor2_1" name="nombreproveedor2_1" class="width-100 TextBox"/></td><td><input type="text" id="ccnit2_1" name="ccnit2_1" class="width-100 TextBox"/></td><td><input type="text" id="cantidad2_1" name="cantidad2_1" onkeypress="return valideKey(event);" onblur="valortotal(2,1)" class="width-100 TextBox"/></td><td><input type="text" id="descripciongasto2_1" name="descripciongasto2_1" class="width-100 TextBox"/></td><td><input type="text" id="valorunitario2_1" name="valorunitario2_1"  onkeypress="return valideKey(event);" onblur="valortotal(2,1)" class="width-100 TextBox"/></td><td><input type="text" id="valortotal2_1" name="valortotal2_1" class="width-100 TextBox" disabled/></td></tr>');

	        //------
	        $("#tablecampus3 tbody").html('<tr><td><input type="datetime" id="fechagasto3_1" name="fechagasto3_1" class="width-100 TextBox"/></td><td><input type="text" id="nombreproveedor3_1" name="nombreproveedor3_1" class="width-100 TextBox"/></td><td><input type="text" id="ccnit3_1" name="ccnit3_1" class="width-100 TextBox"/></td><td><input type="text" id="cantidad3_1" name="cantidad3_1" onkeypress="return valideKey(event);"  onblur="valortotal(3,1)" class="width-100 TextBox"/></td><td><input type="text" id="descripciongasto3_1" name="descripciongasto3_1" class="width-100 TextBox"/></td><td><input type="text" id="valorunitario3_1" name="valorunitario3_1"  onkeypress="return valideKey(event);" onblur="valortotal(3,1)" class="width-100 TextBox"/></td><td><input type="text" id="valortotal3_1" name="valortotal3_1" class="width-100 TextBox" disabled/></td></tr>');

	        //------
	        $("#tablecampus4 tbody").html('<tr><td><input type="datetime" id="fechagasto4_1" name="fechagasto4_1" class="width-100 TextBox"/></td><td><input type="text" id="nombreproveedor4_1" name="nombreproveedor4_1" class="width-100 TextBox"/></td><td><input type="text" id="ccnit4_1" name="ccnit4_1" class="width-100 TextBox"/></td><td><input type="text" id="cantidad4_1" name="cantidad4_1" onkeypress="return valideKey(event);" onblur="valortotal(4,1)" class="width-100 TextBox"/></td><td><input type="text" id="descripciongasto4_1" name="descripciongasto4_1" class="width-100 TextBox"/></td><td><input type="text" id="valorunitario4_1" name="valorunitario4_1"  onkeypress="return valideKey(event);" onblur="valortotal(4,1)" class="width-100 TextBox"/></td><td><input type="text" id="valortotal4_1" name="valortotal4_1" class="width-100 TextBox" disabled/></td></tr>');

	        //------
	        $("#tablecampus5 tbody").html('<tr><td><input type="datetime" id="fechagasto5_1" name="fechagasto5_1" class="width-100 TextBox"/></td><td><input type="text" id="nombreproveedor5_1" name="nombreproveedor5_1" class="width-100 TextBox"/></td><td><input type="text" id="ccnit5_1" name="ccnit5_1" class="width-100 TextBox"/></td><td><input type="text" id="cantidad5_1" name="cantidad5_1" onkeypress="return valideKey(event);" onblur="valortotal(5,1)" class="width-100 TextBox"/></td><td><input type="text" id="descripciongasto5_1" name="descripciongasto5_1" class="width-100 TextBox"/></td><td><input type="text" id="valorunitario5_1" name="valorunitario5_1"  onkeypress="return valideKey(event);" onblur="valortotal(5,1)" class="width-100 TextBox"/></td><td><input type="text" id="valortotal5_1" name="valortotal5_1" class="width-100 TextBox" disabled/></td></tr>');

	        //------
	        $("#tablecampus6 tbody").html('<tr><td><input type="datetime" id="fechagasto6_1" name="fechagasto6_1" class="width-100 TextBox"/></td><td><input type="text" id="nombreproveedor6_1" name="nombreproveedor6_1" class="width-100 TextBox"/></td><td><input type="text" id="ccnit6_1" name="ccnit6_1" class="width-100 TextBox"/></td><td><input type="text" id="cantidad6_1" name="cantidad6_1" onkeypress="return valideKey(event);" onblur="valortotal(6,1)" class="width-100 TextBox"/></td><td><input type="text" id="descripciongasto6_1" name="descripciongasto6_1" class="width-100 TextBox"/></td><td><input type="text" id="valorunitario6_1" name="valorunitario6_1"  onkeypress="return valideKey(event);" onblur="valortotal(6,1)" class="width-100 TextBox"/></td><td><input type="text" id="valortotal6_1" name="valortotal6_1" class="width-100 TextBox" disabled/></td></tr>');

	        //--------
	        $("#firmamaestro").val('');
	        $("#firmanino").val('');
	        $("#firmaasesor").val('');
	        $("#fechadiligenciamiento").val('');

	        $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	    }

	    function enviarbitacora4_1reporte(event) {
	        if ($.trim($("#municipio").val()) == '') {
	            alert("Por favor, seleccione Municipio");
	            $("#municipio").focus();
	        }
	        else if ($.trim($("#institucion").val()) == '') {
	            alert("Por favor, seleccione Institución Educativa ");
	            $("#institucion").focus();
	        }
	        else if ($.trim($("#sede").val()) == '') {
	            alert("Por favor, seleccione Sede Educativa");
	            $("#sede").focus();
	        }
	        else if ($.trim($("#grupoinvestigacion").val()) == '') {
	            alert("Por favor, seleccione Grupo de Investigación");
	            $("#grupoinvestigacion").focus();
	        }
	        //else if ($.trim($("#lineainvestigacion").val()) == '') {
	        //    alert("Por favor, seleccione Línea de Investigación");
	        //    $("#lineainvestigacion").focus();
	        //}

	        else if ($.trim($("#fechagasto1_" + total).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto 1");
	            $("#fechagasto1_" + total).focus();
	        }
	        else if ($.trim($("#nombreproveedor1_" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor1_" + total).focus();
	        }
	        else if ($.trim($("#ccnit1_" + total).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit1_" + total).focus();
	        }
	        else if ($.trim($("#cantidad1_" + total).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad1_" + total).focus();
	        }
	        else if ($.trim($("#descripciongasto1_" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto1_" + total).focus();
	        }
	        else if ($.trim($("#valorunitario1_" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario1_" + total).focus();
	        }



	        else if ($.trim($("#fechagasto2_" + total2).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto 2" );
	            $("#fechagasto2_" + total2).focus();
	        }
	        else if ($.trim($("#nombreproveedor2_" + total2).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor2_" + total2).focus();
	        }
	        else if ($.trim($("#ccnit2_" + total2).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit2_" + total2).focus();
	        }
	        else if ($.trim($("#cantidad2_" + total2).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad2_" + total2).focus();
	        }
	        else if ($.trim($("#descripciongasto2_" + total2).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto2_" + total2).focus();
	        }
	        else if ($.trim($("#valorunitario2_" + total2).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario2_" + total2).focus();
	        }


            

	        else if ($.trim($("#fechagasto3_" + total3).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto 3");
	            $("#fechagasto3_" + total3).focus();
	        }
	        else if ($.trim($("#nombreproveedor3_" + total3).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor3_" + total3).focus();
	        }
	        else if ($.trim($("#ccnit3_" + total3).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit3_" + total3).focus();
	        }
	        else if ($.trim($("#cantidad3_" + total3).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad3_" + total3).focus();
	        }
	        else if ($.trim($("#descripciongasto3_" + total3).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto3_" + total3).focus();
	        }
	        else if ($.trim($("#valorunitario3_" + total3).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario3_" + total3).focus();
	        }



	        else if ($.trim($("#fechagasto4_" + total4).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto 4");
	            $("#fechagasto4_" + total4).focus();
	        }
	        else if ($.trim($("#nombreproveedor4_" + total4).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor4_" + total4).focus();
	        }
	        else if ($.trim($("#ccnit4_" + total4).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit4_" + total4).focus();
	        }
	        else if ($.trim($("#cantidad4_" + total4).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad4_" + total4).focus();
	        }
	        else if ($.trim($("#descripciongasto4_" + total4).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto4_" + total4).focus();
	        }
	        else if ($.trim($("#valorunitario4_" + total4).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario4_" + total4).focus();
	        }


	        else if ($.trim($("#fechagasto5_" + total5).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto 5");
	            $("#fechagasto5_" + total5).focus();
	        }
	        else if ($.trim($("#nombreproveedor5_" + total5).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor5_" + total5).focus();
	        }
	        else if ($.trim($("#ccnit5_" + total5).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit5_" + total5).focus();
	        }
	        else if ($.trim($("#cantidad5_" + total5).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad5_" + total5).focus();
	        }
	        else if ($.trim($("#descripciongasto5_" + total5).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto5_" + total5).focus();
	        }
	        else if ($.trim($("#valorunitario5_" + total5).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario5_" + total5).focus();
	        }


	        else if ($.trim($("#fechagasto6_" + total6).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto 6");
	            $("#fechagasto6_" + total6).focus();
	        }
	        else if ($.trim($("#nombreproveedor6_" + total6).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor6_" + total6).focus();
	        }
	        else if ($.trim($("#ccnit6_" + total6).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit6_" + total6).focus();
	        }
	        else if ($.trim($("#cantidad6_" + total6).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad6_" + total6).focus();
	        }
	        else if ($.trim($("#descripciongasto6_" + total6).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto6_" + total6).focus();
	        }
	        else if ($.trim($("#valorunitario6_" + total6).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario6_" + total6).focus();
	        }


	        else if ($.trim($('#firmamaestro').val()) == '') {
	            alert("Por favor, ingrese Firma de Maestro (a) Acompañante");
	            $('#firmamaestro').focus();
	            calculartotal();
	        }
	        else if ($.trim($('#firmanino').val()) == '') {
	            alert("Por favor, Firma del niño (a) Tesorero");
	            $('#firmanino').focus();
	            calculartotal();
	        }
	        else if ($.trim($('#firmaasesor').val()) == '') {
	            alert("Por favor, ingrese Firma del Asesor");
	            $('#firmaasesor').focus();
	            calculartotal();
	        }
	        else if ($.trim($('#fechadiligenciamiento').val()) == '') {
	            alert("Por favor, ingrese Fecha de Diligenciamiento");
	            $('#fechadiligenciamiento').focus();
	            calculartotal();
	        }
	        else {
	            calculartotal();
	            $('body').append('<div class="desactivarC" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:60px 60px;position: fixed;height:100%"></div>');

	            if (event == 'insert' ) {
	                var jsonData = '{ "grupoinvestigacion":"' + $("#grupoinvestigacion").val() + '", "firmamaestro":"' + $("#firmamaestro").val() + '", "firmanino":"' + $("#firmanino").val() + '", "fechadiligenciamiento":"' + $("#fechadiligenciamiento").val() + '",  "firmaasesor":"' + $("#firmaasesor").val() + '"}';
	                //console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'bitacora4_1reporte.aspx/insertbitacora4_1reporte',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            //alert("bitacora insertada exitosamente");
	                            codigoinstrumento = resp[1];
	                            //console.log(codigoinstrumento);
	                            //$('#btn-guardar').attr('value', 'Actualizar');
	                            //$('#btn-guardar').attr('onclick', 'enviarbitacora4_1reporte(\'update\')');

	                           
	                            finsertrubros();
	                        } else {
	                            alert(json.d);
	                        }
	                    }, complete: function () {
	                        //finsertrubros();
	                    }
	                });
	            }
	            else if (event == 'update') {
	                var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "grupoinvestigacion":"' + $("#grupoinvestigacion").val() + '", "firmamaestro":"' + $("#firmamaestro").val() + '", "firmanino":"' + $("#firmanino").val() + '", "fechadiligenciamiento":"' + $("#fechadiligenciamiento").val() + '",  "firmaasesor":"' + $("#firmaasesor").val() + '"}';
	                //console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'bitacora4_1reporte.aspx/updatebitacora4_1reporte',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            //console.log("registro actualizado exitosamente");
	                            //$('#btn-guardar').attr('value', 'Actualizar');
	                            //$('#btn-guardar').attr('onclick', 'enviarbitacora4_1reporte(\'update\')');

	                            finsertrubros();
	                        } else {
	                            alert("error: intente de nuevo");
	                            $('.desactivarC').remove().fadeOut(500);
	                        }
	                    }, complete: function () {
	                        
	                    }
	                });
	            }
	            
	        }
	    }

	    //validar solo numeros
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

        //cargar datos si ya tiene para actualizarlos
	    function cargarbitacora4_1reporte(codigoinstrumento1) {
	        reset();
	        codigoinstrumento = codigoinstrumento1;
	        var jsonData = '{"codigoinstrumento":"' + codigoinstrumento1 + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'bitacora4_1reporte.aspx/loadInstrumento',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsonData,
	            success: function (json) {
	                var resp = json.d.split("@");
	                if (resp[0] === "true") {
	                    codigoinstrumento = resp[1];
	                    $("#fechadiligenciamiento").val(resp[2]);
	                    $("#firmamaestro").val(resp[3]);
	                    $("#firmanino").val(resp[4]);
	                    $("#firmaasesor").val(resp[5]);

	                    $("#municipio").html("<option value='" + resp[6] + "' selected>" + resp[7] + "</option></option>");
	                    $("#sede").html("<option value='" + resp[8] + "' selected>" + resp[9] + "</option></option>");
	                    $("#institucion").html("<option value='" + resp[10] + "' selected>" + resp[11] + "</option></option>");

	                    $("#grupoinvestigacion").html("<option value='" + resp[12] + "' selected>" + resp[13] + "</option></option>");
	                    $('#btn-guardar').attr('value', 'Actualizar');
	                    $('#btn-guardar').attr('onclick', 'enviarbitacora4_1reporte(\'update\')');
	                    floadRubrosbitacora4_1reporte(codigoinstrumento);
	                }
	                 else {
	                    console.error(json.d);
	                }
	            }, complete: function () {
	                $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	            }
	        });
	    }

        //insertanto el informe de ejecucion financiera
	    function finsertrubros() {

	        var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'bitacora4_1reporte.aspx/deleteRubrosbitacora4_1reporte',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                var resp = data.d.split("@");
	                if (resp[0] === "true") {
	                    var j = 0;
	                    for (var i = 1; i <= total; i++) {
	                        var jsonData = '{ "rubro": "insumos", "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto1_" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor1_" + i).val() + '", "ccnit":"' + $("#ccnit1_" + i).val() + '", "cantidad":"' + $("#cantidad1_" + i).val() + '", "descripciongasto":"' + $("#descripciongasto1_" + i).val() + '", "valorunitario":"' + $("#valorunitario1_" + i).val() + '", "valortotal":"' + $("#valortotal1_" + i).val() + '"}';
	                        $.ajax({
	                            type: 'POST',
	                            url: 'bitacora4_1reporte.aspx/insertRubrobitacora4_1reporte',
	                            data: jsonData,
	                            contentType: "application/json; charset=utf-8",
	                            dataType: "json",
	                            success: function (data) {
	                                var resp = data.d.split("@");
	                                if (resp[0] === "true") {
	                                    console.log("instrumento rubro exitosamente 1_" + i);
	                                } else {
	                                    console.error(data.d + " 1_" + i);
	                                    //console.error(data.d);
	                                }
	                            }, complete: function () {
	                                j++;
	                                if (j == total) {
	                                    j = 0;
	                                    for (var i = 1; i <= total2; i++) {
	                                        var jsonData = '{ "rubro": "papeleria", "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto2_" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor2_" + i).val() + '", "ccnit":"' + $("#ccnit2_" + i).val() + '", "cantidad":"' + $("#cantidad2_" + i).val() + '", "descripciongasto":"' + $("#descripciongasto2_" + i).val() + '", "valorunitario":"' + $("#valorunitario2_" + i).val() + '", "valortotal":"' + $("#valortotal2_" + i).val() + '"}';
	                                        $.ajax({
	                                            type: 'POST',
	                                            url: 'bitacora4_1reporte.aspx/insertRubrobitacora4_1reporte',
	                                            data: jsonData,
	                                            contentType: "application/json; charset=utf-8",
	                                            dataType: "json",
	                                            success: function (data) {
	                                                var resp = data.d.split("@");
	                                                if (resp[0] === "true") {
	                                                    console.log("instrumento rubro exitosamente 2_" + i);
	                                                } else {
	                                                    console.error(data.d + " 2_" + i);
	                                                    //console.error(data.d);
	                                                }
	                                            }, complete: function () {
	                                                j++;
	                                                if (j == total2) {
	                                                    j = 0;
	                                                    for (var i = 1; i <= total3; i++) {
	                                                        var jsonData = '{ "rubro": "transporte", "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto3_" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor3_" + i).val() + '", "ccnit":"' + $("#ccnit3_" + i).val() + '", "cantidad":"' + $("#cantidad3_" + i).val() + '", "descripciongasto":"' + $("#descripciongasto3_" + i).val() + '", "valorunitario":"' + $("#valorunitario3_" + i).val() + '", "valortotal":"' + $("#valortotal3_" + i).val() + '"}';
	                                                        $.ajax({
	                                                            type: 'POST',
	                                                            url: 'bitacora4_1reporte.aspx/insertRubrobitacora4_1reporte',
	                                                            data: jsonData,
	                                                            contentType: "application/json; charset=utf-8",
	                                                            dataType: "json",
	                                                            success: function (data) {
	                                                                var resp = data.d.split("@");
	                                                                if (resp[0] === "true") {
	                                                                    console.log("instrumento rubro exitosamente 3_" + i);
	                                                                } else {
	                                                                    console.error(data.d + " 3_" + i);
	                                                                    //console.error(data.d);
	                                                                }
	                                                            }, complete: function () {
	                                                                j++;
	                                                                if (j == total3) {
	                                                                    j = 0;
	                                                                    for (var i = 1; i <= total4; i++) {
	                                                                        var jsonData = '{ "rubro": "correo", "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto4_" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor4_" + i).val() + '", "ccnit":"' + $("#ccnit4_" + i).val() + '", "cantidad":"' + $("#cantidad4_" + i).val() + '", "descripciongasto":"' + $("#descripciongasto4_" + i).val() + '", "valorunitario":"' + $("#valorunitario4_" + i).val() + '", "valortotal":"' + $("#valortotal4_" + i).val() + '"}';
	                                                                        $.ajax({
	                                                                            type: 'POST',
	                                                                            url: 'bitacora4_1reporte.aspx/insertRubrobitacora4_1reporte',
	                                                                            data: jsonData,
	                                                                            contentType: "application/json; charset=utf-8",
	                                                                            dataType: "json",
	                                                                            success: function (data) {
	                                                                                var resp = data.d.split("@");
	                                                                                if (resp[0] === "true") {
	                                                                                    console.log("instrumento rubro exitosamente 4_" + i);
	                                                                                } else {
	                                                                                    console.error(data.d + " 4_" + i);
	                                                                                    //console.error(data.d);
	                                                                                }
	                                                                            }, complete: function () {
	                                                                                j++;
	                                                                                if (j == total4) {
	                                                                                    j = 0;
	                                                                                    for (var i = 1; i <= total5; i++) {
	                                                                                        var jsonData = '{ "rubro": "materialdivulgacion", "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto5_" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor5_" + i).val() + '", "ccnit":"' + $("#ccnit5_" + i).val() + '", "cantidad":"' + $("#cantidad5_" + i).val() + '", "descripciongasto":"' + $("#descripciongasto5_" + i).val() + '", "valorunitario":"' + $("#valorunitario5_" + i).val() + '", "valortotal":"' + $("#valortotal5_" + i).val() + '"}';
	                                                                                        $.ajax({
	                                                                                            type: 'POST',
	                                                                                            url: 'bitacora4_1reporte.aspx/insertRubrobitacora4_1reporte',
	                                                                                            data: jsonData,
	                                                                                            contentType: "application/json; charset=utf-8",
	                                                                                            dataType: "json",
	                                                                                            success: function (data) {
	                                                                                                var resp = data.d.split("@");
	                                                                                                if (resp[0] === "true") {
	                                                                                                    console.log("instrumento rubro exitosamente 5_" + i);
	                                                                                                } else {
	                                                                                                    console.error(data.d + " 5_" + i);
	                                                                                                    //console.error(data.d);
	                                                                                                }
	                                                                                            }, complete: function () {
	                                                                                                j++;
	                                                                                                if (j == total5) {
	                                                                                                    j = 0;
	                                                                                                    for (var i = 1; i <= total6; i++) {
	                                                                                                        var jsonData = '{ "rubro": "refrigerios", "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto6_" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor6_" + i).val() + '", "ccnit":"' + $("#ccnit6_" + i).val() + '", "cantidad":"' + $("#cantidad6_" + i).val() + '", "descripciongasto":"' + $("#descripciongasto6_" + i).val() + '", "valorunitario":"' + $("#valorunitario6_" + i).val() + '", "valortotal":"' + $("#valortotal6_" + i).val() + '"}';
	                                                                                                        $.ajax({
	                                                                                                            type: 'POST',
	                                                                                                            url: 'bitacora4_1reporte.aspx/insertRubrobitacora4_1reporte',
	                                                                                                            data: jsonData,
	                                                                                                            contentType: "application/json; charset=utf-8",
	                                                                                                            dataType: "json",
	                                                                                                            success: function (data) {
	                                                                                                                var resp = data.d.split("@");
	                                                                                                                if (resp[0] === "true") {
	                                                                                                                    console.log("instrumento rubro exitosamente 6_" + i);
	                                                                                                                } else {
	                                                                                                                    console.error(data.d + " 6_" + i);
	                                                                                                                    //console.error(data.d);
	                                                                                                                }
	                                                                                                            }, complete: function () {
	                                                                                                                j++;
	                                                                                                                if (j == total6) {
	                                                                                                                    $('.desactivarC').remove().fadeOut(500);
	                                                                                                                    alert("Bitacora guardada exitosamente");
	                                                                                                                    listarbitacora4_1reporte();

	                                                                                                                    //$('#btn-guardar').attr('value', 'Actualizar');
	                                                                                                                    //$('#btn-guardar').attr('onclick', 'enviarbitacora4_1reporte(\'update\')');
	                                                                                                                }
	                                                                                                            }
	                                                                                                        });
	                                                                                                    }
	                                                                                                }
	                                                                                            }
	                                                                                        });
	                                                                                    }
	                                                                                }
	                                                                            }
	                                                                        });
	                                                                    }
	                                                                }
	                                                            }
	                                                        });
	                                                    }
	                                                }
	                                            }
	                                        });
	                                    }
	                                }
	                            }
	                        });
	                    }

	                } else {
	                    alert(data.d);
	                }
	            },
	            complete: function () {
	                
	            }
	        });
	    }

        //cargar material si ya tiene
	    function floadRubrosbitacora4_1reporte(codigoinstrumento) {
	        total = 1;
	        var jsonData = '{"rubro": "insumos", "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total + '}';
	        $.ajax({
	            type: 'POST',
	            url: 'bitacora4_1reporte.aspx/loadRubrosbitacora4_1reporte',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                console.log(data);
	                var resp = data.d.split("@");
	                
	                $("#tablecampus1 tbody").html(resp[0]);
	                total = resp[1];
	                console.log("new total " + total);

	                //papeleria
	                total2 = 1;
	                jsonData = '{"rubro": "papeleria", "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total2 + '}';
	                $.ajax({
	                    type: 'POST',
	                    url: 'bitacora4_1reporte.aspx/loadRubrosbitacora4_1reporte',
	                    data: jsonData,
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    success: function (data) {
	                        console.log(data);
	                        var resp = data.d.split("@");

	                        $("#tablecampus2 tbody").html(resp[0]);
	                        total2 = resp[1];
	                        console.log("new total2 " + total2);

	                        //transporte
	                        total3 = 1;
	                        jsonData = '{"rubro": "transporte", "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total3 + '}';
	                        $.ajax({
	                            type: 'POST',
	                            url: 'bitacora4_1reporte.aspx/loadRubrosbitacora4_1reporte',
	                            data: jsonData,
	                            contentType: "application/json; charset=utf-8",
	                            dataType: "json",
	                            success: function (data) {
	                                console.log(data);
	                                var resp = data.d.split("@");

	                                $("#tablecampus3 tbody").html(resp[0]);
	                                total3 = resp[1];
	                                console.log("new total3 " + total3);

	                                //correo
	                                total4 = 1;
	                                jsonData = '{"rubro": "correo", "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total4 + '}';
	                                $.ajax({
	                                    type: 'POST',
	                                    url: 'bitacora4_1reporte.aspx/loadRubrosbitacora4_1reporte',
	                                    data: jsonData,
	                                    contentType: "application/json; charset=utf-8",
	                                    dataType: "json",
	                                    success: function (data) {
	                                        console.log(data);
	                                        var resp = data.d.split("@");

	                                        $("#tablecampus4 tbody").html(resp[0]);
	                                        total4 = resp[1];
	                                        console.log("new total4 " + total4);

	                                        //materialdivulgacion
	                                        total5 = 1;
	                                        jsonData = '{"rubro": "materialdivulgacion", "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total5 + '}';
	                                        $.ajax({
	                                            type: 'POST',
	                                            url: 'bitacora4_1reporte.aspx/loadRubrosbitacora4_1reporte',
	                                            data: jsonData,
	                                            contentType: "application/json; charset=utf-8",
	                                            dataType: "json",
	                                            success: function (data) {
	                                                console.log(data);
	                                                var resp = data.d.split("@");

	                                                $("#tablecampus5 tbody").html(resp[0]);
	                                                total5 = resp[1];
	                                                console.log("new total5 " + total5);

	                                                //refrigerios
	                                                total6 = 1;
	                                                jsonData = '{"rubro": "refrigerios", "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total6 + '}';
	                                                $.ajax({
	                                                    type: 'POST',
	                                                    url: 'bitacora4_1reporte.aspx/loadRubrosbitacora4_1reporte',
	                                                    data: jsonData,
	                                                    contentType: "application/json; charset=utf-8",
	                                                    dataType: "json",
	                                                    success: function (data) {
	                                                        console.log(data);
	                                                        var resp = data.d.split("@");

	                                                        $("#tablecampus6 tbody").html(resp[0]);
	                                                        total6 = resp[1];
	                                                        console.log("new total6 " + total6);

	                                                        calculartotal();
	                                                    }, complete: function () {
	                                                        $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	                                                    }
	                                                });
	                                            }
	                                        });
	                                    }
	                                });
	                            }
	                        });
	                    }
	                });
	            }
	        });
	    }

	    function addclick(data) {
	        if(data==1){
	            var totalop = total;
	        } else if (data == 2) {
	            var totalop = total2;
	        } else if (data == 3) {
	            var totalop = total3;
	        } else if (data == 4) {
	            var totalop = total4;
	        } else if (data == 5) {
	            var totalop = total5;
	        } else if (data == 6) {
	            var totalop = total6;
	        }
	        
	        if ($.trim($("#fechagasto" + data + "_" + totalop).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto");
	            $("#fechagasto" + data + "_" + totalop).focus();
	        }
	        else if ($.trim($("#nombreproveedor" + data + "_" + totalop).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor" + data + "_" + totalop).focus();
	        }
	        else if ($.trim($("#ccnit" + data + "_" + totalop).val()) == '') {
	            alert("Por favor, Ingrese CC/NIT");
	            $("#ccnit" + data + "_" + totalop).focus();
	        }
	        else if ($.trim($("#cantidad" + data + "_" + totalop).val()) == '') {
	            alert("Por favor, Ingrese Cantidad");
	            $("#cantidad" + data + "_" + totalop).focus();
	        }
	        else if ($.trim($("#descripciongasto" + data + "_" + totalop).val()) == '') {
	            alert("Por favor, Ingrese descripción de gasto");
	            $("#descripciongasto" + data + "_" + totalop).focus();
	        }
	        else if ($.trim($("#valorunitario" + data + "_" + totalop).val()) == '') {
	            alert("Por favor, Ingrese valor unitario");
	            $("#valorunitario" + data + "_" + totalop).focus();
	        }
	        else {
	            totalop = parseInt(totalop) + 1;
	            if (data == 1) {
	                total = parseInt(total) + 1;
	            } else if (data == 2) {
	                total2 = parseInt(total2) + 1;
	            } else if (data == 3) {
	                total3 = parseInt(total3) + 1;
	            } else if (data == 4) {
	                total4 = parseInt(total4) + 1;
	            } else if (data == 5) {
	                total5 = parseInt(total5) + 1;
	            } else if (data == 6) {
	                total6 = parseInt(total6) + 1;
	            }
	            // alert(total);
	            calculartotal();
	            if ($("#remove" + data)) {
	                $("#remove" + data).remove();
	            }
	            console.log(totalop);
	            html = '<tr id="campus' + data + '_' + totalop + '">';
	            //html += '<td><input type="text" id="fechagasto1_' + total + '" class="TextBox" name="fechagasto' + total + '" class="width-100" onclick="calendario($(this).get(0).id);"/></td>';
	            html += '<td><input type="datetime" id="fechagasto' + data + '_' + totalop + '" name="fechagasto' + data + '_' + totalop + '" class="width-100 TextBox"/></td>';
	            html += '<td><input type="text" id="nombreproveedor' + data + '_' + totalop + '" name="nombreproveedor' + data + '_' + totalop + '" class="width-100 TextBox"/></td>';
	            html += '<td><input type="text" id="ccnit' + data + '_' + totalop + '" name="ccnit' + data + '_' + totalop + '" class="width-100 TextBox"/></td>';
	            html += '<td><input type="text" id="cantidad' + data + '_' + totalop + '" name="cantidad' + data + '_' + totalop + '" onkeypress="return valideKey(event);" onblur="valortotal(' + data + ',' + totalop + ')" class="width-100 TextBox"/></td>';
	            html += '<td><input type="text" id="descripciongasto' + data + '_' + totalop + '" name="descripciongasto' + data + '_' + totalop + '" class="width-100 TextBox"/></td>';
	            html += '<td><input type="text" id="valorunitario' + data + '_' + totalop + '" name="valorunitario' + data + '_' + totalop + '"  onkeypress="return valideKey(event);" onblur="valortotal(' + data + ',' + totalop + ')" class="width-100 TextBox"/></td>';
	            html += '<td><table width="100%"><tr id="radiotr' + data + '_' + totalop + '"><td><input type="text" class="TextBox" id="valortotal' + data + '_' + totalop + '" name="valortotal' + data + '_' + totalop + '"  disabled  /></td><td><button id="remove' + data + '" onclick="fRemove(' + data + ',' + totalop + ')" class="btn btn-danger">-</button></td></tr></table></td>';
	            $("#tablecampus" + data).append(html);

	            $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	        }
	    }


	    function valortotal(data1,data2) {
	        var cantidad = $("#cantidad" + data1 + "_" + data2).val();
	        var valorunitario = $("#valorunitario" + data1 + "_" + data2).val();
	        var valorfinal = valorunitario * cantidad;
	        $("#valortotal" + data1 + "_" + data2).val(valorfinal);
	    }

	    //nuevo codigo
	    function nuevaBitacora() {
	        $("#table").hide();
	        $("#form").fadeIn(500);
	        $("#institucion").html("");
	        $("#sede").html("");
	        $("#grupoinvestigacion").html("");
	        $("#lineainvestigacion").html("");
	        var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
	        $.ajax({
	            type: 'POST',
	            url: 'bitacora4_1reporte.aspx/cargarMunicipios',
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
	        reset();
	    }

	    function regresar() {
	        $("#form").hide();
	        $("#table").fadeIn(500);
	        $("#institucion").html("");
	        $("#sede").html("");
	        $("#grupoinvestigacion").html("");
	        $("#lineainvestigacion").html("");
	      
	        reset();
	    }

	    function listarbitacora4_1reporte(codasesorcoordinador) {
	        $("#form").hide();
	        $("#table").fadeIn(500);

	        $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
	        var jsondata = "{'codasesorcoordinador':'" + codasesorcoordinador + "'}";

	        $.ajax({
	            type: 'POST',
	            url: 'bitacora4_1reporte.aspx/listarbitacora4_1reporte',
	            contentType: 'application/json; charset=utf-8',
	            dataType: 'JSON',
	            data: jsondata,
	            success: function (response) {
	                $(".mGridTesoreria tbody").html(response.d);
	            }
	        });
	    }

	    function eliminar(codigo) {
	        if (confirm('¿Estás seguro de eliminar este registro?')) {
	            var jsonData = "{ 'codigo':'" + codigo + "'}";
	            $.ajax({
	                type: 'POST',
	                url: 'bitacora4_1reporte.aspx/deletebitacora4_1reporte',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    var resp = json.d.split("@");
	                    if (resp[0] === "delete") {
	                        alert('Registro eliminado correctamente.');
	                        listarbitacora4_1reporte();
	                    }
	                }
	            });
	        }

	    }

	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2>Bitacora Nº 4.1 informe financiero de ejecución de recursos del <asp:Label ID="lblDesembolso" runat="server"></asp:Label> desembolso</h2>

<div id="table">
     <%--<a class="btn btn-primary" style="float:right;" onclick="nuevaBitacora()">Nueva bitácora 4.1</a>--%>
       <table>
            <tr>
                <td>Asesor:</td>
                <td><select id="listasesores" class="TextBox"><option>Seleccione asesor...</option></select></td>
            </tr>
          </table>
     <fieldset >
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede Educativa</th>
                    <th>Grupo<br/>investigación</th>
                    <th>Desembolso</th>
                    <th>Fecha<br/>Creación</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
</div>

     <asp:Label runat="server" ID="lblCodMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodActividad" Visible="false"></asp:Label>

    
        <!-- DATOS DE LA INSTITUCIÓN -->
    <div id="form" style="display:none;">
        <%--<input type="button" value="Regresar" class="btn btn-primary" id="btn-regresar1" onclick="listarbitacora4_1reporte();" style="float:right">--%>
		<fieldset>
		    <legend>DATOS DE LA INSTITUCIÓN</legend>
		    <table>
                <tr>
                   <td>Departamento: </td>
                    <td>
                        <select class="TextBox width-100" name="departamento" id="departamento" style="width: 250px" disabled="true">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Municipio: </td>
                    <td>
                        <select class="TextBox width-100" name="municipio" id="municipio" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                      <td>Institución Educativa: </td>
                    <td>
                        <select class="TextBox width-100" name="institucion" id="institucion" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Sede Educativa: </td>
                    <%--<td>Línea de Investigación</td>--%>
                     <td>
                        <select class="TextBox width-100" name="sede" id="sede" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                     <td>Grupo de Investigación: </td>
                    <td>
                        <select class="TextBox width-100" name="grupoinvestigacion" id="grupoinvestigacion" style="width: 250px">
                        </select>
                    </td>
                    <%--<td>
                        <select class="TextBox width-100" name="lineainvestigacion" id="lineainvestigacion" style="width: 250px">
                        </select>
                    </td>--%>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td><b>Desembolso Primer Segmento</b></td>
                    <td>
                        <input type="text" name="name" value="700.000,00" class="TextBox" disabled style="width: 250px"/>
                    </td>
                </tr>
            </table>	    
		</fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
		<br>
		<fieldset>
		    <legend>INFORME DE EJECUCIÓN FINANCIERA</legend>
            <b style="font-size:15px;">Rubro: </b><span class="rubro" style="font-size:15px;">Insumos para la investigación (Pruebas de laboratorio)</span><br /><br />
		    <table width="100%" class="border" id="tablecampus1">
                <thead>
		    	    <tr>
		    		    <th>Fecha del gasto</th>
		    		    <th>Nombre del proveedor</th>
		    		    <th>CC/NIT</th>
		    		    <th>Cantidad</th>
		    		    <th>Descripción</th>
                        <th>Valor unitario</th>
                        <th>Valor total</th>
		    	    </tr>
                </thead>
                <tbody>
                    <tr>
					    <td><input type="datetime" id="fechagasto1_1" name="fechagasto1_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="nombreproveedor1_1" name="nombreproveedor1_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="ccnit1_1" name="ccnit1_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="cantidad1_1" onblur="valortotal(1,1)" name="cantidad1_1" onkeypress="return valideKey(event);" class="width-100 TextBox"/></td>
					    <td><input type="text" id="descripciongasto1_1" name="descripciongasto1_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valorunitario1_1" name="valorunitario1_1"  onkeypress="return valideKey(event);" onblur="valortotal(1,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valortotal1_1" name="valortotal1_1" class="width-100 TextBox" disabled /></td>
		    	    </tr>
                </tbody>
            </table>
            <table width="100%" >
                <tr>
                    <td colspan="2" align="right">
                        <button id="add1" type="button" class="btn btn-primary" onclick="addclick(1)">+ Add</button>
                        <br />
                    </td>
                </tr>
		        <tr>
                    <td colspan="2" style="font-size:15px;"><b>Rubro: </b><span class="rubro">Papelería (Fotocopias, Impresiones, Lápices, Lapiceros, Libretas de apuntes)</span><br /></td>
		        </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" class="border" id="tablecampus2">
                <thead>
                    <tr>
		    		    <th>Fecha del gasto</th>
		    		    <th>Nombre del proveedor</th>
		    		    <th>CC/NIT</th>
		    		    <th>Cantidad</th>
		    		    <th>Descripción</th>
                        <th>Valor unitario</th>
                        <th>Valor total</th>
		    	    </tr>
                </thead>
                <tbody>
                    <tr>
					    <td><input type="datetime" id="fechagasto2_1" name="fechagasto2_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="nombreproveedor2_1" name="nombreproveedor2_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="ccnit2_1" name="ccnit2_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="cantidad2_1" name="cantidad2_1" onkeypress="return valideKey(event);" onblur="valortotal(2,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="descripciongasto2_1" name="descripciongasto2_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valorunitario2_1" name="valorunitario2_1"  onkeypress="return valideKey(event);" onblur="valortotal(2,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valortotal2_1" name="valortotal2_1" class="width-100 TextBox" disabled/></td>
		    	    </tr>
                </tbody>
		    	
            </table>
            <table  width="100%">
                <tr>
                    <td colspan="2" align="right">
                        <button id="add2" type="button" class="btn btn-primary" onclick="addclick(2)">+ Add</button>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><b>Rubro: </b><span class="rubro">Transporte Municipal e Intermunicipal</span><br /></td>
		        </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" class="border" id="tablecampus3">
                <thead>
                    <tr>
		    		    <th>Fecha del gasto</th>
		    		    <th>Nombre del proveedor</th>
		    		    <th>CC/NIT</th>
		    		    <th>Cantidad</th>
		    		    <th>Descripción</th>
                        <th>Valor unitario</th>
                        <th>Valor total</th>
		    	    </tr>
                </thead>
                <tbody>
                    <tr>
					    <td><input type="datetime" id="fechagasto3_1" name="fechagasto3_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="nombreproveedor3_1" name="nombreproveedor3_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="ccnit3_1" name="ccnit3_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="cantidad3_1" name="cantidad3_1" onkeypress="return valideKey(event);"  onblur="valortotal(3,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="descripciongasto3_1" name="descripciongasto3_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valorunitario3_1" name="valorunitario3_1"  onkeypress="return valideKey(event);" onblur="valortotal(3,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valortotal3_1" name="valortotal3_1" class="width-100 TextBox" disabled/></td>
		    	    </tr>
                </tbody>
		    	
            </table>
            <table  width="100%">
                <tr>
                    <td colspan="2" align="right">
                        <button id="add3" type="button" class="btn btn-primary" onclick="addclick(3)">+ Add</button>
                        <br />
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="font-size:15px;"><b>Rubro: </b><span class="rubro">Correo Aéreo e Internet</span><br /></td>
		        </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" class="border" id="tablecampus4">
                <thead>
                    <tr>
		    		    <th>Fecha del gasto</th>
		    		    <th>Nombre del proveedor</th>
		    		    <th>CC/NIT</th>
		    		    <th>Cantidad</th>
		    		    <th>Descripción</th>
                        <th>Valor unitario</th>
                        <th>Valor total</th>
		    	    </tr>
                </thead>
                <tbody>
		    	    <tr>
					    <td><input type="datetime" id="fechagasto4_1" name="fechagasto4_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="nombreproveedor4_1" name="nombreproveedor4_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="ccnit4_1" name="ccnit4_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="cantidad4_1" name="cantidad4_1" onkeypress="return valideKey(event);" onblur="valortotal(4,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="descripciongasto4_1" name="descripciongasto4_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valorunitario4_1" name="valorunitario4_1"  onkeypress="return valideKey(event);" onblur="valortotal(4,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valortotal4_1" name="valortotal4_1" class="width-100 TextBox" disabled/></td>
		    	    </tr>
                </tbody>
            </table>
            <table  width="100%">
                <tr>
                    <td colspan="2" align="right">
                        <button id="add4" type="button" class="btn btn-primary" onclick="addclick(4)">+ Add</button>
                        <br />
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="font-size:15px;"><b>Rubro: </b><span class="rubro">Material de Divulgación (Plegables, Videos, Fotografías, Afiches)</span><br /></td>
		        </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" class="border" id="tablecampus5">
                <thead>
                    <tr>
		    		    <th>Fecha del gasto</th>
		    		    <th>Nombre del proveedor</th>
		    		    <th>CC/NIT</th>
		    		    <th>Cantidad</th>
		    		    <th>Descripción</th>
                        <th>Valor unitario</th>
                        <th>Valor total</th>
		    	    </tr>
                </thead>
                <tbody>
                    <tr>
					    <td><input type="datetime" id="fechagasto5_1" name="fechagasto5_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="nombreproveedor5_1" name="nombreproveedor5_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="ccnit5_1" name="ccnit5_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="cantidad5_1" name="cantidad5_1" onkeypress="return valideKey(event);" onblur="valortotal(5,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="descripciongasto5_1" name="descripciongasto5_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valorunitario5_1" name="valorunitario5_1"  onkeypress="return valideKey(event);" onblur="valortotal(5,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valortotal5_1" name="valortotal5_1" class="width-100 TextBox" disabled/></td>
		    	    </tr>
                </tbody>
		    	
            </table>
            <table  width="100%">
                <tr>
                    <td colspan="2" align="right">
                        <button id="add5" type="button" class="btn btn-primary" onclick="addclick(5)">+ Add</button>
                        <br />
                    </td>
                </tr>


                <tr>
                    <td colspan="2" style="font-size:15px;"><b>Rubro: </b><span class="rubro">Refrigerios</span><br /></td>
		        </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" class="border" id="tablecampus6">
                <thead>
                    <tr>
		    		    <th>Fecha del gasto</th>
		    		    <th>Nombre del proveedor</th>
		    		    <th>CC/NIT</th>
		    		    <th>Cantidad</th>
		    		    <th>Descripción</th>
                        <th>Valor unitario</th>
                        <th>Valor total</th>
		    	    </tr>
                </thead>
                <tbody>
                    <tr>
					    <td><input type="datetime" id="fechagasto6_1" name="fechagasto6_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="nombreproveedor6_1" name="nombreproveedor6_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="ccnit6_1" name="ccnit6_1" class="width-100 TextBox"/></td>
                        <td><input type="text" id="cantidad6_1" name="cantidad6_1" onkeypress="return valideKey(event);" onblur="valortotal(6,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="descripciongasto6_1" name="descripciongasto6_1" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valorunitario6_1" name="valorunitario6_1"  onkeypress="return valideKey(event);" onblur="valortotal(6,1)" class="width-100 TextBox"/></td>
					    <td><input type="text" id="valortotal6_1" name="valortotal6_1" class="width-100 TextBox" disabled/></td>
		    	    </tr>
                </tbody>
		    	
            </table>
            <table  width="100%">
                <tr>
                    <td colspan="2" align="right">
                        <button id="add6" type="button" class="btn btn-primary" onclick="addclick(6)">+ Add</button>
                        <br />
                    </td>
                </tr>
		    </table>
		    <table width="100%" >
		    	<tr>
					<td width="70%"></td>
					<td width="30%">
                        <br />
                        <b>Total ejecutado:  </b><input type="text" id="total" name="total" disabled style="width:200px;float:right" class="TextBox"/>
                        <br />
					</td>
		    	</tr>
		    	<tr>
					<td colspan="2" align="right">
                        <button id="calc" type="button" class="btn btn-success">Calcular total</button>
					</td>
		    	</tr>
		    </table>
		</fieldset>
		<br>
		<fieldset>
		    <!-- <legend>RELLENE LA INFORMACIÓN</legend> -->
		    <table width="100%" class="border">
                <tr>
                    <td colspan="2"><b>Nota: </b> El valor total no puede exceder el recurso asignado al grupo de investigación para el proyecto.</td>
                </tr>
		    	<tr>
		    		<td width="40%">
		    			Firma de Maestro (a) Acompañante
		    		</td>
		    		<td width="60%">
		    			<input type="text" class="width-100 TextBox" name="firmamaestro" id="firmamaestro">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Firma del niño (a) Tesorero </td>
		    		<td>
    					<input type="text" name="firmanino" id="firmanino" class="width-100 TextBox">
		    		</td>
		    	</tr>
                <tr>
		    		<td>Firma del Asesor de  línea de ciclón o el acompañante de la formación </td>
		    		<td>
    					<input type="text" name="firmaasesor" id="firmaasesor" class="width-100 TextBox">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Fecha de diligenciamiento</td>
		    		<td>
    					<input type="datetime" name="fechadiligenciamiento" id="fechadiligenciamiento" class="width-100 TextBox">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td colspan="2" align="right">
		    			<%--<input type="button" value="Guardar" class="btn btn-success" id="btn-guardar" onclick="enviarbitacora4_1reporte('insert');">--%>
                        <input type="button" value="Regresar" class="btn btn-primary" id="btn-regresar" onclick="regresar();">
                        <%--<asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />--%>
		    		</td>
		    	</tr>
		    </table>
		</fieldset>

    </div>
</asp:Content>

