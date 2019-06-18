function time(txt, e, tp)
{
    var estado;
    if (document.getElementById('MainContent_chkActivarTiempo').checked) {
        estado = "Si";
    }
    else {
        estado = "No";
    }

    actualizaEstadoTiempo(estado);
           
}

function actualizaEstadoTiempo(estado)
{
    var jsonData = '{ "tiempoenlineabase":"' + estado + '"}';
    $.ajax({
        type: "POST",
        url: "lineabaseconfi.aspx/ActualizarEstadoTiempoEjecucion",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $("#Chkmensajes").html(json.d);
                setTimeout(function () { $("#Chkmensajes").fadeOut(1500); }, 1500);
            //alert(json.d);
            //}
            
        }
    });

}