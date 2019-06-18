<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseregistro.aspx.cs" Inherits="lineabaseregistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
            // alert("Si este es");
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
                 $('#MainContent_dropInstitucion').filterByText($('#textbox'), false);
                 $("#MainContent_dropInstitucion option").click(function () {
                     alert(1);
                 });
             });

      
         }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Registro de Línea base</h2><br />

    <table align="center">
        <tr>
          
            <%-- <td>
                 <asp:Button ID="btnIniciarDisponibilidadTIC" Visible="true" runat="server" CssClass="btn btn-primary" Text="03 - Disponibilidad, acceso y uso TIC" OnClick="btnIniciarDisponibilidadTIC_Onclick" />
            </td>--%>
           
            <td>
                 <asp:Button ID="btnIniciarPerfilDocente" Visible="true" runat="server" CssClass="btn btn-primary" Text="05 - Perfil Docente" OnClick="btnIniciarPerfilDocente_Onclick" />
            </td>
             <td>
                 <asp:Button ID="btnIniciarAutopercepcion" Visible="true" runat="server" CssClass="btn btn-primary" Text="04 - Autopercepción Docente" OnClick="btnIniciarAutopercepcion_Onclick" />
            </td>
            <td>
                 <asp:Button ID="btnIniciarEstudiante" Visible="true" runat="server" CssClass="btn btn-primary" Text="06 - Estudiantes" OnClick="btnIniciarEstudiante_Onclick" />
            </td>
        </tr>
    </table>

     <asp:Panel ID="Paneltime" runat="server" Visible="false">
        <table class="cajafiltro">
            <tr>
                <td>Tiempo para la ejecución del instrumento: 
                </td>
                <td>

                    <div class="btn btn-danger" style="width: 150px;float:right;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="Reloj" runat="server" Interval="1000" OnTick="Reloj_Tick"></asp:Timer>
                                <strong>
                                    <asp:Label ID="lblReloj" runat="server" Text=""></asp:Label>
                                 </strong>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </td>
            </tr>

        </table>
    </asp:Panel>

    <asp:Label ID="lblCodDocenteAsesor" runat="server" Visible="false"></asp:Label>
     <asp:Label ID="lblCodDANE" runat="server" Visible="false"></asp:Label>
    
    

    <!-- Instrumento 04 Linea Base Autopercepción docentes  CTEi-INV-NTICS  -->
    <asp:Panel ID="PanelAutopercepcionDocentes" runat="server" Visible="false">
        <h2 style="text-align:center"><%--Instrumento No. 04 <br />--%>
            Formulario de autopercepción sobre Competencias pedagógicas de los docentes en: CTeI, Uso de TICs e Investigación</h2>
        <fieldset>
            <legend>Agregrar Autopercepción docentes</legend>
        
        <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                   <b> 1.	Técnicas y tecnológicas </b>
                </td>
            </tr>
            <tr>
                <td>
                    1.1	Reconoce un amplio espectro de herramientas tecnológicas y algunas formas de integrarlas a la práctica educativa.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta1" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
             </table>
            <table><tr><td><asp:Button ID="btnPrimerGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%">
            <tr>
                <td><hr /></td>
            </tr>
            <tr>
                <td>
                 1.2. Utiliza herramientas tecnológicas en los procesos educativos, de acuerdo a su rol, área de formación, nivel y contexto en el que se desempeña.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta2" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                   </table>
            <table><tr><td><asp:Button ID="btnSegundoGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td><hr /></td>
            </tr>
            <tr>
                <td>
                    1.3. Aplica el conocimiento de una amplia variedad de tecnologías en el diseño de ambientes de aprendizaje  innovadores y para plantear soluciones a problemas
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta3" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            </table>
            <table><tr><td><asp:Button ID="btnTercerGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnTercerGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td><hr /></td>
            </tr>
            <tr>
                <td>
                    <b>2.	Pedagógicas </b>
                </td>
                </tr>
            <tr>
                <td>
                    2.1. Identifica nuevas estrategias y metodologías mediadas por las TIC, como  herramienta para su desempeño profesional.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                    <asp:GridView ID="GridPregunta4" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb4" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnCuartoGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnCuartoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    2.2. Propone proyectos y estrategias de aprendizaje con el uso de TIC para potenciar el aprendizaje de los estudiantes.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                    <asp:GridView ID="GridPregunta5" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb5" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnQuintoGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnQuintoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    2.3. Lidera experiencias significativas que involucran ambientes de aprendizaje diferenciados de acuerdo a las necesidades e intereses propias y de los estudiante.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta6" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb6" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnSextoGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSextoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <b>3.	Comunicativas  </b>
                </td>
            </tr>
            <tr>
                <td>
                    3.1. Emplea diversos canales y lenguajes propios de las TIC para comunicarse con la comunidad educativa.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta7" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb7" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnSeptimoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSeptimoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                    <asp:GridView ID="GridPregunta8" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb8" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnOctavoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnOctavoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta9" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb9" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>

            <tr>
                <td>
                    <hr />
                </td>
            </tr>
                   </table>
            <table><tr><td><asp:Button ID="btnNovenoGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnNovenoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                   <b> 4.	Gestión escolar</b>
                </td>
            </tr>
            <tr>
                <td>
                    4.1. Organiza actividades propias de su quehacer profesional con el uso de las TIC.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta10" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb10" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnDecimoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnDecimoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    4.2. Integra las TIC en procesos de dinamización de las gestiones directiva, académica, administrativa y comunitaria de su institución.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta11" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb11" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnDecimoPrimerGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnDecimoPrimerGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    4.3. Propone y lidera acciones para optimizar procesos integrados de   la gestión escolar.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta12" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb12" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnDecimoSegundoGuardar04" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnDecimoSegundoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                  <b>  5.	Investigativas</b>
                </td>
            </tr>
            <tr>
                <td>
                    5.1. Usa las TIC para hacer registro y seguimiento de lo que vive y observa en su práctica, su contexto y el de sus estudiantes.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta13" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb13" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnDecimoTercerGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnDecimoTercerGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    5.2. Construye estrategias educativas innovadoras que incluyen la generación colectiva de conocimientos.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                    <asp:GridView ID="GridPregunta14" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb14" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="btnDecimoCuartoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnDecimoCuartoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    5.3. Construye estrategias educativas innovadoras que incluyen la generación colectiva de conocimientos.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta15" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb15" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
                  </table>
            <table><tr><td><asp:Button ID="DecimoQuintoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnDecimoQuintoGuardar04_Click" /></td></tr></table>
             <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                   <b> 6.	Éticas</b>
                </td>
            </tr>
            <tr>
                <td>
                    6.1 Comprender las oportunidades, implicaciones y riesgos de la utilización de TIC para mi práctica docente y el desarrollo humano.
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-weight:bold;text-align:center">1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</p>
                     <asp:GridView ID="GridPregunta16" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="100%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Estándar General" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb16" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="btnRegresarCaracterizacion" runat="server" Text="Regresar"  
                             CssClass="btn btn-primary" onclick="btnRegresarCaracterizacion_Click"/>
                    <asp:Button ID="btnGuardarAutopercepcion" runat="server" Text="Guardar"   
                             CssClass="btn btn-success" onclick="btnGuardarAutopercepcion_Click"/>
                </td>
            </tr>
        </table>
      </fieldset>
    </asp:Panel>

    <!-- Instrumento 05 Perfil, formación y experiencia de los/las docentes vinculados al proyecto  en TIC, CTeI e investigación -->
    <asp:Panel ID="PanelPerfilDocente" runat="server" Visible="false">
        <h2>Perfil, formación y experiencia de los/las docentes vinculados al proyecto  en TIC, CTeI e investigación</h2>

        <fieldset>
        <legend>Datos del Asesor</legend>
        <table>
                <tr>
                    <td>
                        Seleccione el Asesor
                    </td>
                    <td>
                        <asp:DropDownList ID="dropAsesor" runat="server" CssClass="TextBox" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropAsesor" runat="server" Display="None" ErrorMessage="Seleccione el Asesor"
                            ControlToValidate="dropAsesor" Text="*" ValidationGroup="addPerfil"  InitialValue="Seleccione"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVdropAsesor"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
            </table>
    </fieldset>

        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" >
          
            <tr>
                <td>
                    <b>1. Clase de funcionario:</b>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkClaseFuncionario" runat="server" RepeatColumns="1" CssClass="TextBox">
                          <asp:ListItem>Directivo docente</asp:ListItem>
                          <asp:ListItem>Docentes (no incluya educadores especiales ni etnoeducadores)  </asp:ListItem>
                          <asp:ListItem>Docentes de educación especial </asp:ListItem>
                          <asp:ListItem>Docentes de etnoeducación</asp:ListItem>
                          <asp:ListItem>Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales</asp:ListItem>
                          <asp:ListItem>Médicos, odontólogos, nutricionistas, terapeutas y enfermeros </asp:ListItem>
                          <asp:ListItem>Administrativos (de apoyo y personal de servicios generales)</asp:ListItem>
                          <asp:ListItem>Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.)</asp:ListItem>
                          <asp:ListItem>Tutores</asp:ListItem>
                          <asp:ListItem>Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)</asp:ListItem>
                          <asp:ListItem>Auxiliar de aula</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <b>2.	Ultimo nivel de formación obtenido</b>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GridFormacionDocente" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="titulo" HeaderText="Título" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <HeaderTemplate>Año</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:TextBox id="txtAnioFormacion" CssClass="TextBox" runat="server" Width="50"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                   <b> 3.	Nivel educativo en el que trabaja</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkNivelEducativoDocente" runat="server" RepeatColumns="3">
                        <asp:ListItem>Preescolar</asp:ListItem>
                        <asp:ListItem>Básica Primaria</asp:ListItem>
                        <asp:ListItem>Básica Secundaria y Media</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            </table>
        <table><tr><td><asp:Button ID="btnPrimerGuardar05" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar05_Click" /></td></tr></table>
        <table>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                   <b> 4.	Áreas de enseñanza  en las que desarrolla la docencia</b>
                </td>
            </tr>
            <tr>
                <td>
                  <i>  Para el carácter académico</i>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkAreaEnsenianzaAcademico" runat="server" RepeatColumns="3">
                        <asp:ListItem>Todas las áreas</asp:ListItem>
                        <asp:ListItem>Ciencias naturales y educación ambiental</asp:ListItem>
                        <asp:ListItem>Ciencias sociales, historia, geografía, constitución política y democracia</asp:ListItem>
                        <asp:ListItem>Educación artística</asp:ListItem>
                        <asp:ListItem>Educación ética y en valores humanos</asp:ListItem>
                        <asp:ListItem>Educación física, recreación y deportes</asp:ListItem>
                        <asp:ListItem>Educación religiosa</asp:ListItem>
                        <asp:ListItem>Humanidades, lengua castellana e idiomas extranjeros</asp:ListItem>
                        <asp:ListItem>Matemáticas</asp:ListItem>
                        <asp:ListItem>Tecnología e informática</asp:ListItem>
                        <asp:ListItem>Ciencias económicas</asp:ListItem>
                        <asp:ListItem>Ciencias políticas</asp:ListItem>
                        <asp:ListItem>Filosofía</asp:ListItem>
                        <asp:ListItem>Otra, ¿cuál?</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:TextBox ID="txtAreaEnsenianzaAcademico" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  Para el carácter técnico
                </td>
            </tr>
            <tr>
                <td>
                     <i> Agropecuario</i>
                    <asp:CheckBoxList ID="chkAreaEnsenianzaTecnico" runat="server" RepeatColumns="1">
                        <asp:ListItem>Agrícola</asp:ListItem>
                        <asp:ListItem>Pecuario</asp:ListItem>
                        <asp:ListItem>Otra ¿cuál?</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaTecnico" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                <i>    Comercial y servicios</i>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkAreaEnsenianzaComercialServ" runat="server" RepeatColumns="2">
                        <asp:ListItem>Contabilidad</asp:ListItem>
                        <asp:ListItem>Finanzas</asp:ListItem>
                        <asp:ListItem>Gestión</asp:ListItem>
                        <asp:ListItem>Administración</asp:ListItem>
                        <asp:ListItem>Ambiental</asp:ListItem>
                        <asp:ListItem>Salud</asp:ListItem>
                        <asp:ListItem>Otra ¿cuál?</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaComercialServ" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <i>  Industrial</i>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkAreaEnsenianzaIndustrial" runat="server" RepeatColumns="4">
                        <asp:ListItem>Electricidad</asp:ListItem>
                        <asp:ListItem>Electrónica</asp:ListItem>
                        <asp:ListItem>Mecánica industrial</asp:ListItem>
                        <asp:ListItem>Mecánica automotriz</asp:ListItem>
                        <asp:ListItem>Metalistería</asp:ListItem>
                        <asp:ListItem>Metalmecánica</asp:ListItem>
                         <asp:ListItem>Ebanistería</asp:ListItem>
                         <asp:ListItem>Fundición</asp:ListItem>
                         <asp:ListItem>Construcciones civiles</asp:ListItem>
                         <asp:ListItem>Diseño mecánico</asp:ListItem>
                         <asp:ListItem>Diseño gráfico</asp:ListItem>
                         <asp:ListItem>Diseño arquitectónico</asp:ListItem>
                        <asp:ListItem>Otra ¿cuál?</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaIndustrial" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <i>  Pedagógica</i>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaPedagogica" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <i>  Promoción social</i>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaPromocionSocial" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <i>  Informática</i>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaInformatica" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <i>  Otra, ¿cuál?</i>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaEnsenianzaOtra" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table><tr><td><asp:Button ID="btnSegundoGuardar05" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSegundoGuardar05_Click" /></td></tr></table>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" >
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                  <b>  5.	¿Ha recibido formación específica investigación?</b>
                </td>
            </tr>
             <tr>
                <td align="center">
                    <asp:GridView ID="GridFormacionInvestigacionDocente" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />
                            <asp:TemplateField >
                                <HeaderTemplate>Tipo</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:DropDownList ID="dropFomacionInvesTipo" runat="server">
                                       <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Curso Corto</asp:ListItem>
                                      <asp:ListItem>Diplomado</asp:ListItem>
                                      <asp:ListItem>Especialización</asp:ListItem>
                                      <asp:ListItem>Pregrado</asp:ListItem>
                                      <asp:ListItem>Maestría y Doctorado</asp:ListItem>
                                      <asp:ListItem>Otro</asp:ListItem>
                                     
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Nombre</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNomFormacionInvesTipo" runat="server" CssClass="TextBox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Duración (horas)</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDuracionFormacionInvesTipo" runat="server" CssClass="TextBox" Width="80"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Año</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnioFormacionInvesTipo" runat="server" CssClass="TextBox" Width="50" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Modalidad</HeaderTemplate>
                                <ItemTemplate>
                                     <asp:DropDownList ID="dropFomacionInvesModalidad" runat="server">
                                          <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Presencial</asp:ListItem>
                                      <asp:ListItem>Virtual</asp:ListItem>
                                          
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <b> 5.1	Esta formación contribuyó a cambiar sus práctica pedagógicas?  </b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbContribuyoPracticaPedago" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtContribuyoPracticaPedago" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                   <b> 6.	Ha participado en proyecto de investigación dentro de la Institución Educativa  </b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbProyectoInvestigacionIE" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Cuales?
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtProyectoInvestigacionIE" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Modalidad:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkModalidadProyectoInvgestigacion" runat="server" RepeatColumns="3">
                        <asp:ListItem>De aula</asp:ListItem>
                        <asp:ListItem>Transversales</asp:ListItem>
                        <asp:ListItem>Interdisciplinarios</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                   <b> 7.	Ha participado en proyecto de investigación Fuera de la Institución Educativa  </b>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:RadioButtonList ID="rbProyectoInvestigacionFueraIE" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Cuales?
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtProyectoInvestigacionFueraIE" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                 <b>   8.	Ha realizado proyecto e investigación con niños, Niñas y  Jóvenes como práctica pedagógica?</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbProyectoNiniosNinias" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td>
                    Cuales?
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtProyectoNiniosNinias" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    Modalidad:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkProyectoNiniosNinias" runat="server"  RepeatColumns="3">
                        <asp:ListItem>De aula</asp:ListItem>
                        <asp:ListItem>Transversales</asp:ListItem>
                        <asp:ListItem>Interdisciplinarios</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
             </table>
        <table><tr><td><asp:Button ID="btnTercerGuardar05" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnTercerGuardar05_Click" /></td></tr></table>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" >
            <tr>
                <td>
                  <b>  9.	Ha recibido formación específica en Ciencia, Tecnología e Innovación?</b>
                </td>
            </tr>
            <tr>
               <td align="center">
                    <asp:GridView ID="GridFormacionCienciaTecnoInno" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />
                            <asp:TemplateField >
                                <HeaderTemplate>Tipo</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:DropDownList ID="dropFomacionCienciaTecnoInno" runat="server">
                                       <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Curso Corto</asp:ListItem>
                                      <asp:ListItem>Diplomado</asp:ListItem>
                                      <asp:ListItem>Especialización</asp:ListItem>
                                      <asp:ListItem>Pregrado</asp:ListItem>
                                      <asp:ListItem>Maestría y Doctorado</asp:ListItem>
                                      <asp:ListItem>Otro</asp:ListItem>
                                     
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Nombre</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNomFormacionCienciaTecnoInno" runat="server" CssClass="TextBox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Duración (horas)</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDuracionFormacionCienciaTecnoInno" runat="server" CssClass="TextBox" Width="80"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Año</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnioFormacionCienciaTecnoInno" runat="server" CssClass="TextBox" Width="50" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Modalidad</HeaderTemplate>
                                <ItemTemplate>
                                     <asp:DropDownList ID="dropFomacionCienciaTecnoInnoMod" runat="server">
                                          <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Presencial</asp:ListItem>
                                      <asp:ListItem>Virtual</asp:ListItem>
                                         
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
              <tr>
                <td>
                    <b> 9.1	Esta formación contribuyó a cambiar sus práctica pedagógicas?   </b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbFormacionPracticaPedagogica" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Cómo
                    <asp:TextBox ID="txtFormacionPracticaPedagogica" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <b>10.	Ha recibido formación específica en NTICs?</b>
                </td>
            </tr>
             <tr>
               <td align="center">
                    <asp:GridView ID="GridFormacionNTICs" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />
                            <asp:TemplateField >
                                <HeaderTemplate>Tipo</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:DropDownList ID="dropFormacionNTICs" runat="server">
                                       <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Curso Corto</asp:ListItem>
                                      <asp:ListItem>Diplomado</asp:ListItem>
                                      <asp:ListItem>Especialización</asp:ListItem>
                                      <asp:ListItem>Pregrado</asp:ListItem>
                                      <asp:ListItem>Maestría y Doctorado</asp:ListItem>
                                      <asp:ListItem>Otro</asp:ListItem>
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Nombre</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNomFormacionNTICs" runat="server" CssClass="TextBox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Duración (horas)</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDuracionFormacionNTICs" runat="server" CssClass="TextBox" Width="80"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Año</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnioFormacionNTICs" runat="server" CssClass="TextBox" Width="50" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Modalidad</HeaderTemplate>
                                <ItemTemplate>
                                     <asp:DropDownList ID="dropFormacionNTICsMod" runat="server">
                                          <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Presencial</asp:ListItem>
                                      <asp:ListItem>Virtual</asp:ListItem>
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
              <tr>
                <td>
                    <b> 10.1	Esta formación contribuyó a cambiar sus práctica pedagógicas?   </b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbFormacionNTICs" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Cómo
                    <asp:TextBox ID="txtFormacionNTICs" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRegresarAutopercepcion" runat="server" Text="Regresar"  
                             CssClass="btn btn-primary" Visible="false" onclick="btnRegresarAutopercepcion_Click"/>
                    <asp:Button ID="btnGuardarPerfilDocente" runat="server" Text="Guardar" ValidationGroup="addPerfil"   
                             CssClass="btn btn-success" onclick="btnGuardarPerfilDocente_Click"/>
                </td>
            </tr>
            </table>
    </asp:Panel>

    <!-- Instrumento 06  perfil estudiantes  -->

    <!-- Instrumento 06 - 1  perfil estudiantes grupos de investigación  -->
    <asp:Label ID="lblCodGradoDocenteInstrumento6" Visible="false" runat="server"></asp:Label>
    <asp:Label ID="lblCodSedeInstrumento6" Visible="false" runat="server"></asp:Label>
    <table align="center"><tr><td>
                    <asp:Button runat="server" Visible="false" ID="btnGrupoInvestigacion" CssClass="btn btn-danger" Text="Grupo de Investigación" OnClick="btnGrupoInvestigacion_Click" />
                    <asp:Button runat="server" ID="btnRedTematica" Visible="false" CssClass="btn btn-danger" Text="Red Temática" OnClick="btnRedTematica_Click" />
               </td></tr></table>
 <asp:Panel ID="PanelEstudiantes" runat="server" Visible="false">
         <h4>Estrategia No 1. Estrategia de acompañamiento y formación de los grupos de investigación siguiendo los lineamientos y la metodología del programa Ondas apoyado en herramientas virtuales</h4>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" >
             <tr>
                <td>
                    <b style="color:red">Para tener en cuenta:</b> Si existe un solo Grupo de Investigación para un grupo de Docentes, primeramente, un solo docente deberá ingresar el nombre del Grupo de Investigación, para que luego los demás docentes pueda escogerla en el listado.<br />
                </td>
            </tr>
            <tr>
                <td><br />
                    Si el grupo de investigación no aparece en el siguiente listado, por favor escoja la opción "Nuevo Grupo de Investigación" y digite el nombre en "Nombre del grupo de investigación"
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:DropDownList runat="server" ID="dropNombreGrupoInvestigacion" CssClass="TextBox" Visible="false"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                   <b> Nombre del grupo de investigación</b>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:TextBox ID="txtNomGrupoInvestigacion" runat="server" CssClass="TextBox" Width="300"></asp:TextBox>
                </td>
            </tr>
            </table>
        <fieldset>
            <legend> De los Estudiantes</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" border="0" >
                       <tr>
                     <td align="center" colspan="2">
                           <asp:GridView ID="GridEstudiantexDocente" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="70%" EmptyDataText="Docente no registra estudiantes en Grupo de Investigación" OnRowDataBound="GridEstudiantesxProceso_RowDataBound" OnRowDeleting="GridEstudiantesxProceso_RowDeleting"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="codestumatricula" HeaderText="codestumatricula"  />
                            <asp:BoundField DataField="nombrecompleto" HeaderText="Nombre estudiante"  />
                            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="sexo" HeaderText="Genero" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="grado" HeaderText="Grado" ItemStyle-HorizontalAlign="Center" />

                           <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png"><ItemStyle Width="20px" /></asp:CommandField>      
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Button ID="btnGuardarPrimero06GI" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardarPrimero06GI_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <b>B.	Los ítems que se describen a continuación deberán ser diligenciados por el docente acompañante y/o docente coinvestigador del grupo de investigación en el aula, </b>
                     </td>
                     </tr>
                 <tr>
                      <td colspan="2" >
                      <b> 1.  ¿En el Programa CIClÓN  se incluyen estudiantes con discapacidad o capacidades excepcionales?</b>
                     </td>
                     </tr>
                 <tr>
                     <td colspan="2">
                         <asp:RadioButtonList ID="rbValidarPregunta1Intrumento06" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbValidarPregunta1Intrumento06_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (pase a la pregunta No.3)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                     <asp:Panel ID="PanelPregunta2Instrumento06" runat="server" Visible="false">
                         <tr>
                           
                                 <td colspan="2">
                                   <b>  2.	Número de estudiantes del grupo de investigación con discapacidad o capacidades excepcionales, integrados* a la educación formal, según Género.</b>
                                     <br />
                                     Diligencie únicamente con cifras
                                 </td>
                             </tr>
                         <tr>
                             <td colspan="2">
                                  <table>
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Categoria
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con discapacidad
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadHom" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadMuj" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtTotalDiscapacidad" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con capacidades excepcionales
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtCapacidadExcepHom" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtCapacidadExcepMuj" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                           <td>
                                              <asp:TextBox ID="txtTotalCapacidadExcep" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>Total</td>
                                          <td>
                                              <asp:TextBox ID="txtTotalHom" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtTotalMuj" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                           </td>
                                          <td>
                                              <asp:Button ID="btnValidarSumInvDiscapacidad" Visible="false" runat="server" CssClass="btn btn-danger" Text="Calcular" OnClick="btnValidarSumInvDiscapacidad_Click" />
                                          </td>
                                      </tr>
                                  </table>
                             </td>
                           </tr>
                    </asp:Panel>
                 <tr>
                     <td colspan="2">
                         <b>3.	Número de estudiantes con discapacidad, integrados y no integrados que hacen parte del grupo de investigación, por categoría y Género. </b>
                          <br />
                                     Diligencie únicamente con cifras
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2" >
                         <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="60%">
                             <tr>
                                 <td rowspan="2" style="font-weight:bold;">
                                     categoría
                                 </td>
                                 <td colspan="3" style="font-weight:bold;" align="center">
                                     Integrados 
                                 </td>
                                  <td colspan="3" style="font-weight:bold;" align="center">
                                     No Integrados 
                                 </td>
                                  <td colspan="3" style="font-weight:bold;" align="center">
                                     Total 
                                 </td>
                                 </tr>
                             <tr>
                                 <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                                 <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                                  <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Auditiva 
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAuditivaHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Visual  
                                 </td>
                                    <td>
                                     <asp:TextBox ID="txtVisualHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtVisualHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisual" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Motora   
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotora" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Cognitiva    
                                 </td>
                                   <td>
                                     <asp:TextBox ID="txtCognitivaHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtCognitivaHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitiva" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Autismo     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAutismoHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Múltiple     
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleInte" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomNoInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujNoInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultiple" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Otra, ¿cuál?     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraHomInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtOtraHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujNoInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Total    
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Button ID="btnEstudianteDiscapacidad" CssClass="btn btn-danger" Visible="false" Text="Calcular" runat="server" />
                                 </td>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                       <b>  4.	¿En el grupo de investigación y las redes temáticas institucionales, se incluye población de grupos étnicos? </b>
                     </td>
                 </tr>
                 <tr>
                     <td colpan="2">
                          <asp:RadioButtonList ID="rbGrupoInvestigacionEtnicoInstru06" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbGrupoInvestigacionEtnicoInstru06_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (pase a la pregunta No.6)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelGrupoEtnicos" runat="server" Visible="false">
                     <tr>
                         <td>
                            <b> 5.	Número de estudiantes de grupos étnicos del grupo de investigación, según Género.</b>
                             <br />
                              Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                              <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="100%">
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Nombre del Grupo Etnico
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                  <tr>
                                      <td>
                                          Indígenas
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtIndigenaHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtIndigenaMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                           <asp:TextBox ID="txtIndigenaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                        Rom (gitanos)
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Afrocolombianos, afrodecendientes, negro o mulato.
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Raizal del archipiélago de San Andrés, Providencia y Santa Catalina
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRaizaHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                           <asp:TextBox ID="txtRaizaMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRaizaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Palenquero de San Basilio 
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Total 
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtTotalHomEtnico" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtTotalMujEtnico" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:Button ID="btnEtnica" CssClass="btn btn-danger" Text="Calcular" Visible="false" runat="server" />
                                      </td>
                                  </tr>
                                  </table>
                         </td>
                     </tr>
                  </asp:Panel>
                 <tr>
                     <td colspan="2">
                         <b>6.	¿En esta sede-jornada se atiende población víctima del conflicto?</b>
                     </td>
                 </tr>
                   <tr>
                     <td colspan="2">
                          <asp:RadioButtonList ID="rbVictimaConflicto" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbVictimaConflicto_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (fin del instrumento)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelVictimaConflicto" runat="server" Visible="false">
                     <tr>
                         <td  colspan="2">
                         <b>   7. Número de estudiantes participantes del grupo de investigación víctimas del conflicto. </b>
                             <br />
                                  Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                                <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="100%">
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Tipo de Situación
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                    <tr>
                                        <td>
                                            En situación de desplazamiento 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesplazamientoHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesplazamientoMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesplazamientoTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Desvinculados de organizaciones armadas al margen de la Ley
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtAlMargenHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlMargenMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlMargenTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Hijos de adultos desmovilizados 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesmovilizadosHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesmovilizadosMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesmovilizadosTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Total
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalHomConflicto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalMujConflicto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnConflicto" CssClass="btn btn-danger" Text="Calcular" Visible="false" runat="server" />
                                        </td>
                                    </tr>
                                    </table>
                         </td>
                     </tr>
                </asp:Panel>
                 <tr>
                     <td colspan="2" align="center"><br />
                          <asp:Button ID="btnRegresarPerfilDocente" CssClass="btn btn-primary" Text="Regresar" runat="server" Visible="false" OnClick="btnRegresarPerfilDocente_Onclick" />
                         <asp:Button ID="btnTerminar" CssClass="btn btn-success" Text="Guardar" runat="server" Visible="false" OnClick="btnTerminar_Onclick" />
                     </td>
                 </tr>
        </table>
        </fieldset>
       
    </asp:Panel>

    <!-- RED TEMÁTICA -->
     <asp:Label ID="lblCodGradoDocenteInstrumento6RT" Visible="false" runat="server"></asp:Label>
    <asp:Label ID="lblCodSedeInstrumento6RT" Visible="false" runat="server"></asp:Label>
    <asp:Panel ID="PanelEstudiantesRT" runat="server" Visible="false">
        <h4>Estrategia No 1. Estrategia de acompañamiento y formación de los grupos de investigación siguiendo los lineamientos y la metodología del programa Ondas apoyado en herramientas virtuales</h4>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" >
            <tr>
                <td>
                    <b style="color:red">Para tener en cuenta:</b> Si existe una sola Red Temática para un grupo de Docentes, primeramente, un solo docente deberá ingresar  el nombre de la Red Temática, para que luego los demás docentes pueda escogerla en el listado.
                </td>
            </tr>
            <tr>
                <td><br />
                    Si la Red Temática no aparece en el siguiente listado, por favor escoja la opción "Nueva Red Temática" y digite el nombre en "Nombre de la Red Temática"
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:DropDownList runat="server" ID="dropNombreRedTematica" CssClass="TextBox" Visible="false"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center">
                   <b> Nombre de la Red Temática</b>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:TextBox ID="txtNomRedTematica" runat="server" CssClass="TextBox" Width="300"></asp:TextBox>
                </td>
            </tr>
            </table>
        <fieldset>
            <legend> De los Estudiantes</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" border="0" >
                       <tr>
                     <td align="center" colspan="2">
                           <asp:GridView ID="GridEstudiantexDocenteRT" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="70%" EmptyDataText="Docente no registra estudiantes en Red Tématica" OnRowDataBound="GridEstudiantesxProcesoRT_RowDataBound" OnRowDeleting="GridEstudiantesxProcesoRT_RowDeleting"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="codestumatricula" HeaderText="codestumatricula"  />
                            <asp:BoundField DataField="nombrecompleto" HeaderText="Nombre estudiante"  />
                            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="sexo" HeaderText="Genero" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="grado" HeaderText="Grado" ItemStyle-HorizontalAlign="Center" />

                           <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png"><ItemStyle Width="20px" /></asp:CommandField>      
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Button ID="btnGuardarPrimero06RT" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardarPrimero06RT_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <b>B.	Los ítems que se describen a continuación deberán ser diligenciados por el docente acompañante y/o docente coinvestigador del grupo de investigación en el aula, </b>
                     </td>
                     </tr>
                 <tr>
                      <td colspan="2" >
                      <b> 1.  ¿En el Programa CIClÓN  se incluyen estudiantes con discapacidad o capacidades excepcionales?</b>
                     </td>
                     </tr>
                 <tr>
                     <td colspan="2">
                         <asp:RadioButtonList ID="rbValidarPregunta1Intrumento06RT" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbValidarPregunta1Intrumento06RT_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (pase a la pregunta No.3)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                     <asp:Panel ID="PanelPregunta2Instrumento06RT" runat="server" Visible="false">
                         <tr>
                           
                                 <td colspan="2">
                                   <b>  2.	Número de estudiantes del grupo de investigación con discapacidad o capacidades excepcionales, integrados* a la educación formal, según Género.</b>
                                     <br />
                                     Diligencie únicamente con cifras
                                 </td>
                             </tr>
                         <tr>
                             <td colspan="2">
                                  <table>
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Categoria
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con discapacidad
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadHomRT" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadMujRT" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtTotalDiscapacidadRT" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con capacidades excepcionales
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtCapacidadExcepHomRT" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtCapacidadExcepMujRT" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                           <td>
                                              <asp:TextBox ID="txtTotalCapacidadExcepRT" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>Total</td>
                                          <td>
                                              <asp:TextBox ID="txtTotalHomRT" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtTotalMujRT" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                           </td>
                                          <td>
                                              <asp:Button ID="btnValidarSumInvDiscapacidadRT" Visible="false" runat="server" CssClass="btn btn-danger" Text="Calcular" OnClick="btnValidarSumInvDiscapacidad_Click" />
                                          </td>
                                      </tr>
                                  </table>
                             </td>
                           </tr>
                    </asp:Panel>
                 <tr>
                     <td colspan="2">
                         <b>3.	Número de estudiantes con discapacidad, integrados y no integrados que hacen parte del grupo de investigación, por categoría y Género. </b>
                          <br />
                                     Diligencie únicamente con cifras
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2" >
                         <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="60%">
                             <tr>
                                 <td rowspan="2" style="font-weight:bold;">
                                     categoría
                                 </td>
                                 <td colspan="3" style="font-weight:bold;" align="center">
                                     Integrados 
                                 </td>
                                  <td colspan="3" style="font-weight:bold;" align="center">
                                     No Integrados 
                                 </td>
                                  <td colspan="3" style="font-weight:bold;" align="center">
                                     Total 
                                 </td>
                                 </tr>
                             <tr>
                                 <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                                 <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                                  <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Auditiva 
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaHomInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAuditivaHomNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Visual  
                                 </td>
                                    <td>
                                     <asp:TextBox ID="txtVisualHomInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtVisualHomNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Motora   
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Cognitiva    
                                 </td>
                                   <td>
                                     <asp:TextBox ID="txtCognitivaHomInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtCognitivaHomNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Autismo     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoHomInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAutismoHomNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Múltiple     
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujInteRT"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleInteRT" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomNoInteRT"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujNoInteRT"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Otra, ¿cuál?     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraHomInteRT"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujInteRT"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtOtraHomNoInteRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujNoInteRT"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Total    
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalNoInteRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalHomRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalMujRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Button ID="btnEstudianteDiscapacidadRT" CssClass="btn btn-danger" Visible="false" Text="Calcular" runat="server" />
                                 </td>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                       <b>  4.	¿En el grupo de investigación y las redes temáticas institucionales, se incluye población de grupos étnicos? </b>
                     </td>
                 </tr>
                 <tr>
                     <td colpan="2">
                          <asp:RadioButtonList ID="rbGrupoInvestigacionEtnicoInstru06RT" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbGrupoInvestigacionEtnicoInstru06RT_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (pase a la pregunta No.6)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelGrupoEtnicosRT" runat="server" Visible="false">
                     <tr>
                         <td>
                            <b> 5.	Número de estudiantes de grupos étnicos del grupo de investigación, según Género.</b>
                             <br />
                              Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                              <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="100%">
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Nombre del Grupo Etnico
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                  <tr>
                                      <td>
                                          Indígenas
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtIndigenaHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtIndigenaMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                           <asp:TextBox ID="txtIndigenaTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                        Rom (gitanos)
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Afrocolombianos, afrodecendientes, negro o mulato.
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Raizal del archipiélago de San Andrés, Providencia y Santa Catalina
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRaizaHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                           <asp:TextBox ID="txtRaizaMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRaizaTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Palenquero de San Basilio 
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Total 
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtTotalHomEtnicoRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtTotalMujEtnicoRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:Button ID="btnEtnicaRT" CssClass="btn btn-danger" Visible="false" Text="Calcular" runat="server" />
                                      </td>
                                  </tr>
                                  </table>
                         </td>
                     </tr>
                  </asp:Panel>
                 <tr>
                     <td colspan="2">
                         <b>6.	¿En esta sede-jornada se atiende población víctima del conflicto?</b>
                     </td>
                 </tr>
                   <tr>
                     <td colspan="2">
                          <asp:RadioButtonList ID="rbVictimaConflictoRT" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbVictimaConflictoRT_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (fin del instrumento)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelVictimaConflictoRT" runat="server" Visible="false">
                     <tr>
                         <td  colspan="2">
                         <b>   7. Número de estudiantes participantes del grupo de investigación víctimas del conflicto. </b>
                             <br />
                                  Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                                <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="100%">
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Tipo de Situación
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                    <tr>
                                        <td>
                                            En situación de desplazamiento 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesplazamientoHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesplazamientoMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesplazamientoTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Desvinculados de organizaciones armadas al margen de la Ley
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtAlMargenHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlMargenMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlMargenTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Hijos de adultos desmovilizados 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesmovilizadosHomRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesmovilizadosMujRT" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesmovilizadosTotalRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Total
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalHomConflictoRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalMujConflictoRT" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnConflictoRT" CssClass="btn btn-danger" Text="Calcular" Visible="false" runat="server" />
                                        </td>
                                    </tr>
                                    </table>
                         </td>
                     </tr>
                </asp:Panel>
                 <tr>
                     <td colspan="2" align="center"><br />
                         <asp:Button ID="btnTerminarRT" CssClass="btn btn-success" Text="Guardar" runat="server" Visible="false" OnClick="btnTerminarRT_Onclick" />
                     </td>
                 </tr>
        </table>
        </fieldset>
       
    </asp:Panel>

    <asp:Panel ID="PanelTerminado" runat="server" Visible="false">
        <center>
             <img src="images/terminado.png" width="300" />
            </center>

    </asp:Panel>
</asp:Content>

