<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verestraunobitacoratres.aspx.cs" Inherits="verestraunobitacoratres" %>

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
            cargarasesores();
            //cargarDepartamentoMagdalena();
            //cargarinstituciones();
            
            $("#asesores").change(function () {
                console.log($("#asesores").val());

                listarBitacoraTres($("#asesores").val());
            });

            $("#departamento").change(function () {
                reset();
                var jsonData = '{ "departamento":"' + $("#departamento").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunobitacoratres.aspx/cargarMunicipios',
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
                    url: 'estraunobitacoratres.aspx/cargarInstituciones',
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
                    url: 'estraunobitacoratres.aspx/cargarsedes',
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
                    url: 'estraunobitacoratres.aspx/grupoInvestigacion',
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

        function cargarasesores() {

            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: 'verestraunobitacorados.aspx/cargarasesores',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    if (response.d != null) {
                        $("#asesores").html(response.d);
                    }
                }
            });
        }
        function cargaranio(codProyecto) {
            var jsondata = "{'codProyecto':'" + codProyecto + "'}";
            $.ajax({
                type: 'POST',
                data: jsondata,
                dataType: 'JSON',
                url: 'verestraunobitacorados.aspx/cargaranios',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    $('#anios').html(response.d);
                }
            });
        }

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
                url: 'estraunobitacoratres.aspx/cargarDepartamentoMagdalena',
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
                url: 'estraunobitacoratres.aspx/cargarInstituciones',
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
                alert("Por favor, seleccione sede");
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
                    fupdateInstrumento(codproyecto,respuestapregunta1, respuestapregunta2, $("#codigo").val());
                }
            }
        //--- Fin de nueva funcion para enviar

        function updateSede(codigo, respuestapregunta1, respuestapregunta2, event) {
            //console.log(codigo + " " + telefono + " " + email + " " + direccion);
            var jsonData = '{ "codigo":"' + codigo + '", "respuestapregunta1": "' + respuestapregunta1 + '", "respuestapregunta2": "' + respuestapregunta2 + '" }';
            $.ajax({
                type: 'POST',
                url: 'verestraunobitacoratres.aspx/updateDatosSede',
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
                url: 'verestraunobitacoratres.aspx/insertInstrumento',
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
                        /*modificado 2016-10-24*/
                        listarBitacoraTres();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }
        
        function fupdateInstrumento(codproyecto, respuestapregunta1, respuestapregunta2, codigoinstrumento) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "codproyecto":"' + codproyecto + '", "respuestapregunta1": "' + respuestapregunta1 + '", "respuestapregunta2": "' + respuestapregunta2 + '"}';
            $.ajax({
                type: 'POST',
                url: 'verestraunobitacoratres.aspx/updateInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        //alert("instrumento actualizado exitosamente " + codigoinstrumento);
                        /*2016-10-25 agregado*/
                        listarBitacoraTres();
                       // finsertMaterial();
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
                url: 'verestraunobitacoratres.aspx/loadInstrumento',
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
                url: 'verestraunobitacoratres.aspx/deleteMaterial',
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
                url: 'verestraunobitacoratres.aspx/loadMaterial',
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
      <!--2016-10-24 JONNY PACHECO metodo para  listar las bitacoras-->
    <script>
        //$(function () {
        //    listarBitacoraTres();
        //});

        function listarBitacoraTres(codasesorcoordinador) {
            //$("#form").hide();
            //$("#table").fadeIn(500);
            $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'codasesorcoordinador':'" + codasesorcoordinador + "'}";
            $.ajax({
                type: 'POST',
                url: 'verestraunobitacoratres.aspx/listarBitacoraTres',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function loadSelectBitacoraTres(codProyecto) {
            var jsondata = "{'codProyecto':'" + codProyecto + "'}";
            $.ajax({
                type: 'POST',
                url: 'verestraunobitacoratres.aspx/loadSelectBitacoraTres',
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
                        cargaranio(codProyecto);
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
            $("#grupoinvestigacion").html("<option value=''>Seleccione grupo de investigación...</option>");
            reset();
            cargarDepartamentoMagdalena();
        }

        function traerPreguntasTres(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'verestraunobitacoratres.aspx/traerPreguntasTres',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    $("#codigo").val(resp[1])
                    $("#respuestapregunta1").val(resp[2]);
                    $("#respuestapregunta2").val(resp[3]);
                    
                    $('#btn-guardar').attr('value', 'Actualizar');
                    $('#btn-guardar').attr('onclick', 'enviarestragb03(\'update\')');
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
    <h2 >Estrategia Nro. 1 - Bitacora Nro. 3</h2>
    <div id="table">
     <a href="#" class="btn btn-primary" style="float:right;display:none;" onclick="nuevaBitacora()">Nueva bitácora 3</a>
         <table>
        <tr>
            <td>Asesor:</td>
            <td><select id="asesores" class="TextBox"><option>Seleccione asesor...</option></select></td>
        </tr>
      </table>
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

    <!-- DATOS DE LA INSTITUCIÓN -->
    <div id="form" style="display:none;">
    <fieldset>
        <legend>DATOS DE LA INSTITUCIÓN</legend>
        <table width="100%">
            <tr>
                <td width="60%">
                     <table width="100%">
                           <tr width="100%">
                            <td style="width: 150px;">Año lectivo:</td>
                            <td >
                                <select class="TextBox" name="anios" id="anios" >
                                    <option value="">Seleccione año...</option>
                                </select></td>
                            </tr>
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
                <td >
                    <table>
                        <tr>
                            <td width="27%">Nombre del grupo de investigación: </td>
                            <td style="width: 205px;">
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
        <legend>PROBLEMA DE INVESTIGACIÓN</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    1. Describa el problema que se han planteado y sus características. El contexto geográfico, su relación con las personas que afectan, las causas y consecuencias del mismo u otros aspectos que consideren importantes. De igual manera, a partir de los recursos humanos, físicos y económicos y del tiempo disponible, argumenten hasta donde se pretende llegar con la investigación iniciada.
                </td>
            </tr>
            <tr>
                <td>
                    <textarea rows="5" id="respuestapregunta1" name="respuestapregunta1" cols="200" style="width: 100%;"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    2. Con base en los puntos anteriores, justifiquen la importancia de resolver el problema o avanzar en su solución. Explique hasta dónde el grupo pretende llegar con la investigación y en la solución del problema.
                </td>
            </tr>
            <tr>
                <td>
                    <textarea  rows="5" id="respuestapregunta2" name="respuestapregunta2" cols="200" style="width: 100%;"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                   <input  type="hidden" id="codigo"/><!--2016-10-25 agregado-->
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <input type="button" id="btn-guardar" value="Guardar" onclick="enviarestragb03('insert')" class="btn btn-success" style="display:none;">
                    <a href="#" onclick="btnRegresar();" class="btn btn-primary">Regresar</a>
                </td>
            </tr>
        </table>
    </fieldset>
    <br>
    </div>
    

</asp:Content>

