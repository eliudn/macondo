<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultviejo.aspx.cs" Inherits="Defaultviejo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />
    <%--<link href="~/Imagenes/favicon.ico" rel="shortcut icon" type="image/x-icon" />--%>
    <title>Inicio de Sesion - HelpDesk</title>
    <style>
        .TextBox {
            outline: 0 none;
            font-size: 15px;
            border: 1px #aaaaaa solid;
            border-radius: 4px;
            padding: 2px;
            font-family: inherit;
            margin-right: 0px;
        }
        ::-webkit-input-placeholder {
   text-align: center;
}

:-moz-placeholder { /* Firefox 18- */
   text-align: center;  
}

::-moz-placeholder {  /* Firefox 19+ */
   text-align: center;  
}

:-ms-input-placeholder {  
   text-align: center; 
}

            .TextBox:focus {
                -webkit-box-shadow: 0px 0px 5px #0C87DA;
                -moz-box-shadow: 0px 0px 5px #0C87DA;
                box-shadow: 0px 0px 5px #0C87DA;
            }

        a.tooltip {
            position: relative;
        }

            a.tooltip::before {
                content: attr(data-tooltip);
                font-size: 12px;
                position: absolute;
                z-index: 999;
                white-space: nowrap;
                bottom: 9999px;
                left: 0;
                background: #000;
                color: #e0e0e0;
                padding: 0px 7px;
                line-height: 24px;
                height: 24px;
                opacity: 0;
            }

            a.tooltip:hover::before {
                opacity: 1;
                top: 22px;
            }

            a.tooltip:hover::after {
                content: "";
                opacity: 1;
                width: 0;
                height: 0;
                border-left: 5px solid transparent;
                border-right: 5px solid transparent;
                border-bottom: 5px solid black;
                z-index: 999;
                position: absolute;
                white-space: nowrap;
                top: 17px;
                left: 0px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mensaje" runat="server"></div>
        <div class="tablanube">
            <div class="azul1">
                <center><img src="Imagenes/login/inicio.png" alt="logoame" style="padding-top:5px; height: 56px; width: 250px;"/></center>
                 <asp:Panel ID="PanelUserPass" runat="server">
                 <table align="center" cellpadding="4">
                    <tr>
                     
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" required CssClass="campodetexto" placeholder="Usuario"></asp:TextBox>
                         
                        </td>
                        <td>
                            <img src="Imagenes/login/img-05.png" width="25px" height="25px" alt="User" />
                        </td>
                    </tr>
                    <tr>
                         <td>

                            <asp:TextBox ID="txtPass" placeholder="Contraseña" runat="server" CssClass="campodetexto"
                                TextMode="Password" required></asp:TextBox>
                       
                        </td>
                        <td>
                            <img src="Imagenes/login/img-04.png" width="25px" height="25px" alt="Pass" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div class="mensaje">
                                <asp:Label ID="lblMensaje" runat="server" Text="Usuario No Existe" Visible="false"></asp:Label>
                            </div>

                            <asp:Button ID="btnEntrar" runat="server" Text="Iniciar Sesión" OnClick="btnEntrar_Click"
                                CssClass="boton" />
                        </td>
                    </tr>
                </table>
                     </asp:Panel>
                
                <asp:Panel ID="PanelRoles" runat="server" Visible="false">
                    <br />
                    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
                    <table align="center" cellpadding="4">
                        <tr>
                            <td>Seleccione
                            </td>
                            <td>
                                <asp:DropDownList ID="dropRoles" runat="server" CssClass="TextBox"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnElegirRol" Text="Seguir" runat="server" CssClass="boton" OnClick="btnElegirRol_Click" />
                            </td>
                            <td>
                                <a href="#" class="tooltip" data-tooltip="El rol que elijas ahora, sera el preferido lo podras cambiar dentro de la aplicación.">
                                    <img src="Imagenes/help.png" width="20px" /></a>

                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
