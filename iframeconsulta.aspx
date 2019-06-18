<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="iframeconsulta.aspx.cs" Inherits="iframeconsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="./js/jquery.table2excel.js"></script>
    <style>
        .h2 {
            font-family: 'Lato', Helvetica, sans-serif !important;
            font-weight: bold;
            line-height: 18px;
            font-size: 23px;
        }
        .no-padding {
            padding:0px;
        }
        .padding-5 {
            padding:5px !important;
        }
        body {
             background: #F6F6F6 !important;
        }
        .panel-gray {
            border-color: #26414C;
        }
        .panel-gray > .panel-heading {
            border-color: #26414C;
            color: #fff;
            background-color: #26414C;
        }
        .panel-red {
            border-color: #d9534f;
        }
        .panel-red > .panel-heading {
            border-color: #d9534f;
            color: #fff;
            background-color: #d9534f;
        }
        .panel-info {
            border-color: #5BC0DE;
        }
        .panel-info > .panel-heading {
            border-color: #5BC0DE;
            color: #fff;
            background-color: #5BC0DE;
        }
        .mapa {
            background-image: url(Imagenes/magdalena.png);
            background-size: 300px 424px;
            width: 300px;
            height: 424px;
        }
        fieldset {
            font-family: inherit;
            padding: 10px;
            border: 1px solid #ccc;
        }
        legend {
            font-family: inherit;
            font-size: 12px;
            font-weight: normal;
            font-style: oblique;
            padding: 2px 4px 4px 4px;
            margin-bottom: 0px;
            height: auto;
            width:auto;
            border-bottom: 0px;
        }
    </style>
     <script type="text/javascript" >
         $(document).ready(function () {
             /*inicializo los mensajes popup*/
             $('[data-toggle="popover"]').popover();
             estadoActual();
             productos();
             tiempoEjecucion();
             /*municipios*/
             estadoActualxMunicipio('al', '10', '311');
             estadoActualxMunicipio('ar', '14', '312');
             estadoActualxMunicipio('ai', '8', '313');
             estadoActualxMunicipio('cs', '6', '314');
             estadoActualxMunicipio('ch', '9', '315');
             estadoActualxMunicipio('co', '9', '316'); 
             estadoActualxMunicipio('eb', '38', '286');
             estadoActualxMunicipio('ep', '9', '317');
             estadoActualxMunicipio('er', '6', '318');
             estadoActualxMunicipio('fu', '25', '319'); 
             estadoActualxMunicipio('gu', '13', '320');
             estadoActualxMunicipio('ng', '3', '321');
             estadoActualxMunicipio('pe', '6', '322');
             estadoActualxMunicipio('pc', '2', '323');
             estadoActualxMunicipio('pi', '18', '324');
             estadoActualxMunicipio('pl', '25', '287');
             estadoActualxMunicipio('pv','11','326');
             estadoActualxMunicipio('re', '5', '327');
             estadoActualxMunicipio('sa', '1', '328'); 
             estadoActualxMunicipio('sl', '7', '329');
             estadoActualxMunicipio('ss', '12', '330');
             estadoActualxMunicipio('sz', '8', '331');
             estadoActualxMunicipio('st', '8', '332');
             estadoActualxMunicipio('sb', '5', '333');
             estadoActualxMunicipio('sn', '10', '334');
             estadoActualxMunicipio('te', '7', '335');
             estadoActualxMunicipio('za', '6', '336');
             estadoActualxMunicipio('zb', '6', '337');
             getDeparatamentos();                   
             getMunicipios();
             getLineaInvestigacion();
             /*cargando las instituciones*/
             $("#municipio2").on("change", function () {
                 var codMunicipio = $("#municipio2").val();
                 cargarinstituciones(codMunicipio,"institucion2");                
             });
             $("#municipio3").on("change", function () {
                 var codMunicipio = $("#municipio3").val();
                 cargarinstituciones(codMunicipio,"institucion3");
             });
             $("#municipio4").on("change", function () {
                 var codMunicipio = $("#municipio4").val();
                 cargarinstituciones(codMunicipio, "institucion4");
             });
             $("#municipio7").on("change", function () {
                 var codMunicipio = $("#municipio7").val();
                 cargarinstituciones(codMunicipio, "institucion7");
             });
             $("#municipio8").on("change", function () {
                 var codMunicipio = $("#municipio8").val();
                 cargarinstituciones(codMunicipio, "institucion8");
             });
             $("#municipio8f").on("change", function () {
                 var codMunicipio = $("#municipio8f").val();
                 cargarinstituciones(codMunicipio, "institucion8f");
             });
             //cargando sedes segun institucion seleccionada
             $("#institucion2").change(function () {
                 var codInstitucion = $("#institucion2").val();
                 cargarSedes(codInstitucion,"sede")
             });
             //cargando sedes segun institucion seleccionada
             $("#institucion3").change(function () {
                 var codInstitucion = $("#institucion3").val();
                 cargarSedes(codInstitucion, "sede3")
             });
             //cargando sedes según isntitución seleccionado
             $("#institucion4").change(function () {
                 var codMunicipio = $("#institucion4").val();
                 cargarSedes(codMunicipio, "sede4")
             });
             //cargando sedes segun institucion seleccionada
             $("#institucion7").change(function () {
                 var codInstitucion = $("#institucion7").val();
                 cargarSedes(codInstitucion, "sede7")
             });
             //cargando sedes segun institucion seleccionada
             $("#institucion8").change(function () {
                 var codInstitucion = $("#institucion8").val();
                 cargarSedes(codInstitucion, "sede8")
             });

             $("#institucion8f").change(function () {
                 var codInstitucion = $("#institucion8f").val();
                 cargarSedes(codInstitucion, "sede8f")
             });
             
             //cargando sedes según municipio seleccionado
             $("#municipio5").change(function () {
                 var codMunicipio = $("#municipio5").val();
                 cargarSedesxMunicipio(codMunicipio, "sede5")
             });
             //cargando sedes según municipio seleccionado
             $("#municipio6").change(function () {
                 var codMunicipio = $("#municipio6").val();
                 cargarSedesxMunicipio(codMunicipio, "sede6")
             });
             cargarGrados();
             
         });
         function estadoActual() {
             $.ajax({
                 type: "POST",
                 url: "iframeconsulta.aspx/estadoActual",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 beforeSend: function (xhr) {
                     $("#listIndGenerales").html("<li  class='list-group-item' >Cargando...</li>");
                 },
                 success: function (json) {
                     $("#listIndGenerales").html(json.d);                    
                 }
             });
         }
         function estadoActualxMunicipio(id, sedesEducativas, codMunicipio) {            
             var jsondata = "{'sedesEducativas': '" + sedesEducativas + "','codMunicipio': '" + codMunicipio + "'}";
             $.ajax({
                 type: "POST",
                 data: jsondata,
                 url: "iframeconsulta.aspx/estadoActualxMunicipio",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (json) {                    
                     $("#"+id).attr('data-content',json.d);
                 }
             });
         }
         function productos() {
             $.ajax({
                 type: "POST",
                 url: "iframeconsulta.aspx/productos",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 beforeSend: function (xhr) {
                     $("#listProductos").html("<li  class='list-group-item' >Cargando...</li>");
                 },
                 success: function (json) {
                     $("#listProductos").html(json.d);
                 }
             });
         }
         function tiempoEjecucion() {
             $.ajax({
                 type: "POST",
                 url: "iframeconsulta.aspx/tiempoEjecucion",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 beforeSend: function (xhr) {
                     $("#listTiempo").html("<li  class='list-group-item' >Cargando...</li>");
                 },
                 success: function (json) {
                     $("#listTiempo").html(json.d);
                 }
             });
         }
         function getDeparatamentos() {
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarDepartamentoMagdalena',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "departamento") {
                         $(".departamento").append(resp[1]);
                         $(".departamento").val("20");
                         $(".departamento").attr("disabled", true);
                     }
                 }
             });
         }
         function getMunicipios() {
             var jsondata = "{'codDepartamento': '20'}";
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarMunicipioMagdalena',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "municipio") {
                         $(".municipio").html(resp[1]);
                     }
                 }
             });
         }
         function getLineaInvestigacion() {
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarLineaInvestigacion',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "linea") {
                         $("#lineainvestigacion").html(resp[1]);
                     }
                 }
             });
         }
         function cargarinstituciones(codMunicipio,id) {
             var jsondata = "{'codMunicipio':'" + codMunicipio + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarInstituciones',
                 data: jsondata,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 //data:frmserialize,
                 success: function (json) {
                     var resp = json.d.split("@");
                     if (resp[0] === "inst") {
                         $("#"+id).html(resp[1]);
                     }
                 }
             });
         }
         function cargarSedes(codInstitucion,id){
             var jsonData = '{ "codigoins":"' + codInstitucion + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarsedes',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 data: jsonData,
                 success: function (json) {
                     var resp = json.d.split("@");
                     if (resp[0] === "sedes") {
                         $("#"+id).html(resp[1]);
                     }
                 }
             });
         }

         function cargarSedesxMunicipio(codMunicipio, id) {
             var jsonData = '{ "codMunicipio":"' + codMunicipio + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarsedesxMunicipio',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 data: jsonData,
                 success: function (json) {
                     var resp = json.d.split("@");
                     if (resp[0] === "sedes") {
                         $("#" + id).html(resp[1]);
                     }
                 }
             });
         }

         function verConsultas(id) {
             $("#pl-main").hide();
             $("#"+id).fadeIn(200);
         }
         function cargarInstEduBeneficiadas() {
             var codMunicipio = $("#municipio").val();
             //if (codMunicipio != null) {
                 var jornada = $("#jornada").val();
                 var codZona = $("#zona").val();
                 var niveles = $("#nivel").val();
                 var especialidad = $("#especialidad").val();
                 var jsondata = "{'codMunicipio':'" + codMunicipio + "','codZona':'" + codZona + "','jornada':'" + jornada + "','niveles':'" + niveles + "','especialidad':'" + especialidad + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'iframeconsulta.aspx/cargarInstEduBeneficiadas',
                     data: jsondata,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     beforeSend: function (xhr) {
                         $("#tbliebeneficiadas tbody").html("<tr><td colspan='15' style='padding:15px;'><center>Cargando...</center></td></tr>");
                     },
                     success: function (response) {
                         var resp = response.d.split("#@");
                         if (resp[0] === "table") {
                             $("#tbliebeneficiadas tbody").html(resp[1]);
                         }
                     }
                 });


             //} else {
             //    alert("Seleccione el municipio.");
             //} 
         }
         function cargarSedesEduBeneficiadas() {
             var codMunicipio = $("#municipio2").val();
             var codInstitucion = $("#institucion").val();
             if (codMunicipio == null) {
                 alert("Seleccione el municipio.");
             } else if (codInstitucion==null) {
                 alert("Seleccione la institución.");
             }else{
                 var jornada = $("#jornada2").val();
                 var codZona = $("#zona2").val();
                 var niveles = $("#nivel2").val();
                 var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codZona':'" + codZona + "','jornada':'" + jornada + "','niveles':'" + niveles + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'iframeconsulta.aspx/cargarSedesBeneficiadas',
                     data: jsondata,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     beforeSend: function (xhr) {
                         $("#tblsedesbeneficiadas tbody").html("<tr><td colspan='11' style='padding:15px;'><center>Cargando...</center></td></tr>");
                     },
                     success: function (response) {
                         var resp = response.d.split("#@");
                         if (resp[0] === "table") {
                             $("#tblsedesbeneficiadas tbody").html(resp[1]);
                         }
                     }
                 });


             }
         }
         function exportarExcel(id,namexls) {
             //excel
             $("#"+id).table2excel({
                 exclude: ".noExl",
                 name: "Excel Document Name",
                 filename: namexls,
                 fileext: ".xls",
                 exclude_img: true,
                 exclude_links: true,
                 exclude_inputs: true
             });
         }
         function cargarGrados() {
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarGrados',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "grados") {
                         $("#grado").html(resp[1]);
                     }
                 }
             });
         }

         function cargarEstudiantesBeneficiados() {
             var codMunicipio = $("#municipio3").val();
             var codInstitucion = $("#institucion3").val();
             var codSede = $("#sede3").val();
             if (codMunicipio == null) {
                 alert("Seleccione el municipio.");
             } else if (codInstitucion == null) {
                 alert("Seleccione la institución.");
             } else if (codSede == null) {
                 alert("Seleccione la sede.");
             } else {
                 var grupos = $("#grupos").val();
                 var sexo = $("#sexo").val();
                 var grado = $("#grado").val();
                 var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "','grupos':'" + grupos + "','sexo':'" + sexo + "','grado':'" + grado + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'iframeconsulta.aspx/cargarEstudiantesBeneficiados',
                     data: jsondata,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     beforeSend: function (xhr) {
                         $("#tblestubeneficiados tbody").html("<tr><td colspan='11' style='padding:15px;'><center>Cargando...</center></td></tr>");
                     },
                     success: function (response) {
                         var resp = response.d.split("@");
                         if (resp[0] === "table") {
                             $("#tblestubeneficiados tbody").html(resp[1]);
                         }
                     }
                 });


             }
         }

         function cargarSedesConectadas() {
             var codMunicipio = $("#municipio5").val();
             var codSede = $("#sede5").val();
          
            var zona = $("#zona5").val();
            var bw = $("#bw5").val();
               
            var jsondata = "{'codMunicipio':'" + codMunicipio + "','codSede':'" + codSede + "','zona':'" + zona + "','bw':'" + bw + "'}";
            $.ajax({
                type: 'POST',
                url: 'iframeconsulta.aspx/cargarSedesConectadas',
                data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                beforeSend: function (xhr) {
                    $("#tblsedesconectadas tbody").html("<tr><td colspan='9' style='padding:15px;'><center>Cargando...</center></td></tr>");
                },
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "table") {
                        $("#tblsedesconectadas tbody").html(resp[1]);
                    }
                }
            });

         }

         function cargarDocentesBeneficiados() {
             var codMunicipio = $("#municipio4").val();
             var codInstitucion = $("#institucion4").val();
             var codSede = $("#sede4").val();

             var sexodocente = $("#sexodocente").val();
             var areas = $("#areas").val();
             var formacion = $("#formacion").val();
             var tipomaestro = $("#tipomaestro").val();

             var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "','sexodocente':'" + sexodocente + "','tipomaestro':'" + tipomaestro + "'}";
             //var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "','sexodocente':'" + sexodocente + "','areas':'" + areas + "','formacion':'" + formacion + "','tipomaestro':'" + tipomaestro + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarDocentesBeneficiados',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 beforeSend: function (xhr) {
                     $("#tbldocentesbeneficiados tbody").html("<tr><td colspan='10' style='padding:15px;'><center>Cargando...</center></td></tr>");
                 },
                 success: function (response) {
                     var resp = response.d.split("search@");
                     if (resp[0] === "table") {
                         $("#tbldocentesbeneficiados tbody").html(resp[1]);
                     }
                 }
             });

         }

         function cargarSedesConTablets() {
             var codMunicipio = $("#municipio6").val();
             var codSede = $("#sede6").val();
             var zona = $("#zona6").val();

             var jsondata = "{'codMunicipio':'" + codMunicipio + "','codSede':'" + codSede + "','zona':'" + zona + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarSedesConTables',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 beforeSend: function (xhr) {
                     $("#tblsedescontablets tbody").html("<tr><td colspan='9' style='padding:15px;'><center>Cargando...</center></td></tr>");
                 },
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "table") {
                         $("#tblsedescontablets tbody").html(resp[1]);
                     }
                 }
             });

         }

         function cargarGruposJuveniles() {
             var codMunicipio = $("#municipio7").val();
             var codInstitucion = $("#institucion7").val();
             var codSede = $("#sede7").val();
             var lineainvestigacion = $("#lineainvestigacion").val();
             var tipo = $("#tipoproyecto").val();

             var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "','lineainvestigacion':'" + lineainvestigacion + "','tipoproyecto':'" + tipo + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarGruposJuveniles',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 beforeSend: function (xhr) {
                     $("#tblgruposjuveniles tbody").html("<tr><td colspan='8' style='padding:15px;'><center>Cargando...</center></td></tr>");
                 },
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "table") {
                         $("#tblgruposjuveniles tbody").html(resp[1]);
                     }
                 }
             });

         }

         function cargarGruposMaestros() {
             var codMunicipio = $("#municipio8").val();
             var codInstitucion = $("#institucion8").val();
             var codSede = $("#sede8").val();
             var tipo = $("#tipoproyecto8").val();

             var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "','tipoproyecto':'" + tipo + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'iframeconsulta.aspx/cargarGruposMaestros',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 beforeSend: function (xhr) {
                     $("#tblgruposmaestros tbody").html("<tr><td colspan='8' style='padding:15px;'><center>Cargando...</center></td></tr>");
                 },
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "table") {
                         $("#tblgruposmaestros tbody").html(resp[1]);
                     }
                 }
             });

         }
     </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
     <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
     <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false" ></asp:Label>
      <br /><br />
<div id="pl-main" >
    <h2 class="h2">Consultas</h2>
    <div class="panel panel-default">
        <div class="panel-body">
            <p >
            <strong>Macondo</strong> ofrece información sobre el funcionamiento del proyecto, el logro de los objetivos propuestos, los niveles de desarrollo de la experiencia en cada contexto, las condiciones que afectan los procesos en las distintas instancias y el aporte de los diferentes actores, con el propósito orientar acciones de mejoramiento continuo
            </p>
        </div>
    </div>
     <div class="row" >
         <div   class="col-lg-3 col-md-6">
             <div  class="panel panel-info" >
                 <div class="panel-heading">
                     <span class="h4"><i class="glyphicon glyphicon-stats" aria-hidden="true"></i>  Estado actual</span>
                 </div>
                  <div class="panel-body no-padding">
                      <ul id="listIndGenerales" class="list-group">                     

                      </ul>
                  </div>
             </div>
             <% /*end*/ %>
             <div  class="panel panel-gray" >
                 <div class="panel-heading">
                     <span class="h4"><i class="glyphicon glyphicon-check" aria-hidden="true"></i>  Productos</span>
                 </div>
                  <div class="panel-body no-padding">
                      <ul id="listProductos" class="list-group">                     

                      </ul>
                  </div>
             </div>                          
         </div> <% /*end*/%> 
         <div  class="col-lg-9 col-md-6 " >
             <div  class="panel panel-red" >
                 <div class="panel-heading">
                     <span class="h4"><i class="glyphicon glyphicon-map-marker" aria-hidden="true"></i> Municipios beneficiados</span>
                 </div>
                 <div class="panel-body" style="padding-bottom:0px;">
                     <div class="row">
                         <div class="col-lg-6 padding-5">
                                <div class="mapa">
                                    <span id="zb" style="position: absolute;top: 102px; left: 155px; cursor:pointer;" data-toggle="popover" data-trigger="hover" title="Zona Bananera" data-html="true">28</span>
                                    <span id="pv" style="position: absolute;top: 95px; left: 116px; cursor:pointer;" data-toggle="popover" data-trigger="hover" title="Pueblo Viejo" data-html="true">17</span>
                                    <span id="sn" style="position: absolute;top: 90px; left: 80px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Sitionuevo" data-html="true">25</span>
                                    <span id="er" style="position: absolute;top: 122px; left: 126px; cursor:pointer;" data-toggle="popover" data-trigger="hover" title="El Retén" data-html="true">9</span>
                                    <span id="re" style="position: absolute;top: 125px; left: 80px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Remolino" data-html="true">18</span>               
                                    <span id="ar" style="position: absolute;top: 130px; left: 210px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Aracataca" data-html="true">2</span>
                                    <span id="sl" style="position: absolute;top: 150px; left: 55px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Salamina" data-html="true">20</span>  
                                    <span id="pi" style="position: absolute;top: 165px; left: 115px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Pivijay" data-html="true">15</span>  
                                    <span id="fu" style="position: absolute;top: 160px; left: 210px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Fundación" data-html="true">10</span>
                                    <span id="al" style="position: absolute;top: 190px; left: 170px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Algarrobo" data-html="true">1</span>
                                    <span id="ep" style="position: absolute;top: 175px; left: 65px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="El Piñon" data-html="true">8</span>
                                    <span id="cs" style="position: absolute;top: 183px; left: 37px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Cerro San Antonio" data-html="true">4</span>
                                    <span id="co" style="position: absolute;top: 198px; left: 50px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Concordia" data-html="true">6</span>
                                    <span id="pe" style="position: absolute;top: 209px; left: 32px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Pedraza" data-html="true">13</span>
                                    <span id="za" style="position: absolute;top: 215px; left: 61px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Zapayán" data-html="true">27</span>  
                                    <span id="ch" style="position: absolute;top: 218px; left: 92px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Chibolo" data-html="true">5</span>   
                                    <span id="sa" style="position: absolute;top: 226px; left: 136px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Sabanas de San Angel" data-html="true">19</span>   
                                    <span id="te" style="position: absolute;top: 245px; left: 55px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Tenerife" data-html="true">26</span>
                                    <span id="pl" style="position: absolute;top: 278px; left: 73px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Plato" data-html="true">16</span>  
                                    <span id="ng" style="position: absolute;top: 278px; left: 122px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Nueva Granada" data-html="true">12</span>
                                    <span id="ai" style="position: absolute;top: 264px; left: 162px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Ariguaní" data-html="true">3</span>    
                                    <span id="sb" style="position: absolute;top: 310px; left: 73px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Santa Bárbara de Pinto" data-html="true">24</span>
                                    <span id="st" style="position: absolute;top: 320px; left: 108px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Santa Ana" data-html="true">23</span>    
                                    <span id="pc" style="position: absolute;top: 340px; left: 118px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Pijiño del Carmen" data-html="true">14</span> 
                                    <span id="sz" style="position: absolute;top: 355px; left: 113px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="San Zenón" data-html="true">22</span>
                                    <span id="ss" style="position: absolute;top: 334px; left: 160px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="San Sebastián de Buenavista" data-html="true">21</span>                 
                                    <span id="gu" style="position: absolute;top: 360px; left: 163px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="Guamal" data-html="true">11</span>                 
                                    <span id="eb" style="position: absolute;top: 385px; left: 190px; cursor:pointer;" data-toggle="popover" data-trigger="hover"  title="El Banco" data-html="true">7</span>                 
                                
                                </div>
                                <ul id="listTiempo" class="list-group">                                    
                                </ul>
                                <!--<button type="button" class="btn btn-warning btn-lg btn-block">Duración del proyecto: 36 meses</button>
                                <button type="button" class="btn btn-warning btn-lg btn-block">Ejecutado: 18 meses</button>-->
                         </div>
                         <div class="col-lg-2 padding-5">
                             <ul  class="list-group">
                                  <li class='list-group-item'>1. Algarrobo</li> 
                                  <li class='list-group-item'>2. Aracataca</li>
                                  <li class='list-group-item'>3. Ariguaní</li>
                                  <li class='list-group-item'>4. Cerro San Antonio</li>
                                  <li class='list-group-item'>5. Chibolo</li>
                                  <li class='list-group-item'>6. Concordia</li>
                                  <li class='list-group-item'>7. El Banco</li>
                                  <li class='list-group-item'>8. El Piñon</li>
                                  <li class='list-group-item'>9. El Retén</li>
                               </ul>
                         </div>
                         <div class="col-lg-2 padding-5">
                             <ul  class="list-group">
                                  <li class='list-group-item'>10. Fundación</li>
                                  <li class='list-group-item'>11. Guamal</li>
                                  <li class='list-group-item'>12. Nueva Granada</li>
                                  <li class='list-group-item'>13. Pedraza</li>
                                  <li class='list-group-item'>14. Pijiño del Carmen</li>
                                  <li class='list-group-item'>15. Pivijay</li>
                                  <li class='list-group-item'>16. Plato</li>
                                  <li class='list-group-item'>17. Pueblo Viejo</li>
                                  <li class='list-group-item'>18. Remolino</li>
                               </ul>
                         </div>
                         <div class="col-lg-2 padding-5">
                              <ul  class="list-group">
                                  <li class='list-group-item'>19. Sabanas de San Angel</li>
                                  <li class='list-group-item'>20. Salamina</li>
                                  <li class='list-group-item'>21. San Sebastián de Buenavista</li>
                                  <li class='list-group-item'>22. San Zenón</li>
                                  <li class='list-group-item'>23. Santa Ana</li>
                                  <li class='list-group-item'>24. Santa Bárbara de Pinto</li>
                                  <li class='list-group-item'>25. Sitionuevo</li>
                                  <li class='list-group-item'>26. Tenerife</li>
                                  <li class='list-group-item'>27. Zapayán</li>
                                  <li class='list-group-item'>28. Zona Bananera</li>                     
                               </ul>
                         </div>
                     </div>
                    
                 </div>
             </div>
         </div> <% /*end*/%>     
     </div><% /*end*/%>
    <div class="row" >
         <div   class="col-lg-8 col-lg-offset-2">
             <div  class="panel panel-primary" >
                 <div class="panel-heading">
                     <span class="h4"><i class="glyphicon glyphicon-search" aria-hidden="true"></i> Consulta avanzada</span>
                 </div>
                 <div class="panel-body no-padding">                      
                        <div class="list-group">
                            <button type="button" class="list-group-item" onclick="verConsultas('iebeneficiadas');"><i class="glyphicon glyphicon-home" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Instituciones educativas beneficiadas</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('sedesbeneficiadas');"><i class="glyphicon glyphicon-home" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Sedes educativas beneficiadas</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('estubeneficiados');"><i class="glyphicon glyphicon-user" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Estudiantes beneficiados</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('mbeneficiados');"><i class="glyphicon glyphicon-user" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Maestros beneficiados</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('seconectadas');"><i class="glyphicon glyphicon-home" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Sedes educativas conectadas</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('setabletas');"><i class="glyphicon glyphicon-home" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Sedes educativas con tabletas</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('gijuveniles');"><i class="glyphicon glyphicon-user" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Grupos de investigación infantiles y juveniles</button>
                            <button type="button" class="list-group-item" onclick="verConsultas('gimaestros');"><i class="glyphicon glyphicon-user" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Grupos de investigación de maestros</button> 
                            <button type="button" class="list-group-item" onclick="verConsultas('gimaestrosf');"><i class="glyphicon glyphicon-user" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Maestros Formados</button> 

                        </div>
                  </div>
             </div>
         </div>
    </div> <% /*end*/%>  
</div>
<!--iebeneficiadas-->
<div id="iebeneficiadas" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Instituciones educativas beneficiadas</span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
   <br />
    <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento" id="departamento" style="width:125px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio" id="municipio"  style="width:300px;">
                        <option value="">Todo</option>
                    </select>
                </td>            
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
              <td style="padding-right:10px;">Zona:</td>
               <td>
                    <select class="TextBox" name="zona" id="zona"  style="width:90px;">
                        <option value="1">Rurales</option>
                        <option value="2">Urbanas</option>
                        <option value="5">Rurales y Urbanas</option>
                        <option value=""  selected="selected">Todas</option>
                    </select>
                </td>
               <td style="padding: 0 10px;">Jornada:</td>
               <td>
                    <select class="TextBox" name="jornada" id="jornada"  style="width:100px;">
                        <option value="Completa" >Completa</option>
                        <option value="Mañana">Mañana</option>
                        <option value="Tarde">Tarde</option>
                        <option value="Nocturna">Nocturna</option>
                        <option value="Fin de semana">Fin de semana</option>
                        <option value="" selected="selected">Todas</option>                        
                    </select>
                </td>
                <td style="padding: 0 10px;">Niveles de enseñanza:</td>
                <td>
                    <select class="TextBox" name="nivel" id="nivel"  style="width:150px;">
                        <option value="Preescolar">Preescolar</option>
                        <option value="Básica primaria">Básica primaria</option>
                        <option value="Básica secundaria">Básica secundaria</option>
                        <option value="Media">Media</option>
                         <option value="" selected="selected">Todos</option>
                    </select>
                </td>
                <td style="padding: 0 10px;">Carácter y especialidad:</td>
                <td>
                    <select class="TextBox" name="especialidad" id="especialidad"  style="width:150px;">
                        <option value="Académica">Académica</option>
                        <option value="Técnica (Incluye la Comercial, Industrial, Pedagógica, Promoción social, Agropecuario)">Técnica</option>
                        <option value="Otras">Otras</option>
                         <option value=""  selected="selected">Todos</option>
                    </select>
                </td>
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarInstEduBeneficiadas()">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tbliebeneficiadas','InstitucionesEducativasBeneficiadas')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tbliebeneficiadas" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>DANE</th>
                    <th>Dirección</th>
                    <th>Teléfono<br />De la institución</th>
                    <th>Email</th>
                    <th>zona</th>
                    <th>Jornada</th>
                    <th>Niveles de enseñanza</th>
                    <th>Carácter y espacialidad</th>
                    <th>Nombre del rector</th>
                    <th>Identificación</th>
                    <th>Teléfono</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="15" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!--end-->
<!--sedesbeneficiadas-->
<div id="sedesbeneficiadas" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Sedes educativas beneficiadas</span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
    <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento2" id="departamento2" style="width:125px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio2" id="municipio2"  style="width:300px;">
                        <option value="">Seleccione municipio</option>
                    </select>
                </td> 
                <td style="padding:0 10px;">Institución educativa</td>
                 <td>
                    <select class="TextBox" name="institucion" id="institucion"  style="width:300px;">
                        <option value="">Seleccione la institución</option>
                    </select>
                </td>           
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
              <td style="padding-right:10px;">Zona:</td>
               <td>
                    <select class="TextBox" name="zona2" id="zona2"  style="width:90px;">
                        <option value="1">Rurales</option>
                        <option value="2">Urbanas</option>
                        <option value="5">Rurales y Urbanas</option>
                        <option value=""  selected="selected">Todas</option>
                    </select>
                </td>
               <td style="padding: 0 10px;">Jornada:</td>
               <td>
                    <select class="TextBox" name="jornada2" id="jornada2"  style="width:100px;">
                        <option value="Completa" >Completa</option>
                        <option value="Mañana">Mañana</option>
                        <option value="Tarde">Tarde</option>
                        <option value="Nocturna">Nocturna</option>
                        <option value="Fin de semana">Fin de semana</option>
                        <option value="" selected="selected">Todas</option>                        
                    </select>
                </td>
                <td style="padding: 0 10px;">Niveles de enseñanza:</td>
                <td>
                    <select class="TextBox" name="nivel2" id="nivel2"  style="width:150px;">
                        <option value="Preescolar">Preescolar</option>
                        <option value="Básica primaria">Básica primaria</option>
                        <option value="Básica secundaria">Básica secundaria</option>
                        <option value="Media">Media</option>
                         <option value="" selected="selected">Todos</option>
                    </select>
                </td>
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarSedesEduBeneficiadas()">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblsedesbeneficiadas','SedesEducativasBeneficiadas')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblsedesbeneficiadas" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No. </th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede Educativa</th>
                    <th>DANE</th>
                    <th>Dirección</th>
                    <th>Teléfono<br />De la sede</th>
                    <th>Email</th>
                    <th>zona</th>
                    <th>Jornada</th>
                    <th>Niveles de enseñanza</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="11" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!--end-->
<!--estubeneficiados-->
<div id="estubeneficiados" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Estudiantes beneficiados</span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
    <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0" style="width:1000px;">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento3" id="departamento3" style="width:150px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio3" id="municipio3"  style="width:300px;">
                        <option value="">Seleccione municipio</option>
                    </select>
                </td> 
                <td style="padding:0 10px;">Institución educativa</td>
                 <td>
                    <select class="TextBox" name="institucion3" id="institucion3"  style="width:300px;">
                        <option value="">Seleccione la institución</option>
                    </select>
                </td>           
            </tr>
            <tr>
               <td style="padding-top:10px;padding-right:10px; text-align:right">Sede</td>
                <td colspan="3" style="padding-top:10px;">
                    <select name="sede3" id="sede3" class="TextBox width-100" >
                         <option value="">Seleccione la sede</option>
                    </select>

                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
              <td style="padding-right:10px;">Estudiantes en:</td>
               <td>
                    <select class="TextBox" name="grupos" id="grupos"  style="width:200px;">
                        <option value="Grupos de investigación">Grupos de investigación</option>
                        <option value="Redes temáticas" selected="selected">Redes temáticas</option>
                    </select>
                </td>
               <td style="padding: 0 10px;">Sexo:</td>
               <td>
                    <select class="TextBox" name="sexo" id="sexo"  style="width:100px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="M">Masculino</option>
                        <option value="F">Femenino</option>                       
                    </select>
                </td>
                <td style="padding: 0 10px;">Grado:</td>
                <td>
                    <select class="TextBox" name="grado" id="grado"  style="width:300px;">
                    </select>
                </td>
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarEstudiantesBeneficiados();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblestubeneficiados','EstudiantesBeneficiados')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblestubeneficiados" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede Educativa</th>
                    <th>Nombre</th>
                    <th>Sexo</th>	
                    <th>Grado</th>
                    <th>Grupo</th>

                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="9" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!--end-->
<div id="mbeneficiados" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Maestros beneficiados</span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
    <fieldset>
        <legend>Posición geográfica  </legend>
         <table border="0" style="width:1000px;">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento4" id="departamento4" style="width:150px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio4" id="municipio4"  style="width:300px;">
                        <option value="">Seleccione municipio</option>
                    </select>
                </td> 
                        
            </tr>
            <tr>
                <td style="padding:0 10px;">Institución educativa</td>
                 <td>
                    <select class="TextBox" name="institucion4" id="institucion4"  style="width:300px;">
                        <option value="">Seleccione la institución</option>
                    </select>
                </td>   
               <td style="padding-top:10px;padding-right:10px; text-align:right">Sede</td>
                <td colspan="3" style="padding-top:10px;">
                    <select name="sede4" id="sede4" class="TextBox width-100" style="width:300px;" >
                         <option value="">Seleccione la sede</option>
                    </select>

                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
             
               <td style="padding: 0 10px;">Maestros:</td>
               <td>
                    <select class="TextBox" name="tipomasestro" id="tipomasestro"  style="width:200px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="participantes">Maestros participantes</option>
                        <option value="grupos">Maestros que acompañan  grupos de investigación</option>                       
                        <option value="redes">Maestros que acompañan rede temáticas</option>
                    </select>
                </td>
                <td style="padding: 0 10px;">Sexo:</td>
                <td>
                    <select class="TextBox" name="sexom" id="sexodocente"  style="width:70px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="F">Femenino</option>
                        <option value="M">Masculino</option>
                    </select>
                </td>
                <%--<td style="padding: 0 10px;">Formación:</td>
                <td>
                    <select class="TextBox" name="formacion" id="formacion"  style="width:200px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="Normalista Superior">Bachillerato pedagógico</option>
                        <option value="Normalista Superior">Normalista Superior</option>
                        <option value="Otro bachillerato">Otro bachillerato</option>
                        <option value="Técnico o tecnológico">Técnico o tecnológico </option>
                        <option value="Otro Técnico o tecnológico">Otro Técnico o tecnológico</option>
                        <option value="Profesional pedagógico">Profesional pedagógico</option>
                        <option value="Otro profesional">Otro profesional</option>
                        <option value="Especialización">Especialización</option>
                        <option value="Maestría en educación o pedagogía">Maestría en educación o pedagogía</option>
                        <option value="Otra Maestría">Otra Maestría</option>
                        <option value="Doctorado en educación o pedagogía">Doctorado en educación o pedagogía</option>
                        <option value="Otro doctorado">Otro doctorado</option>
                    </select>
                </td>
                <td style="padding: 0 10px;">Áreas de enseñanza:</td>
                <td>
                    <select class="TextBox" name="areas" id="areas"  style="width:200px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="Todas las áreas">Todas las áreas</option>
                        <option value="Ciencias naturales y educación ambiental">Ciencias naturales y educación ambiental</option>
                        <option value="Ciencias sociales, historia, geografía, constitución política y democracia">Ciencias sociales, historia, geografía, constitución política y democracia</option>
                        <option value="Educación artística">Educación artística</option>
                        <option value="Educación ética y en valores humanos">Educación ética y en valores humanos</option>
                        <option value="Educación física, recreación y deportes">Educación física, recreación y deportes</option>
                        <option value="Educación religiosa">Educación religiosa</option>
                        <option value="Humanidades, lengua castellana e idiomas extranjeros">Humanidades, lengua castellana e idiomas extranjeros</option>
                        <option value="Matemáticas">Matemáticas</option>
                        <option value="Tecnología e informática">Tecnología e informática</option>
                        <option value="Ciencias económicas">Ciencias económicas</option>
                        <option value="Ciencias políticas">Ciencias políticas</option>
                        <option value="Filosofía">Filosofía</option>
                        <option value="Otra">Otra</option>
                    </select>
                </td>--%>
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarDocentesBeneficiados();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tbldocentesbeneficiados','DocentesBeneficiados')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <table id="tbldocentesbeneficiados" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Institución educativa</th>
                    <th>Sede educativa</th>
                    <th>Nombre</th>
                    <th>Cédula</th>	
                    <th>Email</th>
                    <th>Sexo</th>
                    <th>Último nivel de formación</th>
                    <th>Área de enseñanza</th>
                    <th></th>

                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="10" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!--end-->
    <!--sedesconectadas-->
<div id="seconectadas" style="display:none;">
     <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Sedes conectadas</span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
     <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento5" id="departamento5" style="width:125px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio5" id="municipio5"  style="width:300px;">
                        <option value="">Todo</option>
                    </select>
                </td> 
                <td style="padding:0 10px;">Sede</td>
                <td>
                    <select class="TextBox sede" name="sede5" id="sede5"  style="width:300px;">
                        <option value="">Todo</option>
                    </select>
                </td>            
            </tr>
        </table>
    </fieldset>

     <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
             
               <td style="padding: 0 10px;">Zona:</td>
               <td>
                    <select class="TextBox" name="zona5" id="zona5"  style="width:100px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="RURAL">Rural</option>
                        <option value="URBANA">Urbana</option>                       
                    </select>
                </td>
                <td style="padding: 0 10px;">BW:</td>
                <td>
                    <select class="TextBox" name="bw5" id="bw5"  style="width:70px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="4 MB">4 MB</option>
                        <option value="6 MB">6 MB</option>
                    </select>
                </td>
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarSedesConectadas();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblsedesconectadas','SedesConectadas')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblsedesconectadas" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Dane</th>
                    <th>Nombre sede educativa</th>
                    <th>Zona</th>
                    <th>Bw</th>	
                    <th>Fecha activación del servicio</th>

                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="7" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!--end-->
    <!-- Sedes tabletas -->
<div id="setabletas" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Sedes educativas con tablets</span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
     <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento6" id="departamento6" style="width:125px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio6" id="municipio6"  style="width:300px;">
                        <option value="">Todo</option>
                    </select>
                </td> 
                <td style="padding:0 10px;">Sede</td>
                <td>
                    <select class="TextBox sede" name="sede6" id="sede6"  style="width:300px;">
                        <option value="">Todo</option>
                    </select>
                </td>            
            </tr>
        </table>
    </fieldset>

     <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
             
               <td style="padding: 0 10px;">Zona:</td>
               <td>
                    <select class="TextBox" name="zona6" id="zona6"  style="width:100px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="1">Rural</option>
                        <option value="2">Urbana</option>                       
                    </select>
                </td>
             
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarSedesConTablets();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblsedescontablets','SedesConTablets')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblsedescontablets" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Institución educativa</th>
                    <th>Nombre sede educativa</th>
                    <th>Dane</th>
                    <th>Zona</th>
                    <th>Tablets para estudiantes</th>	
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="7" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  

</div><!-- end -->
<div id="gijuveniles" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Grupos infantiles y juveniles </span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
     <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0" style="width:1000px;">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento7" id="departamento7" style="width:150px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio7" id="municipio7"  style="width:300px;">
                        <option value="">Seleccione municipio</option>
                    </select>
                </td> 
                        
            </tr>
            <tr>
                <td style="padding:0 10px;">Institución educativa</td>
                 <td>
                    <select class="TextBox" name="institucion7" id="institucion7"  style="width:300px;">
                        <option value="">Seleccione la institución</option>
                    </select>
                </td>   
               <td style="padding-top:10px;padding-right:10px; text-align:right">Sede</td>
                <td colspan="3" style="padding-top:10px;">
                    <select name="sede7" id="sede7" class="TextBox width-100" style="width:300px;" >
                         <option value="">Seleccione la sede</option>
                    </select>

                </td>
            </tr>
        </table>
    </fieldset>

     <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
             
               <td style="padding: 0 10px;">Línea de investigación:</td>
               <td>
                    <select class="TextBox" name="lineainvestigacion" id="lineainvestigacion"  style="width:300px;">
                    </select>
                </td>
                <td style="padding: 0 10px;">Tipo de proyecto:</td>
                 <td>
                    <select class="TextBox" name="tipoproyecto" id="tipoproyecto"  style="width:100px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="2">Abierta</option>
                        <option value="3">Pre-Estructurado</option>                       
                    </select>
                </td>
             
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarGruposJuveniles();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblgruposjuveniles','GruposJuveniles')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblgruposjuveniles" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>Municipio</th>
                    <th>Institución educativa</th>
                    <th>Nombre sede educativa</th>
                    <th>Dane</th>
                    <th>Zona</th>
                    <th>Grupo de investigación</th>	
                    <th>Línea investigación</th>	
                    <th>Tipo de proyecto</th>	
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="8" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!-- end -->
<div id="gimaestros" style="display:none;">

    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Grupos de investigación de maestros </span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
     <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0" style="width:1000px;">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento8" id="departamento8" style="width:150px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio8" id="municipio8"  style="width:300px;">
                        <option value="">Seleccione municipio</option>
                    </select>
                </td> 
                        
            </tr>
            <tr>
                <td style="padding:0 10px;">Institución educativa</td>
                 <td>
                    <select class="TextBox" name="institucion8" id="institucion8"  style="width:300px;">
                        <option value="">Seleccione la institución</option>
                    </select>
                </td>   
               <td style="padding-top:10px;padding-right:10px; text-align:right">Sede</td>
                <td colspan="3" style="padding-top:10px;">
                    <select name="sede8" id="sede8" class="TextBox width-100" style="width:300px;" >
                         <option value="">Seleccione la sede</option>
                    </select>

                </td>
            </tr>
        </table>
    </fieldset>

     <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>                
             
                <td style="padding: 0 10px;">Tipo de proyecto:</td>
                 <td>
                    <select class="TextBox" name="tipoproyecto8" id="tipoproyecto8"  style="width:100px;">
                        <option value=""  selected="selected">Todos</option>
                        <option value="2">Abierta</option>
                        <option value="3">Pre-Estructurado</option>                       
                    </select>
                </td>
             
                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarGruposMaestros();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblgruposmaestros','GruposMaestros')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblgruposmaestros" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>Municipio</th>
                    <th>Institución educativa</th>
                    <th>Nombre sede educativa</th>
                    <th>Dane</th>
                    <th>Zona</th>
                    <th>Grupo de investigación</th>	
                    <th>Pregunta de investigación</th>	
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="8" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  

</div>

    <div id="gimaestrosf" style="display:none;">

    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Maestros formados </span>
        <a href="iframeconsulta.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;" >Regresar</a>
    </div>
    <br />
     <fieldset>
        <legend>Posición geográfica  </legend>
        <table border="0" style="width:1000px;">
            <tr>
                <td style="padding-right:10px;">Departamento</td>
                <td>
                    <select class="TextBox departamento" name="departamento8" id="departamento8f" style="width:150px;">
                        <option value="">Seleccione departamento</option>
                    </select>
                </td>
                <td style="padding:0 10px;">Municipio</td>
                <td>
                    <select class="TextBox municipio" name="municipio8" id="municipio8f"  style="width:300px;">
                        <option value="">Seleccione municipio</option>
                    </select>
                </td> 
                        
            </tr>
            <tr>
                <td style="padding:0 10px;">Institución educativa</td>
                 <td>
                    <select class="TextBox" name="institucion8" id="institucion8f"  style="width:300px;">
                        <option value="">Seleccione la institución</option>
                    </select>
                </td>   
               <td style="padding-top:10px;padding-right:10px; text-align:right">Sede</td>
                <td colspan="3" style="padding-top:10px;">
                    <select name="sede8" id="sede8f" class="TextBox width-100" style="width:300px;" >
                         <option value="">Seleccione la sede</option>
                    </select>

                </td>
            </tr>
        </table>
    </fieldset>

     <fieldset>
        <legend>Filtros</legend>
        <table  border="0">
            <tr>      
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarGruposMaestros();">Buscar</a>
                </td>          
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblgruposmaestros','GruposMaestros')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblgruposmaestrosf" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Identificación</th>
                    <th>Municipio</th>
                    <th>Institución educativa</th>
                    <th>Nombre sede educativa</th>	
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="8" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  

</div>
    
</asp:Content>

