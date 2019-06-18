<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estradosmomentos.aspx.cs" Inherits="estradosmomentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <%--<script src="Scripts/pruebas.js"></script>--%>

     <script>
        $(document).ready(function () {
            $("#MainContent_accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#MainContent_accordion").attr("style", "visibility:visible;");

        });

    </script>
     <script>
         function abrir(panel) {
             var p = parseInt(panel);
             $(function () {
                 $("#MainContent_accordion").accordion({
                     heightStyle: "content",
                     active: p
                 });
             });
         }
    </script>


    <style type="text/css">
        img.res {
            width: 100%;
            max-width: 600px;
        }

        .navegadores {
            background-color: #BECECE;
            float: right;
            border-top:2px solid #8FA9A9;
            border-left:2px solid #8FA9A9;
            border-collapse: collapse;
            border-radius: 4px 4px 4px 4px;
            position: absolute;
            width: 250px;
            bottom: 0;
            right:0;
            font-size:14px;
            }
 
    </style>

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>

    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false" ></asp:Label>

 <br /><br />
    <h2>Estrategía No. 2 - Momentos</h2>
    <p><b>OBJETIVO ESPECÍFICO:</b> Formar a los maestros(as) de los niños(as) y jóvenes del Magdalena en el desarrollo de las habilidades, capacidades y competencias científicas, tecnológicas y de innovación y en el uso y apropiación de las herramientas virtuales.</p>

   
    <div id="accordion" runat="server" >
         
     </div>

</asp:Content>

