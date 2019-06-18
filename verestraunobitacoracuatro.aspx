<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verestraunobitacoracuatro.aspx.cs" Inherits="verestraunobitacoracuatro" %>

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

            $("#asesores").change(function () {
                console.log($("#asesores").val());
                listadobitacora4($("#asesores").val());
            });
            
        });

        function listadobitacora4(codasesorcoordinador) {
            $("#tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'codasesorcoordinador':'" + codasesorcoordinador + "'}";
            $.ajax({
                type: 'POST',
                url: 'verestraunobitacoracuatro.aspx/listadobitacora4',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                data: jsondata,
                success: function (response) {
                    $("#tbody").html(response.d);
                }
            });
        }

        function cargarasesores() {

            $.ajax({
                type: 'POST',
                dataType: 'JSON',
                url: 'verestraunobitacoracuatro.aspx/cargarasesores',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    if (response.d != null) {
                        $("#asesores").html(response.d);
                    }
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

            function calculateSum() {
                var sum = 0;
                $(".price").each(function () {
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseFloat(this.value);
                    }
                    $("#txttotal").val(formatNumber.new(sum, "$"));
                });
            }

            

            $.ajax({
                url: 'estrag007.aspx/cargarDepartamentoMagdalena',
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
                    url: 'estrag007.aspx/cargarMunicipios',
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
                    url: 'estrag007.aspx/cargarInstituciones',
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
                    url: 'estrag007.aspx/cargarSedesInstitucion',
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
                    url: 'estrag007.aspx/cargarLineaInvestigacion',
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
                url: 'estrag007.aspx/loadSelectBitacoraCuatro',
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
                url: 'estrag007.aspx/cargaranios',
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    $('#anios').html(response.d);
                }
            });
        }
        function loadRubros(codigo)
        {
            //$("#grupoInvestigacion").on("change", function () {
            var data = "{'codigo':'" + codigo + "'}";
                $.ajax({
                    url: 'estrag007.aspx/searchRubros',
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
                        calculateSum();
                    }
                });
            //});
        }

        /*Metodo para guardar Rubros*/
        function btnGuardar_Click() {
            var jsonData = "{'codGrupoInvestigacion': '" + $("#grupoInvestigacion").val().toString() + "', 'valInsumo': '" + $("#txtinsumo").val().toString() + "', 'valPapeleria': '" + $("#txtpapeleria").val().toString() + "', 'valTransporte': '" + $("#txttransporte").val().toString() + "', 'valMaterial': '" + $("#txtmaterial").val().toString() + "', 'valRefrigerio': '" + $("#txtrefrigerio").val().toString() + "', 'valOtros': '" + $("#txtotros").val().toString() + "'}";
            $.ajax({
                url: 'estrag007.aspx/guardarRubros',
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

        function reset() {
            //$("#txttotal").val('');
            $("#txtinsumo").val('');
            $("#txtpapeleria").val('');
            $("#txttransporte").val('');
            $("#txtmaterial").val('');
            $("#txtrefrigerio").val('');
            $("#txtotros").val('');
           
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
                    url: 'estrag007.aspx/deletebitacora',
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
                    <th>Sesión</th>
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
                        <th>RUBRO (Recursos elegibles)</th>
                        <th>VALOR</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Insumos para la investigacíon</td>
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
                        <td>Otros</td>
                        <td><input id="txtotros" type="text" class="TextBox price" /></td>
                    </tr>
                     <tr>
                        <td>Total proyecto</td>
                        <td><input type="text" id="txttotal" class="TextBox" disabled="disabled"/></td>
                    </tr>
                </tbody>
            </table>
            <p><strong>Nota:</strong> No serán consideradas las propustas cuyo objetivo primordial sea la dotacíon de equipos o materiales didácticos (a nos ser que estos sean indispensables, locual debe estar justificado en el diseño de los trayectos de investigacíon); la construcción de infraestructura o el desarrollo de actividades como talleres, convivencias y otro tipo de eventos de intervención que no formen parte del proyecto general de investigación.</p>
            <p><strong>Nota:</strong> El presupuesto total no debe exceder la suma de $XXXXXX.oo</p>
            <p>* Gastos elegibles son aquellos seleccionados  para ser financiados con los recursos asignados al grupo de investigación de aula por el proyecto Ciclón.</p>
        </fieldset>
        <fieldset>
            <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
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
        <input type="button" class="btn btn-success" value="Guardar" onclick="btnGuardar_Click();" />
      
      <asp:Button runat="server" ID="btnSubirFirmaPop" Text="Cargar Evidencias" CssClass="btn btn-danger" OnClick="cargarEvidencias_Click" />
    </center>--%>
    </div>

   
</asp:Content>

