<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras015.aspx.cs" Inherits="estras015" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

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
			padding: 5px;
		}
		table.border th{
			background: #004B96;
			color: #fff;
		}
		table.border tr,table.border{
			margin: 0;
			padding: 0;
		}
		.width-100{
			width: 98%;
		}
    </style>
    <script>
        var total = 1;
        var codigoinstrumento;

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
            sumaa();

            $("input[type='date']").datepicker();

            //cargando sede
            cargarinstituciones();

            //cargando sedes segun institucion seleccionada
            $("#institucion").change(function () {
                
                var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras015.aspx/cargarsedes',
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
                    url: 'estras015.aspx/datosSedes',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("&");
                        if (resp[0] === "datossede") {
                            $("#departamento").html(resp[1]);
                            $("#municipio").html(resp[2]);
                            $("#telefono").val(resp[3]);
                            $("#email").val(resp[4]);
                            $("#direccion").val(resp[5]);
                        }
                        else {
                            $("#modal1").openModal();
                            $("#mensaje2").html(json.d);
                        }
                    }
                });

                $.ajax({
                    type: 'POST',
                    url: 'estras015.aspx/loadDocentes',
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
                        } else {
                            alert(json.d);
                        }
                    }
                });

            });

            $("#docente").change(function () {
                reset();
                var jsonData = '{ "coddocente":"' + $("#docente").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras015.aspx/grupoInvestigacion',
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
                reset();
                var jsonData = '{ "codproyecto":"' + $("#grupoinvestigacion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras015.aspx/loadestras015',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "datosintrumento") {
                            codigoestrategia = resp[1];
                            $("#nombrevalorador").val(resp[2]);
                            $("#profesionvalorador").val(resp[3]);
                            $("#lineatematica").val(resp[4]);
                            $("#firmavalorador").val(resp[5]);
                            $("#observaciones").val(resp[6]);
                            
                            if (resp[7] != "vacio") {
                                j = 7;
                                for (var i = 1; i <= 6; i++) {
                                    $("#puntaje" + i).val(resp[j]);
                                    j++;
                                }
                            }

                            $('#btn-guardar').attr('value', 'Actualizar');
                            $('#btn-guardar').attr('onclick', 'enviarestras015(\'update\')');

                        }
                        else if (resp[0] === "vacio") {
                            $('#btn-guardar').attr('value', 'Guardar');
                            $('#btn-guardar').attr('onclick', 'enviarestras015(\'insert\')');
                        } else {
                            alert.error(json.d);
                        }
                    },
                    complete: function () {
                        sumaa();
                    }
                });
            });

        });
        

        function cargarinstituciones() {
            $.ajax({
                type: 'POST',
                url: 'estras015.aspx/cargarInstituciones',
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

            $("#nombrevalorador").val('');
            $("#profesionvalorador").val('');
            $("#lineatematica").val('');
            $("#observaciones").val('');
            $("#firmavalorador").val('');

            for (var i = 1; i <= 6; i++) {
                $("#puntaje" + i).val('');
            }
            $(".total").text('0');
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
        var sum = 0;

        function valmax(value, max, num) {
            if (value > max) {
                $(".error" + num).text("Error: Maximo " + max + " Puntos");
            } else {
                sum = 0;
                $(".error" + num).text("");
                sumaa();
            }
        }

        function sumaa() {
            sum = 0;
            for (var i = 1; i <= 6; i++) {
                sum = parseInt(sum) + parseInt(($("#puntaje" + i).val() == '' ? 0 : $("#puntaje" + i).val()));
            }
            $(".total").text(sum);
        }

       

        function enviarestras015(event) {

            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione Nombre de la entidad y / o Institución Educativa: ");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, Seleccione Sede");
                $("#sede").focus();
            }
            else if ($.trim($("#docente").val()) == '') {
                alert("Por favor, seleccione docente");
                $("#docente").focus();
            }
            else if ($.trim($("#grupoinvestigacion").val()) == '') {
                alert("Por favor, seleccione grupo de investigacion");
                $("#grupoinvestigacion").focus();
            }
            
            else if ($.trim($("#nombrevalorador").val()) == '') {
                alert("Por favor, ingrese nombre del valorador");
                $("#nombrevalorador").focus();
            }
            else if ($.trim($("#profesionvalorador").val()) == '') {
                alert("Por favor, ingrese profesión");
                $("#profesionvalorador").focus();
            }
            else if ($.trim($("#lineatematica").val()) == '') {
                alert("Por favor, ingrese línea temática");
                $("#lineatematica").focus();
            }
            
            else if ($.trim($("#puntaje1").val()) == '') {
                alert("Por favor ingrese puntaje 1");
                $("#puntaje1").focus();
            }
            else if ($.trim(parseInt($("#puntaje1").val())) > parseInt($("#puntaje1").attr('valmax'))) {
                alert("el puntaje 1 ingresado debe ser menos de " + $("#puntaje1").attr('valmax'));
                $("#puntaje1").focus();
            }
            else if ($.trim($("#puntaje2").val()) == '') {
                alert("Por favor ingrese puntaje 2");
                $("#puntaje2").focus();
            }
            else if ($.trim(parseInt($("#puntaje2").val())) > parseInt($("#puntaje2").attr('valmax'))) {
                alert("el puntaje 2 ingresado debe ser menor de " + $("#puntaje2").attr('valmax'));
                $("#puntaje2").focus();
            }
            else if ($.trim($("#puntaje3").val()) == '') {
                alert("Por favor ingrese puntaje 3");
                $("#puntaje3").focus();
            }
            else if ($.trim(parseInt($("#puntaje3").val())) > parseInt($("#puntaje3").attr('valmax'))) {
                alert("el puntaje 3 ingresado debe ser menor de " + $("#puntaje3").attr('valmax'));
                $("#puntaje3").focus();
            }
            else if ($.trim($("#puntaje4").val()) == '') {
                alert("Por favor ingrese puntaje 4");
                $("#puntaje4").focus();
            }
            else if ($.trim(parseInt($("#puntaje4").val())) > parseInt($("#puntaje4").attr('valmax'))) {
                alert("el puntaje 4 ingresado debe ser menor de " + $("#puntaje4").attr('valmax'));
                $("#puntaje4").focus();
            }
            else if ($.trim($("#puntaje5").val()) == '') {
                alert("Por favor ingrese puntaje 5");
                $("#puntaje5").focus();
            }
            else if ($.trim(parseInt($("#puntaje5").val())) > parseInt($("#puntaje5").attr('valmax'))) {
                alert("el puntaje 5 ingresado debe ser menor de " + $("#puntaje5").attr('valmax'));
                $("#puntaje5").focus();
            }

            else if ($.trim($("#puntaje6").val()) == '') {
                alert("Por favor ingrese puntaje 6");
                $("#puntaje6").focus();
            }
            else if ($.trim(parseInt($("#puntaje6").val())) > parseInt($("#puntaje6").attr('valmax'))) {
                alert("el puntaje 6 ingresado debe ser menor de " + $("#puntaje6").attr('valmax'));
                $("#puntaje6").focus();
            }
            else if ($.trim($("#firmavalorador").val()) == '') {
                alert("Por favor ingrese Firma del Valorador");
                $("#firmavalorador").focus();
            }

            else {
                if (event == 'insert') {
                    var jsonData = "{'grupoinvestigacion': '" + $("#grupoinvestigacion").val() + "', 'nombrevalorador' : '" + $("#nombrevalorador").val() + "', 'profesionvalorador' : '" + $("#profesionvalorador").val() + "', 'lineatematica' : '" + $("#lineatematica").val() + "', 'firmavalorador' : '" + $("#firmavalorador").val() + "',  'observaciones' : '" + $("#observaciones").val() + "'}";
                    //console.log(jsonDataa
                    $.ajax({
                        type: 'POST',
                        url: 'estras015.aspx/insertests015',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                codigoestrategia = resp[1];
                                //alert("registro guardado exitosamente");
                                $('#btn-guardar').attr('value', 'Actualizar');
                                $('#btn-guardar').attr('onclick', 'enviarestras015(\'update\')');

                                finsertPuntajes();
                            } else {
                                alert(json.d);
                            }
                        }
                    });
                }
                else if (event == 'update') {

                    var jsonData = "{'codigoestrategia':'" + codigoestrategia + "', 'grupoinvestigacion': '" + $("#grupoinvestigacion").val() + "', 'nombrevalorador' : '" + $("#nombrevalorador").val() + "', 'profesionvalorador' : '" + $("#profesionvalorador").val() + "', 'lineatematica' : '" + $("#lineatematica").val() + "', 'firmavalorador' : '" + $("#firmavalorador").val() + "', 'observaciones' : '" + $("#observaciones").val() + "'}";
                    //console.log(jsonData);
                    $.ajax({
                        type: 'POST',
                        url: 'estras015.aspx/updateests015',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                //alert("registro guardado exitosamente");
                                $('#btn-guardar').attr('value', 'Actualizar');
                                $('#btn-guardar').attr('onclick', 'enviarestras015(\'update\')');

                                finsertPuntajes();
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

        function finsertPuntajes() {
            $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:15%;position: fixed;height:100%"></div>');
            var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '"}';
            $.ajax({
                type: 'POST',
                url: 'estras015.aspx/deletePuntajess015',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        k2 = 1;
                        for (var i = 1; i <= 6; i++) {
                            var jsonData = '{ "codigoestrategia":"' + codigoestrategia + '", "numero":"' + i + '", "puntaje":"' + $("#puntaje" + i).val() + '"}';
                            $.ajax({
                                type: 'POST',
                                url: 'estras015.aspx/insertPuntajess015',
                                data: jsonData,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    var resp = data.d.split("@");
                                    if (resp[0] === "true") {
                                        console.log("puntaje " + i + "insertado exitosamente");
                                    } else {
                                        console.error(data.d + " " + i);
                                        //console.error(data.d);
                                    }
                                }, complete: function () {

                                    if (k2 == 6) {
                                        $('.desactivarC1').remove().fadeOut(500);
                                        alert("registro guardado exitosamente");
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
                    $('#btn-guardar').attr('onclick', 'enviarestras015(\'update\')');
                }
            });
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia Nro  <asp:Label runat="server" ID="lblEstrategia" Visible="true"></asp:Label> - S015: </h2>

    <fieldset>
	    <legend>DATOS DE LA INSTITUCIÓN</legend>
	    <table width="100%">
             <tr>
                <td width="100%" colspan="2">
                    <table width="100%">
                        <tr>
                            <td width="30%">Nombre de la entidad y / o Institución Educativa: </td>
                            <td width="70%">
                                <select class="TextBox width-100" name="institucion" id="institucion">
                                    <option value="">Seleccione institución</option>
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
                                    <option value="">Seleccione Sede</option>
                                </select></td>
                        </tr>
                    </table>
                </td>
            </tr>
		    <tr>
		        <td width="50%">
		    	    <table width="100%">
			    	    <tr>
			    		    <td width="40%">Departamento:</td>
			    		    <td width="60%"><select name="departamento" id="departamento" class="TextBox width-100"><option value="">Seleccione...</option></select></td>
			    	    </tr>
		    	    </table>
		        </td>
		        <td width="50%">
		    	    <table width="100%">
			    	    <tr>
			    		    <td width="40%">Municipio: </td>
			    		    <td width="60%"><select name="municipio" id="municipio" class="TextBox width-100"><option value="">Seleccione...</option></select></td>
			    	    </tr>
		    	    </table>
		        </td>
		    </tr>
		    <tr>
		        <td width="50%">
		    	    <table width="100%">
			    	    <tr>
			    		    <td width="40%">Nombre del Maestro:</td>
			    		    <td width="60%"><select name="docente" id="docente" class="TextBox width-100"><option value="">Seleccione...</option></select></td>
			    	    </tr>
		    	    </table>
		        </td>
		        <td width="50%">
		    	    <table width="100%">
			    	    <tr>
			    		    <td width="40%">Nombre del grupo de investigación que acompaña: </td>
			    		    <td width="60%"><select name="grupoinvestigacion" id="grupoinvestigacion" class="TextBox width-100"><option value="">Seleccione...</option></select></td>
			    	    </tr>
		    	    </table>
		        </td>
		    </tr>

		    <tr>
		        <td width="50%">
		    	    <table  width="100%">
			    	    <tr>
			    		    <td width="40%">Nombre del valorador:</td>
			    		    <td width="60%"><input name="nombrevalorador" id="nombrevalorador" class="TextBox width-100" /></td>
			    	    </tr>
		    	    </table>
		        </td>
		        <td width="50%">
		    	    <table  width="100%">
			    	    <tr>
			    		    <td width="40%">Profesión: </td>
			    		    <td width="60%"><input type="text" id="profesionvalorador" name="profesionvalorador" class="width-100 TextBox"></td>
			    	    </tr>
		    	    </table>
		        </td>
		    </tr>

		    <tr>
		        <td width="50%">
    			    <table  width="100%">
			    	    <tr>
			    		    <td width="40%">Línea Temática:</td>
			    		    <td width="60%"><input type="text" id="lineatematica" name="lineatematica" class="width-100 TextBox"></td>
			    	    </tr>
		    	    </table>
    		    </td>
		    </tr>
	    </table>	    
    </fieldset>
		<br>
	
		<br><br>
		<fieldset>
		    <!-- <legend>Información de la investigación</legend> -->
		    <table width="100%" class="border" border="1">
			  <col>
			  <colgroup span="2"></colgroup>
			  <colgroup span="2"></colgroup>
			  <tr>
			    <th colspan="2" scope="colgroup">Aspectos por valorar</th>
			    <th colspan="1" scope="colgroup">Puntajes </th>
			  </tr>
			  <tr>
			    <td rowspan="6" width="20%">Ruta de indagación: Desarrollo de pensamiento científico, capacidades y aprendizajes colaborativo, situado, problematizador, por indagación crítica (100 puntos máximo)</td>
			    <td  width="60%"><b>Resúmen:</b> permite comprender la pregunta y el problema de investigación, la forma en que fue resuelto y sus resultados principales</td>
			    <td>
                    <input type="text" id="puntaje1" name="puntaje1" onkeypress="return valideKey(event);" onkeyup="valmax(this.value, 10, 1)" valmax="10" maxlength="2"  class="width-100 TextBox">
                    <span class="error1" style="color:red;"></span>
			    </td>
			  </tr>
			  
			  <tr>
			    <!-- <td></td> -->
			    <td><b>Estar en Ciclón es la vía:</b> explica claramente la forma de organización del grupo de investigación, roles, símbolos, identidad y pertenencia </td><!-- (califique de 1 a 15) -->
			    <td>
                    <input type="text" id="puntaje2" name="puntaje2" onkeypress="return valideKey(event);" onkeyup="valmax(this.value, 15, 2)" valmax="15" maxlength="2"  class="width-100 TextBox">
                    <span class="error2" style="color:red;"></span>
                </td>
			  </tr>

			  <tr>
			    <!-- <td></td> -->
			    <td><b>La perturbación de la Onda en Ciclón:</b> claridad de la pregunta que orientó la investigación </td> <!-- (califíquese de 1 a 15) -->
			    <td>
                    <input type="text" id="puntaje3" name="puntaje3" onkeypress="return valideKey(event);" onkeyup="valmax(this.value, 15, 3)" valmax="15" maxlength="2"  class="width-100 TextBox">
                    <span class="error3" style="color:red;"></span>
			    </td>
			  </tr>

			  <tr>
			    <!-- <td></td> -->
			    <td><b>La superposición de la Onda en Ciclón:</b> el planteamiento del problema de investigación está bien definido, es explicado correctamente y es coherente con la pregunta de investigación </td><!-- (califíquese de 1 a 15) -->
			    <td>
                    <input type="text" id="puntaje4" name="puntaje4" onkeypress="return valideKey(event);" onkeyup="valmax(this.value, 15, 4)" valmax="15" maxlength="2"  class="width-100 TextBox">
                    <span class="error4" style="color:red;"></span>
			    </td>
			  </tr>
				<tr>
				    <td><b>Diseño y recorrido de las trayectorias de indagación en Ciclón:</b> claridad y coherencia de la investigación y la búsqueda para llegar a ella (l proceso metodológico de la investigación,   objetivos planteados y la utilización de fuentes bibliográficas).</td> <!-- (califíquese de 1 a 15) -->
				    <td>
                        <input type="text" id="puntaje5" name="puntaje5" onkeypress="return valideKey(event);" onkeyup="valmax(this.value, 15, 5)" valmax="15" maxlength="2"  class="width-100 TextBox">
                        <span class="error5" style="color:red;"></span>
				    </td>
			  	</tr>
			  	<tr>
				    <td><b>Propagación de la Onda en Ciclón:</b>  relaciona y describe los escenarios y lenguajes utilizados para dar a conocer los resultados de indagación. </td> <!-- (Califique de 1 a 10) -->
				    <td>
                        <input type="text" id="puntaje6" name="puntaje6" onkeypress="return valideKey(event);" onkeyup="valmax(this.value, 10, 6)" valmax="10" maxlength="2"  class="width-100 TextBox">
                        <span class="error6" style="color:red;"></span>
				    </td>
			  	</tr>
			  	<tr>
					<td colspan="2" align="right"><b>Puntaje Total</b></td> <!-- (Máximo 100 puntos) -->
					<td align="center"><span class="total"></span></td>
				</tr>
				<tr>
		    		<td colspan="3"><b>Firma del valorador:</b><input type="text" id="firmavalorador" name="firmavalorador" class="width-100 TextBox"></td>
		    	</tr>
				<tr>
		    		<td colspan="3"><b>Observaciones:</b> <textarea name="observaciones" id="observaciones" cols="30" rows="5" class="width-100 TextBox" placeholder=" describir las sugerencias que contribuyan al mejoramiento del proceso pedagógico de formación, investigación y socialización de los resultados del grupo"></textarea></td>
		    	</tr>

			</table>
		</fieldset>
    <br>
    
    <table width="100%" class="border">
        <tr>
            <td colspan="2" align="right">
                <input type="button" id="btn-guardar" value="Guardar" onclick="enviarestras015('insert')" class="btn btn-success">
                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

