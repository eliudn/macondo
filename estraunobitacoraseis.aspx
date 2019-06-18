<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunobitacoraseis.aspx.cs" Inherits="estraunobitacoraseis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>
       .primeracolumna{
            text-align:right;
            font-weight:bold;
        }
    
        .auto-style1 {
            color: #FF0000;
        }
    </style>

     <script type="text/javascript">

         var codigoinstrumento;

         $(document).ready(function () {
             listadobitacora6();
         });

         function listadobitacora6() {
             $.ajax({
                 type: 'POST',
                 url: 'estraunobitacoraseis.aspx/listadobitacora6',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     $("#tbody").html(response.d);
                 }
             });
         }
         var codigo;
         var total = 1;
         var total2do = 1;
         var total3ro = 1;
         var total4to = 1;
         //var total5to = 1;
         //var total6to = 1;
         //var total7mo = 1;
         //var total8vo = 1;

         var e;
         var m;
         var s;
         $(function () {
             var formatNumber = {
                 separador: ".", // separador para los miles
                 sepDecimal: ',', // separador para los decimales
                 formatear: function (num) {
                     num += '';
                     var splitStr = num.split('.');
                     var splitLeft = splitStr[0];
                     var splitRight = splitStr.length > 1 ? this.sepDecimal + splitStr[1] : '';
                     var regx = /(\d+)(\d{3})/;
                     while (regx.test(splitLeft)) {
                         splitLeft = splitLeft.replace(regx, '$1' + this.separador + '$2');
                     }
                     return this.simbol + splitLeft + splitRight;
                 },
                 new: function (num, simbol) {
                     this.simbol = simbol || '';
                     return this.formatear(num);
                 }
             }
            


             cargarDepartamentosMagdalena();

             $("#departamento").on('change', function () {
                 var data = "{'coddepartamento': '" + $('#departamento').val() + "'}"
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/cargarMunicipios',
                     type: 'POST',
                     data: data,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#municipio").html(response.d);

                     }

                 });
             });


             $("#municipio").on('change', function () {
                 var data = "{'codmunicipio': '" + $('#municipio').val() + "'}"
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/cargarInstituciones',
                     type: 'POST',
                     data: data,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#instituciones").html(response.d);


                     }

                 });
             });

             $("#instituciones").on('change', function () {
                 var data = "{'codInstitucion': '" + $('#instituciones').val() + "'}"
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/cargarSedesInstitucion',
                     type: 'POST',
                     data: data,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#sedes").html(response.d);


                     }

                 });
             });

             $("#sedes").on("change", function () {
                 var data = "{'codSede':'" + $("#sedes").val() + "'}";
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/cargarLineaInvestigacion',
                     type: 'POST',
                     data: data,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         $("#grupoInvestigacion").html(response.d);
                     }
                 });
             });
         });

         function cargarDepartamentosMagdalena() {
             $.ajax({
                 url: 'estraunobitacoraseis.aspx/cargarDepartamentoMagdalena',
                 type: 'POST',
                 contentType: "application/json; charset=utf-8",
                 dataType: 'JSON',
                 //data:frmserialize,
                 success: function (json) {
                     var respo = json.d.split("@");
                     $("#departamento").html(respo[1]);
                     e = respo[2];
                     m = respo[3];
                     s = respo[4];


                 }
             });
         }

         function add() {
             if ($.trim($("#actividad" + total).val()) == '' || $.trim($("#actividad" + total).val()) == null) {
                 alert("Por favor, Ingrese actividades en este primer trayecto");
                 $("#actividad" + total).focus();
             } else if ($.trim($("#herramienta" + total).val()) == '' || $.trim($("#herramienta" + total).val()) == null) {
                 alert("Por favor, Ingrese las herramientas en este primer trayecto");
                 $("#herramienta" + total).focus();
             } else if ($.trim($("#resultado" + total).val()) == '' || $.trim($("#resultado" + total).val()) == null) {
                 alert("Por favor, Ingrese resultado en este primer trayecto");
                 $("#resultado" + total).focus();
             } else if ($.trim($("#presupuesto" + total).val()) == '' || $.trim($("#presupuesto" + total).val()) == null) {
                 alert("Por favor, Ingrese presupuesto en este primer trayecto");
                 $("#presupuesto" + total).focus();
             }else {
                 total = total + 1;
                 if ($("#remove1")) {
                     $("#remove1").remove();
                 }

                 html = '<tr id="oCampus' + total + '">';
                 html += '<td><input type="text" id="actividad' + total + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="herramienta' + total + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="resultado' + total + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td id="oRadiotr' + total + '"><input type="text" id="presupuesto' + total + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove1" class="btn btn-danger" onclick="fRemove1(' + total + ');" value="-"/></td></tr>';
                 $("#tableTrayecto").append(html);

             }
         }

         function add2do() {
             if ($.trim($("#actividad2do" + total2do).val()) == '' || $.trim($("#actividad2do" + total2do).val()) == null) {
                 alert("Por favor, Ingrese actividades en este segundo trayecto");
                 $("#actividad2do" + total2do).focus();
             } else if ($.trim($("#herramienta2do" + total2do).val()) == '' || $.trim($("#herramienta2do" + total2do).val()) == null) {
                 alert("Por favor, Ingrese las herramientas en este segundo trayecto");
                 $("#herramienta2do" + total2do).focus();
             } else if ($.trim($("#resultado2do" + total2do).val()) == '' || $.trim($("#responsable2do" + total2do).val()) == null) {
                 alert("Por favor, Ingrese resultado en este segundo trayecto");
                 $("#resultado2do" + total2do).focus();
             } else if ($.trim($("#presupuesto2do" + total2do).val()) == '' || $.trim($("#presupuesto2do" + total2do).val()) == null) {
                 alert("Por favor, Ingrese presupuesto en este segundo trayecto");
                 $("#presupuesto2do" + total2do).focus();
             } else {
                 total2do = total2do + 1;
                 if ($("#remove12do")) {
                     $("#remove12do").remove();
                 }

                 html = '<tr id="oCampus2do' + total2do + '">';
                 html += '<td><input type="text" id="actividad2do' + total2do + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="herramienta2do' + total2do + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="resultado2do' + total2do + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td id="oRadiotr2do' + total2do + '"><input type="text" id="presupuesto2do' + total2do + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove12do" class="btn btn-danger" onclick="fRemove12do(' + total2do + ');" value="-"/></td></tr>';
                 $("#tableTrayecto2do").append(html);

             }
         }

         function add3ro() {
             if ($.trim($("#actividad3ro" + total3ro).val()) == '' || $.trim($("#actividad3ro" + total3ro).val()) == null) {
                 alert("Por favor, Ingrese actividades en este tercer trayecto");
                 $("#actividad3ro" + total3ro).focus();
             } else if ($.trim($("#herramienta3ro" + total3ro).val()) == '' || $.trim($("#herramienta3ro" + total3ro).val()) == null) {
                 alert("Por favor, Ingrese las herramientas en este tercer trayecto");
                 $("#herramienta3ro" + total3ro).focus();
             } else if ($.trim($("#resultado3ro" + total3ro).val()) == '' || $.trim($("#responsable3ro" + total3ro).val()) == null) {
                 alert("Por favor, Ingrese resultado en este tercer trayecto");
                 $("#resultado3ro" + total3ro).focus();
             } else if ($.trim($("#presupuesto3ro" + total3ro).val()) == '' || $.trim($("#presupuesto3ro" + total3ro).val()) == null) {
                 alert("Por favor, Ingrese presupuesto en este tercer trayecto");
                 $("#presupuesto3ro" + total3ro).focus();
             } else {
                 total3ro = total3ro + 1;
                 if ($("#remove13ro")) {
                     $("#remove13ro").remove();
                 }

                 html = '<tr id="oCampus3ro' + total3ro + '">';
                 html += '<td><input type="text" id="actividad3ro' + total3ro + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="herramienta3ro' + total3ro + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="resultado3ro' + total3ro + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td id="oRadiotr3ro' + total3ro + '"><input type="text" id="presupuesto3ro' + total3ro + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove13ro" class="btn btn-danger" onclick="fRemove13ro(' + total3ro + ');" value="-"/></td></tr>';
                 $("#tableTrayecto3ro").append(html);

             }
         }

         function add4to() {
             if ($.trim($("#actividad4to" + total4to).val()) == '' || $.trim($("#actividad4to" + total4to).val()) == null) {
                 alert("Por favor, Ingrese actividades en este tercer trayecto");
                 $("#actividad4to" + total4to).focus();
             } else if ($.trim($("#herramienta4to" + total4to).val()) == '' || $.trim($("#herramienta4to" + total4to).val()) == null) {
                 alert("Por favor, Ingrese las herramientas en este tercer trayecto");
                 $("#herramienta4to" + total4to).focus();
             } else if ($.trim($("#resultado4to" + total4to).val()) == '' || $.trim($("#responsable4to" + total4to).val()) == null) {
                 alert("Por favor, Ingrese resultado en este tercer trayecto");
                 $("#resultado4to" + total4to).focus();
             } else if ($.trim($("#presupuesto4to" + total4to).val()) == '' || $.trim($("#presupuesto4to" + total4to).val()) == null) {
                 alert("Por favor, Ingrese presupuesto en este tercer trayecto");
                 $("#presupuesto4to" + total4to).focus();
             } else {
                 total4to = total4to + 1;
                 if ($("#remove14to")) {
                     $("#remove14to").remove();
                 }

                 html = '<tr id="oCampus4to' + total4to + '">';
                 html += '<td><input type="text" id="actividad4to' + total4to + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="herramienta4to' + total4to + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td><input type="text" id="resultado4to' + total4to + '"  class="TextBox" style="width: 98%;"></td>';
                 html += '<td id="oRadiotr4to' + total4to + '"><input type="text" id="presupuesto4to' + total4to + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove14to" class="btn btn-danger" onclick="fRemove14to(' + total4to + ');" value="-"/></td></tr>';
                 $("#tableTrayecto4to").append(html);

             }
         }

         //function add5to() {
         //    if ($.trim($("#actividad5to" + total5to).val()) == '' || $.trim($("#actividad5to" + total5to).val()) == null) {
         //        alert("Por favor, Ingrese actividades en este tercer trayecto");
         //        $("#actividad5to" + total5to).focus();
         //    } else if ($.trim($("#herramienta5to" + total5to).val()) == '' || $.trim($("#herramienta5to" + total5to).val()) == null) {
         //        alert("Por favor, Ingrese las herramientas en este tercer trayecto");
         //        $("#herramienta5to" + total5to).focus();
         //    } else if ($.trim($("#responsable5to" + total5to).val()) == '' || $.trim($("#responsable5to" + total5to).val()) == null) {
         //        alert("Por favor, Ingrese responsable en este tercer trayecto");
         //        $("#responsable5to" + total5to).focus();
         //    } else if ($.trim($("#duracion5to" + total5to).val()) == '' || $.trim($("#duracion5to" + total5to).val()) == null) {
         //        alert("Por favor, Ingrese la duracion en este tercer trayecto");
         //        $("#duracion5to" + total5to).focus();
         //    } else if ($.trim($("#presupuesto5to" + total5to).val()) == '' || $.trim($("#presupuesto5to" + total5to).val()) == null) {
         //        alert("Por favor, Ingrese presupuesto en este tercer trayecto");
         //        $("#presupuesto5to" + total5to).focus();
         //    } else {
         //        total5to = total5to + 1;
         //        if ($("#remove15to")) {
         //            $("#remove15to").remove();
         //        }

         //        html = '<tr id="oCampus5to' + total5to + '">';
         //        html += '<td><input type="text" id="actividad5to' + total5to + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="herramienta5to' + total5to + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="responsable5to' + total5to + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="number" id="duracion5to' + total5to + '"  class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>';
         //        html += '<td id="oRadiotr5to' + total5to + '"><input type="text" id="presupuesto5to' + total5to + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove15to" class="btn btn-danger" onclick="fRemove15to(' + total5to + ');" value="-"/></td></tr>';
         //        $("#tableTrayecto5to").append(html);

         //    }
         //}

         //function add6to() {
         //    if ($.trim($("#actividad6to" + total6to).val()) == '' || $.trim($("#actividad6to" + total6to).val()) == null) {
         //        alert("Por favor, Ingrese actividades en este tercer trayecto");
         //        $("#actividad6to" + total6to).focus();
         //    } else if ($.trim($("#herramienta6to" + total6to).val()) == '' || $.trim($("#herramienta6to" + total6to).val()) == null) {
         //        alert("Por favor, Ingrese las herramientas en este tercer trayecto");
         //        $("#herramienta6to" + total6to).focus();
         //    } else if ($.trim($("#responsable6to" + total6to).val()) == '' || $.trim($("#responsable6to" + total6to).val()) == null) {
         //        alert("Por favor, Ingrese responsable en este tercer trayecto");
         //        $("#responsable6to" + total6to).focus();
         //    } else if ($.trim($("#duracion6to" + total6to).val()) == '' || $.trim($("#duracion6to" + total6to).val()) == null) {
         //        alert("Por favor, Ingrese la duracion en este tercer trayecto");
         //        $("#duracion6to" + total6to).focus();
         //    } else if ($.trim($("#presupuesto6to" + total6to).val()) == '' || $.trim($("#presupuesto6to" + total6to).val()) == null) {
         //        alert("Por favor, Ingrese presupuesto en este tercer trayecto");
         //        $("#presupuesto6to" + total6to).focus();
         //    } else {
         //        total6to = total6to + 1;
         //        if ($("#remove16to")) {
         //            $("#remove16to").remove();
         //        }

         //        html = '<tr id="oCampus6to' + total6to + '">';
         //        html += '<td><input type="text" id="actividad6to' + total6to + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="herramienta6to' + total6to + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="responsable6to' + total6to + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="number" id="duracion6to' + total6to + '"  class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>';
         //        html += '<td id="oRadiotr6to' + total6to + '"><input type="text" id="presupuesto6to' + total6to + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove16to" class="btn btn-danger" onclick="fRemove16to(' + total6to + ');" value="-"/></td></tr>';
         //        $("#tableTrayecto6to").append(html);

         //    }
         //}

         //function add7mo() {
         //    if ($.trim($("#actividad7mo" + total7mo).val()) == '' || $.trim($("#actividad7mo" + total7mo).val()) == null) {
         //        alert("Por favor, Ingrese actividades en este tercer trayecto");
         //        $("#actividad7mo" + total7mo).focus();
         //    } else if ($.trim($("#herramienta7mo" + total7mo).val()) == '' || $.trim($("#herramienta7mo" + total7mo).val()) == null) {
         //        alert("Por favor, Ingrese las herramientas en este tercer trayecto");
         //        $("#herramienta7mo" + total7mo).focus();
         //    } else if ($.trim($("#responsable7mo" + total7mo).val()) == '' || $.trim($("#responsable7mo" + total7mo).val()) == null) {
         //        alert("Por favor, Ingrese responsable en este tercer trayecto");
         //        $("#responsable7mo" + total7mo).focus();
         //    } else if ($.trim($("#duracion7mo" + total7mo).val()) == '' || $.trim($("#duracion7mo" + total7mo).val()) == null) {
         //        alert("Por favor, Ingrese la duracion en este tercer trayecto");
         //        $("#duracion7mo" + total7mo).focus();
         //    } else if ($.trim($("#presupuesto7mo" + total7mo).val()) == '' || $.trim($("#presupuesto7mo" + total7mo).val()) == null) {
         //        alert("Por favor, Ingrese presupuesto en este tercer trayecto");
         //        $("#presupuesto7mo" + total7mo).focus();
         //    } else {
         //        total7mo = total7mo + 1;
         //        if ($("#remove17mo")) {
         //            $("#remove17mo").remove();
         //        }

         //        html = '<tr id="oCampus7mo' + total7mo + '">';
         //        html += '<td><input type="text" id="actividad7mo' + total7mo + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="herramienta7mo' + total7mo + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="responsable7mo' + total7mo + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="number" id="duracion7mo' + total7mo + '"  class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>';
         //        html += '<td id="oRadiotr7mo' + total7mo + '"><input type="text" id="presupuesto7mo' + total7mo + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove17mo" class="btn btn-danger" onclick="fRemove17mo(' + total7mo + ');" value="-"/></td></tr>';
         //        $("#tableTrayecto7mo").append(html);

         //    }
         //}

         //function add8vo() {
         //    if ($.trim($("#actividad8vo" + total8vo).val()) == '' || $.trim($("#actividad8vo" + total8vo).val()) == null) {
         //        alert("Por favor, Ingrese actividades en este tercer trayecto");
         //        $("#actividad8vo" + total8vo).focus();
         //    } else if ($.trim($("#herramienta8vo" + total8vo).val()) == '' || $.trim($("#herramienta8vo" + total8vo).val()) == null) {
         //        alert("Por favor, Ingrese las herramientas en este tercer trayecto");
         //        $("#herramienta8vo" + total8vo).focus();
         //    } else if ($.trim($("#responsable8vo" + total8vo).val()) == '' || $.trim($("#responsable8vo" + total8vo).val()) == null) {
         //        alert("Por favor, Ingrese responsable en este tercer trayecto");
         //        $("#responsable8vo" + total8vo).focus();
         //    } else if ($.trim($("#duracion8vo" + total8vo).val()) == '' || $.trim($("#duracion8vo" + total8vo).val()) == null) {
         //        alert("Por favor, Ingrese la duracion en este tercer trayecto");
         //        $("#duracion8vo" + total8vo).focus();
         //    } else if ($.trim($("#presupuesto8vo" + total8vo).val()) == '' || $.trim($("#presupuesto8vo" + total8vo).val()) == null) {
         //        alert("Por favor, Ingrese presupuesto en este tercer trayecto");
         //        $("#presupuesto8vo" + total8vo).focus();
         //    } else {
         //        total8vo = total8vo + 1;
         //        if ($("#remove18vo")) {
         //            $("#remove18vo").remove();
         //        }

         //        html = '<tr id="oCampus8vo' + total8vo + '">';
         //        html += '<td><input type="text" id="actividad8vo' + total8vo + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="herramienta8vo' + total8vo + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="text" id="responsable8vo' + total8vo + '"  class="TextBox" style="width: 98%;"></td>';
         //        html += '<td><input type="number" id="duracion8vo' + total8vo + '"  class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>';
         //        html += '<td id="oRadiotr8vo' + total8vo + '"><input type="text" id="presupuesto8vo' + total8vo + '"  class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"  /><input type="button" id="remove18vo" class="btn btn-danger" onclick="fRemove18vo(' + total8vo + ');" value="-"/></td></tr>';
         //        $("#tableTrayecto8vo").append(html);

         //    }
         //}

         function fRemove1(data) {
             var ant = data - 1;
             total = total - 1;
             $("#oCampus" + data).remove();
             $("#oRadiotr" + ant).append('<input type="button" id="remove1" class="btn btn-danger" onclick="fRemove1('+ant+');" value="-"/>');
        
         }
         function fRemove12do(data) {
             var ant = data - 1;
             total2do = total2do - 1;
             $("#oCampus2do" + data).remove();
             $("#oRadiotr2do" + ant).append('<input type="button" id="remove12do" class="btn btn-danger" onclick="fRemove12do(' + ant + ');" value="-"/>');

         }

         function fRemove13ro(data) {
             var ant = data - 1;
             total3ro = total3ro - 1;
             $("#oCampus3ro" + data).remove();
             $("#oRadiotr3ro" + ant).append('<input type="button" id="remove13ro" class="btn btn-danger" onclick="fRemove13ro(' + ant + ');" value="-"/>');

         }

         function fRemove14to(data) {
             var ant = data - 1;
             total4to = total4to - 1;
             $("#oCampus4to" + data).remove();
             $("#oRadiotr4to" + ant).append('<input type="button" id="remove14to" class="btn btn-danger" onclick="fRemove14to(' + ant + ');" value="-"/>');

         }

         //function fRemove15to(data) {
         //    var ant = data - 1;
         //    total5to = total5to - 1;
         //    $("#oCampus5to" + data).remove();
         //    $("#oRadiotr5to" + ant).append('<input type="button" id="remove15to" class="btn btn-danger" onclick="fRemove15to(' + ant + ');" value="-"/>');

         //}

         //function fRemove16to(data) {
         //    var ant = data - 1;
         //    total6to = total6to - 1;
         //    $("#oCampus6to" + data).remove();
         //    $("#oRadiotr6to" + ant).append('<input type="button" id="remove16to" class="btn btn-danger" onclick="fRemove16to(' + ant + ');" value="-"/>');

         //}

         //function fRemove17mo(data) {
         //    var ant = data - 1;
         //    total7mo = total7mo - 1;
         //    $("#oCampus7mo" + data).remove();
         //    $("#oRadiotr7mo" + ant).append('<input type="button" id="remove17mo" class="btn btn-danger" onclick="fRemove17mo(' + ant + ');" value="-"/>');

         //}

         //function fRemove18vo(data) {
         //    var ant = data - 1;
         //    total8vo = total8vo - 1;
         //    $("#oCampus8vo" + data).remove();
         //    $("#oRadiotr8vo" + ant).append('<input type="button" id="remove18vo" class="btn btn-danger" onclick="fRemove18vo(' + ant + ');" value="-"/>');

         //}

         function isNumberKey(e) {
             var charCode = (e.which) ? e.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 75))
                 return false;
             return true;
         }

         function number_format(amount, decimals) {
             amount += ''; // por si pasan un numero en vez de un string
             amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto

             decimals = decimals || 0; // por si la variable no fue fue pasada

             // si no es un numero o es igual a cero retorno el mismo cero
             if (isNaN(amount) || amount === 0)
                 return parseFloat(0).toFixed(decimals);

             // si es mayor o menor que cero retorno el valor formateado como numero
             amount = '' + amount.toFixed(decimals);

             var amount_parts = amount.split('.'),
                 regexp = /(\d+)(\d{3})/;

             while (regexp.test(amount_parts[0]))
                 amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');

             return amount_parts.join('.');
         }
         

         function btnGuardar_Click(event) {

             var trayecto = [];
             var num = 1;
             var data = "";

             $("#tableTrayecto tbody tr").each(function () {
                 data = [$("#actividad" + num).val(), $("#herramienta" + num).val(), $("#resultado" + num).val(), $("#presupuesto" + num).val()];
                 trayecto.push(data);
                 num++;
             });
             console.log(trayecto);

             //2do bloque
             var trayecto2do = [];
             var num2do = 1;
             var data2do = "";

             $("#tableTrayecto2do tbody tr").each(function () {
                 data2do = [$("#actividad2do" + num2do).val(), $("#herramienta2do" + num2do).val(), $("#resultado2do" + num2do).val(), $("#presupuesto2do" + num2do).val()];
                 trayecto2do.push(data2do);
                 num2do++;
             });
             console.log(trayecto2do);

             //3ro bloque
             var trayecto3ro = [];
             var num3ro = 1;
             var data3ro = "";

             $("#tableTrayecto3ro tbody tr").each(function () {
                 data3ro = [$("#actividad3ro" + num3ro).val(), $("#herramienta3ro" + num3ro).val(), $("#resultado3ro" + num3ro).val(), $("#presupuesto3ro" + num3ro).val()];
                 trayecto3ro.push(data3ro);
                 num3ro++;
             });
             console.log(trayecto3ro);

             //4to bloque
             var trayecto4to = [];
             var num4to = 1;
             var data4to = "";

             $("#tableTrayecto4to tbody tr").each(function () {
                 data4to = [$("#actividad4to" + num4to).val(), $("#herramienta4to" + num4to).val(), $("#resultado4to" + num4to).val(), $("#presupuesto4to" + num4to).val()];
                 trayecto4to.push(data4to);
                 num4to++;
                
             });
             console.log(trayecto4to);

             //5to bloque
             //var trayecto5to = [];
             //var num5to = 1;
             //var data5to = "";

             //$("#tableTrayecto5to tbody tr").each(function () {
             //    data5to = [$("#actividad5to" + num5to).val(), $("#herramienta5to" + num5to).val(), $("#responsable5to" + num5to).val(), $("#duracion5to" + num5to).val(), $("#presupuesto5to" + num5to).val()];
             //    trayecto5to.push(data5to);
             //    num5to++;
             //});
             //console.log(trayecto5to);

             //6to bloque
             //var trayecto6to = [];
             //var num6to = 1;
             //var data6to = "";

             //$("#tableTrayecto6to tbody tr").each(function () {
             //    data6to = [$("#actividad6to" + num6to).val(), $("#herramienta6to" + num6to).val(), $("#responsable6to" + num6to).val(), $("#duracion6to" + num6to).val(), $("#presupuesto6to" + num6to).val()];
             //    trayecto6to.push(data6to);
             //    num6to++;
             //});
             //console.log(trayecto6to);

             //7mo bloque
             //var trayecto7mo = [];
             //var num7mo = 1;
             //var data7mo = "";

             //$("#tableTrayecto7mo tbody tr").each(function () {
             //    data7mo = [$("#actividad7mo" + num7mo).val(), $("#herramienta7mo" + num7mo).val(), $("#responsable7mo" + num7mo).val(), $("#duracion7mo" + num7mo).val(), $("#presupuesto7mo" + num7mo).val()];
             //    trayecto7mo.push(data7mo);
             //    num7mo++;
             //});
             //console.log(trayecto7mo);

             //8vo bloque
             //var trayecto8vo = [];
             //var num8vo = 1;
             //var data8vo = "";

             //$("#tableTrayecto8vo tbody tr").each(function () {
             //    data8vo = [$("#actividad8vo" + num8vo).val(), $("#herramienta8vo" + num8vo).val(), $("#responsable8vo" + num8vo).val(), $("#duracion8vo" + num8vo).val(), $("#presupuesto8vo" + num8vo).val()];
             //    trayecto8vo.push(data8vo);
             //    num8vo++;
             //});
             //console.log(trayecto8vo);

             if (event == 'insert')
             {
                
                 var jsonData = "{'codProyecto': '" + $("#grupoInvestigacion").val().toString() + "', 'trayecto1': '" + $("#trayecto1ro").val().toString() + "', 'trayecto2': '" + $("#trayecto2do").val().toString() + "', 'trayecto3': '" + $("#trayecto3ro").val().toString() + "', 'trayecto4': '" + $("#trayecto4to").val().toString() + "', 'conclusion1': '" + $("#conclusion1").val().toString() + "', 'conclusion2': '" + $("#conclusion2").val().toString() + "', 'conclusion3': '" + $("#conclusion3").val().toString() + "', 'conclusion4': '" + $("#conclusion4").val().toString() + "', 'dificultades': '" + $("#dificultades").val().toString() + "', 'fortalezas': '" + $("#fortalezas").val().toString() + "', 'caracteristicas': '" + $("#caracteristicas").val().toString() + "', 'acciones': '" + $("#acciones").val().toString() + "'}";
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/encabezado',
                     type: 'POST',
                     data: jsonData,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         codigo = response.d.split("@");

                         $.each(trayecto, function (index, element) {
                             var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";
                             $.ajax({
                                 url: 'estraunobitacoraseis.aspx/detalleBitacora6',
                                 type: 'POST',
                                 data: jsonData,
                                 contentType: 'application/json; charset=utf-8',
                                 dataType: 'JSON'
                             });
                         });

                         $.each(trayecto2do, function (index, element) {
                             var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";
                             $.ajax({
                                 url: 'estraunobitacoraseis.aspx/detalleBitacora6_2do',
                                 type: 'POST',
                                 data: jsonData,
                                 contentType: 'application/json; charset=utf-8',
                                 dataType: 'JSON'
                             });
                         });

                         $.each(trayecto3ro, function (index, element) {
                             var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";
                             $.ajax({
                                 url: 'estraunobitacoraseis.aspx/detalleBitacora6_3ro',
                                 type: 'POST',
                                 data: jsonData,
                                 contentType: 'application/json; charset=utf-8',
                                 dataType: 'JSON'
                             });
                         });

                         $.each(trayecto4to, function (index, element) {
                             var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";
                             $.ajax({
                                 url: 'estraunobitacoraseis.aspx/detalleBitacora6_4to',
                                 type: 'POST',
                                 data: jsonData,
                                 contentType: 'application/json; charset=utf-8',
                                 dataType: 'JSON'
                             });
                         });

                         //$.each(trayecto5to, function (index, element) {
                         //    var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";
                         //    $.ajax({
                         //        url: 'estraunobitacoraseis.aspx/detalleBitacora5_5to',
                         //        type: 'POST',
                         //        data: jsonData,
                         //        contentType: 'application/json; charset=utf-8',
                         //        dataType: 'JSON'
                         //    });
                         //});

                         //$.each(trayecto6to, function (index, element) {
                         //    var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";
                         //    $.ajax({
                         //        url: 'estraunobitacoraseis.aspx/detalleBitacora5_6to',
                         //        type: 'POST',
                         //        data: jsonData,
                         //        contentType: 'application/json; charset=utf-8',
                         //        dataType: 'JSON'
                         //    });
                         //});

                         //$.each(trayecto7mo, function (index, element) {
                         //    var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";
                         //    $.ajax({
                         //        url: 'estraunobitacoraseis.aspx/detalleBitacora5_7mo',
                         //        type: 'POST',
                         //        data: jsonData,
                         //        contentType: 'application/json; charset=utf-8',
                         //        dataType: 'JSON'
                         //    });
                         //});

                         //$.each(trayecto8vo, function (index, element) {
                         //    var jsonData = "{'codEstraBitacora':'" + codigo[0].toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";
                         //    $.ajax({
                         //        url: 'estraunobitacoraseis.aspx/detalleBitacora5_8vo',
                         //        type: 'POST',
                         //        data: jsonData,
                         //        contentType: 'application/json; charset=utf-8',
                         //        dataType: 'JSON'
                         //    });
                         //});

                     },
                     complete: function () {
                         alert("Datos almacenados exitosamente");
                         listadobitacora6();
                         reset();
                         //$("#form").hide();
                         //$("#table").fadeIn(500);
                         window.location.href = "estraunobitacoraseis.aspx?e=" + codigo[1] + "&m=" + codigo[2];
                     }
                 });
             } else if (event == 'update') {

                 //$("#tableTrayecto tbody tr").each(function (index) {

                 //    var actividad, herramienta, resultado, presupuesto;

                 //    $(this).children("td").each(function (index2) {
                 //        switch (index2) {
                 //            case 0: actividad = $(this).text(); break;
                 //            case 1: herramienta = $(this).text(); break;
                 //            case 2: resultado = $(this).text(); break;
                 //            case 3: presupuesto = $(this).text(); break;
                 //        }
                 //        alert(actividad + ' - ' + herramienta + ' - ' + resultado + ' - ' + presupuesto);
                 //    })

                 //});

                 var jsonData = "{'codigoinstrumento': '" + codigoinstrumento + "', 'trayecto1': '" + $("#trayecto1ro").val().toString() + "', 'trayecto2': '" + $("#trayecto2do").val().toString() + "', 'trayecto3': '" + $("#trayecto3ro").val().toString() + "', 'trayecto4': '" + $("#trayecto4to").val().toString() + "', 'conclusion1': '" + $("#conclusion1").val().toString() + "', 'conclusion2': '" + $("#conclusion2").val().toString() + "', 'conclusion3': '" + $("#conclusion3").val().toString() + "', 'conclusion4': '" + $("#conclusion4").val().toString() + "', 'dificultades': '" + $("#dificultades").val().toString() + "', 'fortalezas': '" + $("#fortalezas").val().toString() + "', 'caracteristicas': '" + $("#caracteristicas").val().toString() + "', 'acciones': '" + $("#acciones").val().toString() + "'}";
               
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/updateencabezado',
                     type: 'POST',
                     data: jsonData,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         var resp = response.d.split("@");

                         if (resp[0] === "update") {

                             eliminardetallesBitacora6(codigoinstrumento, "1", trayecto);
                             eliminardetallesBitacora6_2(codigoinstrumento, "2", trayecto2do);
                             eliminardetallesBitacora6_3(codigoinstrumento, "3", trayecto3ro);
                             eliminardetallesBitacora6_4(codigoinstrumento, "4", trayecto4to);
                             //eliminardetallesBitacora5_5(codigoinstrumento, "5", trayecto5to);
                             //eliminardetallesBitacora5_6(codigoinstrumento, "6", trayecto6to);
                             //eliminardetallesBitacora5_7(codigoinstrumento, "7", trayecto7mo);
                             //eliminardetallesBitacora5_8(codigoinstrumento, "8", trayecto8vo);

                         }

                     },
                     complete: function () {
                         alert("Datos editados exitosamente");
                         listadobitacora6();
                         reset();
                         //$("#form").hide();
                         //$("#table").fadeIn(500);
                         window.location.href = "estraunobitacoraseis.aspx?e=" + codigo[1] + "&m=" + codigo[2];
                     }
                 });
   
             }
            
         }

         function eliminardetallesBitacora6(codigoinstrumento, nodetalle, trayecto) {
             
             var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";
                
                 $.ajax({
                     url: 'estraunobitacoraseis.aspx/deletedetalleBitacora6',
                     type: 'POST',
                     data: jsonData,
                     contentType: 'application/json; charset=utf-8',
                     dataType: 'JSON',
                     success: function (response) {
                         var resp = response.d.split("@");
                         
                         $.each(trayecto, function (index, element) {
                             
                             var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";
                                 
                             $.ajax({
                                 url: 'estraunobitacoraseis.aspx/detalleBitacora6',
                                     type: 'POST',
                                     data: jsonData,
                                     contentType: 'application/json; charset=utf-8',

                                     dataType: 'JSON'
                                 });
                             });
                       
                     }
                 });
         }

         function eliminardetallesBitacora6_2(codigoinstrumento, nodetalle, trayecto2do) {

             var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

             $.ajax({
                 url: 'estraunobitacoraseis.aspx/deletedetalleBitacora6',
                 type: 'POST',
                 data: jsonData,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");

                     $.each(trayecto2do, function (index, element) {

                         var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";

                         $.ajax({
                             url: 'estraunobitacoraseis.aspx/detalleBitacora6_2do',
                             type: 'POST',
                             data: jsonData,
                             contentType: 'application/json; charset=utf-8',

                             dataType: 'JSON'
                         });
                     });

                 }
             });
         }

         function eliminardetallesBitacora6_3(codigoinstrumento, nodetalle,trayecto3ro) {

             var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

             $.ajax({
                 url: 'estraunobitacoraseis.aspx/deletedetalleBitacora6',
                 type: 'POST',
                 data: jsonData,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");

                     $.each(trayecto3ro, function (index, element) {

                         var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";  

                         $.ajax({
                             url: 'estraunobitacoraseis.aspx/detalleBitacora6_3ro',
                             type: 'POST',
                             data: jsonData,
                             contentType: 'application/json; charset=utf-8',

                             dataType: 'JSON'
                         });
                     });

                 }
             });
         }

         function eliminardetallesBitacora6_4(codigoinstrumento, nodetalle, trayecto4to) {

             var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

             $.ajax({
                 url: 'estraunobitacoraseis.aspx/deletedetalleBitacora6',
                 type: 'POST',
                 data: jsonData,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");

                     $.each(trayecto4to, function (index, element) {

                         var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'resultado':'" + element[2].toString() + "', 'presupuesto':'" + element[3].toString() + "'}";

                         $.ajax({
                             url: 'estraunobitacoraseis.aspx/detalleBitacora6_4to',
                             type: 'POST',
                             data: jsonData,
                             contentType: 'application/json; charset=utf-8',

                             dataType: 'JSON'
                         });
                     });

                 }
             });
         }

         //function eliminardetallesBitacora5_5(codigoinstrumento, nodetalle, trayecto5to) {

         //    var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

         //    $.ajax({
         //        url: 'estraunobitacoraseis.aspx/deletedetalleBitacora5',
         //        type: 'POST',
         //        data: jsonData,
         //        contentType: 'application/json; charset=utf-8',
         //        dataType: 'JSON',
         //        success: function (response) {
         //            var resp = response.d.split("@");

         //            $.each(trayecto5to, function (index, element) {

         //                var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";

         //                $.ajax({
         //                    url: 'estraunobitacoraseis.aspx/detalleBitacora5_5to',
         //                    type: 'POST',
         //                    data: jsonData,
         //                    contentType: 'application/json; charset=utf-8',

         //                    dataType: 'JSON'
         //                });
         //            });

         //        }
         //    });
         //}

         //function eliminardetallesBitacora5_6(codigoinstrumento, nodetalle, trayecto6to) {

         //    var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

         //    $.ajax({
         //        url: 'estraunobitacoraseis.aspx/deletedetalleBitacora5',
         //        type: 'POST',
         //        data: jsonData,
         //        contentType: 'application/json; charset=utf-8',
         //        dataType: 'JSON',
         //        success: function (response) {
         //            var resp = response.d.split("@");

         //            $.each(trayecto6to, function (index, element) {

         //                var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";

         //                $.ajax({
         //                    url: 'estraunobitacoraseis.aspx/detalleBitacora5_6to',
         //                    type: 'POST',
         //                    data: jsonData,
         //                    contentType: 'application/json; charset=utf-8',

         //                    dataType: 'JSON'
         //                });
         //            });

         //        }
         //    });
         //}

         //function eliminardetallesBitacora5_7(codigoinstrumento, nodetalle, trayecto7mo) {

         //    var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

         //    $.ajax({
         //        url: 'estraunobitacoraseis.aspx/deletedetalleBitacora5',
         //        type: 'POST',
         //        data: jsonData,
         //        contentType: 'application/json; charset=utf-8',
         //        dataType: 'JSON',
         //        success: function (response) {
         //            var resp = response.d.split("@");

         //            $.each(trayecto7mo, function (index, element) {

         //                var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";

         //                $.ajax({
         //                    url: 'estraunobitacoraseis.aspx/detalleBitacora5_7mo',
         //                    type: 'POST',
         //                    data: jsonData,
         //                    contentType: 'application/json; charset=utf-8',

         //                    dataType: 'JSON'
         //                });
         //            });

         //        }
         //    });
         //}

         //function eliminardetallesBitacora5_8(codigoinstrumento, nodetalle, trayecto8vo) {

         //    var jsonData = "{'codigoinstrumento':'" + codigoinstrumento.toString() + "', 'nodetalle':'" + nodetalle + "'}";

         //    $.ajax({
         //        url: 'estraunobitacoraseis.aspx/deletedetalleBitacora5',
         //        type: 'POST',
         //        data: jsonData,
         //        contentType: 'application/json; charset=utf-8',
         //        dataType: 'JSON',
         //        success: function (response) {
         //            var resp = response.d.split("@");

         //            $.each(trayecto8vo, function (index, element) {

         //                var jsonData = "{'codEstraBitacora':'" + codigoinstrumento.toString() + "', 'actividad':'" + element[0].toString() + "', 'herramienta':'" + element[1].toString() + "', 'responsable':'" + element[2].toString() + "', 'duracion':'" + element[3].toString() + "', 'presupuesto':'" + element[4].toString() + "'}";

         //                $.ajax({
         //                    url: 'estraunobitacoraseis.aspx/detalleBitacora5_8vo',
         //                    type: 'POST',
         //                    data: jsonData,
         //                    contentType: 'application/json; charset=utf-8',

         //                    dataType: 'JSON'
         //                });
         //            });

         //        }
         //    });
         //}

         function nuevabitacora() {
             cargarDepartamentosMagdalena();
             $("#table").hide();
             $("#form").fadeIn(500);
             $("#municipio").html("<option value=''>Seleccione municipio...</option>");
             $("#instituciones").html("<option value=''>Seleccione institucion...</option>");
             $("#sedes").html("<option value=''>Seleccione sede...</option>");
             $("#grupoInvestigacion").html("<option value=''>Seleccione grupo de investigación...</option>");
            
             $("#actividad1").val('');
             $("#herramienta1").val('');
             $("#resultado1").val('');
             $("#presupuesto1").val('');

             $("#actividad2do1").val('');
             $("#herramienta2do1").val('');
             $("#resultado2do1").val('');
             $("#presupuesto2do1").val('');

             $("#actividad3ro1").val('');
             $("#herramienta3ro1").val('');
             $("#resultado3ro1").val('');
             $("#presupuesto3ro1").val('');

             $("#actividad4to1").val('');
             $("#herramienta4to1").val('');
             $("#resultado4to1").val('');
             $("#presupuesto4to1").val('');

             //$("#actividad5to1").val('');
             //$("#herramienta5to1").val('');
             //$("#responsable5to1").val('');
             //$("#duracion5to1").val('');
             //$("#presupuesto5to1").val('');

             //$("#actividad6to1").val('');
             //$("#herramienta6to1").val('');
             //$("#responsable6to1").val('');
             //$("#duracion6to1").val('');
             //$("#presupuesto6to1").val('');

             //$("#actividad7mo1").val('');
             //$("#herramienta7mo1").val('');
             //$("#responsable7mo1").val('');
             //$("#duracion7mo1").val('');
             //$("#presupuesto7mo1").val('');

             //$("#actividad8vo1").val('');
             //$("#herramienta8vo1").val('');
             //$("#responsable8vo1").val('');
             //$("#duracion8vo1").val('');
             //$("#presupuesto8vo1").val('');

             $("#btnGuardar").attr('value', 'Guardar');
             $("#btnGuardar").attr('onclick', 'btnGuardar_Click(\'insert\')');

         }
         function resetTabla() {

           
             html += "<tr><th> Actividades desarrolladas</th>";
             html += "<th> Herramientas necesarias utilizadas </th>";
             html += "<th> Resultados </th>";
             html += "<th> Presupuesto utilizado </th>";
             html += "</tr> ";
             html += "<tr>";
             html += "<td><input type='text' id='actividad1'  class='TextBox' style='width: 98%;'></td>";
             html += "<td><input type='text' id='herramienta1'  class='TextBox' style='width: 98%;'></td>";
             html += "<td><input type='text' id='resultado1'  class='TextBox' style='width: 98%;'></td>";
             html += "<td ><input type='text' id='presupuesto1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
             html += "</td></tr>";
             $("#tableTrayecto").html(html);

           
            total = 1;

            html2do += "<tr><th> Actividades desarrolladas</th>";
            html2do += "<th> Herramientas necesarias utilizadas </th>";
            html2do += "<th> Resultados </th>";
            html2do += "<th> Presupuesto utilizado </th>";
            html2do += "</tr> ";
            html2do += "<tr>";
            html2do += "<td><input type='text' id='actividad2do1'  class='TextBox' style='width: 98%;'></td>";
            html2do += "<td><input type='text' id='herramienta2do1'  class='TextBox' style='width: 98%;'></td>";
            html2do += "<td><input type='text' id='resultado2do1'  class='TextBox' style='width: 98%;'></td>";
            html2do += "<td ><input type='text' id='presupuesto2do1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            html2do += "</td></tr>";
            $("#tableTrayecto2do").html(html2do);
            total2do = 1;

            html3ro += "<tr><th> Actividades desarrolladas</th>";
            html3ro += "<th> Herramientas necesarias utilizadas </th>";
            html3ro += "<th> Resultados </th>";
            html3ro += "<th> Presupuesto utilizado </th>";
            html3ro += "</tr> ";
            html3ro += "<tr>";
            html3ro += "<td><input type='text' id='actividad3ro1'  class='TextBox' style='width: 98%;'></td>";
            html3ro += "<td><input type='text' id='herramienta3ro1'  class='TextBox' style='width: 98%;'></td>";
            html3ro += "<td><input type='text' id='resultado3ro1'  class='TextBox' style='width: 98%;'></td>";
            html3ro += "<td ><input type='text' id='presupuesto3ro1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            html3ro += "</td></tr>";
            $("#tableTrayecto3ro").html(html3ro);

            total3ro = 1;

            html4to += "<tr><th> Actividades desarrolladas</th>";
            html4to += "<th> Herramientas necesarias utilizadas </th>";
            html4to += "<th> Resultados </th>";
            html4to += "<th> Presupuesto utilizado </th>";
            html4to += "</tr> ";
            html4to += "<tr>";
            html4to += "<td><input type='text' id='actividad4to1'  class='TextBox' style='width: 98%;'></td>";
            html4to += "<td><input type='text' id='herramienta4to1'  class='TextBox' style='width: 98%;'></td>";
            html4to += "<td><input type='text' id='resultado4to1'  class='TextBox' style='width: 98%;'></td>";
            html4to += "<td ><input type='text' id='presupuesto4to1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            html4to += "</td></tr>";
            $("#tableTrayecto4to").html(html4to);

            total4to = 1;

            //html5to += "<tr><th> Actividades</th>";
            //html5to += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            //html5to += "<th> Responsable de la actividad </th>";
            //html5to += "<th> Duración en meses </th>";
            //html5to += "<th> Presupuesto requerido </th>";
            //html5to += "</tr> ";
            //html5to += "<tr>";
            //html5to += "<td><input type='text' id='actividad5to1'  class='TextBox' style='width: 98%;'></td>";
            //html5to += "<td><input type='text' id='herramienta5to1'  class='TextBox' style='width: 98%;'></td>";
            //html5to += "<td><input type='text' id='responsable5to1'  class='TextBox' style='width: 98%;'></td>";
            //html5to += "<td><input type='number' id='duracion5to1' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
            //html5to += "<td ><input type='text' id='presupuesto5to1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            //html5to += "</td></tr>";
            //$("#tableTrayecto5to").html(html5to);

            //total5to = 1;

            //html6to += "<tr><th> Actividades</th>";
            //html6to += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            //html6to += "<th> Responsable de la actividad </th>";
            //html6to += "<th> Duración en meses </th>";
            //html6to += "<th> Presupuesto requerido </th>";
            //html6to += "</tr> ";
            //html6to += "<tr>";
            //html6to += "<td><input type='text' id='actividad6to1'  class='TextBox' style='width: 98%;'></td>";
            //html6to += "<td><input type='text' id='herramienta6to1'  class='TextBox' style='width: 98%;'></td>";
            //html6to += "<td><input type='text' id='responsable6to1'  class='TextBox' style='width: 98%;'></td>";
            //html6to += "<td><input type='number' id='duracion6to1' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
            //html6to += "<td ><input type='text' id='presupuesto6to1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            //html6to += "</td></tr>";
            //$("#tableTrayecto6to").html(html6to);

            //total6to = 1;

            //html7mo += "<tr><th> Actividades</th>";
            //html7mo += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            //html7mo += "<th> Responsable de la actividad </th>";
            //html7mo += "<th> Duración en meses </th>";
            //html7mo += "<th> Presupuesto requerido </th>";
            //html7mo += "</tr> ";
            //html7mo += "<tr>";
            //html7mo += "<td><input type='text' id='actividad7mo1'  class='TextBox' style='width: 98%;'></td>";
            //html7mo += "<td><input type='text' id='herramienta7mo1'  class='TextBox' style='width: 98%;'></td>";
            //html7mo += "<td><input type='text' id='responsable7mo1'  class='TextBox' style='width: 98%;'></td>";
            //html7mo += "<td><input type='number' id='duracion7mo1' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
            //html7mo += "<td ><input type='text' id='presupuesto7mo1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            //html7mo += "</td></tr>";
            //$("#tableTrayecto7mo").html(html7mo);

            //total7mo = 1;

            //html8vo += "<tr><th> Actividades</th>";
            //html8vo += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            //html8vo += "<th> Responsable de la actividad </th>";
            //html8vo += "<th> Duración en meses </th>";
            //html8vo += "<th> Presupuesto requerido </th>";
            //html8vo += "</tr> ";
            //html8vo += "<tr>";
            //html8vo += "<td><input type='text' id='actividad8vo1'  class='TextBox' style='width: 98%;'></td>";
            //html8vo += "<td><input type='text' id='herramienta8vo1'  class='TextBox' style='width: 98%;'></td>";
            //html8vo += "<td><input type='text' id='responsable8vo1'  class='TextBox' style='width: 98%;'></td>";
            //html8vo += "<td><input type='number' id='duracion8vo1' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
            //html8vo += "<td ><input type='text' id='presupuesto8vo1'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";
            //html8vo += "</td></tr>";
            //$("#tableTrayecto8vo").html(html8vo);

            //total8vo = 1;
         }
         function regresar() {
            

             $.ajax({
                 url: 'estraunobitacoraseis.aspx/regresar',
                 type: 'POST',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var resp = response.d.split("@");
                     $("#btnGuardar").attr('value', 'Guardar');
                     $("#btnGuardar").attr('onclick', 'btnGuardar_Click(\'insert\')');
                     window.location.href = "estraunobitacoraseis.aspx?e=" + resp[0] + "&m=" + resp[1];
                    
                 }
             });

         }
        function reset() {
            $("#table").fadeIn(500);
            $("#form").hide();
            $("#municipio").html("<option value=''>Seleccione municipio...</option>");
            $("#instituciones").html("<option value=''>Seleccione institucion...</option>");
            $("#sedes").html("<option value=''>Seleccione sede...</option>");
            $("#grupoInvestigacion").html("<option value=''>Seleccione grupo de investigación...</option>");
           
            $("#dificultades").val('');
            $("#caracteristicas").val('');
            $("#fortalezas").val('');
            $("#acciones").val('');

            $("#conclusion1").val('');
            $("#conclusion2").val('');
            $("#conclusion3").val('');
            $("#conclusion4").val('');
           

            $("#trayecto1ro").val('');
            $("#trayecto2do").val('');
            $("#trayecto3ro").val('');
            $("#trayecto4to").val('');
            //$("#trayecto5to").val('');
            //$("#trayecto6to").val('');
            //$("#trayecto7mo").val('');
            //$("#trayecto8vo").val('');

            for (var i = 1; i <= total; i++) {
                if (i == 1) {
                    $("#actividad" + (i)).val('');
                    $("#herramienta" + (i)).val('');
                    $("#resultado" + (i)).val('');
                    $("#presupuesto" + (i)).val('');
                    $("#remove" + (i)).remove();
                }
                else {
                    $("#oCampus" + i).remove();
                }

            }
           
            for (var i2do = 1; i2do <= total2do; i2do++) {
                if (i2do == 1) {
                    $("#actividad2do" + (i2do)).val('');
                    $("#herramienta2do" + (i2do)).val('');
                    $("#resultado2do" + (i2do)).val('');
                    $("#presupuesto2do" + (i2do)).val('');
                    $("#remove12do" + (i2do)).remove();
                }
                else {
                    $("#oCampus2do" + i2do).remove();
                }

            }

            for (var i3ro = 1; i3ro <= total3ro; i3ro++) {
                if (i3ro == 1) {
                    $("#actividad3ro" + (i3ro)).val('');
                    $("#herramienta3ro" + (i3ro)).val('');
                    $("#resultado3ro" + (i3ro)).val('');
                    $("#presupuesto3ro" + (i3ro)).val('');
                    $("#remove13ro" + (i3ro)).remove();
                }
                else {
                    $("#oCampus3ro" + i3ro).remove();
                }

            }

            for (var i4to = 1; i4to <= total4to; i4to++) {
                if (i4to == 1) {
                    $("#actividad4to" + (i4to)).val('');
                    $("#herramienta4to" + (i4to)).val('');
                    $("#resultado4to" + (i4to)).val('');
                    $("#presupuesto4to" + (i4to)).val('');
                    $("#remove4to1" + (i4to)).remove();
                }
                else {
                    $("#oCampus4to" + i4to).remove();
                }

            }

            //for (var i5to = 1; i5to <= total5to; i5to++) {
            //    if (i5to == 1) {
            //        $("#actividad5to" + (i5to)).val('');
            //        $("#herramienta5to" + (i5to)).val('');
            //        $("#responsable5to" + (i5to)).val('');
            //        $("#duracion5to" + (i5to)).val('');
            //        $("#presupuesto5to" + (i5to)).val('');
            //        $("#remove15to" + (i5to)).remove();
            //    }
            //    else {
            //        $("#oCampus5to" + i5to).remove();
            //    }

            //}

            //for (var i6to = 1; i6to <= total6to; i6to++) {
            //    if (i6to == 1) {
            //        $("#actividad6to" + (i6to)).val('');
            //        $("#herramienta6to" + (i6to)).val('');
            //        $("#responsable6to" + (i6to)).val('');
            //        $("#duracion6to" + (i6to)).val('');
            //        $("#presupuesto6to" + (i6to)).val('');
            //        $("#remove16to" + (i6to)).remove();
            //    }
            //    else {
            //        $("#oCampus6to" + i6to).remove();
            //    }

            //}

            //for (var i7mo = 1; i7mo <= total7mo; i7mo++) {
            //    if (i7mo == 1) {
            //        $("#actividad7mo" + (i7mo)).val('');
            //        $("#herramienta7mo" + (i7mo)).val('');
            //        $("#responsable7mo" + (i7mo)).val('');
            //        $("#duracion7mo" + (i7mo)).val('');
            //        $("#presupuesto7mo" + (i7mo)).val('');
            //        $("#remove17mo" + (i7mo)).remove();
            //    }
            //    else {
            //        $("#oCampus7mo" + i7mo).remove();
            //    }

            //}

            //for (var i8vo = 1; i8vo <= total8vo; i8vo++) {
            //    if (i8vo == 1) {
            //        $("#actividad8vo" + (i8vo)).val('');
            //        $("#herramienta8vo" + (i8vo)).val('');
            //        $("#responsable8vo" + (i8vo)).val('');
            //        $("#duracion8vo" + (i8vo)).val('');
            //        $("#presupuesto8vo" + (i8vo)).val('');
            //        $("#remove18vo").remove();
            //    }
            //    else {
            //        $("#oCampus8vo" + i8vo).remove();
            //    }

            //}

         }
        function loadSelectBitacoraSeis(codigo) {
            codigoinstrumento = codigo;
             var jsondata = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 type: 'POST',
                 url: 'estraunobitacoraseis.aspx/loadSelectBitacoraSeis',
                 data: jsondata,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {

                     var resp = response.d.split("@");
                     if (resp[0] === "loadSelect") {
                         $("#departamento").html(resp[1]);
                         $("#municipio").html(resp[2]);
                         $("#instituciones").html(resp[3]);
                         $("#sedes").html(resp[4]);
                         $("#grupoInvestigacion").html(resp[5]);
                         //cargaranio(codigo);
                     }
                 }
             });
         }

         function loadBitacora(codigo) {
             codestrategia = codigo;
             var data = "{'codigo':'" + codigo + "'}";
             $.ajax({
                 url: 'estraunobitacoraseis.aspx/loadBitacora',
                 type: 'POST',
                 data: data,
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'JSON',
                 success: function (response) {
                     var data = response.d.split("@");
                     $("#trayecto1ro").val(data[0]);
                     $("#conclusion1").val(data[1]);
                     $("#trayecto2do").val(data[2]);
                     $("#conclusion2").val(data[3]);
                     $("#trayecto3ro").val(data[4]);
                     $("#conclusion3").val(data[5]);
                     $("#trayecto4to").val(data[6]);
                     $("#conclusion4").val(data[7]);
                     $("#dificultades").val(data[8]);
                     $("#fortalezas").val(data[9]);
                     $("#caracteristicas").val(data[10]);
                     $("#acciones").val(data[11]);
                    
                     floadPrimerTrayecto(codigo);
                     floadSegundoTrayecto(codigo);
                     floadTercerTrayecto(codigo);
                     floadCuartoTrayecto(codigo);
                     //floadQuintoTrayecto(codigo);
                     //floadSextoTrayecto(codigo);
                     //floadSeptimoTrayecto(codigo);
                     //floadOctavoTrayecto(codigo);

                 }
             });
        
             $("#btnGuardar").attr('value', 'Actualizar');
             $("#btnGuardar").attr('onclick', 'btnGuardar_Click(\'update\')');
         }

         function floadPrimerTrayecto(codigoinstrumento) {
             total = 1;
             var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'estraunobitacoraseis.aspx/loadPrimerTrayecto',
                 data: jsonData,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     console.log(data);
                     var resp = data.d.split("@");
                     if (resp[0] === "mat") {
                         $("#tableTrayecto").html(resp[1]);
                         total = resp[2];
                         console.log("instrumento insertado exitosamente" + resp[1]);
                     } else {
                         $('#btn-guardar').val('Guardar');
                         $("#tableTrayecto").html(resp[1]);
                         //alert(data.d);
                         console.error(data.d);
                     }
                 }
             });
         }

         function floadSegundoTrayecto(codigoinstrumento) {
             total2do = 1;
             var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'estraunobitacoraseis.aspx/loadSegundoTrayecto',
                 data: jsonData,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     console.log(data);
                     var resp = data.d.split("@");
                     if (resp[0] === "mat") {
                         $("#tableTrayecto2do").html(resp[1]);
                         total2do = resp[2];
                         console.log("instrumento insertado exitosamente" + resp[1]);
                     } else {
                         $('#btn-guardar').val('Guardar');
                         $("#tableTrayecto2do").html(resp[1]);
                         //alert(data.d);
                         console.error(data.d);
                     }
                 }
             });
         }

         function floadTercerTrayecto(codigoinstrumento) {
             total3ro = 1;
             var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'estraunobitacoraseis.aspx/loadTercerTrayecto',
                 data: jsonData,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     console.log(data);
                     var resp = data.d.split("@");
                     if (resp[0] === "mat") {
                         $("#tableTrayecto3ro").html(resp[1]);
                         total3ro = resp[2];
                         console.log("instrumento insertado exitosamente" + resp[1]);
                     } else {
                         $('#btn-guardar').val('Guardar');
                         $("#tableTrayecto3ro").html(resp[1]);
                         //alert(data.d);
                         console.error(data.d);
                     }
                 }
             });
         }

         function floadCuartoTrayecto(codigoinstrumento) {
             total4to = 1;
             var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
             $.ajax({
                 type: 'POST',
                 url: 'estraunobitacoraseis.aspx/loadCuartoTrayecto',
                 data: jsonData,
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     console.log(data);
                     var resp = data.d.split("@");
                     if (resp[0] === "mat") {
                         $("#tableTrayecto4to").html(resp[1]);
                         total4to = resp[2];
                         console.log("instrumento insertado exitosamente" + resp[1]);
                     } else {
                         $('#btn-guardar').val('Guardar');
                         $("#tableTrayecto4to").html(resp[1]);
                         //alert(data.d);
                         console.error(data.d);
                     }
                 }
             });
         }

         //function floadQuintoTrayecto(codigoinstrumento) {
         //    total5to = 1;
         //    var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
         //    $.ajax({
         //        type: 'POST',
         //        url: 'estraunobitacoraseis.aspx/loadQuintoTrayecto',
         //        data: jsonData,
         //        contentType: "application/json; charset=utf-8",
         //        dataType: "json",
         //        success: function (data) {
         //            console.log(data);
         //            var resp = data.d.split("@");
         //            if (resp[0] === "mat") {
         //                $("#tableTrayecto5to").html(resp[1]);
         //                total5to = resp[2];
         //                console.log("instrumento insertado exitosamente" + resp[1]);
         //            } else {
         //                $('#btn-guardar').val('Guardar');
         //                $("#tableTrayecto5to").html(resp[1]);
         //                //alert(data.d);
         //                console.error(data.d);
         //            }
         //        }
         //    });
         //}

         //function floadSextoTrayecto(codigoinstrumento) {
         //    total6to = 1;
         //    var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
         //    $.ajax({
         //        type: 'POST',
         //        url: 'estraunobitacoraseis.aspx/loadSextoTrayecto',
         //        data: jsonData,
         //        contentType: "application/json; charset=utf-8",
         //        dataType: "json",
         //        success: function (data) {
         //            console.log(data);
         //            var resp = data.d.split("@");
         //            if (resp[0] === "mat") {
         //                $("#tableTrayecto6to").html(resp[1]);
         //                total6to = resp[2];
         //                console.log("instrumento insertado exitosamente" + resp[1]);
         //            } else {
         //                $('#btn-guardar').val('Guardar');
         //                $("#tableTrayecto6to").html(resp[1]);
         //                //alert(data.d);
         //                console.error(data.d);
         //            }
         //        }
         //    });
         //}

         //function floadSeptimoTrayecto(codigoinstrumento) {
         //    total7mo = 1;
         //    var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
         //    $.ajax({
         //        type: 'POST',
         //        url: 'estraunobitacoraseis.aspx/loadSeptimoTrayecto',
         //        data: jsonData,
         //        contentType: "application/json; charset=utf-8",
         //        dataType: "json",
         //        success: function (data) {
         //            console.log(data);
         //            var resp = data.d.split("@");
         //            if (resp[0] === "mat") {
         //                $("#tableTrayecto7mo").html(resp[1]);
         //                total7mo = resp[2];
         //                console.log("instrumento insertado exitosamente" + resp[1]);
         //            } else {
         //                $('#btn-guardar').val('Guardar');
         //                $("#tableTrayecto7mo").html(resp[1]);
         //                //alert(data.d);
         //                console.error(data.d);
         //            }
         //        }
         //    });
         //}

         //function floadOctavoTrayecto(codigoinstrumento) {
         //    total8vo = 1;
         //    var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
         //    $.ajax({
         //        type: 'POST',
         //        url: 'estraunobitacoraseis.aspx/loadOctavoTrayecto',
         //        data: jsonData,
         //        contentType: "application/json; charset=utf-8",
         //        dataType: "json",
         //        success: function (data) {
         //            console.log(data);
         //            var resp = data.d.split("@");
         //            if (resp[0] === "mat") {
         //                $("#tableTrayecto8vo").html(resp[1]);
         //                total8vo = resp[2];
         //                console.log("instrumento insertado exitosamente" + resp[1]);
         //            } else {
         //                $('#btn-guardar').val('Guardar');
         //                $("#tableTrayecto8vo").html(resp[1]);
         //                //alert(data.d);
         //                console.error(data.d);
         //            }
         //        }
         //    });
         //}

         function deleteBitacoraSeis(codigo) {
             if (confirm('¿Estás seguro de eliminar este registro? Recuerde que perderá los detalles y evidencias que tenga cargadas')) {
                 var jsonData = "{ 'codigo':'" + codigo + "'}";
                 $.ajax({
                     type: 'POST',
                     url: 'estraunobitacoraseis.aspx/deleteBitacoraSeis',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     data: jsonData,
                     success: function (json) {
                         var resp = json.d.split("@");
                         if (resp[0] === "delete") {
                             alert('Registro eliminado correctamente.');
                             listadobitacora6();
                         }
                     }
                 });
             }

         }
     </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Estrategía Nro 1 - Bitacora Nro 6: Recorrido de la trayectoria de indagación</h2><br />

    <div id="table">
         <a href="javascript:java(0)" id="nuevabitacora" class="btn btn-primary" style="float:right;" onclick="nuevabitacora();">Nueva bitácora</a>
         <br />
      <br />
     <fieldset >
         <table  class="mGridTesoreria">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Departamento</th>
                    <th>Municipio</th>
                    <th>Institución Educativa</th>
                    <th>Sede</th>
                    <th>Grupo<br/>Investigación</th>
                    <th>Fecha<br/>diligenciamiento</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbody">

            </tbody>
        </table>
    </fieldset>
    </div>

    <div id="form" style="display:none">

        <fieldset>
<legend>Agregar Bitacora</legend>
    <table border="0" style="padding: 10px; border-radius: 5px; background-color: #ECECEC;">
        <tr>
            <td colspan="3">
               <table>
                        <tr>
                             <td>Departamento</td>
                            <td><select id="departamento" class="TextBox"></select></td>
                        </tr>
                        <tr>
                            <td>Municipio</td>
                            <td><select id="municipio" class="TextBox"></select></td>
                        </tr>
                        <tr>
                            <td>Institución</td>
                            <td><select id="instituciones" class="TextBox"></select></td>
                        </tr>
                        <tr>
                        <td>Sede</td>
                        <td><select id="sedes" class="TextBox"></select></td>
                    </tr>
                    <tr>
                        <td>Grupo de investigación</td>
                        <td><select id="grupoInvestigacion" class="TextBox"></select></td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    <br />
   
    <fieldset>
        <p>En esta etapa el grupo de investigación recorren los diferentes segmentos de su trayectoria de indagación, proceso en el que van resolviendo las dudas y cuestionamientos que se les presenten. Sin embargo, sólo hasta al final, cuando unan la información que han ido recopilando durante el recorrido, podrán construir la respuesta al problema de investigación.</p>
        <table>
            <tr>
                <td>Trayecto / Meta a desarrollar: </td>
                <td><input type="text" class="TextBox" id="trayecto1ro"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto">
            <thead>
                <tr>
                    <th>Actividades a desarrollar</th>
                    <th>Herramientas necesarias utilizadas</th>
                    <th>Resultados</th>
                    <th>Presupuesto utilizado</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="resultado1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="presupuesto1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add();"/></td>
		    </tr>
		</table>

        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th colspan="4">Conclusiones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="4"><textarea id="conclusion1" class="TextBox" cols="95" rows="5"></textarea></td>
                </tr>
            </tbody>
        </table>

        <br />

        <table>
            <tr>
                <td>Trayecto / Meta a desarrollar: </td>
                <td><input type="text" class="TextBox" id="trayecto2do"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto2do">
            <thead>
                <tr>
                    <th>Actividades a desarrollar</th>
                    <th>Herramientas necesarias utilizadas</th>
                    <th>Resultados</th>
                    <th>Presupuesto utilizado</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad2do1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta2do1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="resultado2do1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="presupuesto2do1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add2do();"/></td>
		    </tr>
		</table>
           <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th colspan="4">Conclusiones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="4"><textarea id="conclusion2" class="TextBox" cols="95" rows="5"></textarea></td>
                </tr>
            </tbody>
        </table>
        <br />

        <table>
            <tr>
                <td>Trayecto / Meta a desarrollar: </td>
                <td><input type="text" class="TextBox" id="trayecto3ro"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto3ro">
            <thead>
                <tr>
                    <th>Actividades a desarrollar</th>
                    <th>Herramientas necesarias utilizadas</th>
                    <th>Resultados</th>
                    <th>Presupuesto utilizado</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad3ro1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta3ro1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="resultado3ro1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="presupuesto3ro1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add3ro();"/></td>
		    </tr>
		</table>
        <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th colspan="4">Conclusiones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="4"><textarea id="conclusion3" class="TextBox" cols="95" rows="5"></textarea></td>
                </tr>
            </tbody>
        </table>
         <br />

        <table>
            <tr>
               <td>Trayecto / Meta a desarrollar: </td>
                <td><input type="text" class="TextBox" id="trayecto4to"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto4to">
            <thead>
                <tr>
                    <th>Actividades a desarrollar</th>
                    <th>Herramientas necesarias utilizadas</th>
                    <th>Resultados</th>
                    <th>Presupuesto utilizado</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad4to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta4to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="resultado4to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="presupuesto4to1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add4to();"/></td>
		    </tr>
		</table>
         <table class="mGridTesoreria">
            <thead>
                <tr>
                    <th colspan="4">Conclusiones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="4"><textarea id="conclusion4" class="TextBox" cols="95" rows="5"></textarea></td>
                </tr>
            </tbody>
        </table>
         <br />

      <%--  <table>
            <tr>
                <td>Nombre del quinto trayecto de indagación: </td>
                <td><input type="text" class="TextBox" id="trayectoIndagacion5to"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto5to">
            <thead>
                <tr>
                    <th>Actividades</th>
                    <th>Herramientas necesarias para desarrollar la actividad</th>
                    <th>Responsable de la actividad</th>
                    <th>Duración en meses</th>
                    <th>Presupuesto requerido</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad5to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta5to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="responsable5to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="number" id="duracion5to1" class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>
                    <td><input type="text" id="presupuesto5to1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add5to();"/></td>
		    </tr>
		</table>

         <br />

        <table>
            <tr>
                <td>Nombre del sexto trayecto de indagación: </td>
                <td><input type="text" class="TextBox" id="trayectoIndagacion6to"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto6to">
            <thead>
                <tr>
                    <th>Actividades</th>
                    <th>Herramientas necesarias para desarrollar la actividad</th>
                    <th>Responsable de la actividad</th>
                    <th>Duración en meses</th>
                    <th>Presupuesto requerido</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad6to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta6to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="responsable6to1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="number" id="duracion6to1" class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>
                    <td><input type="text" id="presupuesto6to1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add6to();"/></td>
		    </tr>
		</table>

         <br />

        <table>
            <tr>
                <td>Nombre del séptimo trayecto de indagación: </td>
                <td><input type="text" class="TextBox" id="trayectoIndagacion7mo"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto7mo">
            <thead>
                <tr>
                    <th>Actividades</th>
                    <th>Herramientas necesarias para desarrollar la actividad</th>
                    <th>Responsable de la actividad</th>
                    <th>Duración en meses</th>
                    <th>Presupuesto requerido</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad7mo1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta7mo1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="responsable7mo1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="number" id="duracion7mo1" class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>
                    <td><input type="text" id="presupuesto7mo1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add7mo();"/></td>
		    </tr>
		</table>

         <br />

        <table>
            <tr>
                <td>Nombre del octavo trayecto de indagación: </td>
                <td><input type="text" class="TextBox" id="trayectoIndagacion8vo"/></td>
            </tr>
        </table>
        <br />
        <table class="mGridTesoreria" id="tableTrayecto8vo">
            <thead>
                <tr>
                    <th>Actividades</th>
                    <th>Herramientas necesarias para desarrollar la actividad</th>
                    <th>Responsable de la actividad</th>
                    <th>Duración en meses</th>
                    <th>Presupuesto requerido</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><input type="text" id="actividad8vo1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="herramienta8vo1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="text" id="responsable8vo1" class="TextBox" style="width: 98%;"/></td>
                    <td><input type="number" id="duracion8vo1" class="TextBox" style="width: 98%;" min="0" onkeypress="return isNumberKey(event);"/></td>
                    <td><input type="text" id="presupuesto8vo1" class="TextBox" style="width: 98%;" onkeypress="return isNumberKey(event);"/></td>
                </tr>
            </tbody>
            
        </table>
        <table>
		    <tr>
				<td colspan="3"> <input type="button" value=" + Añadir mas" class="btn btn-success" onclick="add8vo();"/></td>
		    </tr>
		</table>--%>

        <p>Aquí deben escribir los sentimientos del grupo, las dificultades y logros obtenidos en cada trayecto del recorrido teniendo en cuenta las actividades realizadas.</p>
        <center><p><b>PARA EL MAESTRO ACOMPAÑANTE/COINVESTIGADOR:</b></p></center>
        <p>Describir las dificultades que se presentaron en el grupo para recorrer la trayectoria de indagación.</p>
        <textarea  cols="200" rows="5" style="width:100%;" id="dificultades"></textarea>

        <p>Describir las fortalezas del grupo de investigación para tomar decisiones sobre el recorrido de las trayectorias y argumentarlas.</p>
        <textarea  cols="200" rows="5" style="width:100%;" id="fortalezas"></textarea>

        <p>Después de hacer la trayectoria de indagación, cuáles serán las características del espíritu científico que se fomenta desde el proyecto.</p>
        <textarea  cols="200" rows="5" style="width:100%;" id="caracteristicas"></textarea>

        <p>Cuáles son las acciones del recorrido de la trayectoria de indagación que fomenta cada una de estas capacidades: sociales, cognitivas, comunicativas y científicas y como se manifiestan en los miembros del grupo.</p>
        <textarea  cols="200" rows="5" style="width:100%;" id="acciones"></textarea>
    </fieldset>
</fieldset>
        <center> 
            <input type="button" class="btn btn-success" value="Guardar" id="btnGuardar" onclick="btnGuardar_Click('insert');" />
            <input type="button" class="btn btn-primary" value="Regresar" id="btnRegresar" onclick="regresar();" />
        </center>
    </div>
    
    
</asp:Content>

