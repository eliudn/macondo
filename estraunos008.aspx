<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunos008.aspx.cs" Inherits="estraunos008" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
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
            //cargarinstituciones();
            reset();

            $("#departamento").change(function () {
                reset();
                var jsonData = '{ "departamento":"' + $("#departamento").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estraunos008.aspx/cargarMunicipios',
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
                    url: 'estraunos008.aspx/cargarInstituciones',
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
                    url: 'estraunos008.aspx/cargarsedes',
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
                    url: 'estraunos008.aspx/grupoInvestigacion',
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

            //$("#grupoinvestigacion").change(function () {
            //    cargarInstrumento_b03($('#grupoinvestigacion').val());
            //});

            $("input[type='date']").datepicker();

        });

       
        function cargarDepartamentoMagdalena() {
            $.ajax({
                type: 'POST',
                url: 'estraunos008.aspx/cargarDepartamentoMagdalena',
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
                url: 'estraunos008.aspx/cargarInstituciones',
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
            $("#proyeccion").val('');
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
            } else if ($.trim($("#grupoinvestigacion").val()) == '') {
                alert("Por favor, seleccione grupo investigacion");
                $("#grupoinvestigacion").focus();
            }
            else if ($.trim(document.getElementById('MainContent_resumen_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite el resumen");
            }
            else if ($.trim(document.getElementById('MainContent_relato_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite el relato");
            }
            else if ($.trim(document.getElementById('MainContent_perturbacion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite la Perturbación de la Onda en Ciclón");
            }
            else if ($.trim(document.getElementById('MainContent_superposicion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite la Superposición de la Onda en Ciclón");
            }
            else if ($.trim(document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite la sintesis");
            }
            else if ($.trim(document.getElementById('MainContent_aprendizaje_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite el aprendizaje");
            }
            else if ($.trim(document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite la conclusión");
            }
            else if ($.trim(document.getElementById('MainContent_fuentes_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, digite la fuente");
            }
            
            else {
                var codigo = $("#grupoinvestigacion").val();
                var resumen = document.getElementById('MainContent_resumen_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var relato = document.getElementById('MainContent_relato_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var perturbacion = document.getElementById('MainContent_perturbacion_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var superposicion = document.getElementById('MainContent_superposicion_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var sintesis = document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var aprendizaje = document.getElementById('MainContent_aprendizaje_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var conclusiones = document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var fuentes = document.getElementById('MainContent_fuentes_ctl02_ctl00').contentWindow.document.body.innerHTML;
                enviardato(codigo, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes, event);
            }
        }

        //--- Inicio de nueva funcion para enviar
        function enviardato(codigo, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes, event) {
                var codproyecto = $("#grupoinvestigacion").val();
                var proyeccion = $("#proyeccion").val();
                if (event == 'insert') {
                    finsertInstrumento(codproyecto, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes);
                } else if (event == 'update') {
                    fupdateInstrumento(resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes, $("#codigo").val());
                }
            }
        //--- Fin de nueva funcion para enviar

       

        function finsertInstrumento(codproyecto, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codproyecto": "' + codproyecto + '", "resumen": "' + resumen + '", "relato": "' + relato + '", "perturbacion": "' + perturbacion + '", "superposicion": "' + superposicion + '", "sintesis": "' + sintesis + '", "aprendizaje": "' + aprendizaje + '", "conclusiones": "' + conclusiones + '", "fuentes": "' + fuentes + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunos008.aspx/insertInstrumento',
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
                        listarBitacoraSeis();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }
        
        function fupdateInstrumento(resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes, codigoinstrumento) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "resumen": "' + resumen + '", "relato": "' + relato + '", "perturbacion": "' + perturbacion + '", "superposicion": "' + superposicion + '", "sintesis": "' + sintesis + '", "aprendizaje": "' + aprendizaje + '", "conclusiones": "' + conclusiones + '", "fuentes": "' + fuentes + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunos008.aspx/updateInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        alert("instrumento actualizado exitosamente");
                        /*2016-10-25 agregado*/
                        listarBitacoraSeis();
                       // finsertMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function loadInstrumentosSeis(codigo) {
            
            var jsonData = '{ "codigo":"' + codigo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estraunos008.aspx/loadInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        $("#codigo").val(resp[1]);
                                              
                        document.getElementById('MainContent_resumen_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[2];
                        document.getElementById('MainContent_relato_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[3];
                        document.getElementById('MainContent_perturbacion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[4];
                        document.getElementById('MainContent_superposicion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[5];
                        document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[6];
                        document.getElementById('MainContent_aprendizaje_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[7];
                        document.getElementById('MainContent_conclusiones_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[8];
                        document.getElementById('MainContent_fuentes_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[9];

                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestragb03(\'update\')');
                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        $("#proyeccion").val('');
                        $('#btn-guardar').attr('onclick', 'enviarestragb03(\'insert\')');
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
            listarBitacoraSeis();
        });

        function listarBitacoraSeis() {
            $("#form").hide();
            $("#table").fadeIn(500);

            $.ajax({
                type: 'POST',
                url: 'estraunos008.aspx/listarBitacoraSeis',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function loadSelectBitacoraSeis(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estraunos008.aspx/loadSelectBitacoraSeis',
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

      

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsondata = "{'codigo':'" + codigo + "'}";

                $.ajax({
                    type: 'POST',
                    url: 'estraunos008.aspx/eliminar',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsondata,
                    success: function (json) {
                        alert("Registro eliminado correctamente");
                        listarBitacoraSeis();
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
    <h2 >Estrategia Nro. 1 - Resumen Artículo de Investigación</h2>
    <div id="table">
     <a href="#" class="btn btn-primary" style="float:right;" onclick="nuevaBitacora()">Nuevo resumen</a>
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
        <legend>Resumen</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ececec;">
            <tr>
                <td>
                    El resumen del proyecto de investigación no puede exceder las 400 palabras ni debe ser inferior a 320 palabras 
                </td>
            </tr>
            <tr>
                <td>
                     <cc1:Editor ID="resumen" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

            <tr>
                <td>
                    a.	Breve relato que da cuenta de la perturbación y superposición de la Onda en Ciclón, cómo llegaron a ella y cuál es la meta final. Min 80, Max 110 palabras 
                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="relato" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

             <tr>
                <td>
                   <b> •	Perturbación de la Onda en Ciclón</b><br />
                    Enunciar la (s)  pregunta (s) de investigación que ha formulado.
                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="perturbacion" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

             <tr>
                <td>
                    <b>•	Superposición de la Onda en Ciclón</b><br />
                    Resumen de máximo 50 palabras de la problemática de su investigación
                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="superposicion" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

             <tr>
                <td>
                   <b> b.	Reflexión de la Onda en Ciclón</b><br />
                   •	Síntesis de los resultados de la investigación que dan cuenta de la respuesta a la pregunta y el problema de investigación. Incluya datos estadísticos si se tienen. 70- 80 palabras
                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="sintesis" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

              <tr>
                <td>
                   •	Aprendizajes, logros alcanzados y dificultades presentadas en el proceso de investigación. Min 80, Max 100 palabras
                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="aprendizaje" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

             <tr>
                <td>
                   •	Conclusiones del grupo sobre el estudio del problema de investigación. 40- 50 palabras
                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="conclusiones" runat="server" Width="1050px" Height="250" />
                </td>
            </tr>

             <tr>
                <td>
                   Fuentes<br />
                    Relación de las fuentes de consulta más relevante de su investigación debidamente citada, normas APA

                </td>
            </tr>

            <tr>
                <td>
                     <cc1:Editor ID="fuentes" runat="server" Width="1050px" Height="250" />
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

