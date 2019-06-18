<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estrag001reportes.aspx.cs" Inherits="estrag001reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script src="js/jquery.timepicker.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="Styles/jquery.timepicker.css"/>
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
        $(function () {
            listarcontrolasistencia();

            

            //$("#asesor").on("change", function () {
            //    listarcontrolasistencia($("#asesor").val());
            //    console.log($("#asesor").val());
            //})
        });

        //function cargarAsesores() {
        //    $.ajax({
        //        url: 'estrag001reportes.aspx/cargarAsesores',
        //        type: 'POST',
        //        contentType: 'application/json; charset=utf-8',
        //        dataType: 'JSON',
        //        success: function (response) {
        //            if (response.d != null) {
        //                $("#asesor").html(response.d);
        //            }
        //        }
        //    });
        //}

        function listarcontrolasistencia() {
            //console.log(codasesor);
            //var datajson = "{'codasesor':'" + codasesor + "'}";
            $.ajax({
                url: 'estrag001reportes.aspx/listarcontrolasistencia',
                type: 'POST',
                //data: datajson,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    if (response.d != null) {
                        $("#tableinfo").html(response.d);
                    }
                }
            });
        }

        function detalles(codigo) {
            var datajson = "{'codigo':'" + codigo + "'}";
            $.ajax({
                url: 'estrag001reportes.aspx/detalledocentesasistentes',
                type: 'POST',
                data: datajson,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    if (response.d != null) {
                        $("#infodoc").html(response.d);
                        $("#dialog-docente").dialog({
                            resizable: false,
                            height: "auto",
                            width: "auto",
                            modal: true
                        });
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
    <h2 >Estrategía Nro 2 - Instrumento G001 Reporte Asistencia Docentes</h2><br />
    <div style="float:right;">
        <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
    </div>
    <fieldset>
        <legend>Formato control de asistencia</legend>
        <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
           <%-- <tr>
                <td>Nombre asesor</td>
                <td><select id="asesor" class="TextBox"></select></td>
            </tr>--%>
        </table>
        <fieldset>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>Institución</th>
                        <th>Sede</th>
                        <th>Tipo de actividad</th>
                        <th>Tema</th>
                        <th>Facilitador</th>
                        <th>Hora inicio - fin</th>
                        <th>Fecha</th>
                        <th>Momento</th>
                        <th>Sesión</th>
                        <th>Jornada</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="tableinfo">                </tbody>
            </table>
        </fieldset>
    </fieldset>
    <div id="dialog-docente" title="Docentes asistentes" style="display:none">
       <fieldset>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Docente</th>
                    </tr>
                </thead>
                <tbody id="infodoc"></tbody>
            </table>
        </fieldset>
    </div>
    <br />
    <center>
        <%--<input type="button" class="btn btn-success" value="Guardar" onclick="btnGuardar_Click();" />--%>
        <%--<asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
        <asp:Button runat="server" ID="btnSubirFirmaPop" Text="Cargar Evidencias" CssClass="btn btn-danger" OnClick="cargarEvidencias_Click" />--%>
    </center>
</asp:Content>

