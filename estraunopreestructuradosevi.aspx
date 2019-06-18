<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunopreestructuradosevi.aspx.cs" Inherits="estraunopreestructuradosevi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
    <script src="jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    
    <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>
    
    
    
    <!--Prueba -->

  <script type="text/javascript">
      function mostrar() {
          document.getElementById('oculto').style.display = 'block';
          document.getElementById('oculto2').style.display = 'none';
          document.getElementById('oculto3').style.display = 'none';
          document.getElementById('oculto4').style.display = 'none';
      }
  </script>

  <script type="text/javascript">
        function mostrar2() {
            document.getElementById('oculto2').style.display = 'block';
            document.getElementById('oculto3').style.display = 'none';
            document.getElementById('oculto4').style.display = 'none';
            document.getElementById('oculto').style.display = 'none';
        }
  </script>

  <script type="text/javascript">
    function mostrar3() {
        document.getElementById('oculto3').style.display = 'block';
        document.getElementById('oculto4').style.display = 'none';
        document.getElementById('oculto').style.display = 'none';
        document.getElementById('oculto2').style.display = 'none';
    }
  </script>

  <script type="text/javascript">
        function mostrar4() {
            document.getElementById('oculto4').style.display = 'block';
            document.getElementById('oculto').style.display = 'none';
            document.getElementById('oculto2').style.display = 'none';
            document.getElementById('oculto3').style.display = 'none';
        }
  </script>

    <!--Cierre prueba dos-->
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <br /><br />
  <h2>Estrategia No 1 - Cargue de evidencias Preestructurados</h2>
     
    <asp:Label runat="server" Visible="false" ID="lblCoord"></asp:Label>
     <asp:Label runat="server" Visible="false" ID="lblCodUsuario"></asp:Label>
     <asp:Label runat="server" Visible="false" ID="lblCodigo"></asp:Label>

     <!-- DATOS DE LA INSTITUCIÓN -->
   
    <!-- FIN DATOS DE LA INSTITUCIÓN -->

               
                <!--Prueba -->
                <div style="text-align: center">
                <input type="button" value="Ambiental" onclick="mostrar()" class="btn btn-primary">
                <input type="button" value="Bienestar infantil y juvenil" onclick="mostrar2()" class="btn btn-primary">
                <input type="button" value="Energías para el futuro" onclick="mostrar3()" class="btn btn-primary">
                <input type="button" value="Historia" onclick="mostrar4()" class="btn btn-primary">
                </div>
    
                <div id='oculto' style='display:true;'>
                    <center><h1>Ambiental</h1></center>
                    <fieldset> 
                    <legend><b>1. DESCARGA Y DILIGENCIA LA BITÁCORA CORRESPONDIENTE</b></legend>
                    <b>• Momento pedagógico 1</b><br />
                   Bitácora Ambiental <a href="Manuales/Bitacoras/Momento1/Ambiental/Ambiental%20Bitácora%201.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 3</b><br />
                   Bitácora Ambiental <a href="Manuales/Bitacoras/Momento3/Ambiental/Ambiental%20Bitácora%202.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 4</b><br />
                   Bitácora Ambiental <a href="Manuales/Bitacoras/Momento4/Ambiental/Ambiental%20Bitácora%203.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 5</b><br />
                   Bitácora Ambiental <a href="Manuales/Bitacoras/Momento5/Ambiental/Ambiental%20Bitácora%204.doc">Descargar</a><br />
                    </fieldset>
                </div>
                    
               
    
                <div id='oculto2' style='display:none;'>
                    <center><h1>Bienestar infantil y juvenil</h1></center>
                    <fieldset> 
                    <legend><b>1. DESCARGA Y DILIGENCIA LA BITÁCORA CORRESPONDIENTE</b></legend>
                    <b>• Momento pedagógico 1</b><br />
                   Bitácora Bienestar <a href="Manuales/Bitacoras/Momento1/Bienestar%20infantil/Bienestar%20Bitácora%201.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 3</b><br />
                   Bitácora Bienestar <a href="Manuales/Bitacoras/Momento3/Bienestar%20infantil/Bienestar%20Bitácora%202.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 4</b><br />
                   Bitácora Bienestar <a href="Manuales/Bitacoras/Momento4/Bienestar%20infantil/Bienestar%20Bitácora%203.doc">Descargar</a><br />
                </fieldset> 
                        </div> 


                <div id='oculto3' style='display:none;'>
                    <center><h1>Energías para el futuro</h1></center>
                    <fieldset> 
                    <legend><b>1. DESCARGA Y DILIGENCIA LA BITÁCORA CORRESPONDIENTE</b></legend>
                    <b>• Momento pedagógico 1</b><br />
                   1. Bitácora Energías <a href="Manuales/Bitacoras/Momento1/Energías%20para%20el%20futuro/Energía%20Bitácora%201.doc">Descargar</a><br />
                   2. Bitácora Energías <a href="Manuales/Bitacoras/Momento1/Energías%20para%20el%20futuro/Energía%20Bitácora%202.doc">Descargar</a><br />
                   3. Bitácora Energías <a href="Manuales/Bitacoras/Momento1/Energías%20para%20el%20futuro/Energía%20Bitácora%203.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 3</b><br />
                   1. Bitácora Energías <a href="Manuales/Bitacoras/Momento3/Energías%20para%20el%20futuro/Energía%20Bitácora%204.doc">Descargar</a><br />
                   2. Bitácora Energías <a href="Manuales/Bitacoras/Momento3/Energías%20para%20el%20futuro/Energía%20Bitácora%205.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 4</b><br />
                   Bitácora Energías <a href="Manuales/Bitacoras/Momento4/Energías%20para%20el%20futuro/Energía%20Bitácora%206.doc">Descargar</a><br />
                </fieldset> 
                        </div>

                <div id='oculto4' style='display:none;'>
                    <center><h1>Historia</h1></center>
                    <fieldset> 
                    <legend><b>1. DESCARGA Y DILIGENCIA LA BITÁCORA CORRESPONDIENTE</b></legend>
                    <b>• Momento pedagógico 1</b><br />
                   1. Bitácora Historia <a href="Manuales/Bitacoras/Momento1/Historia/Historia%20Bitácora%201.doc">Descargar</a><br />
                   2. Bitácora Historia <a href="Manuales/Bitacoras/Momento1/Historia/Historia%20Bitácora%202.doc">Descargar</a><br />
                   3. Bitácora Historia <a href="Manuales/Bitacoras/Momento1/Historia/Historia%20Bitácora%203.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 3</b><br />
                   1. Bitácora Historia <a href="Manuales/Bitacoras/Momento3/Historia/Historia%20Bitácora%204.doc">Descargar</a><br />
                   2. Bitácora Historia <a href="Manuales/Bitacoras/Momento3/Historia/Historia%20Bitácora%205.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 4</b><br />
                   Bitácora Historia <a href="Manuales/Bitacoras/Momento4/Historia/Historia%20Bitácora%206.doc">Descargar</a><br /><br />
                    <b>• Momento pedagógico 5</b><br />
                   Bitácora Historia <a href="Manuales/Bitacoras/Momento5/Historia/Historia%20Bitácora%207.doc">Descargar</a><br />
                </fieldset> 
                        </div>
                <!--Prueba -->
    <br />
                <fieldset> 
                    <legend><b>2. SELECCIONA EL TIPO DE EVIDENCIA</b></legend>
                     <asp:RadioButtonList runat="server" ID="rbtActividades">
                        <asp:ListItem Value="Lista de Asistencia">1. Lista de Asistencia</asp:ListItem>
                        <asp:ListItem Value="Formato de evaluación">2. Formato de evaluación</asp:ListItem>
                        <asp:ListItem Value="Fotos">3. Fotos</asp:ListItem>
                        <asp:ListItem Value="Bitácora">4. Bitácora</asp:ListItem>
                        <asp:ListItem Value="Otras evidencias">5. Otras evidencias</asp:ListItem>
                     </asp:RadioButtonList>
                     <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades" Display="Dynamic" ControlToValidate="rbtActividades" ValidationGroup="addEvidencia">
                     <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
                     </asp:RequiredFieldValidator>
                </fieldset> 
                    <br />

                
            <fieldset> 
                    <legend><b>3. CARGAR ARCHIVO</b></legend>
                    
                    <asp:FileUpload ID="trepador" runat="server" />
                    <p>Tamaño máximo: 4 MB</p>
            </fieldset>
    <br />
        
                    <footer >
                        <div style="text-align: center">
                            <asp:Button ID="Button1" runat="server" Text="Subir Evidencia" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
                           <asp:Button runat="server" Text="Regresar" OnClick="btnRegresar_click" ID="btnRegresar" CssClass="btn btn-primary" />
                        </div>
                    </footer>


        

       



          
                
  
     
    <fieldset>
     <legend>Listado de evidencias</legend>
        
      <asp:GridView ID="GridEvidencias" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  AutoGenerateColumns="false" Style="margin: 0 auto" 
                        GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombrearchivo" HeaderText="Nombre archivo">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tamano"  HeaderText="Tamaño" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="actividad" HeaderText="Tipo de evidencia">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                                <asp:BoundField DataField="fechacreado" HeaderText="Fecha subida">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombreguardado" HeaderText="Guardado" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="path" HeaderText="Path" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                            </asp:BoundField>


                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/down.png" Height="20px" Width="20px" OnClick="imgDescargar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
                                 </ItemTemplate> 

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
           
</asp:Content>

