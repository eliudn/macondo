function nose(txt) {

    if (txt.id == "MainContent_txtSm")
    {
        var parametro = (document.getElementById('MainContent_lblSM').textContent);
        if (parseFloat(txt.value) >= parametro)
        {
            $('#imgSM').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgSM').prepend('<img id="imgSM" src="Imagenes/ok.png" Width="24px" Height="24px" />');
       } else {
            $('#imgSM').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgSM').prepend('<img id="imgSM" src="Imagenes/error3.png" Width="24px" Height="24px" />');
         }

    }
    else if (txt.id == "MainContent_txtCCQ")
    {
        var parametro = (document.getElementById('MainContent_lblCCQ').textContent);
        if (parseFloat(txt.value) >= parametro) {
            $('#imgCCQ').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgCCQ').prepend('<img id="imgCCQ" src="Imagenes/ok.png" Width="24px" Height="24px" />');
        } else {
            $('#imgCCQ').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgCCQ').prepend('<img id="imgCCQ" src="Imagenes/error3.png" Width="24px" Height="24px" />');
        }
    }
    else if (txt.id == "MainContent_txtTtlNodo") {
        var parametro = (document.getElementById('MainContent_lblTTLN').textContent);
        if (parseFloat(txt.value) <= parametro) {
            $('#imgTTLN').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgTTLN').prepend('<img id="imgTTLN" src="Imagenes/ok.png" Width="24px" Height="24px" />');
        } else {
            $('#imgTTLN').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgTTLN').prepend('<img id="imgTTLN" src="Imagenes/error3.png" Width="24px" Height="24px" />');
        }
    }
    else if (txt.id == "MainContent_txtTtlWeb") {
        var parametro = (document.getElementById('MainContent_lblTTLW').textContent);
        if (parseFloat(txt.value) <= parametro) {
            $('#imgTTLW').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgTTLW').prepend('<img id="imgTTLW" src="Imagenes/ok.png" Width="24px" Height="24px" />');
        } else {
            $('#imgTTLW').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
            $('#imgTTLW').prepend('<img id="imgTTLW" src="Imagenes/error3.png" Width="24px" Height="24px" />');
        }
    }
    else if (txt.id == "MainContent_txtAnchoActual") {
        var anchoContratado = (document.getElementById('MainContent_txtAnchoBanda'));
        if (anchoContratado.value != "")
        {
            var parametro = (document.getElementById('MainContent_lblAncho').textContent);//Porcentaje
            var porcentaje = parseFloat(parametro) / 100;
            var minimoContratado = parseFloat(anchoContratado.value) * porcentaje;
            var anchoActual = parseFloat(txt.value);

            if (minimoContratado <= anchoActual) {
                $('#imgAncho').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
                $('#imgAncho').prepend('<img id="imgAncho" src="Imagenes/ok.png" Width="24px" Height="24px" />');
            } else {
                $('#imgAncho').empty();//Siempre lo vaciamos para que no salgan 2 imagenes.
                $('#imgAncho').prepend('<img id="imgAncho" src="Imagenes/error3.png" Width="24px" Height="24px" />');
            }
        }
        else
        {
            alert('ERROR: Debe digitar el ancho de banda contratado, Para verificar');
            anchoContratado.focus();
        }
     
    }
    else 
    {
        alert('ERROR: Input No encontrado');
    }
    return false;
}