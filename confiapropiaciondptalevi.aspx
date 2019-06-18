<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiapropiaciondptalevi.aspx.cs" Inherits="confiapropiaciondptalevi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
  
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <br /><br />
  <h2>Estrategia No 1 - Cargue de evidencias espacios de apropiación</h2>
     
        <asp:Label runat="server" Visible="false" ID="lblCodUsuario"></asp:Label>
        <asp:Label runat="server" Visible="false" ID="lblCodDepartamento"></asp:Label>
        <asp:Label runat="server" Visible="false" ID="lblCodEspacio"></asp:Label>

    <fieldset>
        <legend>Datos</legend>
        <table>
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
                <td>Fecha Fin
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
                <td>Hora inicio</td>
                <td>
                    <asp:DropDownList runat="server" ID="drophorainicio" CssClass="TextBox">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem value="00:00">00:00</asp:ListItem>
                        <asp:ListItem value="00:15">00:15</asp:ListItem>
                        <asp:ListItem value="00:30">00:30</asp:ListItem>
                        <asp:ListItem value="00:45">00:45</asp:ListItem>

                        <asp:ListItem value="01:00">01:00</asp:ListItem>
                        <asp:ListItem value="01:15">01:15</asp:ListItem>
                        <asp:ListItem value="01:30">01:30</asp:ListItem>
                        <asp:ListItem value="01:45">01:45</asp:ListItem>

                        <asp:ListItem value="02:00">02:00</asp:ListItem>
                        <asp:ListItem value="02:15">02:15</asp:ListItem>
                        <asp:ListItem value="02:30">02:30</asp:ListItem>
                        <asp:ListItem value="02:45">02:45</asp:ListItem>

                        <asp:ListItem value="03:00">03:00</asp:ListItem>
                        <asp:ListItem value="03:15">03:15</asp:ListItem>
                        <asp:ListItem value="03:30">03:30</asp:ListItem>
                        <asp:ListItem value="03:45">03:45</asp:ListItem>

                        <asp:ListItem value="04:00">04:00</asp:ListItem>
                        <asp:ListItem value="04:15">04:15</asp:ListItem>
                        <asp:ListItem value="04:30">04:30</asp:ListItem>
                        <asp:ListItem value="04:45">04:45</asp:ListItem>

                        <asp:ListItem value="05:00">05:00</asp:ListItem>
                        <asp:ListItem value="05:15">05:15</asp:ListItem>
                        <asp:ListItem value="05:30">05:30</asp:ListItem>
                        <asp:ListItem value="05:45">05:45</asp:ListItem>

                        <asp:ListItem value="06:00">06:00</asp:ListItem>
                        <asp:ListItem value="06:15">06:15</asp:ListItem>
                        <asp:ListItem value="06:30">06:30</asp:ListItem>
                        <asp:ListItem value="06:45">06:45</asp:ListItem>

                        <asp:ListItem value="07:00">07:00</asp:ListItem>
                        <asp:ListItem value="07:15">07:15</asp:ListItem>
                        <asp:ListItem value="07:30">07:30</asp:ListItem>
                        <asp:ListItem value="07:45">07:45</asp:ListItem>

                        <asp:ListItem value="08:00">08:00</asp:ListItem>
                        <asp:ListItem value="08:15">08:15</asp:ListItem>
                        <asp:ListItem value="08:30">08:30</asp:ListItem>
                        <asp:ListItem value="08:45">08:45</asp:ListItem>

                        <asp:ListItem value="09:00">09:00</asp:ListItem>
                        <asp:ListItem value="09:15">09:15</asp:ListItem>
                        <asp:ListItem value="09:30">09:30</asp:ListItem>
                        <asp:ListItem value="09:45">09:45</asp:ListItem>

                        <asp:ListItem value="10:00">10:00</asp:ListItem>
                        <asp:ListItem value="10:15">10:15</asp:ListItem>
                        <asp:ListItem value="10:30">10:30</asp:ListItem>
                        <asp:ListItem value="10:45">10:45</asp:ListItem>

                        <asp:ListItem value="11:00">11:00</asp:ListItem>
                        <asp:ListItem value="11:15">11:15</asp:ListItem>
                        <asp:ListItem value="11:30">11:30</asp:ListItem>
                        <asp:ListItem value="11:45">11:45</asp:ListItem>

                        <asp:ListItem value="12:00">12:00</asp:ListItem>
                        <asp:ListItem value="12:15">12:15</asp:ListItem>
                        <asp:ListItem value="12:30">12:30</asp:ListItem>
                        <asp:ListItem value="12:45">12:45</asp:ListItem>

                        <asp:ListItem value="13:00">13:00</asp:ListItem>
                        <asp:ListItem value="13:15">13:15</asp:ListItem>
                        <asp:ListItem value="13:30">13:30</asp:ListItem>
                        <asp:ListItem value="13:45">13:45</asp:ListItem>

                        <asp:ListItem value="14:00">14:00</asp:ListItem>
                        <asp:ListItem value="14:15">14:15</asp:ListItem>
                        <asp:ListItem value="14:30">14:30</asp:ListItem>
                        <asp:ListItem value="14:45">14:45</asp:ListItem>

                        <asp:ListItem value="15:00">15:00</asp:ListItem>
                        <asp:ListItem value="15:15">15:15</asp:ListItem>
                        <asp:ListItem value="15:30">15:30</asp:ListItem>
                        <asp:ListItem value="15:45">15:45</asp:ListItem>

                        <asp:ListItem value="16:00">16:00</asp:ListItem>
                        <asp:ListItem value="16:15">16:15</asp:ListItem>
                        <asp:ListItem value="16:30">16:30</asp:ListItem>
                        <asp:ListItem value="16:45">16:45</asp:ListItem>

                        <asp:ListItem value="17:00">17:00</asp:ListItem>
                        <asp:ListItem value="17:15">17:15</asp:ListItem>
                        <asp:ListItem value="17:30">17:30</asp:ListItem>
                        <asp:ListItem value="17:45">17:45</asp:ListItem>

                        <asp:ListItem value="18:00">18:00</asp:ListItem>
                        <asp:ListItem value="18:15">18:15</asp:ListItem>
                        <asp:ListItem value="18:30">18:30</asp:ListItem>
                        <asp:ListItem value="18:45">18:45</asp:ListItem>

                        <asp:ListItem value="19:00">19:00</asp:ListItem>
                        <asp:ListItem value="19:15">19:15</asp:ListItem>
                        <asp:ListItem value="19:30">19:30</asp:ListItem>
                        <asp:ListItem value="19:45">19:45</asp:ListItem>

                        <asp:ListItem value="20:00">20:00</asp:ListItem>
                        <asp:ListItem value="20:15">20:15</asp:ListItem>
                        <asp:ListItem value="20:30">20:30</asp:ListItem>
                        <asp:ListItem value="20:45">20:45</asp:ListItem>

                        <asp:ListItem value="21:00">21:00</asp:ListItem>
                        <asp:ListItem value="21:15">21:15</asp:ListItem>
                        <asp:ListItem value="21:30">21:30</asp:ListItem>
                        <asp:ListItem value="21:45">21:45</asp:ListItem>

                        <asp:ListItem value="22:00">22:00</asp:ListItem>
                        <asp:ListItem value="22:15">22:15</asp:ListItem>
                        <asp:ListItem value="22:30">22:30</asp:ListItem>
                        <asp:ListItem value="22:45">22:45</asp:ListItem>

                        <asp:ListItem value="23:00">23:00</asp:ListItem>
                        <asp:ListItem value="23:15">23:15</asp:ListItem>
                        <asp:ListItem value="23:30">23:30</asp:ListItem>
                        <asp:ListItem value="23:45">23:45</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Hora fin</td>
                <td>
                    <asp:DropDownList runat="server" ID="drophorafin" CssClass="TextBox">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem value="00:00">00:00</asp:ListItem>
                        <asp:ListItem value="00:15">00:15</asp:ListItem>
                        <asp:ListItem value="00:30">00:30</asp:ListItem>
                        <asp:ListItem value="00:45">00:45</asp:ListItem>

                        <asp:ListItem value="01:00">01:00</asp:ListItem>
                        <asp:ListItem value="01:15">01:15</asp:ListItem>
                        <asp:ListItem value="01:30">01:30</asp:ListItem>
                        <asp:ListItem value="01:45">01:45</asp:ListItem>

                        <asp:ListItem value="02:00">02:00</asp:ListItem>
                        <asp:ListItem value="02:15">02:15</asp:ListItem>
                        <asp:ListItem value="02:30">02:30</asp:ListItem>
                        <asp:ListItem value="02:45">02:45</asp:ListItem>

                        <asp:ListItem value="03:00">03:00</asp:ListItem>
                        <asp:ListItem value="03:15">03:15</asp:ListItem>
                        <asp:ListItem value="03:30">03:30</asp:ListItem>
                        <asp:ListItem value="03:45">03:45</asp:ListItem>

                        <asp:ListItem value="04:00">04:00</asp:ListItem>
                        <asp:ListItem value="04:15">04:15</asp:ListItem>
                        <asp:ListItem value="04:30">04:30</asp:ListItem>
                        <asp:ListItem value="04:45">04:45</asp:ListItem>

                        <asp:ListItem value="05:00">05:00</asp:ListItem>
                        <asp:ListItem value="05:15">05:15</asp:ListItem>
                        <asp:ListItem value="05:30">05:30</asp:ListItem>
                        <asp:ListItem value="05:45">05:45</asp:ListItem>

                        <asp:ListItem value="06:00">06:00</asp:ListItem>
                        <asp:ListItem value="06:15">06:15</asp:ListItem>
                        <asp:ListItem value="06:30">06:30</asp:ListItem>
                        <asp:ListItem value="06:45">06:45</asp:ListItem>

                        <asp:ListItem value="07:00">07:00</asp:ListItem>
                        <asp:ListItem value="07:15">07:15</asp:ListItem>
                        <asp:ListItem value="07:30">07:30</asp:ListItem>
                        <asp:ListItem value="07:45">07:45</asp:ListItem>

                        <asp:ListItem value="08:00">08:00</asp:ListItem>
                        <asp:ListItem value="08:15">08:15</asp:ListItem>
                        <asp:ListItem value="08:30">08:30</asp:ListItem>
                        <asp:ListItem value="08:45">08:45</asp:ListItem>

                        <asp:ListItem value="09:00">09:00</asp:ListItem>
                        <asp:ListItem value="09:15">09:15</asp:ListItem>
                        <asp:ListItem value="09:30">09:30</asp:ListItem>
                        <asp:ListItem value="09:45">09:45</asp:ListItem>

                        <asp:ListItem value="10:00">10:00</asp:ListItem>
                        <asp:ListItem value="10:15">10:15</asp:ListItem>
                        <asp:ListItem value="10:30">10:30</asp:ListItem>
                        <asp:ListItem value="10:45">10:45</asp:ListItem>

                        <asp:ListItem value="11:00">11:00</asp:ListItem>
                        <asp:ListItem value="11:15">11:15</asp:ListItem>
                        <asp:ListItem value="11:30">11:30</asp:ListItem>
                        <asp:ListItem value="11:45">11:45</asp:ListItem>

                        <asp:ListItem value="12:00">12:00</asp:ListItem>
                        <asp:ListItem value="12:15">12:15</asp:ListItem>
                        <asp:ListItem value="12:30">12:30</asp:ListItem>
                        <asp:ListItem value="12:45">12:45</asp:ListItem>

                        <asp:ListItem value="13:00">13:00</asp:ListItem>
                        <asp:ListItem value="13:15">13:15</asp:ListItem>
                        <asp:ListItem value="13:30">13:30</asp:ListItem>
                        <asp:ListItem value="13:45">13:45</asp:ListItem>

                        <asp:ListItem value="14:00">14:00</asp:ListItem>
                        <asp:ListItem value="14:15">14:15</asp:ListItem>
                        <asp:ListItem value="14:30">14:30</asp:ListItem>
                        <asp:ListItem value="14:45">14:45</asp:ListItem>

                        <asp:ListItem value="15:00">15:00</asp:ListItem>
                        <asp:ListItem value="15:15">15:15</asp:ListItem>
                        <asp:ListItem value="15:30">15:30</asp:ListItem>
                        <asp:ListItem value="15:45">15:45</asp:ListItem>

                        <asp:ListItem value="16:00">16:00</asp:ListItem>
                        <asp:ListItem value="16:15">16:15</asp:ListItem>
                        <asp:ListItem value="16:30">16:30</asp:ListItem>
                        <asp:ListItem value="16:45">16:45</asp:ListItem>

                        <asp:ListItem value="17:00">17:00</asp:ListItem>
                        <asp:ListItem value="17:15">17:15</asp:ListItem>
                        <asp:ListItem value="17:30">17:30</asp:ListItem>
                        <asp:ListItem value="17:45">17:45</asp:ListItem>

                        <asp:ListItem value="18:00">18:00</asp:ListItem>
                        <asp:ListItem value="18:15">18:15</asp:ListItem>
                        <asp:ListItem value="18:30">18:30</asp:ListItem>
                        <asp:ListItem value="18:45">18:45</asp:ListItem>

                        <asp:ListItem value="19:00">19:00</asp:ListItem>
                        <asp:ListItem value="19:15">19:15</asp:ListItem>
                        <asp:ListItem value="19:30">19:30</asp:ListItem>
                        <asp:ListItem value="19:45">19:45</asp:ListItem>

                        <asp:ListItem value="20:00">20:00</asp:ListItem>
                        <asp:ListItem value="20:15">20:15</asp:ListItem>
                        <asp:ListItem value="20:30">20:30</asp:ListItem>
                        <asp:ListItem value="20:45">20:45</asp:ListItem>

                        <asp:ListItem value="21:00">21:00</asp:ListItem>
                        <asp:ListItem value="21:15">21:15</asp:ListItem>
                        <asp:ListItem value="21:30">21:30</asp:ListItem>
                        <asp:ListItem value="21:45">21:45</asp:ListItem>

                        <asp:ListItem value="22:00">22:00</asp:ListItem>
                        <asp:ListItem value="22:15">22:15</asp:ListItem>
                        <asp:ListItem value="22:30">22:30</asp:ListItem>
                        <asp:ListItem value="22:45">22:45</asp:ListItem>

                        <asp:ListItem value="23:00">23:00</asp:ListItem>
                        <asp:ListItem value="23:15">23:15</asp:ListItem>
                        <asp:ListItem value="23:30">23:30</asp:ListItem>
                        <asp:ListItem value="23:45">23:45</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Lugar de realización</td>
                <td colspan="3"><asp:TextBox runat="server" ID="txtLugar" CssClass="TextBox" Width="300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Número de estudiantes <br /> participantes</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEstudiantes" CssClass="TextBox" Width="50"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="txtEstudiantes" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                </td>
                <td>Número de docentes</td>
                <td>
                    <asp:TextBox runat="server" ID="txtDocentes" CssClass="TextBox" Width="50"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtDocentes" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                </td>
            </tr>
        </table>
    </fieldset>
       
        <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>

                 <fieldset>
                <legend>Actividades</legend>
                <asp:Label ID="lblEncabezados" runat="server" Visible="true" ></asp:Label>
         <asp:Panel runat="server" ID="PanelMomento0" Visible="true">
              <asp:RadioButtonList runat="server" ID="rbtActividades">
                    <asp:ListItem>Registro de asistencias</asp:ListItem>  
                </asp:RadioButtonList>
         </asp:Panel>
          
         <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades" Display="Dynamic" ControlToValidate="rbtActividades" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
  
         </fieldset>

                <asp:FileUpload ID="trepador" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer >
            <div style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Cargar" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
               <asp:Button runat="server" Text="Regresar" OnClick="btnRegresar_click" ID="btnRegresar" CssClass="btn btn-primary" />
            </div>
        </footer>
    <%--</asp:Panel>--%>
  
     <fieldset>
     <legend>Listado de evidencias</legend>
        
      <asp:GridView ID="GridEvidencias" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                            <asp:BoundField DataField="nombrearchivo" HeaderText="Nombre archivo" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Center" Width="120px" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tamano"  HeaderText="Tamaño" HeaderStyle-CssClass="ocultarcell" >
                                <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>

                            <asp:BoundField DataField="fechainicio"  HeaderText="Fecha inicio" DataFormatString="{0:d}" >
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="fechafin"  HeaderText="Fecha fin" DataFormatString="{0:d}">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="horainicio"  HeaderText="Hora inicio" >
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="horafin"  HeaderText="Hora fin" >
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="lugar"  HeaderText="Lugar" >
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="nodocentes"  HeaderText="No. Docentes" >
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="noestudiantes"  HeaderText="No. Estudiantes" >
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="actividad" HeaderText="Actividad">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="fechacreado" HeaderText="Fecha subida">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombreguardado" HeaderText="Guardado" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="path" HeaderText="Path" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                            </asp:BoundField>

                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/down.png" Height="20px" Width="20px" OnClick="imgDescargar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSubir" runat="server" CommandName="Select" ImageUrl="~/Imagenes/upload.png" Height="20px" Width="20px" OnClick="imgSubir_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>


                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
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

    <asp:Button ID="btnShow" runat="server" style="display:none"/>
    <ajx:modalpopupextender id="PanelEditarDatos_ModalPopupExtender" runat="server" enabled="True"
        targetcontrolid="btnShow" popupcontrolid="PanelEditarDatos" cancelcontrolid="btnCancelar"
        backgroundcssclass="modalBackground">
    </ajx:modalpopupextender>

<asp:Panel ID="PanelEditarDatos" runat="server" CssClass="modalPopup">
    <asp:Label ID="lblTipo" runat="server" Visible="false" ></asp:Label>
     <asp:Label ID="lblID" runat="server" Visible="false" ></asp:Label>

<fieldset>
<legend>Editar datos</legend>

    <table>
         <tr>

                <td>Fecha Inicio
                </td>
                <td>
                    <asp:TextBox ID="txtFechainicioedit" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechainicioedit"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVtxtFechainicioedit" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="txtFechainicioedit" ValidationGroup="EditProyecto" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                        runat="server" Enabled="True" TargetControlID="REVtxtFechainicioedit"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechainicioedit" runat="server" Display="None" ErrorMessage="Digite Fecha Inicio"
                        ControlToValidate="txtFechainicioedit" Text="*" ValidationGroup="EditProyecto"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RFVtxtFechainicioedit"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Fecha Fin
                </td>
                <td>
                    <asp:TextBox ID="txtFechafinedit" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtFechafinedit"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="REVtxtFechafinedit" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="txtFechafinedit" ValidationGroup="EditProyecto" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6"
                        runat="server" Enabled="True" TargetControlID="REVtxtFechafinedit"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechafinedit" runat="server" Display="None" ErrorMessage="Digite Fecha fin"
                        ControlToValidate="txtFechaFin" Text="*" ValidationGroup="EditProyecto"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RFVtxtFechafinedit"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                </tr>
                <tr>
                <td>Hora inicio</td>
                <td>
                    <asp:DropDownList runat="server" ID="drophorainicioedit" CssClass="TextBox">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem value="00:00">00:00</asp:ListItem>
                        <asp:ListItem value="00:15">00:15</asp:ListItem>
                        <asp:ListItem value="00:30">00:30</asp:ListItem>
                        <asp:ListItem value="00:45">00:45</asp:ListItem>

                        <asp:ListItem value="01:00">01:00</asp:ListItem>
                        <asp:ListItem value="01:15">01:15</asp:ListItem>
                        <asp:ListItem value="01:30">01:30</asp:ListItem>
                        <asp:ListItem value="01:45">01:45</asp:ListItem>

                        <asp:ListItem value="02:00">02:00</asp:ListItem>
                        <asp:ListItem value="02:15">02:15</asp:ListItem>
                        <asp:ListItem value="02:30">02:30</asp:ListItem>
                        <asp:ListItem value="02:45">02:45</asp:ListItem>

                        <asp:ListItem value="03:00">03:00</asp:ListItem>
                        <asp:ListItem value="03:15">03:15</asp:ListItem>
                        <asp:ListItem value="03:30">03:30</asp:ListItem>
                        <asp:ListItem value="03:45">03:45</asp:ListItem>

                        <asp:ListItem value="04:00">04:00</asp:ListItem>
                        <asp:ListItem value="04:15">04:15</asp:ListItem>
                        <asp:ListItem value="04:30">04:30</asp:ListItem>
                        <asp:ListItem value="04:45">04:45</asp:ListItem>

                        <asp:ListItem value="05:00">05:00</asp:ListItem>
                        <asp:ListItem value="05:15">05:15</asp:ListItem>
                        <asp:ListItem value="05:30">05:30</asp:ListItem>
                        <asp:ListItem value="05:45">05:45</asp:ListItem>

                        <asp:ListItem value="06:00">06:00</asp:ListItem>
                        <asp:ListItem value="06:15">06:15</asp:ListItem>
                        <asp:ListItem value="06:30">06:30</asp:ListItem>
                        <asp:ListItem value="06:45">06:45</asp:ListItem>

                        <asp:ListItem value="07:00">07:00</asp:ListItem>
                        <asp:ListItem value="07:15">07:15</asp:ListItem>
                        <asp:ListItem value="07:30">07:30</asp:ListItem>
                        <asp:ListItem value="07:45">07:45</asp:ListItem>

                        <asp:ListItem value="08:00">08:00</asp:ListItem>
                        <asp:ListItem value="08:15">08:15</asp:ListItem>
                        <asp:ListItem value="08:30">08:30</asp:ListItem>
                        <asp:ListItem value="08:45">08:45</asp:ListItem>

                        <asp:ListItem value="09:00">09:00</asp:ListItem>
                        <asp:ListItem value="09:15">09:15</asp:ListItem>
                        <asp:ListItem value="09:30">09:30</asp:ListItem>
                        <asp:ListItem value="09:45">09:45</asp:ListItem>

                        <asp:ListItem value="10:00">10:00</asp:ListItem>
                        <asp:ListItem value="10:15">10:15</asp:ListItem>
                        <asp:ListItem value="10:30">10:30</asp:ListItem>
                        <asp:ListItem value="10:45">10:45</asp:ListItem>

                        <asp:ListItem value="11:00">11:00</asp:ListItem>
                        <asp:ListItem value="11:15">11:15</asp:ListItem>
                        <asp:ListItem value="11:30">11:30</asp:ListItem>
                        <asp:ListItem value="11:45">11:45</asp:ListItem>

                        <asp:ListItem value="12:00">12:00</asp:ListItem>
                        <asp:ListItem value="12:15">12:15</asp:ListItem>
                        <asp:ListItem value="12:30">12:30</asp:ListItem>
                        <asp:ListItem value="12:45">12:45</asp:ListItem>

                        <asp:ListItem value="13:00">13:00</asp:ListItem>
                        <asp:ListItem value="13:15">13:15</asp:ListItem>
                        <asp:ListItem value="13:30">13:30</asp:ListItem>
                        <asp:ListItem value="13:45">13:45</asp:ListItem>

                        <asp:ListItem value="14:00">14:00</asp:ListItem>
                        <asp:ListItem value="14:15">14:15</asp:ListItem>
                        <asp:ListItem value="14:30">14:30</asp:ListItem>
                        <asp:ListItem value="14:45">14:45</asp:ListItem>

                        <asp:ListItem value="15:00">15:00</asp:ListItem>
                        <asp:ListItem value="15:15">15:15</asp:ListItem>
                        <asp:ListItem value="15:30">15:30</asp:ListItem>
                        <asp:ListItem value="15:45">15:45</asp:ListItem>

                        <asp:ListItem value="16:00">16:00</asp:ListItem>
                        <asp:ListItem value="16:15">16:15</asp:ListItem>
                        <asp:ListItem value="16:30">16:30</asp:ListItem>
                        <asp:ListItem value="16:45">16:45</asp:ListItem>

                        <asp:ListItem value="17:00">17:00</asp:ListItem>
                        <asp:ListItem value="17:15">17:15</asp:ListItem>
                        <asp:ListItem value="17:30">17:30</asp:ListItem>
                        <asp:ListItem value="17:45">17:45</asp:ListItem>

                        <asp:ListItem value="18:00">18:00</asp:ListItem>
                        <asp:ListItem value="18:15">18:15</asp:ListItem>
                        <asp:ListItem value="18:30">18:30</asp:ListItem>
                        <asp:ListItem value="18:45">18:45</asp:ListItem>

                        <asp:ListItem value="19:00">19:00</asp:ListItem>
                        <asp:ListItem value="19:15">19:15</asp:ListItem>
                        <asp:ListItem value="19:30">19:30</asp:ListItem>
                        <asp:ListItem value="19:45">19:45</asp:ListItem>

                        <asp:ListItem value="20:00">20:00</asp:ListItem>
                        <asp:ListItem value="20:15">20:15</asp:ListItem>
                        <asp:ListItem value="20:30">20:30</asp:ListItem>
                        <asp:ListItem value="20:45">20:45</asp:ListItem>

                        <asp:ListItem value="21:00">21:00</asp:ListItem>
                        <asp:ListItem value="21:15">21:15</asp:ListItem>
                        <asp:ListItem value="21:30">21:30</asp:ListItem>
                        <asp:ListItem value="21:45">21:45</asp:ListItem>

                        <asp:ListItem value="22:00">22:00</asp:ListItem>
                        <asp:ListItem value="22:15">22:15</asp:ListItem>
                        <asp:ListItem value="22:30">22:30</asp:ListItem>
                        <asp:ListItem value="22:45">22:45</asp:ListItem>

                        <asp:ListItem value="23:00">23:00</asp:ListItem>
                        <asp:ListItem value="23:15">23:15</asp:ListItem>
                        <asp:ListItem value="23:30">23:30</asp:ListItem>
                        <asp:ListItem value="23:45">23:45</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Hora fin</td>
                <td>
                    <asp:DropDownList runat="server" ID="drophorafinedit" CssClass="TextBox">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem value="00:00">00:00</asp:ListItem>
                        <asp:ListItem value="00:15">00:15</asp:ListItem>
                        <asp:ListItem value="00:30">00:30</asp:ListItem>
                        <asp:ListItem value="00:45">00:45</asp:ListItem>

                        <asp:ListItem value="01:00">01:00</asp:ListItem>
                        <asp:ListItem value="01:15">01:15</asp:ListItem>
                        <asp:ListItem value="01:30">01:30</asp:ListItem>
                        <asp:ListItem value="01:45">01:45</asp:ListItem>

                        <asp:ListItem value="02:00">02:00</asp:ListItem>
                        <asp:ListItem value="02:15">02:15</asp:ListItem>
                        <asp:ListItem value="02:30">02:30</asp:ListItem>
                        <asp:ListItem value="02:45">02:45</asp:ListItem>

                        <asp:ListItem value="03:00">03:00</asp:ListItem>
                        <asp:ListItem value="03:15">03:15</asp:ListItem>
                        <asp:ListItem value="03:30">03:30</asp:ListItem>
                        <asp:ListItem value="03:45">03:45</asp:ListItem>

                        <asp:ListItem value="04:00">04:00</asp:ListItem>
                        <asp:ListItem value="04:15">04:15</asp:ListItem>
                        <asp:ListItem value="04:30">04:30</asp:ListItem>
                        <asp:ListItem value="04:45">04:45</asp:ListItem>

                        <asp:ListItem value="05:00">05:00</asp:ListItem>
                        <asp:ListItem value="05:15">05:15</asp:ListItem>
                        <asp:ListItem value="05:30">05:30</asp:ListItem>
                        <asp:ListItem value="05:45">05:45</asp:ListItem>

                        <asp:ListItem value="06:00">06:00</asp:ListItem>
                        <asp:ListItem value="06:15">06:15</asp:ListItem>
                        <asp:ListItem value="06:30">06:30</asp:ListItem>
                        <asp:ListItem value="06:45">06:45</asp:ListItem>

                        <asp:ListItem value="07:00">07:00</asp:ListItem>
                        <asp:ListItem value="07:15">07:15</asp:ListItem>
                        <asp:ListItem value="07:30">07:30</asp:ListItem>
                        <asp:ListItem value="07:45">07:45</asp:ListItem>

                        <asp:ListItem value="08:00">08:00</asp:ListItem>
                        <asp:ListItem value="08:15">08:15</asp:ListItem>
                        <asp:ListItem value="08:30">08:30</asp:ListItem>
                        <asp:ListItem value="08:45">08:45</asp:ListItem>

                        <asp:ListItem value="09:00">09:00</asp:ListItem>
                        <asp:ListItem value="09:15">09:15</asp:ListItem>
                        <asp:ListItem value="09:30">09:30</asp:ListItem>
                        <asp:ListItem value="09:45">09:45</asp:ListItem>

                        <asp:ListItem value="10:00">10:00</asp:ListItem>
                        <asp:ListItem value="10:15">10:15</asp:ListItem>
                        <asp:ListItem value="10:30">10:30</asp:ListItem>
                        <asp:ListItem value="10:45">10:45</asp:ListItem>

                        <asp:ListItem value="11:00">11:00</asp:ListItem>
                        <asp:ListItem value="11:15">11:15</asp:ListItem>
                        <asp:ListItem value="11:30">11:30</asp:ListItem>
                        <asp:ListItem value="11:45">11:45</asp:ListItem>

                        <asp:ListItem value="12:00">12:00</asp:ListItem>
                        <asp:ListItem value="12:15">12:15</asp:ListItem>
                        <asp:ListItem value="12:30">12:30</asp:ListItem>
                        <asp:ListItem value="12:45">12:45</asp:ListItem>

                        <asp:ListItem value="13:00">13:00</asp:ListItem>
                        <asp:ListItem value="13:15">13:15</asp:ListItem>
                        <asp:ListItem value="13:30">13:30</asp:ListItem>
                        <asp:ListItem value="13:45">13:45</asp:ListItem>

                        <asp:ListItem value="14:00">14:00</asp:ListItem>
                        <asp:ListItem value="14:15">14:15</asp:ListItem>
                        <asp:ListItem value="14:30">14:30</asp:ListItem>
                        <asp:ListItem value="14:45">14:45</asp:ListItem>

                        <asp:ListItem value="15:00">15:00</asp:ListItem>
                        <asp:ListItem value="15:15">15:15</asp:ListItem>
                        <asp:ListItem value="15:30">15:30</asp:ListItem>
                        <asp:ListItem value="15:45">15:45</asp:ListItem>

                        <asp:ListItem value="16:00">16:00</asp:ListItem>
                        <asp:ListItem value="16:15">16:15</asp:ListItem>
                        <asp:ListItem value="16:30">16:30</asp:ListItem>
                        <asp:ListItem value="16:45">16:45</asp:ListItem>

                        <asp:ListItem value="17:00">17:00</asp:ListItem>
                        <asp:ListItem value="17:15">17:15</asp:ListItem>
                        <asp:ListItem value="17:30">17:30</asp:ListItem>
                        <asp:ListItem value="17:45">17:45</asp:ListItem>

                        <asp:ListItem value="18:00">18:00</asp:ListItem>
                        <asp:ListItem value="18:15">18:15</asp:ListItem>
                        <asp:ListItem value="18:30">18:30</asp:ListItem>
                        <asp:ListItem value="18:45">18:45</asp:ListItem>

                        <asp:ListItem value="19:00">19:00</asp:ListItem>
                        <asp:ListItem value="19:15">19:15</asp:ListItem>
                        <asp:ListItem value="19:30">19:30</asp:ListItem>
                        <asp:ListItem value="19:45">19:45</asp:ListItem>

                        <asp:ListItem value="20:00">20:00</asp:ListItem>
                        <asp:ListItem value="20:15">20:15</asp:ListItem>
                        <asp:ListItem value="20:30">20:30</asp:ListItem>
                        <asp:ListItem value="20:45">20:45</asp:ListItem>

                        <asp:ListItem value="21:00">21:00</asp:ListItem>
                        <asp:ListItem value="21:15">21:15</asp:ListItem>
                        <asp:ListItem value="21:30">21:30</asp:ListItem>
                        <asp:ListItem value="21:45">21:45</asp:ListItem>

                        <asp:ListItem value="22:00">22:00</asp:ListItem>
                        <asp:ListItem value="22:15">22:15</asp:ListItem>
                        <asp:ListItem value="22:30">22:30</asp:ListItem>
                        <asp:ListItem value="22:45">22:45</asp:ListItem>

                        <asp:ListItem value="23:00">23:00</asp:ListItem>
                        <asp:ListItem value="23:15">23:15</asp:ListItem>
                        <asp:ListItem value="23:30">23:30</asp:ListItem>
                        <asp:ListItem value="23:45">23:45</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Lugar de realización</td>
                <td colspan="3"><asp:TextBox runat="server" ID="txtLugarEdit" CssClass="TextBox" Width="300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Número de estudiantes <br /> participantes</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEstudiantesEdit" CssClass="TextBox" Width="50"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtEstudiantesEdit" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                </td>
                <td>Número de docentes</td>
                <td>
                    <asp:TextBox runat="server" ID="txtDocentesEdit" CssClass="TextBox" Width="50"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" TargetControlID="txtDocentesEdit" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                </td>
            </tr>
        <tr>
    <td colspan="4" style="text-align:center">
        <asp:Button ID="btnEditar" runat="server" Text="Guardar Cambios"  ValidationGroup="editUsuario"
            CssClass="btn btn-success" onclick="btnEditar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botones" 
            onclick="btnCancelar_Click"/>
    </td>
</tr>
    </table>

</fieldset>
</asp:Panel>

    <%-- Upload --%>

     <asp:Button ID="btnShow2" runat="server" style="display:none"/>
    <ajx:modalpopupextender id="PanelUpload_ModalPopupExtender" runat="server" enabled="True"
        targetcontrolid="btnShow2" popupcontrolid="PanelUpload" cancelcontrolid="btnCancelar2"
        backgroundcssclass="modalBackground">
    </ajx:modalpopupextender>

<asp:Panel ID="PanelUpload" runat="server" CssClass="modalPopup">
    <asp:Label ID="Label1" runat="server" Visible="false" ></asp:Label>
     <asp:Label ID="Label2" runat="server" Visible="false" ></asp:Label>

<fieldset>
<legend>Subir</legend>

    <table>
    <tr>
        <td>
             <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>

                 <fieldset>
                <legend>Actividades</legend>
                <asp:Label ID="Label3" runat="server" Visible="true" ></asp:Label>
         <asp:Panel runat="server" ID="Panel1" Visible="true">
              <asp:RadioButtonList runat="server" ID="rbtActividades2">
                    <asp:ListItem>Registro de asistencias</asp:ListItem>  
                </asp:RadioButtonList>
         </asp:Panel>
          
         <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades2" Display="Dynamic" ControlToValidate="rbtActividades2" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
  
         </fieldset>

                <asp:FileUpload ID="FileUpload1" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer >
            <div style="text-align: center">
                <asp:Button ID="Button2" runat="server" Text="Cargar" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
            </div>
        </footer>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="text-align:center">
            <asp:Button ID="Button3" runat="server" Text="Guardar Cambios"  ValidationGroup="editUsuario"
                CssClass="btn btn-success" onclick="btnEditar_Click"/>
            <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" CssClass="botones" 
                onclick="btnCancelar2_Click"/>
        </td>
    </tr>
    </table>

</fieldset>
</asp:Panel>
           
</asp:Content>

