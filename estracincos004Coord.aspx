<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estracincos004Coord.aspx.cs" Inherits="estracincos004Coord" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
        TagPrefix="cc1" %>
   <script src="jquery.js"></script>

   <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
 

 
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
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);

        var total = 1;
        var codigoestrategia;
        $(document).ready(function () {

            
            //Cargar listado de memorias
            cargarListadoMemorias("1");
            reset();

            //Cargar departamento
            $.ajax({
                type: 'POST',
                url: 'estracincos004Coord.aspx/cargarDepartamentoMagdalena',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "departamento") {
                        $("#departamento").html(resp[1]);
                    }
                }
            });

            $("#departamento").on("change", function () {
                var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estracincos004Coord.aspx/cargarMunicipioMagdalena',
                    data: jsondata,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        var resp = response.d.split("@");
                        if (resp[0] === "municipio") {
                            $("#municipio").html(resp[1]);
                        }
                    }
                });
            });

          
            $(".datepicker").datepicker({ changeYear: true, changeMonth: true });
        });

        function cargarListadoMemorias(page) {
            $("#infoListTable").html("<tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>")
            var jsondata = "{'page':'" + page + "'}";

            $.ajax({
                type: 'POST',
                url: 'estracincos004Coord.aspx/cargarListadoMemoriaCoord',
                data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {

                    var resp = response.d.split("@");

                    $("#infoListTable").html(resp[0]);
                    $("#paginacion").html(resp[1]);
                }
            });
        }

        function cargarMunicipios() {
            var jsondata = "{'codDepartamento': '" + $("#departamento").val() + "'}";
            $.ajax({
                type: 'POST',
                url: 'estracincos004Coord.aspx/cargarMunicipioMagdalena',
                data: jsondata,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "municipio") {
                        $("#municipio").html(resp[1]);
                    }
                }
            });
        }

        function reset() {
            $("#nombreactividad").val('');
            $("#fechaelaboracion").val('');
            $("#fechaelaboracionini").val('');
            $("#lugar").val('');
            $("#horainicio").val('');
            $("#horafin").val('');


            document.getElementById('MainContent_descripcion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_producto_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_recursos_ctl02_ctl00').contentWindow.document.body.innerHTML = '';
            document.getElementById('MainContent_evaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML = '';

        }


        function enviarestras004(event) {
            if ($.trim($("#municipio").val()) == '') {
                alert("Por favor, seleccione el municipio");
                $("#municipio").focus();
            } else if ($.trim($("#lugar").val()) == '') {
                alert("Por favor, ingrese el lugar de realización");
                $("#lugar").focus();
            } else if ($.trim($("#nombreactividad").val()) == '') {
                alert("Por favor, ingrese Nombre de la actividad de formación");
                $("#nombreactividad").focus();
            } else if ($.trim($("#fechaelaboracionini").val()) == '') {
                alert("Por favor, ingrese Fecha de inicio de la memoría");
                $("#fechaelaboracion").focus();
            } else if ($.trim($("#fechaelaboracion").val()) == '') {
                alert("Por favor, ingrese Fecha fin de la memoría");
                $("#fechaelaboracion").focus();
            } else if ($.trim($("#horainicio").val()) == '') {
                alert("Por favor, Selecciones la hora de inicio");
                $("#fechaelaboracion").focus();
            } else if ($.trim($("#horafin").val()) == '') {
                alert("Por favor, Selecciones la hora fin");
                $("#fechaelaboracion").focus();
            }

            else if ($.trim(document.getElementById('MainContent_descripcion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese el punto 1. del Desarrollo de la jornada de formación");
            } else if ($.trim(document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese el punto 2. del Desarrollo de la jornada de formación");
            } else if ($.trim(document.getElementById('MainContent_producto_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese los productos ");
            } else if ($.trim(document.getElementById('MainContent_recursos_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese Recursos Pedagogicos ");
            } else if ($.trim(document.getElementById('MainContent_evaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML) == '<br>') {
                alert("Por favor, ingrese la Evaluación de la Sesión");
            }
            else {
                var descripcion = document.getElementById('MainContent_descripcion_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var sintesis = document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var producto = document.getElementById('MainContent_producto_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var recursos = document.getElementById('MainContent_recursos_ctl02_ctl00').contentWindow.document.body.innerHTML;
                var evaluacion = document.getElementById('MainContent_evaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML;

            if (event == 'insert') {
                var jsonData = "{ 'municipio':'" + $("#municipio").val() + "', 'lugar':'" + $("#lugar").val() + "', 'nombreactividad':'" + $("#nombreactividad").val() + "', 'descripcion':'" + descripcion + "', 'sintesis':'" + sintesis + "', 'producto':'" + producto + "', 'recursos':'" + recursos + "', 'evaluacion':'" + evaluacion + "', 'fechaelaboracion':'" + $("#fechaelaboracion").val() + "', 'horainicio':'" + $("#horainicio").val() + "', 'horafin':'" + $("#horafin").val() + "', 'fechaelaboracionini':'" + $("#fechaelaboracionini").val() + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estracincos004Coord.aspx/insertestras004',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                codigoestrategia = resp[1];
                                alert("instrumento insertado exitosamente");
                                $("#formTable").hide();
                                $("#listTable").fadeIn(500);
                                cargarListadoMemorias("1");
                                reset();
                            } else {
                                alert(resp[1]);
                            }
                        }
                    });
                } else if (event == 'update') {
                    var jsonData = "{  'codigoestrategia':'" + codigoestrategia + "', 'nombreactividad':'" + $("#nombreactividad").val() + "', 'descripcion':'" + descripcion + "', 'sintesis':'" + sintesis + "', 'producto':'" + producto + "', 'recursos':'" + recursos + "', 'evaluacion':'" + evaluacion + "', 'fechaelaboracion':'" + $("#fechaelaboracion").val() + "', 'lugar':'" + $("#lugar").val() + "', 'horainicio':'" + $("#horainicio").val() + "', 'horafin':'" + $("#horafin").val() + "', 'fechaelaboracionini':'" + $("#fechaelaboracionini").val() + "', 'codmunicipio':'" + $("#municipio").val() + "'}";

                    $.ajax({
                        type: 'POST',
                        url: 'estracincos004Coord.aspx/updateestras004',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function (json) {
                            var resp = json.d.split("@");
                            if (resp[0] === "true") {
                                //codigoestrategia = codigoestrategia;
                                alert("instrumento actualizado exitosamente");
                                $("#formTable").hide();
                                $("#listTable").fadeIn(500);
                                cargarListadoMemorias("1");
                                reset();
                            } else {
                                alert(resp[1]);
                            }
                        }
                        //, complete: function () {
                        //    finsertpreguntas();
                        //}
                    });
                }

            }
        }


        function loadInstrumento(codigo) {
            var jsonData = "{ 'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estracincos004Coord.aspx/loadestras004',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    //console.log(json);
                    loadSelectInstrumento(codigo);
                    //loadEvidencias(codigo)
                    var resp = json.d.split("@");
                    if (resp[0] === "datosintrumento") {
                        codigoestrategia = resp[1];
                        $("#nombreactividad").val(resp[2]);

                        document.getElementById('MainContent_descripcion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[3];
                        document.getElementById('MainContent_sintesis_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[4];
                        document.getElementById('MainContent_producto_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[5];
                        document.getElementById('MainContent_recursos_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[6];
                        document.getElementById('MainContent_evaluacion_ctl02_ctl00').contentWindow.document.body.innerHTML = resp[7];

                        $("#fechaelaboracion").val(resp[8]);
                        $("#lugar").val(resp[9]);
                        $("#horainicio").val(resp[10]);
                        $("#horafin").val(resp[11]);
                        $("#fechaelaboracionini").val(resp[12]);

                        if (resp[13] === "12") {
                            $('#btn-guardar').attr('value', 'Actualizar');
                            $('#btn-guardar').attr('onclick', 'enviarestras004(\'update\')');
                        } else {
                            $('#btn-guardar').hide();
                        }

                        loadSelectInstrumento(codigo);


                    } else {
                        alert("Ocurrio un error");
                    }
                }
            });
        }

        function loadSelectInstrumento(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estracincos004Coord.aspx/loadSelectInstrumento',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "loadSelect") {
                        //cargarMunicipios();
                        $("#departamento").html(resp[1]);
                        $("#municipio").html(resp[2]);
                        
                    }
                }
            });
        }


        function resetSelect(){
            $("#departamento").val("");
            $("#municipio").val("");

            $('#btn-guardar').attr('value', 'Guardar todo');
            $('#btn-guardar').attr('onclick', 'enviarestras004(\'insert\')');
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar esta Memoria? Recuerde que perderá todo sus registros')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estracincos004Coord.aspx/deleteestras004',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            cargarListadoMemorias("1");
                            alert('Datos eliminados correctamente.');
                        }
                    }
                });
            }

        }

    </script>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display: none;"></div>
    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. <asp:Label runat="server" ID="lblEstrategia" Visible="true"></asp:Label> -  S004: Memoria de los espacios de formación o apropiación social</h2>
    <asp:Label ID="lblCodMomento" runat="server" Visible="false"></asp:Label>
<asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodRedTematicaSede" Visible="true"></asp:Label>

    <!-- <legend>DATOS DE LA INSTITUCIÓN</legend> -->
    <div id="listTable">
        <%--<button class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500)">Nueva memoria</button>--%>
        <a class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500), resetSelect()">Nueva memoria</a>
        <br /><br /><br />
        <fieldset>
            <table class="mGridTesoreria">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Departamento</th>
                        <th>Municipio</th>
                        <th>Lugar</th>
                        <th>Actividad</th>
                        <th>Fecha inicio</th>
                         <th>Fecha fin</th>
                        <th>Sesión</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="infoListTable">

                </tbody>
            </table>
            <ul id="paginacion" class="pagination">
            </ul>
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
                        <td width="30%">Lugar de realización: </td>
                        <td width="70%">
                            <input type="text" id="lugar" name="lugar" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td width="100%" colspan="2">
                <table width="100%">
                    <tr>
                        <td width="30%">Nombre de la actividad o proceso de formación o apropiación social: </td>
                        <td width="70%">
                            <input type="text" id="nombreactividad" name="nombreactividad" class="width-100 TextBox" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td width="30%">
              Fecha de la formación
            </td>
        <td>
              <table width="100%" border="0">
                    <tr>
                        <td>Fecha de formación Inicial</td>
                        <td > <input type="text" id="fechaelaboracionini" name="fechaelaboracion" class="width-100 TextBox datepicker" /></td>
                        <td>Fecha de Formación Final</td>
                        <td >
                            <input type="text" id="fechaelaboracion" name="fechaelaboracion" class="width-100 TextBox datepicker" /></td>
                    </tr>
                </table>
        </td>
        </tr>
        <tr>
                  <table>
       <td width="30%">Horario de formación: </td>
       <td width="0%">
            <td width="23%">
                <table width="100%">
                    <tr>
                        <td >Hora de Inicio de Formación:</td>
                        <td >
                            <select class="TextBox width-50" name="horainicio" id="horainicio">
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
                        <td >Hora final de Formación: </td>
                        <td >
                            <select class="TextBox width-50" name="horafin" id="horafin">
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
     
    </table>
    </fieldset>
		<!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br/>

    <fieldset>

        <h2 style="display: block; text-align: center">DESARROLLO DE LA JORNADA DE FORMACIÓN</h2>

        <span>1.  Realice una descripción de las actividades de formación realizadas en la sesión, destacando aspectos metodológicos y didácticos. Describa las actividades de manera cronológica.<br />
        </span><br/>
        <br/>
      
        <cc1:Editor ID="descripcion" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <span>2.	Síntesis de los aportes, comentarios y apreciaciones de estudiantes de la red temática durante el desarrollo de la sesión presencial y virtual.
            <br>
        </span>
        <br>
        <br>
        <cc1:Editor ID="sintesis" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <h2 style="display: block; text-align: center">PRODUCTOS</h2>
        <span>Describa los productos solicitados y diseñados por los participantes durante la sesión de formación: relato, diagrama, cuadro u otros</span><br>
        <br>
        <cc1:Editor ID="producto" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
        <h2 style="display: block; text-align: center">RECURSOS
        </h2>
        <span> Relacione la bibliografía, infografía, herramientas y estrategias lúdico/pedagógicas utilizadas. </span><br>
        <br>
       <cc1:Editor ID="recursos" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
         <h2 style="display: block; text-align: center">EVALUACIÓN DE LA SESIÓN
        </h2>
        <span> Describa los aspectos por mejorar, fortalezas y debilidades </span><br>
        <br>
        <cc1:Editor ID="evaluacion" runat="server" Width="1050px" Height="250" />
        <br>
        <br>
        <br>
    </fieldset>

    <br>
      

    
 </fieldset>
        <div class="button">
        <a class="btn btn-primary" onclick="$('#listTable').fadeIn(500), $('#formTable').hide(), $('#evidencias').hide(), reset()">Regresar</a>
        <input type="button" value="Guardar todo" class="btn btn-success" id="btn-guardar" onclick="enviarestras004('insert');">
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

    
</ContentTemplate>
</asp:UpdatePanel>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                    <h6> <p style="text-align:center"> <b>Procesando Datos, Espere por favor... <br /><br /></b> </p> </h6>
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>
      

</asp:Content>

