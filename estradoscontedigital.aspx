<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estradoscontedigital.aspx.cs" Inherits="estradoscontedigital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

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
	        dateFormat: 'yy-mm-dd',
	        firstDay: 1,
	        isRTL: false,
	        showMonthAfterYear: false,
	        yearSuffix: ''
	    };
	    $.datepicker.setDefaults($.datepicker.regional['es']);
		
	    var codigoinstrumento;
	    $(document).ready(function () {

	        listar();
	        areas();
	        cargaranio();

	        $("input[type='datetime']").datepicker({changeYear: true, changeMonth: true });
	        
	        //Cargar departamento
	        $.ajax({

	            type: 'POST',
	            url: 'estradoscontedigital.aspx/cargarDepartamentoMagdalena',
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
	                    url: 'estradoscontedigital.aspx/cargarMunicipios',
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

	            $("#institucion").html("");
	            $("#municipio").html("");
	            $("#sede").html("");
	            var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
	            $.ajax({
	                type: 'POST',
	                url: 'estradoscontedigital.aspx/cargarMunicipios',
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
	            $("#institucion").html("");
	            $("#sede").html("");
	            var codMunicipio = $("#municipio").val();
	            var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
	            $.ajax({
	                type: 'POST',
	                url: 'estradoscontedigital.aspx/cargarInstituciones',
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
	                url: 'estradoscontedigital.aspx/cargarSedesxInstitucion',
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

	        //cargando áreas del curriculo
	        $("#areas").on("change", function () {

	            if ($("#areas").val() == "Otra") {
	                $("#txtotra").fadeIn(500);
	            }
	            else {
	                $("#txtotra").hide();
	                $("#txtotra").val("");
	            }
	        });

	    });

	    function btnnuevo() {
	        $("#table").hide();
	        $("#form").fadeIn(500);
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();

	        cargaranio();

	        var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
	        $.ajax({
	            type: 'POST',
	            url: 'estradoscontedigital.aspx/cargarMunicipios',
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

	    function btnregresar() {
	        $("#form").hide();
	        $("#table").fadeIn(500);
	        reset();
	        listar();
	        areas();
	       
	    }

	    function reset() {
	        $("#sede").html("");
	        $("#institucion").html("");
	        $("#sede").html("");
	        $("#municipio").val("");
	        $("#anio").val("");
	        $("#txtotra").val("");
            $("#txtotra").hide();
            $("#areas").val("");
	        $("#docentes tbody").html("");
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();
	    }

	    function listar() {
	        $.ajax({
	            type: 'POST',
	            url: 'estradoscontedigital.aspx/listar',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (json) {
	                $("#tbody").html(json.d);
	            }
	        });
	    }

	    function cargaranio() {
	            $.ajax({
	                type: 'POST',
	                url: 'estradoscontedigital.aspx/cargaranios',
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

	    function areas() {
	        $.ajax({
	            type: 'POST',
	            url: 'estradoscontedigital.aspx/cargarareas',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (json) {
	                var resp = json.d.split("@");
	                if (resp[0] === "area") {
	                    $("#areas").html(resp[1]);
	                }
	            }
	        });
	    }

	    function btnbuscar() {
	        if ($.trim($("#areas").val()) == "") {
	            $("#areas").focus();
	            alert('Por favor seleccione un Área del currículo');
	        } else {
	            var jsonData = "{'codanio':'" + $("#anio").val() + "', 'codsede':'" + $("#sede").val() + "'}";
	            $.ajax({
	                type: 'POST',
	                url: 'estradoscontedigital.aspx/buscar',
	                contentType: "application/json; charset=utf-8",
	                dataType: "json",
	                data: jsonData,
	                success: function (json) {
	                    $("#docentes tbody").html(json.d);
	                    $("#btn-guardar").show();
	                }
	            });
	        }
           
        }

        function btnguardar(event) {

            if ($("#anio").val() == "") {
                alert("Por favor seleccione un año");
                $("#anio").focus();
            } else if ($.trim($("#tematica").val()) == "") {
                alert("Por favor digite la temática");
                $("#tematica").focus();
            } else {

                //var jsonData = "{'codsede':'" + $("#sede").val() + "','codintroieparea':'" + $("#areas").val() + "', 'txtotra':'" + $("#txtotra").val() + "'}";
                var jsonData = "{'codanio':'" + $("#anio").val() + "','tematica':'" + $("#tematica").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estradoscontedigital.aspx/encabezado',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("_insert@");
                        if (resp[0] === "true") {
                            //guardardetalle(resp[1]);
                        }
                    },
                    complete: function () {
                        alert("Datos guardados exitosamente.");
                        btnregresar();
                    }
                });

            }
       }

        function guardardetalle(codencabezado) {

            var i = 1;
            $("#docentes tbody tr").each(function (index, elem) {
                var campo1, campo3;

                if ($("#chkdoc_" + i).is(':checked')) {
                    $(this).children("td").each(function (index2, elem2) {

                        switch (index2) {
                            case 1:
                                campo1 = $(this).text();
                                console.log("identificacion: " + campo1);
                                break;
                            case 3:
                                campo3 = $(elem2).children("input").val();
                                console.log("chk_: " + campo3);
                                break;
                        }
                    });

                    var jsonData = "{'codencabezado':'" + codencabezado + "', 'codgradodocente':'" + campo3 + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'estradoscontedigital.aspx/inasistenciadocentes',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            console.log(json.d);
                        }
                    });
                }

                i = i + 1;
            });

           
        }

        function loadinstrumento(codigo) {
            var jsonData = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estradoscontedigital.aspx/load',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");
                    if (resp[0] === "true") {
                        $("#municipio").html(resp[1]);
                        $("#institucion").html(resp[2]);
                        $("#sede").html(resp[3]);
                        $("#areas").html(resp[4]);

                        $("#btn-guardar").hide();
                        //$('#btn-guardar').attr('value', 'Actualizar');
                        //$('#btn-guardar').attr('onclick', 'btnguardar(\'update\')');
                        $("#table").hide();
                        $("#form").fadeIn(500);
                        $("#btnbuscar").hide();

                        buscardocentes(codigo);
                    }
                }
            });
        }

        function buscardocentes(codigo) {
            var jsonData = "{'codigo':'" + codigo + "'}";

            $.ajax({
                type: 'POST',
                url: 'estradoscontedigital.aspx/buscardocentes',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");
                    if (resp[0] === "true") {
                        $("#anio").html(resp[1]);
                        $("#docentes tbody").html(resp[2]);
                        
                      
                    }
                }
            });
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estradoscontedigital.aspx/delete',
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
    <h2>Contenidos digitales</h2>
  
    <div id="table">
   
     <fieldset >
          <a class="btn btn-primary" id="btn-nuevo" onclick="btnnuevo();" style="float:right">Nuevo registro</a>
         <br /><br />
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Coordinador</th>
                    <th>Fecha</th>
                    <th>Temática</th>
                    <th>Año</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
</div>

     <div id="form" style="display:none;">
        <a class="btn btn-primary" id="btn-regresar" onclick="btnregresar();" style="float:right">Regresar</a><br /><br />
		<fieldset>
		    <legend>DATOS</legend>
		    <table>
                <tr>
                   <td>Año: </td>
                    <td>
                        <select class="TextBox width-100" name="anio" id="anio" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Tématica</td>
                    <td><input id="tematica" class="TextBox width-100" style="width: 500px" /></td>
                </tr>
                <tr>
                    <td> <input type="button" class="btn btn-success" id="btn-guardar" onclick="btnguardar('insert')" value="Guardar" /></td>
                </tr>
                <%--<tr>
                   <td>Departamento: </td>
                    <td>
                        <select class="TextBox width-100" name="departamento" id="departamento" style="width: 250px" disabled="true">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Municipio: </td>
                    <td>
                        <select class="TextBox width-100" name="municipio" id="municipio" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                      <td>Institución Educativa: </td>
                    <td>
                        <select class="TextBox width-100" name="institucion" id="institucion" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Sede Educativa: </td>
                     <td>
                        <select class="TextBox width-100" name="sede" id="sede" style="width: 250px">
                        </select>
                    </td>
                </tr>
                 <tr>
                    <td>Área del currículo: </td>
                     <td>
                        <select class="TextBox width-100" name="areas" id="areas" style="width: 250px">
                        </select>
                         <input class="TextBox" id="txtotra" style="display:none;width: 250px" placeholder="Digite la nueva Área del currículo "  />
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2">
                        <a href="javascript:void(0)" class="btn btn-primary" onclick="btnbuscar()" id="btnbuscar">Buscar</a>
                    </td>
                </tr>--%>
               
              
            </table>
         </fieldset>

         <%-- <fieldset>
             <legend>Sedes</legend>
            <center>
                 Fecha de asistencia<br />
                 <input type="datetime" name="fecha" id="fecha" class="TextBox" />
             </center>
             <br />
              <table class="mGridTesoreria" id="docentes">
                 <thead>
                     <tr>
                         <th>No.</th>
                         <th>Identificación</th>
                         <th>Nombre</th>
                         <th>Asistencia</th>
                     </tr>
                 </thead>
                 <tbody ></tbody>
             </table>--%>
            <%-- <table class="mGridTesoreria">
                 <thead>
                     <tr>
                         <th>No.</th>
                         <th>Identificación</th>
                         <th>Nombre</th>
                         <th>Asistencia</th>
                     </tr>
                 </thead>
                 <tbody id="docentes"></tbody>
             </table>
             <br />
            
         </fieldset>--%>
       </div>
             
</asp:Content>

