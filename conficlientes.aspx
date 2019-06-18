<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="conficlientes.aspx.cs" Inherits="conficlientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

        .auto-style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Agregar Clientes</h2>
    <br />
    <fieldset>
            <legend>Datos del cliente - Campos Obligatorios*</legend>

            <table cellpadding="8" align="center">
                <tr>
                    <td class="primeracolumna">Nit o Dane<span class="auto-style1">*</span>
                    </td>
                    <td colspan="3" style="text-align:center">
                        <asp:TextBox ID="txtId" placeholder="900837624 (sin puntos)" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
                           <ajx:FilteredTextBoxExtender ID="txtId_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtId" FilterType="Custom, Numbers" ValidChars="">
                            </ajx:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RFVtxtId" runat="server" ErrorMessage="Digite Nit Del Cliente"
                            Text="*" Display="None" ControlToValidate="txtId" ValidationGroup="add">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtId"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="primeracolumna">Nombre o Razon Social<span class="auto-style1">*</span>
                    </td>
                    <td colspan="3" style="text-align:center">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="400px" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite Nombre Del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombre" ValidationGroup="add">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombre"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
           
                    </tr>
                <tr>
                    <td class="primeracolumna">Apellido
                    </td>
                    <td colspan="3" style="text-align:center">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width="400px" MaxLength="50"></asp:TextBox>
                    </td>
                 </tr>
                <tr>
                    <td>Dirección:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>

                    </td>
                    <td>Telefono:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" placeholder="micorreo@gmail.com" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVtxtEmail" runat="server" ErrorMessage="Email Incorrecto" Display="None"
                            ControlToValidate="txtEmail" ValidationGroup="add"
                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Style="color: #FF0000"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21"
                            runat="server" Enabled="True" TargetControlID="REVtxtEmail"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Celular:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelularContacto" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="primeracolumna">Tipo<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoCliente" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropTipoCliente" runat="server" ErrorMessage="Seleccione el tipo cliente" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropTipoCliente" ValidationGroup="add">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVdropTipoCliente"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                        <asp:ImageButton ID="imgTipoCliente" runat="server" ToolTip="Agregar Tipo Cliente" CommandName="Select" ImageUrl="~/Imagenes/add.png" Height="20px" Width="20px" style="vertical-align:middle"  OnClick="imgTipoCliente_Click"/>
                    </td>
                    <td class="primeracolumna">Municipio<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipio" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Selecciones el municipio Del Cliente"
                            Text="*" Display="None" ControlToValidate="dropMunicipio" ValidationGroup="add" InitialValue="Seleccione">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align:center">
                        <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" CssClass="btn btn-success" OnClick="btnAgregarCliente_Click" ValidationGroup="add" />
                    </td>
                </tr>
            </table>
        </fieldset>

   
      <asp:Button ID="btnShowTipoCliente" runat="server" style="display:none"/>
<ajx:modalpopupextender id="PanelAgregar_TipoCliente_Modalpopupextender" runat="server" enabled="True"
    targetcontrolid="btnShowTipoCliente" popupcontrolid="PanelAgregar_TipoCliente" cancelcontrolid="btnCerrar_TipoCliente"
    backgroundcssclass="modalBackground">
</ajx:modalpopupextender>
    <asp:Panel ID="PanelAgregar_TipoCliente" runat="server" CssClass="modalPopup">
            <header class="headerpopup">        
                <div style="float:left;margin-right:15px" >
                    Nuevo Tipo de Cliente
                </div>
                <div style="float:right;">
                    <asp:Label ID="btnCerrar_TipoCliente" runat="server" Text="Cerrar" CssClass="botones" ></asp:Label>
                </div>
            </header>
            <section class="sectionpopup">
                <fieldset>
                    <legend>Agregar Nuevo Tipo de Cliente al Sistema</legend>  
                    <table align="center">
                        <tr>
                            <td>
                                Nombre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoCliente" runat="server" CssClass="TextBox" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVtxtTipoCliente" runat="server" Display="None" ErrorMessage="Digite tipo de Cliente" 
                                    ControlToValidate="txtTipoCliente" Text="*" ValidationGroup="AgregarTipoProducto"></asp:RequiredFieldValidator>
                                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RFVtxtTipoCliente"
                                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                </ajx:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </section>
            <footer class="footerpopup">
                <div style="text-align:center"><asp:Button ID="btnAgregarNewTipoCliente" runat="server" Text="Guardar" ValidationGroup="AgregarTipoCliente" CssClass="botones" OnClick="btnAgregarNewTipoCliente_Click"/></div>
            </footer>
    </asp:Panel>


</asp:Content>

