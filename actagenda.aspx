<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="actagenda.aspx.cs" Inherits="actagenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />


    <style type="text/css">
        .auto-style1 {
            color: #f00;
            font-size:95%;
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
                 $('#dropCliente').filterByText($('#textbox'), false);
                 $("#dropCliente option").click(function () {
                     alert(1);
                 });
             });
         }
    </script>

    <link rel='stylesheet' href='calendar/lib/cupertino/jquery-ui.min.css' />
    <link href='calendar/fullcalendar.css' rel='stylesheet' />
    <link href='calendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <link href="Styles/list.css" rel="stylesheet" />

    <style type="text/css">
        body {
            margin: 40px 10px;
            padding: 0;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
            font-size: 14px;
        }

        #calendar {
            max-width: 90%;
            margin: 0 auto;
            height: 400px;
        }

        .header {
            color: #000;
            background-color: #DBDBDB;
            padding: 8px 10px 13px 15px;
            height: 13px;
            font-size: 16px;
            font-family: inherit;
            font-weight: 600;
            border: 1px solid #c1c1c1;
            margin-bottom: 8px;
        }

        .auto-style1 {
            color: #FF0000;
        }

        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

        .zona_izq {
            /*width:180px;*/
            padding: 2px;
            /*float:left;*/
            position: relative;
            margin-right: 5px;
            margin-left: -10px;
            /*border:2px solid #ccc;*/
            padding: 3px;
            border-radius: 5px;
            -moz-border-radius: 5px;
            /*min-height:330px;*/
        }

            .zona_izq > .divi1 {
                background-color: #fff;
                margin-bottom: 10px;
                padding: 4px;
                border-radius: 5px;
                -moz-border-radius: 5px;
                /*min-height:50px;*/
                font-size: 95%;
            }

        .divi_opciones {
            background-color: #F9F9F9;
            vertical-align: top;
            display: flex;
            border-radius: 5px;
            padding: 4px;
            margin-right: 2px;
            margin-bottom: 2px;
            float: left;
            color: #000;
        }

            .divi_opciones:hover {
                background-color: #ebebeb;
            }

        .divi_opciones_img {
            width: 20px;
            margin-left: 5px;
            height: 20px;
        }
       
        .cajafiltroCentrado {
            background-color: #F9F9F9;
            border: 0px;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            padding: 0px;
            border-spacing: 1px;
            margin: 0;
            width: 100%;
        }

        .calendario {
            float: left;
        }
        /*Color al titulo del calendario*/
        .fc-toolbar {
            background-color: #BCD9EF;
            border: 1px solid #87B7D6;
            border-radius: 7px;
            -moz-border-radius: 7px;
        }

        /*SCROLLBAR - Para Chrome y Opera*/
        ::-webkit-scrollbar {
            width: 13px;
        }

        ::-webkit-scrollbar-track {
            background-color: #eaeaea;
            border-left: 1px solid #ccc;
        }

        ::-webkit-scrollbar-thumb {
            background-color: #ccc;
        }

            ::-webkit-scrollbar-thumb:hover {
                background-color: #aaa;
            }


        /*Listado de Actividades*/
        .evento_gnral {
            border: 1px solid #e6e6e6;
            border-left: 4px solid #f00;
            min-height: 40px;
            /*margin-top:2px*/
        }

            .evento_gnral:hover {
                border: 1px solid #cccccc;
                border-left: 4px solid #f00;
            }

        .evento_color {
            min-height: 40px;
            float: left;
            border-right: 1px solid #ccc;
        }

        .evento_titulo {
            padding-left: 8px;
            font-weight: bold;
            background-color: #E6E6E6;
        }

        .evento_descripcion {
            margin-left: 8px;
            font-size: 80%;
        }
        .evento_img{
            width: 20px;
            margin-left: 5px;
            height: 20px;
            float:right;
            right:0px;
        }
        .fieldset {
            padding: 0px;
        }

        .decorLink {
            text-decoration: none;
            /*background: #004491;*/
            padding: 2px 4px;
            color: #000;
            border-radius: 6px;
        }
    </style>

    <script src='calendar/lib/moment.min.js'></script>
    <script src='calendar/lib/jquery.min.js'></script>
    <script src='calendar/fullcalendar.min.js'></script>
    <script type="text/javascript" src='calendar/lang/es.js'> </script>
    <script type="text/javascript" src='calendar/gcal.js'></script>
      
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblOperacion" runat="server" Visible="false"></asp:Label>
     <asp:Label ID="lblCodEvento" runat="server" Visible="false"></asp:Label>
   
    <div id="mensaje" runat="server"></div>
    <script>
        function saludar() {
            $(document).ready(function () {
                // Recargo la página
                location.reload();
            });

        }
    </script>
    <div class="zona_izq">
        <div class="divi1">
            <asp:Panel ID="PanelAgregarAct" runat="server" Visible="false">
                <div class="divi_opciones">
                    <asp:ImageButton ID="imgAddGeneral" runat="server" CssClass="divi_opciones_img" ToolTip="Agregar Nuevos Eventos" ImageUrl="~/Imagenes/agenda_icons.png" Style="object-fit: none; object-position: -60px;" OnClick="imgAddGeneral_Click" />
                    <p style="margin: 3px 0 0 3px">Nueva Actividad</p>
                </div>
            </asp:Panel>

            <a id="refrescar" href="javascript:saludar()" runat="server">
                <div class="divi_opciones">
                    <div></div>
                    <img class="divi_opciones_img" alt="Refrescar" src="Imagenes/agenda_icons.png" style="object-fit: none; object-position: -20px;" />
                    <p style="margin: 3px 0 0 3px">Recargar Calendario.</p>
                </div>
            </a>
            <div class="divi_opciones">
                <asp:ImageButton ID="imgListaEventos" CssClass="divi_opciones_img" runat="server" ToolTip="Ver mi lista" ImageUrl="~/Imagenes/agenda_icons.png" Style="object-fit: none; object-position: 0;" OnClick="imgListaEventos_Click" />
                <p style="margin: 3px 0 0 3px">Lista de actividades.</p>
            </div>
            <div class="divi_opciones">
                <img class="divi_opciones_img" alt="Refrescar" src="Imagenes/agenda_icons.png" style="object-fit: none; object-position: -40px;" />
                <p style="margin: 3px 3px 0 3px">Estados: </p>
                <asp:Label ID="lblColores" runat="server" Style="display: inherit;"></asp:Label>
            </div>
            <asp:Panel ID="PanelFiltros" runat="server" Visible="false">
                <div class="divi_opciones">
                    <table>
                        <tr>
                            <td>Proyecto</td>
                            <td>
                                <asp:DropDownList ID="dropProyectoFiltrar" runat="server" CssClass="TextBox"></asp:DropDownList></td>
                            <td>Estado</td>
                            <td>
                                <asp:DropDownList ID="dropEstadoFiltrar" runat="server" CssClass="TextBox"></asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnFiltrar" runat="server" CssClass="botones" Text="Filtrar" OnClick="btnFiltrar_Click" /></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            
            <div style="clear: both"></div>
        </div>
    </div>
    <div style="clear: both"></div>
    <div id='calendar' class="calendario"></div>

    <ajx:ModalPopupExtender ID="PanelAgregarEvento_Modalpopupextender2" runat="server" Enabled="True"
        TargetControlID="imgAddGeneral" PopupControlID="PanelAgregarEvento" CancelControlID="btnCerrarAgregarEvento"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarEvento" runat="server" CssClass="modalPopup">
        <header class="headerpopup">
            <div style="float: left; margin-right: 15px" id="Div2">
                Agregar Actividad
            </div>
            <div style="float: right;">
                <asp:Label ID="btnCerrarAgregarEvento" runat="server" Text="Cerrar" CssClass="botones"></asp:Label>
            </div>
        </header>
        <section class="sectionpopup">
            <fieldset>
                <legend>Campos obligatorios  <span class="auto-style1">*</span></legend>
                <table align="center" cellpadding="4">
                    <tr>
                        <td class="primeracolumna">Tipo de actividad: <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="dropTipoActividad" runat="server" CssClass="TextBox" AutoPostBack="True" OnSelectedIndexChanged="dropTipoActividad_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVdropTipoActividad" runat="server" Display="None" ErrorMessage="Selecciones el tipo de actividad"
                                ControlToValidate="dropTipoActividad" Text="*" ValidationGroup="AgregarR" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RFVdropTipoActividad"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" style="display: inline">
                                <ContentTemplate>
                                     <asp:Label ID="lblAns" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblColorFiltro" runat="server" Style="display: inline;"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropTipoActividad" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="primeracolumna">Descripción :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDescripción" runat="server" CssClass="TextBox" placeholder="Describa la actividad." Width="300px" TextMode="MultiLine" Rows="3" Style="resize: none"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Fecha Inicio <span class="auto-style1">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaIni" runat="server" MaxLength="10" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa" AutoPostBack="true" OnTextChanged="txtFechaIni_TextChanged"></asp:TextBox>
                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFechaIni" FilterType="Custom, Numbers" ValidChars="-"></ajx:FilteredTextBoxExtender>
                            <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server"
                                DefaultView="Days" Enabled="True" Format="dd-MM-yyyy"
                                TargetControlID="txtFechaIni"></ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaIni" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                ControlToValidate="txtFechaIni" ValidationGroup="Agregar"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                Style="color: #FF0000"></asp:RegularExpressionValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="REVtxtFechaIni"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite fecha inicio"
                                ControlToValidate="txtFechaIni" Text="*" ValidationGroup="AgregarR"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RFVtxtFechaIni"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                        <td class="primeracolumna">Hora Inicio:
                        </td>
                        <td>
                            <asp:DropDownList ID="dropHoraini" AutoPostBack="true" OnSelectedIndexChanged="dropHoraini_SelectedIndexChanged" CssClass="TextBox" runat="server">
                                <asp:ListItem Selected="True">00</asp:ListItem>
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>

                            </asp:DropDownList>&nbsp&nbsp<asp:DropDownList ID="dropMinutosini" CssClass="TextBox" runat="server">
                                <asp:ListItem Selected="True">00</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>35</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>55</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3" style="font-size: 80%; color: #2a2a2a">
                            <p style="text-justify: auto">
                                <b>NOTA:</b>
                            <p>Las horas del <b>ANS</b> tipos de actividad es una guia, Puede colocar la hora que necesite.</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Fecha Cierre
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtFechaFin" MaxLength="10" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFechaFin" FilterType="Custom, Numbers" ValidChars="-"></ajx:FilteredTextBoxExtender>
                                    <ajx:CalendarExtender ID="txtFechaFin_CalendarExtender1" runat="server"
                                        DefaultView="Days" Enabled="True" Format="dd-MM-yyyy"
                                        TargetControlID="txtFechaFin"></ajx:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="REVtxtFechaFin" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                        ControlToValidate="txtFechaFin" ValidationGroup="Agregar"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="REVtxtFechaFin"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVtxtFechaFin" runat="server" Display="None" ErrorMessage="Digite fecha cierre"
                                        ControlToValidate="txtFechaFin" Text="*" ValidationGroup="AgregarR"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVtxtFechaFin"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtFechaIni" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="primeracolumna">Hora Fin:
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="dropHorafin"  CssClass="TextBox" runat="server" style="display:inline">
                                        <asp:ListItem Selected="True">00</asp:ListItem>
                                        <asp:ListItem>01</asp:ListItem>
                                        <asp:ListItem>02</asp:ListItem>
                                        <asp:ListItem>03</asp:ListItem>
                                        <asp:ListItem>04</asp:ListItem>
                                        <asp:ListItem>05</asp:ListItem>
                                        <asp:ListItem>06</asp:ListItem>
                                        <asp:ListItem>07</asp:ListItem>
                                        <asp:ListItem>08</asp:ListItem>
                                        <asp:ListItem>09</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>

                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropHoraini" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel><asp:DropDownList ID="dropMinutosfin"  style="display:inline" CssClass="TextBox" runat="server">
                                <asp:ListItem Selected="True">00</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>35</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>55</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Proyecto: <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="dropProyectos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropProyectos_SelectedIndexChanged" CssClass="TextBox"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVdropProyectos" runat="server" Display="None" ErrorMessage="Selecciones el proyecto"
                                        ControlToValidate="dropProyectos" Text="*" ValidationGroup="AgregarR" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RFVdropProyectos"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr >
                        <td  class="primeracolumna">Cliente: 
                        </td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    
                                    <table>
                                        <tr>
                                            <td>Filtrar</td>
                                            <td> <input id="textbox" type="text" class="TextBox" style="width:200px" placeholder="Digita Nombre o Id" /></td>
                                        </tr>
                                           <tr>
                                            <td colspan="2"><asp:DropDownList ID="dropCliente" ClientIDMode="Static" runat="server" CssClass="TextBox"></asp:DropDownList><asp:Label ID="lblvalidador" runat="server" visible="true"></asp:Label></td>
                                            
                                        </tr>
                                          <tr>
                        <td colspan="2" style="text-align: center; font-size: 12px"><b>Tecnicos:</b>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                    <asp:CheckBoxList ID="cblTecnicos" runat="server" RepeatColumns="5" CssClass="TextBox">
                            </asp:CheckBoxList>
                            </center>

                        </td>
                    </tr>
                                    </table>
                                   
                                    
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropProyectos" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                  
                </table>
                <br />
                <br />

            </fieldset>
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnAddEvento" runat="server" Text="Agregar Evento" CssClass="btn btn-success"
                    ValidationGroup="AgregarR" OnClick="btnAddEvento_Click" />
                <asp:Button ID="btnEditar" Style="text-align: center; margin: 2px 2px 2px 2px" runat="server" Text="Editar Evento" CssClass="btn btn-primary"
                    ValidationGroup="AgregarR" OnClick="btnEditar_Click" Visible="false" />
            </div>
        </footer>
    </asp:Panel>
     <asp:Button ID="btnShowListadoUsuario" runat="server" style="display:none"/>
    <ajx:modalpopupextender id="PanelListadoUsuario_Modalpopupextender" runat="server" enabled="True"
        targetcontrolid="btnShowListadoUsuario" popupcontrolid="PanelListadoUsuario" cancelcontrolid="btnCerrarListadoUsuario"
        backgroundcssclass="modalBackground">
    </ajx:modalpopupextender>
    <asp:Panel ID="PanelListadoUsuario" runat="server" CssClass="modalPopup">
        <div id="mensaje2" runat="server"></div>
        <header class="headerpopup">        
            <div style="float:left;margin-right:15px">
                Listado de Actividades
            </div>
            <div style="float:right;">
                <asp:Label ID="btnCerrarListadoUsuario" runat="server" Text="Cerrar" CssClass="botones" ></asp:Label>
            </div>
        </header>
        <section class="sectionpopup">           
            <fieldset style="min-width:500px;">
                <table align="left" style="width:100%">
                    <tr>
                        <td>
                            Desde:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaIniFiltro"  MaxLength="10" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajx:FilteredTextBoxExtender ID="filtro" runat="server" TargetControlID="txtFechaIniFiltro" FilterType="Custom, Numbers" ValidChars="-">
                             </ajx:FilteredTextBoxExtender>
                            <ajx:CalendarExtender ID="txtFechaIniFiltro_CalendarExtender" runat="server"
                                DefaultView="Days" Enabled="True" Format="dd-MM-yyyy"
                                TargetControlID="txtFechaIniFiltro">
                            </ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaIniFiltro" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                ControlToValidate="txtFechaIniFiltro" ValidationGroup="Filtrar"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                Style="color: #FF0000"></asp:RegularExpressionValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="REVtxtFechaIniFiltro"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                      
                        </td>
                        <td>
                            Hasta:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaFinFiltro"  MaxLength="10" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                             <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFechaFinFiltro" FilterType="Custom, Numbers" ValidChars="-">
                            </ajx:FilteredTextBoxExtender>
                            <ajx:CalendarExtender ID="txtFechaFinFiltro_CalendarExtender" runat="server"
                                DefaultView="Days" Enabled="True" Format="dd-MM-yyyy"
                                TargetControlID="txtFechaFinFiltro">
                            </ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaFinFiltro" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                ControlToValidate="txtFechaFinFiltro" ValidationGroup="Filtrar"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                Style="color: #FF0000"></asp:RegularExpressionValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="REVtxtFechaFinFiltro"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                         
                        </td>   
                        <td rowspan="2" style="vertical-align:middle">
                            <asp:Button ID="btnFiltrarLista" runat="server" ValidationGroup="Filtrar" Text="Filtrar"  CssClass="btn btn-primary" OnClick="btnFiltrarLista_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Proyecto:
                        </td>
                        <td>
                            <asp:DropDownList ID="dropProyectoLista" runat="server" CssClass="TextBox" style="max-width:250px"></asp:DropDownList>
                        </td>
                        <td>
                            Estado:
                        </td>
                        <td>
                            <asp:DropDownList ID="dropEstadoLista" runat="server" Visible="true" style="max-width:250px" CssClass="TextBox">
                           </asp:DropDownList>
                          </td>
                      </tr>
                </table>
            </fieldset>
            <div style="height: 350px; overflow-x: auto; margin-top:5px;">
                <asp:Label ID="lblMiLista_BETA" runat="server" ></asp:Label>
            </div>
        </section>
        <footer class="footerpopup" style="height:5px;">        
            <div style="text-align:center">                
            </div>
        </footer>  
    </asp:Panel>
</asp:Content>

