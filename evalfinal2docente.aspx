<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="evalfinal2docente.aspx.cs" Inherits="evalfinal2docente" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
    <script>
        $(document).ready(function () {
            buscarasesor();
           
            
        });

       
        function buscarasesor() {
                     
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/buscarasesor',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //data: jsonData,
                success: function (json) {
                    var resp = json.d.split("&");
                    if (resp[1] === "true") {
                        $("#asesor").html(resp[0]);
                        //cargarrespuestaspregunta($("#asesor").val(), "7", "1");
                        //cargarrespuestaspregunta($("#asesor").val(), "7", "2");
                        //cargarrespuestaspregunta($("#asesor").val(), "7", "3");
                        //cargarrespuestaspregunta($("#asesor").val(), "7", "4");
                        //cargarrespuestaspregunta($("#asesor").val(), "9", "1");
                        //cargarrespuestaspregunta($("#asesor").val(), "9", "2");
                        //cargarrespuestaspregunta($("#asesor").val(), "9", "3");
                        //cargarrespuestaspregunta($("#asesor").val(), "9", "4");

                        cargarrespuestaspregunta($("#asesor").val(), "2", "");
                        cargarrespuestaspregunta($("#asesor").val(), "4", "");
                        cargarrespuestaspregunta($("#asesor").val(), "3", "");
                        cargarrespuestaspregunta($("#asesor").val(), "6", "");
                        cargarrespuestaspregunta($("#asesor").val(), "5", "1");
                        //cargarrespuestaspregunta($("#asesor").val(), "8", "");
                        //cargarrespuestaspregunta($("#asesor").val(), "10", "");

                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "1", "0", "modtic", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "2", "0", "rbejetic", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "0", "rbpedago", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "1", "preg31", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "2", "preg32", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "3", "preg33", "");


                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "4", "preg34", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "5", "preg35", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "6", "preg36", "");

                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "7", "preg37", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "8", "preg38", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "9", "preg39", "");

                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "3", "10", "preg40", "");

                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "4", "0", "preg4", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "4", "1", "preg41", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "4", "2", "preg42", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "4", "3", "preg43", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "4", "4", "preg44", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "5", "0", "preg5", "");
                        cargarrespuestaspreguntacerrada_radio($("#asesor").val(), "7", "0", "preg7", "");

                      
                                               
                        cargarrespuestascerradaschk1($("#asesor").val());
                        cargarrespuestascerradaschk4($("#asesor").val());
                        cargarrespuestascerradaschk5($("#asesor").val());
                        cargarrespuestascerradaschk6($("#asesor").val());
                        cargarrespuestascerradaschk11($("#asesor").val());
                        cargarrespuestascerradaschk12($("#asesor").val());
                        cargarrespuestascerradaschk13($("#asesor").val());
                        cargarrespuestascerradaschk14($("#asesor").val());
                    }
                    else {
                        cargarasesores();
                    }
                }
            });
        }
        function cargarasesores() {

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarasesores',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var resp = json.d.split("&");
                    if (resp[0] === "true") {
                        $("#asesor").html(resp[1]);
                    }
                }
            });
        }

        function cargarrespuestaspregunta(codasesor,pregunta,numero) {
            var jsonData = '{"codasesor":"' + codasesor + '", "pregunta":"' + pregunta + '", "numero":"' + numero + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestaspregunta',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");

                    if (resp[0] === "true") {
                        
                        switch (pregunta) {
                            case "2":
                                $("#txtnproyecto2").val(resp[1]);
                                break;
                            case "3":
                                $("#txtpedago").val(resp[1]);
                                break;
                            case "4":
                                $("#txtnproyectos").val(resp[1]);
                                break;
                            
                        }
                        
                    }
                }
            });
        }
// <!-- 
//         function cargarrespuestaspreguntacerrada_2(codasesor, pregunta, subpregunta, nombre, numero) {
//             var jsonData = '{"codasesor":"' + codasesor + '", "pregunta":"' + pregunta + '", "subpregunta":"' + subpregunta + '", "numero":"' + numero + '"}';
//             $.ajax({
//                 type: 'POST',
//                 url: 'evalfinal2docente.aspx/cargarrespuestaspreguntacerrada_2',
//                 contentType: "application/json; charset=utf-8",
//                 dataType: "json",
//                 data: jsonData,
//                 success: function (json) {
//                     var resp = json.d.split("_load@");

//                     if (resp[0] === "true") {
//                         if (resp[1] == "si")
//                             $("#" + nombre + "_1").attr('checked', true);
//                         else if (resp[1] == "2")
//                             $("#" + nombre + "_2").attr('checked', true);
//                          else if (resp[1] == "3")
//                             $("#" + nombre + "_3").attr('checked', true);
//                          else if (resp[1] == "4")
//                             $("#" + nombre + "_4").attr('checked', true);
//                          else if (resp[1] == "5")
//                             $("#"+ nombre + "_5").attr('checked', true);
//                          else if (resp[1] == "si")
//                             $("#"+ nombre + "_si").attr('checked', true);
//                          else if (resp[1] == "no")
//                             $("#"+ nombre + "_no").attr('checked', true);
//                     }
//                 }
//             });
//         } -->

        function cargarrespuestaspreguntacerrada_radio(codasesor, pregunta, subpregunta, nombre, numero) {
            var jsonData = '{"codasesor":"' + codasesor + '", "pregunta":"' + pregunta + '", "subpregunta":"' + subpregunta + '", "numero":"' + numero + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestaspreguntacerrada_2',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("_load@");

                    if (resp[0] === "true") {
                        if (resp[1] == "1")
                            $("#" + nombre + "_1").attr('checked', true);
                        else if (resp[1] == "2")
                            $("#" + nombre + "_2").attr('checked', true);
                         else if (resp[1] == "3")
                            $("#" + nombre + "_3").attr('checked', true);
                         else if (resp[1] == "4")
                            $("#" + nombre + "_4").attr('checked', true);
                         else if (resp[1] == "5")
                            $("#"+ nombre + "_5").attr('checked', true);

                         else if (resp[1] == "si")
                            $("#"+ nombre + "_si").attr('checked', true);

                         else if (resp[1] == "no")
                            $("#"+ nombre + "_no").attr('checked', true);
                    }
                }
            });
        }

        function cargarrespuestascerradaschk1(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk1',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=clasefuncionario]").each(function (index) {
                            if (resp[i] == "Maestroa acompañante")
                                $("#directivodocente").attr('checked', true);

                            if (resp[i] == "Beneficiario")
                                $("#docente").attr('checked', true);

                            if (resp[i] == "Maestro lider")
                                $("#docenteeduesp").attr('checked', true);

                            if (resp[i] == "Maestro investigador")
                                $("#docenteetno").attr('checked', true);

                            if (resp[i] == "Apoyar y participar")
                                $("#consejero").attr('checked', true);

                            //if (resp[i] == "Médicos")
                            //    $("#medico").attr('checked', true);

                            //if (resp[i] == "Administrativos")
                            //    $("#admin").attr('checked', true);

                            //if (resp[i] == "Profesionales")
                            //    $("#profesionales").attr('checked', true);

                            //if (resp[i] == "Tutores")
                            //    $("#tutores").attr('checked', true);

                            //if (resp[i] == "Directivos")
                            //    $("#directivos").attr('checked', true);

                            //if (resp[i] == "Auxiliar de aula")
                            //    $("#auxiliar").attr('checked', true);

                            i++;
                        });
                    }
                }
            });
        }

        function cargarrespuestascerradaschk4(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk4',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=modalidad]").each(function (index) {
                            if (resp[i] == "De aula")
                                $("#chkaula").attr('checked', true);

                            if (resp[i] == "Transversales")
                                $("#chktransversales").attr('checked', true);

                            if (resp[i] == "Interdisciplinarios")
                                $("#chkinterdisciplinarios").attr('checked', true);

                            i++;
                        });
                    }
                }
            });
        }

        function cargarrespuestascerradaschk5(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk5',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=partimodalidad]").each(function (index) {
                            if (resp[i] == "De aula")
                                $("#chkpartiaula").attr('checked', true);

                            if (resp[i] == "Transversales")
                                $("#chkpartitransversales").attr('checked', true);

                            if (resp[i] == "Interdisciplinarios")
                                $("#chkpartiinterdisciplinarios").attr('checked', true);

                            i++;
                        });
                    }
                }
            });
        }

        function cargarrespuestascerradaschk6(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk6',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=investigamodalidad]").each(function (index) {
                            if (resp[i] == "De aula")
                                $("#chkinvestigaaula").attr('checked', true);

                            if (resp[i] == "Transversales")
                                $("#chkinvestigatransversales").attr('checked', true);

                            if (resp[i] == "Interdisciplinarios")
                                $("#chkinvestigainterdisciplinarios").attr('checked', true);

                            i++;
                        });
                    }
                }
            });
        }

        function cargarrespuestascerradaschk11(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk11',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=ieptics]").each(function (index) {
                            if (resp[i] == "conocimientos")
                                $("#conocimientos").attr('checked', true);

                            if (resp[i] == "liderazgo")
                                $("#liderazgo").attr('checked', true);

                            if (resp[i] == "investigativo")
                                $("#investigativo").attr('checked', true);

                            if (resp[i] == "creativos")
                                $("#creativos").attr('checked', true);

                            if (resp[i] == "internet")
                                $("#internet").attr('checked', true);

                            if (resp[i] == "colaborativo")
                                $("#colaborativo").attr('checked', true);
                            
                            if (resp[i] == "colaborativo")
                                $("#colaborativo").attr('checked', true);

                            if (resp[i] == "reconocer")
                                $("#reconocer").attr('checked', true);

                            if (resp[i] == "escuchar")
                                $("#escuchar").attr('checked', true);

                            if (resp[i] == "interactuar")
                                $("#interactuar").attr('checked', true);

                            if (resp[i] == "naturaleza")
                               $("#naturaleza").attr('checked', true);

                            if (resp[i] == "dimension")
                                $("#dimension").attr('checked', true);

                            if (resp[i] == "preguntas")
                                $("#preguntas").attr('checked', true);

                            if (resp[i] == "comprender")
                                $("#comprender").attr('checked', true);

                        

                            i++;
                        });
                    }
                }
            });
        }

        function cargarrespuestascerradaschk12(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk12',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=preg71]").each(function (index) {
                            if (resp[i] == "Consolidan los procesos")
                                $("#ticinves").attr('checked', true);

                            if (resp[i] == "Facilitan el trabajo en el aula")
                                $("#ticaula").attr('checked', true);

                            if (resp[i] == "Motivan a los estudiantes")
                                $("#ticestudiante").attr('checked', true);

                            if (resp[i] == "Incrementan el interés de los estudiantes")
                                $("#ticmaterias").attr('checked', true);

                            if (resp[i] == "Favorecen la interacción, la comunicación")
                                $("#ticcomunicacion").attr('checked', true);

                            if (resp[i] == "Mejoran los resultados educativos")
                                $("#ticeducativos").attr('checked', true);
                            
                            if (resp[i] == "Favorecen el desarrollo de nuevas estrategias")
                                $("#ticdesarrollo").attr('checked', true);
                                
                            if (resp[i] == "Facilitan la realización de experiencias")
                                $("#ticexperiencia").attr('checked', true);
                            
                            if (resp[i] == "Ayudan a corregir los errores que se producen")
                                $("#ticerrores").attr('checked', true);
                            
                            if (resp[i] == "Favorecen el desarrollo de la iniciativa")
                                $("#ticiniciativa").attr('checked', true);

                            if (resp[i] == "Incrementan la autonomía")
                                $("#ticautonomia").attr('checked', true);
                            i++;
                        });
                    }
                }
            });
        }
         function cargarrespuestascerradaschk13(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk13',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=p10]").each(function (index) {
                            if (resp[i] == "Computador")
                                $("#computador").attr('checked', true);

                            if (resp[i] == "Google drive")
                                $("#googled").attr('checked', true);

                            if (resp[i] == "E-mail")
                                $("#emaikl").attr('checked', true);

                            if (resp[i] == "Contenido de audio")
                                $("#caudio").attr('checked', true);

                            if (resp[i] == "Impresora")
                                $("#impresora").attr('checked', true);
                                
                            if (resp[i] == "Eduka")
                                $("#eduka").attr('checked', true);

                            if (resp[i] == "Whatsapp")
                                $("#whatsapp").attr('checked', true);

                            if (resp[i] == "Contenido audiovisual")
                                $("#audiovisual").attr('checked', true);

                            if (resp[i] == "Video Beam")
                                $("#videobeam").attr('checked', true);

                            if (resp[i] == "Google sites")
                                $("#googlesite").attr('checked', true);

                            if (resp[i] == "googlegrup")
                                $("#googlegrup").attr('checked', true);

                            if (resp[i] == "Contenido Multimedia")
                                $("#multimedia").attr('checked', true);

                            if (resp[i] == "Video camara")
                                $("#videocamara").attr('checked', true);

                            if (resp[i] == "Educared")
                                $("#educared").attr('checked', true);

                            if (resp[i] == "Twiter")
                                $("#twitter").attr('checked', true);

                            if (resp[i] == "Publicaciones WEB")
                                $("#pweb").attr('checked', true);

                            if (resp[i] == "Reproductor DVD")
                                $("#dvd").attr('checked', true);

                            if (resp[i] == "Google educa")
                                $("#googleedu").attr('checked', true);

                            if (resp[i] == "Mesenger")
                                $("#messenger").attr('checked', true);

                            if (resp[i] == "Administracion canal Web")
                                $("#aweb").attr('checked', true);

                            if (resp[i] == "Celular")
                                $("#celular").attr('checked', true);

                            if (resp[i] == "Eduteka")
                                $("#eduteka").attr('checked', true);

                            if (resp[i] == "Facebook")
                                $("#facebook").attr('checked', true);

                            if (resp[i] == "Administración Red Social")
                                $("#adredsocial").attr('checked', true);

                            if (resp[i] == "Escaner")
                                $("#escaner").attr('checked', true);

                            if (resp[i] == "Colombia aprende")
                                $("#colomapren").attr('checked', true);

                            if (resp[i] == "Web personal")
                                $("#webpersonal").attr('checked', true);

                            if (resp[i] == "Foros")
                                $("#foros").attr('checked', true);

                            if (resp[i] == "Fotocopiadora")
                                $("#fotocopia").attr('checked', true);

                            if (resp[i] == "Wikipedia")
                                $("#wikipedia").attr('checked', true);

                            if (resp[i] == "Skype")
                                $("#skype").attr('checked', true);

                            if (resp[i] == "Blogs")
                                $("#blogs").attr('checked', true);

                            if (resp[i] == "Proyector acetato")
                                $("#proyectorace").attr('checked', true);

                            if (resp[i] == "Computadores para educar")
                                $("#computadoresedu").attr('checked', true);

                            if (resp[i] == "Wiki")
                                $("#wiki").attr('checked', true);

                            if (resp[i] == "Otros Equipos")
                                $("#otros1").attr('checked', true);

                            if (resp[i] == "conferencista2")
                                $("#conferencista2").attr('checked', true);
                                
                            if (resp[i] == "Otros Para Docencias")
                                $("#otros2").attr('checked', true);

                            if (resp[i] == "Otros Redes sociales")
                                $("#otros3").attr('checked', true);

                            if (resp[i] == "Otros Herramientas Virtuales")
                                $("#otros4").attr('checked', true);

                            if (resp[i] == "Ninguno Equipos")
                                $("#ninguno1").attr('checked', true);

                            if (resp[i] == "Ninguno Para Docencia")
                                $("#ninguno2").attr('checked', true);

                            if (resp[i] == "Ninguno Redes Sociales")
                                $("#ninguno3").attr('checked', true);

                            if (resp[i] == "Ninguno Herrameitnas Virtuales")
                                $("#ninguno4").attr('checked', true);

                            if (resp[i] == "Disco 3/2")
                                $("#disco32").attr('checked', true);

                            if (resp[i] == "Aula Fácil (cursos gratis Online)")
                                $("#free").attr('checked', true);

                            if (resp[i] == "SIGCE (Gestión SED)")
                                $("#sigce").attr('checked', true);

                            if (resp[i] == "CD ROM")
                                $("#cdrom").attr('checked', true);

                            if (resp[i] == "DVD")
                                $("#cdvd").attr('checked', true);

                            if (resp[i] == "Blackboard")
                                $("#black").attr('checked', true);

                            if (resp[i] == "SGCF (Sistema gestión y control financiero MEN)")
                                $("#sgcf").attr('checked', true);

                            if (resp[i] == "USB")
                                $("#usb").attr('checked', true);

                            if (resp[i] == "YouTube")
                                $("#youtube").attr('checked', true);

                            if (resp[i] == "SINEB (Sistema de Educación Básiac")
                                $("#sineb").attr('checked', true);

                            if (resp[i] == "Micro SD")
                                $("#microsd").attr('checked', true);

                            if (resp[i] == "Conferencia TED")
                                $("#ted").attr('checked', true);

                            if (resp[i] == "SICIED (Sistema de consulta infraestructura)")
                                $("#sicied").attr('checked', true);

                            if (resp[i] == "Blu-Ray")
                                $("#bluray").attr('checked', true);

                            if (resp[i] == "Moodle")
                                $("#moodle").attr('checked', true);

                            if (resp[i] == "SINIES (Sistema información Educación Superior)")
                                $("#sinies").attr('checked', true);

                            if (resp[i] == "Celulares y smartphones")
                                $("#celulares").attr('checked', true);

                            if (resp[i] == "Webdubox")
                                $("#webdubox").attr('checked', true);

                            if (resp[i] == "SAC (Unidad Atención ciudadano)")
                                $("#sac").attr('checked', true);

                            if (resp[i] == "Otros Dispositivos")
                                $("#otros5").attr('checked', true);

                            if (resp[i] == "Otros Herramientas formación")
                                $("#otros6").attr('checked', true);

                            if (resp[i] == "Otros Plataformas que conoce")
                                $("#otros7").attr('checked', true);

                            if (resp[i] == "Ninguno Dispositivos")
                                $("#ninguno5").attr('checked', true);

                            if (resp[i] == "Ninguno Herramientas formación")
                                $("#ninguno6").attr('checked', true);

                            if (resp[i] == "Ninguno Plataformas que conoce")
                                $("#ninguno7").attr('checked', true);
                                
                            if (resp[i] == "Windows")
                                $("#window").attr('checked', true);

                            if (resp[i] == "Gózate la ciencia")
                                $("#gozate").attr('checked', true);

                            if (resp[i] == "AQTCR (A que te cojo ratón)")
                                $("#aqtcr").attr('checked', true);

                            if (resp[i] == "Linux")
                                $("#linux").attr('checked', true);

                            if (resp[i] == "La de la CUC")
                                $("#cuc").attr('checked', true);

                            if (resp[i] == "Proyect")
                                $("#proyect").attr('checked', true);

                            if (resp[i] == "Android")
                                $("#android").attr('checked', true);

                            if (resp[i] == "La de la UNIMAG")
                                $("#unimag").attr('checked', true);

                            if (resp[i] == "MacOS")
                                $("#macos").attr('checked', true);

                            if (resp[i] == "Página web programa Ciclón")
                                $("#ciclon").attr('checked', true);

                            if (resp[i] == "Entre pares")
                                $("#entrepares").attr('checked', true);

                            if (resp[i] == "Chrome")
                                $("#chrome").attr('checked', true);

                            if (resp[i] == "Macondo")
                                $("#macondo").attr('checked', true);

                            if (resp[i] == "INTEL")
                                $("#intel").attr('checked', true);
                            
                            if (resp[i] == "Coursera")
                                $("#courseras").attr('checked', true);

                            if (resp[i] == "SIMAT (Sistema matrícula - MEN)")
                                $("#simat").attr('checked', true);
                            
                            if (resp[i] == "Compartel")
                                $("#compartel").attr('checked', true);
                            
                            
                            i++;
                        });
                    }
                }
            });
        }

        function cargarrespuestascerradaschk14(codasesor) {
            var jsonData = '{"codasesor":"' + codasesor + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/cargarrespuestascerradaschk14',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function (json) {
                    var resp = json.d.split("@");

                    if (resp[0] === "true") {
                        var i = 1;
                        $("input[name=aspecpedago]").each(function (index) {
                            if (resp[i] == "Los métodos de enseñanza")
                                $("#pp1").attr('checked', true);

                            if (resp[i] == "La utilización de nuevas herramientas")
                                $("#pp2").attr('checked', true);

                            if (resp[i] == "El lugar de las preguntas de los estudiantes")
                                $("#pp3").attr('checked', true);

                            if (resp[i] == "Las estrategias para despertar en los estudiantes")
                                $("#pp4").attr('checked', true);

                            if (resp[i] == "La incorporación de las TIC")
                                $("#pp5").attr('checked', true);
                            
                            if (resp[i] == "Las estrategias didácticas")
                                $("#pp6").attr('checked', true);
                                
                            if (resp[i] == "Las mallas curriculares y los planes")
                                $("#pp7").attr('checked', true);
                            
                             if (resp[i] == "La incorporación de la innovación")
                                $("#pp8").attr('checked', true);    
                                
                            if (resp[i] == "Las estrategias didácticas utilizadas")
                                $("#pp9").attr('checked', true);
                        
                            
                            if (resp[i] == "Las estrategias para fomentar la innovación")
                                $("#pp10").attr('checked', true);

                            i++;
                        });
                    }
                }
            });
        }


        // function history() {

        //     alert(resp[1]='1'+''+pregunta+''+subpregunta)
        // }
        function enviar() {
            if ($.trim($("#asesor").val()) == '' || $.trim($("#asesor").val()) == '0') {
                    alert("Por favor, seleccione el asesor");
                $("#asesor").focus();

            } else if (!$("input[name=modtic]:checked").val()) {
                alert("Por favor, seleccione una opción de la pregunta No. 1 ");

            } else if (!$("input[name=rbejetic]:checked").val()) {
                alert("Por favor, seleccione una opción de la pregunta No. 2 ");

            } else if (!$("input[name=rbpedago]:checked").val()) {
                alert("Por favor, seleccione una opción de la pregunta No. 3 ");

            //} else if (!$("input[name=preg111]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 1.1 subpregunta 1");
            //    //$("#preg1").focus();

            //} else if (!$("input[name=preg112]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 1.1 subpregunta 2 ");

            //} else if (!$("input[name=preg113]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 1.1  subpregunta 3");

            // } else if (!$("input[name=preg121]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 1.2  subpregunta 1");
            //    //$("#preg1").focus();

            //} else if (!$("input[name=preg122]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 1.2  subpregunta 2");

            //} else if (!$("input[name=preg123]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 1.2  subpregunta 3")

            //} else if (!$("input[name=preg131]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 1.3  subpregunta 1");
            //    //$("#preg1").focus();

            //} else if (!$("input[name=preg132]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 1.3 subpregunta 2");

            //} else if (!$("input[name=preg133]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 1.3  subpregunta 3")

            //} else if (!$("input[name=preg211]:checked").val()) {

            //    alert("Por favor, seleccione una opción de la pregunta No. 2.1  subpregunta 1");
            //} else if (!$("input[name=preg212]:checked").val()) {



            //    //$("#direccion").focus();
            //} else if (!$("input[name=participoproyecto]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 4");
            //    //$("#telefono").focus();
            //} else if (!$("input[name=inventigaf2]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 3");
            //    //$("#telefono").focus();
            //} else if (!$("input[name=rbinvestiga]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 6");
            //    //$("#telefono").focus();
            //    } else if (!$("input[name=beneficiarioconvocatoria]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 5");
            //    //$("#telefono").focus();
            //    } else if (!$("input[name=ejecuciclon]:checked").val()) {
            //    alert("Por favor, seleccione una opción de la pregunta No. 7");
            //    //$("#telefono").focus();
            } else {
                
                guardarpreguntas();
               $('body').append('<div class="desactivarC1" style="background: rgb(255, 255, 255);z-index: 999; position: absolute; top: 0; left: 0; bottom: 0; width: 100%; background-image: url(\'imagenes/loading.gif\'); background-repeat: no-repeat; background-position: center;background-size:4%;position: fixed;height:100%;display: flex;justify-content: center;align-items: center;">Las respuestas están siendo guardadas, por favor espere...</div>');
               $(".desactivarC1").delay(40000).fadeOut(500);
                //alert("Datos guardados correctamente");
                
               
            }
            
        }
       
       
        function guardarpreguntas() {
            //pregunta 2 los radio
            //Pregunta 1
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg111]:checked').val(), "1", "11", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg112]:checked').val(), "1", "12", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg113]:checked').val(), "1", "13", "");

            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg121]:checked').val(), "1", "21", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg122]:checked').val(), "1", "22", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg123]:checked').val(), "1", "23", "");

            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg131]:checked').val(), "1", "31", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg132]:checked').val(), "1", "32", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg133]:checked').val(), "1", "33", "");

            ////Pregunta 2
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg211]:checked').val(), "2", "11", "");



            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=modtic]:checked').val(), "1", "0", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=rbejetic]:checked').val(), "2", "0", "");
            

            //Guardar preguntas 3
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=rbpedago]:checked').val(), "3", "0", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg31]:checked').val(), "3", "1", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg32]:checked').val(), "3", "2", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg33]:checked').val(), "3", "3", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg34]:checked').val(), "3", "4", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg35]:checked').val(), "3", "5", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg36]:checked').val(), "3", "6", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg37]:checked').val(), "3", "7", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg38]:checked').val(), "3", "8", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg39]:checked').val(), "3", "9", "");
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg40]:checked').val(), "3", "10", "");

            /**Guardar pregunta 4*/
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg4]:checked').val(), "4", "0", ""); 
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg41]:checked').val(), "4", "1", ""); 
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg42]:checked').val(), "4", "2", ""); 
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg43]:checked').val(), "4", "3", ""); 
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg44]:checked').val(), "4", "4", ""); 
           
            /**Guardar pregunta 5*/
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg5]:checked').val(), "5", "0", "");           

             /**Guardar pregunta 7*/
            guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=preg7]:checked').val(), "7", "0", "");

            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=participoproyecto]:checked').val(), "4", "0", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=inventigaf2]:checked').val(), "3", "0", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=rbinvestiga]:checked').val(), "6", "0", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=beneficiarioconvocatoria]:checked').val(), "5", "0", "");
            //guardarpreguntascerradas_radio($("#asesor").val(), $('input:radio[name=ejecuciclon]:checked').val(), "7", "0", "");


            //Preguntas abiertas
            //Pregunta 2 los text


            //Pregunta 3, 4, 5, 6, 8, 10 text
            //guardarpreguntasabiertas_preg3($("#asesor").val(), "txtpedago", "3", "delete");
            //guardarpreguntasabiertas_preg3($("#asesor").val(), "txtnproyecto2", "2", "delete");
            //guardarpreguntasabiertas_preg3($("#asesor").val(), "txtnproyectos", "4", "delete");


            ////pregunta 2 los drops
            //guardarpreguntascerradas_preg2($("#asesor").val(), "tipo", "1", "2", "1", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "tipo", "2", "2", "3", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "tipo", "3", "2", "5", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "tipo", "4", "2", "7", "delete");

            //guardarpreguntascerradas_preg2($("#asesor").val(), "modalidad", "1", "2", "2", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "modalidad", "2", "2", "4", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "modalidad", "3", "2", "6", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "modalidad", "4", "2", "8", "delete");

            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7tipo", "1", "7", "1", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7tipo", "2", "7", "3", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7tipo", "3", "7", "5", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7tipo", "4", "7", "7", "delete");

            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7modalidad", "1", "7", "2", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7modalidad", "2", "7", "4", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7modalidad", "3", "7", "6", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg7modalidad", "4", "7", "8", "delete");

            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9tipo", "1", "9", "1", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9tipo", "2", "9", "3", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9tipo", "3", "9", "5", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9tipo", "4", "9", "7", "delete");

            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9modalidad", "1", "9", "2", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9modalidad", "2", "9", "4", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9modalidad", "3", "9", "6", "delete");
            //guardarpreguntascerradas_preg2($("#asesor").val(), "preg9modalidad", "4", "9", "8", "delete");

            //guardarpreguntascerradaschk1();
            //guardarpreguntascerradaschk4();
            //guardarpreguntascerradaschk5();
            //guardarpreguntascerradaschk6();
            guardarpreguntascerradaschk11();
            guardarpreguntascerradaschk12();
            guardarpreguntascerradaschk13();
            guardarpreguntascerradaschk14();
        }

        function guardarpreguntasabiertas_preg2(codasesor, nombre, duracion, anio, numero, pregunta, accion) {
            var jsonData = '{"codasesor":"' + codasesor + '", "respuesta":"' + $('#' + nombre + '_' + numero).val() + '", "pregunta":"' + pregunta + '", "accion":"' + accion + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/guardarpreguntasabiertas',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {
                    var jsonData = '{"codasesor":"' + codasesor + '", "respuesta":"' + $('#' + duracion + '_' + numero).val() + '", "pregunta":"' + pregunta + '", "accion":"nodelete"}';
                    $.ajax({
                        type: 'POST',
                        url: 'evalfinal2docente.aspx/guardarpreguntasabiertas',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: jsonData,
                        success: function () {
                            var jsonData = '{"codasesor":"' + codasesor + '", "respuesta":"' + $('#' + anio + '_' + numero).val() + '", "pregunta":"' + pregunta + '", "accion":"nodelete"}';
                            $.ajax({
                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardarpreguntasabiertas',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData,
                                success: function () {

                                }
                            });
                        }
                    });
                }
            });
        }

        function guardarpreguntascerradas_radio(codasesor, nombre, pregunta, subpregunta, accion) {
           // alert(codasesor+' '+ nombre+' '+ pregunta+' '+ subpregunta+' '+ accion);
            
           if(nombre !=null)
           {  var jsonData = '{"codasesor":"' + codasesor + '", "respuesta":"' + nombre + '", "pregunta":"' + pregunta + '", "subpregunta":"' + subpregunta + '", "accion":"' + accion + '"}';
               $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/guardarpreguntascerradas',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {
                    
                }
            });
           }
           
        }

        function guardarpreguntascerradas_preg2(codasesor, nombre, numero, pregunta, subpregunta, accion) {
            var jsonData = '{"codasesor":"' + codasesor + '", "respuesta":"' + $('#' + nombre + '_' + numero).val() + '", "pregunta":"' + pregunta + '", "subpregunta":"' + subpregunta + '", "accion":"' + accion + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/guardarpreguntascerradas',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {
                   
                }
            });
        }

        function guardarpreguntasabiertas_preg3(codasesor, txt, pregunta, accion) {
            var jsonData = '{"codasesor":"' + codasesor + '", "respuesta":"' + $('#' + txt).val() + '", "pregunta":"' + pregunta + '", "accion":"' + accion + '"}';
            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/guardarpreguntasabiertas',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {
                  
                }
            });
        }

        

        //function guardarpreguntascerradas_old() {
        //    var jsonData = '{"codasesor":"' + $("#asesor").val() + '", "preg2_1":"' + $('#tipo_1').val() + '", "preg2_2":"' + $('#modalidad_1').val() + '", "preg2_3":"' + $('#tipo_2').val() + '", "preg2_4":"' + $('#modalidad_2').val() + '", "preg2_5":"' + $('#tipo_3').val() + '", "preg2_6":"' + $('#modalidad_3').val() + '", "preg2_7":"' + $('#tipo_4').val() + '", "preg2_8":"' + $('#modalidad_4').val() + '", "preg3":"' + $('input:radio[name=rbpedago]:checked').val() + '", "preg4":"' + $('input:radio[name=rbpromueve]:checked').val() + '", "preg5":"' + $('input:radio[name=rbparticipado]:checked').val() + '", "preg6":"' + $('input:radio[name=rbinvestiga]:checked').val() + '", "preg8":"' + $('input:radio[name=preg8rbforma]:checked').val() + '", "preg10":"' + $('input:radio[name=preg10rbforma]:checked').val() + '", "preg7_1":"' + $('#preg7tipo_1').val() + '", "preg7_2":"' + $('#preg7modalidad_1').val() + '", "preg7_3":"' + $('#preg7tipo_2').val() + '", "preg7_4":"' + $('#preg7modalidad_2').val() + '", "preg7_5":"' + $('#preg7tipo_3').val() + '", "preg7_6":"' + $('#preg7modalidad_3').val() + '", "preg7_7":"' + $('#preg7tipo_4').val() + '", "preg7_8":"' + $('#preg7modalidad_4').val() + '", "preg9_1":"' + $('#preg9tipo_1').val() + '", "preg9_2":"' + $('#preg9modalidad_1').val() + '", "preg9_3":"' + $('#preg9tipo_2').val() + '", "preg9_4":"' + $('#preg9modalidad_2').val() + '", "preg9_5":"' + $('#preg9tipo_3').val() + '", "preg9_6":"' + $('#preg9modalidad_3').val() + '", "preg9_7":"' + $('#preg9tipo_4').val() + '", "preg9_8":"' + $('#preg9modalidad_4').val() + '"}';
        //    $.ajax({
        //        type: 'POST',
        //        url: 'lineabasedocentes2_intermedia.aspx/guardardatoscerradas',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        data: jsonData
        //    });
        //}

        //function guardarpreguntasabiertas() {
        //    var jsonData = '{ "codasesor":"' + $("#asesor").val() + '", "preg2_nombre_1":"' + $("#nombre_1").val() + '", "preg2_duracion_1":"' + $("#duracion_1").val() + '", "preg2_anio_1":"' + $("#anio_1").val() + '", "preg2_nombre_2":"' + $("#nombre_2").val() + '", "preg2_duracion_2":"' + $("#duracion_2").val() + '", "preg2_anio_2":"' + $("#anio_2").val() + '", "preg2_nombre_3":"' + $("#nombre_3").val() + '", "preg2_duracion_3":"' + $("#duracion_3").val() + '", "preg2_anio_3":"' + $("#anio_3").val() + '", "preg2_nombre_4":"' + $("#nombre_4").val() + '", "preg2_duracion_4":"' + $("#duracion_4").val() + '", "preg2_anio_4":"' + $("#anio_4").val() + '", "txtpedago":"' + $("#txtpedago").val() + '", "txtpromueve":"' + $("#txtpromueve").val() + '", "txtparticipado":"' + $("#txtparticipado").val() + '", "txtinvestiga":"' + $("#txtinvestiga").val() + '", "preg7nombre_1":"' + $("#preg7nombre_1").val() + '", "preg7duracion_1":"' + $("#preg7duracion_1").val() + '", "preg7anio_1":"' + $("#preg7anio_1").val() + '", "preg7nombre_2":"' + $("#preg7nombre_2").val() + '", "preg7duracion_2":"' + $("#preg7duracion_2").val() + '", "preg7anio_2":"' + $("#preg7anio_2").val() + '", "preg7nombre_3":"' + $("#preg7nombre_3").val() + '", "preg7duracion_3":"' + $("#preg7duracion_3").val() + '", "preg7anio_3":"' + $("#preg7anio_3").val() + '", "preg7nombre_4":"' + $("#preg7nombre_4").val() + '", "preg7duracion_4":"' + $("#preg7duracion_4").val() + '", "preg7anio_4":"' + $("#preg7anio_4").val() + '", "preg9nombre_1":"' + $("#preg9nombre_1").val() + '", "preg9duracion_1":"' + $("#preg9duracion_1").val() + '", "preg9anio_1":"' + $("#preg9anio_1").val() + '", "preg9nombre_2":"' + $("#preg9nombre_2").val() + '", "preg9duracion_2":"' + $("#preg9duracion_2").val() + '", "preg9anio_2":"' + $("#preg9anio_2").val() + '", "preg9nombre_3":"' + $("#preg9nombre_3").val() + '", "preg9duracion_3":"' + $("#preg9duracion_3").val() + '", "preg9anio_3":"' + $("#preg9anio_3").val() + '", "preg9nombre_4":"' + $("#preg9nombre_4").val() + '", "preg9duracion_4":"' + $("#preg9duracion_4").val() + '", "preg9anio_4":"' + $("#preg9anio_4").val() + '", "preg8rbforma":"' + $("#preg8rbforma").val() + '", "preg10rbforma":"' + $("#preg10rbforma").val() + ', "preg11_1":"' + $('#txtnivel_bachillerato').val() + '", "preg11_2":"' + $('#txtnivel_normalista').val() + '", "preg11_3":"' + $('#txtnivel_otrobachillerato').val() + '", "preg11_4":"' + $('#txtnivel_tecnico').val() + '", "preg11_5":"' + $('#txtnivel_otrotecnico').val() + ', "preg11_6":"' + $('#txtnivel_profesional').val() + '", "preg11_7":"' + $('#txtnivel_otroprofesional').val() + '", "preg11_8":"' + $('#txtnivel_especializacion').val() + '", "preg11_9":"' + $('#txtnivel_maestria').val() + '", "preg11_10":"' + $('#txtnivel_otromaestria').val() + '", "preg11_11":"' + $('#txtnivel_doctorado').val() + '", "preg11_12":"' + $('#txtnivel_otrodoctorado').val() + '"}';
        //    $.ajax({
        //        type: 'POST',
        //        url: 'lineabasedocentes2_intermedia.aspx/guardardatosabiertas',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        data: jsonData
        //    });
        //}

        //function guardarpreguntascerradaschk1() {

        //    var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

        //    $.ajax({
        //        type: 'POST',
        //        url: 'evalfinal2docente.aspx/eliminarchk1',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        data: jsonData,
        //        success: function () {

        //            $("input[name=ieptics]").each(function (index) {
        //                if ($(this).is(':checked')) {

        //                    var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

        //                    $.ajax({
        //                        type: 'POST',
        //                        url: 'evalfinal2docente.aspx/guardardatoschk1',
        //                        contentType: "application/json; charset=utf-8",
        //                        dataType: "json",
        //                        data: jsonData2

        //                    });
        //                }
        //            });

        //        }

        //    });
        //}

        function guardarpreguntascerradaschk4() {

            var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/eliminarchk4',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {

                    $("input[name=modalidad]").each(function (index) {
                        if ($(this).is(':checked')) {
                            var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                            $.ajax({

                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardardatoschk4',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData2

                            });
                        }
                    });

                }

            });
        }

        function guardarpreguntascerradaschk5() {

            var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/eliminarchk5',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {

                    $("input[name=partimodalidad]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardardatoschk5',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData2

                            });
                        }
                    });

                }

            });
        }

        function guardarpreguntascerradaschk6() {

            var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/eliminarchk6',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {

                    $("input[name=investigamodalidad]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardardatoschk6',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData2

                            });
                        }
                    });

                }

            });
        }

        function guardarpreguntascerradaschk11() {

            var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/eliminarchk11docente',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {

                    $("input[name=ieptics]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardardatoschk11',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData2

                            });
                        }
                    });

                }

            });
        }

        function guardarpreguntascerradaschk12() {

            var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/eliminarchk12',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {

                    $("input[name=preg71]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardardatoschk12',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData2

                            });
                        }
                    });

                }

            });
        }

        function guardarpreguntascerradaschk13() {

            var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

            $.ajax({
                type: 'POST',
                url: 'evalfinal2docente.aspx/eliminarchk13',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonData,
                success: function () {

                    $("input[name=p10]").each(function (index) {
                        if ($(this).is(':checked')) {

                            var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                            $.ajax({
                                type: 'POST',
                                url: 'evalfinal2docente.aspx/guardardatoschk13',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: jsonData2

                            });
                        }
                    });

                }

            });
        }

        function guardarpreguntascerradaschk14() {

         var jsonData = "{ 'codasesor':'" + $("#asesor").val() + "'}";

         $.ajax({
         type: 'POST',
         url: 'evalfinal2docente.aspx/eliminarchk14',
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         data: jsonData,
         success: function () {

        $("input[name=aspecpedago]").each(function (index) {
            if ($(this).is(':checked')) {

                var jsonData2 = "{ 'chk':'" + $(this).val() + "', 'codasesor':'" + $("#asesor").val() + "'}";

                $.ajax({
                    type: 'POST',
                    url: 'evalfinal2docente.aspx/guardardatoschk14',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData2

                });
            }
        });

    }

});
}
    </script>

    <style>
        .bold{
            font-weight:bold;
        }    

 .titu{
          display:block;
          background:#507cd1;
          height:21px;
          padding-top:3px;
           margin:0 10px 0px 10px;
            text-align :center;
      }
      .titu> label{
           color:azure;
           font-weight:bold;
      }
      td> ul> li{
           
           display:block;
           padding:0 0 0 10px;
            border: 1px solid  #ccc;
     
           
       }
       .ul{
           margin:0 10px 10px 10px;
           
            border: 1px solid  #ccc;

       }
      .liimpar{
       background:#fff;
       }
       .lipar{
                background:#fff;
        }
       .prbutton{
            display:inline-block;
            width:70%;
           margin:0;
           
       }
       
       .radio{
        position:relative;
            display:inline-block;
            margin-left: 20px;
            padding: 5px 5px 5px 40px;
            
             top:0;
             bottom: 0;
                height:100%;

         
           
           
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" ></asp:ScriptManager>


    <div id="mensaje" runat="server"></div><br /><br />
     <h2 style="text-align:center">FORTALECIMIENTO DE LA CULTURA CIUDADANA Y DEMOCRÁTICA EN CTeI A TRAVÉS DE LA IEP APOYADA EN TIC EN EL DPTO DEL MAGDALENA</h2>
        <h3 style="text-align:center">- Evaluación final-</h3>
    <br />
    <asp:Label ID="lblCodDANE" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblCodInstAsesor" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodRol" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodInstitucion" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodAsesor" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblBack" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblLineaBaseSede" runat="server" Visible="False"></asp:Label>


   
        <center>
        <h2>
                   Instrumento No. 02.1
            <br /> Caracterización de Currículos de las Instituciones Educativas

            <br />(Cambios en los currículos, en las prácticas educativas y en los estudiantes de las sedes educativas beneficiadas a través de la IEP y de la TIC)<br /><br />Fuente información primaria
        </h2>
        
    </center>

        <p>
            <b>Introducción:</b><br /><br />

            En la evaluación final del proyecto es necesario revisar la caracterización de los currículos de las sedes educativas beneficiadas para hacer visible las posibles modificaciones realizadas a los mismos en el marco del desarrollo de la estrategia No. 2 <i>“Estrategia de autoformación, formación de saber y conocimiento y apropiación para maestros(as) acompañantes  coinvestigadores e investigadores en los lineamientos del IEP apoya de TIC y su propuesta metodológica”</i>, para valorar sus alcances en términos de resultados, efectos e impactos. 
           
            <br /><br />
            <b>Propósito: </b>
            <br /><br />
           Recoger información primaria sobre la percepción que tienen los maestros y maestras de los impactos que el proyecto ha generado sobre el PEI, el currículo de las instituciones educativas y el quehacer de los docentes, en especial referido a la apropiación de las TIC, atribuibles a la introducción de la Investigación como Estrategia Pedagógica apoyada en TIC.
            <br /><br />
            <b>Metodología: </b>
            <br /><br />
            Este instrumento será diligenciado directamente en la plataforma Macondo por los maestros/as que culminaron el proceso <i>“De Autoformación, formación de saber y conocimiento y apropiación para maestros(as) acompañantes  coinvestigadores e investigadores en los lineamientos del programa Ondas y su propuesta metodológica”</i> del proyecto en mención.  

        </p>

      <tr>
                <td>Seleccione el asesor: </td>
                <td><select id="asesor" class="TextBox"></select></td>
            </tr>
        
            
            <fieldset>
                <legend>
                    Datos institucionales
                </legend>
            <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" width="100%" > 

                <tr>
                   <td class="bold">
                       1. ¿Ha recibido la formación específica en la Investigación como Estrategia Pedagógica apoyada en TIC por el Programa Ciclón de la Gobernación del Magdalena? 
                   </td>
               </tr>
                <tr>
                    <td>
                        <input id="modtic_si" name="modtic" type="radio" value="si" />Si <input id="modtic_no" name="modtic" type="radio" value="no" />No
                    </td>
                </tr>

                <tr>
                     <td class="bold">
                         <br />
                        2.	Considera Usted que la formación en la Investigación como Estrategia Pedagógica apoyada en TIC ¿modificó su práctica pedagógica?
                    </td>
                </tr>

                <tr>
                    <td>
                        <input id="rbejetic_si" name="rbejetic" type="radio" value="si" />Si <input id="rbejetic_no" name="rbejetic" type="radio" value="no" />No
                    </td>
                </tr>

                <tr>
                    <td class="bold">
                        <br />
                        Si la respuesta a la pregunta anterior fue SI indiqué qué aspectos de su práctica pedagógica se modificaron.
                    </td>
                </tr>

                 <tr>
                    <td>
                        <table align="center" class="mGridTesoreria">
                            
                            <thead>
                                <tr>
                                    <th>Aspecto de la práctica pedagógica que se modificaron</th>
                                    <th>Seleccione</th>
                                </tr>
                            </thead>
                            <tr>
                                <td>1.	Los métodos de enseñanza. </td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp1" value="Los métodos de enseñanza"  /></td>
                                

                            </tr>
                            <tr>
                                <td>2.	La utilización de nuevas herramientas y materiales didácticos en el aula.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp2" value="La utilización de nuevas herramientas"  /></td>
                                
                            </tr>

                            <tr>
                                <td>3.	El lugar de las preguntas de los estudiantes para orientar el aprendizaje. </td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp3" value="El lugar de las preguntas de los estudiantes"  /></td>
                             
                            </tr>
                             <tr>
                                <td>4.	Las estrategias para despertar en los estudiantes la motivación por aprender. </td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp4" value="Las estrategias para despertar en los estudiantes"  /></td>
                         
                            </tr>
                             <tr>
                                <td>5.	La incorporación de las TIC en la enseñanza</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp5" value="La incorporación de las TIC"  /></td>
                           
                            </tr>
                             <tr>
                                <td>6.	Las estrategias didácticas en el aula.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp6" value="Las estrategias didácticas"  /></td>
                          
                            </tr>
                            <tr>
                                <td>7.	Las mallas curriculares y los planes de aula y clases.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp7" value="Las mallas curriculares y los planes"  /></td>
                         
                            </tr>
                            <tr>
                                <td>8.	La incorporación de la innovación en el quehacer pedagógico. </td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp8" value="La incorporación de la innovación"  /></td>
                          
                            </tr>
                            <tr>
                                <td>9.	Las estrategias didácticas utilizadas para evaluar los desempeños de las competencias científicas en los estudiantes</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp9" value="Las estrategias didácticas utilizadas"  /></td>
                        
                            </tr>
                            <tr>
                                <td>10. Las estrategias para fomentar la innovación y la investigación a través del desarrollo de proyectos (IEP).</td>
                                <td  style="text-align:center; vertical-align: middle;"><input type="checkbox" name="aspecpedago" id="pp10" value="Las estrategias para fomentar la innovación"/></td>
                        
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                     <td class="bold">
                         <br />
                        3.	A partir de la formación de maestros recibida en el Programa sobre la Investigación como Estrategia Pedagógica apoyada e TIC ¿se han realizado algunas modificaciones al currículo de su sede educativa dirigidas a introducir la IEP apoyada en TIC en el mismo?
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="rbpedago_si" name="rbpedago" type="radio" value="si" />Si <input id="rbpedago_no" type="radio" name="rbpedago" value="no" />No
                    </td>
                </tr>
             
                <tr>

                   <td class="bold">
                          <br />
                              Si se han incorporado algunas modificaciones identifique que aspectos se han incorporado, siendo 1 en menor proporción y 5 completamente incorporados</td>
                          </tr>
                   <tr>
                    <td>
                      <div class="titu">
                            <label>Modificaciones
                            </label>
                        </div>
                    <ul class="ul">
                      
                        <li class="liimpar">
                            <p class="prbutton">1. Las preguntas de investigación de los proyectos que se ejecutan en su institución han aportado al desarrollo del plan curricular</p>

                        <div class="radio">
                            <input type="radio" name="preg31" id="preg31_1" value="1"/>1
                            <input type="radio" name="preg31" id="preg31_2" value="2"/>2
                            <input type="radio" name="preg31" id="preg31_3" value="3"/>3
                            <input type="radio" name="preg31" id="preg31_4" value="4"/>4
                            <input type="radio" name="preg31" id="preg31_5" value="5"/>5
                        </div>
                    </li>
                        <li class="lipar">
                            <p class="prbutton">2. En los objetivos curriculares se incorporó el proceso de investigación de los estudiantes.</p>

                        <div class="radio">
                            <input type="radio" name="preg32" id="preg32_1" value="1"/>1
                            <input type="radio" name="preg32" id="preg32_2" value="2"/>2
                            <input type="radio" name="preg32" id="preg32_3" value="3"/>3
                            <input type="radio" name="preg32" id="preg32_4" value="4"/>4
                            <input type="radio" name="preg32" id="preg32_5" value="5"/>5
                        </div>
                        </li>
                        <li class="liimpar"><p class="prbutton">2. En los objetivos curriculares se incorporó el proceso de investigación de los estudiantes.</p>

                        <div class="radio">
                            <input type="radio" name="preg33" id="preg33_1" value="1"/>1
                            <input type="radio" name="preg33" id="preg33_2" value="2"/>2
                            <input type="radio" name="preg33" id="preg33_3" value="3"/>3
                            <input type="radio" name="preg33" id="preg33_4" value="4"/>4
                            <input type="radio" name="preg33" id="preg33_5" value="5"/>5
                       </div>
                            </li>
     
                        <li class="lipar">
                            <p class="prbutton">4. Los contenidos curriculares tienen relación con las temáticas que proponen los proyectos de investigación desarrollados en el marco de la IEP apoyada en TIC</p>

                        <div class="radio">
                            <input type="radio" name="preg34" id="preg34_1" value="1"/>1
                            <input type="radio" name="preg34" id="preg34_2" value="2"/>2
                            <input type="radio" name="preg34" id="preg34_3" value="3"/>3
                            <input type="radio" name="preg34" id="preg34_4" value="4"/>4
                            <input type="radio" name="preg34" id="preg34_5" value="5"/>5
                        </div>
                    </li>
                     <li class="liimpar">
                            <p class="prbutton">5. Se transversalizan las áreas del saber a través de la metodología de proyectos (IEP).</p>

                        <div class="radio">
                            <input type="radio" name="preg35" id="preg35_1" value="1"/>1
                            <input type="radio" name="preg35" id="preg35_2" value="2"/>2
                            <input type="radio" name="preg35" id="preg35_3" value="3"/>3
                            <input type="radio" name="preg35" id="preg35_4" value="4"/>4
                            <input type="radio" name="preg35" id="preg35_5" value="5"/>5
                        </div>
                        </li>
                     <li class="lipar">
                         <p class="prbutton">6. Se introducen mejores prácticas pedagógicas en el aula de clases que surgen de la implementación de la IEP.</p>

                        <div class="radio">
                            <input type="radio" name="preg36" id="preg36_1" value="1"/>1
                            <input type="radio" name="preg36" id="preg36_2" value="2"/>2
                            <input type="radio" name="preg36" id="preg36_3" value="3"/>3
                            <input type="radio" name="preg36" id="preg36_4" value="4"/>4
                            <input type="radio" name="preg36" id="preg36_5" value="5"/>5
                        </div></li>

                      <li class="liimpar">
                            <p class="prbutton">7. Se modifican los microcurrículos.</p>

                        <div class="radio">
                            <input type="radio" name="preg37" id="preg37_1" value="1"/>1
                            <input type="radio" name="preg37" id="preg37_2" value="2"/>2
                            <input type="radio" name="preg37" id="preg37_3" value="3"/>3
                            <input type="radio" name="preg37" id="preg37_4" value="4"/>4
                            <input type="radio" name="preg37" id="preg37_5" value="5"/>5
                        </div>
                    </li>
                    <li class="lipar">
                            <p class="prbutton">8. Se apropian de metodologías que contribuyen al desarrollo del pensamiento. científico y crítico.</p>

                        <div class="radio">
                            <input type="radio" name="preg38" id="preg38_1" value="1"/>1
                            <input type="radio" name="preg38" id="preg38_2" value="2"/>2
                            <input type="radio" name="preg38" id="preg38_3" value="3"/>3
                            <input type="radio" name="preg38" id="preg38_4" value="4"/>4
                            <input type="radio" name="preg38" id="preg38_5" value="5"/>5
                        </div>
                        </li>
                    <li class="liimpar">
                        <p class="prbutton">9. Se utilizan herramientas TIC en el proceso de enseñanza aprendizaje</p>

                        <div class="radio">
                           <input type="radio"  name="preg39" id="preg39_1" value="1"/>1
                            <input type="radio" name="preg39" id="preg39_2" value="2"/>2
                            <input type="radio" name="preg39" id="preg39_3" value="3"/>3
                            <input type="radio" name="preg39" id="preg39_4" value="4"/>4
                            <input type="radio" name="preg39" id="preg39_5" value="5"/>5
                        </div></li>

                    
                
                        <li class="lipar">
                            <p class="prbutton">10. Se desarrollan procesos de investigación en las jornadas complementarias.</p>

                        <div class="radio">
                            <input type="radio" name="preg40" id="preg40_1" value="1"/>1
                            <input type="radio" name="preg40" id="preg40_2" value="2"/>2
                            <input type="radio" name="preg40" id="preg40_3" value="3"/>3
                            <input type="radio" name="preg40" id="preg40_4" value="4"/>4
                            <input type="radio" name="preg40" id="preg40_5" value="5"/>5
                        </div>
                    </li>
                     </ul>
                        
                    </td>
                </tr>

                <tr>
                     <td class="bold">
                         <br />
                         4.	A partir de la formación de maestros recibida en el Programa sobre la Investigación como Estrategia Pedagógica apoyada e TIC, indique ¿si considera que el modelo educativo de su institución favorece la incorporación de esta propuesta pedagógica al currículo?</td>
                </tr>
                 <tr>
                    <td>
                        <input id="preg4_si" name="preg4" type="radio" value="si" />Si 
                        <input id="preg4_no" type="radio" name="preg4" value="no" />No
                    </td>
                </tr>
                <tr>
                <td class="bold">
                <br />
                            Si la respuesta a la pregunta anterior fue SI indique cómo el modelo educativo de su institución favorece la incorporación de la IEP apoyada en TIC al currículo.</td>
                    </tr>

                 

                <tr>
                    <td>
                    <div class="titu">
                            <label>De qué manera se favorece
                            </label>
                        </div>
                    <ul class="ul">
                        <li class="liimpar">
                            <p class="prbutton">1. Incorpora las TIC en la enseñanza</p>

                        <div class="radio">
                            <input type="radio" name="preg41" id="preg41_1" value="1"/>1
                            <input type="radio" name="preg41" id="preg41_2" value="2"/>2
                            <input type="radio" name="preg41" id="preg41_3" value="3"/>3
                            <input type="radio" name="preg41" id="preg41_4" value="4"/>4
                            <input type="radio" name="preg41" id="preg41_5" value="5"/>5
                        </div>
                    </li>
                    <li class="lipar">
                            <p class="prbutton">2. Favorece el desarrollo del aprendizaje colaborativo, situado, problematizador y por indagación crítica.</p>

                        <div class="radio">
                            <input type="radio" name="preg42" id="preg42_1" value="1"/>1
                            <input type="radio" name="preg42" id="preg42_2" value="2"/>2
                            <input type="radio" name="preg42" id="preg42_3" value="3"/>3
                            <input type="radio" name="preg42" id="preg42_4" value="4"/>4
                            <input type="radio" name="preg42" id="preg42_5" value="5"/>5
                        </div>
                        </li>
                        <li class="liimpar">
                            <p class="prbutton">3. Fomenta la investigación en estudiantes y docentes.</p>

                        <div class="radio">
                            <input type="radio" name="preg43" id="preg43_1" value="1"/>1
                            <input type="radio" name="preg43" id="preg43_2" value="2"/>2
                            <input type="radio" name="preg43" id="preg43_3" value="3"/>3
                            <input type="radio" name="preg43" id="preg43_4" value="4"/>4
                            <input type="radio" name="preg43" id="preg43_5" value="5"/>5
                        </div></li>

                         <li class="lipar">
                            <p class="prbutton">4. Fomenta la innovación y la indagación a través del desarrollo de proyectos.</p>

                        <div class="radio">
                            <input type="radio" name="preg44" id="preg44_1" value="1"/>1
                            <input type="radio" name="preg44" id="preg44_2" value="2"/>2
                            <input type="radio" name="preg44" id="preg44_3" value="3"/>3
                            <input type="radio" name="preg44" id="preg44_4" value="4"/>4
                            <input type="radio" name="preg44" id="preg44_5" value="5"/>5
                        </div>
                    </li>


                    </ul>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Nota:</b> Los modelos educativos según el MEN son Aceleración de aprendizaje, Escuela Nueva, postprimaria, telesecundaria, Servicio de Educación Rural – SER, Programa de educación continuada – CAFAM, Sistema de aprendizaje tutorial – SAT, 
                        Propuesta de formación para jóvenes y adultos –A CRECER o transformemos. 
                    </td>
                </tr>

                  <tr>
                     <td class="bold">
                         <br />
                        5.	Finalizada la ejecución del Programa Ciclón, ¿qué cambios considera Usted que se generaron en sus estudiantes ?</td>
                </tr>
                 <tr>
                    <td>
                        <input id="preg5_si" name="preg5" type="radio" value="si" />Si
                        <input id="preg5_no" type="radio" name="preg5" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Si la respuesta a la pregunta anterior fue SI indiqué qué cambios se generaron en sus estudiantes: </b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>La definición de las opciones para identificar los cambios generados en los estudiantes, se organiza según lo definido por el ICFES (2007) en: Fundamentación conceptual área de Ciencias Naturales. Bogotá: Secretaría General, Grupo Editorial, ICFES, por lo tanto, se sugiere leer el Anexo No. 1 para responder la pregunta. </b>
                    </td>
                </tr>
                 <tr>

                <td>
                    <br/>
                    <table class="mGridTesoreria">
                           <thead>
                               <tr>

                                <th>Cambios generados en los estudiantes</th>
                                <th>Seleccione</th>
                            </tr>
                           </thead>
                        
                        <tbody><tr>

                            <td>1. Fortalecieron sus conocimientos en la parte investigativa</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="conocimientos" value="conocimientos"/></td>
                        </tr>
                        <tr>

                            <td>2. Desarrollaron la capacidad de liderazgo. </td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="liderazgo" value="liderazgo"/></td>
                        </tr>
                        <tr>

                            <td>3. Desarrollaron su espíritu investigativo y muestran interés por el conocimiento</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="investigativo" value="investigativo"/></td>
                        </tr>
                         <tr>

                            <td>4. Los estudiantes se ven más creativos y participativos en las clases</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="creativos" value="creativos"/></td>
                        </tr>
                        <tr>

                            <td>5. Los estudiantes utilizan el internet y las tabletas entregadas por el programa Ciclón en el desarrollo de las clases y los procesos investigativos.</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="internet" value="internet"/></td>
                        </tr>
                        <tr>

                            <td>6. Desarrollaron los aprendizajes colaborativo, situado, problematizador y por indagación crítica.</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="colaborativo" value="colaborativo"/></td>
                        </tr>
                        <tr>

                            <td>7. Desarrollaron la capacidad para reconocer y diferenciar fenómenos, representaciones y preguntas pertinentes a problemáticas de su contexto familiar, social, ambiental, escolar. (Identificar)</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="reconocer" value="reconocer"/></td>
                        </tr>
                        <tr>

                            <td>8. Desarrollaron la capacidad para plantear preguntas y procedimientos [de investigación] adecuados para dar respuesta a esas preguntas. (Indagar)</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="preguntas" value="preguntas"/></td>
                        </tr>
                        <tr>

                            <td>9. Desarrollaron la capacidad para construir y comprender argumentos que den razón de los fenómenos y problemáticas de su contexto familiar, social, ambiental, escolar. (Explicar)</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="comprender" value="comprender"/></td>
                        </tr>
                            <tr>

                            <td>10. Desarrollaron la capacidad para escuchar, plantear puntos de vista y compartir conocimiento. (Comunicar)</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="escuchar" value="escuchar"/></td>
                        </tr>
                            <tr>

                            <td>11. Desarrollaron la capacidad de interactuar productivamente asumiendo compromisos. (Trabajar en equipo)</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="interactuar" value="interactuar"/></td>
                        </tr>
                            <tr>

                            <td>12. Disposición para aceptar la naturaleza abierta, parcial y cambiante del conocimiento.</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="naturaleza" value="naturaleza"/></td>
                        </tr>
                            <tr>

                            <td>13. Disposición para reconocer la dimensión social del conocimiento y para asumirla responsablemente.</td>
                            <td style="font-weight:bold;text-align:center"><input type="checkbox" name="ieptics" id="dimension" value="dimension"/></td>
                        </tr>
                    </tbody>
                </table>
                </td>
            </tr>

                <tr>
                    <td>
                        <br />
                        6.	Si el PEI considera el uso de las TIC en las prácticas institucionales, ¿cuáles de las siguientes TICS hacen parte de las prácticas institucionales que promueven? 
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="1" class="mGridTesoreria">
      <thead>
        <tr>
          <th colspan="2">Manejo de hardware y software</th>
          <th colspan="2">Manejo de recursos en internet</th>
          <th colspan="2">Estrategias de comunicacion</th>
          <th colspan="2">productos y soluciones</th>


        </tr>
      </thead>
      <tbody>
        <tr>
          <td><b>Equipos</b></td>
          <td>%</td>
          <td><b>Para docencia</b></td>
          <td>%</td>
          <td><b>Redes sociales</b></td>
          <td>%</td>
          <td><b>Herramientas virtuales</b></td>
          <td>%</td>
        </tr>
        <tr>
          <td>Computador</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="computador" value="Computador"/></td>
          <td>Google drive</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="googled" value="Google drive"/></td>
          <td>E-mail</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="emaikl" value="E-mail"/></td>
          <td>Contenido de audio</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="caudio" value="Contenido de audio"/></td>
        </tr>
        <tr>
          <td>Impresora</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="impresora" value="Impresora"/></td>
          <td>Eduka</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="eduka" value="Eduka"/></td>
          <td>Whatsapp</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="whatsapp" value="Whatsapp"/></td>
          <td>Contenido audiovisual</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="audiovisual" value="Contenido audiovisual"/></td>
        </tr>
        <tr>
          <td>Video Beam</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="videobeam" value="Video Beam"/></td>
          <td>Google sites</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="googlesite" value="Google sites"/></td>
          <td>Google group</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="googlegrup" value="googlegrup"/></td>
          <td>Contenido Multimedia</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="multimedia" value="Contenido Multimedia"/></td> 
        </tr>
        <tr>
          <td>Video cámara</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="videocamara" value="Video camara"/></td>
          <td>Educared</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="educared" value="Educared"/></td>
          <td>Twiter</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="twitter" value="Twiter"/></td>
          <td>Publicaciones WEB</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="pweb" value="Publicaciones WEB"/></td> 
        </tr>
        <tr>
          <td>Reproductor DVD</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="dvd" value="Reproductor DVD"/></td>
          <td>Google educa</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="googleedu" value="Google educa"/></td>
          <td>Mesenger</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="messenger" value="Mesenger"/></td>
          <td>Administración canal Web</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="aweb" value="Administracion canal Web"/></td> 
        </tr>
        <tr>
          <td>Celular</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="celular" value="Celular"/></td>
          <td>Eduteka</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="eduteka" value="Eduteka"/></td>
          <td>Facebook</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="facebook" value="Facebook"/></td>
          <td>Administración Red Social</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="adredsocial" value="Administración Red Social"/></td> 
        </tr>
        <tr>
          <td>Escaner</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="escaner" value="Escaner"/></td>
          <td>Colombia aprende</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="colomapren" value="Colombia aprende"/></td>
          <td>Web personal</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="webpersonal" value="Web personal"/></td>
          <td>Foros</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="foros" value="Foros"/></td> 
        </tr>
        <tr>
          <td>Fotocopiadora</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="fotocopia" value="Fotocopiadora"/></td>
          <td>Wikipedia</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="wikipedia" value="Wikipedia"/></td>
          <td>Skype</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="skype" value="Skype"/></td>
          <td>Blogs</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="blogs" value="Blogs"/></td> 
        </tr>
        <tr>
          <td>Proyector acetato</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="proyectorace" value="Proyector acetato"/></td>
          <td>Computadores para educar</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="computadoresedu" value="Computadores para educar"/></td>
          <td>Wiki</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="wiki" value="Wiki"/></td> 
        </tr>
        <tr>
          <td>Otros Equipos</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros1" value="Otros Equipos"/></td>
          <td>Otros Para Docencias</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros2" value="Otros Para Docencias"/></td>
          <td>Otros Redes sociales</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros3" value="Otros Redes sociales"/></td>
          <td>Otros Herramientas Virtuales</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros4" value="Otros Herramientas Virtuales"/></td> 
        </tr>  
        <tr>
          <td>Ninguno Equipos</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno1" value="Ninguno Equipos"/></td>
          <td>Ninguno Para Docencia </td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno2" value="Ninguno Para Docencia"/></td>
          <td>Ninguno Redes Sociales</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno3" value="Ninguno Redes Sociales"/></td>
          <td>Ninguno Herrameitnas Virtuales</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno4" value="Ninguno Herrameitnas Virtuales"/></td> 
        </tr>

        <tr>
          <td><b>Dispositivos</b></td>
          <td>%</td>
          <td><b>Herramientas formación virtual</b></td>
          <td>%</td>
          <td><b>Plataformas que conoce</b></td>
          <td>%</td>
          <td></td>
          <td></td>
        </tr> 

        <tr>
          <td>Disco 3/2</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="disco32" value="Disco 3/2"/></td>
          <td>Aula Fácil (cursos gratis Online)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="free" value="Aula Fácil (cursos gratis Online)"/></td>
          <td>SIGCE (Gestión SED)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="sigce" value="SIGCE (Gestión SED)"/></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>CD ROM</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="cdrom" value="CD ROM"/></td>
          <td>Coursera</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="courseras" value="Coursera"/></td>
          <td>SIMAT (Sistema matrícula - MEN)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="simat" value="SIMAT (Sistema matrícula - MEN)"/></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>DVD</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="cdvd" value="DVD"/></td>
          <td>Blackboard</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="black" value="Blackboard"/></td>
          <td>SGCF (Sistema gestión y control financiero MEN)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="sgcf" value="SGCF (Sistema gestión y control financiero MEN)"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>USB</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="usb" value="USB"/></td>
          <td>YouTube</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="youtube" value="YouTube"/></td>
          <td>SINEB (Sistema de Educación Básiac</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="sineb" value="SINEB (Sistema de Educación Básiac"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Micro SD</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="microsd" value="Micro SD"/></td>
          <td>Conferencia TED</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ted" value="Conferencia TED"/></td>
          <td>SICIED (Sistema de consulta infraestructura)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="sicied" value="SICIED (Sistema de consulta infraestructura)"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Blu-Ray</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="bluray" value="Blu-Ray"/></td>
          <td>Moodle</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="moodle" value="Moodle"/></td>
          <td>SINIES (Sistema información Educación Superior)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="sinies" value="SINIES (Sistema información Educación Superior)"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Celulares y smartphones</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="celulares" value="Celulares y smartphones"/></td>
          <td>Webdubox</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="webdubox" value="Webdubox"/></td>
          <td>SAC (Unidad Atención ciudadano)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="sac" value="SAC (Unidad Atención ciudadano)"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Otros Dispositivos</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros5" value="Otros Dispositivos"/></td>
          <td>Otros Herramientas formación</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros6" value="Otros Herramientas formación"/></td>
          <td>Otros Plataformas que conoce</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="otros7" value="Otros Plataformas que conoce"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Ninguno Dispositivos</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno5" value="Ninguno Dispositivos"/></td>
          <td>Ninguno Herramientas formación</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno6" value="Ninguno Herramientas formación"/></td>
          <td>Ninguno Plataformas que conoce</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ninguno7" value="Ninguno Plataformas que conoce"/></td>
          <td></td>
          <td></td>
         </tr>

         <tr>
          <td><b>Sistema Operativo</b></td>
          <td>%</td>
          <td><b> Plataformas del programa Ciclón</b></td>
          <td>%</td>
          <td><b>Integración en el aula y  formación  en TIC</b></td>
          <td>%</td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>Windows</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="window" value="Windows"/></td>
          <td> Juego Gózate la Ciencia</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="gozate" value="Gózate la ciencia"/></td>
          <td>AQTCR (A que te cojo ratón)</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="aqtcr" value="AQTCR (A que te cojo ratón)"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Linux</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="linux" value="Linux"/></td>
          <td>Moodle</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="cuc" value="La de la CUC"/></td>
          <td>Proyect</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="proyect" value="Proyect"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Android</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="android" value="Android"/></td>
          <td> Blackboard</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="unimag" value="La de la UNIMAG"/></td>
          <td>Compartel</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="compartel" value="Compartel"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>MacOS</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="macos" value="MacOS"/></td>
          <td>Página web programa Ciclón</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="ciclon" value="Página web programa Ciclón"/></td>
          <td>Entre pares</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="entrepares" value="Entre pares"/></td>
          <td></td>
          <td></td>
         </tr>
         <tr>
          <td>Chrome</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="chrome" value="Chrome"/></td>
          <td>Macondo</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="macondo" value="Macondo"/></td>
          <td>INTEL</td>
          <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="p10" id="intel" value="INTEL"/></td>
          <td></td>
          <td></td>
         </tr>
          </td>
          </tr>     
      </tbody>
    </table>

      <tr>
        <td>
            <b>Una adecuación de: Instrumentos línea de base del proyecto: FORTALECIMIENTO DE CAPACIDADES EN CONOCIMIENTO, INVESTIGACIÓN, CIENCIA, TECNOLOGÍA, E INNOVACIÓN, ENCAUZADOS AL DESARROLLO INTEGRAL DEL SECTOR EDUCATIVO, MEDIADO POR LAS TICs, EN CASANARE. CUN, 2017</b>
        </td>
    </tr>
                 <tr>
                     <td class="bold">
                         <br />
                        7.	Finalizada la ejecución del Programa Ciclón, considera Usted que el uso de las TIC en los procesos de investigación y formación ¿modificaron su práctica pedagógica? </td>
                </tr>
                 <tr>
                    <td>
                        <input id="preg7_si" name="preg7" type="radio" value="si" />Si 
                        <input id="preg7_no" type="radio" name="preg7" value="no" />No
                    </td>
                </tr>
                <tr>
                    <td class="bold"><br />

                        Si la respuesta a la pregunta anterior fue SI indiqué qué aspectos de su práctica pedagógica se modificaron:

                    </td>

                </tr>
                
                 <tr>
                    <td>
                        <table align="center" class="mGridTesoreria">
                            
                            <thead>
                                <tr>
                                    <th>Cambios producidos en su práctica pedagógica por el uso de las TIC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </thead>
                            <tr>
                                <td>1.	Consolidan los procesos de investigación e innovación.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticinves" value="Consolidan los procesos"  /></td>
                                

                            </tr>
                            <tr>
                                <td>2.	Facilitan el trabajo en el aula.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticaula" value="Facilitan el trabajo en el aula"  /></td>
                                
                            </tr>

                            <tr>
                                <td>3.	Motivan a los estudiantes.  </td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticestudiante" value="Motivan a los estudiantes"  /></td>
                             
                            </tr>
                             <tr>
                                <td>4.	Incrementan el interés de los estudiantes por algunas materias.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticmaterias" value="Incrementan el interés de los estudiantes"  /></td>
                         
                            </tr>
                             <tr>
                                <td>5.	Favorecen la interacción, la comunicación y el intercambio de experiencias.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticcomunicacion" value="Favorecen la interacción, la comunicación"  /></td>
                           
                            </tr>
                             <tr>
                                <td>6.	Mejoran los resultados educativos de los estudiantes.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticeducativos" value="Mejoran los resultados educativos"  /></td>
                          
                            </tr>
                            <tr>
                                <td>7.	Favorecen el desarrollo de nuevas estrategias pedagógicas innovadoras en el aula.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticdesarrollo" value="Favorecen el desarrollo de nuevas estrategias"  /></td>
                         
                            </tr>
                            <tr>
                                <td>8.	Facilitan la realización de experiencias, trabajos o proyectos en común.</td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticexperiencia" value="Facilitan la realización de experiencias"  /></td>
                          
                            </tr>
                            <tr>
                                <td>9.	Ayudan a corregir los errores que se producen en el aprendizaje. </td>
                                <td style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticerrores" value="Ayudan a corregir los errores que se producen"  /></td>
                        
                            </tr>
                            <tr>
                                <td>10.	Favorecen el desarrollo de la iniciativa y la creatividad del alumno.</td>
                                <td  style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticiniciativa" value="Favorecen el desarrollo de la iniciativa"/></td>
                        
                            </tr>
                            <tr>
                                <td>11.	Incrementan la autonomía. </td>
                                <td  style="text-align:center; vertical-align: middle;"><input type="checkbox" name="preg71" id="ticautonomia" value="Incrementan la autonomía"/></td>
                        
                            </tr>
                            </table>
                            </td>

                            </tr>
               
            </fieldset>

                <tr>
                    <td colspan="6">
                         <input type="button" id="btn-guardar" value="Guardar" onclick="enviar()" class="btn btn-success" />
                    </td>
                </tr>

              

                 
          







    <%--AQUI FINALIZA EL INSTRUMENTO 5 IMPACTO--%>




     <table align="center">
        <tr>
            <td>
                <asp:Button ID="btnIniciarInfoBasica" Visible="false" runat="server" CssClass="btn btn-primary" Text="001A - Información básica IES" OnClick="btnIniciarInfoBasica_Click" />
            </td>
            <td>
                <asp:Button ID="btnIniciarInfoBasica2" Visible="false" runat="server" CssClass="btn btn-primary" Text="01 - Información básica IES" OnClick="btnIniciarInfoBasica2_Click" />
            </td>
              <td>
                <asp:Button ID="btnIniciarCaracterizacion" Visible="false" runat="server" CssClass="btn btn-primary" Text="02 - Currículo" OnClick="btnIniciarCaracterizacion_Click" />
            </td>
        </tr>
    </table>
     

  <!-- Instrumento 001A -->
    <asp:Panel ID="PanelInstrumento001A" runat="server" Visible="false">

          <fieldset>
        <legend>Datos del Asesor</legend>
        <table>
                <tr>
                    <td>
                        Seleccione el Asesor
                    </td>
                    <td>
                        <asp:DropDownList ID="dropAsesor" runat="server" CssClass="TextBox" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropAsesor" runat="server" Display="None" ErrorMessage="Seleccione el Asesor"
                            ControlToValidate="dropAsesor" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVdropAsesor"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
            </table>
    </fieldset>

        <table>
            <tr>
                <td>
                   <b>Introducción</b>  <br /><br />

                    Para la construcción de la línea de base del proyecto Ciclón se requiere recoger información institucional básica sobre el equipamiento institucional de TIC y su uso pedagógico, con el objeto de aportar indicadores para la línea de base del proyecto. <br />
                    Para su elaboración se hizo una revisión del marco de política tanto a nivel nacional como departamental para indagar sobre la normatividad con referencia a TIC. Los artículos 20 y 67 de la Constitución Política establecen que el Estado promoverá el derecho al acceso a las Tecnologías de la Información y las Comunicaciones que permitan entre otros, el ejercicio pleno al derecho de la educación. Inspirada en estos principios, la Ley 1341 de febrero de 2009 establece que las entidades del orden nacional y territorial dispondrán lo pertinente para garantizar el uso y acceso a estos derechos. Igualmente el Plan Nacional de Tics 2008 - 2019 genera directrices al mismo fin.
                    <br /><br />

                    <b>Objetivo</b><br />
                    Acopiar información de línea de base sobre el equipamiento y uso de TIC, en las sedes educativas vinculadas al proyecto Ciclón.
                     <br /><br />

                   <b> Metodología</b><br />

                    Este instrumento será diligenciado en dos partes:<br />
                    La primera parte será migrado de los instrumentos 01, C600A y C600B o del SIMAT.<br />
                    La segunda parte del instrumento será implementado por el Docente Asesor de FUNTIC o quien haga sus veces con el Rector/a, Director/a o a quien se delegue en la Institución Educativa diligenciado directamente en el SIEP. 

                </td>
            </tr>
        </table>

        <fieldset>
            <legend>Identificación</legend>

           <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
               <tr>
                   <td>
                       Código DANE de la Institución educativa
                   </td>
                   <td>
                       <asp:TextBox ID="txtDANE" runat="server" CssClass="TextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVtxtDANE" runat="server" Display="None" ErrorMessage="Digite el código DANE de la institución"
                    ControlToValidate="txtDANE" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVtxtDANE"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                   </td>
                   <td>
                       Nombre Institución educativa
                   </td>
                   <td>
                        <asp:TextBox ID="txtNomInstitucion" runat="server" CssClass="TextBox"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RFVtxtNomInstitucion" runat="server" Display="None" ErrorMessage="Digite el nombre de la institución"
                    ControlToValidate="txtNomInstitucion" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RFVtxtNomInstitucion"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                   </td>
                     <td>
                       Nombre rector
                   </td>
                   <td>
                     <asp:DropDownList ID="dropNomRector" runat="server" CssClass="TextBox" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFdropNomRector" runat="server" Display="None" ErrorMessage="Seleccione el Nombre del Rector"
                    ControlToValidate="dropNomRector" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RFdropNomRector"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                   </td>
               </tr>
               <tr>
                  <td>
                      Dirección
                   </td>
                   <td>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                   <td>
                       Teléfono
                   </td>
                   <td>
                       <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                   <td>
                       Fax
                   </td>
                   <td>
                       <asp:TextBox ID="txtFax" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                  
               </tr>
               <tr>
                   
                   <td>
                       Correo electrónico
                   </td>
                   <td>
                         <asp:TextBox ID="txtemail" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
                   <td>
                        Sitio Web
                   </td>
                   <td>
                       <asp:TextBox ID="txtWeb" runat="server" CssClass="TextBox"></asp:TextBox>
                   </td>
               </tr>
            </table>

        </fieldset>

        <fieldset>
            <legend>Ubicación y localización física de la institución educativa</legend>
              <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;">
                  <tr>
                      <td>
                          Departamento <asp:DropDownList ID="dropDepartamento" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropCiudad_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFdropDepartamento" runat="server" Display="None" ErrorMessage="Seleccione el Departamento"
                    ControlToValidate="dropDepartamento" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RFdropDepartamento"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>

                            Ciudad  <asp:DropDownList ID="dropCiudad" runat="server" CssClass="TextBox"></asp:DropDownList> 
                           <asp:RequiredFieldValidator ID="RFVdropCiudad" runat="server" Display="None" ErrorMessage="Seleccione la Ciudad"
                    ControlToValidate="dropCiudad" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RFVdropCiudad"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                            
                           Zona <asp:DropDownList ID="dropZona" runat="server" CssClass="TextBox"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RFVdropZona" runat="server" Display="None" ErrorMessage="Seleccione la Zona"
                    ControlToValidate="dropZona" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RFVdropZona"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                      </td>
           
                  </tr>
                  <tr>
                      <td>
                          Nro. Total de Sedes:
                              Activas  <asp:TextBox ID="txtActivas" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                           Inactivas   <asp:TextBox ID="txtInactivas" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                      </td>
               
                  </tr>
                  </table>
        </fieldset>

        <fieldset>
            <legend>Propiedad Jurídica</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                 <tr>
                     <td>
                         Propiedad Jurídica
                         <asp:DropDownList ID="dropPropiedadJuridica" runat="server" CssClass="TextBox"></asp:DropDownList>
                     </td>
          
                 </tr>
                 </table>
        </fieldset>
        <table align="center"><tr><td><asp:Button ID="btnPrimerGuardar" ValidationGroup="addUsuario" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar_Onclick" /></td></tr></table>
        <fieldset>
            <legend>Niveles de enseñanza</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;"  >
                 <tr>
                     <td width="25%">
                       <b> 1.  Niveles de enseñanza que ofrece</b>
                     </td>
                     <td >
                         <asp:CheckBoxList ID="chkNivelesEnsenaza" runat="server">
                             <asp:ListItem>Preescolar</asp:ListItem>
                             <asp:ListItem>Básica primaria</asp:ListItem>
                             <asp:ListItem>Básica secundaria</asp:ListItem>
                             <asp:ListItem>Media</asp:ListItem>
                         </asp:CheckBoxList>
                     </td>
                 </tr>
                 </table>
             <fieldset>
                <legend>Programas, estrategias o modelos educativos</legend>
                    <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" border="0">
                        <tr>
                            <td>
                              <b> 2. Programas, estrategias o modelos educativos que ofrecen</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Preescolar</b>
                            </td>
                            <td>
                                <b>Básica primaria</b>
                            </td>
                             </tr>
                        <tr>
                            <td>
                                <asp:CheckBoxList ID="chkProgramaEstrategiaModeloPreescolar" runat="server"  >
                                    <asp:ListItem>Preescolar escolarizado</asp:ListItem>
                                    <asp:ListItem>Preescolar semi-escolarizado</asp:ListItem>
                                    <asp:ListItem>Preescolar no escolarizado</asp:ListItem>
                                </asp:CheckBoxList>
                                Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloPreescolar" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                             <td>
                                 <asp:CheckBoxList ID="chkProgramaEstrategiaModeloPrimaria" runat="server" RepeatColumns="2">
                                    <asp:ListItem>Educación tradicional</asp:ListItem>
                                    <asp:ListItem>Escuela nueva</asp:ListItem>
                                    <asp:ListItem>SER</asp:ListItem>
                                    <asp:ListItem>CAFAM</asp:ListItem>
                                    <asp:ListItem>Etnoeducación</asp:ListItem>
                                    <asp:ListItem>Aceleración del aprendizaje</asp:ListItem>
                                    <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                                    <asp:ListItem>Transformemos</asp:ListItem>
                                </asp:CheckBoxList>
                                 Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloPrimaria" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            
                             <td>
                                 <b>Básica secundaria</b>
                            </td>
                            <td>
                                 <b>Media</b>
                            </td>
                             </tr>
                        <tr>
                           
                              <td>
                                 <asp:CheckBoxList ID="chkProgramaEstrategiaModeloSecundaria" runat="server">
                                    <asp:ListItem>Educación tradicional</asp:ListItem>
                                    <asp:ListItem>Posprimaria</asp:ListItem>
                                    <asp:ListItem>Telesecundaria</asp:ListItem>
                                    <asp:ListItem>SER</asp:ListItem>
                                    <asp:ListItem>CAFAM</asp:ListItem>
                                    <asp:ListItem>SAT</asp:ListItem>
                                    <asp:ListItem>Etnoeducación</asp:ListItem>
                                    <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                                    <asp:ListItem>Transformemos</asp:ListItem>
                                </asp:CheckBoxList>
                                 Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloSecundaria" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                             <td>
                                 <asp:CheckBoxList ID="chkProgramaEstrategiaModeloMedia" runat="server">
                                    <asp:ListItem>Educación tradicional</asp:ListItem>
                                    <asp:ListItem>SER</asp:ListItem>
                                    <asp:ListItem>CAFAM</asp:ListItem>
                                    <asp:ListItem>SAT</asp:ListItem>
                                    <asp:ListItem>Etnoeducación</asp:ListItem>
                                    <asp:ListItem>Programa para jóvenes en extraedad y adultos</asp:ListItem>
                                    <asp:ListItem>Transformemos</asp:ListItem>
                                </asp:CheckBoxList>
                                 Otro, ¿Cuál?<br />
                                <asp:TextBox ID="txtCualProgramaEstrategiaModeloMedia" CssClass="TextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                       
                      
                        </table>
                </fieldset>
        </fieldset>

        <fieldset>
            <legend>Jornadas</legend>
                <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
                    <tr>
                        <td width="25%">
                           <b> 3. Jornadas de la institución educativa</b>
                        </td>
                        <td>
                             <asp:CheckBoxList ID="chkJornadas" runat="server">
                                    <asp:ListItem>Completa</asp:ListItem>
                                    <asp:ListItem>Mañana</asp:ListItem>
                                    <asp:ListItem>Tarde</asp:ListItem>
                                    <asp:ListItem>Nocturna</asp:ListItem>
                                    <asp:ListItem>Fin de semana</asp:ListItem>
                                </asp:CheckBoxList>
                        </td>
                    </tr>
                    </table>
        </fieldset>

        <fieldset>
            <legend>Información del recurso humano en el presente año</legend>
             <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" border="0" >
                 <tr>
                     <td>
                       Relacione el número total de personas que prestan sus servicios en la institución educativa, según la función Primordial que cumplen en todas las sedes-jornadas y todos los niveles educativos que se imparten. Diligencie únicamente con cifras, no utilice otros signos.
                         <br />
                        <b> 4. Información en el presente año</b>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <b>Docentes</b>
                     </td>
                    
                   </tr>
                     <tr>
                          <td>
                         Directivo docente <asp:TextBox ID="txtDirectivoDocente" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>

                     </td>
                          </tr>
                     <tr>
                         <td>
                             Docentes (no incluya educadores especiales ni etnoeducadores) <asp:TextBox ID="txtDocentes" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                         </td>
                     </tr>
                <tr>
                    <td>
                        Docentes de educación especial <asp:TextBox ID="txtDocenteEspecial" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                     <td>
                         Docentes de etnoeducación <asp:TextBox ID="txtDocentesEtno" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <b>Otros</b>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos) <asp:TextBox ID="txtDirectivos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales <asp:TextBox ID="txtConsejeros" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Médicos, odontólogos, nutricionistas, terapeutas y enfermeros <asp:TextBox ID="txtMedicos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Administrativos (de apoyo y personal de servicios generales) <asp:TextBox ID="txtAdministrativos" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.) <asp:TextBox ID="txtProfesionales" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td> 
                 </tr>
                 <tr>
                     <td>
                         Tutores <asp:TextBox ID="txtTutores" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Auxiliar de aula <asp:TextBox ID="txtAula" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Otros <asp:TextBox ID="txtOtros" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     </td>
                 </tr>
                 </table>
        </fieldset>

        <table align="center"><tr><td><asp:Button ID="btnSegundoGuardado" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSegundoGuardado_Onclick" /></td></tr></table>

        <fieldset>
            <legend>Personas que prestan sus servicios en la institución educativa</legend>
            <table> 
                <tr><td>
                    Relacione todos los docentes que laboran en la institución educativa. Ubique al docente en el nivel educativo donde tenga la mayor carga académica. Incluya los docentes de horas extra. Diligencie únicamente con cifras, no utilice otros signos. 
                    </td></tr>
                <tr><td ><b>5. Personal docente por nivel de enseñanza, según último nivel educativo aprobado por el docente</b></td></tr></table>
             <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                
                <tr>
                    <td rowspan="4" colspan="2" style="font-weight:bold;">Último nivel educativo aprobado por el docente</td>
                </tr>
                <tr>
                    <td colspan="15" style="font-weight:bold;" align="center">Nivel educativo en el que dicta el docente</td>
                   
                </tr>
                <tr>
                    <td colspan="3" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Media</td>
                    <td colspan="3" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                    <td style="font-weight:bold;">Total</td>
                </tr>
              
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Bachillerato pedagógico</td>
                     <td><asp:TextBox ID="txtBachiHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtBachiHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtBachiMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtBachiTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Normalista superior</td>
                    <td><asp:TextBox ID="txtSuperiorHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtSuperiorHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSuperiorMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSuperiorTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Otro bachillerato</td>
                    <td><asp:TextBox ID="txtOtroBachiHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtroBachiHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroBachiMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroBachiTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                <tr>
                    <td rowspan="3" style="font-weight:bold;">Técnico o tecnológico</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pedagógico</td>
                     <td><asp:TextBox ID="txtTecPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTecPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTecPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTecPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Otro</td>
                   <td><asp:TextBox ID="txtOtroPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtroPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td rowspan="3" style="font-weight:bold;">Profesional</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pedagógico</td>
                    <td><asp:TextBox ID="txtProfPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtProfPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Otro</td>
                    <td><asp:TextBox ID="txtProfOtroPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtProfOtroPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtProfOtroPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtProfOtroPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td rowspan="3" style="font-weight:bold;">Posgrado</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pedagógico</td>
                    <td><asp:TextBox ID="txtPosPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPosPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosPedagoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Otro</td>
                    <td><asp:TextBox ID="txtPosOtroPedagoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPosOtroPedagoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPosOtroPedagoMujTotal" Enabled="false"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPosOtroPedagoTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
          
                 <tr>
                    <td style="font-weight:bold;" align="center" colspan="2">Otro</td>
                    
                     <td><asp:TextBox ID="txtOtroCualHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujPreescolar"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualTotalPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtroCualHomSecundaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujSecundaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualHomMedia"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujMedia"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtroCualMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtroCualTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td style="font-weight:bold;" align="center" colspan="2">Total</td>
                     
                     <td><asp:TextBox ID="txtTotalTotalHomPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomPrimaria" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalHomPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTotalTotalHomSecundaria" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomMedia" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalHomTotal" Visible="false" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalTotalMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalTotalTotalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:Button runat="server" ID="btnSumarTotales" Text="Calcular" OnClick="btnSumarTotales_Click" CssClass="btn btn-danger" /></td>
                </tr>
                
            </table>
            <table align="center"><tr><td><asp:Button ID="btnTercerGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnTercerGuardar_Onclick" /></td></tr></table>

            <br />

             <table width="100%"> <tr>
                     <td>
                         <hr />
                         Relacione únicamente los docentes. No relacione directivos ni personal administrativo. Ubique al docente en alguno de los cuadros 6.1 ó 6.2, en el área de enseñanza donde tenga la mayor carga académica. Incluya los docentes de horas extras. Diligencie únicamente con cifras, no utilice otros signos
                     </td>
                 </tr> <tr><td ><b>6. Personal docente por género y nivel educativo, según área de enseñanza</b></td></tr></table>

            6.1. Personal docente para el carácter académico
             <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
                
                <tr>
                    <td rowspan="4" style="font-weight:bold;" align="center">Áreas de enseñanza</td>
                </tr>
                <tr>
                    <td colspan="15" style="font-weight:bold;" align="center">Nivel educativo</td>
                   
                </tr>
                <tr>
                    <td colspan="2" style="font-weight:bold;" align="center">Preescolar</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Básica primaria</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Básica secundaria</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Media</td>
                    <td colspan="2" style="font-weight:bold;" align="center">Total</td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                      <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>

                     <td style="font-weight:bold;">Hombres</td>
                    <td style="font-weight:bold;">Mujeres</td>
                </tr>
              
                <tr>
                    <td style="font-weight:bold;">Todas las áreas</td>
                     <td><asp:TextBox ID="txtTodasAreasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtTodasAreasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTodasAreasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTodasAreasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="font-weight:bold;" >Ciencias naturales y educación ambiental</td>
                    <td><asp:TextBox ID="txtNaturalesHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtNaturalesHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtNaturalesHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtNaturalesMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="font-weight:bold;" align="center">Ciencias sociales, historia, geografía, constitución política y democracia</td>
                    <td><asp:TextBox ID="txtSocialesHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesHomPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujPrimaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtSocialesHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtSocialesHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtSocialesMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="font-weight:bold;">Educación artística</td>
                    <td><asp:TextBox ID="txtArtisticaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtArtisticaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtArtisticaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtArtisticaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtArtisticaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtArtisticaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

               <tr>
                    <td style="font-weight:bold;">Educación ética y en valores humanos </td>
                    <td><asp:TextBox ID="txtEticaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEticaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEticaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEticaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEticaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEticaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Educación física, recreación y deportes </td>
                    <td><asp:TextBox ID="txtDeportesHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtDeportesMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtDeportesHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtDeportesMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtDeportesHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtDeportesMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Educación religiosa </td>
                    <td><asp:TextBox ID="txtReligiosaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtReligiosaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtReligiosaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtReligiosaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtReligiosaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtReligiosaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Humanidades, lengua castellana e idiomas extranjeros</td>
                    <td><asp:TextBox ID="txtCastellanaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtCastellanaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtCastellanaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtCastellanaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtCastellanaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtCastellanaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Matemáticas</td>
                    <td><asp:TextBox ID="txtMatematicasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtMatematicasMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtMatematicasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtMatematicasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtMatematicasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtMatematicasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Tecnología e informática</td>
                    <td><asp:TextBox ID="txtInformaticaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtInformaticaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtInformaticaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtInformaticaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtInformaticaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtInformaticaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Ciencias económicas</td>
                    <td><asp:TextBox ID="txtEconomicasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEconomicasMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEconomicasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtEconomicasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtEconomicasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtEconomicasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Ciencias políticas</td>
                    <td><asp:TextBox ID="txtPoliticasHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPoliticasMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPoliticasHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPoliticasMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPoliticasHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtPoliticasMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
              
                  <tr>
                    <td style="font-weight:bold;">Filosofía</td>
                    <td><asp:TextBox ID="txtFilosofiaHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtFilosofiaMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtFilosofiaHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtFilosofiaMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtFilosofiaHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtFilosofiaMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;">Otra</td>
                    <td><asp:TextBox ID="txtOtraAcademicoHomPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoMujPreescolar" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoHomPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtraAcademicoMujPrimaria"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoHomSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoMujSecundaria" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtraAcademicoHomMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtOtraAcademicoMujMedia" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtOtraAcademicoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtOtraAcademicoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="font-weight:bold;" align="center" >Total</td>
                     
                     <td><asp:TextBox ID="txtTotalAcademicoHomPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoMujPreescolar" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalAcademicoMujPrimaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalAcademicoMujSecundaria" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                      <td><asp:TextBox ID="txtTotalAcademicoMujMedia" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoHomTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtTotalAcademicoMujTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                </tr>
            </table>
            <table align="center"><tr><td><asp:Button ID="btnCuartoguardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnCuartoguardar_Onclick" /></td></tr></table>
        </fieldset>

         <br />

             <table width="100%"> <tr>
                     <td>
                         <hr />
                     </td>
                 </tr> <tr><td >6.2. Personal docente para el carácter técnico, del nivel educativo Media</td></tr></table>

       <table border="1" cellspacing="0" cellpadding="2" bordercolor="#004b96">
            <tr>
                <td style="font-weight:bold;">Especialidad</td>
                <td style="font-weight:bold;">Áreas de enseñanza</td>
                <td style="font-weight:bold;">Hombres</td>
                <td style="font-weight:bold;">Mujeres</td>
                <td style="font-weight:bold;">Total</td>
            </tr>
            <tr>
                <td rowspan="4" style="font-weight:bold;">Agropecuario</td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Agrícola</td>
                 <td><asp:TextBox ID="txtAgricolaHom" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                <td><asp:TextBox ID="txtAgricolaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                <td><asp:TextBox ID="txtAgricolaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Pecuario</td>
                    <td><asp:TextBox ID="txtPecuarioHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtPecuarioMuj"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                     <td><asp:TextBox ID="txtPecuarioTotal" Enabled="false"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Otra ¿cuál?</td>
                   <td><asp:TextBox ID="txtAgroOtraHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtAgroOtraMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                   <td><asp:TextBox ID="txtAgroOtraTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
            </tr>
             <tr>
                <td rowspan="8" style="font-weight:bold;">Comercial y servicios</td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Contabilidad</td>
                 <td><asp:TextBox ID="txtContablidadHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtContablidadMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtContablidadTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Finanzas</td>
                  <td><asp:TextBox ID="txtFinanzasHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFinanzasMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFinanzasTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Administración y gestión</td>
                  <td><asp:TextBox ID="txtAdminGestionHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdminGestionMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdminGestionTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="font-weight:bold;">Administración</td>
                 <td><asp:TextBox ID="txtAdministracionHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdministracionMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAdministracionTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Ambiental</td>
                  <td><asp:TextBox ID="txtAmbientalHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAmbientalMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtAmbientalTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Salud</td>
                   <td><asp:TextBox ID="txtSaludHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtSaludMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtSaludTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
             </tr>
             <tr>
                <td style="font-weight:bold;">Otra ¿cuál?</td>
                  <td><asp:TextBox ID="txtOtraComercialHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraComercialMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraComercialTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
            </tr>
             <tr>
                <td rowspan="14" style="font-weight:bold;">Industrial</td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Electricidad</td>
                 <td><asp:TextBox ID="txtElectridadHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectridadMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectridadTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Electrónica</td>
                 <td><asp:TextBox ID="txtElectronicaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectronicaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtElectronicaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Mecánica industrial</td>
                 <td><asp:TextBox ID="txtMecaIndustrialHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaIndustrialMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaIndustrialTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                 <td style="font-weight:bold;">Mecánica automotriz</td>
                 <td><asp:TextBox ID="txtMecaAutomotrizHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaAutomotrizMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMecaAutomotrizTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Metalistería</td>
                  <td><asp:TextBox ID="txtMetalisteriaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalisteriaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalisteriaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Metalmecánica</td>
                <td><asp:TextBox ID="txtMetalmecanicaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalmecanicaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtMetalmecanicaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                 <td style="font-weight:bold;">Ebanistería</td>
                <td><asp:TextBox ID="txtEbanisterHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtEbanisteriaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtEbanisteriaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Fundición</td>
                 <td><asp:TextBox ID="txtFundicionHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFundicionMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtFundicionTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                <td style="font-weight:bold;">Construcciones civiles</td>
                  <td><asp:TextBox ID="txtCivilesHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtCivilesMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtCivilesTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
              </tr>
             <tr>
                 <td style="font-weight:bold;">Diseño mecánico</td>
                 <td><asp:TextBox ID="txtDisMecanicoHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisMecanicoMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisMecanicoTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                  </tr>
             <tr>
                <td style="font-weight:bold;">Diseño gráfico</td>
                 <td><asp:TextBox ID="txtDisGraficaHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisGraficaMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisGraficaTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                  </tr>
             <tr>
                <td style="font-weight:bold;">Diseño arquitectónico</td>
                  <td><asp:TextBox ID="txtDisArquitectonicoHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisArquitectonicoMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtDisArquitectonicoTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                  </tr>
             <tr>
                <td style="font-weight:bold;">Otra ¿cuál?</td>
                 <td><asp:TextBox ID="txtOtraIndustrialHom"  runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraIndustrialMuj" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtOtraIndustrialTotal" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
            </tr>
           <tr>
               <td style="font-weight:bold;" align="center" colspan="2">Total</td>
                 <td><asp:TextBox ID="txtTotalHom" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                 <td><asp:TextBox ID="txtTotalMuj" Enabled="false" runat="server" Width="50" CssClass="TextBox"></asp:TextBox></td>
                
           </tr>
        </table>

        <table align="center">
            <tr>
                <td>
                    <asp:Button ID="btnGuardarInfoBasica"  Visible="false" runat="server" CssClass="btn btn-primary" Text="Ir al Formulario C600B" OnClick="btnGuardarInfoBasica_Click"  />
                </td>
            </tr>
        </table>



    </asp:Panel>

    <!-- Formulario C600B -->

      <asp:Panel ID="PanelFormularioC600B" runat="server" Visible="false">

             <fieldset>
            <legend>Información de las Sedes de la Institución Educativa por Jornada</legend>

          
        <asp:GridView ID="GridSedesC600B" runat="server" CellPadding="4" DataKeyNames="cod"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen sedes para esta institución."
            GridLines="None" >
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="codSede" HeaderStyle-CssClass="ocultarcell" >
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nit" HeaderText="DANE">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                  <asp:BoundField DataField="consesede" HeaderText="Consecutivo Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Dirección">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
               <%--  <asp:BoundField DataField="telefono" HeaderText="Telefono">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="codmunicipio" HeaderText="codMunicipio" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrem" HeaderText="Municipio" />
                 <asp:BoundField DataField="codzona" HeaderText="codzona" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nomzona" HeaderText="Zona" />
                <asp:BoundField DataField="sede" HeaderText="Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
              <asp:BoundField DataField="codinstitucion" HeaderText="codinstitucion" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ver
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVer" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVer_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                  <%--  <HeaderTemplate>
                        <asp:Button ID="btnAgregarSede" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarSede_Click" />
                    </HeaderTemplate>--%>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:CommandField ShowDeleteButton="True" Visible="false" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                    <ItemStyle Width="20px" />
                </asp:CommandField>

                  <asp:TemplateField>
                    <HeaderTemplate>
                        C600B
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgInfoxSedeC600B" runat="server" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgInfoxSedeC600B_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </fieldset>

        </asp:Panel>

    <!-- Instrumento 01 -->

    <asp:Panel runat="server" ID="PanelInstrumento01" Visible="false">

        <fieldset>
            <legend>Sedes</legend>

            <table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;width:100%;" >
               <tr>
                   <td>
                       Nro de Sedes involucradas en la fusión: <asp:TextBox ID="txtNroSedesenFusion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                   </td>
               </tr>
              
            </table>
        </fieldset>
        
        <fieldset>
            <legend>Información de las Sedes de la Institución Educativa</legend>

          
        <asp:GridView ID="GridSedes" runat="server" CellPadding="4" DataKeyNames="cod"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen sedes para esta institución."
            GridLines="None" OnRowDeleting="GridSedes_RowDeleting" >
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="codSede" HeaderStyle-CssClass="ocultarcell" >
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nit" HeaderText="DANE">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                  <asp:BoundField DataField="consesede" HeaderText="Consecutivo Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Dirección">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
               <%--  <asp:BoundField DataField="telefono" HeaderText="Telefono">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="codmunicipio" HeaderText="codMunicipio" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrem" HeaderText="Municipio" />
                 <asp:BoundField DataField="codzona" HeaderText="codzona" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nomzona" HeaderText="Zona" />
                <asp:BoundField DataField="sede" HeaderText="Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
              <asp:BoundField DataField="codinstitucion" HeaderText="codinstitucion" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
              <%--  <asp:TemplateField>
                    <HeaderTemplate>
                        Ver
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVer" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVer_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Button ID="btnAgregarSede" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarSede_Click" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:CommandField ShowDeleteButton="True" Visible="false" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                    <ItemStyle Width="20px" />
                </asp:CommandField>--%>

                  <asp:TemplateField>
                    <HeaderTemplate>
                        01 x Sede
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgInfoxSede" runat="server" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgInfoxSede_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </fieldset>
        <table align="center"><tr><td><asp:Button runat="server" ID="btnAgregarInfoSede" CssClass="btn btn-success" Text="Terminar" OnClick="btnAgregarInfoSede_Click" /></td></tr></table>
    </asp:Panel>
  
     <asp:Button ID="btnShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelVerDependencias_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShow" PopupControlID="PanelEditarSede" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEditarSede" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodSede" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <legend>Edición de Sede</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado" border="0">
                <tr>
                    <td>NIT
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNitSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="txtNitSede_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtNitSede" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>

                    </td>
                     </tr>
                <tr>
                    <td>
                        Consecutivo Sede
                    </td>
                    <td colspan="3">
                          <asp:TextBox ID="txtConseSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtConseSede" runat="server" ErrorMessage="Digite el Consecutivo de la Sede"
                            Text="*" Display="None" ControlToValidate="txtConseSede" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" Enabled="True" TargetControlID="RFVtxtConseSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Nombre
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreSede" runat="server" ErrorMessage="Digite el nombre del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombreSede" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVtxtNombreSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Dirección
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                      <td>Zona
                    </td>
                    <td>
                       <asp:DropDownList ID="dropZonaEdit" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropZonaEdit" runat="server" ErrorMessage="Seleccione la Zona de la Sede" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropZonaEdit" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="RFVdropZonaEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender></td>
                </tr>
                <tr>
                    <td>Municipio
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipio" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Seleccione el municipio" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropMunicipio" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Sede
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoSede" runat="server" CssClass="TextBox">
                            <asp:ListItem>Principal</asp:ListItem>
                            <asp:ListItem>Sede</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnEditarSede" runat="server" ValidationGroup="editSede" CssClass="btn btn-success" Text="Editar Sede" OnClick="btnEditarSede_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

     <asp:Button ID="btnAddSedeShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelAgregarSede_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnAddSedeShow" PopupControlID="PanelAgregarSede" CancelControlID="btnCancelar2"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarSede" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Agregar Sede</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>NIT
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNitAddSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="txtNitAddSede_FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtNitAddSede" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>

                    </td>
                     </tr>
                <tr>
                    <td>Consecutivo Sede</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtConseSedeAdd" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtConseSedeAdd" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>Nombre
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreAddSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreAddSede" runat="server" ErrorMessage="Digite el nombre del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombreAddSede" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVtxtNombreAddSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                   
                    <td>Dirección
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionAddSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                     <td>Zona
                    </td>
                    <td>
                       <asp:DropDownList ID="DropZonaAdd" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVDropZonaAdd" runat="server" ErrorMessage="Seleccione la Zona de la Sede" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="DropZonaAdd" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RFVDropZonaAdd"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender></td>
                </tr>
                <tr>
                    <td>Municipio
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipioAddSede" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipioAddSede" runat="server" ErrorMessage="Seleccione el municipio" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropMunicipioAddSede" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RFVdropMunicipioAddSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Sede
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoAddSede" runat="server" CssClass="TextBox">
                            <asp:ListItem>Principal</asp:ListItem>
                            <asp:ListItem>Sede</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddSede" runat="server" CssClass="btn btn-success" ValidationGroup="addSede" Text="Agregar Sede" OnClick="btnAddSede_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar2" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>
   
     <asp:Panel ID="PanelCaracterizacion" runat="server" Visible="false">
        <h2 style="text-align:center"><%--Instrumento No. 02 <br />--%>
            Caracterización de Currículos de las Instituciones Educativas </h2>

         <table>
             <tr>
                 <td>
                     <b>Introducción:</b><br />

                    Para el diseño del Sistema de Información, Monitoreo, Seguimiento y Evaluación Permanente SIEP del proyecto CICLÓN, es importante, levantar una línea de base para la caracterización de Currículos de las instituciones educativas, en desarrollo de la estrategia No. 2 “Estrategia de autoformación, formación de saber y conocimiento y apropiación para maestros(as) acompañantes  coinvestigadores e investigadores en los lineamientos del programa ondas y su propuesta metodológica”, para valorar sus alcances en términos de resultados, efectos e impactos. 
                     <br /><br />
                    <b>Objetivo</b><br />

                    Recoger información básica sobre el PEI y los Currículos de las instituciones educativas que hacen parte del proyecto para indagar sobre el lugar de la investigación como Estrategia Pedagógica apoyada en TIC.
                     <br /><br />
                   <b> Metodología</b><br />

                    Este instrumento será diligenciado al inicio de la etapa No. 3 del proyecto fortalecimiento de la cultura ciudadana y democrática en CT+I a través de la iep apoyada en TIC en el dpto del Magdalena, denominada Ejecución y formación básica por el docente asesor o por quién haga sus veces. Será diligenciado directamente en el  SIEP.  Alguna de la información que solicita es de fuentes primarias y otras secundaria.

                 </td>
             </tr>
         </table>
        
      <%--  <fieldset>
            <legend>Responsable del diligenciamiento</legend>
             <table style="background-color: #ECECEC; padding: 10px; border-radius: 5px;" >
                <tr>
         
             <td>
               Nombre del asesor <span class="auto-style1">*</span>
            </td>
            <td>
              <asp:DropDownList ID="dropAsesor02" runat="server" CssClass="TextBox" ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVdropAsesor02" runat="server" Display="None" ErrorMessage="Seleccione el Asesor"
                    ControlToValidate="dropAsesor02" Text="*" ValidationGroup="addUsuario" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" TargetControlID="RFVdropAsesor02"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                    Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
             </td> 
            </tr>
            </table>
        </fieldset>--%>

    <fieldset>
        <legend>Agregar Caracterización del curriculo</legend>
        <asp:Label ID="lblCodPregunta" runat="server"></asp:Label>
        <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
        <tr>
            <td style="font-weight:bold;">
                <asp:Label ID="lblCodPregunta1" runat="server"></asp:Label>
                <asp:Label ID="lblPregunta1" runat="server"></asp:Label>
            </td>
        </tr>
            <tr>
                <td>
                      <asp:CheckBoxList ID="chkEnfasisPEI" runat="server" RepeatColumns="5" CssClass="TextBox">
                          <asp:ListItem>Ciencia</asp:ListItem>
                          <asp:ListItem>Tecnología</asp:ListItem>
                          <asp:ListItem>Innovación</asp:ListItem>
                          <asp:ListItem>Investigación</asp:ListItem>
                          <asp:ListItem>TIC</asp:ListItem>
                           <asp:ListItem>No aplica</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>  
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta2" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta2" runat="server"></asp:Label>
                </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkModeloEducativo" runat="server" RepeatColumns="3" CssClass="TextBox">
                          <asp:ListItem>Aceleración del aprendizaje</asp:ListItem>
                          <asp:ListItem>Escuela Nueva</asp:ListItem>
                          <asp:ListItem>Postprimaria</asp:ListItem>
                          <asp:ListItem>Telesecundara</asp:ListItem>
                          <asp:ListItem>Servicio de educación rural –SER-</asp:ListItem>
                          <asp:ListItem>Programa de educación continuada de CAFAM</asp:ListItem>
                          <asp:ListItem>Sistema De Educación Tutorial SAT</asp:ListItem>
                          <asp:ListItem>Propuesta educativa para jóvenes y adultos CRECER</asp:ListItem>
                        <asp:ListItem>No aplica</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr> 
            <tr>
                 <td style="font-weight:bold;">
                    Describa si el modelo educativo seleccionado favorece la incorporación de la IEP en su sede educativa?
                </td>
            </tr>
            <tr>
                <td>
                     <asp:TextBox ID="txtDescripcionIEP" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtDescripcionIEP" runat="server" ErrorMessage="Digite la descripcion"
                        Text="*" Display="None" ControlToValidate="txtDescripcionIEP"
                        ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RFVtxtDescripcionIEP" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta3" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta3" runat="server"></asp:Label>
                </td>
                </tr>
            <tr>
                <td>
                    <table align="center"  border="0" width="40%" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
                          <tr>
                            <td>
                                 <asp:Label ID="lblCodSubPregunta1" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta1" runat="server"></asp:Label> 
                                </td>
                            <td>
                                <asp:RadioButtonList ID="rbInvestigacionDocente" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                             </tr> 
                        <tr>
                            <td>
                                  <asp:Label ID="lblCodSubPregunta2" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta2" runat="server"></asp:Label> 
                                </td>
                            <td>
                                <asp:RadioButtonList ID="rbInvestigacionEstudiante" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                            </tr>
                        <tr>
                                <td>
                                     <asp:Label ID="lblCodSubPregunta3" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta3" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbticDocente" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:Label ID="lblCodSubPregunta4" runat="server"></asp:Label>
                                 <asp:Label ID="lblSubPregunta4" runat="server"></asp:Label>
                                </td>
                            <td>
                    
                                <asp:RadioButtonList ID="rbticEstudiante" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                            </td>
                        </tr>
                </table>
            </td>
            </tr>
          <tr>
              <td style="font-weight:bold;">
                   <asp:Label ID="lblCodPregunta4" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta4" runat="server"></asp:Label>
              </td>
          </tr>
            <tr>
                 <td>
                      <asp:TextBox ID="txtPrincipalesPracticas" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtPrincipalesPracticas" runat="server" ErrorMessage="Digite la descripcion"
                        Text="*" Display="None" ControlToValidate="txtPrincipalesPracticas"
                        ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True" TargetControlID="RFVtxtPrincipalesPracticas" 
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            </table>
        <table><tr><td><asp:Button ID="btnPrimerGuardar02" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnPrimerGuardar02_Click" /></td></tr></table> 
        <br />
        <table align="center" border="0" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta5" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:RadioButtonList ID="rbinvestigacionPEI" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta6" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta6" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:CheckBoxList ID="chkUsoTIC" runat="server" RepeatColumns="5" CssClass="TextBox">
                          <asp:ListItem>PC</asp:ListItem>
                          <asp:ListItem>Portátil </asp:ListItem>
                          <asp:ListItem>Tableta </asp:ListItem>
                          <asp:ListItem>Correo electrónico</asp:ListItem>
                          <asp:ListItem>Tablero inteligente</asp:ListItem>
                          <asp:ListItem>Software educativo</asp:ListItem>
                          <asp:ListItem>Wikis</asp:ListItem>
                          <asp:ListItem>Blogs</asp:ListItem>
                          <asp:ListItem>Foros</asp:ListItem>
                          <asp:ListItem>Otras</asp:ListItem>
                    </asp:CheckBoxList>
                    Cuáles?:
                     <asp:TextBox ID="txtUsoTIC" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta7" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta7" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:RadioButtonList ID="rbCompetenciaTIC" runat="server" RepeatDirection="Horizontal" >
                                 <asp:ListItem>Si</asp:ListItem>
                                 <asp:ListItem>No</asp:ListItem>
                                     </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                 <td style="font-weight:bold;">
                     <asp:Label ID="lblCodPregunta8" runat="server"></asp:Label>
                     <asp:Label ID="lblPregunta8" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkAreaCurriculo" runat="server" RepeatColumns="5" CssClass="TextBox">
                          <asp:ListItem>Pedagógica</asp:ListItem>
                          <asp:ListItem>Tecnológica </asp:ListItem>
                          <asp:ListItem>Investigativa </asp:ListItem>
                          <asp:ListItem>Comunicativa</asp:ListItem>
                          <asp:ListItem>Gestión</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    Área del currículo
                </td>
                </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAreaCurriculo" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine" Columns="200" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                     <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false"   ValidationGroup="addUsuario"
                             CssClass="btn btn-success" onclick="btnGuardar_Click"/>
                </td>
            </tr>
            </table>
    </fieldset>

 </asp:Panel>

</asp:Content>

