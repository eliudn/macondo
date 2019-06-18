<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estulistadopag.aspx.cs" Inherits="estulistadopag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
    <link rel="stylesheet" href="css/paginacion.css">
   
      <script type="text/javascript">
          cargarListadoEstudiantes("1", "100");

          function cargarListadoEstudiantes(page, rows) {
              $("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
              var jsondata = "{'page':'" + page + "','rows':'" + rows + "'}";

              $.ajax({
                  type: 'POST',
                  url: 'estulistadopag.aspx/cargarListadoEstudiantes',
                  data: jsondata,
                  contentType: 'application/json; charset=utf-8',
                  dataType: 'JSON',
                  success: function (response) {

                      var resp = response.d.split("&");

                      //alert(resp[0]);

                      $("#infoListTable").html(resp[0]);
                      $("#paginacion").html(resp[1]);
                  }
              });
          }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div>
    <br /><br />
    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Lista de Estudiantes</h2>
        </div>
        <div style="float: right;">
            <%--    <a href="estureg.aspx" class="btn btn-primary">Nuevo Estudiante</a>
            <a href="estumatricula.aspx" class="btn btn-primary">Matricular Estudiante</a>--%>
        </div>
    </div>
    <br /><br /><br />
    <fieldset>
        <legend>Listado básico de Estudiantes registrados en el sistema.</legend>
                <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Tipo Doc.</th>
                        <th>Identificación</th>
                        <th>Apellido</th>
                        <th>Nombre</th>
                        <th>Género</th>
                        <th>Fecha Nac.</th>
                        <th>Teléfono</th>
                        <th>Dirección</th>
                        <th>Email</th>
                        <th>Etnía</th>
                    </tr>
                </thead>
                <tbody id="infoListTable">

                </tbody>
            </table>
            <div id="paginacion" class="pagination">
            </div>
        </fieldset>

</asp:Content>

