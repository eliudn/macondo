<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunoevidenciass007.aspx.cs" Inherits="estraunoevidenciass007" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

      <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

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

     <script type="text/javascript">
        $(document).ready(function () {
            cargarDataTable();
        });

        function cargarDataTable() {
            $('#GridEvidencias').DataTable({
                "language": {
                    "url": "dataTables.spanish.lang",
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "NingÃºn dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Ãšltimo",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                }
            });

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <asp:Label Visible="false" runat="server" ID="lblCodUsuario"></asp:Label>

    <div id="mensaje" runat="server"></div><br /><br />
    <h2 >Evaluación de Asesorias </h2>
    <%--<div style="float:right;margin-top:-30px;"><asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" /></div>--%>
    <br />

    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMomento" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblSesion" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblActividad" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblEstrategia" runat="server" Visible="False"></asp:Label>

<asp:Panel runat="server" ID="PanelMostrarEvidencias" Visible="true">

     <fieldset>
                <legend>Actividades</legend>
                <asp:Label ID="lblEncabezados" runat="server" Visible="true" ></asp:Label>
         <asp:Panel runat="server" ID="PanelMomento0" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtActividades">
                    <asp:ListItem>Registro de asesoría</asp:ListItem>
                </asp:RadioButtonList>
         </asp:Panel>

        <%--  <asp:Panel runat="server" ID="PanelMomento1" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtMomento1">
                    <asp:ListItem Value="1">1. Convocatoria</asp:ListItem>
                    <asp:ListItem Value="2">2. Kit de materiales pedagógicos</asp:ListItem>
                    <asp:ListItem Value="3">3. Guías de investigatigación propuesta por Ciclón</asp:ListItem>
                    <asp:ListItem Value="5">5. Asistencia a eventos</asp:ListItem>
                    <asp:ListItem Value="6">6. Evaluación eventos de formación</asp:ListItem>
                </asp:RadioButtonList>
         </asp:Panel>--%>

       <%--   <asp:Panel runat="server" ID="PanelMomento2" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtMomento2">
                    <asp:ListItem Value="1">1. Proyectos organziados por línea de investigación</asp:ListItem>
                    <asp:ListItem Value="2">2. Líneas de investigación</asp:ListItem>
                </asp:RadioButtonList>
         </asp:Panel>--%>
         
        <%--  <asp:Panel runat="server" ID="PanelMomento3" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtMomento3">
                    <asp:ListItem Value="1">1. Asistencia de eventos</asp:ListItem>
                  <asp:ListItem Value="2">2. Diseño de las trayectorias de indagación y presupuesto</asp:ListItem>

                </asp:RadioButtonList>
         </asp:Panel>--%>

         <%-- <asp:Panel runat="server" ID="PanelMomento4" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtMomento4">
                    <asp:ListItem Value="1">1. Asistencia de eventos</asp:ListItem>

                </asp:RadioButtonList>
         </asp:Panel>--%>

        <%--  <asp:Panel runat="server" ID="PanelMomento5" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtMomento5">
                      <asp:ListItem Value="1">1. Espacios de apropiación municipales</asp:ListItem>
                      <asp:ListItem Value="2">2. Espacios de apropiación departamentales</asp:ListItem>
                      <asp:ListItem Value="3">3. Espacios de apropiación regionales</asp:ListItem>
                      <asp:ListItem Value="4">4. Espacios de apropiación nacionales</asp:ListItem>
                      <asp:ListItem Value="5">5. Espacios de apropiación internacionales</asp:ListItem>

                </asp:RadioButtonList>
         </asp:Panel>--%>

                            
         <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades" Display="Dynamic" ControlToValidate="rbtActividades" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
          <%-- <asp:RequiredFieldValidator runat="server" ID="rbtValideMomento1" Display="Dynamic" ControlToValidate="rbtMomento1" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator runat="server" ID="rbtValideMomento2" Display="Dynamic" ControlToValidate="rbtMomento2" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator runat="server" ID="rbtValideMomento3_G001" Display="Dynamic" ControlToValidate="rbtMomento3" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator runat="server" ID="rbtValideMomento4_G001" Display="Dynamic" ControlToValidate="rbtMomento4" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator runat="server" ID="rbtValideMomento5" Display="Dynamic" ControlToValidate="rbtMomento5" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>--%>
         
         </fieldset>

  

 
            <fieldset>
                <legend>Subir Archivo</legend>
                <asp:FileUpload ID="trepador" runat="server" />
                <asp:Button ID="btnActualizarDatosTutoria" runat="server" Text="Cargar" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
                <br />Tamaño máximo: 4 MB
                    
            </fieldset>

</asp:Panel>

 <fieldset>
     <legend>Listado de evidencias</legend>
      <asp:GridView ID="GridEvidencias" runat="server" CellPadding="4" DataKeyNames="codigo" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
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
                             <asp:BoundField DataField="estrategia" HeaderText="Estrategia" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="momento" HeaderText="Momento" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sesion" HeaderText="Sesión" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="actividad" HeaderText="Actividad">
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

