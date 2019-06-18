<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunoevalasesoria.aspx.cs" Inherits="estraunoevalasesoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
    <style>
       .primeracolumna{
            text-align:right;
            font-weight:bold;
        }
    
        .auto-style1 {
            color: #FF0000;
        }
    </style>

     <script type="text/javascript">
         $(function () {
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

             $("#fechaeval").datepicker({
                 dateFormat: 'yy-mm-dd'
             });

             /*//////////////////////////////////////////////////////////////////////////////////////////////////////*/
             //$.ajax({
             //    url: 'estraunoevalasesoria.aspx/cargarInstituciones',
             //    type: 'POST',
             //    contentType: 'application/json; charset=utf-8',
             //    dataType: 'JSON',
             //    success: function (response) {
             //        $("#instituciones").html(response.d);
             //    }
             //});

             /*//////////////////////////////////////////////////////////////////////////////////////////////////////*/
             //$("#instituciones").on('change', function () {
             //    var data = "{'codInstitucion': '" + $('#instituciones').val() + "'}"
             //    $.ajax({
             //        url: 'estraunoevalasesoria.aspx/cargarSedesInstitucion',
             //        type: 'POST',
             //        data: data,
             //        contentType: 'application/json; charset=utf-8',
             //        dataType: 'JSON',
             //        success: function (response) {
             //            $("#sedes").html(response.d);
             //        }
             //    });
             //});

             /*//////////////////////////////////////////////////////////////////////////////////////////////////////*/
             //$("#sedes").on("change", function () {
             //    var data = "{'codSede':'" + $("#sedes").val() + "'}";
             //    $.ajax({
             //        url: 'estraunoevalasesoria.aspx/cargarLineaInvestigacion',
             //        type: 'POST',
             //        data: data,
             //        contentType: 'application/json; charset=utf-8',
             //        dataType: 'JSON',
             //        success: function (response) {
             //            $("#grupoInvestigacion").html(response.d);
             //        }
             //    });
             //});

                 $.ajax({
                     url: 'estraunoevalasesoria.aspx/cargaGrupoInvestigacion',
                     type: 'POST',
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#grupoInvestigacion").html(response.d);
                     }
                 });

             $("#grupoInvestigacion").on("change", function () {
                 $.ajax({
                     url: 'estraunoevalasesoria.aspx/cargarAsesores',
                     type: 'POST',
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#asesor").html(response.d);
                     }
                 });
             })

             $("#asesor").on("change", function () {
                 $.ajax({
                     url: 'estraunoevalasesoria.aspx/cargarEntidadPromotora',
                     type: 'POST',
                     data: "{'codAsesorCoordinador':'" + $("#asesor").val().toString() + "'}",
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#nomEntidad").html(response.d);
                     }
                 });
             });
         });
         function buscar() {
             //alert("Si este es");
             jQuery.fn.filterByText = function (textbox, selectSingleMatch) {
                 return this.each(function () {
                     var select = this;
                     var options = [];
                     $(select).find('option').each(function () {
                         options.push({ value: $(this).val(), text: $(this).text() });
                     });
                     $(select).data('options', options);
                     $(textbox).bind('change keyup', function () {
                         var options = $(select).empty().data('options');
                         var search = $(this).val().trim();
                         var regex = new RegExp(search, "gi");

                         $.each(options, function (i) {
                             var option = options[i];
                             if (option.text.match(regex) !== null) {
                                 $(select).append(
                                    $('<option>').text(option.text).val(option.value)
                                 );
                             }
                         });
                         if (selectSingleMatch === true && $(select).children().length === 1) {
                             $(select).children().get(0).selected = true;
                         }
                     });
                 });
             };

             $(function () {
                 $('#dropInstitucion').filterByText($('#textbox'), false);
                 $("#dropInstitucion option").click(function () {
                     alert(1);
                 });
             });

             $(function () {
                 $('#dropDocente').filterByText($('#textboxDoc'), false);
                 $("#dropDocente option").click(function () {
                     alert(1);
                 });
             });
         }

         function btnGuardar_Click() {
             var codigo = 1;
             if ($.trim($("#asesor").val()) == '' || $.trim($("#asesor").val()) == null) {
                 alert("Por favor, rellene todos los campos");
                 $("#asesor").focus();
             } else if ($.trim($("#nomEntidad").val()) == '' || $.trim($("#nomEntidad").val()) == null) {
                 alert("Por favor, rellene todos los campos");
                 $("#nomEntidad").focus();
             } else if ($.trim($("#tema").val()) == '' || $.trim($("#tema").val()) == null) {
                 alert("Por favor, rellene todos los campos");
                 $("#tema").focus();
             } else if ($.trim($("#fechaeval").val()) == '' || $.trim($("#fechaeval").val()) == null) {
                 alert("Por favor, rellene todos los campos");
                 $("#fechaeval").focus();
             } else {
                 if ($("input[name='p1']").is(":checked") && $("input[name='p2.1']").is(":checked") && $("input[name='p2.2']").is(":checked") && $("input[name='p3.1']").is(":checked") && $("input[name='p3.2']").is(":checked") && $("input[name='p3.3']").is(":checked") && $("input[name='p3.4']").is(":checked") && $("input[name='p4.1']").is(":checked") && $("input[name='p4.2']").is(":checked") && $("input[name='p4.3']").is(":checked")) {
                     var jsonCalificacion = [
                         $("input[name='p1']:checked").val(),
                         $("input[name='p2.1']:checked").val(),
                         $("input[name='p2.2']:checked").val(),
                         $("input[name='p3.1']:checked").val(),
                         $("input[name='p3.2']:checked").val(),
                         $("input[name='p3.3']:checked").val(),
                         $("input[name='p3.4']:checked").val(),
                         $("input[name='p4.1']:checked").val(),
                         $("input[name='p4.2']:checked").val(),
                         $("input[name='p4.3']:checked").val(),
                     ];
                     var jsonInputData = "{'codGrupoInvestigacion': '" + $("#grupoInvestigacion").val().toString() + "', 'codAsesor': '" + $("#asesor").val().toString() + "', 'codEntidad': '" + $("#nomEntidad").val().toString() + "', 'tema': '" + $("#tema").val().toString() + "', 'fecha': '" + $("#fechaeval").val().toString() + "'}";
                     $.ajax({
                         url: 'estraunoevalasesoria.aspx/encabezado',
                         type: 'POST',
                         data: jsonInputData,
                         contentType: 'application/json; charset=utf-8',
                         dataType: 'JSON',
                         success: function (response) {
                             var codigo = response.d;
                             console.log(codigo);
                             for (var i = 0; i < jsonCalificacion.length; i++) {
                                 var codPregunta = i + 1;
                                 var jsonData = "{'codEstraEvalAsesoria': '" + codigo.toString() + "', 'codPregunta': '" + codPregunta.toString() + "', 'Calificacion': '" + jsonCalificacion[i].toString() + "'}";
                                 $.ajax({
                                     url: 'estraunoevalasesoria.aspx/respuestaPCerrada',
                                     type: 'POST',
                                     data: jsonData,
                                     contentType: 'application/json; charset=utf-8',
                                     dataType: 'JSON',
                                     success: function (response) {
                                         console.log(response.d);
                                     }
                                 });
                             }
                             $.ajax({
                                 url: 'estraunoevalasesoria.aspx/respuestaPAbierta',
                                 type: 'POST',
                                 data: "{'codEstraEvalAsesoria': '" + codigo.toString() + "', 'sugerencias':'" + $("#sugerencias").val().toString() + "'}",
                                 contentType: 'application/json; charset=utf-8',
                                 dataType: 'JSON',
                                 success: function (response) {
                                     console.log(response.d);
                                 }
                             });

                             alert("Evaluacion guardada exitosamente!");
                         }
                     });
                     
                 } else {
                     alert("Todas las preguntas deben ser contestadas, por favor verifique si le falto alguna por calificar.");
                 }
             }
             
             
         }
    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Estrategía Nro 1 - Evaluación Asesoría</h2><br />

     <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
        <tr>
            <td>Con el propósito de mejorar nuestras actividades, le solicitamos responder objetivamente los siguientes enunciados, seleccionando una opcion, la respuesta que usted considere adecuada, teniendo en cuenta que 5 es Excelente, 4 es bueno, 3 es regular, 2 es Deficiente y 1 muy Deficiente.</td>
        </tr>
    </table>
    <fieldset>
    <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
            <%--<tr>
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
            </tr>--%>
            <tr>
                <td>Grupo de investigación</td>
                <td><select id="grupoInvestigacion" class="TextBox"></select></td>
            </tr>
        </table>
    <fieldset>
        <legend>Informaci&oacute;n general</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    Nombre del asesor
                </td>
                <td>
                    <%--<input type="text" class="TextBox" id="asesor"/>--%>
                    <select id="asesor" class="TextBox"></select>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre de la entidad promotora
                </td>
                <td>
                    <%--<input type="text" class="TextBox" id="nomEntidad"/>--%>
                    <select id="nomEntidad" class="TextBox"></select>
                </td>
            </tr>
            <tr>
                <td>
                    Tema tratado
                </td>
                <td>
                    <input type="text" class="TextBox" id="tema"/>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha de evaluaci&oacute;n
                </td>
                <td>
                    <input type="text" class="TextBox" id="fechaeval"/>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Evaluación</legend>
        <table style="color:#333333;width:100%;border-collapse:collapse;" cellspacing="0">
            <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                <th style="font-weight:bold;">
                    1. OBJETIVOS DE LA ACTIVIDAD
                </th>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr style="background-color:#EFF3FB;">
                             <td style="width: 120%;">1.1 ¿Los objetivos de la actividad del asesor se presentaron de una manera adecuada?</td>
                            <td>
                                <table class="radio" >
                                    <tr>
                                        <td>
                                            <table >
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p1" value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p1"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p1"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p1"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p1"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                <th style="font-weight:bold;">
                    2. DESARROLLO DE LA ACTIVIDAD
                </th>
            </tr>
            <tr>
                <td>
                    <table >
                        <tr style="background-color:#EFF3FB;">
                            <td class="enunciado">
                                2.1 ¿Las actividades de participación desarrolladas por el asesor fueron adecuadas (trabajos en grupo, lecturas, casos dinámicas, otros)?
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.1"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.1"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.1"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.1"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.1"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color:White;">
                            <td>
                                2.2 ¿La metodología utilizada por el asesor fue clara?
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.2"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.2"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.2"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.2"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p2.2"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                <th style="font-weight:bold;">
                    3. CONTENIDO DE LA ASESORIA
                </th>
            </tr>
            <tr>
                <td>
                    <table border="0">
                        <tr style="background-color:#EFF3FB;">
                            <td>
                                3.1 ¿El tema y los conceptos tratados por el asesor fueron claros?           
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.1"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.1"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.1"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.1"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.1"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color:white;">
                            <td>
                                3.2 ¿Las ayudas didácticas fueron apropiadas (videos, video beam, otros)?
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.2"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.2"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.2"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.2"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.2"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color:#EFF3FB;">
                            <td>
                                3.3 El tema visto, ¿le sirve en el desarrollo del proyecto de investigación?                                                             
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.3"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.3"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.3"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.3"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.3"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color:white;">
                            <td class="enunciado">
                                3.4 ¿Los temas de la actividad resuelven sus necesidades de formación con respecto a las actividades que desarrollará dentro de la investigación a trabajar?
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.4"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.4"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.4"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.4"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p3.4"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color:White;background-color:#507CD1;font-weight:bold;">
                <td style="font-weight:bold;" align="center">
                    4. ASESOR
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" width="100%">
                         <tr style="background-color:#EFF3FB;">
                            <td style="width: 120%;">
                                4.1 ¿Demostró conocimiento y manejo de tema?          
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.1"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.1"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.1"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.1"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.1"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color:white;">
                            <td>
                                4.2 ¿Creó un ambiente agradable, respetuoso y abierto a inquietudes?
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.2"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.2"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.2"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.2"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.2"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                         <tr style="background-color:#EFF3FB;">
                            <td class="enunciado">
                                4.3 ¿Propició y logró la participación del grupo?                                                             
                            </td>
                            <td>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.3"  value="1"/>
                                                    </td>
                                                    <td>
                                                        <label>1</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.3"  value="2"/>
                                                    </td>
                                                    <td>
                                                        <label>2</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.3"  value="3"/>
                                                    </td>
                                                    <td>
                                                        <label>3</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.3"  value="4"/>
                                                    </td>
                                                    <td>
                                                        <label>4</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="radio" name="p4.3"  value="5"/>
                                                    </td>
                                                    <td>
                                                        <label>5</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight:bold;">
                    SUGERENCIAS
                </td>
            </tr>
            <tr>
                <td>
                    <textarea class="TextBox" cols="200" rows="5" style="width: 100%;" id="sugerencias"></textarea>
                </td>
            </tr>
        </table>
    </fieldset>
</fieldset>
    <br />
    <center>
        <input type="button" class="btn btn-success" value="Guardar" onclick="btnGuardar_Click();"/>
         <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
    </center>

</asp:Content>

