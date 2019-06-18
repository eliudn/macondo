<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunoentregarecursosgrupos.aspx.cs" Inherits="estraunoentregarecursosgrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

     <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />

    <script>
        var table;
        function cargarDataTable() {
            table = $('#infotbody').DataTable({
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
		
	    var codigoinstrumento;
	    var coddesembolso1; var coddesembolso2; var coddesembolso3;
	    var desembolso1; var desembolso2; var desembolso3;
	    var codproyecto;
	    var primero;
	    var segundo;
	    var tercero;
	    $(document).ready(function () {

	        listar();
	        //cargaranio();

	        $("input[type='datetime']").datepicker({changeYear: true, changeMonth: true });
	        
	        //Cargar departamento
	        $.ajax({

	            type: 'POST',
	            url: 'estraunoentregarecursosgrupos.aspx/cargarDepartamentoMagdalena',
	            contentType: 'application/json; charset=utf-8',
	            dataType: 'JSON',
	            success: function (response) {
	                var resp = response.d.split("@");
	                if (resp[0] === "departamento") {
	                    $("#departamento").html(resp[1]);
	                }
	            }, complete: function () {
	                $("#institucion").html("");
	                $("#municipio").html("");
                    
	                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
	                $.ajax({
	                    type: 'POST',
	                    url: 'estraunoentregarecursosgrupos.aspx/cargarMunicipios',
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
	            }
	        });

	        $("#departamento").on("change", function () {

	            //$("#institucion").html("");
	            $("#municipio").html("");
	            //$("#sede").html("");
	            var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
	            $.ajax({
	                type: 'POST',
	                url: 'estraunoentregarecursosgrupos.aspx/cargarMunicipios',
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
	        //$("#municipio").on("change", function () {
	        //    $("#institucion").html("");
	        //    $("#sede").html("");
	        //    var codMunicipio = $("#municipio").val();
	        //    var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
	        //    $.ajax({
	        //        type: 'POST',
	        //        url: 'estraunoentregarecursosgrupos.aspx/cargarInstituciones',
	        //        data: jsondata,
	        //        contentType: "application/json; charset=utf-8",
	        //        dataType: "json",
	        //        success: function (json) {
	        //            var resp = json.d.split("@");
	        //            if (resp[0] === "inst") {
	        //                $("#institucion").html(resp[1]);
	        //                //alert(resp[0]);
	        //            }
	        //        }
	        //    });
	        //});

	        //cargando sedes educativas
	        //$("#institucion").on("change", function () {
	        //    var codInstitucion = $("#institucion").val();
	        //    var jsondata = "{'codInstitucion':'" + codInstitucion + "'}";
	        //    $.ajax({
	        //        type: 'POST',
	        //        url: 'estraunoentregarecursosgrupos.aspx/cargarSedesxInstitucion',
	        //        data: jsondata,
	        //        contentType: "application/json; charset=utf-8",
	        //        dataType: "json",
	        //        success: function (json) {
	        //            var resp = json.d.split("@");
	        //            if (resp[0] === "sede") {
	        //                $("#sede").html(resp[1]);
	        //            }
	        //        }
	        //    });
	        //});

	    });

	    function btnnuevo() {
	        $("#infotable").hide();
	        $("#form").fadeIn(500);
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();
	    }

	    function btnregresar() {
	        $("#form").hide();
	        $("#infotable").fadeIn(500);
	        reset();
	    }

	    function reset() {
	        //$("#sede").html("");
	        //$("#institucion").html("");
	        //$("#sede").html("");
	        $("#municipio").val("");
	        //$("#anio").val("");
	        $("#sedes tbody").html("");
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();
	    }

	    function listar() {
	        $.ajax({
	            type: 'POST',
	            url: 'estraunoentregarecursosgrupos.aspx/listar',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (json) {
	                $("#infotbody tbody").html(json.d);
	            }, complete: function(){
	                cargarDataTable();
	            }
	        });
	    }

	    //function cargaranio() {
	    //        $.ajax({
	    //            type: 'POST',
	    //            url: 'estraunoentregarecursosgrupos.aspx/cargaranios',
	    //            contentType: "application/json; charset=utf-8",
	    //            dataType: "json",
	    //            success: function (json) {
	    //                var resp = json.d.split("@");
	    //                if (resp[0] === "anio") {
	    //                    $("#anio").html(resp[1]);
	    //                }
	    //            }
	    //        });
	    //}

        //function btnbuscar() {
        //    //var jsonData = "{'codanio':'" + $("#anio").val() + "', 'codsede':'" + $("#sede").val() + "'}";
        //    var jsonData = "{'codmunicipio':'" + $("#municipio").val() + "', 'codanio':'" + $("#anio").val() + "'}";
	    //    $.ajax({
	    //        type: 'POST',
	    //        url: 'estraunoentregarecursosgrupos.aspx/buscar',
	    //        contentType: "application/json; charset=utf-8",
	    //        dataType: "json",
	    //        data: jsonData,
	    //        success: function (json) {
	    //            $("#sedes tbody").html(json.d);
	    //            $("#btn-guardar").show();
	    //        }
	    //    });
        //}

	    function primerdesembolso() {
	        var jsondata = "{'codproyecto': '" + codproyecto + "', 'radiobutton': '" + $('input:radio[name=rbprimer]:checked').val() + "', 'fechainicio': '" + $("#fechainicioprimer").val() + "', 'fechafin': '" + $("#fechafinprimer").val() + "', 'desembolso':'1'}";
	        $.ajax({
	            type: 'POST',
	            url: 'estraunoentregarecursosgrupos.aspx/guardarentrega',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsondata,
	            success: function (json) {
	                var resp = json.d.split("_insert@");
	                if (resp[0] === "true") {
	                    console.log("primer");
	                    primero = resp[1];
	                } else {
	                    alert(resp[1]);
	                    primero = resp[2];
	                }
	            }, complete: function () {
	                segundodesembolso();
	            }
	        });
	    }

	    function segundodesembolso() {
	        var jsondata = "{'codproyecto': '" + codproyecto + "', 'radiobutton': '" + $('input:radio[name=rbsegundo]:checked').val() + "', 'fechainicio': '" + $("#fechainiciosegundo").val() + "', 'fechafin': '" + $("#fechafinsegundo").val() + "', 'desembolso':'2'}";
	        $.ajax({
	            type: 'POST',
	            url: 'estraunoentregarecursosgrupos.aspx/guardarentrega',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsondata,
	            success: function (json) {
	                var resp = json.d.split("_insert@");
	                if (resp[0] === "true") {
	                    console.log("segundo");
	                    segundo = resp[1];
	                } else {
	                    alert(resp[1]);
	                    segundo = resp[2];
	                }
	            }, complete: function () {
	                tercerdesembolso();
	            }
	        });
	    }

	    function tercerdesembolso() {
	        var jsondata = "{'codproyecto': '" + codproyecto + "', 'radiobutton': '" + $('input:radio[name=rbtercer]:checked').val() + "', 'fechainicio': '" + $("#fechainiciotercer").val() + "', 'fechafin': '" + $("#fechafintercer").val() + "', 'desembolso':'3'}";
	        $.ajax({
	            type: 'POST',
	            url: 'estraunoentregarecursosgrupos.aspx/guardarentrega',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsondata,
	            success: function (json) {
	                var resp = json.d.split("_insert@");
	                if (resp[0] === "true") {
	                    console.log("tercero");
	                    tercero = resp[1];
	                } else {
	                    alert(resp[1]);
	                    tercero = resp[2];
	                }
	            }, complete: function () {
	                //alert("primero:" + primero + ", segundo: " + segundo + ", tercero: " + tercero);
	                if (primero === "Si" && segundo === "Si" && tercero === "Si") {
	                    alert("Registros guardados correctamente");
	                    window.location.href = "estraunoentregarecursosgrupos.aspx";
	                }
	                else {
	                    table.destroy();
	                    window.location.href = "estraunoentregarecursosgrupos.aspx";
	                }
	            }
	        });
	    }

	    function btnguardar(event) {

	        primerdesembolso();
	  
        }

        function loadinstrumento(codproyectosede, nombregrupo) {
            codproyecto = codproyectosede;
            $("#nomgrupo tbody").html("<tr><td><b>GRUPO: </b>" + nombregrupo + "</td></td>");
            var jsonData = "{'codproyectosede':'" + codproyectosede + "'}";
            $.ajax({
                type: 'POST',
                url: 'estraunoentregarecursosgrupos.aspx/load',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");
                    if (resp[0] === "true" && resp[6] === "1") {

                        //$("#nomgrupo").html(resp[1]);
                        $("#fechainicioprimer").val(resp[2]);
                        $("#fechafinprimer").val(resp[3]);
                        if (resp[4] === "Si") {
                            $("#rbprimer_si").attr('checked', true);
                        } else if (resp[4] === "No") {
                            $("#rbprimer_no").attr('checked', true);
                        }
                        coddesembolso1 = resp[5];
                        desembolso1 = resp[6];

                        $("#btn-guardar").show();
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'btnguardar(\'update\')');
                    }
                    else {
                        $("#fechainicioprimer").val("");
                        $("#fechafinprimer").val("");
                        $("#rbprimer_no").attr('checked', true);
                    }

                    if (resp[7] === "true" && resp[13] === "2") {
                        //$("#nomgrupo").html(resp[8]);
                        $("#fechainiciosegundo").val(resp[9]);
                        $("#fechafinsegundo").val(resp[10]);
                        if (resp[11] === "Si") {
                            $("#rbsegundo_si").attr('checked', true);
                        } else if (resp[11] === "No") {
                            $("#rbsegundo_no").attr('checked', true);
                        }
                        coddesembolso2 = resp[12];
                        desembolso2 = resp[13];

                       
                       
                    }
                    else {
                        $("#fechainiciosegundo").val("");
                        $("#fechafinsegundo").val("");
                        $("#rbsegundo_no").attr('checked', true);
                    }

                    if (resp[14] === "true" && resp[20] === "3") {
                        //$("#nomgrupo").html(resp[15]);
                        $("#fechainiciotercer").val(resp[16]);
                        $("#fechafintercer").val(resp[17]);
                        if (resp[18] === "Si") {
                            $("#rbtercer_si").attr('checked', true);
                        } else if (resp[18] === "No") {
                            $("#rbtercer_no").attr('checked', true);
                        }
                        coddesembolso3 = resp[19];
                        desembolso3 = resp[20];

                      
                    } else {
                        $("#fechainiciotercer").val("");
                        $("#fechafintercer").val("");
                        $("#rbtercer_no").attr('checked', true);
                    }
                    $("#infotable").hide();
                    $("#form").fadeIn(500);

                    if (resp[21] === "20") {
                        $("#btn-guardar").hide();
                    } else {
                        $("#btn-guardar").show();
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'btnguardar(\'update\')');
                    }
                }
            });
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estraunoentregarecursosgrupos.aspx/delete',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        alert('Registro eliminado correctamente.');
                        btnregresar();
                        listar();
                    }
                });
            }

        }

        function isNumberKey(e) {
            var charCode = (e.which) ? e.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 75))
                return false;
            return true;
        }
        </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <br /><br />
    <h2>Entrega de recursos a grupos <asp:Label runat="server" ID="lblSesion" Visible="false"> </asp:Label></h2>
  
    <div id="infotable">
   
     <fieldset >
          <%--<a class="btn btn-primary" id="btn-nuevo" onclick="btnnuevo();" style="float:right">Nuevo registro</a>--%>
         <br /><br />
         <table id="infotbody"  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Institución</th>
                    <th>Sede</th>
                    <th>Grupo <br /> investigación</th>
                    <th></th>
                </tr>
            </thead>
            <tbody >
                <tr><td colspan="10" align="center"><img src="images/loader.gif" alt="" /></td></tr>
            </tbody>
        </table>
    </fieldset>
</div>

     <div id="form" style="display:none" >
        <a class="btn btn-primary" id="btn-regresar" onclick="btnregresar();" style="float:right">Regresar</a><br /><br />
		<fieldset>
		    <legend>Desembolsos</legend>
            <table id="nomgrupo" align="center"><tbody></tbody></table>
		    <table id="desembolsos" class="mGridTesoreria">
                <tr>
                    <th></th>
                    <th>Recibió desembolso</th>
                    <th>Fecha inicio</th>
                    <th>Fecha fin</th>
              </tr>
              <tr>
                  <th>Primer desembolso</th>
                  <td align="center"><input type="radio" id="rbprimer_si" name="rbprimer" value="Si" />Si <input type="radio" id="rbprimer_no" name="rbprimer" value="No" checked />No</td>
                  <td><input type="datetime" class="TextBox" id="fechainicioprimer" style="width:100px;"  /></td>
                  <td><input type="datetime" class="TextBox" id="fechafinprimer" style="width:100px;" /></td>
             </tr>
              <tr>
                  <th>Segundo desembolso</th>
                  <td align="center"><input type="radio" id="rbsegundo_si" name="rbsegundo" value="Si" />Si <input type="radio" id="rbsegundo_no" name="rbsegundo" value="No" checked />No</td>
                  <td><input type="datetime" class="TextBox" id="fechainiciosegundo" style="width:100px;"  /></td>
                  <td><input type="datetime" class="TextBox" id="fechafinsegundo" style="width:100px;" /></td>
             </tr>
              <tr>
                  <th>Tercer desembolso</th>
                  <td align="center"><input type="radio" id="rbtercer_si" name="rbtercer" value="Si" />Si <input type="radio" id="rbtercer_no" name="rbtercer" value="No" checked />No</td>
                  <td><input type="datetime" class="TextBox" id="fechainiciotercer" style="width:100px;"  /></td>
                  <td><input type="datetime" class="TextBox" id="fechafintercer" style="width:100px;" /></td>
              </tr>
             </table>
          
             <br />
             <center><input type="button" class="btn btn-success" id="btn-guardar" onclick="btnguardar('insert')" value="Guardar" /></center>
         </fieldset>
       </div>
             
</asp:Content>

