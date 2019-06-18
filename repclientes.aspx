<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="repclientes.aspx.cs" Inherits="repclientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
        function imprSelec(muestra)
        {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            ventimp.print();
            ventimp.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Ficha Tecnica De Clientes.</h2>
    <br />
    <table cellpadding="4" align="center">
        <tr>
            <td>Seleccione Proyecto:
            </td>
            <td>
                <asp:DropDownList ID="DropProyecto" runat="server" CssClass="TextBox"
                    Width="235px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDropProyecto" runat="server" ErrorMessage="Seleccione Proyecto"
                    Text="*" Display="None" ControlToValidate="DropProyecto" InitialValue="Seleccione"
                    ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVDropProyecto"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                <asp:Label ID="lblPerfilEsc" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnSeleccioneProyecto" runat="server" Text="Seleccionar"
                    CssClass="botones" ValidationGroup="Usuario"
                    OnClick="btnSeleccioneProyecto_Click" />
            </td>
        </tr>
    </table>
    <table class="cajafiltroCentrado" id="botones" runat="server" visible="false">
        <tr>
            <td>
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
           
            
     
    <asp:Label ID="lblClientes" runat="server"></asp:Label>

        </div> 
</asp:Content>


