<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="reptickets.aspx.cs" Inherits="reptickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
       <style>
        .tabla td{
            padding:5px;
        }
           .auto-style1 {
            color: #FF0000;
        }

        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

    </style>
      <style type="text/css">
        @media print {
            @page {size: landscape;}
            thead {display: table-header-group;}
            .cuadroEncabezado{
            display:block;
        }
        }
        .uldef {
            -webkit-margin-before: 2px;
            -webkit-margin-after: 2px;
        }
        .cuadroPeriodo{
            margin:10px auto;
            padding:10px;
            /*border-radius:10px;
            -moz-border-radius:10px;
            -webkit-border-radius:10px;*/
        }
        .cuadroVerde{
            background-color:#dff0d8;
        }
        .cuadroRojo{
            background-color:#f2dede;
        }
        .cuadroplanilla{
                overflow-x:auto;
            }
        .cuadroEncabezado{
            display:none;
        }
        .parrafoExplicacion{
            font-size:11px;
            color:#202020;
        }
 
        .decorLink{
            text-decoration:none;
            color: inherit;            
        }        
    </style>
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
  <%--  <script>


        function filtrar()
        {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm._doPostBack('MainContent_UpdatePanel3', '');
            return false;
        }

        function cambiarClientes()
        {
            var unico = document.getElementById('MainContent_radUnico');
            var multiple = document.getElementById('MainContent_radMultiple');
            if (unico.checked == true) {
                document.getElementById('cliente').style.display = "block";
                document.getElementById('tipoClientes').style.display = "none";
            } else
            {
                if (multiple.checked)
                {
                    document.getElementById('cliente').style.display = "none";
                    document.getElementById('tipoClientes').style.display = "block";
                }
            }
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Reporte de Tickets</h2>
        </div>

        <div style="float: right;">
            <%--<a href="actagenda.aspx" runat="server" id="btnMiAgenda" class="btn btn-primary">Mi Agenda</a>--%>
        </div>
    </div>
     <fieldset>
            <legend>Filtros</legend>

            <table align="center" class="tabla" style="width: 50%">
                <tr>
                    <td>Desde: </td>
                    <td>
                        <asp:TextBox ID="txtFechaIniFiltro" runat="server" CssClass="TextBox" MaxLength="10" placeholder="dd-mm-aaaa" Width="90px"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="filtro" runat="server" FilterType="Custom, Numbers" TargetControlID="txtFechaIniFiltro" ValidChars="-" />
                        <ajx:CalendarExtender ID="txtFechaIniFiltro_CalendarExtender" runat="server" DefaultView="Days" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaIniFiltro" />
                        <asp:RegularExpressionValidator ID="REVtxtFechaIniFiltro" runat="server" ControlToValidate="txtFechaIniFiltro" Display="None" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Style="color: #FF0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="Filtrar"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" CssClass="CustomValidatorCalloutStyle" Enabled="True" HighlightCssClass="Highlight" PopupPosition="BottomLeft" TargetControlID="REVtxtFechaIniFiltro" WarningIconImageUrl="Imagenes/error3.png" Width="250px">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Hasta: </td>
                    <td>
                        <asp:TextBox ID="txtFechaFinFiltro" runat="server" CssClass="TextBox" MaxLength="10" placeholder="dd-mm-aaaa" Width="90px"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers" TargetControlID="txtFechaFinFiltro" ValidChars="-" />
                        <ajx:CalendarExtender ID="txtFechaFinFiltro_CalendarExtender" runat="server" DefaultView="Days" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaFinFiltro" />
                        <asp:RegularExpressionValidator ID="REVtxtFechaFinFiltro" runat="server" ControlToValidate="txtFechaFinFiltro" Display="None" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Style="color: #FF0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="Filtrar"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" CssClass="CustomValidatorCalloutStyle" Enabled="True" HighlightCssClass="Highlight" PopupPosition="BottomLeft" TargetControlID="REVtxtFechaFinFiltro" WarningIconImageUrl="Imagenes/error3.png" Width="250px">
                        </ajx:ValidatorCalloutExtender>
                    </td>

                </tr>
                <tr>
                    <td>Proyecto: </td>
                    <td>
                        <asp:DropDownList ID="dropProyectoLista" runat="server" CssClass="TextBox" Style="max-width: 250px">
                        </asp:DropDownList>
                    </td>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="dropEstadoLista" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Solicitud: </td>
                    <td>
                        <asp:DropDownList ID="dropSolicitudLista" runat="server" CssClass="TextBox" Style="max-width: 250px">
                        </asp:DropDownList>
                    </td>
                    <td>Prioridad:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropPrioridadLista" runat="server" CssClass="TextBox"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: middle; text-align: center">
                        <asp:Button ID="btnFiltrarLista" runat="server" CssClass="btn btn-primary" OnClick="btnFiltrarLista_Click" Text="Filtrar" ValidationGroup="Filtrar" />
                    </td>
                </tr>

            </table>

        </fieldset>
        <fieldset>
        <legend>Resultados</legend>
      <table class="cajafiltroCentrado" id="botones" runat="server" visible="false">
        <tr>
            <td >
              <a id="btnImprimirPlanilla" runat="server" href="javascript:imprSelec('muestra')" class="botones" >Imprimir</a>

            </td>
            <td>
                <asp:Button ID="btnExportExcel" runat="server" Text="Exportar" CssClass="btn btn-success" OnClick="btnExportExcel_Click" />

            </td>
        </tr>
    </table>

   <div id="muestra">
        <link href="Styles/General.css" rel="stylesheet" />
        <link href="Styles/boletin.css" rel="stylesheet" />
        <style type="text/css" media="print">
            @media print {
                @page {size: auto;}
                thead {display: table-header-group;}
                
            }
            
            .cuadroplanilla{
                overflow-x:no-display;
            }
            body{
                font-size:90%;
                background-color:!important;
                background-color:#fff;
                
            }
            .cuadroEncabezado{
                margin:0 auto;
            }
            a{
                text-decoration:none;
                color:inherit;
            }
            .imgedicionnota{
                display:none;
            }
        </style>
           
            
     
    <asp:Label ID="lblTickets" runat="server"></asp:Label>

        </div> 
    </fieldset>

</asp:Content>

