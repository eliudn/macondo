<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiredtematicaeditar.aspx.cs" Inherits="confiredtematicaeditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

    <style>
       .primeracolumna{
            text-align:right;
            font-weight:bold;
        }
    
        .auto-style1 {
            color: #FF0000;
        }
    </style>

     <script type="text/javascript">

         function buscar() {
             //alert("Si este es");
             jQuery.fn.filterByText = function (textbox, selectSingleMatch) {
                 return this.each(function () {
                     var select = this;
                     var options = [];
                     $(select).find('option').each(function () {
                         options.push({ value: $(this).val(), text: $(this).text() });
                     });
                     $(select).data('options', options);
                     $(textbox).bind('change keyup', function () {
                         var options = $(select).empty().data('options');
                         var search = $(this).val().trim();
                         var regex = new RegExp(search, "gi");

                         $.each(options, function (i) {
                             var option = options[i];
                             if (option.text.match(regex) !== null) {
                                 $(select).append(
                                    $('<option>').text(option.text).val(option.value)
                                 );
                             }
                         });
                         if (selectSingleMatch === true && $(select).children().length === 1) {
                             $(select).children().get(0).selected = true;
                         }
                     });
                 });
             };

             $(function () {
                 $('#dropInstitucion').filterByText($('#textbox'), false);
                 $("#dropInstitucion option").click(function () {
                     alert(1);
                 });
             });

             $(function () {
                 $('#dropDocente').filterByText($('#textboxDoc'), false);
                 $("#dropDocente option").click(function () {
                     alert(1);
                 });
             });
         }
    </script>

    <style>
        .TrueGrupo{
            display: block;
           width: 25%;
           margin: 10px 3% 0 3%;
           margin-top: 0px;
           -webkit-border-radius: 5px;
           -moz-border-radius: 5px;
           border-radius: 5px;
           background-color: #79C20D;
           background-position: 10px 10px;
           border: 1px solid #79C20D;
           color: #fff;
           padding: 5px 0;
           text-indent: 40px;
           font-size: 10px;
        }

        .ErrorGrupo{
            display: block;
           width: 25%;
           -webkit-border-radius: 5px;
           -moz-border-radius: 5px;
           border-radius: 5px;
           background-color: #e51c23;
           background-position: 10px 10px;
           border: 1px solid #7B040F;
           color: #fff;
           padding: 5px 0;
           text-indent: 40px;
           font-size: 10px;
        }
    </style>

     <script language="javascript" type="text/javascript">

         $().ready(function () {

             $(document).everyTime(480000, function () {

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

    </script>
    
     <script type="text/javascript">
         $("#MainContent_lblRealizado").ready(function () {
             setTimeout(function () { $("#MainContent_lblRealizado").fadeOut(1500); }, 1500);
         });
        </script>

      <script type="text/javascript">
          $("#MainContent_lblError").ready(function () {
              setTimeout(function () { $("#MainContent_lblError").fadeOut(1500); }, 1500);
          });

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

        </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" AsyncPostBackTimeOut="600"></asp:ScriptManager>
    
    <asp:Label runat="server" ID="lblCodSede" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblEstrategia" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblMomento" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodUsuario" Visible="false" ></asp:Label>

<div
     id="mensaje" runat="server"></div><br /><br />
<h2 >Editar Redes Temáticas</h2><br />
     <asp:Label ID="lblRealizado" CssClass="TrueGrupo" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblError" CssClass="ErrorGrupo" runat="server" Visible="false"></asp:Label>
     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
   <ContentTemplate>
       <div style="float:right">
           <asp:LinkButton runat="server"  ID="lnkAgregarNuevoEstudiante" Visible="true" CssClass="btn btn-success" OnClick="lnkAgregarNuevoEstudiante_Click" >Nuevo estudiante</asp:LinkButton>
           <asp:LinkButton runat="server"  ID="lnkVolverAlEditar" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverAlEditar_Click" >Volver</asp:LinkButton>
           <asp:LinkButton ID="lnkVolverMoverDocente" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverMoverDocente_Click">Volver</asp:LinkButton>
       </div>
       <br /><br />
<div id="ver">
<fieldset>
<legend>Redes Temáticas</legend>
    
    
    <asp:Label ID="lblDatos" runat="server" Visible="true"></asp:Label>
     <asp:Label ID="lblCodProyectoSede" runat="server" Visible="false"></asp:Label>
      <table>
           <tr>
               <td>Año lectivo: </td>
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
                                    <asp:DropDownList runat="server" ID="dropDepartamento" CssClass="TextBox" ></asp:DropDownList>
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
                                     <asp:DropDownList runat="server" ID="dropMunicipio" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Seleccione el municipio"
                                        Text="*" Display="None" ControlToValidate="dropMunicipio" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
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
                              </asp:UpdatePanel>

                         </td>
                     </tr>
                    <tr>
                         <td>Red Temática:</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropRedTematica" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropRedTematica" runat="server" ErrorMessage="Seleccione"
                                        Text="*" Display="None" ControlToValidate="dropRedTematica" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVdropRedTematica"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                             </asp:UpdatePanel>

                         </td>
                     </tr>
          <tr>
              <td colspan="2">
                  <asp:LinkButton runat="server" ID="lnlEditarRed" CssClass="btn btn-primary" Text="Editar" OnClick="lnkEditarRed_Click"></asp:LinkButton>
              </td>
          </tr>
                  
          </table>

    <fieldset>
        <legend>Integrantes del grupo</legend>
           <center> 
               <asp:Button visible="false" runat="server" ID="btnAgregarEstudiante" CssClass="btn btn-success" Text="Agregar estudiante" Onclick="btnAgregarEstudiante_Click" /> 
               <asp:Label runat="server" id="lblCodGrupoInvestigacion" Visible="false"></asp:Label>
           </center>
                    <br />
                     <asp:GridView ID="GridEstudiante" runat="server" CellPadding="4" DataKeyNames="rt_codproyectomatricula" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                             <asp:BoundField DataField="codestumatricula" HeaderText="codestumatricula" HeaderStyle-CssClass="ocultarcell">
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
                            <%-- <asp:BoundField DataField="grupo" HeaderText="Grupo">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>--%>

                             <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:ImageButton ID="btnEditarEstudiante" runat="server" ImageUrl='~/Imagenes/edit.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnEditarEstudiante_Click" />
                                    <%--<asp:ImageButton runat="server" ID="btnEditarEstudiante" ImageUrl="~/Imagenes/edit.png" Width="20" OnClick="btnEditarEstudiante_Click" />--%>
                                </ItemTemplate>
                             </asp:TemplateField>
                           

                         <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteEstudianteActivo_Click" />
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

        <%-- Mostrar Datos de los estudiantes a buscar --%>

  <asp:Panel runat="server" ID="PanelVerEstudiante" Visible ="false">
    <center>
            <fieldset>
                 <legend>Agregar estudiantes</legend>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                             Grados: 
                             <asp:DropDownList runat="server" ID="dropGrados" CssClass="TextBox" ></asp:DropDownList>
                             Grupo:
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
                             <asp:Button runat="server" ID="btnBuscarEstudiantesNew" CssClass="btn btn-primary" Text="Buscar " OnClick="btnBuscarEstudiantesNew_Click"  />
                                                   
                 <br />
                        <fieldset>
                        <legend>Búsqueda</legend>
                                <table align="center">
                                    <tr>
                                        <td>Estudiante: <input id="buscarEstudiantes" class="TextBox" placeholder="ID o Nombre..." type="text" onkeyup="doSearch('buscarEstudiantes','GridEstudiantesBuscados')"></td>
                                    </tr>
                                </table>
                     </fieldset>
                 <br />
                  <asp:GridView ID="GridEstudiantesBuscados" runat="server" CellPadding="4" CssClass="mGridTesoreria" DataKeyNames="codestumatricula" UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  Style="margin: 0 auto" AutoGenerateColumns="false"
                        GridLines="None" >
                        <Columns>

                     <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="codestumatricula" HeaderText="codestumatricula" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
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
                                               <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:CheckBox runat="server" ID="chkAllAsignados" AutoPostBack="true" OnCheckedChanged="chkAllAsignados_Click" />
                                                    </ContentTemplate>
                                               </asp:UpdatePanel>
                                         </HeaderTemplate>

                                  <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListEstudiante" />
                                </ItemTemplate>

                                        <%-- <ItemTemplate>
                                             <asp:CheckBox ID="cbItem" runat="server" />
                                         </ItemTemplate>--%>
                                         <ItemStyle Width="50px" HorizontalAlign="Center" />
                                     </asp:TemplateField>

                         <%-- <asp:TemplateField>
                               
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
                    
                             <center><asp:Button visible="false" runat="server" ID="btnGuardarEstuLineaInvestigacion" CssClass="btn btn-danger" Text="Asignar estudiante(s)" Onclick="btnGuardarEstuLineaInvestigacion_Click" /></center>

                  </ContentTemplate>
                    </asp:UpdatePanel>
             </fieldset>
        </center>
       </asp:Panel>

    </fieldset>
    <fieldset>
        <legend>Maestros(as) acompanante(s)</legend>
            <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
         <center> 
               <asp:Button visible="false" runat="server" ID="btnAgregarDocente" CssClass="btn btn-success" Text="Agregar Docentes" Onclick="btnAgregarDocente_Click" /> 
           </center>
        <br />
   
                 <asp:GridView ID="GridDocentes" runat="server" CellPadding="4" DataKeyNames="codredtematicadocente" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                            <asp:BoundField DataField="nombre"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                             <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteDocenteActivo_Click" />
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
              </ContentTemplate>
                    </asp:UpdatePanel>
    </fieldset>

        <%-- Mostrar Datos de los Docentes a buscar --%>

  <asp:Panel runat="server" ID="PanelVerDocentes" Visible ="false">
    <center>
            <fieldset>
                 <legend>Agregar Docente</legend>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                               <fieldset>
                                    <legend>Búsqueda</legend>
                                        <table align="center">
                                            <tr>
                                                <td>Docente: <input id="buscarDocentes" class="TextBox" placeholder="ID o Nombre..." type="text" onkeyup="doSearch('buscarDocentes','GridDocentesBuscados')"></td>
                                            </tr>
                                        </table>
                                 </fieldset>
                  <asp:GridView ID="GridDocentesBuscados" runat="server" CellPadding="4" CssClass="mGridTesoreria" DataKeyNames="codgradodocente" UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  Style="margin: 0 auto" AutoGenerateColumns="false"
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

                              <asp:TemplateField >
                                <ItemTemplate>
                                             <asp:ImageButton ID="btnMoverDocente" ToolTip="Mover Docente a otra sede" runat="server" ImageUrl='~/Imagenes/mover.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnMoverDocente_Click"  />
                                 </ItemTemplate>
                            </asp:TemplateField>
         
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListDocente" />
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
                    
                             <center><asp:Button visible="false" runat="server" ID="btnGuardarDocenteLineaInvestigacion" CssClass="btn btn-danger" Text="Asignar docente(s)" Onclick="btnGuardarDocenteLineaInvestigacion_Click" /></center>

                  </ContentTemplate>
                    </asp:UpdatePanel>
             </fieldset>
        </center>
       </asp:Panel>

    <fieldset>
        <legend>Asesor</legend>
         <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
         <center> 
               <asp:Button visible="false" runat="server" ID="btnagregarAsesor" CssClass="btn btn-success" Text="Agregar Asesor" Onclick="btnagregarAsesor_Click" /> 
           </center>
        <br />
                 <asp:GridView ID="GridAsesor" runat="server" CellPadding="4" DataKeyNames="codredtematicasede" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                             <asp:BoundField DataField="codasesorcoordinador" HeaderText="codasesorcoordinador" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="identificacion" HeaderText="Identificación">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                         <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteAsesorActivo_Click" />
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
              </ContentTemplate>
                    </asp:UpdatePanel>
    </fieldset>

      <%-- Mostrar Datos de los Asesores a buscar --%>

     <asp:Panel runat="server" ID="PanelVerAsesores" Visible ="false">
    <center>
            <fieldset>
                 <legend>Agregar asesores</legend>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                      
                 <br />
                  <asp:GridView ID="GridAsesoresBuscados" runat="server" CellPadding="4" CssClass="mGridTesoreria" DataKeyNames="codasesorcoordinador"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  Style="margin: 0 auto" AutoGenerateColumns="false"
                        GridLines="None" >
                        <Columns>
                     <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="codasesorcoordinador" HeaderText="codasesorcoordinador" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                          <asp:BoundField DataField="identificacion" HeaderText="Identificación">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
  
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton runat="server" ID="rbtAsesor" />
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
                    
                             <center><asp:Button visible="false" runat="server" ID="btnGuardarAsesorLineaInvestigacion" CssClass="btn btn-danger" Text="Asignar Asesor" Onclick="btnGuardarAsesorLineaInvestigacion_Click" /></center>

                  </ContentTemplate>
                    </asp:UpdatePanel>
             </fieldset>
        </center>
       </asp:Panel>

</fieldset>

        <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
        
</div>


          <%-- Agregar estudiantes --%>
       <div id="agregar" style="display:none;">
           <asp:Label runat="server" ID="lblIDEstudianteOld" Visible="false"></asp:Label>
             <fieldset>
                 <legend>Datos a ingresar</legend>
                 * Nota: Si hay campos vacios por favor diligencielos con el valor de cero (0)
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
       <div id="mover" style="display:none;">
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

 </ContentTemplate>
</asp:UpdatePanel>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                   
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>
</asp:Content>

