<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiredtematica.aspx.cs" Inherits="confiredtematica" %>

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
     <script src="jquery.js"></script>
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

     <link href="css/datepicker.css" rel="stylesheet" type="text/css">
     <script src="js/datepicker.js"></script>
     <script>
         $(function () {

             $(".datepicker").datepicker({
                 changeMonth: true,
                 changeYear: true
             });



         });
     </script>

    <script type="text/javascript">

       

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

            var jsonData = '{ "dropsede":"' + $("#MainContent_dropSedeMover").val() + ', "dropAnio":" ' + $("#MainContent_dropAnio").val() + ' "}';
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

      <script language="javascript" type="text/javascript">
          $(function () {
              $("#btn-nuveoEstudiante").hide();
              $('#lnkVolver').hide();
             
          });

         
          /*nuevo estudiante*/
          function btnAgregarNuevoEstudiante() {
              $('#dialog-formadd').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
              //$('#VerRed').hide();
              //$('#CrearRed').show();
              //$("#txtIDEstudianteNuevo").val("");
              //$("#txtNomEstudianteNuevo").val("");
              //$("#txtNomApellidoNuevo").val("");
              //$("#dropSexo").val("Seleccione");
              //$("#txtFechaNacimiento").val("");
              //$("#txtTelefonoNuevo").val("");
              //$("#txtDireccionNuevo").val("");
              //$("#txtemailNuevo").val("");
              //$('#MainContent_lnkVerGruposInvestigacion').hide();

          }
          /*lnk volver*/
          function lnkVolver() {
              $('#CrearRed').hide();
              $('#VerRed').fadeIn(500);
              $('#btn-nuveoEstudiante').hide();
              $('#lnkVolver').hide();
              $('#MainContent_lnkVerGruposInvestigacion').show();
          }
          
          function btnEditarEstudiante_Click() {
              $('#dialog-form').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
              $('#VerRed').hide(), $('#CrearRed').show();
          }

          function doSearch(val, table) {
              /*var tableReg = document.getElementById('table');*/
              var tableReg = document.getElementById("" + table);
              var searchText = $("#" + val).val().toLowerCase();
              /*var searchText = document.getElementById('buscar').value.toLowerCase();*/
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

        <%--  function SeleccionarCheckbox(Checkbox) {
              var GridEstudiante = document.GridEstudiante("<%=GridEstudiante.ClientID %>");
              for (i = 1; i < GridEstudiante.rows.length; i++) {
                  GridEstudiante.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
              }
          }--%>
    
          function btnModificarFecha() {
              var jsonData = "{'fecha':'" + $("#MainContent_txtFechaModificar").val() + "'}";

              $.ajax({
                  type: "POST",
                  url: "confiredtematica.aspx/ModificarFecha",
                  data: jsonData,
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (json) {
                     
                      if (json.d === "exito") {
                          //alert('Fecha actualizada correctamente');
                          window.location.href = "confiredtematica.aspx";
                      }

                      else {
                          alert('Error al modificar.');
                      }
                  }
              });
          }
    </script>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" AsyncPostBackTimeOut="36000" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div><br /><br />
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
    <div class="header">
        <div style="float: left;margin-right: 15px;">
            <h2>Conformación de las Redes Temáticas</h2>
        </div>
        <div style="float: right;margin-top:20px;">
			<%--<a id="btn-moverDocente" class="btn btn-danger" href="Documentos/Mover_docente_de_sede.pdf" target="_blank">Instructivo mover docente</a>
            <a id="btn-nuevoEstudiante" class="btn btn-danger" href="Documentos/Creacion_Nuevo_Estudiante.pdf" target="_blank">Instructivo nuevo estudiante</a>--%>
            <asp:LinkButton runat="server"  ID="btnnuevoEstudiante" Visible="false" CssClass="btn btn-success" OnClick="btnAgregarNuevoEstudiante_Click" >Nuevo estudiante</asp:LinkButton>
              <%--<asp:LinkButton runat="server"  ID="btnnuevoEstudiante" Visible="false" CssClass="btn btn-success" OnClientClick="btnAgregarNuevoEstudiante();" >Nuevo estudiante</asp:LinkButton>--%>
             <%--<asp:Button runat="server" ID="btnRedTematicaCreada" Text="Ver Redes Temáticas creadas" CssClass="btn btn-success" OnClick="btnRedTematicaCreada_Click" />--%>
            <asp:LinkButton runat="server" ID="lnkVerGruposInvestigacion" CssClass="btn btn-primary" OnClick="lnkCrearRedesTematicas_Click">Crear Red Temática</asp:LinkButton>
            <asp:LinkButton ID="lnkVolver" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolver_Click">Volver</asp:LinkButton>
            <asp:LinkButton ID="lnkVolverEditarDatosEstudiante" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverEditarDatosEstudiante_Click">Volver</asp:LinkButton>
            <asp:LinkButton ID="lnkVolverMoverDocente" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverMoverDocente_Click">Volver</asp:LinkButton>
        </div>
    </div>
        <br /><br /><br />

       <div id="VerRed" >
          Seleccione el año lectivo <asp:DropDownList ID="dropAnio2" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropAnio2_OnSelectedIndexChanged"></asp:DropDownList>
            <asp:GridView ID="GridRed" runat="server" CellPadding="4" 
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen Redes Temáticas." CssClass="mGridTesoreria"
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codredtematicasede" HeaderText="codredtematicasede" HeaderStyle-CssClass="ocultarcell">
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
                         <asp:BoundField DataField="fechacreacion" HeaderText="Fecha creación">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombregrupo" HeaderText="Red Temática">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                         <asp:BoundField DataField="cantestudiantes" HeaderText="Cantidad Estudiantes" >
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Integrantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerEstudiantes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerEstudiantes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:BoundField DataField="cantdocente" HeaderText="Cantidad Docentes" >
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Docentes acompañantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerDocentes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerDocentes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:BoundField DataField="aniored" HeaderText="Año de la Red Temática">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFechaRed" runat="server" ToolTip="Cambiar año de creación de la memoria" OnClick="lnkFechaRed_Click"><img src="Imagenes/fecha.png" width="25" /></asp:LinkButton><br />
                                <asp:LinkButton ID="lnkEditarRed" runat="server" CssClass="btn btn-success" Text="Editar" OnClick="lnkEditarRed_Click"></asp:LinkButton><br /><br />
                                <asp:LinkButton ID="lnkEliminarRedTematica" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="lnkEliminarRedTematica_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción? Recuerde que perderá todos los registros asociados a esta Red Temática.')){ return false; };"></asp:LinkButton>
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

       </div>

         

<div id="CrearRed" style="display:none;">
    <fieldset>
        <legend>Datos institucionales</legend>
       
       
                 <table>
                     <tr>
                         <td>Año Lectivo</td>
              <td>
                   <asp:UpdatePanel runat="server" ID="UpdatePanel13" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"  ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropAnio" runat="server" ErrorMessage="Seleccione el Año"
                                        Text="*" Display="None" ControlToValidate="dropAnio" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True" TargetControlID="RFVdropAnio"
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
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVdropDepartamento"
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
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
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
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropInstituciones"
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
                                  <asp:ListItem>6</asp:ListItem>
                                  <asp:ListItem>7</asp:ListItem>
                                  <asp:ListItem>8</asp:ListItem>
                                  <asp:ListItem>9</asp:ListItem>
                              </asp:DropDownList>
                              <%-- <asp:RequiredFieldValidator ID="RFVdropGrupo" runat="server" ErrorMessage="Seleccione el grupo"
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
        <legend>Búsqueda</legend>
        <table align="center">
            <tr>
                <td>Estudiante: <input id="buscarEstudiantes" class="TextBox" placeholder="ID o Nombre..." type="text" onkeyup="doSearch('buscarEstudiantes','GridEstudiante')"></td>
                <td>Docente: <input id="buscarDocentes" class="TextBox" placeholder="ID o Nombre..." type="text" onkeyup="doSearch('buscarDocentes','GridDocentes')"></td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
         <legend>Selección de personal</legend>  
       <table>
           <tr>
               <td>
                    <fieldset>
        <legend>Estudiantes por grados</legend>
                        <asp:Label runat="server" ID="lblEstudentVacio" Visible="true"></asp:Label>
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
                                <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkseleccionartodo" AutoPostBack="true" OnCheckedChanged="chkseleccionartodo_Click" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListEstudiante" />
                                </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:ImageButton ID="btnEditarEstudiante" runat="server" ImageUrl='~/Imagenes/edit.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnEditarEstudiante_Click" />
                                    <%--<asp:ImageButton runat="server" ID="btnEditarEstudiante" ImageUrl="~/Imagenes/edit.png" Width="20" OnClick="btnEditarEstudiante_Click" />--%>
                                </ItemTemplate>
                             </asp:TemplateField>
                       <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEliminarEstudianteRedTematica" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="lnkEliminarEstudianteRedTematica_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción?')){ return false; };" />
                                          <%--        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
                                 --%></ItemTemplate>
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

        <table Width="100%"><tr><td>          
            <td width="80%">
                <asp:Button runat="server" ID="btnSeleccionarEstudiantes" Visible="false" CssClass="btn btn-danger" Text="Agregar Selección" OnClick="btnSeleccionarEstudiantes_Click" />               
            </td>

            <td width="30%">
                <asp:Button runat="server" ID="btnBorrarSeleccion" Visible="false" CssClass="btn btn-danger" Text="Borrar Selección" OnClick="btnBorrarSeleccionados_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción? Los estudiantes seleccionados serán borrados permanentemente.')){ return false; };" />
            </td>
                             </td></tr></table>

                        
    </fieldset>
               </td>
               <td>
                    <fieldset>
        <legend>Docentes por Sede</legend>
                        <asp:Label runat="server" ID="lblDocVacio" Visible="true"></asp:Label>
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
                                    <asp:CheckBox runat="server" ID="chkListDocente"  />
                                </ItemTemplate>
                             </asp:TemplateField>

                             <%-- <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:ImageButton ID="btnEditarDocente" runat="server" ImageUrl='~/Imagenes/edit.png' Width="20px" Height="20px" Style="cursor: pointer"  />
                                </ItemTemplate>
                             </asp:TemplateField>--%>

                            <asp:TemplateField >
                                <ItemTemplate>
                                             <asp:ImageButton ID="btnMoverDocente" ToolTip="Mover Docente a otra sede" runat="server" ImageUrl='~/Imagenes/mover.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnMoverDocente_Click"  />
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
   
       

      
           <asp:Panel runat="server" ID="PanelNomRedtematica" Visible="false">
                <table align="center"><tr>
                    <td>Nombre de la Red Temática</td>
                    <%--</tr>
                    <tr>--%>
                    <td>
                        <asp:DropDownList runat="server" ID="dropRedTematica" CssClass="TextBox"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RFVdropRedTematica" runat="server" ErrorMessage="Seleccione la Red Temática"
                                        Text="*" Display="None" ControlToValidate="dropRedTematica" InitialValue="Seleccione"
                                        ValidationGroup="addestudiantes"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVdropRedTematica"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                    </td>
                       </tr></table>
            </asp:Panel>

        <fieldset>
         <legend>Personal para la Red Temática</legend>  
            <table align="center">
                <tr>
                    <td>
                          <fieldset>
                             <legend>Estudiantes cargados para la Red Temática</legend>  
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
                            <legend>Docente(s) cargado(s) para la Red Temática</legend>  
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
 </div> <!-- Fin CrearRed -->      
             
       <table align="center"><tr>
           <td>
               <asp:Button runat="server" ID="btnAgregarEstudiantes" ValidationGroup="addestudiantes" Visible="false" CssClass="btn btn-success" Text="Crear Red Temática" OnClick="btnAgregarEstudiantes_Click" />
           </td>
              </tr></table>

       <%-- Edición de los estudiantes --%>
       <div id="dialog-form" style="display:none;" title="Editar información del estudiante">
             <fieldset>
                 <legend>Datos a editar</legend>
                 <asp:Label runat="server" ID="lblCodEstudiante" Visible="false"></asp:Label>
                 <table>
                     <tr>
                         <td>Identificación</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtIDestudiante" CssClass="TextBox"></asp:TextBox>
                         </td>
                          <td>Nombre estudiante</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtNomEstudiante" CssClass="TextBox"></asp:TextBox>
                         </td>
                         <td>Apellido</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtApellidoEstudiante" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                        <td>Género</td>
                         <td>
                             <asp:DropDownList runat="server" ID="dropGenero" CssClass="TextBox">
                                 <asp:ListItem>Seleccione</asp:ListItem>
                                 <asp:ListItem>M</asp:ListItem>
                                 <asp:ListItem>F</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         <td>Fecha nacimiento</td>
                         <td>
                             <asp:TextBox ID="txtFechaIni" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                           <%-- <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaIni">
                            </ajx:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite Fecha Inicio" 
                                ControlToValidate="txtFechaIni" Text="*" ValidationGroup="Filtrar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVtxtFechaIni"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>--%>
                         </td>
                     </tr>
                     <tr>
                         <td>Teléfono</td>
                         <td>
                              <asp:TextBox runat="server" ID="txtTelefono" CssClass="TextBox"></asp:TextBox>
                         </td>
                         <td>Dirección</td>
                          <td>
                              <asp:TextBox runat="server" ID="txtDireccion" CssClass="TextBox"></asp:TextBox>
                         </td>
                          <td>Email</td>
                          <td>
                              <asp:TextBox runat="server" ID="txtEmail" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="6" align="right"><br />
                             <a href="#" id="btnEditar" class="btn btn-primary" style="width:100%;color:white;" onclick="btnEditar_click();">Editar Estudiante</a>
                             <%--<asp:Button runat="server" ID="btnGuardarEdicionEstudiante" CssClass="btn btn-success" Text="Editar" OnClick="btnGuardarEdicionEstudiante_Click"  />--%>
                         </td>
                     </tr>
                 </table>
             </fieldset>
        </div>

        <%-- Agregar estudiantes --%>
       <%--<div id="dialog-formadd" style="display:none;" title="Agregar información del estudiante">--%>
       <div id="agregar" style="display: none" title="Agregar información del estudiante">
           <asp:Label runat="server" ID="lblIDEstudianteOld" Visible="false"></asp:Label>
             <fieldset>
                 <legend>Datos a ingresar</legend>
                 * Nota: Si hay campos vacios por favor diligencielos con el valor de cero (0)
                 <%--<table>
                     <tr>
                         <td>Identificación</td>
                         <td>
                             <input type="text" ID="txtIDEstudianteNuevo" class="TextBox"/>
                         </td>
                          <td>Nombre estudiante</td>
                         <td>
                             <input type="text" ID="txtNomEstudianteNuevo" class="TextBox"/>
                         </td>
                         <td>Apellido</td>
                         <td>
                             <input type="text" ID="txtNomApellidoNuevo" class="TextBox"/>
                         </td>
                     </tr>
                     <tr>
                        <td>Género</td>
                         <td>
                              <select  ID="dropSexo" class="TextBox">
                                  <option value="Seleccione">Seleccione</option>
                                  <option value="M">M</option>
                                  <option value="F">F</option>
                               </select>
                            
                         </td>
                         <td>Fecha nacimiento</td>
                         <td>
                             <input type="text" ID="txtFechaNacimiento"  class="TextBox" Width="90px"/>Ej: 2016/01/01
                           
                         </td>
                     </tr>
                     <tr>
                         <td>Teléfono</td>
                         <td>
                              <input type="text" ID="txtTelefonoNuevo" class="TextBox"/>
                         </td>
                         <td>Dirección</td>
                          <td>
                              <input type="text" ID="txtDireccionNuevo" class="TextBox"/>
                         </td>
                          <td>Email</td>
                          <td>
                              <input type="text" ID="txtemailNuevo" class="TextBox"/>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="6" align="right"><br />
                             <a href="#" id="btnEntrar" class="btn btn-primary" style="width:100%;color:white;" onclick="btnEntrar_click();">Agregar Estudiante</a>
                         </td>
                     </tr>
                 </table>--%>
                 <table>
                     <tr>
                         <td>Identificación</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtIDEstudianteNuevo" CssClass="TextBox"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RFVtxtIDEstudianteNuevo" runat="server" ErrorMessage="Digite la indetificación."
                                Text="*" Display="None" ControlToValidate="txtIDEstudianteNuevo"
                                ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RFVtxtIDEstudianteNuevo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                               <ajx:FilteredTextBoxExtender ID="txtIDEstudianteNuevo_FilteredTextBoxExtender"
                                    runat="server" Enabled="True" TargetControlID="txtIDEstudianteNuevo" FilterType="Numbers" ></ajx:FilteredTextBoxExtender>
                         </td>
                          <td>Nombre estudiante</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtNomEstudianteNuevo" CssClass="TextBox"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RFVtxtNomEstudianteNuevo" runat="server" ErrorMessage="Digite el nombre."
                                Text="*" Display="None" ControlToValidate="txtNomEstudianteNuevo"
                                ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVtxtNomEstudianteNuevo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                         </td>
                         <td>Apellido</td>
                         <td>
                             <asp:TextBox runat="server" ID="txtNomApellidoNuevo" CssClass="TextBox"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RFVtxtNomApellidoNuevo" runat="server" ErrorMessage="Digite el apellido."
                                Text="*" Display="None" ControlToValidate="txtNomApellidoNuevo"
                                ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RFVtxtNomApellidoNuevo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
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
                             <asp:TextBox ID="txtFechaN" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                              <ajx:TextBoxWatermarkExtender ID="txtFechaN_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtFechaN" WatermarkCssClass="TextWater" WatermarkText="dd-MM-aaaa" ></ajx:TextBoxWatermarkExtender>
                            <ajx:CalendarExtender ID="txtFechaN_CalendarExtender" runat="server" DefaultView="Years" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaN"></ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaN" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None" ControlToValidate="txtFechaN" ValidationGroup="Agregar" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" style="color: #FF0000"></asp:RegularExpressionValidator>    
                            <asp:RequiredFieldValidator ID="RFVtxtFechaN" runat="server" Display="None" ErrorMessage="Digite fecha de nacimiento" ControlToValidate="txtFechaN" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RFVtxtFechaN" HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle"></ajx:ValidatorCalloutExtender>
                         </td>
                     </tr>
                     <tr>
                         <td>Teléfono</td>
                         <td>
                              <asp:TextBox runat="server" ID="txtTelefonoNuevo" CssClass="TextBox"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RFVtxtTelefonoNuevo" runat="server" ErrorMessage="Digite el teléfono."
                                Text="*" Display="None" ControlToValidate="txtTelefonoNuevo"
                                ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVtxtTelefonoNuevo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                              <ajx:FilteredTextBoxExtender ID="txtTelefonoNuevo_FilteredTextBoxExtender"
                                    runat="server" Enabled="True" TargetControlID="txtTelefonoNuevo" FilterType="Numbers" ></ajx:FilteredTextBoxExtender>
                         </td>
                         <td>Dirección</td>
                          <td>
                              <asp:TextBox runat="server" ID="txtDireccionNuevo" CssClass="TextBox"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RFVtxtDireccionNuevo" runat="server" ErrorMessage="Digite la dirección."
                                Text="*" Display="None" ControlToValidate="txtDireccionNuevo"
                                ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RFVtxtDireccionNuevo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                         </td>
                          <td>Email</td>
                          <td>
                              <asp:TextBox runat="server" ID="txtemailNuevo" CssClass="TextBox"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RFVtxtemailNuevo" runat="server" ErrorMessage="Digite el email."
                                Text="*" Display="None" ControlToValidate="txtemailNuevo"
                                ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="RFVtxtemailNuevo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="6" align="right"><br />
                             <asp:LinkButton runat="server" ID="btnEntrar" ValidationGroup="Agregar" CssClass="btn btn-primary" style="width:100%;color:white;" Text="Agregar Estudiante" OnClick="btnEntrar_click" ></asp:LinkButton>
                             <asp:LinkButton runat="server" Visible="false" ID="btnEditarDatosEstudiante" CssClass="btn btn-primary" style="width:100%;color:white;" Text="Editar Estudiante" OnClick="btnEditarDatosEstudiante_Click" ></asp:LinkButton>
                            <%-- <a href="#" id="btnEntrar" class="btn btn-primary" style="width:100%;color:white;" onclick="btnEntrar_click();">Agregar Estudiante</a>--%>
                             </td>
                     </tr>
                 </table>
             </fieldset>
        </div>

         <%-- Mover docente sede --%>
       <div id="mover" style="display:none;" title="Mover docente de sede">
             <fieldset>
                 <legend>Mover</legend>
                 <table>
                     <tr>
                         <td>Sede</td>
                         <td>
                             <asp:DropDownList runat="server" ID="dropSedeMover" CssClass="TextBox"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RFVdropSedeMover" runat="server" ErrorMessage="Digite la actividad a ejecutar"
                            Text="*" Display="None" ControlToValidate="dropSedeMover" InitialValue="Seleccione"
                            ValidationGroup="actividad"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" Enabled="True" TargetControlID="RFVdropSedeMover"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                         </td>
                     </tr> 
                     <tr>
                         <td colspan="2" align="right"><br />
                             <asp:LinkButton ID="lnkMoverDocente" runat="server" Text="Mover docente" CssClass="btn btn-primary" style="width:100%;color:white;" onclick="lnkMoverDocente_Click"></asp:LinkButton>
                             <%--<a href="#" id="btnMoverDocente" class="btn btn-primary" style="width:100%;color:white;" onclick="btnMoverDocente_click();">Mover docente</a>--%>
                             <%--<asp:Button runat="server" ID="btnNuevoEstudiante" CssClass="btn btn-primary" Text="Agregar estudiante" OnClick="btnNuevoEstudiante_Click"  />--%>
                         </td>
                     </tr>
                 </table>
             </fieldset>
        </div>

        <div id="dialog-formEstudiantes" style="display:none;" title="Estudiante">

                 <asp:Label ID="lblEstudiantes" runat="server" Visible="true"></asp:Label>

                 </div>

            <div id="dialog-formDocentes" style="display:none;" title="Docentes">

                <asp:Label ID="lblDocentes" runat="server" Visible="true"></asp:Label>

                 </div>
        
       
       
  </ContentTemplate>
</asp:UpdatePanel>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                   
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>

      <div id="Modificarfecha" style="display:none;">
            <asp:Label ID="lblCodRedTematica" runat="server" Visible="false"></asp:Label>
        <p>Actualizar fecha para las Redes Temáticas</p>
            <asp:Label ID="lblFechaRed" runat="server" Visible="true"></asp:Label>
            <table >
                <tr>
                    <td>Año de la red temática</td>
                    <td>
                       <asp:DropDownList runat="server" id="dropAnioRed" CssClass="TextBox"></asp:DropDownList>
                       <%-- <asp:TextBox ID="txtFechaModificar" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                            <ajx:TextBoxWatermarkExtender ID="txtFechaModificar_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtFechaModificar" WatermarkCssClass="TextWater" WatermarkText="dd-MM-aaaa" ></ajx:TextBoxWatermarkExtender>
                            <ajx:CalendarExtender ID="txtFechaModificar_CalendarExtender" runat="server" DefaultView="Years" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaModificar"></ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaModificar" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None" ControlToValidate="txtFechaModificar" ValidationGroup="fecha" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" style="color: #FF0000"></asp:RegularExpressionValidator>    
                            <asp:RequiredFieldValidator ID="RFVtxtFechaModificar" runat="server" Display="None" ErrorMessage="Digite fecha de nacimiento" ControlToValidate="txtFechaModificar" Text="*" ValidationGroup="fecha"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="RFVtxtFechaModificar" HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle"></ajx:ValidatorCalloutExtender>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="lnkModificarFecha" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="lnkModificarFecha_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>

</asp:Content>

