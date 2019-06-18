<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estrag006reporte2.aspx.cs" Inherits="estrag006reporte2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

     <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

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
            cargarListadoMateriales();
            //cargarinstituciones();
            reset();

            $("#add").click(function () {

                if ($.trim($("#nombrematerial" + total).val()) == '') {
                    alert("Por favor, Ingrese nombre material");
                    $("#nombrematerial" + total).focus();
                } else if ($.trim($("#cantidad" + total).val()) == '') {
                    alert("Por favor, Ingrese cantidad");
                    $("#cantidad" + total).focus();
                } else if (!$('input[name="estado' + total + '"]').is(':checked')) {
                    alert('Por favor, seleccione estado');
                } else {
                    total = parseInt(total) + 1;
                    // alert(total);
                    if ($("#remove")) {
                        $("#remove").remove();
                    }
                    html = '<tr id="campus' + total + '">';
                    html += '<td align="center"><input type="text" class="TextBox" id="nombrematerial' + total + '" name="nombrematerial' + total + '" class="width-100"></td>';
                    html += '<td align="center"><input type="text" class="TextBox" id="cantidad' + total + '" onkeypress="return valideKey(event);" name="cantidad' + total + '" class="width-100"></td>';
                    html += '<td><table ><tr id="radiotr' + total + '"><td style=" text-align: center;" align="center"><input type="radio" name="estado' + total + '" value="bueno"></td><td style=" text-align: center;" align="center"><input type="radio" name="estado' + total + '" value="regular"></td><td><br /><button id="remove" class="btn btn-danger" onclick="fRemove(' + total + ')">-</button></td></tr></table></td>';
                    $("#tablecampus").append(html);

                }
            });


            //Cargar departamento
            cargarDepartamento();

            $("#departamento").on("change", function () {
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estrag006reporte2.aspx/cargarMunicipioMagdalena',
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

            //cargando las instituciones
            //cargarinstituciones();

            //cargando sedes segun institucion seleccionada
            $("#institucion").change(function () {
                var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estrag006reporte2.aspx/cargarsedes',
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

            $("input[type='date']").datepicker();

        });

        var table;
        //JQuerys

        function cargarDataTable() {
            table = $('#infoListTable').DataTable({
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

        function cargarDepartamento()
        {
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/cargarDepartamentoMagdalena',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "departamento") {
                        $("#departamento").html(resp[1]);
                    }
                }
            });
        }

        function cargarListadoMateriales()
        {
           
            //$("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            //var jsondata = "{'page':'" + page + "','rows':'" + rows + "'}";
            
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/cargarListadoMaterialesAsesor',
                //data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                success: function (response) {

                    var resp = response.d.split("@");

                    $("#infoListTable tbody").html(resp[0]);
                    $("#btn-guardar").hide(resp[1]);
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
            $("#radiotr" + ant).append('<td><button id="remove"  class="btn btn-danger" onclick="fRemove(' + ant + ')">-</button></td>');
        }

        function cargarinstituciones(codMunicipio) {
            reset();
            var jsonData = '{ "codmunicipio":"' + codMunicipio + '"}';
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/cargarInstituciones',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
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
            $('#telefono').val('');
            $("#email").val('');
            $("#direccion").val('');

            $('#grupoinvestigacion').html("<option value='' selected>Seleccione grupo investigación...</option>");

            $('#btn-guardar').val('Guardar');
            $("#fechaentrega").val('');
            $("#nombre").val('');
            $('#btn-guardar').attr('onclick', 'enviarestrag006reporte2(\'insert\')');

            $("#cantidad1").val('');
            $("#cantidad2").val('');
            $("#cantidad3").val('');
            $("#cantidad4").val('');

            $("input[type=radio]").attr('checked', false);

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
            //total = 1;
        }

        function enviarestrag006reporte2(event) {
            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            if ($.trim($("#departamento").val()) == '') {
                alert("Por favor, seleccione departamento");
                $("#departamento").focus();
            } else if ($.trim($("#municipio").val()) == '') {
                alert("Por favor, seleccione municipio");
                $("#municipio").focus();
            } else if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione institución");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione sede");
                $("#sede").focus();
            } else if ($.trim($("#nombrematerial" + total).val()) == '') {
                alert("Por favor, Ingrese nombre material");
                $("#nombrematerial" + total).focus();
            } else if ($.trim($("#cantidad" + total).val()) == '') {
                alert("Por favor, Ingrese cantidad");
                $("#cantidad" + total).focus();
            } else if (!$('input[name="estado' + total + '"]').is(':checked')) {
                alert('Por favor, seleccione estado');
            } else if ($.trim($("#fechaentrega").val()) == '') {
                alert("Por favor, Ingrese fecha de entrega");
                $("#fechaentrega").focus();
            } else if ($.trim($("#nombre").val()) == '') {
                alert("Por favor, Ingrese nombre");
                $("#nombre").focus();
            }
           
            
                //else if ($.trim($("#firma").val()) == '') {
                //    alert("Por favor, Ingrese firma");
                //    $("#firma").focus();
                //}
            else {
                var codsede = $("#sede").val();
                var fechaentregamaterial = $("#fechaentrega").val();
                var nombrequienrecibe = $("#nombre").val();
                if (event == 'insert') {
                    finsertInstrumento(fechaentregamaterial, codsede, nombrequienrecibe);
                } else if (event == 'update') {
                    fupdateInstrumento(fechaentregamaterial, nombrequienrecibe, codigoinstrumento);
                }
                //updateSede(codigo, telefono, email, direccion, event);
            }
        }

        //function updateSede(codigo, telefono, email, direccion, event) {
        //    //console.log(codigo + " " + telefono + " " + email + " " + direccion);
        //    var jsonData = '{ "codigo":"' + codigo + '", "telefono": "' + telefono + '", "email": "' + email + '", "direccion": "' + direccion + '" }';
        //    $.ajax({
        //        type: 'POST',
        //        url: 'estrag006reporte2.aspx/updateDatosSede',
        //        data: jsonData,
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (data) {
        //            console.log(data);
        //            var resp = data.d.split("@");
        //            if (resp[0] === "true") {
        //                console.log("datos de sede actualizados exitosamente");
        //                var fechaentregamaterial = $("#fechaentrega").val();
        //                var codsede = $("#sede").val();
        //                var nombrequienrecibe = $("#nombre").val();
        //                //alert(codigoinstrumento);
        //                if (event == 'insert') {
        //                    finsertInstrumento(fechaentregamaterial, codsede, nombrequienrecibe);
        //                } else if (event == 'update') {
        //                    fupdateInstrumento(fechaentregamaterial, codsede, nombrequienrecibe, codigoinstrumento);
        //                }
                        
        //            } else {
        //                alert(data.d);
        //                console.error(data.d);
        //            }
        //        }
        //    });
        //}

        function finsertInstrumento(fechaentregamaterial, codsede, nombrequienrecibe) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "fechaentregamaterial":"' + fechaentregamaterial + '", "codsede": "' + codsede + '", "nombrequienrecibe": "' + nombrequienrecibe + '"}';
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/insertInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        console.log("instrumento insertado exitosamente" + resp[1]);
                        codigoinstrumento = resp[1];
                        //alert("instrumento insertado exitosamente " + codigoinstrumento);

                        finsertMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function fupdateInstrumento(fechaentregamaterial, nombrequienrecibe, codigoinstrumento) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "fechaentregamaterial":"' + fechaentregamaterial + '", "nombrequienrecibe": "' + nombrequienrecibe + '"}';
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/updateInstrumento',
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

        function loadInstrumento(codigogrupo) {
            
            var jsonData = '{ "codigo":"' + codigogrupo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/loadInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        codigoinstrumento = resp[5];
                        loadSelectInstrumento(codigoinstrumento);
                        floadMaterial(codigoinstrumento);
                        
                        $("#nombre").val(resp[3]);
                        $("#fechaentrega").val(resp[4]);
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestrag006reporte2(\'update\')');

                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        $("#fechaentrega").val('');
                        $("#nombre").val('');
                        $('#btn-guardar').attr('onclick', 'enviarestrag006reporte2(\'insert\')');
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
                url: 'estrag006reporte2.aspx/deleteMaterial',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {

                        for (var i = 1; i <= 4; i++) {
                            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "nombrematerial":"' + $("#nombrematerial" + i).val() + '", "cantidad":"' + $("#cantidad" + i).val() + '", "estado":"' + $("input[name='estado" + i + "']:checked").val() + '"}';
                            $.ajax({
                                type: 'POST',
                                url: 'estrag006reporte2.aspx/insertMaterial',
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
                    window.location.href = "estrag006reporte2.aspx";
                    $('#btn-guardar').attr('value', 'Actualizar');
                    $('#btn-guardar').attr('onclick', 'enviarestrag006reporte2(\'update\')');
                }
            });
        }

        //funcion para traer todo los materiales
        function floadMaterial(codigoinstrumento) {
            total = 1;
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total + '}';
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/loadMaterial',
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

        function loadSelectInstrumento(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag006reporte2.aspx/loadSelectInstrumento',
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
                    }
                }
            });
        }

        function resetSelect() {
            cargarDepartamento();
            //$("#departamento").val("");
            $("#municipio").val("Seleccione municipio");
            $("#institucion").val("Seleccione institución");
            $("#sede").val("Seleccione sede");
           

            $('#btn-guardar').attr('value', 'Guardar todo');
            $('#btn-guardar').attr('onclick', 'enviarestrag006reporte2(\'insert\')');
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro? Recuerde que perderá las evidencias que tenga cargadas')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estrag006reporte2.aspx/deleteestrag006reporte2',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            eliminarEvidencias(codigo);
                            alert('Registro eliminado correctamente.');
                            window.location.href = "estrag006reporte2.aspx";
                            //cargarListadoMateriales("1", "10");
                        }
                    }
                });
            }

        }

        function eliminarEvidencias(codigo) {
           
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estrag006reporte2.aspx/eliminarEvidenciasEntregaMaterial',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData
                });
  
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. 2  - G006: Entrega de material pedagógico</h2>
    <asp:Label runat="server" ID="lblEstrategia" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
    <div id="formTable" style="display:none;">
    <!-- DATOS DE LA INSTITUCIÓN -->
    <fieldset>
        <legend>DATOS DE LA INSTITUCIÓN</legend>
        <table >
             <tr>
            <td>Departamento </td>
                        <td >
                            <select class="TextBox width-100" name="departamento" id="departamento">
                                <option value="">Seleccione departamento</option>
                            </select></td>
        </tr>
         <tr>
            <td >Municipio </td>
                        <td >
                            <select class="TextBox width-100" name="municipio" id="municipio"> 
                                <option value="">Seleccione municipio</option>
                            </select></td>
        </tr>
            <tr>
                <td>Institución Educativa:</td>
                            <td>
                                <select class="TextBox" name="institucion" id="institucion" style="width: 300px;">
                                    <option value="">Seleccione...</option>
                                </select></td>
            </tr>
            <tr>
                 <td >Sede: </td>
                            <td>
                                <select class="TextBox" name="sede" id="sede" style="width: 300px;">
                                    <option value='' selected>Seleccione sede...</option>
                                </select></td>
                            <td>
            </tr>
          
             <%-- <tr>
                <td width="50%">Teléfono: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="telefono" name="telefono" /></td>
                </tr>
          <tr>
                <td width="50%">
                    <table>
                        <tr>
                            <td width="50%">Email: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="email" name="email" /></td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <%--<tr>--%>
                <%--<td width="50%">
                    <table>
                        <tr>
                            <td width="50%">Dirección: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="direccion" name="direccion" /></td>
                        </tr>
                    </table>
                </td>--%>
                <%--<td width="50%">
                    <table>
                        <tr>
                            <td width="50%">Jornada: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="jornada" name="jornada" /></td>
                        </tr>
                    </table>
                </td>--%>
           <%-- </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td width="27%">Nombre del grupo de investigación: </td>
                            <td width="50%">
                                <select class="TextBox" name="grupoinvestigacion" id="grupoinvestigacion" style="width: 270px;">
                                    <option value="">Seleccione grupo investigación...</option>
                                </select></td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </fieldset>
    <!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br>
    <fieldset>
        <legend>RELLENE LA INFORMACIÓN</legend>

          <table class="mGridTesoreria" id="tablecampus">
            <tr>
                <th>Nombre del material</th>
                <th>Cantidad</th>
                <th>Estado
                    <br/>
                    <table >
                        <tr>
                            <td >Bueno</td>
                            <td >Regular</td>
                        </tr>
                    </table>
                </th>
            </tr>
            <tr>

                <td align="center">
                    <input type="text" class="TextBox" width="350" id="nombrematerial1" name="nombrematerial1" value="Caja de herramientas para maestros" class="width-100" style="width:250px;" disabled></td>
                <td align="center">
                    <input type="text" class="TextBox" id="cantidad1" name="cantidad1"  onkeypress="return valideKey(event);" class="width-100" style="width:40px;"></td>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado1" value="bueno"></td>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado1" value="regular"></td>
                        </tr>
                    </table>
                </td>
            </tr>
              <tr>

                <td align="center">
                    <input type="text" class="TextBox" width="350" id="nombrematerial2" name="nombrematerial1" value="Libros de apoyo" class="width-100" style="width:250px;" disabled></td>
                <td align="center">
                    <input type="text" class="TextBox" id="cantidad2" name="cantidad2"  onkeypress="return valideKey(event);" class="width-100" style="width:40px;"></td>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado2" value="bueno"></td>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado2" value="regular"></td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr>

                <td align="center">
                    <input type="text" class="TextBox" width="350" id="nombrematerial3" name="nombrematerial1" value="Publicaciones" class="width-100" style="width:250px;" disabled></td>
                <td align="center">
                    <input type="text" class="TextBox" id="cantidad3" name="cantidad3"  onkeypress="return valideKey(event);" class="width-100" style="width:40px;"></td>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado3" value="bueno"></td>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado3" value="regular"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>

                <td align="center">
                    <input type="text" class="TextBox" width="350" id="nombrematerial4" name="nombrematerial4" value="Otro" class="width-100" style="width:250px;" disabled></td>
                <td align="center">
                    <input type="text" class="TextBox" id="cantidad4" name="cantidad4"  onkeypress="return valideKey(event);" class="width-100" style="width:40px;"></td>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado4" value="bueno"></td>
                            <td width="50%" style="text-align: center;">
                                <input type="radio" name="estado4" value="regular"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
       <%-- <table width="100%">
            <tr>
                <td colspan="3" align="right">
                    <button id="add" class="btn btn-primary" type="button">+</button></td>
            </tr>
        </table>--%>
    </fieldset>
    <br>
    <fieldset>
        <!-- <legend>RELLENE LA INFORMACIÓN</legend> -->
        <table width="100%" class="border">
            <tr>
                <td width="40%">Fecha de entrega del material pedagógico
                </td>
                <td width="60%">
                    <input type="date" class="TextBox" class="width-100" name="fechaentrega" id="fechaentrega">
                </td>
            </tr>
            <tr>
                <td>Nombre y Firma de quien recibe el material pedagógico.</td>
                <td>
                    <table width="100%">
                        <tr>
                            <td > </td>
                            <td >
                                <input type="text" class="TextBox" name="nombre" id="nombre" class="width-100"></td>
                        </tr>
                      <%--  <tr>
                            <td>Firma: </td>
                            <td>
                                <input type="text" class="TextBox" name="firma" id="firma" class="width-100"></td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <input type="button" id="btn-guardar" value="Guardar" onclick="enviarestrag006reporte2('insert')" class="btn btn-success">
                    <a href="estrag006reporte2.aspx" class="btn btn-primary">Volver</a>
                    <%--<input type="button" id="btn-volver" value="Volver" onclick="$('#formTable').hide(); $('#listTable').fadeIn(500); reset(); cargarListadoMateriales('1', '10');" class="btn btn-primary">--%>
                   
                </td>
            </tr>
        </table>
    </fieldset>
</div>

    <!-- Listar entrega de materiales -->

    <div id="listTable">
         <a class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500), resetSelect(), reset(), resetSelect()">Nuevo registro</a>
        <a class="btn btn-success" style="float:right" href="estradossecretariaedu_evi.aspx">Acta de materiales SED</a>
         <br /><br /><br />
         <table class="mGridTesoreria" id="infoListTable">
            <thead>
                <tr>
                    <th>Nro.</th>
                    <th>Coordinador</th>
                    <th>Municipio</th>
                    <th>Institución</th>
                    <th>Sede</th>
                    <th>Quien recibe</th>
                    <th></th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
         <%--<div id="paginacion" class="pagination"></div>--%>
    </div>


</asp:Content>

