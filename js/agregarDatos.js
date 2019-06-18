function validar(txt, e, tp)
{
  
    if (document.getElementById('MainContent_rbInvestigacionDocente_0').checked) {
            alert("guarda 0");
        }
        else
        {
            alert("elimina 0");
        }

    
  

   

   
            //if (e.which == 13 || tp=="1")
            //{
            //    var codestumatricula = txt.parentNode.parentNode.childNodes[2].textContent;
            //    var ddProceso = document.getElementById("MainContent_dropProcesoEval");
            //    var codProceso = ddProceso.options[ddProceso.selectedIndex].value;
            //    var codSubProceso;
            //    var ddSubProceso = document.getElementById("MainContent_dropSubProcesoEval");
            //    if (ddSubProceso.length == 0)
            //    {
            //        codSubProceso = "";
            //    }
            //    else
            //    {
            //        codSubProceso = ddSubProceso.options[ddSubProceso.selectedIndex].value;
            //    }
            //    var codPeriodo = (document.getElementById('MainContent_lblCodPeriodo').textContent);
            //    var codGradosAsig = (document.getElementById('MainContent_lblCodGradosAsig').textContent);
            //    var codUsuario = (document.getElementById('MainContent_lblCodUsuario').textContent);

            //    var valormax = (document.getElementById('MainContent_Labelmax').textContent);
            //    var valormin = (document.getElementById('MainContent_Labelmin').textContent);

            //    var nroEstudiantes = document.getElementById("MainContent_lblNroEstudiantes");
            //    var intNroEstudiantes = parseInt(nroEstudiantes.textContent);

            //    var longitudId = txt.id.length;
            //    var resnum;
            //    var res;
            //    var numcodnota;
            //    if (longitudId == 32)
            //    {
            //        var str = txt.id;
            //        numcodnota = str.substring(29);
            //        res = str.substring(0, 31);
            //        resnum = str.substring(31);
            //        resnum = parseInt(resnum);
            //        resnum = resnum+1;
            //    }
            //    else if (longitudId == 33)
            //    {
            //        var str = txt.id;
            //        numcodnota = str.substring(29);
            //        var split = numcodnota.split("_");
            //        if (split[0].length == "1")
            //        {
            //            res = str.substring(0, 31);
            //            resnum = str.substring(31);
            //            resnum = parseInt(resnum);
            //            resnum = resnum + 1;
            //        }
            //        else if (split[0].length == "2")
            //        {
            //            res = str.substring(0, 32);
            //            resnum = str.substring(32);
            //            resnum = parseInt(resnum);
            //            resnum = resnum + 1;
            //        }
              
            //    }
            //    else if (longitudId == 34)
            //    {
            //        var str = txt.id;
            //        numcodnota = str.substring(29);
            //        res = str.substring(0, 32);
            //        resnum = str.substring(32);
            //        resnum = parseInt(resnum);
            //        resnum = resnum + 1;
            //    }

            //    if (resnum >= intNroEstudiantes)
            //    {
            //        var concat = res + "" + 0;
            //    }
            //    else
            //    {
            //        var concat = res + "" + resnum;
            //    }
              
            //    var labelnota = "MainContent_GridNotas_lblCodNota";
            //    var labeldef = "MainContent_GridNotas_lblCodDefinicion";
            //    var codnota = document.getElementById(labelnota + "" + numcodnota);
            //    var coddefinicion = document.getElementById(labeldef + "" + numcodnota);
            //    if (codnota.textContent != "")
            //    {
            //        //ActualizarNota
            //        if (txt.value != "")
            //        {
            //            calcula(valormax, valormin, txt.value, txt.id, concat, tp, codestumatricula, codGradosAsig, codPeriodo, codProceso, codSubProceso, coddefinicion.textContent, "actualizar", codUsuario, codnota);
            //        }
            //        else
            //        {
            //            buscarNota(codnota.textContent, txt.id);
            //            if (tp == "0")
            //            {
            //                var destino = (document.getElementById(concat));
            //                destino.focus();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //Guardar nota
            //        if (txt.value != "")
            //        {
            //            calcula(valormax, valormin, txt.value, txt.id, concat, tp, codestumatricula, codGradosAsig, codPeriodo, codProceso, codSubProceso, coddefinicion.textContent, "guardar", codUsuario, codnota);
            //        }
            //        else
            //        {
            //            if (tp == "0")
            //            {
            //                var destino = (document.getElementById(concat));
            //                destino.focus();
            //            }
            //        }
            //    }
            //    return false;
            //}            
}

function calcula(vmax, vmin, valor, origen, destino, tp, codestumatricula, codgradosasig, codperiodo, codproceso, codsubproceso, coddeficionnota, operacion, codusuario, codnota)
{
    var vma = parseFloat(vmax);
    var vmi = parseFloat(vmin);
    var va = parseFloat(valor);
    if (va >= vmi && va <= vma)
    {
        if (operacion == "guardar")
        {
            guardarNota(codestumatricula, codgradosasig, codperiodo, codproceso, codsubproceso, coddeficionnota, va, origen,codnota);
        }
        else if (operacion == "actualizar")
        {
            actualizarNota(codnota.textContent, va, origen, codusuario);
        }
        
        if (tp == "0")
        {
            var text1 = (document.getElementById(destino));
            text1.focus();
        }
        var text2 = (document.getElementById(origen));
        if (text2.style.backgroundColor == '#ff9999')
        {
            text2.style.backgroundColor = 'white';
        }
    }
    else
    {
        alert('ERROR:La calificación es de: ' + vmi + ' a ' + vma);
        var text1 = (document.getElementById(origen));
        text1.focus();
        text1.value = '';
        text1.style.backgroundColor = '#ff9999';
    }
}

function guardarNota(codestumatricula,codgradosasig,codperiodo,codproceso,codsubproceso,coddeficionnota,nota,origen,codnota)
{
           $.ajax({
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'evalnotasasignar.aspx/InsertMethod',
                data: "{'estu':'" + codestumatricula + "', 'asig':'" + codgradosasig + "','per':'" + codperiodo + "','pro':'" + codproceso + "','sub':'" + codsubproceso + "','dfn':'" + coddeficionnota + "','nota':'" + nota + "'}",
                async: false,
                success: function (response)
                {
                    if (response.d != "-1")
                    {
                        codnota.textContent = response.d;
                        var text2 = (document.getElementById(origen));
                        text2.style.backgroundColor = '#ccffcc';
                    }
                    else
                    {
                        document.getElementById("demoRespuesta").innerHTML = response.d;
                        var text2 = (document.getElementById(origen));
                        text2.style.backgroundColor = '#ff9999';
                    }
                  
                    
                },
                error: function (response)
                {
                    var text2 = (document.getElementById(origen));
                    text2.style.backgroundColor = '#ff9999';
                }
            });
       
   
}

function actualizarNota(codnota, nota, origen, codusuario)
{
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'evalnotasasignar.aspx/UpdateMethod',
        data: "{'nota':'" + nota + "', 'codnota':'" + codnota + "','codusuario':'" + codusuario + "'}",
        async: false,
        success: function (response)
        {
            if (response.d == "Nota actualizada exitoxamente.")
            {
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#FFFF8A';
            }
            else if (response.d == "nada.")
            {
               
            }
            else
            {
                document.getElementById("demoRespuesta").innerHTML = response.d;
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#ff9999';
            }

        },
        error: function (response) {
            var text2 = (document.getElementById(origen));
            text2.style.backgroundColor = '#ff9999';
        }
    });


}

function buscarNota(codnota,origen) {
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'evalnotasasignar.aspx/FindMethod',
        data: "{'codnota':'" + codnota + "'}",
        async: false,
        success: function (response)
        {
            if (response.d != "")
            {
                var text2 = (document.getElementById(origen));
                text2.value = response.d;
            }
            else
            {
                document.getElementById("demoRespuesta").innerHTML = "Nota no encontrada.";
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#ff9999';
            }

        },
        error: function (response)
        {
            var text2 = (document.getElementById(origen));
            text2.style.backgroundColor = '#ff9999';
        }
    });


}

function calcularGrilla()
{
    var nroEstudiantes = document.getElementById("MainContent_lblNroEstudiantes");
    var nroDefiniciones = document.getElementById("MainContent_lblND");
    var nroDecimales = document.getElementById("MainContent_lblDecimales");
    var intNroEstudiantes = parseInt(nroEstudiantes.textContent);
    var intNroDefiniciones = parseInt(nroDefiniciones.textContent);
    var intNroDecimales = parseInt(nroDecimales.textContent);
    var i;
    for (i = 0; i < intNroEstudiantes; i++)
    {
        var j;
        var sum = 0;
        var count=0;
        for (j = 1; j < (intNroDefiniciones+1); j++)
        {
            var txt = document.getElementById("MainContent_GridNotas_txtNota" + j + "_" + i + "");
            if (txt.value != "")
            {
                sum += parseFloat(txt.value);
                count++;
            }
        }
        var txtCalculo = document.getElementById("MainContent_GridNotas_txtCalculo_" + i + "");
        txtCalculo.value = redondeo(sum / count, intNroDecimales);
    }
    return false;
}

function redondeo(numero, decimales)
{
    var flotante = parseFloat(numero);
    var resultado = Math.round(flotante * Math.pow(10, decimales)) / Math.pow(10, decimales);
    return resultado;
}

  
function nose2(txt, e, tp)
{
    if (e.which == 13 || tp == "1")
    {
        var codestumatricula = txt.parentNode.parentNode.childNodes[2].textContent;
        var ddProceso = document.getElementById("MainContent_dropProcesoEval");
        var codProceso = ddProceso.options[ddProceso.selectedIndex].value;
        var codSubProceso;
        var ddSubProceso = document.getElementById("MainContent_dropSubProcesoEval");
        if (ddSubProceso.length == 0)
        {
            codSubProceso = "";
        }
        else
        {
            codSubProceso = ddSubProceso.options[ddSubProceso.selectedIndex].value;
        }
        var codPeriodo = (document.getElementById('MainContent_lblCodPeriodo').textContent);
        var codNivelesGrupo = (document.getElementById('MainContent_lblCodNivelesGrupo').textContent);
        var codUsuario = (document.getElementById('MainContent_lblCodUsuario').textContent);

        var valormax = (document.getElementById('MainContent_Labelmax').textContent);
        var valormin = (document.getElementById('MainContent_Labelmin').textContent);

        var nroEstudiantes = document.getElementById("MainContent_lblNroEstudiantes");
        var intNroEstudiantes = parseInt(nroEstudiantes.textContent);

        var longitudId = txt.id.length;
        var resnum;
        var res;
        var numcodnota;
        if (longitudId == 32)
        {
            var str = txt.id;
            numcodnota = str.substring(29);
            res = str.substring(0, 31);
            resnum = str.substring(31);
            resnum = parseInt(resnum);
            resnum = resnum + 1;
        }
        else if (longitudId == 33)
        {
            var str = txt.id;
            numcodnota = str.substring(29);
            var split = numcodnota.split("_");
            if (split[0].length == "1")
            {
                res = str.substring(0, 31);
                resnum = str.substring(31);
                resnum = parseInt(resnum);
                resnum = resnum + 1;
            }
            else if (split[0].length == "2")
            {
                res = str.substring(0, 32);
                resnum = str.substring(32);
                resnum = parseInt(resnum);
                resnum = resnum + 1;
            }

        }
        else if (longitudId == 34)
        {
            var str = txt.id;
            numcodnota = str.substring(29);
            res = str.substring(0, 32);
            resnum = str.substring(32);
            resnum = parseInt(resnum);
            resnum = resnum + 1;
        }

        if (resnum >= intNroEstudiantes)
        {
            var concat = res + "" + 0;
        }
        else
        {
            var concat = res + "" + resnum;
        }

        var labelnota = "MainContent_GridNotas_lblCodNota";
        var labeldef = "MainContent_GridNotas_lblCodDefinicion";
        var codnota = document.getElementById(labelnota + "" + numcodnota);
        var coddefinicion = document.getElementById(labeldef + "" + numcodnota);
        if (codnota.textContent != "")
        {
            //ActualizarNota
            if (txt.value != "")
            {
                calculaIngles(valormax, valormin, txt.value, txt.id, concat, tp, codestumatricula, codNivelesGrupo, codPeriodo, codProceso, codSubProceso, coddefinicion.textContent, "actualizar", codUsuario, codnota);
            }
            else
            {
                buscarNotaIngles(codnota.textContent, txt.id);
                if (tp == "0")
                {
                    var destino = (document.getElementById(concat));
                    destino.focus();
                }
            }
        }
        else
        {
            //Guardar nota
            if (txt.value != "")
            {
                calculaIngles(valormax, valormin, txt.value, txt.id, concat, tp, codestumatricula, codNivelesGrupo, codPeriodo, codProceso, codSubProceso, coddefinicion.textContent, "guardar", codUsuario, codnota);
            }
            else
            {
                if (tp == "0")
                {
                    var destino = (document.getElementById(concat));
                    destino.focus();
                }
            }
        }
        return false;
    }
}

function calculaIngles(vmax, vmin, valor, origen, destino, tp, codestumatricula, codnivelesgrupo, codperiodo, codproceso, codsubproceso, coddeficionnota, operacion, codusuario, codnota)
{
    var vma = parseFloat(vmax);
    var vmi = parseFloat(vmin);
    var va = parseFloat(valor);
    if (va >= vmi && va <= vma)
    {
        if (operacion == "guardar")
        {
            guardarNotaIngles(codestumatricula, codnivelesgrupo, codperiodo, codproceso, codsubproceso, coddeficionnota, va, origen, codnota);
        }
        else if (operacion == "actualizar")
        {
            actualizarNotaIngles(codnota.textContent, va, origen, codusuario);
        }

        if (tp == "0")
        {
            var text1 = (document.getElementById(destino));
            text1.focus();
        }
        var text2 = (document.getElementById(origen));
        if (text2.style.backgroundColor == '#ff9999')
        {
            text2.style.backgroundColor = 'white';
        }
    }
    else
    {
        alert('ERROR:La calificación es de: ' + vmi + ' a ' + vma);
        var text1 = (document.getElementById(origen));
        text1.focus();
        text1.value = '';
        text1.style.backgroundColor = '#ff9999';
    }
}

function guardarNotaIngles(codestumatricula, codnivelesgrupo, codperiodo, codproceso, codsubproceso, coddeficionnota, nota, origen, codnota)
{
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'ingevalnotasasignar.aspx/InsertMethod',
        data: "{'estu':'" + codestumatricula + "', 'nivgrupo':'" + codnivelesgrupo + "','per':'" + codperiodo + "','pro':'" + codproceso + "','sub':'" + codsubproceso + "','dfn':'" + coddeficionnota + "','nota':'" + nota + "'}",
        async: false,
        success: function (response)
        {
            if (response.d != "-1")
            {
                codnota.textContent = response.d;
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#ccffcc';
            }
            else
            {
                document.getElementById("demoRespuesta").innerHTML = response.d;
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#ff9999';
            }
        },
        error: function (response)
        {
            //var text2 = (document.getElementById(origen));
            //text2.style.backgroundColor = '#ff9999';
        }
    });


}

function actualizarNotaIngles(codnota, nota, origen, codusuario)
{
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'ingevalnotasasignar.aspx/UpdateMethod',
        data: "{'nota':'" + nota + "', 'codnota':'" + codnota + "','codusuario':'" + codusuario + "'}",
        async: false,
        success: function (response)
        {
            if (response.d == "Nota actualizada exitoxamente.")
            {
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#FFFF8A';
            }
            else if (response.d == "nada.")
            {

            }
            else
            {
                document.getElementById("demoRespuesta").innerHTML = response.d;
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#ff9999';
            }

        },
        error: function (response)
        {
            var text2 = (document.getElementById(origen));
            text2.style.backgroundColor = '#ff9999';
        }
    });


}

function buscarNotaIngles(codnota, origen)
{
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: 'ingevalnotasasignar.aspx/FindMethod',
        data: "{'codnota':'" + codnota + "'}",
        async: false,
        success: function (response)
        {
            if (response.d != "")
            {
                var text2 = (document.getElementById(origen));
                text2.value = response.d;
            }
            else
            {
                document.getElementById("demoRespuesta").innerHTML = "Nota no encontrada.";
                var text2 = (document.getElementById(origen));
                text2.style.backgroundColor = '#ff9999';
            }

        },
        error: function (response)
        {
            var text2 = (document.getElementById(origen));
            text2.style.backgroundColor = '#ff9999';
        }
    });


}