<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiespaciodeapropiacionint.aspx.cs" Inherits="confiespaciodeapropiacion" %>

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

    <script type="text/javascript">

        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);

        $("#sede").change(function () {
            reset();
        });

        $(".datepicker").datepicker({ changeYear: true, changeMonth: true });
        

        function btnEntrar_click() {
            var jsonData = '{ "txtIDEstudianteNuevo":"' + $("#MainContent_txtIDEstudianteNuevo").val() + '" }';
            //var jsonData = '{ "txtIDEstudianteNuevo":"' + $("#txtIDEstudianteNuevo").val() + '", "txtNomEstudianteNuevo":"' + $("#txtNomEstudianteNuevo").val() + '", "txtNomApellidoNuevo": "' + $("#txtNomApellidoNuevo").val() + '", "dropsexo": "' + $("#dropSexo").val() + '", "txtFechaNacimiento": "' + $("#txtFechaNacimiento").val() + '", "txtTelefonoNuevo": "' + $("#txtTelefonoNuevo").val() + '", "txtDireccionNuevo": "' + $("#txtDireccionNuevo").val() + '", "txtemailNuevo": "' + $("#txtemailNuevo").val() + '","dropSedes": "' + $("#MainContent_dropSedes").val() + '","dropGrados": "' + $("#MainContent_DropGrados").val() + '" }';
            alert(jsonData);
          
        }

        function btnEditar_click() {

            var jsonData = '{ "txtIDEstudianteNuevo":"' + $("#MainContent_txtIDestudiante").val() + '", "txtNomEstudianteNuevo": "' + $("#MainContent_txtNomEstudiante").val() + '", "txtNomApellidoNuevo": "' + $("#MainContent_txtApellidoEstudiante").val() + '", "dropsexo": "' + $("#MainContent_dropGenero").val() + '", "txtFechaNacimiento": "' + $("#MainContent_txtFechaIni").val() + '", "txtTelefonoNuevo": "' + $("#MainContent_txtTelefono").val() + '", "txtDireccionNuevo": "' + $("#MainContent_txtDireccion").val() + '", "txtemailNuevo": "' + $("#MainContent_txtEmail").val() + '" }';
            //alert(jsonData);
            $.ajax({
                type: "POST",
                url: "confiespaciodeapropiacion.aspx/actualizarEstudiante",
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
                url: "confiespaciodeapropiacion.aspx/moverDocente",
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
          $(function () {
              $("#btn-nuveoEstudiante").hide();
              $('#lnkVolver').hide();
             
          });

      
        
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
            <h2>Conformación de las Ferias Internacionales</h2>
        </div>
        <div style="float: right;margin-top:20px;">
            <asp:LinkButton runat="server" ID="lnkVerGruposInvestigacion" CssClass="btn btn-primary" OnClick="lnkCrearRedesTematicas_Click">Crear Nueva Feria</asp:LinkButton>
            <asp:LinkButton ID="lnkVolver" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolver_Click">Volver</asp:LinkButton>
            <asp:LinkButton ID="lnkVolverEditarDatosEstudiante" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="lnkVolverEditarDatosEstudiante_Click">Volver</asp:LinkButton>
        </div>
    </div>
        <br /><br /><br />

       <div id="VerRed">

            <asp:GridView ID="GridFeria" runat="server" CellPadding="4" 
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen Ferias Internacionales."
                    GridLines="None" CssClass="mGridTesoreria">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codferiamunicipal" HeaderText="codigo" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="nomferiamunicipal" HeaderText="Nombre Feria Internacional">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="asistentes" HeaderText="No. Estudiantes">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hora" HeaderText="Hora">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomdepartamento" HeaderText="Departamento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="coddepartamento" HeaderText="coddepartamento" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell"/>
                        </asp:BoundField>
                        
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <br />
                                <asp:LinkButton ID="lnkEditarRed" runat="server" CssClass="btn btn-success" Text="Ver" OnClick="lnkEditarRed_Click"></asp:LinkButton> <br /><br />
                                <asp:LinkButton ID="lnkEvidenciasIns" runat="server" CssClass="btn btn-primary" Text="Inscripción" OnClick="lnkEvidenciasIns_Click"></asp:LinkButton> <br /><br />
                                <asp:LinkButton ID="lnkApropiacionMaestros" runat="server" CssClass="btn btn-success" Text="Grupos" OnClick="lnkApropiacionMaestros_Click"></asp:LinkButton> <br /><br />
                                <asp:LinkButton ID="lnkEvidencias" runat="server" CssClass="btn btn-primary" Text="Evidencias" OnClick="lnkEvidencias_Click"></asp:LinkButton> <br /><br />
                                <asp:LinkButton ID="lnkEliminarRedTematica" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="lnkEliminarRedTematica_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción? Recuerde que perderá todos los registros asociados a esta Feria.')){ return false; };"></asp:LinkButton><br /><br />
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
                         <td>Número de Estudiantes</td>
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
                         <td>Número de Docentes</td>
                         <td>
                         <asp:TextBox ID="numerodocentes" runat="server" CssClass="TextBox"></asp:TextBox>
                         </td>
                     </tr>
            </table>
        <br />
    <table>
                <tr>
                    <td>Lugar de Realización&nbsp  &nbsp</td>
                    <td>
                         <asp:TextBox ID="lugarferia" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                </tr>

    </table>
        <br />
        <table>

                <tr>
                    <td>Fecha de Realización&nbsp &nbsp</td>
                         <td>
                           <asp:TextBox ID="fechaelaboracion" runat="server" CssClass="TextBox" Width="130px" placeholder="dd-mm-aaaa"></asp:TextBox>
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
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVfechaelaboracion"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                         </td>
                </tr>

                <tr>
                    <td>Hora Inicial:</td>
                        <td>
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
                        <td>Hora Final: </td>
                        <td>
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
        <br />
    <table>
                <tr>
                    <td>Fecha de Finalización&nbsp&nbsp</td>
                         <td>
                           <asp:TextBox ID="fechaelaboracioncierre" runat="server" CssClass="TextBox" Width="130px" placeholder="dd-mm-aaaa"></asp:TextBox>
                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="fechaelaboracioncierre"
                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday">
                    </ajx:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                        ControlToValidate="fechaelaboracion" ValidationGroup="Agregar" Text="*"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" 
                        style="color: #FF0000"></asp:RegularExpressionValidator>    
                 <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" 
                        runat="server" Enabled="True" TargetControlID="REVfechaelaboracion" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Digite Fecha de Inicio del Periodo" 
                        ControlToValidate="fechaelaboracion" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RFVfechaelaboracion"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                         </td>
                </tr>

                <tr>
                    <td>Hora Inicial:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="horaferiacierre" CssClass="TextBox">
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
                        <td>Hora Final: </td>
                        <td>
                            <asp:DropDownList runat="server" ID="horaferiafinalcierre" CssClass="TextBox">
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
        <br />

        
       <table align="center">
           <tr>
           <td>
           <asp:Button runat="server" ID="btnAgregarEstudiantes" ValidationGroup="addestudiantes"  visible="true" CssClass="btn btn-success" Text="Crear Feria Internacional" OnClick="btnAgregarEstudiantes_Click" />
           </td>
           </tr>
       </table>
    
   </fieldset>

    <!--Esto esta oculto-->
    <fieldset style="display:none;">
        <legend>Datos Institucionales</legend>
       
       
                 <table>
                   
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
                       
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" Visible="false">
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
                   
                   
                   
    </fieldset>
    <table>
           <tr>
               <td>
                    <fieldset >
        <legend>Municipios</legend>
                        <asp:Label runat="server" ID="lblEstudentVacio" Visible="true"></asp:Label>
         <asp:GridView ID="GridMunicipio" runat="server" CellPadding="4" DataKeyNames="coddepartamento" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                             <asp:BoundField DataField="coddepartamento" HeaderText="coddepartamento" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod" HeaderText="codmunicipio" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                          <%--  <asp:BoundField DataField="tipo" HeaderText="Tipo">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="nombre"  HeaderText="Nombre" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <%-- <asp:BoundField DataField="nomgrado" HeaderText="Grado">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>  --%>                         
                            
                           
                            <asp:TemplateField>
                                <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkseleccionartodo" AutoPostBack="true" OnCheckedChanged="chkseleccionartodo_Click" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkListEstudiante" />
                                </ItemTemplate>
                             </asp:TemplateField>
                             <%-- <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:ImageButton ID="btnEditarEstudiante" runat="server" ImageUrl='~/Imagenes/edit.png' Width="20px" Height="20px" Style="cursor: pointer" OnClick="btnEditarEstudiante_Click" />
                                    <asp:ImageButton runat="server" ID="btnEditarEstudiante" ImageUrl="~/Imagenes/edit.png" Width="20" OnClick="btnEditarEstudiante_Click" />
                                </ItemTemplate>
                             </asp:TemplateField>--%>
                       <asp:TemplateField ShowHeader="False">
                                <%--<ItemTemplate>
                                    <asp:ImageButton ID="lnkEliminarEstudianteRedTematica" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="lnkEliminarEstudianteRedTematica_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción?')){ return false; };" />
                                          <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
                          </ItemTemplate>--%>
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
                <asp:Button runat="server" ID="btnSeleccionarEstudiantes" Visible="false" CssClass="btn btn-danger" Text="Agregar Municipios" OnClick="btnSeleccionarEstudiantes_Click" />               
            </td>

           <%-- <td width="30%">
                <asp:Button runat="server" ID="btnBorrarSeleccion" Visible="false" CssClass="btn btn-danger" Text="Borrar Selección" OnClick="btnBorrarSeleccionados_Click" OnClientClick="if(!confirm('¿Está Seguro en realizar esta acción? Los estudiantes seleccionados serán borrados permanentemente.')){ return false; };" />
            </td>--%>
                             </td></tr></table>

                        
    </fieldset>
               </td>
             
           </tr>
       </table>
    </fieldset>
    <fieldset style="display:none;">
         <legend>Municipios Cargados</legend>  
            <table align="center">
                <tr>
                    <td>
                          <fieldset>
                             <legend>Municipos cargados para la Feria Municipal</legend>  
                              <asp:GridView ID="GridSeleccionMunicipios" runat="server" CellPadding="3" AutoGenerateColumns="false" style="margin:0 auto; width:100%"
                                ForeColor="#333333" GridLines="None" 
                                onrowdatabound="GridSeleccionMunicipios_RowDataBound" 
                                onrowdeleting="GridSeleccionMunicipios_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="coddepartamento" HeaderText="Cod. Departamento" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="cod" HeaderText="Cod. Municipio" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre Municipio" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>                                    
                   
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
                           
                            </fieldset>
                    </td>
                
                </tr>
            </table>
         </fieldset>
    
    <fieldset style="display:none;">
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
                    <asp:DropDownList runat="server" ID="dropInstituciones" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropInstituciones_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Sede</td>
                <td>
                    <asp:DropDownList runat="server" ID="dropSedes" CssClass="TextBox"></asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lnkBuscarGrupos" CssClass="btn btn-primary" OnClick="lnkBuscarGrupos_Click">Buscar</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
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
            <br />
            <table Width="100%" align="center">
            <tr>          
                <td>
                    <asp:Button runat="server" ID="lnkAgregarGrupo" Visible="false" CssClass="btn btn-success" Text="Agregar Grupo" OnClick="lnkAgregarGrupo_Click" />               
                </td>
            </tr>
        </table>
        </center>

    </fieldset>

    <fieldset style="display:none;">
        <legend>Selección de Grupos de investigación</legend>

        <asp:GridView ID="GridSeleccionGrupos" runat="server" CellPadding="3" AutoGenerateColumns="false" style="margin:0 auto; width:100%"
            ForeColor="#333333" GridLines="None" onrowdatabound="GridSeleccionGrupos_RowDataBound" onrowdeleting="GridSeleccionGrupos_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="codgrupoinvestigacion" HeaderText="codgrupoinvestigacion" HeaderStyle-CssClass="ocultarcell"><ItemStyle  HorizontalAlign="Center" CssClass="ocultarcell" /></asp:BoundField>
                                    <asp:BoundField DataField="municipio" HeaderText="Municipio" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="institucion" HeaderText="Institución" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="sede" HeaderText="Sede" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                    <asp:BoundField DataField="grupos" HeaderText="Grupos de investigación" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
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

    </fieldset>

    <!--Fin de Esto esta oculto-->
    
 </div> <!-- Fin CrearRed -->      
       


             </fieldset>
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



</asp:Content>

