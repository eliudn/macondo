<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseconficode.aspx.cs" Inherits="lineabaseconficode" %>

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
   <script src="js/confi_generalLB.js" type="text/javascript"></script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display:none;" ></div>
<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Configuración y Activación de Códigos de acceso</h2><br />

    <fieldset>
        <legend>Detalles de la configuración</legend>
       <table>
           <tr>
               <td>
                   De clic para ejecutar la activación de códigos para el acceso de los usuarios
               </td>
               <td>
                   <asp:Button ID="btnActivacionCode"  runat="server" CssClass="btn btn-success" Text="Generar" OnClick="btnActivacionCode_Click" />
               </td>
           </tr>
       </table>
        <br /><br />
        <table align="center">
            <tr>
                <td>
                     <asp:Button ID="btnExportar02" CssClass="btn btn-success" Text="Exportar" OnClick="btnExportar02_Click" runat="server" />
                     <asp:Button ID="btnImprimir02" CssClass="btn btn-primary" Text="Imprimir" OnClick="btnImprimir02_Click" runat="server" />
                </td>
            </tr>
        </table>

        <asp:Panel ID="PanelGeneracion" runat="server">
             <fieldset>
            <legend>Generación de Códigos</legend>
                  <asp:Label ID="lblStylePrint02" runat="server"></asp:Label>
            <asp:Label runat="server" ID="lblcodes" Visible="true"></asp:Label>

        </fieldset>
        </asp:Panel>
       
       
   </fieldset>
 

</asp:Content>

