<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verestudiantesxsedes.aspx.cs" Inherits="verestudiantesxsedes" %>

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

     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

   
      <script language="javascript" type="text/javascript">
       

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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div><br /><br />
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
    <div class="header">
        <div style="float: left;margin-right: 15px;">
            <h2>Verificación de estudiantes cargados en la plataforma por Sede y año lectivo para las Redes Temáticas</h2>
        </div>
    </div>
        <br /><br /><br />
         

<div id="CrearRed">
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
         <legend>Personal encontrado</legend>  
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
                
    </fieldset>
               </td>
           </tr>
       </table>
 </fieldset>
   
 </div> <!-- Fin CrearRed -->      


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

