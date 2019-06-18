<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="procuadrilla.aspx.cs" Inherits="procuadrilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script language="javascript" type="text/javascript">
        function clickClient() {
            alert("Está seguro en eliminar este Coordinador?, Si lo hace se eliminarán el Proyecto y los Técnicos que lo relaciona");
        }
    </script>

    <style>
        .gridBoletin td{
            padding :8px 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Cuadrillas de trabajo.</h2>
        <br />
     <table cellpadding="4" align="center">
        <tr>
            <td>Seleccione Proyecto:
            </td>
            <td>
                <asp:DropDownList ID="dropProyecto" runat="server" CssClass="TextBox"
                    Width="235px">
                </asp:DropDownList>
            
            </td>
            <td>
                <asp:Button ID="btnSeleccioneProyecto" runat="server" Text="Seleccionar"
                    CssClass="botones"  OnClick="btnSeleccioneProyecto_Click" />
            </td>
        </tr>
    </table>
    <div style="margin:0 auto;text-align:center">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Visible="false" CssClass="btn btn btn-success" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnEditarCuadrilla" runat="server" Text="Editar Cuadrilla" CssClass="btn btn-primary" OnClick="btnEditarCuadrilla_Click" />
        <asp:Button ID="btnEliminarCoordinador" runat="server" Text="Eliminar Coordinador" CssClass="btn btn-danger" OnClick="btnEliminarCoordinador_Click" />
    </div>
    <div style="margin: 0 auto; text-align: center;">
        <center>
        <asp:Label ID="lblImpresion" runat="server" ></asp:Label>
       </center>
    </div>

     <ajx:ModalPopupExtender ID="PanelCoordinadorAdd_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnAgregar" PopupControlID="PanelCoordinadorAdd" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelCoordinadorAdd" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Agregar Cuadrilla</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
            <tr>
                <td>Proyecto:
                </td>
                <td colspan="3">
                  <asp:DropDownList ID="dropProyectoAdd" runat="server" CssClass="TextBox"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropProyectoAdd" runat="server" ErrorMessage="Debe seleccionar un proyecto" InitialValue="Seleccione"
                        Text="*" Display="None" ControlToValidate="dropProyectoAdd" ValidationGroup="addDocumento">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="RFVdropProyectoAdd"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
                <tr>
                    <td>
                        Coordinador:
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="dropCoordinadorAdd" runat="server" CssClass="TextBox"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RFVdropCoordinadorAdd" runat="server" ErrorMessage="Seleccione el Coordinador" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropCoordinadorAdd" ValidationGroup="addDocumento">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" Enabled="True" TargetControlID="RFVdropCoordinadorAdd"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center">
                        Tecnicos:
                    </td>
                  
                </tr>
                <tr>
                      <td  colspan="4" style="text-align:center">
                           <asp:CheckBoxList ID="cblTecnicos" runat="server" RepeatColumns="5" CssClass="TextBox">
                            </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddCuadrilla" runat="server" CssClass="btn btn-success" ValidationGroup="addDocumento" Text="Agregar Cuadrilla" OnClick="btnAddCuadrilla_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>


    <!-- Editar Cuadrilla -->

     <ajx:ModalPopupExtender ID="PanelCoordinadorEditar_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnEditarCuadrilla" PopupControlID="PanelCoordinadorEditar" CancelControlID="btnCancelar2"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelCoordinadorEditar" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Editar Cuadrilla</legend>
             <asp:Label ID="lblcodProyecto" runat="server" visible="true"></asp:Label>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
            <tr>
                <td>Proyecto:
                </td>
                <td colspan="3">
                  <asp:DropDownList ID="dropProyectoEditar" runat="server" CssClass="TextBox" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropProyectoEditar" runat="server" ErrorMessage="Debe seleccionar un proyecto" InitialValue="Seleccione"
                        Text="*" Display="None" ControlToValidate="dropProyectoEditar" ValidationGroup="EditDocumento">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropProyectoEditar"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
                <tr>
                    <td>
                        Coordinador:
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="dropCoordinadorEditar" runat="server" CssClass="TextBox" OnSelectedIndexChanged="dropCoordEditar_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RFVdropCoordinadorEditar" runat="server" ErrorMessage="Seleccione el Coordinador" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropCoordinadorEditar" ValidationGroup="EditDocumento">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropCoordinadorEditar"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center">
                        Tecnicos:
                    </td>
                  
                </tr>
                <tr>
                      <td  colspan="4" style="text-align:center">
                          <asp:Label ID="lblcadena" runat="server" Visible="true"></asp:Label>
                           <asp:CheckBoxList ID="cblTecnicosEditar" runat="server" RepeatColumns="5" CssClass="TextBox">
                            </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnEditarCuadrilla2" runat="server" CssClass="btn btn-success" ValidationGroup="EditarDocumento" Text="Editar Cuadrilla" OnClick="btnEditarCuadrilla2_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar2" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

     <!-- Eliminar Coordinador -->

     <ajx:ModalPopupExtender ID="PanelCoordinadorEliminar_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnEliminarCoordinador" PopupControlID="PanelCoordinadorEliminar" CancelControlID="btnCancelar3"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelCoordinadorEliminar" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Eliminar Coordinador</legend>

            <table cellpadding="4" align="center" class="cajafiltroCentrado">
            <tr>
                <td>Proyecto:
                </td>
                <td colspan="3">
                  <asp:DropDownList ID="dropProyectoEliminar" runat="server" CssClass="TextBox" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropProyectoEliminar" runat="server" ErrorMessage="Debe seleccionar un proyecto" InitialValue="Seleccione"
                        Text="*" Display="None" ControlToValidate="dropProyectoEliminar" ValidationGroup="EliminarDocumento">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVdropProyectoEditar"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
                <tr>
                    <td>
                        Coordinador:
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="dropCoordinadorEliminar" runat="server" CssClass="TextBox" ></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RFVdropCoordinadorEliminar" runat="server" ErrorMessage="Seleccione el Coordinador" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropCoordinadorEliminar" ValidationGroup="EliminarDocumento">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVdropCoordinadorEditar"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnEliminarCoordinador2" runat="server" CssClass="btn btn-danger" ValidationGroup="EliminarDocumento" Text="Eliminar Coordinador" OnClick="btnEliminarCoordinador2_Click"  />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar3" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

</asp:Content>

