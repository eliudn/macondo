<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verEstraUnoBitacoraUno.aspx.cs" Inherits="verEstraUnoBitacoraUno" %>

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

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    
    <asp:Label runat="server" ID="lblCodSede" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblEstrategia" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblMomento" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodUsuario" Visible="false" ></asp:Label>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Ver Estrategía Nro 1 - Bitacora Nro 1</h2><br />


     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
   <ContentTemplate>

        <div style="float: right;">
            <%--<asp:LinkButton runat="server" ID="lnkVerGruposInvestigacion" CssClass="btn btn-primary" OnClick="lnkVerGruposInvestigacion_Click">Nueva bitácora</asp:LinkButton>--%>
            <asp:LinkButton runat="server" ID="lnkVolver" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolver_Click">Volver</asp:LinkButton>
        </div>
     
<div id="insertarbitacoras" style="display:none;">

<fieldset>
<legend>Agregar Bitacora</legend>

      <table>
          <tr>
              <td>Año lectivo</td>
              <td>
                   <asp:UpdatePanel runat="server" ID="UpdatePanel13" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"  ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropAnio" runat="server" ErrorMessage="Seleccione el Año"
                                        Text="*" Display="None" ControlToValidate="dropAnio" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropAnio"
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
                                     <asp:DropDownList runat="server" ID="dropSedes" CssClass="TextBox" UpdateMode="Conditional" AutoPostBack="true" OnSelectedIndexChanged="dropSedes_SelectedIndexChanged" ></asp:DropDownList>
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
                         <td>Grupo de Investigación:</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropGrupoInvestigacion" CssClass="TextBox" UpdateMode="Conditional" AutoPostBack="true" OnSelectedIndexChanged="dropGrupoInvestigacion_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropGrupoInvestigacion" runat="server" ErrorMessage="Seleccione"
                                        Text="*" Display="None" ControlToValidate="dropGrupoInvestigacion" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVdropGrupoInvestigacion"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropSedes" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>

                         </td>
                     </tr>
                    <tr>
                         <td>Línea de investigacipón</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropLineaInvestigacion" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropLineaInvestigacion" runat="server" ErrorMessage="Seleccione"
                                        Text="*" Display="None" ControlToValidate="dropLineaInvestigacion" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVdropLineaInvestigacion"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                             </asp:UpdatePanel>

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
                     <asp:GridView ID="GridEstudiante" runat="server" CellPadding="4" DataKeyNames="pro_proyectomatricula" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                             <asp:BoundField DataField="pro_proyectomatricula" HeaderText="pro_proyectomatricula" HeaderStyle-CssClass="ocultarcell">
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
                             <asp:Button runat="server" ID="btnBuscarEstudiantesNew" CssClass="btn btn-primary" Text="Buscar " OnClick="btnBuscarEstudiantesNew_Click"  />
                                                   
                 <br />
                  <asp:GridView ID="GridEstudiantesBuscados" runat="server" CellPadding="4" CssClass="mGridTesoreria" DataKeyNames="codestumatricula"
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
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListEstudiante" />
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
                 <asp:GridView ID="GridDocentes" runat="server" CellPadding="4" DataKeyNames="codproyectodocente" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                  <asp:GridView ID="GridDocentesBuscados" runat="server" CellPadding="4" CssClass="mGridTesoreria" DataKeyNames="codgradodocente"
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
                 <asp:GridView ID="GridAsesor" runat="server" CellPadding="4" DataKeyNames="codproyectosede" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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

    <table border="0" align="" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;" >
        <tr>
            <td>Señor docente haga un relato en el que describa el proceso en su institución para conformar el grupo de investigación y las características del grupo. 
Explique cuáles fueron los motivos que lo llevaron a participar en Ciclón y de qué forma contribuye a su práctica docente.

            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtRelato" runat="server" TextMode="MultiLine" Columns="125" Rows="5" ></asp:TextBox>
            </td>
        </tr>
    </table>
</fieldset>

    <center>
        <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button runat="server" ID="btnEditar" CssClass="btn btn-success" Text="Editar" Visible="false" OnClick="btnEditar_Click" />
        <asp:Label id="lblCodBitacora" Visible="false" runat="server"></asp:Label>
         </center>
</div>

     
<!--Grid Bitacoras-->
       <div id="tablabitacoras">
            <asp:UpdatePanel runat="server" ID="UpdatePanel14" UpdateMode="Conditional">
                <ContentTemplate>
                    Asesores: 
                    <asp:DropDownList runat="server" ID="dropAsesores" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropAsesores_SelectedIndexChanged" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropAsesores" runat="server" ErrorMessage="Seleccione el asesor"
                        Text="*" Display="None" ControlToValidate="dropAsesores" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVdropAsesores"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
           <br />
           <asp:GridView ID="GridBitacoras" runat="server" CellPadding="4"  DataKeyNames="codbitacora"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen Bitácoras para este asesor."
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codbitacora" HeaderText="codbitacora" >
                            <ItemStyle  HorizontalAlign="Left" />
                        </asp:BoundField>
                           <asp:BoundField DataField="codproyectosede" HeaderText="codproyectosede" >
                            <ItemStyle  HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomasesor" HeaderText="Asesor">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="departamento" HeaderText="Departamento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="municipio" HeaderText="Municipio">
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
                           <asp:BoundField DataField="fechacreacion" HeaderText="Fecha creación">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       
                          <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lknEditar" CssClass="btn btn-success" OnClick="lknEditar_Click">Ver</asp:LinkButton><br /><br />
                                <%--<asp:LinkButton runat="server" ID="lknEvidencias" CssClass="btn btn-primary" OnClick="lknEvidencias_Click">Evidencias</asp:LinkButton>--%>
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

