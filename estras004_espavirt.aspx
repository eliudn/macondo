<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras004_espavirt.aspx.cs" Inherits="estras004_espavirt" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
   <script src="jquery.js"></script>
    <%--<script src="s003/tinymce.min.js"></script>--%>
   <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
 
     <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
     <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />
 
     <%--<link rel="stylesheet" href="css/paginacion.css">--%>
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


        .pagination li {
  display: inline-block;
  border-radius: 2px;
  text-align: center;
  vertical-align: top;
  height: 30px;
}

.pagination li a {
  color: #444;
  display: inline-block;
  font-size: 1rem;
  padding: 0 10px;
  line-height: 30px;
}

.pagination li.active a {
  color: #fff;
}

.pagination li.active {
  background-color: #ee6e73;
}

.pagination li.disabled a {
  cursor: default;
  color: #999;
}

.pagination li i {
  font-size: 2rem;
}

.pagination li.pages ul li {
  display: inline-block;
  float: none;
}

@media only screen and (max-width: 992px) {
  .pagination {
    width: 100%;
  }
  .pagination li.prev,
  .pagination li.next {
    width: 10%;
  }
  .pagination li.pages {
    width: 80%;
    overflow: hidden;
    white-space: nowrap;
  }
}

    </style>

    <script>
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

        var total = 1;
        var codigoestrategia;
        var sesion;
        var codmemoria;
        var insert;
        var idred;
        $(document).ready(function () {

            //Cargar listado de memorias
            cargarListadoMemorias();
            reset();
           
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/cargarnomasesor',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "nombre") {
                        $("#nombreapellidorelator").val(resp[1]);
                    }
                }
            });

            //Cargar departamento
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/cargarDepartamentoMagdalena',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "departamento") {
                        $("#departamento").html(resp[1]);
                    }
                }
            });

            $("#departamento").on("change", function () {
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estras004_espavirt.aspx/cargarMunicipioMagdalena',
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
            
            //cargando sedes segun institucion seleccionada
            $("#institucion").change(function () {
                var jsonData = '{ "codigoins":"' + $("#institucion").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras004_espavirt.aspx/cargarsedes',
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

            //cargando sedes segun institucion seleccionada
            $("#sede").change(function () {
                var jsonData = '{ "codsede":"' + $("#sede").val() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'estras004_espavirt.aspx/cargarRedtematica',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "redtematica") {
                            //$("#redtematica").html(resp[1]);
                            $("#redtematica").append(resp[1]);

                        }
                    }
                });
            });

            $(".datepicker").datepicker({ changeYear: true, changeMonth: true });
        });

        function buscarSesionMemoria(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/buscarSesionMemoria',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    var resp = response.d.split("@");
                    $("#infosesion").html(resp[1]);
                    sesion = resp[0];
                    codmemoria = codigo;
                }
            });
        }

        function guardarSesion() {
            var jsondata = "{'codmemoria':'" + codmemoria + "', 'sesion':'" + $("#sesion").val() + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/guardarSesion',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    alert("Sesión modificada con éxito");
                    $("#modificarsesion").hide();
                    $("#formTable").hide();
                    $("#listTable").fadeIn(500);
                    cargarListadoMemorias();
                }
            });
        }

        function cargarTemas() {

            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/cargarTemas',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#temasesion").val(response.d);
                }
            });
        }

        //var table;
        function cargarDataTable() {
            $('#infoListTable').DataTable({
                //"scrollX": 400,   // For Scrolling
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

        function cargarListadoMemorias() {
            //$("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            //var jsondata = "{'page':'" + page + "'}";
            var table = $('#infoListTable').DataTable();
            table.destroy();
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/cargarListadoMemoriaAsesor',
                //data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {

                    var resp = response.d.split("@");

                    $("#infoListTable tbody").html(resp[0]);
                    //$("#paginacion").html(resp[1]);
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
            $("#radiotr" + ant).append('<button id="remove" onclick="fRemove(' + ant + ')" class="btn btn-danger">-</button>');
        }


        function cargarinstituciones(codMunicipio) {
            var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/cargarInstituciones',
                data: jsondata,
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
            //$("#departamento").val('');
            //$("#municipio").val('');
            //$("#institucion").val('');
            //$("#sede").val('');
            $("#nombresesion").val('GÓZATE LA CIENCIA Y MEJORA TUS CAPACIDADES INVESTIGATIVAS A TRAVÉS DE COMUNIDADES VIRTUALES COMO ESTRATEGIA PARA CONFORMAR LA COMUNIDAD DE PRÁCTICA, APRENDIZAJE, SABER, CONOCIMIENTO Y TRANSFORMACIÓN');
            $("#fechaelaboracion").val('');

            $("#horasesion").val('');
            $("#horasesionfinal").val('');
            $("#nombreapellidorelator").val('');
            $("#nohoras").val('');
            //$("#nosesiones").val('');

            document.getElementById('MainContent_acompanamiento_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_herramientas_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';

            html = '<tr>';
            html += '<th>No.</th>';
            html += '<th></th>';
            html += '</th>';
            html += '</tr>';
            html += '<tr >';
            html += '<td>1.</td>';
            //html += '<td><input type="text" class="TextBox width-90" id="pregunta1" name="pregunta1" ></td>';
            html += '</tr>';
            $("#tablecampus").html(html);
            total = 1;
        }


        function enviarestras004(event) {
            if ($.trim($("#institucion").val()) == '') {
                alert("Por favor, seleccione Nombre de la entidad y / o Institución Educativa: ");
                $("#institucion").focus();
            } else if ($.trim($("#sede").val()) == '') {
                alert("Por favor, seleccione Sede");
                $("#sede").focus();
            }
            //else if ($.trim($("#redtematica").val()) == '') {
            //    alert("Por favor, seleccione Red Temática");
            //    $("#redtematica").focus();
            //}
            else if ($.trim($("#nombresesion").val()) == '') {
                alert("Por favor, ingrese Nombre de sesión o actividad de formación");
                $("#nombresesion").focus();
            } else if ($.trim($("#temasesion").val()) == '') {
                alert("Por favor, ingrese Tema de la sesión o actividad de formación");
                $("#temasesion").focus();
            }
                
            else if ($.trim($("#fechaelaboracion").val()) == '') {
                alert("Por favor, ingrese Fecha de la elaboración de la memoría");
                $("#fechaelaboracion").focus();
            } else if ($.trim($("#horasesion").val()) == '') {
                alert("Por favor, ingrese Hora Inicial de la sesión de formación");
                $("#horasesion").focus();
            } else if ($.trim($("#horasesionfinal").val()) == '') {
                alert("Por favor, ingrese Hora Final de formación");
                $("#horasesionfinal").focus();
            } else if ($.trim($("#nombreapellidorelator").val()) == '') {
                alert("Por favor, ingrese Nombres y apellidos del docente Asesor");
                $("#nombreapellidorelator").focus();
            } else if ($.trim($("#nohoras").val()) == '') {
                alert("Por favor, ingrese el número de horas virtuales de esta(s) red(es)");
                $("#nohoras").focus();
            }
            //else if ($.trim($("#nosesiones").val()) == '') {
            //    alert("Por favor, ingrese el número de sesiones realizadas");
            //    $("#nosesiones").focus();
            //}
            else if ($.trim(document.getElementById('MainContent_acompanamiento_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese el punto 1. Acompañamiento virtual");
            } else if ($.trim(document.getElementById('MainContent_herramientas_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese las herramientas");
            } else if ($.trim(document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Evaluación de la Sesión ");
            }
            else {
                var acompanamiento = document.getElementById('MainContent_acompanamiento_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var herramientas = document.getElementById('MainContent_herramientas_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var evaluacionsesion = document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML;

                if (event == 'insert') {
                    var check = $("input[type='checkbox']:checked").length;
                    $("input[name=redestematicas]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData = "{ 'redtematica':'" + $(this).val() + "', 'nombresesion':'" + $("#nombresesion").val() + "', 'temasesion':'" + $("#temasesion").val() + "', 'fechaelaboracion':'" + $("#fechaelaboracion").val() + "', 'nombrerelator':'" + $("#nombreapellidorelator").val() + "', 'horasesion':'" + $("#horasesion").val() + "', 'horasesionfinal':'" + $("#horasesionfinal").val() + "', 'acompanamiento':'" + acompanamiento + "', 'herramientas':'" + herramientas + "', 'evaluacionsesion':'" + evaluacionsesion + "', 'nohoras':'" + $("#nohoras").val() + "'}";


                            $.ajax({
                                type: 'POST',
                                url: 'estras004_espavirt.aspx/insertestras004',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData,
                                success: function (json) {
                                    var resp = json.d.split("@");
                                    if (resp[0] === "true") {
                                        codigoestrategia = resp[1];
                                        //alert("instrumento insertado exitosamente");
                                        //$("#formTable").hide();
                                        //$("#listTable").fadeIn(500);
                                        //cargarListadoMemorias();
                                        //reset();
                                        insert = parseInt(insert) + 1;
                                    } else {
                                        alert(resp[1]);
                                    }
                                }
                                //, complete: function () {
                                //    finsertpreguntas();
                                //}
                            });

                        }
                    });

                    if (check == "") {
                        alert("Seleccione por lo menos una red temática para continuar.");
                    } else {
                        alert("instrumento insertado exitosamente");
                        btnregresar();
                    }

                } else if (event == 'update') {
                    var jsonData = "{  'codigoestrategia':'" + codigoestrategia + "', 'nombresesion':'" + $("#nombresesion").val() + "', 'temasesion':'" + $("#temasesion").val() + "', 'fechaelaboracion':'" + $("#fechaelaboracion").val() + "', 'nombrerelator':'" + $("#nombreapellidorelator").val() + "', 'horasesion':'" + $("#horasesion").val() + "', 'horasesionfinal':'" + $("#horasesionfinal").val() + "', 'acompanamiento':'" + acompanamiento + "', 'herramientas':'" + herramientas + "', 'evaluacionsesion':'" + evaluacionsesion + "', 'nohoras':'" + $("#nohoras").val() + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estras004_espavirt.aspx/updateestras004',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                //codigoestrategia = codigoestrategia;
                                alert("instrumento actualizado exitosamente");
                                //$("#formTable").hide();
                                //$("#listTable").fadeIn(500);
                                //cargarListadoMemorias("1");
                                btnregresar();
                            } else {
                                alert(resp[1]);
                            }
                        }
                        //, complete: function () {
                        //    finsertpreguntas();
                        //}
                    });
                }
                //$("#redtematica").remove();
            }
        }


        function loadInstrumento(codigo) {
            var jsonData = "{ 'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/loadestras004',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    //console.log(json);
                    loadSelectInstrumento(codigo);
                    //loadEvidencias(codigo)
                    var resp = json.d.split("@");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];
                        $("#nombresesion").val(resp[2]);
                        $("#temasesion").val(resp[3]);
                       

                        $("#fechaelaboracion").val(resp[4]);
                        //var hora = fechahora[1].split(":");
                        //if (hora[0] < 10) {
                        //    hora[0] = "0" + hora[0];
                        //}
                        $("#horasesion").val(resp[9]);
                        $("#horasesionfinal").val(resp[10]);
                        $("#nombreapellidorelator").val(resp[5]);

                        document.getElementById('MainContent_acompanamiento_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[6];
                        document.getElementById('MainContent_herramientas_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[7];
                        document.getElementById('MainContent_evaluacionsesion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[8];

                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestras004(\'update\')');
                        //loadSelectInstrumento(codigo);
                        $("#nohoras").val(resp[11]);
                        //$("#nosesiones").val(resp[12]);
                    }  else {
                        alert("Ocurrio un error");
                    }
                }
            });
        }

        function loadSelectInstrumento(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estras004_espavirt.aspx/loadSelectInstrumento',
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
                        $("#redtematica").append(resp[5]);
                        //idred = resp[6];
                    }
                }
            });
        }

        function btnregresar() {
            $.ajax({
                type: "POST",
                url: "estras004_espavirt.aspx/regresar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    window.location.href = "estras004_espavirt.aspx?e=" + resp[0] + "&m=" + resp[1] + "&s=" + resp[2];
                }
            });
        }

        function resetSelect(){
            $("#departamento").val("");
            $("#municipio").val("");
            $("#institucion").val("");
            $("#sede").val("");
            //$("#redtematica").val("");

            $('#btn-guardar').attr('value', 'Guardar todo');
            $('#btn-guardar').attr('onclick', 'enviarestras004(\'insert\')');
        }

       

       
    </script>

   
     <script type="text/javascript">
      
         function eliminar(codigo) {
             if (confirm('¿Estás seguro de eliminar esta Memoria?')) {
                 var jsonData = "{ 'codigo':'" + codigo + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'estras004_espavirt.aspx/deleteestras004',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     data: jsonData,
                     success: function (json) {
                         var resp = json.d.split("@");
                         if (resp[0] === "delete") {
                             cargarListadoMemorias();
                             alert('Dato eliminado correctamente.');
                         }
                     }
                 });
             }
            
         }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. <asp:Label runat="server" ID="lblEstrategia" Visible="true"></asp:Label> -  S004: Memoria de los espacios de formación virtual</h2>
    <asp:Label ID="lblCodMomento" runat="server" Visible="false"></asp:Label>
<asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodRedTematicaSede" Visible="true"></asp:Label>

    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
    <div id="listTable">
        <%--<button class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500)">Nueva memoria</button>--%>
        <a class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(); $('#formTable').fadeIn(500); resetSelect(); cargarTemas();">Nueva memoria</a>
        <br /><br /><br />
        <fieldset>
            <table class="mGridTesoreria" id="infoListTable">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Departamento</th>
                        <th>Municipio</th>
                        <th>Institucion</th>
                        <th>Sede</th>
                        <th>Nombre Sesión</th>
                        <th>Red tematica</th>
                        <th>Fecha elaboración</th>
                        <th>Momento</th>
                        <th>Sesión</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>

                </tbody>
            </table>
           <%-- <ul id="paginacion" class="pagination">
            </ul>--%>
        </fieldset>
    </div>
    <div id="formTable" style="display:none;">
        <fieldset>
    <table width="100%">
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Departamento </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="departamento" id="departamento">
                                <option value="">Seleccione departamento</option>
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Municipio </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="municipio" id="municipio">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de la entidad y / o Institución Educativa: </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="institucion" id="institucion">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Sede: </td>
                        <td width="70%">
                            <select name="sede" id="sede" class="width-100 TextBox">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%"><asp:label ID="lblTipoGrupo" runat="server" Visible="true"></asp:label>: </td>
                        <td width="70%">
                             <div id="redtematica"></div>
                           <%-- <select name="redtematica" id="redtematica" class="width-100 TextBox">
                                <option value="">Seleccione...</option>
                            </select>--%>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Número de sesiones realizadas </td>
                        <td width="70%">
                        <select id="nosesiones" class="TextBox" style="width:100px;">
                            <option value="" disabled>Seleccione sesión</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                        </select>    
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de sesión o actividad de formación: </td>
                        <td width="70%">
                            <input type="text" id="nombresesion" name="nombresesion" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Tema de la sesión o actividad de formación: </td>
                        <td width="70%">
                            <input type="text" id="temasesion" name="temasesion" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>

     
        <tr>
            <td width="55%">
                <table width="100%">
                    <tr>
                        <td width="30%">Fecha de la formación: </td>
                        <td width="100%">
                            <input type="text" id="fechaelaboracion" name="fechaelaboracion" class="width-100 TextBox datepicker" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td width="100%" colspan="2">
            <table width="100%">
                <tr>
                    <td width="30%">No. Horas virtuales por red: </td>
                    <td width="70%">
                        <input type="text" id="nohoras" name="nohoras" class="width-100 TextBox" style="width:50px;" onkeypress="return isNumberKey(event);" /></td>
                </tr>
            </table>
        </td>
    </tr>
        <tr>
      
            <table>
       <td width="30%">Hora de formación virtual en la Sede: </td>
       <td width="0%">
            <td width="23%">
                <table width="100%">
                    <tr>
                        <td width="50%">Hora Inicial:</td>
                        <td width="100%">
                            <select class="TextBox width-50" name="horasesion" id="horasesion">
                                <option value="">Seleccione hora</option>
                                <option value="00:00">00:00</option>
                                <option value="00:15">00:15</option>
                                <option value="00:30">00:30</option>
                                <option value="00:45">00:45</option>

                                <option value="01:00">01:00</option>
                                <option value="01:15">01:15</option>
                                <option value="01:30">01:30</option>
                                <option value="01:45">01:45</option>

                                <option value="02:00">02:00</option>
                                <option value="02:15">02:15</option>
                                <option value="02:30">02:30</option>
                                <option value="02:45">02:45</option>

                                <option value="03:00">03:00</option>
                                <option value="03:15">03:15</option>
                                <option value="03:30">03:30</option>
                                <option value="03:45">03:45</option>

                                <option value="04:00">04:00</option>
                                <option value="04:15">04:15</option>
                                <option value="04:30">04:30</option>
                                <option value="04:45">04:45</option>

                                <option value="05:00">05:00</option>
                                <option value="05:15">05:15</option>
                                <option value="05:30">05:30</option>
                                <option value="05:45">05:45</option>

                                <option value="06:00">06:00</option>
                                <option value="06:15">06:15</option>
                                <option value="06:30">06:30</option>
                                <option value="06:45">06:45</option>

                                <option value="07:00">07:00</option>
                                <option value="07:15">07:15</option>
                                <option value="07:30">07:30</option>
                                <option value="07:45">07:45</option>

                                <option value="08:00">08:00</option>
                                <option value="08:15">08:15</option>
                                <option value="08:30">08:30</option>
                                <option value="08:45">08:45</option>

                                <option value="09:00">09:00</option>
                                <option value="09:15">09:15</option>
                                <option value="09:30">09:30</option>
                                <option value="09:45">09:45</option>

                                <option value="10:00">10:00</option>
                                <option value="10:15">10:15</option>
                                <option value="10:30">10:30</option>
                                <option value="10:45">10:45</option>

                                <option value="11:00">11:00</option>
                                <option value="11:15">11:15</option>
                                <option value="11:30">11:30</option>
                                <option value="11:45">11:45</option>

                                <option value="12:00">12:00</option>
                                <option value="12:15">12:15</option>
                                <option value="12:30">12:30</option>
                                <option value="12:45">12:45</option>

                                <option value="13:00">13:00</option>
                                <option value="13:15">13:15</option>
                                <option value="13:30">13:30</option>
                                <option value="13:45">13:45</option>

                                <option value="14:00">14:00</option>
                                <option value="14:15">14:15</option>
                                <option value="14:30">14:30</option>
                                <option value="14:45">14:45</option>

                                <option value="15:00">15:00</option>
                                <option value="15:15">15:15</option>
                                <option value="15:30">15:30</option>
                                <option value="15:45">15:45</option>

                                <option value="16:00">16:00</option>
                                <option value="16:15">16:15</option>
                                <option value="16:30">16:30</option>
                                <option value="16:45">16:45</option>

                                <option value="17:00">17:00</option>
                                <option value="17:15">17:15</option>
                                <option value="17:30">17:30</option>
                                <option value="17:45">17:45</option>

                                <option value="18:00">18:00</option>
                                <option value="18:15">18:15</option>
                                <option value="18:30">18:30</option>
                                <option value="18:45">18:45</option>

                                <option value="19:00">19:00</option>
                                <option value="19:15">19:15</option>
                                <option value="19:30">19:30</option>
                                <option value="19:45">19:45</option>

                                <option value="20:00">20:00</option>
                                <option value="20:15">20:15</option>
                                <option value="20:30">20:30</option>
                                <option value="20:45">20:45</option>

                                <option value="21:00">21:00</option>
                                <option value="21:15">21:15</option>
                                <option value="21:30">21:30</option>
                                <option value="21:45">21:45</option>

                                <option value="22:00">22:00</option>
                                <option value="22:15">22:15</option>
                                <option value="22:30">22:30</option>
                                <option value="22:45">22:45</option>

                                <option value="23:00">23:00</option>
                                <option value="23:15">23:15</option>
                                <option value="23:30">23:30</option>
                                <option value="23:45">23:45</option>

                            </select>
                        </td>
                    </tr>
                </table>
            </td>

       

              <td width="100%">
                  <table>
            <td width="50%">
                <table width="55%">                  
                    <tr>
                        <td width="50%">Hora Final: </td>
                        <td width="100%">
                            <select class="TextBox width-50" name="horasesionfinal" id="horasesionfinal">
                                <option value="">Seleccione hora</option>
                                <option value="00:00">00:00</option>
                                <option value="00:15">00:15</option>
                                <option value="00:30">00:30</option>
                                <option value="00:45">00:45</option>

                                <option value="01:00">01:00</option>
                                <option value="01:15">01:15</option>
                                <option value="01:30">01:30</option>
                                <option value="01:45">01:45</option>

                                <option value="02:00">02:00</option>
                                <option value="02:15">02:15</option>
                                <option value="02:30">02:30</option>
                                <option value="02:45">02:45</option>

                                <option value="03:00">03:00</option>
                                <option value="03:15">03:15</option>
                                <option value="03:30">03:30</option>
                                <option value="03:45">03:45</option>

                                <option value="04:00">04:00</option>
                                <option value="04:15">04:15</option>
                                <option value="04:30">04:30</option>
                                <option value="04:45">04:45</option>

                                <option value="05:00">05:00</option>
                                <option value="05:15">05:15</option>
                                <option value="05:30">05:30</option>
                                <option value="05:45">05:45</option>

                                <option value="06:00">06:00</option>
                                <option value="06:15">06:15</option>
                                <option value="06:30">06:30</option>
                                <option value="06:45">06:45</option>

                                <option value="07:00">07:00</option>
                                <option value="07:15">07:15</option>
                                <option value="07:30">07:30</option>
                                <option value="07:45">07:45</option>

                                <option value="08:00">08:00</option>
                                <option value="08:15">08:15</option>
                                <option value="08:30">08:30</option>
                                <option value="08:45">08:45</option>

                                <option value="09:00">09:00</option>
                                <option value="09:15">09:15</option>
                                <option value="09:30">09:30</option>
                                <option value="09:45">09:45</option>

                                <option value="10:00">10:00</option>
                                <option value="10:15">10:15</option>
                                <option value="10:30">10:30</option>
                                <option value="10:45">10:45</option>

                                <option value="11:00">11:00</option>
                                <option value="11:15">11:15</option>
                                <option value="11:30">11:30</option>
                                <option value="11:45">11:45</option>

                                <option value="12:00">12:00</option>
                                <option value="12:15">12:15</option>
                                <option value="12:30">12:30</option>
                                <option value="12:45">12:45</option>

                                <option value="13:00">13:00</option>
                                <option value="13:15">13:15</option>
                                <option value="13:30">13:30</option>
                                <option value="13:45">13:45</option>

                                <option value="14:00">14:00</option>
                                <option value="14:15">14:15</option>
                                <option value="14:30">14:30</option>
                                <option value="14:45">14:45</option>

                                <option value="15:00">15:00</option>
                                <option value="15:15">15:15</option>
                                <option value="15:30">15:30</option>
                                <option value="15:45">15:45</option>

                                <option value="16:00">16:00</option>
                                <option value="16:15">16:15</option>
                                <option value="16:30">16:30</option>
                                <option value="16:45">16:45</option>

                                <option value="17:00">17:00</option>
                                <option value="17:15">17:15</option>
                                <option value="17:30">17:30</option>
                                <option value="17:45">17:45</option>

                                <option value="18:00">18:00</option>
                                <option value="18:15">18:15</option>
                                <option value="18:30">18:30</option>
                                <option value="18:45">18:45</option>

                                <option value="19:00">19:00</option>
                                <option value="19:15">19:15</option>
                                <option value="19:30">19:30</option>
                                <option value="19:45">19:45</option>

                                <option value="20:00">20:00</option>
                                <option value="20:15">20:15</option>
                                <option value="20:30">20:30</option>
                                <option value="20:45">20:45</option>

                                <option value="21:00">21:00</option>
                                <option value="21:15">21:15</option>
                                <option value="21:30">21:30</option>
                                <option value="21:45">21:45</option>

                                <option value="22:00">22:00</option>
                                <option value="22:15">22:15</option>
                                <option value="22:30">22:30</option>
                                <option value="22:45">22:45</option>

                                <option value="23:00">23:00</option>
                                <option value="23:15">23:15</option>
                                <option value="23:30">23:30</option>
                                <option value="23:45">23:45</option>

                            </select>
                        </td>
                    </tr>
                </table>
            </td>
                      </table>
                  </td>
           </td>
        </table>

        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombres y apellidos del docente Asesor: </td>
                        <td width="70%">
                            <input type="text" id="nombreapellidorelator" name="nombreapellidorelator" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br/>

    <fieldset>

        <h2 style="display: block; text-align: center">ACOMPAÑAMIENTO VIRTUAL</h2>

        <span>1.  Describa las actividades realizadas para el acompañamiento virtual, destacando aspectos metodológicos y didácticos. (¿De qué manera organizó al grupo?, ¿Qué actividades realizó? Responsables de las actividades)<br />
         
</span><br/>
        <br/>
    
        <cc1:Editor ID="acompanamiento" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
       <h2 style="display: block; text-align: center">HERRAMIENTAS VIRTUALES UTILIZADAS</h2>
        <span>Describa los módulos y herramientas trabajadas en la plataforma Juego gózate la ciencia, puede incluir otras herramientas de apoyo utilizadas.
            <br>

        </span>
        <br>
        <br>
     
        <cc1:Editor ID="herramientas" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
       
         <h2 style="display: block; text-align: center">EVALUACIÓN DE LA SESIÓN
        </h2>
        <span> Describa los aspectos por mejorar, fortalezas y debilidades. </span><br>
        <br>
        <cc1:Editor ID="evaluacionsesion" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
    </fieldset>

    <br>
      
    
 </fieldset>
        <div class="button">
        <%--<a class="btn btn-primary" onclick="$('#listTable').fadeIn(500), $('#formTable').hide(), $('#evidencias').hide(), reset()">Regresar</a>--%>
             <a class="btn btn-primary" onclick="btnregresar()">Regresar</a>
        <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviarestras004('insert');">
       <%-- <a class="btn btn-danger" onclick="uploadImagen()">Subir evidencia</a>--%>
        <%--<asp:Button ID="btnSubirFirmaPop" runat="server" Text="Subir Imagen" CssClass="btn btn-danger" OnClick="btnSubirFirmaPop_Click" />--%>
        <%--<asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar todo" runat="server" OnClick="btnGuardarSede_Click" />--%>
    </div>
    </div>
    
  
    <style type="text/css">
        .button {
            background: rgba(255,255,255,.7);
            bottom:0;
            display:block;
            left: 0;
            padding: 15px;
            position: fixed;
            right: 0;
            text-align:right;
        }
    </style>

       <div id="modificarsesion" style="display:none">
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>Red temática</th>
                    <th>Sesión</th>
                </tr>
            </thead>
            <tbody id="infosesion"></tbody>
        </table>

        <table align="center">
            <tr>
                <td><select id="sesion" class="TextBox">
                    <option value="0" disabled>Seleccione una Sesión</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                    </select></td>
            </tr>
            <tr>
                <td><a onclick="guardarSesion();" class="btn btn-success">Modificar Sesión</a>
                    <a onclick="$('#modificarsesion').hide();$('#formTable').hide();$('#listTable').fadeIn(500)" class="btn btn-primary">Regresar</a>
                </td>
            </tr>
        </table>

    </div>

    
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

