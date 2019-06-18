<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estracincos004Coordasistencia.aspx.cs" Inherits="estracincos004Coordasistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script src="js/jquery.timepicker.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="Styles/jquery.timepicker.css"/>
    <style> 
		fieldset{
			padding: 10px;
		}
		table.border td, table.border th{
			/*border: 1px solid;*/
			margin: 0;
			padding: 5px;
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
        $(function () {
            cargarListado();
            cargarEncabezados();
            /*Configurar idioma del calandario*/
            $.datepicker.regional['es'] = {
                closeText: 'Cerrar',
                prevText: ' nextText: Sig>',
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié;', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            /*Asignar idioma al calendario*/
            $.datepicker.setDefaults($.datepicker.regional['es']);

            $("#fecha").datepicker({
                dateFormat: 'yy-mm-dd'
            });
            /*//////////////////////////////////////////////////////////////////////////////////////////////////////*/
            $("#hInicio").timepicker({ 'timeFormat': 'H:i' });
            $("#hFin").timepicker({ 'timeFormat': 'H:i' });

            /*//////////////////////////////////////////////////////////////////////////////////////////////////////
            $.ajax({
                url: 'estracincos004Coordasistencia.aspx/cargarInstituciones',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#instituciones").html(response.d);
                }
            });*/

            /*//////////////////////////////////////////////////////////////////////////////////////////////////////
            $("#instituciones").on('change', function () {
                var data = "{'codInstitucion': '" + $('#instituciones').val() + "'}"
                $.ajax({
                    url: 'estracincos004Coordasistencia.aspx/cargarSedesInstitucion',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#sedes").html(response.d);
                    }
                });
            });*/

            /*//////////////////////////////////////////////////////////////////////////////////////////////////////
            $("#sedes").on("change", function () {
                var data = "{'codSede':'" + $("#sedes").val() + "'}";
                $.ajax({
                    url: 'estracincos004Coordasistencia.aspx/cargarRedTematica',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#redtematica").html(response.d);
                    }
                });
            });

            $("#redtematica").on("change", function () {
                var data = "{'codRedTematica':'" + $("#redtematica").val() + "', 'codSede':'" + $("#sedes").val() + "'}";
                $.ajax({
                    url: 'estracincos004Coordasistencia.aspx/cargarEstudiantes',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#contentTable").html(response.d);
                    }
                });
            });*/
        });

      

        function cargarEstudiantes() {
           
            $.ajax({
                url: 'estracincos004Coordasistencia.aspx/cargarEstudiantes',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#contentTable").html(response.d);
                }
            });

        }

        function loadinstrumento(codigo) {
            $('#agregar').fadeIn(500);
            $('#list').hide();
            $('#btguardar').hide();
            var data = "{'codigo':'" + codigo + "'}";
            $.ajax({
                url: 'estracincos004Coordasistencia.aspx/cargarinasistentes',
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#contentTable").html(response.d);
                }
            });

        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var data = "{'codigo':'" + codigo + "'}";
                $.ajax({
                    url: 'estracincos004Coordasistencia.aspx/eliminar',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        cargarListado();
                        alert("Eliminado correctamente.");
                    }
                });
            }
        }

     

        function cargarEncabezados() {
            $.ajax({
                type: 'POST',
                url: 'estracincos004Coordasistencia.aspx/cargarEncabezados',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    //console.log(json);
                    //loadEvidencias(codigo)
                    var resp = json.d.split("@");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];
                        $("#txttActividad").val(resp[2]);
                        $("#fecha").val(resp[3]);

                        $("#hInicio").val(resp[4]);
                        $("#hFin").val(resp[5]);

                        if(resp[6] === "20")
                            $("#btneliminar").hide();
                    } 
                }
            });
        }

        /*Metodo para guardar Datos de la tabla*/
        function btnGuardar_Click() {

            if ($.trim($("#fecha").val()) == '' || $.trim($("#fecha").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#fecha").focus();
            } else if ($.trim($("#txttActividad").val()) == '' || $.trim($("#txttActividad").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#txttActividad").focus();
            } else if ($.trim($("#hInicio").val()) == '' || $.trim($("#hInicio").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#hInicio").focus();
            } else if ($.trim($("#hFin").val()) == '' || $.trim($("#hFin").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#hFin").focus();
            } else {
                var dataTabla = [];
                var i = 1;
                $("input:checkbox:checked").each(function () {
                    var data =  $(this).val();
                    dataTabla.push(data);
                    i++;
                });

                console.log(dataTabla);
                var estrategia = 4;
                var jsonData = "{'valFecha': '" + $("#fecha").val().toString() + "', 'valtActividad': '" + $("#txttActividad").val().toString() + "',  'valhInicio': '" + $("#hInicio").val().toString() + "', 'valhFin': '" + $("#hFin").val().toString() + "', 'estrategia':'" + estrategia.toString() + "'}";
                $.ajax({
                    url: 'estracincos004Coordasistencia.aspx/encabezado',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        var cod = response.d;
                        var mensaje;
                        for (var i = 0; i < dataTabla.length; i++) {
                            console.log(dataTabla[i]);
                            var jsonData = "{'codInasistencia': '" + cod.toString() + "', 'codEstudiante': '" + dataTabla[i].toString() + "'}";
                            $.ajax({
                                url: 'estracincos004Coordasistencia.aspx/matriculadosInasistente',
                                type: 'POST',
                                data: jsonData,
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'JSON',
                                success: function (response) {
                                    mensaje = response.d;
                                    console.log(mensaje);
                                }
                            });
                        }
                        if (mensaje == undefined) {
                            alert("Datos almacenados exitosamente");
                            cargarListado();
                        } else {
                            alert(mensaje);
                        }
                    },
                    complete: function () {
                        
                        $("#agregar").hide();
                        $("#list").fadeIn(500);
                    }
                });
            }
            
        }
        /*//////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
        function editarEstudiante(codigo, nombre, apellido, identificacion, sexo, fechanacimiento, telefono, direccion, email, codtipodocumento) {
            $("#fnacimientoEst").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'yy-mm-dd',
                yearRange: "1900:2025"
            });

            $("#tdocumento").val(codtipodocumento);
            $("#nombreEst").val(nombre);
            $("#apellidoEst").val(apellido);
            $("#identificacionEst").val(identificacion);
            $("#sexoEst").val(sexo);
            var fnacimiento = fechanacimiento.split(" ");
            $("#fnacimientoEst").val(fnacimiento[0]);
            $("#telefonoEst").val(telefono);
            $("#direccionEst").val(direccion);
            $("#emailEst").val(email);

            $("#dialog-form").dialog({
                modal: true,
                height: "auto",
                width: "auto",
                buttons: {
                    Guardar: function(){
                        updateEstudiante(codigo)
                    },
                    Cancelar: function () {
                        $("#dialog-form").dialog("close");
                    }
                }
            });
        }
        /*//////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
        function updateEstudiante(cod) {
            //alert(cod + " " + $("#tdocumento").val().toString() + "  " + $("#nombreEst").val().toString() + " " + $("#apellidoEst").val().toString() + " " + $("#identificacionEst").val() + " " + $("#sexoEst").val() + " " + $("#fnacimientoEst").val() + " " + $("#telefonoEst").val() + " " + $("#direccionEst").val() + " " + $("#emailEst").val());

            if ($.trim($("#nombreEst").val()) == '' || $.trim($("#nombreEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#nombreEst").focus();
            } else if ($.trim($("#apellidoEst").val()) == '' || $.trim($("#apellidoEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#apellidoEst").focus();
            } else if ($.trim($("#identificacionEst").val()) == '' || $.trim($("#identificacionEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#identificacionEst").focus();
            } else if ($.trim($("#fnacimientoEst").val()) == '' || $.trim($("#fnacimientoEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#fnacimientoEst").focus();
            } else if ($.trim($("#telefonoEst").val()) == '' || $.trim($("#telefonoEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#telefonoEst").focus();
            } else if ($.trim($("#direccionEst").val()) == '' || $.trim($("#direccionEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#direccionEst").focus();
            } else if ($.trim($("#emailEst").val()) == '' || $.trim($("#emailEst").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#emailEst").focus();
            } else {
                var jsonData = "{'codEstudiante':'" + cod.toString() + "','tdocumentoEstudiante':'" + $("#tdocumento").val().toString() + "','nombreEstudiante':'" + $("#nombreEst").val().toString() + "','apellidoEstudiante':'" + $("#apellidoEst").val().toString() + "','identificacionEstudiante':'" + $("#identificacionEst").val().toString() + "','sexoEstudiante':'" + $("#sexoEst").val().toString() + "','fnacimientoEstudiante':'" + $("#fnacimientoEst").val().toString() + "','telefonoEstudiante':'" + $("#telefonoEst").val().toString() + "','direccionEstudiante':'" + $("#direccionEst").val().toString() + "','emailEstudiante':'" + $("#emailEst").val().toString() + "'}";
                $.ajax({
                    url: 'estracincos004Coordasistencia.aspx/actualizarEstudiante',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        alert(response.d);
                        $("#dialog-form").dialog("close");
                        recargarTabla();
                    }
                });
            }
        }

        /*//////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
        function eliminarEstudiante(codigo) {
            $("#dialog-confirm").dialog({
                resizable: false,
                height: "auto",
                width: 400,
                modal: true,
                buttons: {
                    Eliminar: function () {
                        var data = "{'codEstudiante':'" + codigo + "'}";
                        $.ajax({
                            url: 'estracincos004Coordasistencia.aspx/eliminarEstudiante',
                            type: 'POST',
                            data: data,
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'JSON',
                            success: function (response) {
                                alert(response.d);
                                recargarTabla();
                            }
                        });
                        $(this).dialog("close");
                    },
                    Cancelar: function () {
                        $(this).dialog("close");
                    }
                }
            });
        }

        function recargarTabla() {
            var data = "{'codRedTematica':'" + $("#redtematica").val() + "', 'codSede':'" + $("#sedes").val() + "'}";
            $.ajax({
                url: 'estracincos004Coordasistencia.aspx/cargarEstudiantes',
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#contentTable").html(response.d);
                }
            });
        }

        function btnNuevo_click() {
            $('#agregar').fadeIn(500);
            $('#list').hide();
            cargarMatriculados();
            $('#btguardar').show();
        }

        function cargarListado() {

            $.ajax({
                url: 'estracincos004Coordasistencia.aspx/cargarListado',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("load@");
                    $("#infolist").html(resp[1]);
                    if (resp[0] === "20") {
                        $("#btnuevo").hide();
                        $("#btneliminar").hide();
                    }
                        
                }
            });

        }

        function cargarMatriculados() {
            $.ajax({
                type: 'POST',
                url: 'estracincos004Coordasistencia.aspx/cargarMatriculados',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    //console.log(json);
                    //loadEvidencias(codigo)
                    $("#contentTable").html(json.d);
                }
            });
        }

        function btnRegresar_Click() {
            $("#agregar").hide();
            $("#list").fadeIn(500);
            cargarListado();

        }

       
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
    <h2 >Estrategía Nro. 5 - G001: Registro de Asistencia</h2><br />

     <div id="agregar" style="display:none;">

          <fieldset>
        <legend>Formato control de asistencia</legend>
      <asp:Label ID="lblDatosInstitucion" runat="server" Visible="true"></asp:Label>

        <br />
       <!-- <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
            
            <tr>
                <td>Institucion educativa</td>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>Filtar</td>
                        </tr>
                        <tr>
                            <td><input type="text" class="TextBox" placeholder="Codigo DANE o Nombre" style="width: 200px;" /></td>
                        </tr>
                        <tr>
                            <td><select id="instituciones" class="TextBox"></select></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>Sede</td>
                <td><select id="sedes" class="TextBox"></select></td>
            </tr>
            <tr>
                <td>Red tematica</td>
                <td><select id="redtematica" class="TextBox"></select></td>
            </tr>
        </table>-->
        <br />
        <fieldset>
            <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC; width: 100%;">
            <tr>
                <td>Fecha</td>
                <td><input type="text" id="fecha" class="TextBox" required="required"/></td>
                <td>Actividad</td>
                <td><input type="text" id="txttActividad" class="TextBox" required="required"/></td>
            </tr>
            <tr>
                <td>Hora inicio</td>
                <td><input type="text" class="TextBox" id="hInicio" required="required" /></td>
                <td>Hora fin</td>
                <td><input type="text" class="TextBox" id="hFin" required="required" /></td>
            </tr>
        </table>
        </fieldset>
        <fieldset>
            <legend>Listado de asistencia</legend>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No.</th>
                        <th>Identificación</th>
                        <th>Nombre(s) y apellido(s)</th>
                        <th>Asistencia</th>
                    </tr>
                </thead>
                <tbody id="contentTable"></tbody>
            </table>
        </fieldset>
       <%-- <fieldset>
            <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
                <tr>
                    <td>Firma de maestro(a) tesorero(a)</td>
                    <td><input type="text" id="txtfirma" class="TextBox" /></td>
                </tr>
                <tr>
                    <td>Vo.bo. del asesor de línea de ciclón</td>
                    <td><input type="text" id="txtvobo" class="TextBox" /></td>
                </tr>
            </table>
        </fieldset>--%>
    </fieldset>
    <br />
    <center>
        <input id="btguardar" type="button" class="btn btn-success" value="Guardar" onclick="btnGuardar_Click();" />
        <input type="button" id="btnRegresar" class="btn btn-primary" value="Regresar" onclick="btnRegresar_Click();" />
        <%--<asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
        <asp:Button runat="server" ID="btnSubirFirmaPop" Text="Cargar Evidencias" CssClass="btn btn-danger" OnClick="cargarEvidencias_Click" />--%>
    </center>

     </div>

   
    <div id="dialog-form" style="display:none;" title="Editar informacíon del estudiante">
        <fieldset>
        <legend>Formulario Estudiante</legend>
        <table>
            <tr>
                <td>Tipo de documento</td>
                <td><select class="TextBox" id="tdocumento">
                    <option value="0" selected disabled>Seleccione tipo Documento</option>
                    <option value="1">Tarjeta identidad</option>
                    <option value="2">Registro civil</option>
                    <option value="3">Cédula de ciudadanía</option>
                    <option value="4">Cédula de extranjería</option>
                    <option value="5">Pasaporte</option>
                    </select></td>
                <td>Nombre</td>
                <td><input type="text" class="TextBox" id="nombreEst"/></td>
                <td>Apellido</td>
                <td><input type="text" class="TextBox" id="apellidoEst"/></td>
            </tr>
            <tr>
                <td>Identificacion</td>
                <td><input type="text" class="TextBox" id="identificacionEst"/></td>
                <td>Sexo</td>
                <td><select class="TextBox" id="sexoEst">
                    <option value="0" selected disabled>Seleccione Sexo</option>
                    <option value="F">Femenino</option>
                    <option value="M">Masculino</option>
                    </select></td>
                <td>Fecha nacimiento</td>
                <td><input type="text" class="TextBox" id="fnacimientoEst" /></td>
            </tr>
            <tr>
                <td>Telefono</td>
                <td><input type="text" class="TextBox" id="telefonoEst"/></td>
                <td>Direccion</td>
                <td><input type="text" class="TextBox" id="direccionEst" /></td>
                <td>Email</td>
                <td><input type="email" class="TextBox" id="emailEst" /></td>
            </tr>
        </table>
    </fieldset>
    </div>
    <div id="dialog-confirm" title="Eliminar estudiante de la red tematica" style="display:none;">
        <p><span class="ui-icon ui-icon-alert" style="float:left; margin:12px 12px 20px 0;"></span>Este estudiante se eliminara de forma permanente de la red tematica a la cual pertenece. ¿Está seguro de continuar?</p>
    </div>
    

     <div id="list">
        <div style="float:right"><a href="javascript:void(0)" id="btnuevo" class="btn btn-primary" onclick="btnNuevo_click()">Nuevo registro</a></div><br /><br />
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Actividad</th>
                    <th>Fecha</th>
                    <th>Hora inicio</th>
                    <th>Hora fin</th>
                     <th></th>
                </tr>
            </thead>
            <tbody id="infolist"></tbody>
        </table>

    </div>

</asp:Content>

