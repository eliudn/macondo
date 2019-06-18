<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseSedeC600B.aspx.cs" Inherits="lineabaseSedeC600B" %>

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
<h2 style="text-decoration: underline;">C600B - Información General por Sede - Jornada</h2>
    <div style="float:right;margin-top:-40px;"><asp:Button ID="btnRegresar" Text="Regresar" runat="server" Onclick="btnRegresar_Click" CssClass="btn btn-primary" /></div><br />
    <asp:Label ID="lblCodInstitucion" runat="server" Visible="False"></asp:Label> 
    <asp:Label ID="lblCodSede" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodAsesor" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblCodInstAsesor" runat="server" Visible="False"></asp:Label>

    <fieldset>
        <legend>Datos Institucional</legend>
        <asp:Label ID="lblDatoInstitucional" runat="server" Visible="true"></asp:Label>
    </fieldset>

     <fieldset>
            <legend>Jornadas</legend>
                <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                    <tr>
                        <td width="25%">
                           <b> 1. Jornadas de la institución educativa</b>
                        </td>
                        <td>
                             <asp:CheckBoxList ID="chkJornadas" runat="server">
                                    <asp:ListItem>Completa</asp:ListItem>
                                    <asp:ListItem>Mañana</asp:ListItem>
                                    <asp:ListItem>Tarde</asp:ListItem>
                                    <asp:ListItem>Nocturna</asp:ListItem>
                                    <asp:ListItem>Fin de semana</asp:ListItem>
                                </asp:CheckBoxList>
                        </td>
                    </tr>
                    </table>
        </fieldset>

    <fieldset>
        <legend></legend>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
               <tr>
                    <td style="font-weight:bold;">
                        2. Genero de la población atendida
                    </td>
                     </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rbtGeneroPoblacionAtendida" runat="server">
                            <asp:ListItem>Masculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Mixto</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
             <tr>
                 <td>
                     <b>3. Niveles de enseñanza que ofrece</b>

                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:CheckBoxList runat="server" ID="chkNivelesEnsenianza" AutoPostBack="true" OnSelectedIndexChanged="chkNivelesEnsenianza_SelectedIndexChanged">
                         <asp:ListItem>Preescolar</asp:ListItem>
                         <asp:ListItem>Básica Primaria</asp:ListItem>
                         <asp:ListItem>Básica secundaria</asp:ListItem>
                         <asp:ListItem>Media</asp:ListItem>
                     </asp:CheckBoxList>
                 </td>
             </tr>
            
             <tr>
                 <td>
                     <asp:Panel ID="PanelCaracteryespecialidadparaMedia" Visible="false" runat="server">
                        <b> Carácter y especialidad para Media </b>
                          <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="auto">
                               
                         <tr>
                             <td style="font-weight:bold;">Carácter</td>
                             <td style="font-weight:bold;" align="center">Especialidad o Intensificación</td>
                         </tr>
                         <tr>
                             <td rowspan="3" style="font-weight:bold;">Académico</td>
                         </tr>
                         <tr>
                             <td style="font-weight:bold;" align="center">Intensificación</td>
                         </tr>
                         <tr>
                             <td>
                                  <asp:CheckBoxList runat="server" ID="chkCaracterAcademico" >
                                     <asp:ListItem>Académico</asp:ListItem>
                                     <asp:ListItem>Ciencias Naturales</asp:ListItem>
                                     <asp:ListItem>Ciencias Sociales</asp:ListItem>
                                     <asp:ListItem>Humanidades</asp:ListItem>
                                      <asp:ListItem>Arte o lenguas extranjeras</asp:ListItem>
                                 </asp:CheckBoxList>
                                 Otro ¿Cuál?
                                 <asp:textbox runat="server" ID="txtOtroAcademico" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                             </td>
                         </tr>
                               <tr>
                             <td rowspan="3" style="font-weight:bold;">Técnico</td>
                         </tr>
                         <tr>
                             <td style="font-weight:bold;" align="center">Especialidad</td>
                         </tr>
                         <tr>
                             <td>
                                  <asp:CheckBoxList runat="server" ID="chkCaracterTecnico" >
                                     <asp:ListItem>Agropecuadrio</asp:ListItem>
                                     <asp:ListItem>Comercial y servicios</asp:ListItem>
                                     <asp:ListItem>Industrial</asp:ListItem>
                                     <asp:ListItem>Pedagógico</asp:ListItem>
                                      <asp:ListItem>Promoción social</asp:ListItem>
                                 </asp:CheckBoxList>
                                 Otro ¿Cuál?
                                 <asp:textbox runat="server" ID="txtOtroTecnico" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                             </td>
                         </tr>
                     </table>
                     </asp:Panel>
                 </td>
             </tr>
                <tr>
                    <td style="font-weight:bold;">4. ¿En esta sede-jornada, se atiende población de grupos étnicos?</td>
                </tr>
              <tr>
                  <td>
                      <asp:RadioButtonList ID="rbtEtnias" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem>Si</asp:ListItem>
                          <asp:ListItem>No</asp:ListItem>
                      </asp:RadioButtonList>
                  </td>
              </tr>
         <tr>
             <td style="font-weight:bold;">5.	¿Qué programas, estrategias o modelos educativos se ofrecen?</td>
         </tr>
             <tr>
                 <td>
                     Preescolar  <br />
                     <asp:CheckBoxList ID="chkEstrategiaModelosEducativosPreescolar" runat="server">
                         <asp:ListItem>Preescolar escolarizado</asp:ListItem>
                         <asp:ListItem>Preescolar semi -escolarizado</asp:ListItem>
                         <asp:ListItem>Preescolar no escolarizado</asp:ListItem>
                     </asp:CheckBoxList>
                     Otro, cuál? <br />
                     <asp:TextBox ID="txtOtroPreescolar" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     Básica Primaria <br />
                     <asp:CheckBoxList ID="chkEstrategiaModelosEducativosPrimaria" runat="server">
                         <asp:ListItem>Educación tradicional</asp:ListItem>
                         <asp:ListItem>Escuela nueva</asp:ListItem>
                         <asp:ListItem>SER</asp:ListItem>
                         <asp:ListItem>CAFAM</asp:ListItem>
                         <asp:ListItem>SAT</asp:ListItem>
                         <asp:ListItem>Etnoeducación</asp:ListItem>
                         <asp:ListItem>Aceleración del Aprendizaje</asp:ListItem>
                         <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                         <asp:ListItem>Transformemos</asp:ListItem>
                     </asp:CheckBoxList>
                     Otro, cuál?  <br />
                     <asp:TextBox ID="txtOtroPrimaria" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     Básica secundaria <br />
                     <asp:CheckBoxList ID="chkEstrategiaModelosEducativosSecundaria" runat="server">
                         <asp:ListItem>Educación tradicional</asp:ListItem>
                         <asp:ListItem>Posprimaria</asp:ListItem>
                         <asp:ListItem>Telesecundaria</asp:ListItem>
                         <asp:ListItem>SER</asp:ListItem>
                         <asp:ListItem>CAFAM</asp:ListItem>
                         <asp:ListItem>SAT</asp:ListItem>
                         <asp:ListItem>Etnoeducación</asp:ListItem>
                         <asp:ListItem>Aceleración del Aprendizaje</asp:ListItem>
                         <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                         <asp:ListItem>Transformemos</asp:ListItem>
                     </asp:CheckBoxList>
                     Otro, cuál?  <br />
                     <asp:TextBox ID="txtOtroSecundaria" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     Media <br />
                     <asp:CheckBoxList ID="chkEstrategiaModelosEducativosMedia" runat="server">
                         <asp:ListItem>Educación tradicional</asp:ListItem>
                         <asp:ListItem>SER</asp:ListItem>
                         <asp:ListItem>CAFAM</asp:ListItem>
                         <asp:ListItem>SAT</asp:ListItem>
                         <asp:ListItem>Etnoeducación</asp:ListItem>
                         <asp:ListItem>Aceleración del Aprendizaje</asp:ListItem>
                         <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                         <asp:ListItem>Transformemos</asp:ListItem>
                     </asp:CheckBoxList>
                     Otro, cuál?  <br />
                     <asp:TextBox ID="txtOtroMedia" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                 </td>
             </tr>
        </table>
        <table ><tr><td><asp:Button ID="btnPrimerGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnPrimerGuardar_Onclick" /></td></tr></table>
 </fieldset>

  
    <fieldset>
        <legend>Información de docentes de la Sede - Jornada</legend>
        Ubique al docente en el nivel educativo donde tenga la mayor carga académica. Incluya los docentes de horas extras. Diligencie únicamente con cifras, no utilice signos. <br />
        <b>6. Personal docente por nivel de enseñanza, según último nivel educativo aprobado por el docente</b>
          <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                
                <tr>
                    <td rowspan="4" colspan="2" style="font-weight:bold;">Último nivel educativo aprobado por el docente</td>
                </tr>
                <tr>
                    <td colspan="15" style="font-weight:bold;" align="center">Nivel educativo en el que dicta el docente</td>
                   
                </tr>
                <tr>
                    <td colspan="3" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Media</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>
                </tr>
              
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Bachillerato pedagógico</td>
                     <td><asp:TextBox ID="txtBachiHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtBachiHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Normalista superior</td>
                    <td><asp:TextBox ID="txtSuperiorHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtSuperiorHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Otro bachillerato</td>
                    <td><asp:TextBox ID="txtOtroBachiHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtroBachiHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                <tr>
                    <td rowspan="3" style="font-weight:bold;">Técnico o tecnológico</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pedagógico</td>
                     <td><asp:TextBox ID="txtTecPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTecPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Otro</td>
                   <td><asp:TextBox ID="txtOtroPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtroPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td rowspan="3" style="font-weight:bold;">Profesional</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pedagógico</td>
                    <td><asp:TextBox ID="txtProfPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtProfPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Otro</td>
                    <td><asp:TextBox ID="txtProfOtroPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtProfOtroPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td rowspan="3" style="font-weight:bold;">Posgrado</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pedagógico</td>
                    <td><asp:TextBox ID="txtPosPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPosPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Otro</td>
                    <td><asp:TextBox ID="txtPosOtroPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPosOtroPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujTotal" Enabled="false"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
          
                 <tr>
                    <td style="font-weight:bold;" align="center" colspan="2">Otro</td>
                    
                     <td><asp:TextBox ID="txtOtroCualHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujPreescolar"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtroCualHomSecundaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujSecundaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualHomMedia"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujMedia"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td style="font-weight:bold;" align="center" colspan="2">Total</td>
                     
                     <td><asp:TextBox ID="txtTotalTotalHomPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalHomPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTotalTotalHomSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
            </table>
        <table ><tr><td><asp:Button ID="btnSegundoGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnSegundoGuardar_Onclick" /></td></tr></table>
        <hr />
        <table>
            <tr>
                <td><b>7. ¿En esta sede-jornada se atiende población con discapacidad o capacidades excepcionales? </b></td>
            </tr>
            <tr>
                <td>
                     <asp:RadioButtonList ID="rbdiscapacidadexcepcional" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbdiscapacidadexcepcional_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (pase a la pregunta No. 8 del presente capítulo)</asp:ListItem>
                         </asp:RadioButtonList>
                </td>
            </tr>
            <asp:Panel ID="Paneldiscapacidadexcepcional" runat="server" Visible="false">
                         <tr>
                           
                                 <td colspan="2">
                                   <b>Número de estudiantes del grupo de investigación con discapacidad o capacidades excepcionales, integrados* a la educación formal, según Género.</b>
                                     <br />
                                     Diligencie únicamente con cifras
                                 </td>
                             </tr>
                         <tr>
                             <td colspan="2">
                                 <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Cateogría</td>
                </tr>
               
                <tr>
                    <td colspan="3" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Media</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>
                </tr>
                                      <tr>
                                          <td>
                                              Con discapacidad
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadHomPreescolar" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                         </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadMujPreescolar" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                           </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadTotalPreescolar" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadHomPrimaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                          <td>  
                                               <asp:TextBox ID="txtDiscapacidadMujPrimaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                          <td>   
                                               <asp:TextBox ID="txtDiscapacidadTotalPrimaria" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadHomSecundaria"  runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                           </td>
                                          <td>  
                                                 <asp:TextBox ID="txtDiscapacidadMujSecundaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                          <td>   
                                               <asp:TextBox ID="txtDiscapacidadTotalSecundaria" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                            <td>   
                                               <asp:TextBox ID="txtDiscapacidadHomMedia" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                           <td>  
                                                 <asp:TextBox ID="txtDiscapacidadMujMedia" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                          <td>   
                                               <asp:TextBox ID="txtDiscapacidadTotalMedia" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                           <td>   
                                               <asp:TextBox ID="txtDiscapacidadHomTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                           <td>  
                                                 <asp:TextBox ID="txtDiscapacidadMujTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                          <td>   
                                               <asp:TextBox ID="txtDiscapacidadTotalTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con capacidades excepcionales
                                          </td>
                                          <td><asp:TextBox ID="txtCapacidadExcepHomPreescolar" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtCapacidadExcepMujPreescolar" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtTotalCapacidadExcepPreescolar" Enabled="false"  runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtCapacidadExcepHomPrimaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtCapacidadExcepMujPrimaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtTotalCapacidadExcepPrimaria" Enabled="false"  runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtCapacidadExcepHomSecundaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtCapacidadExcepMujSecundaria" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtTotalCapacidadExcepSecundaria" Enabled="false"  runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtCapacidadExcepHomMedia" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtCapacidadExcepMujMedia" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtTotalCapacidadExcepMedia" Enabled="false"  runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtCapacidadExcepHomTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtCapacidadExcepMujTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                           <td><asp:TextBox ID="txtTotalCapacidadExcepTotal" Enabled="false"  runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                      </tr>
                                      <tr>
                                          <td>Total</td>
                                          <td><asp:TextBox ID="txtTotalHomPreescolar" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtTotalMujPreescolar" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td></td>
                                          <td><asp:TextBox ID="txtTotalHomPrimaria" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtTotalMujPrimaria" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td></td>
                                           <td><asp:TextBox ID="txtTotalHomSecundaria" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtTotalMujSecundaria" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td></td>
                                           <td><asp:TextBox ID="txtTotalHomMedia" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtTotalMujMedia" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td></td>
                                           <td><asp:TextBox ID="txtTotalHomTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td><asp:TextBox ID="txtTotalMujTotal" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox></td>
                                          <td></td>
                                      </tr>
                                  </table>
                             </td>
                           </tr>
                <tr>
                    <td >
                        <asp:Button ID="btnTercerGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnTercerGuardar_Onclick" />
                    </td>
                </tr>
                    </asp:Panel>
        </table>
        <hr />
        <table>
             <tr>
                     <td colspan="2">
                         <b>8.	Número de estudiantes con discapacidad, integrados y no integrados que hacen parte del grupo de investigación, por categoría y Género. </b>
                          <br />
                                     Diligencie únicamente con cifras
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2" >
                         <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="60%">
                             <tr>
                                 <td rowspan="2" style="font-weight:bold;">
                                     categoría
                                 </td>
                                 <td colspan="3" style="font-weight:bold;" align="center">
                                     Integrados 
                                 </td>
                                  <td colspan="3" style="font-weight:bold;" align="center">
                                     No Integrados 
                                 </td>
                                  <td colspan="3" style="font-weight:bold;" align="center">
                                     Total 
                                 </td>
                                 </tr>
                             <tr>
                                 <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                                 <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                                  <td>
                                     Hombres
                                 </td>
                                 <td>
                                     Mujeres
                                 </td>
                                 <td>
                                     Total
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Auditiva 
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAuditivaHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Visual  
                                 </td>
                                    <td>
                                     <asp:TextBox ID="txtVisualHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtVisualHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisual" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Motora   
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotora" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     Cognitiva    
                                 </td>
                                   <td>
                                     <asp:TextBox ID="txtCognitivaHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtCognitivaHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitiva" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Autismo     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAutismoHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Múltiple     
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleInte" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomNoInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujNoInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultiple" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Otra, ¿cuál?     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraHomInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtOtraHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujNoInte"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Total    
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalNoInte" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Button ID="btnEstudianteDiscapacidad" CssClass="btn btn-danger" Visible="false" Text="Calcular" runat="server" />
                                 </td>
                             </tr>
                         </table>
                     </td>
                 </tr>
             <tr>
                    <td >
                        <asp:Button ID="btnCuartoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnCuartoGuardar_Onclick" />
                    </td>
                </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                   <b> 9.	¿En esta sede-jornada, se atiende población de grupos étnicos?</b>
                </td>
            </tr>
            <tr>
                     <td colpan="2">
                          <asp:RadioButtonList ID="rbGrupoEtnico" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbGrupoEtnico_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (pase a la pregunta No.10)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
            <asp:Panel ID="PanelGrupoEtnicos" runat="server" Visible="false">
                     <tr>
                         <td>
                            Número de estudiantes de grupos étnicos del grupo de investigación, según Género.
                             <br />
                              Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                              <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Nombre del Grupo Etnico</td>
                </tr>
               
                <tr>
                    <td colspan="3" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Media</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>
                </tr>
                                  <tr>
                                      <td>
                                          Indígenas
                                      </td>
                                      <td><asp:TextBox ID="txtIndigenaHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtIndigenaHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtIndigenaHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtIndigenaHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtIndigenaHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtIndigenaTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td>
                                        Rom (gitanos)
                                      </td>
                                      <td><asp:TextBox ID="txtRomHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtRomHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtRomHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtRomHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtRomHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td>Afrocolombianos, afrodecendientes, negro o mulato.</td>
                                      <td><asp:TextBox ID="txtAfroHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtAfroHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtAfroHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtAfroHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtAfroHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtAfroTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Raizal del archipiélago de San Andrés, Providencia y Santa Catalina
                                      </td>
                                       <td><asp:TextBox ID="txtRaizaHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtRaizaTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Palenquero de San Basilio 
                                      </td>
                                      <td><asp:TextBox ID="txtPalenqueroHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtPalenqueroHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtPalenqueroTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Total 
                                      </td>
                                      <td><asp:TextBox ID="txtTotalHomEtnicoPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalMujEtnicoPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td> <asp:TextBox ID="txtTotalEtnicaPreescolar" Enabled="false" CssClass="TextBox" Width="50" runat="server" ></asp:TextBox></td>
                                       <td><asp:TextBox ID="txtTotalHomEtnicoPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalMujEtnicoPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalEtnicaPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalHomEtnicoSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalMujEtnicoSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalEtnicaSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalHomEtnicoMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalMujEtnicoMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalEtnicaMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalHomEtnicoTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalMujEtnicoTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                      <td><asp:TextBox ID="txtTotalEtnicaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                  </tr>
                                  </table>
                         </td>
                     </tr>
                   <tr>
                <td>
                    Nombre del grupo indígena
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox id="txtNomGrupoIndigena" runat="server" CssClass="TextBox" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                </td>
            </tr>
                 <tr>
                    <td >
                        <asp:Button ID="btnQuintoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnQuintoGuardar_Onclick" />
                    </td>
                </tr>
                  </asp:Panel>
         
             <tr>
                     <td colspan="2">
                         <b>10.	¿En esta sede-jornada se atiende población víctima del conflicto?</b>
                     </td>
                 </tr>
                   <tr>
                     <td colspan="2">
                          <asp:RadioButtonList ID="rbVictimaConflicto" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbVictimaConflicto_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (Continúe)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelVictimaConflicto" runat="server" Visible="false">
                     <tr>
                         <td  colspan="2">
                         Número de estudiantes participantes del grupo de investigación víctimas del conflicto.
                             <br />
                                  Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                                <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Nombre del Grupo Etnico</td>
                </tr>
               
                <tr>
                    <td colspan="3" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Media</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>
                </tr>
                            <tr>
                                <td>
                                    En situación de desplazamiento 
                                </td>
                                <td><asp:TextBox ID="txtDesplazamientoHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesplazamientoTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    Desvinculados de organizaciones armadas al margen de la Ley
                                </td>
                                    <td><asp:TextBox ID="txtAlMargenHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                 <td><asp:TextBox ID="txtAlMargenHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtAlMargenTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    Hijos de adultos desmovilizados 
                                </td>
                                <td><asp:TextBox ID="txtDesmovilizadosHomPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txtDesmovilizadosMujPreescolar" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txtDesmovilizadosTotalPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                 <td><asp:TextBox ID="txtDesmovilizadosHomPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosMujPrimaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosHomSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosMujSecundaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosTotalSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosHomMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosMujMedia" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosTotalMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosHomTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtDesmovilizadosTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    Total
                                </td>
                                <td><asp:TextBox ID="txtTotalHomConflictoPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalMujConflictoPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalConflictoPreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                 <td><asp:TextBox ID="txtTotalHomConflictoPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalMujConflictoPrimariar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalConflictoPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalHomConflictoSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalMujConflictoSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalConflictoSecundaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalHomConflictoMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalMujConflictoMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalConflictoMedia" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalHomConflictoTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalMujConflictoTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                                <td><asp:TextBox ID="txtTotalConflictoTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                            </tr>
                         </table>
                         </td>
                     </tr>
                     <tr>
                    <td >
                        <asp:Button ID="btnSextoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnSextoGuardar_Onclick" />
                    </td>
                </tr>
                </asp:Panel>
        </table>
    </fieldset>
   
    <fieldset>
        <legend>Información de estudiantes del presente año por Sede - Jornada</legend>
        <b>11. Para los niveles de Preescolar y Básica primaria</b>
         <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Género edades en años cumplidos </td>
                                           <td align="center" colspan="6">Preescolar</td>
                                           <td colspan="2"></td>
                                           <td align="center" colspan="10">Básica Primaria</td>
                                           <td colspan="2"></td>
                </tr>
               
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Pre jardín</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Jardín</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Transición</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total Preescolar</td>
                    <td colspan="2" style="font-weight:bold;" align="center">1°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">2°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">3°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">4°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">5°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total Básica Primaria</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                </tr>
             <tr>
                 <td>3</td>
                        <td><asp:TextBox ID="txtEdad3HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad3MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>4</td>
                 <td><asp:TextBox ID="txtEdad4HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad4MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>5</td>
                        <td><asp:TextBox ID="txtEdad5HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad5MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>6</td>
                 <td><asp:TextBox ID="txtEdad6HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad6MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>7</td>
                 <td><asp:TextBox ID="txtEdad7HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad7MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>8</td>
                 <td><asp:TextBox ID="txtEdad8HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad8MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>9</td>
                 <td><asp:TextBox ID="txtEdad9HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad9MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>10</td>
                 <td><asp:TextBox ID="txtEdad10HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad10MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>11</td>
                  <td><asp:TextBox ID="txtEdad11HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad11MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>12</td>
                  <td><asp:TextBox ID="txtEdad12HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad12MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>13</td>
                  <td><asp:TextBox ID="txtEdad13HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad13MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>14</td>
                  <td><asp:TextBox ID="txtEdad14HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad14MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>15 y más</td>
                  <td><asp:TextBox ID="txtEdad15HomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15HomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdad15MujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Total general </td>
                  <td><asp:TextBox ID="txtEdadGeneralHomPrejardin" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujPrejardin" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomJardin" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujJardin" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomTransicion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujTransicion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomPrimero" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujPrimero" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomSegundo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujSegundo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomTercero" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujTercero" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomCuarto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujCuarto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomQuinto" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujQuinto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralHomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGeneralMujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                  <td>Núm. Repitentes o re iniciantes</td>
                     <td><asp:TextBox ID="txtEdadRepitentesHomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesHomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadRepitentesMujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Núm. De grupos por grado*</td>
                  <td><asp:TextBox ID="txtEdadGruposPorGradoHomPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujPrejardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomJardin"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujJardin" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomTransicion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujTransicion"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujTotalpreescolar" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomPrimero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujPrimero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomCuarto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujCuarto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomQuinto"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujQuinto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoHomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEdadGruposPorGradoMujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             </table>
        <table>
             <tr>
                    <td >
                        <asp:Button ID="btnSeptimoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnSeptimoGuardar_Onclick" />
                    </td>
                </tr>
        </table>
        <hr />
        <b>12. Información de matrícula del programa de aceleración del aprendizaje, en el presente año lectivo.</b>
         <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
             <tr>
                 <td rowspan="3">Básica Primaria</td>
             </tr>
             <tr>
                 <td colspan="9" align="center">Edad (años)</td>
             </tr>
             <tr>
                 <td>10</td>
                 <td>11</td>
                 <td>12</td>
                 <td>13</td>
                 <td>14</td>
                 <td>15</td>
                 <td>16</td>
                 <td>17</td>
                 <td>Total</td>
             </tr>
             <tr>
                 <td>Hombre</td>
                 <td><asp:TextBox ID="txtHom10Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtHom11Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHom12Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHom13Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtHom14Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHom15Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHom16Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHom17Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Mujer</td>
                  <td><asp:TextBox ID="txtMuj10Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMuj11Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMuj12Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMuj13Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMuj14Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMuj15Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMuj16Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMuj17Primaria"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Total</td>
                  <td><asp:TextBox ID="txtHomTotal10Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtHomTotal11Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotal12Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotal13Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtHomTotal14Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotal15Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotal16Primaria" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotal17Primaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtHomTotalTotalPrimaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             </table>
        <table>
             <tr>
                    <td >
                        <asp:Button ID="btnOctavoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnOctavoGuardar_Onclick" />
                    </td>
                </tr>
        </table>

        <br />
        <hr />
        <b>13. Para los niveles  de Básica secundaria y media</b>
         <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Género edades en años cumplidos </td>
                                           <td align="center" colspan="8">Básica Secundaria </td>
                                           <td colspan="2"></td>
                                           <td align="center" colspan="8">Media </td>
                                           <td colspan="2"></td>
                </tr>
               
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">6°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">7°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">8°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">9°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total Básica Secundaria</td>
                    <td colspan="2" style="font-weight:bold;" align="center">10°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">11°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">12°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">13°</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total Media</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                </tr>
             <tr>
                 <td>9 y menos </td>
                        <td><asp:TextBox ID="txt9HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt9MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>10</td>
                 <td><asp:TextBox ID="txt10HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt10MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>11</td>
                         <td><asp:TextBox ID="txt11HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt11MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>12</td>
                 <td><asp:TextBox ID="txt12HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt12MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>13</td>
                 <td><asp:TextBox ID="txt13HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt13MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>14</td>
                 <td><asp:TextBox ID="txt14HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>15</td>
                  <td><asp:TextBox ID="txt15HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt15MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>16</td>
                 <td><asp:TextBox ID="txt16HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt16MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>17</td>
                  <td><asp:TextBox ID="txt17HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt17MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>18</td>
                  <td><asp:TextBox ID="txt18HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt18MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>19</td>
                  <td><asp:TextBox ID="txt19HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt19MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>20 y más</td>
                  <td><asp:TextBox ID="txt20HomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20HomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt20MujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
            
             <tr>
                 <td>Total general </td>
                  <td><asp:TextBox ID="txtGeneralHomSexto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujSexto" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomSeptimo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujSeptimo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomOctavo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujOctavo"  Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomNoveno" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujNoveno" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomDecimo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujDecimo" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomUnDecimo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujUnDecimo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomDecimoSegundo" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujUnDecimoSegundo" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomDecimoTercero" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujDecimoTercero" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralHomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGeneralMujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                  <td>Núm. Repitentes o re iniciantes</td>
                    <td><asp:TextBox ID="txtRepitentesHomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesHomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtRepitentesMujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Núm. De grupos por grado*</td>
                 <td><asp:TextBox ID="txtGruposPorGradosHomSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujSexto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujSeptimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomOctavo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujOctavo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujNoveno"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomTotal" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujDecimo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujUnDecimo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomDecimoSegundo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujUnDecimoSegundo"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomDecimoTercero"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujDecimoTercero" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosHomTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtGruposPorGradosMujTotalTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             </table>
        <table>
            <tr>
                    <td >
                        <asp:Button ID="btnNovenoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnNovenoGuardar_Onclick" />
                    </td>
                </tr>
        </table>
        <hr />
        <b>14. Información de matrícula en educación Media del presente año lectivo, discriminada por carácter y especialidad</b>
        <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
             <tr>
                    <td rowspan="3" colspan="2"  style="font-weight:bold;">Carácter y especialidad para Media </td>
                                           <td align="center" colspan="16">Grados</td>
                                          
                </tr>
               
                <tr>
                    <td colspan="3" style="font-weight:bold;" align="center">10°</td>
                    <td colspan="3" style="font-weight:bold;" align="center">11°</td>
                    <td colspan="3" style="font-weight:bold;" align="center">12°</td>
                    <td colspan="3" style="font-weight:bold;" align="center">13°</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Total</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Cuántos Repitentes?</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                     <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                     <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                     <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                     <td style="font-weight:bold;">Total</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                     <td style="font-weight:bold;">Total</td>

                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                     <td style="font-weight:bold;">Total</td>
                   
                </tr>
             <tr>
                 <td colspan="2">Académica</td>
                  <td><asp:TextBox ID="txt10HomAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtRepitentesHomAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujAcademica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalAcademica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
             <tr>
                 <td rowspan="7">Técnica</td>
                 </tr>
            <tr>
                 <td >Agropecuaria</td>
                  <td><asp:TextBox ID="txt10HomAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtRepitentesHomAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujAgropecuaria" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalAgropecuaria" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
             </tr>
            <tr>
                 <td >Comercial y Servicios</td>
                  <td><asp:TextBox ID="txt10HomComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesHomComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujComercial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalComercial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
            </tr>
            <tr>
                  <td >Industrial</td>
                  <td><asp:TextBox ID="txt10HomIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesHomIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujIndustrial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalIndustrial" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
            </tr>
            <tr>
                  <td >Pedagógica</td>
                  <td><asp:TextBox ID="txt10HomPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesHomPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujPedagogica" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalPedagogica" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
            </tr>
            <tr>
                  <td >Promoción Social</td>
                  <td><asp:TextBox ID="txt10HomPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesHomPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujPromocion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalPromocion" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
            </tr>
            <tr>
                  <td >Otra ¿Cuál?</td>
                  <td><asp:TextBox ID="txt10HomOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesHomOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalOtra" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
            </tr>
            <tr>
                   <td colspan="2">Total General</td>
                  <td><asp:TextBox ID="txt10HomTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10MujTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt10TotalTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt11HomTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11MujTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt11TotalTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt12HomTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12MujTotalGeneral" runat="server" Enabled="false" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt12TotalTotalGeneral" Enabled="false"  runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txt13HomTotalGeneral" runat="server" Enabled="false" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujTotalGeneral" runat="server" CssClass="TextBox" Enabled="false" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13TotalTotalGeneral" Enabled="false" runat="server" CssClass="TextBox"  Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalHomTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50" ></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtRepitentesHomTotalGeneral" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujTotalGeneral" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesTotalTotalGeneral" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
            </tr>
            
            </table>
        <table>
            <tr>
                    <td >
                        <asp:Button ID="btnDecimoGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnDecimoGuardar_Onclick" />
                    </td>
                </tr>
        </table>
       <hr />
        <b>15. ¿En esta sede-jornada se ofrece educación formal para jóvenes en extraedad y adultos? Marque con X.</b>
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rtbEducacionFormalExtraedad" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rtbEducacionFormalExtraedad_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem Selected>No (Fin Formulario)</asp:ListItem>
                         </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelEducacionFormalExtraedad" Visible="false">
            Información para ser diligenciada exclusivamente por la sede-jornada que ofrece educación formal para jóvenes en extra edad y adultos, con los modelos: SAT, SER, CAFAM, Transformemos y otros programas.
             <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
             <tr>
                    <td rowspan="3"  style="font-weight:bold;">Nivel Educativo</td>
                 <td rowspan="3" style="font-weight:bold;">Ciclos</td>
                                          
                </tr>
               
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Aprobados</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Reprobados</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Desertores*</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Transferidos/Trasladados*</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                </tr>
                 <tr>
                     <td rowspan="4">Básica primaria</td>
                 </tr>
                 <tr>
                     <td>Ciclo I</td>
                       <td><asp:TextBox ID="txtHomCicloIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Ciclo II</td>
                      <td><asp:TextBox ID="txtHomCicloIIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                  <tr>
                     <td>Total</td>
                        <td><asp:TextBox ID="txtTotalHomCicloIyIIAprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujTotalMujCicloIyIIAprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIyIIReprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIyIIReprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIyIIDesertores" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIyIIDesertores" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIyIITranferidos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIyIITranferidos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIyIITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIyIITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                  <tr>
                     <td rowspan="4">Básica secundaria</td>
                 </tr>
                 <tr>
                     <td>Ciclo III</td>
                      <td><asp:TextBox ID="txtHomCicloIIIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIIIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIIIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIIITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIIITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIIITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Ciclo IV</td>
                      <td><asp:TextBox ID="txtHomCicloIVAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIVAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIVReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIVReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIVDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIVDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIVTranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIVTranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloIVTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloIVTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                  <tr>
                     <td>Total</td>
                        <td><asp:TextBox ID="txtTotalHomCicloIIIyIVAprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujTotalMujCicloIIIyIVAprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIIIyIVReprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIIIyIVReprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIIIyIVDesertores" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIIIyIVDesertores" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIIIyIVTranferidos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIIIyIVTranferidos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloIIIyIVTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloIIIyIVTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                  <tr>
                     <td rowspan="4">Media</td>
                 </tr>
                 <tr>
                     <td>Ciclo V</td>
                      <td><asp:TextBox ID="txtHomCicloVAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVTranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVTranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Ciclo VI</td>
                      <td><asp:TextBox ID="txtHomCicloVIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVIAprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVIReprobado" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVIDesertores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVITranferidos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtHomCicloVITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujCicloVITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                  <tr>
                     <td>Total</td>
                        <td><asp:TextBox ID="txtTotalHomCicloVyVIAprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtMujTotalMujCicloVyVIAprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloVyVIReprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloVyVIReprobado" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloVyVIDesertores" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloVyVIDesertores" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloVyVITranferidos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloVyVITranferidos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomCicloVyVITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujCicloVyVITotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
             </table>
            <table>
                 <tr>
                    <td>
                        <asp:Button ID="btnDecimoPrimero" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnDecimoPrimero_Onclick" />
                    </td>
                </tr>
            </table>
            <hr />
            <b>16. Información de jóvenes en extra edad y adultos del presente ciclo lectivo</b>

              <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Género edades en años cumplidos </td>
                                           
                </tr>
               
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo I</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo II</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo III</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo IV</td>
                     <td colspan="2" style="font-weight:bold;" align="center">Ciclo V</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo VI</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total</td>
                   
                
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                </tr>
              <tr>
                     <td align="center">13 y menos</td>
                      <td><asp:TextBox ID="txt13HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt13HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt13HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt13HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt13HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt13HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt13MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">14</td>
                      <td><asp:TextBox ID="txt14HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt14HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt14HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt14HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt14HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt14HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                        <td><asp:TextBox ID="txt14HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt14MujCicloTotal" runat="server" Enabled="false" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">15</td>
                      <td><asp:TextBox ID="txt15HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt15HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt15HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt15HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt15HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt15HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt15MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">16</td>
                      <td><asp:TextBox ID="txt16HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt16HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt16HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt16HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt16HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt16HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt16MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">17</td>
                      <td><asp:TextBox ID="txt17HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt17HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt17HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt17HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt17HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt17HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt17MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">18</td>
                      <td><asp:TextBox ID="txt18HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt18HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt18HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt18HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt18HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt18HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt18MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">19</td>
                      <td><asp:TextBox ID="txt19HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt19HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt19HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt19HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt19HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt19HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt19MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">20</td>
                      <td><asp:TextBox ID="txt20HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt20HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt20HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt20HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt20HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt20HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt20MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">21</td>
                      <td><asp:TextBox ID="txt21HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt21HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt21HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt21HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt21HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt21HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt21MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">22</td>
                      <td><asp:TextBox ID="txt22HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt22HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt22HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt22HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt22HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt22HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt22MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">23</td>
                      <td><asp:TextBox ID="txt23HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt23HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt23HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt23HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt23HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt23HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt23MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">24</td>
                      <td><asp:TextBox ID="txt24HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt24HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt24HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt24HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt24HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt24HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt24MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">25</td>
                      <td><asp:TextBox ID="txt25HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt25HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt25HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt25HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt25HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt25HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt25MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">26</td>
                      <td><asp:TextBox ID="txt26HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt26HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt26HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt26HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt26HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt26HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt26MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">27</td>
                      <td><asp:TextBox ID="txt27HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt27HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt27HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt27HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt27HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt27HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt27MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">28</td>
                      <td><asp:TextBox ID="txt28HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt28HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt28HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt28HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt28HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt28HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt28MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">29</td>
                      <td><asp:TextBox ID="txt29HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt29HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt29HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt29HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt29HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt29HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt29MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">30</td>
                      <td><asp:TextBox ID="txt30HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt30HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt30HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt30HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt30HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt30HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt30MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">31</td>
                      <td><asp:TextBox ID="txt31HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt31HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt31HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt31HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt31HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt31HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt31MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">32</td>
                      <td><asp:TextBox ID="txt32HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt32HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt32HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt32HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt32HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt32HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt32MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">33</td>
                      <td><asp:TextBox ID="txt33HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt33HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt33HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt33HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt33HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt33HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt33MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">34</td>
                      <td><asp:TextBox ID="txt34HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt34HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt34HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt34HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt34HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt34HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt34MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">35</td>
                      <td><asp:TextBox ID="txt35HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt35HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt35HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt35HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt35HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt35HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt35MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">36 y más</td>
                      <td><asp:TextBox ID="txt36HomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt36HomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt36HomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt36HomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txt36HomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txt36HomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36HomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txt36MujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">Total General</td>
                      <td><asp:TextBox ID="txtTotalGeneralHomCicloI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalGeneralHomCicloII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalGeneralHomCicloIII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloIII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalGeneralHomCicloIV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloIV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalGeneralHomCicloV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtTotalGeneralHomCicloVI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloVI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralHomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalGeneralMujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">Núm. De Repitentes o reiniciantes</td>
                      <td><asp:TextBox ID="txtRepitentesHomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtRepitentesHomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtRepitentesHomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtRepitentesHomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtRepitentesHomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtRepitentesHomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesHomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtRepitentesMujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td align="center">Núm. De grupos por ciclo</td>
                      <td><asp:TextBox ID="txtGruposPorCiclosHomCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtGruposPorCiclosHomCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtGruposPorCiclosHomCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtGruposPorCiclosHomCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtGruposPorCiclosHomCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtGruposPorCiclosHomCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosHomCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtGruposPorCiclosMujCicloTotal" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
           </table>
            <table>
                 <tr>
                    <td align="center">
                        <asp:Button ID="btnDecimoSegundo" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnDecimoSegundo_Onclick" />
                    </td>
                </tr>
            </table>
             <hr />
            <b>17. Información de matrícula del presente año, discriminada por modelos educativos</b>

              <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                                       <tr>
                    <td rowspan="3"  style="font-weight:bold;">Modelos </td>
                                           
                </tr>
               
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo I</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo II</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo III</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo IV</td>
                     <td colspan="2" style="font-weight:bold;" align="center">Ciclo V</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Ciclo VI</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total</td>
                   
                
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                </tr>
              <tr>
                     <td>Programa para jóvenes en extraedad y adultos</td>
                      <td><asp:TextBox ID="txtExtredadHomClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadMujClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtExtredadHomClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadMujClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtExtredadHomClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadMujClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtExtredadHomClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadMujClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtExtredadHomClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadMujClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtExtredadHomClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadMujClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtExtredadTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                    <tr>
                     <td>SAT</td>
                      <td><asp:TextBox ID="txtSATHomClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATMujClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSATHomClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATMujClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSATHomClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATMujClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSATHomClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATMujClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSATHomClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATMujClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtSATHomClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATMujClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSATTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                    <tr>
                     <td>SER</td>
                      <td><asp:TextBox ID="txtSERHomClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERMujClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSERHomClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERMujClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSERHomClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERMujClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSERHomClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERMujClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtSERHomClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERMujClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtSERHomClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERMujClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtSERTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                    <tr>
                     <td>CAFAM</td>
                      <td><asp:TextBox ID="txtCAFAMHomClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMMujClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtCAFAMHomClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMMujClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtCAFAMHomClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMMujClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtCAFAMHomClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMMujClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtCAFAMHomClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMMujClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtCAFAMHomClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMMujClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtCAFAMTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                    <tr>
                     <td>Transformemos</td>
                      <td><asp:TextBox ID="txtTransformemosHomClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosMujClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTransformemosHomClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosMujClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTransformemosHomClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosMujClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTransformemosHomClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosMujClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTransformemosHomClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosMujClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtTransformemosHomClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosMujClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTransformemosTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                    <tr>
                     <td>Otro   ¿cuál </td>
                      <td><asp:TextBox ID="txtOtroHomClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroMujClicloI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtOtroHomClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroMujClicloII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtOtroHomClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroMujClicloIII" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtOtroHomClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroMujClicloIV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtOtroHomClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroMujClicloV" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtOtroHomClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroMujClicloVI" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroTotalHom" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtOtroTotalMuj" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                    <tr>
                     <td>Total</td>
                      <td><asp:TextBox ID="txtTotalHomClicloI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujClicloI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomClicloII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotaldMujClicloII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomClicloIII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujClicloIII" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomClicloIV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujClicloIV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                         <td><asp:TextBox ID="txtTotalHomClicloV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujClicloV" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtTotalHomClicloVI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalMujClicloVI" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalHomCiclosModelos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtTotalTotalMujCiclosModelos" Enabled="false" runat="server" CssClass="TextBox" Width="50"></asp:TextBox></td>
                 </tr>
                 </table>
            <table>
                  <tr>
                    <td >
                        <asp:Button ID="btnDecimoTercero" Text="Guardar" runat="server" CssClass="btn btn-success" OnClick="btnDecimoTercero_Onclick" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
  
    <br />
    <%--<table align="center">
        <tr>
            <td>
                <asp:button ID="btnGuardarSede" runat="server" Text="Terminar" CssClass="btn btn-success" OnClick="btnGuardarSede_Click" />
            </td>
        </tr>
    </table>--%>

</asp:Content>

