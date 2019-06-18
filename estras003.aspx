<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras003.aspx.cs" Inherits="estras003" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
    
    <%--<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>--%>
    
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <script type="text/javascript" src="js/json2.min.js"></script>
     <link rel="stylesheet" href="css/paginacion.css">

     <script src="ckeditor/ckeditor.js"></script><!-- Llama al editor HTML-->

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
            
            cargarListadoS003("1","10");
            reset();

           
        });

        function cargarListadoS003(page, rows) {
            $("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'page':'" + page + "','rows':'" + rows + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras003.aspx/cargarListadoS003',
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
            $("#btn_regresar").show();
            $("#btn_nuevos003").show();
            cargarListadoS003("1", "10");
        }

        function regresar() {
            window.location.href = "configrupoinvestigacionDocentes.aspx";
        }

        function borrarsesion() {
            $.ajax({
                type: 'POST',
                url: 'estras003.aspx/borrarsesion',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                  
                }
            });
        }

        function reset() {

           

            //document.getElementById('MainContent_introduccion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_objetivogeneral_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_objetivosespecificos_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_perturbaciononda_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_superposiciononda_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_trayectoriaindagacion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_reflexiononda_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_bibliografia_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_anexoevidencias_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_hallazgosyresultados_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            //document.getElementById('MainContent_bibliografiayfuentes_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
        }

        function enviarestras003(event) {

           

            if ($.trim(CKEDITOR.instances.introduccion.getData()) == '') {
                alert("Por favor, ingrese introducción");
            }
            else if ($.trim(CKEDITOR.instances.objetivogeneral.getData()) == '') {
                alert("Por favor, ingrese Objetivo General");
            }
            else if ($.trim(CKEDITOR.instances.objetivosespecificos.getData()) == '') {
                alert("Por favor, ingrese Objetivos Especificos");
            }
            else if ($.trim(CKEDITOR.instances.perturbaciononda.getData()) == '') {
                alert("Por favor, ingrese Pregunta de Investigación");
            }
            else if ($.trim(CKEDITOR.instances.superposiciononda.getData()) == '') {
                alert("Por favor, ingrese Planteamiento del Problema de Investigación");
            }
            else if ($.trim(CKEDITOR.instances.trayectoriaindagacion.getData()) == '') {
                alert("Por favor, ingrese Justificación");
            }
            else if ($.trim(CKEDITOR.instances.reflexiononda.getData()) == '') {
                alert("Por favor, ingrese Referentes Conceptuales");
            }
            else if ($.trim(CKEDITOR.instances.bibliografia.getData()) == '') {
                alert("Por favor, ingrese Metodología");
            }
            else if ($.trim(CKEDITOR.instances.anexoevidencias.getData()) == '') {
                alert("Por favor, ingrese Anexo y Evidencias");
            }
            else if ($.trim(CKEDITOR.instances.hallazgosyresultados.getData()) == '') {
                alert("Por favor, ingrese Hallazgos y Resultados");
            }
            else if ($.trim(CKEDITOR.instances.bibliografiayfuentes.getData()) == '') {
                alert("Por favor, ingrese Bibliografía y Fuentes");
            }
            else {

                if (event == 'insert') {

                    var introduccion = CKEDITOR.instances.introduccion.getData();
                    var objetivogeneral = CKEDITOR.instances.objetivogeneral.getData();
                    var objetivosespecificos = CKEDITOR.instances.objetivosespecificos.getData();
                    var perturbaciononda = CKEDITOR.instances.perturbaciononda.getData();
                    var superposiciononda = CKEDITOR.instances.superposiciononda.getData();
                    var trayectoriaindagacion = CKEDITOR.instances.trayectoriaindagacion.getData();
                    var reflexiononda = CKEDITOR.instances.reflexiononda.getData();
                    var bibliografia = CKEDITOR.instances.bibliografia.getData();
                    var anexoevidencias = CKEDITOR.instances.anexoevidencias.getData();
                    var hallazgosyresultados = CKEDITOR.instances.hallazgosyresultados.getData();
                    var bibliografiayfuentes = CKEDITOR.instances.bibliografiayfuentes.getData();
       
                    var jsonData = "{'introduccion':'" + introduccion + "', 'objetivogeneral':'" + objetivogeneral + "', 'objetivosespecificos':'" + objetivosespecificos + "', 'perturbaciononda':'" + perturbaciononda + "', 'superposiciononda':'" + superposiciononda + "', 'trayectoriaindagacion':'" + trayectoriaindagacion + "', 'reflexiononda':'" + reflexiononda + "', 'bibliografia':'" + bibliografia + "', 'anexoevidencias':'" + anexoevidencias + "', 'hallazgosyresultados':'" + hallazgosyresultados + "', 'bibliografiayfuentes':'" + bibliografiayfuentes + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estras003.aspx/insertestras003',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("_insert@");
                            if (resp[0] === "true") {
                                codigoestrategia = resp[1];
                                alert("instrumento insertado exitosamente");
                                
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
                     alert(codigoestrategia);
                        var introduccion = CKEDITOR.instances.introduccion.getData();
                        var objetivogeneral = CKEDITOR.instances.objetivogeneral.getData();
                        var objetivosespecificos = CKEDITOR.instances.objetivosespecificos.getData();
                        var perturbaciononda = CKEDITOR.instances.perturbaciononda.getData();
                        var superposiciononda = CKEDITOR.instances.superposiciononda.getData();
                        var trayectoriaindagacion = CKEDITOR.instances.trayectoriaindagacion.getData();
                        var reflexiononda = CKEDITOR.instances.reflexiononda.getData();
                        var bibliografia = CKEDITOR.instances.bibliografia.getData();
                        var anexoevidencias = CKEDITOR.instances.anexoevidencias.getData();
                        var hallazgosyresultados = CKEDITOR.instances.hallazgosyresultados.getData();
                        var bibliografiayfuentes = CKEDITOR.instances.bibliografiayfuentes.getData();

                        var jsonData = "{  'codigoestrategia':'" + codigoestrategia + "', 'introduccion':'" + introduccion + "', 'objetivogeneral':'" + objetivogeneral + "', 'objetivosespecificos':'" + objetivosespecificos + "', 'perturbaciononda':'" + perturbaciononda + "', 'superposiciononda':'" + superposiciononda + "', 'trayectoriaindagacion':'" + trayectoriaindagacion + "', 'reflexiononda':'" + reflexiononda + "', 'bibliografia':'" + bibliografia + "', 'anexoevidencias':'" + anexoevidencias + "', 'hallazgosyresultados':'" + hallazgosyresultados + "', 'bibliografiayfuentes':'" + bibliografiayfuentes + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'estras003.aspx/updateestras003',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData,
                                success: function (json) {
                                    var resp = json.d.split("_update@");
                                    if (resp[0] === "true") {
                                        codigoestrategia = codigoestrategia;
                                        alert("instrumento actualizado exitosamente");
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

            }
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estras003.aspx/deleteestras003',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            alert('Dato eliminado correctamente.');
                            $('#form').hide();
                            $('#lista').fadeIn(500);
                            cargarListadoS003("1", "10");
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
                url: 'estras003.aspx/loadestras003',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];

                        CKEDITOR.instances.introduccion.setData(resp[2]);
                        CKEDITOR.instances.objetivogeneral.setData(resp[3]);
                        CKEDITOR.instances.objetivosespecificos.setData(resp[4]);
                        CKEDITOR.instances.perturbaciononda.setData(resp[5]);
                        CKEDITOR.instances.superposiciononda.setData(resp[6]);
                        CKEDITOR.instances.trayectoriaindagacion.setData(resp[7]);
                        CKEDITOR.instances.reflexiononda.setData(resp[8]);
                        CKEDITOR.instances.bibliografia.setData(resp[9]);
                        CKEDITOR.instances.anexoevidencias.setData(resp[10]);
                        CKEDITOR.instances.hallazgosyresultados.setData(resp[11]);
                        CKEDITOR.instances.bibliografiayfuentes.setData(resp[12]);

                        //ocultar();

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
      <a class="btn btn-success" id="btn_regresar" style="float:right" onclick="regresar()">Regresar</a>
      <a class="btn btn-primary" id="btn_nuevos003" style="float:right" onclick="$('#lista').hide(), $('#form').fadeIn(500), reset(), ocultar()">Nuevo informe</a>
   <br /><br /><br />
    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
    <div id="form" style="display:none;">
 
		<!-- FIN DATOS DE LA INSTITUCIÓN -->

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
        <%--<cc1:Editor ID="introduccion" runat="server" Width="100%" Height="250" />--%>
        <%--<CKEditor:CKEditorControl ID="introduccion" runat="server" Height="500px"></CKEditor:CKEditorControl>--%>
        <textarea class="ckeditor" cols="155" id="introduccion" name="introduccion" rows="10"></textarea>
		<script type="text/javascript">
			CKEDITOR.replace("introduccion");
	    </script>
        <br>
        <br>
        <br>
        <h2 style="display: block;">2. OBJETIVOS</h2>

        <b class="title">2.1. OBJETIVO GENERAL</b>
	    <span class="note"><span class="red">*</span>Trascriba el propósito final de su investigación que planteó cuando diseño las trayectorias de indagación. </span>
        <br>
        <%--<cc1:Editor ID="objetivogeneral" runat="server" Width="100%" Height="250" />--%>
         <textarea class="ckeditor" cols="155" id="objetivogeneral" name="objetivogeneral" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("objetivogeneral");
	    </script>
        <br>
        <br>
        <br>

        <b class="title">2.2. OBJETIVO ESPECIFICOS</b>
	    <span class="note"><span class="red">*</span>Escriba los alcances esperados de la investigación relacionado en los segmentos de investigación. </span>
        <br>
        <%--<cc1:Editor ID="objetivosespecificos" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="objetivosespecificos" name="objetivosespecificos" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("objetivosespecificos");
	    </script>
        <br>
        <br>
        <br>


        <h2 style="display: block;">3. PREGUNTA DE INVESTIGACIÓN</h2>
	    <span class="note"><span class="red">*</span>Escriba la pregunta de investigación del proyecto y el proceso con el cual que llegaron a ella. (Máximo 100 palabras). </span>
        <br>
        <%--<cc1:Editor ID="perturbaciononda" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="perturbaciononda" name="perturbaciononda" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("perturbaciononda");
	    </script>
        <br>
        <br>
        <br>

        <h2 style="display: block;">4. PLANTEAMIENTO DEL PROBLEMA DE INVESTIGACIÓN</h2>
	    <span class="note"><span class="red">*</span>Indiquen la problemática que aborda la investigación (En máximo 300 palabras). </span>
        <br>
        <%--<cc1:Editor ID="superposiciononda" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="superposiciononda" name="superposiciononda" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("superposiciononda");
	    </script>
        <br>
        <br>
        <br>


        <h2 style="display: block;">5. JUSTIFICACIÓN</h2>
	    <span class="note"><span class="red">*</span>Por qué es importante la propuesta, qué aspectos se resolverán con su implementación, para qué servirá a la institución, los estudiantes, los maestros y comunidad en general. En este capítulo se debe mostrar la utilidad, aportes e impacto del proyecto para la gestión curricular. </span>
        <br>
        <%--<cc1:Editor ID="trayectoriaindagacion" runat="server" Width="100%" Height="250" />--%>
         <textarea class="ckeditor" cols="155" id="trayectoriaindagacion" name="trayectoriaindagacion" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("trayectoriaindagacion");
	    </script>
        <br>
        <br>
        <br>


        <h2 style="display: block;">6. REFERENTES CONCEPTUALES</h2>
	    <span class="note"><span class="red">*</span>Explique los conceptos o ideas centrales que orientaron la investigación. </span>
        <br>
        <%--<cc1:Editor ID="reflexiononda" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="reflexiononda" name="reflexiononda" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("reflexiononda");
	    </script>
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
        <%--<cc1:Editor ID="bibliografia" runat="server" Width="100%" Height="250" />--%>
         <textarea class="ckeditor" cols="155" id="bibliografia" name="bibliografia" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("bibliografia");
	    </script>
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
        <%--<cc1:Editor ID="hallazgosyresultados" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="hallazgosyresultados" name="hallazgosyresultados" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("hallazgosyresultados");
	    </script>
        <br>
        <br>
        <br>


        <h2 style="display: block;">9. BIBLIOGRAFÍA Y FUENTES </h2>
	    <span class="note"><span class="red">*</span>Relación de las fuentes de consulta más relevante de su investigación debidamente citada, normas APA. </span>
        <br>
        <%--<cc1:Editor ID="bibliografiayfuentes" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="bibliografiayfuentes" name="bibliografiayfuentes" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("bibliografiayfuentes");
	    </script>
        <br>
        <br>
        <br>


        <h2 style="display: block;">10.	ANEXOS Y EVIDENCIAS
        </h2>
        <span class="note"><span class="red">*</span>Recuerde en cada fotografía que anexe como evidencia, debe el pie de foto respectivo. </span>
        <br>
        <%--<cc1:Editor ID="anexoevidencias" runat="server" Width="100%" Height="250" />--%>
        <textarea class="ckeditor" cols="155" id="anexoevidencias" name="anexoevidencias" rows="10"></textarea>
		<script type="text/javascript">
		    CKEDITOR.replace("anexoevidencias");
	    </script>
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

     
    <div class="button">
        <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviarestras003('insert');">
         <input type="button" value="Volver" class="btn btn-primary" id="btn-volver" onclick="reset(), $('#form').hide(), $('#lista').fadeIn(500), mostrar(), sesion()">
        <%--<asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar todo" runat="server" OnClick="btnGuardarSede_Click" />--%>
    </div>
</div>

    <div id="lista">
         <fieldset>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Objetivo General</th>
                        <th>Pregunta de investigación</th>
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

