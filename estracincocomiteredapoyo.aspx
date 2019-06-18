<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estracincocomiteredapoyo.aspx.cs" Inherits="estracincocomiteredapoyo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

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
	        //cargaranio();

	        $("input[type='datetime']").datepicker({changeYear: true, changeMonth: true });
	        
	        //Cargar departamento
	        $.ajax({

	            type: 'POST',
	            url: 'estracincocomiteredapoyo.aspx/cargarDepartamentoMagdalena',
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
	                    url: 'estracincocomiteredapoyo.aspx/cargarMunicipios',
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
	                url: 'estracincocomiteredapoyo.aspx/cargarMunicipios',
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
	        //        url: 'estracincocomiteredapoyo.aspx/cargarInstituciones',
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
	        //        url: 'estracincocomiteredapoyo.aspx/cargarSedesxInstitucion',
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
	        //$("#anio").val("");
	        $("#sedes tbody").html("");
	        $('#btn-guardar').attr('value', 'Guardar');
	        $('#btn-guardar').attr('onclick', 'btnguardar(\'insert\')');
	        $("#btnbuscar").show();
	    }

	    function listar() {
	        $.ajax({
	            type: 'POST',
	            url: 'estracincocomiteredapoyo.aspx/listar',
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (json) {
	                var dat = json.d.split("encontro@");
	                $("#tbody").html(dat[1]);
	                if (dat[1] == "20") {
	                    $("#btn-guardar").hide();
	                }
	            }
	        });
	    }

	    //function cargaranio() {
	    //        $.ajax({
	    //            type: 'POST',
	    //            url: 'estracincocomiteredapoyo.aspx/cargaranios',
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
	    //        url: 'estracincocomiteredapoyo.aspx/buscar',
	    //        contentType: "application/json; charset=utf-8",
	    //        dataType: "json",
	    //        data: jsonData,
	    //        success: function (json) {
	    //            $("#sedes tbody").html(json.d);
	    //            $("#btn-guardar").show();
	    //        }
	    //    });
        //}

        function btnguardar(event) {

            if (event == "insert") {
                if ($.trim($("#municipio").val()) == '') {
                    alert("Por favor, seleccione el municipio ");
                    $("#municipio").focus();
                } else if ($.trim($("#fecha").val()) == '') {
                    alert("Por favor, digite la fecha de reunión");
                    $("#fecha").focus();
                } else if ($.trim($("#lugar").val()) == '') {
                    alert("Por favor, digite el lugar");
                    $("#lugar").focus();
                } else if ($.trim($("#hora").val()) == '') {
                    alert("Por favor, seleccione la hora");
                    $("#hora").focus();
                } else if ($.trim($("#participantes").val()) == '') {
                    alert("Por favor, digite la cantidad de participantes");
                    $("#participantes").focus();
                } else if ($.trim($("#entidades").val()) == '') {
                    alert("Por favor, digite la cantidad de entidades participantes");
                    $("#entidades").focus();
                } else if ($.trim(document.getElementById('MainContent_objetivo_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                    alert("Por favor, digite el objetivo");
                    //$("#objetivo").focus();
                } else if ($.trim(document.getElementById('MainContent_desarrollo_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                    alert("Por favor, digite el desarrollo");
                    //$("#desarrollo").focus();
                } else {

                    var objetivo = document.getElementById('MainContent_objetivo_ctl02_ctl00').contentWindow.document.body.innerHTML;
                    var desarrollo = document.getElementById('MainContent_desarrollo_ctl02_ctl00').contentWindow.document.body.innerHTML;

                    var jsondata = "{'codmunicipio': '" + $("#municipio").val() + "', 'fecha': '" + $("#fecha").val() + "', 'lugar': '" + $("#lugar").val() + "', 'hora': '" + $("#hora").val() + "', 'participantes': '" + $("#participantes").val() + "', 'entidades': '" + $("#entidades").val() + "', 'objetivo': '" + objetivo + "', 'desarrollo': '" + desarrollo + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'estracincocomiteredapoyo.aspx/encabezado',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsondata,
                        success: function (json) {
                            var resp = json.d.split("_insert@");
                            if (resp[0] === "true") {
                                console.log(resp[1]);
                            }
                        }, complete: function () {
                            alert("Datos ingresados correctamente");
                            listar();
                            btnregresar();
                        }
                    });

                }
            }
            else if (event == "update") {

                var objetivo = document.getElementById('MainContent_objetivo_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var desarrollo = document.getElementById('MainContent_desarrollo_ctl02_ctl00').contentWindow.document.body.innerHTML;
               
                var jsondata = "{'codigo': '" + codigoinstrumento + "', 'codmunicipio': '" + $("#municipio").val() + "', 'fecha': '" + $("#fecha").val() + "', 'lugar': '" + $("#lugar").val() + "', 'hora': '" + $("#hora").val() + "', 'participantes': '" + $("#participantes").val() + "', 'entidades': '" + $("#entidades").val() + "', 'objetivo': '" + objetivo + "', 'desarrollo': '" + desarrollo + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'estracincocomiteredapoyo.aspx/update',
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
         
            //if ($("#fecha").val() == '') {
            //    alert("Por favor digite la fecha de asistencia");
            //    $("#fecha").focus();
            //} else {
            //    var jsonData = "{'codsede':'" + $("#sede").val() + "', 'fecha':'" + $("#fecha").val() + "'}";
            //    $.ajax({
            //        type: 'POST',
            //        url: 'estracincocomiteredapoyo.aspx/encabezado',
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

        function loadinstrumento(codigo) {
            var jsonData = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estracincocomiteredapoyo.aspx/load',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");
                    if (resp[0] === "true") {
                        $("#municipio").val(resp[1]);
                        $("#fecha").val(resp[2]);
                        $("#lugar").val(resp[3]);
                        $("#hora").val(resp[4]);
                        $("#participantes").val(resp[5]);
                        $("#entidades").val(resp[6]);
                        document.getElementById('MainContent_objetivo_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[7];
                        document.getElementById('MainContent_desarrollo_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[8];
                        codigoinstrumento = resp[9];

                        if (resp[10] === "20") {
                            $("#btn-guardar").hide();
                            $("#btn-nuevo").hide();
                        }
                        else {
                            $("#btn-guardar").show();
                            $('#btn-guardar').attr('value', 'Actualizar');
                            $('#btn-guardar').attr('onclick', 'btnguardar(\'update\')');
                        }
                        $("#table").hide();
                        $("#form").fadeIn(500);
                    }
                }
            });
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estracincocomiteredapoyo.aspx/delete',
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
    <h2>Encuentros red de apoyo <asp:Label runat="server" ID="lblSesion" Visible="false"> </asp:Label></h2>
  
    <div id="table">
   
     <fieldset >
          <a class="btn btn-primary" id="btn-nuevo" onclick="btnnuevo();" style="float:right">Nuevo registro</a>
         <br /><br />
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Municipio</th>
                    <th>Fecha</th>
                    <th>Hora</th>
                    <th>Lugar</th>
                    <th>No. participantes</th>
                    <th>No. entidades <br /> participantes</th>
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
		    <legend>Sesión</legend>
		    <table>
               <%-- <tr>
                   <td>Año: </td>
                    <td>
                        <select class="TextBox width-100" name="anio" id="anio" style="width: 250px">
                        </select>
                    </td>
                </tr>--%>
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
                </tr>
                <tr>
                    <td colspan="2">
                        <a href="javascript:void(0)" class="btn btn-primary" onclick="btnbuscar()" id="btnbuscar">Buscar</a>
                    </td>
                </tr>
               --%>
              
           
               <tr>
                   <td style="width:20%;">Fecha de reunión:</td>
                   <td><input type="datetime" name="fecha" id="fecha" class="TextBox" /></td>
               </tr>
                <tr>
                   <td style="width:5%;">Lugar: </td>
                    <td><input type="text" name="fecha" id="lugar" class="TextBox" /></td>
                </tr>
                <tr>
                      <td style="width:5%;">Hora:</td>
                      <td>
                          <select class="TextBox width-50" name="hora" id="hora">
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
                  <tr>
                      <td style="width:5%;" >No. participantes:  </td>
                      <td><input type="text" name="participantes" id="participantes" class="TextBox" style="width:50px;" /></td>
                  </tr>
                  <tr>
                       <td style="width:5%;">No. entidades participantes:  </td>
                      <td><input type="text" name="entidades" id="entidades" class="TextBox" style="width:50px;" /></td>
                  </tr>
                  <tr>
                      <td colspan="2"><br />Objetivo: </td>
                  </tr>
                  <tr>
                      <td colspan="5">
                           <cc1:Editor ID="objetivo" runat="server" Width="1050px" Height="250" />
                      </td>
                  </tr>
                  <tr>
                      <td colspan="2"><br />Desarrollo de la agenda: </td>
                  </tr>
                  <tr>
                      <td colspan="5">
                           <cc1:Editor ID="desarrollo" runat="server" Width="1050px" Height="250" />
                      </td>
                  </tr>
             </table>
          
             <br />
             <center><input type="button" class="btn btn-success" id="btn-guardar" onclick="btnguardar('insert')" value="Guardar" /></center>
         </fieldset>
       </div>
             
</asp:Content>

