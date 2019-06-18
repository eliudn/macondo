<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabasereportedet.aspx.cs" Inherits="lineabasereportedet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />

      <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Reporte de Línea Base: </h2>
        </div>
        <div style="float: right;margin-top: 20px">
            <a href="lineabasereporte.aspx" id="btnRegresar" runat="server" class="btn btn-primary">Volver</a>
        </div>
    </div>

    <asp:Label ID="lblCodInstrumento" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodIndicador" runat="server" Visible="false"></asp:Label>
     
    
    <asp:Label ID="lblResultado" runat="server" Visible="true"></asp:Label>

   
    

</asp:Content>

