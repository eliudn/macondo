<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiapropiaciondptal.aspx.cs" Inherits="confiapropiaciondptal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <style type="text/css">

        .auto-style1 {
            color: #FF0000;
        }

        .dt-button{
              background: #004b96 none repeat scroll 0 0;
                border-radius: 5px;
                color: #fff;
                margin-left: 5px;
                padding: 10px;
        }

        .textos2 {
            font-size: 17px;
            font-weight: bold;
            letter-spacing: 0.5px;
        }

        .cajausuario {
            background-color: #e6e6e6;
            border: 1px solid #d5d5d5;
            border-radius: 5px;
            -moz-border-radius: 5px;
            padding: 3px;
            border-spacing: 5px;
            margin: 2px auto 8px;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
        }

                .border th {
            background: #507cd1;
            color: #fff;
            font-size: 15px;
            padding: 10px;
        }
        .center{
            text-align:center;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
        }
        table.border{
            border-collapse: separate;
            border-spacing: 0;

        }
        table.border td{
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;

        }
         table.border th {
            border: 0px solid;
            margin: 0;
            padding: 10px;
        }
         table.border td,  .border th{
            /*border: 1px solid;*/
            margin: 0;
            padding: 10px !important;
            border-right: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
        }
          table.border td:last-child{
            /*border-right: 0;*/

          }

         
        table.border tr, table.border {
            margin: 0;
            padding: 0;
            /*border: 1px solid #ccc;*/
            background: #fff;
        }

        .width-100 {
            width: 100%;
        }
    </style>

    <script>

        (function ($) {
            $.get = function (key) {
                key = key.replace(/[\[]/, '\\[');
                key = key.replace(/[\]]/, '\\]');
                var pattern = "[\\?&]" + key + "=([^&#]*)";
                var regex = new RegExp(pattern);
                var url = unescape(window.location.href);
                var results = regex.exec(url);
                if (results === null) {
                    return null;
                } else {
                    return results[1];
                }
            }
        })(jQuery);

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
            dateFormat: 'yy-mm-dd',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);

        var modu = [];

        $(document).ready(function () {

            //$('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%"></div>');

            cargaranio();

            $("input[type='datetime']").datepicker({ changeYear: true, changeMonth: true });

            loadData($.get("tipo"));


            var jsondata = "{'codDepartamento': '20'}";
            $.ajax({
                type: 'POST',
                url: 'confiapropiaciondptal.aspx/cargarMunicipios',
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


            //cargando las instituciones
            $("#municipio").on("change", function () {
                $("#institucion").html("");
                $("#sede").html("");
                var codMunicipio = $("#municipio").val();
                var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'confiapropiaciondptal.aspx/cargarInstituciones',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "inst") {
                            $("#institucion").html(resp[1]);
                            //alert(resp[0]);
                        }
                    }
                });
            });

            //cargando sedes educativas
            $("#institucion").on("change", function () {
                var codInstitucion = $("#institucion").val();
                var jsondata = "{'codInstitucion':'" + codInstitucion + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'confiapropiaciondptal.aspx/cargarSedesxInstitucion',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "sede") {
                            $("#sede").html(resp[1]);
                        }
                    }
                });
            });
        });

        function loadData(dataID) {
            var table = $('#tableList').DataTable();
            table.destroy();
            var jsondata = "{'dataID':'" + dataID + "'}";
            $.ajax({
                type: 'POST',
                url: 'confiapropiaciondptal.aspx/loadData',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "full") {
                        $("#tableList tbody").html(resp[1]);
                    }
                }, complete: function () {
                    cargarDataTable();
                    $('.desactivarC1').remove().fadeOut(500);
                }
            });
        }

        //cargando docentes 
        function loadGruposInvestigacion() {
            if ($("#anio").val() == "") {
                alert("Por favor, seleccione Año");
            }else if($("#municipio").val() == ""){
                alert("Por favor, seleccione Municipio");
            }else if($("#institucion").val() == ""){
                alert("Por favor, seleccione Institución educativa");
            } else if ($("#sede").val() == "") {
                alert("Por favor, seleccione Sede educativa");
            } else {
                $("#tbldocentes tbody").html("<tr><td colspan='7'  align='center'>Buscando...</td></tr>");
                var jsonData = '{ "codsede":"' + $("#sede").val() + '", "municipio" : "' + $("#municipio option:selected").text() + '", "institucion" : "' + $("#institucion option:selected").text() + '", "sede" : "' + $("#sede option:selected").text() + '"}';
                $.ajax({
                    type: 'POST',
                    url: 'confiapropiaciondptal.aspx/cargarGrupoInvestigacion',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "full") {
                            $("#tbldocentes tbody").html(resp[1]);
                        } else {
                            $("#tbldocentes tbody").html("<tr><td colspan='7'  align='center'>No se encontraron grupos de investigación</td></tr>");
                        }
                    }, complete: function () {
                    }
                });
            }
        }

        function cargaranio() {
            $.ajax({
                type: 'POST',
                url: 'confiapropiaciondptal.aspx/cargaranios',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "anio") {
                        $("#anio").html(resp[1]);
                    }
                }
            });
        }

        function btnnuevo() {
            $("#table").hide();
            $("#form").fadeIn(500);
            reset();
        }

        function btnregresar() {
            $("#form").hide();
            $("#table").fadeIn(500);
            reset();
            loadData($.get("tipo"));
        }

        function reset() {
            $("#tipoevento").val('');
            $("#fecha").val('');
            $("#horainicio").val('');
            $("#horafin").val('');
            $("#anio").val('');
            $("#municipio").val('');
            $("#institucion").val('');
            $("#sede").val('');
            c$("#tbldocentes tbody").html("<tr><td colspan='7'  align='center'>Realice una búsqueda</td></tr>");
            $("#tbldocentesSeleccionados tbody").html("<tr id=\"no\"><td colspan='7' align='center'>Aún no ha agregado ningún grupo de investigación</td></tr>");
            
            $('#btn-guardar').attr('value', 'Guardar');
            $('#btn-guardar').attr('onclick', 'fevent(\'insert\')');
            
        }

        function cargarDataTable() {
            $('#tableList').DataTable({
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
                    "searching": false,
                    "aaSorting": [[0, 'desc']],
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
                "columns": [ //agregar configuraciones a cada una de las columnas de las tablas
                      { "orderable": false },//column 1
                      { "orderable": false },//column 2
                      { "orderable": false },//column 3
                      { "orderable": false },//column 4
                      { "orderable": false },//column 5
                      { "orderable": false },//column 6
                      { "orderable": false },//column 6
                      { "orderable": false }//column 6
                ]
            });

        }

        function seleccionar() {
            var total = $("input[name='chkGrupo']:checked").length;
                if (total >= 1) {
                    $("input[name=chkGrupo").each(function (index) {

                        if ($(this).is(':checked')) {

                            var index = modu.indexOf($(this).val());

                            if (index == -1) {
                                modu.push($(this).val());
                                var html = "";
                                html += "<tr id='tr" + $(this).val() + "'>";
                                for (var i = 0; i < 5; i++) {
                                    html += "<td>" + $(this).parents("tr").find("td").eq(i).text() + "</td>";
                                    if (i == 4) {
                                        html += "<td align='center'><img src='Imagenes/delete.png' alt='Eliminar docente' onclick='deletee(" + $(this).val() + ")' /></td>";
                                    }
                                }
                                html += "</tr>";
                                $("#no").remove();
                                $("#tbldocentesSeleccionados tbody").append(html);
                            } else {
                                alert("Grupo " + $(this).val() + " ya fué agregado");
                            }


                        }
                    });

                    console.log(modu.length);
                } else {
                    alert("debe seleccionar mínimo un grupo de investigación");
                }

        }

        function deletee(dataID) {
            $("#tr" + dataID).remove();
            var index = modu.indexOf(dataID);
            modu.splice(index, 1);
            console.log(modu.length);
            if (modu.length == 0) {
                $("#tbldocentesSeleccionados tbody").append("<tr id='no'><td colspan='7' align='center'>Aún no ha agregado ningún grupo de investigación</td></tr>");
            }
        }


        function fevent(dataEV) {
            if ($("#anio").val() == "") {
                alert("Por favor, seleccione el año");
            } else if (modu.length == 0) {
                alert("Por favor, seleccione por lo menos un grupo de investigación");
            } else {
                $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%"></div>');
                if (dataEV == 'insert') {

                    var k = 0;
                    $.each(modu, function (index, contenido) {
                        var jsonData2 = '{ "tipo":"' + $.get("tipo") + '", "anio" : "' + $("#anio").val() + '", "codgrupo" : "' + contenido + '"}';
                        $.ajax({
                            type: 'POST',
                            url: 'confiapropiaciondptal.aspx/insertEspacioApropiacion',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: jsonData2,
                            success: function (json) {
                                var resp = json.d.split("@");
                                if (resp[0] === "true") {

                                } else {
                                    console.log("error al insertar docente " + contenido);
                                }
                            }, complete: function () {
                                k++;

                                if (k == modu.length) {
                                    alert("Guardado exitoso");
                                    loadData($.get("tipo"));
                                    btnregresar();
                                }
                            }
                        });
                    });

                } else if (dataEV == 'update') {


                    var jsondata2 = "{'codencabezado':'" + $("#codencabezado").val() + "', 'tipoevento':'" + $("#tipoevento").val() + "', 'fecha':'" + $("#fecha").val() + "', 'horainicio':'" + $("#horainicio").val() + "',  'horafin':'" + $("#horafin").val() + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'confiapropiaciondptal.aspx/update',
                        data: jsondata2,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {

                                //alert("true");
                                var jsondata2 = "{'codencabezado':'" + $("#codencabezado").val() + "'}";
                                $.ajax({
                                    type: 'POST',
                                    url: 'confiapropiaciondptal.aspx/deleteDocentesSeleccionado',
                                    data: jsondata2,
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (json) {
                                        var resp = json.d.split("@");
                                        if (resp[0] === "true") {

                                            var k = 0;
                                            console.log(modu);
                                            $.each(modu, function (index, contenido) {
                                                var jsonData2 = '{ "codencabezado":"' + $("#codencabezado").val() + '", "codgradodocente" : "' + contenido + '"}';
                                                $.ajax({
                                                    type: 'POST',
                                                    url: 'confiapropiaciondptal.aspx/insertDocentes',
                                                    contentType: "application/json; charset=utf-8",
                                                    dataType: "json",
                                                    data: jsonData2,
                                                    success: function (json) {
                                                        var resp = json.d.split("@");
                                                        if (resp[0] === "true") {

                                                        } else {
                                                            console.log("error al insertar docente " + contenido);
                                                        }
                                                    }, complete: function () {
                                                        k++;

                                                        if (k == modu.length) {
                                                            alert("Guardado exitoso");
                                                            $('.desactivarC1').remove().fadeOut(500);
                                                            btnregresar();
                                                        }
                                                    }
                                                });
                                            });

                                        } else {
                                            alert(json.d);
                                            $('.desactivarC1').remove().fadeOut(500);
                                        }
                                    }, complete: function () {
                                    }
                                });

                            } else {
                                alert(json.d);
                                $('.desactivarC1').remove().fadeOut(500);
                            }
                        }, complete: function () {
                        }
                    });


                } else {
                    alert("error");
                }
            }
        }


        function fedit(cod) {
            var jsondata = "{'cod':'" + cod + "'}";
            $.ajax({
                type: 'POST',
                url: 'confiapropiaciondptal.aspx/loaddetallesevento',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "full") {
                        
                        $("#codencabezado").val(resp[1]);
                        $("#tipoevento").val(resp[2]);
                        $("#fecha").val(resp[3]);
                        $("#horainicio").val(resp[4]);
                        $("#horafin").val(resp[5]);

                        var jsondata2 = "{'codencabezado':'" + $("#codencabezado").val() + "'}";
                        $.ajax({
                            type: 'POST',
                            url: 'confiapropiaciondptal.aspx/cargarDocentesSeleccionados',
                            data: jsondata2,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (json) {
                                var resp = json.d.split("@");
                                if (resp[0] === "full") {

                                    $("#tbldocentesSeleccionados tbody").html(resp[1]);


                                    var ids = resp[2].split("&");
                                    modu = [];
                                    for (var i = 0; i < ids.length - 1; i++) {
                                        modu.push(ids[i]);
                                    }
                                    console.log(modu);
                                    

                                }
                            }, complete: function () {

                                $("#table").hide();
                                $("#form").show();
                                $('#btn-guardar').attr('value', 'Actualizar');
                                $('#btn-guardar').attr('onclick', 'fevent(\'update\')');
                            }
                        });

                    }
                }, complete: function () {

                    
                }
            });
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";

                $.ajax({
                    type: 'POST',
                    url: 'confiapropiaciondptal.aspx/eliminar',
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        console.log(json.d);
                    }, complete: function () {
                        alert("eliminado correctamente");
                        loadData($.get("tipo"));
                    }
                });

                
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Apropiación <asp:Label ID="lblApropiacion" runat="server" Visible="true"></asp:Label></h2>
    <asp:Label ID="lblCodApropiacion" runat="server" Visible="false"></asp:Label>

    
        <div id="table">
            <fieldset>
                 <a class="btn btn-primary" id="btn-nuevo" onclick="btnnuevo();" style="float:right">Nuevo registro</a><br />
                 <br />
             <legend>Listado de registro</legend>
                 <table width="100%" class="border" id="tableList">
                     <thead>
		                <tr>
                            <th>No.</th>
                            <th>Año</th>
		                    <th>Municipio</th>
                            <th>Institución</th>
                            <th>Sede</th>
                            <th>Grupo de investigación</th>
                            <th>Línea temática</th>
                            <th>Acciones</th>
		                </tr>
                    </thead>
                     <tbody>
                     </tbody>
	            </table>
      
             </fieldset>
        </div>
     
        
    <div id="form" style="display:none;">
        
        <a class="btn btn-primary" id="btn-regresar" onclick="btnregresar();" style="float:right">Regresar</a><br /><br />
		
        <fieldset>
            <legend>GRUPOS DE INVESTIGACIÓN</legend>
            <table>
                <tr>
                   <td>Año: </td>
                    <td>
                        <select class="TextBox width-100" name="anio" id="anio">
                            <option value="">Seleccione año</option>
                        </select>
                    </td>
                </tr>
                <tr>
                   <td>Municipio: </td>
                    <td>
                        <select class="TextBox width-100" name="municipio" id="municipio">
                            </select>
                    </td>
                </tr>
                <tr>
                   <td>Institución educativa: </td>
                    <td>
                        <select class="TextBox width-100" name="institucion" id="institucion">
                            </select>
                        
                    </td>
                </tr>
                <tr>
                   <td>Sede educativa: </td>
                    <td>
                        <select name="sede" id="sede" class="width-100 TextBox">
                            </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a class="btn btn-primary" onclick="loadGruposInvestigacion();" style="float:right">Buscar</a>
                    </td>
                </tr>
            </table>
            <br />
            <br />
           <div style="">

               <table width="100%" class="border" id="tbldocentes">
                     <thead>
		                <tr>
                            <th>No.</th>
                            <th>Municipio</th>
                            <th>Institución educativa</th>
                            <th>Sede educativa</th>
		                    <th>Grupo de investigación</th>
                            <th>Agregar</th>
		                </tr>
                    </thead>
                     <tbody>
                         <tr><td colspan='6'  align='center'>Realice una búsqueda</td></tr>
                     </tbody>
	            </table>
               <br />

           </div>
            <a class="btn btn-success"  onclick="seleccionar();" style="float:right">Seleccionar</a>
            <br />
            <br />
             <div style="">
                 <h1 style="font-size: 20px;background: #507cd1;padding: 10px;color: #fff;">Grupos seleccionados</h1>
               <table width="100%" class="border" id="tbldocentesSeleccionados">
                     <thead>
		                <tr>
                            <th>No.</th>
                            <th>Municipio</th>
                            <th>Institución educativa</th>
                            <th>Sede educativa</th>
		                    <th>Grupo de investigación</th>
                            <th>Eliminar</th>
		                </tr>
                    </thead>
                     <tbody>
                         <tr id="no"><td colspan='7' align='center'>Aún no ha agregado ningún Grupo de investigación</td></tr>
                     </tbody>
	            </table>
           </div>

            <br />
            <br />
            
            
            <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="fevent('insert'); ">           

            
        </fieldset>
    </div>
   
</asp:Content>




