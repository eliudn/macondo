<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="repseguimiento3.aspx.cs" Inherits="repseguimiento3" %>

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
    <h2 style="text-decoration: underline;">Reporte de Seguimiento - Estrategia No. 4</h2>
    <br />

    
  
    <table><tr>
        <td>Año:</td>
        <td><asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"></asp:DropDownList></td>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

              <%--  <td>Momento</td>
                <td><asp:DropDownList runat="server" ID="dropMomentos" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropMomento_OnSelectedIndexChanged"></asp:DropDownList></td>--%>
                <td>Sesión:</td>
                <td><asp:DropDownList runat="server" ID="dropSesion" CssClass="TextBox">
                    <asp:ListItem>1</asp:ListItem><asp:ListItem>2</asp:ListItem><asp:ListItem>3</asp:ListItem><asp:ListItem>4</asp:ListItem><asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem><asp:ListItem>7</asp:ListItem><asp:ListItem>8</asp:ListItem><asp:ListItem>9</asp:ListItem><asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList></td>
                <%-- <td>Jornada</td>
                 <td><asp:DropDownList runat="server" ID="dropJornada" CssClass="TextBox" >
                    </asp:DropDownList></td>--%>
                <td>Formación:</td>
                <td>
                    <asp:RadioButtonList ID="rbtFormacion" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Presencial</asp:ListItem>
                        <asp:ListItem>Virtual</asp:ListItem>
                    </asp:RadioButtonList>
                </td>

            </ContentTemplate>
        </asp:UpdatePanel>

         <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                   
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>
      
        <td><asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="lnkBuscar_Click" ID="lnkBuscar"></asp:LinkButton></td>
           </tr></table>
    
    <fieldset>
        <legend>Reporte</legend>

        <asp:label ID="lblResultado" Visible="true" runat="server"></asp:label>

    </fieldset>

</asp:Content>


