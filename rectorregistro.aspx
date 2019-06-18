<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="rectorregistro.aspx.cs" Inherits="rectorregistro" %>

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
  
      <script type="text/javascript">

         function buscar() {
             //alert("Si este es");
             jQuery.fn.filterByText = function (textbox, selectSingleMatch) {
                 return this.each(function () {
                     var select = this;
                     var options = [];
                     $(select).find('option').each(function () {
                         options.push({ value: $(this).val(), text: $(this).text() });
                     });
                     $(select).data('options', options);
                     $(textbox).bind('change keyup', function () {
                         var options = $(select).empty().data('options');
                         var search = $(this).val().trim();
                         var regex = new RegExp(search, "gi");

                         $.each(options, function (i) {
                             var option = options[i];
                             if (option.text.match(regex) !== null) {
                                 $(select).append(
                                    $('<option>').text(option.text).val(option.value)
                                 );
                             }
                         });
                         if (selectSingleMatch === true && $(select).children().length === 1) {
                             $(select).children().get(0).selected = true;
                         }
                     });
                 });
             };

             $(function () {
                 $('#dropInstitucion').filterByText($('#textbox'), false);
                 $("#dropInstitucion option").click(function () {
                     alert(1);
                 });
             });

         }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Registro de rector para la IE</h2><br />
    <asp:Label id="lblCodDANE" runat="server" Visible="false"></asp:Label>
     <asp:Label id="lblCodRector" runat="server" Visible="false"></asp:Label>
<fieldset>
<legend>Agregar Usuario</legend>

<table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px; width:80%">
   
   
    <tr> 
        <td>
            Tipo Id.
        </td> 
        <td>
        <asp:DropDownList ID="dropTipoID" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="true">
                    </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RFVdropTipoID" runat="server" ErrorMessage="Seleccione el tipo de identificación"
            Text="*" Display="None" InitialValue="Seleccione" ControlToValidate="dropTipoID" ValidationGroup="addUsuario">
        </asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropTipoID"
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
        </td>
        <td>
           Identificación <span class="auto-style1">*</span>
        </td>
        <td>
             <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtIdentificacion" runat="server" ErrorMessage="Digite la identificación"
                Text="*" Display="None" ControlToValidate="txtIdentificacion"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtIdentificacion" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td> 
    </tr>
    
    <tr>  
        <td>
           Nombres <span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite su nombre"
                Text="*" Display="None" ControlToValidate="txtNombre"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtNombre" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>
        <td>
          Apellidos <span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtApellidos" runat="server" ErrorMessage="Digite sus apellidos"
                Text="*" Display="None" ControlToValidate="txtApellidos"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVtxtApellidos" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td>Genero</td>
        <td>
         <asp:DropDownList ID="dropGenero" runat="server" CssClass="TextBox" Style="max-width: 50px" Visible="true">
             <asp:ListItem>M</asp:ListItem><asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
         </td>
        <td>
            Fecha de nacimiento
        </td>
        <td>
            <asp:TextBox ID="txtFechaIniFiltro"  MaxLength="10" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajx:FilteredTextBoxExtender ID="filtro" runat="server" TargetControlID="txtFechaIniFiltro" FilterType="Custom, Numbers" ValidChars="-">
                             </ajx:FilteredTextBoxExtender>
                            <ajx:CalendarExtender ID="txtFechaIniFiltro_CalendarExtender" runat="server"
                                DefaultView="Days" Enabled="True" Format="dd-MM-yyyy"
                                TargetControlID="txtFechaIniFiltro">
                            </ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaIniFiltro" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                ControlToValidate="txtFechaIniFiltro" ValidationGroup="addUsuario"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                Style="color: #FF0000"></asp:RegularExpressionValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="REVtxtFechaIniFiltro"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td>
            Teléfono
        </td>
        <td>
           <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="200px" MaxLength="20"></asp:TextBox>
        </td> 
         <td>
            Celular
        </td>
        <td>
            <asp:TextBox ID="txtCelular" runat="server" CssClass="TextBox" Width="200px" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
       <td>
            E-mail 
        </td>
        <td >
            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="200px" MaxLength="100"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
    <td colspan="6" style="text-align:center">
        <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Rector"  ValidationGroup="addUsuario"
            CssClass="btn btn-success" OnClick="btnAgregarUsuario_Click" />
         <asp:Button ID="btnEditarUsuario" runat="server" Text="Editar Rector"  
            CssClass="btn btn-primary" OnClick="btnEditarUsuario_Click" />
    </td>
</tr>
   <tr>
       <td colspan="4">
           <br />
           <hr />
           <h2>Relacionar Rector con Institución</h2>
       </td>
   </tr>  
  <tr>
      <td>
          Identificación del rector
      </td>
      <td>
          <asp:TextBox ID="txtIDDocente" runat="server" CssClass="TextBox"  ></asp:TextBox>
      </td>
  </tr>
    <tr>
        <td>
            Institución
        </td>
        <td colspan="3">
       
                    <table>
                        <tr>
                            <td>
                                Filtrar
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="textbox" type="text" class="TextBox" style="width:200px" placeholder="Digita DANE o Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="dropInstitucion" ClientIDMode="Static" runat="server" CssClass="TextBox" ></asp:DropDownList><asp:Label ID="lblvalidador" runat="server" visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
              
        </td>
    </tr>
   
   <tr>
    <td colspan="6" style="text-align:center">
        <asp:Button ID="btnRelacionarRectorConInstitucion" runat="server" Text="Relacionar"  
            CssClass="btn btn-success" OnClick="btnRelacionarRectorConInstitucion_Click" />
    </td>
</tr>
   
</table>
</fieldset>
 
</asp:Content>

