<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estumatricula.aspx.cs" Inherits="estumatricula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
<style>
    .switch {
        position: relative;
        display: inline-block;
        width: 60px;
        height: 34px;
    }

    .switch input {display:none;}

    .slider {
        position: absolute;
        cursor: pointer;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: #ccc;
        -webkit-transition: .4s;
        transition: .4s;
    }

    .slider:before {
        position: absolute;
        content: "";
        height: 26px;
        width: 26px;
        left: 4px;
        bottom: 4px;
        background-color: white;
        -webkit-transition: .4s;
        transition: .4s;
    }

    input:checked + .slider {
        background-color: #2196F3;
    }

    input:focus + .slider {
        box-shadow: 0 0 1px #2196F3;
    }

    input:checked + .slider:before {
        -webkit-transform: translateX(26px);
        -ms-transform: translateX(26px);
        transform: translateX(26px);
    }

    /* Rounded sliders */
    .slider.round {
        border-radius: 34px;
    }

    .slider.round:before {
        border-radius: 50%;
    }
</style>

    <script>
        $(function () {
            //*cargarListado();
            cargarDepartamento();

            $("#departamento").on("change", function () {
                cargarMunicipio($("#departamento").val());
            });

            $("#municipio").on("change", function () {
                cargarInstitucion($("#municipio").val());
            });

            $("#institucion").on("change", function(){
                cargarSede($("#institucion").val());
            });

            $("#sede").on("change", function () {
                cargarGrado();
            });
        });

        function cargarDepartamento() {
            $.ajax({
                url: 'estumatricula.aspx/cargarDepartamentoMagdalena',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'JSON',
                //data:frmserialize,
                success: function (json) {
                    $("#departamento").html(json.d);
                }
            });
        }

        function cargarMunicipio(codigo) {
            var data = "{'coddepartamento': '" + codigo + "'}"
            $.ajax({
                url: 'estumatricula.aspx/cargarMunicipios',
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#municipio").html(response.d);

                }

            });
        }

        function cargarInstitucion(codigo) {
            var data = "{'codmunicipio': '" + codigo + "'}"
            $.ajax({
                url: 'estumatricula.aspx/cargarInstituciones',
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#institucion").html(response.d);
                }
            });
        }

        function cargarSede(codigo) {
            var data = "{'codInstitucion': '" + codigo + "'}"
            $.ajax({
                url: 'estumatricula.aspx/cargarSedesInstitucion',
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#sede").html(response.d);
                }
            });
        }

        function cargarGrado() {
            $.ajax({
                url: 'estumatricula.aspx/cargarGrado',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    $("#grado").html(response.d);
                }
            });
        }

        function cargarListado() {
            $.ajax({
                url: 'estumatricula.aspx/listarEstudianteNoMatricula',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if(resp[0] == "lista")
                    {
                        $("#listData").html(resp[1]);
                    }
                }
            })
        }

        function doSearch(valor) {
            $("#listData").html("<tr><td colspan='4' style='text-align:center'>Cargando...</td></tr>");

            var data = "{'valor': '" + valor + "'}";

            $.ajax({
                url: 'estumatricula.aspx/buscarEstudianteNoMatricula',
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'JSON',
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] == "lista") {
                        $("#listData").html(resp[1]);
                    } else {
                        $("#listData").html("<tr><td colspan='4' style='text-align:center'>No se encontraron resultados.</td></tr>");

                    }

                }
            })
        }

        function matricularEstudiante() {
            var codigo = "";
            var mensaje = "";
            var parametro = "";
            $("input:checkbox:checked").each(function () {
                codigo += "@" + $(this).val();
            });
            //console.log(codigo);
            //console.log(codigo.length);

            if($.trim($("#departamento").val()) == '' || $.trim($("#departamento").val()) == null)
            {
                alert("Por favor seleccione el departamento");
                $("#departamento").focus();
                return false;
            }
            else if ($.trim($("#municipio").val()) == '' || $.trim($("#municipio").val()) == null)
            {
                alert("Por favor seleccione el municipio");
                $("#municipio").focus();
                return false;
            }
            else if ($.trim($("#institucion").val()) == '' || $.trim($("#institucion").val()) == null)
            {
                alert("Por favor seleccione la institucion");
                $("#institucion").focus();
                return false;
            }
            else if ($.trim($("#sede").val()) == '' || $.trim($("#sede").val()) == null)
            {
                alert("Por favor seleccione la sede");
                $("#sede").focus();
                return false;
            }
            else if($.trim($("#grado").val()) == '' || $.trim($("#grado").val()) == null)
            {
                alert("Por favor seleccione el grado");
                $("#grado").focus();
                return false;
            }
            else if (codigo.length == 0) {
                alert("por favor seleccione los estudiantes a matricular");
                return false;
            }
            else
            {
               
                var jsondata = "{'codestudiante':'" + codigo + "', 'codsede':'" + $("#sede").val() + "', 'codgrado':'" + $("#grado").val() + "'}";
                $.ajax({
                    url: 'estumatricula.aspx/matricularEstudiante',
                    type: 'POST',
                    data: jsondata,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'JSON',
                    success: function (response) {
                        var resp = response.d.split("@");
                        if (resp[0] == "matricula") {
                            alert(resp[1]);
                            $("#listData").html("");
                            //load();
                        }
                        else if(resp[0] == "vacio")
                        {
                            alert(resp[1]);
                        }
                    }
                });
            }
        }

        function load() {
            cargarDepartamento();
            cargarListado();
            $("#municipio").val("");
            $("#institucion").val("");
            $("#sede").val("");
            $("#grado").val("");
        }

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br /><br />
    <h2>Matricular estudiante</h2>
    <fieldset>
        <legend>Datos institucionales</legend>
        <a href="Documentos/Modulo_matricular_estudiante.pdf" class="btn btn-danger" id="btn-instructuvo" style="float:right;"  target="_blank">instructivo</a>
        <table>
            <tr>
                <td>Departamento</td>
                <td>
                    <select id="departamento" class="TextBox"></select>
                </td>
            </tr>
            <tr>
                <td>Municipio</td>
                <td>
                    <select id="municipio" class="TextBox"></select>
                </td>
            </tr>
            <tr>
                <td>Institucion educativa</td>
                <td>
                    <select id="institucion" class="TextBox"></select>
                </td>
            </tr>
            <tr>
                <td>Sede</td>
                <td>
                    <select id="sede" class="TextBox"></select>
                </td>
            </tr>
            <tr>
                <td>Grado</td>
                <td>
                    <select id="grado" class="TextBox"></select>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="text-align:center;">
        <legend>Listado estudiantes sin matricular</legend>
        <input type="text" id="buscar" class="TextBox" style="width:22%;"  placeholder="Buscar por nombre o documento..." />
         <a class="btn btn-success" id="btn-buscar"  onclick="doSearch($('#buscar').val());">Buscar</a>       
         <a class="btn btn-primary" id="btn-matricular" style="float:right;" onclick="matricularEstudiante()">Matricular</a>
        <br /><br />
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Identificacion</th>
                    <th>Nombre estudiante</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="listData">
            </tbody>
        </table>
    </fieldset>
</asp:Content>

