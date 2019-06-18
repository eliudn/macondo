<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default-old.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HelpDesk Funtics</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        /* =====Login=====*/
        body[role="login"] {
            font-family: 'Roboto', sans-serif;
	        /*background: #045404;*/
            background-image:url('Imagenes/login/back.jpg');
	        background-size: cover;
            background-position: center center;
            background-repeat: no-repeat;
	        color: #EFEFEF;

        }
        [role="login"] .container {
	        margin-top: 100px
        }
        [role="login"] .btn-success {
	        background: #76B831;
	        border: 1px solid #679F2C;
	        float: right
        }
        [role="login"] label {
	        font-weight: normal;
	        color: #404040
        }
        .label{           
	        color: #404040;
        }
        .panel-heading {
	        padding: 5px 15px;
        }
        .form-inline {
	        margin: 5px
        }
        .panel-footer {
	        padding: 1px 15px;
	        color: #A0A0A0;
        }
        hr {
	        border: 0;
	        height: 1px;
	        /*background-image: linear-gradient(to right, rgba(0, 0, 0, 0), #FFF, rgba(0, 0, 0, 0));*/
            background-color:#D6D6D6;
	        margin: 5px
        }
        .profile-img {
	        margin: 0 auto 10px;
	        display: block;
            max-width:265px;
        }
        .panel {
            /*background-color: transparent;*/
        }
        .panel-default {
            opacity: .9;
            -webkit-box-shadow: 0px 7px 24px 1px rgba(0,0,0,0.45);
            -moz-box-shadow: 0px 7px 24px 1px rgba(0,0,0,0.45);
            box-shadow: 0px 7px 24px 1px rgba(0,0,0,0.45);
            /*background: transparent url('http://3rwebtech.com/bg-white.png') repeat scroll 0% 0%;*/
        }
        /** TextBox **/
        /*.TextBox {
            outline: 0 none;
            font-size: 15px;
            border: 1px #aaaaaa solid;
            border-radius: 4px;
            padding: 2px;
            font-family: inherit;
            margin-right: 0px;
        }

            .TextBox:focus {
                -webkit-box-shadow: 0px 0px 5px #0C87DA;
                -moz-box-shadow: 0px 0px 5px #0C87DA;
                box-shadow: 0px 0px 5px #0C87DA;
            }*/
    </style>
     <link href="~/Imagenes/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
</head>
<body role="login">
    <form id="form1" runat="server">
    <div class="container" style="margin-top:70px">
<div class="row">
  <div class="col-sm-6 col-md-4 col-sm-offset-3 col-md-offset-4">
    <div class="panel panel-default">
    
      <div class="panel-body">
        <form role="form" action="#" method="POST">
          <fieldset>
            <div class="row">
              <div class="center-block"> <img class="profile-img" src="Imagenes/login/inicio.png" class="img-responsive" alt=""> </div>
              <hr>
            </div>
            <div class="row">
                <asp:Panel ID="PanelUserPass" runat="server">
              <div class="col-sm-12 col-md-10  col-md-offset-1 ">
                <div class="form-group">
                <label>Usuario:</label>
                  <div class="input-group"> <span class="input-group-addon"> <i class="glyphicon glyphicon-user"></i> </span>
                      <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" required autofocus placeholder="Usuario"></asp:TextBox>
<%--                    <input class="form-control" placeholder="Usuario" name="loginname" type="text" autofocus>--%>
                  </div>
                </div>
                <div class="form-group">
                 <label>Contraseña:</label>
                  <div class="input-group"> <span class="input-group-addon"> <i class="glyphicon glyphicon-lock"></i> </span>
                      <asp:TextBox ID="txtPass" placeholder="Contraseña" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
<%--                    <input class="form-control" placeholder="Contraseña" name="password" type="password" value="">--%>
                  </div>
                </div>
               
                <div class="form-group">
                    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="label"></asp:Label>
                    <%--<label><input type="checkbox">Keep me Logged in </label> --%>
                    <asp:Button ID="btnEntrar" runat="server" Text="Iniciar Sesión" OnClick="btnEntrar_Click" CssClass="btn btn-success" />
                    <%--<input type="submit" class="btn btn-success" value="Entrar">--%>
                </div>
               
              </div>
                    </asp:Panel>
                <asp:Panel ID="PanelRoles" runat="server" Visible="false">
                    <br />
                    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
                    <div class="form-group">
                       <div class="input-group">
                           <div style="text-align:center;margin:0 auto">
                                     <label for="dropRoles">Seleccione:</label>
                           <asp:DropDownList ID="dropRoles" style="color:black" name="dropRoles" runat="server" CssClass="TextBox"></asp:DropDownList>
                            <a href="#" class="tooltip" data-tooltip="El rol que elijas ahora, sera el preferido lo podras cambiar dentro de la aplicación.">
                                <img src="Imagenes/help.png" width="20px" /></a>
                           </div>
                        
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnElegirRol" Text="Seguir" runat="server" CssClass="btn btn-success" OnClick="btnElegirRol_Click" />

                    </div>

                </asp:Panel>
            </div>
           
          </fieldset>
        </form>
    
      </div>
    </div>
  </div>
</div>
    </form>
</body>
</html>
