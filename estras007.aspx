<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras007.aspx.cs" Inherits="estras007" %>

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

            cargarinstituciones();
            reset();

            $("#institucion").change(function () {
                reset();
                var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'bitacora3.aspx/cargarsedes',
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
                //$.ajax({
                //    type: 'POST',
                //    url: 'bitacora3.aspx/datosSedes',
                //    contentType: "application/json; charset=utf-8",
                //    dataType: "json",
                //    data: jsonData,
                //    success: function (json) {
                //        var resp = json.d.split("&");
                //        if (resp[0] === "datossede") {
                //            //$("#departamento").html(resp[1]);
                //            //$("#municipio").html(resp[2]);
                //            //$("#telefono").val(resp[3]);
                //            //$("#email").val(resp[4]);
                //            //$("#direccion").val(resp[5]);
                //        }
                //        else {
                //            $("#modal1").openModal();
                //            $("#mensaje2").html(json.d);
                //        }
                //    }
                //});

                $.ajax({
                    type: 'POST',
                    url: 'estrag006.aspx/grupoInvestigacion',
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
                cargarInstrumento_b03($('#grupoinvestigacion').val());
            });

            $("input[type='date']").datepicker();

        });

        function fRemove(data) {
            // alert(data);
            var ant = data - 1;
            total = total - 1;
            $("#campus" + data).remove();
            $("#radiotr" + ant).append('<td><button id="remove"  class="btn btn-danger" onclick="fRemove(' + ant + ')">-</button></td>');
        }

        function cargarinstituciones() {
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/cargarInstituciones',
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
            
            //$('#grupoinvestigacion').html("<option value='' selected>Seleccione grupo investigación...</option>");
            //$('#institucion').html("<option value='' selected>Seleccione institución...</option>");
            //$('#sede').html("<option value='' selected>Seleccione sede...</option>");

            $('#btn-guardar').val('Guardar');
            $("#respuestapregunta1").val('');
            $("#respuestapregunta2").val('');
            $("#nombre").val('');
            $('#btn-guardar').attr('onclick', 'enviarestragb03(\'insert\')');
            //html = '<tr>';
            //html += '<th>Nombre del material</th>';
            //html += '<th>Cantidad</th>';
            //html += '<th>Estado <br>';
            //html += '<table width="100%">';
            //html += '<tr>';
            //html += '<td width="50%">Bueno</td>';
            //html += '<td width="50%">Regular</td>';
            //html += '</tr>';
            //html += '</table>';
            //html += '</th>';
            //html += '</tr>';
            //html += '<tr >';
            //html += '<td align="center"><input type="text" class="TextBox" width="350" id="nombrematerial1" name="nombrematerial1" class="width-100"></td>';
            //html += '<td align="center"><input type="text" class="TextBox" id="cantidad1" name="cantidad1" onkeypress="return valideKey(event);" class="width-100"></td>';
            //html += '<td>';
            //html += '<table width="100%">';
            //html += '<tr>';
            //html += '<td width="50%" style=" text-align: center;"><input type="radio" name="estado1" value="bueno"></td>';
            //html += '<td width="50%" style=" text-align: center;"><input type="radio" name="estado1" value="regular"></td>';
            //html += '</tr>';
            //html += '</table>';
            //html += '</td>';
            //html += '</tr>';
            //$("#tablecampus").html(html);
            total = 1;
        }

        function enviarestragb03(event) {
            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione institución");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione Sede");
                $("#sede").focus();
            } else if ($.trim($("#grupoinvestigacion").val()) == '') {
                alert("Por favor, seleccione grupo investigacion");
                $("#grupoinvestigacion").focus();
            } 
            //else if ($.trim($("#nombrematerial" + total).val()) == '') {
                //alert("Por favor, Ingrese nombre material");
                //$("#nombrematerial" + total).focus();
            //} else if ($.trim($("#cantidad" + total).val()) == '') {
                //alert("Por favor, Ingrese cantidad");
                //$("#cantidad" + total).focus();
            //} else if (!$('input[name="estado' + total + '"]').is(':checked')) {
                //alert('Por favor, seleccione estado');
            //} else if ($.trim($("#fechaentrega").val()) == '') {
            //    alert("Por favor, Ingrese fecha de entrega");
            //    $("#fechaentrega").focus();
            //} else if ($.trim($("#nombre").val()) == '') {
            //    alert("Por favor, Ingrese nombre");
            //    $("#nombre").focus();
            //}
            else if ($.trim($("#respuestapregunta1").val()) == '') {
                alert("Por favor, responda la primera pregunta");
                $("#respuestapregunta1").focus();
            }
            else if ($.trim($('#respuestapregunta2').val()) == '') {
                alert("Por favor, responda la segunda pregunta");
                $("#respuestapregunta2").focus();
            }
                //else if ($.trim($("#firma").val()) == '') {
                //    alert("Por favor, Ingrese firma");
                //    $("#firma").focus();
                //}
            else {
                var codigo = $("#grupoinvestigacion").val();
                var respuestapregunta1 = $("#respuestapregunta1").val();
                var respuestapregunta2 = $("#respuestapregunta2").val();
                
                //var direccion = $("#direccion").val();
                //updateSede(codigo, respuestapregunta1, respuestapregunta2, event);
                enviardato(codigo, respuestapregunta1, respuestapregunta2, event);
            }
        }

        //--- Inicio de nueva funcion para enviar
            function enviardato(codigo, respuestapregunta1, respuestapregunta2, event) {
                var codproyecto = $("#grupoinvestigacion").val();
                var respuestapregunta1 = $("#respuestapregunta1").val();
                var respuestapregunta2 = $("#respuestapregunta2").val();
                //alert(codigoinstrumento);
                if (event == 'insert') {
                    finsertInstrumento(codproyecto, respuestapregunta1, respuestapregunta2);
                } else if (event == 'update') {
                    fupdateInstrumento(codproyecto, respuestapregunta1, respuestapregunta2, codigoinstrumento);
                }
            }
        //--- Fin de nueva funcion para enviar

        function updateSede(codigo, respuestapregunta1, respuestapregunta2, event) {
            //console.log(codigo + " " + telefono + " " + email + " " + direccion);
            var jsonData = '{ "codigo":"' + codigo + '", "respuestapregunta1": "' + respuestapregunta1 + '", "respuestapregunta2": "' + respuestapregunta2 + '" }';
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/updateDatosSede',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        console.log("datos de sede actualizados exitosamente");
                        //var fechaejecucion = $("#fechaentrega").val();
                        var codproyecto = $("#grupoinvestigacion").val();
                        var respuestapregunta1 = $("#respuestapregunta1").val();
                        var respuestapregunta2 = $("#respuestapregunta2").val();
                        //alert(codigoinstrumento);
                        if (event == 'insert') {
                            finsertInstrumento(codproyecto, respuestapregunta1,respuestapregunta2);
                        } else if (event == 'update') {
                            fupdateInstrumento(codproyecto, respuestapregunta1, respuestapregunta2, codigoinstrumento);
                        }
                        
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function finsertInstrumento(codproyecto, respuestapregunta1,respuestapregunta2) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codproyecto": "' + codproyecto + '", "respuestapregunta1": "' + respuestapregunta1 + '", "respuestapregunta2": "' + respuestapregunta2 + '"}';
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/insertInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        //console.log("instrumento insertado exitosamente" + resp[1]);
                        //codigoinstrumento = resp[1];
                        alert("instrumento insertado exitosamente ");
                        reset();
                        //finsertMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }
        
        function fupdateInstrumento(codproyecto, respuestapregunta1, respuestapregunta2) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "codproyecto":"' + codproyecto + '", "respuestapregunta1": "' + respuestapregunta1 + '", "respuestapregunta2": "' + respuestapregunta2 + '"}';
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/updateInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        //alert("instrumento actualizado exitosamente " + codigoinstrumento);

                        finsertMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function cargarInstrumento_b03(codigogrupo) {
            
            var jsonData = '{ "codproyectosede":"' + codigogrupo + '"}';
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/loadInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        codigoinstrumento = resp[5];
                        floadMaterial(codigoinstrumento);
                        
                        $("#nombre").val(resp[3]);
                        $("#fechaentrega").val(resp[4]);
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestragb03(\'update\')');

                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        $("#fechaentrega").val('');
                        $("#nombre").val('');
                        $('#btn-guardar').attr('onclick', 'enviarestragb03(\'insert\')');
                        html = '<tr>';
                        html += '<th>Nombre del material</th>';
                        html += '<th>Cantidad</th>';
                        html += '<th>Estado <br>';
                        html += '<table width="100%">';
                        html += '<tr>';
                        html += '<td width="50%">Bueno</td>';
                        html += '<td width="50%">Regular</td>';
                        html += '</tr>';
                        html += '</table>';
                        html += '</th>';
                        html += '</tr>';
                        html += '<tr >';
                        html += '<td align="center"><input type="text" class="TextBox" width="350" id="nombrematerial1" name="nombrematerial1" class="width-100"></td>';
                        html += '<td align="center"><input type="text" class="TextBox" id="cantidad1" name="cantidad1" onkeypress="return valideKey(event);" class="width-100"></td>';
                        html += '<td>';
                        html += '<table width="100%">';
                        html += '<tr>';
                        html += '<td width="50%" style=" text-align: center;"><input type="radio" name="estado1" value="bueno"></td>';
                        html += '<td width="50%" style=" text-align: center;"><input type="radio" name="estado1" value="regular"></td>';
                        html += '</tr>';
                        html += '</table>';
                        html += '</td>';
                        html += '</tr>';
                        $("#tablecampus").html(html);
                        total = 1;
                        //alert(data.d);
                        //console.error(data.d);
                    }
                }
            });
        }

        //funcion para insertar los materiales
        function finsertMaterial() {
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/deleteMaterial',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {

                        for (var i = 1; i <= total; i++) {
                            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "nombrematerial":"' + $("#nombrematerial" + i).val() + '", "cantidad":"' + $("#cantidad" + i).val() + '", "estado":"' + $("input[name='estado" + i + "']:checked").val() + '"}';
                            $.ajax({
                                type: 'POST',
                                url: 'bitacora3.aspx/insertMaterial',
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
                    $('#btn-guardar').attr('onclick', 'enviarestragb03(\'update\')');
                }
            });
        }

        //funcion para traer todo los materiales
        function floadMaterial(codigoinstrumento) {
            total = 1;
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total + '}';
            $.ajax({
                type: 'POST',
                url: 'bitacora3.aspx/loadMaterial',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "mat") {
                        $("#tablecampus").html(resp[1]);
                        total = resp[2];
                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        $("#tablecampus").html(resp[1]);
                        //alert(data.d);
                        //console.error(data.d);
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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 style="text-decoration: underline;">EVALUACIÓN DE LA ASESORIA</h2>

    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false"></asp:Label>
    <span>Con el propósito de mejorar nuestras actividades, le solicitamos responder objetivamente los siguientes enunciados, marcando con una X, la respuesta que usted considere adecuada, teniendo en cuenta que 5 es Excelente, 4 es bueno, 3 es regular, 2 es Deficiente y 1 muy Deficiente.</span><br />
    
    <fieldset>
        
        <legend>1.	INFORMACIÓN GENERAL</legend>
        <table width="100%">
            <tr>
                <td width="60%">
                    <table width="100%">
                        <tr width="100%">
                            <td style="width: 300px;">Nombre del Asesor</td>
                        
                            <td width="80%">
                                <input type="text" id="nombreasesor" name="nombreasesor" />
                            </td>
                        </tr>
                        <tr width="100%">
                            <td style="width: 300px;">Nombre de la entidad operadora</td>
                        
                            <td width="80%">
                                <input type="text" id="entidadoperadora" name="entidadoperadora" />
                            </td>
                        </tr>
                        <tr width="100%">
                            <td style="width: 300px;">Tema tratado</td>
                        
                            <td width="80%">
                                <input type="text" id="tematratado" name="tematratado" />
                            </td>
                        </tr>
                        <tr width="100%">
                            <td style="width: 300px;">Fecha de la evaluación</td>
                        
                            <td width="80%">
                                <input type="date" id="fechaevaluacion" name="fechaevaluacion" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </fieldset>
    
    <br>
    <fieldset>
        <legend>ACTIVIDAD</legend>
    <fieldset>
        <legend>1. OBJETIVOS DE LA ACTIVIDAD</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    1.1 ¿Los objetivos de la actividad del asesor se presentaron de una manera adecuada?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br>
    <fieldset>
        <legend>2. DESARROLLO DE LA ACTIVIDAD</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    2.1 ¿Las actividades de participación desarrolladas por el asesor fueron adecuadas (trabajos en grupo, lecturas, casos dinámicas, otros)?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            <tr>
                <td>
                    2.2 ¿La metodología utilizada por el asesor fue clara?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
       </table>
    </fieldset>
    <br>     
    <fieldset>
        <legend>3. CONTENIDO DE LA ASESORÍA</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    3.1 ¿El tema y los conceptos tratados por el asesor fueron claros?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            <tr>
                <td>
                    3.2 ¿Las ayudas didácticas fueron apropiadas (videos, video beam, otros)?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            <tr>
                <td>
                    3.3 El tema visto, ¿le sirve en el desarrollo del proyecto de investigación?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            <tr>
                <td>
                    3.4 ¿Los temas de la actividad resuelven sus necesidades de formación con respecto a las actividades que desarrollará dentro de la investigación a trabajar?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            
       </table>
    </fieldset>
    <br>        
    <fieldset>
        <legend>4. ASESOR</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    4.1 ¿Demostró conocimiento y manejo de tema?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            <tr>
                <td>
                    4.3 ¿Creó un ambiente agradable, respetuoso y abierto a inquietudes?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
            <tr>
                <td>
                    4.4 ¿Propició y logró la participación del grupo?
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="1" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="2" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text"style="width:100%"  placeholder="3" />                    
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="4" />
                </td>
                <td align="right" width="5%">
                    <input type="text" style="width:100%" placeholder="5" />
                </td>
            </tr>
                        
       </table>
    </fieldset>
        <table width="100%" border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    SUGERENCIAS:
                </td>
            </tr>
            <tr>
                <td>
                    <textarea id="sugerencias" name="sugerencias" style="width:100%"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="right">
                    <input type="button" id="btn-guardar" value="Guardar" onclick="enviarestragb03('insert')" class="btn btn-success">
                    <%--<asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />--%>
                </td>
            </tr>    
        </table> 
    </fieldset>       
        
    <%--</fieldset>--%>
    <%--<br>--%>
    

</asp:Content>

