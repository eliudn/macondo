<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="configrupoinvestigacion.aspx.cs" Inherits="configrupoinvestigacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function imprSelec(muestra) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            ventimp.print();
            ventimp.close();
        }
    </script>
    <style type="text/css">
        .cuadroEncabezado {
            display: none;
        }

        .impresionInfo {
            display: none;
        }
    </style>

    
    <!-- Para el ModalPopup del editar estudiante -->
  <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"  rel="stylesheet" type="text/css" />--%>
<%--<link href="Style/GeneralModalsPopup.css"  rel="stylesheet" type="text/css" />--%>

     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

    <script type="text/javascript">

        function btnEntrar_click() {
            
            var jsonData = '{ "txtIDEstudianteNuevo":"' + $("#MainContent_txtIDEstudianteNuevo").val() + '", "txtNomEstudianteNuevo": "' + $("#MainContent_txtNomEstudianteNuevo").val() + '", "txtNomApellidoNuevo": "' + $("#MainContent_txtNomApellidoNuevo").val() + '", "dropsexo": "' + $("#MainContent_dropSexo").val() + '", "txtFechaNacimiento": "' + $("#MainContent_txtFechaNacimiento").val() + '", "txtTelefonoNuevo": "' + $("#MainContent_txtTelefonoNuevo").val() + '", "txtDireccionNuevo": "' + $("#MainContent_txtDireccionNuevo").val() + '", "txtemailNuevo": "' + $("#MainContent_txtemailNuevo").val() + '" }';
            //alert(jsonData);
            $.ajax({
                type: "POST",
                url: "configrupoinvestigacion.aspx/agregarEstudiante",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "true") {
                        alert('Datos ingresados correctamente');
                        $("#dialog-formadd").dialog("close");
                    }
                    else if (resp[0] === "errorMatricula") {
                        alert('Error al relacionar estudiante con matricula.');
                    }
                    else if (resp[0] === "errorSeleccion") {
                        alert('Debe Seleccionar la Sede y el Grado');
                    }
                    else {
                        alert('Error al guardar estudiante.');
                    }
                }
            });
        }

        function btnEditar_click() {

            var jsonData = '{ "txtIDEstudianteNuevo":"' + $("#MainContent_txtIDestudiante").val() + '", "txtNomEstudianteNuevo": "' + $("#MainContent_txtNomEstudiante").val() + '", "txtNomApellidoNuevo": "' + $("#MainContent_txtApellidoEstudiante").val() + '", "dropsexo": "' + $("#MainContent_dropGenero").val() + '", "txtFechaNacimiento": "' + $("#MainContent_txtFechaIni").val() + '", "txtTelefonoNuevo": "' + $("#MainContent_txtTelefono").val() + '", "txtDireccionNuevo": "' + $("#MainContent_txtDireccion").val() + '", "txtemailNuevo": "' + $("#MainContent_txtEmail").val() + '" }';
            //alert(jsonData);
            $.ajax({
                type: "POST",
                url: "confiredtematica.aspx/actualizarEstudiante",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "true") {
                        alert('Datos editados correctamente');
                        $("#dialog-form").dialog("close");
                    }
                   
                    else {
                        alert('Error al editar estudiante.');
                    }
                }
            });
        }

        function btnMoverDocente_click() {

            var jsonData = '{ "dropsede":"' + $("#MainContent_dropSedeMover").val() + ', "dropanio":"' + $("#MainContent_dropAnio").val() + '"}';
            //alert(jsonData);
            $.ajax({
                type: "POST",
                url: "confiredtematica.aspx/moverDocente",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("@");
                    if (resp[0] === "true") {
                        alert('Docente trasladado correctamente');
                        $("#dialog-formmover").dialog("close");
                    }

                    else {
                        alert('Error al mover docente.');
                    }
                }
            });
        }

    </script>


    <script type="text/javascript">

        function doSearch(val, table) {
            var tableReg = document.getElementById("" + table);
            var searchText = $("#" + val).val().toLowerCase();
            for (var i = 1; i < tableReg.rows.length; i++) {
                var cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
                var found = false;
                for (var j = 0; j < cellsOfRow.length && !found; j++) {
                    var compareWith = cellsOfRow[j].innerHTML.toLowerCase();
                    if (searchText.length === 0 || (compareWith.indexOf(searchText) > -1)) {
                        found = true;
                    }
                }
                if (found) {
                    tableReg.rows[i].style.display = '';
                } else {
                    tableReg.rows[i].style.display = 'none';
                }
            }
        }

    </script>

     <%-- <script language="javascript" type="text/javascript">

          $().ready(function () {

              $(document).everyTime(3000, function () {

                  $.ajax({
                      type: "POST",
                      url: "bienvenida.aspx/KeepActiveSession",
                      data: {},
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      async: true,
                      success: VerifySessionState,
                      error: function (XMLHttpRequest, textStatus, errorThrown) {
                          alert("Su sesión ha expirado por interrupción en su conexión a Internet, por favor inicie sesión nuevamente.");
                          //alert(textStatus + ": " + XMLHttpRequest.responseText);
                      }
                  });

              });


          });

          var cantValidaciones = 0;

          function VerifySessionState(result) {

              if (result.d) {
                  $("#EstadoSession").text("activo");
              }
              else
                  $("#EstadoSession").text("expiro");

              $("#cantValidaciones").text(cantValidaciones);
              cantValidaciones++;

          }

    </script>--%>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div><br /><br />
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
    <div class="header">
        <div style="float: left;margin-right: 15px;">
            <h2>Conformación de los Grupos de Investigación</h2>
        </div>

        <div style="float: right;margin-top:20px;">
              <asp:LinkButton runat="server" ID="btnAgregarNuevoEstudiante" Text="Nuevo Estudiante" Visible="false" CssClass="btn btn-success" OnClick="btnAgregarNuevoEstudiante_Click" />
			  <a class="btn btn-danger" href="Documentos/Conformacion_Grupos_De_Investigacion.pdf" target="_blank">Instructivo Grupos de investigacíon</a>
            <asp:LinkButton runat="server" ID="lnkVerGruposInvestigacion" CssClass="btn btn-primary" OnClick="lnkVerGruposInvestigacion_Click">Crear Grupo de Investigación</asp:LinkButton>
            <asp:LinkButton runat="server" ID="lnkVolver" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolver_Click">Volver</asp:LinkButton>
            <asp:LinkButton runat="server" ID="lnkVolverEditarDatosEstudiante" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverEditarDatosEstudiante_Click">Volver</asp:LinkButton>
            <asp:LinkButton runat="server" ID="lnkVolverMoverDocente" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverMoverDocente_Click">Volver</asp:LinkButton>
        </div>
    </div>
       <br /><br /><br />

       <div id="conformar" style="display:none">
    <fieldset>
        <legend>Datos institucionales</legend>

       
                 <table>
                       <tr>
                           <td>Año</td>
              <td>
                   <asp:UpdatePanel runat="server" ID="UpdatePanel13" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"  ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropAnio" runat="server" ErrorMessage="Seleccione el Año"
                                        Text="*" Display="None" ControlToValidate="dropAnio" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RFVdropAnio"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
              </td>
          </tr>
                      <tr>
              <td>Departamento</td>
               <td>
                             <asp:UpdatePanel runat="server" ID="UpdatePanel11" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropDepartamento" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropDepartamento_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropDepartamento" runat="server" ErrorMessage="Seleccione el departamento"
                                        Text="*" Display="None" ControlToValidate="dropDepartamento" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropDepartamento"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                         <td>Municipio:</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropMunicipio" CssClass="TextBox" UpdateMode="Conditional" AutoPostBack="true" OnSelectedIndexChanged="dropMunicipio_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Seleccione el municipio"
                                        Text="*" Display="None" ControlToValidate="dropMunicipio" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropDepartamento" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>

                         </td>
                     </tr>
                     <tr>
                        <td>Institución:</td>
                        <td>
                             <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropInstituciones" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropInstituciones_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropInstituciones" runat="server" ErrorMessage="Seleccione la institución"
                                        Text="*" Display="None" ControlToValidate="dropInstituciones" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVdropInstituciones"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                 </ContentTemplate>
                                  <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropMunicipio" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                     <tr>
                         <td>Sede:</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropSedes" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropSedes" runat="server" ErrorMessage="Seleccione la sede"
                                        Text="*" Display="None" ControlToValidate="dropSedes" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropSedes"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropInstituciones" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>

                         </td>
                     </tr>
                     <tr>
                         <td>Grados:</td>
                         <td>
                             <asp:DropDownList runat="server" ID="DropGrados" CssClass="TextBox" ></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RFVDropGrados" runat="server" ErrorMessage="Seleccione el grado"
                                        Text="*" Display="None" ControlToValidate="DropGrados" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVDropGrados"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                         </td>
                     </tr>
                      <tr>
                         <td>Grupo</td>
                         <td>
                              <asp:DropDownList runat="server" ID="dropGrupo" CssClass="TextBox" >
                                  <asp:ListItem>Seleccione</asp:ListItem>
                                  <asp:ListItem>1</asp:ListItem>
                                  <asp:ListItem>2</asp:ListItem>
                                  <asp:ListItem>3</asp:ListItem>
                                  <asp:ListItem>4</asp:ListItem>
                                  <asp:ListItem>5</asp:ListItem>
                              </asp:DropDownList>
                               <%--<asp:RequiredFieldValidator ID="RFVdropGrupo" runat="server" ErrorMessage="Seleccione el grupo"
                                        Text="*" Display="None" ControlToValidate="dropGrupo" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" Enabled="True" TargetControlID="RFVdropGrupo"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>--%>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <asp:Button runat="server" ID="btnBuscar" ValidationGroup="Buscar" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Onclick" />
                         </td>
                     </tr>
                </table>
    </fieldset>

             <fieldset>
        <legend>Filtro de datos</legend>
        <table align="center">
            <tr>
                <td>
                    Filtrar estudiante:
                    <input id="buscarEstudiante" class="TextBox" placeholder="Buscar estudiante..." type="text" onkeyup="doSearch('buscarEstudiante','GridEstudiante')">
                </td>
                <td>
                    Filtrar docente:
                      <input id="buscarDocente" class="TextBox" placeholder="Buscar docente..." type="text" onkeyup="doSearch('buscarDocente','GridDocentes')">
                </td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
         <legend>Selección de personal</legend>  
       <table>
           <tr>
               <td><center>
                    <fieldset>
        <legend>Estudiantes por grados</legend>

         <asp:GridView ID="GridEstudiante" runat="server" CellPadding="4" DataKeyNames="codestumatricula" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  AutoGenerateColumns="false" Style="margin: 0 auto" 
                        GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="codestudiante" HeaderText="codestudiante" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="identificacion" HeaderText="Identificación">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="nomgrado" HeaderText="Grado">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                           
                             <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:ImageButton ID="btnEditarEstudiante" runat="server" ImageUrl='~/Imagenes/edit.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnEditarEstudiante_Click" />
                                   <%--<asp:ImageButton runat="server" ID="btnEditarEstudiante" ImageUrl="~/Imagenes/edit.png" Width="20" OnClick="btnEditarEstudiante_Click" />--%>
                                </ItemTemplate>
                             </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListEstudiante" Checked="true" />
                                </ItemTemplate>
                             </asp:TemplateField>
                              
                         <%--   <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
                                 </ItemTemplate>
                            </asp:TemplateField>--%>
                           
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
        <table align="center"><tr><td>
           <asp:Button runat="server" ID="btnSeleccionarEstudiantes" Visible="false" CssClass="btn btn-danger" Text="Seleccionar estudiantes" OnClick="btnSeleccionarEstudiantes_Click" />
                  </td></tr></table>
    </fieldset>
            </center>
               </td>
               <td>
                    <fieldset>
        <legend>Docentes por Sede</legend>

         <asp:GridView ID="GridDocentes" runat="server" CellPadding="4" DataKeyNames="codgradodocente" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  AutoGenerateColumns="false" Style="margin: 0 auto" 
                        GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="codgradodocente" HeaderText="codgradodocente" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="identificacion" HeaderText="Identificación">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nomdocente"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListDocente" />
                                </ItemTemplate>
                             </asp:TemplateField>

                             <%-- <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:ImageButton ID="btnEditarDocente" runat="server" ImageUrl='~/Imagenes/edit.png' Width="20px" Height="20px" Style="cursor: pointer"  />
                                </ItemTemplate>
                             </asp:TemplateField>--%>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkMoverDocente" ToolTip="Mover Docente a otra sede"  OnClick="lnkMoverDocente_Click"><img src="Imagenes/mover.png" width="20" Style="cursor: pointer" /></asp:LinkButton>
                                <%--<asp:ImageButton ID="btnMoverDocente" ToolTip="Mover Docente a otra sede" runat="server" ImageUrl='~/Imagenes/mover.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnMoverDocente_Click"  />--%>
                                 </ItemTemplate>
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
                    <table align="center"><tr><td>
                       <asp:Button runat="server" ID="btnSeleccionarDocente" Visible="false" CssClass="btn btn-danger" Text="Seleccionar Docente" OnClick="btnSeleccionarDocente_Click" />
                              </td></tr></table>
    </fieldset>
               </td>
           </tr>
       </table>
 </fieldset>
   
       

      
           <asp:Panel runat="server" ID="PanelLineaIngestigacion" Visible="false">
                <table align="center">
                    <tr>
                        <td>Nombre del Grupo de Investigación</td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtNomGrupoInvestigacion" CssClass="TextBox" Width="800" ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RFVtxtNomGrupoInvestigacion" runat="server" ErrorMessage="Digite el nombre del Grupo Ingestigación"
                                        Text="*" Display="None" ControlToValidate="txtNomGrupoInvestigacion" 
                                        ValidationGroup="addestudiantes"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVtxtNomGrupoInvestigacion"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                    <td>Tipo de Proyecto</td>
                    <td>
                        <asp:DropDownList runat="server" ID="dropLineaIngestigacion" CssClass="TextBox"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RFVdropLineaIngestigacion" runat="server" ErrorMessage="Seleccione Tipo de Proyecto"
                                        Text="*" Display="None" ControlToValidate="dropLineaIngestigacion" InitialValue="Seleccione"
                                        ValidationGroup="addestudiantes"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVdropLineaIngestigacion"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                    </td>
                     <td>Línea de Investigación</td>
                    <td>
                        <asp:DropDownList runat="server" ID="dropArea" CssClass="TextBox"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RFVdropArea" runat="server" ErrorMessage="Seleccione Línea de Ingestigación"
                                        Text="*" Display="None" ControlToValidate="dropArea" InitialValue="Seleccione"
                                        ValidationGroup="addestudiantes"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVdropArea"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                    </td>
                       </tr></table>
            </asp:Panel>

        <fieldset>
         <legend>Personal para el Grupo de Investigación</legend>  
            <table align="center">
                <tr>
                    <td>
                          <fieldset>
                             <legend>Estudiantes cargados para el Grupo de Investigación</legend>  
                              <asp:GridView ID="GridSeleccionEstudiantes" runat="server" CellPadding="4" AutoGenerateColumns="false" style="margin:0 auto; width:100%"
                                ForeColor="#333333" GridLines="None" 
                                onrowdatabound="GridSeleccionEstudiantes_RowDataBound" 
                                onrowdeleting="GridSeleccionEstudiantes_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="codestumatricula" HeaderText="Cod. Matricula" ><ItemStyle  HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="identificacion" HeaderText="ID Estudiante" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre Estudiante" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                                    <asp:BoundField DataField="grado" HeaderText="Grado" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>               
                   
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png"><ItemStyle Width="20px" /></asp:CommandField>        
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
                             <table align="center"><tr><td>
                                    <asp:Button runat="server" ID="btnDeseleccionarEstudiantes" Visible="false" CssClass="btn btn-danger" Text="Borrar lista" OnClick="btnDeseleccionarEstudiantes_Click" />
                                  </td></tr></table>
                            </fieldset>
                    </td>
                   <td>
                         <fieldset>
                            <legend>Docente(s) cargado(s) para el Grupo Investigación</legend>  
                         <asp:GridView ID="GridSeleccionDocentes" runat="server" CellPadding="4" AutoGenerateColumns="false" style="margin:0 auto; width:100%"
                            ForeColor="#333333" GridLines="None" 
                            onrowdatabound="GridSeleccionDocentes_RowDataBound" 
                            onrowdeleting="GridSeleccionDocentes_RowDeleting">
                            <Columns>
                            <asp:BoundField DataField="codgradodocente" HeaderText="Cod. Matricula" ><ItemStyle  HorizontalAlign="Center" /></asp:BoundField>
                            <asp:BoundField DataField="identificacion" HeaderText="ID Estudiante" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                            <asp:BoundField DataField="nomdocente" HeaderText="Nombre Docente" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                   
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png"><ItemStyle Width="20px" /></asp:CommandField>        
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
                     <table align="center"><tr><td>
                            <asp:Button runat="server" ID="btnDeseleccionarDocentes" Visible="false" CssClass="btn btn-danger" Text="Borrar lista" OnClick="btnDeseleccionarDocentes_Click" />
                          </td></tr></table>
                 </fieldset>
                   </td>
                </tr>
            </table>
         </fieldset>
       
             
       <table align="center"><tr>
           <td>
               <asp:Button runat="server" ID="btnAgregarEstudiantes" ValidationGroup="addestudiantes" Visible="false" CssClass="btn btn-success" Text="Crear Grupo de Investigación" OnClick="btnAgregarEstudiantes_Click" />
           </td>
              </tr></table>

    </div><!-- Cerrar #conformar -->

         <%-- Agregar estudiantes --%>
       <div id="agregar" style="display:none">
           <asp:Label ID="lblCodEstudiante" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblIDEstudianteOld" runat="server" Visible="false"></asp:Label>
             <fieldset>
                 <legend>Datos a ingresar</legend>
                 * Nota: Si hay campos vacios por favor diligencielos con el valor de cero (0)
                 <table>
                     <tr>
                         <td>Identificación</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtIDEstudianteNuevo" CssClass="TextBox"></asp:TextBox>
                         </td>
                          <td>Nombre estudiante</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtNomEstudianteNuevo" CssClass="TextBox"></asp:TextBox>
                         </td>
                         <td>Apellido</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtNomApellidoNuevo" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                        <td>Género</td>
                         <td>
                             <asp:DropDownList runat="server" ID="dropSexo" CssClass="TextBox">
                                 <asp:ListItem>M</asp:ListItem>
                                 <asp:ListItem>F</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         <td>Fecha nacimiento</td>
                         <td>
                             <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                            <ajx:CalendarExtender ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaNacimiento">
                            </ajx:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RFVtxtFechaNacimiento" runat="server" Display="None" ErrorMessage="Digite Fecha Inicio" 
                                ControlToValidate="txtFechaNacimiento" Text="*" ValidationGroup="Filtrar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RFVtxtFechaNacimiento"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                         </td>
                     </tr>
                     <tr>
                         <td>Teléfono</td>
                         <td>
                              <asp:TextBox runat="server" ID="txtTelefonoNuevo" CssClass="TextBox"></asp:TextBox>
                         </td>
                         <td>Dirección</td>
                          <td>
                              <asp:TextBox runat="server" ID="txtDireccionNuevo" CssClass="TextBox"></asp:TextBox>
                         </td>
                          <td>Email</td>
                          <td>
                              <asp:TextBox runat="server" ID="txtemailNuevo" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="6" align="right"><br />
                            <%-- <a href="#" id="btnEntrar" class="btn btn-primary" style="width:100%;color:white;" onclick="btnEntrar_click();">Agregar Estudiante</a>--%>
                             <asp:Button runat="server" ID="btnEntrar" CssClass="btn btn-primary" Text="Agregar estudiante" OnClick="btnEntrar_click"   />
                             <asp:LinkButton runat="server" Visible="false" ID="btnEditarDatosEstudiante" CssClass="btn btn-primary" style="width:100%;color:white;" Text="Editar Estudiante" OnClick="btnEditarDatosEstudiante_Click" ></asp:LinkButton>
                         </td>
                     </tr>
                 </table>
             </fieldset>
        </div>

         <%-- Mover docente sede --%>
       <div id="mover" style="display:none;">
             <fieldset>
                 <legend>Mover</legend>
                 <table>
                     <tr>
                         <td>Sede</td>
                         <td>
                             <asp:DropDownList runat="server" ID="dropSedeMover" CssClass="TextBox"></asp:DropDownList>
                         </td>
                     </tr> 
                     <tr>
                         <td colspan="2" align="right"><br />
                            <%-- <a href="#" id="btnMoverDocente" class="btn btn-primary" style="width:100%;color:white;" onclick="btnMoverDocente_click();">Mover docente</a>--%>
                             <asp:Button runat="server" ID="btnMoverDocente" CssClass="btn btn-primary" Text="Mover docente" OnClick="btnMoverDocente_Click"  />
                         </td>
                     </tr>
                 </table>
             </fieldset>
        </div>
       
    <div id="verGrupos" >
        
        <asp:GridView ID="GridGrupo" runat="server" CellPadding="4" 
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen Grupos de investigación."
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codproyectosede" HeaderText="codproyectosede" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nomasesor" HeaderText="Asesor">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nomdepartamento" HeaderText="Departamento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nommunicipio" HeaderText="Municipio">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nominstitucion" HeaderText="Institución">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nomsede" HeaderText="Sede">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombregrupo" HeaderText="Grupo">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Integrantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerEstudiantes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerEstudiantes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Docentes acompañantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerDocentes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerDocentes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="nomarea" HeaderText="Línea de Investigación">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomlinea" HeaderText="Tipo de Investigación" >
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:BoundField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="lnkS003" runat="server" CssClass="btn btn-primary" Text="S003" OnClick="lnkS003_Click"></asp:LinkButton><br /><br />--%>
                                <asp:LinkButton ID="lnkEditarGrupo" runat="server" CssClass="btn btn-success" Text="Editar" OnClick="lnkEditarGrupo_Click"></asp:LinkButton><br /><br />
                                <asp:LinkButton ID="lnkEliminarGrupo" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="lnkEliminarGrupo_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción? Recuerde que perderá todos los registros asociados a este Grupo de Investigación.')){ return false; };"></asp:LinkButton>
                            </ItemTemplate>
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

             <div id="dialog-formEstudiantes" style="display:none;" title="Estudiante">

                 <asp:Label ID="lblEstudiantes" runat="server" Visible="true"></asp:Label>

                 </div>

            <div id="dialog-formDocentes" style="display:none;" title="Docentes">

                <asp:Label ID="lblDocentes" runat="server" Visible="true"></asp:Label>

                 </div>

    </div><!-- Cerrar #verGrupos -->

  </ContentTemplate>
</asp:UpdatePanel>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                   
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>


</asp:Content>

