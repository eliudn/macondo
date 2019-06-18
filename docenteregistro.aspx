<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="docenteregistro.aspx.cs" Inherits="docenteregistro" %>

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

             $(function () {
                 $('#dropDocente').filterByText($('#textboxDoc'), false);
                 $("#dropDocente option").click(function () {
                     alert(1);
                 });
             });
         }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Registro de Docente</h2><br />
<fieldset>
<legend>Agregar Usuario</legend>

<table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
   
   
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
            Fecha de nacimiento<span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtFechaIniFiltro"  MaxLength="10" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajx:CalendarExtender ID="txtFechaIniFiltro_CalendarExtender" runat="server" 
                            Enabled="True" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" 
                            TargetControlID="txtFechaIniFiltro">
                        </ajx:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RFVtxtFechaIniFiltro" runat="server" Display="None" ErrorMessage="Digite la Fecha de Nacimiento" 
                            ControlToValidate="txtFechaIniFiltro" Text="*" ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVtxtFechaIniFiltro"
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
           <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="200px" ></asp:TextBox>
        </td> 
      <td>Dirección</td>
        <td>
             <asp:TextBox ID="txtDireccion" runat="server" CssClass="TextBox" Width="200px" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Email</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="200px" ></asp:TextBox>
        </td>
    </tr>
   
   <tr>
       <td colspan="4">
           <br />
           <hr />
       </td>
   </tr>  
    <tr>
        <td>
            DANE de la Sede
        </td>
        <td colspan="3">
       
                  <asp:TextBox runat="server" ID="txtDane" CssClass="TextBox" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RFVtxtDane" runat="server" ErrorMessage="Digite El código DANE de la sede"
                Text="*" Display="None" ControlToValidate="txtDane"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVtxtDane" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
              
        </td>
    </tr>
    <tr>
        <td>Año lectivo</td>
        <td>
            <asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"></asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td colspan="6" style="text-align:center">
        <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Docente"  ValidationGroup="addUsuario"
            CssClass="btn btn-success" OnClick="btnAgregarUsuario_Click" />
    </td>
</tr>
   
</table>
</fieldset>
 
</asp:Content>

