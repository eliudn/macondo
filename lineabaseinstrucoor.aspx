<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseinstrucoor.aspx.cs" Inherits="lineabaseinstrucoor" %>

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
           $("#MainContent_btnIniciarDisponibilidadTIC").hide();           
       });
   </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display:none;" ></div>
<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Registro de Línea base</h2><br />
<div style="float:right;margin-top:-40px;">
        <a href="menulineabase.aspx" class="btn btn-primary" >Regresar</a>
    </div>
    <asp:Label ID="lblCodRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodDANE" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodSedeinsAsesor" runat="server" Visible="false"></asp:Label>

     <table align="center">
        <tr>
             <td align="center">
                 <asp:Button ID="btnIniciarDisponibilidadTIC" Visible="true" runat="server" CssClass="btn btn-primary" Text="03 - Disponibilidad, acceso y uso TIC" OnClick="btnIniciarDisponibilidadTIC_Onclick" />
            </td>
        </tr>
         <tr>
             <td>
                <b> Introducción </b><br />

                    Para la construcción de la línea de base del proyecto Ciclón se requiere recoger información institucional básica sobre el equipamiento institucional de TIC y su uso pedagógico, con el objeto de aportar indicadores para la línea de base del proyecto. <br /><br />
                    Para su elaboración se hizo una revisión del marco de política tanto a nivel nacional como departamental para indagar sobre la normatividad con referencia a TIC. Los artículos 20 y 67 de la Constitución Política establecen que el Estado promoverá el derecho al acceso a las Tecnologías de la Información y las Comunicaciones que permitan entre otros, el ejercicio pleno al derecho de la educación. Inspirada en estos principios, la Ley 1341 de febrero de 2009 establece que las entidades del orden nacional y territorial dispondrán lo pertinente para garantizar el uso y acceso a estos derechos. Igualmente el Plan Nacional de Tics 2008 - 2019 genera directrices al mismo fin.<br />
                    <br />
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
            <legend>Sedes de la Institución Educativa</legend>

          
        <asp:GridView ID="GridSedes" runat="server" CellPadding="4" DataKeyNames="cod"
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
                        03 x Sede
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

   <!-- Instrumento 03 Disposición, acceso y uso de las TICS  -->
    <asp:Panel ID="PanelDisposicionTIC" runat="server" Visible="false">
         <h2 style="text-align:center"><%--Instrumento No. 03 <br />--%>
            Disponibilidad, acceso y uso de Tics </h2>

        <fieldset>
            <legend>Primera Parte</legend>
            <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
            <tr>
                <td style="font-weight:bold;">
                    1.	Instituciones educativas con infraestructura para TIC (conectividad y equipamiento)
                </td>
            </tr>
            <tr>
                <td>
                    1.1.	Equipamiento:   
                </td>
            </tr>
            <tr>
                <td>
                    <table border="1">
                        <tr>
                            <td rowspan="3" style="font-weight:bold;text-align:center">
                                Usuarios
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                                Nro Pc
                            </td>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                               No. Portátiles
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tablet
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tableros inteligentes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                        </tr>
                        <tr>
                           <td style="font-weight:bold">
                                Administración  
                            </td>
                            <td><asp:TextBox runat="server" ID="txtAdminPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtAdminTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Docentes 
                            </td>
                            <td><asp:TextBox runat="server" ID="txtDocentePCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocentePCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocentePortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocentePortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtDocenteTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                           <td style="font-weight:bold">
                                Estudiantes
                            </td>
                           <td><asp:TextBox runat="server" ID="txtEstudiantesPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEstudiantesTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Total 
                            </td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
                </table>
            <table><tr><td>  <asp:Button ID="btnPrimerGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar_OnClick" /></td></tr></table>
           <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                <tr>
                    <td>
                        1.1.1.	Equipamiento desagregado según estudiantes por grado
                    </td>
                 </tr>
                <tr>
                    <td>
                        <table border="1">
                        <tr>
                            <td rowspan="3" style="font-weight:bold;text-align:center">
                                Estudiantes<br />
                                Grados
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                                Nro Pc
                            </td>
                            <td colspan="2" style="font-weight:bold;text-align:center">
                               No. Portátiles
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tablet
                            </td>
                             <td colspan="2" style="font-weight:bold;text-align:center">
                                No. Tableros inteligentes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                            <td>
                                Con Conexión
                            </td>
                            <td>
                                Sin conexión
                            </td>
                        </tr>
                        <tr>
                           <td style="font-weight:bold">
                                Preescolar  
                            </td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtPreescolarTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Básica primaria 
                            </td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicaprimariaTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                           <td style="font-weight:bold">
                                Básica secundaria
                            </td>
                           <td><asp:TextBox runat="server" ID="txtBasicasecundariaPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtBasicasecundariaTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                             <tr>
                           <td style="font-weight:bold">
                                Media
                            </td>
                           <td><asp:TextBox runat="server" ID="txtMediaPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtMediaTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                             <tr>
                           <td style="font-weight:bold">
                                Normal Superior 
                            </td>
                           <td><asp:TextBox runat="server" ID="txtNormalSuperiorPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtNormalSuperiorTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                             <tr>
                           <td style="font-weight:bold">
                               Educación discapacidad 
                            </td>
                           <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" ID="txtEducaciondiscapacidadTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                         <tr>
                            <td style="font-weight:bold">
                                Total 
                            </td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPCConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPCSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPortatilesConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosPortatilesSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTabletsConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTabletsSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTablerosConConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                            <td><asp:TextBox runat="server" Enabled="false" ID="txtTotalGradosTablerosSinConexion" Width="75" CssClass="TextBox"></asp:TextBox></td>
                        </tr>
                    </table>
                    </td>
                </tr>
           </table>
            <table><tr><td>  <asp:Button ID="btnSegundoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSegundoGuardar_OnClick" /></td></tr></table>
            </fieldset>

        <fieldset>
            <legend>Segunda Parte</legend>
            <table>
                <tr>
                   <td >
                        1.1.2.	¿Los estudiantes tienen acceso en equipamiento en TICs fuera del horario escolar?    
                    </td>
                </tr>
                <tr>
                    <td>
                <table border="1">
                    <tr>
                        <td rowspan="3" style="font-weight:bold;text-align:center">Estudiantes<br /> Grados </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-weight:bold;text-align:center">Nro Pc </td>
                        <td colspan="2" style="font-weight:bold;text-align:center">No. Portátiles </td>
                        <td colspan="2" style="font-weight:bold;text-align:center">No. Tablet </td>
                        <td colspan="2" style="font-weight:bold;text-align:center">No. Tableros inteligentes </td>
                    </tr>
                    <tr>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                        <td>Con Conexión </td>
                        <td>Sin conexión </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Preescolar </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreescolarTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Básica primaria </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicaprimariaTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Básica secundaria </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicasecundariaTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Media </td>
                        <td>
                            <asp:TextBox ID="txtMediaPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMediaTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Normal Superior </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNormalSuperiorTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Educación discapacidad </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPCConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPCSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPortatilesConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTabletsConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTabletsSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTablerosConConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEducaciondiscapacidadTablerosSinConexionFuera" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Total </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPCConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPCSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPortatilesConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosPortatilesSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTabletsConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTabletsSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTablerosConConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalGradosTablerosSinConexionFuera" runat="server" CssClass="TextBox" Enabled="false" Width="75"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                        </td>
                </tr>
                </table>
             <table><tr><td>  <asp:Button ID="btnTercerGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnTercerGuardar_OnClick" /></td></tr></table>
            <table>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                  <tr>
                    <td>
                        1.1.3.	Calidad de acceso y soporte técnico del equipamiento.    
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <p style="font-weight:bold;text-align:center"> Califique de 1 a  5 (siendo uno lo más bajo y cinco lo más alto)  los siguientes ítems</p>
                     <asp:GridView ID="GridPregunta1Intrumento03" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="50%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Item" />
                            <asp:TemplateField HeaderStyle-Width="18%">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codpregunta" HeaderText="Codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codsubpregunta" HeaderText="Codsubpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
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
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        1.2.	Ubicación del equipamiento de uso pedagógico
                    </td>
                </tr>
                <tr>
                    <td>
                       <table border="1">
                           <tr>
                                 <td style="font-weight:bold">
                                    Equipamento
                                </td>
                                <td style="font-weight:bold">
                                    Ludotecas
                                </td>
                                 <td style="font-weight:bold">
                                    Bibliotecas
                                </td>
                                 <td style="font-weight:bold">
                                    Salones de <br />computo
                                </td>
                                 <td style="font-weight:bold">
                                    Aulas
                                </td>
                                 <td style="font-weight:bold">
                                    Otros
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold">
                                    No. PC
                                </td>
                                <td>
                                    <asp:TextBox id="txtLudotecasPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosPC" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                   <td style="font-weight:bold">
                                      No. Portátiles 
                                  </td>
                                <td>
                                    <asp:TextBox id="txtLudotecaPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosPortatil" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                  <td style="font-weight:bold">
                                     No. Tablet
                                 </td>
                                <td>
                                    <asp:TextBox id="txtLudotecaTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosTablet" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td style="font-weight:bold">
                                    No. Tableros inteligentes
                                </td>
                                <td>
                                    <asp:TextBox id="txtLudotecaTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosTableros" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                 <td style="font-weight:bold">
                                     Total 
                                 </td>
                                <td>
                                    <asp:TextBox id="txtLuditecaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtBibliotecaTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtSalonesTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:TextBox id="txtAulasTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="txtOtrosTotal" Enabled="false" runat="server" CssClass="TextBox" Width="75"></asp:TextBox>
                                </td>
                            </tr>
                       </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                     <b>  1.3. La institución dispone de software educativo?</b><br/>
                        Si lo utiliza, ¿en que grados?   ¿En qué áreas?
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <asp:GridView ID="GridSoftwareEducativo" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />

                             <asp:TemplateField >
                                <HeaderTemplate>Software</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSoftware" runat="server" CssClass="TextBox" Width="200"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Grados</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGradosSoftware" runat="server" CssClass="TextBox" Width="200"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Áreas</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAreasSoftware" runat="server" CssClass="TextBox" Width="200" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
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
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                     <b>  1.4. De cuál de estas herramientas dispone la institución educativa:</b>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <asp:GridView ID="GridHerramientasDisponeIE" runat="server"  AutoGenerateColumns="False" CellPadding="4" 
                            GridLines="None" Width="30%"
                            ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nro" HeaderText="Nro." />
                            <asp:TemplateField >
                                <HeaderTemplate>Tipo</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:DropDownList ID="dropHerramientasDisponeIE" runat="server">
                                       <asp:ListItem>N/A</asp:ListItem>
                                      <asp:ListItem>Wikis</asp:ListItem>
                                      <asp:ListItem>Blogs</asp:ListItem>
                                      <asp:ListItem>Página de internet</asp:ListItem>
                                     
                                  </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <HeaderTemplate>Dirección</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDireccionHerramientasDisponeIE" runat="server" CssClass="TextBox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                          
                            <asp:BoundField DataField="codpregunta" HeaderText="codpregunta" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
                            <asp:BoundField DataField="codinstrumento" HeaderText="Codinstrumento" HeaderStyle-CssClass="ocultarcell" ItemStyle-CssClass="ocultarcell" />
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
                    <td>
                        Plataformas pedagógicas <br/> ¿Cuál o cuáles?
                    </td>
                    </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="txtPlataformasPedagogicas" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                </table>
             
            <table>
                <tr>
                    <td style="font-weight:bold;">
                        2.	Desarrollo profesional de los docentes en el uso pedagógico de medios y tecnologías de información y comunicación.
                    </td>
                </tr>
                <tr>
                    <td>
                        2.1.	¿La institución ha participado en procesos de formación de docentes en el uso de las TICs?  
                    </td>
                </tr>
                <tr>
                    <td>
                       Nombre del proceso de formación: <asp:TextBox ID="txtNomProcesoFormacionTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Duración en horas la capacitación: <asp:TextBox ID="txtNomProcesoFormacionTICSHoras" CssClass="TextBox" runat="server" Width="50"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Total beneficiario y beneficiarias: <asp:TextBox ID="txtNomProcesoFormacionTICSTotalBeneficiarios" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        2.2.	¿En los últimos tres Planes  de  Mejoramiento Institucional  se han incluido propuestas de mejoramiento en el uso de las TICs?  
                    </td>
                </tr>
                <tr>
                    <td>
                       Cuáles se han incluido?: <asp:TextBox ID="txtCualesPlanesMejoramientoTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Cuales se han desarrollado?: <asp:TextBox ID="txtDesarrolladosPlanesMejoramientoTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       Cuáles han sido los efectos en la institución?: <asp:TextBox ID="txtEfectosPlanesMejoramientoTICS" CssClass="TextBox" runat="server" Width="200"></asp:TextBox> 
                    </td>
                </tr>
               
            </table>

        </fieldset>
        <br />
       <table><tr><td>  <asp:Button ID="btnCuartoGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnCuartoGuardar_OnClick" /></td></tr></table>
             <%--<asp:Button ID="btnAgregarDisponibilidadTICS" runat="server" CssClass="btn btn-success" Text="Terminar" OnClick="btnAgregarDisponibilidad_OnClick" />--%>
            
       
    </asp:Panel>
 

</asp:Content>

