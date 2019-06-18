<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="bienvenida.aspx.cs" Inherits="bienvenida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        img.res {
            width: 100%;
            max-width: 200px;
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

        .oval-speech {
          position:relative;
          width:430px;
          padding:50px 40px;
          margin:1em auto 50px;
          text-align:center;
          color:#fff;
          background:#004B96;
          /* css3 */
          background:-webkit-gradient(linear, 0 0, 0 100%, from(#0f1729), to(#004B96));
          background:-moz-linear-gradient(#0f1729, #004B96);
          background:-o-linear-gradient(#0f1729, #004B96);
          background:linear-gradient(#0f1729, #004B96);
          /*
          NOTES:
          -webkit-border-radius:220px 120px; // produces oval in safari 4 and chrome 4
          -webkit-border-radius:220px / 120px; // produces oval in chrome 4 (again!) but not supported in safari 4
          Not correct application of the current spec, therefore, using longhand to avoid future problems with webkit corrects this
          */
          -webkit-border-top-left-radius:220px 120px;
          -webkit-border-top-right-radius:220px 120px;
          -webkit-border-bottom-right-radius:220px 120px;
          -webkit-border-bottom-left-radius:220px 120px;
          -moz-border-radius:220px / 120px;
          border-radius:220px / 120px;

           box-shadow: 2px 3px 5px #888888;
}

        .oval-speech p {font-size:1.25em;}

/* creates part of the curve */
        .oval-speech:before {
              content:"";
              position:absolute;
              z-index:-1;
              bottom:-30px;
              right:50%;
              height:30px;
              border-right:60px solid #004B96;
              background:#004B96; /* need this for webkit - bug in handling of border-radius */
              /* css3 */
              -webkit-border-bottom-right-radius:80px 50px;
              -moz-border-radius-bottomright:80px 50px;
              border-bottom-right-radius:80px 50px;
              /* using translate to avoid undesired appearance in CSS2.1-capabable but CSS3-incapable browsers */
              -webkit-transform:translate(0, -2px);
              -moz-transform:translate(0, -2px);
              -ms-transform:translate(0, -2px);
              -o-transform:translate(0, -2px);
              transform:translate(0, -2px);
               box-shadow: 2px 3px 5px #888888;
        }

/* creates part of the curved pointy bit */
    .oval-speech:after {
          content:"";
          position:absolute;
          z-index:-1;
          bottom:-30px;
          right:50%;
          width:60px;
          height:30px;
          background:#F6F6F6;
          /* css3 */
          -webkit-border-bottom-right-radius:40px 50px;
          -moz-border-radius-bottomright:40px 50px;
          border-bottom-right-radius:40px 50px;
          /* using translate to avoid undesired appearance in CSS2.1-capabable but CSS3-incapable browsers */
          -webkit-transform:translate(-30px, -2px);
          -moz-transform:translate(-30px, -2px);
          -ms-transform:translate(-30px, -2px);
          -o-transform:translate(-30px, -2px);
          transform:translate(-30px, -2px);
    }
 
    </style>

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
   <%--  <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Panel ID="ManualAdmin" runat="server" Visible="false">
       <a href="Manuales/Manual%20helpdesk.pdf"><img src="Imagenes/descarga.jpg" width="15%"  /></a>
    </asp:Panel>
    <asp:Panel ID="ManualCliente" runat="server" Visible="false">
        <a href="Manuales/Manual%20helpdesk%20cliente.pdf"><img src="Imagenes/descarga.jpg" width="15%"  /></a>
      </asp:Panel>
    <asp:Panel ID="ManualAgente" runat="server" Visible="false">
        <a href="Manuales/Manual%20helpdesk%20agente.pdf"><img src="Imagenes/descarga.jpg" width="15%"  /></a>
    </asp:Panel>
    <asp:Panel ID="ManualCoordinador" runat="server" Visible="false">
        <a href="Manuales/Manual%20helpdesk%20coordinador.pdf"><img src="Imagenes/descarga.jpg" width="15%"  /></a>
    </asp:Panel>
    <asp:Panel ID="ManualTecnico" runat="server" Visible="false">
        <a href="Manuales/Manual%20helpdesk%20tecnico.pdf"><img src="Imagenes/descarga.jpg" width="15%"  /></a>
    </asp:Panel>--%>

        <br /><br />
      <!--<center>
         <br /> <br /> <br /> <br /> <br />
   <img height="480" src="Imagenes/navidad.png" />
	<img class="res" src="Imagenes/login/Logotipo.png" />
      
    </center>
	<center><img src="https://www.cloudnets.org/flyers/fondo.png" width="50%" /></center>-->
    <table align="center" border="0">
        <tr >
            <td style="padding:10px">
                 <blockquote class="oval-speech">
                     <p>“<b>Macondo</b> es un conjunto de elementos organizados que interactúan entre sí y con el contexto, con la finalidad de suministrar información periódica para la toma de decisiones oportunas y pertinentes en todos los ámbitos de acción del proyecto y para aportar conocimiento sobre éste”</p>
                </blockquote>
                
                <img src="Imagenes/persona.png" />
            </td>
            <td style="padding:10px">
                 <blockquote class="oval-speech">
                    <p>“<b>Macondo</b> ofrece información sobre el funcionamiento del proyecto, el logro de los objetivos propuestos,  los niveles de desarrollo de la experiencia en cada contexto, las condiciones que afectan los procesos en las distintas instancias y el aporte de los diferentes actores, con el propósito orientar acciones de mejoramiento continuo”</p>
                 </blockquote>
                <img src="Imagenes/persona2.png" style="margin-left:50px;" />
            </td>
        </tr>
    </table>
	

     

 <asp:Button ID="btnShowPopup" runat="server" style="display:none"/>
<ajx:modalpopupextender id="PanelPopup_Modalpopupextender" runat="server" enabled="True"
    targetcontrolid="btnShowPopup" popupcontrolid="PanelPopup" 
    backgroundcssclass="modalBackground">
</ajx:modalpopupextender>

<asp:Panel ID="PanelPopup" runat="server" CssClass="modalPopup" style="position: fixed;z-index: 100001;left: 144.5px;top: 801px;">
    <header class="headerpopup">        
        <div style="float:left;margin-right:15px">
            Verificación de Código!
        </div>
        <div style="float:right;">
            <%--<asp:Label ID="btnCerrarPopup" runat="server" Text="Cerrar" CssClass="botones" ></asp:Label>--%>
        </div>
    </header><br /><br /><br />
    <center>
        <section class="sectionpopup" >
            Ingrese el código: 
           <asp:TextBox ID="txtCodeVerify" CssClass="TextBox" runat="server" Enabled="false" ></asp:TextBox>
            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtCodeVerify" FilterType="Custom, Numbers" ValidChars="+"></ajx:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RFVtxtCodeVerify" runat="server" ErrorMessage="Digite el Código que se le envío a su email"
                Text="*" Display="None" ControlToValidate="txtCodeVerify" ValidationGroup="CodeVerify" >
            </asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtCodeVerify"
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
          </section>
        </center>
        <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label><br />
    <asp:CheckBox id="chkAceptarTerminos" runat="server" /> Aceptar Términos y Condiciones
        <asp:Label ID="lblMensajeCondiciones" runat="server" Visible="false"></asp:Label>
      <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnVerificarCodigo" Visible="false" runat="server" Text="Verificar" CssClass="btn btn-success" ValidationGroup="CodeVerify" OnClick="btnVerificarCodigo_Click" />
                <asp:Button ID="btnRecargarPagina" Visible="false" runat="server" Text="Recargar" CssClass="btn btn-primary" OnClick="btnRecargarPagina_Click" />
                <asp:Button ID="btnSalirPagina" Visible="false" runat="server" Text="Salir" CssClass="btn btn-danger" OnClick="btnSalirPagina_Click" />
            </div>
        </footer>

</asp:Panel>


 
   <%-- <div class="navegadores">
        <table style="width:100%">
            <tr>
                <td style="font-size: 12px; text-align: center;">Utiliza estos navegadores.
                </td>
            </tr>
            <tr style="height: 71px">               
                <td style="text-align: center;">
                    <a href="http://www.google.com/intl/es-419/chrome/browser/" target="_blank">
                        <img src="Imagenes/chrome.png" alt="chrome" width="60px" /></a>
                    <a href="http://www.mozilla.org/es-ES/firefox/new/" target="_blank">
                        <img src="Imagenes/firefox.png" alt="chrome" width="60px" /></a>
                </td>
            </tr>
            <tr>
                <td style="font-size: 12px; text-align: center;">
                    <p>© <%: DateTime.Now.Year %> Funtics</p>
                     <p> Versión 1.0.</p>
                </td>
            </tr>
        </table>
    </div>--%>
           
</asp:Content>

