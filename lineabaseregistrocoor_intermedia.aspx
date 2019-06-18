<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseregistrocoor_intermedia.aspx.cs" Inherits="lineabaseregistrocoor_intermedia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


   <script type="text/javascript">
       var codinstitucion;
       var codigosede;
       $(document).ready(function () {
           cargarinfoinstitucion();
       });

       function cargarinfoinstitucion() {
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/cargarinfoinstitucion',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       codinstitucion = resp[1];
                       $("#infoie").html(resp[2]);
                       cargarsedes(codinstitucion);
                       buscarasesor(codinstitucion);
                   }
               }
           });
       }

       function buscarasesor(codinstitucion) {
           var jsonData = '{ "codinstitucion":"' + codinstitucion + '"}';

           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/buscarasesor',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[1] === "true") {
                       $("#asesor").html(resp[0]);
                   }
                   else {
                       cargarasesores();
                   }
               }
           });
       }
       function cargarasesores() {

           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/cargarasesores',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       $("#asesor").html(resp[1]);
                   }
               }
           });
       }

       function cargarsedes(codinstitucion) {
           var jsonData = '{ "codinstitucion":"' + codinstitucion + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/cargarsedes',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       $("#infose").html(resp[1]);
                   }
               }
           });
       }

       function disponibilidad(codsede) {
           $("#disponibilidad").fadeIn(500);
           $("#table").hide();
           cargarsedesxcod(codsede);
           codigosede = codsede;
       }

       function cargarsedesxcod(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/cargarsedesxcod',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       $("#infosede").html(resp[1]);
                       cargarequipamiento(codsede);
                   }
               }
           });
       }

       function cargarequipamiento(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/cargarequipamientoxsede',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       $("#txtd1").val(resp[1]);
                       $("#txtd2").val(resp[2]);
                       $("#txtd3").val(resp[3]);
                       $("#txtd4").val(resp[4]);
                       $("#txtd5").val(resp[5]);
                       $("#txtd6").val(resp[6]);
                       $("#txtd7").val(resp[7]);
                       $("#txtd8").val(resp[8]);

                       $("#txte1").val(resp[9]);
                       $("#txte2").val(resp[10]);
                       $("#txte3").val(resp[11]);
                       $("#txte4").val(resp[12]);
                       $("#txte5").val(resp[13]);
                       $("#txte6").val(resp[14]);
                       $("#txte7").val(resp[15]);
                       $("#txte8").val(resp[16]);
                       codsedeasesor = resp[17];

                       var txt1 = parseInt(resp[1]) + parseInt(resp[9]);
                      $("#txtt1").val(txt1);

                      var txt2 = parseInt(resp[2]) + parseInt(resp[10]);
                      $("#txtt2").val(txt2);

                      var txt3 = parseInt(resp[3]) + parseInt(resp[11]);
                      $("#txtt3").val(txt3);

                      var txt4 = parseInt(resp[4]) + parseInt(resp[12]);
                      $("#txtt4").val(txt4);

                      var txt5 = parseInt(resp[5]) + parseInt(resp[13]);
                      $("#txtt5").val(txt5);

                      var txt6 = parseInt(resp[6]) + parseInt(resp[14]);
                      $("#txtt6").val(txt6);

                      var txt7 = parseInt(resp[7]) + parseInt(resp[15]);
                      $("#txtt7").val(txt7);

                      var txt8 = parseInt(resp[8]) + parseInt(resp[16]);
                      $("#txtt8").val(txt8);

                      if (resp[18] == "si")
                          $("#dotaciontablet_si").attr('checked', true);
                      else if (resp[18] == "no")
                          $("#dotaciontablet_no").attr('checked', true);

                      if (resp[19] == "Siempre")
                          $("#usodotaciontabletg_siempre").attr('checked', true);
                      else if (resp[19] == "Casi Siempre")
                          $("#usodotaciontabletg_casi").attr('checked', true);
                      else if (resp[19] == "Algunas Veces")
                          $("#usodotaciontabletg_algunas").attr('checked', true);
                      else if (resp[19] == "Muy pocas Veces")
                          $("#usodotaciontabletg_pocas").attr('checked', true);
                      else if (resp[19] == "Nunca")
                          $("#usodotaciontabletg_nunca").attr('checked', true);

                      if (resp[20] == "si")
                          $("#conectividad_si").attr('checked', true);
                      else if (resp[20] == "no")
                          $("#conectividad_no").attr('checked', true);

                      if (resp[21] == "Siempre")
                          $("#funconectividadg_siempre").attr('checked', true);
                      else if (resp[21] == "Casi Siempre")
                          $("#funconectividadg_casi").attr('checked', true);
                      else if (resp[21] == "Algunas Veces")
                          $("#funconectividadg_algunas").attr('checked', true);
                      else if (resp[21] == "Muy pocas Veces")
                          $("#funconectividadg_pocas").attr('checked', true);
                      else if (resp[21] == "Nunca")
                          $("#funconectividadg_nunca").attr('checked', true);

                     if (resp[22] == "si")
                         $("#platapedago_si").attr('checked', true);
                     else if (resp[22] == "no")
                         $("#platapedago_no").attr('checked', true);

                     if (resp[23] == "si")
                        $("#proceformtic_si").attr('checked', true);
                     else if (resp[23] == "no")
                         $("#proceformtic_no").attr('checked', true);

                      if (resp[24] == "si")
                          $("#planmejortic_si").attr('checked', true);
                      else if (resp[24] == "no")
                          $("#planmejortic_no").attr('checked', true);

                      $("#herramientas1").val(resp[25]);
                      $("#direccion1").val(resp[26]);

                      $("#herramientas2").val(resp[27]);
                      $("#direccion2").val(resp[28]);

                      $("#herramientas3").val(resp[29]);
                      $("#direccion3").val(resp[30]);

                      $("#herramientas4").val(resp[31]);
                      $("#direccion4").val(resp[32]);

                      $("#herramientas5").val(resp[33]);
                      $("#direccion5").val(resp[34]);

                      $("#textplatapedago").val(resp[35]);

                      $("#nomproceform").val(resp[36]);
                      $("#duraproceform").val(resp[37]);
                      $("#totalproceform").val(resp[38]);

                      $("#incluplanmejortic").val(resp[39]);
                      $("#desaplanmejortic").val(resp[40]);
                      $("#efectplanmejortic").val(resp[41]);

                      if (resp[42] == "Siempre")
                          $("#usodotaciontabletr_siempre").attr('checked', true);
                      else if (resp[42] == "Casi Siempre")
                          $("#usodotaciontabletr_casi").attr('checked', true);
                      else if (resp[42] == "Algunas Veces")
                          $("#usodotaciontabletr_algunas").attr('checked', true);
                      else if (resp[42] == "Muy pocas Veces")
                          $("#usodotaciontabletr_pocas").attr('checked', true);
                      else if (resp[42] == "Nunca")
                          $("#usodotaciontabletr_nunca").attr('checked', true);

                      if (resp[43] == "Siempre")
                          $("#usodotaciontabletm_siempre").attr('checked', true);
                      else if (resp[43] == "Casi Siempre")
                          $("#usodotaciontabletm_casi").attr('checked', true);
                      else if (resp[43] == "Algunas Veces")
                          $("#usodotaciontabletm_algunas").attr('checked', true);
                      else if (resp[43] == "Muy pocas Veces")
                          $("#usodotaciontabletm_pocas").attr('checked', true);
                      else if (resp[43] == "Nunca")
                          $("#usodotaciontabletm_nunca").attr('checked', true);

                      if (resp[44] == "Siempre")
                          $("#funconectividadr_siempre").attr('checked', true);
                      else if (resp[44] == "Casi Siempre")
                          $("#funconectividadr_casi").attr('checked', true);
                      else if (resp[44] == "Algunas Veces")
                          $("#funconectividadr_algunas").attr('checked', true);
                      else if (resp[44] == "Muy pocas Veces")
                          $("#funconectividadr_pocas").attr('checked', true);
                      else if (resp[44] == "Nunca")
                          $("#funconectividadr_nunca").attr('checked', true);

                      if (resp[45] == "Siempre")
                          $("#funconectividadm_siempre").attr('checked', true);
                      else if (resp[45] == "Casi Siempre")
                          $("#funconectividadm_casi").attr('checked', true);
                      else if (resp[45] == "Algunas Veces")
                          $("#funconectividadm_algunas").attr('checked', true);
                      else if (resp[45] == "Muy pocas Veces")
                          $("#funconectividadm_pocas").attr('checked', true);
                      else if (resp[45] == "Nunca")
                          $("#funconectividadm_nunca").attr('checked', true);

                   }
                   else {
                       alert(resp[1]);
                   }
               }
           });
       }

       function btnguardar(event) {
           if (event == "insert") {
               if (!$("input[name=dotaciontablet]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 6");
               } else if (!$("input[name=usodotaciontabletg]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 7: Grupos de investigación infantiles y juveniles");
               } else if (!$("input[name=usodotaciontabletr]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 7: Redes Temáticas Institucionales");
               } else if (!$("input[name=usodotaciontabletm]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 7: Formación de maestros (Ciclón)");
               } else if (!$("input[name=conectividad]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 8");
               } else if (!$("input[name=funconectividadg]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 9: Grupos de investigación infantiles y juveniles");
               } else if (!$("input[name=funconectividadr]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 9: Redes Temáticas Institucionales");
               } else if (!$("input[name=funconectividadm]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 9: Formación de maestros (Ciclón)");
               } else if (!$("input[name=platapedago]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta Plataformas pedagógicas");
               } else if (!$("input[name=proceformtic]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2.1");
               } else if (!$("input[name=planmejortic]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2.2");
               }

               else {
                   guardarequipamientodocentes();
                   guardarequipamientoestudiantes();
                   guardarpreguntascerradas();
                   guardarherramientasdispoie();
                   guardarpreguntasabiertas();
                   alert("Datos guardados correctamente");
                   btnregresar();
                   //reset();
                   //$("#table").fadeIn(500);
                   //$("#disponibilidad").hide();
               }
              
           }
           else {

           }
       }
       function guardarequipamientodocentes() {
           var jsonData = '{ "tipo":"docentes", "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "txt1":"' + $("#txtd1").val() + '", "txt2":"' + $("#txtd2").val() + '", "txt3":"' + $("#txtd3").val() + '", "txt4":"' + $("#txtd4").val() + '", "txt5":"' + $("#txtd5").val() + '", "txt6":"' + $("#txtd6").val() + '", "txt7":"' + $("#txtd7").val() + '", "txt8":"' + $("#txtd8").val() + '"}';
            $.ajax({
                type: 'POST',
                url: 'lineabaseregistrocoor_intermedia.aspx/guardardatos',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData
            });
       }

       function guardarequipamientoestudiantes() {
           var jsonData = '{ "tipo":"estudiantes", "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "txt1":"' + $("#txte1").val() + '", "txt2":"' + $("#txte2").val() + '", "txt3":"' + $("#txte3").val() + '", "txt4":"' + $("#txte4").val() + '", "txt5":"' + $("#txte5").val() + '", "txt6":"' + $("#txte6").val() + '", "txt7":"' + $("#txte7").val() + '", "txt8":"' + $("#txte8").val() + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/guardardatos',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData
           });
       }

       function guardarpreguntascerradas() {
           var jsonData = '{ "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "dotaciontablet":"' + $('input:radio[name=dotaciontablet]:checked').val() + '", "usodotaciontabletg":"' + $('input:radio[name=usodotaciontabletg]:checked').val() + '", "usodotaciontabletr":"' + $('input:radio[name=usodotaciontabletr]:checked').val() + '", "usodotaciontabletm":"' + $('input:radio[name=usodotaciontabletm]:checked').val() + '", "conectividad":"' + $('input:radio[name=conectividad]:checked').val() + '", "funconectividadg":"' + $('input:radio[name=funconectividadg]:checked').val() + '", "funconectividadr":"' + $('input:radio[name=funconectividadr]:checked').val() + '", "funconectividadm":"' + $('input:radio[name=funconectividadm]:checked').val() + '", "platapedago":"' + $('input:radio[name=platapedago]:checked').val() + '", "proceformtic":"' + $('input:radio[name=proceformtic]:checked').val() + '", "planmejortic":"' + $('input:radio[name=planmejortic]:checked').val() + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/guardardatospreguntascerradas',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData
           });
       }

       function guardarherramientasdispoie() {
           var jsonData = '{ "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "herramientas1":"' + $('#herramientas1').val() + '", "direccion1":"' + $('#direccion1').val() + '", "herramientas2":"' + $('#herramientas2').val() + '", "direccion2":"' + $('#direccion2').val() + '", "herramientas3":"' + $('#herramientas3').val() + '", "direccion3":"' + $('#direccion3').val() + '", "herramientas4":"' + $('#herramientas4').val() + '", "direccion4":"' + $('#direccion4').val() + '", "herramientas5":"' + $('#herramientas5').val() + '", "direccion5":"' + $('#direccion5').val() + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/guardardatosherramientasdispoie',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData
           });
       }

       function guardarpreguntasabiertas() {
           var jsonData = '{ "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "textplatapedago":"' + $('#textplatapedago').val() + '", "nomproceform":"' + $('#nomproceform').val() + '", "duraproceform":"' + $('#duraproceform').val() + '", "totalproceform":"' + $('#totalproceform').val() + '", "incluplanmejortic":"' + $('#incluplanmejortic').val() + '", "desaplanmejortic":"' + $('#desaplanmejortic').val() + '", "efectplanmejortic":"' + $('#efectplanmejortic').val() + '"}';
           $.ajax({
               type: 'POST',
               url: 'lineabaseregistrocoor_intermedia.aspx/guardardatospreguntasabiertas',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData
           });
       }

       function btnregresar() {
           window.location.href = "lineabaseregistrocoor_intermedia.aspx";
           //$("#table").fadeIn(500);
           //$("#disponibilidad").hide();
           //reset();
       }

       function reset() {
           $("#txtd1").val('');
           $("#txtd2").val('');
           $("#txtd3").val('');
           $("#txtd4").val('');
           $("#txtd5").val('');
           $("#txtd6").val('');
           $("#txtd7").val('');
           $("#txtd8").val('');

           $("#txte1").val('');
           $("#txte2").val('');
           $("#txte3").val('');
           $("#txte4").val('');
           $("#txte5").val('');
           $("#txte6").val('');
           $("#txte7").val('');
           $("#txte8").val('');
           codsedeasesor = '';

           $("#txtt1").val('');
           $("#txtt2").val('');
           $("#txtt3").val('');
           $("#txtt4").val('');
           $("#txtt5").val('');
           $("#txtt6").val('');
           $("#txtt7").val('');
           $("#txtt8").val('');

               $("#dotaciontablet_si").attr('checked', false);
               $("#dotaciontablet_no").attr('checked', false);

               $("#usodotaciontabletg_siempre").attr('checked', false);
               $("#usodotaciontabletg_casi").attr('checked', false);
               $("#usodotaciontabletg_algunas").attr('checked', false);
               $("#usodotaciontabletg_pocas").attr('checked', false);
               $("#usodotaciontabletg_nunca").attr('checked', false);

               $("#usodotaciontabletr_siempre").attr('checked', false);
               $("#usodotaciontabletr_casi").attr('checked', false);
               $("#usodotaciontabletr_algunas").attr('checked', false);
               $("#usodotaciontabletr_pocas").attr('checked', false);
               $("#usodotaciontabletr_nunca").attr('checked', false);

               $("#usodotaciontabletm_siempre").attr('checked', false);
               $("#usodotaciontabletm_casi").attr('checked', false);
               $("#usodotaciontabletm_algunas").attr('checked', false);
               $("#usodotaciontabletm_pocas").attr('checked', false);
               $("#usodotaciontabletm_nunca").attr('checked', false);

               $("#conectividad_si").attr('checked', false);
               $("#conectividad_no").attr('checked', false);
              
               $("#funconectividadg_siempre").attr('checked', false);
               $("#funconectividadg_casi").attr('checked', false);
               $("#funconectividadg_algunas").attr('checked', false);
               $("#funconectividadg_pocas").attr('checked', false);
               $("#funconectividadg_nunca").attr('checked', false);

               $("#funconectividadr_siempre").attr('checked', false);
               $("#funconectividadr_casi").attr('checked', false);
               $("#funconectividadr_algunas").attr('checked', false);
               $("#funconectividadr_pocas").attr('checked', false);
               $("#funconectividadr_nunca").attr('checked', false);

               $("#funconectividadm_siempre").attr('checked', false);
               $("#funconectividadm_casi").attr('checked', false);
               $("#funconectividadm_algunas").attr('checked', false);
               $("#funconectividadm_pocas").attr('checked', false);
               $("#funconectividadm_nunca").attr('checked', false);

               $("#platapedago_si").attr('checked', false);
               $("#platapedago_no").attr('checked', false);
               $("#proceformtic_si").attr('checked', false);
               $("#proceformtic_no").attr('checked', false);
               $("#planmejortic_si").attr('checked', false);
               $("#planmejortic_no").attr('checked', false);

           $("#herramientas1").val('');
           $("#direccion1").val('');

           $("#herramientas2").val('');
           $("#direccion2").val('');

           $("#herramientas3").val('');
           $("#direccion3").val('');

           $("#herramientas4").val('');
           $("#direccion4").val('');

           $("#herramientas5").val('');
           $("#direccion5").val('');

           $("#textplatapedago").val('');

           $("#nomproceform").val('');
           $("#duraproceform").val('');
           $("#totalproceform").val('');

           $("#incluplanmejortic").val('');
           $("#desaplanmejortic").val('');
           $("#efectplanmejortic").val('');
       }

       function isNumberKey(e) {
           var charCode = (e.which) ? e.which : event.keyCode
           if (charCode > 31 && (charCode < 48 || charCode > 75))
               return false;
           return true;
       }

       function valortotal(data1, data2) {
           var cantd = $("#txtd" + data1).val();
           var cante = $("#txte" + data1).val();
           var valorfinal = parseInt(cantd) + parseInt(cante);
           $("#txtt" + data2).val(valorfinal);
       }
   </script>



    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display:none;" ></div>
<div id="mensaje" runat="server"></div><br /><br />
    <asp:Label ID="lblCodRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodDANE" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodSedeinsAsesor" runat="server" Visible="false"></asp:Label>

    <h2 style="text-decoration: none;">FORTALECIMIENTO DE LA CULTURA CIUDADANA Y DEMOCRÁTICA EN CTeI A TRAVÉS DE LA IEP APOYADA EN TIC EN EL DPTO DEL MAGDALENA<br /><center>Evaluación Intermedia</center></h2>

    <center>
        <h2>
            Instrumento No. 03, Disponibilidad, acceso y uso de TICS en IEP 
        </h2>
    </center>

    <div id="table">

         <p>
            <b>Introducción:</b><br /><br />

            Para la evaluación intermedia del programa CICLÓN se requiere recoger información institucional básica sobre el equipamiento institucional de TIC y su uso pedagógico, con el objeto de indagar sobre el impacto de las dotaciones tecnológicas que se han realizado. 
            
            <br /><br />
            <b>Objetivo: </b>
            <br /><br />
            Acopiar información de carácter documental sobre el equipamiento, dotaciones entregadas por el proyecto CICLÓN y uso de TIC en las sedes educativas vinculadas al proyecto.
            <br /><br />
            <b>Metodología: </b>
            <br /><br />
            El instrumento será implementado por el profesional de FUNTICS con el Rector/a, Director/a o a quien se delegue en la Institución Educativa diligenciado directamente en el SIEP. 
            Las dotaciones entregadas a las Instituciones Educativas serán verificadas contra las actas respectivas que deben ser solicitadas a la Secretaria de Educación Departamental.


        </p>

         <table>
            <tr>
                <td>Seleccione el profesional: </td>
                <td><select id="asesor" class="TextBox"></select></td>
            </tr>
        </table>

    <fieldset>
        <legend>Datos institucionales</legend>

              <table class="mGridTesoreria" align="center">
                   <thead>
                       <tr>
                           <th>Dane</th>
                           <th>Institución</th>
                       </tr>
                   </thead>
                   <tbody id="infoie"></tbody>
               </table>

        <br />
        <fieldset>
        <legend>Datos Sede</legend>

            <table class="mGridTesoreria" align="center">
                   <thead>
                       <tr>
                           <th>Dane</th>
                           <th>Consecutivo Sede</th>
                           <th>Sede</th>
                           <th></th>
                       </tr>
                   </thead>
                   <tbody id="infose"></tbody>
               </table>

        </fieldset>
         
    </fieldset>

    </div>
       
    <div id="disponibilidad" style="display: none;">

         <fieldset>
        <legend>Datos Sede</legend>

            <table class="mGridTesoreria" align="center">
                   <thead>
                       <tr>
                           <th>Dane</th>
                            <th>Consecutivo Sede</th>
                           <th>Sede</th>
                       </tr>
                   </thead>
                     <tbody id="infosede"></tbody>
               </table>

        </fieldset>

        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td style="font-weight:bold;">
                    1.	Instituciones educativas con infraestructura para TIC (conectividad y equipamiento)
                </td>
            </tr>
            <tr>
                <td>
                    1.1.	Equipamiento:   
                </td>
            </tr>
            <tr>
                <td>
                    <table border="1" class="mGridTesoreria">
                        <tr>
                            <td rowspan="3" style="font-weight:bold;text-align:center">
                                Usuarios
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" style="font-weight:bold;text-align:center">
                                Nro Pc
                            </th>
                            <th colspan="2" style="font-weight:bold;text-align:center">
                               No. Portátiles
                            </th>
                             <th colspan="2" style="font-weight:bold;text-align:center">
                                No. Tablet
                            </th>
                             <th colspan="2" style="font-weight:bold;text-align:center">
                                No. Tableros inteligentes
                            </th>
                        </tr>
                        <tr>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                        </tr>
                         <tr>
                            <th style="font-weight:bold">
                                Docentes 
                            </th>
                            <td><input type="text" class="TextBox" id="txtd1" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(1,1)" /></td>
                            <td><input type="text" class="TextBox" id="txtd2" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(2,2)" /></td>
                            <td><input type="text" class="TextBox" id="txtd3" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(3,3)" /></td>
                            <td><input type="text" class="TextBox" id="txtd4" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(4,4)" /></td>
                            <td><input type="text" class="TextBox" id="txtd5" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(5,5)" /></td>
                            <td><input type="text" class="TextBox" id="txtd6" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(6,6)" /></td>
                            <td><input type="text" class="TextBox" id="txtd7" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(7,7)" /></td>
                            <td><input type="text" class="TextBox" id="txtd8" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(8,8)" /></td>
                        </tr>
                         <tr>
                           <th style="font-weight:bold">
                                Estudiantes
                            </th>
                            <td><input type="text" class="TextBox" id="txte1" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(1,1)" /></td>
                            <td><input type="text" class="TextBox" id="txte2" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(2,2)" /></td>
                            <td><input type="text" class="TextBox" id="txte3" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(3,3)" /></td>
                            <td><input type="text" class="TextBox" id="txte4" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(4,4)" /></td>
                            <td><input type="text" class="TextBox" id="txte5" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(5,5)" /></td>
                            <td><input type="text" class="TextBox" id="txte6" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(6,6)" /></td>
                            <td><input type="text" class="TextBox" id="txte7" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(7,7)" /></td>
                            <td><input type="text" class="TextBox" id="txte8" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(8,8)" /></td>
                        </tr>
                         <tr>
                            <th style="font-weight:bold">
                                Total 
                            </th>
                            <td><input type="text" class="TextBox" id="txtt1" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt2" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt3" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt4" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt5" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt6" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt7" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txtt8" style="width:75px;" disabled/></td>
                        </tr>
                    </table>
                </td>
            </tr>
           </table>

        <br />

        6.	¿Ha recibido dotación de tabletas por parte del programa CICLÓN?
        <table>
            <tr>
                <td>Si<input id="dotaciontablet_si" type="radio" name="dotaciontablet" value="si" /></td>
                <td>No<input id="dotaciontablet_no" type="radio" name="dotaciontablet" value="no" /></td>
            </tr>
        </table>

        <br />

        7.	Si la respuesta a la pregunta anterior es SI ¿Se utilizan las tabletas en los espacios de formación del programa?
        <table border="1" class="mGridTesoreria">
            <tr>
                <th >
                    Grupos de investigación infantiles y juveniles:
                </th>
                <td>
                    Siempre<input id="usodotaciontabletg_siempre" type="radio" name="usodotaciontabletg" value="Siempre" />
                </td>
                <td>
                    Casi Siempre<input id="usodotaciontabletg_casi" type="radio" name="usodotaciontabletg" value="Casi Siempre" />
                </td>
                <td>
                    Algunas Veces<input id="usodotaciontabletg_algunas" type="radio" name="usodotaciontabletg" value="Algunas Veces" />
                </td>
                <td>
                    Muy pocas Veces<input id="usodotaciontabletg_pocas" type="radio" name="usodotaciontabletg" value="Muy pocas Veces" />
               </td>
                <td>
                    Nunca<input id="usodotaciontabletg_nunca" type="radio" name="usodotaciontabletg" value="Nunca" />
                </td>
            </tr>
             <tr>
                <th >
                   Redes Temáticas Institucionales:
                </th>
                <td>
                    Siempre<input id="usodotaciontabletr_siempre" type="radio" name="usodotaciontabletr" value="Siempre" />
                    
                </td>
                 <td>
                     Casi Siempre<input id="usodotaciontabletr_casi" type="radio" name="usodotaciontabletr" value="Casi Siempre" />
                    
                 </td>
                 <td>
                     Algunas Veces<input id="usodotaciontabletr_algunas" type="radio" name="usodotaciontabletr" value="Algunas Veces" />
                    
                 </td>
                 <td>
                     Muy pocas Veces<input id="usodotaciontabletr_pocas" type="radio" name="usodotaciontabletr" value="Muy pocas Veces" />
                    
                 </td>
                 <td>
                     Nunca<input id="usodotaciontabletr_nunca" type="radio" name="usodotaciontabletr" value="Nunca" />
                 </td>
            </tr>
             <tr>
                <th>
                   Formación de maestros (Ciclón):
                </th>
                <td>
                    Siempre<input id="usodotaciontabletm_siempre" type="radio" name="usodotaciontabletm" value="Siempre" />
                   
                </td>
                 <td>
                      Casi Siempre<input id="usodotaciontabletm_casi" type="radio" name="usodotaciontabletm" value="Casi Siempre" />
                    
                 </td>
                 <td>
                     Algunas Veces<input id="usodotaciontabletm_algunas" type="radio" name="usodotaciontabletm" value="Algunas Veces" />
                    
                 </td>
                 <td>
                     Muy pocas Veces<input id="usodotaciontabletm_pocas" type="radio" name="usodotaciontabletm" value="Muy pocas Veces" />
                    
                 </td>
                 <td>
                     Nunca<input id="usodotaciontabletm_nunca" type="radio" name="usodotaciontabletm" value="Nunca" />
                 </td>
            </tr>
           <%-- <tr>
                <td>Si<input id="usodotaciontablet_si" type="radio" name="usodotaciontablet" value="si" /></td>
                <td>No<input id="usodotaciontablet_no" type="radio" name="usodotaciontablet" value="no" /></td>
            </tr>--%>
        </table>

         <br />

        8.	¿Ha recibido dotación de conectividad por parte del programa CICLÓN? 
        <table>
            <tr>
                <td>Si<input id="conectividad_si" type="radio" name="conectividad" value="si" /></td>
                <td>No<input id="conectividad_no" type="radio" name="conectividad" value="no" /></td>
            </tr>
        </table>

         <br />

       9.	Si la respuesta a la pregunta anterior es SI ¿Se utiliza la conectividad en los espacios de formación del programa?
         <table border="1" class="mGridTesoreria">
            <tr>
                <th >
                    Grupos de investigación infantiles y juveniles:
                </th>
                <td>
                    Siempre<input id="funconectividadg_siempre" type="radio" name="funconectividadg" value="Siempre" />
                </td>
                <td>
                    Casi Siempre<input id="funconectividadg_casi" type="radio" name="funconectividadg" value="Casi Siempre" />
                </td>
                <td>
                    Algunas Veces<input id="funconectividadg_algunas" type="radio" name="funconectividadg" value="Algunas Veces" />
                </td>
                <td>
                    Muy pocas Veces<input id="funconectividadg_pocas" type="radio" name="funconectividadg" value="Muy pocas Veces" />
               </td>
                <td>
                    Nunca<input id="funconectividadg_nunca" type="radio" name="funconectividadg" value="Nunca" />
                </td>
            </tr>
             <tr>
                <th >
                   Redes Temáticas Institucionales:
                </th>
                <td>
                    Siempre<input id="funconectividadr_siempre" type="radio" name="funconectividadr" value="Siempre" />
                    
                </td>
                 <td>
                     Casi Siempre<input id="funconectividadr_casi" type="radio" name="funconectividadr" value="Casi Siempre" />
                    
                 </td>
                 <td>
                     Algunas Veces<input id="funconectividadr_algunas" type="radio" name="funconectividadr" value="Algunas Veces" />
                    
                 </td>
                 <td>
                     Muy pocas Veces<input id="funconectividadr_pocas" type="radio" name="funconectividadr" value="Muy pocas Veces" />
                    
                 </td>
                 <td>
                     Nunca<input id="funconectividadr_nunca" type="radio" name="funconectividadr" value="Nunca" />
                 </td>
            </tr>
             <tr>
                <th>
                   Formación de maestros (Ciclón):
                </th>
                <td>
                    Siempre<input id="funconectividadm_siempre" type="radio" name="funconectividadm" value="Siempre" />
                   
                </td>
                 <td>
                      Casi Siempre<input id="funconectividadm_casi" type="radio" name="funconectividadm" value="Casi Siempre" />
                    
                 </td>
                 <td>
                     Algunas Veces<input id="funconectividadm_algunas" type="radio" name="funconectividadm" value="Algunas Veces" />
                    
                 </td>
                 <td>
                     Muy pocas Veces<input id="funconectividadm_pocas" type="radio" name="funconectividadm" value="Muy pocas Veces" />
                    
                 </td>
                 <td>
                     Nunca<input id="funconectividadm_nunca" type="radio" name="funconectividadm" value="Nunca" />
                 </td>
            </tr>
        </table>
       <%-- <table>
            <tr>
                <td>Buena<input id="funconectividad_b" type="radio" name="funconectividad" value="buena" /></td>
                <td>Regular<input id="funconectividad_r" type="radio" name="funconectividad" value="regular" /></td>
                 <td>Mala<input id="funconectividad_m" type="radio" name="funconectividad" value="mala" /></td>
            </tr>
        </table>--%>

         <br />
        <b> 1.2.	De cuál de estas herramientas dispone la institución educativa:</b>
          <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:40%;" >
          
            <tr>
                <td>
                    <table class="mGridTesoreria">
                        <tr style="font-weight:bold;">
                            <th>Herramienta</th>
                            <th>Dirección</th>
                        </tr>
                        <tr>
                            <td>
                                <select id="herramientas1" class="TextBox">
                                    <option value="N/A" selected>N/A</option>
                                    <option value="Wikis">Wikis</option>
                                    <option value="Blogs">Blogs</option>
                                    <option value="Foros">Foros</option>
                                    <option value="Redes sociales">Redes sociales</option>
                                    <option value="Página de internet">Página de internet</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" id="direccion1" class="TextBox" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <select id="herramientas2" class="TextBox">
                                    <option value="N/A" selected>N/A</option>
                                   <option value="Wikis">Wikis</option>
                                    <option value="Blogs">Blogs</option>
                                    <option value="Foros">Foros</option>
                                    <option value="Redes sociales">Redes sociales</option>
                                    <option value="Página de internet">Página de internet</option>
                                </select>
                            </td>
                            <td>
                               
                                <input type="text" id="direccion2" class="TextBox" />
                               
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <select id="herramientas3" class="TextBox">
                                    <option value="N/A" selected>N/A</option>
                                   <option value="Wikis">Wikis</option>
                                    <option value="Blogs">Blogs</option>
                                    <option value="Foros">Foros</option>
                                    <option value="Redes sociales">Redes sociales</option>
                                    <option value="Página de internet">Página de internet</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" id="direccion3" class="TextBox" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <select id="herramientas4" class="TextBox">
                                    <option value="N/A" selected>N/A</option>
                                    <option value="Wikis">Wikis</option>
                                    <option value="Blogs">Blogs</option>
                                    <option value="Foros">Foros</option>
                                    <option value="Redes sociales">Redes sociales</option>
                                    <option value="Página de internet">Página de internet</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" id="direccion4" class="TextBox" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <select id="herramientas5" class="TextBox">
                                    <option value="N/A" selected>N/A</option>
                                    <option value="Wikis">Wikis</option>
                                    <option value="Blogs">Blogs</option>
                                    <option value="Foros">Foros</option>
                                    <option value="Redes sociales">Redes sociales</option>
                                    <option value="Página de internet">Página de internet</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" id="direccion5" class="TextBox" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           </table>
        Plataformas pedagógicas <table><tr><td>Si<input id="platapedago_si" type="radio" name="platapedago" value="si" />No<input id="platapedago_no" type="radio" name="platapedago" value="no" /></td></tr></table>
        ¿Cuál o cuáles?<br />
        <textarea id="textplatapedago" cols="130" rows="5" class="TextBox"> </textarea>

        <br /><br />
        <b>2.	Desarrollo profesional de los docentes en el uso pedagógico de medios y tecnologías de información y comunicación.</b>
        <br /><br />
        2.1.	¿La institución ha participado en procesos de formación de docentes en el uso de las TIC?  

        <table><tr><td>Si<input id="proceformtic_si" type="radio" name="proceformtic" value="si" />No<input id="proceformtic_no" type="radio" name="proceformtic" value="no" /></td></tr></table>
        
        <table aling="center">
            <tr>
                <td> Nombre del proceso de formación:</td>
                <td> <input type="text" class="TextBox" id="nomproceform" /></td>
            </tr>
            <tr>
                <td> Duración en horas la capacitación: </td>
                <td> <input type="text" class="TextBox" id="duraproceform" /></td>
            </tr>
            <tr>
                <td> Total beneficiario y beneficiarias: </td>
                <td> <input type="text" class="TextBox" id="totalproceform" /></td>
            </tr>
        </table>
        <br /><br />
        2.2.	¿En los últimos tres Planes de Mejoramiento Institucional se han incluido propuestas de mejoramiento en el uso de las TIC?

        <table><tr><td>Si<input id="planmejortic_si" type="radio" name="planmejortic" value="si" />No<input id="planmejortic_no" type="radio" name="planmejortic" value="no" /></td></tr></table>
        
        <table aling="center">
            <tr>
                <td> Cuáles se han incluido:</td>
                <td> <input type="text" class="TextBox" id="incluplanmejortic" /></td>
            </tr>
            <tr>
                <td> Cuales se han desarrollado:  </td>
                <td> <input type="text" class="TextBox" id="desaplanmejortic" /></td>
            </tr>
            <tr>
                <td> Cuáles han sido los efectos en la institución:  </td>
                <td> <input type="text" class="TextBox" id="efectplanmejortic" /></td>
            </tr>
        </table>
       
        <table align="center">
            <tr>
                <td><a href="#" class="btn btn-success" onclick="btnguardar('insert')">Guardar</a></td>
                <td><a href="#" class="btn btn-primary" onclick="btnregresar()">Regresar</a></td>
            </tr>
        </table>

    </div>
     




    <!--



     <table align="center">
        <tr>
             <td align="center">
                 <asp:Button ID="btnIniciarDisponibilidadTIC" Visible="true" runat="server" CssClass="btn btn-primary" Text="03 - Disponibilidad, acceso y uso TIC" OnClick="btnIniciarDisponibilidadTIC_Onclick" />
            </td>
        </tr>
         <tr>
             <td>
                <b> Introducción </b><br />

                    Para la construcción de la línea de base del proyecto Ciclón se requiere recoger información institucional básica sobre el equipamiento institucional de TIC y su uso pedagógico, con el objeto de aportar indicadores para la línea de base del proyecto. <br /><br />
                    Para su elaboración se hizo una revisión del marco de política tanto a nivel nacional como departamental para indagar sobre la normatividad con referencia a TIC. Los artículos 20 y 67 de la Constitución Política establecen que el Estado promoverá el derecho al acceso a las Tecnologías de la Información y las Comunicaciones que permitan entre otros, el ejercicio pleno al derecho de la educación. Inspirada en estos principios, la Ley 1341 de febrero de 2009 establece que las entidades del orden nacional y territorial dispondrán lo pertinente para garantizar el uso y acceso a estos derechos. Igualmente el Plan Nacional de Tics 2008 - 2019 genera directrices al mismo fin.<br />
                    <br />
                    <b>Objetivo</b><br />
                    Acopiar información de línea de base sobre el equipamiento y uso de TIC, en las sedes educativas vinculadas al proyecto Ciclón.
                    <br /><br />
                  <b> Metodología</b><br />

                    Este instrumento será diligenciado en dos partes:<br />
                    La primera parte será migrado de los instrumentos 01, C600A y C600B o del SIMAT.<br />
                    La segunda parte del instrumento será implementado por el Docente Asesor de FUNTIC o quien haga sus veces con el Rector/a, Director/a o a quien se delegue en la Institución Educativa diligenciado directamente en el SIEP. 

             </td>
         </tr>
    </table>

     <fieldset>
            <legend>Sedes de la Institución Educativa</legend>

          
        <asp:GridView ID="GridSedes" runat="server" CellPadding="4" DataKeyNames="cod"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen sedes para esta institución."
            GridLines="None" >
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="codSede" HeaderStyle-CssClass="ocultarcell" >
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nit" HeaderText="DANE">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                  <asp:BoundField DataField="consesede" HeaderText="Consecutivo Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Dirección">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
               <%--  <asp:BoundField DataField="telefono" HeaderText="Telefono">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="codmunicipio" HeaderText="codMunicipio" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrem" HeaderText="Municipio" />
                 <asp:BoundField DataField="codzona" HeaderText="codzona" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nomzona" HeaderText="Zona" />
                <asp:BoundField DataField="sede" HeaderText="Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
              <asp:BoundField DataField="codinstitucion" HeaderText="codinstitucion" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
           

                  <asp:TemplateField>
                    <HeaderTemplate>
                        03 x Sede
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgInfoxSede" runat="server" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgInfoxSede_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </fieldset>

   <!-- Instrumento 03 Disposición, acceso y uso de las TICS 
    <asp:Panel ID="PanelDisposicionTIC" runat="server" Visible="false">
         <h2 style="text-align:center"><%--Instrumento No. 03 <br />--%>
            Disponibilidad, acceso y uso de Tics </h2>

        <fieldset>
            <legend>Primera Parte</legend>
            <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td style="font-weight:bold;">
                    1.	Instituciones educativas con infraestructura para TIC (conectividad y equipamiento)
                </td>
            </tr>
            <tr>
                <td>
                    1.1.	Equipamiento:   
                </td>
            </tr>
            <tr>
                <td>
                    <table border="1">
                        <tr>
                            <td rowspan="3" style="font-weight:bold;text-align:center">
                                Usuarios
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                                Nro Pc
                            </td>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                               No. Portátiles
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tablet
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tableros inteligentes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                        </tr>
                        <tr>
                           <td style="font-weight:bold">
                                Administración  
                            </td>
                            <td><asp:TextBox runat="server" ID="txtAdminPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Docentes 
                            </td>
                            <td><asp:TextBox runat="server" ID="txtDocentePCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocentePCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocentePortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocentePortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                           <td style="font-weight:bold">
                                Estudiantes
                            </td>
                           <td><asp:TextBox runat="server" ID="txtEstudiantesPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Total 
                            </td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
                </table>
            <table><tr><td>  <asp:Button ID="btnPrimerGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar_OnClick" /></td></tr></table>
           <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                <tr>
                    <td>
                        1.1.1.	Equipamiento desagregado según estudiantes por grado
                    </td>
                 </tr>
                <tr>
                    <td>
                        <table border="1">
                        <tr>
                            <td rowspan="3" style="font-weight:bold;text-align:center">
                                Estudiantes<br />
                                Grados
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                                Nro Pc
                            </td>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                               No. Portátiles
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tablet
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tableros inteligentes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                        </tr>
                        <tr>
                           <td style="font-weight:bold">
                                Preescolar  
                            </td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Básica primaria 
                            </td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                           <td style="font-weight:bold">
                                Básica secundaria
                            </td>
                           <td><asp:TextBox runat="server" ID="txtBasicasecundariaPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                             <tr>
                           <td style="font-weight:bold">
                                Media
                            </td>
                           <td><asp:TextBox runat="server" ID="txtMediaPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                             <tr>
                           <td style="font-weight:bold">
                                Normal Superior 
                            </td>
                           <td><asp:TextBox runat="server" ID="txtNormalSuperiorPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                             <tr>
                           <td style="font-weight:bold">
                               Educación discapacidad 
                            </td>
                           <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Total 
                            </td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                    </table>
                    </td>
                </tr>
           </table>
            <table><tr><td>  <asp:Button ID="btnSegundoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSegundoGuardar_OnClick" /></td></tr></table>
            </fieldset>

        <fieldset>
            <legend>Segunda Parte</legend>
            <table>
                <tr>
                   <td >
                        1.1.2.	¿Los estudiantes tienen acceso en equipamiento en TICs fuera del horario escolar?    
                    </td>
                </tr>
                <tr>
                    <td>
                <table border="1">
                    <tr>
                        <td rowspan="3" style="font-weight:bold;text-align:center">Estudiantes<br /> Grados </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-weight:bold;text-align:center">Nro Pc </td>
                        <td colspan="2" style="font-weight:bold;text-align:center">No. Portátiles </td>
                        <td colspan="2" style="font-weight:bold;text-align:center">No. Tablet </td>
                        <td colspan="2" style="font-weight:bold;text-align:center">No. Tableros inteligentes </td>
                    </tr>
                    <tr>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Preescolar </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Básica primaria </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Básica secundaria </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Media </td>
                        <td>
                            <asp:TextBox ID="txtMediaPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Normal Superior </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Educación discapacidad </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Total </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPCConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPCSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPortatilesConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTabletsConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTabletsSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTablerosConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTablerosSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                        </td>
                </tr>
                </table>
             <table><tr><td>  <asp:Button ID="btnTercerGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnTercerGuardar_OnClick" /></td></tr></table>
            <table>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                  <tr>
                    <td>
                        1.1.3.	Calidad de acceso y soporte técnico del equipamiento.    
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <p style="font-weight:bold;text-align:center"> Califique de 1 a  5 (siendo uno lo más bajo y cinco lo más alto)  los siguientes ítems</p>
                     <asp:GridView ID="GridPregunta1Intrumento03" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="50%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Item" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        1.2.	Ubicación del equipamiento de uso pedagógico
                    </td>
                </tr>
                <tr>
                    <td>
                       <table border="1">
                           <tr>
                                 <td style="font-weight:bold">
                                    Equipamento
                                </td>
                                <td style="font-weight:bold">
                                    Ludotecas
                                </td>
                                 <td style="font-weight:bold">
                                    Bibliotecas
                                </td>
                                 <td style="font-weight:bold">
                                    Salones de <br />computo
                                </td>
                                 <td style="font-weight:bold">
                                    Aulas
                                </td>
                                 <td style="font-weight:bold">
                                    Otros
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold">
                                    No. PC
                                </td>
                                <td>
                                    <asp:TextBox id="txtLudotecasPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                   <td style="font-weight:bold">
                                      No. Portátiles 
                                  </td>
                                <td>
                                    <asp:TextBox id="txtLudotecaPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                  <td style="font-weight:bold">
                                     No. Tablet
                                 </td>
                                <td>
                                    <asp:TextBox id="txtLudotecaTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td style="font-weight:bold">
                                    No. Tableros inteligentes
                                </td>
                                <td>
                                    <asp:TextBox id="txtLudotecaTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                 <td style="font-weight:bold">
                                     Total 
                                 </td>
                                <td>
                                    <asp:TextBox id="txtLuditecaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                       </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                     <b>  1.3. La institución dispone de software educativo?</b><br/>
                        Si lo utiliza, ¿en que grados?   ¿En qué áreas?
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <asp:GridView ID="GridSoftwareEducativo" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />

                             <asp:TemplateField >
                                <HeaderTemplate>Software</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSoftware" runat="server" CssClass="TextBox" Width="200"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Grados</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGradosSoftware" runat="server" CssClass="TextBox" Width="200"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Áreas</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAreasSoftware" runat="server" CssClass="TextBox" Width="200" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                     <b>  1.4. De cuál de estas herramientas dispone la institución educativa:</b>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <asp:GridView ID="GridHerramientasDisponeIE" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />
                            <asp:TemplateField >
                                <HeaderTemplate>Tipo</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:DropDownList ID="dropHerramientasDisponeIE" runat="server">
                                       <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Wikis</asp:ListItem>
                                      <asp:ListItem>Blogs</asp:ListItem>
                                      <asp:ListItem>Página de internet</asp:ListItem>
                                     
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Dirección</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDireccionHerramientasDisponeIE" runat="server" CssClass="TextBox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                          
                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    </td>
                </tr>
               
                <tr>
                    <td>
                        Plataformas pedagógicas <br/> ¿Cuál o cuáles?
                    </td>
                    </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="txtPlataformasPedagogicas" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                </table>
             
            <table>
                <tr>
                    <td style="font-weight:bold;">
                        2.	Desarrollo profesional de los docentes en el uso pedagógico de medios y tecnologías de información y comunicación.
                    </td>
                </tr>
                <tr>
                    <td>
                        2.1.	¿La institución ha participado en procesos de formación de docentes en el uso de las TICs?  
                    </td>
                </tr>
                <tr>
                    <td>
                       Nombre del proceso de formación: <asp:TextBox ID="txtNomProcesoFormacionTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Duración en horas la capacitación: <asp:TextBox ID="txtNomProcesoFormacionTICSHoras" CssClass="TextBox" runat="server" Width="50"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Total beneficiario y beneficiarias: <asp:TextBox ID="txtNomProcesoFormacionTICSTotalBeneficiarios" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        2.2.	¿En los últimos tres Planes  de  Mejoramiento Institucional  se han incluido propuestas de mejoramiento en el uso de las TICs?  
                    </td>
                </tr>
                <tr>
                    <td>
                       Cuáles se han incluido?: <asp:TextBox ID="txtCualesPlanesMejoramientoTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Cuales se han desarrollado?: <asp:TextBox ID="txtDesarrolladosPlanesMejoramientoTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Cuáles han sido los efectos en la institución?: <asp:TextBox ID="txtEfectosPlanesMejoramientoTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
               
            </table>

        </fieldset>
        <br />
       <table><tr><td>  <asp:Button ID="btnCuartoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnCuartoGuardar_OnClick" /></td></tr></table>
             <%--<asp:Button ID="btnAgregarDisponibilidadTICS" runat="server" CssClass="btn btn-success" Text="Terminar" OnClick="btnAgregarDisponibilidad_OnClick" />--%>
            
       
    </asp:Panel>
 -->

</asp:Content>

