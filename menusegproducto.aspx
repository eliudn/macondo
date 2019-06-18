<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="menusegproducto.aspx.cs" Inherits="menusegproducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <%--<script src="Scripts/pruebas.js"></script>--%>

     <script>
         $(document).ready(function () {
             getDeparatamentos();
             getMunicipios();
             getLineaInvestigacion();
             getRedes();
             cargardatos();

            $("#MainContent_accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#MainContent_accordion").attr("style", "visibility:visible;");

             //cargando sedes según municipio seleccionado
            $("#municipio5").change(function () {
                var codMunicipio = $("#municipio5").val();
                cargarSedesxMunicipio(codMunicipio, "sede5")
            });
            $("#municipio7").on("change", function () {
                var codMunicipio = $("#municipio7").val();
                cargarinstituciones(codMunicipio, "institucion7");
            });
             //cargando sedes segun institucion seleccionada
            $("#institucion7").change(function () {
                var codInstitucion = $("#institucion7").val();
                cargarSedes(codInstitucion, "sede7")
            });
         });

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

         function getRedes() {
             $.ajax({
                 type: 'POST',
                 url: 'menusegproducto.aspx/cargarRedes',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "red") {
                         $("#redest").html(resp[1]);
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

         function cargardatos() {

             $.ajax({
                 type: "POST",
                 url: "menusegproducto.aspx/cargardatos",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (json) {
                     $("#tableList tbody").html(json.d);
                 }
             });
         }

         function verConsultas(id) {
             $("#listado").hide();
             $("#" + id).fadeIn(200);
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

         function cargarFerias() {
             $("#listado").hide();
             $("#ferias").fadeIn(200);
             $.ajax({
                 type: 'POST',
                 url: 'menusegproducto.aspx/cargarFerias',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 beforeSend: function (xhr) {
                     $("#tblferias tbody").html("<tr><td colspan='9' style='padding:15px;'><center>Cargando...</center></td></tr>");
                 },
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "table") {
                         $("#tblferias tbody").html(resp[1]);
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

         function cargarRedesTematicas() {
             var codMunicipio = $("#municipio8").val();
             var codInstitucion = $("#institucion8").val();
             var codSede = $("#sede8").val();
             
                 var redtematica = $("#redest").val();
                 var jsondata = "{'codMunicipio':'" + codMunicipio + "','codInstitucion':'" + codInstitucion + "','codSede':'" + codSede + "','redtematica':'" + redtematica + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'menusegproducto.aspx/cargarRedesTematicas',
                     data: jsondata,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     beforeSend: function (xhr) {
                         $("#tblredestematicas tbody").html("<tr><td colspan='11' style='padding:15px;'><center>Cargando...</center></td></tr>");
                     },
                     success: function (response) {
                         var resp = response.d.split("@");
                         if (resp[0] === "table") {
                             $("#tblredestematicas tbody").html(resp[1]);
                         }
                     }
                 });

         }

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


    <style type="text/css">
         .h2 {
            font-family: 'Lato', Helvetica, sans-serif !important;
            font-weight: bold;
            line-height: 18px;
            font-size: 23px;
        }
        img.res {
            width: 100%;
            max-width: 600px;
        }

        .navegadores {
            background-color: #BECECE;
            float: right;
            border-top:2px solid #8FA9A9;
            border-left:2px solid #8FA9A9;
            border-collapse: collapse;
            border-radius: 4px 4px 4px 4px;
            position: absolute;
            width: 250px;
            bottom: 0;
            right:0;
            font-size:14px;
            }

         .auto-style1 {
            color: #FF0000;
        }

        .dt-button{
              background: #004b96 none repeat scroll 0 0;
                border-radius: 5px;
                color: #fff;
                margin-left: 5px;
                padding: 10px;
        }

        .textos2 {
            font-size: 17px;
            font-weight: bold;
            letter-spacing: 0.5px;
        }

        .cajausuario {
            background-color: #e6e6e6;
            border: 1px solid #d5d5d5;
            border-radius: 5px;
            -moz-border-radius: 5px;
            padding: 3px;
            border-spacing: 5px;
            margin: 2px auto 8px;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
        }

                .border th {
            background: #507cd1;
            color: #fff;
            font-size: 15px;
            padding: 10px;
        }
        .center{
            text-align:center;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
        }
        table.border{
            border-collapse: separate;
            border-spacing: 0;

        }
        table.border td{
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;

        }
         table.border th {
            border: 0px solid;
            margin: 0;
            padding: 10px;
        }
         table.border td,  .border th{
            /*border: 1px solid;*/
            margin: 0;
            padding: 10px !important;
            border-right: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
        }
          table.border td:last-child{
            /*border-right: 0;*/

          }

         
        table.border tr, table.border {
            margin: 0;
            padding: 0;
            /*border: 1px solid #ccc;*/
            background: #fff;
        }

        .width-100 {
            width: 100%;
        }
 
    </style>

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>

    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false" ></asp:Label>

 <br /><br />
    <h2>Productos</h2>
    <div id="listado" >
         
         <fieldset>

         <legend>ÍNDICE</legend>
     
      
             <table width="50%" class="border" id="tableList">
                 <thead>
		            <tr>
                        <th ></th>
		                <th >Meta</th>
                        <th>Ejecución</th>
                        <th>%</th>
		                <th class="noExl">Detalles</th>
		            </tr>
                </thead>
                 <tbody>

                 </tbody>
	        </table>

    </fieldset>

     </div>

   

     <!--sedesconectadas-->
<div id="seconectadas" style="display:none;">
     <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Sedes conectadas</span>
        <a href="menusegproducto.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;float:right" >Regresar</a>
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
        <a href="menusegproducto.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;float:right" >Regresar</a>
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
    <!-- Ferias -->
    <div id="ferias" style="display:none;">

    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Ferias </span>
        <a href="menusegproducto.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;float:right" >Regresar</a>
    </div>
    <br />
  
        <table id="tblferias" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Departamento</th>
                    <th>Nombre feria</th>
                    <th>Fecha elaboración</th>
                    <th>Hora inicio</th>
                    <th>Hora fin</th>
                    <th>No. Grupos</th>
                    <th>Asistentes</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="8" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  

</div><!-- end>-->
    <!-- Grupos  -->
    <div id="gijuveniles" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Grupos infantiles y juveniles </span>
        <a href="menusegproducto.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;float:right" >Regresar</a>
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

    <!-- Redes  -->
    <div id="redes" style="display:none;">
    <div style="margin-top:10px;">
        <span class="h2" style="width:400px;">Redes temáticas </span>
        <a href="menusegproducto.aspx" class="btn btn-primary pull-right" style="padding: 3px 12px;float:right" >Regresar</a>
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
             
               <td style="padding: 0 10px;">Red temática:</td>
               <td>
                    <select class="TextBox" name="redest" id="redest"  style="width:300px;">
                    </select>
                </td>

                 <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-primary" style="padding: 3px 12px;" onclick="cargarRedesTematicas();">Buscar</a>
                </td>
                <td style="padding-left: 10px;">
                    <a href="javascript:void(0);" class="btn btn-success" style="padding: 3px 12px;" onclick="exportarExcel('tblredestematicas','RedesTematicas')">Excel</a>
                </td>
            </tr>
        </table>
     </fieldset>
    <br />
        <table id="tblredestematicas" class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Municipio</th>
                    <th>Institución educativa</th>
                    <th>Nombre sede educativa</th>
                    <th>Dane</th>
                    <th>Nombre red temática</th>	
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="8" style="padding:15px;"><center>Presione el boton buscar para generar resultados</center></td>
                </tr>
            </tbody>
         </table>  
</div><!-- end -->

</asp:Content>

