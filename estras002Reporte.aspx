<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras002reporte.aspx.cs" Inherits="estras002reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
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
	    var total = 5;
	    var total1 = 1;
	    var codestrategia = "";
	    $(function () {
	        cargarasesores();
	        listarInstrumentos002Regresar();
	        $("#listasesores").change(function () {
	            listarInstrumentos002($("#listasesores").val());
	        });

	        cargarAnio();
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

	        $("#fechavisita").datepicker({
	            dateFormat: 'yy-mm-dd'
	        });

	        $("input[type=datetime]").datepicker({
                dateFormat: 'yy-mm-dd'
	        });

	        

	        /*//////////////////////////////////////////////////////////////////////////////////////////////////////*/
	        $.ajax({
	            url: 'estras002reporte.aspx/cargarDepartamentoMagdalena',
	            type: 'POST',
	            contentType: "application/json; charset=utf-8",
	            dataType: 'JSON',
	            //data:frmserialize,
	            success: function (json) {
	                $("#departamento").html(json.d);


	            }
	        });

	        $("#departamento").on('change', function () {
	            var data = "{'coddepartamento': '" + $('#departamento').val() + "'}"
	            $.ajax({
	                url: 'estras002reporte.aspx/cargarMunicipios',
	                type: 'POST',
	                data: data,
	                contentType: 'application/json; charset=utf-8',
	                dataType: 'JSON',
	                success: function (response) {
	                    $("#municipio").html(response.d);

	                }

	            });
	        });


	        $("#municipio").on('change', function () {
	            var data = "{'codmunicipio': '" + $('#municipio').val() + "'}"
	            $.ajax({
	                url: 'estras002reporte.aspx/cargarInstituciones',
	                type: 'POST',
	                data: data,
	                contentType: 'application/json; charset=utf-8',
	                dataType: 'JSON',
	                success: function (response) {
	                    $("#instituciones").html(response.d);


	                }

	            });
	        });

	        $("#instituciones").on('change', function () {
	            var data = "{'codInstitucion': '" + $('#instituciones').val() + "'}"
	            $.ajax({
	                url: 'estras002reporte.aspx/cargarSedesInstitucion',
	                type: 'POST',
	                data: data,
	                contentType: 'application/json; charset=utf-8',
	                dataType: 'JSON',
	                success: function (response) {
	                    $("#sedes").html(response.d);


	                }

	            });
	        });

	        $("#sedes").on("change", function () {
	            var data = "{'codSede':'" + $("#sedes").val() + "'}";
	            $.ajax({
	                url: 'estras002reporte.aspx/cargarLineaInvestigacion',
	                type: 'POST',
	                data: data,
	                contentType: 'application/json; charset=utf-8',
	                dataType: 'JSON',
	                success: function (response) {
	                    $("#grupoInvestigacion").html(response.d);
	                }
	            });
	        });

	        $("#grupoInvestigacion").on("change", function () {
	            $.ajax({
	                url: 'estras002reporte.aspx/cargarAsesores',
	                type: 'POST',
	                contentType: 'application/json; charset=utf-8',
	                dataType: 'JSON',
	                success: function (response) {
	                    $("#asesores").html(response.d);
	                }
	            });
	        })
	    });

	    function addActividades() {
	        if ($.trim($("#actividad1").val()) != '' && $.trim($("#actividad2").val()) != '' && $.trim($("#actividad3").val()) != '' && $.trim($("#actividad4").val()) != '' && $.trim($("#actividad5").val()) != '') {
	            if (total > 5) {
	                //alert(total);
	                if ($.trim($("#actividad" + total).val()) == '') {
	                    alert("no es necesario agregar otro item, aún hay items vacios");
	                } else {
	                    total = total + 1;
	                    // alert(total);
	                    if ($("#remove")) {
	                        $("#remove").remove();
	                    }
	                    html = '<tr id="campus' + total + '">';
	                    html += '<td>' + total + '</td>';
	                    html += '<td id="radiotr' + total + '"><input type="text" id="actividad' + total + '" name="actividad' + total + '" class="TextBox actividades"><button id="remove" class="btn btn-danger" onclick="fRemove(' + total + ')">-</button></td></tr>';
	                    $("#tablecampus").append(html);
	                }
	            } else {
	                total = total + 1;
	                // alert(total);
	                if ($("#remove")) {
	                    $("#remove").remove();
	                }
	                html = '<tr id="campus' + total + '">';
	                html += '<td>' + total + '</td>';
	                html += '<td id="radiotr' + total + '"><input type="text" id="actividad' + total + '" name="actividad' + total + '" class="TextBox"><button class="btn btn-danger" id="remove" onclick="fRemove(' + total + ')">-</button></td></tr>';
	                $("#tablecampus").append(html);
	            }
	        }
	        else {
	            alert("no es necesario agregar otro item, aún hay items vacios");
	        }
	    }

	    function addCompromisos() {
	        if ($.trim($("#compromisos" + total1).val()) == '' || $.trim($("#compromisos" + total1).val()) == null) {
	            alert("Por favor, Ingrese compromisos");
	            $("#compromisos" + total1).focus();
	        } else if ($.trim($("#fechacumplimiento" + total1).val()) == '' || $.trim($("#fechacumplimiento" + total1).val()) == null) {
	            alert("Por favor, Ingrese fecha de cumplimiento");
	            $("#fechacumplimiento" + total1).focus();
	        } else if ($.trim($("#responsable" + total1).val()) == '' || $.trim($("#responsable" + total1).val()) == null) {
	            alert("Por favor, Ingrese responsable");
	            $("#responsable" + total1).focus();
	        } else {
	            $(".fechacumplimiento").datepicker({
	                dateFormat: 'yy-mm-dd'
	            });
	            total1 = total1 + 1;
	            // alert(total);
	            if ($("#remove1")) {
	                $("#remove1").remove();
	            }

	            html = '<tr id="oCampus' + total1 + '">';
	            html += '<td><input type="text" id="compromisos' + total1 + '" name="compromisos' + total1 + '" class="TextBox"></td>';
	            html += '<td><input type="datetime" id="fechacumplimiento' + total1 + '" name="fechacumplimiento' + total1 + '" class="TextBox" onfocus="fechaCumplimiento($(this).get(0).id)"></td>';
	            html += '<td id="oRadiotr' + total1 + '"><input type="text" id="responsable' + total1 + '" name="responsable' + total1 + '" class="TextBox"><button id="remove1" onclick="fRemove1(' + total1 + ')" class="btn btn-danger" >-</button></td></tr>';
	            $("#tablecampus1").append(html);

	            $("input[type=datetime]").datepicker({
                    dateFormat: 'yy-mm-dd'
	            })

	        }
	    }

	    function fRemove1(data) {
	        // alert(data);
	        var ant = data - 1;
	        total1 = total1 - 1;
	        $("#oCampus" + data).remove();
	        $("#oRadiotr" + ant).append('<button class="btn btn-danger" id="remove1" onclick="fRemove1(' + ant + ')">-</button>');
	    }

	    function fRemove(data) {
	        // alert(data);
	        var ant = data - 1;
	        total = total - 1;
	        $("#campus" + data).remove();
	        $("#radiotr" + ant).append('<button class="btn btn-danger" id="remove" onclick="fRemove(' + ant + ')">-</button>');
	    }

	    function fechaCumplimiento(id) {
	        $("#"+id).datepicker({
	            dateFormat: 'yy-mm-dd',
                showOnFocus: true
	        });
	    }

	    function btnGuardar_Click(event) {

	        var codchkdoc = "";
	        $("input:checkbox:checked").each(function () {
	            codchkdoc += "@" + $(this).val();
	        });

	        console.log(event);
	        var actividades = [];
	        var compromisos = [];
	        var num = 1;
	        var data = "";
	        $(".actividades").each(function () {
	            if (this.value != '') {
	                actividades.push(this.value);
	            }
	        });

	        $("#tablecampus1 tbody tr").each(function () {
	            //data = [$("input[id^='compromisos']").val(), $("input[id^='fechacumplimiento']").val(), $("input[id^='responsable']").val()];
	            data = [$("#compromisos" + num).val(), $("#fechacumplimiento" + num).val(), $("#responsable" + num).val()];
	            compromisos.push(data);
	            num++;
	        });

	        if (event == "insert")
	        {
	            if (codchkdoc.length == 0) {
	                alert("por favor seleccione los docentes para este registro");
	                return false;
	            } else {
	                var jsonData = "{'codProyecto':'" + $("#grupoInvestigacion").val().toString() + "', 'codAsesor':'" + $("#asesores").val().toString() + "',  'noAsesoria':'" + $("#noasesoria").val().toString() + "', 'fechaVisita':'" + $("#fechavisita").val().toString() + "', 'duracionHoras':'" + $("#duracionhoras").val().toString() + "', 'tipoAcompaniamiento':'" + $("input[name='tipoacompaniamiento']:checked").val().toString() + "', 'motivoAsesoria':'" + $("input[name='motivoasesoria']:checked").val().toString() + "', 'objetivo':'" + $("#objetivo").val().toString() + "' , 'noproyectadas':'" + $("#noproyectadas").val().toString() + "', 'noasistentes':'" + $("#noasistentes").val().toString() + "'}";
	                //var jsonData = "{'codProyecto':'" + $("#grupoInvestigacion").val().toString() + "', 'codAsesor':'" + $("#asesores").val().toString() + "', 'nomInvestigacion':'" + $("#nombreInvestigacion").val().toString() + "', 'noAsesoria':'" + $("#noasesoria").val().toString() + "', 'fechaVisita':'" + $("#fechavisita").val().toString() + "', 'duracionHoras':'" + $("#duracionhoras").val().toString() + "', 'tipoAcompaniamiento':'" + $("input[name='tipoacompaniamiento']:checked").val().toString() + "', 'motivoAsesoria':'" + $("input[name='motivoasesoria']:checked").val().toString() + "', 'objetivo':'" + $("#objetivo").val().toString() + "'}";
	                $.ajax({
	                    url: 'estras002reporte.aspx/encabezado',
	                    type: 'POST',
	                    data: jsonData,
	                    contentType: 'application/json; charset=utf-8',
	                    dataType: 'JSON',
	                    success: function (response) {
	                        /* Guardar docentes */

	                        guardarDocentes(response.d.toString(), codchkdoc);

	                        /*Recorrido actividades*/
	                        for (var i = 0; i < actividades.length; i++) {
	                            var jsonData = "{'codestras002reporte': '" + response.d.toString() + "', 'actividad': '" + actividades[i].toString() + "', 'noactividad':'" + (i + 1) + "'}";
	                            $.ajax({
	                                url: 'estras002reporte.aspx/actividades',
	                                type: 'POST',
	                                data: jsonData,
	                                contentType: 'application/json; charset=utf-8',
	                                dataType: 'JSON'
	                            });
	                        }
	                        /*Recorrido compromisos*/
	                        var x = 1;
	                        $.each(compromisos, function (index, element) {
	                            var jsonData = "{'codestras002reporte': '" + response.d.toString() + "', 'compromiso': '" + element[0].toString() + "', 'fechaCumplimiento': '" + element[1].toString() + "', 'responsable': '" + element[2].toString() + "', 'nocompromiso':'" + x + "'}";
	                            $.ajax({
	                                url: 'estras002reporte.aspx/compromisos',
	                                type: 'POST',
	                                data: jsonData,
	                                contentType: 'application/json; charset=utf-8',
	                                dataType: 'JSON'
	                            });
	                            x++;
	                        });
	                        alert("Datos almacenados exitosamente!");
	                        /*2016-10-25 07:55 pm*/
	                        listarInstrumentos002();
	                    }
	                });
	            }
	           
	        }
	        else if(event == "update")
	        {
	            var jsondata = "{'codestrategia':'" + codestrategia + "', 'noasesoria':'" + $("#noasesoria").val().toString() + "', 'noproyectadas': '" + $("#noproyectadas").val().toString() + "', 'fechavisita':'" + $("#fechavisita").val().toString() + "', 'duracionhoras':'" + $("#duracionhoras").val().toString() + "', 'tipoacompaniamiento':'" + $("input[name='tipoacompaniamiento']:checked").val().toString() + "', 'motivoasesoria':'" + $("input[name='motivoasesoria']:checked").val().toString() + "', 'objetivo':'" + $("#objetivo").val().toString() + "', 'noasistentes':'" + $("#noasistentes").val().toString() + "'}";
	            $.ajax({
	                url: 'estras002reporte.aspx/updates002',
	                type: 'POST',
	                data: jsondata,
	                contentType: 'application/json; charset=utf-8',
	                dataType: 'JSON',
	                success: function (response) {
	                    var resp = response.d.split("@");
	                    if (resp[0] == "true")
	                    {
	                        //Docentes
	                        actualizarMatriculaDocente(codestrategia, codchkdoc);

	                        //Delete actividades antiguas
	                        var jsondata = "{'codinstrumento':'"+codestrategia+"'}";
	                        $.ajax({
	                            type: 'POST',
	                            url: 'estras002reporte.aspx/deleteactividadess002',
	                            data: jsondata,
	                            contentType: 'application/json; charset=utf-8',
	                            dataType: 'JSON',
	                            success: function (response) {
	                                var resp = response.d.split("@");
	                                if(resp[0] == "true")
	                                {
	                                    for(var i = 0; i < actividades.length; i++)
	                                    {
	                                        var jsondata = "{'codestras002reporte':'" + codestrategia + "', 'actividad':'" + actividades[i].toString() + "', 'noactividad':'" + (i + 1) + "'}";
	                                        $.ajax({
	                                            url: 'estras002reporte.aspx/actividades',
	                                            type: 'POST',
	                                            data: jsondata,
	                                            contentType: 'application/json; charset=utf-8',
	                                            dataType: 'JSON'
	                                        });
	                                    }
	                                }
	                            } 
	                        });

	                        //Delete compromisos antiguas
	                        
	                        var jsondata = "{'codinstrumento':'" + codestrategia + "'}";
	                        $.ajax({
	                            type: 'POST',
	                            url: 'estras002reporte.aspx/deletecompromisoss002',
	                            data: jsondata,
	                            contentType: 'application/json; charset=utf-8',
	                            dataType: 'JSON',
	                            success: function (response) {
	                                var resp = response.d.split("@");
	                                if (resp[0] == "true")
	                                {
	                                    var x = 1;
	                                    $.each(compromisos, function (index, element) {
	                                        var jsonData = "{'codestras002reporte': '" + codestrategia + "', 'compromiso': '" + element[0].toString() + "', 'fechaCumplimiento': '" + element[1].toString() + "', 'responsable': '" + element[2].toString() + "', 'nocompromiso':'" + x + "'}";

	                                        $.ajax({
	                                            url: 'estras002reporte.aspx/compromisos',
	                                            type: 'POST',
	                                            data: jsonData,
	                                            contentType: 'application/json; charset=utf-8',
	                                            dataType: 'JSON'
	                                        });
	                                        x++;
	                                    });
	                                }
	                            }
	                        });
	                    }
	                },
	                complete: function () {
	                    alert("datos almacenados exitosamente");
	                    listarInstrumentos002();
	                }
	            });
	        }
	    }

	    function guardarDocentes(codestras002reporte, codgradodocente) {
	        var jsonData = '{ "codestras002reporte": "' + codestras002reporte + '", "codgradodocente": "' + codgradodocente + '"}';
	        $.ajax({
	            type: 'POST',
	            url: 'estras002reporte.aspx/matricularDocentes',
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


	</script>
    <!--2016-10-25 04:52 pm Jonny Pacheco -->
    <script>

        function listarInstrumentos002(asesor) {
            total = 5;
            total1 = 1;
            $("#form").hide();
         
            $("#table").fadeIn(500);

            $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'codasesorcoordinador':'" + asesor + "'}";

            $.ajax({
                type: 'POST',
                url: 'estras002reporte.aspx/listarInstrumentos002',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function listarInstrumentos002Regresar() {
            total = 5;
            total1 = 1;
            $("#form").hide();

            $("#table").fadeIn(500);

            $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")

            $.ajax({
                type: 'POST',
                url: 'estras002reporte.aspx/listarInstrumentos002Regresar',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function cargarasesores() {

            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: 'estras002reporte.aspx/cargarlistasesores',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    if (response.d != null) {
                        $("#listasesores").html(response.d);
                    }
                }
            });
        }



        function nuevaasesoria() {
            $("#table").hide();
            $("#evidencias").hide();
            $("#form").fadeIn(500);
            $.ajax({
                url: 'estras002reporte.aspx/cargarDepartamentoMagdalena',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'JSON',
                //data:frmserialize,
                success: function (json) {
                    $("#departamento").html(json.d);


                }
            });
            $("#municipio").html("<option value=''></option>");
            $("#instituciones").html("<option value=''></option>");
            $("#sedes").html("<option value=''></option>");
            $("#asesores").html("<option value=''></option>");
            $("#grupoInvestigacion").html("<option value=''></option>");
            $("#noasesoria").val("");
            $("#noproyectadas").val("");
            $("#fechavisita").val("");
            $("#duracionhoras").val("");
            $('input[name="tipoacompaniamiento"]').prop('checked', false);
            $('input[name="motivoasesoria"]').prop('checked', false);
            $("#objetivo").val("");
            /*actividades*/
            $("#actividad1").val("");
            $("#actividad2").val("");
            $("#actividad3").val("");
            $("#actividad4").val("");
            $("#actividad5").val("");
            $("#noasistentes").val("");
            /*reset tabla actividades*/
            var n = $("#tableactividades tbody tr").length

            for (i = 1; i <=n; i++) {
                if (i > 5) {
                    $("#campus"+i).remove();
                }
            }
            /*reset tabla compromisos*/
            var m = $("#tablecampus1 tbody tr").length

            for (i = 1; i <= m; i++) {
                if (i > 1) {
                    $("#oCampus" + i).remove();
                }
            }
           

            $("#compromisos1").val(""); 
            $("#fechacumplimiento1").val("");
            $("#responsable1").val("");

            $("#btn-guardar").attr('value', 'Guardar todo');
            $("#btn-guardar").attr('onclick', 'btnGuardar_Click(\'insert\')');
            
        }
        function btnRegresar() {
            $("#form").hide();
            $("#table").fadeIn(500);
            $("#evidencias").hide();
            total = 5;
            total1= 1;
        }
        /*Editar 2016-10-25 09 pm */
        function loadSelectInstrumentos002(codProyecto) {
            var jsondata = "{'codProyecto':'" + codProyecto + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras002reporte.aspx/loadSelectInstrumentos002',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "loadSelect") {
                        $("#departamento").html(resp[1]);
                        $("#municipio").html(resp[2]);
                        $("#instituciones").html(resp[3]);
                        $("#sedes").html(resp[4]);
                        $("#grupoInvestigacion").html(resp[5]);
                        $("#asesores").html(resp[6]);
                    }
                }
            });
        }
        /* 2016-10-26 12:08 pm  */
        function cargarInstrumentos002(codigo) {
            codestrategia = codigo;
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras002reporte.aspx/cargarInstrumentos002',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "load") {
                        $("#codigo").val(resp[4]);

                        $("#noasesoria").val(resp[1]);
                        $("#noproyectadas").val(resp[2]);
                        $("#fechavisita").val(resp[3]);
                        $("#duracionhoras").val(resp[4]);
                        
                        $('input:radio[name=tipoacompaniamiento]').each(function () {
                           
                            if ($(this).attr("value") == resp[5]) {
                                $(this).prop('checked', true);
                            }
                        });
                        $('input:radio[name=motivoasesoria]').each(function () {

                            if ($(this).attr("value") == resp[6]) {
                                $(this).prop('checked', true);
                            }
                        });

                        $("#objetivo").val(resp[7]);
                        $("#noasistentes").val(resp[8]);

                        cargarDocentesMatriculados(codigo, resp[9], resp[10]);
                    }
                }
            });

            $("#btn-guardar").attr('value', 'Actualizar');
            $("#btn-guardar").attr('onclick', 'btnGuardar_Click(\'update\')');
        }

        function cargarDocentesMatriculados(codestra2instrumento_s002, codanio, codsede) {
            var jsonData = '{ "codestra2instrumento_s002":"' + codestra2instrumento_s002 + '", "codsede":"' + codsede + '", "codanio":"' + codanio + '"}';
            $.ajax({
                type: 'POST',
                url: 'estras002reporte.aspx/listardocentesmatriculados',
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
                    }

                }
            });
        }

        /*2016-10-27 10:49 am */
        function listaractividadess002(codigo) {
            total = 5;
            var jsondata = "{'codigo':'" + codigo + "'}";

            $.ajax({
                type: 'POST',
                url: 'estras002reporte.aspx/listaractividadess002',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "load") {
                        /* calculo tamaño de las filas del arraglo el ultimo y el primero  es vacio*/
                        n = resp.length - 2;
                        /*calculo tamaño de las filas tabla*/
                        m = $("#tableactividades tbody tr").length;
                        /*reset tabla tableactividades*/
                        for (h = 1; h <= m; h++) {
                            if (h > 5) {
                                $("#campus" + h).remove();
                            }
                        }

                        /* iterador */
                        i = 1;
                        /* recorro la tabla con los 5 primeros*/
                        $("#tableactividades tbody tr").each(function () {
                            $("#actividad" + i).val(resp[i]);
                            i++;
                        });

                        if (n > 5) {
                            /*m-2 para que no tome el  ultimo  que es vacìo*/
                            for (j = 6; j <= n; j++) {
                                html = '<tr id="campus' + j + '">';
                                html += '<td>' + j + '</td>';
                                html += '<td id="radiotr' + j + '"><input type="text" id="actividad' + j + '" name="actividad' + j + '"  class="TextBox actividades"><button id="remove" class="btn btn-danger" onclick="fRemove(' + j + ')">-</button></td></tr>';
                                $("#tablecampus").append(html);
                                $("#actividad" + j).val(resp[j]);
                                total++;
                            }
                        }
                    }

                }
            });
        }

            /*2016-10-27 10:49 am */
        function listarcompromisoss002(codigo) {
            total1 = 1;
            var jsondata = "{'codigo':'" + codigo + "'}";
            
                $.ajax({
                    type: 'POST',
                    url: 'estras002reporte.aspx/listarcompromisoss002',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var row = response.d.split("@");
                        if (row[0] === "load") {
                            /*calculo tamaño de las filas tabla*/
                            m = $("#tablecampus1 tbody tr").length;
                            /*reset tabla */
                            for (h = 2; h <= m; h++) {
                                if (h > 1) {
                                    $("#oCampus" + h).remove();
                                }
                            }
                            colu = row[1].split("|");
                            $("#compromisos1").val(colu[0]);
                            $("#fechacumplimiento1").val(colu[1]);
                            $("#responsable1").val(colu[2]);

                            n = row.length - 2;
                            if (n > 1) {
                                /*m-2 para que no tome el  ultimo  que es vacìo*/
                                for (j = 2; j <= n; j++) {
                                   
                                    col=row[j].split("|");
                                    html = '<tr id="oCampus' + j + '">';
                                    html += '<td><input id="compromisos' + j + '" name="compromisos' + j + '" class="TextBox" type="text" value="'+col[0]+'"></td>';
                                    html += '<td><input id="fechacumplimiento' + j + '" name="fechacumplimiento' + j + '" class="TextBox" type="text" value="'+col[1]+'" onfocus="fechaCumplimiento($(this).get(0).id)" ></td>';
                                    html += '<td><input id="responsable' + j + '"  name="responsable' + j + '" class="TextBox" type="text"  value="' + col[2] + '"><button id="remove1" class="btn btn-danger" onclick="fRemove1(' + j + ')">-</button></td>';
                                    html += '</tr>';
                                    $("#tablecampus1").append(html);
                                    total1++;
                                }
                            }
                        }
                    }
                });
            }

        /* 2016-10-28 3:49 pm */
            function btnActualizar() {
                var actividades = [];
                var compromisos = [];
                var num = 1;
                var data = "";
                $(".actividades").each(function () {
                    if (this.value != '') {
                        actividades.push(this.value);
                    }
                });

                $("#tablecampus1 tbody tr").each(function () {
                    //data = [$("input[id^='compromisos']").val(), $("input[id^='fechacumplimiento']").val(), $("input[id^='responsable']").val()];
                    data = [$("#compromisos" + num).val(), $("#fechacumplimiento" + num).val(), $("#responsable" + num).val()];
                    compromisos.push(data);
                    num++;
                });

                var jsonData = "{'codProyecto':'" + codestrategia + "', 'codAsesor':'" + $("#asesores").val().toString() + "',  'noAsesoria':'" + $("#noasesoria").val().toString() + "', 'fechaVisita':'" + $("#fechavisita").val().toString() + "', 'duracionHoras':'" + $("#duracionhoras").val().toString() + "', 'tipoAcompaniamiento':'" + $("input[name='tipoacompaniamiento']:checked").val().toString() + "', 'motivoAsesoria':'" + $("input[name='motivoasesoria']:checked").val().toString() + "', 'objetivo':'" + $("#objetivo").val().toString() + "' , 'noproyectadas':'" + $("#noproyectadas").val().toString() + "'}";
               
                $.ajax({
                    url: 'estras002reporte.aspx/actualizarEncabezados002',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {

                      
                        /*Recorrido actividades
                        for (var i = 0; i < actividades.length; i++) {
                            var jsonData = "{'codestras002reporte': '" + response.d.toString() + "', 'actividad': '" + actividades[i].toString() + "'}";
                            $.ajax({
                                url: 'estras002reporte.aspx/actividades',
                                type: 'POST',
                                data: jsonData,
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'JSON'
                            });
                        }*/
                        /*Recorrido compromisos
                        $.each(compromisos, function (index, element) {
                            var jsonData = "{'codestras002reporte': '" + response.d.toString() + "', 'compromiso': '" + element[0].toString() + "', 'fechaCumplimiento': '" + element[1].toString() + "', 'responsable': '" + element[2].toString() + "'}";
                            $.ajax({
                                url: 'estras002reporte.aspx/compromisos',
                                type: 'POST',
                                data: jsonData,
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'JSON'
                            });
                        });*/
                        alert("Datos almacenados exitosamente!");
                        /*2016-10-25 07:55 pm*/
                        listarInstrumentos002();
                    }
                });


            }

            function actualizarMatriculaDocente(codinstrumento, codchkdoc) {

                var jsonData = '{ "codinstrumento":"' + codinstrumento + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras002reporte.aspx/deletematriculaDocente',
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        var resp = data.d.split("@");
                        if (resp[0] === "true") {

                            guardarDocentes(codinstrumento, codchkdoc);

                        }
                        else {
                            alert("error al matricular docentes, ya existe(n) en la base de datos");
                        }
                    }
                });
            }
            

        
            function evidencias(codigo) {
                $("#table").hide();
                $("#evidencias").fadeIn(500);
                $("#form").hide();
                var jsonData = "{'codigo':'" + codigo + "'}";
                $.ajax({
                    url: 'estras002reporte.aspx/evidencias',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON'
                  
                });
            }

            function cargarAnio() {
                $.ajax({
                    type: 'POST',
                    url: 'estras002reporte.aspx/cargaranios',
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

            function btncargardoc() {
                var jsonData = '{ "codsede": "' + $("#sedes").val() + '", "codanio": "' + $("#anio").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras002reporte.aspx/cargarDocentes',
                    contentType: "application/json; charset=utf-8",
                    data: jsonData,
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "datos") {
                            $("#listData").html(resp[1]);
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

     <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
        <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            cargarDataTable();
        });

        function cargarDataTable() {
            $('#GridEvidencias').DataTable({
                "language": {
                    "url": "dataTables.spanish.lang",
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "NingÃºn dato disponible en esta tabla",
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
                        "sLast": "Ãšltimo",
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

        function deleteInstrumentos002(codigoestrategia) {
            if (confirm('¿Estás seguro de eliminar este Registro? Recuerde que perderá toda las evidencias cargadas')) {
                var jsonData = "{ 'codigoestrategia':'" + codigoestrategia + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estras002reporte.aspx/deleteestras002reporte',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            listarInstrumentos002();
                            alert('Dato eliminado correctamente.');
                            //var jsonData = "{ 'codigoestrategia':'" + codigo + "'}";
                            //$.ajax({
                            //    type: 'POST',
                            //    url: 'estras004.aspx/deletedetalle',
                            //    data: jsonData,
                            //    contentType: "application/json; charset=utf-8",
                            //    dataType: "json",
                            //    success: function (data) {
                            //        cargarListadoMemorias("1");
                            //        alert('Dato eliminado correctamente.');

                            //    }
                            //});

                        }
                    }
                });
            }

        }
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Estrategia Nro. <asp:label runat="server" ID="lblEstrategia" Visible="true"></asp:label> - S002: Registro de la asesoría</h2>

      <div id="table">
     <table>
            <tr>
                <td>Asesor:</td>
                <td><select id="listasesores" class="TextBox"><option>Seleccione asesor...</option></select></td>
            </tr>
          </table>

     <fieldset >
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede</th>
                    <th>Grupo<br/>Investigación</th>
                    <th>No<br/>Asistentes</th>
                    <th>Fecha<br/>Visita</th>
                    <th>Nombre<br/>Asesor</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
</div>



     <asp:label runat="server" ID="lblMomento" Visible="false"></asp:label>
    <asp:label runat="server" ID="lblSesion" Visible="false"></asp:label>
    <asp:label runat="server" ID="lblActividad" Visible="false"></asp:label>

<div id="form" style="display:none;">
  <fieldset>
        <legend>Datos institución</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
		    <tr>
              
                <td colspan="3">
                     <table>
                         <tr> <td><input type="hidden" class="TextBox" id="codido" /></td></tr>
                        <tr>
                             <td>Departamento</td>
                            <td><select id="departamento" class="TextBox"></select></td>
                        </tr>
                        <tr>
                            <td>Municipio</td>
                            <td><select id="municipio" class="TextBox"></select></td>
                        </tr>
                        <tr>
                            <td>Institución</td>
                            <td><select id="instituciones" class="TextBox"></select></td>
                        </tr>
                        <tr>
                        <td>Sede</td>
                        <td><select id="sedes" class="TextBox"></select></td>
                    </tr>
                    <tr>
                        <td>Grupo de investigación<asp:label ID="lblTipoGrupo" runat="server" Visible="false"></asp:label></td>
                         <td><select id="grupoInvestigacion" class="TextBox"></select></td>
                    </tr>
                          <tr>
                        <td>Nombre del (la) asesor(a) </td>
                       
                        <td><select id="asesores" class="TextBox"></select></td>
            </tr>
                    </table>
                </td>
            </tr>
           
   
	    </table>
  </fieldset>
<br/>
		<fieldset >
            <table>
                <tr>
                    <td>Asesoría No.</td>
                    <td style="padding-left:32px;"><input type="number" min="0" id="noasesoria" class="TextBox"  style="width: 12%;"/> De <input type="number" min="0" id="noproyectadas" name="noproyectadas" style="width:12%;" class="TextBox"/> proyectadas</td>
                    <%--<td><input type="number" min="0" id="noasesoria" style="width:10%;" class="TextBox"/> de <input type="number" min="0" id="noproyectadas" name="noproyectadas" style="width:10%;" class="TextBox"/> proyectadas </td>--%>
		    	</tr>
            </table>
            <table>
                <tr>
                    <td>No de asistentes</td>
                    <td style="padding-left:10px;"><input type="text" id="noasistentes" class="TextBox" onkeypress="return valideKey(event);" style="width: 20%;"/></td>
                </tr>
            </table>
		    <table>
                <tr>
                    <td>Fecha de la visita</td>
                    <td><input type="text" id="fechavisita" name="fechavisita" class="TextBox"/></td>
                </tr>
                <%--<tr>
                    <td>Nombre del grupo: </td>
		    		<td><input type="text" id="nombregrupo" name="nombregrupo" class="TextBox" /></td>
                </tr>--%>
                <tr>
                    <td>Duración / horas: </td>
		    		<td><input type="number" min="0" id="duracionhoras" name="duracionhoras" class="TextBox" /></td>
                </tr>
		    </table>
		</fieldset>
<br/>
    <fieldset >
		    <legend>Tipo de Acompañamiento </legend>
            <table>
                <%--<tr>
                    <td>Presencial</td>
                    <td><input type="radio" name="tipoacompaniamiento" value="presencial" /></td>
                </tr>
                <tr>
                    <td>Virtual</td>
                    <td><input type="radio" name="tipoacompaniamiento" value="virtual" /></td>
                </tr>--%>
                <tr>
		    		<td colspan="2">
		    			<table cellspacing="10">
		    				<tr>
		    					<td>Presencial <input type="radio"  name="tipoacompaniamiento" value="presencial"/></td>
		    					<td>Virtual <input type="radio"  name="tipoacompaniamiento" value="virtual"/></td>
		    				</tr>
		    			</table>
		    		</td>
		    	</tr>
                <%--<tr>
                    <td>Lugar de la asesoría: </td>
		    	    <td><input type="text" id="lugarasesoria" name="lugarasesoria" class="TextBox" /></td>
                </tr>--%>
                <tr>
		    		<td colspan="2">
		    			<table cellspacing="10">
		    				<tr>
		    					<td >Asesoría de línea <input type="radio" name="motivoasesoria" value="asesoria de linea"/></td>
		    					<td >Sesión de formación <input type="radio" name="motivoasesoria" value="sesion de formacion"/></td>
		    					<td >Acompañamiento <input type="radio" name="motivoasesoria" value="acompañamiento"/></td>
		    					<td >Seguimiento <input type="radio" name="motivoasesoria" value="seguimiento"/></td>
		    				</tr>
		    			</table>
		    		</td>
		    	</tr>
            </table>
		</fieldset>
    <br />
    <fieldset >
        <p><strong>Objetivo de la sesión de asesoría, acompañamiento y / o formación</strong></p>
		<textarea name="objetivo" id="objetivo" cols="30" rows="10" style="width:100%; max-width:100%; min-width:100%;"></textarea>
	</fieldset>
    <br />

    <fieldset>
        <legend>Actividades desarrolladas</legend>
			<%--<p><strong>Actividades desarrolladas</strong></p>--%>
            <table id="tableactividades"  class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No.</th>
                        <th>Titulo</th>
                    </tr>
                </thead>
                <tbody id="tablecampus">
                <tr>
		    		<td>1</td>
		    		<td><input type="text" id="actividad1" name="actividad1" class="TextBox actividades"/></td>
		    	</tr>
		    	<tr>
		    		<td>2</td>
		    		<td><input type="text" id="actividad2" name="actividad2" class="TextBox actividades"/></td>
		    	</tr>
				<tr>
		    		<td>3</td>
		    		<td><input type="text" id="actividad3" name="actividad3" class="TextBox actividades"/></td>
		    	</tr>
		    	<tr>
		    		<td>4</td>
		    		<td><input type="text" id="actividad4" name="actividad4" class="TextBox actividades"/></td>
		    	</tr>
		    	<tr>
		    		<td>5</td>
		    		<td><input type="text" id="actividad5" name="actividad5" class="TextBox actividades"/></td>
		    	</tr>
                </tbody>
            </table>
           <%-- <table>
		    	<tr>
					<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="addActividades();" /></td>
		    	</tr>
		    </table>--%>
	</fieldset>
	<fieldset >
		    <legend>Rellene la información</legend>
            <table id="tablecampus1" class="mGridTesoreria">
            <thead>
                <tr>
		    		<th>Compromisos</th>
		    		<th>Fecha de cumplimiento</th>
		    		<th>Responsable </th>
		    	</tr>
            </thead>
		    	<tbody>
                    <tr>
		    		<td><input type="text" id="compromisos1" name="compromisos1" class="TextBox"/></td>
		    		<td><input type="datetime" id="fechacumplimiento1" name="fechacumplimiento1" class="TextBox" onfocus="fechaCumplimiento($(this).attr('id'))"/></td>
		    		<td>
		    			<input type="text" id="responsable1" name="responsable1" class="TextBox"/>
	  				</td>
		    	</tr>
		    	</tbody>
		    </table>
           <%-- <table>
                <tr>
					<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="addCompromisos();" /></td>
		    	</tr>
            </table>--%>
		</fieldset>
	<br />
		  <fieldset>
            <legend>Lista de docentes</legend>
            <center>
                <table>
                    <tr>
                        <td colspan="2">Antes realizar la carga de los docentes, por favor seleccione la sede y el año</td>
                    </tr>
                 <tr>
                     <td align="right">
                        Año:  <select class="TextBox" id="anio"></select>
                     </td>
                     <td >
                         <a id="btncargardoc" href="javascript:void(0)" class="btn btn-success" onclick="btncargardoc()">Cargar docentes</a>
                     </td>
                 </tr>
            </table>
            
           <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Identificacion</th>
                    <th>Nombre</th>
                    <%--<th></th>--%>
                </tr>
            </thead>
            <tbody id="listData">
            </tbody>
        </table>
            
        </center>
        </fieldset>
    <br />
	<center>
         <a href="#" onclick="btnRegresar();" class="btn btn-primary">Regresar</a>
    </center>
</div>


</asp:Content>

