<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="repseguimiento.aspx.cs" Inherits="repseguimiento" %>

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
    <div id="mensaje" runat="server"></div> <br /> <br />
    <h2 style="text-decoration: underline;">Reporte de Seguimiento - Estrategia No. 1</h2>
    <br />
  
    <table><tr>
      <%--  <td>Año</td>
        <td><asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"></asp:DropDownList></td>--%>
        <td>Momento</td>
        <td><asp:DropDownList runat="server" ID="dropMomentos" CssClass="TextBox"></asp:DropDownList></td>
        <td><asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="lnkBuscar_Click" ID="lnkBuscar"></asp:LinkButton></td>
           </tr></table>

    <fieldset>
        <legend>Reporte</legend>
        <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-success" OnClick="btnExportar_Click" />
        <asp:Panel ID="export" runat="server">
             
            <asp:label ID="lblResultado" Visible="true" runat="server"></asp:label>
        </asp:Panel>
        

    </fieldset>

</asp:Content>


