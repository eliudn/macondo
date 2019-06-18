<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="asesorgruposinvestigacion.aspx.cs" Inherits="asesorgruposinvestigacion" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <script src="js/jquery.table2excel.js"></script>

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
                border: none;
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


         $(document).ready(function () {

             floadReport();

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

        });

        

        function cargarDataTable() {
            $('#GridEvidencias').DataTable({
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
                }
            });

        }

        function floadReport() {
            $("#tableList tbody").html('<td colspan="4" style="text-align:center;">Cargando...</td>');
            $.ajax({
                type: 'POST',
                url: 'asesorgruposinvestigacion.aspx/loadReport',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d;
                    $("#tableList tbody").html(resp);
                }, complete: function () {
                    
                }
            });
        }

        function exportExcel() {
            /*var index = this.cellIndex;
            $(this).closest('table').find('tr').each(function () {
                this.removeChild(this.cells[index]);
            });*/

            $("#tableList").table2excel({
                exclude: ".noExl",
                name: "asesorgruposinvestigacion",
                filename: "asesorgruposinvestigacion",
                fileext: ".xls"//,
                //exclude_img: true,
                //exclude_links: true,
                //exclude_inputs: true
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <asp:Label Visible="false" runat="server" ID="lblCodUsuario"></asp:Label>

    <div id="mensaje" runat="server"></div><br /><br />
    <h2>El asesor acompaña a los grupos de investigación a elaborar el presupuesto y desarrollar la etapa 4 Diseño de las trayectorías de indagación</h2>
    <div style="float:right;margin-top:-30px;"><asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" /></div>
    <br />

    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMomento" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblSesion" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblActividad" runat="server" Visible="False"></asp:Label>
 <fieldset>

      <b>Exportar a:</b><br />
     <input type="button" value="Excel" class="dt-button" id="btn-exportExcel" onclick="exportExcel();" /><br />
     <br />

     <legend>Listado de evidencias</legend>
     <table width="100%" class="border" id="tableList">
         <thead>
		    <tr>
		        <th>Nombre actividad</th>
		        <th>Cantidad</th>
                <th>Porcentaje</th>
		        <th class="noExl">Detalles</th>
		    </tr>
        </thead>
         <tbody>
             <tr>
                 <td colspan="4" style="text-align:center;">Sin resultados</td>
             </tr>

         </tbody>
	</table>
 </fieldset>
    

</asp:Content>

