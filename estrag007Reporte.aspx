<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estrag007Reporte.aspx.cs" Inherits="estrag007Reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="jquery.js"></script>

    <style> 
		fieldset{
			padding: 10px;
		}
		table.border td, table.border th{
			/*border: 1px solid;*/
			margin: 0;
			padding: 5px;
		}
		table.border tr,table.border{
			margin: 0;
			padding: 0;
		}
		.width-100{
			width: 98%;
		}
	</style>

    <script>
        $(document).ready(function () {
            cargarasesores();
            listadobitacora4Regresar();

            $("#asesores").change(function () {
                console.log($("#asesores").val());
                listadobitacora4($("#asesores").val());
            });
        });

        function cargarasesores() {

            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: 'estrag007Reporte.aspx/cargarasesores',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    if (response.d != null) {
                        $("#asesores").html(response.d);
                    }
                }
            });
        }

        function listadobitacora4(codasesorcoordinador) {
            $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'codasesorcoordinador':'" + codasesorcoordinador + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag007Reporte.aspx/listadobitacora4',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function listadobitacora4Regresar() {
            $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            $.ajax({
                type: 'POST',
                url: 'estrag007Reporte.aspx/listadobitacora4Regresar',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }
    </script>


	<%--<script>
	    var total = 0;
	    $(document).ready(function () {

	        //$("#frmg007").submit(function (event) {
	        //    event.preventDefault();
	        //    if ($.trim($('#insumos').val()) == '' || $.trim($('#insumos').val()) == 0) {
	        //        alert("Por favor, ingrese valor insumos");
	        //        $('#insumos').focus();
	        //    } else if ($.trim($('#papeleria').val()) == '' || $.trim($('#papeleria').val()) == 0) {
	        //        alert("Por favor, ingrese valor papeleria");
	        //        $('#papeleria').focus();
	        //    } else if ($.trim($('#transporte').val()) == '' || $.trim($('#transporte').val()) == 0) {
	        //        alert("Por favor, ingrese valor transporte");
	        //        $('#transporte').focus();
	        //    } else if ($.trim($('#materialdivulgacion').val()) == '' || $.trim($('#materialdivulgacion').val()) == 0) {
	        //        alert("Por favor, ingrese valor material de divulgacion");
	        //        $('#materialdivulgacion').focus();
	        //    } else if ($.trim($('#refrigerios').val()) == '' || $.trim($('#refrigerios').val()) == 0) {
	        //        alert("Por favor, ingrese valor refrigerios");
	        //        $('#refrigerios').focus();
	        //    } else if ($.trim($('#firmatesorero').val()) == '') {
	        //        alert("Por favor, ingrese firma de tesorero(a)");
	        //        $('#firmatesorero').focus();
	        //        caltotal();
	        //    } else if ($.trim($('#voboasesor').val()) == '') {
	        //        alert("Por favor, ingrese Vo.Bo. Del asesor");
	        //        $('#voboasesor').focus();
	        //        caltotal();
	        //    } else if ($.trim($('#fechadiligenciamiento').val()) == '') {
	        //        alert("Por favor, ingrese fecha de diligenciamiento");
	        //        $('#fechadiligenciamiento').focus();
	        //        caltotal();
	        //    } else {
	        //        alert("true");
	        //        caltotal();
	        //        var frmserialize = $("#frmg007").serialize();
	        //        alert(frmserialize + "&total=" + total);
	        //         $.ajax({
	        //         	type: 'POST',
	        //         	url: url,
	        //         	data:frmserialize,
	        //         	success: function(data){

	        //         	}
	        //         });
	        //    }
	        //});

	        

	        

	        
	    //function caltotal() {
	    //    total = parseInt($('#insumos').val()) + parseInt($('#papeleria').val()) + parseInt($('#transporte').val()) + parseInt($('#materialdivulgacion').val()) + parseInt($('#refrigerios').val()) + parseInt($('#otro').val());
	    //    $('#total').val("$ " + returnpuntitos(total.toString()) + ",00");
	    //}
	    function returnpuntitos(valor, caracter) {
	        pat = /[\*,\+,\(,\),\?,\,$,\[,\],\^]/;
	        // valor = donde.value;
	        valorfinal = 0;
	        largo = valor.length;
	        crtr = true;
	        if (isNaN(valor) || pat.test(valor) == true) {
	            if (pat.test(valor) == true) {
	                valor = "\"" + valor;
	            }
	            carcter = new RegExp(valor, "g");
	            valor = valor.replace(carcter, "");
	            valorfinal = valor;
	            crtr = false;
	        }
	        else {
	            var nums = new Array();
	            cont = 0;
	            for (m = 0; m < largo; m++) {
	                if (valor.charAt(m) == "." || valor.charAt(m) == " ")
	                { continue; }
	                else {
	                    nums[cont] = valor.charAt(m);
	                    cont++;
	                }
	            }
	        }
	        var cad1 = "", cad2 = "", tres = 0;
	        if (largo > 3 && crtr == true) {
	            for (k = nums.length - 1; k >= 0; k--) {
	                cad1 = nums[k];
	                cad2 = cad1 + cad2;
	                tres++;
	                if ((tres % 3) == 0) {
	                    if (k != 0) {
	                        cad2 = "." + cad2;
	                    }
	                }
	            }
	            valorfinal = cad2;
	        }
	        return valorfinal;
	    }
	</script>--%>
    <script>
        var codestrategia = "";
        $(function () {
            
            var formatNumber = {
                separador: ".", // separador para los miles
                sepDecimal: ',', // separador para los decimales
                formatear: function (num) {
                    num += '';
                    var splitStr = num.split('.');
                    var splitLeft = splitStr[0];
                    var splitRight = splitStr.length > 1 ? this.sepDecimal + splitStr[1] : '';
                    var regx = /(\d+)(\d{3})/;
                    while (regx.test(splitLeft)) {
                        splitLeft = splitLeft.replace(regx, '$1' + this.separador + '$2');
                    }
                    return this.simbol + splitLeft + splitRight;
                },
                new: function (num, simbol) {
                    this.simbol = simbol || '';
                    return this.formatear(num);
                }
            }

            $(".price").keyup(function () {
                calculateSum();
            });

            $(".price2do").keyup(function () {
                calculateSum2do();
            });

            $(".price3ro").keyup(function () {
                calculateSum3ro();
            });

            function calculateSum() {
                var sum = 0;
                $(".price").each(function () {
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseFloat(this.value);
                    }
                    $("#txttotal").val(formatNumber.new(sum, "$"));
                });

            }

            function calculateSum2do() {
             
                var sum2do = 0;
                $(".price2do").each(function () {
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum2do += parseFloat(this.value);
                    }
                    $("#txttotal2do").val(formatNumber.new(sum2do, "$"));
                });

            }

            function calculateSum3ro() {
               
                var sum3ro = 0;
                $(".price3ro").each(function () {
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum3ro += parseFloat(this.value);
                    }
                    $("#txttotal3ro").val(formatNumber.new(sum3ro, "$"));
                });
            }

            

            $.ajax({
                url: 'estrag007Reporte.aspx/cargarDepartamentoMagdalena',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'JSON',
                //data:frmserialize,
                success: function (json) {
                    $("#departamento").html(json.d);

            
                }
            });

            $("#departamento").on('change', function () {
                var data = "{'coddepartamento': '" + $('#departamento').val() + "'}"
                $.ajax({
                    url: 'estrag007Reporte.aspx/cargarMunicipios',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#municipio").html(response.d);

                    }

                });
            });

           
            $("#municipio").on('change', function () {
                var data = "{'codmunicipio': '" + $('#municipio').val() + "'}"
                $.ajax({
                    url: 'estrag007Reporte.aspx/cargarInstituciones',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#instituciones").html(response.d);


                    }

                });
            });

            $("#instituciones").on('change', function () {
                var data = "{'codInstitucion': '" + $('#instituciones').val() + "'}"
                $.ajax({
                    url: 'estrag007Reporte.aspx/cargarSedesInstitucion',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#sedes").html(response.d);


                    }

                });
            });
            

            $("#sedes").on("change", function () {
                var data = "{'codSede':'" + $("#sedes").val() + "'}";
                $.ajax({
                    url: 'estrag007Reporte.aspx/cargarLineaInvestigacion',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        $("#grupoInvestigacion").html(response.d);
                    }
                });
            });

        });
        function loadSelectBitacoraCuatro(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag007Reporte.aspx/loadSelectBitacoraCuatro',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    var resp = response.d.split("@");
                    if (resp[0] === "loadSelect") {
                        $("#departamento").html(resp[1]);
                        $("#municipio").html(resp[2]);
                        $("#instituciones").html(resp[3]);
                        $("#sedes").html(resp[4]);
                        $("#grupoInvestigacion").html(resp[5]);
                        //cargaranio(codigo);
                    }
                }
            });
        }
        function cargaranio(codProyecto) {
            var jsondata = "{'codProyecto':'" + codProyecto + "'}";
            $.ajax({
                type: 'POST',
                data: jsondata,
                dataType: 'JSON',
                url: 'estrag007Reporte.aspx/cargaranios',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    $('#anios').html(response.d);
                }
            });
        }
        function loadRubros(codigo)
        {
            codestrategia = codigo;
            //$("#grupoInvestigacion").on("change", function () {
            var data = "{'codigo':'" + codigo + "'}";
                $.ajax({
                    url: 'estrag007Reporte.aspx/searchRubros',
                    type: 'POST',
                    data: data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        var data = response.d.split("-");
                        $("#txtinsumo").val(data[0]);
                        $("#txtpapeleria").val(data[1]);
                        $("#txttransporte").val(data[2]);
                        $("#txtmaterial").val(data[3]);
                        $("#txtrefrigerio").val(data[4]);
                        $("#txtotros").val(data[5]);
                        $("#txttotal").val('');

                        var total = parseInt(data[0]) + parseInt(data[1]) + parseInt(data[2]) + parseInt(data[3]) + parseInt(data[4]) + parseInt(data[5]);

                        $("#txttotal").val(total);

                        $("#txtinsumo2do").val(data[6]);
                        $("#txtpapeleria2do").val(data[7]);
                        $("#txttransporte2do").val(data[8]);
                        $("#txtmaterial2do").val(data[9]);
                        $("#txtrefrigerio2do").val(data[10]);
                        $("#txtotros2do").val(data[11]);
                        $("#txttotal2do").val('');

                        var total2do = parseInt(data[6]) + parseInt(data[7]) + parseInt(data[8]) + parseInt(data[9]) + parseInt(data[10]) + parseInt(data[11]);

                        $("#txttotal2do").val(total2do);

                        $("#txtinsumo3ro").val(data[12]);
                        $("#txtpapeleria3ro").val(data[13]);
                        $("#txttransporte3ro").val(data[14]);
                        $("#txtmaterial3ro").val(data[15]);
                        $("#txtrefrigerio3ro").val(data[16]);
                        $("#txtotros3ro").val(data[17]);
                        $("#txttotal3ro").val('');

                        var total3ro = parseInt(data[12]) + parseInt(data[13]) + parseInt(data[14]) + parseInt(data[15]) + parseInt(data[16]) + parseInt(data[17]);

                        $("#txttotal3ro").val(total3ro);

                    }
                });
            //});
                $("#btnGuardar").attr('value', 'Actualizar');
                $("#btnGuardar").attr('onclick', 'btnGuardar_Click(\'update\')');
        }

        /*Metodo para guardar Rubros*/
        function btnGuardar_Click(event) {

            if (event == "insert") {
                var jsonData = "{'codGrupoInvestigacion': '" + $("#grupoInvestigacion").val().toString() + "', 'valInsumo': '" + $("#txtinsumo").val().toString() + "', 'valPapeleria': '" + $("#txtpapeleria").val().toString() + "', 'valTransporte': '" + $("#txttransporte").val().toString() + "', 'valMaterial': '" + $("#txtmaterial").val().toString() + "', 'valRefrigerio': '" + $("#txtrefrigerio").val().toString() + "', 'valOtros': '" + $("#txtotros").val().toString() + "', 'valInsumo2do': '" + $("#txtinsumo2do").val().toString() + "', 'valPapeleria2do': '" + $("#txtpapeleria2do").val().toString() + "', 'valTransporte2do': '" + $("#txttransporte2do").val().toString() + "', 'valMaterial2do': '" + $("#txtmaterial2do").val().toString() + "', 'valRefrigerio2do': '" + $("#txtrefrigerio2do").val().toString() + "', 'valOtros2do': '" + $("#txtotros2do").val().toString() + "', 'valInsumo3ro': '" + $("#txtinsumo3ro").val().toString() + "', 'valPapeleria3ro': '" + $("#txtpapeleria3ro").val().toString() + "', 'valTransporte3ro': '" + $("#txttransporte3ro").val().toString() + "', 'valMaterial3ro': '" + $("#txtmaterial3ro").val().toString() + "', 'valRefrigerio3ro': '" + $("#txtrefrigerio3ro").val().toString() + "', 'valOtros3ro': '" + $("#txtotros3ro").val().toString() + "'}";
                $.ajax({
                    url: 'estrag007Reporte.aspx/guardarRubros',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        alert(response.d);
                        console.log(response.d);
                        listadobitacora4();
                        btnRegresar();

                    }
                });
            }
            else if (event == "update") {
                var jsonData = "{'codestrategia': '" + codestrategia + "', 'valInsumo': '" + $("#txtinsumo").val().toString() + "', 'valPapeleria': '" + $("#txtpapeleria").val().toString() + "', 'valTransporte': '" + $("#txttransporte").val().toString() + "', 'valMaterial': '" + $("#txtmaterial").val().toString() + "', 'valRefrigerio': '" + $("#txtrefrigerio").val().toString() + "', 'valOtros': '" + $("#txtotros").val().toString() + "', 'valInsumo2do': '" + $("#txtinsumo2do").val().toString() + "', 'valPapeleria2do': '" + $("#txtpapeleria2do").val().toString() + "', 'valTransporte2do': '" + $("#txttransporte2do").val().toString() + "', 'valMaterial2do': '" + $("#txtmaterial2do").val().toString() + "', 'valRefrigerio2do': '" + $("#txtrefrigerio2do").val().toString() + "', 'valOtros2do': '" + $("#txtotros2do").val().toString() + "', 'valInsumo3ro': '" + $("#txtinsumo3ro").val().toString() + "', 'valPapeleria3ro': '" + $("#txtpapeleria3ro").val().toString() + "', 'valTransporte3ro': '" + $("#txttransporte3ro").val().toString() + "', 'valMaterial3ro': '" + $("#txtmaterial3ro").val().toString() + "', 'valRefrigerio3ro': '" + $("#txtrefrigerio3ro").val().toString() + "', 'valOtros3ro': '" + $("#txtotros3ro").val().toString() + "'}";
                $.ajax({
                    url: 'estrag007Reporte.aspx/updateRubros',
                    type: 'POST',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        alert(response.d);
                        console.log(response.d);
                        listadobitacora4();
                        btnRegresar();

                    }
                });
            }
           
        }

        function reset() {
            //$("#txttotal").val('');
            $("#txtinsumo").val('');
            $("#txtpapeleria").val('');
            $("#txttransporte").val('');
            $("#txtmaterial").val('');
            $("#txtrefrigerio").val('');
            $("#txtotros").val('');

            $("#txtinsumo2do").val('');
            $("#txtpapeleria2do").val('');
            $("#txttransporte2do").val('');
            $("#txtmaterial2do").val('');
            $("#txtrefrigerio2do").val('');
            $("#txtotros2do").val('');

            $("#txtinsumo3ro").val('');
            $("#txtpapeleria3ro").val('');
            $("#txttransporte3ro").val('');
            $("#txtmaterial3ro").val('');
            $("#txtrefrigerio3ro").val('');
            $("#txtotros3ro").val('');
           
        }

        function nuevopresupuesto() {
            $("#table").hide();
            $("#form").fadeIn(500);
            $("#municipio").html("<option value=''>Seleccione municipio...</option>");
            $("#instituciones").html("<option value=''>Seleccione institucion...</option>");
            $("#sedes").html("<option value=''>Seleccione sede...</option>");
            $("#grupoInvestigacion").html("<option value=''>Seleccione grupo de investigación...</option>");
            reset();
            cargarDepartamentoMagdalena();

            $("#btnGuardar").attr('value', 'Guardar todo');
            $("#btnGuardar").attr('onclick', 'btnGuardar_Click(\'insert\')');
         
        }

        function btnRegresar() {
            $("#form").hide();
            $("#table").fadeIn(500);
           

        
        }

        function deleteBitacoraCuatro(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro?')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estrag007Reporte.aspx/deletebitacora',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            alert('Dato eliminado correctamente.');
                            listadobitacora4();
                        }
                    }
                });
            }

        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
    <h2 >Estrategía Nro. <asp:Label runat="server" ID="lblCodEstrategia" Visible="true"></asp:Label> - Presupuesto de los proyectos de investigación</h2><br />
    
    <asp:Label runat="server" ID="lblCodMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodActividad" Visible="false"></asp:Label>

    

      <div id="table">
     
      <br />
      <br />
     <fieldset >
          <table>
            <tr>
                <td>Asesor:</td>
                <td><select id="asesores" class="TextBox"><option>Seleccione asesor...</option></select></td>
            </tr>
          </table>
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede</th>
                    <th>Grupo<br/>Investigación</th>
                    <th>Fecha<br/>diligenciamiento</th>
                    <th>Nombre<br/>Asesor</th>
                    <th>Momento</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
</div>

    <div id="form" style="display:none">
        <a href="#" id="btnRegresar" style="float:right;" class="btn btn-primary" onclick="btnRegresar();" >Regresar</a>
        <br /> <br />
         <fieldset>
        <legend>Presupuesto </legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
            <tr>
                <td colspan="3">
                    <table>
                       <%-- <tr width="100%">
                            <td style="width: 150px;">Año lectivo:</td>
                            <td >
                                <select class="TextBox" name="anios" id="anios" >
                                    <option value="">Seleccione año...</option>
                                </select></td>
                            </tr>--%>
                        <tr>
                             <td>Departamento</td>
                            <td><select id="departamento" class="TextBox"></select></td>
                        </tr>
                        <tr>
                            <td>Municipio</td>
                            <td><select id="municipio" class="TextBox"></select></td>
                        </tr>
                        <tr>
                            <td>Institución</td>
                            <td><select id="instituciones" class="TextBox"></select></td>
                        </tr>
                        <tr>
                        <td>Sede</td>
                        <td><select id="sedes" class="TextBox"></select></td>
                    </tr>
                    <tr>
                        <td>Nombre del grupo de investigación: </td>
                        <td><select id="grupoInvestigacion" class="TextBox"></select></td>
                    </tr>
                    </table>
                </td>
            </tr>
            
        </table>
        <fieldset>
            <legend>Presupuesto</legend>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>PRIMER SEGMENTO O TRAYECTO</th>
                        <th>VALOR</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Insumos para la investigación (Pruebas de laboratorio)</td>
                        <td><input id="txtinsumo" type="text" class="TextBox price"/></td>
                    </tr>
                    <tr>
                        <td>Papelería (fotocopias, impreciones, lápices, lapiceros, libreta de apunte)</td>
                        <td><input id="txtpapeleria" type="text" class="TextBox price"/></td>
                    </tr>
                    <tr>
                        <td>Transporte municipal e intermunicipal</td>
                        <td><input id="txttransporte" type="text" class="TextBox price"/></td>
                    </tr>
                    <tr>
                        <td>Materia de divulgacíon (Plegables, videos, fotografías, afiches e internet)</td>
                        <td><input id="txtmaterial" type="text" class="TextBox price"/></td>
                    </tr>
                     <tr>
                        <td>Refrigerios</td>
                        <td><input id="txtrefrigerio" type="text" class="TextBox price"/></td>
                    </tr>
                    <tr>
                        <td>Correo Aéreo e Internet</td>
                        <td><input id="txtotros" type="text" class="TextBox price" /></td>
                    </tr>
                     <tr>
                        <td>Total proyecto</td>
                        <td><input type="text" id="txttotal" class="TextBox" disabled="disabled"/></td>
                    </tr>
                </tbody>
            </table>

            <br />

            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>SEGUNDO SEGMENTO O TRAYECTO</th>
                        <th>VALOR</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Insumos para la investigación (Pruebas de laboratorio)</td>
                        <td><input id="txtinsumo2do" type="text" class="TextBox price2do"/></td>
                    </tr>
                    <tr>
                        <td>Papelería (fotocopias, impreciones, lápices, lapiceros, libreta de apunte)</td>
                        <td><input id="txtpapeleria2do" type="text" class="TextBox price2do"/></td>
                    </tr>
                    <tr>
                        <td>Transporte municipal e intermunicipal</td>
                        <td><input id="txttransporte2do" type="text" class="TextBox price2do"/></td>
                    </tr>
                    <tr>
                        <td>Materia de divulgacíon (Plegables, videos, fotografías, afiches e internet)</td>
                        <td><input id="txtmaterial2do" type="text" class="TextBox price2do"/></td>
                    </tr>
                     <tr>
                        <td>Refrigerios</td>
                        <td><input id="txtrefrigerio2do" type="text" class="TextBox price2do"/></td>
                    </tr>
                    <tr>
                        <td>Correo Aéreo e Internet</td>
                        <td><input id="txtotros2do" type="text" class="TextBox price2do" /></td>
                    </tr>
                     <tr>
                        <td>Total proyecto</td>
                        <td><input type="text" id="txttotal2do" class="TextBox" disabled="disabled"/></td>
                    </tr>
                </tbody>
            </table>

            <br />

            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>TERCER SEGMENTO O TRAYECTO</th>
                        <th>VALOR</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Insumos para la investigación (Pruebas de laboratorio)</td>
                        <td><input id="txtinsumo3ro" type="text" class="TextBox price3ro"/></td>
                    </tr>
                    <tr>
                        <td>Papelería (fotocopias, impreciones, lápices, lapiceros, libreta de apunte)</td>
                        <td><input id="txtpapeleria3ro" type="text" class="TextBox price3ro"/></td>
                    </tr>
                    <tr>
                        <td>Transporte municipal e intermunicipal</td>
                        <td><input id="txttransporte3ro" type="text" class="TextBox price3ro"/></td>
                    </tr>
                    <tr>
                        <td>Materia de divulgacíon (Plegables, videos, fotografías, afiches e internet)</td>
                        <td><input id="txtmaterial3ro" type="text" class="TextBox price3ro"/></td>
                    </tr>
                     <tr>
                        <td>Refrigerios</td>
                        <td><input id="txtrefrigerio3ro" type="text" class="TextBox price3ro"/></td>
                    </tr>
                    <tr>
                        <td>Correo Aéreo e Internet</td>
                        <td><input id="txtotros3ro" type="text" class="TextBox price3ro" /></td>
                    </tr>
                     <tr>
                        <td>Total proyecto</td>
                        <td><input type="text" id="txttotal3ro" class="TextBox" disabled="disabled"/></td>
                    </tr>
                </tbody>
            </table>
            <p><strong>Nota:</strong> No serán consideradas las propustas cuyo objetivo primordial sea la dotacíon de equipos o materiales didácticos (a nos ser que estos sean indispensables, locual debe estar justificado en el diseño de los trayectos de investigacíon); la construcción de infraestructura o el desarrollo de actividades como talleres, convivencias y otro tipo de eventos de intervención que no formen parte del proyecto general de investigación.</p>
            <p><strong>Nota:</strong> El presupuesto total no debe exceder la suma de $ 2.000.000</p>
            <p>* Gastos elegibles son aquellos seleccionados  para ser financiados con los recursos asignados al grupo de investigación de aula por el proyecto Ciclón.</p>
        </fieldset>
        <fieldset>
            <table border="0" style="display:none;padding: 10px; border-radius: 5px; background-color: #ECECEC;">
                <tr>
                    <td>Firma de maestro(a) tesorero(a)</td>
                    <td><input type="text" id="txtfirma" class="TextBox" /></td>
                </tr>
                <tr>
                    <td>Vo.bo. del asesor de línea de ciclón</td>
                    <td><input type="text" id="txtvobo" class="TextBox" /></td>
                </tr>
            </table>
        </fieldset>
    </fieldset>
    <br />
     <%--   <center>
        <input type="button" class="btn btn-success" value="Guardar" id="btnGuardar" onclick="btnGuardar_Click('insert');" />
      
     <asp:Button runat="server" ID="btnSubirFirmaPop" Text="Cargar Evidencias" CssClass="btn btn-danger" OnClick="cargarEvidencias_Click" />
    </center>--%>
    </div>

   
</asp:Content>

