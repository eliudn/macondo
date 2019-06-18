<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseinstrurectores.aspx.cs" Inherits="lineabaseinstrurectores" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }

        .textos2 {
            font-size: 17px;
            font-weight: bold;
            letter-spacing: 0.5px;
        }

        .cajausuario {
            background-color: #e6e6e6;
            border: 1px solid #d5d5d5;
            border-radius: 5px;
            -moz-border-radius: 5px;
            padding: 3px;
            border-spacing: 5px;
            margin: 2px auto 8px;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 30px;
        }
    </style>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script>
        $(document).ready(function () {
            $(".TextBox").attr("disabled",true);
            $(".btn-success").hide();
            $(".btn-danger").hide();
            $("input[type=checkbox]").attr("disabled",true);
            $("input[type=radio]").attr("disabled",true);
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>


    <div id="mensaje" runat="server"></div><br /><br />
    <h2 style="text-decoration: underline;">Información general de la Institución Educativa o Centro Educativo</h2>
    <div style="float:right;margin-top:-40px;">
        <a href="menulineabase.aspx" class="btn btn-primary" >Regresar</a>
    </div>
    <br />
    <asp:Label ID="lblCodDANE" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblCodInstAsesor" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodRol" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodInstitucion" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodAsesor" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblBack" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblLineaBaseSede" runat="server" Visible="False"></asp:Label>

     <table align="center">
        <tr>
            <td>
                <asp:Button ID="btnIniciarInfoBasica" Visible="true" runat="server" CssClass="btn btn-primary" Text="001A - Información básica IES" OnClick="btnIniciarInfoBasica_Click" />
            </td>
            <td>
                <asp:Button ID="btnIniciarInfoBasica2" Visible="true" runat="server" CssClass="btn btn-primary" Text="01 - Información básica IES" OnClick="btnIniciarInfoBasica2_Click" />
            </td>
              <td>
                <asp:Button ID="btnIniciarCaracterizacion" Visible="true" runat="server" CssClass="btn btn-primary" Text="02 - Currículo" OnClick="btnIniciarCaracterizacion_Click" />
            </td>
        </tr>
    </table>
     

  <!-- Instrumento 001A -->
    <asp:Panel ID="PanelInstrumento001A" runat="server" Visible="false">

          <fieldset>
        <legend>Datos del Asesor</legend>
        <table>
                <tr>
                    <td>
                        Seleccione el Asesor
                    </td>
                    <td>
                        <asp:DropDownList ID="dropAsesor" runat="server" CssClass="TextBox" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropAsesor" runat="server" Display="None" ErrorMessage="Seleccione el Asesor"
                            ControlToValidate="dropAsesor" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVdropAsesor"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
            </table>
    </fieldset>

        <table>
            <tr>
                <td>
                   <b>Introducción</b>  <br /><br />

                    Para la construcción de la línea de base del proyecto Ciclón se requiere recoger información institucional básica sobre el equipamiento institucional de TIC y su uso pedagógico, con el objeto de aportar indicadores para la línea de base del proyecto. <br />
                    Para su elaboración se hizo una revisión del marco de política tanto a nivel nacional como departamental para indagar sobre la normatividad con referencia a TIC. Los artículos 20 y 67 de la Constitución Política establecen que el Estado promoverá el derecho al acceso a las Tecnologías de la Información y las Comunicaciones que permitan entre otros, el ejercicio pleno al derecho de la educación. Inspirada en estos principios, la Ley 1341 de febrero de 2009 establece que las entidades del orden nacional y territorial dispondrán lo pertinente para garantizar el uso y acceso a estos derechos. Igualmente el Plan Nacional de Tics 2008 - 2019 genera directrices al mismo fin.
                    <br /><br />

                    <b>Objetivo</b><br />
                    Acopiar información de línea de base sobre el equipamiento y uso de TIC, en las sedes educativas vinculadas al proyecto Ciclón.
                     <br /><br />

                   <b> Metodología</b><br />

                    Este instrumento será diligenciado en dos partes:<br />
                    La primera parte será migrado de los instrumentos 01, C600A y C600B o del SIMAT.<br />
                    La segunda parte del instrumento será implementado por el Docente Asesor de FUNTIC o quien haga sus veces con el Rector/a, Director/a o a quien se delegue en la Institución Educativa diligenciado directamente en el SIEP. 

                </td>
            </tr>
        </table>

        <fieldset>
            <legend>Identificación</legend>

           <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
               <tr>
                   <td>
                       Código DANE de la Institución educativa
                   </td>
                   <td>
                       <asp:TextBox ID="txtDANE" runat="server" CssClass="TextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVtxtDANE" runat="server" Display="None" ErrorMessage="Digite el código DANE de la institución"
                    ControlToValidate="txtDANE" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVtxtDANE"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                   </td>
                   <td>
                       Nombre Institución educativa
                   </td>
                   <td>
                        <asp:TextBox ID="txtNomInstitucion" runat="server" CssClass="TextBox"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RFVtxtNomInstitucion" runat="server" Display="None" ErrorMessage="Digite el nombre de la institución"
                    ControlToValidate="txtNomInstitucion" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RFVtxtNomInstitucion"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                   </td>
                     <td>
                       Nombre rector
                   </td>
                   <td>
                     <asp:DropDownList ID="dropNomRector" runat="server" CssClass="TextBox" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFdropNomRector" runat="server" Display="None" ErrorMessage="Seleccione el Nombre del Rector"
                    ControlToValidate="dropNomRector" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RFdropNomRector"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                   </td>
               </tr>
               <tr>
                  <td>
                      Dirección
                   </td>
                   <td>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                   <td>
                       Teléfono
                   </td>
                   <td>
                       <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                   <td>
                       Fax
                   </td>
                   <td>
                       <asp:TextBox ID="txtFax" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                  
               </tr>
               <tr>
                   
                   <td>
                       Correo electrónico
                   </td>
                   <td>
                         <asp:TextBox ID="txtemail" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                   <td>
                        Sitio Web
                   </td>
                   <td>
                       <asp:TextBox ID="txtWeb" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
               </tr>
            </table>

        </fieldset>

        <fieldset>
            <legend>Ubicación y localización física de la institución educativa</legend>
              <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;">
                  <tr>
                      <td>
                          Departamento <asp:DropDownList ID="dropDepartamento" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropCiudad_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFdropDepartamento" runat="server" Display="None" ErrorMessage="Seleccione el Departamento"
                    ControlToValidate="dropDepartamento" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RFdropDepartamento"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>

                            Ciudad  <asp:DropDownList ID="dropCiudad" runat="server" CssClass="TextBox"></asp:DropDownList> 
                           <asp:RequiredFieldValidator ID="RFVdropCiudad" runat="server" Display="None" ErrorMessage="Seleccione la Ciudad"
                    ControlToValidate="dropCiudad" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RFVdropCiudad"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                            
                           Zona <asp:DropDownList ID="dropZona" runat="server" CssClass="TextBox"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RFVdropZona" runat="server" Display="None" ErrorMessage="Seleccione la Zona"
                    ControlToValidate="dropZona" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RFVdropZona"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                      </td>
           
                  </tr>
                  <tr>
                      <td>
                          Nro. Total de Sedes:
                              Activas  <asp:TextBox ID="txtActivas" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                           Inactivas   <asp:TextBox ID="txtInactivas" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                      </td>
               
                  </tr>
                  </table>
        </fieldset>

        <fieldset>
            <legend>Propiedad Jurídica</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                 <tr>
                     <td>
                         Propiedad Jurídica
                         <asp:DropDownList ID="dropPropiedadJuridica" runat="server" CssClass="TextBox"></asp:DropDownList>
                     </td>
          
                 </tr>
                 </table>
        </fieldset>
        <table align="center"><tr><td><asp:Button ID="btnPrimerGuardar" ValidationGroup="addUsuario" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar_Onclick" /></td></tr></table>
        <fieldset>
            <legend>Niveles de enseñanza</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;"  >
                 <tr>
                     <td width="25%">
                       <b> 1.  Niveles de enseñanza que ofrece</b>
                     </td>
                     <td >
                         <asp:CheckBoxList ID="chkNivelesEnsenaza" runat="server">
                             <asp:ListItem>Preescolar</asp:ListItem>
                             <asp:ListItem>Básica primaria</asp:ListItem>
                             <asp:ListItem>Básica secundaria</asp:ListItem>
                             <asp:ListItem>Media</asp:ListItem>
                         </asp:CheckBoxList>
                     </td>
                 </tr>
                 </table>
             <fieldset>
                <legend>Programas, estrategias o modelos educativos</legend>
                    <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" border="0">
                        <tr>
                            <td>
                              <b> 2. Programas, estrategias o modelos educativos que ofrecen</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Preescolar</b>
                            </td>
                            <td>
                                <b>Básica primaria</b>
                            </td>
                             </tr>
                        <tr>
                            <td>
                                <asp:CheckBoxList ID="chkProgramaEstrategiaModeloPreescolar" runat="server"  >
                                    <asp:ListItem>Preescolar escolarizado</asp:ListItem>
                                    <asp:ListItem>Preescolar semi-escolarizado</asp:ListItem>
                                    <asp:ListItem>Preescolar no escolarizado</asp:ListItem>
                                </asp:CheckBoxList>
                                Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloPreescolar" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                             <td>
                                 <asp:CheckBoxList ID="chkProgramaEstrategiaModeloPrimaria" runat="server" RepeatColumns="2">
                                    <asp:ListItem>Educación tradicional</asp:ListItem>
                                    <asp:ListItem>Escuela nueva</asp:ListItem>
                                    <asp:ListItem>SER</asp:ListItem>
                                    <asp:ListItem>CAFAM</asp:ListItem>
                                    <asp:ListItem>Etnoeducación</asp:ListItem>
                                    <asp:ListItem>Aceleración del aprendizaje</asp:ListItem>
                                    <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                                    <asp:ListItem>Transformemos</asp:ListItem>
                                </asp:CheckBoxList>
                                 Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloPrimaria" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            
                             <td>
                                 <b>Básica secundaria</b>
                            </td>
                            <td>
                                 <b>Media</b>
                            </td>
                             </tr>
                        <tr>
                           
                              <td>
                                 <asp:CheckBoxList ID="chkProgramaEstrategiaModeloSecundaria" runat="server">
                                    <asp:ListItem>Educación tradicional</asp:ListItem>
                                    <asp:ListItem>Posprimaria</asp:ListItem>
                                    <asp:ListItem>Telesecundaria</asp:ListItem>
                                    <asp:ListItem>SER</asp:ListItem>
                                    <asp:ListItem>CAFAM</asp:ListItem>
                                    <asp:ListItem>SAT</asp:ListItem>
                                    <asp:ListItem>Etnoeducación</asp:ListItem>
                                    <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                                    <asp:ListItem>Transformemos</asp:ListItem>
                                </asp:CheckBoxList>
                                 Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloSecundaria" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                             <td>
                                 <asp:CheckBoxList ID="chkProgramaEstrategiaModeloMedia" runat="server">
                                    <asp:ListItem>Educación tradicional</asp:ListItem>
                                    <asp:ListItem>SER</asp:ListItem>
                                    <asp:ListItem>CAFAM</asp:ListItem>
                                    <asp:ListItem>SAT</asp:ListItem>
                                    <asp:ListItem>Etnoeducación</asp:ListItem>
                                    <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                                    <asp:ListItem>Transformemos</asp:ListItem>
                                </asp:CheckBoxList>
                                 Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloMedia" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                       
                      
                        </table>
                </fieldset>
        </fieldset>

        <fieldset>
            <legend>Jornadas</legend>
                <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                    <tr>
                        <td width="25%">
                           <b> 3. Jornadas de la institución educativa</b>
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
            <legend>Información del recurso humano en el presente año</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" border="0" >
                 <tr>
                     <td>
                       Relacione el número total de personas que prestan sus servicios en la institución educativa, según la función Primordial que cumplen en todas las sedes-jornadas y todos los niveles educativos que se imparten. Diligencie únicamente con cifras, no utilice otros signos.
                         <br />
                        <b> 4. Información en el presente año</b>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <b>Docentes</b>
                     </td>
                    
                   </tr>
                     <tr>
                          <td>
                         Directivo docente <asp:TextBox ID="txtDirectivoDocente" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>

                     </td>
                          </tr>
                     <tr>
                         <td>
                             Docentes (no incluya educadores especiales ni etnoeducadores) <asp:TextBox ID="txtDocentes" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                         </td>
                     </tr>
                <tr>
                    <td>
                        Docentes de educación especial <asp:TextBox ID="txtDocenteEspecial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                     <td>
                         Docentes de etnoeducación <asp:TextBox ID="txtDocentesEtno" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <b>Otros</b>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos) <asp:TextBox ID="txtDirectivos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales <asp:TextBox ID="txtConsejeros" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Médicos, odontólogos, nutricionistas, terapeutas y enfermeros <asp:TextBox ID="txtMedicos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Administrativos (de apoyo y personal de servicios generales) <asp:TextBox ID="txtAdministrativos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.) <asp:TextBox ID="txtProfesionales" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td> 
                 </tr>
                 <tr>
                     <td>
                         Tutores <asp:TextBox ID="txtTutores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Auxiliar de aula <asp:TextBox ID="txtAula" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Otros <asp:TextBox ID="txtOtros" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 </table>
        </fieldset>

        <table align="center"><tr><td><asp:Button ID="btnSegundoGuardado" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSegundoGuardado_Onclick" /></td></tr></table>

        <fieldset>
            <legend>Personas que prestan sus servicios en la institución educativa</legend>
            <table> 
                <tr><td>
                    Relacione todos los docentes que laboran en la institución educativa. Ubique al docente en el nivel educativo donde tenga la mayor carga académica. Incluya los docentes de horas extra. Diligencie únicamente con cifras, no utilice otros signos. 
                    </td></tr>
                <tr><td ><b>5. Personal docente por nivel de enseñanza, según último nivel educativo aprobado por el docente</b></td></tr></table>
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
                     <td><asp:TextBox ID="txtTotalTotalHomPrimaria" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalHomPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTotalTotalHomSecundaria" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomMedia" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomTotal" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:Button runat="server" ID="btnSumarTotales" Text="Calcular" OnClick="btnSumarTotales_Click" CssClass="btn btn-danger" /></td>
                </tr>
                
            </table>
            <table align="center"><tr><td><asp:Button ID="btnTercerGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnTercerGuardar_Onclick" /></td></tr></table>

            <br />

             <table width="100%"> <tr>
                     <td>
                         <hr />
                         Relacione únicamente los docentes. No relacione directivos ni personal administrativo. Ubique al docente en alguno de los cuadros 6.1 ó 6.2, en el área de enseñanza donde tenga la mayor carga académica. Incluya los docentes de horas extras. Diligencie únicamente con cifras, no utilice otros signos
                     </td>
                 </tr> <tr><td ><b>6. Personal docente por género y nivel educativo, según área de enseñanza</b></td></tr></table>

            6.1. Personal docente para el carácter académico
             <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                
                <tr>
                    <td rowspan="4" style="font-weight:bold;" align="center">Áreas de enseñanza</td>
                </tr>
                <tr>
                    <td colspan="15" style="font-weight:bold;" align="center">Nivel educativo</td>
                   
                </tr>
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Media</td>
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
                    <td style="font-weight:bold;">Todas las áreas</td>
                     <td><asp:TextBox ID="txtTodasAreasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTodasAreasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTodasAreasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="font-weight:bold;" >Ciencias naturales y educación ambiental</td>
                    <td><asp:TextBox ID="txtNaturalesHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtNaturalesHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtNaturalesMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="font-weight:bold;" align="center">Ciencias sociales, historia, geografía, constitución política y democracia</td>
                    <td><asp:TextBox ID="txtSocialesHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtSocialesHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSocialesMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="font-weight:bold;">Educación artística</td>
                    <td><asp:TextBox ID="txtArtisticaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtArtisticaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtArtisticaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtArtisticaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtArtisticaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

               <tr>
                    <td style="font-weight:bold;">Educación ética y en valores humanos </td>
                    <td><asp:TextBox ID="txtEticaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEticaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEticaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEticaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEticaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Educación física, recreación y deportes </td>
                    <td><asp:TextBox ID="txtDeportesHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtDeportesMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtDeportesHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtDeportesMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtDeportesMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Educación religiosa </td>
                    <td><asp:TextBox ID="txtReligiosaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtReligiosaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtReligiosaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtReligiosaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtReligiosaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Humanidades, lengua castellana e idiomas extranjeros</td>
                    <td><asp:TextBox ID="txtCastellanaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtCastellanaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtCastellanaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtCastellanaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtCastellanaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Matemáticas</td>
                    <td><asp:TextBox ID="txtMatematicasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtMatematicasMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtMatematicasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtMatematicasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtMatematicasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Tecnología e informática</td>
                    <td><asp:TextBox ID="txtInformaticaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtInformaticaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtInformaticaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtInformaticaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtInformaticaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Ciencias económicas</td>
                    <td><asp:TextBox ID="txtEconomicasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEconomicasMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEconomicasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEconomicasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEconomicasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Ciencias políticas</td>
                    <td><asp:TextBox ID="txtPoliticasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPoliticasMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPoliticasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPoliticasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPoliticasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
              
                  <tr>
                    <td style="font-weight:bold;">Filosofía</td>
                    <td><asp:TextBox ID="txtFilosofiaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtFilosofiaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtFilosofiaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtFilosofiaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtFilosofiaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Otra</td>
                    <td><asp:TextBox ID="txtOtraAcademicoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtraAcademicoMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtraAcademicoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtraAcademicoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtraAcademicoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;" align="center" >Total</td>
                     
                     <td><asp:TextBox ID="txtTotalAcademicoHomPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoMujPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalAcademicoMujPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalAcademicoMujSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalAcademicoMujMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
            </table>
            <table align="center"><tr><td><asp:Button ID="btnCuartoguardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnCuartoguardar_Onclick" /></td></tr></table>
        </fieldset>

         <br />

             <table width="100%"> <tr>
                     <td>
                         <hr />
                     </td>
                 </tr> <tr><td >6.2. Personal docente para el carácter técnico, del nivel educativo Media</td></tr></table>

       <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
            <tr>
                <td style="font-weight:bold;">Especialidad</td>
                <td style="font-weight:bold;">Áreas de enseñanza</td>
                <td style="font-weight:bold;">Hombres</td>
                <td style="font-weight:bold;">Mujeres</td>
                <td style="font-weight:bold;">Total</td>
            </tr>
            <tr>
                <td rowspan="4" style="font-weight:bold;">Agropecuario</td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Agrícola</td>
                 <td><asp:TextBox ID="txtAgricolaHom" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                <td><asp:TextBox ID="txtAgricolaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                <td><asp:TextBox ID="txtAgricolaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Pecuario</td>
                    <td><asp:TextBox ID="txtPecuarioHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPecuarioMuj"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPecuarioTotal" Enabled="false"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Otra ¿cuál?</td>
                   <td><asp:TextBox ID="txtAgroOtraHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtAgroOtraMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtAgroOtraTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
            </tr>
             <tr>
                <td rowspan="8" style="font-weight:bold;">Comercial y servicios</td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Contabilidad</td>
                 <td><asp:TextBox ID="txtContablidadHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtContablidadMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtContablidadTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Finanzas</td>
                  <td><asp:TextBox ID="txtFinanzasHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFinanzasMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFinanzasTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Administración y gestión</td>
                  <td><asp:TextBox ID="txtAdminGestionHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdminGestionMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdminGestionTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="font-weight:bold;">Administración</td>
                 <td><asp:TextBox ID="txtAdministracionHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdministracionMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdministracionTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Ambiental</td>
                  <td><asp:TextBox ID="txtAmbientalHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAmbientalMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAmbientalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Salud</td>
                   <td><asp:TextBox ID="txtSaludHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtSaludMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtSaludTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Otra ¿cuál?</td>
                  <td><asp:TextBox ID="txtOtraComercialHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraComercialMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraComercialTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
            </tr>
             <tr>
                <td rowspan="14" style="font-weight:bold;">Industrial</td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Electricidad</td>
                 <td><asp:TextBox ID="txtElectridadHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectridadMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectridadTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Electrónica</td>
                 <td><asp:TextBox ID="txtElectronicaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectronicaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectronicaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Mecánica industrial</td>
                 <td><asp:TextBox ID="txtMecaIndustrialHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaIndustrialMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaIndustrialTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                 <td style="font-weight:bold;">Mecánica automotriz</td>
                 <td><asp:TextBox ID="txtMecaAutomotrizHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaAutomotrizMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaAutomotrizTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Metalistería</td>
                  <td><asp:TextBox ID="txtMetalisteriaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalisteriaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalisteriaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Metalmecánica</td>
                <td><asp:TextBox ID="txtMetalmecanicaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalmecanicaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalmecanicaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                 <td style="font-weight:bold;">Ebanistería</td>
                <td><asp:TextBox ID="txtEbanisterHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtEbanisteriaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtEbanisteriaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Fundición</td>
                 <td><asp:TextBox ID="txtFundicionHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFundicionMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFundicionTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Construcciones civiles</td>
                  <td><asp:TextBox ID="txtCivilesHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtCivilesMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtCivilesTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                 <td style="font-weight:bold;">Diseño mecánico</td>
                 <td><asp:TextBox ID="txtDisMecanicoHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisMecanicoMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisMecanicoTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                  </tr>
             <tr>
                <td style="font-weight:bold;">Diseño gráfico</td>
                 <td><asp:TextBox ID="txtDisGraficaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisGraficaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisGraficaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                  </tr>
             <tr>
                <td style="font-weight:bold;">Diseño arquitectónico</td>
                  <td><asp:TextBox ID="txtDisArquitectonicoHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisArquitectonicoMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisArquitectonicoTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                  </tr>
             <tr>
                <td style="font-weight:bold;">Otra ¿cuál?</td>
                 <td><asp:TextBox ID="txtOtraIndustrialHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraIndustrialMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraIndustrialTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
            </tr>
           <tr>
               <td style="font-weight:bold;" align="center" colspan="2">Total</td>
                 <td><asp:TextBox ID="txtTotalHom" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalMuj" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                
           </tr>
        </table>

        <table align="center">
            <tr>
                <td>
                    <asp:Button ID="btnGuardarInfoBasica"  Visible="false" runat="server" CssClass="btn btn-primary" Text="Ir al Formulario C600B" OnClick="btnGuardarInfoBasica_Click"  />
                </td>
            </tr>
        </table>



    </asp:Panel>

    <!-- Formulario C600B -->

      <asp:Panel ID="PanelFormularioC600B" runat="server" Visible="false">

             <fieldset>
            <legend>Información de las Sedes de la Institución Educativa por Jornada</legend>

          
        <asp:GridView ID="GridSedesC600B" runat="server" CellPadding="4" DataKeyNames="cod"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen sedes para esta institución."
            GridLines="None" >
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="codSede" HeaderStyle-CssClass="ocultarcell" >
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nit" HeaderText="DANE">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                  <asp:BoundField DataField="consesede" HeaderText="Consecutivo Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Dirección">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
               <%--  <asp:BoundField DataField="telefono" HeaderText="Telefono">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="codmunicipio" HeaderText="codMunicipio" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrem" HeaderText="Municipio" />
                 <asp:BoundField DataField="codzona" HeaderText="codzona" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nomzona" HeaderText="Zona" />
                <asp:BoundField DataField="sede" HeaderText="Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
              <asp:BoundField DataField="codinstitucion" HeaderText="codinstitucion" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ver
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVer" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVer_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                  <%--  <HeaderTemplate>
                        <asp:Button ID="btnAgregarSede" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarSede_Click" />
                    </HeaderTemplate>--%>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:CommandField ShowDeleteButton="True" Visible="false" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                    <ItemStyle Width="20px" />
                </asp:CommandField>

                  <asp:TemplateField>
                    <HeaderTemplate>
                        C600B
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgInfoxSedeC600B" runat="server" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgInfoxSedeC600B_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </fieldset>

        </asp:Panel>

    <!-- Instrumento 01 -->

    <asp:Panel runat="server" ID="PanelInstrumento01" Visible="false">

        <fieldset>
            <legend>Sedes</legend>

            <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
               <tr>
                   <td>
                       Nro de Sedes involucradas en la fusión: <asp:TextBox ID="txtNroSedesenFusion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                   </td>
               </tr>
              
            </table>
        </fieldset>
        
        <fieldset>
            <legend>Información de las Sedes de la Institución Educativa</legend>

          
        <asp:GridView ID="GridSedes" runat="server" CellPadding="4" DataKeyNames="cod"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen sedes para esta institución."
            GridLines="None" OnRowDeleting="GridSedes_RowDeleting" >
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="codSede" HeaderStyle-CssClass="ocultarcell" >
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nit" HeaderText="DANE">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                  <asp:BoundField DataField="consesede" HeaderText="Consecutivo Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Dirección">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
               <%--  <asp:BoundField DataField="telefono" HeaderText="Telefono">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="codmunicipio" HeaderText="codMunicipio" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrem" HeaderText="Municipio" />
                 <asp:BoundField DataField="codzona" HeaderText="codzona" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nomzona" HeaderText="Zona" />
                <asp:BoundField DataField="sede" HeaderText="Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
              <asp:BoundField DataField="codinstitucion" HeaderText="codinstitucion" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
              <%--  <asp:TemplateField>
                    <HeaderTemplate>
                        Ver
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVer" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVer_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Button ID="btnAgregarSede" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarSede_Click" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:CommandField ShowDeleteButton="True" Visible="false" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                    <ItemStyle Width="20px" />
                </asp:CommandField>--%>

                  <asp:TemplateField>
                    <HeaderTemplate>
                        01 x Sede
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgInfoxSede" runat="server" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgInfoxSede_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </fieldset>
        <table align="center"><tr><td><asp:Button runat="server" ID="btnAgregarInfoSede" CssClass="btn btn-success" Text="Terminar" OnClick="btnAgregarInfoSede_Click" /></td></tr></table>
    </asp:Panel>
  
     <asp:Button ID="btnShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelVerDependencias_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShow" PopupControlID="PanelEditarSede" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEditarSede" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodSede" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <legend>Edición de Sede</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado" border="0">
                <tr>
                    <td>NIT
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNitSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="txtNitSede_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtNitSede" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>

                    </td>
                     </tr>
                <tr>
                    <td>
                        Consecutivo Sede
                    </td>
                    <td colspan="3">
                          <asp:TextBox ID="txtConseSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtConseSede" runat="server" ErrorMessage="Digite el Consecutivo de la Sede"
                            Text="*" Display="None" ControlToValidate="txtConseSede" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" Enabled="True" TargetControlID="RFVtxtConseSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Nombre
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreSede" runat="server" ErrorMessage="Digite el nombre del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombreSede" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVtxtNombreSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Dirección
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                      <td>Zona
                    </td>
                    <td>
                       <asp:DropDownList ID="dropZonaEdit" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropZonaEdit" runat="server" ErrorMessage="Seleccione la Zona de la Sede" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropZonaEdit" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="RFVdropZonaEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender></td>
                </tr>
                <tr>
                    <td>Municipio
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipio" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Seleccione el municipio" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropMunicipio" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Sede
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoSede" runat="server" CssClass="TextBox">
                            <asp:ListItem>Principal</asp:ListItem>
                            <asp:ListItem>Sede</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnEditarSede" runat="server" ValidationGroup="editSede" CssClass="btn btn-success" Text="Editar Sede" OnClick="btnEditarSede_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

     <asp:Button ID="btnAddSedeShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelAgregarSede_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnAddSedeShow" PopupControlID="PanelAgregarSede" CancelControlID="btnCancelar2"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarSede" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Agregar Sede</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>NIT
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNitAddSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="txtNitAddSede_FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtNitAddSede" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>

                    </td>
                     </tr>
                <tr>
                    <td>Consecutivo Sede</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtConseSedeAdd" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtConseSedeAdd" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>Nombre
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreAddSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreAddSede" runat="server" ErrorMessage="Digite el nombre del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombreAddSede" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVtxtNombreAddSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                   
                    <td>Dirección
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionAddSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                     <td>Zona
                    </td>
                    <td>
                       <asp:DropDownList ID="DropZonaAdd" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVDropZonaAdd" runat="server" ErrorMessage="Seleccione la Zona de la Sede" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="DropZonaAdd" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RFVDropZonaAdd"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender></td>
                </tr>
                <tr>
                    <td>Municipio
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipioAddSede" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipioAddSede" runat="server" ErrorMessage="Seleccione el municipio" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropMunicipioAddSede" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RFVdropMunicipioAddSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Sede
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoAddSede" runat="server" CssClass="TextBox">
                            <asp:ListItem>Principal</asp:ListItem>
                            <asp:ListItem>Sede</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddSede" runat="server" CssClass="btn btn-success" ValidationGroup="addSede" Text="Agregar Sede" OnClick="btnAddSede_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar2" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>
   
     <asp:Panel ID="PanelCaracterizacion" runat="server" Visible="false">
        <h2 style="text-align:center"><%--Instrumento No. 02 <br />--%>
            Caracterización de Currículos de las Instituciones Educativas </h2>

         <table>
             <tr>
                 <td>
                     <b>Introducción:</b><br />

                    Para el diseño del Sistema de Información, Monitoreo, Seguimiento y Evaluación Permanente SIEP del proyecto CICLÓN, es importante, levantar una línea de base para la caracterización de Currículos de las instituciones educativas, en desarrollo de la estrategia No. 2 “Estrategia de autoformación, formación de saber y conocimiento y apropiación para maestros(as) acompañantes  coinvestigadores e investigadores en los lineamientos del programa ondas y su propuesta metodológica”, para valorar sus alcances en términos de resultados, efectos e impactos. 
                     <br /><br />
                    <b>Objetivo</b><br />

                    Recoger información básica sobre el PEI y los Currículos de las instituciones educativas que hacen parte del proyecto para indagar sobre el lugar de la investigación como Estrategia Pedagógica apoyada en TIC.
                     <br /><br />
                   <b> Metodología</b><br />

                    Este instrumento será diligenciado al inicio de la etapa No. 3 del proyecto fortalecimiento de la cultura ciudadana y democrática en CT+I a través de la iep apoyada en TIC en el dpto del Magdalena, denominada Ejecución y formación básica por el docente asesor o por quién haga sus veces. Será diligenciado directamente en el  SIEP.  Alguna de la información que solicita es de fuentes primarias y otras secundaria.

                 </td>
             </tr>
         </table>
        
      <%--  <fieldset>
            <legend>Responsable del diligenciamiento</legend>
             <table style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" >
                <tr>
         
             <td>
               Nombre del asesor <span class="auto-style1">*</span>
            </td>
            <td>
              <asp:DropDownList ID="dropAsesor02" runat="server" CssClass="TextBox" ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVdropAsesor02" runat="server" Display="None" ErrorMessage="Seleccione el Asesor"
                    ControlToValidate="dropAsesor02" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" TargetControlID="RFVdropAsesor02"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
             </td> 
            </tr>
            </table>
        </fieldset>--%>

    <fieldset>
        <legend>Agregar Caracterización del curriculo</legend>
        <asp:Label ID="lblCodPregunta" runat="server"></asp:Label>
        <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
        <tr>
            <td style="font-weight:bold;">
                <asp:Label ID="lblCodPregunta1" runat="server"></asp:Label>
                <asp:Label ID="lblPregunta1" runat="server"></asp:Label>
            </td>
        </tr>
            <tr>
                <td>
                      <asp:CheckBoxList ID="chkEnfasisPEI" runat="server" RepeatColumns="5" CssClass="TextBox">
                          <asp:ListItem>Ciencia</asp:ListItem>
                          <asp:ListItem>Tecnología</asp:ListItem>
                          <asp:ListItem>Innovación</asp:ListItem>
                          <asp:ListItem>Investigación</asp:ListItem>
                          <asp:ListItem>TIC</asp:ListItem>
                           <asp:ListItem>No aplica</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>  
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta2" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta2" runat="server"></asp:Label>
                </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkModeloEducativo" runat="server" RepeatColumns="3" CssClass="TextBox">
                          <asp:ListItem>Aceleración del aprendizaje</asp:ListItem>
                          <asp:ListItem>Escuela Nueva</asp:ListItem>
                          <asp:ListItem>Postprimaria</asp:ListItem>
                          <asp:ListItem>Telesecundara</asp:ListItem>
                          <asp:ListItem>Servicio de educación rural –SER-</asp:ListItem>
                          <asp:ListItem>Programa de educación continuada de CAFAM</asp:ListItem>
                          <asp:ListItem>Sistema De Educación Tutorial SAT</asp:ListItem>
                          <asp:ListItem>Propuesta educativa para jóvenes y adultos CRECER</asp:ListItem>
                        <asp:ListItem>No aplica</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr> 
            <tr>
                 <td style="font-weight:bold;">
                    Describa si el modelo educativo seleccionado favorece la incorporación de la IEP en su sede educativa?
                </td>
            </tr>
            <tr>
                <td>
                     <asp:TextBox ID="txtDescripcionIEP" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtDescripcionIEP" runat="server" ErrorMessage="Digite la descripcion"
                        Text="*" Display="None" ControlToValidate="txtDescripcionIEP"
                        ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RFVtxtDescripcionIEP" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta3" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta3" runat="server"></asp:Label>
                </td>
                </tr>
            <tr>
                <td>
                    <table align="center"  border="0" width="40%" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
                          <tr>
                            <td>
                                 <asp:Label ID="lblCodSubPregunta1" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta1" runat="server"></asp:Label> 
                                </td>
                            <td>
                                <asp:RadioButtonList ID="rbInvestigacionDocente" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                             </tr> 
                        <tr>
                            <td>
                                  <asp:Label ID="lblCodSubPregunta2" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta2" runat="server"></asp:Label> 
                                </td>
                            <td>
                                <asp:RadioButtonList ID="rbInvestigacionEstudiante" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                            </tr>
                        <tr>
                                <td>
                                     <asp:Label ID="lblCodSubPregunta3" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta3" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbticDocente" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:Label ID="lblCodSubPregunta4" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta4" runat="server"></asp:Label>
                                </td>
                            <td>
                    
                                <asp:RadioButtonList ID="rbticEstudiante" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                            </td>
                        </tr>
                </table>
            </td>
            </tr>
          <tr>
              <td style="font-weight:bold;">
                   <asp:Label ID="lblCodPregunta4" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta4" runat="server"></asp:Label>
              </td>
          </tr>
            <tr>
                 <td>
                      <asp:TextBox ID="txtPrincipalesPracticas" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtPrincipalesPracticas" runat="server" ErrorMessage="Digite la descripcion"
                        Text="*" Display="None" ControlToValidate="txtPrincipalesPracticas"
                        ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True" TargetControlID="RFVtxtPrincipalesPracticas" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            </table>
        <table><tr><td><asp:Button ID="btnPrimerGuardar02" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar02_Click" /></td></tr></table> 
        <br />
        <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta5" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:RadioButtonList ID="rbinvestigacionPEI" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta6" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta6" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkUsoTIC" runat="server" RepeatColumns="5" CssClass="TextBox">
                          <asp:ListItem>PC</asp:ListItem>
                          <asp:ListItem>Portátil </asp:ListItem>
                          <asp:ListItem>Tableta </asp:ListItem>
                          <asp:ListItem>Correo electrónico</asp:ListItem>
                          <asp:ListItem>Tablero inteligente</asp:ListItem>
                          <asp:ListItem>Software educativo</asp:ListItem>
                          <asp:ListItem>Wikis</asp:ListItem>
                          <asp:ListItem>Blogs</asp:ListItem>
                          <asp:ListItem>Foros</asp:ListItem>
                          <asp:ListItem>Otras</asp:ListItem>
                    </asp:CheckBoxList>
                    Cuáles?:
                     <asp:TextBox ID="txtUsoTIC" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta7" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta7" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:RadioButtonList ID="rbCompetenciaTIC" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta8" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta8" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkAreaCurriculo" runat="server" RepeatColumns="5" CssClass="TextBox">
                          <asp:ListItem>Pedagógica</asp:ListItem>
                          <asp:ListItem>Tecnológica </asp:ListItem>
                          <asp:ListItem>Investigativa </asp:ListItem>
                          <asp:ListItem>Comunicativa</asp:ListItem>
                          <asp:ListItem>Gestión</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    Área del currículo
                </td>
                </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaCurriculo" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                     <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false"   ValidationGroup="addUsuario"
                             CssClass="btn btn-success" onclick="btnGuardar_Click"/>
                </td>
            </tr>
            </table>
    </fieldset>

 </asp:Panel>

</asp:Content>

