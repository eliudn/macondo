<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunoparticipantesferias.aspx.cs" Inherits="estraunoparticipantesferias" %>

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
        var codinstrumento;
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
            cargartipoid();
            reset();

            $("#departamento").change(function () {
                reset();
                var jsonData = '{ "departamento":"' + $("#departamento").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunoparticipantesferias.aspx/cargarMunicipios',
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
                    url: 'estraunoparticipantesferias.aspx/cargarInstituciones',
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
                    url: 'estraunoparticipantesferias.aspx/cargarsedes',
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

            //$("#sede").change(function () {
            //    reset();
            //    var jsonData = '{ "codigosede":"' + $("#sede").val() + '"}';
               
            //    $.ajax({
            //        type: 'POST',
            //        url: 'estraunoparticipantesferias.aspx/grupoInvestigacion',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        data: jsonData,
            //        success: function (json) {
            //            var resp = json.d.split("@");
            //            if (resp[0] === "gruposinvestigacion") {
            //                $("#grupoinvestigacion").html(resp[1]);
            //            }
            //            else if (resp[0] === "vacio") {
            //                $("#grupoinvestigacion").html(json.d);

            //            } else {
            //                console.error(json.d);
            //            }
            //        }
            //    });
            //});

          
            $("input[type='date']").datepicker();

        });

        function form_agregarDocente() {
            if ($("#sede").val() == "" || $("#anio").val() == "0") {
                alert("Por favor seleccione la sede y el año para poder continuar");
            }
            else{
                $('#form-docente').dialog({
                    modal: true,
                    height: 'auto',
                    width: 'auto',
                });
            }
            
        }

        function cargartipoid() {
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/cargartipoid',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //data:frmserialize,
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "tipo") {
                        $("#tipoid").html(resp[1]);
                    }
                }
            });
        }

        function cargarAnio() {
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/cargaranios',
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

        function guardarDocentes() {
            var jsonData = '{ "tipoid": "' + $("#tipoid").val() + '", "identificacion": "' + $("#identificacion").val() + '", "nombre": "' + $("#nombre").val() + '", "apellido": "' + $("#apellido").val() + '", "sexo": "' + $("#sexo").val() + '", "fecha_nacimiento": "' + $("#fechanacimiento").val() + '", "telefono": "' + $("#telefono").val() + '", "direccion": "' + $("#direccion").val() + '", "email": "' + $("#email").val() + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/guardardocente',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                //data:frmserialize,
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "tipo") {
                        $("#tipoid").html(resp[1]);
                        guardaGradorDocentes();
                    }
                }
            });
        }

        function guardaGradorDocentes() {
            var jsonData = '{ "tipoid": "' + $("#tipoid").val() + '", "identificacion": "' + $("#identificacion").val() + '", "nombre": "' + $("#nombre").val() + '", "apellido": "' + $("#apellido").val() + '", "sexo": "' + $("#sexo").val() + '", "fechanacimiento": "' + $("#fechanacimiento").val() + '", "telefono": "' + $("#telefono").val() + '", "direccion": "' + $("#direccion").val() + '", "email": "' + $("#email").val() + '",  "codsede": "' + $("#sede").val() + '", "codanio": "' + $("#anio").val() + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/guardardocente',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                //data:frmserialize,
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "true") {
                        $("#tipoid").val('0');
                        $("#identificacion").val('');
                        $("#nombre").val('');
                        $("#apellido").val('');
                        $("#fechanacimiento").val('');
                        $("#telefono").val('');
                        $("#direccion").val('');
                        $("#email").val('');
                        alert("Docente ingresado correctamente");
                    } else if (resp[0] === "false") {
                        alert("Error al matricular docente");
                        form_agregarDocente();
                    } else if (resp[0] === "false2") {
                        alert("Error al ingresar docente");
                        form_agregarDocente();
                    }
                }
            });
        }

        function btncargardoc() {

            if ($.trim($("#sede").val()) == '' || $.trim($("#sede").val()) == null) {
                alert("Por favor seleccione la sede");
                $("#sede").focus();
                return false;
            } else if ($.trim($("#anio").val()) == '' || $.trim($("#anio").val()) == null) {
                alert("Por favor seleccione el año");
                $("#anio").focus();
                return false;
            } else {

                var jsonData = '{ "codsede": "' + $("#sede").val() + '", "codanio": "' + $("#anio").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunoparticipantesferias.aspx/cargarDocentes',
                    contentType: "application/json; charset=utf-8",
                    data: jsonData,
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "datos") {
                            $("#listData").html(resp[1]);
                        }
                        else {
                            alert("Esta sede ya fue ingresada.");
                        }
                    }
                });

            }
        }

        function matricularDocentes() {
            var codigo = "";
            $("input:checkbox:checked").each(function () {
                codigo += "@" + $(this).val();
            });

            if ($.trim($("#departamento").val()) == '' || $.trim($("#departamento").val()) == null) {
                alert("Por favor seleccione el departamento");
                $("#departamento").focus();
                return false;
            }
            else if ($.trim($("#municipio").val()) == '' || $.trim($("#municipio").val()) == null) {
                alert("Por favor seleccione el municipio");
                $("#municipio").focus();
                return false;
            }
            else if ($.trim($("#institucion").val()) == '' || $.trim($("#institucion").val()) == null) {
                alert("Por favor seleccione la institucion");
                $("#institucion").focus();
                return false;
            }
            else if ($.trim($("#sede").val()) == '' || $.trim($("#sede").val()) == null) {
                alert("Por favor seleccione la sede");
                $("#sede").focus();
                return false;
            }
            
            else if (codigo.length == 0) {
                alert("por favor seleccione los docentes a matricular");
                return false;
            }
            else {
                var jsonData = '{ "codparticipantesferias": "' + $("#codigo").val() + '", "codgradodocente": "' + codigo + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunoparticipantesferias.aspx/matricularDocentes',
                    contentType: "application/json; charset=utf-8",
                    data: jsonData,
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] == "matricula") {
                            alert(resp[1]);
                            $("#listData").html("");
                        }
                        else if (resp[0] == "vacio") {
                            alert(resp[1]);
                        }
                    }
                });
            }

            
        }

        function cargarDepartamentoMagdalena() {
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/cargarDepartamentoMagdalena',
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
                url: 'estraunoparticipantesferias.aspx/cargarInstituciones',
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
            $("#anio").val('0');
            $('#btn-guardar').attr('onclick', 'enviarespacioapro(\'insert\')');
            document.getElementById("anio").disabled = false;
            $("#listData").html('');
            document.getElementById("btncargardoc").style.visibility = "visible";
           
        }

        function enviarespacioapro(event) {
            var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione institución");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione sede");
                $("#sede").focus();
            }
            //else if ($.trim($("#grupoinvestigacion").val()) == '') {
            //    alert("Por favor, seleccione grupo investigacion");
            //    $("#grupoinvestigacion").focus();
            //} 
           
            //else if ($.trim($("#fecharealizacion").val()) == '') {
            //    alert("Por favor, digite la fecha de elaboración");
            //    $("#fecharealizacion").focus();
            //}
            //else if ($.trim($("#nroestudiantes").val()) == '') {
            //    alert("Por favor, digite el numero de estudiantes");
            //    $("#nroestudiantes").focus();
            //}
            //else if ($.trim($("#nrodocentes").val()) == '') {
            //    alert("Por favor, digite el numero de docentes");
            //    $("#nrodocentes").focus();
            //}
            
            else {
                //var codigo = $("#grupoinvestigacion").val();
                //var proyeccion = $("#proyeccion").val();
                enviardato(event);
            }
        }

        //--- Inicio de nueva funcion para enviar
        function enviardato(event) {
                //var codproyecto = $("#grupoinvestigacion").val();
                //var fecharealizacion = $("#fecharealizacion").val();
                //var nroestudiantes = $("#nroestudiantes").val();
            var sede = $("#sede").val();
            var anio = $("#anio").val();

                if (event == 'insert') {
                    finsertInstrumento(sede,anio);
                } else if (event == 'update') {
                    fupdateInstrumento($("#codigo").val());
                }
            }
        //--- Fin de nueva funcion para enviar

       

        function finsertInstrumento(codsede,codanio) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codsede": "' + codsede + '", "codanio": "' + codanio + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/insertInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        $("#codigo").val(resp[1]);
                        matricularDocentes();
                        alert("instrumento insertado exitosamente ");
                        reset();
                        $("#table").fadeIn(500); 
                        $("#form").hide();
                        listarEspaciosApro();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }
        
        function fupdateInstrumento(codigoinstrumento) {

            actualizarMatriculaDocente(codinstrumento);

            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            //var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
            //$.ajax({
            //    type: 'POST',
            //    url: 'estraunoparticipantesferias.aspx/updateInstrumento',
            //    data: jsonData,
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (data) {
            //        //console.log(data);
            //        var resp = data.d.split("@");
            //        if (resp[0] === "true") {
            //            alert("instrumento actualizado exitosamente");
            //            listarEspaciosApro();
            //            actualizarMatriculaDocente(codinstrumento);
            //        } else {
            //            alert(data.d);
            //            console.error(data.d);
            //        }
            //    }
            //});
        }

        function actualizarMatriculaDocente(codespacioapro) {

            var jsonData = '{ "codespacioapro":"' + codespacioapro + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/deletematriculaDocente',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {

                        matricularDocentes();

                    }
                    else {
                        alert("error al matricular docentes, ya existe(n) en la base de datos");
                    }
                }, complete: function () {
                    listarEspaciosApro();
                }
            });
        }

        function loadInstrumentosParticipantesFerias(codigo) {
            
            var jsonData = '{ "codigo":"' + codigo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/loadInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        codinstrumento = resp[1];
                        $("#codigo").val(resp[1]);
                        
                        //$("#fecharealizacion").val(resp[2]);
                        //$("#nroestudiantes").val(resp[3]);
                        //$("#nrodocentes").val(resp[4]);
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarespacioapro(\'update\')');
                        cargarDocentesMatriculados(resp[1], resp[2], resp[3]);
                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        //$("#proyeccion").val('');
                        $('#btn-guardar').attr('onclick', 'enviarespacioapro(\'insert\')');
                    }
                }
            });
        }

        function cargarDocentesMatriculados(codparticipantesferias, codanio, codsede) {
            var jsonData = '{ "codparticipantesferias":"' + codparticipantesferias + '", "codsede":"' + codsede + '", "codanio":"' + codanio + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/listardocentesmatriculados',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsonData,
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[1] === "datos") {
                        $("#anio").val(resp[0]);
                        $("#listData").html(resp[2]);
                        document.getElementById("anio").disabled = true;
                        document.getElementById("btncargardoc").style.visibility = "hidden";
                    } else {
                        document.getElementById("anio").disabled = false;
                        document.getElementById("btncargardoc").style.visibility = "visible";
                        $("#listData").html('');
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
            listarEspaciosApro();
        });

        function listarEspaciosApro() {
            $("#form").hide();
            $("#table").fadeIn(500);

            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/listarParticipantesFerias',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function loadSelectParticipantesFerias(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estraunoparticipantesferias.aspx/loadSelectParticipantesFerias',
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
                        if (resp[5] === "anio") {
                            $("#anio").val(resp[6]);
                        }
                        
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
                    url: 'estraunoparticipantesferias.aspx/eliminar',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsondata,
                    success: function (json) {
                        alert("Registro eliminado correctamente");
                        listarEspaciosApro();
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
    <h2 >Estrategia Nro. 1 - Maestros participantes en Comité de ferias</h2>
    <div id="table">
     <a href="#" class="btn btn-primary" style="float:right;" onclick="nuevaBitacora()">Nuevo comité</a>
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
                             <td> Año: </td>
                              <td> <select class="TextBox" id="anio"></select> </td>
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
                         <tr>
                             <td colspan="2">
                                 <a id="btncargardoc" href="javascript:void(0)" class="btn btn-primary" onclick="btncargardoc()">Buscar</a>
                             </td>
                         </tr>
                    </table>
                </td>
            </tr>
        </table>
    </fieldset>
    <!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br>
    <fieldset>
        <legend>Lista de docentes</legend>

        <fieldset>
            <legend></legend>
            <center>
                <table>
                 <tr>
                     <td align="left">
                         <a id="btndocente" href="javascript:void(0)" onclick="form_agregarDocente()" class="btn btn-success">Agregar docente</a>
                     </td>
                 </tr>
            </table>
            
           <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Identificacion</th>
                    <th>Nombre</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="listData">
            </tbody>
        </table>
            
        </center>
        </fieldset>


            <table>
            <tr>
                <td colspan="2" align="right">
                    <input type="button" id="btn-guardar" value="Guardar" onclick="enviarespacioapro('insert')" class="btn btn-success">
                    <a href="#" onclick="btnRegresar();" class="btn btn-primary">Regresar</a>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    </div>

     <div id="form-docente" style="display:none;" title="Agregar Docente">
         Antes de realizar este ingreso, por favor seleccione la sede y el año lectivo del docente
                <table>
                    <tr>
                        <td>Tipo ID</td>
                        <td><select id="tipoid" class="TextBox"></select></td>
                        <td>Identificación</td>
                        <td><input type="text" id="identificacion" class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td>Nombres</td>
                        <td><input type="text" id="nombre" class="TextBox" /></td>
                        <td>Apellidos</td>
                        <td><input type="text" id="apellido" class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td>Sexo</td>
                        <td><select id="sexo" class="TextBox"><option value="M">Masculino</option><option value="F">Femenino</option></select></td>
                        <td>Fecha de nacimiento</td>
                        <td><input id="fechanacimiento" class="TextBox" type="date" /></td>
                    </tr>
                    <tr>
                        <td>Teléfono</td>
                        <td><input type="text" id="telefono" value="0" class="TextBox" /></td>
                        <td>Dirección</td>
                        <td><input type="text" id="direccion" value="0" class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td><input type="text" id="email" value="0" class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <a href="javascript:void(0)" id="btnguardarDocentes" class="btn btn-success" style="color:white" onclick="guardaGradorDocentes()">Guardar</a>
                             <input  type="hidden" id="codigo"/>
                        </td>
                    </tr>
                </table> 
     </div>
    

</asp:Content>

