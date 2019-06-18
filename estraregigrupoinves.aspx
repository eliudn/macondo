<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraregigrupoinves.aspx.cs" Inherits="estraregigrupoinves" %>

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
       <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
        <div class="header">
            <div style="float: left; margin-right: 15px"><br /><br />
                <h2>Perfil y grado de formación de los estudiantes de grupos de investigación abiertos y preestructurados y de las redes temáticas del Programa CICLÓN</h2>
            </div>
          
            <div style="float: right;">
                <%--<a href="actagenda.aspx" runat="server" id="btnMiAgenda" class="btn btn-primary">Mi Agenda</a>--%>
            </div>
        </div>
  
   <asp:Panel ID="PanelEstudiantes" runat="server" Visible="true">
        <h4>Estrategia No 1. Estrategia de acompañamiento y formación de los grupos de investigación siguiendo los lineamientos y la metodología del programa Ondas apoyado en herramientas virtuales</h4>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" >
            <tr>
                <td align="right">
                    Nombre del grupo de investigación
                </td>
                <td>
                    <asp:TextBox ID="txtNomGrupoInvestigacion" runat="server" CssClass="TextBox" Width="300"></asp:TextBox>
                </td>
            </tr>
            </table>
        <fieldset>
            <legend> De los Estudiantes</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" border="0" >
            <tr>
                <td align="right" width="30%">
                   ID del docente
                </td>
                <td align="left">
                    <asp:TextBox ID="txtBusqNomDocente" runat="server" Width="300" CssClass="TextBox"></asp:TextBox>
                    <asp:Button ID="btnBuscarDocente" runat="server" CssClass="btn btn-primary" Text="Seleccionar" OnClick="btnBuscarDocente_Click" />
                </td>
            </tr>
                 <tr>
                     <td align="center" colspan="2">
                           <asp:GridView ID="GridEstudiantexDocente" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="70%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombrecompleto" HeaderText="Nombre estudiante"  />
                            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="sexo" HeaderText="Genero" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="grado" HeaderText="Grado" ItemStyle-HorizontalAlign="Center" />

                           <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png"><ItemStyle Width="20px" /></asp:CommandField>      
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <b>B.	Los ítems que se describen a continuación deberán ser diligenciados por el docente acompañante y/o docente coinvestigador del grupo de investigación en el aula, </b>
                     </td>
                     </tr>
                 <tr>
                      <td colspan="2" >
                       1.  ¿En el Programa CIClÓN  se incluyen estudiantes con discapacidad o capacidades excepcionales?
                     </td>
                     </tr>
                 <tr>
                     <td colspan="2">
                         <asp:RadioButtonList ID="rbValidarPregunta1Intrumento06" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbValidarPregunta1Intrumento06_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem>No (pase a la pregunta No.3)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                     <asp:Panel ID="PanelPregunta2Instrumento06" runat="server" Visible="true">
                         <tr>
                           
                                 <td colspan="2">
                                   <b>  2.	Número de estudiantes del grupo de investigación con discapacidad o capacidades excepcionales, integrados* a la educación formal, según Género.</b>
                                     <br />
                                     Diligencie únicamente con cifras
                                 </td>
                             </tr>
                         <tr>
                             <td colspan="2">
                                  <table>
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Categoria
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con discapacidad
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadHom" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtDiscapacidadMuj" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtTotalDiscapacidad" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>
                                              Con capacidades excepcionales
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtCapacidadExcepHom" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtCapacidadExcepMuj" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                           <td>
                                              <asp:TextBox ID="txtTotalCapacidadExcep" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td>Total</td>
                                          <td>
                                              <asp:TextBox ID="txtTotalHom" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:TextBox ID="txtTotalMuj" Enabled="false" runat="server" Width="50px" CssClass="TextBox"></asp:TextBox>
                                           </td>
                                          <td>
                                              <asp:Button ID="btnValidarSumInvDiscapacidad" runat="server" CssClass="btn btn-danger" Text="Calcular" OnClick="btnValidarSumInvDiscapacidad_Click" />
                                          </td>
                                      </tr>
                                  </table>
                             </td>
                           </tr>
                    </asp:Panel>
                 <tr>
                     <td colspan="2">
                         <b>3.	Número de estudiantes con discapacidad, integrados y no integrados que hacen parte del grupo de investigación, por categoría y Género. </b>
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
                                     <asp:TextBox ID="txtTotalAuditivaInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAuditivaHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAuditivaMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivaNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivoMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAuditivo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
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
                                     <asp:TextBox ID="txtTotalVisualInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtVisualHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtVisualMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisualMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalVisual" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
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
                                     <asp:TextBox ID="txtTotalMotoraInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMotoraHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMotoraMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotoraMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMotora" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
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
                                     <asp:TextBox ID="txtTotalCognitivaInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtCognitivaHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtCognitivaMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitivaMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalCognitiva" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
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
                                     <asp:TextBox ID="txtTotalAutismoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtAutismoHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtAutismoMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismoMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAutismo" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
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
                                     <asp:TextBox ID="txtMultipleMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtMultipleHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtMultipleMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultipleMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMultiple" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Otra, ¿cuál?     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtOtraHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtOtraMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtraMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalOtra" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Total    
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                  <td>
                                     <asp:TextBox ID="txtTotalHomNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalMujNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalNoInte" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtTotalTotalMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Button ID="btnEstudianteDiscapacidad" CssClass="btn btn-danger" Text="Calcular" runat="server" />
                                 </td>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                       <b>  4.	¿En el grupo de investigación y las redes temáticas institucionales, se incluye población de grupos étnicos? </b>
                     </td>
                 </tr>
                 <tr>
                     <td colpan="2">
                          <asp:RadioButtonList ID="rbGrupoInvestigacionEtnicoInstru06" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbGrupoInvestigacionEtnicoInstru06_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem>No (pase a la pregunta No.6)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelGrupoEtnicos" runat="server" Visible="true">
                     <tr>
                         <td>
                            <b> 5.	Número de estudiantes de grupos étnicos del grupo de investigación, según Género.</b>
                             <br />
                              Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                              <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="100%">
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Nombre del Grupo Etnico
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                  <tr>
                                      <td>
                                          Indígenas
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtIndigenaHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtIndigenaMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                           <asp:TextBox ID="txtIndigenaTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                        Rom (gitanos)
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRomTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Afrocolombianos, afrodecendientes,negro o mulato.
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtAfroTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Raizal dl archipiélago de San Andrés, Providencia y Santa Catalina
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRaizaHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                           <asp:TextBox ID="txtRaizaMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtRaizaTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Palenquero de San Basilio 
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtPalenqueroTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          Total 
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtTotalHomEtnico" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtTotalMujEtnico" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:Button ID="btnEtnica" CssClass="btn btn-danger" Text="Calcular" runat="server" />
                                      </td>
                                  </tr>
                                  </table>
                         </td>
                     </tr>
                  </asp:Panel>
                 <tr>
                     <td colspan="2">
                         <b>6.	¿En esta sede-jornada se atiende población víctima del conflicto?</b>
                     </td>
                 </tr>
                   <tr>
                     <td colspan="2">
                          <asp:RadioButtonList ID="rbVictimaConflicto" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbVictimaConflicto_SelectedIndexChanged" AutoPostBack="true" >
                             <asp:ListItem>Si (continúe)</asp:ListItem>
                             <asp:ListItem>No (fin del instrumento)</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                 </tr>
                 <asp:Panel ID="PanelVictimaConflicto" runat="server" Visible="true">
                     <tr>
                         <td  colspan="2">
                         <b>   7. Número de estudiantes participantes del grupo de investigación víctimas del conflicto. </b>
                             <br />
                                  Diligencie únicamente con cifras
                         </td>
                     </tr>
                     <tr>
                         <td>
                                <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96" width="100%">
                                      <tr>
                                          <td style="font-weight:bold;">
                                              Tipo de Situación
                                          </td>
                                          <td style="font-weight:bold;">
                                              Hombres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Mujeres
                                          </td>
                                          <td style="font-weight:bold;">
                                              Total
                                          </td>
                                      </tr>
                                    <tr>
                                        <td>
                                            En situación de desplazamiento 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesplazamientoHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesplazamientoMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesplazamientoTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Desvinculados de organizaciones armadas al margen de la Ley
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtAlMargenHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlMargenMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAlMargenTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Hijos de adultos desmovilizados 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesmovilizadosHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesmovilizadosMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtDesmovilizadosTotal" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Total
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalHomConflicto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalMujConflicto" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnConflicto" CssClass="btn btn-danger" Text="Calcular" runat="server" />
                                        </td>
                                    </tr>
                                    </table>
                         </td>
                     </tr>
                </asp:Panel>
                 <tr>
                     <td colspan="2" align="center"><br />
                         <asp:Button ID="btnTerminar" CssClass="btn btn-success" Text="Terminar" runat="server" />
                     </td>
                 </tr>
        </table>
        </fieldset>
       
    </asp:Panel>



</asp:Content>

