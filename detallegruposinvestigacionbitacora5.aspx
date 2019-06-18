<%@ Page Title="Grupos de investigación con bitacora 5 " Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="detallesedesgpbitacora4.aspx.cs" Inherits="detallesedesgpbitacora4" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

      <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <script src="js/dataTables.buttons.min.js"></script>
    <script src="js/jszip.min.js"></script>
   <script src="js/buttons.html5.min.js"></script>

    <style type="text/css">
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
         table.border th {
            /*border: 1px solid;*/
            margin: 0;
            padding: 0;
        }
         table.border td,  .border th{
            /*border: 1px solid;*/
            margin: 0;
            padding: 5px;
            border-right: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
        }
          table.border td:last-child{
            border-right: 0;

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

     <script type="text/javascript">

         (function ($) {
             $.get = function (key) {
                 key = key.replace(/[\[]/, '\\[');
                 key = key.replace(/[\]]/, '\\]');
                 var pattern = "[\\?&]" + key + "=([^&#]*)";
                 var regex = new RegExp(pattern);
                 var url = unescape(window.location.href);
                 var results = regex.exec(url);
                 if (results === null) {
                     return null;
                 } else {
                     return results[1];
                 }
             }
         })(jQuery);

        $(document).ready(function () {
            floadDetalles();

            //Cargar departamento
            $.ajax({
                type: 'POST',
                url: 'detallesedesgpbitacora4.aspx/cargarDepartamentoMagdalena',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "departamento") {
                        $("#departamento").html(resp[1]);
                    }
                }, complete: function(){
                    $("#institucion").html("");
                    $("#sede").html("");
                    $("#municipio").html("");
                    var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                    $.ajax({
                        type: 'POST',
                        url: 'detallesedesgpbitacora4.aspx/cargarMunicipios',
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
                $("#sede").html("");
                $("#municipio").html("");
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'detallesedesgpbitacora4.aspx/cargarMunicipios',
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
                    url: 'detallesedesgpbitacora4.aspx/cargarInstituciones',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //data:frmserialize,
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
            $("#institucion").on("change", function () {
                $("#sede").html("");
                var codInstitucion = $("#institucion").val();
                var jsondata = "{'codInstitucion':'" + codInstitucion + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'detallesdesarrollo.aspx/cargarSedesxInstitucion',
                    data: jsondata,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "sede") {
                            $("#sede").html(resp[1]);
                        }
                    }
                });
            });
        });

        function cargarDataTable() {
            $('#tableList').DataTable({
                "language": {
                    "url": "dataTables.spanish.lang",
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "NingÃºn dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Ãšltimo",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
                dom: 'Bfrtip',
                buttons: [
                    'excel'
                    // 'copy', 'csv', 'excel', 'pdf'
                ]
            });

        }

        function floadDetalles() {
            $("#tableList tbody").html("<tr><td colspan=\"6\" style=\"text-align:center;\">Cargando...</td></tr>");
            $.ajax({
                type: 'POST',
                url: 'detallesedesgpbitacora4.aspx/gruposInvestigacionBitacora5',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "lleno") {
                        $("#tableList tbody").html(resp[1]);
                    } else {
                        $("#tableList tbody").html(response.d);
                    }
                }, complete: function () {
                    cargarDataTable();
                }
            });
        }

        // realizar busqueda
        function filtro() {
            var table = $('#tableList').DataTable();
            table.destroy();
            $("#tableList tbody").html("<tr><td colspan=\"6\" style=\"text-align:center;\">Cargando...</td></tr>");
            var codDepartamento = $("#departamento").val();
            var codMunicipio = $("#municipio").val();
            var codInstitucion = $("#institucion").val();
            var codSede = $("#sede").val();
            var codGrupoInvestigacion = $("#grupoinvestigacion").val();
            var jsondata = "{'coddepartamento':'" + codDepartamento + "', 'codmuncipio':'" + codMunicipio + "', 'codinstitucion':'" + codInstitucion + "', 'codsede':'" + codSede + "', 'codgrupoinvestigacion':'" + codGrupoInvestigacion + "'}";
            $.ajax({
                type: 'POST',
                url: 'detallesedesgpbitacora4.aspx/realizarBusquedagruposInvestigacionBitacora5',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "lleno") {
                        $("#tableList tbody").html(resp[1]);
                    } else {
                        $("#tableList tbody").html(json.d);
                    }
                }, complete: function () {
                    cargarDataTable();
                }
            });
        }

        function btnregresar() {
            if ($.get("sg") === "true") {
                window.location.href = "menusegestrategia1.aspx";
            }
            else {
                window.location.href = "grupostrayectoriaindagacion.aspx";
            }
        }

        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <asp:Label Visible="false" runat="server" ID="lblCodUsuario"></asp:Label>

    <div id="mensaje" runat="server"></div><br /><br />
    <h2 >Los grupos de investigación que elaboran el presupuesto </h2>
    <div style="float:right;margin-top:-30px;">
        <a onclick="btnregresar()" class="btn btn-primary">Regresar</a>
        <%--<asp:Button runat="server"  ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" />--%>   
    </div>
    <h4 >Total grupos de investigación infantiles y juveniles con trayectorias de indagación diseñadas</h4>
    <p>Mide la cantidad de grupos de investigación infantiles y juveniles que diligencian la bitácora 05 de trayectorías de indagación  y la han cargado en la plataforma de Ciclón </p>
    
    <br />
 <fieldset>
     <legend>Realizar Busqueda</legend>
     <table>
            <tr>
                <td>Departamento: </td>
                <td>Municipio: </td>
                <td>Institución Educativa: </td>
                <td>Sede Educativa: </td>
            </tr>
            <tr>
                <td>
                    <select class="TextBox width-100" name="departamento" id="departamento" style="width: 220px" disabled="true">
                    </select>
                </td>
                <td>
                    <select class="TextBox width-100" name="municipio" id="municipio" style="width: 220px">
                    </select>
                </td>
                <td>
                    <select class="TextBox width-100" name="institucion" id="institucion" style="width: 220px">
                    </select>
                </td>
                 <td>
                    <select class="TextBox width-100" name="sede" id="sede" style="width: 220px">
                    </select>
                </td>
                <td><input type="button" value="Buscar..." class="btn btn-primary" id="btn-guardar" onclick="filtro();" /></td>
            </tr>
        </table>
 </fieldset>
 <fieldset>
     <legend>Listado de evidencias</legend>
     <b>Exportar a:</b><br /><br />
     <table width="100%" class="border" id="tableList">
         <thead>
		    <tr>
		        <th>No.</th>
                <th>Departamento</th>
                <th>Municipio</th>
                <th>Institución Educativa</th>
		        <th>Sede Educativa</th>
                <th>Grupo Investigación</th>
		    </tr>
        </thead>
         <tbody>
             <tr>
                 <td colspan="6" style="text-align:center;">Sin resultados</td>
             </tr>
         </tbody>
	</table>
      
 </fieldset>
    

</asp:Content>

