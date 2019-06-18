<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="evalfinalins3.aspx.cs" Inherits="evalfinalins3" %>

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
               url: 'evalfinalins3.aspx/cargarinfoinstitucion',
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
               url: 'evalfinalins3.aspx/buscarasesor',
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
               url: 'evalfinalins3.aspx/cargarasesores',
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
               url: 'evalfinalins3.aspx/cargarsedes',
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
               url: 'evalfinalins3.aspx/cargarsedesxcod',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       $("#infosede").html(resp[1]);
                       cargarpreguntaNo1_1(codsede);
                   }
               }
           });
       }

       function cargarpreguntaNo1_1(codsede) {
           $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">El formulario está cargando, por favor espere...</div>');
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"1.1"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo1',
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

                       //codsedeasesor = resp[17];

                       var txt1 = parseInt(resp[1]) + parseInt(resp[9]);
                       $("#txt1").val(txt1);

                       var txt2 = parseInt(resp[2]) + parseInt(resp[10]);
                       $("#txt2").val(txt2);

                       var txt3 = parseInt(resp[3]) + parseInt(resp[11]);
                       $("#txt3").val(txt3);

                       var txt4 = parseInt(resp[4]) + parseInt(resp[12]);
                       $("#txt4").val(txt4);

                       var txt5 = parseInt(resp[5]) + parseInt(resp[13]);
                       $("#txt5").val(txt5);

                       var txt6 = parseInt(resp[6]) + parseInt(resp[14]);
                       $("#txt6").val(txt6);

                       var txt7 = parseInt(resp[7]) + parseInt(resp[15]);
                       $("#txt7").val(txt7);

                       var txt8 = parseInt(resp[8]) + parseInt(resp[16]);
                       $("#txt8").val(txt8);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo1_2(codsede);
               }
           });
       }

       function cargarpreguntaNo1_2(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"1.2"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo1',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       $("#xtd1").val(resp[1]);
                       $("#xtd2").val(resp[2]);
                       $("#xtd3").val(resp[3]);
                       $("#xtd4").val(resp[4]);
                       $("#xtd5").val(resp[5]);
                       $("#xtd6").val(resp[6]);
                       $("#xtd7").val(resp[7]);
                       $("#xtd8").val(resp[8]);

                       $("#xte1").val(resp[9]);
                       $("#xte2").val(resp[10]);
                       $("#xte3").val(resp[11]);
                       $("#xte4").val(resp[12]);
                       $("#xte5").val(resp[13]);
                       $("#xte6").val(resp[14]);
                       $("#xte7").val(resp[15]);
                       $("#xte8").val(resp[16]);
                       //codsedeasesor = resp[17];

                       var txt1 = parseInt(resp[1]) + parseInt(resp[9]);
                      $("#xtt1").val(txt1);

                      var txt2 = parseInt(resp[2]) + parseInt(resp[10]);
                      $("#xtt2").val(txt2);

                      var txt3 = parseInt(resp[3]) + parseInt(resp[11]);
                      $("#xtt3").val(txt3);

                      var txt4 = parseInt(resp[4]) + parseInt(resp[12]);
                      $("#xtt4").val(txt4);

                      var txt5 = parseInt(resp[5]) + parseInt(resp[13]);
                      $("#xtt5").val(txt5);

                      var txt6 = parseInt(resp[6]) + parseInt(resp[14]);
                      $("#xtt6").val(txt6);

                      var txt7 = parseInt(resp[7]) + parseInt(resp[15]);
                      $("#xtt7").val(txt7);

                      var txt8 = parseInt(resp[8]) + parseInt(resp[16]);
                      $("#xtt8").val(txt8);

                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo2_1(codsede);
               }
           });
       }

       function cargarpreguntaNo2_1(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"2", "subpregunta":"1"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                        if (resp[1] == "Siempre")
                            $("#dotacionticfinalg_siempre").attr('checked', true);
                        else if (resp[1] == "Casi Siempre")
                            $("#dotacionticfinalg_casi").attr('checked', true);
                        else if (resp[1] == "Algunas Veces")
                            $("#dotacionticfinalg_algunas").attr('checked', true);
                        else if (resp[1] == "Muy pocas Veces")
                            $("#dotacionticfinalg_pocas").attr('checked', true);
                        else if (resp[1] == "Nunca")
                            $("#dotacionticfinalg_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo2_2(codsede);
               }
           });
       }

       function cargarpreguntaNo2_2(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"2", "subpregunta":"2"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalr_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalr_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalr_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalr_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalr_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo2_3(codsede);
               }
           });
       }

       function cargarpreguntaNo2_3(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"2", "subpregunta":"3"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalm_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalm_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalm_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalm_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalm_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo2_4(codsede);
               }
           });
       }

       function cargarpreguntaNo2_4(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"2", "subpregunta":"4"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalf_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalf_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalf_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalf_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalf_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo2_5(codsede);
               }
           });
       }

       function cargarpreguntaNo2_5(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"2", "subpregunta":"5"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalaf_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalaf_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalaf_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalaf_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalaf_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo2_6(codsede);
               }
           });
       }

       function cargarpreguntaNo2_6(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"2", "subpregunta":"6"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalda_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalda_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalda_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalda_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalda_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo3(codsede);
               }
           });
       }

       function cargarpreguntaNo3(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"3", "subpregunta":"0"}';

           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo3',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("@");

                   if (resp[0] === "true") {
                       var i = 1;
                       $("input[name=conectividad]").each(function (index) {

                           if (resp[i] == "Octubre2016")
                               $("#conectividad1").attr('checked', true);

                           if (resp[i] == "Junio2018")
                               $("#conectividad2").attr('checked', true);

                           i++;
                       });
                   }
               },
               complete: function () {
                   cargarpreguntaNo4_1(codsede);
               }
           });
       }

       function cargarpreguntaNo4_1(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"4", "subpregunta":"1"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalgf_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalgf_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalgf_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalgf_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalgf_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo4_2(codsede);
               }
           });
       }

       function cargarpreguntaNo4_2(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"4", "subpregunta":"2"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalrf_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalrf_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalrf_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalrf_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalrf_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo4_3(codsede);
               }
           });
       }

       function cargarpreguntaNo4_3(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"4", "subpregunta":"3"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalmf_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalmf_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalmf_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalmf_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalmf_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo4_4(codsede);
               }
           });
       }

       function cargarpreguntaNo4_4(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"4", "subpregunta":"4"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalff_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalff_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalff_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalff_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalff_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo4_5(codsede);
               }
           });
       }

       function cargarpreguntaNo4_5(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"4", "subpregunta":"5"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinalaff_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinalaff_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinalaff_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinalaff_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinalaff_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   cargarpreguntaNo4_6(codsede);
               }
           });
       }

       function cargarpreguntaNo4_6(codsede) {
           var jsonData = '{ "codsede":"' + codsede + '", "pregunta":"4", "subpregunta":"6"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/cargarpreguntaNo2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function (json) {
                   var resp = json.d.split("&");
                   if (resp[0] === "true") {
                       if (resp[1] == "Siempre")
                           $("#dotacionticfinaldaf_siempre").attr('checked', true);
                       else if (resp[1] == "Casi Siempre")
                           $("#dotacionticfinaldaf_casi").attr('checked', true);
                       else if (resp[1] == "Algunas Veces")
                           $("#dotacionticfinaldaf_algunas").attr('checked', true);
                       else if (resp[1] == "Muy pocas Veces")
                           $("#dotacionticfinaldaf_pocas").attr('checked', true);
                       else if (resp[1] == "Nunca")
                           $("#dotacionticfinaldaf_nunca").attr('checked', true);
                   }
                   else {
                       //alert(resp[1]);
                   }
               },
               complete: function () {
                   $(".desactivarC1").fadeOut(500);
               }
           });
       }

       function btnguardar() {
          
               if (!$("input[name=usodotaciontabletg]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2 Item 1");
               } else if (!$("input[name=usodotaciontabletr]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2 Item 2");
               }
               else if (!$("input[name=usodotaciontabletm]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2 Item 3");
               }
               else if (!$("input[name=usodotaciontabletmf]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2 Item 4");
               }
               else if (!$("input[name=usodotaciontabletmpf]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2 Item 5");
               }
               else if (!$("input[name=usodotaciontabletmd]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 2 Item 6");
               }
               else if (!$("input[name=usoconectividadtabletg]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 4 Item 1");
               }
               else if (!$("input[name=usoconectividadtabletr]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 4 Item 2");
               }
               else if (!$("input[name=usoconectividadtabletm]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 4 Item 3");
               }
               else if (!$("input[name=usoconectividadtabletmff]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 4 Item 4");
               }
               else if (!$("input[name=usoconectividadtabletmppf]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 4 Item 5");
               }
               else if (!$("input[name=usoconectividadtabletmda]:checked").val()) {
                   alert("No hay ninguna opción seleccionada en la pregunta No. 4 Item 6");
               }
               else {
                   $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Las respuestas están siendo guardadas, por favor espere...</div>');
                   guardarequipamientodocentes1_1();
                   //guardarequipamientoestudiantes();
                   //guardarpreguntascerradas();
                   //guardarherramientasdispoie();
                   //guardarpreguntasabiertas();
                   //alert("Datos guardados correctamente");
                   //btnregresar();
                   //reset();
                   //$("#table").fadeIn(500);
                   //$("#disponibilidad").hide();
               }
              
         
       }
       function guardarequipamientodocentes1_1() {
           var jsonData = '{ "tipo":"docentes", "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "txt1":"' + $("#txtd1").val() + '", "txt2":"' + $("#txtd2").val() + '", "txt3":"' + $("#txtd3").val() + '", "txt4":"' + $("#txtd4").val() + '", "txt5":"' + $("#txtd5").val() + '", "txt6":"' + $("#txtd6").val() + '", "txt7":"' + $("#txtd7").val() + '", "txt8":"' + $("#txtd8").val() + '", "pregunta":"1.1"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinalins3.aspx/guardardatos',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {
                    console.log("Equipamiento guardado, docentes, pregunta 1.1");
                },
                complete: function () {
                    guardarequipamientoestudiantes1_1();
                }
            });
       }

       function guardarequipamientoestudiantes1_1() {
           var jsonData = '{ "tipo":"estudiantes", "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "txt1":"' + $("#txte1").val() + '", "txt2":"' + $("#txte2").val() + '", "txt3":"' + $("#txte3").val() + '", "txt4":"' + $("#txte4").val() + '", "txt5":"' + $("#txte5").val() + '", "txt6":"' + $("#txte6").val() + '", "txt7":"' + $("#txte7").val() + '", "txt8":"' + $("#txte8").val() + '", "pregunta":"1.1"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/guardardatos',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function () {
                   console.log("Equipamiento guardado, estudiantes, pregunta 1.1");
               },
               complete: function () {
                   guardarequipamientodocentes1_2();
               }
           });
       }

       function guardarequipamientodocentes1_2() {
           var jsonData = '{ "tipo":"docentes", "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "txt1":"' + $("#xtd1").val() + '", "txt2":"' + $("#xtd2").val() + '", "txt3":"' + $("#xtd3").val() + '", "txt4":"' + $("#xtd4").val() + '", "txt5":"' + $("#xtd5").val() + '", "txt6":"' + $("#xtd6").val() + '", "txt7":"' + $("#xtd7").val() + '", "txt8":"' + $("#xtd8").val() + '", "pregunta":"1.2"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/guardardatos',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function () {
                   console.log("Equipamiento guardado, docentes, pregunta 1.2");
               },
               complete: function () {
                   guardarequipamientoestudiantes1_2();
               }
           });
       }

       function guardarequipamientoestudiantes1_2() {
           var jsonData = '{ "tipo":"estudiantes", "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "txt1":"' + $("#xte1").val() + '", "txt2":"' + $("#xte2").val() + '", "txt3":"' + $("#xte3").val() + '", "txt4":"' + $("#xte4").val() + '", "txt5":"' + $("#xte5").val() + '", "txt6":"' + $("#xte6").val() + '", "txt7":"' + $("#xte7").val() + '", "txt8":"' + $("#xte8").val() + '", "pregunta":"1.2"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/guardardatos',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function () {
                   console.log("Equipamiento guardado, estudiantes, pregunta 1.2");
               },
               complete: function () {
                   guardarpregunta2();
               }
           });
       }

       function guardarpregunta2() {
           var jsonData = '{ "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "usodotaciontabletg":"' + $('input:radio[name=usodotaciontabletg]:checked').val() + '", "usodotaciontabletr":"' + $('input:radio[name=usodotaciontabletr]:checked').val() + '", "usodotaciontabletm":"' + $('input:radio[name=usodotaciontabletm]:checked').val() + '", "usodotaciontabletmf":"' + $('input:radio[name=usodotaciontabletmf]:checked').val() + '", "usodotaciontabletmpf":"' + $('input:radio[name=usodotaciontabletmpf]:checked').val() + '", "usodotaciontabletmd":"' + $('input:radio[name=usodotaciontabletmd]:checked').val() + '"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/guardarpregunta2',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function () {
                   console.log("guardado, pregunta 2");
               },
               complete: function () {
                   guardarpreguntaNo3();
               }
           });
       }

       function guardarpreguntaNo3() {
           var k = 0;
           var jsonData = '{"codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "pregunta":"3"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/eliminarpreguntaChk',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function () {
                   console.log("Pregunta 3 eliminada.");

                   $("input[name=conectividad]").each(function (index) {
                       if (this.checked) {
                           var jsonData3 = "{'codinsasesor':'" + $("#asesor").val() + "', 'codsede':'" + codigosede + "', 'respuesta':'" + $(this).val() + "', 'pregunta':'3', 'subpregunta':'0'}";

                           $.ajax({
                               type: 'POST',
                               url: 'evalfinalins3.aspx/guardarpreguntaCerradaChk',
                               contentType: "application/json; charset=utf-8",
                               dataType: "json",
                               data: jsonData3,
                               success: function () {
                                   //console.log("Pregunta 3 guardarda, item: " + $(this).val());
                                   console.log(k);
                               }
                               //,
                               //complete: function () {
                                   
                                   
                               //}
                           });
                       }
                       k++;
                   });
               },
               complete: function () {
                  
                   if (k == 2) {
                       guardarpreguntaNo4();
                   }

               }
           });

       }

       function guardarpreguntaNo4() {
           var jsonData = '{ "codinsasesor":"' + $("#asesor").val() + '", "codsede":"' + codigosede + '", "usoconectividadtabletg":"' + $('input:radio[name=usoconectividadtabletg]:checked').val() + '", "usoconectividadtabletr":"' + $('input:radio[name=usoconectividadtabletr]:checked').val() + '", "usoconectividadtabletm":"' + $('input:radio[name=usoconectividadtabletm]:checked').val() + '", "usoconectividadtabletmff":"' + $('input:radio[name=usoconectividadtabletmff]:checked').val() + '", "usoconectividadtabletmppf":"' + $('input:radio[name=usoconectividadtabletmppf]:checked').val() + '", "usoconectividadtabletmda":"' + $('input:radio[name=usoconectividadtabletmda]:checked').val() + '"}';
           $.ajax({
               type: 'POST',
               url: 'evalfinalins3.aspx/guardarpregunta4',
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               data: jsonData,
               success: function () {
                   console.log("guardado, pregunta 4");
               },
               complete: function () {
                   $(".desactivarC1").fadeOut(500);
                   
               }
           });
       }

       function btnregresar() {
           window.location.href = "evalfinalins3.aspx";
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

    <h2 style="text-decoration: none;"><center>FORTALECIMIENTO DE LA CULTURA CIUDADANA Y DEMOCRÁTICA EN CT+I <br> A TRAVÉS DE LA IEP APOYADA EN TIC EN EL DPTO DEL MAGDALENA<br /></center><center><br>Evaluación final</center></h2>

    <center>
        <h2>
            Instrumento No. 03 <br><br>Disponibilidad, acceso y uso de TICS en IEP
 
        </h2>
    </center>

    <div id="table">

         <p>
            <b>Introducción:</b><br /><br />

            Para la evaluación final del proyecto se requiere recoger información básica sobre el equipamiento institucional de TIC y su uso pedagógico, con el objeto de indagar sobre el impacto de las dotaciones tecnológicas que ha realizado el Proyecto. 
            
            <br /><br />
            <b>Objetivo: </b>
            <br /><br />
            Acopiar información de carácter documental sobre el equipamiento, dotaciones entregadas por el proyecto y el uso de las TIC en las sedes educativas beneficiadas al proyecto.
            <br /><br />
            <b>Metodología: </b>
            <br /><br />
            El instrumento será diligenciado directamente en la plataforma Macondo. por el profesional de FUNTICS con el Rector/a, Director/a o a quien se delegue en la Institución Educativa. 
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

        <fieldset>
          <legend>Responsable</legend>
          <td>Nombre</td>
          <td>
            <input type="text" name="nresponsable" id="nresponsable" class="TextBox">
          </td>
          <td>Cargo</td>
          <td>
            <input type="text" class="TextBox" id="cresponsable" name="cresponsable">
          </td>
          <td>Fecha</td>
          <td>
            <input type="date" class="TextBox" id="fechadili" name="fechadili">
          </td>
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
                    1. Instituciones educativas con infraestructura TIC (conectividad y equipamiento)
                </td>
            </tr>
            <tr>
                <td>
                    1.1.  Equipamiento entregado por el programa Ciclón de la Gobernación del Magdalena a las sedes educativas beneficiadas. (Información tomada de las actas de entrega, durante la evaluación intermedia)   
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
                            <td><input type="text" class="TextBox" id="txt1" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt2" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt3" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt4" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt5" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt6" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt7" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="txt8" style="width:75px;" disabled/></td>
                        </tr>
                    </table>
                </td>
            </tr>
           </table>

           <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            
            <tr>
                <td>
                    1.2.  Otro equipamiento entregado por la Gobernación y Computadores para Educar a la sede educativa en el período 2016-2018, diferentes al proporcionado por el programa Ciclón:   
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
                            <td><input type="text" class="TextBox" id="xtd1" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(1,1)" /></td>
                            <td><input type="text" class="TextBox" id="xtd2" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(2,2)" /></td>
                            <td><input type="text" class="TextBox" id="xtd3" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(3,3)" /></td>
                            <td><input type="text" class="TextBox" id="xtd4" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(4,4)" /></td>
                            <td><input type="text" class="TextBox" id="xtd5" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(5,5)" /></td>
                            <td><input type="text" class="TextBox" id="xtd6" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(6,6)" /></td>
                            <td><input type="text" class="TextBox" id="xtd7" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(7,7)" /></td>
                            <td><input type="text" class="TextBox" id="xtd8" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(8,8)" /></td>
                        </tr>
                         <tr>
                           <th style="font-weight:bold">
                                Estudiantes
                            </th>
                            <td><input type="text" class="TextBox" id="xte1" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(1,1)" /></td>
                            <td><input type="text" class="TextBox" id="xte2" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(2,2)" /></td>
                            <td><input type="text" class="TextBox" id="xte3" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(3,3)" /></td>
                            <td><input type="text" class="TextBox" id="xte4" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(4,4)" /></td>
                            <td><input type="text" class="TextBox" id="xte5" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(5,5)" /></td>
                            <td><input type="text" class="TextBox" id="xte6" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(6,6)" /></td>
                            <td><input type="text" class="TextBox" id="xte7" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(7,7)" /></td>
                            <td><input type="text" class="TextBox" id="xte8" style="width:75px;" onkeypress="return isNumberKey(event);" onblur="valortotal(8,8)" /></td>
                        </tr>
                         <tr>
                            <th style="font-weight:bold">
                                Total 
                            </th>
                            <td><input type="text" class="TextBox" id="xtt1" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt2" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt3" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt4" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt5" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt6" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt7" style="width:75px;" disabled/></td>
                            <td><input type="text" class="TextBox" id="xtt8" style="width:75px;" disabled/></td>
                        </tr>
                    </table>
                </td>
            </tr>
           </table>

        <br />

        2.  ¿Se utilizaron las tabletas entregadas por el Programa en sus espacios de formación, apropiación e investigación y para el trabajo en el aula? 
        <table border="1" class="mGridTesoreria">
            <tr>
                <th >
                    Grupos de investigación infantiles y juveniles:
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalg_siempre" type="radio" name="usodotaciontabletg" value="Siempre" />
                </td>
                <td style="text-align:center; vertical-align: middle;">
                    Casi Siempre<input id="dotacionticfinalg_casi" type="radio" name="usodotaciontabletg" value="Casi Siempre" />
                </td>
                <td style="text-align:center; vertical-align: middle;">
                    Algunas Veces<input id="dotacionticfinalg_algunas" type="radio" name="usodotaciontabletg" value="Algunas Veces" />
                </td>
                <td style="text-align:center; vertical-align: middle;">
                    Muy pocas Veces<input id="dotacionticfinalg_pocas" type="radio" name="usodotaciontabletg" value="Muy pocas Veces" />
               </td>
                <td style="text-align:center; vertical-align: middle;">
                    Casi Nunca<input id="dotacionticfinalg_nunca" type="radio" name="usodotaciontabletg" value="Nunca" />
                </td>

            </tr>
             <tr>
                <th >
                   Redes Temáticas Institucionales:
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalr_siempre" type="radio" name="usodotaciontabletr" value="Siempre" />
                    
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Siempre<input id="dotacionticfinalr_casi" type="radio" name="usodotaciontabletr" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalr_algunas" type="radio" name="usodotaciontabletr" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalr_pocas" type="radio" name="usodotaciontabletr" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalr_nunca" type="radio" name="usodotaciontabletr" value="Nunca" />
                 </td>
            </tr>
             <tr>
                <th>
                   Estrategia de formación de maestros(as):
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalm_siempre" type="radio" name="usodotaciontabletm" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalm_casi" type="radio" name="usodotaciontabletm" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalm_algunas" type="radio" name="usodotaciontabletm" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalm_pocas" type="radio" name="usodotaciontabletm" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalm_nunca" type="radio" name="usodotaciontabletm" value="Nunca" />
                 </td>
            </tr>
            <tr>
              <th>
                Durante la participación en las ferias:
              </th>
              <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalf_siempre" type="radio" name="usodotaciontabletmf" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalf_casi" type="radio" name="usodotaciontabletmf" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalf_algunas" type="radio" name="usodotaciontabletmf" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalf_pocas" type="radio" name="usodotaciontabletmf" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalf_nunca" type="radio" name="usodotaciontabletmf" value="Nunca" />
                 </td>
            </tr>

            <tr>
              <th>
                Durante el registro y el acompañamiento realizado por el Programa para  participar en las ferias:
              </th>
              <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalaf_siempre" type="radio" name="usodotaciontabletmpf" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalaf_casi" type="radio" name="usodotaciontabletmpf" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalaf_algunas" type="radio" name="usodotaciontabletmpf" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalaf_pocas" type="radio" name="usodotaciontabletmpf" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalaf_nunca" type="radio" name="usodotaciontabletmpf" value="Nunca" />
                 </td>
            </tr>
            <tr>
              <th>
                Trabajo en el aula para desarrollo de asignaturas:
              </th>
              <td style="text-align:center; vertical-align: middle;">

                    Siempre<input id="dotacionticfinalda_siempre" type="radio" name="usodotaciontabletmd" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalda_casi" type="radio" name="usodotaciontabletmd" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalda_algunas" type="radio" name="usodotaciontabletmd" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalda_pocas" type="radio" name="usodotaciontabletmd" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalda_nunca" type="radio" name="usodotaciontabletmd" value="Nunca" />
                 </td>
            </tr>
        </table>

         <br />

           3. Su sede educativa fue beneficiada con el servicio de conectividad entregado por el programa Ciclón de la gobernación del Magdalena,  entre los meses de: 
        <table border="1" class="mGridTesoreria">
            <tr>
                <th >
                    Octubre de 2016 a Mayo de 2018:
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    <input id="conectividad1" type="checkbox" name="conectividad" value="Octubre2016" />
                </td>

            </tr>
             <tr>
                <th >
                   Junio de 2018 a Noviembre de 2018:
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    <input id="conectividad2" type="checkbox" name="conectividad" value="Junio2018" />    
                </td>
            </tr>
          </table>

         4. ¿Se utilizó la conectividad en los espacios de formación del Programa y en aula? 
        <table border="1" class="mGridTesoreria">
            <tr>
                <th >
                    Grupos de investigación infantiles y juveniles:
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalgf_siempre" type="radio" name="usoconectividadtabletg" value="Siempre" />
                </td>
                <td style="text-align:center; vertical-align: middle;">
                    Casi Siempre<input id="dotacionticfinalgf_casi" type="radio" name="usoconectividadtabletg" value="Casi Siempre" />
                </td>
                <td style="text-align:center; vertical-align: middle;">
                    Algunas Veces<input id="dotacionticfinalgf_algunas" type="radio" name="usoconectividadtabletg" value="Algunas Veces" />
                </td>
                <td style="text-align:center; vertical-align: middle;">
                    Muy pocas Veces<input id="dotacionticfinalgf_pocas" type="radio" name="usoconectividadtabletg" value="Muy pocas Veces" />
               </td>
                <td style="text-align:center; vertical-align: middle;">
                    Casi Nunca<input id="dotacionticfinalgf_nunca" type="radio" name="usoconectividadtabletg" value="Nunca" />
                </td>

            </tr>
             <tr>
                <th >
                   Redes Temáticas Institucionales:
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalrf_siempre" type="radio" name="usoconectividadtabletr" value="Siempre" />
                    
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Siempre<input id="dotacionticfinalrf_casi" type="radio" name="usoconectividadtabletr" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalrf_algunas" type="radio" name="usoconectividadtabletr" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalrf_pocas" type="radio" name="usoconectividadtabletr" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalrf_nunca" type="radio" name="usoconectividadtabletr" value="Nunca" />
                 </td>
            </tr>
             <tr>
                <th>
                   Estrategia de formación de maestros(as):
                </th>
                <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalmf_siempre" type="radio" name="usoconectividadtabletm" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalmf_casi" type="radio" name="usoconectividadtabletm" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalmf_algunas" type="radio" name="usoconectividadtabletm" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalmf_pocas" type="radio" name="usoconectividadtabletm" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalmf_nunca" type="radio" name="usoconectividadtabletm" value="Nunca" />
                 </td>
            </tr>
            <tr>
              <th>
                Durante la participación en las ferias:
              </th>
              <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalff_siempre" type="radio" name="usoconectividadtabletmff" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalff_casi" type="radio" name="usoconectividadtabletmff" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalff_algunas" type="radio" name="usoconectividadtabletmff" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalff_pocas" type="radio" name="usoconectividadtabletmff" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalff_nunca" type="radio" name="usoconectividadtabletmff" value="Nunca" />
                 </td>
            </tr>

            <tr>
              <th>
                Durante el registro y el acompañamiento realizado por el Programa para  participar en las ferias:
              </th>
              <td style="text-align:center; vertical-align: middle;">
                    Siempre<input id="dotacionticfinalaff_siempre" type="radio" name="usoconectividadtabletmppf" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinalaff_casi" type="radio" name="usoconectividadtabletmppf" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinalaff_algunas" type="radio" name="usoconectividadtabletmppf" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinalaff_pocas" type="radio" name="usoconectividadtabletmppf" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinalaff_nunca" type="radio" name="usoconectividadtabletmppf" value="Nunca" />
                 </td>
            </tr>
            <tr>
              <th>
                Trabajo en el aula para desarrollo de asignaturas:
              </th>
              <td style="text-align:center; vertical-align: middle;">

                    Siempre<input id="dotacionticfinaldaf_siempre" type="radio" name="usoconectividadtabletmda" value="Siempre" />
                   
                </td>
                 <td style="text-align:center; vertical-align: middle;">
                      Casi Siempre<input id="dotacionticfinaldaf_casi" type="radio" name="usoconectividadtabletmda" value="Casi Siempre" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Algunas Veces<input id="dotacionticfinaldaf_algunas" type="radio" name="usoconectividadtabletmda" value="Algunas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Muy pocas Veces<input id="dotacionticfinaldaf_pocas" type="radio" name="usoconectividadtabletmda" value="Muy pocas Veces" />
                    
                 </td>
                 <td style="text-align:center; vertical-align: middle;">
                     Casi Nunca<input id="dotacionticfinaldaf_nunca" type="radio" name="usoconectividadtabletmda" value="Nunca" />
                 </td>
            </tr>
        </table>

         <br /> 

        <!-- 6.	¿Ha recibido dotación de tabletas por parte del programa CICLÓN?
        <table visible="false">
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
        </table> -->
       
        <table align="center">
            <tr>
                <td><a href="javascript:void(0)" class="btn btn-success" onclick="btnguardar()">Guardar</a></td>
                <td><a href="javascript:void(0)" class="btn btn-primary" onclick="btnregresar()">Regresar</a></td>
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

