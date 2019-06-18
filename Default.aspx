<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
     <link href="css/siep.css" rel="stylesheet" type="text/css" />
     <link href="css/materialize.css" rel="stylesheet" type="text/css" />
     <link href="css/icon.css" rel="stylesheet" type="text/css" />
    <!--Libreria de JQuery-->
    <script type="text/javascript" src="js/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="js/materialize.min.js"></script> 
     <script type="text/javascript" src="js/enterkey.js"></script>   
    <title>Inicio de Sesión</title>
</head>
<body role="login">
<div class="center-div">
    <div class="panel-login"  >    
             <!--<div id="mensaje" ></div>-->
            <div class="row">
                <div class="col s5" style="text-align:center;"><br /><br /><br /><br />
                    <img src="images/logo.png"  style="margin-top:5%; max-width:190px;width:100%;" />
                 </div>
                  <div class="col s7">
                            <div id="fmlogin" class="row" style="margin-top: 20px;">
                                  <div class="input-field col s12">
                                      <input  name="txtUsuario" type="text" id="txtUsuario" />
                                      <label  for="txtUsuario" >Usuario</label>
                                 </div> 
                                <div class="input-field col s12 ">
                                    <input  name="txtPass" type="password" id="txtPass" />
                                    <label for="txtPass" >Contraseña</label>
                                </div>
                                <div class="col s12">
                                  <a href="#" id="btnEntrar" class="waves-effect waves-light btn school-button" style="width:100%;" onclick="btnEntrar_click();">Iniciar Sesión</a>
                                    <p id="msg" class="col s12" style=" text-decoration:none; color:#9f0606; text-align:center;"></p>
                                </div>
                                <div class="col s12">
                                     <a href="#"  class="col s12" style="padding-top:10px; text-decoration:none; color:#3A6381; text-align:center;" onclick="recuperar_contrasena();">¿Olvidó su contraseña?</a>
                                </div>
                            </div><!--end-->
                            <div id="fmrcprar" class="row" style="margin-top: 20px;display:none;">
                                 <div class="col s12">
                                     <p  class="col s12" style=" text-decoration:none; color:#3A6381; text-align:center;"><strong>Recuperar contraseña</strong> </p>
                                    
                                     <p  class="col s12" style=" text-decoration:none; color:#3A6381; text-align:center;">Escoja una de las opciones:</p>
                                </div>
                                 <div class="col s6">
                                     <input id="rbtusuario" type="radio" name="restablecer" value="rbtusuario" />
                                     <label for="rbtusuario" >Usuario</label>
                                 </div>
                                 <div class="col s6">
                                     <input id="rbtid" type="radio" name="restablecer"" value="rbtid" />
                                     <label for="rbtid" >Identificación</label>
                                 </div>
                                  <div class="input-field col s12">
                                      <input  name="txtUsuario2" type="text" id="txtUsuario2" class="validate"  />
                                      <label  for="txtUsuario2" >Usuario y/o Identificación</label>
                                 </div>
                                 <div class="col s12">
                                     <a href="#" id="btnRecuperar" class="waves-effect waves-light btn school-button" style="width:100%;" onclick="btnRecuperar_click()">Recuperar</a>
                                     <a href="#"  class="col s12" style="padding-top:10px; text-decoration:none; color:#3A6381; text-align:center;" onclick="volver_login()">Regresar</a>
                                 </div>  
                            </div>
                      <!-- Roles -->
                       <div id="fmroles" class="row" style="margin-top: 20px;display:none;">
                            <p  class="col s12" style=" text-decoration:none; color:#3A6381; text-align:center;">Para modificar su rol dentro de la aplicación debe ir a la opción Mi Perfil.</p>
                                  <div class="col s12" >
                                      <input id="cu" value="cu" style="display:none"/>
                                          <select class="browser-default" id="selectDrop"></select>
                                   </div>
                                   <div class="input-field col s12">
                                      <a href="#" id="btnElegirRol" class="waves-effect waves-light btn school-button" style="width:100%;" onclick="btnElegirRol_click()">Seleccionar</a>
                                 </div> 
                            </div><!--end-->
                  </div>
               </div>
           </div>
        
    </div>
<!-- Modal Structure -->
  <div id="modal1" class="modal" style="max-width:300px; width:100%;">
    <div class="modal-content">
      <h4>Información</h4>
      <div id="mensaje2"> sdsdf</div>
    </div>
    <div class="modal-footer">
      <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Aceptar</a>
    </div>
  </div>

    <script type="text/javascript" >
      
        $(document).ready(function () {
            $('select').material_select();
        });
            function recuperar_contrasena() {
                $("#fmlogin").hide();
                $("#fmrcprar").fadeIn(400);
            }

            function volver_login() {
                $("#fmrcprar").hide();
                $("#fmlogin").fadeIn(400);
                $("#txtUsuario").val("");
                $("#txtPass").val("");
                $("#msg").html("");
                $("#txtUsuario2").html("");
                document.getElementById("txtUsuario").focus();
            }

            /*envio de datos al servidor*/
            function btnEntrar_click() {
                var jsonData = '{ "usuario":"' + $("#txtUsuario").val() + '", "contrasenia": "' + $("#txtPass").val() + '" }';
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/login",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "true") {
                            window.location.href = "bienvenida.aspx";
                        }
                        else if (resp[0] === "roles")
                        {
                            $("#fmlogin").hide();
                            $("#fmroles").fadeIn(400);
                            $("#selectDrop").html(resp[1]);
                            $("#cu").val(resp[2]);

                        }
                        else {
                            $("#modal1").openModal();
                            $("#mensaje2").html(json.d);
                        }
                    }
                });
            }
            function btnElegirRol_click() {
                var jsonData = '{ "droprol":"' + $("#selectDrop").val() + '", "cu":"' + $("#cu").val() + '" }';
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/ElegirRol",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                          window.location.href = "bienvenida.aspx";
                    }
                });
            }
            function btnRecuperar_click() {
                var radiobutton = $("input:radio[name=restablecer]:checked").val();
                var jsonData = '{"usuario":"' + $("#txtUsuario2").val() + '","radiobutton":"' + radiobutton + '"}';
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/contrasenia",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (json) {
                        $("#txtUsuario2").html("");
                        //alert(json.d);
                         $("#modal1").openModal();
                         $("#mensaje2").html(json.d);
                    }
                });
            }

            $("#txtUsuario").enterKey(function () {
                btnEntrar_click();
            });
            $("#txtPass").enterKey(function () {
                btnEntrar_click();
            });
            $("#txtUsuario2").enterKey(function () {
                btnRecuperar_click();
            });
            $("#selectDrop").enterKey(function () {
                btnElegirRol_click();
            });
    </script>
    <div class="w3-theme-border" style="position:fixed;padding:0px;top:-7px;left:0;max-width:500px;width:100%;z-index:999">
       <p style="font-size:10pt;">SISTEMA DE INFORMACIÓN, SEGUIMIENTO, MONITOREO Y EVALUACIÓN PERMANENTE 
           <b> DE LA GOBERNACIÓN DE MAGDALENA</b></p>
    </div>
   <div class="w3-theme-border" style="position:fixed;padding:0px;bottom:-7px;right:0;max-width:500px;width:100%;z-index:999">
       <img src="Imagenes/banner_footer.png" width="100%" />
    </div>
     <div class="w3-theme-border" style="position:fixed;padding:0px;top:-7px;right:32%;max-width:500px;width:100%;z-index:999">
       <img src="Imagenes/banner_top.png" width="100%" />
    </div>
</body>
</html>
