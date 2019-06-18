<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiproyectos.aspx.cs" Inherits="confiproyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        a.tooltip {
            position: relative;
        }

            a.tooltip::before {
                content: attr(data-tooltip);
                font-size: 12px;
                position: absolute;
                z-index: 999;
                white-space: nowrap;
                bottom: 9999px;
                left: 0;
                background: #000;
                color: #e0e0e0;
                padding: 0px 7px;
                line-height: 24px;
                height: 24px;
                opacity: 0;
            }

            a.tooltip:hover::before {
                opacity: 1;
                top: 22px;
            }

            a.tooltip:hover::after {
                content: "";
                opacity: 1;
                width: 0;
                height: 0;
                border-left: 5px solid transparent;
                border-right: 5px solid transparent;
                border-bottom: 5px solid black;
                z-index: 999;
                position: absolute;
                white-space: nowrap;
                top: 17px;
                left: 0px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>

    <h2 style="text-decoration: underline;">Configuración de Proyectos</h2>
    <br />
    <fieldset>
        <legend>Creación de proyecto</legend>
        <table align="center" cellpadding="4">
            <tr>
                <td>Nombre:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="400px" placeholder="Digite el nombre del proyecto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" Display="None" ErrorMessage="Digite el nombre"
                        ControlToValidate="txtNombre" Text="*" ValidationGroup="agregarProyecto"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RFVtxtNombre"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>

            </tr>
            <tr>
                <td>Departamento
                </td>
                <td>
                    <asp:DropDownList ID="dropDepartamento" runat="server" CssClass="TextBox" OnSelectedIndexChanged="dropDepartamento_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropDepartamento" runat="server" Display="None" ErrorMessage="Seleccione el departamento"
                        ControlToValidate="dropDepartamento" Text="*" ValidationGroup="agregarProyecto" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RFVdropDepartamento"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Municipio
                </td>
                <td>
                    <asp:DropDownList ID="dropMunicipio" runat="server" CssClass="TextBox"></asp:DropDownList>
                    <a href="#" class="tooltip" data-tooltip="Proyecto solo para un municipio.">
                        <img src="Imagenes/help.png" width="20px" height="20px" />
                    </a>
                </td>
            </tr>
            <tr>
                <td>
                    Grupo de Investigación
                </td>
                <td>
                     <asp:TextBox ID="txtGrupoInvestigacion" runat="server" CssClass="TextBox" Width="200px" placeholder="Digite el nombre del Grupo"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtGrupoInvestigacion" runat="server" Display="None" ErrorMessage="Digite el nombre del Grupo de investigación"
                        ControlToValidate="txtGrupoInvestigacion" Text="*" ValidationGroup="agregarProyecto"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RFVtxtGrupoInvestigacion"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>
                    Línea de investigación
                </td>
                <td>
                     <asp:DropDownList ID="dropLInvestigacion" runat="server" CssClass="TextBox" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropLInvestigacion" runat="server" Display="None" ErrorMessage="Seleccione la línea de investigación"
                        ControlToValidate="dropLInvestigacion" Text="*" ValidationGroup="agregarProyecto" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RFVdropLInvestigacion"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>

                <td>Fecha Inicio
                </td>
                <td>
                    <asp:TextBox ID="txtFechaIni" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaIni"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVtxtFechaIni" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="txtFechaIni" ValidationGroup="agregarProyecto" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21"
                        runat="server" Enabled="True" TargetControlID="REVtxtFechaIni"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite Fecha de Inicio del Proyecto"
                        ControlToValidate="txtFechaIni" Text="*" ValidationGroup="agregarProyecto"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RFVtxtFechaIni"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Fecha Cierre
                </td>
                <td>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaFin"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVtxtFechaFin" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="txtFechaFin" ValidationGroup="agregarProyecto" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                        runat="server" Enabled="True" TargetControlID="REVtxtFechaFin"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechaFin" runat="server" Display="None" ErrorMessage="Digite Fecha de Cierre del Proyecto"
                        ControlToValidate="txtFechaFin" Text="*" ValidationGroup="agregarProyecto"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVtxtFechaFin"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-success" OnClick="btnAgregar_Click" ValidationGroup="agregarProyecto" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Listado de Proyectos</legend>
        <div style="margin: 0 auto; text-align: center">
            <asp:GridView ID="GridProyectos" runat="server" CellPadding="4"
                EmptyDataText="No Existen Proyectos"
                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                GridLines="None" >
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="cod" HeaderText="Cod" HeaderStyle-CssClass="ocultarcell">
                        <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nombre" HeaderText="Proyecto">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="coddepartamento" HeaderText="Cod Departamento" HeaderStyle-CssClass="ocultarcell">
                        <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nombred" HeaderText="Departamento">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codmunicipio" HeaderText="Cod Municipio" HeaderStyle-CssClass="ocultarcell">
                        <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nombrem" HeaderText="Municipio">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechaini" HeaderText="Inicio" DataFormatString="{0:d}">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechafin" HeaderText="Fin" DataFormatString="{0:d}">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="estado" HeaderText="Estado">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDlete" runat="server" CommandName="Select" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="imgDlete_Click" />

                           </ItemTemplate>
                        <ItemStyle Width="20px" />
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
    </fieldset>
     <asp:Button ID="btnShow2" runat="server" Text="Button" style="display:none" />
<ajx:modalpopupextender id="PanelEditar_Modalpopupextender" runat="server" enabled="True"
    targetcontrolid="btnShow2" popupcontrolid="PanelEditar" cancelcontrolid="btnCerrarEditar"
    backgroundcssclass="modalBackground">
</ajx:modalpopupextender>

<asp:Panel ID="PanelEditar" runat="server" CssClass="modalPopup">    
    <header class="headerpopup">        
        <div style="float:left;margin-right:15px" id="Div1">
            Edición de Proyecto
        </div>
        <div style="float:right;">
            <asp:Label ID="btnCerrarEditar" runat="server" Text="Cerrar" CssClass="botones" ></asp:Label>
        </div>
    </header>
    <section class="sectionpopup">     
        <asp:Label ID="lblCodProyecto" runat="server" Visible="false" ></asp:Label>   
        <fieldset>
            <legend>Editar municipio</legend>        
            <table align="center" cellpadding="4">
                <tr>
                    <td>
                        Nombre:
                    </td>            
                    <td colspan="3">
                        <asp:TextBox ID="txtProyectoEditar" runat="server" CssClass="TextBox"  Width="400px" MaxLength="50"></asp:TextBox>                    
                        <asp:RequiredFieldValidator ID="RFVtxtProyectoEditar" runat="server" ErrorMessage="Digite nombre del proyecto"
                            Text="*" Display="None" ControlToValidate="txtProyectoEditar"
                            ValidationGroup="Editar"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVtxtProyectoEditar" 
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>            
                </tr>   
             
                <tr>
                    <td>
                        Departamento:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropDepartamentoEditar" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropDepartamentoEditar_SelectedIndexChanged"></asp:DropDownList>     
                        <asp:RequiredFieldValidator ID="RFVdropDepartamentoEditar" runat="server" ErrorMessage="Seleccione el departamento" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropDepartamentoEditar" 
                            ValidationGroup="Editar"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropDepartamentoEditar" 
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>               
                    </td>
                    <td>
                        Municipio:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="dropMunicipioEditar" runat="server" CssClass="TextBox"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dropDepartamentoEditar" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            <tr>
              <td>
                    Fecha Inicio
                </td>
                <td>
                    <asp:TextBox ID="txtFechaIniEditar" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechaIniEditar"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday">
                    </ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVtxtFechaIniEditar" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="txtFechaIniEditar" ValidationGroup="Editar" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" 
                        style="color: #FF0000"></asp:RegularExpressionValidator>    
	                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" 
                        runat="server" Enabled="True" TargetControlID="REVtxtFechaIni" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>    
                    <asp:RequiredFieldValidator ID="RFVtxtFechaIniEditar" runat="server" Display="None" ErrorMessage="Digite Fecha de Inicio" 
                        ControlToValidate="txtFechaIniEditar" Text="*" ValidationGroup="Editar"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RFVtxtFechaIniEditar"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>
                    Fecha Cierre
                </td>
                <td>
                    <asp:TextBox ID="txtFechaFinEditar" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtFechaFinEditar"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday">
                    </ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVtxtFechaFinEditar" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="txtFechaFinEditar" ValidationGroup="Editar" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" 
                        style="color: #FF0000"></asp:RegularExpressionValidator>    
	                <ajx:ValidatorCalloutExtender ID="loquesea" 
                        runat="server" Enabled="True" TargetControlID="REVtxtFechaFinEditar" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender> 
                    <asp:RequiredFieldValidator ID="RFVtxtFechaFinEditar" runat="server" Display="None" ErrorMessage="Digite Fecha de Cierre" 
                        ControlToValidate="txtFechaFinEditar" Text="*" ValidationGroup="Editar"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="RFVtxtFechaFinEditar"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
             </tr>
                <tr>
                    <td colspan="4" style="text-align:center">   
                        <asp:DropDownList ID="dropEstado" runat="server" CssClass="TextBox">
                            <asp:ListItem>On</asp:ListItem>
                            <asp:ListItem>Off</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table> 
              <fieldset>
            <legend>Listado Documento</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Subir Archivo:
                    </td>
                    <td colspan="3">
                        <asp:FileUpload ID="trepador" runat="server" />
                        <asp:RequiredFieldValidator ID="RFVtrepador" runat="server" ErrorMessage="Debe seleccionar un archivo"
                            Text="*" Display="None" ControlToValidate="trepador" ValidationGroup="addDocumento">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="RFVtrepador"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                   <td colspan="4">
                       <asp:GridView ID="GridDocumentos" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No Tiene Documentos Asignados"
                    GridLines="None" OnRowDeleting="GridDocumentos_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cod" HeaderText="cod" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombrearchivo" HeaderText="Anexo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombreguardado" HeaderText="Guardado" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                        </asp:BoundField>
                        <asp:BoundField DataField="path" HeaderText="Path" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Ver
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/down.png" Height="20px" Width="20px" OnClick="imgDescargar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                            <ItemStyle Width="20px" />
                        </asp:CommandField>
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
                     </td>
                </tr>
            </table>

        </fieldset>
            <br />
                 <br />
                 <br />
                 <br />
                 <br />
         
        </fieldset>  
    </section>
    <footer class="footerpopup">        
        <div style="text-align:center">
            <asp:Button ID="btnEditarProyecto" runat="server" Text="Editar" CssClass="btn btn-success" ValidationGroup="Editar" OnClick="btnEditarProyecto_Click" />                          
        </div>
    </footer>   
</asp:Panel>
</asp:Content>

