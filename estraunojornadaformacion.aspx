<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunojornadaformacion.aspx.cs" Inherits="estraunojornadaformacion" %>

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

            cargarDepartamentoMagdalena();
            cargarAnio();
            //cargarinstituciones();
            reset();

            $("#departamento").change(function () {
                reset();
                var jsonData = '{ "departamento":"' + $("#departamento").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunojornadaformacion.aspx/cargarMunicipios',
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
                    url: 'estraunojornadaformacion.aspx/cargarInstituciones',
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
                    url: 'estraunojornadaformacion.aspx/cargarsedes',
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

        function cargarAnio() {
            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/cargaranios',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //data:frmserialize,
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "anio") {
                        $("#anio").html(resp[1]);
                        //alert(resp[0]);
                    }
                }
            });
        }

        function cargarDepartamentoMagdalena() {
            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/cargarDepartamentoMagdalena',
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
                url: 'estraunojornadaformacion.aspx/cargarInstituciones',
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
            $("#nroasistentes").val('');
            $('#btn-guardar').attr('onclick', 'enviarestragb03(\'insert\')');
           
        }

        function enviarestragb03(event) {
            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione institución");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione sede");
                $("#sede").focus();
            }           
            else if ($.trim($("#nroasistentes").val()) == '') {
                alert("Por favor, digite ek número de asistentes");
                $("#nroasistentes").focus();
            }
            
            else {
                var codsede = $("#sede").val();
                var asistentes = $("#nroasistentes").val();
                var codanio = $("#anio").val();
                enviardato(codsede, asistentes, codanio, event);
            }
        }

        //--- Inicio de nueva funcion para enviar
        function enviardato(codsede, asistentes, codanio, event) {
                if (event == 'insert') {
                    finsertInstrumento(codsede, asistentes, codanio);
                } else if (event == 'update') {
                    fupdateInstrumento(asistentes, $("#codigo").val());
                }
            }
        //--- Fin de nueva funcion para enviar

       

        function finsertInstrumento(codsede, asistentes, codanio) {
            var jsonData = '{ "codsede": "' + codsede + '", "asistentes": "' + asistentes + '", "codanio": "' + codanio + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/insertInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {

                        alert("instrumento insertado exitosamente ");
                        reset();
                        $("#table").fadeIn(500); 
                        $("#form").hide();
                        /*modificado 2016-10-24*/
                        listarJornadasFormacion();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }
        
        function fupdateInstrumento(asistentes, codigoinstrumento) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "asistentes":"' + asistentes + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/updateInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        alert("instrumento actualizado exitosamente");
                        /*2016-10-25 agregado*/
                        listarJornadasFormacion();
                       // finsertMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function loadInstrumentosJornadas(codigo) {
            
            var jsonData = '{ "codigo":"' + codigo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/loadInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        $("#codigo").val(resp[1]);

                        if (resp[3] == "20") {
                            $('#btn-guardar').hide();
                        }
                        else {
                            $("#nroasistentes").val(resp[2]);
                            $('#btn-guardar').attr('value', 'Actualizar');
                            $('#btn-guardar').attr('onclick', 'enviarestragb03(\'update\')');
                        }
                                              
                      
                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        if (resp[3] == "20") {
                            $('#btn-guardar').hide();
                        }
                        else {
                            $('#btn-guardar').val('Guardar');
                            $("#nroasistentes").val('');
                            $('#btn-guardar').attr('onclick', 'enviarestragb03(\'insert\')');
                        }
                        
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
        $(function () {
            listarJornadasFormacion();
        });

        function listarJornadasFormacion() {
            $("#form").hide();
            $("#table").fadeIn(500);

            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/listarJornadasFormacion',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function loadSelectJornadasFormacion(codigo, codanio) {
            var jsondata = "{'codigo':'" + codigo + "', 'codanio':'" + codanio + "'}";
            $.ajax({
                type: 'POST',
                url: 'estraunojornadaformacion.aspx/loadSelectJornadasFormacion',
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
                        $("#anio").val(codanio);
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
            reset();
            cargarDepartamentoMagdalena();
        }

      

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsondata = "{'codigo':'" + codigo + "'}";

                $.ajax({
                    type: 'POST',
                    url: 'estraunojornadaformacion.aspx/eliminar',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsondata,
                    success: function (json) {
                        alert("Registro eliminado correctamente");
                        listarJornadasFormacion();
                    }
                });
            }

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia Nro. 1 - Jornada de formación: <asp:Label ID="lblJornada" runat="server"></asp:Label></h2>
    <div id="table">
     <a href="#" class="btn btn-primary" style="float:right;" onclick="nuevaBitacora()">Nueva jornada</a>
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
                    <th>Fecha<br/>Creación</th>
                    <th>Momento</th>
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
                              <tr>
                                 <td >
                                    Año:  
                                 </td>
                                  <td><select class="TextBox" id="anio"></select></td>
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
        </table>
    </fieldset>
    <!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br>
    <fieldset>
        <legend>Jornadas de Formación</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    Nro de asistentes
                </td>
            </tr>
            <tr>
                <td>
                    <input id="nroasistentes" name="nroasistentes" onkeypress="return valideKey(event);" class="TextBox" type="text" style="width:50px;" />
                </td>
            </tr>
           
            <tr>
                <td>
                   <input  type="hidden" id="codigo"/><!--2016-10-25 agregado-->
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <input type="button" id="btn-guardar" value="Guardar" onclick="enviarestragb03('insert')" class="btn btn-success">
                    <a href="#" onclick="btnRegresar();" class="btn btn-primary">Regresar</a>
                </td>
            </tr>
        </table>
    </fieldset>
    <br>
    </div>
    

</asp:Content>

