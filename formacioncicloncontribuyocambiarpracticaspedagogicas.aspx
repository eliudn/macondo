<%@ Page Title="La formación en Ciclón contribuyó a cambiar sus prácticas pedagógicas" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="formacioncicloncontribuyocambiarpracticaspedagogicas.aspx.cs" Inherits="formacioncicloncontribuyocambiarpracticaspedagogicas" MaintainScrollPositionOnPostback="true" %>

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

          

var Url = {
 

    // public method for url encoding

    encode : function (string) {

        return escape(this._utf8_encode(string));

    },
 

    // public method for url decoding

    decode : function (string) {

        return this._utf8_decode(unescape(string));

    },
 

    // private method for UTF-8 encoding

    _utf8_encode : function (string) {

        string = string.replace(/\r\n/g,"\n");

        var utftext = "";
 

        for (var n = 0; n < string.length; n++) {
 

            var c = string.charCodeAt(n);
 

            if (c < 128) {

                utftext += String.fromCharCode(c);

            }

            else if((c > 127) && (c < 2048)) {

                utftext += String.fromCharCode((c >> 6) | 192);

                utftext += String.fromCharCode((c & 63) | 128);

            }

            else {

                utftext += String.fromCharCode((c >> 12) | 224);

                utftext += String.fromCharCode(((c >> 6) & 63) | 128);

                utftext += String.fromCharCode((c & 63) | 128);

            }
 

        }
 

        return utftext;

    },
 

    // private method for UTF-8 decoding

    _utf8_decode : function (utftext) {

        var string = "";

        var i = 0;

        var c = c1 = c2 = 0;
 

        while ( i < utftext.length ) {
 

            c = utftext.charCodeAt(i);
 

            if (c < 128) {

                string += String.fromCharCode(c);

                i++;

            }

            else if((c > 191) && (c < 224)) {

                c2 = utftext.charCodeAt(i+1);

                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));

                i += 2;

            }

            else {

                c2 = utftext.charCodeAt(i+1);

                c3 = utftext.charCodeAt(i+2);

                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));

                i += 3;

            }
 

        }
 

        return string;

    }
 
         }


         $(document).ready(function () {

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
             console.log();
             
             $("#respuesta").val(Url._utf8_decode($.get('resp')));


            floadDetalles();

            //Cargar departamento
            $.ajax({
                type: 'POST',
                url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/cargarDepartamentoMagdalena',
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
                        url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/cargarMunicipios',
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
                $("#municipio").html("");
                $("#sede").html("");
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/cargarMunicipios',
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
                    url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/cargarInstituciones',
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
                var codInstitucion = $("#institucion").val();
                var jsondata = "{'codInstitucion':'" + codInstitucion + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/cargarSedesxInstitucion',
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
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
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
            $("#tableList tbody").html('<td colspan="7" style="text-align:center;">Cargando...</td>');
            var respuesta = $("#respuesta").val();
            var jsondata = "{'respuesta' : '"+respuesta+"'}";
            $.ajax({
                type: 'POST',
                url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/formacioncicloncontribuyocambiarpracticaspedagogicas_',
                data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "lleno") {
                        $("#tableList tbody").html(resp[1]);
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
            $("#tableList tbody").html("<tr><td colspan=\"7\" style=\"text-align:center;\">Cargando...</td></tr>");
            var codDepartamento = $("#departamento").val();
            var codMunicipio = $("#municipio").val();
            var codInstitucion = $("#institucion").val();
            var codSede = $("#sede").val();
            var respuesta = $("#respuesta").val();
            var jsondata = "{'coddepartamento':'" + codDepartamento + "', 'codmunicipio':'" + codMunicipio + "', 'codinstitucion':'" + codInstitucion + "', 'codsede':'" + codSede + "', 'respuesta' : '"+respuesta+"'}";
            $.ajax({
                type: 'POST',
                url: 'formacioncicloncontribuyocambiarpracticaspedagogicas.aspx/realizarBusquedaformacioncicloncontribuyocambiarpracticaspedagogicas_',
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

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <asp:Label Visible="false" runat="server" ID="lblCodUsuario"></asp:Label>
    <asp:Label Visible="false" runat="server" ID="lblSesion"></asp:Label>

    <div id="mensaje" runat="server"></div><br /><br />
    <h2 style="width:80%;display:block;"><asp:Label Visible="true" runat="server" ID="titulo"></asp:Label></h2>
    <div style="float:right;margin-top:-30px;"><asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" /></div>
    <h4 ><asp:Label Visible="true" runat="server" ID="subtitulo"></asp:Label>  </h4>
    <p><asp:Label Visible="true" runat="server" ID="descripcion"></asp:Label> <br /></p>    
    <br />

    <fieldset>
         <legend>Realizar Busqueda</legend>
         <table>
                <tr>
                    <td>Departamento: </td>
                    <td>Municipio: </td>
                    <td>Institución Educativa: </td>
                </tr>
                
                <tr>
                    <td>
                        <select class="TextBox width-100" name="departamento" id="departamento" style="width: 200px" disabled="true">
                        </select>
                    </td>
                    <td>
                        <select class="TextBox width-100" name="municipio" id="municipio" style="width: 200px">
                        </select>
                    </td>
                    <td>
                        <select class="TextBox width-100" name="institucion" id="institucion" style="width: 250px">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Sede Educativa: </td>
                    <td>Participación: </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <select class="TextBox width-100" name="sede" id="sede" style="width: 250px">
                        </select>
                    </td>
                    <td>
                        <select class="TextBox width-100" name="respuesta" id="respuesta" style="width: 250px">
                            <option value="si">Si</option>
                            <option value="no">No</option>
                        </select>
                    </td>
                    <td><input type="button" value="Buscar..." class="btn btn-primary" id="btn-guardar" onclick="filtro();" /></td>
                </tr>
            </table>
     </fieldset>
 <fieldset>
     <legend>Listado de evidencias</legend>

     <b>Exportar a:</b><br />
     <br />

     <table width="100%" class="border" id="tableList">
         <thead>
		    <tr>
		        <th>No.</th>
                <th>Departamento</th>
                <th>Municipio</th>
                <th>Institución Educativa</th>
		        <th>Sede Educativa</th>
                <th>Docente</th>
		    </tr>
        </thead>
         <tbody>
             <tr>
                 <td colspan="7" style="text-align:center;">Sin resultados</td>
             </tr>
         </tbody>
	</table>
      
 </fieldset>
    

</asp:Content>

