<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunobitacoracuatrouno.aspx.cs" Inherits="estraunobitacoracuatrouno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
    <style>
       .primeracolumna{
            text-align:right;
            font-weight:bold;
        }
    
        .auto-style1 {
            color: #FF0000;
        }
    </style>

     <script type="text/javascript">
         var total = 1;
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
         $(function () {

             /*Configurar idioma del calandario*/
             $.datepicker.regional['es'] = {
                 closeText: 'Cerrar',
                 prevText: ' nextText: Sig>',
                 currentText: 'Hoy',
                 monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                 monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                 dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                 dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié;', 'Juv', 'Vie', 'Sáb'],
                 dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                 weekHeader: 'Sm',
                 dateFormat: 'dd/mm/yy',
                 firstDay: 1,
                 isRTL: false,
                 showMonthAfterYear: false,
                 yearSuffix: ''
             };
             /*Asignar idioma al calendario*/
             $.datepicker.setDefaults($.datepicker.regional['es']);

             $("input[type='datetime']").datepicker({
                 dateFormt: 'yy-mm-dd',
                 changeYear: true,
                 changeMonth: true
             });

             $.ajax({
                 url: 'estraunobitacoracuatro.aspx/cargarInstituciones',
                 type: 'POST',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#instituciones").html(response.d);
                 }
             });

             $("#instituciones").on('change', function () {
                 var data = "{'codInstitucion': '"+$('#instituciones').val()+"'}"
                 $.ajax({
                     url: 'estraunobitacoracuatro.aspx/cargarSedesInstitucion',
                     type: 'POST',
                     data: data,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#sedes").html(response.d);
                         var data = "{'codSede':'" + $("#sedes").val() + "'}";
                         $.ajax({
                             url: 'estraunobitacoracuatro.aspx/cargarLineaInvestigacion',
                             type: 'POST',
                             data: data,
                             contentType: 'application/json; charset=utf-8',
                             dataType: 'JSON',
                             success: function (response) {
                                 $("#grupoInvestigacion").html(response.d);
                             }
                         });
                     }
                 });
             });

             $("#sedes").on("change", function () {
                 var data = "{'codSede':'" + $("#sedes").val() + "'}";
                 $.ajax({
                     url: 'estraunobitacoracuatro.aspx/cargarLineaInvestigacion',
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

         function addrubros() {
             total = total + 1;
             if ($("#remove")) {
                 $("#remove").remove();
             }

             html = '<tr id="oCampus' + total + '">';
             html += '<td><select id="rubros' + total + '"  class="TextBox">';
             html += '<option value="insumo">Insumos para la investigación</option>';
             html += '<option value="papeleria">Papelería</option>';
             html += '<option value="transporte">Transporte municipal e intermunicipal</option>';
             html += '<option value="material">Material de Divulgación</option>';
             html += '<option value="refrigerio">Refrigerios</option>';
             html += '<option value="otros">Otros</option>';
             html += '</select></td>';
             html += '<td><input type="datetime" id="fechagasto' + total + '" class="TextBox"/></td>';
             html += '<td><input type="text" id="nproveedor' + total + '" class="TextBox"/></td>';
             html += '<td><input type="text" id="dgasto' + total + '" class="TextBox"/></td>';
             html += '<td><input type="text" id="vunitario' + total + '" class="TextBox" onkeypress="return isNumberKey(event);"/></td>';
             html += '<td id="oRadiotr' + total + '"><input type="text" id="vtotal' + total + '"  class="TextBox price" onkeypress="return isNumberKey(event);"/><button id="remove" onclick="fRemove(' + total + ')" class="btn btn-danger">-</button></td></tr>';
             $("#tablecampus").append(html);


             $("input[type='datetime']").datepicker({
                 dateFormt: 'yy-mm-dd',
                 changeYear: true,
                 changeMonth: true
             });
         }

         function fRemove(data) {
             var ant = data - 1;
             total = total - 1;
             $("#oCampus" + data).remove();
             $("#oRadiotr" + ant).append('<button id="remove" onclick="fRemove(' + ant + ')" class="btn btn-danger">-</button>');
         }

         function btnGuardar_Click() {
             //var num = 1;
             //var data = "";
             //var rubros = [];

             //$("#tablecampus tr").each(function () {
             //    data = [$("#rubros" + num).val(), $("#fechagasto" + num).val(), $("#nproveedor" + num).val(), $("#dgasto" + num).val(), $("#vunitario" + num).val(), $("#vtotal" + num).val()];
             //    rubros.push(data);
             //    num++;
             //});
             //console.log(rubros);
             //$.each(rubros, function (index, element) {
             //    var jsonData = "{'codProyecto': '" + $("#grupoInvestigacion").val().toString() + "', 'rubros': '" + element[0].toString() + "', 'fechaGasto': '" + element[1].toString() + "', 'nombreProveedor': '" + element[2].toString() + "', 'descripcionGasto': '" + element[3].toString() + "', 'valorTotal':'" + element[4].toString() + "'}";
             //    $.ajax({
             //        url: 'estraunobitacoracuatrouno.aspx/guardarInformefinanciero',
             //        type: 'POST',
             //        data: jsonData,
             //        contentType: 'application/json; charset=utf-8',
             //        dataType: 'JSON'
             //    });
             //});
         }

         function calculateSum() {
             var sum = 0;
             $(".price").each(function () {
                 if (!isNaN(this.value) && this.value.length != 0) {
                     sum += parseFloat(this.value);
                 }
                 $("#total").val(formatNumber.new(sum, "$"));
             });
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

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Estrategía Nro 1 - Bitacora Nro 4.1</h2><br />
<fieldset>
<legend>Agregar Bitacora</legend>
    <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
        <tr>
            <td>Institucion educativa</td>
            <td colspan="3">
                <table>
                    <tr>
                        <td>Filtar</td>
                    </tr>
                    <tr>
                        <td><input type="text" class="TextBox" placeholder="Codigo DANE o Nombre" style="width: 200px;"/></td>
                    </tr>
                    <tr>
                        <td><select id="instituciones" class="TextBox"></select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>Sede</td>
            <td><select id="sedes" class="TextBox"></select></td>
        </tr>
        <tr>
            <td>Grupo de investigación</td>
            <td><select id="grupoInvestigacion" class="TextBox"></select></td>
        </tr>
    </table>
    <fieldset>
        <legend>Informe de ejecución financiera</legend>
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <td><strong>Rubros</strong></td>
                    <td><strong>Fecha del gasto</strong></td>
                    <td><strong>Nombre del proveedor</strong></td>
                    <td><strong>Descripci&oacute;n del gasto</strong></td>
                    <td><strong>Valor unitario</strong></td>
                    <td><strong>Valor total</strong></td>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <td colspan="5"><strong>TOTAL</strong></td>
                    <td><input type="text" class="TextBox" disabled="disabled" id="total"/><input type="button" onclick="calculateSum();" value="Calcular" class="btn btn-primary" /></td>
                </tr>
            </tfoot>
            <tbody id="tablecampus">
                <tr>
                    <td>
                        <select class="TextBox" id="rubros1">
                            <option value="insumo">Insumos para la investigación</option>
                            <option value="papeleria">Papelería</option>
                            <option value="transporte">Transporte municipal e intermunicipal</option>
                            <option value="material">Material de Divulgación</option>
                            <option value="refrigerio">Refrigerios</option>
                            <option value="otro">Otros</option>
                        </select>
                    </td>
                    <td><input type="datetime" class="TextBox" id="fechagasto1"/></td>
                    <td><input type="text" class="TextBox" id="nproveedor1"/></td>
                    <td><input type="text" class="TextBox" id="dgasto1"/></td>
                    <td><input type="text" class="TextBox" id="vunitario1" onkeypress="return isNumberKey(event);"/></td>
                    <td><input type="text" class="TextBox price" id="vtotal1" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
       </table>
        <br />
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="addrubros();" /></td>
		    </tr>
	    </table>
    </fieldset>
</fieldset>
    <br />
    <center>
        <input type="button" class="btn btn-success" value="Guardar" onclick="btnGuardar_Click();" />
        <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
        <asp:Button runat="server" ID="btnSubirFirmaPop" Text="Cargar Evidencias" CssClass="btn btn-danger" OnClick="cargarEvidencias_Click" />
    </center>

      <ajx:ModalPopupExtender ID="PanelEdicion_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnSubirFirmaPop" PopupControlID="PanelEdicion" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

     <asp:Panel ID="PanelEdicion" runat="server" CssClass="modalPopup">
        <header class="headerpopup">
            <div style="float: left; margin-right: 15px" id="tituloPopup">
                Subir Imagen
            </div>
            <div style="float: right;">
                <asp:Label ID="btnCancelar" runat="server" Text="Cerrar" CssClass="botones"></asp:Label>
            </div>
        </header>
        <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>
                <asp:FileUpload ID="trepador" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnActualizarDatosTutoria" runat="server" Text="Subir Imagen" CssClass="botones" ValidationGroup="Editar"  />
            </div>
        </footer>
    </asp:Panel>

</asp:Content>

