<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estradossesionvirtual.aspx.cs" Inherits="estradossesionvirtual" %>

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
	        cargaranio();

	        $("input[type='datetime']").datepicker({changeYear: true, changeMonth: true });
	        
	        //Cargar departamento
	        $.ajax({

	            type: 'POST',
	            url: 'estradossesionvirtual.aspx/cargarDepartamentoMagdalena',
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
	                    url: 'estradossesionvirtual.aspx/cargarMunicipios',
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
	                url: 'estradossesionvirtual.aspx/cargarMunicipios',
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
	                url: 'estradossesionvirtual.aspx/cargarInstituciones',
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
	        //$("#institucion").on("change", function () {
	        //    var codInstitucion = $("#institucion").val();
	        //    var jsondata = "{'codInstitucion':'" + codInstitucion + "'}";
	        //    $.ajax({
	        //        type: 'POST',
	        //        url: 'estradossesionvirtual.aspx/cargarSedesxInstitucion',
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
	        $("#table").hide();
	        $("#form").fadeIn(500);
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();
	    }

	    function btnregresar() {
	        $("#form").hide();
	        $("#table").fadeIn(500);
	        reset();
	    }

	    function reset() {
	        //$("#sede").html("");
	        //$("#institucion").html("");
	        //$("#sede").html("");
	        $("#municipio").val("");
	        $("#anio").val("");
	        $("#sedes tbody").html("");
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();
	    }

	    function listar() {
	        $.ajax({
	            type: 'POST',
	            url: 'estradossesionvirtual.aspx/listar',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (json) {
	                var dat = json.d.split("encontro@");
	                $("#sedes2 tbody").html(dat[1]);
	                if (dat[1] == "20") {
	                    $("#btn-guardar").hide();
	                }
	            }
	        });
	    }

	    function cargaranio() {
	            $.ajax({
	                type: 'POST',
	                url: 'estradossesionvirtual.aspx/cargaranios',
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

        function btnbuscar() {
            //var jsonData = "{'codanio':'" + $("#anio").val() + "', 'codsede':'" + $("#sede").val() + "'}";
            var jsonData = "{'codmunicipio':'" + $("#municipio").val() + "', 'codanio':'" + $("#anio").val() + "'}";
	        $.ajax({
	            type: 'POST',
	            url: 'estradossesionvirtual.aspx/buscar',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            data: jsonData,
	            success: function (json) {
	                var dat = json.d.split("_sedes@");
	                $("#sedes tbody").html(dat[1]);
	                if (dat[2] == "20") {
	                    $("#btn-guardar").hide();
	                }
	            }
	        });
        }

        function btnguardar(event) {

            if (event == "insert") {
                var i = 1;
                $("#sedes tbody tr").each(function (index, elem) {
                    var campo1, campo5, campo6, campo7;

                    if ($("#txt_" + i).val() != '' && $("#autoformacion_" + i).val() != '' && $("#produccion_" + i).val() != '') {
                        $(this).children("td").each(function (index2, elem2) {

                            switch (index2) {
                                case 1:
                                    campo1 = $(this).text();
                                    console.log("codsede: " + campo1);
                                    break;
                                case 5:
                                    campo5 = $(elem2).children("input").val();
                                    console.log("txt_: " + campo5);
                                    break;
                                case 6:
                                    campo6 = $(elem2).children("input").val();
                                    console.log("txt_: " + campo6);
                                    break;
                                case 7:
                                    campo7 = $(elem2).children("input").val();
                                    console.log("txt_: " + campo7);
                                    break;
                            }
                        });

                        var jsondata = "{'codsede': '" + campo1 + "', 'nroasistentes': '" + campo5 + "', 'autoformacion': '" + campo6 + "', 'produccion': '" + campo7 + "'}";
                        $.ajax({
                            type: 'POST',
                            url: 'estradossesionvirtual.aspx/encabezado',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: jsondata,
                            success: function (json) {
                                var resp = json.d.split("_insert@");
                                if (resp[0] === "true") {
                                    console.log(resp[1]);
                                }
                            }
                        });
                    }
                    else {
                        alert("Todos los campos deben estar diligenciados.");
                        $("#txt_" + i).focus();
                        $("#autoformacion_" + i).focus();
                        $("#produccion_" + i).focus();
                    }

                    i = i + 1;
                });

                if (i > 0) {
                    alert("Datos guardados correctamente.");
                    btnregresar();
                    listar();
                }

               
            }
            else if (event == "update") {
                if ($("#nroasistentes").val() == '') {
                    alert("Por favor digite la fecha de asistencia");
                    $("#nroasistentes").focus();
                } else {
                    var jsondata = "{'codigo': '" + codigoinstrumento + "', 'nroasistente': '" + $("#nroasistentes").val() + "', 'autoformacion': '" + $("#autoformacion").val() + "', 'produccion': '" + $("#produccion").val() + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'estradossesionvirtual.aspx/update',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsondata,
                        success: function (json) {
                            var resp = json.d.split("_update@");
                            if (resp[0] === "true") {
                                alert("Dato actualizado correctamente");
                                listar();
                                btnregresar();
                            }
                            else {
                                alert("Error al actualizar");
                            }
                        }
                    });
                }
            }
            //if ($("#fecha").val() == '') {
            //    alert("Por favor digite la fecha de asistencia");
            //    $("#fecha").focus();
            //} else {
            //    var jsonData = "{'codsede':'" + $("#sede").val() + "', 'fecha':'" + $("#fecha").val() + "'}";
            //    $.ajax({
            //        type: 'POST',
            //        url: 'estradossesionvirtual.aspx/encabezado',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        data: jsonData,
            //        success: function (json) {
            //            var resp = json.d.split("_insert@");
            //            if (resp[0] === "true") {
            //                guardardetalle(resp[1]);
            //            }
            //        },
            //        complete: function () {
            //            alert("Datos guardados exitosamente.");
            //        }
            //    });
            //}
        }

        function guardardetalle(codencabezado) {
            var jsonData = "{'codencabezado':'" + codencabezado + "', 'codgradodocente':'" + $("#codgradodocente").val() + "'}";
            $.ajax({
                type: 'POST',
                url: 'estradossesionvirtual.aspx/inasistenciadocentes',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_insert@");
                    if (resp[0] === "true") {
                        
                    }
                }
            });
        }

        function loadinstrumento(codigo) {
            var jsonData = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estradossesionvirtual.aspx/load',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");
                    if (resp[0] === "true") {
                        $("#sedes tbody").html(resp[1]);
                        codigoinstrumento = resp[2];
                        $("#btn-guardar").show();
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'btnguardar(\'update\')');
                        $("#table").hide();
                        $("#form").fadeIn(500);
                        $("#btnbuscar").hide();
                    }
                }
            });
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estradossesionvirtual.aspx/delete',
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
    <h2>Sesión Virtual No. <asp:Label runat="server" ID="lblSesion" Visible="true"> </asp:Label></h2>
  
    <div id="table">
   
     <fieldset >
          <a class="btn btn-primary" id="btn-nuevo" onclick="btnnuevo();" style="float:right">Nuevo registro</a>
         <br /><br />
         <table  class="mGridTesoreria" id="sedes2">
            <thead>
                <tr>
                    <th>No</th>
                    <%--<th>Coordinador</th>--%>
                    <%--<th>Departamento</th>--%>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede Educativa</th>
                    <th>Sesión</th>
                    <th>Nro. Asistentes</th>
                    <th>2 horas de <br />autoformación</th>
                    <th>2 horas de <br />producción</th>
                    <th></th>
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
		    <legend>DATOS DE LA INSTITUCIÓN</legend>
		    <table>
                <tr>
                   <td>Año: </td>
                    <td>
                        <select class="TextBox width-100" name="anio" id="anio" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
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
               <%-- <tr>
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
                </tr>--%>
                <tr>
                    <td colspan="2">
                        <a href="javascript:void(0)" class="btn btn-primary" onclick="btnbuscar()" id="btnbuscar">Buscar</a>
                    </td>
                </tr>
               
              
            </table>
         </fieldset>

         <fieldset>
             <legend>Sedes</legend>
            <%-- <center>
                 Fecha de asistencia<br />
                 <input type="datetime" name="fecha" id="fecha" class="TextBox" />
             </center>--%>
             <br />
              <table class="mGridTesoreria" id="sedes">
                 <thead>
                     <tr>
                         <th>No.</th>
                         <th>Municipio</th>
                         <th>Institución</th>
                         <th>Sede</th>
                         <th>Asistentes a la sesión<br /> virtual (4 horas)</th>
                         <th>2 horas de<br /> autoformación</th>
                         <th>2 horas de <br /> producción</th>
                     </tr>
                 </thead>
                 <tbody ></tbody>
             </table>
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
             </table>--%>
             <br />
             <center>
                 <input type="button" class="btn btn-success" id="btn-guardar" onclick="btnguardar('insert')" value="Guardar"/>
             </center>
         </fieldset>
       </div>
             
</asp:Content>

