using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class lineabaseinstrudocente : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    string codrol = "";
    string validarIntentos = "true";
    LineaBase lb = new LineaBase();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx",true);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       codrol = Session["codrol"].ToString();
      
       mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            lblCodDANE.Text = Session["dane"].ToString();

            if (codrol == "1")
            {
                               
                //ddInstituciones(dropInstitucion);
               


               


                //Instrumento 04
                //gvcargarPreguntas();
            }
           
        }
    }

    protected void btnIniciarAutopercepcion_Onclick(Object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();
        gvcargarPreguntas();
        PanelPerfilDocente.Visible = false;
        btnGuardarPerfilDocente.Visible = false;

        PanelEstudiantes.Visible = false;
        btnTerminar.Visible = false;

        PanelAutopercepcionDocentes.Visible = true;
        btnGuardarAutopercepcion.Visible = true;

        btnRegresarCaracterizacion.Visible = false;
        //btnRegresarAutopercepcion.Visible = false;
        btnRegresarPerfilDocente.Visible = false;
        btnGrupoInvestigacion.Visible = false;
        btnRedTematica.Visible = false;

        if (codrol == "3")
        {

             //DateTime localDateTime = DateTime.Now;
             //   DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
             //   string horares = utcDateTime.ToString("yyyy-MM-dd");
             //   DataRow fecha = lb.buscarFechaInstrumento("4",horares);

                //if (fecha != null)
                //{
                    //DataRow valide = lb.buscarValidacionInstrumento(Session["identificacion"].ToString(), "3");

                    //if (valide != null)
                    //{
                        //if (validarIntentos == "true")
                        //{
                            DataRow dat = lb.buscarDocenteEnSede(Session["identificacion"].ToString());

                            if (dat != null)
                            {
                                //DataRow datt = lb.buscarIntentosDocente(dat["codsede"].ToString(), dat["identificacion"].ToString(), "4");

                            //    if (datt == null)
                            //    {
                                  
                            //        if (lb.agregarIntentosDocente(dat["codsede"].ToString(), dat["identificacion"].ToString(), horares, "4"))
                            //        {

                                        //PanelCaracterizacion.Visible = false;
                                        //btnGuardar.Visible = false;

                                      


                                        DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                                        if (info != null)
                                        {
                                            DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                                            if (regins != null)
                                            {
                                                lblCodDocenteAsesor.Text = regins["codigo"].ToString();
                                                gvcargarPreguntas();
                                                cargarPreguntasInstrumento04(lblCodDocenteAsesor.Text);
                                                //cargarPreguntasInstrumento05(regins["codigo"].ToString(), info["codsede"].ToString());

                                                PanelPerfilDocente.Visible = false;
                                                btnGuardarPerfilDocente.Visible = false;

                                                PanelEstudiantes.Visible = false;
                                                btnTerminar.Visible = false;

                                                PanelAutopercepcionDocentes.Visible = true;
                                                btnGuardarAutopercepcion.Visible = true;

                                                btnRegresarCaracterizacion.Visible = false;
                                                //btnRegresarAutopercepcion.Visible = false;
                                                btnRegresarPerfilDocente.Visible = false;
                                                btnGrupoInvestigacion.Visible = false;
                                                btnRedTematica.Visible = false;
                                            }
                                            else
                                            {
                                                mostrarmensaje("error", "Debe diligenciar el Instrumento 05");
                                                btnRedTematica.Visible = false;
                                                btnGrupoInvestigacion.Visible = false;
                                            }


                                        }

                                       
                                        ////DataRow regins = lb.cargarDatosRegInstitucion(info["cod"].ToString(), info["codinstitucion"].ToString(), info["codsede"].ToString());

                                        ////if (regins != null)
                                        ////{
                                        ////    //Cargar Respuestas del instrumento 03 una vez estén respondidas
                                        ////    gvcargarPreguntas();
                                        ////    //lblCodRegInstitucion.Text = regins["codigo"].ToString();
                                        ////    //cargarPreguntasInstrumento04(lblCodRegInstitucion.Text);


                                        ////}
                                       

                                        //DataRow confitime = lb.buscarconfiSINOTiempo();

                                        //if (confitime != null)
                                        //{
                                        //    if (confitime["tiempoenlineabase"].ToString() == "Si")
                                        //    {
                                        //        //Tiempo de ejecución
                                        //        DataRow datime = lb.buscarConfiTiempo();

                                        //        if (datime != null)
                                        //        {
                                        //            int time = Convert.ToInt32(datime["tiempo"].ToString()) * 60;
                                        //            Session["tiempo"] = time;
                                        //            Paneltime.Visible = true;
                                        //        }
                                        //    }
                                        //}

                                    //}

                        //        }
                        //        else
                        //        {
                        //            mostrarmensaje("error", "Sin acceso a esta Línea Base");
                        //        }
                            }
                            else
                            {
                                mostrarmensaje("error", "Error: Docente no asignado a una sede.");
                            }
                        //}
                        //else
                        //{
                        //    //PanelCaracterizacion.Visible = false;
                        //    //btnGuardar.Visible = false;
                        //}
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "Debe diligenciar antes el Instrumento 02 - Currículo");
                    //}
                //}
                //else
                //{
                //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
                //}
           

        }

    }

    protected void btnIniciarPerfilDocente_Onclick(Object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();
 PanelPerfilDocente.Visible = true;
                                            btnGuardarPerfilDocente.Visible = true;

                                            PanelEstudiantes.Visible = false;
                                            btnTerminar.Visible = false;

                                            PanelAutopercepcionDocentes.Visible = false;
                                            btnGuardarAutopercepcion.Visible = false;


                                            //btnRegresarCaracterizacion.Visible = false;
                                            //btnRegresarAutopercepcion.Visible = false;
                                            //btnRegresarPerfilDocente.Visible = false;

                                            btnGrupoInvestigacion.Visible = false;
                                            btnRedTematica.Visible = false;

        if (codrol == "3")
        {
             //DateTime localDateTime = DateTime.Now;
             //   DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
             //   string horares = utcDateTime.ToString("yyyy-MM-dd");
             //   DataRow fecha = lb.buscarFechaInstrumento("5",horares);



                //if (fecha != null)
                //{
                    //DataRow valide = lb.buscarValidacionInstrumento(Session["identificacion"].ToString(), "4");

                    //if (valide != null)
                    //{
                    //    if (validarIntentos == "true")
                    //    {
                    //        DataRow dat = lb.buscarDocenteEnSede(Session["identificacion"].ToString());

                    //        if (dat != null)
                    //        {
                    //            DataRow datt = lb.buscarIntentosDocente(dat["codsede"].ToString(), dat["identificacion"].ToString(), "5");

                    //            if (datt == null)
                    //            {
                                   
                    //                if (lb.agregarIntentosDocente(dat["codsede"].ToString(), dat["identificacion"].ToString(), horares, "5"))
                    //                {

            ddAsesores(dropAsesor);
            cargarFormacionDocente();
            cargarFormacionInvestigacion();
            cargarFormacionNTICs();
            cargarFormacionCienciaTecnoInno();
                                        DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                                        if (info != null)
                                        {
                                            DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                                            if (regins != null)
                                            {
                                                lblCodDocenteAsesor.Text = regins["codigo"].ToString();
                                                dropAsesor.SelectedValue = regins["codasesor"].ToString();
                                                cargarPreguntasInstrumento05(regins["codigo"].ToString(), info["codsede"].ToString());

                                               
                                            }

                                            PanelPerfilDocente.Visible = true;
                                            btnGuardarPerfilDocente.Visible = true;

                                            PanelEstudiantes.Visible = false;
                                            btnTerminar.Visible = false;

                                            PanelAutopercepcionDocentes.Visible = false;
                                            btnGuardarAutopercepcion.Visible = false;


                                            //btnRegresarCaracterizacion.Visible = false;
                                            //btnRegresarAutopercepcion.Visible = false;
                                            //btnRegresarPerfilDocente.Visible = false;

                                            btnGrupoInvestigacion.Visible = false;
                                            btnRedTematica.Visible = false;

                                        }

                                        

                                        //validarIntentos = "false";

                                        //PanelCaracterizacion.Visible = false;
                                        //btnGuardar.Visible = false;

                                       

                                        //ddInstituciones(dropInstitucion);
                                        //ddAsesores(dropAsesor);


                                        //DataRow confitime = lb.buscarconfiSINOTiempo();

                                        //if (confitime != null)
                                        //{
                                        //    if (confitime["tiempoenlineabase"].ToString() == "Si")
                                        //    {
                                        //        //Tiempo de ejecución
                                        //        DataRow datime = lb.buscarConfiTiempo();

                                        //        if (datime != null)
                                        //        {
                                        //            int time = Convert.ToInt32(datime["tiempo"].ToString()) * 60;
                                        //            Session["tiempo"] = time;
                                        //            Paneltime.Visible = true;
                                        //        }
                                        //    }
                                        //}

                    //                }

                    //            }
                    //            else
                    //            {
                    //                mostrarmensaje("error", "Sin acceso a esta Línea Base");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            mostrarmensaje("error", "Error: Docente no asignado a una sede.");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //PanelCaracterizacion.Visible = false;
                    //        //btnGuardar.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "Debe diligenciar antes el Instrumento 04 - Autopercepción Docente");
                    //}
                //}
                //else
                //{
                //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
                //}
      
        }
    }
   
    protected void btnIniciarEstudiante_Onclick(Object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();
        PanelPerfilDocente.Visible = false;
        btnGuardarPerfilDocente.Visible = false;

        PanelEstudiantes.Visible = true;
        btnTerminar.Visible = true;

        PanelAutopercepcionDocentes.Visible = false;
        btnGuardarAutopercepcion.Visible = false;


        //btnRegresarCaracterizacion.Visible = false;
        //btnRegresarAutopercepcion.Visible = false;
        //btnRegresarPerfilDocente.Visible = false;

        btnGrupoInvestigacion.Visible = true;
        btnRedTematica.Visible = true;

        if (codrol == "3")
        {
             //DateTime localDateTime = DateTime.Now;
             //   DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
             //   string horares = utcDateTime.ToString("yyyy-MM-dd");
             //   DataRow fecha = lb.buscarFechaInstrumento("6",horares);

             //   if (fecha != null)
             //   {
                    //DataRow valide = lb.buscarValidacionInstrumento(Session["identificacion"].ToString(), "5");

                    //if (valide != null)
                    //{
                    //    if (validarIntentos == "true")
                    //    {
                    //        DataRow dat = lb.buscarDocenteEnSede(Session["identificacion"].ToString());

                    //        if (dat != null)
                    //        {
                    //            DataRow datt = lb.buscarIntentosDocente(dat["codsede"].ToString(), dat["identificacion"].ToString(), "6");

                    //            if (datt == null)
                    //            {
                                   
                    //                if (lb.agregarIntentosDocente(dat["codsede"].ToString(), dat["identificacion"].ToString(), horares, "6"))
                    //                {
            ddCargarRedTematica(dropNombreRedTematica);
            ddcargarGrupoInvestigacion(dropNombreGrupoInvestigacion);

                                        DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                                        if (info != null)
                                        {
                                            DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                                            if (regins != null)
                                            {
                                                lblCodDocenteAsesor.Text = regins["codigo"].ToString();
                                                lblCodGradoDocenteInstrumento6.Text = info["cod"].ToString();
                                                lblCodSedeInstrumento6.Text = info["codsede"].ToString();
                                                
                                                lblCodSedeInstrumento6RT.Text = info["codsede"].ToString();
                                                lblCodGradoDocenteInstrumento6RT.Text = info["cod"].ToString();
                                              
                                                //lblCodSedeInstrumento6.Text = regins["codsede"].ToString();

                                                PanelPerfilDocente.Visible = false;
                                                btnGuardarPerfilDocente.Visible = false;

                                                PanelEstudiantes.Visible = false;
                                                btnTerminar.Visible = true;

                                                PanelAutopercepcionDocentes.Visible = false;
                                                btnGuardarAutopercepcion.Visible = false;


                                                //btnRegresarCaracterizacion.Visible = false;
                                                //btnRegresarAutopercepcion.Visible = false;
                                                //btnRegresarPerfilDocente.Visible = false;

                                                btnGrupoInvestigacion.Visible = true;
                                                btnRedTematica.Visible = true;

                                               

                                            }
                                            else
                                            {
                                                mostrarmensaje("error","Debe diligenciar el Instrumento 05");
                                                btnGrupoInvestigacion.Visible = false;
                                                btnRedTematica.Visible = false;
                                            }

                                        }
                                        else
                                        {
                                            mostrarmensaje("error", "Docente no está relacionado con ninguna sede.");
                                        }


                                      

                                        //validarIntentos = "false";

                                        //Paneltime.Visible = false;

                                        //PanelCaracterizacion.Visible = false;
                                        //btnGuardar.Visible = false;

                                       


                                        //ddInstituciones(dropInstitucion);
                                        //ddAsesores(dropAsesor);

                                        //DataRow confitime = lb.buscarconfiSINOTiempo();

                                        //if (confitime != null)
                                        //{
                                        //    if (confitime["tiempoenlineabase"].ToString() == "Si")
                                        //    {
                                        //        //Tiempo de ejecución
                                        //        DataRow datime = lb.buscarConfiTiempo();

                                        //        if (datime != null)
                                        //        {
                                        //            int time = Convert.ToInt32(datime["tiempo"].ToString()) * 60;
                                        //            Session["tiempo"] = time;
                                        //            Paneltime.Visible = true;
                                        //        }
                                        //    }
                                        //}

                    //                }

                    //            }
                    //            else
                    //            {
                    //                mostrarmensaje("error", "Sin acceso a esta Línea Base");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            mostrarmensaje("error", "Error: Docente no asignado a una sede.");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //PanelCaracterizacion.Visible = false;
                    //        //btnGuardar.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "Debe diligenciar antes el Instrumento 05 - Perfil Docente");
                    //}
                //}
                //else
                //{
                //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
                //}
            

            

        }
    }

    private void ddcargarGrupoInvestigacion(DropDownList drop)
    {
        DataTable datos = lb.cargarGrupoInvestigacionxSede(lblCodDANE.Text);
        drop.DataSource = datos;
        drop.DataTextField = "nombreproyecto";
        drop.DataValueField = "codproyecto";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Nuevo Grupo de Investigación"));
    }

    private void ddCargarRedTematica(DropDownList drop)
    {
        DataTable datos = lb.cargarRedTematicaxSede(lblCodDANE.Text);
        drop.DataSource = datos;
        drop.DataTextField = "nombreredtematica";
        drop.DataValueField = "codredtematica";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Nueva Red Temática"));
    }
    
    private void gvcargarPreguntas()
    {
        crearPregunta1();
        crearPregunta2();
        crearPregunta3();
        crearPregunta4();
        crearPregunta5();
        crearPregunta6();
        crearPregunta7();
        crearPregunta8();
        crearPregunta9();
        crearPregunta10();
        crearPregunta11();
        crearPregunta12();
        crearPregunta13();
        crearPregunta14();
        crearPregunta15();
        crearPregunta16();
    }
    private void gvCargarDatos()
    {
        cargarFormacionDocente();
        cargarFormacionInvestigacion();
        cargarFormacionCienciaTecnoInno();
        cargarFormacionNTICs();

    }
    private void crearPregunta1()//Pregunta 1
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos","1", "1","4");
        dtPregunta.Rows.Add("Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales.", "1", "2", "4");
        dtPregunta.Rows.Add("Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material audiovisual.", "1", "3", "4");
        GridPregunta1.DataSource = dtPregunta;
        GridPregunta1.DataBind();
    }
    private void crearPregunta2()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Combino una amplia variedad de herramientas tecnológicas para mejorar la planeación e implementación de mis prácticas educativas.", "1", "4", "4");
        dtPregunta.Rows.Add("Diseño y publico contenidos digitales u objetos virtuales de aprendizaje mediante el uso adecuado de herramientas tecnológicas.", "1", "5", "4");
        dtPregunta.Rows.Add("Analizo los riesgos y potencialidades de publicar y compartir distintos tipos de información a través de Internet.", "1", "6", "4");
        GridPregunta2.DataSource = dtPregunta;
        GridPregunta2.DataBind();
    }
    private void crearPregunta3()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Utilizo herramientas tecnológicas complejas o especializadas para diseñar ambientes virtuales de aprendizaje que favorecen el desarrollo de competencias en mis estudiantes y la conformación de comunidades y/o redes de aprendizaje.", "1", "7", "4");
        dtPregunta.Rows.Add("Utilizo herramientas tecnológicas para ayudar a mis estudiantes a construir aprendizajes significativos y desarrollar pensamiento crítico.", "1", "8", "4");
        dtPregunta.Rows.Add("Aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia.", "1", "9", "4");
        GridPregunta3.DataSource = dtPregunta;
        GridPregunta3.DataBind();
    }
    private void crearPregunta4()//Pregunta 2
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Utilizo las TIC para aprender por iniciativa personal y para actualizar los conocimientos y prácticas propios de mi disciplina.", "2", "1", "4");
        dtPregunta.Rows.Add("Identifico problemáticas educativas en mi práctica docente y las oportunidades, implicaciones y riesgos del uso de las TIC para atenderlas.", "2", "1", "4");
        dtPregunta.Rows.Add("Conozco una variedad de estrategias y metodologías apoyadas por las TIC, para planear y hacer seguimiento a mi labor docente.", "2", "3", "4");
        GridPregunta4.DataSource = dtPregunta;
        GridPregunta4.DataBind();
    }
    private void crearPregunta5()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Incentivo en mis estudiantes el aprendizaje autónomo y el aprendizaje colaborativo apoyados por TIC.", "2", "4", "4");
        dtPregunta.Rows.Add("Utilizo TIC con mis estudiantes para atender sus necesidades e intereses y proponer soluciones a problemas de aprendizaje.", "2", "5", "4");
        dtPregunta.Rows.Add("Implemento estrategias didácticas mediadas por TIC, para fortalecer en mis estudiantes aprendizajes que les permitan resolver problemas de la vida real.", "2", "6", "4");
        GridPregunta5.DataSource = dtPregunta;
        GridPregunta5.DataBind();
    }
    private void crearPregunta6()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Diseño ambientes de aprendizaje mediados por TIC de acuerdo con el desarrollo cognitivo, físico, psicológico y social de mis estudiantes para fomentar el desarrollo de sus competencias.", "2", "7", "4");
        dtPregunta.Rows.Add("Propongo proyectos educativos mediados con TIC, que permiten la reflexión sobre el aprendizaje propio y la producción de conocimiento.", "2", "8", "4");
        dtPregunta.Rows.Add("Evalúo los resultados obtenidos con la implementación de estrategias que hacen uso de las TIC y promuevo una cultura del seguimiento, realimentación y mejoramiento permanente.", "2", "9", "4");
        GridPregunta6.DataSource = dtPregunta;
        GridPregunta6.DataBind();
    }
    private void crearPregunta7()//Pregunta 3
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Me comunico adecuadamente con mis estudiantes y sus familiares, mis colegas e investigadores usando TIC de manera sincrónica y asincrónica.", "3", "1", "4");
        dtPregunta.Rows.Add("Navego eficientemente en Internet integrando fragmentos de información presentados de forma no lineal.", "3", "2", "4");
        dtPregunta.Rows.Add("Evalúo la pertinencia de compartir información a través de canales públicos y masivos, respetando las normas de propiedad intelectual y licenciamiento.", "3", "3", "4");
        GridPregunta7.DataSource = dtPregunta;
        GridPregunta7.DataBind();
    }
    private void crearPregunta8()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Participo activamente en redes y comunidades de práctica mediadas por TIC y facilito la participación de mis estudiantes en las mismas, de una forma pertinente y respetuosa.", "3", "4", "4");
        dtPregunta.Rows.Add("Sistematizo y hago seguimiento a experiencias significativas de uso de TIC.", "3", "5", "4");
        dtPregunta.Rows.Add("Promuevo en la comunidad educativa comunicaciones efectivas que aportan al mejoramiento de los procesos de convivencia escolar.", "3", "6", "4");
        GridPregunta8.DataSource = dtPregunta;
        GridPregunta8.DataBind();
    }
    private void crearPregunta9()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Utilizo variedad de textos e interfaces para transmitir información y expsar ideas propias combinando texto, audio, imágenes estáticas o dinámicas, videos y gestos.", "3", "7", "4");
        dtPregunta.Rows.Add("Interpreto y produzco íconos, símbolos y otras formas de representación de la información, para ser utilizados con propósitos educativos.", "3", "8", "4");
        dtPregunta.Rows.Add("Contribuyo con mis conocimientos y los de mis estudiantes a repositorios de la humanidad en Internet, con textos de diversa naturaleza.", "3", "9", "4");
        GridPregunta9.DataSource = dtPregunta;
        GridPregunta9.DataBind();
    }
    private void crearPregunta10()//Pregunta 4
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Identifico los elementos de la gestión escolar que pueden ser mejorados con el uso de las TIC, en las diferentes actividades institucionales.", "4", "1", "4");
        dtPregunta.Rows.Add("Conozco políticas escolares para el uso de las TIC que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.", "4", "2", "4");
        dtPregunta.Rows.Add("Identifico mis necesidades de desarrollo profesional para la innovación educativa con TIC.", "4", "3", "4");
        GridPregunta10.DataSource = dtPregunta;
        GridPregunta10.DataBind();
    }
    private void crearPregunta11()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Propongo y desarrollo procesos de mejoramiento y seguimiento del uso de TIC en la gestión escolar.", "4", "5", "4");
        dtPregunta.Rows.Add("Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.", "4", "6", "4");
        dtPregunta.Rows.Add("Selecciono y accedo a programas de formación, apropiados para mis necesidades de desarrollo profesional, para la innovación educativa con TIC.", "4", "7", "4");
        GridPregunta11.DataSource = dtPregunta;
        GridPregunta11.DataBind();
    }
    private void crearPregunta12()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Evalúo los beneficios y utilidades de herramientas TIC en la gestión escolar y en la proyección del PEI dando respuesta a las necesidades de mi institución.", "4", "7", "4");
        dtPregunta.Rows.Add("Desarrollo políticas escolares para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.", "4", "8", "4");
        dtPregunta.Rows.Add("Dinamizo la formación de mis colegas y los apoyo para que integren las TIC de forma innovadora en sus prácticas pedagógicas.", "4", "9", "4");
        GridPregunta12.DataSource = dtPregunta;
        GridPregunta12.DataBind();
    }
    private void crearPregunta13()//Pregunta 5
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Documento observaciones de mi entorno y mi practica con el apoyo de TIC.", "5", "1", "4");
        dtPregunta.Rows.Add("Identifico redes, bases de datos y fuentes de información que facilitan mis procesos de investigación.", "5", "2", "4");
        dtPregunta.Rows.Add("Sé buscar, ordenar, filtrar, conectar y analizar información disponible en Internet.", "5", "3", "4");
        GridPregunta13.DataSource = dtPregunta;
        GridPregunta13.DataBind();
    }
    private void crearPregunta14()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Represento e interpreto datos e información de mis investigaciones en diversos formatos digitales.", "5", "4", "4");
        dtPregunta.Rows.Add("Utilizo redes profesionales y plataformas especializadas en el desarrollo de mis investigaciones.", "5", "5", "4");
        dtPregunta.Rows.Add("Contrasto y analizo con mis estudiantes información proveniente de múltiples fuentes digitales.", "5", "6", "4");
        GridPregunta14.DataSource = dtPregunta;
        GridPregunta14.DataBind();
    }
    private void crearPregunta15()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Divulgo los resultados de mis investigaciones utilizando las herramientas que me ofrecen las TIC.", "5", "7", "4");
        dtPregunta.Rows.Add("Participo activamente en redes y comunidades de práctica, para la construcción colectiva de conocimientos con estudiantes y colegas, con el apoyo de TIC.", "5", "8", "4");
        dtPregunta.Rows.Add("Utilizo la información disponible en Internet con una actitud crítica y reflexiva.", "5", "9", "4");
        GridPregunta15.DataSource = dtPregunta;
        GridPregunta15.DataBind();
    }
    private void crearPregunta16()//Pregunta 6
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Comprendo las posibilidades de las TIC para potenciar procesos de participación democrática.", "6", "1", "4");
        dtPregunta.Rows.Add("Identifico los riesgos de publicar y compartir distintos tipos de información a través de Internet.", "6", "2", "4");
        dtPregunta.Rows.Add("Utilizo las TIC teniendo en cuenta recomendaciones básicas de salud.", "6", "3", "4");
        dtPregunta.Rows.Add("Examino y aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia.", "6", "4", "4");
        dtPregunta.Rows.Add("Me comunico de manera respetuosa con los demás.", "6", "5", "4");
        GridPregunta16.DataSource = dtPregunta;
        GridPregunta16.DataBind();
    }

   
    private void cargarFormacionDocente()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[2] { new DataColumn("titulo"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Bachillerato pedagógico.", "5");
        dtPregunta.Rows.Add("Normalista Superior.", "5");
        dtPregunta.Rows.Add("Otro bachillerato.", "5");
        dtPregunta.Rows.Add("Técnico o tecnológico.", "5");
        dtPregunta.Rows.Add("Otro Técnico o tecnológico.", "5");
        dtPregunta.Rows.Add("Profesional pedagógico.", "5");

        dtPregunta.Rows.Add("Especialización.", "5");
        dtPregunta.Rows.Add("Otro profesional.", "5");
        dtPregunta.Rows.Add("Maestría en educación o pedagogía.", "5");
        dtPregunta.Rows.Add("Otra Maestría.", "5");
        dtPregunta.Rows.Add("Doctorado en educación o pedagogía.", "5");
        dtPregunta.Rows.Add("Otro doctorado.", "5");
        GridFormacionDocente.DataSource = dtPregunta;
        GridFormacionDocente.DataBind();
    }
    private void cargarFormacionInvestigacion()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[3] { new DataColumn("nro"), new DataColumn("codpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("1", "5", "5");
        dtPregunta.Rows.Add("2", "5", "5");
        dtPregunta.Rows.Add("3", "5", "5");
        dtPregunta.Rows.Add("4", "5", "5");
        dtPregunta.Rows.Add("5", "5", "5");

        GridFormacionInvestigacionDocente.DataSource = dtPregunta;
        GridFormacionInvestigacionDocente.DataBind();
    }
    private void cargarFormacionCienciaTecnoInno()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[3] { new DataColumn("nro"), new DataColumn("codpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("1", "9","5");
        dtPregunta.Rows.Add("2", "9", "5");
        dtPregunta.Rows.Add("3", "9", "5");
        dtPregunta.Rows.Add("4", "9", "5");
        dtPregunta.Rows.Add("5", "9", "5");

        GridFormacionCienciaTecnoInno.DataSource = dtPregunta;
        GridFormacionCienciaTecnoInno.DataBind();
    }
    private void cargarFormacionNTICs()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[3] { new DataColumn("nro"), new DataColumn("codpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("1", "10","5");
        dtPregunta.Rows.Add("2", "10", "5");
        dtPregunta.Rows.Add("3", "10", "5");
        dtPregunta.Rows.Add("4", "10", "5");
        dtPregunta.Rows.Add("5", "10", "5");

        GridFormacionNTICs.DataSource = dtPregunta;
        GridFormacionNTICs.DataBind();
    }

   

    
  
     private void ddInstituciones(DropDownList drop)
        {
            Institucion usu = new Institucion();
            DataTable datos = usu.cargarInstitucion();
            drop.DataSource = datos;
            drop.DataTextField = "nombre";
            drop.DataValueField = "codigo";
            drop.DataBind();
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

            string script = "buscar();";
            if (ScriptManager1.IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            }
        }

     private void cargarDocentesxSede(DropDownList drop, string codsede)
     {
         LineaBase usu = new LineaBase();
         DataTable datos = usu.cargarDocenteXSede(codsede);
         drop.DataSource = datos;
         drop.DataTextField = "nombre";
         drop.DataValueField = "codigo";
         drop.DataBind();
         drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

     }
     protected void dropdropInstitucion_SelectedIndexChanged(object sender, EventArgs e)
     {
         //if (dropInstitucion.SelectedIndex > 0)
         //{
         //    ddInstitucionxSedes(dropSedes,dropInstitucion.SelectedValue);
         //}
     }
     protected void dropdropDocentes_SelectedIndexChanged(object sender, EventArgs e)
     {
         //if (dropSedes.SelectedIndex > 0)
         //{
         //    cargarDocentesxSede(dropDocente, dropSedes.SelectedValue);
         //}
        
     }
     protected void dropdropCargarRespuestas_SelectedIndexChanged(object sender, EventArgs e)
     {
         Institucion ins = new Institucion();
         //if (dropAsesor.SelectedIndex > 0)
         //{
         //    DataRow datos = ins.cargarRespuestasInstrumento02(dropInstitucion.SelectedValue, dropSedes.SelectedValue,dropAsesor.SelectedValue,dropDocente.SelectedValue);

         //    //Cargar Respuestas
         //    if(datos != null)
         //    {
         //        lblCodRegInstitucion.Text = datos["codigo"].ToString();
         //        cargarDatosInstitucionales(datos);
         //        cargarRespuestasEnfasisPEI(datos, chkEnfasisPEI);
         //        cargarRespuestasModeloEducativo(datos,chkModeloEducativo);
         //        cargarProcesosInstitucionalesPEI(datos, rbInvestigacionDocente);
         //        cargarPrincipalesPracticas(datos);
         //        cargarInvestigacionPEI(datos,rbinvestigacionPEI);
         //        cargarUsoTIC(datos,chkUsoTIC);
         //        cargarCompetenciasTIC(datos,rbCompetenciaTIC);
         //        cargarAreaCurriculo(datos,chkAreaCurriculo);
         //    }
         //    else
         //    {
         //        limpiardatosInstrumento02();
         //    }
         // }
     }
    
     private void ddInstitucionxSedes(DropDownList drop,string codinstitucion)
     {
         Institucion usu = new Institucion();
         DataTable datos = usu.cargarSedesInstitucion(codinstitucion);
         drop.DataSource = datos;
         drop.DataTextField = "nombre";
         drop.DataValueField = "cod";
         drop.DataBind();
         drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
     }
     private void ddAsesores(DropDownList drop)
     {
         Asesores usu = new Asesores();
         DataTable datos = usu.cargarAsesores();
         drop.DataSource = datos;
         drop.DataTextField = "nombre";
         drop.DataValueField = "codigo";
         drop.DataBind();
         drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
     }
     private void ddDocente(DropDownList drop)
     {
         Docentes usu = new Docentes();
         DataTable datos = usu.cargarDocentes();
         drop.DataSource = datos;
         drop.DataTextField = "nombrecompleto";
         drop.DataValueField = "codigo";
         drop.DataBind();
         drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

         string script = "buscar();";
         if (ScriptManager1.IsInAsyncPostBack)
         {
             ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
         }
         else
         {
             ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
         }
     }
    private void cblRoles2(CheckBoxList rol)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        rol.DataSource = datos;
        rol.DataTextField = "nombre";
        rol.DataValueField = "cod";
        rol.DataBind();
    }
    private void ddRoles(DropDownList drop)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
  
 
    
    protected void GridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (ImageButton button in e.Row.Cells[9].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el usuario " + item + "?')){ return false; };";
                }
            }
        }
    }
    /* Mostrar respuestas del Instrumento Nro 2  */
    private void cargarDatosInstitucionales(DataRow datosinstitucionales)
    {
        //txtNomCoordinador.Text = datosinstitucionales["nomcoordinador"].ToString();
        //txtCargo.Text = datosinstitucionales["cargo"].ToString();
    }
    

    

    protected void btnGuardarAutopercepcion_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if(valueRB16 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
       // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);
        
  
    }

    protected void btnPrimerGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB1 == 0 )
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            //Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnSegundoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB2 == 0 )
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnTercerGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if ( valueRB3 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnCuartoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if ( valueRB4 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnQuintoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB5 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnSextoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB6 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnSeptimoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB7 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnOctavoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB8 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnNovenoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB8 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnDecimoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB10 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnDecimoPrimerGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB11 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnDecimoSegundoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB12 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnDecimoTercerGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB13 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnDecimoCuartoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB14 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }
    protected void btnDecimoQuintoGuardar04_Click(object sender, EventArgs e)
    {
        ValidarGridPreguntas();
        if (valueRB15 == 0)
        {
            AgregarGridPreguntasInstrumento04(lblCodDocenteAsesor.Text, "4");
            //btnRegresarCaracterizacion.Visible = true;
            btnGuardarAutopercepcion.Visible = true;
            //btnGuardarPerfilDocente.Visible = true;
            //btnRegresarAutopercepcion.Visible = true;

            PanelAutopercepcionDocentes.Visible = true;
            //PanelPerfilDocente.Visible = true;

            Paneltime.Visible = false;
        }

        //Instrumento 05
        //gvCargarDatos();
        // cargarPreguntasInstrumento05(lblCodRegInstitucion.Text);


    }

    private void cargarPreguntasInstrumento04(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasInstrumento04(codreginstitucion,"4");

        if(datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < GridPregunta1.Rows.Count; i++)
            {
                GridViewRow row = GridPregunta1.Rows[i];
                RadioButtonList dd = (row.FindControl("rb1") as RadioButtonList);
                dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
            }

            if (datos != null && datos.Rows.Count > 3)
            {
                int i = 3;
                foreach (GridViewRow row in GridPregunta2.Rows)
                {
         
                        RadioButtonList dd = (row.FindControl("rb2") as RadioButtonList);
                        dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 6)
            {
                int i = 6;
                foreach (GridViewRow row in GridPregunta3.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb3") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 9)
            {
                int i = 9;
                foreach (GridViewRow row in GridPregunta4.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb4") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 12)
            {
                int i = 12;
                foreach (GridViewRow row in GridPregunta5.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb5") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 15)
            {
                int i = 15;
                foreach (GridViewRow row in GridPregunta6.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb6") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 18)
            {
                int i = 18;
                foreach (GridViewRow row in GridPregunta7.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb7") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 21)
            {
                int i = 21;
                foreach (GridViewRow row in GridPregunta8.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb8") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 24)
            {
                int i = 24;
                foreach (GridViewRow row in GridPregunta9.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb9") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 27)
            {
                int i = 27;
                foreach (GridViewRow row in GridPregunta10.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb10") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 30)
            {
                int i = 30;
                foreach (GridViewRow row in GridPregunta11.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb11") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 33)
            {
                int i = 33;
                foreach (GridViewRow row in GridPregunta12.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb12") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 36)
            {
                int i = 36;
                foreach (GridViewRow row in GridPregunta13.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb13") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 39)
            {
                int i = 39;
                foreach (GridViewRow row in GridPregunta14.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb14") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
            }

            if (datos != null && datos.Rows.Count > 42)
            {
                int i = 42;
                foreach (GridViewRow row in GridPregunta15.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb15") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
                    i++;

                }
                int j = 45;
                foreach (GridViewRow row in GridPregunta16.Rows)
                {
                    RadioButtonList dd = (row.FindControl("rb16") as RadioButtonList);
                    dd.SelectedValue = datos.Rows[j]["respuesta"].ToString();
                    j++;

                }
               
            }

            if (datos.Rows.Count < 50)
            {

            }
        }

       


        
    }

    private void cargarPreguntasInstrumento05(string coddocenteasesor, string codsede)
    {
        LineaBase lb = new LineaBase();

        DataRow datos = lb.buscarDocenteInstrumento05(coddocenteasesor);
        DataTable doc = lb.cargarDocenteXSede(codsede);

        if(datos != null)
        {
         //   dropDocente.SelectedValue = datos["codigo"].ToString();

            cargarPerfilDocente(coddocenteasesor, chkClaseFuncionario);
            cargarNivelEducativoDocente(coddocenteasesor, chkNivelEducativoDocente);
            cargarNivelFormacionDocente(coddocenteasesor);
            cargarAreaEnsenianzaAcademico(coddocenteasesor, chkAreaEnsenianzaAcademico);
            cargarAreaEnsenianzaTecnico(coddocenteasesor, chkAreaEnsenianzaTecnico);
            cargarAreaEnsenianzaComercialyServicio(coddocenteasesor, chkAreaEnsenianzaComercialServ);
            cargarAreaEnsenianzaIndustrial(coddocenteasesor, chkAreaEnsenianzaIndustrial);
            cargarAreaEnsenianzaCajaTexto(coddocenteasesor);
            cargarFormacionInvestigacionDocente(coddocenteasesor);
            cargarContribuyoPracticaPedagogica(coddocenteasesor, rbContribuyoPracticaPedago);
            cargarProyectoInvestigacionIE(coddocenteasesor, rbProyectoInvestigacionIE, chkModalidadProyectoInvgestigacion);
            cargarProyectoInvestigacionFueraIE(coddocenteasesor, rbProyectoInvestigacionFueraIE);
            cargarProyectoNiniosNinias(coddocenteasesor, rbProyectoNiniosNinias, chkProyectoNiniosNinias);
            cargarFormacionPracticaPedagogica(coddocenteasesor, rbFormacionPracticaPedagogica);
            cargarFormacionCienciaTecnoInno(coddocenteasesor);
            cargarFormacionNTICs(coddocenteasesor);
            cargarFormacionNTICs101(coddocenteasesor, rbFormacionNTICs);
        }

    }
    private void cargarPerfilDocente(string coddocenteasesor, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(coddocenteasesor, "1", "0", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
    }
    private void cargarNivelFormacionDocente(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "2", "0","5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if(escogido != null && escogido.Rows.Count>0)
        {
            int i = 0;
            foreach (GridViewRow row in GridFormacionDocente.Rows)
            {
                TextBox dd = (row.FindControl("txtAnioFormacion") as TextBox);

                if (i < escogido.Rows.Count)
                {
                    dd.Text = escogido.Rows[i]["respuesta"].ToString();
                    
                }
                i++; 

            }
        }
       
    }
    private void cargarNivelEducativoDocente(string codreginstitucion, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "3", "0", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
    }
    private void cargarAreaEnsenianzaAcademico(string codreginstitucion, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "4", "1", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion,"4.1","5");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        if(txtescogido != null)
        {
            txtAreaEnsenianzaAcademico.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarAreaEnsenianzaTecnico(string codreginstitucion, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "4", "2", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.2", "5");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        if (txtescogido != null)
        {
            txtAreaEnsenianzaTecnico.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarAreaEnsenianzaComercialyServicio(string codreginstitucion, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "4", "3", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.3", "5");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        if (txtescogido != null)
        {
            txtAreaEnsenianzaComercialServ.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarAreaEnsenianzaIndustrial(string codreginstitucion, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "4", "4", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.4", "5");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        if (txtescogido != null)
        {
            txtAreaEnsenianzaIndustrial.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarAreaEnsenianzaCajaTexto(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataRow txtpedagogico = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.5", "5");
        DataRow txtpromsocial = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.6", "5");
        DataRow txtinformatica = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.7", "5");
        DataRow txtotra = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "4.8", "5");

        if (txtpedagogico != null)
        {
            txtAreaEnsenianzaPedagogica.Text = txtpedagogico["comentario"].ToString();
        }
        if (txtpromsocial != null)
        {
            txtAreaEnsenianzaPromocionSocial.Text = txtpromsocial["comentario"].ToString();
        }
        if (txtinformatica != null)
        {
            txtAreaEnsenianzaInformatica.Text = txtinformatica["comentario"].ToString();
        }
        if (txtotra != null)
        {
            txtAreaEnsenianzaOtra.Text = txtotra["comentario"].ToString();
        }
    }
    private void cargarFormacionInvestigacionDocente(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasPerfilDocentexInstrumento05(codreginstitucion, "5", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if (escogido != null && escogido.Rows.Count > 0)
        {
            int i = 0;

            foreach (GridViewRow row in GridFormacionInvestigacionDocente.Rows)
            {
                DropDownList dropFomacionInvesTipo = (row.FindControl("dropFomacionInvesTipo") as DropDownList);
                TextBox txtNomFormacionInvesTipo = (row.FindControl("txtNomFormacionInvesTipo") as TextBox);
                TextBox txtDuracionFormacionInvesTipo = (row.FindControl("txtDuracionFormacionInvesTipo") as TextBox);
                TextBox txtAnioFormacionInvesTipo = (row.FindControl("txtAnioFormacionInvesTipo") as TextBox);
                DropDownList dropFomacionInvesModalidad = (row.FindControl("dropFomacionInvesModalidad") as DropDownList);
     
                dropFomacionInvesTipo.SelectedValue = escogido.Rows[i]["tipo"].ToString();
                txtNomFormacionInvesTipo.Text = escogido.Rows[i]["nombre"].ToString();
                txtDuracionFormacionInvesTipo.Text = escogido.Rows[i]["duracion"].ToString();
                txtAnioFormacionInvesTipo.Text = escogido.Rows[i]["anio"].ToString();
                dropFomacionInvesModalidad.SelectedValue = escogido.Rows[i]["modalidad"].ToString();

                i++;

            }
        }

    }
    private void cargarContribuyoPracticaPedagogica(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "5", "1", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "5.1", "5");

        if (escogido != null && escogido.Rows.Count > 0)
        {
            rb.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }


        if (txtescogido != null)
        {
            txtContribuyoPracticaPedago.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarProyectoInvestigacionIE(string codreginstitucion, RadioButtonList rb, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "6", "0", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataTable escogido2 = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "6", "1", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "6", "5");

        if(escogido != null && escogido.Rows.Count > 0)
        {
            rb.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido2.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido2.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        if (txtescogido != null)
        {
            txtProyectoInvestigacionIE.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarProyectoInvestigacionFueraIE(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "7", "0", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "7", "5");

        if (escogido != null && escogido.Rows.Count > 0)
        {
            rb.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }

       
        if (txtescogido != null)
        {
            txtProyectoInvestigacionFueraIE.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarProyectoNiniosNinias(string codreginstitucion, RadioButtonList rb, CheckBoxList chk)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "8", "0", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataTable escogido2 = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "8", "1", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "8", "5");

        if (escogido != null && escogido.Rows.Count > 0)
        {
            rb.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido2.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido2.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        if (txtescogido != null)
        {
            txtProyectoNiniosNinias.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarFormacionCienciaTecnoInno(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasPerfilDocentexInstrumento05(codreginstitucion, "9", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if (escogido != null && escogido.Rows.Count > 0)
        {
            int i = 0;

            foreach (GridViewRow row in GridFormacionCienciaTecnoInno.Rows)
            {
                DropDownList dropFomacionInvesTipo = (row.FindControl("dropFomacionCienciaTecnoInno") as DropDownList);
                TextBox txtNomFormacionInvesTipo = (row.FindControl("txtNomFormacionCienciaTecnoInno") as TextBox);
                TextBox txtDuracionFormacionInvesTipo = (row.FindControl("txtDuracionFormacionCienciaTecnoInno") as TextBox);
                TextBox txtAnioFormacionInvesTipo = (row.FindControl("txtAnioFormacionCienciaTecnoInno") as TextBox);
                DropDownList dropFomacionInvesModalidad = (row.FindControl("dropFomacionCienciaTecnoInnoMod") as DropDownList);

                dropFomacionInvesTipo.SelectedValue = escogido.Rows[i]["tipo"].ToString();
                txtNomFormacionInvesTipo.Text = escogido.Rows[i]["nombre"].ToString();
                txtDuracionFormacionInvesTipo.Text = escogido.Rows[i]["duracion"].ToString();
                txtAnioFormacionInvesTipo.Text = escogido.Rows[i]["anio"].ToString();
                dropFomacionInvesModalidad.SelectedValue = escogido.Rows[i]["modalidad"].ToString();

                i++;

            }
        }

    }
    private void cargarFormacionPracticaPedagogica(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "9", "1", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "9.1", "5");

        if (escogido != null && escogido.Rows.Count > 0)
        {
            rb.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }


        if (txtescogido != null)
        {
            txtFormacionPracticaPedagogica.Text = txtescogido["comentario"].ToString();
        }
    }
    private void cargarFormacionNTICs(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasPerfilDocentexInstrumento05(codreginstitucion, "10", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if (escogido != null && escogido.Rows.Count > 0)
        {
            int i = 0;

            foreach (GridViewRow row in GridFormacionNTICs.Rows)
            {
                DropDownList dropFomacionInvesTipo = (row.FindControl("dropFormacionNTICs") as DropDownList);
                TextBox txtTipo = (row.FindControl("txtNomFormacionNTICs") as TextBox);
                TextBox txtDuracionFormacionInvesTipo = (row.FindControl("txtDuracionFormacionNTICs") as TextBox);
                TextBox txtAnioFormacionInvesTipo = (row.FindControl("txtAnioFormacionNTICs") as TextBox);
                DropDownList dropFomacionInvesModalidad = (row.FindControl("dropFormacionNTICsMod") as DropDownList);

                dropFomacionInvesTipo.SelectedValue = escogido.Rows[i]["tipo"].ToString();
                txtTipo.Text = escogido.Rows[i]["nombre"].ToString();
                txtDuracionFormacionInvesTipo.Text = escogido.Rows[i]["duracion"].ToString();
                txtAnioFormacionInvesTipo.Text = escogido.Rows[i]["anio"].ToString();
                dropFomacionInvesModalidad.SelectedValue = escogido.Rows[i]["modalidad"].ToString();

                i++;

            }
        }

    }
    private void cargarFormacionNTICs101(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.cargarRespuestasCerradasxInstrumento05(codreginstitucion, "10", "1", "5");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataRow txtescogido = lb.cargarRespuestasAbiertasxIntrumento05(codreginstitucion, "10.1", "5");

        if (escogido != null && escogido.Rows.Count > 0)
        {
            rb.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }


        if (txtescogido != null)
        {
            txtFormacionNTICs.Text = txtescogido["comentario"].ToString();
        }
    }
    private void ValidarGridPreguntas()
    {
        RecorrerGridPregunta1();
        RecorrerGridPregunta2();
        RecorrerGridPregunta3();
        RecorrerGridPregunta4();
        RecorrerGridPregunta5();
        RecorrerGridPregunta6();
        RecorrerGridPregunta7();
        RecorrerGridPregunta8();
        RecorrerGridPregunta9();
        RecorrerGridPregunta10();
        RecorrerGridPregunta11();
        RecorrerGridPregunta12();
        RecorrerGridPregunta13();
        RecorrerGridPregunta14();
        RecorrerGridPregunta15();
        RecorrerGridPregunta16();
    }
    private void AgregarGridPreguntasInstrumento04(string codreginstitucion, string codinstrumento)
    {
       
        LineaBase lb = new LineaBase();

        if (lb.eliminarRespuestaCerrada(codreginstitucion, "1", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "2", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "3", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "4", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "5", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "6", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "7", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "8", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "9", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "10", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "11", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "12", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "13", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "14", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "15", "0", codinstrumento)) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "16", "0", codinstrumento)) { }

        int rb1 = 0;
        int rm1 = 0;
        foreach(GridViewRow row in GridPregunta1.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb1") as RadioButtonList);
            string rb = dd.SelectedValue;
            if(rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "1", "0", rb, codinstrumento)) { rb1++; } else { rm1++; }
            }

        }
        if(rb1 > 0)
        {
            mostrarmensaje("exito","Respuestas guardadas exitosamente.");
        }else if(rm1 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb2 = 0;
        int rm2 = 0;
        foreach (GridViewRow row in GridPregunta2.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb2") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "2", "0", rb, codinstrumento)) { rb2++; } else { rm2++; }
            }
        }
        if (rb2 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm2 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb3 = 0;
        int rm3 = 0;
        foreach (GridViewRow row in GridPregunta3.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb3") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "3", "0", rb, codinstrumento)) { rb3++; } else { rm3++; }
            }
        }
        if (rb3 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm3 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb4 = 0;
        int rm4 = 0;
        foreach (GridViewRow row in GridPregunta4.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb4") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "4", "0", rb, codinstrumento)) { rb4++; } else { rm4++; }
            }
        }
        if (rb4 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm4 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb5 = 0;
        int rm5 = 0;
        foreach (GridViewRow row in GridPregunta5.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb5") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "5", "0", rb, codinstrumento)) { rb5++; } else { rm5++; }
            }
        }
        if (rb5 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm5 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb6 = 0;
        int rm6 = 0;
        foreach (GridViewRow row in GridPregunta6.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb6") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "6", "0", rb, codinstrumento)) { rb6++; } else { rm6++; }
            }
        }
        if (rb6 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm6 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb7 = 0;
        int rm7 = 0;
        foreach (GridViewRow row in GridPregunta7.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb7") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "7", "0", rb, codinstrumento)) { rb7++; } else { rm7++; }
            }
        }
        if (rb7 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm7 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb8 = 0;
        int rm8 = 0;
        foreach (GridViewRow row in GridPregunta8.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb8") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "8", "0", rb, codinstrumento)) { rb8++; } else { rm8++; }
            }
        }
        if (rb8 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm8 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb9 = 0;
        int rm9 = 0;
        foreach (GridViewRow row in GridPregunta9.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb9") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "9", "0", rb, codinstrumento)) { rb9++; } else { rm9++; }
            }
        }
        if (rb9 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm9 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb10 = 0;
        int rm10 = 0;
        foreach (GridViewRow row in GridPregunta10.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb10") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "10", "0", rb, codinstrumento)) { rb10++; } else { rm10++; }
            }
        }
        if (rb10 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm10 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb11 = 0;
        int rm11 = 0;
        foreach (GridViewRow row in GridPregunta11.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb11") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "11", "0", rb, codinstrumento)) { rb11++; } else { rm11++; }
            }
        }
        if (rb11 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm11 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb12 = 0;
        int rm12 = 0;
        foreach (GridViewRow row in GridPregunta12.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb12") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "12", "0", rb, codinstrumento)) { rb12++; } else { rm12++; }
            }
        }
        if (rb12 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm12 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb13 = 0;
        int rm13 = 0;
        foreach (GridViewRow row in GridPregunta13.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb13") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "13", "0", rb, codinstrumento)) { rb13++; } else { rm13++; }
            }
        }
        if (rb13 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm13 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb14 = 0;
        int rm14 = 0;
        foreach (GridViewRow row in GridPregunta14.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb14") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "14", "0", rb, codinstrumento)) { rb14++; } else { rm14++; }
            }
        }
        if (rb14 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm14 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb15 = 0;
        int rm15 = 0;
        foreach (GridViewRow row in GridPregunta15.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb15") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "15", "0", rb, codinstrumento)) { rb15++; } else { rm15++; }
            }
        }
        if (rb15 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm15 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }

        int rb16 = 0;
        int rm16 = 0;
        foreach (GridViewRow row in GridPregunta16.Rows)
        {
            RadioButtonList dd = (row.FindControl("rb16") as RadioButtonList);
            string rb = dd.SelectedValue;
            if (rb != "")
            {
                if (lb.AgregarRespuestaCerrada(codreginstitucion, "16", "0", rb, codinstrumento)) { rb16++; } else { rm16++; }
            }
        }
        if (rb16 > 0)
        {
            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
        }
        else if (rm16 > 0)
        {
            mostrarmensaje("error", "Error al guardar respuestas.");
        }
    }
    protected void btnRegresarCaracterizacion_Click(object sender, EventArgs e)
    {
        btnGuardarAutopercepcion.Visible = false;
        PanelAutopercepcionDocentes.Visible = false;

        //btnGuardar.Visible = true;
        //PanelCaracterizacion.Visible= true;
    }

   
    private int value = 0;
    int valueRB1 = 0;
    private void RecorrerGridPregunta1()
    {
        foreach (GridViewRow row in GridPregunta1.Rows)
        {
            if (value == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb1") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB1 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB1++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb1") as RadioButtonList);
            }
        }
    }

    private int value2 = 0;
    int valueRB2 = 0;
    private void RecorrerGridPregunta2()
    {
        foreach (GridViewRow row in GridPregunta2.Rows)
        {
            if (value2 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb2") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB2 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB2++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb2") as RadioButtonList);
            }
        }
    }
    private int value3 = 0;
    int valueRB3 = 0;
    private void RecorrerGridPregunta3()
    {
        foreach (GridViewRow row in GridPregunta3.Rows)
        {
            if (value3 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb3") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB3 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB3++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb3") as RadioButtonList);
            }
        }
    }
    private int value4 = 0;
    int valueRB4 = 0;
    private void RecorrerGridPregunta4()
    {
        foreach (GridViewRow row in GridPregunta4.Rows)
        {
            if (value == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb4") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB4 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB4++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb4") as RadioButtonList);
            }
        }
    }
    private int value5 = 0;
    int valueRB5 = 0;
    private void RecorrerGridPregunta5()
    {
        foreach (GridViewRow row in GridPregunta5.Rows)
        {
            if (value5 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb5") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB5 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB5++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb5") as RadioButtonList);
            }
        }
    }
    private int value6 = 0;
    int valueRB6 = 0;
    private void RecorrerGridPregunta6()
    {
        foreach (GridViewRow row in GridPregunta6.Rows)
        {
            if (value6 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb6") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB6 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB6++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb6") as RadioButtonList);
            }
        }
    }
    private int value7 = 0;
    int valueRB7 = 0;
    private void RecorrerGridPregunta7()
    {
        foreach (GridViewRow row in GridPregunta7.Rows)
        {
            if (value7 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb7") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB7 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB7++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb7") as RadioButtonList);
            }
        }
    }
    private int value8 = 0;
    int valueRB8 = 0;
    private void RecorrerGridPregunta8()
    {
        foreach (GridViewRow row in GridPregunta8.Rows)
        {
            if (value8 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb8") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB8 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB8++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb8") as RadioButtonList);
            }
        }
    }
    private int value9 = 0;
    int valueRB9 = 0;
    private void RecorrerGridPregunta9()
    {
        foreach (GridViewRow row in GridPregunta9.Rows)
        {
            if (value9 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb9") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB9 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB9++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb9") as RadioButtonList);
            }
        }
    }
    private int value10 = 0;
    int valueRB10 = 0;
    private void RecorrerGridPregunta10()
    {
        foreach (GridViewRow row in GridPregunta10.Rows)
        {
            if (value10 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb10") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB10 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB10++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb10") as RadioButtonList);
            }
        }
    }
    private int value11 = 0;
    int valueRB11 = 0;
    private void RecorrerGridPregunta11()
    {
        foreach (GridViewRow row in GridPregunta11.Rows)
        {
            if (value11 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb11") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB11 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB11++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb11") as RadioButtonList);
            }
        }
    }
    private int value12 = 0;
    int valueRB12 = 0;
    private void RecorrerGridPregunta12()
    {
        foreach (GridViewRow row in GridPregunta12.Rows)
        {
            if (value12 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb12") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB12 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB12++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb12") as RadioButtonList);
            }
        }
    }
    private int value13 = 0;
    int valueRB13 = 0;
    private void RecorrerGridPregunta13()
    {
        foreach (GridViewRow row in GridPregunta13.Rows)
        {
            if (value13 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb13") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB13 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB13++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb13") as RadioButtonList);
            }
        }
    }
    private int value14 = 0;
    int valueRB14 = 0;
    private void RecorrerGridPregunta14()
    {
        foreach (GridViewRow row in GridPregunta14.Rows)
        {
            if (value14 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb14") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB14 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB14++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb14") as RadioButtonList);
            }
        }
    }
    private int value15 = 0;
    int valueRB15 = 0;
    private void RecorrerGridPregunta15()
    {
        foreach (GridViewRow row in GridPregunta15.Rows)
        {
            if (value15 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb15") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB15 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB15++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb15") as RadioButtonList);
            }
        }
    }
    private int value16 = 0;
    int valueRB16 = 0;
    private void RecorrerGridPregunta16()
    {
        foreach (GridViewRow row in GridPregunta16.Rows)
        {
            if (value16 == 0)
            {
                RadioButtonList ddlCountries = (row.FindControl("rb16") as RadioButtonList);
                if (ddlCountries.SelectedIndex > -1)
                {
                    row.BackColor = Color.Empty;
                    valueRB16 = 0;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    valueRB16++;
                }
            }
            else
            {
                RadioButtonList ddlCountries = (row.FindControl("rb16") as RadioButtonList);
            }
        }
    }

    protected void btnRegresarAutopercepcion_Click(object sender, EventArgs e)
    {
        PanelPerfilDocente.Visible = false;
        btnRegresarAutopercepcion.Visible = false;
        btnGuardarPerfilDocente.Visible = false;

        PanelAutopercepcionDocentes.Visible = true;
        btnRegresarCaracterizacion.Visible = true;
        btnGuardarAutopercepcion.Visible = true;

    }

    protected void btnGuardarPerfilDocente_Click(object sender, EventArgs e)
    {
       // btnGuardarPerfilDocente.Visible = false;

        //if (validarChkClaseFuncionario(chkClaseFuncionario))
        //{
        //   // gvValidarUltimoNIvelFormacion();
        //    //if (validarTextLleno > 0)
        //    //{
        //        if (validarChkNivelEducativo(chkNivelEducativoDocente))
        //        {
        //            if (validarChkAreaEnsenianzaAcademico(chkAreaEnsenianzaAcademico))//Validar el textbox
        //            {
                          
        //                       //Validar los textbox si está vacio Pedagógica, Promoción social, Informática

        //                           // gvValidarFormacionInvestigacion();
        //                            //if (validarTextLleno2 > 0)
        //                            //{
        //                                if(validarRBContribuyoPracticaPedago())
        //                                {
        //                                    //Validar el texbox

        //                                    if (validarRBProyectoInvestigacionIE())
        //                                    {
        //                                        //Validar el texbox
        //                                        if (validarRBProyectoInvestigacionFueraIE())
        //                                        {
        //                                            //Validar el texbox
        //                                            if (validarRBProyectoNiniosNinias())
        //                                            {
                                                       //Validar el texbox
                                                        // gvValidarFormacionCienciaTecInno();
                                                         //if (validarTextLleno3 > 0)
                                                         //{
                                                             if (validarRBFormacionPracticaPedagogica())
                                                             {
                                                                 //Validar el texbox
                                                                // gvValidarFormacionNTICs();
                                                                 //if (validarTextLleno4 > 0)
                                                                 //{ 
                                                                     if(validarRBFormacionNTICs())
                                                                     {
                                                                        
                                                                        //Guardar los datos
                                                                         LineaBase lb = new LineaBase();
                                                                         DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                                                                         if (info != null)
                                                                         {
                                                                             DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                                                                             if (regins != null)
                                                                             {
                                                                                 lblCodDocenteAsesor.Text = regins["codigo"].ToString();

                                                                                 ////ActualizarDatoInstitucionalDocente(lblCodRegInstitucion.Text, dropDocente.SelectedValue);

                                                                                 //EliminarClaseFuncionario(lblCodDocenteAsesor.Text);
                                                                                 //AgregarClaseFuncionarioDocente(lblCodDocenteAsesor.Text, chkClaseFuncionario);

                                                                                 //EliminarUltimoNivelFormacion(lblCodDocenteAsesor.Text);
                                                                                 //AgregarUltimoNIvelFormacion(lblCodDocenteAsesor.Text);

                                                                                 //EliminarNivelEducativoDocente(lblCodDocenteAsesor.Text);
                                                                                 //AgregarNnivelEducativoDocente(lblCodDocenteAsesor.Text, chkNivelEducativoDocente);

                                                                                 //EliminarAreaDeEnsenianzaAcademico(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaAcademico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaAcademico);

                                                                                 //EliminarAreaDeEnsenianzaTecnico(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaTecnico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaTecnico);

                                                                                 //EliminarAreaDeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text, chkAreaEnsenianzaComercialServ);

                                                                                 //EliminarAreaDeEnsenianzaIndustrial(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaIndustrial(lblCodDocenteAsesor.Text, chkAreaEnsenianzaIndustrial);

                                                                                 //EliminarAreaDeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);

                                                                                 //EliminarAreaDeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);

                                                                                 //EliminarAreaDeEnsenianzaInformatica(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreadeEnsenianzaInformatica(lblCodDocenteAsesor.Text);

                                                                                 //EliminarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);
                                                                                 //AgregarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);

                                                                                 //EliminarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);
                                                                                 //AgregarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);

                                                                                 //EliminarContribuyoPracticaPedago(lblCodDocenteAsesor.Text);
                                                                                 //AgregarContribuyoPracticaPedago(lblCodDocenteAsesor.Text, rbContribuyoPracticaPedago);

                                                                                 //EliminarProyectoInvestigacionIE(lblCodDocenteAsesor.Text);
                                                                                 //AgregarProyectoInvestigacionIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionIE, chkModalidadProyectoInvgestigacion);

                                                                                 //EliminarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text);
                                                                                 //AgregarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionFueraIE);

                                                                                 //EliminarProyectoNiniosNinias(lblCodDocenteAsesor.Text);
                                                                                 //AgregarProyectoNiniosNinias(lblCodDocenteAsesor.Text, rbProyectoNiniosNinias, chkProyectoNiniosNinias);

                                                                                 EliminarFormacionCienciaTecnoInno(lblCodDocenteAsesor.Text);
                                                                                 AgregarFormacionCienciaTecnoInno(lblCodDocenteAsesor.Text);

                                                                                 EliminarFormacionPracticaPedagogica(lblCodDocenteAsesor.Text);
                                                                                 AgregarFormacionPracticaPedagogica(lblCodDocenteAsesor.Text, rbFormacionPracticaPedagogica);

                                                                                 EliminarFormacionNTICs(lblCodDocenteAsesor.Text);
                                                                                 AgregarFormacionNTICs(lblCodDocenteAsesor.Text);

                                                                                 EliminarFormacionNTICs101(lblCodDocenteAsesor.Text);
                                                                                 AgregarFormacionNTICs101(lblCodDocenteAsesor.Text, rbFormacionNTICs);
                                                                                 btnGuardarPerfilDocente.Visible = true;
                                                                                 mostrarmensaje("exito","Respuestas guardadas exitosamente.");
                                                                                 
                                                                             }
                                                                             else
                                                                             {
                                                                                 if (dropAsesor.SelectedIndex == 0)
                                                                                 {
                                                                                     mostrarmensaje("error", "Por favor seleccione el asesor. ");
                                                                                 }
                                                                                 else
                                                                                 {
                                                                                     DataRow coddocenteasesor = lb.agregarDocenteAsesor(info["cod"].ToString(), dropAsesor.SelectedValue);

                                                                                     if (coddocenteasesor != null)
                                                                                     {
                                                                                         lblCodDocenteAsesor.Text = coddocenteasesor["codigo"].ToString();

                                                                                         ////ActualizarDatoInstitucionalDocente(lblCodRegInstitucion.Text, dropDocente.SelectedValue);

                                                                                         //EliminarClaseFuncionario(lblCodDocenteAsesor.Text);
                                                                                         //AgregarClaseFuncionarioDocente(lblCodDocenteAsesor.Text, chkClaseFuncionario);

                                                                                         //EliminarUltimoNivelFormacion(lblCodDocenteAsesor.Text);
                                                                                         //AgregarUltimoNIvelFormacion(lblCodDocenteAsesor.Text);

                                                                                         //EliminarNivelEducativoDocente(lblCodDocenteAsesor.Text);
                                                                                         //AgregarNnivelEducativoDocente(lblCodDocenteAsesor.Text, chkNivelEducativoDocente);

                                                                                         //EliminarAreaDeEnsenianzaAcademico(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaAcademico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaAcademico);

                                                                                         //EliminarAreaDeEnsenianzaTecnico(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaTecnico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaTecnico);

                                                                                         //EliminarAreaDeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text, chkAreaEnsenianzaComercialServ);

                                                                                         //EliminarAreaDeEnsenianzaIndustrial(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaIndustrial(lblCodDocenteAsesor.Text, chkAreaEnsenianzaIndustrial);

                                                                                         //EliminarAreaDeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);

                                                                                         //EliminarAreaDeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);

                                                                                         //EliminarAreaDeEnsenianzaInformatica(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreadeEnsenianzaInformatica(lblCodDocenteAsesor.Text);

                                                                                         //EliminarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);
                                                                                         //AgregarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);

                                                                                         //EliminarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);
                                                                                         //AgregarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);

                                                                                         //EliminarContribuyoPracticaPedago(lblCodDocenteAsesor.Text);
                                                                                         //AgregarContribuyoPracticaPedago(lblCodDocenteAsesor.Text, rbContribuyoPracticaPedago);

                                                                                         //EliminarProyectoInvestigacionIE(lblCodDocenteAsesor.Text);
                                                                                         //AgregarProyectoInvestigacionIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionIE, chkModalidadProyectoInvgestigacion);

                                                                                         //EliminarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text);
                                                                                         //AgregarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionFueraIE);

                                                                                         //EliminarProyectoNiniosNinias(lblCodDocenteAsesor.Text);
                                                                                         //AgregarProyectoNiniosNinias(lblCodDocenteAsesor.Text, rbProyectoNiniosNinias, chkProyectoNiniosNinias);

                                                                                         EliminarFormacionCienciaTecnoInno(lblCodDocenteAsesor.Text);
                                                                                         AgregarFormacionCienciaTecnoInno(lblCodDocenteAsesor.Text);

                                                                                         EliminarFormacionPracticaPedagogica(lblCodDocenteAsesor.Text);
                                                                                         AgregarFormacionPracticaPedagogica(lblCodDocenteAsesor.Text, rbFormacionPracticaPedagogica);

                                                                                         EliminarFormacionNTICs(lblCodDocenteAsesor.Text);
                                                                                         AgregarFormacionNTICs(lblCodDocenteAsesor.Text);

                                                                                         EliminarFormacionNTICs101(lblCodDocenteAsesor.Text);
                                                                                         AgregarFormacionNTICs101(lblCodDocenteAsesor.Text, rbFormacionNTICs);

                                                                                         btnGuardarPerfilDocente.Visible = true;
                                                                                         mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
                                                                                     }
                                                                                 }
                                                                                
                                                                             }


                                                                         }

                                                                        

                                                                        


                                                                         //cargarPreguntasInstrumento06();

                                                                         //btnRegresarAutopercepcion.Visible = false;
                                                                         btnGuardarPerfilDocente.Visible = false;
                                                                         //PanelAutopercepcionDocentes.Visible = false;
                                                                         //PanelPerfilDocente.Visible = false;

                                                                         //PanelEstudiantes.Visible = true;
                                                                         //btnTerminar.Visible = true;
                                                                         //btnRegresarPerfilDocente.Visible = true;

                                                                         Paneltime.Visible = false;
                                                                     }
                                                                 //}
                                                             }
                                                         //}
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            //}
        //                            //else
        //                            //{
        //                            //    mostrarmensaje("error", "ERROR: Debe digitar minimo 1 año en el ítem # 5: formación específica investigación.");
        //                            //}

                              
                         
                       
        //            }
        //            else
        //            {
        //                mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 4: Áreas de enseñanza en las que desarrolla la docencia (carácter académico).");
        //            }
        //        }
        //        else
        //        {
        //            mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 3: Nivel educativo en el que trabaja.");
        //        }
        //    //}
        //    //else
        //    //{
        //    //    mostrarmensaje("error", "ERROR: Debe digitar minimo 1 año en el ítem # 2: Ultimo año de formación obtenido.");
        //    //}
        //}
        //else
        //{
        //    mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 1: Clase de funcionario.");
        //}

    }
    protected void btnPrimerGuardar05_Click(object sender, EventArgs e)
    {
        // btnGuardarPerfilDocente.Visible = false;

        if (validarChkClaseFuncionario(chkClaseFuncionario))
        {
            // gvValidarUltimoNIvelFormacion();
            //if (validarTextLleno > 0)
            //{
            if (validarChkNivelEducativo(chkNivelEducativoDocente))
            {
                
                    //Validar los textbox si está vacio Pedagógica, Promoción social, Informática

                    // gvValidarFormacionInvestigacion();
                    //if (validarTextLleno2 > 0)
                    //{
                    //if (validarRBContribuyoPracticaPedago())
                    //{
                    //    //Validar el texbox

                    //    if (validarRBProyectoInvestigacionIE())
                    //    {
                    //        //Validar el texbox
                    //        if (validarRBProyectoInvestigacionFueraIE())
                    //        {
                    //            //Validar el texbox
                    //            if (validarRBProyectoNiniosNinias())
                    //            {
                    //                //Validar el texbox
                    //                // gvValidarFormacionCienciaTecInno();
                    //                //if (validarTextLleno3 > 0)
                    //                //{
                    //                if (validarRBFormacionPracticaPedagogica())
                    //                {
                    //                    //Validar el texbox
                    //                    // gvValidarFormacionNTICs();
                    //                    //if (validarTextLleno4 > 0)
                    //                    //{ 
                    //                    if (validarRBFormacionNTICs())
                    //                    {

                                            //Guardar los datos
                                            LineaBase lb = new LineaBase();
                                            DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                                            if (info != null)
                                            {
                                                DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                                                if (regins != null)
                                                {
                                                    lblCodDocenteAsesor.Text = regins["codigo"].ToString();


                                                }
                                                else
                                                {
                                                    DataRow coddocenteasesor = lb.agregarDocenteAsesor(info["cod"].ToString(), dropAsesor.SelectedValue);

                                                    if (coddocenteasesor != null)
                                                    {
                                                        lblCodDocenteAsesor.Text = coddocenteasesor["codigo"].ToString();
                                                    }
                                                    else
                                                    {
                                                        mostrarmensaje("error", "Por favor seleccione el asesor. ");
                                                    }
                                                }


                                            }



                                            ////ActualizarDatoInstitucionalDocente(lblCodRegInstitucion.Text, dropDocente.SelectedValue);

                                            EliminarClaseFuncionario(lblCodDocenteAsesor.Text);
                                            AgregarClaseFuncionarioDocente(lblCodDocenteAsesor.Text, chkClaseFuncionario);

                                            EliminarUltimoNivelFormacion(lblCodDocenteAsesor.Text);
                                            AgregarUltimoNIvelFormacion(lblCodDocenteAsesor.Text);

                                            EliminarNivelEducativoDocente(lblCodDocenteAsesor.Text);
                                            AgregarNnivelEducativoDocente(lblCodDocenteAsesor.Text, chkNivelEducativoDocente);

                                           
                                            if(contniveleducativo > 0 && contultimonivel > 0 && contclasefuncionario > 0)
                                            {
                                                mostrarmensaje("exito","Respuestas guardadas exitosamente.");
                                            }
                                            else
                                            {
                                                mostrarmensaje("error","Error al guardar.");
                                            }

                                            //cargarPreguntasInstrumento06();

                                            //btnRegresarAutopercepcion.Visible = false;
                                            btnGuardarPerfilDocente.Visible = false;
                                            //PanelAutopercepcionDocentes.Visible = false;
                                            //PanelPerfilDocente.Visible = false;

                                            //PanelEstudiantes.Visible = true;
                                            //btnTerminar.Visible = true;
                                            //btnRegresarPerfilDocente.Visible = true;

                                            Paneltime.Visible = false;
                    //                    }
                    //                    //}
                    //                }
                    //                //}
                    //            }
                    //        }
                    //    }
                    //}
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "ERROR: Debe digitar minimo 1 año en el ítem # 5: formación específica investigación.");
                    //}




               
            }
            else
            {
                mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 3: Nivel educativo en el que trabaja.");
            }
            //}
            //else
            //{
            //    mostrarmensaje("error", "ERROR: Debe digitar minimo 1 año en el ítem # 2: Ultimo año de formación obtenido.");
            //}
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 1: Clase de funcionario.");
        }

    }
    protected void btnSegundoGuardar05_Click(object sender, EventArgs e)
    {
        

                //Guardar los datos
                LineaBase lb = new LineaBase();
                DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                if (info != null)
                {
                    DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                    if (regins != null)
                    {
                        lblCodDocenteAsesor.Text = regins["codigo"].ToString();

                        EliminarAreaDeEnsenianzaAcademico(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaAcademico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaAcademico);

                        EliminarAreaDeEnsenianzaTecnico(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaTecnico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaTecnico);

                        EliminarAreaDeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text, chkAreaEnsenianzaComercialServ);

                        EliminarAreaDeEnsenianzaIndustrial(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaIndustrial(lblCodDocenteAsesor.Text, chkAreaEnsenianzaIndustrial);

                        EliminarAreaDeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);

                        EliminarAreaDeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);

                        EliminarAreaDeEnsenianzaInformatica(lblCodDocenteAsesor.Text);
                        AgregarAreadeEnsenianzaInformatica(lblCodDocenteAsesor.Text);

                        EliminarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);
                        AgregarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);

                        mostrarmensaje("exito","Respuestas guardadas exitosamente.");
                    }
                    else
                    {
                        if (dropAsesor.SelectedIndex == 0)
                        {
                            mostrarmensaje("error", "Por favor seleccione el asesor. ");
                        }
                        else
                        {


                            DataRow coddocenteasesor = lb.agregarDocenteAsesor(info["cod"].ToString(), dropAsesor.SelectedValue);

                            if (coddocenteasesor != null)
                            {
                                lblCodDocenteAsesor.Text = coddocenteasesor.ToString();

                                EliminarAreaDeEnsenianzaAcademico(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaAcademico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaAcademico);

                                EliminarAreaDeEnsenianzaTecnico(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaTecnico(lblCodDocenteAsesor.Text, chkAreaEnsenianzaTecnico);

                                EliminarAreaDeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaComercialServicio(lblCodDocenteAsesor.Text, chkAreaEnsenianzaComercialServ);

                                EliminarAreaDeEnsenianzaIndustrial(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaIndustrial(lblCodDocenteAsesor.Text, chkAreaEnsenianzaIndustrial);

                                EliminarAreaDeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaPedagogica(lblCodDocenteAsesor.Text);

                                EliminarAreaDeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaPromocionSocial(lblCodDocenteAsesor.Text);

                                EliminarAreaDeEnsenianzaInformatica(lblCodDocenteAsesor.Text);
                                AgregarAreadeEnsenianzaInformatica(lblCodDocenteAsesor.Text);

                                EliminarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);
                                AgregarAreaDeEnsenianzaOtra(lblCodDocenteAsesor.Text);

                                mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
                            }
                        }
                       
                    }


                }



                ////ActualizarDatoInstitucionalDocente(lblCodRegInstitucion.Text, dropDocente.SelectedValue);

               

                

               
                //cargarPreguntasInstrumento06();

                //btnRegresarAutopercepcion.Visible = false;
                btnGuardarPerfilDocente.Visible = false;
                //PanelAutopercepcionDocentes.Visible = false;
                //PanelPerfilDocente.Visible = false;

                //PanelEstudiantes.Visible = true;
                //btnTerminar.Visible = true;
                //btnRegresarPerfilDocente.Visible = true;

                //Paneltime.Visible = false;
                                     
                                        //}
                                 
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "ERROR: Debe digitar minimo 1 año en el ítem # 5: formación específica investigación.");
                    //}




             
    }
    protected void btnTercerGuardar05_Click(object sender, EventArgs e)
    {
       
                    if (validarRBContribuyoPracticaPedago())
                    {
                        //Validar el texbox

                        if (validarRBProyectoInvestigacionIE())
                        {
                            //Validar el texbox
                            if (validarRBProyectoInvestigacionFueraIE())
                            {
                                //Validar el texbox
                                if (validarRBProyectoNiniosNinias())
                                {
                                    //Validar el texbox
                                    // gvValidarFormacionCienciaTecInno();
                                    //if (validarTextLleno3 > 0)
                                    //{
                               

                                            //Guardar los datos
                                            LineaBase lb = new LineaBase();
                                            DataRow info = lb.buscarDocentexSedexInstitucion(Session["identificacion"].ToString());

                                            if (info != null)
                                            {
                                                DataRow regins = lb.cargarDatosDocenteAsesor(info["cod"].ToString());

                                                if (regins != null)
                                                {
                                                    lblCodDocenteAsesor.Text = regins["codigo"].ToString();

                                                    EliminarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);
                                                    AgregarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);

                                                    EliminarContribuyoPracticaPedago(lblCodDocenteAsesor.Text);
                                                    AgregarContribuyoPracticaPedago(lblCodDocenteAsesor.Text, rbContribuyoPracticaPedago);

                                                    EliminarProyectoInvestigacionIE(lblCodDocenteAsesor.Text);
                                                    AgregarProyectoInvestigacionIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionIE, chkModalidadProyectoInvgestigacion);

                                                    EliminarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text);
                                                    AgregarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionFueraIE);

                                                    EliminarProyectoNiniosNinias(lblCodDocenteAsesor.Text);
                                                    AgregarProyectoNiniosNinias(lblCodDocenteAsesor.Text, rbProyectoNiniosNinias, chkProyectoNiniosNinias);

                                                    mostrarmensaje("exito","Respuestas guardadas exitosamente.");


                                                }
                                                else
                                                {
                                                    if (dropAsesor.SelectedIndex == 0)
                                                    {
                                                        mostrarmensaje("error", "Por favor seleccione el asesor. ");
                                                    }
                                                    else
                                                    {
                                                        DataRow coddocenteasesor = lb.agregarDocenteAsesor(info["cod"].ToString(), dropAsesor.SelectedValue);

                                                        if (coddocenteasesor != null)
                                                        {
                                                            lblCodDocenteAsesor.Text = coddocenteasesor.ToString();

                                                            EliminarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);
                                                            AgregarFormacionInvestigacionDocentes(lblCodDocenteAsesor.Text);

                                                            EliminarContribuyoPracticaPedago(lblCodDocenteAsesor.Text);
                                                            AgregarContribuyoPracticaPedago(lblCodDocenteAsesor.Text, rbContribuyoPracticaPedago);

                                                            EliminarProyectoInvestigacionIE(lblCodDocenteAsesor.Text);
                                                            AgregarProyectoInvestigacionIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionIE, chkModalidadProyectoInvgestigacion);

                                                            EliminarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text);
                                                            AgregarProyectoInvestigacionFueraIE(lblCodDocenteAsesor.Text, rbProyectoInvestigacionFueraIE);

                                                            EliminarProyectoNiniosNinias(lblCodDocenteAsesor.Text);
                                                            AgregarProyectoNiniosNinias(lblCodDocenteAsesor.Text, rbProyectoNiniosNinias, chkProyectoNiniosNinias);

                                                            mostrarmensaje("exito", "Respuestas guardadas exitosamente.");
                                                        }
                                                    }
                                                  
                                                }


                                            }



                                            ////ActualizarDatoInstitucionalDocente(lblCodRegInstitucion.Text, dropDocente.SelectedValue);

                                           

                                           

                                           


                                            //cargarPreguntasInstrumento06();

                                            //btnRegresarAutopercepcion.Visible = false;
                                            btnGuardarPerfilDocente.Visible = true;
                                            //PanelAutopercepcionDocentes.Visible = false;
                                            //PanelPerfilDocente.Visible = false;

                                            //PanelEstudiantes.Visible = true;
                                            //btnTerminar.Visible = true;
                                            //btnRegresarPerfilDocente.Visible = true;

                                            Paneltime.Visible = false;
                                    
                                }
                            }
                        }
                    }
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "ERROR: Debe digitar minimo 1 año en el ítem # 5: formación específica investigación.");
                    //}




              

    }
    /* Instrumento 05 */
    ////private void ActualizarDatoInstitucionalDocente(string codreginstitucion, string coddocente)
    ////{
    ////    LineaBase lb = new LineaBase();

    ////    if (lb.ActualizarDatosInstitucionalDocente(codreginstitucion,coddocente)) { }
    ////}
    private void EliminarClaseFuncionario(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerrada(id, "1", "0", "5")) { }
    }
    int contclasefuncionario = 0;
    private void AgregarClaseFuncionarioDocente(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerrada(id, "1", "0", combo.Items[i].Value, "5");
            }
            contclasefuncionario++;
        }
    }
    private void EliminarUltimoNivelFormacion(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "2", "0", "5")) { }
    }
    int contultimonivel = 0;
    private void AgregarUltimoNIvelFormacion(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        foreach (GridViewRow row in GridFormacionDocente.Rows)
        {
            TextBox text = (row.FindControl("txtAnioFormacion") as TextBox);
            //if (text.Text != "")
            //{
                lb.AgregarRespuestaCerrada(codreginstitucion,"2","0",text.Text,"5");
            //}
                contultimonivel++;
        }
    }
    private void EliminarNivelEducativoDocente(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerrada(id, "3", "0", "5")) { }
    }
    int contniveleducativo = 0;
    private void AgregarNnivelEducativoDocente(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerrada(id, "3", "0", combo.Items[i].Value, "5");
            }
            contniveleducativo++;
        }
    }
    private void EliminarAreaDeEnsenianzaAcademico(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerrada(id, "4", "1", "5")) { }
        if (user.eliminarRespuestaAbierta(id,"4.1","5")){ } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaAcademico(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerrada(id, "4", "1", combo.Items[i].Value, "5");
            }
        }
        if(txtAreaEnsenianzaAcademico.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.1", txtAreaEnsenianzaAcademico.Text, "5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaTecnico(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerrada(id, "4", "2", "5")) { }
        if (user.eliminarRespuestaAbierta(id, "4.2", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaTecnico(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerrada(id, "4", "2", combo.Items[i].Value, "5");
            }
        }
        if (txtAreaEnsenianzaTecnico.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.2", txtAreaEnsenianzaTecnico.Text, "5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaComercialServicio(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerrada(id, "4", "3", "5")) { }
        if (user.eliminarRespuestaAbierta(id, "4.3", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaComercialServicio(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerrada(id, "4", "3", combo.Items[i].Value, "5");
            }
        }
        if (txtAreaEnsenianzaComercialServ.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.3", txtAreaEnsenianzaComercialServ.Text, "5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaIndustrial(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerrada(id, "4", "4", "5")) { }
        if (user.eliminarRespuestaAbierta(id, "4.4", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaIndustrial(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerrada(id, "4", "4", combo.Items[i].Value, "5");
            }
        }
        if (txtAreaEnsenianzaComercialServ.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.4", txtAreaEnsenianzaComercialServ.Text,"5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaPedagogica(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaAbierta(id, "4.5", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaPedagogica(string id)
    {
        LineaBase user = new LineaBase();

        if (txtAreaEnsenianzaPedagogica.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.5", txtAreaEnsenianzaPedagogica.Text, "5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaPromocionSocial(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaAbierta(id, "4.6", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaPromocionSocial(string id)
    {
        LineaBase user = new LineaBase();

        if (txtAreaEnsenianzaPromocionSocial.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.6", txtAreaEnsenianzaPromocionSocial.Text,"5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaInformatica(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaAbierta(id, "4.7", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreadeEnsenianzaInformatica(string id)
    {
        LineaBase user = new LineaBase();

        if (txtAreaEnsenianzaInformatica.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.7", txtAreaEnsenianzaInformatica.Text,"5")) { }
        }
    }
    private void EliminarAreaDeEnsenianzaOtra(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaAbierta(id, "4.8", "5")) { } //Pregunta con subtexto
    }
    private void AgregarAreaDeEnsenianzaOtra(string id)
    {
        LineaBase user = new LineaBase();

        if (txtAreaEnsenianzaOtra.Text != "")
        {
            if (user.AgregarRespuestaAbierta(id, "4.8", txtAreaEnsenianzaOtra.Text,"5")) { }
        }
    }

    private void EliminarFormacionInvestigacionDocentes(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaPerfilDocentes(id, "5", "5")) { } //codreginstitucion, pregunta, instrumento
    }
    private void AgregarFormacionInvestigacionDocentes(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        foreach (GridViewRow row in GridFormacionInvestigacionDocente.Rows)
        {
            DropDownList tipo = (row.FindControl("dropFomacionInvesTipo") as DropDownList);
            TextBox nomformacion  = (row.FindControl("txtNomFormacionInvesTipo") as TextBox);
            TextBox duracion = (row.FindControl("txtDuracionFormacionInvesTipo") as TextBox);
            TextBox anio = (row.FindControl("txtAnioFormacionInvesTipo") as TextBox);
            DropDownList modalidad = (row.FindControl("dropFomacionInvesModalidad") as DropDownList);
            if (tipo.SelectedValue == "N/A" || modalidad.SelectedValue == "N/A")
            {
                lb.AgregarRespuestaPerfilDocente("5", codreginstitucion, tipo.SelectedValue, "N/A", "N/A", "N/A", "N/A","5");
            }
            else
            {
                lb.AgregarRespuestaPerfilDocente("5", codreginstitucion, tipo.SelectedValue, nomformacion.Text, duracion.Text, anio.Text, modalidad.SelectedValue, "5");
            }
        }
    }

    private void EliminarContribuyoPracticaPedago(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "5", "1", "5")) { }
        if (lb.eliminarRespuestaAbierta(codreginstitucion, "5.1", "5")) { }
    }
    private void AgregarContribuyoPracticaPedago(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        if (lb.AgregarRespuestaCerrada(codreginstitucion, "5", "1", rb.SelectedValue, "5")) { }

        if (txtContribuyoPracticaPedago.Text != "")
        {
            lb.AgregarRespuestaAbierta(codreginstitucion, "5.1", txtContribuyoPracticaPedago.Text, "5");
        }

    }
    private void EliminarProyectoInvestigacionIE(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion,"6","0","5")){ }
        if (lb.eliminarRespuestaAbierta(codreginstitucion,"6","5")) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "6", "1", "5")) { }
    }
    private void AgregarProyectoInvestigacionIE(string codreginstitucion, RadioButtonList rb, CheckBoxList combo)
    {
        LineaBase lb = new LineaBase();
        if (lb.AgregarRespuestaCerrada(codreginstitucion, "6", "0", rb.SelectedValue, "5")) { }

        if(txtProyectoInvestigacionIE.Text != "")
        {
            lb.AgregarRespuestaAbierta(codreginstitucion,"6",txtProyectoInvestigacionIE.Text,"5");
        }

        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerrada(codreginstitucion, "6", "1", combo.Items[i].Value, "5");
            }
        }

    }
    private void EliminarProyectoInvestigacionFueraIE(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "7", "0", "5")) { }
        if (lb.eliminarRespuestaAbierta(codreginstitucion, "7", "5")) { }
    }
    private void AgregarProyectoInvestigacionFueraIE(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        if (lb.AgregarRespuestaCerrada(codreginstitucion, "7", "0", rb.SelectedValue, "5")) { }

        if (txtProyectoInvestigacionFueraIE.Text != "")
        {
            lb.AgregarRespuestaAbierta(codreginstitucion, "7", txtProyectoInvestigacionFueraIE.Text, "5");
        }

    }

    private void EliminarProyectoNiniosNinias(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "8", "0", "5")) { }
        if (lb.eliminarRespuestaAbierta(codreginstitucion, "8", "5")) { }
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "8", "1", "5")) { }
    }
    private void AgregarProyectoNiniosNinias(string codreginstitucion, RadioButtonList rb, CheckBoxList combo)
    {
        LineaBase lb = new LineaBase();
        if (lb.AgregarRespuestaCerrada(codreginstitucion, "8", "0", rb.SelectedValue, "5")) { }

        if (txtProyectoNiniosNinias.Text != "")
        {
            lb.AgregarRespuestaAbierta(codreginstitucion, "8", txtProyectoNiniosNinias.Text, "5");
        }

        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerrada(codreginstitucion, "8", "1", combo.Items[i].Value, "5");
            }
        }

    }

    private void EliminarFormacionCienciaTecnoInno(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaPerfilDocentes(id, "9", "5")) { } //codreginstitucion, pregunta, instrumento
    }
    private void AgregarFormacionCienciaTecnoInno(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        foreach (GridViewRow row in GridFormacionCienciaTecnoInno.Rows)
        {
            DropDownList tipo = (row.FindControl("dropFomacionCienciaTecnoInno") as DropDownList);
            TextBox nomformacion = (row.FindControl("txtNomFormacionCienciaTecnoInno") as TextBox);
            TextBox duracion = (row.FindControl("txtDuracionFormacionCienciaTecnoInno") as TextBox);
            TextBox anio = (row.FindControl("txtAnioFormacionCienciaTecnoInno") as TextBox);
            DropDownList modalidad = (row.FindControl("dropFomacionCienciaTecnoInnoMod") as DropDownList);
            if (tipo.SelectedValue == "N/A" || modalidad.SelectedValue == "N/A")
            {
                lb.AgregarRespuestaPerfilDocente("9", codreginstitucion, tipo.SelectedValue, "N/A", "N/A", "N/A", "N/A", "5");
            }
            else
            {
                lb.AgregarRespuestaPerfilDocente("9", codreginstitucion, tipo.SelectedValue, nomformacion.Text, duracion.Text, anio.Text, modalidad.SelectedValue, "5");
            }
        }
    }

    private void EliminarFormacionPracticaPedagogica(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "9", "1", "5")) { }
        if (lb.eliminarRespuestaAbierta(codreginstitucion, "9.1", "5")) { }
    }
    private void AgregarFormacionPracticaPedagogica(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        if (lb.AgregarRespuestaCerrada(codreginstitucion, "9", "1", rb.SelectedValue, "5")) { }

        if (txtFormacionPracticaPedagogica.Text != "")
        {
            lb.AgregarRespuestaAbierta(codreginstitucion, "9.1", txtFormacionPracticaPedagogica.Text, "5");
        }

    }

    private void EliminarFormacionNTICs(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaPerfilDocentes(id, "10", "5")) { } //codreginstitucion, pregunta, instrumento
    }
    private void AgregarFormacionNTICs(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        foreach (GridViewRow row in GridFormacionNTICs.Rows)
        {
            DropDownList tipo = (row.FindControl("dropFormacionNTICs") as DropDownList);
            TextBox nomformacion = (row.FindControl("txtNomFormacionNTICs") as TextBox);
            TextBox duracion = (row.FindControl("txtDuracionFormacionNTICs") as TextBox);
            TextBox anio = (row.FindControl("txtAnioFormacionNTICs") as TextBox);
            DropDownList modalidad = (row.FindControl("dropFormacionNTICsMod") as DropDownList);
            if (tipo.SelectedValue == "N/A" || modalidad.SelectedValue == "N/A")
            {
                lb.AgregarRespuestaPerfilDocente("10", codreginstitucion, tipo.SelectedValue, "N/A", "N/A", "N/A", "N/A", "5");
            }
            else
            {
                lb.AgregarRespuestaPerfilDocente("10", codreginstitucion, tipo.SelectedValue, nomformacion.Text, duracion.Text, anio.Text, modalidad.SelectedValue, "5");
            }
        }
    }

    private void EliminarFormacionNTICs101(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        if (lb.eliminarRespuestaCerrada(codreginstitucion, "10", "1", "5")) { }
        if (lb.eliminarRespuestaAbierta(codreginstitucion, "10.1", "5")) { }
    }
    private void AgregarFormacionNTICs101(string codreginstitucion, RadioButtonList rb)
    {
        LineaBase lb = new LineaBase();
        if (lb.AgregarRespuestaCerrada(codreginstitucion, "10", "1", rb.SelectedValue, "5")) { }

        if (txtFormacionNTICs.Text != "")
        {
            lb.AgregarRespuestaAbierta(codreginstitucion, "10.1", txtFormacionNTICs.Text, "5");
        }

    }

    private bool validarChkClaseFuncionario(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }
    private bool validarChkNivelEducativo(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }
    private bool validarChkAreaEnsenianzaAcademico(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }
    private bool validarChkAreaEnsenianzaTecnicoAgropecuario(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }
    private bool validarChkAreaEnsenianzaComercialServ(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }
    private bool validarChkAreaEnsenianzaIndustrial(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }



    private int valText = 0;
    int validarTextLleno = 0;
    int validarTextVacio = 0;
    private void gvValidarUltimoNIvelFormacion()
    {
        foreach (GridViewRow row in GridFormacionDocente.Rows)
        {
            if (valText == 0)
            {
                TextBox text = (row.FindControl("txtAnioFormacion") as TextBox);
                if (text.Text != "")
                {
                    row.BackColor = Color.Empty;
                    validarTextLleno++;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    validarTextVacio++;
                }
            }
            else
            {
                TextBox text = (row.FindControl("txtAnioFormacion") as TextBox);
            }
        }
    }
    private int valText2 = 0;
    int validarTextLleno2 = 0;
    int validarTextVacio2 = 0;
    private void gvValidarFormacionInvestigacion()
    {
        foreach (GridViewRow row in GridFormacionInvestigacionDocente.Rows)
        {
            if (valText2 == 0)
            {
                DropDownList tipo = (row.FindControl("dropFomacionInvesTipo") as DropDownList);
                TextBox text = (row.FindControl("txtNomFormacionInvesTipo") as TextBox);
                TextBox text2 = (row.FindControl("txtDuracionFormacionInvesTipo") as TextBox);
                TextBox text3 = (row.FindControl("txtAnioFormacionInvesTipo") as TextBox);

                if (tipo.SelectedValue == "N/A")
                {
                   
                }
                else
                {
                   
                    if (text.Text != "" && text2.Text != "" && text3.Text != "")
                    {
                        row.BackColor = Color.Empty;
                        validarTextLleno2++;
                    }
                    else
                    {
                        row.BackColor = Color.LightPink;
                        validarTextVacio2++;
                    }
                }

               
            }
            else
            {
                TextBox text = (row.FindControl("txtNomFormacionInvesTipo") as TextBox);
                TextBox text2 = (row.FindControl("txtDuracionFormacionInvesTipo") as TextBox);
                TextBox text3 = (row.FindControl("txtAnioFormacionInvesTipo") as TextBox);
            }
        }
    }
    public bool validarRBContribuyoPracticaPedago()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbContribuyoPracticaPedago.Items.Count; i++)
        {
            if (rbContribuyoPracticaPedago.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 5.1.");
            return false;
        }
    }
    public bool validarRBProyectoInvestigacionIE()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbProyectoInvestigacionIE.Items.Count; i++)
        {
            if (rbProyectoInvestigacionIE.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 6.");
            return false;
        }
    }

    public bool validarRBProyectoInvestigacionFueraIE()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbProyectoInvestigacionFueraIE.Items.Count; i++)
        {
            if (rbProyectoInvestigacionFueraIE.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 7.");
            return false;
        }
    }

    public bool validarRBProyectoNiniosNinias()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbProyectoNiniosNinias.Items.Count; i++)
        {
            if (rbProyectoNiniosNinias.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 8.");
            return false;
        }
    }

    private int valText3 = 0;
    int validarTextLleno3 = 0;
    int validarTextVacio3 = 0;
    private void gvValidarFormacionCienciaTecInno()
    {
        foreach (GridViewRow row in GridFormacionCienciaTecnoInno.Rows)
        {
            if (valText3 == 0)
            {
                TextBox text = (row.FindControl("txtNomFormacionCienciaTecnoInno") as TextBox);
                TextBox text2 = (row.FindControl("txtDuracionFormacionCienciaTecnoInno") as TextBox);
                TextBox text3 = (row.FindControl("txtAnioFormacionCienciaTecnoInno") as TextBox);
                if (text.Text != "" && text2.Text != "" && text3.Text != "")
                {
                    row.BackColor = Color.Empty;
                    validarTextLleno3++;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    validarTextVacio3++;
                }
            }
            else
            {
                TextBox text = (row.FindControl("txtNomFormacionCienciaTecnoInno") as TextBox);
                TextBox text2 = (row.FindControl("txtDuracionFormacionCienciaTecnoInno") as TextBox);
                TextBox text3 = (row.FindControl("txtAnioFormacionCienciaTecnoInno") as TextBox);
            }
        }
    }
    public bool validarRBFormacionPracticaPedagogica()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbFormacionPracticaPedagogica.Items.Count; i++)
        {
            if (rbFormacionPracticaPedagogica.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 9.1.");
            return false;
        }
    }
    private int valText4 = 0;
    int validarTextLleno4 = 0;
    int validarTextVacio4 = 0;
    private void gvValidarFormacionNTICs()
    {
        foreach (GridViewRow row in GridFormacionNTICs.Rows)
        {
            if (valText4 == 0)
            {
                TextBox text = (row.FindControl("txtNomFormacionNTICs") as TextBox);
                TextBox text2 = (row.FindControl("txtDuracionFormacionNTICs") as TextBox);
                TextBox text3 = (row.FindControl("txtAnioFormacionNTICs") as TextBox);
                if (text.Text != "" && text2.Text != "" && text3.Text != "")
                {
                    row.BackColor = Color.Empty;
                    validarTextLleno4++;
                }
                else
                {
                    row.BackColor = Color.LightPink;
                    validarTextVacio4++;
                }
            }
            else
            {
                TextBox text = (row.FindControl("txtNomFormacionNTICs") as TextBox);
                TextBox text2 = (row.FindControl("txtDuracionFormacionNTICs") as TextBox);
                TextBox text3 = (row.FindControl("txtAnioFormacionNTICs") as TextBox);
            }
        }
    }
    public bool validarRBFormacionNTICs()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbFormacionNTICs.Items.Count; i++)
        {
            if (rbFormacionNTICs.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 10.1.");
            return false;
        }
    }

    protected void btnBuscarDocente_Click(object sender, EventArgs e)
    {


        //if (txtBusqNomDocente.Text != "")
        //{
        //    Institucion ins = new Institucion();
        //    DataTable datos = ins.cargarEstudiantexDocente(txtBusqNomDocente.Text);
        //    GridEstudiantexDocente.DataSource = datos;
        //    GridEstudiantexDocente.DataBind();
        //}
        //else
        //{
        //    mostrarmensaje("error", "Digite la cédula del docente.");
        //}

    }
    private void cargarEstudiantesxdocente(string cod)
    {
        Institucion ins = new Institucion();
        DataTable datos = ins.cargarEstudiantexDocente(cod);
        GridEstudiantexDocente.DataSource = datos;
        GridEstudiantexDocente.DataBind();

        //if(datos != null && datos.Rows.Count > 0)
        //{ }
        //else { btnGuardarPrimero06GI.Visible = false; txtNomGrupoInvestigacion.Enabled = false; }
    }
    private void cargarEstudiantesxdocenteRT(string cod)
    {
        Institucion ins = new Institucion();
        DataTable datos = ins.cargarEstudiantexDocenteRT(cod);
        GridEstudiantexDocenteRT.DataSource = datos;
        GridEstudiantexDocenteRT.DataBind();

        //if (datos != null && datos.Rows.Count > 0)
        //{ }
        //else { btnGuardarPrimero06RT.Visible = false; txtNomRedTematica.Enabled = false; }
    }
    protected void rbValidarPregunta1Intrumento06_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbValidarPregunta1Intrumento06.SelectedIndex == 0)
        {
            PanelPregunta2Instrumento06.Visible = true;
        }
        else
        {
            PanelPregunta2Instrumento06.Visible = false;
            txtDiscapacidadHom.Text = "";
            txtDiscapacidadMuj.Text = "";
            txtCapacidadExcepHom.Text = "";
            txtCapacidadExcepMuj.Text = "";
            txtTotalHom.Text = "";
            txtTotalMuj.Text = "";
            txtTotalDiscapacidad.Text = "";
            txtTotalCapacidadExcep.Text = "";
        }
    }
    protected void rbValidarPregunta1Intrumento06RT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbValidarPregunta1Intrumento06RT.SelectedIndex == 0)
        {
            PanelPregunta2Instrumento06RT.Visible = true;
        }
        else
        {
            PanelPregunta2Instrumento06RT.Visible = false;
            txtDiscapacidadHomRT.Text = "";
            txtDiscapacidadMujRT.Text = "";
            txtCapacidadExcepHomRT.Text = "";
            txtCapacidadExcepMujRT.Text = "";
            txtTotalHomRT.Text = "";
            txtTotalMujRT.Text = "";
            txtTotalDiscapacidadRT.Text = "";
            txtTotalCapacidadExcepRT.Text = "";
        }
    }

    protected void rbGrupoInvestigacionEtnicoInstru06_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbGrupoInvestigacionEtnicoInstru06.SelectedIndex == 0)
        {
            PanelGrupoEtnicos.Visible = true;
        }
        else
        {
            PanelGrupoEtnicos.Visible = false;

        }
    }
    protected void rbGrupoInvestigacionEtnicoInstru06RT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbGrupoInvestigacionEtnicoInstru06RT.SelectedIndex == 0)
        {
            PanelGrupoEtnicosRT.Visible = true;
        }
        else
        {
            PanelGrupoEtnicosRT.Visible = false;

        }
    }
    protected void rbVictimaConflicto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbVictimaConflicto.SelectedIndex == 0)
        {
            PanelVictimaConflicto.Visible = true;
        }
        else
        {
            PanelVictimaConflicto.Visible = false;

        }
    }
    protected void rbVictimaConflictoRT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbVictimaConflictoRT.SelectedIndex == 0)
        {
            PanelVictimaConflictoRT.Visible = true;
        }
        else
        {
            PanelVictimaConflictoRT.Visible = false;

        }
    }
    protected void btnValidarSumInvDiscapacidad_Click(object sender, EventArgs e)
    {
        int discapacidad = Convert.ToInt32(txtDiscapacidadHom.Text) + Convert.ToInt32(txtDiscapacidadMuj.Text);
        int capacidadExp = Convert.ToInt32(txtCapacidadExcepHom.Text) + Convert.ToInt32(txtCapacidadExcepMuj.Text);

        int discapacidadHom = Convert.ToInt32(txtDiscapacidadHom.Text) + Convert.ToInt32(txtCapacidadExcepHom.Text);
        int capacidadExpMuj = Convert.ToInt32(txtDiscapacidadMuj.Text) + Convert.ToInt32(txtCapacidadExcepMuj.Text);

        txtTotalDiscapacidad.Text = Convert.ToString(discapacidad);
        txtTotalCapacidadExcep.Text = Convert.ToString(capacidadExp);

        txtTotalHom.Text = Convert.ToString(discapacidadHom);
        txtTotalMuj.Text = Convert.ToString(capacidadExpMuj);
    }

    protected void btnRegresarPerfil_Click(object sender, EventArgs e)
    {
        PanelEstudiantes.Visible = false;


        btnTerminar.Visible = false;

    }

    protected void btnRegresarPerfilDocente_Onclick(object sender, EventArgs e)
    {
        //btnRegresarPerfilDocente.Visible = false;
        btnTerminar.Visible = false;
        PanelEstudiantes.Visible = false;

        //PanelPerfilDocente.Visible = true;
        //btnGuardarPerfilDocente.Visible = true;
        //btnRegresarAutopercepcion.Visible = true;
    }


    protected void btnTerminar_Onclick(object sender, EventArgs e)
    {
        if (lb.eliminarRespuestaCerrada(lblCodDocenteAsesor.Text, "1", "1", "6")) { }
        if (lb.AgregarRespuestaCerrada(lblCodDocenteAsesor.Text, "1", "1", rbValidarPregunta1Intrumento06.SelectedValue, "6")) { }

        if (lb.eliminarRespuestasPreguntasInstrumento06(lblCodDocenteAsesor.Text,"6.1")) { }//Elimina todas las respuestas de lbase_respuestaestudiantes

        if (rbValidarPregunta1Intrumento06.SelectedValue == "Si (continúe)")
        {
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "2", "6.1", "Con discapacidad", "0", txtDiscapacidadHom.Text, txtDiscapacidadMuj.Text);
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "2", "6.1", "Con capacidades excepcionales", "0", txtCapacidadExcepHom.Text, txtCapacidadExcepMuj.Text);
        }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Auditiva", "Integrados", txtAuditivaHomInte.Text, txtAuditivaMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Auditiva", "No Integrados", txtAuditivaHomNoInte.Text, txtAuditivaMujNoInte.Text)) { }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Visual", "Integrados", txtVisualHomInte.Text, txtVisualMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Visual", "No Integrados", txtVisualHomNoInte.Text, txtVisualMujNoInte.Text)) { }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Motora", "Integrados", txtMotoraHomInte.Text, txtMotoraMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Motora", "No Integrados", txtMotoraHomNoInte.Text, txtMotoraMujNoInte.Text)) { }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Cognitiva", "Integrados", txtCognitivaHomInte.Text, txtCognitivaMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Cognitiva", "No Integrados", txtCognitivaHomNoInte.Text, txtCognitivaMujNoInte.Text)) { }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Autismo", "Integrados", txtAutismoHomInte.Text, txtAutismoMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Autismo", "No Integrados", txtAutismoHomNoInte.Text, txtAutismoMujNoInte.Text)) { }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Múltiple", "Integrados", txtMultipleHomInte.Text, txtMultipleMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Múltiple", "No Integrados", txtMultipleHomNoInte.Text, txtMultipleMujNoInte.Text)) { }

        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Otra", "Integrados", txtOtraHomInte.Text, txtOtraMujInte.Text)) { }
        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.1", "Otra", "No Integrados", txtOtraHomNoInte.Text, txtOtraMujNoInte.Text)) { }

        if (lb.eliminarRespuestaCerrada(lblCodDocenteAsesor.Text, "4", "1", "6")) { }
        if (lb.AgregarRespuestaCerrada(lblCodDocenteAsesor.Text, "4", "1", rbGrupoInvestigacionEtnicoInstru06.SelectedValue, "6")) { }

        if (rbGrupoInvestigacionEtnicoInstru06.SelectedValue == "Si (continúe)")
        {
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.1", "Indígenas", "0", txtIndigenaHom.Text, txtIndigenaMuj.Text);
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.1", "Rom (gitanos)", "0", txtRomHom.Text, txtRomMuj.Text);

            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.1", "Afrocolombianos, afrodecendientes, negro o mulato.", "0", txtAfroHom.Text, txtAfroMuj.Text);
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.1", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "0", txtRaizaHom.Text, txtRaizaMuj.Text);

            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.1", "Palenquero de San Basilio", "0", txtPalenqueroHom.Text, txtPalenqueroMuj.Text);
        }

        if (lb.eliminarRespuestaCerrada(lblCodDocenteAsesor.Text, "6", "1", "6")) { }
        if (lb.AgregarRespuestaCerrada(lblCodDocenteAsesor.Text, "6", "1", rbVictimaConflicto.SelectedValue, "6")) { }

        if (rbVictimaConflicto.SelectedValue == "Si (continúe)")
        {
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "7", "6.1", "En situación de desplazamiento", "0", txtDesplazamientoHom.Text, txtDesplazamientoMuj.Text);
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "7", "6.1", "Desvinculados de organizaciones armadas al margen de la Ley", "0", txtAlMargenHom.Text, txtAlMargenMuj.Text);
            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "7", "6.1", "Hijos de adultos desmovilizados", "0", txtDesmovilizadosHom.Text, txtDesmovilizadosMuj.Text);
        }
        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        //PanelTerminado.Visible = true;
        btnTerminar.Visible = true;
        //btnRegresarPerfilDocente.Visible = false;
        PanelEstudiantes.Visible = true;

        Paneltime.Visible = false;
    }
    protected void btnTerminarRT_Onclick(object sender, EventArgs e)
    {
       

                        if (lb.eliminarRespuestaCerrada(lblCodDocenteAsesor.Text, "1", "2", "6")) { }
                        if (lb.AgregarRespuestaCerrada(lblCodDocenteAsesor.Text, "1", "2", rbValidarPregunta1Intrumento06RT.SelectedValue, "6")) { }

                        if (lb.eliminarRespuestasPreguntasInstrumento06(lblCodDocenteAsesor.Text, "6.2")) { }//Elimina todas las respuestas de lbase_respuestaestudiantes

                        if (rbValidarPregunta1Intrumento06RT.SelectedValue == "Si (continúe)")
                        {
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "2", "6.2", "Con discapacidad", "0", txtDiscapacidadHomRT.Text, txtDiscapacidadMujRT.Text);
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "2", "6.2", "Con capacidades excepcionales", "0", txtCapacidadExcepHomRT.Text, txtCapacidadExcepMujRT.Text);
                        }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Auditiva", "Integrados", txtAuditivaHomInteRT.Text, txtAuditivaMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Auditiva", "No Integrados", txtAuditivaHomNoInteRT.Text, txtAuditivaMujNoInteRT.Text)) { }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Visual", "Integrados", txtVisualHomInteRT.Text, txtVisualMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Visual", "No Integrados", txtVisualHomNoInteRT.Text, txtVisualMujNoInteRT.Text)) { }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Motora", "Integrados", txtMotoraHomInteRT.Text, txtMotoraMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Motora", "No Integrados", txtMotoraHomNoInteRT.Text, txtMotoraMujNoInteRT.Text)) { }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Cognitiva", "Integrados", txtCognitivaHomInteRT.Text, txtCognitivaMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Cognitiva", "No Integrados", txtCognitivaHomNoInteRT.Text, txtCognitivaMujNoInteRT.Text)) { }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Autismo", "Integrados", txtAutismoHomInteRT.Text, txtAutismoMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Autismo", "No Integrados", txtAutismoHomNoInteRT.Text, txtAutismoMujNoInteRT.Text)) { }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Múltiple", "Integrados", txtMultipleHomInteRT.Text, txtMultipleMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Múltiple", "No Integrados", txtMultipleHomNoInteRT.Text, txtMultipleMujNoInteRT.Text)) { }

                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Otra", "Integrados", txtOtraHomInteRT.Text, txtOtraMujInteRT.Text)) { }
                        if (lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "3", "6.2", "Otra", "No Integrados", txtOtraHomNoInteRT.Text, txtOtraMujNoInteRT.Text)) { }

                        if (lb.eliminarRespuestaCerrada(lblCodDocenteAsesor.Text, "4", "2", "6")) { }
                        if (lb.AgregarRespuestaCerrada(lblCodDocenteAsesor.Text, "4", "2", rbGrupoInvestigacionEtnicoInstru06RT.SelectedValue, "6")) { }

                        if (rbGrupoInvestigacionEtnicoInstru06RT.SelectedValue == "Si (continúe)")
                        {
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.2", "Indígenas", "0", txtIndigenaHomRT.Text, txtIndigenaMujRT.Text);
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.2", "Rom (gitanos)", "0", txtRomHomRT.Text, txtRomMujRT.Text);

                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.2", "Afrocolombianos, afrodecendientes, negro o mulato.", "0", txtAfroHomRT.Text, txtAfroMujRT.Text);
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.2", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "0", txtRaizaHomRT.Text, txtRaizaMujRT.Text);

                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "5", "6.2", "Palenquero de San Basilio", "0", txtPalenqueroHomRT.Text, txtPalenqueroMujRT.Text);
                        }

                        if (lb.eliminarRespuestaCerrada(lblCodDocenteAsesor.Text, "6", "2", "6")) { }
                        if (lb.AgregarRespuestaCerrada(lblCodDocenteAsesor.Text, "6", "2", rbVictimaConflictoRT.SelectedValue, "6")) { }

                        if (rbVictimaConflictoRT.SelectedValue == "Si (continúe)")
                        {
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "7", "6.2", "En situación de desplazamiento", "0", txtDesplazamientoHomRT.Text, txtDesplazamientoMujRT.Text);
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "7", "6.2", "Desvinculados de organizaciones armadas al margen de la Ley", "0", txtAlMargenHomRT.Text, txtAlMargenMujRT.Text);
                            lb.AgregarRespuestaPreguntasIntrumento06(lblCodDocenteAsesor.Text, "7", "6.2", "Hijos de adultos desmovilizados", "0", txtDesmovilizadosHomRT.Text, txtDesmovilizadosMujRT.Text);
                        }
                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                        //PanelTerminado.Visible = true;
                        btnTerminarRT.Visible = true;
                        //btnRegresarPerfilDocente.Visible = false;
                        PanelEstudiantesRT.Visible = true;

                 
    }

    protected void GridEstudiantesxProceso_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string nombre = HttpUtility.HtmlDecode(e.Row.Cells[1].Text);
            foreach (ImageButton button in e.Row.Cells[5].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el estudiante: " + nombre + " de este Grupo de Investigación?')){ return false; };";
                }
            }
        }
    }
    protected void GridEstudiantesxProcesoRT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string nombre = HttpUtility.HtmlDecode(e.Row.Cells[1].Text);
            foreach (ImageButton button in e.Row.Cells[5].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el estudiante: " + nombre + " de esta Red Temática?')){ return false; };";
                }
            }
        }
    }
    protected void GridEstudiantesxProceso_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridEstudiantexDocente.SelectedRow;
        string id = Convert.ToString(GridEstudiantexDocente.Rows[e.RowIndex].Cells[0].Text);

        LineaBase pro = new LineaBase();
        if (pro.eliminarEstudianteXDocente(id))
        {
            mostrarmensaje("exito", "Eliminado correctamente");
            cargarEstudiantesxdocente(Session["identificacion"].ToString());
            PanelEstudiantesRT.Visible = true;
            PanelEstudiantes.Visible = false;
        }
        else
        {
            mostrarmensaje("error", "No puede eliminar este docente");
        }
    }
    protected void GridEstudiantesxProcesoRT_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridEstudiantexDocenteRT.SelectedRow;
        string id = Convert.ToString(GridEstudiantexDocenteRT.Rows[e.RowIndex].Cells[0].Text);

        LineaBase pro = new LineaBase();
        if (pro.eliminarEstudianteXDocente(id))
        {
            mostrarmensaje("exito", "Eliminado correctamente");
            cargarEstudiantesxdocenteRT(Session["identificacion"].ToString());
        }
        else
        {
            mostrarmensaje("error", "No puede eliminar este docente");
        }
    }
    private void cargarPreguntasInstrumento06(string coddocenteasesor, string codgradodocente, string codsede)
    {
        cargarNomProyectoInvestigacion(codsede, codgradodocente);
        cargarEstudiantesxdocente(codgradodocente);

        cargarPreguntaNo1yNo2(coddocenteasesor);
        cargarPreguntaNo3(coddocenteasesor);
        cargarPreguntaNo5(coddocenteasesor);
        cargarPreguntaNo7(coddocenteasesor);
    }
    private void cargarPreguntasInstrumento06RT(string coddocenteasesor, string codgradodocente, string codsede)
    {
        cargarNomProyectoInvestigacionRT(codsede, codgradodocente);
        cargarEstudiantesxdocenteRT(codgradodocente);

        cargarPreguntaNo1yNo2RT(coddocenteasesor);
        cargarPreguntaNo3RT(coddocenteasesor);
        cargarPreguntaNo5RT(coddocenteasesor);
        cargarPreguntaNo7RT(coddocenteasesor);
    }
   
    private void cargarNomProyectoInvestigacion(string codsede, string codgradodocente)
    {
        LineaBase lb = new LineaBase();

        DataRow dat = lb.buscarNomProyectoInvestigacionxDocentexSede(codsede, codgradodocente);

        if(dat != null)
        {
            dropNombreGrupoInvestigacion.SelectedValue = dat["codproyecto"].ToString();
            txtNomGrupoInvestigacion.Enabled = false;
        }
    }
    private void cargarNomProyectoInvestigacionRT(string codsede, string codgradodocente)
    {
        LineaBase lb = new LineaBase();

        DataRow dat = lb.buscarNomProyectoInvestigacionxDocentexSedeRT(codsede, codgradodocente);

        if (dat != null)
        {
            dropNombreRedTematica.SelectedValue = dat["codredtematicasede"].ToString();
            txtNomRedTematica.Enabled = false;
        }
    }
    private void cargarPreguntaNo1yNo2(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable dat = lb.cargarRespuestasCerradasxInstrumento02(codreginstitucion,"1","1","6");

        if(dat != null && dat.Rows.Count > 0)
        {
            if (dat.Rows[0]["respuesta"].ToString() == "Si (continúe)")
            {
                rbValidarPregunta1Intrumento06.SelectedValue = dat.Rows[0]["respuesta"].ToString();
                PanelPregunta2Instrumento06.Visible = true;

                DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "2", "6.1");//codreginstitucion, pregunta, instrumento
                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["categoria"].ToString() == "Con discapacidad")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtDiscapacidadHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtDiscapacidadHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtDiscapacidadMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtDiscapacidadMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Con capacidades excepcionales")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtCapacidadExcepHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtCapacidadExcepMuj.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtCapacidadExcepMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtCapacidadExcepMuj.Text = "0";
                        }
                    }
                }
            }
            else
            {
                rbValidarPregunta1Intrumento06.SelectedValue = dat.Rows[0]["respuesta"].ToString();
            }
        }
    }
    private void cargarPreguntaNo1yNo2RT(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable dat = lb.cargarRespuestasCerradasxInstrumento02(codreginstitucion, "1", "2", "6");

        if (dat != null && dat.Rows.Count > 0)
        {
            if (dat.Rows[0]["respuesta"].ToString() == "Si (continúe)")
            {
                rbValidarPregunta1Intrumento06RT.SelectedValue = dat.Rows[0]["respuesta"].ToString();
                PanelPregunta2Instrumento06RT.Visible = true;

                DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "2", "6.2");//codreginstitucion, pregunta, instrumento
                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["categoria"].ToString() == "Con discapacidad")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtDiscapacidadHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtDiscapacidadHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtDiscapacidadMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtDiscapacidadMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Con capacidades excepcionales")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtCapacidadExcepHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtCapacidadExcepMujRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtCapacidadExcepMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtCapacidadExcepMujRT.Text = "0";
                        }
                    }
                }
            }
            else
            {
                rbValidarPregunta1Intrumento06RT.SelectedValue = dat.Rows[0]["respuesta"].ToString();
            }
        }
    }
    private void cargarPreguntaNo3(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion,"3","6.1");//codreginstitucion, pregunta, instrumento

        if(datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++ )
            {
                if (datos.Rows[i]["categoria"].ToString() == "Auditiva" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAuditivaHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAuditivaHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAuditivaMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAuditivaMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Auditiva" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAuditivaHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAuditivaHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAuditivaMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAuditivaMujNoInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Visual" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtVisualHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtVisualHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtVisualMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtVisualMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Visual" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtVisualHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtVisualHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtVisualMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtVisualMujNoInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Motora" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMotoraHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMotoraHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMotoraMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMotoraMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Motora" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMotoraHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMotoraHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMotoraMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMotoraMujNoInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Cognitiva" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtCognitivaHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtCognitivaHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtCognitivaMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtCognitivaMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Cognitiva" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtCognitivaHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtCognitivaHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtCognitivaMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtCognitivaMujNoInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Autismo" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAutismoHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAutismoHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAutismoMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAutismoMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Autismo" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAutismoHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAutismoHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAutismoMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAutismoMujNoInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Múltiple" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMultipleHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMultipleHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMultipleMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMultipleMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Múltiple" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMultipleHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMultipleHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMultipleMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMultipleMujNoInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Otra" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtOtraHomInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtOtraHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtOtraMujInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtOtraMujInte.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Otra" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtOtraHomNoInte.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtOtraHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtOtraMujNoInte.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtOtraMujNoInte.Text = "0";
                }


            }
        }
    }

    private void cargarPreguntaNo3RT(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "3", "6.2");//codreginstitucion, pregunta, instrumento

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["categoria"].ToString() == "Auditiva" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAuditivaHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAuditivaHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAuditivaMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAuditivaMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Auditiva" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAuditivaHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAuditivaHomNoInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAuditivaMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAuditivaMujNoInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Visual" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtVisualHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtVisualHomInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtVisualMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtVisualMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Visual" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtVisualHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtVisualHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtVisualMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtVisualMujNoInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Motora" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMotoraHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMotoraHomInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMotoraMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMotoraMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Motora" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMotoraHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMotoraHomNoInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMotoraMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMotoraMujNoInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Cognitiva" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtCognitivaHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtCognitivaHomInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtCognitivaMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtCognitivaMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Cognitiva" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtCognitivaHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtCognitivaHomNoInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtCognitivaMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtCognitivaMujNoInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Autismo" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAutismoHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAutismoHomInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAutismoMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAutismoMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Autismo" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtAutismoHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtAutismoHomNoInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtAutismoMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtAutismoMujNoInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Múltiple" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMultipleHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMultipleHomInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMultipleMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMultipleMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Múltiple" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtMultipleHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtMultipleHomNoInte.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtMultipleMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtMultipleMujNoInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Otra" && datos.Rows[i]["subcategoria"].ToString() == "Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtOtraHomInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtOtraHomInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtOtraMujInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtOtraMujInteRT.Text = "0";
                }

                if (datos.Rows[i]["categoria"].ToString() == "Otra" && datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
                {
                    if (datos.Rows[i]["thombre"].ToString() != "")
                        txtOtraHomNoInteRT.Text = datos.Rows[i]["thombre"].ToString();
                    else
                        txtOtraHomNoInteRT.Text = "0";

                    if (datos.Rows[i]["tmujer"].ToString() != "")
                        txtOtraMujNoInteRT.Text = datos.Rows[i]["tmujer"].ToString();
                    else
                        txtOtraMujNoInteRT.Text = "0";
                }


            }
        }
    }

    private void cargarPreguntaNo5(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable dat = lb.cargarRespuestasCerradasxInstrumento02(codreginstitucion, "4", "1", "6");

        if (dat != null && dat.Rows.Count > 0)
        {
            if (dat.Rows[0]["respuesta"].ToString() == "Si (continúe)")
            {
                rbGrupoInvestigacionEtnicoInstru06.SelectedValue = dat.Rows[0]["respuesta"].ToString();
                PanelGrupoEtnicos.Visible = true;

                DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "5", "6.1");//codreginstitucion, pregunta, instrumento
                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["categoria"].ToString() == "Indígenas")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtIndigenaHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtIndigenaHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtIndigenaMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtIndigenaMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Rom (gitanos)")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtRomHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtRomHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtRomMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtRomMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Afrocolombianos, afrodecendientes, negro o mulato.")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtAfroHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtAfroHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtAfroMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtAfroMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtRaizaHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtRaizaHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtRaizaMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtRaizaMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Palenquero de San Basilio")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtPalenqueroHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtPalenqueroHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtPalenqueroMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtPalenqueroMuj.Text = "0";
                        }

                    }
                }
            }
            else
            {
                rbGrupoInvestigacionEtnicoInstru06.SelectedValue = dat.Rows[0]["respuesta"].ToString();
            }
        }
    }

    private void cargarPreguntaNo5RT(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable dat = lb.cargarRespuestasCerradasxInstrumento02(codreginstitucion, "4", "2", "6");

        if (dat != null && dat.Rows.Count > 0)
        {
            if (dat.Rows[0]["respuesta"].ToString() == "Si (continúe)")
            {
                rbGrupoInvestigacionEtnicoInstru06RT.SelectedValue = dat.Rows[0]["respuesta"].ToString();
                PanelGrupoEtnicosRT.Visible = true;

                DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "5", "6.2");//codreginstitucion, pregunta, instrumento
                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["categoria"].ToString() == "Indígenas")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtIndigenaHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtIndigenaHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtIndigenaMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtIndigenaMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Rom (gitanos)")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtRomHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtRomHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtRomMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtRomMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Afrocolombianos, afrodecendientes, negro o mulato.")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtAfroHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtAfroHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtAfroMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtAfroMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtRaizaHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtRaizaHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtRaizaMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtRaizaMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Palenquero de San Basilio")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtPalenqueroHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtPalenqueroHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtPalenqueroMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtPalenqueroMujRT.Text = "0";
                        }

                    }
                }
            }
            else
            {
                rbGrupoInvestigacionEtnicoInstru06RT.SelectedValue = dat.Rows[0]["respuesta"].ToString();
            }
        }
    }

    private void cargarPreguntaNo7(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable dat = lb.cargarRespuestasCerradasxInstrumento02(codreginstitucion, "6", "1", "6");

        if (dat != null && dat.Rows.Count > 0)
        {
            if (dat.Rows[0]["respuesta"].ToString() == "Si (continúe)")
            {
                rbVictimaConflicto.SelectedValue = dat.Rows[0]["respuesta"].ToString();
                PanelVictimaConflicto.Visible = true;

                DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "7", "6.1");//codreginstitucion, pregunta, instrumento
                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["categoria"].ToString() == "En situación de desplazamiento")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtDesplazamientoHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtDesplazamientoHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtDesplazamientoMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtDesplazamientoMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Desvinculados de organizaciones armadas al margen de la Ley")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtAlMargenHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtAlMargenHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtAlMargenMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtAlMargenMuj.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Hijos de adultos desmovilizados")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtDesmovilizadosHom.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtDesmovilizadosHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtDesmovilizadosMuj.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtDesmovilizadosMuj.Text = "0";
                        }
                    }
                }
            }
            else
            {
                rbVictimaConflicto.SelectedValue = dat.Rows[0]["respuesta"].ToString();
            }
        }
    }
    private void cargarPreguntaNo7RT(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable dat = lb.cargarRespuestasCerradasxInstrumento02(codreginstitucion, "6", "2", "6");

        if (dat != null && dat.Rows.Count > 0)
        {
            if (dat.Rows[0]["respuesta"].ToString() == "Si (continúe)")
            {
                rbVictimaConflictoRT.SelectedValue = dat.Rows[0]["respuesta"].ToString();
                PanelVictimaConflictoRT.Visible = true;

                DataTable datos = lb.cargarRespuestasCerradasInstrumento06(codreginstitucion, "7", "6.2");//codreginstitucion, pregunta, instrumento
                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["categoria"].ToString() == "En situación de desplazamiento")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtDesplazamientoHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtDesplazamientoHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtDesplazamientoMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtDesplazamientoMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Desvinculados de organizaciones armadas al margen de la Ley")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtAlMargenHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtAlMargenHomRT.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtAlMargenMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtAlMargenMujRT.Text = "0";
                        }

                        if (datos.Rows[i]["categoria"].ToString() == "Hijos de adultos desmovilizados")
                        {
                            if (datos.Rows[i]["thombre"].ToString() != "")
                                txtDesmovilizadosHomRT.Text = datos.Rows[i]["thombre"].ToString();
                            else
                                txtDesmovilizadosHom.Text = "0";

                            if (datos.Rows[i]["tmujer"].ToString() != "")
                                txtDesmovilizadosMujRT.Text = datos.Rows[i]["tmujer"].ToString();
                            else
                                txtDesmovilizadosMujRT.Text = "0";
                        }
                    }
                }
            }
            else
            {
                rbVictimaConflictoRT.SelectedValue = dat.Rows[0]["respuesta"].ToString();
            }
        }
    }

    protected void Reloj_Tick(object sender, EventArgs e)
    {
        LineaBase ex = new LineaBase();
        if (Convert.ToInt32(Session["tiempo"]) != 0)
        {
            decimal s = Convert.ToDecimal(Session["tiempo"]);
            lblReloj.Text = ex.contador(s);
        }
        else
        {
            //Cuando hacemos click en el evento de terminar, tambien entra a este else
            Session["validador"] = 0;
            Response.Redirect("lineabaseregistro.aspx");
            Session["value"] = "ok";

        }
    }

    protected void btnGrupoInvestigacion_Click(Object sender, EventArgs e)
    {
        PanelEstudiantes.Visible = true;
        PanelEstudiantesRT.Visible = false;
        btnTerminarRT.Visible = false;
        btnTerminar.Visible = true;
        dropNombreRedTematica.Visible = false;
        dropNombreGrupoInvestigacion.Visible = true;
        cargarPreguntasInstrumento06(lblCodDocenteAsesor.Text, lblCodGradoDocenteInstrumento6.Text, lblCodSedeInstrumento6.Text);
    }

    protected void btnRedTematica_Click(Object sender, EventArgs e)
    {
        PanelEstudiantesRT.Visible = true;
        PanelEstudiantes.Visible = false;
        btnTerminarRT.Visible = true;
        btnTerminar.Visible = false;
        dropNombreRedTematica.Visible = true;
        dropNombreGrupoInvestigacion.Visible = false;
        cargarPreguntasInstrumento06RT(lblCodDocenteAsesor.Text, lblCodGradoDocenteInstrumento6.Text, lblCodSedeInstrumento6.Text);
    }

    protected void btnGuardarPrimero06GI_Click(Object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();

        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        if(txtNomGrupoInvestigacion.Text != "" && dropNombreGrupoInvestigacion.SelectedIndex == 0)
        {
            DataRow dat = lb.agregarNomProyecto(txtNomGrupoInvestigacion.Text, horares, horares);

            if (dat != null)
            {
                DataRow dato = lb.agregarProyectoSede(dat["codigo"].ToString(), lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

                if (dato != null)
                {
                    //Validar los datos para el proyecto de eliminar y agregar nuevamente, solamente está agregar

                    foreach (GridViewRow row in GridEstudiantexDocente.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.eliminarEstudiantesxProyectoSede(dato["codigo"].ToString(), codestumatricula)) { }
                    }
                    

                    foreach (GridViewRow row in GridEstudiantexDocente.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.agregarProyectoMatricula(dato["codigo"].ToString(), codestumatricula)) { }
                    }

                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    //PanelTerminado.Visible = true;
                    btnTerminar.Visible = true;
                    //btnRegresarPerfilDocente.Visible = false;
                    PanelEstudiantes.Visible = true;

                    Paneltime.Visible = false;
                }
            }
            else
            {
                mostrarmensaje("error", "Error al ingresar Proyecto.");
            }
        }
        else if (txtNomGrupoInvestigacion.Text == "" && dropNombreGrupoInvestigacion.SelectedIndex > 0)
        {

            DataRow datoProyectoDocente = lb.buscarProyectoxDocente(dropNombreGrupoInvestigacion.SelectedValue, lblCodGradoDocenteInstrumento6.Text);

            if(datoProyectoDocente == null)
            {
                DataRow dato = lb.agregarProyectoSede(dropNombreGrupoInvestigacion.SelectedValue, lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

                if (dato != null)
                {
                    //Validar los datos para el proyecto de eliminar y agregar nuevamente, solamente está agregar

                    foreach (GridViewRow row in GridEstudiantexDocente.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.eliminarEstudiantesxProyectoSede(dato["codigo"].ToString(), codestumatricula)) { }
                    }


                    foreach (GridViewRow row in GridEstudiantexDocente.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.agregarProyectoMatricula(dato["codigo"].ToString(), codestumatricula)) { }
                    }

                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    //PanelTerminado.Visible = true;
                    btnTerminar.Visible = true;
                    //btnRegresarPerfilDocente.Visible = false;
                    PanelEstudiantes.Visible = true;

                    Paneltime.Visible = false;
                }
            }
            else
            {
                if (lb.editarDatoProyectoSede(dropNombreGrupoInvestigacion.SelectedValue, lblCodGradoDocenteInstrumento6.Text))
                {
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    //PanelTerminado.Visible = true;
                    btnTerminar.Visible = true;
                    //btnRegresarPerfilDocente.Visible = false;
                    PanelEstudiantes.Visible = true;

                    Paneltime.Visible = false;
                }
                else
                {
                    mostrarmensaje("error", "Error.");
                }
            }

            
        }
        else
        {
            mostrarmensaje("error","Si va a crear un nuevo Grupo, por favor escoja la opción Nuevo Grupo de Investigación.");
        }



        //if (txtNomGrupoInvestigacion.Text != "" && dropNombreGrupoInvestigacion.SelectedIndex == 0)
        //{
        //    DataRow datt = lb.buscarNomProyectoInvestigacionxDocentexSedeDelete(lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

        //    if (datt != null)
        //    {
        //        foreach (GridViewRow row in GridEstudiantexDocente.Rows)
        //        {
        //            string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
        //            if (lb.eliminarEstudiantesxProyectoSede(datt["codproyectosede"].ToString(), codestumatricula)) { }
        //        }

        //        if (lb.eliminarProyectoSede(datt["codproyecto"].ToString())) { }
        //        if (lb.eliminarProyecto(datt["codproyecto"].ToString())) { }

        //        DataRow dat = lb.agregarNomProyecto(txtNomGrupoInvestigacion.Text, horares, horares);

        //        if (dat != null)
        //        {
        //            DataRow dato = lb.agregarProyectoSede(dat["codigo"].ToString(), lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

        //            if (dato != null)
        //            {
        //                //Validar los datos para el proyecto de eliminar y agregar nuevamente, solamente está agregar
        //                foreach (GridViewRow row in GridEstudiantexDocente.Rows)
        //                {
        //                    string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
        //                    if (lb.agregarProyectoMatricula(dato["codigo"].ToString(), codestumatricula)) { }
        //                }
        //                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        //                //PanelTerminado.Visible = true;
        //                btnTerminar.Visible = true;
        //                //btnRegresarPerfilDocente.Visible = false;
        //                PanelEstudiantes.Visible = true;

        //                Paneltime.Visible = false;
        //            }
        //        }
        //        else
        //        {
        //            mostrarmensaje("error", "Error al ingresar Proyecto.");
        //        }

        //    }
        //    else
        //    {
        //        DataRow dat = lb.agregarNomProyecto(txtNomGrupoInvestigacion.Text, horares, horares);

        //        if (dat != null)
        //        {
        //            DataRow dato = lb.agregarProyectoSede(dat["codigo"].ToString(), lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

        //            if (dato != null)
        //            {
        //                //Validar los datos para el proyecto de eliminar y agregar nuevamente, solamente está agregar
        //                foreach (GridViewRow row in GridEstudiantexDocente.Rows)
        //                {
        //                    string codestumatricula = GridEstudiantexDocente.Rows[row.RowIndex].Cells[0].Text;
        //                    if (lb.agregarProyectoMatricula(dato["codigo"].ToString(), codestumatricula)) { }
        //                }

        //                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        //                //PanelTerminado.Visible = true;
        //                btnTerminar.Visible = true;
        //                //btnRegresarPerfilDocente.Visible = false;
        //                PanelEstudiantes.Visible = true;

        //                Paneltime.Visible = false;
        //            }
        //        }
        //        else
        //        {
        //            mostrarmensaje("error", "Error al ingresar Proyecto.");
        //        }
        //    }

            
        //}
        //else
        //{
        //    mostrarmensaje("error", "Digite el nombre del Grupo de Investigación.");
        //}
    }

    protected void btnGuardarPrimero06RT_Click(Object sender, EventArgs e)
    {

        LineaBase lb = new LineaBase();

        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        if (txtNomRedTematica.Text != "" && dropNombreRedTematica.SelectedIndex == 0)
        {
            DataRow dat = lb.agregarNomProyectoRT(txtNomRedTematica.Text, horares, horares);

            if (dat != null)
            {
                DataRow dato = lb.agregarProyectoSedeRT(dat["codigo"].ToString(), lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

                if (dato != null)
                {
                    //Validar los datos para red temática de eliminar y agregar nuevamente

                    foreach (GridViewRow row in GridEstudiantexDocenteRT.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocenteRT.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.eliminarEstudiantesxProyectoSedeRT(dato["codigo"].ToString(), codestumatricula)) { }
                    }


                    foreach (GridViewRow row in GridEstudiantexDocenteRT.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocenteRT.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.agregarProyectoMatriculaRT(dato["codigo"].ToString(), codestumatricula)) { }
                    }

                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    //PanelTerminado.Visible = true;
                    btnTerminar.Visible = true;
                    //btnRegresarPerfilDocente.Visible = false;
                    PanelEstudiantesRT.Visible = true;

                    Paneltime.Visible = false;
                }
            }
            else
            {
                mostrarmensaje("error", "Error al ingresar Proyecto.");
            }
        }
        else if (txtNomRedTematica.Text == "" && dropNombreRedTematica.SelectedIndex > 0)
        {

            DataRow datoProyectoDocente = lb.buscarProyectoxDocenteRT(dropNombreRedTematica.SelectedValue, lblCodGradoDocenteInstrumento6.Text);

            if (datoProyectoDocente == null)
            {
                DataRow dato = lb.agregarProyectoSedeRT(dropNombreRedTematica.SelectedValue, lblCodSedeInstrumento6.Text, lblCodGradoDocenteInstrumento6.Text);

                if (dato != null)
                {
                    //Validar los datos para el proyecto de eliminar y agregar nuevamente, solamente está agregar

                    foreach (GridViewRow row in GridEstudiantexDocenteRT.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocenteRT.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.eliminarEstudiantesxProyectoSedeRT(dato["codigo"].ToString(), codestumatricula)) { }
                    }


                    foreach (GridViewRow row in GridEstudiantexDocenteRT.Rows)
                    {
                        string codestumatricula = GridEstudiantexDocenteRT.Rows[row.RowIndex].Cells[0].Text;
                        if (lb.agregarProyectoMatriculaRT(dato["codigo"].ToString(), codestumatricula)) { }
                    }

                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    //PanelTerminado.Visible = true;
                    btnTerminar.Visible = true;
                    //btnRegresarPerfilDocente.Visible = false;
                    PanelEstudiantesRT.Visible = true;

                    Paneltime.Visible = false;
                }
            }
            else
            {
                if (lb.editarDatoProyectoSedeRT(dropNombreRedTematica.SelectedValue, lblCodGradoDocenteInstrumento6.Text))
                {
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    //PanelTerminado.Visible = true;
                    btnTerminar.Visible = true;
                    //btnRegresarPerfilDocente.Visible = false;
                    PanelEstudiantesRT.Visible = true;

                    Paneltime.Visible = false;
                }
                else
                {
                    mostrarmensaje("error", "Error.");
                }
            }


        }
        else
        {
            mostrarmensaje("error", "Si va a crear un nuevo Grupo, por favor escoja la opción Nueva Red Temática y/o Digite el nombre de la Red Temática .");
        }


        //LineaBase lb = new LineaBase();

        //DateTime localDateTime = DateTime.Now;
        //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        //string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        //if (txtNomRedTematica.Text != "")
        //{
        //    DataRow datt = lb.buscarNomProyectoInvestigacionxDocentexSedeDeleteRT(lblCodSedeInstrumento6RT.Text, lblCodGradoDocenteInstrumento6RT.Text);

        //    if (datt != null)
        //    {
        //        foreach (GridViewRow row in GridEstudiantexDocenteRT.Rows)
        //        {
        //            string codestumatricula = GridEstudiantexDocenteRT.Rows[row.RowIndex].Cells[0].Text;
        //            if (lb.eliminarEstudiantesxProyectoSedeRT(datt["codredtematicasede"].ToString(), codestumatricula)) { }
        //        }

        //        if (lb.eliminarProyectoSedeRT(datt["codredtematica"].ToString())) { }
        //        if (lb.eliminarProyectoRT(datt["codredtematica"].ToString())) { }

        //    }

        //    DataRow dat = lb.agregarNomProyectoRT(txtNomRedTematica.Text, horares, horares);

        //    if (dat != null)
        //    {
        //        DataRow dato = lb.agregarProyectoSedeRT(dat["codigo"].ToString(), lblCodSedeInstrumento6RT.Text, lblCodGradoDocenteInstrumento6RT.Text);

        //        if (dato != null)
        //        {
        //            //Validar los datos para el proyecto de eliminar y agregar nuevamente, solamente está agregar
        //            foreach (GridViewRow row in GridEstudiantexDocenteRT.Rows)
        //            {
        //                string codestumatricula = GridEstudiantexDocenteRT.Rows[row.RowIndex].Cells[0].Text;
        //                if (lb.agregarProyectoMatriculaRT(dato["codigo"].ToString(), codestumatricula)) { }
        //            }

        //            mostrarmensaje("exito","Respuestas agregadas exitosamente.");

        //            //PanelTerminado.Visible = true;
        //            btnTerminar.Visible = true;
        //            //btnRegresarPerfilDocente.Visible = false;
        //            PanelEstudiantes.Visible = false;

        //            Paneltime.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        mostrarmensaje("error", "Error al ingresar Proyecto.");
        //    }


        //}
        //else
        //{
        //    mostrarmensaje("error", "Digite el nombre del Grupo de Investigación.");
        //}
    }

}