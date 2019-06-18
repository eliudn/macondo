<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiespaciodeapropiacioneditar.aspx.cs" Inherits="confiespaciodeapropiacioneditar" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    
    <asp:Label runat="server" ID="lblCodSede" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblEstrategia" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblMomento" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodUsuario" Visible="false" ></asp:Label>

<div
     id="mensaje" runat="server"></div><br /><br />
<h2 >Editar Ferias Municipales</h2>
     <asp:Label ID="lblRealizado" CssClass="TrueGrupo" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblError" CssClass="ErrorGrupo" runat="server" Visible="false"></asp:Label>
     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
   <ContentTemplate>
      
<div id="ver">
<fieldset>
<legend>Ferias Municipales</legend>
    
    
    <asp:Label ID="lblDatos" runat="server" Visible="true"></asp:Label>
     <asp:Label ID="lblCodProyectoSede" runat="server" Visible="false"></asp:Label>
      <table>
           <tr>
              <td>
                 
              </td>
          </tr>

          <td>
                            <asp:TextBox ID="codigo" runat="server" CssClass="TextBox" Visible="false"></asp:TextBox>
                         </td>

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
                         <%--<td>Municipio:</td>--%>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" Visible="false">
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
                        <%--<td>Institución:</td>--%>
                        <td>
                             <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" Visible="false">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropInstituciones" CssClass="TextBox" ></asp:DropDownList>
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
                         <%--<td>Sede:</td>--%>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" Visible="false">
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
                         <%--<td>Red Temática:</td>--%>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="false">
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
                  
          </table>

    <fieldset>
        <legend>Municipios</legend>
           <center> 
               <%--<asp:Button visible="false" runat="server" ID="btnAgregarEstudiante" CssClass="btn btn-success" Text="Agregar estudiante" Onclick="btnAgregarEstudiante_Click" />--%> 
               <asp:Label runat="server" id="lblCodGrupoInvestigacion" Visible="false"></asp:Label>
           </center>
                    <br />
                     <asp:GridView ID="GridMunicipio" runat="server" CellPadding="4" DataKeyNames="coddepartamento" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Left" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  AutoGenerateColumns="false" Style="margin: 0 auto" 
                        GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="coddepartamento" HeaderText="coddepartamento" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod" HeaderText="codmunicipio" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Center" Width="120px" CssClass="ocultarcell"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                   
                            
                           
                            <asp:TemplateField>
                                <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkseleccionartodo" AutoPostBack="true" OnCheckedChanged="chkseleccionartodo_Click" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListEstudiante" />
                                </ItemTemplate>
                             </asp:TemplateField>
                       <asp:TemplateField ShowHeader="False">
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
            <td>
                <asp:Button runat="server" ID="btnSeleccionarEstudiantes" Visible="true" CssClass="btn btn-danger" Text="Agregar Municipios" OnClick="btnSeleccionarEstudiantes_Click" />               
            </td>
                             </td></tr></table>

        <fieldset>
         <legend>Municipios Cargados</legend>  
            <table align="center">
                <tr>
                    <td>
                          <fieldset>
                             <legend>Municipos cargados para la Feria Municipal</legend>  
                              <asp:GridView ID="GridSeleccionMunicipios" runat="server" CellPadding="4" CssClass="mGridTesoreria" DataKeyNames="coddepartamento" UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  Style="margin: 0 auto" AutoGenerateColumns="false"
                        GridLines="None"  >
                                <Columns>
                                    <asp:BoundField DataField="coddepartamento" HeaderText="Cod. Departamento" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="cod" HeaderText="Cod. Municipio" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo" HeaderStyle-CssClass="ocultarcell" ><ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>  
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre Municipio" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>                                    
                                
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEliminarMunicipioFeriaMunicipal" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px"  OnClick="lnkEliminarMunicipioFeriaMunicipal_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción?')){ return false; };" />  
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
                            
                            </fieldset>
                    </td>
                   
                </tr>
            </table>
         </fieldset>

        <fieldset>
        <legend>Carga de grupos</legend>
        <table>
            <tr>
                <td>Municipio</td>
                <td>
                    <asp:DropDownList runat="server" ID="dropMunicipiosSedes" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropMunicipio_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                 <td>Institución</td>
                <td>
                    <asp:DropDownList runat="server" ID="dropInstitucionesGrupos" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropInstituciones_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Sede</td>
                <td>
                    <asp:DropDownList runat="server" ID="dropSedesGrupos" CssClass="TextBox"></asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lnkBuscarGrupos" CssClass="btn btn-primary" OnClick="lnkBuscarGrupos_Click">Buscar</asp:LinkButton>
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridGrupos" runat="server" CellPadding="4" DataKeyNames="codigo" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                             <asp:BoundField DataField="codigo" HeaderText="codgrupoinvestigacion" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="municipio"  HeaderText="Municipio" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="institucion"  HeaderText="Institución" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sede"  HeaderText="Sede" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombregrupo"  HeaderText="Grupo Investigación" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                         
                            <asp:TemplateField>
                                <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkseleccionartodogrupo" AutoPostBack="true" OnCheckedChanged="chkseleccionartodogrupo_Click" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListGrupo" />
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

        <center>
            <table Width="100%" align="center">
            <tr>          
                <td>
                    <asp:Button runat="server" ID="lnkAgregarGrupo" Visible="false" CssClass="btn btn-success" Text="Agregar Grupo" OnClick="lnkAgregarGrupo_Click" />               
                </td>
            </tr>
        </table>
        </center>

    </fieldset>

    <fieldset>
        <legend>Selección de Grupos de investigación</legend>

        <asp:GridView ID="GridSeleccionGrupos" runat="server" DataKeyNames="codproyectosede" CellPadding="3" AutoGenerateColumns="false" style="margin:0 auto; width:100%"
            ForeColor="#333333" GridLines="None" onrowdatabound="GridSeleccionGrupos_RowDataBound" onrowdeleting="GridSeleccionGrupos_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="codferiamunicipal" HeaderText="codferiamunicipal" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="codproyectosede" HeaderText="codproyectosede" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="codigo" HeaderText="codgrupoinvestigacion" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="municipio" HeaderText="Municipio" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="institucion" HeaderText="Institución" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="sede" HeaderText="Sede" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="grupo" HeaderText="Grupos de investigación" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                                     <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                                     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteGrupo_Click" />
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

    </fieldset>

    <fieldset>
         <legend>Datos Especificos</legend>  
            <table>

<tr>
                         <td>Nombre de la Feria</td>
                         <td>
                             <asp:TextBox ID="nombreferiamunicipal" runat="server" CssClass="TextBox"></asp:TextBox>
                            <%--<input type="text" id="nombreferiamunicipal" name="nombreferiamunicipal" class="width-100 TextBox" />--%> 
                         </td>
                     </tr>

                     <tr>
                         <td>Número de Asistentes</td>
                         <td>
                            <asp:TextBox ID="numeroasistentes" runat="server" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>

                     <tr>
                         <td>Número de Grupos</td>
                         <td>
                            <asp:TextBox ID="numerogrupos" runat="server" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>

                     <tr>
                         <td>Fecha de Realización</td>
                         <td>
                           <asp:TextBox ID="fechaelaboracion" runat="server" CssClass="TextBox" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="fechaelaboracion_CalendarExtender" runat="server" Enabled="True" TargetControlID="fechaelaboracion"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday">
                    </ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVfechaelaboracion" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="fechaelaboracion" ValidationGroup="Agregar" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" 
                        style="color: #FF0000"></asp:RegularExpressionValidator>    
                 <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" 
                        runat="server" Enabled="True" TargetControlID="REVfechaelaboracion" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>    
                    <asp:RequiredFieldValidator ID="RFVfechaelaboracion" runat="server" Display="None" ErrorMessage="Digite Fecha de Inicio del Periodo" 
                        ControlToValidate="fechaelaboracion" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVfechaelaboracion"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                         </td>
                     </tr>

                     <table>
       <%--<td width="15%">Horario de formación: </td>--%>
       <td width="0%">
            <td width="23%">
                <table width="100%">
                    <tr>
                        <td width="50%">Hora Inicial:</td>
                        <td width="100%">
                            <asp:DropDownList runat="server" ID="horaferia" CssClass="TextBox">
                                <asp:listitem value =""> Seleccione Hora </asp:listitem>
                                <asp:listitem value ="00:00"> 00:00 </asp:listitem>
                                <asp:listitem value ="00:15"> 00:15 </asp:listitem>
                                <asp:listitem value ="00:30"> 00:30 </asp:listitem>
                                <asp:listitem value ="00:45"> 00:45 </asp:listitem>

                                <asp:listitem value ="01:00"> 01:00 </asp:listitem>
                                <asp:listitem value ="01:15"> 01:15 </asp:listitem>
                                <asp:listitem value ="01:30"> 01:30 </asp:listitem>
                                <asp:listitem value ="01:45"> 01:45 </asp:listitem>

                                <asp:listitem value ="02:00"> 02:00 </asp:listitem>
                                <asp:listitem value ="02:15"> 02:15 </asp:listitem>
                                <asp:listitem value ="02:30"> 02:30 </asp:listitem>
                                <asp:listitem value ="02:45"> 02:45 </asp:listitem>

                                <asp:listitem value ="03:00"> 03:00 </asp:listitem>
                                <asp:listitem value ="03:15"> 03:15 </asp:listitem>
                                <asp:listitem value ="03:30"> 03:30 </asp:listitem>
                                <asp:listitem value ="03:45"> 03:45 </asp:listitem>

                                <asp:listitem value ="04:00"> 04:00 </asp:listitem>
                                <asp:listitem value ="04:15"> 04:15 </asp:listitem>
                                <asp:listitem value ="04:30"> 04:30 </asp:listitem>
                                <asp:listitem value ="04:45"> 04:45 </asp:listitem>

                                <asp:listitem value ="05:00"> 05:00 </asp:listitem>
                                <asp:listitem value ="05:15"> 05:15 </asp:listitem>
                                <asp:listitem value ="05:30"> 05:30 </asp:listitem>
                                <asp:listitem value ="05:45"> 05:45 </asp:listitem>

                                <asp:listitem value ="06:00"> 06:00 </asp:listitem>
                                <asp:listitem value ="06:15"> 06:15 </asp:listitem>
                                <asp:listitem value ="06:30"> 06:30 </asp:listitem>
                                <asp:listitem value ="06:45"> 06:45 </asp:listitem>

                                <asp:listitem value ="07:00"> 07:00 </asp:listitem>
                                <asp:listitem value ="07:15"> 07:15 </asp:listitem>
                                <asp:listitem value ="07:30"> 07:30 </asp:listitem>
                                <asp:listitem value ="07:45"> 07:45 </asp:listitem>

                                <asp:listitem value ="08:00"> 08:00 </asp:listitem>
                                <asp:listitem value ="08:15"> 08:15 </asp:listitem>
                                <asp:listitem value ="08:30"> 08:30 </asp:listitem>
                                <asp:listitem value ="08:45"> 08:45 </asp:listitem>

                                <asp:listitem value ="09:00"> 09:00 </asp:listitem>
                                <asp:listitem value ="09:15"> 09:15 </asp:listitem>
                                <asp:listitem value ="09:30"> 09:30 </asp:listitem>
                                <asp:listitem value ="09:45"> 09:45 </asp:listitem>

                                <asp:listitem value ="10:00"> 10:00 </asp:listitem>
                                <asp:listitem value ="10:15"> 10:15 </asp:listitem>
                                <asp:listitem value ="10:30"> 10:30 </asp:listitem>
                                <asp:listitem value ="10:45"> 10:45 </asp:listitem>

                                <asp:listitem value ="11:00"> 11:00 </asp:listitem>
                                <asp:listitem value ="11:15"> 11:15 </asp:listitem>
                                <asp:listitem value ="11:30"> 11:30 </asp:listitem>
                                <asp:listitem value ="11:45"> 11:45 </asp:listitem>

                                <asp:listitem value ="12:00"> 12:00 </asp:listitem>
                                <asp:listitem value ="12:15"> 12:15 </asp:listitem>
                                <asp:listitem value ="12:30"> 12:30 </asp:listitem>
                                <asp:listitem value ="12:45"> 12:45 </asp:listitem>

                                <asp:listitem value ="13:00"> 13:00 </asp:listitem>
                                <asp:listitem value ="13:15"> 13:15 </asp:listitem>
                                <asp:listitem value ="13:30"> 13:30 </asp:listitem>
                                <asp:listitem value ="13:45"> 13:45 </asp:listitem>

                                <asp:listitem value ="14:00"> 14:00 </asp:listitem>
                                <asp:listitem value ="14:15"> 14:15 </asp:listitem>
                                <asp:listitem value ="14:30"> 14:30 </asp:listitem>
                                <asp:listitem value ="14:45"> 14:45 </asp:listitem>

                                <asp:listitem value ="15:00"> 15:00 </asp:listitem>
                                <asp:listitem value ="15:15"> 15:15 </asp:listitem>
                                <asp:listitem value ="15:30"> 15:30 </asp:listitem>
                                <asp:listitem value ="15:45"> 15:45 </asp:listitem>

                                <asp:listitem value ="16:00"> 16:00 </asp:listitem>
                                <asp:listitem value ="16:15"> 16:15 </asp:listitem>
                                <asp:listitem value ="16:30"> 16:30 </asp:listitem>
                                <asp:listitem value ="16:45"> 16:45 </asp:listitem>

                                <asp:listitem value ="17:00"> 17:00 </asp:listitem>
                                <asp:listitem value ="17:15"> 17:15 </asp:listitem>
                                <asp:listitem value ="17:30"> 17:30 </asp:listitem>
                                <asp:listitem value ="17:45"> 17:45 </asp:listitem>

                                <asp:listitem value ="18:00"> 18:00 </asp:listitem>
                                <asp:listitem value ="18:15"> 18:15 </asp:listitem>
                                <asp:listitem value ="18:30"> 18:30 </asp:listitem>
                                <asp:listitem value ="18:45"> 18:45 </asp:listitem>

                                <asp:listitem value ="19:00"> 19:00 </asp:listitem>
                                <asp:listitem value ="19:15"> 19:15 </asp:listitem>
                                <asp:listitem value ="19:30"> 19:30 </asp:listitem>
                                <asp:listitem value ="19:45"> 19:45 </asp:listitem>

                                <asp:listitem value ="20:00"> 20:00 </asp:listitem>
                                <asp:listitem value ="20:15"> 20:15 </asp:listitem>
                                <asp:listitem value ="20:30"> 20:30 </asp:listitem>
                                <asp:listitem value ="20:45"> 20:45 </asp:listitem>

                                <asp:listitem value ="21:00"> 21:00 </asp:listitem>
                                <asp:listitem value ="21:15"> 21:15 </asp:listitem>
                                <asp:listitem value ="21:30"> 21:30 </asp:listitem>
                                <asp:listitem value ="21:45"> 21:45 </asp:listitem>

                                <asp:listitem value ="22:00"> 22:00 </asp:listitem>
                                <asp:listitem value ="22:15"> 22:15 </asp:listitem>
                                <asp:listitem value ="22:30"> 22:30 </asp:listitem>
                                <asp:listitem value ="22:45"> 22:45 </asp:listitem>

                                <asp:listitem value ="23:00"> 23:00 </asp:listitem>
                                <asp:listitem value ="23:15"> 23:15 </asp:listitem>
                                <asp:listitem value ="23:30"> 23:30 </asp:listitem>
                                <asp:listitem value ="23:45"> 23:45 </asp:listitem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>

       

              <td width="100%">
                  <table>
            <td width="50%">
                <table width="55%">                  
                    <tr>
                        <td width="50%">Hora Final: </td>
                        <td width="100%">
                            <asp:DropDownList runat="server" ID="horaferiafinal" CssClass="TextBox">
                                <asp:listitem value =""> Seleccione Hora </asp:listitem>
                                <asp:listitem value ="00:00"> 00:00 </asp:listitem>
                                <asp:listitem value ="00:15"> 00:15 </asp:listitem>
                                <asp:listitem value ="00:30"> 00:30 </asp:listitem>
                                <asp:listitem value ="00:45"> 00:45 </asp:listitem>

                                <asp:listitem value ="01:00"> 01:00 </asp:listitem>
                                <asp:listitem value ="01:15"> 01:15 </asp:listitem>
                                <asp:listitem value ="01:30"> 01:30 </asp:listitem>
                                <asp:listitem value ="01:45"> 01:45 </asp:listitem>

                                <asp:listitem value ="02:00"> 02:00 </asp:listitem>
                                <asp:listitem value ="02:15"> 02:15 </asp:listitem>
                                <asp:listitem value ="02:30"> 02:30 </asp:listitem>
                                <asp:listitem value ="02:45"> 02:45 </asp:listitem>

                                <asp:listitem value ="03:00"> 03:00 </asp:listitem>
                                <asp:listitem value ="03:15"> 03:15 </asp:listitem>
                                <asp:listitem value ="03:30"> 03:30 </asp:listitem>
                                <asp:listitem value ="03:45"> 03:45 </asp:listitem>

                                <asp:listitem value ="04:00"> 04:00 </asp:listitem>
                                <asp:listitem value ="04:15"> 04:15 </asp:listitem>
                                <asp:listitem value ="04:30"> 04:30 </asp:listitem>
                                <asp:listitem value ="04:45"> 04:45 </asp:listitem>

                                <asp:listitem value ="05:00"> 05:00 </asp:listitem>
                                <asp:listitem value ="05:15"> 05:15 </asp:listitem>
                                <asp:listitem value ="05:30"> 05:30 </asp:listitem>
                                <asp:listitem value ="05:45"> 05:45 </asp:listitem>

                                <asp:listitem value ="06:00"> 06:00 </asp:listitem>
                                <asp:listitem value ="06:15"> 06:15 </asp:listitem>
                                <asp:listitem value ="06:30"> 06:30 </asp:listitem>
                                <asp:listitem value ="06:45"> 06:45 </asp:listitem>

                                <asp:listitem value ="07:00"> 07:00 </asp:listitem>
                                <asp:listitem value ="07:15"> 07:15 </asp:listitem>
                                <asp:listitem value ="07:30"> 07:30 </asp:listitem>
                                <asp:listitem value ="07:45"> 07:45 </asp:listitem>

                                <asp:listitem value ="08:00"> 08:00 </asp:listitem>
                                <asp:listitem value ="08:15"> 08:15 </asp:listitem>
                                <asp:listitem value ="08:30"> 08:30 </asp:listitem>
                                <asp:listitem value ="08:45"> 08:45 </asp:listitem>

                                <asp:listitem value ="09:00"> 09:00 </asp:listitem>
                                <asp:listitem value ="09:15"> 09:15 </asp:listitem>
                                <asp:listitem value ="09:30"> 09:30 </asp:listitem>
                                <asp:listitem value ="09:45"> 09:45 </asp:listitem>

                                <asp:listitem value ="10:00"> 10:00 </asp:listitem>
                                <asp:listitem value ="10:15"> 10:15 </asp:listitem>
                                <asp:listitem value ="10:30"> 10:30 </asp:listitem>
                                <asp:listitem value ="10:45"> 10:45 </asp:listitem>

                                <asp:listitem value ="11:00"> 11:00 </asp:listitem>
                                <asp:listitem value ="11:15"> 11:15 </asp:listitem>
                                <asp:listitem value ="11:30"> 11:30 </asp:listitem>
                                <asp:listitem value ="11:45"> 11:45 </asp:listitem>

                                <asp:listitem value ="12:00"> 12:00 </asp:listitem>
                                <asp:listitem value ="12:15"> 12:15 </asp:listitem>
                                <asp:listitem value ="12:30"> 12:30 </asp:listitem>
                                <asp:listitem value ="12:45"> 12:45 </asp:listitem>

                                <asp:listitem value ="13:00"> 13:00 </asp:listitem>
                                <asp:listitem value ="13:15"> 13:15 </asp:listitem>
                                <asp:listitem value ="13:30"> 13:30 </asp:listitem>
                                <asp:listitem value ="13:45"> 13:45 </asp:listitem>

                                <asp:listitem value ="14:00"> 14:00 </asp:listitem>
                                <asp:listitem value ="14:15"> 14:15 </asp:listitem>
                                <asp:listitem value ="14:30"> 14:30 </asp:listitem>
                                <asp:listitem value ="14:45"> 14:45 </asp:listitem>

                                <asp:listitem value ="15:00"> 15:00 </asp:listitem>
                                <asp:listitem value ="15:15"> 15:15 </asp:listitem>
                                <asp:listitem value ="15:30"> 15:30 </asp:listitem>
                                <asp:listitem value ="15:45"> 15:45 </asp:listitem>

                                <asp:listitem value ="16:00"> 16:00 </asp:listitem>
                                <asp:listitem value ="16:15"> 16:15 </asp:listitem>
                                <asp:listitem value ="16:30"> 16:30 </asp:listitem>
                                <asp:listitem value ="16:45"> 16:45 </asp:listitem>

                                <asp:listitem value ="17:00"> 17:00 </asp:listitem>
                                <asp:listitem value ="17:15"> 17:15 </asp:listitem>
                                <asp:listitem value ="17:30"> 17:30 </asp:listitem>
                                <asp:listitem value ="17:45"> 17:45 </asp:listitem>

                                <asp:listitem value ="18:00"> 18:00 </asp:listitem>
                                <asp:listitem value ="18:15"> 18:15 </asp:listitem>
                                <asp:listitem value ="18:30"> 18:30 </asp:listitem>
                                <asp:listitem value ="18:45"> 18:45 </asp:listitem>

                                <asp:listitem value ="19:00"> 19:00 </asp:listitem>
                                <asp:listitem value ="19:15"> 19:15 </asp:listitem>
                                <asp:listitem value ="19:30"> 19:30 </asp:listitem>
                                <asp:listitem value ="19:45"> 19:45 </asp:listitem>

                                <asp:listitem value ="20:00"> 20:00 </asp:listitem>
                                <asp:listitem value ="20:15"> 20:15 </asp:listitem>
                                <asp:listitem value ="20:30"> 20:30 </asp:listitem>
                                <asp:listitem value ="20:45"> 20:45 </asp:listitem>

                                <asp:listitem value ="21:00"> 21:00 </asp:listitem>
                                <asp:listitem value ="21:15"> 21:15 </asp:listitem>
                                <asp:listitem value ="21:30"> 21:30 </asp:listitem>
                                <asp:listitem value ="21:45"> 21:45 </asp:listitem>

                                <asp:listitem value ="22:00"> 22:00 </asp:listitem>
                                <asp:listitem value ="22:15"> 22:15 </asp:listitem>
                                <asp:listitem value ="22:30"> 22:30 </asp:listitem>
                                <asp:listitem value ="22:45"> 22:45 </asp:listitem>

                                <asp:listitem value ="23:00"> 23:00 </asp:listitem>
                                <asp:listitem value ="23:15"> 23:15 </asp:listitem>
                                <asp:listitem value ="23:30"> 23:30 </asp:listitem>
                                <asp:listitem value ="23:45"> 23:45 </asp:listitem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
                      </table>
                  </td>
           </td>
        </table>

                </table>

            </table>
   </fieldset>

    
 </fieldset>

</div>

       <table align="center"><tr>
           <td> <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" /></td>
           <td>
               <asp:Button runat="server" ID="btnAgregarEstudiantes" ValidationGroup="addestudiantes" Visible="true" CssClass="btn btn-success" Text="Actualizar Feria Municipal" OnClick="btnAgregarEstudiantes_Click" />
           </td>
              </tr></table>

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

