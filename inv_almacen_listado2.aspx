<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="inv_almacen_listado2.aspx.cs" Inherits="inv_almacen_listado2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
     <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />

     <script type="text/javascript">
         $(document).ready(function () {
             cargarlistado();
             $('.modal').modal();
         });

         var codequipodetalle;
         var unidad;
         var baja;
         var table;
         //JQuerys

         function cargarDataTable() {
             table = $('#infotable').DataTable({
                 "language": {
                     "url": "dataTables.spanish.lang",
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
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
                         "sLast": "Último",
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

         function cargarlistado() {
             $("#infotable tbody").html("<tr><td colspan='13' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
             $.ajax({
                 type: 'POST',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/cargarlistado',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $("#infotable tbody").html(resp[1]);
                     }

                 }, complete: function () {
                     cargarDataTable();
                 }
             });
         }

         function abrirventanaeditar() {
             $('#EditarProducto').modal('open');
         }
         function verrecorrido(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/verrecorrido',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#verlistado').modal('open');
                         $("#infodetalle").html(resp[1]);
                         //buscarProductoCoordinadorAlmacen(resp[2]);
                         //buscarProductoCoordinadorTecnico(resp[2]);
                     }
                     else {
                         alert('Este producto se encuentra en la bodega principal');
                     }


                 }
             });
         }

         function buscarProductoCoordinadorTecnico(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarProductoCoordinadorTecnico',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#verlistado').modal('open');
                         $("#infodetalle2").html(resp[1]);
                         buscarProductoTecnicoCliente(resp[2]);
                     }

                 }
             });
         }

         function buscarProductoTecnicoCliente(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarProductoTecnicoCliente',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#verlistado').modal('open');
                         $("#infodetalle3").html(resp[1]);
                         buscarProductoClienteTecnico(resp[2]);
                     }

                 }
             });
         }

         function buscarProductoClienteTecnico(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarProductoClienteTecnico',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#verlistado').modal('open');
                         $("#infodetalle4").html(resp[1]);
                         buscarProductoTecnicoCoordinador(resp[2]);
                     }

                 }
             });
         }

         function buscarProductoTecnicoCoordinador(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarProductoTecnicoCoordinador',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#verlistado').modal('open');
                         $("#infodetalle5").html(resp[1]);
                         buscarProductoCoordinadorAlmacen(resp[2]);
                     }

                 }
             });
         }

         function buscarProductoCoordinadorAlmacen(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarProductoCoordinadorAlmacen',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#verlistado').modal('open');
                         $("#infodetalle6").html(resp[1]);
                     }

                 }
             });
         }

         function editarproducto(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             codequipodetalle = codigo;
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarproducto',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "encontro") {
                         $('#EditarProducto').modal('open');
                         $("#MainContent_txtSerial2").val(resp[1]);
                         $("#MainContent_txtCantidadActual").val(resp[2]);
                         unidad = resp[3];
                     }
                     else {
                         alert('A este producto no se le puede agregar mas de una cantidad');
                     }

                 }
             });
         }

         function btnEditar() {
             var jsondata = "{'codigo':'" + codequipodetalle + "', 'cantactual':'" + $("#MainContent_txtCantidadActual").val() + "', 'cantingresar':'" + $("#MainContent_txtCantidadIngresar").val() + "', 'codoperacion':'" + $("#MainContent_dropOperacion").val() + "', 'unidad':'" + unidad + "'}";
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/editarproducto',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "true") {
                         $('#EditarProducto').modal('close');
                         alert('Dato editado correctamente');
                         window.location.href = "inv_almacen_listado2.aspx";
                     }
                     else if (resp[0] === "false2") {
                         $('#EditarProducto').modal('close');
                         alert('Error al editar');
                     }
                     else if (resp[0] === "false") {
                         alert('La cantidad a ingresar debe ser menor a la cantidad actual');
                         $('#EditarProducto').modal('close');
                     }
                 }
             });
         }

         function dardebaja(codigo) {
             var jsondata = "{'codigo':'" + codigo + "'}";
             codequipodetalle = codigo;
             $.ajax({
                 type: 'POST',
                 data: jsondata,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 url: 'inv_almacen_listado2.aspx/buscarproductodebaja',
                 success: function (response) {
                     var resp = response.d.split("@");
                     if (resp[0] === "encontro") {
                         $('#dardebaja').modal('open');
                         $("#MainContent_txtSerialDeBaja").val(resp[1]);
                         baja = resp[2];
                     }
                     else {
                         alert('Error');
                     }

                 }
             });
         }

         function btndardebaja() {

             if (baja === "Dañado") {

                 if (confirm('¿Estás seguro en darle de baja a este producto?')) {
                     var jsondata = "{'codigo':'" + codequipodetalle + "', 'comentario':'" + $("#MainContent_txtComentario").val() + "'}";
                     $.ajax({
                         type: 'POST',
                         data: jsondata,
                         contentType: 'application/json; charset=utf-8',
                         dataType: 'JSON',
                         url: 'inv_almacen_listado2.aspx/dardebajaproducto',
                         success: function (response) {
                             var resp = response.d.split("@");
                             if (resp[0] === "true") {
                                 $('#dardebaja').modal('close');
                                 alert('Producto dado de baja correctamente');
                                 window.location.href = "inv_almacen_listado2.aspx";
                             }
                             else {
                                 $('#dardebaja').modal('close');
                                 alert('Este producto no se puede dar de baja.');
                                 $("#MainContent_txtComentario").val() = "";
                             }
                         }
                     });
                 }
             }
             else {
                 alert('Este producto no se puede dar de baja.');
                 $("#MainContent_txtComentario").val() = "";
             }
         }

         function eliminarpro(codigo) {

          
                 if (confirm('¿Estás seguro en eliminar este producto?')) {
                     var jsondata = "{'codigo':'" + codigo + "'}";
                     $.ajax({
                         type: 'POST',
                         data: jsondata,
                         contentType: 'application/json; charset=utf-8',
                         dataType: 'JSON',
                         url: 'inv_almacen_listado2.aspx/eliminarproducto',
                         success: function (response) {
                             var resp = response.d.split("@");
                             if (resp[0] === "true") {
                                 alert('Producto eliminado correctamente');
                                 window.location.href = "inv_almacen_listado2.aspx";
                             }
                             else {
                                 $('#dardebaja').modal('close');
                                 alert('Error al eliminar producto, ya fue entregado.');
                             }
                         }
                     });
                 }
            
         }
         

    </script>

     <style>
      .z-depth-4, .modal {
         box-shadow: 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12), 0 5px 5px -3px rgba(0, 0, 0, 0.3);
        }

      .modal {
      display: none;
      position: fixed;
      left: 0;
      right: 0;
      background-color: #fafafa;
      padding: 0;
      max-height: 70%;
      width: 70%;
      margin: auto;
      overflow-y: auto;
      border-radius: 2px;
      will-change: top, opacity;
    }

    @media only screen and (max-width: 992px) {
      .modal {
        width: 80%;
      }
    }

    .modal h1, .modal h2, .modal h3, .modal h4 {
      margin-top: 0;
    }

    .modal .modal-content {
      padding: 24px;
    }

    .modal .modal-close {
      cursor: pointer;
    }

    .modal .modal-footer {
      border-radius: 0 0 2px 2px;
      background-color: #fafafa;
      padding: 4px 6px;
      height: 56px;
      /*width: 100%;*/
    }

    .modal .modal-footer .btn, .modal .modal-footer .btn-large, .modal .modal-footer .btn-flat {
      float: right;
      margin: 6px 0;
    }

    .modal-overlay {
      position: fixed;
      z-index: 999;
      top: -100px;
      left: 0;
      bottom: 0;
      right: 0;
      height: 125%;
      width: 100%;
      background: #000;
      display: none;
      will-change: opacity;
    }

    .modal.modal-fixed-footer {
      padding: 0;
      height: 70%;
    }

    .modal.modal-fixed-footer .modal-content {
      position: absolute;
      height: calc(100% - 56px);
      max-height: 100%;
      width: 100%;
     
    }

    .modal.modal-fixed-footer .modal-footer {
      border-top: 1px solid rgba(0, 0, 0, 0.1);
      position: absolute;
      bottom: 0;
    }

    .modal.bottom-sheet {
      top: auto;
      bottom: -100%;
      margin: 0;
      width: 100%;
      max-height: 45%;
      border-radius: 0;
      will-change: bottom, opacity;
    }
    </style>

   
    <script src="js/jquerymaterialice.js"></script>
 
     <link rel="stylesheet" type="text/css" href="lightbox/jquery.lightbox-0.5.css"/>
    <script type="text/javascript" src="lightbox/jquery.lightbox-0.5.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('.zoom').lightBox({
                overlayBgColor: '#FFF',
                overlayOpacity: 0.8,
                containerResizeSpeed: 350,
                txtImage: 'Imagen',
                txtOf: 'de'
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>

     <br /><br /><br />
    <h2>Inventario</h2>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>


           <div id="inventario" >

               <table id="infotable" class="mGridTesoreria">
                   <thead>
                       <tr>
                           <th>Usuario</th>
                           <th>Cod. Familia</th>
                           <th>Familia</th>
                           <th>Cod. Producto</th>
                           <th>Producto</th>
                           <th>Serial/Nombre</th>
                           <th>Rotulación</th>
                           <th>Oficina</th>
                           <th>Cod. Barra</th>
                           <th>Descripción</th>
                           <th>Cantidad</th>
                           <th>Estado</th>
                           <th></th>
                           <th></th>
                           <th></th>
                           <th></th>
                           <th></th>
                           <th></th>
                       </tr>
                   </thead>
                   <tbody></tbody>
               </table>

              <%--  <asp:GridView ID="GridListProd" runat="server" CellPadding="4" DataKeyNames="codigo" AutoGenerateColumns="false" style="margin:0 auto; width:100%"
                    ForeColor="#333333" GridLines="None"  CssClass="mGridTesoreria"
                    onrowdatabound="GridListProd_RowDataBound" 
                   UseAccessibleHeader="true" ClientIDMode="Static">
                    <Columns>
                         <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>        
                            <ItemStyle Width="40px" HorizontalAlign="Center" />      
                         </asp:TemplateField> 
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="codigo" HeaderStyle-CssClass="ocultarcell" HeaderText="codmovcoordinador_almacen" ><ItemStyle CssClass="ocultarcell"  HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="codfamilia" HeaderText="Cod. Familia" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="familia" HeaderText="Familia" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>               
                        <asp:BoundField DataField="codclase" HeaderText="Cod. Clase" ><ItemStyle  HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="clase" HeaderText="Clase" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="codproducto" HeaderText="Cod. Producto" ><ItemStyle  HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="producto" HeaderText="Producto"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="serial" HeaderText="Serial/Nombre" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                        <asp:BoundField DataField="rotulo" HeaderText="Rotulación" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="codoficina" HeaderStyle-CssClass="ocultarcell" HeaderText="codoficina" ><ItemStyle CssClass="ocultarcell"  HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="oficina" HeaderText="Oficina" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                        <asp:BoundField DataField="codbarra" HeaderText="Cod. Barra" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField> 
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField> 
                        <asp:BoundField DataField="estado" HeaderText="Estado" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>   
                        <%--<asp:BoundField DataField="cantmetros" HeaderText="Cant. Metros" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="cantmetros_max" HeaderText="Cant. Metros Disponibles" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="fechainigarantia" HeaderText="Inicio de Garantia" DataFormatString="{0:d}" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>  
                        <asp:BoundField DataField="fechafingarantia" HeaderText="Fin de Garantia" DataFormatString="{0:d}" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>   
                        

                        <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="equipocodbarra.aspx?co=<%# Eval("codoficina") %>&cp=<%# Eval("codproducto") %>&r=<%# Eval("rotulo") %>&pag=nprod" ><img src="Imagenes/codbarra.png" width="20" title="Generar Código de Barra" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                         </asp:TemplateField> 

                         <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="inv_almacen_editpro.aspx?codequipodetalle=<%# Eval("codigo") %>" ><img src="Imagenes/edit.png" width="20" title="Editar Producto" /></a>
                                    <%--<asp:LinkButton ID="lnkEditar" runat="server" ToolTip="Editar Producto"><img src="Imagenes/edit.png" width="20" onclick="lnkEditar_Click" /></asp:LinkButton
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                         </asp:TemplateField> 

                       <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:void(0)" onclick="verrecorrido(<%# Eval("codigo") %>);"><img src="Imagenes/ojo.png" width="20" title="Ver recorrido de entrega" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                         </asp:TemplateField> 

                         <asp:TemplateField>
                                <ItemTemplate>
                                    <a class='zoom' href='Evidencias_Almacen/storealcaldiasoledad/<%# Eval("evidencia") %>'><img  src='Imagenes/img.png' width="20" alt='<%# Eval("evidencia") %>' title="Ver evidencia" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>

                         <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="inv_almacen_listado2_evi.aspx?codequipodetalle=<%# Eval("codigo") %>" ><img src="Imagenes/cloud-upload.png" width="20" title="Cargar evidencia del producto" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                         </asp:TemplateField> 
                        
                      <%--   <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:void(0)" onclick="dardebaja(<%# Eval("codigo") %>);"><img src="Imagenes/down_pro.png" width="20" title="Dar de Bajar" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                         </asp:TemplateField>   

                         <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:void(0)" onclick="eliminarpro(<%# Eval("codigo") %>);"><img src="Imagenes/icon-delete.png" width="20" title="Eliminar Producto" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                         </asp:TemplateField>  

                    </Columns>
            </asp:GridView>--%>
           </div>

           
              <!-- Modal Structure -->
              <div id="verlistado" class="modal">
                 <div class="modal-content">
                     <fieldset>
                         <legend>Recorrido del Producto</legend>

                         <table class="mGridTesoreria" id="infodetalle"></table>
                         <br />
                          <table class="mGridTesoreria" id="infodetalle2"></table>
                          <br />
                          <%--<table class="mGridTesoreria" id="infodetalle3"></table>
                          <br />
                          <table class="mGridTesoreria" id="infodetalle4"></table>
                           <br />
                          <table class="mGridTesoreria" id="infodetalle5"></table>
                           <br />--%>
                          <table class="mGridTesoreria" id="infodetalle6"></table>
            
                      </fieldset>
 
                </div>
                <div class="modal-footer">
                    <a href="javascript:void(0)" class="modal-action modal-close waves-effect waves-green btn btn-primary TextBox" >Cerrar</a>
                </div>
              </div>


             <div id="EditarProducto" class="modal">
                 <div class="modal-content">
                     <fieldset>
                         <legend>Editar Producto</legend>

                        <table>
                            <tr>
                                <td>Serial/Nombre</td>
                                <td><asp:TextBox ID="txtSerial2" runat="server" CssClass="TextBox" Enabled="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Cantidad actual</td>
                                <td><asp:TextBox ID="txtCantidadActual" runat="server" CssClass="TextBox" Enabled="false"></asp:TextBox></td>
                                <td>Cantidad a ingresar</td>
                                <td><asp:TextBox ID="txtCantidadIngresar" runat="server" CssClass="TextBox" ></asp:TextBox></td>
                                <td>Operación</td>
                                <td><asp:DropDownList ID="dropOperacion" runat="server" CssClass="TextBox">
                                    <asp:ListItem Value="s">Sumar</asp:ListItem>
                                    <asp:ListItem Value="r">Restar</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    Factura Proveedor
                                </td>
                                <td>
                                     <asp:TextBox ID="txtBusqFactura" runat="server" CssClass="TextBox" Width="200px" placeholder="Código de la Factura Compra - Proveedor"
                                         ontextchanged="btnBusqCodFactura_Click" AutoPostBack="True"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RFVtxtBusqFactura" runat="server" ErrorMessage="Digite el Código de la factura del Proveedor"
                                            Text="*" Display="None" ControlToValidate="txtBusqFactura" 
                                            ></asp:RequiredFieldValidator>
                                         <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVtxtBusqFactura"
                                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                        </ajx:ValidatorCalloutExtender>
                                        <ajx:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                            DelimiterCharacters="" Enabled="True" TargetControlID="txtBusqFactura" 
                                            CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem" 
                                            CompletionInterval="200" MinimumPrefixLength="2" ServiceMethod="GetListaFacturasxProveedor" ServicePath="WebAutoComplete.asmx" 
                                            UseContextKey="True">
                                        </ajx:AutoCompleteExtender>  
                                    <asp:Label ID="lblCodFacturaProoveedor" runat="server" Visible="false"></asp:Label> 
                                </td>
                            </tr>
                        </table>
            
                      </fieldset>
 
                </div>
                <div class="modal-footer">
                    <a href="#" onclick="btnEditar()" class="modal-action modal-close waves-effect waves-green btn btn-success TextBox">Editar</a>
                    <a href="javascript:void(0)" class="modal-action modal-close waves-effect waves-green btn btn-primary TextBox" >Cerrar</a>
                </div>
              </div>

            <%-- Dar de baja --%>

             <div id="dardebaja" class="modal">
                 <div class="modal-content">
                     <fieldset>
                         <legend>Dar de baja a Producto</legend>

                        <table align="center">
                            <tr>
                                <td>Serial/Nombre</td>
                                <td><asp:TextBox ID="txtSerialDeBaja" runat="server" CssClass="TextBox" Enabled="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    Comentario
                                </td>
                                <td>
                                    <asp:TextBox ID="txtComentario" runat="server" CssClass="TextBox" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
            
                      </fieldset>
 
                </div>
                <div class="modal-footer">
                    <a href="#" onclick="btndardebaja()" class="modal-action modal-close waves-effect waves-green btn btn-danger TextBox">Dar de baja</a>
                    <a href="javascript:void(0)" class="modal-action modal-close waves-effect waves-green btn btn-primary TextBox" >Cerrar</a>
                </div>
              </div>

        </ContentTemplate>
     </asp:UpdatePanel>
 
           
</asp:Content>

