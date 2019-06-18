<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estrag001.aspx.cs" Inherits="estrag001" %>

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
       
        function loadSelectInstrumento() {
            $.ajax({
                type: 'POST',
                url: 'estras004Sedes.aspx/loadSelectInstrumento',
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

        $(function () {
            cargarlistado();
            cargaranios();
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


            $("#anios").on("change", function () {
                var data = "{'codanio':'" + $("#anios").val() + "'}";
                $.ajax({
                    url: 'estrag001.aspx/cargarDocentesxSede',
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    data: data,
                    success: function (response) {
                        $("#contentTable").html(response.d);
                        loadSelectInstrumento();
                    }
                });
            });

            /*//////////////////////////////////////////////////////////////////////////////////////////////////////
            $.ajax({
                url: 'estrag001.aspx/cargarDepartamento',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#departamento").html(response.d);
                }
            });


            $("#departamento").on("change", function () {
                var data = "{'codDepartamento':'" + $("#departamento").val() + "'}";
                $.ajax({
                    url: 'estrag001.aspx/cargarMunicipio',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#municipio").html(response.d);
                    }
                });
            })


            $("#municipio").on("change", function () {
                var data = "{'codMunicipio':'" + $("#municipio").val() + "'}";
                $.ajax({
                    url: 'estrag001.aspx/cargarInstitucionesxMunicipio',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#instituciones").html(response.d);
                    }
                });
            })*/
            /*//////////////////////////////////////////////////////////////////////////////////////////////////////
            $("#instituciones").on('change', function () {
                var data = "{'codInstitucion': '" + $('#instituciones').val() + "'}"
                $.ajax({
                    url: 'estrag001.aspx/cargarSedesInstitucion',
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
                    url: 'estrag001.aspx/cargarDocente',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#contentTable").html(response.d);
                        //$("#redTematica").html(response.d);
                    }
                });
            });*/

            //$("#sedes").on("change", function () {
            //    var data = "{'codSede':'" + $("#sedes").val() + "'}";
            //    $.ajax({
            //        url: 'estrag001.aspx/cargarDocentesxSede',
            //        type: 'POST',
            //        data: data,
            //        contentType: 'application/json; charset=utf-8',
            //        dataType: 'JSON',
            //        success: function (response) {
            //            //$("#contentTable").html(response.d);
            //            $("#redTematica").html(response.d);
            //        }
            //    });
            //});

            //$("#sedes").on("change", function () {
            //    var data = "{'codSede':'" + $("#sedes").val() + "'}";
            //    $.ajax({
            //        url: 'estrag001.aspx/cargarRedTematica',
            //        type: 'POST',
            //        data: data,
            //        contentType: 'application/json; charset=utf-8',
            //        dataType: 'JSON',
            //        success: function (response) {
            //            //$("#contentTable").html(response.d);
            //            $("#redTematica").html(response.d);
            //        }
            //    });
            //});

            //$("#redTematica").on("change", function () {
            //    var data = "{'codRedTematicaSede':'" + $("#redTematica").val() + "'}";
            //    $.ajax({
            //        url: 'estrag001.aspx/cargarDocente',
            //        type: 'POST',
            //        data: data,
            //        contentType: 'application/json; charset=utf-8',
            //        dataType: 'JSON',
            //        success: function (response) {
            //            $("#contentTable").html(response.d);
            //        }
            //    });
            //});

            //$("#grupoInvestigacion").on("change", function () {
            //    var data = "{'codGrupoInvestigacion':'" + $("#grupoInvestigacion").val() + "'}";
            //    $.ajax({
            //        url: 'estrag007.aspx/searchRubros',
            //        type: 'POST',
            //        data: data,
            //        contentType: 'application/json; charset=utf-8',
            //        dataType: 'JSON',
            //        success: function (response) {
            //            var data = response.d.split("-");
            //            $("#txtinsumo").val(data[0]);
            //            $("#txtpapeleria").val(data[1]);
            //            $("#txttransporte").val(data[2]);
            //            $("#txtmaterial").val(data[3]);
            //            $("#txtrefrigerio").val(data[4]);
            //            $("#txtotros").val(data[5]);
            //            calculateSum();
            //        }
            //    });
            //});
        });

        function cargarlistado() {
            $.ajax({
                url: 'estrag001.aspx/cargarListado',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#listasistencia").html(response.d);
                }
            });
        }

        function loadinstrumento(codigo) {
            var data = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag001.aspx/loadinstrumento',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: data,
                success: function (json) {
                    //console.log(json);
                    //loadEvidencias(codigo)
                    $("#contentTable").html(json.d);
                    $("#form").fadeIn(500);
                    $("#btguardar").hide();
                    $("#list").hide();
                    cargarEncabezado(codigo);
                }
            });
        }

        function cargarEncabezado(codigo) {
            var data = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag001.aspx/cargarEncabezado',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: data,
                success: function (json) {
                    $("#txttActividad").val(json.d);
                }
            });
        }

        function eliminar(codigo) {
            var data = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag001.aspx/eliminar',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: data,
                success: function (json) {
                    alert("Datos eliminados correctamente");
                    cargarlistado();
                }
            });
        }

        function cargaranios()
        {
         $.ajax({
                        url: 'estrag001.aspx/cargarAnios',
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'JSON',
                        success: function (response) {
                            $("#anios").html(response.d);
                            //cargarDocentesSedes($("#anios").val());
                        }
                    });
        }

        function cargarEncabezados() {
            $.ajax({
                type: 'POST',
                url: 'estrag001.aspx/cargarEncabezados',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    //console.log(json);
                    //loadEvidencias(codigo)
                    var resp = json.d.split("@");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];
                        $("#txttema").val(resp[2]);
                        $("#fecha").val(resp[3]);

                        $("#hInicio").val(resp[5]);
                        $("#hFin").val(resp[6]);
                        $("#txtfacilitador").val(resp[4]);

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
            } else if ($.trim($("#txttema").val()) == '' || $.trim($("#txttema").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#txttema").focus();
            } else if ($.trim($("#txtfacilitador").val()) == '' || $.trim($("#txtfacilitador").val()) == null) {
                alert("Por favor, rellene todos los campos");
                $("#txtfacilitador").focus();
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

                var jsonData = "{'valFecha': '" + $("#fecha").val().toString() + "', 'valtActividad': '" + $("#txttActividad").val().toString() + "', 'valTema': '" + $("#txttema").val().toString() + "', 'valFacilitador': '" + $("#txtfacilitador").val().toString() + "', 'valhInicio': '" + $("#hInicio").val().toString() + "', 'valhFin': '" + $("#hFin").val().toString() + "'}";
                $.ajax({
                    url: 'estrag001.aspx/encabezado',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        var cod = response.d;
                        var mensaje;
                        for (var i = 0; i < dataTabla.length; i++) {
                            console.log(dataTabla[i]);
                            var jsonData = "{'codInasistencia': '" + cod.toString() + "', 'codDocente': '" + dataTabla[i].toString() + "'}";
                            $.ajax({
                                url: 'estrag001.aspx/docenteInasistente',
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
                    },
                    complete: function () {
                        alert("Datos almacenados exitosamente");
                        cargarlistado();
                        $('#form').hide();
                        $('#list').fadeIn(500);
                    }
                });
            }
            
        }

        function btnNuevo_click() {
            $('#form').fadeIn(500);
            $('#list').hide();
        }

        function btnRegresarAsis_Click() {
            $('#form').hide();
            $('#list').fadeIn(500); 
        }

     
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
    <h2 >Estrategía Nro 2 - Instrumento G001: Formato de Asistencia Docentes</h2><br />

    <div id="form" style="display:none;">


         <fieldset>
        <legend>Formato control de asistencia</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
            <tr>
                <td><asp:Label ID="lblEncabezado" Visible="true" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Año: <select id="anios" class="TextBox"></select>
                </td>
                
            </tr>
         
        </table>
        <fieldset>
            <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC; width: 100%;">
            <tr>
                <td>Fecha</td>
                <td><input type="text" id="fecha" class="TextBox" required="required"/></td>
                <td>Tipo de actividad</td>
                <td><input type="text" id="txttActividad" class="TextBox" required="required"/></td>
            </tr>
            <tr>
                <td>Tema</td>
                <td><input type="text" id="txttema" class="TextBox" required="required" /></td>
                <td>Facilitador(es)</td>
                <td><input type="text" id="txtfacilitador" class="TextBox" required="required" /></td>
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
    </fieldset>
    <br />
    <center>
        <input type="button" class="btn btn-success" value="Guardar" onclick="btnGuardar_Click();" />
        <a href="#" class="btn btn-primary" onclick="btnRegresarAsis_Click()">Volver</a>
    </center>


    </div>

    <div id="list">
         <div style="float:right">
             <asp:LinkButton runat="server" ID="lnkRegresar" CssClass="btn btn-success" OnClick="btnRegresar_Click">Regresar</asp:LinkButton>
             <a href="#" id="btnuevo" class="btn btn-primary" onclick="btnNuevo_click()">Nuevo registro</a>
         </div>

       <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Tipo actividad</th>
                    <th>Tema</th>
                    <th>Facilitador</th>
                    <th>Fecha</th>
                    <th>Hora inicio</th>
                    <th>Hora fin</th>
                     <th></th>
                </tr>
            </thead>
           <tbody id="listasistencia"></tbody>
       </table>


    </div>

   
</asp:Content>

