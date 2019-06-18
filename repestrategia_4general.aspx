<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="repestrategia_4general.aspx.cs" Inherits="repestrategia_4general" %>

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
            $("#btn_asesoriasrealizadas").on("click", function () {
                $.ajax({
                    url: 'repestrategia_4general.aspx/cargarAsesoriasRealizadas',
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'JSON',
                    success: function (json) {
                        console.log(json.d);
                        $("#panelTable").html(json.d);
                    }
                });
            });

            $("#btn_asesoriasevaluadas").on("click", function () {
                $.ajax({
                    url: 'repestrategia_4general.aspx/cargarAsesoriasEvaluadas',
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'JSON',
                    success: function (json) {
                        console.log(json.d);
                        $("#panelTable").html(json.d);
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br /><br />
    <h2>Reporte General Estrategia No. 4</h2><br /><br />

    <a class="btn btn-success" id="btn_asesoriasrealizadas">Asesorias realizadas</a>
    <a class="btn btn-success" id="btn_asesoriasevaluadas">Asesorias evaluadas</a>
    <div id="panelTable" style="padding-top:75px;"></div>
    
</asp:Content>

