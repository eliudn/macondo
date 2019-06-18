<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="miperfil.aspx.cs" Inherits="miperfil" MaintainScrollPositionOnPostback="true" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>


    <div id="mensaje" runat="server"></div><br /><br />
    <h2 style="text-decoration: underline;">Mi Perfil</h2>
    <br />
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Panel ID="PanelUsuario" runat="server">
        <fieldset>
            <legend>Imagen de Usuario</legend>
            <asp:Label ID="lblCodImgPerfil" runat="server" Visible="False"></asp:Label>
            <table class="cajafiltroCentrado" align="center" width="150px">
                <tr>
                    <td style="text-align: center">
                        <asp:Image ID="imgPerfil" runat="server" Height="140px" /></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblMensajeFirma" runat="server"></asp:Label>
                        <asp:Button ID="btnSubirFirmaPop" runat="server" Text="Subir Imagen" CssClass="botones" OnClick="btnSubirFirmaPop_Click" />

                    </td>
                </tr>
            </table>
        </fieldset>
        <asp:Panel ID="PanelRoles" runat="server" Visible="false">
            <table class="cajafiltroCentrado">
                <tr>
                    <td>
                        Cambiar Rol:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblSeleccionar" runat="server" RepeatDirection="Horizontal" >
                         </asp:RadioButtonList>
                    </td>
                    <td>
                        Preferido?
                    </td>
                    <td>
                        <asp:CheckBox ID="cbPreferido" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btnCambiarRol" runat="server" CssClass="btn btn-primary" Text="Cambiar" OnClick="btnCambiarRol_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <fieldset>
            <legend>Datos de Usuario</legend>
            <asp:Label ID="lblCodUsuario" runat="server" Visible="False"></asp:Label>
            <table align="center" class="cajausuario" cellpadding="4">
                <tr>
                    <td>Usuario:
                    </td>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server" class="textos2"></asp:Label>

                    </td>
                    <td>Contraseña:
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkReestablecerContra" runat="server"
                            OnClick="lnkReestablecerContra_Click">Reestablecer Contraseña</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </fieldset>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelNuevaContra" runat="server" Visible="false">
                    <fieldset>
                        <legend>Cambio de Contraseña</legend>
                        <table style="border-color: Red" align="center">
                            <tr>
                                <td>Contraseña Actual:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContraActual" runat="server" CssClass="TextBox" AUTOCOMPLETE="off" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtContraActual" runat="server" ErrorMessage="Digite su contraseña actual"
                                        Text="*" Display="None" ControlToValidate="txtContraActual"
                                        ValidationGroup="ActualizarContra"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" runat="server" Enabled="True" TargetControlID="RFVtxtContraActual"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>Nueva Contraseña
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNuevaContra" runat="server" CssClass="TextBox" AUTOCOMPLETE="off" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtNuevaContra" runat="server" ErrorMessage="Digite su nueva contraseña"
                                        Text="*" Display="None" ControlToValidate="txtNuevaContra"
                                        ValidationGroup="ActualizarContra"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" runat="server" Enabled="True" TargetControlID="RFVtxtNuevaContra"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>Repita Nueva Contraseña
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNuevaContra2" runat="server" CssClass="TextBox" AUTOCOMPLETE="off" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtNuevaContra2" runat="server" ErrorMessage="Digite su nueva contraseña"
                                        Text="*" Display="None" ControlToValidate="txtNuevaContra2"
                                        ValidationGroup="ActualizarContra"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" runat="server" Enabled="True" TargetControlID="RFVtxtNuevaContra2"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Label ID="lblerrorcontra" runat="server" Text="Contraseñas No Coinciden"
                                        Style="font-weight: 700; color: #FF0000" Visible="false"></asp:Label><br />
                                    <asp:Button ID="btnGuardarcontra" runat="server" Text="Guardar"
                                        CssClass="botones" OnClick="btnGuardarcontra_Click" />
                                    <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" CssClass="botones"
                                        OnClick="btnCancelar2_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkReestablecerContra" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnGuardarcontra" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:Panel ID="PanelOtro" runat="server">
        <fieldset>
            <legend>Edición de Usuario</legend>
            <table cellpadding="4" align="center">
                <tr>

                    <td class="primeracolumna">Identificación <span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtIdentificacion" runat="server" ErrorMessage="Digite La Identificación"
                            Text="*" Display="None" ControlToValidate="txtIdentificacion"
                            ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtIdentificacion"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td class="primeracolumna">Email<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="233px" MaxLength="100"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RFVtxtEmail" runat="server" ErrorMessage="Digite Su email"
                            Text="*" Display="None" ControlToValidate="txtEmail"
                            ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtEmail"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="primeracolumna">Primer Nombre <span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="170px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite su nombre"
                            Text="*" Display="None" ControlToValidate="txtNombre"
                            ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtNombre"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Segundo Nombre
                    </td>
                    <td>
                        <asp:TextBox ID="txtSNombre" runat="server" CssClass="TextBox" Width="170px" MaxLength="50"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="primeracolumna">Primer  Apellido <span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidos" runat="server" CssClass="TextBox" Width="170px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtApellidos" runat="server" ErrorMessage="Digite sus apellidos"
                            Text="*" Display="None" ControlToValidate="txtApellidos"
                            ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVtxtApellidos"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Segundo Apellido
                    </td>
                    <td>
                        <asp:TextBox ID="txtSApellido" runat="server" CssClass="TextBox" Width="170px" MaxLength="50"></asp:TextBox>

                    </td>
                </tr>
                <tr>

                    <td>Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>Celular
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="TextBox" Width="233px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center">
                        <asp:Button ID="btnEditarUsuario" runat="server" Text="Guardar Cambios" ValidationGroup="addUsuario"
                            CssClass="btn btn-success" OnClick="btnEditarUsuario_Click" />
                    </td>
                </tr>

            </table>
        </fieldset>
    </asp:Panel>


    <ajx:ModalPopupExtender ID="PanelEdicion_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnSubirFirmaPop" PopupControlID="PanelEdicion" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEdicion" runat="server" CssClass="modalPopup">
        <header class="headerpopup">
            <div style="float: left; margin-right: 15px" id="tituloPopup">
                Subir Imagen
            </div>
            <div style="float: right;">
                <asp:Label ID="btnCancelar" runat="server" Text="Cerrar" CssClass="botones"></asp:Label>
            </div>
        </header>
        <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>
                <asp:FileUpload ID="trepador" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnActualizarDatosTutoria" runat="server" Text="Subir Imagen" CssClass="botones" ValidationGroup="Editar" OnClick="btnActualizarDatosTutoria_Click" />
            </div>
        </footer>
    </asp:Panel>


</asp:Content>

