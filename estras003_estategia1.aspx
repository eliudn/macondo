<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras003_estategia1.aspx.cs" Inherits="estras003_estategia1" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
     <link rel="stylesheet" href="css/paginacion.css">
    <style>
        body {
            font-family: arial;
        }

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

        .width-100 {
            width: 100%;
        }

        .width-40 {
            width: 40px;
        }

        table.padding tr, table.padding {
            padding: 5px;
            margin: 5px;
        }

        .width-90 {
            width: 90%;
        }

        .title{
			display: block;
   			margin-bottom: 7px;
		}
		.note{
			font-size: 14px;
			margin-bottom: 5px;
			display:block;
		}
		.red{
			color: red;
			font-size: 16px !important;

		}
    </style>

    <script>

        var total = 1;
        var codigoestrategia;
        $(document).ready(function () {
            cargarDepartamentoMagdalena();
            cargarListadoS003("1","10");
            reset();

            $("#departamento").change(function () {
                reset();
                var jsonData = '{ "departamento":"' + $("#departamento").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras003_estategia1.aspx/cargarMunicipios',
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
                    url: 'estras003_estategia1.aspx/cargarInstitucionesxMunicipio',
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
                    url: 'estras003_estategia1.aspx/cargarsedes',
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
                var jsonData = '{ "codsede":"' + $("#sede").val() + '"}';

                $.ajax({
                    type: 'POST',
                    url: 'estras003_estategia1.aspx/grupoInvestigacion',
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

           
        });

        function cargarDepartamentoMagdalena() {
            $.ajax({
                type: 'POST',
                url: 'estras003_estategia1.aspx/cargarDepartamentoMagdalena',
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

        function cargarListadoS003(page, rows) {
            $("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'page':'" + page + "','rows':'" + rows + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras003_estategia1.aspx/cargarListadoS003',
                contentType: "application/json; charset=utf-8",
                data: jsondata,
                dataType: 'JSON',
                success: function (json) {
                    var resp = json.d.split("@S3p4");

                        $("#infoListTable").html(resp[0]);
                        $("#paginacion").html(resp[1]);
                        //alert(resp[0]);

                }
            });
        }

        function ocultar() {
            $("#btn_nuevos003").hide();
            $("#btn_regresar").hide();

            $('#btn-guardar').attr('value', 'Guardar Todo');
            $('#btn-guardar').attr('onclick', 'enviarestras003(\'insert\')');
            
        }

        function sesion() {
            borrarsesion();
            
        }

        function mostrar() {
            //$("#btn_regresar").show();
            $("#btn_nuevos003").show();
            cargarListadoS003("1", "10");
        }

        function regresar() {
            //window.location.href = "configrupoinvestigacionDocentes.aspx";
            $('#lista').fadeIn(500); $('#form').hide();

        }

        function borrarsesion() {
            $.ajax({
                type: 'POST',
                url: 'estras003_estategia1.aspx/borrarsesion',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                  
                }
            });
        }

        function reset() {

            document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_objetivogeneral_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_objetivosespecificos_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_perturbaciononda_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_superposiciononda_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_trayectoriaindagacion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_reflexiononda_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_anexoevidencias_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_hallazgosyresultados_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_bibliografiayfuentes_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
        }

        function loadSelect(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras003_estategia1.aspx/loadSelect',
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

        function enviarestras003(event) {

           

            if ($("#grupoinvestigacion").val() == '') {
                alert("Por favor, seleccione el grupo de investigación");
            }
            else if ($.trim(document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese introducción");
            }
            else if ($.trim(document.getElementById('MainContent_objetivogeneral_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Objetivo General");
            }
            else if ($.trim(document.getElementById('MainContent_objetivosespecificos_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Objetivos Especificos");
            }
            else if ($.trim(document.getElementById('MainContent_perturbaciononda_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Pregunta de Investigación");
            }
            else if ($.trim(document.getElementById('MainContent_superposiciononda_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Planteamiento del Problema de Investigación");
            }
            else if ($.trim(document.getElementById('MainContent_trayectoriaindagacion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Justificación");
            }
            else if ($.trim(document.getElementById('MainContent_reflexiononda_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Referentes Conceptuales");
            }
            else if ($.trim(document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Metodología");
            }
            else if ($.trim(document.getElementById('MainContent_anexoevidencias_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Anexo y Evidencias");
            }
            else if ($.trim(document.getElementById('MainContent_hallazgosyresultados_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Hallazgos y Resultados");
            }
            else if ($.trim(document.getElementById('MainContent_bibliografiayfuentes_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Bibliografía y Fuentes");
            }
            else {

                var codproyectosede = $("#grupoinvestigacion").val();
                var introduccion = document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var objetivogeneral = document.getElementById('MainContent_objetivogeneral_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var objetivosespecificos = document.getElementById('MainContent_objetivosespecificos_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var perturbaciononda = document.getElementById('MainContent_perturbaciononda_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var superposiciononda = document.getElementById('MainContent_superposiciononda_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var trayectoriaindagacion = document.getElementById('MainContent_trayectoriaindagacion_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var reflexiononda = document.getElementById('MainContent_reflexiononda_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var bibliografia = document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var anexoevidencias = document.getElementById('MainContent_anexoevidencias_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var hallazgosyresultados = document.getElementById('MainContent_hallazgosyresultados_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var bibliografiayfuentes = document.getElementById('MainContent_bibliografiayfuentes_ctl02_ctl00').contentWindow.document.body.innerHTML;

                if (event == 'insert') {

                    var jsonData = "{'codproyectosede':'" + codproyectosede + "',  'introduccion':'" + introduccion + "', 'objetivogeneral':'" + objetivogeneral + "','objetivosespecificos':'" + objetivosespecificos + "',  'perturbaciononda':'" + perturbaciononda + "', 'superposiciononda':'" + superposiciononda + "', 'trayectoriaindagacion':'" + trayectoriaindagacion + "',  'reflexiononda':'" + reflexiononda + "', 'bibliografia':'" + bibliografia + "', 'anexoevidencias':'" + anexoevidencias + "', 'hallazgosyresultados':'" + hallazgosyresultados + "', 'bibliografiayfuentes':'" + bibliografiayfuentes + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estras003_estategia1.aspx/insertestras003',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                codigoestrategia = resp[1];
                                alert("instrumento insertado exitosamente");
                                $('#lista').fadeIn(500); $('#form').hide();
                                reset();
                                $("#btn_nuevos003").show();
                                $("#btn_regresar").hide();
                                cargarListadoS003("1", "10");
                                
                            } else {
                                alert(resp[1]);
                            }
                        }, complete: function () {
                            $('#btn-guardar').attr('value', 'Actualizar');
                            $('#btn-guardar').attr('onclick', 'enviarestras003(\'update\')');
                        }
                    });
                }
                else if (event == 'update') {

                    var jsonData = "{  'codigoestrategia':'" + codigoestrategia + "', 'introduccion':'" + introduccion + "', 'objetivogeneral':'" + objetivogeneral + "','objetivosespecificos':'" + objetivosespecificos + "',  'perturbaciononda':'" + perturbaciononda + "', 'superposiciononda':'" + superposiciononda + "', 'trayectoriaindagacion':'" + trayectoriaindagacion + "',  'reflexiononda':'" + reflexiononda + "', 'bibliografia':'" + bibliografia + "', 'anexoevidencias':'" + anexoevidencias + "', 'hallazgosyresultados':'" + hallazgosyresultados + "', 'bibliografiayfuentes':'" + bibliografiayfuentes + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estras003_estategia1.aspx/updateestras003',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                codigoestrategia = codigoestrategia;
                                alert("instrumento actualizado exitosamente");
                                cargarListadoS003("1", "10");
                                $('#lista').fadeIn(500); $('#form').hide();
                                reset();
                                $("#btn_nuevos003").show();
                                $("#btn_regresar").hide();
                            } else {
                                alert(resp[1]);
                            }
                        }, complete: function () {
                            $('#btn-guardar').attr('value', 'Actualizar');
                            $('#btn-guardar').attr('onclick', 'enviarestras003(\'update\')');
                        }
                    });
                }

            }
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estras003_estategia1.aspx/deleteestras003',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            cargarListadoS003("1", "10");
                            alert('Dato eliminado correctamente.');
                            $('#form').hide();
                            $('#lista').fadeIn(500);
                           
                        }
                        else {
                            alert('Error al eliminar.');
                        }
                    }
                });
            }

        }

        function loadInstrumento(codigo) {
            var jsonData = "{ 'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras003_estategia1.aspx/loadestras003',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];

                        document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[2];
                        document.getElementById('MainContent_objetivogeneral_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[3];
                        document.getElementById('MainContent_objetivosespecificos_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[4];
                        document.getElementById('MainContent_perturbaciononda_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[5];
                        document.getElementById('MainContent_superposiciononda_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[6];
                        document.getElementById('MainContent_trayectoriaindagacion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[7];
                        document.getElementById('MainContent_reflexiononda_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[8];
                        document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[9];
                        document.getElementById('MainContent_anexoevidencias_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[10];
                        document.getElementById('MainContent_hallazgosyresultados_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[11];
                        document.getElementById('MainContent_bibliografiayfuentes_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[12];

                        ocultar();

                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestras003(\'update\')');

                    }
                }
            });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Informe de investigación</h2>
    <asp:Label ID="lblCodMomento" runat="server" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
      <a class="btn btn-success" id="btn_regresar" style="float:right;display:none" onclick="regresar()">Regresar</a>
      <a class="btn btn-primary" id="btn_nuevos003" style="float:right" onclick="$('#lista').hide(), $('#form').fadeIn(500), reset(), ocultar(),$('#btn_regresar').show()">Nuevo informe</a>
   <br /><br /><br />
    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
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
                            <td width="100%">Nombre del grupo de investigación: </td>
                            <td style="width: 150px;">
                                <select class="TextBox" name="grupoinvestigacion" id="grupoinvestigacion" >
                                    <option value="">Seleccione grupo investigación...</option>
                                </select></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td> 
                    <br /> <br />
                        <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviarestras003('insert');">
                </td>
            </tr>
        </table>
            <br />
            <div class="button">     
        <%--<asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar todo" runat="server" OnClick="btnGuardarSede_Click" />--%>
       </div>
    </fieldset>
        

      </div>  
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
        <br />
    <div id="form" style="display:none;">
    <fieldset>
        <h1 style="display: block;text-align:center;">DESARROLLO DEL INFORME DE INVESTIGACIÓN</h1>
        <br />
        <br />

        <h2 style="display: block;">1. INTRODUCCIÓN</h2>
        <span class="note"><span class="red">*</span>Realice síntesis de máximo 1.000 palabras en el que dé cuenta de los aspectos más importantes de la investigación (planteamientos iniciales, procesos, resultados, alcances y aprendizajes). </span>
            <br>
        </span>
        <br>
        <br>
        <cc1:Editor ID="introduccion" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>
        <h2 style="display: block;">2. OBJETIVOS</h2>

        <b class="title">2.1. OBJETIVO GENERAL</b>
	    <span class="note"><span class="red">*</span>Trascriba el propósito final de su investigación que planteó cuando diseño las trayectorias de indagación. </span>
        <br>
        <cc1:Editor ID="objetivogeneral" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>

        <b class="title">2.2. OBJETIVO ESPECIFICOS</b>
	    <span class="note"><span class="red">*</span>Escriba los alcances esperados de la investigación relacionado en los segmentos de investigación. </span>
        <br>
        <cc1:Editor ID="objetivosespecificos" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>


        <h2 style="display: block;">3. PREGUNTA DE INVESTIGACIÓN</h2>
	    <span class="note"><span class="red">*</span>Escriba la pregunta de investigación del proyecto y el proceso con el cual que llegaron a ella. (Máximo 100 palabras). </span>
        <br>
        <cc1:Editor ID="perturbaciononda" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>

        <h2 style="display: block;">4. PLANTEAMIENTO DEL PROBLEMA DE INVESTIGACIÓN</h2>
	    <span class="note"><span class="red">*</span>Indiquen la problemática que aborda la investigación (En máximo 300 palabras). </span>
        <br>
        <cc1:Editor ID="superposiciononda" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>


        <h2 style="display: block;">5. JUSTIFICACIÓN</h2>
	    <span class="note"><span class="red">*</span>Por qué es importante la propuesta, qué aspectos se resolverán con su implementación, para qué servirá a la institución, los estudiantes, los maestros y comunidad en general. En este capítulo se debe mostrar la utilidad, aportes e impacto del proyecto para la gestión curricular. </span>
        <br>
        <cc1:Editor ID="trayectoriaindagacion" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>


        <h2 style="display: block;">6. REFERENTES CONCEPTUALES</h2>
	    <span class="note"><span class="red">*</span>Explique los conceptos o ideas centrales que orientaron la investigación. </span>
        <br>
        <cc1:Editor ID="reflexiononda" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>



        <h2 style="display: block;">7. METODOLOGÍA
        </h2>
        <span class="note"><span class="red">*</span>(máximo 2.000 palabras)</span>
        <br>
        <span>Explique: </span>
        <br>
        <br>
        <span> •	Explique la metodología utilizada. Incluya datos estadísticos si se tienen. </span>
        <br>
        <span> •	Describa el recorrido de la investigación para responder la pregunta y el problema. </span>
        <br>
        <br>
        <cc1:Editor ID="bibliografia" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>


        
        <h2 style="display: block;">8. HALLAZGOS Y RESULTADOS
        </h2>
        <span class="note"><span class="red">*</span>Presenten los resultados y conclusiones de la investigación desarrollando: </span>
        <br>
        <span> •	Contenidos. </span>
        <br>
        <span> •	Procesos. </span>
        <br>
        <span> •	Espacios de apropiación en los cuales se hayan presentado avances o resultados del proyecto, indicando los medios propuestos y utilizados para la divulgación del proyecto, así como sus resultados. </span>
        <br>
        <br>
        <cc1:Editor ID="hallazgosyresultados" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>


        <h2 style="display: block;">9. BIBLIOGRAFÍA Y FUENTES </h2>
	    <span class="note"><span class="red">*</span>Relación de las fuentes de consulta más relevante de su investigación debidamente citada, normas APA. </span>
        <br>
        <cc1:Editor ID="bibliografiayfuentes" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>


        <h2 style="display: block;">10.	ANEXOS Y EVIDENCIAS
        </h2>
        <span class="note"><span class="red">*</span>Recuerde en cada fotografía que anexe como evidencia, debe el pie de foto respectivo. </span>
        <br>
        <cc1:Editor ID="anexoevidencias" runat="server" Width="100%" Height="250" />
        <br>
        <br>
        <br>
    </fieldset>

    <br>
  
    <style>
        .button {
            background: rgba(255,255,255,.7);
            bottom: 0;
            display: block;
            left: 0;
            padding: 15px;
            position: fixed;
            right: 0;
            text-align: right;
        }
    </style>

 </fieldset>

     

</div>

    <div id="lista">
         <fieldset>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No</th>
                         <th>Departamento</th>
                         <th>Municipio</th>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Grupo<br />Investigación</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="infoListTable">

                </tbody>
            </table>
            <div id="paginacion" class="pagination">
            </div>
        </fieldset>
    </div>
</asp:Content>

