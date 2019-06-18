<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseinstrusede.aspx.cs" Inherits="lineabaseinstrusede" %>

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
   <script src="//code.jquery.com/jquery-1.10.2.js"></script>
   <script>
       $(document).ready(function () {
           $(".TextBox").attr("disabled",true);
           $(".btn-success").hide();
           $(".btn-danger").hide();
           $("input[type=radio]").attr("disabled",true);
           $("textarea").attr("disabled",true);
           $("input[type=checkbox]").attr("disabled",true);
           
       });

   </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display:none;" ></div>
<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Información general de la sede en la institución educativa</h2>
    <div style="float:right;margin-top:-40px;"><asp:Button ID="btnRegresar" Text="Regresar" runat="server" Onclick="btnRegresar_Click" CssClass="btn btn-primary" /></div><br />
    <asp:Label ID="lblCodInstitucion" runat="server" Visible="False"></asp:Label> 
    <asp:Label ID="lblCodSede" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodAsesor" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblCodInstAsesor" runat="server" Visible="False"></asp:Label>

    <table>
        <tr>
            <td>
                <b>Presentación:</b>
                <br />
                El presente documento contiene una descripción detallada de la información de línea de base que se requiere de las Sedes educativas seleccionadas como beneficiarias del proyecto CICLÓN.
                <br /><br />
                Esta información, corresponde a la que según la normativa legal (Resolución 166 de 2003) debe recogerse en cada Institución Educativa y consolidarse en un sistema de información departamental, referida a los ítems de matrícula, perfil institucional, perfil docente, perfil de docentes directivos y caracterización de los estudiantes.
                <br /><br />
                Según el cronograma de aplicación establecido para todas las IES del país, la información correspondiente al año 2016, debe estar disponible en el mes de mayo, por lo cual se ajusta y aplica como línea de base para el proyecto CICLÓN.
                <br /><br />
                Proceso de aplicación: Se espera que los responsables del equipo técnico de FUNTICS realicen los trámites correspondientes ante las instancias responsables de la administración del sistema de matrícula departamental, para migrar la información del SIMAT, desagregada según esta guía, a la plataforma de CICLÓN.
                <br /><br />
                La información que se priorizo y referencia a continuación, fue elaborada con base en las matrices descriptivas de la información previstas en la Resolución de la referencia.

            </td>
        </tr>
    </table>

    <fieldset>
        <legend>Datos Institucional</legend>
        <asp:Label ID="lblDatoInstitucional" runat="server" Visible="true"></asp:Label>
    </fieldset>

    <fieldset>
        <legend>Especialidad</legend>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
               <tr>
                    <td style="font-weight:bold;">
                       1. Genero de la población atendida
                    </td>
                     </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="chkGeneroPoblacionAtendida" runat="server">
                            <asp:ListItem>Masculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Mixto</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">2. Etnias</td>
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
                  <td style="font-weight:bold;">
                  3.  Escoja la especialidad de la Sede Educativa
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList runat="server" ID="chkEspecialidad">
                        <asp:ListItem>Académica</asp:ListItem>
                        <asp:ListItem>Técnica (Incluye la Comercial, Industrial, Pedagógica, Promoción social, Agropecuario)</asp:ListItem>
                        <asp:ListItem>Otra</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td><asp:Button ID="btnPrimerGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnPrimerGuardar_Click" /></td>
            </tr>
        </table>
 </fieldset>

    <fieldset>
        <legend>Grados</legend>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                  <td style="font-weight:bold;">
                   4. Escoja los Grados que tiene la Sede Educativa
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList runat="server" ID="chkGradosSede" RepeatColumns="5">
                        <asp:ListItem>Pre-jardín</asp:ListItem>
                        <asp:ListItem>Jardín I o A o Kínder</asp:ListItem>
                        <asp:ListItem>Jardín II o B, Transición o Grado 0 </asp:ListItem>
                        <asp:ListItem>Primero</asp:ListItem>
                        <asp:ListItem>Segundo</asp:ListItem>
                        <asp:ListItem>Tercero</asp:ListItem>
                        <asp:ListItem>Cuarto</asp:ListItem>
                        <asp:ListItem>Quinto</asp:ListItem>
                        <asp:ListItem>Sexto</asp:ListItem>
                        <asp:ListItem>Séptimo</asp:ListItem>
                        <asp:ListItem>Octavo</asp:ListItem>
                        <asp:ListItem>Noveno</asp:ListItem>
                        <asp:ListItem>Décimo</asp:ListItem>
                        <asp:ListItem>Once</asp:ListItem>
                        <asp:ListItem>Doce - Normal Superior</asp:ListItem>
                        <asp:ListItem>Trece - Normal Superior</asp:ListItem>
                        <asp:ListItem>Educación discapacidad cognitiva no integrada</asp:ListItem>
                        <asp:ListItem>Educación discapacidad auditiva no integrada</asp:ListItem>
                        <asp:ListItem>Educación discapacidad visual no integrada</asp:ListItem>
                        <asp:ListItem>Educación discapacidad motora no integrada</asp:ListItem>
                        <asp:ListItem>Educación discapacidad múltiple no integrada</asp:ListItem>
                        <asp:ListItem>Ciclo 1 Adultos</asp:ListItem>
                        <asp:ListItem>Ciclo 2 Adultos</asp:ListItem>
                        <asp:ListItem>Ciclo 3 Adultos</asp:ListItem>
                        <asp:ListItem>Ciclo 4 Adultos</asp:ListItem>
                        <asp:ListItem>Ciclo 5 Adultos</asp:ListItem>
                        <asp:ListItem>Ciclo 6 Adultos</asp:ListItem>
    
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td><asp:Button ID="btnSegundoGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnSegundoGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>Nro de estudiantes</legend>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
             <tr>
                 <td><b>5. Número de estudiante</b></td>
             </tr>
            <tr>
                <td>
                    Número de estudiantes de género Masculino matriculados en el actual año escolar
                </td>
                <td>
                    <asp:TextBox ID="txtNroEstudiantesH" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Femenino matriculados en el actual año escolar
                </td>
                <td>
                    <asp:TextBox ID="txtNroEstudiantesF" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td>
                    Número de estudiantes de género Masculino con discapacidades  matriculados en Nivel Preescolar en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroHomDiscapacidadPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género Femenino con discapacidades  matriculados en Nivel Preescolar en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroFemDiscapacidadPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Masculino con discapacidades matriculados en Nivel Básica Primaria en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroHomDiscapacidadPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género Femenino con discapacidades matriculados en Nivel Básica Primaria en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroFemDiscapacidadPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Masculino con discapacidades matriculados en Nivel Básica Secundaria en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroHomDiscapacidadSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Femenino con discapacidades matriculados en Nivel Básica Secundaria en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroFemDiscapacidadSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Masculino con discapacidades o matriculados en Nivel Media en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroHomDiscapacidadMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    Número de estudiantes de género Femenino con discapacidades o matriculados en Nivel Media en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroFemDiscapacidadMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td><asp:Button ID="btnTercerGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnTercerGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>Etnias</legend>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
             <tr>
                 <td>
                     <b>6. Etnías</b>
                 </td>
             </tr>
            <tr>
                <td>
                    Número de estudiantes de género Masculino de la etnia matriculados en el año en curso en el nivel de preescolar
                </td>
                <td>
                     <asp:TextBox ID="txtNroMasEtniaPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Femenino de la etnia matriculados en el año en curso en el nivel de preescolar
                </td>
                <td>
                     <asp:TextBox ID="txtNroFemEtniaPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Masculino de la etnia matriculados en el año en curso en el nivel de primaria
                </td>
                <td>
                     <asp:TextBox ID="txtNroMasEtniaPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Femenino de la etnia matriculados en el año en curso en el nivel de primaria
                </td>
                <td>
                     <asp:TextBox ID="txtNroFemEtniaPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de estudiantes de género Masculino de la etnia matriculados en el año en curso en el nivel de secundaria
                </td>
                <td>
                     <asp:TextBox ID="txtNroMasEtniaSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    Número de estudiantes de género Femenino de la etnia matriculados en el año en curso en el nivel de secundaria
                </td>
                <td>
                     <asp:TextBox ID="txtNroFemEtniaSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género Masculino de la etnia matriculados en el año en curso en el nivel de media
                </td>
                <td>
                     <asp:TextBox ID="txtNroMasEtniaMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género Femenino de la etnia matriculados en el año en curso en el nivel de media
                </td>
                <td>
                     <asp:TextBox ID="txtNroFemEtniaMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td><asp:Button ID="btnCuartoGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnCuartoGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>Metodología</legend>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                  <td style="font-weight:bold;">
                   7. Escoja la metodología de la Sede
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkMetodologia" runat="server">
                        <asp:ListItem>SER</asp:ListItem>
                        <asp:ListItem>CAFAM</asp:ListItem>
                        <asp:ListItem>SAT</asp:ListItem>
                        <asp:ListItem>Aceleración del Aprendizaje</asp:ListItem>
                    </asp:CheckBoxList>
                    Otra <br />
                     <asp:textbox runat="server" ID="txtOtraMetodologia" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género masculino matriculados en instituciones del sector oficial en el actual año escolar, <br />según la metodología/programa educativo o modelo pedagógico
                </td>
                <td>
                    <asp:TextBox ID="txtNroMasMetodologia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género femenino matriculados en instituciones del sector oficial en el actual año escolar, <br />según la metodología/programa educativo o modelo pedagógico
                </td>
                <td>
                    <asp:TextBox ID="txtNroFemMetodologia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td><asp:Button ID="btnQuintoGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnQuintoGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>
 
    <fieldset>
        <legend>Población víctima del conflicto</legend>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                  <td style="font-weight:bold;">
                  8. Escoja la población víctima del conflicto
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkPoblacion" runat="server">
                        <asp:ListItem>En situación de desplazamiento</asp:ListItem>
                        <asp:ListItem>Desvinculados</asp:ListItem>
                        <asp:ListItem>Hijos de adultos desmovilizados</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
              <tr>
                <td>
                    Número de estudiantes de género masculino matriculados en instituciones del sector oficial en el actual año escolar,<br /> considerados población víctima del conflicto
                </td>
                <td>
                    <asp:TextBox ID="txtMasPoblacionVictima" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de estudiantes de género femenino matriculados en instituciones del sector oficial en el actual año escolar,<br /> considerados población víctima del conflicto
                </td>
                <td>
                    <asp:TextBox ID="txtFemPoblacionVictima" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <hr />
                </td>
            </tr>
             <tr>
                 <td style="font-weight:bold;">
                  9.  Escoja el nivel de educación
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkNivelEducativo" runat="server">
                        <asp:ListItem>Preescolar</asp:ListItem>
                        <asp:ListItem>Básica Primaria</asp:ListItem>
                        <asp:ListItem>Básica Secundaria</asp:ListItem>
                        <asp:ListItem>Media</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
             
             
             </table>
         <table>
            <tr>
                <td><asp:Button ID="btnSextoGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnSextoGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Recurso Humano de la Institución Educativa</legend>

        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td >
                    Año de reporte de la información
                </td>
            </tr>
            <tr>
                <td>
                  <b>10. Clase de funcionario</b> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkFuncionarios" runat="server" RepeatColumns="2">
                        <asp:ListItem>Rectores / Directores Rurales</asp:ListItem>
                        <asp:ListItem>Coordinadores</asp:ListItem>
                        <asp:ListItem>Supervisores de Educación</asp:ListItem>
                        <asp:ListItem>Directores de Núcleo de Desarrollo Educativo</asp:ListItem>
                        <asp:ListItem>Docentes</asp:ListItem>
                        <asp:ListItem>Docentes en Comisión</asp:ListItem>
                        <asp:ListItem>Docentes de educación especial</asp:ListItem>
                        <asp:ListItem>Etnoeducadores</asp:ListItem>
                        <asp:ListItem>Administrativos</asp:ListItem>
                        <asp:ListItem>Profesionales de apoyo en el aula a alumnos con discapacidades ((intérpretes, tiflólogos, etc.)</asp:ListItem>
                        <asp:ListItem>Profesionales en el área de las salud (Médicos, odontólogos, terapeutas, enfermeros, etc)</asp:ListItem>
                        <asp:ListItem>Consejeros y orientadores</asp:ListItem>
                    </asp:CheckBoxList>
                    Otro <br />
                     <asp:textbox runat="server" ID="txtFuncionario" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                </td>
            </tr>
           </table>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td>
                    Número de docentes hombres
                </td>
                <td>
                    <asp:TextBox ID="txtDocentesHom" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                </td>
                </tr>
            <tr>
                 <td>
                    Número de docentes mujeres
                </td>
                <td>
                    <asp:TextBox ID="txtDocentesMuj" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="font-weight:bold;">
                   11. Ultimo nivel aprobado
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkUltimoNivelEducativo" runat="server" RepeatColumns="2">
                        <asp:ListItem>Bachillerato pedagógico</asp:ListItem>
                        <asp:ListItem>Normalista Superior</asp:ListItem>
                        <asp:ListItem>Otro bachillerato</asp:ListItem>
                        <asp:ListItem>Técnico o tecnológico pedagógico</asp:ListItem>
                        <asp:ListItem>Otro Técnico o tecnológico</asp:ListItem>
                        <asp:ListItem>Profesional pedagógico</asp:ListItem>
                        <asp:ListItem>Otro profesional</asp:ListItem>
                        <asp:ListItem>Postgrado pedagógico</asp:ListItem>
                        <asp:ListItem>Otro postgrado</asp:ListItem>
                        <asp:ListItem>Profesionales de apoyo en el aula a alumnos con discapacidades ((intérpretes, tiflólogos, etc.)</asp:ListItem>
                        <asp:ListItem>Profesionales en el área de las salud (Médicos, odontólogos, terapeutas, enfermeros, etc)</asp:ListItem>
                        <asp:ListItem>Consejeros y orientadores</asp:ListItem>
                        
                    </asp:CheckBoxList>
                    Otro<br />
                     <asp:textbox runat="server" ID="txtUltimoNivelEducativo" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                </td>
            </tr>
             <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    Número de docentes de género Masculino que dicta clases en Nivel Preescolar en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroDocentesMasPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de docentes de género Femenino que dicta clases en Nivel Preescolar en el año en curso
                </td>
                <td>
                    <asp:TextBox ID="txtNroDocentesFemPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de docentes de género Masculino que dicta clases en Nivel Básica Primaria en el año en curso
                </td>
                 <td>
                    <asp:TextBox ID="txtNroDocentesMasPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Número de docentes de género Femenino que dicta clases en Nivel Básica Primaria en el año en curso
                </td>
                 <td>
                    <asp:TextBox ID="txtNroDocentesFemPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    Número de docentes de género Masculino que dicta clases en Nivel Básica Secundaria y Media en el año en curso
                </td>
                 <td>
                    <asp:TextBox ID="txtNroDocentesMasSecundariaMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Número de docentes de género Femenino que dicta clases en Nivel Básica Secundaria y Media en el año en curso
                </td>
                 <td>
                    <asp:TextBox ID="txtNroDocentesFemSecundariaMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox>
                </td>
            </tr>
        </table>
          <table>
            <tr>
                <td><asp:Button ID="btnSeptimoGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnSeptimoGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>Estrato socieconomico del estudiante</legend>
        <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                 <td style="font-weight:bold;">
                  12.  Estrato del estudiante
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkEstudiante" runat="server" RepeatColumns="4">
                        <asp:ListItem>Estrato 0</asp:ListItem>
                        <asp:ListItem>Estrato 1</asp:ListItem>
                        <asp:ListItem>Estrato 2</asp:ListItem>
                        <asp:ListItem>Estrato 3</asp:ListItem>
                        <asp:ListItem>Estrato 4</asp:ListItem>
                        <asp:ListItem>Estrato 5</asp:ListItem>
                        <asp:ListItem>Estrato 6</asp:ListItem>
                        <asp:ListItem>Otro</asp:ListItem>
                    </asp:CheckBoxList>
                    Otro<br />
                     <asp:textbox runat="server" ID="txtEstudiante" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                </td>
            </tr>
             <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                  <td style="font-weight:bold;">13. Sisben</td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkSisben" runat="server">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>N/A</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
             <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                  <td style="font-weight:bold;">
                   14. Tipo de discapacidad
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkDiscapacidad" runat="server" RepeatColumns="6">
                        <asp:ListItem>Sordera Profunda</asp:ListItem>
                        <asp:ListItem>Hipoacusia o Baja audición</asp:ListItem>
                        <asp:ListItem>Baja visión diagnosticada</asp:ListItem>
                        <asp:ListItem>Ceguera</asp:ListItem>
                        <asp:ListItem>Parálisis cerebral</asp:ListItem>
                        <asp:ListItem>Lesión neuromuscular</asp:ListItem>
                        <asp:ListItem>Autismo</asp:ListItem>
                        <asp:ListItem>Deficiencia cognitiva (Retardo Mental)</asp:ListItem>
                         <asp:ListItem>Síndrome de Down</asp:ListItem>
                         <asp:ListItem>Múltiple</asp:ListItem>
                         <asp:ListItem>N/A</asp:ListItem>
                    </asp:CheckBoxList>
                    Otro<br />
                    <asp:textbox runat="server" ID="txtDiscapacidad" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td><asp:Button ID="btnOctavoGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnOctavoGuardar_Click" /></td>
            </tr>
        </table>
    </fieldset>

    <fieldset>
        <legend>Tipos de Etnias</legend>
         <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
             <tr>
                 <td>
                     <b>15. Tipo de Etnías</b>
                 </td>
             </tr>
             <tr>
                 <td>
                       <asp:CheckBoxList ID="chkTipoEtnias" runat="server" RepeatColumns="9">
            <asp:ListItem>Achagua</asp:ListItem>
            <asp:ListItem>Amorua</asp:ListItem>
            <asp:ListItem>Andoque</asp:ListItem>
            <asp:ListItem>Arhuaco</asp:ListItem>
            <asp:ListItem>Awa</asp:ListItem>
            <asp:ListItem>Bará</asp:ListItem>
            <asp:ListItem>Barazana</asp:ListItem>
            <asp:ListItem>Barí</asp:ListItem>
            <asp:ListItem>Betoye</asp:ListItem>
             <asp:ListItem>Bora</asp:ListItem>
            <asp:ListItem>Cabiyari</asp:ListItem>
            <asp:ListItem>Carapana</asp:ListItem>
            <asp:ListItem>Carijona</asp:ListItem>
            <asp:ListItem>Chimila</asp:ListItem>
            <asp:ListItem>Chiricoa</asp:ListItem>
            <asp:ListItem>Cocama</asp:ListItem>
            <asp:ListItem>Coconuco</asp:ListItem>
            <asp:ListItem>Cofán</asp:ListItem>
             <asp:ListItem>Coyaima-Natagaima</asp:ListItem>
            <asp:ListItem>Cubeo</asp:ListItem>
            <asp:ListItem>Cuiba</asp:ListItem>
            <asp:ListItem>Curripaco</asp:ListItem>
            <asp:ListItem>Desano</asp:ListItem>
            <asp:ListItem>Dujos</asp:ListItem>
            <asp:ListItem>Embera</asp:ListItem>
            <asp:ListItem>EmberaCatio</asp:ListItem>
            <asp:ListItem>Embera Chami</asp:ListItem>
             <asp:ListItem>Embera Siapidara</asp:ListItem>
            <asp:ListItem>Guambiano</asp:ListItem>
            <asp:ListItem>Guanaca</asp:ListItem>
            <asp:ListItem>Guayabero</asp:ListItem>
            <asp:ListItem>Guayuú</asp:ListItem>
            <asp:ListItem>Hitnú</asp:ListItem>
            <asp:ListItem>Inga</asp:ListItem>
            <asp:ListItem>Kamsa</asp:ListItem>
             <asp:ListItem>Kogui</asp:ListItem>
            <asp:ListItem>Koreguaje</asp:ListItem>
            <asp:ListItem>Letuama</asp:ListItem>
            <asp:ListItem>Macaguaje</asp:ListItem>
            <asp:ListItem>Macú</asp:ListItem>
            <asp:ListItem>Macuna</asp:ListItem>
            <asp:ListItem>Masiguare</asp:ListItem>
            <asp:ListItem>Matapi</asp:ListItem>
            <asp:ListItem>Miraña</asp:ListItem>
             <asp:ListItem>Muinane</asp:ListItem>
            <asp:ListItem>Muisca</asp:ListItem>
            <asp:ListItem>Nonuya</asp:ListItem>
            <asp:ListItem>Ocaina</asp:ListItem>
            <asp:ListItem>Paéz</asp:ListItem>
            <asp:ListItem>Pastos</asp:ListItem>
            <asp:ListItem>Piapoco</asp:ListItem>
             <asp:ListItem>Piaroa</asp:ListItem>
            <asp:ListItem>Piratapuyo</asp:ListItem>
            <asp:ListItem>Pisamira</asp:ListItem>
            <asp:ListItem>Puinave</asp:ListItem>
            <asp:ListItem>Sáliba </asp:ListItem>
            <asp:ListItem>Sikuani</asp:ListItem>
            <asp:ListItem>Siona</asp:ListItem>
            <asp:ListItem>Siriano</asp:ListItem>
            <asp:ListItem>Siripu</asp:ListItem>
             <asp:ListItem>Taiwano</asp:ListItem>
            <asp:ListItem>TanimuKa</asp:ListItem>
            <asp:ListItem>Tariano</asp:ListItem>
            <asp:ListItem>Tatuyo</asp:ListItem>
            <asp:ListItem>Tikunas</asp:ListItem>
            <asp:ListItem>Totoró</asp:ListItem>
            <asp:ListItem>Tucano</asp:ListItem>
            <asp:ListItem>Tule</asp:ListItem>
             <asp:ListItem>Tuyuca</asp:ListItem>
            <asp:ListItem>U´wa</asp:ListItem>
            <asp:ListItem>Wanano</asp:ListItem>
            <asp:ListItem>Wayuu</asp:ListItem>
            <asp:ListItem>Witoto</asp:ListItem>
            <asp:ListItem>Wiwua</asp:ListItem>
            <asp:ListItem>Wounaan</asp:ListItem>
            <asp:ListItem>Yagua</asp:ListItem>
            <asp:ListItem>Yanacona</asp:ListItem>
             <asp:ListItem>Yauna</asp:ListItem>
            <asp:ListItem>Yucuna</asp:ListItem>
            <asp:ListItem>Yuko</asp:ListItem>
            <asp:ListItem>Yurí</asp:ListItem>
            <asp:ListItem>Yurutí</asp:ListItem>
             <asp:ListItem>Zenú</asp:ListItem>
            <asp:ListItem>Caramanta</asp:ListItem>
            <asp:ListItem>Katio</asp:ListItem>
            <asp:ListItem>Chami</asp:ListItem>
            <asp:ListItem>Corocoro</asp:ListItem>
            <asp:ListItem>Datuana</asp:ListItem>
            <asp:ListItem>Garú</asp:ListItem>
            <asp:ListItem>Mura</asp:ListItem>
            <asp:ListItem>Payoarini</asp:ListItem>
            <asp:ListItem>Polindara</asp:ListItem>
            <asp:ListItem>Tama</asp:ListItem>
            <asp:ListItem>In residentes Bogotá</asp:ListItem>
            <asp:ListItem>Negritudes</asp:ListItem>
            <asp:ListItem>Rom</asp:ListItem>
          
        </asp:CheckBoxList>
                     Otras Etnías<br />
                      <asp:textbox runat="server" ID="txtOtrasEtnias" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox>
                 </td>
             </tr>
             </table>
      

    </fieldset>
    <br />
    <table >
        <tr>
            <td>
                <asp:button ID="btnGuardarSede" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardarSede_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

