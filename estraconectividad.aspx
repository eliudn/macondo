<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraconectividad.aspx.cs" Inherits="estraconectividad" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
   <script src="jquery.js"></script>
    <%--<script src="s003/tinymce.min.js"></script>--%>
   <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
 
     <script src="Scripts/DataTables/js/jquery.dataTables.min.js"></script>
     <link href="Scripts/DataTables/css/dataTables.jqueryui.css" rel="stylesheet" />
 
     <%--<link rel="stylesheet" href="css/paginacion.css">--%>
   <style>
        body {
            font-family: arial;
        }

        fieldset {
            padding: 10px;
        }

        table.border td, table.border th {
            /*border: 1px solid;*/
            margin: 0;
            padding: 0;
        }

        table.border tr, table.border {
            margin: 0;
            padding: 0;
        }

        .width-100 {
            width: 100%;
        }

        .width-40 {
            width: 40px;
        }

        table.padding tr, table.padding {
            padding: 5px;
            margin: 5px;
        }

        .width-90 {
            width: 90%;
        }


        .pagination li {
  display: inline-block;
  border-radius: 2px;
  text-align: center;
  vertical-align: top;
  height: 30px;
}

.pagination li a {
  color: #444;
  display: inline-block;
  font-size: 1rem;
  padding: 0 10px;
  line-height: 30px;
}

.pagination li.active a {
  color: #fff;
}

.pagination li.active {
  background-color: #ee6e73;
}

.pagination li.disabled a {
  cursor: default;
  color: #999;
}

.pagination li i {
  font-size: 2rem;
}

.pagination li.pages ul li {
  display: inline-block;
  float: none;
}

@media only screen and (max-width: 992px) {
  .pagination {
    width: 100%;
  }
  .pagination li.prev,
  .pagination li.next {
    width: 10%;
  }
  .pagination li.pages {
    width: 80%;
    overflow: hidden;
    white-space: nowrap;
  }
}

    </style>

    <script>
     
        $(document).ready(function () {

            //Cargar listado 
            cargarListado();
           
        });

        var table;
        function cargarDataTable() {
            table = $('#infoListTable').DataTable({
                //"scrollX": 400,   // For Scrolling
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

        function cargarListado() {
            $("#infoListTable tbody").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            //var jsondata = "{'page':'" + page + "'}";

            $.ajax({
                type: 'POST',
                url: 'estraconectividad.aspx/cargarListado',
                //data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {

                    //var resp = response.d.split("@");

                    $("#infoListTable tbody").html(response.d);
                    //$("#paginacion").html(resp[1]);
                },
                complete: function () {
                    cargarDataTable();
                }
            });
        }

    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. 4 -  Conectividad</h2>
    <asp:Label ID="lblCodMomento" runat="server" Visible="false"></asp:Label>
<asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodRedTematicaSede" Visible="true"></asp:Label>

    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
    <div id="listTable">
        <%--<button class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500)">Nueva memoria</button>--%>

        <br />
        <fieldset>
            <table class="mGridTesoreria" id="infoListTable">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Municipio</th>
                        <th>Sede</th>
                        <th>Dane</th>
                        <th>Zona</th>
                        <th>BW</th>
                        <th>Fecha</th>
                    </tr>
                </thead>
                <tbody>

                </tbody>
            </table>
           <%-- <ul id="paginacion" class="pagination">
            </ul>--%>
        </fieldset>
    </div>
    <div id="formTable" style="display:none;">
        <fieldset>
    <table width="100%">
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Departamento </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="departamento" id="departamento">
                                <option value="">Seleccione departamento</option>
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Municipio </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="municipio" id="municipio">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de la entidad y / o Institución Educativa: </td>
                        <td width="70%">
                            <select class="TextBox width-100" name="institucion" id="institucion">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Sede: </td>
                        <td width="70%">
                            <select name="sede" id="sede" class="width-100 TextBox">
                            </select></td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%"><asp:label ID="lblTipoGrupo" runat="server" Visible="true"></asp:label>: </td>
                        <td width="70%">
                             <div id="redtematica"></div>
                           <%-- <select name="redtematica" id="redtematica" class="width-100 TextBox">
                                <option value="">Seleccione...</option>
                            </select>--%>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Número de sesiones realizadas </td>
                        <td width="70%">
                        <select id="nosesiones" class="TextBox" style="width:100px;">
                            <option value="" disabled>Seleccione sesión</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                        </select>    
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de sesión o actividad de formación: </td>
                        <td width="70%">
                            <input type="text" id="nombresesion" name="nombresesion" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Tema de la sesión o actividad de formación: </td>
                        <td width="70%">
                            <input type="text" id="temasesion" name="temasesion" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>

     
        <tr>
            <td width="55%">
                <table width="100%">
                    <tr>
                        <td width="30%">Fecha de la formación: </td>
                        <td width="100%">
                            <input type="text" id="fechaelaboracion" name="fechaelaboracion" class="width-100 TextBox datepicker" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td width="100%" colspan="2">
            <table width="100%">
                <tr>
                    <td width="30%">No. Horas virtuales por red: </td>
                    <td width="70%">
                        <input type="text" id="nohoras" name="nohoras" class="width-100 TextBox" style="width:50px;" onkeypress="return isNumberKey(event);" /></td>
                </tr>
            </table>
        </td>
    </tr>
        <tr>
      
            <table>
       <td width="30%">Hora de formación virtual en la Sede: </td>
       <td width="0%">
            <td width="23%">
                <table width="100%">
                    <tr>
                        <td width="50%">Hora Inicial:</td>
                        <td width="100%">
                            <select class="TextBox width-50" name="horasesion" id="horasesion">
                                <option value="">Seleccione hora</option>
                                <option value="00:00">00:00</option>
                                <option value="00:15">00:15</option>
                                <option value="00:30">00:30</option>
                                <option value="00:45">00:45</option>

                                <option value="01:00">01:00</option>
                                <option value="01:15">01:15</option>
                                <option value="01:30">01:30</option>
                                <option value="01:45">01:45</option>

                                <option value="02:00">02:00</option>
                                <option value="02:15">02:15</option>
                                <option value="02:30">02:30</option>
                                <option value="02:45">02:45</option>

                                <option value="03:00">03:00</option>
                                <option value="03:15">03:15</option>
                                <option value="03:30">03:30</option>
                                <option value="03:45">03:45</option>

                                <option value="04:00">04:00</option>
                                <option value="04:15">04:15</option>
                                <option value="04:30">04:30</option>
                                <option value="04:45">04:45</option>

                                <option value="05:00">05:00</option>
                                <option value="05:15">05:15</option>
                                <option value="05:30">05:30</option>
                                <option value="05:45">05:45</option>

                                <option value="06:00">06:00</option>
                                <option value="06:15">06:15</option>
                                <option value="06:30">06:30</option>
                                <option value="06:45">06:45</option>

                                <option value="07:00">07:00</option>
                                <option value="07:15">07:15</option>
                                <option value="07:30">07:30</option>
                                <option value="07:45">07:45</option>

                                <option value="08:00">08:00</option>
                                <option value="08:15">08:15</option>
                                <option value="08:30">08:30</option>
                                <option value="08:45">08:45</option>

                                <option value="09:00">09:00</option>
                                <option value="09:15">09:15</option>
                                <option value="09:30">09:30</option>
                                <option value="09:45">09:45</option>

                                <option value="10:00">10:00</option>
                                <option value="10:15">10:15</option>
                                <option value="10:30">10:30</option>
                                <option value="10:45">10:45</option>

                                <option value="11:00">11:00</option>
                                <option value="11:15">11:15</option>
                                <option value="11:30">11:30</option>
                                <option value="11:45">11:45</option>

                                <option value="12:00">12:00</option>
                                <option value="12:15">12:15</option>
                                <option value="12:30">12:30</option>
                                <option value="12:45">12:45</option>

                                <option value="13:00">13:00</option>
                                <option value="13:15">13:15</option>
                                <option value="13:30">13:30</option>
                                <option value="13:45">13:45</option>

                                <option value="14:00">14:00</option>
                                <option value="14:15">14:15</option>
                                <option value="14:30">14:30</option>
                                <option value="14:45">14:45</option>

                                <option value="15:00">15:00</option>
                                <option value="15:15">15:15</option>
                                <option value="15:30">15:30</option>
                                <option value="15:45">15:45</option>

                                <option value="16:00">16:00</option>
                                <option value="16:15">16:15</option>
                                <option value="16:30">16:30</option>
                                <option value="16:45">16:45</option>

                                <option value="17:00">17:00</option>
                                <option value="17:15">17:15</option>
                                <option value="17:30">17:30</option>
                                <option value="17:45">17:45</option>

                                <option value="18:00">18:00</option>
                                <option value="18:15">18:15</option>
                                <option value="18:30">18:30</option>
                                <option value="18:45">18:45</option>

                                <option value="19:00">19:00</option>
                                <option value="19:15">19:15</option>
                                <option value="19:30">19:30</option>
                                <option value="19:45">19:45</option>

                                <option value="20:00">20:00</option>
                                <option value="20:15">20:15</option>
                                <option value="20:30">20:30</option>
                                <option value="20:45">20:45</option>

                                <option value="21:00">21:00</option>
                                <option value="21:15">21:15</option>
                                <option value="21:30">21:30</option>
                                <option value="21:45">21:45</option>

                                <option value="22:00">22:00</option>
                                <option value="22:15">22:15</option>
                                <option value="22:30">22:30</option>
                                <option value="22:45">22:45</option>

                                <option value="23:00">23:00</option>
                                <option value="23:15">23:15</option>
                                <option value="23:30">23:30</option>
                                <option value="23:45">23:45</option>

                            </select>
                        </td>
                    </tr>
                </table>
            </td>

       

              <td width="100%">
                  <table>
            <td width="50%">
                <table width="55%">                  
                    <tr>
                        <td width="50%">Hora Final: </td>
                        <td width="100%">
                            <select class="TextBox width-50" name="horasesionfinal" id="horasesionfinal">
                                <option value="">Seleccione hora</option>
                                <option value="00:00">00:00</option>
                                <option value="00:15">00:15</option>
                                <option value="00:30">00:30</option>
                                <option value="00:45">00:45</option>

                                <option value="01:00">01:00</option>
                                <option value="01:15">01:15</option>
                                <option value="01:30">01:30</option>
                                <option value="01:45">01:45</option>

                                <option value="02:00">02:00</option>
                                <option value="02:15">02:15</option>
                                <option value="02:30">02:30</option>
                                <option value="02:45">02:45</option>

                                <option value="03:00">03:00</option>
                                <option value="03:15">03:15</option>
                                <option value="03:30">03:30</option>
                                <option value="03:45">03:45</option>

                                <option value="04:00">04:00</option>
                                <option value="04:15">04:15</option>
                                <option value="04:30">04:30</option>
                                <option value="04:45">04:45</option>

                                <option value="05:00">05:00</option>
                                <option value="05:15">05:15</option>
                                <option value="05:30">05:30</option>
                                <option value="05:45">05:45</option>

                                <option value="06:00">06:00</option>
                                <option value="06:15">06:15</option>
                                <option value="06:30">06:30</option>
                                <option value="06:45">06:45</option>

                                <option value="07:00">07:00</option>
                                <option value="07:15">07:15</option>
                                <option value="07:30">07:30</option>
                                <option value="07:45">07:45</option>

                                <option value="08:00">08:00</option>
                                <option value="08:15">08:15</option>
                                <option value="08:30">08:30</option>
                                <option value="08:45">08:45</option>

                                <option value="09:00">09:00</option>
                                <option value="09:15">09:15</option>
                                <option value="09:30">09:30</option>
                                <option value="09:45">09:45</option>

                                <option value="10:00">10:00</option>
                                <option value="10:15">10:15</option>
                                <option value="10:30">10:30</option>
                                <option value="10:45">10:45</option>

                                <option value="11:00">11:00</option>
                                <option value="11:15">11:15</option>
                                <option value="11:30">11:30</option>
                                <option value="11:45">11:45</option>

                                <option value="12:00">12:00</option>
                                <option value="12:15">12:15</option>
                                <option value="12:30">12:30</option>
                                <option value="12:45">12:45</option>

                                <option value="13:00">13:00</option>
                                <option value="13:15">13:15</option>
                                <option value="13:30">13:30</option>
                                <option value="13:45">13:45</option>

                                <option value="14:00">14:00</option>
                                <option value="14:15">14:15</option>
                                <option value="14:30">14:30</option>
                                <option value="14:45">14:45</option>

                                <option value="15:00">15:00</option>
                                <option value="15:15">15:15</option>
                                <option value="15:30">15:30</option>
                                <option value="15:45">15:45</option>

                                <option value="16:00">16:00</option>
                                <option value="16:15">16:15</option>
                                <option value="16:30">16:30</option>
                                <option value="16:45">16:45</option>

                                <option value="17:00">17:00</option>
                                <option value="17:15">17:15</option>
                                <option value="17:30">17:30</option>
                                <option value="17:45">17:45</option>

                                <option value="18:00">18:00</option>
                                <option value="18:15">18:15</option>
                                <option value="18:30">18:30</option>
                                <option value="18:45">18:45</option>

                                <option value="19:00">19:00</option>
                                <option value="19:15">19:15</option>
                                <option value="19:30">19:30</option>
                                <option value="19:45">19:45</option>

                                <option value="20:00">20:00</option>
                                <option value="20:15">20:15</option>
                                <option value="20:30">20:30</option>
                                <option value="20:45">20:45</option>

                                <option value="21:00">21:00</option>
                                <option value="21:15">21:15</option>
                                <option value="21:30">21:30</option>
                                <option value="21:45">21:45</option>

                                <option value="22:00">22:00</option>
                                <option value="22:15">22:15</option>
                                <option value="22:30">22:30</option>
                                <option value="22:45">22:45</option>

                                <option value="23:00">23:00</option>
                                <option value="23:15">23:15</option>
                                <option value="23:30">23:30</option>
                                <option value="23:45">23:45</option>

                            </select>
                        </td>
                    </tr>
                </table>
            </td>
                      </table>
                  </td>
           </td>
        </table>

        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombres y apellidos del docente Asesor: </td>
                        <td width="70%">
                            <input type="text" id="nombreapellidorelator" name="nombreapellidorelator" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br/>

    <fieldset>

        <h2 style="display: block; text-align: center">ACOMPAÑAMIENTO VIRTUAL</h2>

        <span>1.  Describa las actividades realizadas para el acompañamiento virtual, destacando aspectos metodológicos y didácticos. (¿De qué manera organizó al grupo?, ¿Qué actividades realizó? Responsables de las actividades)<br />
         
</span><br/>
        <br/>
    
        <cc1:Editor ID="acompanamiento" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
       <h2 style="display: block; text-align: center">HERRAMIENTAS VIRTUALES UTILIZADAS</h2>
        <span>Describa los módulos y herramientas trabajadas en la plataforma Juego gózate la ciencia, puede incluir otras herramientas de apoyo utilizadas.
            <br>

        </span>
        <br>
        <br>
     
        <cc1:Editor ID="herramientas" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
       
         <h2 style="display: block; text-align: center">EVALUACIÓN DE LA SESIÓN
        </h2>
        <span> Describa los aspectos por mejorar, fortalezas y debilidades. </span><br>
        <br>
        <cc1:Editor ID="evaluacionsesion" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
    </fieldset>

    <br>
      
    
 </fieldset>
        <div class="button">
        <%--<a class="btn btn-primary" onclick="$('#listTable').fadeIn(500), $('#formTable').hide(), $('#evidencias').hide(), reset()">Regresar</a>--%>
             <a class="btn btn-primary" onclick="btnregresar()">Regresar</a>
        <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviarestras004('insert');">
       <%-- <a class="btn btn-danger" onclick="uploadImagen()">Subir evidencia</a>--%>
        <%--<asp:Button ID="btnSubirFirmaPop" runat="server" Text="Subir Imagen" CssClass="btn btn-danger" OnClick="btnSubirFirmaPop_Click" />--%>
        <%--<asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar todo" runat="server" OnClick="btnGuardarSede_Click" />--%>
    </div>
    </div>
    
  
    <style type="text/css">
        .button {
            background: rgba(255,255,255,.7);
            bottom:0;
            display:block;
            left: 0;
            padding: 15px;
            position: fixed;
            right: 0;
            text-align:right;
        }
    </style>

       <div id="modificarsesion" style="display:none">
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>Red temática</th>
                    <th>Sesión</th>
                </tr>
            </thead>
            <tbody id="infosesion"></tbody>
        </table>

        <table align="center">
            <tr>
                <td><select id="sesion" class="TextBox">
                    <option value="0" disabled>Seleccione una Sesión</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                    </select></td>
            </tr>
            <tr>
                <td><a onclick="guardarSesion();" class="btn btn-success">Modificar Sesión</a>
                    <a onclick="$('#modificarsesion').hide();$('#formTable').hide();$('#listTable').fadeIn(500)" class="btn btn-primary">Regresar</a>
                </td>
            </tr>
        </table>

    </div>

    
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

