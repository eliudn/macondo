<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estrag008.aspx.cs" Inherits="estrag008" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

   <style> 
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
			width: 95%;
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
	    var codigoinstrumento;
	    $(document).ready(function () {
	        $("input[type='datetime']").datepicker({changeYear: true, changeMonth: true });
	        //llamando funcion para cargar instituciones 
	        cargarinstituciones();
	        reset();
	        $("#add").click(function () {

	            if ($.trim($("#fechagasto" + total).val()) == '') {
	                alert("Por favor, Ingrese fecha de gasto");
	                $("#fechagasto" + total).focus();
	            } else if ($.trim($("#nombreproveedor" + total).val()) == '') {
	                alert("Por favor, Ingrese nombre de proveedor");
	                $("#nombreproveedor" + total).focus();
	            } else if ($.trim($("#descripciongasto" + total).val()) == '') {
	                alert("Por favor, Ingrese nombre de descripción de gasto");
	                $("#descripciongasto" + total).focus();
	            } else if ($.trim($("#valorunitario" + total).val()) == '') {
	                alert("Por favor, Ingrese nombre de valor unitario");
	                $("#valorunitario" + total).focus();
	            } else if ($.trim($("#valortotal" + total).val()) == '') {
	                alert("Por favor, Ingrese nombre de valor valor total");
	                $("#valortotal" + total).focus();
	            } else {
	                total = parseInt(total) + 1;
	                // alert(total);
	                calculartotal();
	                if ($("#remove")) {
	                    $("#remove").remove();
	                }
	                console.log(total);
	                html = '<tr id="campus' + total + '">';
	                html += '<td><input type="text" id="fechagasto' + total + '" class="TextBox" name="fechagasto' + total + '" class="width-100" onclick="calendario($(this).get(0).id);"/></td>';
	                html += '<td><input type="text" id="nombreproveedor' + total + '" class="TextBox" name="nombreproveedor' + total + '"  class="width-100"/></td>';
	                html += '<td><input type="text" id="descripciongasto' + total + '" class="TextBox" name="descripciongasto' + total + '"  class="width-100"/></td>';
	                html += '<td><input type="text" id="valorunitario' + total + '"  class="TextBox" name="valorunitario' + total + '"  onkeypress="return valideKey(event);" class="width-100" /></td>';
	                html += '<td><table width="100%"><tr id="radiotr' + total + '"><td><input type="text" class="TextBox" id="valortotal' + total + '" name="valortotal' + total + '"  onkeypress="return valideKey(event);"  /></td><td><button id="remove" onclick="fRemove(' + total + ')" class="btn btn-danger">-</button></td></tr></table></td>';
	                $("#tablecampus").append(html);

	                $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	            }
	        });

            //cargando sedes segun institucion seleccioanda
	        $("#institucion").change(function () {
	            reset();
	            var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estrag008.aspx/cargarsedes',
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

	        //funcion cargar grupo de investigacion segun sede
	        $("#sede").change(function () {
	            reset();
	            var jsonData = '{"codigosede":"' + $("#sede").val() + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estrag008.aspx/grupoInvestigacion',
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
	            $("#fechagasto1").val('');
	            $("#nombreproveedor1").val('');
	            $("#descripciongasto1").val('');
	            $("#valorunitario1").val('');
	            $("#valortotal1").val('');
	            $("#firmatesorero").val('');
	            $("#voboasesor").val('');
	            $("#fechadiligenciamiento").val('');
	            cargarInstrumentog008();
	        });
	        
	        $("#calc").click(function () {
	            calculartotal();
	        });


	    });
	    function fRemove(data) {
	        // alert(data);
	        
	        var ant = data - 1;
	        total = total - 1;
	        $("#campus" + data).remove();
	        $("#radiotr" + ant).append('<td><button id="remove" onclick="fRemove(' + ant + ')" class="btn btn-danger">-</button></td>');

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
	        for (var i = 1; i <= total; i++) {
	            valortotal = parseInt(valortotal) + parseInt($('#valortotal' + i).val());
	        }

	        $('#total').val("$ " + returnpuntitos(valortotal.toString()) + ",00");
	    }

	    //cargar instituciones de la base de datos
	    function cargarinstituciones() {
	        $.ajax({
	            type: 'POST',
	            url: 'estrag008.aspx/cargarInstituciones',
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
	        $("#grupoinvestigacion").val('');
	        $("#fechagasto1").val('');
	        $("#nombreproveedor1").val('');
	        $("#descripciongasto1").val('');
	        $("#valorunitario1").val('');
	        $("#valortotal1").val('');
	        $("#firmatesorero").val('');
	        $("#voboasesor").val('');
	        $("#fechadiligenciamiento").val('');
	    }

	    function enviarestrag008(event) {
	        if ($.trim($("#institucion").val()) == '') {
	            alert("Por favor, seleccione institución");
	            $("#institucion").focus();
	        } else if ($.trim($("#sede").val()) == '') {
	            alert("Por favor, seleccione Sede");
	            $("#sede").focus();
	        } else if ($.trim($("#grupoinvestigacion").val()) == '') {
	            alert("Por favor, seleccione grupo investigacion");
	            $("#grupoinvestigacion").focus();
	        } else if ($.trim($("#fechagasto" + total).val()) == '') {
	            alert("Por favor, Ingrese fecha de gasto");
	            $("#fechagasto" + total).focus();
	        } else if ($.trim($("#nombreproveedor" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de proveedor");
	            $("#nombreproveedor" + total).focus();
	        } else if ($.trim($("#descripciongasto" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de descripción de gasto");
	            $("#descripciongasto" + total).focus();
	        } else if ($.trim($("#valorunitario" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor unitario");
	            $("#valorunitario" + total).focus();
	        } else if ($.trim($("#valortotal" + total).val()) == '') {
	            alert("Por favor, Ingrese nombre de valor valor total");
	            $("#valortotal" + total).focus();
	        } else if ($.trim($('#firmatesorero').val()) == '') {
	            alert("Por favor, ingrese firma de tesorero(a)");
	            $('#firmatesorero').focus();
	            calculartotal();
	        } else if ($.trim($('#voboasesor').val()) == '') {
	            alert("Por favor, ingrese Vo.Bo. Del asesor");
	            $('#voboasesor').focus();
	            calculartotal();
	        } else if ($.trim($('#fechadiligenciamiento').val()) == '') {
	            alert("Por favor, ingrese fecha de diligenciamiento");
	            $('#fechadiligenciamiento').focus();
	            calculartotal();
	        } else {
	            calculartotal();
	           
	            if (event == 'insert' ) {
	                var jsonData = '{ "grupoinvestigacion":"' + $("#grupoinvestigacion").val() + '", "firmatesorero":"' + $("#firmatesorero").val() + '", "voboasesor":"' + $("#voboasesor").val() + '", "fechadiligenciamiento":"' + $("#fechadiligenciamiento").val() + '"}';
	                console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'estrag008.aspx/insertestrag008',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            alert("registro insertado exitosamente");
	                            codigoinstrumento = resp[1];
	                            console.log(codigoinstrumento);
	                            $('#btn-guardar').attr('value', 'Actualizar');
	                            $('#btn-guardar').attr('onclick', 'enviarestrag008(\'update\')');
	                        } else {
	                            alert(json.d);
	                        }
	                    }, complete: function () {
	                        finsertmaterial();
	                    }
	                });
	            }
	            else if (event == 'update') {
	                var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "grupoinvestigacion":"' + $("#grupoinvestigacion").val() + '", "firmatesorero":"' + $("#firmatesorero").val() + '", "voboasesor":"' + $("#voboasesor").val() + '", "fechadiligenciamiento":"' + $("#fechadiligenciamiento").val() + '"}';
	                console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'estrag008.aspx/updateestrag008',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            console.log("registro actualizado exitosamente");
	                            $('#btn-guardar').attr('value', 'Actualizar');
	                            $('#btn-guardar').attr('onclick', 'enviarestrag008(\'update\')');
	                        } else {
	                            alert(json.d);
	                        }
	                    }, complete: function () {
	                        finsertmaterial();
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
	    function cargarInstrumentog008() {
	        var jsonData = '{"codproyecto":"' + $("#grupoinvestigacion").val() + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'estrag008.aspx/loadInstrumento',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsonData,
	            success: function (json) {
	                var resp = json.d.split("@");
	                if (resp[0] === "true") {
	                    codigoinstrumento = resp[1];
	                    $("#firmatesorero").val(resp[2]);
	                    $("#voboasesor").val(resp[3]);
	                    $("#fechadiligenciamiento").val(resp[4]);
	                    $('#btn-guardar').attr('value', 'Actualizar');
	                    $('#btn-guardar').attr('onclick', 'enviarestrag008(\'update\')');
	                    floadMaterialestrag008(codigoinstrumento);
	                }
	                else if (resp[0] === "vacio") {
	                    total = 1;
	                    $("#tablecampus").html(resp[1]);
	                    $('#btn-guardar').attr('value', 'Guardar');
	                    $('#btn-guardar').attr('onclick', 'enviarestrag008(\'insert\')');
	                    calculartotal();
	                } else {
	                    console.error(json.d);
	                }
	            }, complete: function () {
	                $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	            }
	        });
	    }

        //insertanto el informe de ejecucion financiera
	    function finsertmaterial() {
	        var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'estrag008.aspx/deleteMaterialestrag008',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                var resp = data.d.split("@");
	                if (resp[0] === "true") {

	                    for (var i = 1; i <= total; i++) {
	                        var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "fechagasto":"' + $("#fechagasto" + i).val() + '", "nombreproveedor":"' + $("#nombreproveedor" + i).val() + '", "descripciongasto":"' + $("#descripciongasto" + i).val() + '", "valorunitario":"' + $("#valorunitario" + i).val() + '", "valortotal":"' + $("#valortotal" + i).val() + '"}';
	                        $.ajax({
	                            type: 'POST',
	                            url: 'estrag008.aspx/insertMaterialestrag008',
	                            data: jsonData,
	                            contentType: "application/json; charset=utf-8",
	                            dataType: "json",
	                            success: function (data) {
	                                var resp = data.d.split("@");
	                                if (resp[0] === "true") {
	                                    console.log("instrumento insertado exitosamente " + i);
	                                } else {
	                                    console.error(data.d + " " + i);
	                                    //console.error(data.d);
	                                }
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
	                $('#btn-guardar').attr('onclick', 'enviarestrag008(\'update\')');
	            }
	        });
	    }

        //cargar material si ya tiene
	    function floadMaterialestrag008(codigoinstrumento) {
	        total = 1;
	        var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total + '}';
	        $.ajax({
	            type: 'POST',
	            url: 'estrag008.aspx/loadMaterialestrag008',
	            data: jsonData,
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                console.log(data);
	                var resp = data.d.split("@");
	                if (resp[0] === "mat") {
	                    $("#tablecampus").html(resp[1]);
	                    total = resp[2];
	                    console.log("new total " + total);
	                    
	                    calculartotal();
	                } else {
	                    $('#btn-guardar').val('Guardar');
	                    $("#tablecampus").html(resp[0]);
	                    total = 1;

	                    calculartotal();
	                    //alert(data.d);
	                    //console.error(data.d);
	                }
	            }, complete: function () {
	                $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });
	            }
	        });
	    }
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Estrategía Nro. <asp:Label runat="server" ID="lblCodEstrategia" Visible="true"></asp:Label> - G008: Ejecución financiera de recursos</h2>

     <asp:Label runat="server" ID="lblCodMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodActividad" Visible="false"></asp:Label>

  <!-- DATOS DE LA INSTITUCIÓN -->
		<fieldset>
		    <legend>DATOS DE LA INSTITUCIÓN</legend>
		    <table width="100%">
		    	<tr width="100%">
                <td style="display: block; width: 130px;">Institución Educativa:</td>
                <td width="30%">
                    <select class="TextBox" name="institucion" id="institucion" style="width: 300px;">
                        <option value="">Seleccione...</option>
                    </select></td>
                <td style="display: block; width: 40px;">Sede: </td>
                <td>
                    <select class="TextBox" name="sede" id="sede" style="width: 300px;">
                        <option value='' selected>Seleccione sede...</option>
                    </select></td>
                <td>
            </tr>
            <tr>
                <td style="display: block; width: 125px;">Nombre del grupo de investigación: </td>
                <td>
                    <select class="TextBox" name="grupoinvestigacion" id="grupoinvestigacion" style="width: 300px;">
                        <option value='' selected>Seleccione grupo investigación...</option>
                    </select></td>
                <td>
                    <%--<input type="submit" value="Buscar" class="btn btn-success">--%></td>
            </tr>
		    </table>	    
		</fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
		<br>
		<fieldset >
		    <legend>INFORME DE EJECUCIÓN FINANCIERA</legend>
            <b>Rubro: </b><span class="rubro"></span><br />
		    <table width="100%" class="border" id="tablecampus">
		    	<tr>
		    		<th>Fecha del gasto</th>
		    		<th>Nombre del proveedor</th>
		    		<th>Descripción del gasto</th>
		    		<th>Valor unitario</th>
		    		<th>Valor total</th>
		    	</tr>
		    	<tr>
					<td><input type="datetime" id="fechagasto1" name="fechagasto1" class="width-100 TextBox"/></td>
					<td><input type="text" id="nombreproveedor1" name="nombreproveedor1" class="width-100 TextBox"/></td>
					<td><input type="text" id="descripciongasto1" name="descripciongasto1" class="width-100 TextBox"/></td>
					<td><input type="text" id="valorunitario1" name="valorunitario1"  onkeypress="return valideKey(event);" class="width-100 TextBox"/></td>
					<td><input type="text" id="valortotal1" name="valortotal1"  onkeypress="return valideKey(event);" class="width-100 TextBox"/></td>
		    	</tr>
		    </table>
		    <table width="100%" >
		    	<tr>
					<td width="70%" ><b>Total: </b></td>
					<td width="30%"><input type="text" id="total" name="total" disabled class="width-100"/></td>
		    	</tr>
		    	<tr>
					<td colspan="2" align="right"><button id="calc" type="button" class="btn btn-success">Calcular total</button><button id="add" type="button" class="btn btn-primary">+ Add</button></td>
		    	</tr>
		    </table>
		</fieldset>
		<br>
		<br>
		<fieldset>
		    <!-- <legend>RELLENE LA INFORMACIÓN</legend> -->
		    <table width="100%" class="border">
		    	<tr>
		    		<td width="40%">
		    			Firma de Maestro (a) Tesorero
		    		</td>
		    		<td width="60%">
		    			<input type="text" class="width-100" name="firmatesorero" id="firmatesorero">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Vo.Bo. Del asesor de  línea de ciclón:</td>
		    		<td>
    					<input type="text" name="voboasesor" id="voboasesor" class="width-100">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Fecha de diligenciamiento</td>
		    		<td>
    					<input type="datetime" name="fechadiligenciamiento" id="fechadiligenciamiento" class="width-100">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td colspan="2" align="right">
		    			<input type="button" value="Guardar" class="btn btn-success" id="btn-guardar" onclick="enviarestrag008('insert');">
                        <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
		    		</td>
		    	</tr>
		    </table>
		</fieldset>

</asp:Content>

