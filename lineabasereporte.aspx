<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabasereporte.aspx.cs" Inherits="lineabasereporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Reportes de Línea Base</h2>

    <table align="center">
        <tr>
            <td>
                 <asp:Button ID="btncargarReporteLineaBase02" runat="server" CssClass="btn btn-primary" Text="02 - Currículo" OnClick="btncargarReporteLineaBase02_Onclick" />
            </td>
            <td>
                 <asp:Button ID="btncargarReporteLineaBase04" runat="server" CssClass="btn btn-primary" Text="04 - Autopercepción Docente" OnClick="btncargarReporteLineaBase04_Onclick" />
            </td>
            <td>
                 <asp:Button ID="btncargarReporteLineaBase05" runat="server" CssClass="btn btn-primary" Text="05 - Perfil Docente" OnClick="btncargarReporteLineaBase05_Onclick" />
            </td>
            <td>
                 <asp:Button ID="btncargarReporteLineaBase06" runat="server" CssClass="btn btn-primary" Text="06 - Estudiantes" OnClick="btncargarReporteLineaBase06_Onclick" />
            </td>
        </tr>
    </table>
   
    <asp:Panel ID="PanelReporteLineaBase02" runat="server" Visible="false">
        <br />
        <center>
            <asp:Button ID="btnExportar02" CssClass="btn btn-success" Text="Exportar" OnClick="btnExportar02_Click" runat="server" />
            <asp:Button ID="btnImprimir02" CssClass="btn btn-primary" Text="Imprimir" OnClick="btnImprimir02_Click" runat="server" />
         </center>
        <asp:Panel ID="PanelImprimir02" runat="server">
           <asp:Label ID="lblStylePrint02" runat="server"></asp:Label>
             <asp:Label ID="lblResultado02" runat="server" Visible="true"></asp:Label>
        </asp:Panel>
       
    </asp:Panel>

     <asp:Panel ID="PanelReporteLineaBase04" runat="server" Visible="false">
          <br />
        <center>
          <asp:Button ID="btnExportar04" CssClass="btn btn-success" Text="Exportar" OnClick="btnExportar04_Click" runat="server" />
        <asp:Button ID="btnImprimir04" CssClass="btn btn-primary" Text="Imprimir" OnClick="btnImprimir04_Click" runat="server" />
             </center>
          <asp:Panel ID="PanelImprimir04" runat="server">
              <asp:Label ID="lblStylePrint04" runat="server"></asp:Label>
               <asp:Label ID="lblResultado04" runat="server" Visible="true"></asp:Label>
          </asp:Panel>
       
    </asp:Panel>

     <asp:Panel ID="PanelReporteLineaBase05" runat="server" Visible="false">
          <br />
        <center>
          <asp:Button ID="btnExportar05" CssClass="btn btn-success" Text="Exportar" OnClick="btnExportar05_Click" runat="server" />
        <asp:Button ID="btnImprimir05" CssClass="btn btn-primary" Text="Imprimir" OnClick="btnImprimir05_Click" runat="server" />
             </center>
          <asp:Panel ID="PanelImprimir05" runat="server">
              <asp:Label ID="lblStylePrint05" runat="server"></asp:Label>
                <asp:Label ID="lblResultado05" runat="server" Visible="true"></asp:Label>
          </asp:Panel>
      
    </asp:Panel>

      <asp:Panel ID="PanelReporteLineaBase06" runat="server" Visible="false">
           <br />
        <center>
          <asp:Button ID="btnExportar06" CssClass="btn btn-success" Text="Exportar" OnClick="btnExportar06_Click" runat="server" />
        <asp:Button ID="btnImprimir06" CssClass="btn btn-primary" Text="Imprimir" OnClick="btnImprimir06_Click" runat="server" />
             </center>
          <asp:Panel ID="PanelImprimir06" runat="server">
                <asp:Label ID="lblStylePrint06" runat="server"></asp:Label>
               <asp:Label ID="lblResultado06" runat="server" Visible="true"></asp:Label>
          </asp:Panel>
       
    </asp:Panel>
    

</asp:Content>

