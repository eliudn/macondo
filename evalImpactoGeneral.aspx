<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="evalImpactoGeneral.aspx.cs" Inherits="evalintermediaGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />

     <script>
         $(document).ready(function () {
             $("#MainContent_accordion").accordion({
                 heightStyle: "content",
                 active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
             });
             $("#MainContent_accordion").attr("style", "visibility:visible;");

         });

    </script>
     <script>
         function abrir(panel) {
             var p = parseInt(panel);
             $(function () {
                 $("#MainContent_accordion").accordion({
                     heightStyle: "content",
                     active: p
                 });
             });
         }
    </script>

     <script type="text/javascript">

         function docentesbeneficiados() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalImpactoGeneral.aspx/docentesbeneficiados',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function docentesEvaluacionintermedia() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/docentesEvaluacionintermedia',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function inventariodequipamiento() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/inventariodequipamiento',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function inventariotabletasentregadas() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/inventariotabletasentregadas',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function accesostabletasformacionmaestros() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/accesostabletasformacionmaestros',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function Accesosgrupostabletasentregadas() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/Accesosgrupostabletasentregadas',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function accesosredestabletasentregadas() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/accesosredestabletasentregadas',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function sedeseducativasservicioconectividad() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedeseducativasservicioconectividad',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }


         function usoconectividadformacionmaestros() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/usoconectividadformacionmaestros',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function sedesbeneficiadasconectividadentregado() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesbeneficiadasconectividadentregado',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function usoconectividadtrabajoredes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/usoconectividadtrabajoredes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }
         
         
         function herramientaswebsedes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/herramientaswebsedes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function plataformasPedagogicasSedes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/plataformasPedagogicasSedes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function participacionProcesosFormacionDocentes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/participacionProcesosFormacionDocentes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function sedesEducativasTresPlanesdeMejoramiento() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesEducativasTresPlanesdeMejoramiento',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function percepcionefectosincorporacionTICsedes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/percepcionefectosincorporacionTICsedes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function modificacionescurriculosdirigidas() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/modificacionescurriculosdirigidas',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function modeloeducativoinstitucion() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/modeloeducativoinstitucion',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function docentesmodificaronpracticapedagogica() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/docentesmodificaronpracticapedagogica',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function maestrosincluyenelusoTIC() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/maestrosincluyenelusoTIC',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }


         
         function actualizacionPEI() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/actualizacionPEI',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }


         function sedesincluyenformativos() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesincluyenformativos',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function institucionesincluyenciencia() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/institucionesincluyenciencia',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function sedesincluyentecnologiaspei() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesincluyentecnologiaspei',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {

                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function sedesincluyeninnovacionpei() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesincluyeninnovacionpei',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }


         function sedesincluyeninvestigacionpei() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesincluyeninvestigacionpei',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function sedesincluyenTicpei() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/sedesincluyenTicpei',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function modeloseducativosdesedes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/modeloseducativosdesedes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }


         
         function institucionespromueveinvestigaciondocente() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/institucionespromueveinvestigaciondocente',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }


         function institucionespromueveinvestigacionestudiantes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/institucionespromueveinvestigacionestudiantes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function institucionespromueveusoticdocentes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/institucionespromueveusoticdocentes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function institucionespromueveusoticestudiantes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/institucionespromueveusoticestudiantes',
                 //data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         //nuevo
         function participacionmaestrosproyectosinvestigacion() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/participacionmaestrosproyectosinvestigacion',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function proyectosinvestigacionestudiantespracticapedagogica() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/proyectosinvestigacionestudiantespracticapedagogica',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }
          
         function modalidadproyectosestudiantes() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/modalidadproyectosestudiantes',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function formacionespecificaenciencia() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/formacionespecificaenciencia',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         function formacioncontribuyocambiarpracticaspedagogicas() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/formacioncontribuyocambiarpracticaspedagogicas',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

          
         function formacionespecificaenTIC() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/formacionespecificaenTIC',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         // function formacionespecificaenTIC() {
         //     $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
         //     $.ajax({
         //         type: 'POST',
         //         url: 'evalintermediaGeneral.aspx/dequemaneracontribuyocambiarlaspracticaspedagogica',
         //         contentType: 'application/json; charset=utf-8',
         //         dataType: 'JSON',
         //         success: function (response) {
         //             $("#infoListTable").html(response.d);
         //             $("#table").fadeIn(500);
         //         }
         //     });
         // }

         function dequemaneracontribuyocambiarlaspracticaspedagogica() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/dequemaneracontribuyocambiarlaspracticaspedagogica',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function formacionprogramaciclon() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/formacionprogramaciclon',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }

         
         function formacioncicloncontribuyocambiarpracticaspedagogicas() {
             $("#infoListTable").html("<tr><td></td></tr><tr><td><img src='images/loader.gif' /></td></tr>");
             $.ajax({
                 type: 'POST',
                 url: 'evalintermediaGeneral.aspx/formacioncicloncontribuyocambiarpracticaspedagogicas',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#infoListTable").html(response.d);
                     $("#table").fadeIn(500);
                 }
             });
         }
         </script>
    <style>
        .mGridTesoreria td {
            border: solid 1px #c1c1c1;
            font-size: 14px;
            padding: 7px 10px;
        }
        h3> div> ul>li{
           
        }
    </style>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Reporte General Evaluación Impacto</h2>

    <div id="accordion" runat="server" >
     </div>

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

             <%--<asp:Button ID="btnCurriculo" runat="server" Text="Currículo" OnClick="btnCurriculo_Click" Visible="true" CssClass="btn btn-primary" />

           <asp:Button ID="btnSedesxUbicacion" runat="server" Text="Total de Sedes por Ubicación" OnClick="btnSedesxUbicacion_Click" Visible="false" CssClass="btn btn-success" /> 
            <asp:Button ID="btnSedesxMunicipioCurriculo" runat="server" Text="Sedes por Municipio" OnClick="btnSedesxMunicipioCurriculo_Click" Visible="false" CssClass="btn btn-success" /> 
            <asp:Button ID="btnEnfasisCurriculo" runat="server" Text="Énfasis Currículo" OnClick="btnEnfasisCurriculo_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnModeloEducativoCurriculo" runat="server" Text="Modelo Educativo" OnClick="btnModeloEducativoCurriculo_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnPEIProcesoInstitucionalEstudiantes" runat="server" Text="Diagnostico uso TIC" OnClick="btnPEIProcesoInstitucionalEstudiantes_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnPEIInvestigacion" runat="server" Text="PEI promueve la Investigación" OnClick="btnPEIInvestigacion_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnPEIUsoTIC" runat="server" Text="PEI promueve el uso de las TIC" OnClick="btnPEIUsoTIC_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnUsoTICCurriculo" runat="server" Text="Currículo con apropiación en TIC" OnClick="btnUsoTICCurriculo_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnUsoTICCurriculoCompentencias" runat="server" Text="Currículo con competencias en TIC" OnClick="btnUsoTICCurriculoCompentencias_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnDocentesUltimoNivelEducativoAprobado" runat="server" Text="Total de personal docente según último nivel educativo aprobado" OnClick="btnDocentesUltimoNivelEducativoAprobado_Click" Visible="false" CssClass="btn btn-success" />--%>
  <%--<br /><br />                
            <asp:Button ID="btnEquipamiento" runat="server" Text="Equipamiento" OnClick="btnEquipamiento_Click" Visible="true" CssClass="btn btn-primary" />

          <asp:Button ID="btnSedesxMunicipioEquipamiento" runat="server" Text="Sedes por Municipio" OnClick="btnSedesxMunicipioEquipamiento_Click" Visible="false" CssClass="btn btn-success" /> 
            <asp:Button ID="btnSedesxEquiposInformaticoEquipamiento" runat="server" Text="Equipos Informáticos por Sedes" OnClick="btnSedesxEquiposInformaticoEquipamiento_Click" Visible="false" CssClass="btn btn-success" />  --%>
            <%--<asp:Button ID="btnSedesxEquiposInformaticodesagregadoGrado" runat="server" Text="Equipos Informáticos desagregados por grados" OnClick="btnSedesxEquiposInformaticodesagregadoGrado_Click" Visible="false" CssClass="btn btn-success" />--%>  
            <%--<asp:Button ID="btnSedesxEquiposInformaticoFueraEscuela" runat="server" Text="Acceso en equipamiento en TICs fuera del horario escolar" OnClick="btnSedesxEquiposInformaticoFueraEscuela_Click" Visible="false" CssClass="btn btn-success" />--%>  
            <%--<asp:Button ID="btnSedesxSoftwareEducativo" runat="server" Text="IE con Software Educativo" OnClick="btnSedesxSoftwareEducativo_Click" Visible="false" CssClass="btn btn-success" />--%>
            <%--<asp:Button ID="btnSedesxHerramientaWeb" runat="server" Text="IE con herramientas WEB" OnClick="btnSedesxHerramientaWeb_Click" Visible="false" CssClass="btn btn-success" />--%>
            <%--<asp:Button ID="btnSedesxFormacionDocenteUsoTIC" runat="server" Text="IE con procesos de formación docentes en uso TIC" OnClick="btnSedesxFormacionDocenteUsoTIC_Click" Visible="false" CssClass="btn btn-success" />--%>
            <%--<asp:Button ID="btnSedesxPlanMejoramientoTIC" runat="server" Text="IE con planes de mejoramiento TIC" OnClick="btnSedesxPlanMejoramientoTIC_Click" Visible="false" CssClass="btn btn-success" />
<br /><br /> --%>
            <%--<asp:Button ID="btnAutoPercepcionDocente" runat="server" Text="Autopercepción Docente" OnClick="btnAutoPercepcionDocente_Click" CssClass="btn btn-primary" />--%>

            <%--<asp:Button ID="btnSedesxMunicipioAutopercepcion" runat="server" Text="Sedes por Municipio " OnClick="btnFormulariosxMunicipioAutopercepcion_Click" Visible="false" CssClass="btn btn-success" />--%>         
            <%--<asp:Button ID="btnFormulariosxMunicipioAutopercepcion" runat="server" Text="Formularios por Municipio " OnClick="btnFormulariosxMunicipioAutopercepcion_Click" Visible="false" CssClass="btn btn-success" />--%>         
            
<%--            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo1" runat="server" Text="Pregunta No 1: Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos " OnClick="btnAutoPercepcionDocentePreguntaNo1_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo2" runat="server" Text="Pregunta No 2: Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales" OnClick="btnAutoPercepcionDocentePreguntaNo2_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo3" runat="server" Text="Pregunta No 3: Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material " OnClick="btnAutoPercepcionDocentePreguntaNo3_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo4" runat="server" Text="Pregunta No 4: Combino una amplia variedad de herramientas tecnológicas para mejorar la planeación e implementación de mis prácticas educativas " OnClick="btnAutoPercepcionDocentePreguntaNo4_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo5" runat="server" Text="Pregunta No 5: Diseño y publico contenidos digitales u objetos virtuales de aprendizaje mediante el uso adecuado de herramientas tecnológicas" OnClick="btnAutoPercepcionDocentePreguntaNo5_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo6" runat="server" Text="Pregunta No 6: Analizo los riesgos y potencialidades de publicar y compartir distintos tipos de información a través de Internet" OnClick="btnAutoPercepcionDocentePreguntaNo6_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo7" runat="server" Text="Pregunta No 7: Utilizo herramientas tecnológicas complejas o especializadas para diseñar ambientes virtuales de aprendizaje que favorecen el desarrollo de competencias en mis estudiantes y la conformación de comunidades y/o redes de aprendizaje" OnClick="btnAutoPercepcionDocentePreguntaNo7_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo8" runat="server" Text="Pregunta No 8: Utilizo herramientas tecnológicas para ayudar a mis estudiantes a construir aprendizajes significativos y desarrollar pensamiento crítico" OnClick="btnAutoPercepcionDocentePreguntaNo8_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo9" runat="server" Text="Pregunta No 9: Aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia" OnClick="btnAutoPercepcionDocentePreguntaNo9_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo10" runat="server" Text="Pregunta No 10: Utilizo las TIC para aprender por iniciativa personal y para actualizar los conocimientos y prácticas propios de mi disciplina" OnClick="btnAutoPercepcionDocentePreguntaNo10_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo11" runat="server" Text="Pregunta No 11: Identifico problemáticas educativas en mi práctica docente y las oportunidades, implicaciones y riesgos del uso de las TIC para atenderlas" OnClick="btnAutoPercepcionDocentePreguntaNo11_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo12" runat="server" Text="Pregunta No 12: Conozco una variedad de estrategias y metodologías apoyadas por las TIC, para planear y hacer seguimiento a mi labor docente" OnClick="btnAutoPercepcionDocentePreguntaNo12_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo13" runat="server" Text="Pregunta No 13: Incentivo en mis estudiantes el aprendizaje autónomo y el aprendizaje colaborativo apoyados por TIC" OnClick="btnAutoPercepcionDocentePreguntaNo13_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo14" runat="server" Text="Pregunta No 14: Utilizo TIC con mis estudiantes para atender sus necesidades e intereses y proponer soluciones a problemas de aprendizaje" OnClick="btnAutoPercepcionDocentePreguntaNo14_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo15" runat="server" Text="Pregunta No 15: Implemento estrategias didácticas mediadas por TIC, para fortalecer en mis estudiantes aprendizajes que les permitan resolver problemas de la vida real" OnClick="btnAutoPercepcionDocentePreguntaNo15_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo16" runat="server" Text="Pregunta No 16: Diseño ambientes de aprendizaje mediados por TIC de acuerdo con el desarrollo cognitivo, físico, psicológico y social de mis estudiantes para fomentar el desarrollo de sus competencias" OnClick="btnAutoPercepcionDocentePreguntaNo16_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo17" runat="server" Text="Pregunta No 17: Propongo proyectos educativos mediados con TIC, que permiten la reflexión sobre el aprendizaje propio y la producción de conocimiento" OnClick="btnAutoPercepcionDocentePreguntaNo17_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo18" runat="server" Text="Pregunta No 18: Evalúo los resultados obtenidos con la implementación de estrategias que hacen uso educativo de TIC y promuevo una cultura de seguimiento, retroalimentación y mejoramiento permanente" OnClick="btnAutoPercepcionDocentePreguntaNo18_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo19" runat="server" Text="Pregunta No 19: Me comunico adecuadamente con mis estudiantes y sus familiares, mis colegas e investigadores usando TIC de manera sincrónica y asincrónica" OnClick="btnAutoPercepcionDocentePreguntaNo19_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo20" runat="server" Text="Pregunta No 20: Navego eficientemente en Internet integrando fragmentos de información presentados de forma no lineal" OnClick="btnAutoPercepcionDocentePreguntaNo20_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo21" runat="server" Text="Pregunta No 21: Evalúo la pertinencia de compartir información a través de canales públicos y masivos, respetando las normas de propiedad intelectual y licenciamiento" OnClick="btnAutoPercepcionDocentePreguntaNo21_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo22" runat="server" Text="Pregunta No 22: Participo activamente en redes y comunidades de práctica mediadas por TIC y facilito la participación de mis estudiantes en las mismas, de una forma pertinente y respetuosa" OnClick="btnAutoPercepcionDocentePreguntaNo22_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo23" runat="server" Text="Pregunta No 23: Sistematizo y hago seguimiento a experiencias significativas de uso de TIC" OnClick="btnAutoPercepcionDocentePreguntaNo22_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo24" runat="server" Text="Pregunta No 24: Promuevo en la comunidad educativa comunicaciones efectivas que aportan al mejoramiento de los procesos de convivencia escolar" OnClick="btnAutoPercepcionDocentePreguntaNo24_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo25" runat="server" Text="Pregunta No 25: Utilizo variedad de textos e interfaces para transmitir información y expresar ideas propias combinando texto, audio, imágenes estáticas o dinámicas, videos y gestos" OnClick="btnAutoPercepcionDocentePreguntaNo25_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo26" runat="server" Text="Pregunta No 26: Interpreto y produzco íconos, símbolos y otras formas de representación de la información, para ser utilizados con propósitos educativos" OnClick="btnAutoPercepcionDocentePreguntaNo26_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo27" runat="server" Text="Pregunta No 27: Contribuyo con mis conocimientos y los de mis estudiantes a repositorios de la humanidad de Internet, con textos de diversa naturaleza" OnClick="btnAutoPercepcionDocentePreguntaNo27_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo28" runat="server" Text="Pregunta No 28: Identifico los elementos de la gestión escolar que pueden ser mejorados con el uso de las TIC, en las diferentes actividades institucionales " OnClick="btnAutoPercepcionDocentePreguntaNo28_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo29" runat="server" Text="Pregunta No 29: Conozco políticas escolares para el uso de las TIC que contemplan la privacidad, el impacto ambiental y la salud de los usuarios " OnClick="btnAutoPercepcionDocentePreguntaNo29_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo30" runat="server" Text="Pregunta No 30: Identifico mis necesidades de desarrollo profesional para la innovación educativa con TIC " OnClick="btnAutoPercepcionDocentePreguntaNo30_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo31" runat="server" Text="Pregunta No 31: Propongo y desarrollo procesos de mejoramiento y seguimiento del uso de TIC en la gestión escolar " OnClick="btnAutoPercepcionDocentePreguntaNo31_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo32" runat="server" Text="Pregunta No 32: Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios" OnClick="btnAutoPercepcionDocentePreguntaNo32_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo33" runat="server" Text="Pregunta No 33: Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios " OnClick="btnAutoPercepcionDocentePreguntaNo33_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo34" runat="server" Text="Pregunta No 34: Selecciono y accedo a programas de formación, apropiados para mis necesidades de desarrollo profesional, para la innovación educativa con TIC " OnClick="btnAutoPercepcionDocentePreguntaNo34_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo35" runat="server" Text="Pregunta No 35: Evalúo los beneficios y utilidades de herramientas TIC en la gestión escolar y en la proyección del PEI dando respuesta a las necesidades de mi institución" OnClick="btnAutoPercepcionDocentePreguntaNo35_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo36" runat="server" Text="Pregunta No 36: Desarrollo políticas escolares para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios" OnClick="btnAutoPercepcionDocentePreguntaNo36_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo37" runat="server" Text="Pregunta No 37: Dinamizo la formación de mis colegas y los apoyo para que integren las TIC de forma innovadora en sus prácticas pedagógicas" OnClick="btnAutoPercepcionDocentePreguntaNo37_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo38" runat="server" Text="Pregunta No 38: Documento observaciones de mi entorno y mi practica con el apoyo de TIC" OnClick="btnAutoPercepcionDocentePreguntaNo38_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo39" runat="server" Text="Pregunta No 39: Identifico redes, bases de datos y fuentes de información que facilitan mis procesos de investigación" OnClick="btnAutoPercepcionDocentePreguntaNo39_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo40" runat="server" Text="Pregunta No 40: Sé buscar, ordenar, filtrar, conectar y analizar información disponible en Internet " OnClick="btnAutoPercepcionDocentePreguntaNo40_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo41" runat="server" Text="Pregunta No 41: Represento e interpreto datos e información de mis investigaciones en diversos formatos digitales " OnClick="btnAutoPercepcionDocentePreguntaNo41_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo42" runat="server" Text="Pregunta No 42: Utilizo redes profesionales y plataformas especializadas en el desarrollo de mis investigaciones" OnClick="btnAutoPercepcionDocentePreguntaNo42_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo43" runat="server" Text="Pregunta No 43: Contrasto y analizo con mis estudiantes información proveniente de múltiples fuentes digitales " OnClick="btnAutoPercepcionDocentePreguntaNo43_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo44" runat="server" Text="Pregunta No 44: Divulgo los resultados de mis investigaciones utilizando las herramientas que me ofrecen las TIC " OnClick="btnAutoPercepcionDocentePreguntaNo44_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo45" runat="server" Text="Pregunta No 45: Participo activamente en redes y comunidades de práctica, para la construcción colectiva de conocimientos con estudiantes y colegas, con el apoyo de TIC" OnClick="btnAutoPercepcionDocentePreguntaNo45_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo46" runat="server" Text="Pregunta No 46: Utilizo la información disponible en Internet con una actitud crítica y reflexiva" OnClick="btnAutoPercepcionDocentePreguntaNo46_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo47" runat="server" Text="Pregunta No 47: Comprendo las posibilidades de las TIC para potenciar procesos de participación democrática" OnClick="btnAutoPercepcionDocentePreguntaNo47_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo48" runat="server" Text="Pregunta No 48:  Identifico los riesgos de publicar y compartir distintos tipos de información a través de Internet" OnClick="btnAutoPercepcionDocentePreguntaNo48_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo49" runat="server" Text="Pregunta No 49: Utilizo las TIC teniendo en cuenta recomendaciones básicas de salud" OnClick="btnAutoPercepcionDocentePreguntaNo49_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo50" runat="server" Text="Pregunta No 50: Examino y aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia" OnClick="btnAutoPercepcionDocentePreguntaNo50_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnAutoPercepcionDocentePreguntaNo51" runat="server" Text="Pregunta No 51: Me comunico de manera respetuosa con los demás" OnClick="btnAutoPercepcionDocentePreguntaNo51_Click" Visible="false" CssClass="btn btn-success" />
<br /><br /> 
            <a href="#" onclick="btnPreguntaNo1_click()" class="btn btn-success">Pregunta No 1</a>
<br /><br />
            <asp:Button ID="btnPerfilDocente" runat="server" Text="Perfil docente" OnClick="btnPerfilDocente_Click" Visible="true" CssClass="btn btn-primary" /> 

            <asp:Button ID="btnFormulariosxMunicipio" runat="server" Text="formularios diligenciados por municipio" OnClick="btnFormulariosxMunicipio_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnFormulariosxSedes" runat="server" Text="formularios diligenciados por sede" OnClick="btnFormulariosxSedes_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnFormulariosxRespondiente" runat="server" Text="formularios diligenciados por respondiente" OnClick="btnFormulariosxRespondiente_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnNivelObtenidoDocente" runat="server" Text="Nivel de formación obtenido" OnClick="btnNivelObtenidoDocente_Click" Visible="false" CssClass="btn btn-success" />        
            <asp:Button ID="btnFormularioDiligenciadoxNivelEducativo" runat="server" Text="formularios diligenciados por nivel de trabajo educativo" OnClick="btnFormularioDiligenciadoxNivelEducativo_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnFormularioDiligenciadoxDocencia" runat="server" Text="formularios diligenciados por desarrollo de docencia" OnClick="btnFormularioDiligenciadoxDocencia_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnCaracterAcademico" runat="server" Text="Carácter academico" OnClick="btnCaracterAcademico_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnCaracterTecnicoAgropecuario" runat="server" Text="Carácter tecnico agropecuario" OnClick="btnCaracterTecnicoAgropecuario_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnCaracterTecnicoComercial" runat="server" Text="Carácter tecnico comercial" OnClick="btnCaracterTecnicoComercial_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnCaracterTecnicoIndustrial" runat="server" Text="Carácter tecnico industrial" OnClick="btnCaracterTecnicoIndustrial_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnFormacionEspecificaPracticasPedagogicas" runat="server" Text="Cursos de formación especifica en sus practicas pedagogicas" OnClick="btnFormacionEspecificaPracticasPedagogicas_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnParticipoProyectosInvestifacionDinstitucion" runat="server" Text="Participo en grupos de investigación dentro INS" OnClick="btnParticipoProyectosInvestifacionDinstitucion_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnModalidadProyectoDinstitucion" runat="server" Text="Modalidad de proyecto dentro INS" OnClick="btnModalidadProyectoDinstitucion_Click" Visible="false" CssClass="btn btn-success" />

<br /><br /> 
            <asp:Button ID="btnPerfilEstudiante" runat="server" Text="Perfil Estudiante" Visible="true" OnClick="btnPerfilEstudiante_Click" CssClass="btn btn-primary" />

            <asp:Button ID="btnEstudiantesMujeres" runat="server" Text="Estudiantes Mujeres" OnClick="btnEstudiantesMujeres_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnEstudiantesconDiscapacidad" runat="server" Text="Estudiantes con discapacidad o capacidad excepcional" OnClick="btnEstudiantesconDiscapacidad_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnEstudiantesPertenecientesGrupoEtnico" runat="server" Text="Estudiantes pertenecientes a un grupo etnico" OnClick="btnEstudiantesPertenecientesGrupoEtnico_Click" Visible="false" CssClass="btn btn-success" />
            <asp:Button ID="btnEstudianteVictimaConflicto" runat="server" Text="Estudiantes victimas del conflicto" OnClick="btnEstudianteVictimaConflicto_Click" Visible="false" CssClass="btn btn-success" />

--%>
            

            <br /><br />
            
           <fieldset>
               <legend>Resultado</legend>
                <div id="table" style="display:none">
                <table class="mGridTesoreria" id="infoListTable"> </table>
            </div>

           </fieldset>

            <asp:Panel ID="panelResultado" runat="server" Visible="false">
                <asp:Button ID="btnExportExcel" runat="server" Text="Exportar excel" OnClick="btnExportExcel_Click" Visible="false" CssClass="btn btn-danger" /><br />
                <asp:Label ID="lblResultado" runat="server" Visible="true"></asp:Label>

                

            </asp:Panel>

      <%--  </ContentTemplate>
    </asp:UpdatePanel>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                   
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>--%>

   

</asp:Content>

