<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras001.aspx.cs" Inherits="estras001" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
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
	        dateFormat: 'dd/mm/yy',
	        firstDay: 1,
	        isRTL: false,
	        showMonthAfterYear: false,
	        yearSuffix: ''
	    };
	    $.datepicker.setDefaults($.datepicker.regional['es']);
	    
	    var total = 1;
	    var codigoestrategia;
	    $(document).ready(function () {

	        reset();       

	        $("#fechanacimiento").datepicker({ maxDate: '0', changeYear: true, changeMonth: true });
	        cargarinstituciones();
	        cargardepartamentos();
	        
	        $("#institucion").change(function () {
	            reset();
	            $("#emailentidad").val('');
	            $("#telefonoentidad").val('');
	            //tinymce.get('introduccion').setContent('');
	            document.getElementById('MainContent_propositos_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
	            document.getElementById('MainContent_numeroperfilparticipantes_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
	            document.getElementById('MainContent_metodologia_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
	            document.getElementById('MainContent_criterioevaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';

	            var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estras001.aspx/cargarsedes',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    var resp = json.d.split("&");
	                    if (resp[0] === "sedes") {
	                        $("#sede").html(resp[1]);
	                        $("#emailentidad").val(resp[2]);
	                        $("#telefonoentidad").val(resp[3]);

	                    }
	                }
	            });
	        });

	        $("#sede").change(function () {
	            reset();
	            var jsonData = '{ "codigosede":"' + $("#sede").val() + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estras001.aspx/loadDocentes',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    var resp = json.d.split("@");
	                    if (resp[0] === "docentes") {
	                        $("#docente").html(resp[1]);
	                    }
	                    else if (resp[0] === "vacio") {
	                        $("#docente").html("<option value='' disabled selected>Sin Docentes</option>");
	                    }else{
	                        alert(json.d);
	                    }
	                }
	            });
	        });

	        $("#departamento").change(function () {
	            selectmunicipio($("#departamento").val());
	        });

	        function selectmunicipio(coddepartamento,val) {
	            var jsonData = '{ "coddepartamento":"' + coddepartamento  + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estras001.aspx/cargarMunicipios',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    var resp = json.d.split("@");
	                    if (resp[0] === "muni") {
	                        $("#municipio").html(resp[1]);
	                    }
	                    else if (resp[0] === "vacio") {
	                        $("#municipio").html("<option value='' disabled selected>Seleccione municipio...</option>");
	                    } else {
	                        alert(json.d);
	                    }
	                }, complete: function () {
	                    if (val) {
	                        $("#municipio").val(val);
	                    }
	                }
	            });
	        }
	        

	        $("#docente").change(function () {
	            reset();
	            floadestras001();
	            var jsonData = '{ "identificaciondocente":"' + $("#docente").val() + '"}';
	            $.ajax({
	                type: 'POST',
	                url: 'estras001.aspx/loadDatosDocente',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    var resp = json.d.split("&");
	                    if (resp[0] === "datosdocente") {
	                        selectmunicipio(resp[14], resp[9]);
	                        var apellidos = resp[1].split(" ");
	                        $("#departamento").val(resp[14]);
	                        $("#primerapellido").val(apellidos[0]);
	                        $("#segundoapellido").val(apellidos[1]);
	                        $("#nombres").val(resp[2]);
	                        $("#documentoidentidad").val(resp[3]);
	                        $("#expedidaen").val(resp[4]);
	                        $("#lugarnacimiento").val(resp[5]);
	                        $("#fechanacimiento").val(resp[6]);
	                        $("#edad").val(resp[7]);
	                        $("#direccion").val(resp[8]);
	                        
	                        //$("#departamento").val(resp[8]);
	                        $("#telefono").val(resp[10]);
	                        $("#celular").val(resp[11]);
	                        $("#email").val(resp[12]);
	                        $("#profesion").val(resp[13]);                      
	                    
	                    }
	                    else {
	                        alert(json.d);
	                    }
	                }
	            });
	        });


	    });

	    function cargarinstituciones() {
	        $.ajax({
	            type: 'POST',
	            url: 'estras001.aspx/cargarInstituciones',
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
	        //$("#sede").html("<option value='' disabled selected>Seleccione sede...</option>");
	        //$("#docente").html("<option value='' selected>Seleccione docente...</option>");
	        $("#primerapellido").val('');
	        $("#segundoapellido").val('');
	        $("#nombres").val('');
	        $("#documentoidentidad").val('');
	        $("#expedidaen").val('');
	        $("#lugarnacimiento").val('');
	        $("#fechanacimiento").val('');
	        $("#edad").val('');
	        $("#direccion").val('');
	        $("#municipio").val('');
	        //$("#departamento").val(resp[8]);
	        $("#telefono").val('');
	        $("#celular").val('');
	        $("#email").val('');
	        $("#profesion").val('');

	        document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';
	        document.getElementById('MainContent_propositos_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';
	        document.getElementById('MainContent_numeroperfilparticipantes_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';
	        document.getElementById('MainContent_metodologia_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';
	        document.getElementById('MainContent_criterioevaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML = '<br>';

	        $("#cargo").val('');
	        
	        $("#informacionadicional").val('');

	    }
	    function cargardepartamentos() {
	        $.ajax({
	            type: 'POST',
	            url: 'estras001.aspx/cargarDepartamentos',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            //data:frmserialize,
	            success: function (json) {
	                var resp = json.d.split("@");
	                if (resp[0] === "muni") {
	                    $("#departamento").html(resp[1]);
	                    //alert(resp[0]);
	                }
	            }
	        });
	    }

	    function enviars001(event) {
	        var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
	        if ($.trim($("#institucion").val()) == '') {
	            alert("Por favor, seleccione institución");
	            $("#institucion").focus();
	        } else if ($.trim($("#sede").val()) == '') {
	            alert("Por favor, seleccione Sede");
	            $("#sede").focus();
	        } else if ($.trim($("#docente").val()) == '') {
	            alert("Por favor, seleccione docente");
	            $("#docente").focus();
	        } else if ($.trim($("#primerapellido").val()) == '') {
	            alert("Por favor, ingrese primer apellido");
	            $("#primerapellido").focus();
	        } else if ($.trim($("#nombres").val()) == '') {
	            alert("Por favor, ingrese nombres");
	            $("#nombres").focus();
	        } else if ($.trim($("#expedidaen").val()) == '') {
	            alert("Por favor, ingrese lugar de expedicion");
	            $("#expedidaen").focus();
	        } else if ($.trim($("#lugarnacimiento").val()) == '') {
	            alert("Por favor, ingrese lugar de nacimiento");
	            $("#lugarnacimiento").focus();
	        } else if ($.trim($("#fechanacimiento").val()) == '') {
	            alert("Por favor, ingrese fecha de nacimiento");
	            $("#fechanacimiento").focus();
	        } else if ($.trim($("#edad").val()) == '') {
	            alert("Por favor, ingrese edad");
	            $("#edad").focus();
	        } else if ($.trim($("#direccion").val()) == '') {
	            alert("Por favor, ingrese dirección");
	            $("#direccion").focus();
	        } else if ($.trim($("#departamento").val()) == '') {
	            alert("Por favor, seleccione departamento");
	            $("#departamento").focus();
	        } else if ($.trim($("#municipio").val()) == '') {
	            alert("Por favor, seleccione municipio");
	            $("#municipio").focus();
	        } else if ($.trim($("#telefono").val()) == '') {
	            alert("Por favor, ingrese telefono");
	            $("#telefono").focus();
	        } else if ($.trim($("#celular").val()) == '') {
	            alert("Por favor, ingrese celular");
	            $("#celular").focus();
	        } else if ($.trim($("#email").val()) == '') {
	            alert("Por favor, ingrese email");
	            $("#email").focus();
	        } else if (!regex.test($('#email').val().trim())) {
	            alert("Por favor, ingrese un E-Mail valido");
	            $("#email").focus();
	        } else if ($.trim($("#profesion").val()) == '') {
	            alert("Por favor, ingrese profesión");
	            $("#profesion").focus();
	        }
	        else if ($.trim(document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

	            alert("por favor ingrese Introducción");
	        }
	        else if ($.trim(document.getElementById('MainContent_propositos_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

	            alert("por favor ingrese Propositos");

	        }
	        
            else if ($.trim(document.getElementById('MainContent_numeroperfilparticipantes_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

	            alert("por favor ingrese numero y perfil de participantes");

            }
            else if ($.trim(document.getElementById('MainContent_metodologia_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

                alert("por favor ingrese metodologia");

            } 
            else if ($.trim(document.getElementById('MainContent_criterioevaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {

                alert("por favor ingrese criterio de evaluación");

	        } else if ($.trim($("#cargo").val()) == '') {
	            alert("Por favor, ingrese Cargo que desempeña en la entidad");
	            $("#cargo").focus();
	        } else {
	            actualizardatos();
	            
	            var introduccion = document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML;
	            var propositos = document.getElementById('MainContent_propositos_ctl02_ctl00').contentWindow.document.body.innerHTML;
	            var numeroperfilparticipantes = document.getElementById('MainContent_numeroperfilparticipantes_ctl02_ctl00').contentWindow.document.body.innerHTML;
	            var metodologia = document.getElementById('MainContent_metodologia_ctl02_ctl00').contentWindow.document.body.innerHTML;
	            var criterioevaluacion = document.getElementById('MainContent_criterioevaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML;

	            if (event == 'insert') {
	                var jsonData = "{'introduccion': '" + introduccion + "', 'propositos': '" + propositos + "', 'numeroperfilparticipantes':'" + numeroperfilparticipantes + "', 'metodologia': '" + metodologia + "', 'criterioevaluacion' : '" + criterioevaluacion + "', 'cargo': '" + $("#cargo").val() + "', 'informacionadicional' : '" + $("#informacionadicional").val() + "', 'coddocente' : '" + $("#docente").val() + "'}";
	                //console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'estras001.aspx/insertests001',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            codigoestrategia = resp[1];
	                            alert("registro insertado exitosamente");
	                            $('#btn-guardar').attr('value', 'Actualizar');
	                            $('#btn-guardar').attr('onclick', 'enviars001(\'update\')');
	                        } else {
	                            alert(json.d);
	                        }
	                    }
	                });
	            } else if (event == 'update') {

	                var jsonData = "{'codigoestrategia':'" + codigoestrategia + "', 'introduccion': '" + introduccion + "', 'propositos': '" + propositos + "', 'numeroperfilparticipantes':'" + numeroperfilparticipantes + "', 'metodologia': '" + metodologia + "', 'criterioevaluacion' : '" + criterioevaluacion + "', 'cargo': '" + $("#cargo").val() + "', 'informacionadicional' : '" + $("#informacionadicional").val() + "'}";
	                //console.log(jsonData);
	                $.ajax({
	                    type: 'POST',
	                    url: 'estras001.aspx/updateests001',
	                    contentType: "application/json; charset=utf-8",
	                    dataType: "json",
	                    data: jsonData,
	                    success: function (json) {
	                        var resp = json.d.split("@");
	                        if (resp[0] === "true") {
	                            alert("registro guardado exitosamente");
	                            $('#btn-guardar').attr('value', 'Actualizar');
	                            $('#btn-guardar').attr('onclick', 'enviars001(\'update\')');
	                        } else {
	                            alert(resp[1]);
	                        }
	                    }
	                });
	            } else {
	                alert("error no hay event");
	            }
	        }
	        

	    }

	    function actualizardatos() {
	        var jsonData = '{ "codigodocente":"' + $("#docente").val() + '", "apellidos":"' + $("#primerapellido").val() + " " + $("#segundoapellido").val() + '", "nombres":"' + $("#nombres").val() + '", "expedidaen":"' + $("#expedidaen").val() + '", "lugarnacimiento":"' + $("#lugarnacimiento").val() + '", "fechanacimiento":"' + $("#fechanacimiento").val() + '", "edad":"' + $("#edad").val() + '", "direccion":"' + $("#direccion").val() + '", "departamento":"' + $("#departamento").val() + '", "municipio":"' + $("#municipio").val() + '", "telefono":"' + $("#telefono").val() + '", "celular":"' + $("#celular").val() + '", "email":"' + $("#email").val() + '", "profesion":"' + $("#profesion").val() + '"}';
	        //console.log(jsonData);
	        $.ajax({
	            type: 'POST',
	            url: 'estras001.aspx/updateDocente',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsonData,
	            success: function (json) {
	                var resp = json.d.split("@");
	                if (resp[0] === "true") {
	                    console.log("datos de docente actualizados exitosamente");
	                    //alert(resp[0]);
	                } else {
	                    alert(json.d);
	                }
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

	    function floadestras001() {
	        var jsonData = "{ 'coddocente':'" + $("#docente").val() + "'}";
	        $.ajax({
	            type: 'POST',
	            url: 'estras001.aspx/loadestras001',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsonData,
	            success: function (json) {
	                //console.log(json);
	                var resp = json.d.split("@");
	                if (resp[0] === "datosintrumento") {
	                    codigoestrategia = resp[1];
	                    document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[2];
	                    document.getElementById('MainContent_propositos_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[3];
	                    document.getElementById('MainContent_numeroperfilparticipantes_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[4];
	                    document.getElementById('MainContent_metodologia_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[5];
	                    document.getElementById('MainContent_criterioevaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[6];


	                    $("#cargo").val(resp[7]);
	                    $("#informacionadicional").val(resp[8]);

	                    $('#btn-guardar').attr('value', 'Actualizar');
	                    $('#btn-guardar').attr('onclick', 'enviars001(\'update\')');

	                } else if (resp[0] === "vacio") {
	                    $('#btn-guardar').attr('value', 'Guardar todo');
	                    $('#btn-guardar').attr('onclick', 'enviars001(\'insert\')');
	                } else {
	                    alert("Ocurrio un error");
	                }
	            }
	        });
	    }


	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Instrumento s001</h2>
        
        <table width="100%">
            <tr width="100%">
                <td style="display: block; width: 130px;">Institución Educativa:</td>
                <td width="30%">
                    <select class="TextBox" name="institucvion" id="institucion" style="width: 300px;">
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
                <td style="display: block; width: 40px;">Docente: </td>
                <td>
                    <select class="TextBox" name="docente" id="docente" style="width: 300px;">
                        <option value='' selected>Seleccione docente...</option>
                    </select></td>
                <td>
                    <%--<input type="submit" value="Buscar" class="btn btn-success">--%></td>
            </tr>
        </table>
		<fieldset>
		    <!-- <legend>NOMBRE DE LA ENTIDAD QUE ORGANIZA</legend> -->
		    <table width="100%">
		    	<tr>
		    		<td width="100%">
			    		<b>INTRODUCCIÓN</b> <br><br>
			    		<%--<textarea style="width: 100%" name="introduccion" id="introduccion"  runat="server" class="editor" cols="30" rows="10"></textarea>--%>
                        <cc1:Editor ID="introduccion" runat="server" Width="100%" Height="250" />
		    		</td>
		    	</tr>
		    </table>	    
		</fieldset>
<br>
		<fieldset>
		    <!-- <legend>NOMBRE DE LA ENTIDAD QUE ORGANIZA</legend> -->
		    <table width="100%">
		    	<tr>
		    		<td width="100%">
			    		<b>PROPÓSITOS</b> <br />
                        <%--<textarea style="width: 100%" name="propositos" id="propositos" class="editor" cols="30" rows="10"></textarea>--%>
                        <cc1:Editor ID="propositos" runat="server" Width="100%" Height="250" />
		    		</td>
		    	</tr>
		    </table>	    
		</fieldset>
<br>
		<!-- NÚMERO Y PERFIL DE LOS PARTICIPANTES -->
		<fieldset>
		    <table width="100%">
		    	<tr>
		    		<td width="100%">
		    			<b>NÚMERO Y PERFIL DE LOS PARTICIPANTES:</b> <br>
			    		<%--<textarea style="width: 100%" name="numeroperfilparticipantes" id="numeroperfilparticipantes" class="editor" cols="30" rows="10"></textarea>--%>
                        <cc1:Editor ID="numeroperfilparticipantes" runat="server" Width="100%" Height="250" />
		    		</td>
		    	</tr>
		    </table>	    
		</fieldset>
<br>
		<!-- METODOLOGÍA -->
		<fieldset>
		    <table width="100%">
		    	<tr>
		    		<td width="100%">
		    			<b>METODOLOGÍA</b>
			    		<%--<textarea style="width: 100%" name="metodologia" id="metodologia" class="editor" cols="30" rows="10"></textarea>--%>
                        <cc1:Editor ID="metodologia" runat="server" Width="100%" Height="250" />
		    		</td>
		    	</tr>
		    </table>	    
		</fieldset><br>
		
		<!-- CRITERIOS DE EVALUACIÓN -->
		<fieldset>
		    <table width="100%">
		    	<tr>
		    		<td width="100%">
		    			<b>CRITERIOS DE EVALUACIÓN </b> <br>
			    		<%--<textarea style="width: 100%" name="criterioevaluacion" id="criterioevaluacion" class="editor" cols="30" rows="10"></textarea>--%>
                        <cc1:Editor ID="criterioevaluacion" runat="server" Width="100%" Height="250" />
		    		</td>
		    	</tr>
		    </table>	    
		</fieldset><br>

		<br>
		<!-- DATOS PERSONALES -->
        
		<fieldset >
		    <legend>DATOS PERSONALES</legend>
            
		    <table width="100%" class="border" id="tablecampus">
		    	<tr>
		    		<td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Primer Apellido:</td>
			    				<td width="70%"><input type="text" name="primerapellido" id="primerapellido" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Segundo Apellido:</td>
			    				<td width="70%"><input type="text" name="segundoapellido" id="segundoapellido" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    	<tr>
	    			<td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Nombres:</td>
			    				<td width="70%"><input type="text" name="nombres" id="nombres" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Documento de Identidad:</td>
			    				<td width="70%"><input type="text" name="documentoidentidad" disabled id="documentoidentidad" maxlength="15" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Expedido en:</td>
			    				<td width="70%"><input type="text" name="expedidaen" id="expedidaen" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>

		    	<tr>
		    		<td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Lugar y Fecha de Nacimiento:</td>
			    				<td width="70%"><input type="text" name="lugarnacimiento" id="lugarnacimiento" class="width-50 TextBox"><input type="date" name="fechanacimiento" id="fechanacimiento" class="width-50 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Edad:</td>
			    				<td width="70%"><input type="text" name="edad" id="edad" onkeypress="return valideKey(event);" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>

		    	<tr>
	    			<td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Dirección Actual:</td>
			    				<td width="70%"><input type="text" name="direccion" id="direccion" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="50%">
		    		</td>
		    	</tr>

		    	<tr>
                    <td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Departamento: </td>
			    				<td width="70%">
                                    <select class="TextBox" name="departamento" id="departamento" style="width: 300px;">
                                        <option value="">Seleccione departamento...</option>
                                    </select>

			    				</td>
			    			</tr>
		    			</table>
		    		</td>

		    		<td width="50%" >
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Municipio: </td>
			    				<td width="70%">
                                    <select class="TextBox" name="municipio" id="municipio" style="width: 300px;">
                                        <option value="">Seleccione municipio...</option>
                                    </select>
			    				</td>
			    			</tr>
		    			</table>
		    		</td>
		    		
		    	</tr>

		    	<tr>
		    		<td width="33%">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Teléfono Fijo: </td>
			    				<td width="70%"><input type="text" name="telefono" id="telefono" onkeypress="return valideKey(event);" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="32%">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Teléfono Celular: </td>
			    				<td width="70%"><input type="text" name="celular" id="celular" onkeypress="return valideKey(event);" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    		<td width="33%">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">E-mail: </td>
			    				<td width="70%"><input type="text" name="email" id="email" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>

		    	<tr>
		    		<td width="50%" colspan="2">
		    			<table width="100%">
			    			<tr>
			    				<td width="30%">Profesión u Oficio:  </td>
			    				<td width="70%"><input type="text" name="profesion" id="profesion" class="width-100 TextBox"></td>
			    			</tr>
		    			</table>
		    		</td>
		    	</tr>
		    </table>
		</fieldset>
		<br>

		<!-- DATOS INSTITUCIONALES -->
		<fieldset>
		    <legend>DATOS INSTITUCIONALES</legend>
		    <table width="100%" class="border">
		    	<%--<tr>
		    		<td width="40%">
		    			Nombre de la entidad a la cual está vinculado
		    		</td>
		    		<td width="60%">
		    			<input type="text" class="width-100" name="nombreentidad" id="nombreentidad">
		    		</td>
		    	</tr>--%>
		    	<tr>
		    		<td width="40%">Cargo que desempeña en la entidad:</td>
		    		<td width="60%"a>
    					<input type="text" name="cargo" id="cargo" class="width-100 TextBox">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Correo electrónico de la entidad:</td>
		    		<td>
    					<input type="date" name="emailentidad" id="emailentidad" class="width-100 TextBox">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Teléfono de contacto de la entidad:</td>
		    		<td>
    					<input type="date" name="telefonoentidad" id="telefonoentidad" class="width-100 TextBox">
		    		</td>
		    	</tr>
		    	<tr>
		    		<td>Información adicional requerida por la entidad que organiza la formación:</td>
		    		<td>
    					<input type="date" name="informacionadicional" id="informacionadicional" class="width-100 TextBox">
		    		</td>
		    	</tr>
		    </table>
		</fieldset>
		<br>

		<fieldset>
		    <!-- <legend>DATOS INSTITUCIONALES</legend> -->
		    <p>Yo <input type="text" name="nombreapellido" id="nombreapellido" >, identificado(a) con <select name="tipodocumento" id="tipodocumento"><option value="">Seleccione...</option><option value="C.C">C.C</option><option value="TI">TI</option><option value="TE">TE</option></select>  No.<input type="text" name="documentoindentidad" id="documentoindentidad" > expedida en <input type="text" name="expedidaen1" id="expedidaen1" >, asumo los compromisos individuales y grupales de autoformación, formación colaborativa, producción y apropiación social de conocimiento en el desarrollo de la formación. Adicionalmente, acepto el horario y fechas establecidas para el desarrollo de los encuentros presenciales. </p>
		    <!-- <br> -->
		    <p>Esta formación es un componente del proyecto FORTALECIMIENTO DE LA CULTURA CIUDADANA Y DEMOCRÁTICA EN CT+I A TRAVÉS DE LA IEP APOYADA EN TIC EN EL DPTO DEL MAGDALENA, tiene una intensidad horaria de <input type="text" name="totaldehorasdesarrollada" id="totaldehorasdesarrollada"> desarrollada en <input type="text" name="numerodesesiones" id="numerodesesiones"> que corresponden a <input type="text" name="numerodias" id="numerodias"> días de trabajo presencial. </p>
		    <!-- <br> -->
		    <p>Conozco que la formación plantea como criterios para la certificación <input type="text" name="criterioscertificacion" id="criterioscertificacion">. <br>
		    	En caso de incumplimiento la entidad puede <input type="text" name="multassanciones" id="multassanciones">
			</p>
			<!-- <br> -->
			<p>
			Firma del participante ________________________ <br>

			Vo.Bo. Coordinador del proyecto en la entidad operadora: ______________________________ 
			</p>

			<!-- <tr> -->
	    		<!-- <td colspan="2" align="right"> -->
	    		<!-- </td> -->
	    	<!-- </tr> -->
		</fieldset><br>

    <br>
    <br>
    <br>
    <br>
    <style>
        .button {
            background: rgba(255,255,255,.7);
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
        <input type="button" value="Guardar todo" onclick="enviars001('insert')" id="btn-guardar" class="btn btn-success">
        <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
    </div>
		

</asp:Content>

