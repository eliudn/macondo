using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Drawing;

public partial class intermediainstrucoor : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    string codrol = "";
    string validarIntentos = "true";
    Institucion inst = new Institucion();
    LineaBase lb = new LineaBase();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
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
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            lblCodRol.Text = Session["codrol"].ToString();
            lblCodDANE.Text = Session["dane"].ToString();

            if (Session["codrol"].ToString() == "7")
            {
                DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);
                if(datoie != null)
                {
                    cargarSedes(datoie["codigo"].ToString());
                }
               
            }
            else if (Session["codrol"].ToString() == "9")
            {
                PanelDisposicionTIC.Visible = true;
            }

            
        }
    }
    private void cargarSedes(string codcliente)
    {
        GridSedes.DataSource = inst.cargarSedesInstitucion(codcliente);
        GridSedes.DataBind();
      
    }
    protected void btnIniciarDisponibilidadTIC_Onclick(Object sender, EventArgs e)
    {


        if (lblCodRol.Text == "7")
        {

            //DateTime localDateTime = DateTime.Now;
            //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
            //string horares = utcDateTime.ToString("yyyy-MM-dd");
            //DataRow fecha = lb.buscarFechaInstrumento("2", horares);

            //if (fecha != null)
            //{

                //PanelDisposicionTIC.Visible = true;

                //PanelPerfilDocente.Visible = false;
                //btnGuardarPerfilDocente.Visible = false;

                //PanelEstudiantes.Visible = false;
                //btnTerminar.Visible = false;

                //PanelAutopercepcionDocentes.Visible = false;
                //btnGuardarAutopercepcion.Visible = false;

                //btnRegresarCaracterizacion.Visible = false;
                //btnRegresarAutopercepcion.Visible = false;
                //btnRegresarPerfilDocente.Visible = false;

               

            //}
            //else
            //{
            //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
            //}


        }
      

    }

    protected void imgInfoxSede_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string codinstitucion = HttpUtility.HtmlDecode(gvrow.Cells[11].Text);

        DataRow sede = lb.buscarSedexInsasesor(codsede);

        if(sede != null)
        {
            lblCodSedeinsAsesor.Text = sede["codigo"].ToString();
            PanelDisposicionTIC.Visible = true;
            cargarPregunta1Intrumento03();
            cargarHerramientasDisponeIE();
            cargarSoftwareEducativo();

            cargarInformacionRespuesta03(sede["codigo"].ToString());
        }
        else
        {
            mostrarmensaje("error","Por favor Diligencie el Instrumento C600B para esta sede.");
            PanelDisposicionTIC.Visible = false;
        }

        

        //Response.Redirect("lineabaseSede.aspx?cs=" + codsede + "&ca=" + lblCodAsesor.Text + "&ci=" + codinstitucion);

    }
    private void cargarPregunta1Intrumento03()//Pregunta 1 Intrumento 03
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[4] { new DataColumn("nombre"), new DataColumn("codpregunta"), new DataColumn("codsubpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("Funcionamiento de los equipos.", "1", "3", "3");
        dtPregunta.Rows.Add("Acceso a internet.", "1", "3", "3");
        dtPregunta.Rows.Add("Calidad de la conexión.", "1", "3", "3");
        dtPregunta.Rows.Add("Soporte técnico.", "1", "3", "3");
        dtPregunta.Rows.Add("Seguridad de los equipos.", "1", "3", "3");
        GridPregunta1Intrumento03.DataSource = dtPregunta;
        GridPregunta1Intrumento03.DataBind();
    }

    private void cargarHerramientasDisponeIE()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[3] { new DataColumn("nro"), new DataColumn("codpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("1", "1.4", "3");
        dtPregunta.Rows.Add("2", "1.4", "3");
        dtPregunta.Rows.Add("3", "1.4", "3");

        GridHerramientasDisponeIE.DataSource = dtPregunta;
        GridHerramientasDisponeIE.DataBind();
    }

    private void cargarSoftwareEducativo()
    {
        DataTable dtPregunta = new DataTable();
        dtPregunta.Columns.AddRange(new DataColumn[3] { new DataColumn("nro"), new DataColumn("codpregunta"), new DataColumn("codinstrumento") });
        dtPregunta.Rows.Add("1", "1.3", "3");
        dtPregunta.Rows.Add("2", "1.3", "3");
        dtPregunta.Rows.Add("3", "1.3", "3");
        dtPregunta.Rows.Add("4", "1.3", "3");
        dtPregunta.Rows.Add("5", "1.3", "3");

        GridSoftwareEducativo.DataSource = dtPregunta;
        GridSoftwareEducativo.DataBind();
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

    private int valueinst03 = 0;
    int valueRB1inst03 = 0;
    int valueRB1 = 0;
    private void RecorrerGridPregunta1Instrumento03()
    {
        foreach (GridViewRow row in GridPregunta1Intrumento03.Rows)
        {
            if (valueinst03 == 0)
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

    private void AgregarSoftEducativo(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        lb.eliminarRespuestaInstrumento03SoftEducativo(codreginstitucion, "3", "1.3");

        foreach (GridViewRow row in GridSoftwareEducativo.Rows)
        {
            TextBox txtSoftware = (row.FindControl("txtSoftware") as TextBox);
            TextBox txtGradosSoftware = (row.FindControl("txtGradosSoftware") as TextBox);
            TextBox txtAreasSoftware = (row.FindControl("txtAreasSoftware") as TextBox);

            lb.AgregarRespuestaInstrumento03SoftEducativo(codreginstitucion, "1.3", "3", txtSoftware.Text, txtGradosSoftware.Text, txtAreasSoftware.Text);

        }
    }

    private void AgregarHerramientasDisponeIE(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        lb.eliminarRespuestaInstrumento03HerramientasDisponibles(codreginstitucion, "3", "1.4");

        foreach (GridViewRow row in GridHerramientasDisponeIE.Rows)
        {
            DropDownList dropHerramientasDisponeIE = (row.FindControl("dropHerramientasDisponeIE") as DropDownList);
            TextBox txtDireccionHerramientasDisponeIE = (row.FindControl("txtDireccionHerramientasDisponeIE") as TextBox);

            lb.AgregarRespuestaInstrumento03HerramientasDisponibles(codreginstitucion, "1.4", "3", dropHerramientasDisponeIE.SelectedValue, txtDireccionHerramientasDisponeIE.Text);

        }


        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "1.4", "3");
        if (txtPlataformasPedagogicas.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "1.4", txtPlataformasPedagogicas.Text, "3");
        }
    }

    private void AgregarPregunta2_1Instrumento03(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "211", "3");
        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "212", "3");
        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "213", "3");

        if (txtNomProcesoFormacionTICS.Text != "" )
        {
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "211", txtNomProcesoFormacionTICS.Text, "3");

        }
        if ( txtNomProcesoFormacionTICSHoras.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "212", txtNomProcesoFormacionTICSHoras.Text, "3");
        }
        if (txtNomProcesoFormacionTICSTotalBeneficiarios.Text != "")
        {
          
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "213", txtNomProcesoFormacionTICSTotalBeneficiarios.Text, "3");
        }
    }

    private void AgregarPregunta2_2Instrumento03(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "221", "3");
        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "222", "3");
        lb.eliminarRespuestaAbiertaSede(codreginstitucion, "223", "3");

        if (txtCualesPlanesMejoramientoTICS.Text != "" && txtDesarrolladosPlanesMejoramientoTICS.Text != "" && txtEfectosPlanesMejoramientoTICS.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "221", txtCualesPlanesMejoramientoTICS.Text, "3");
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "222", txtDesarrolladosPlanesMejoramientoTICS.Text, "3");
            lb.AgregarRespuestaAbiertaSede(codreginstitucion, "223", txtEfectosPlanesMejoramientoTICS.Text, "3");
        }
    }

    //Cargar Respuestas de la pregunta en el instrumento 03

    private void cargarInformacionRespuesta03(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();


        //Cargar respuestas
        // de 1.1.	Equipamiento y 1.1.1.	Equipamiento desagregado según estudiantes por grado
        DataTable datos = lb.RespuestaInstrumento03TICS(codreginstitucion, "3", "1.1");
        cargarRespuesta1_1Equipamiento(datos);

        //1.1.1.	Equipamiento desagregado según estudiantes por grado
        DataTable datos2 = lb.RespuestaInstrumento03TICS(codreginstitucion, "3", "111");
        cargarRespuesta1_1_1Equipamiento(datos2);

        // 1.1.2.	¿Los estudiantes tienen acceso en equipamiento en TICs fuera del horario escolar? 
        DataTable datos3 = lb.RespuestaInstrumento03TICS(codreginstitucion, "3", "112");
        cargarRespuesta1_1_2Equipamiento(datos3);

        //1.1.3     Calidad de acceso y soporte técnico del equipamiento.
        cargarRespuesta_1_1_3Equipamiento(codreginstitucion);

        //1.2.	Ubicación del equipamiento de uso pedagógico
        DataTable datos4 = lb.RespuestasInstrumento03UbicacionTICS(codreginstitucion, "3", "1.2");
        cargarRespuesta_1_2Equipamiento(datos4);

        //1.3. La institución dispone de software educativo?
        cargarGridSofEducativo(codreginstitucion);

        // 1.4. De cuál de estas herramientas dispone la institución educativa
        cargarGridHerramientasDispone(codreginstitucion);

        //2.	Desarrollo profesional de los docentes en el uso pedagógico de medios y tecnologías de información y comunicación.
        cargarRespuestas_2Equipamiento(codreginstitucion);


    }
    private void ValidarGridPreguntasIntrumento03(string codreginstitucion)
    {
        RecorrerGridPregunta1Instrumento03(); //Para la pregunta 1.1.3 del instrumento 03
        LineaBase lb = new LineaBase();
        if (valueRB1inst03 == 0)
        {
            if (lb.eliminarRespuestaCerradaSede(codreginstitucion, "1", "3", "3")) { }

            foreach (GridViewRow row in GridPregunta1Intrumento03.Rows)
            {
                RadioButtonList dd = (row.FindControl("rb1") as RadioButtonList);
                string rb = dd.SelectedValue;
                if (rb != "")
                {
                    if (lb.AgregarRespuestaCerradaSede(codreginstitucion, "1", rb, "3", "3")) { }
                }
            }
        }
    }
    private void cargarRespuesta1_1Equipamiento(DataTable datos)
    {
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["nombre"].ToString() == "Administración")
                {
                    txtAdminPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtAdminPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtAdminPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtAdminPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtAdminTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtAdminTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtAdminTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtAdminTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Docentes")
                {
                    txtDocentePCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtDocentePCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtDocentePortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtDocentePortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtDocenteTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtDocenteTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtDocenteTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtDocenteTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Estudiantes")
                {
                    txtEstudiantesPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtEstudiantesPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtEstudiantesPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtEstudiantesPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtEstudiantesTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtEstudiantesTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtEstudiantesTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtEstudiantesTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }

            }
        }
    }

    private void cargarRespuesta1_1_1Equipamiento(DataTable datos)
    {
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["nombre"].ToString() == "Preescolar")
                {
                    txtPreescolarPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtPreescolarPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtPreescolarPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtPreescolarPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtPreescolarTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtPreescolarTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtPreescolarTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtPreescolarTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Básica primaria")
                {
                    txtBasicaprimariaPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtBasicaprimariaPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtBasicaprimariaPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtBasicaprimariaPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtBasicaprimariaTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtBasicaprimariaTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtBasicaprimariaTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtBasicaprimariaTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Básica secundaria")
                {
                    txtBasicasecundariaPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtBasicasecundariaPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtBasicasecundariaPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtBasicasecundariaPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtBasicasecundariaTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtBasicasecundariaTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtBasicasecundariaTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtBasicasecundariaTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Media")
                {
                    txtMediaPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtMediaPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtMediaPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtMediaPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtMediaTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtMediaTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtMediaTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtMediaTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Normal Superior")
                {
                    txtNormalSuperiorPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtNormalSuperiorPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtNormalSuperiorPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtNormalSuperiorPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtNormalSuperiorTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtNormalSuperiorTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtNormalSuperiorTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtNormalSuperiorTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Educación discapacidad")
                {
                    txtEducaciondiscapacidadPCConConexion.Text = datos.Rows[i]["conpc"].ToString();
                    txtEducaciondiscapacidadPCSinConexion.Text = datos.Rows[i]["sinpc"].ToString();
                    txtEducaciondiscapacidadPortatilesConConexion.Text = datos.Rows[i]["conportatil"].ToString();
                    txtEducaciondiscapacidadPortatilesSinConexion.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtEducaciondiscapacidadTablerosConConexion.Text = datos.Rows[i]["contableros"].ToString();
                    txtEducaciondiscapacidadTablerosSinConexion.Text = datos.Rows[i]["sintableros"].ToString();
                    txtEducaciondiscapacidadTabletsConConexion.Text = datos.Rows[i]["contablet"].ToString();
                    txtEducaciondiscapacidadTabletsSinConexion.Text = datos.Rows[i]["sintablet"].ToString();
                }


            }
        }
    }

    private void cargarRespuesta1_1_2Equipamiento(DataTable datos)
    {
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["nombre"].ToString() == "Preescolar")
                {
                    txtPreescolarPCConConexionFuera.Text = datos.Rows[i]["conpc"].ToString();
                    txtPreescolarPCSinConexionFuera.Text = datos.Rows[i]["sinpc"].ToString();
                    txtPreescolarPortatilesConConexionFuera.Text = datos.Rows[i]["conportatil"].ToString();
                    txtPreescolarPortatilesSinConexionFuera.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtPreescolarTablerosConConexionFuera.Text = datos.Rows[i]["contableros"].ToString();
                    txtPreescolarTablerosSinConexionFuera.Text = datos.Rows[i]["sintableros"].ToString();
                    txtPreescolarTabletsConConexionFuera.Text = datos.Rows[i]["contablet"].ToString();
                    txtPreescolarTabletsSinConexionFuera.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Básica primaria")
                {
                    txtBasicaprimariaPCConConexionFuera.Text = datos.Rows[i]["conpc"].ToString();
                    txtBasicaprimariaPCSinConexionFuera.Text = datos.Rows[i]["sinpc"].ToString();
                    txtBasicaprimariaPortatilesConConexionFuera.Text = datos.Rows[i]["conportatil"].ToString();
                    txtBasicaprimariaPortatilesSinConexionFuera.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtBasicaprimariaTablerosConConexionFuera.Text = datos.Rows[i]["contableros"].ToString();
                    txtBasicaprimariaTablerosSinConexionFuera.Text = datos.Rows[i]["sintableros"].ToString();
                    txtBasicaprimariaTabletsConConexionFuera.Text = datos.Rows[i]["contablet"].ToString();
                    txtBasicaprimariaTabletsSinConexionFuera.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Básica secundaria")
                {
                    txtBasicasecundariaPCConConexionFuera.Text = datos.Rows[i]["conpc"].ToString();
                    txtBasicasecundariaPCSinConexionFuera.Text = datos.Rows[i]["sinpc"].ToString();
                    txtBasicasecundariaPortatilesConConexionFuera.Text = datos.Rows[i]["conportatil"].ToString();
                    txtBasicasecundariaPortatilesSinConexionFuera.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtBasicasecundariaTablerosConConexionFuera.Text = datos.Rows[i]["contableros"].ToString();
                    txtBasicasecundariaTablerosSinConexionFuera.Text = datos.Rows[i]["sintableros"].ToString();
                    txtBasicasecundariaTabletsConConexionFuera.Text = datos.Rows[i]["contablet"].ToString();
                    txtBasicasecundariaTabletsSinConexionFuera.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Media")
                {
                    txtMediaPCConConexionFuera.Text = datos.Rows[i]["conpc"].ToString();
                    txtMediaPCSinConexionFuera.Text = datos.Rows[i]["sinpc"].ToString();
                    txtMediaPortatilesConConexionFuera.Text = datos.Rows[i]["conportatil"].ToString();
                    txtMediaPortatilesSinConexionFuera.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtMediaTablerosConConexionFuera.Text = datos.Rows[i]["contableros"].ToString();
                    txtMediaTablerosSinConexionFuera.Text = datos.Rows[i]["sintableros"].ToString();
                    txtMediaTabletsConConexionFuera.Text = datos.Rows[i]["contablet"].ToString();
                    txtMediaTabletsSinConexionFuera.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Normal Superior")
                {
                    txtNormalSuperiorPCConConexionFuera.Text = datos.Rows[i]["conpc"].ToString();
                    txtNormalSuperiorPCSinConexionFuera.Text = datos.Rows[i]["sinpc"].ToString();
                    txtNormalSuperiorPortatilesConConexionFuera.Text = datos.Rows[i]["conportatil"].ToString();
                    txtNormalSuperiorPortatilesSinConexionFuera.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtNormalSuperiorTablerosConConexionFuera.Text = datos.Rows[i]["contableros"].ToString();
                    txtNormalSuperiorTablerosSinConexionFuera.Text = datos.Rows[i]["sintableros"].ToString();
                    txtNormalSuperiorTabletsConConexionFuera.Text = datos.Rows[i]["contablet"].ToString();
                    txtNormalSuperiorTabletsSinConexionFuera.Text = datos.Rows[i]["sintablet"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Educación discapacidad")
                {
                    txtEducaciondiscapacidadPCConConexionFuera.Text = datos.Rows[i]["conpc"].ToString();
                    txtEducaciondiscapacidadPCSinConexionFuera.Text = datos.Rows[i]["sinpc"].ToString();
                    txtEducaciondiscapacidadPortatilesConConexionFuera.Text = datos.Rows[i]["conportatil"].ToString();
                    txtEducaciondiscapacidadPortatilesSinConexionFuera.Text = datos.Rows[i]["sinportatil"].ToString();
                    txtEducaciondiscapacidadTablerosConConexionFuera.Text = datos.Rows[i]["contableros"].ToString();
                    txtEducaciondiscapacidadTablerosSinConexionFuera.Text = datos.Rows[i]["sintableros"].ToString();
                    txtEducaciondiscapacidadTabletsConConexionFuera.Text = datos.Rows[i]["contablet"].ToString();
                    txtEducaciondiscapacidadTabletsSinConexionFuera.Text = datos.Rows[i]["sintablet"].ToString();
                }


            }
        }
    }

    private void cargarRespuesta_1_1_3Equipamiento(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasCerradasInstrumentoC600B(codreginstitucion, "1", "3", "3");

        if(datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < GridPregunta1Intrumento03.Rows.Count; i++)
            {
                GridViewRow row = GridPregunta1Intrumento03.Rows[i];
                RadioButtonList dd = (row.FindControl("rb1") as RadioButtonList);
                dd.SelectedValue = datos.Rows[i]["respuesta"].ToString();
            }
        }
      



    }

    private void cargarRespuesta_1_2Equipamiento(DataTable datos)
    {
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["nombre"].ToString() == "PC")
                {
                    txtLudotecasPC.Text = datos.Rows[i]["ludoteca"].ToString();
                    txtBibliotecaPC.Text = datos.Rows[i]["biblioteca"].ToString();
                    txtSalonesPC.Text = datos.Rows[i]["salones"].ToString();
                    txtAulasPC.Text = datos.Rows[i]["aulas"].ToString();
                    txtOtrosPC.Text = datos.Rows[i]["otros"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Portátil")
                {
                    txtLudotecaPortatil.Text = datos.Rows[i]["ludoteca"].ToString();
                    txtBibliotecaPortatil.Text = datos.Rows[i]["biblioteca"].ToString();
                    txtSalonesPortatil.Text = datos.Rows[i]["salones"].ToString();
                    txtAulasPortatil.Text = datos.Rows[i]["aulas"].ToString();
                    txtOtrosPortatil.Text = datos.Rows[i]["otros"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Tablet")
                {
                    txtLudotecaTablet.Text = datos.Rows[i]["ludoteca"].ToString();
                    txtBibliotecaTablet.Text = datos.Rows[i]["biblioteca"].ToString();
                    txtSalonesTablet.Text = datos.Rows[i]["salones"].ToString();
                    txtAulasTablet.Text = datos.Rows[i]["aulas"].ToString();
                    txtOtrosTablet.Text = datos.Rows[i]["otros"].ToString();
                }
                else if (datos.Rows[i]["nombre"].ToString() == "Tableros")
                {
                    txtLudotecaTableros.Text = datos.Rows[i]["ludoteca"].ToString();
                    txtBibliotecaTableros.Text = datos.Rows[i]["biblioteca"].ToString();
                    txtSalonesTableros.Text = datos.Rows[i]["salones"].ToString();
                    txtAulasTableros.Text = datos.Rows[i]["aulas"].ToString();
                    txtOtrosTableros.Text = datos.Rows[i]["otros"].ToString();
                }
            }
        }
    }

    private void cargarGridSofEducativo(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.RespuestasInstrumento03SoftEducativo(codreginstitucion, "3", "1.3");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if (escogido != null && escogido.Rows.Count > 0)
        {
            int i = 0;

            foreach (GridViewRow row in GridSoftwareEducativo.Rows)
            {
                //DropDownList dropFomacionInvesTipo = (row.FindControl("txtSoftware") as DropDownList);
                TextBox txtSoftware = (row.FindControl("txtSoftware") as TextBox);
                TextBox txtGradosSoftware = (row.FindControl("txtGradosSoftware") as TextBox);
                TextBox txtAreasSoftware = (row.FindControl("txtAreasSoftware") as TextBox);

                txtSoftware.Text = escogido.Rows[i]["nombre"].ToString();
                txtGradosSoftware.Text = escogido.Rows[i]["grados"].ToString();
                txtAreasSoftware.Text = escogido.Rows[i]["areas"].ToString();

                i++;

            }
        }

    }

    private void cargarGridHerramientasDispone(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();
        DataTable escogido = lb.RespuestasInstrumento03HerramientasDispone(codreginstitucion, "3", "1.4");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if (escogido != null && escogido.Rows.Count > 0)
        {
            int i = 0;

            foreach (GridViewRow row in GridHerramientasDisponeIE.Rows)
            {
                DropDownList dropHerramientasDisponeIE = (row.FindControl("dropHerramientasDisponeIE") as DropDownList);
                TextBox txtDireccionHerramientasDisponeIE = (row.FindControl("txtDireccionHerramientasDisponeIE") as TextBox);


                dropHerramientasDisponeIE.SelectedValue = escogido.Rows[i]["tipo"].ToString();
                txtDireccionHerramientasDisponeIE.Text = escogido.Rows[i]["direccion"].ToString();

                i++;

            }
        }
        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "1.4", "3");

        if (dat != null)
        {
            txtPlataformasPedagogicas.Text = dat["comentario"].ToString();
        }

    }

    private void cargarRespuestas_2Equipamiento(string codreginstitucion)
    {
        LineaBase lb = new LineaBase();

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "211", "3");

        if (dat != null)
        {
            txtNomProcesoFormacionTICS.Text = dat["comentario"].ToString();
        }

        DataRow dat2 = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "212", "3");

        if (dat2 != null)
        {
            txtNomProcesoFormacionTICSHoras.Text = dat2["comentario"].ToString();
        }
        DataRow dat3 = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "213", "3");

        if (dat3 != null)
        {
            txtNomProcesoFormacionTICSTotalBeneficiarios.Text = dat3["comentario"].ToString();
        }

        DataRow dat4 = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "221", "3");

        if (dat4 != null)
        {
            txtCualesPlanesMejoramientoTICS.Text = dat4["comentario"].ToString();
        }

        DataRow dat5 = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "222", "3");

        if (dat5 != null)
        {
            txtDesarrolladosPlanesMejoramientoTICS.Text = dat5["comentario"].ToString();
        }

        DataRow dat6 = lb.cargarRespuestaAbiertaInstrumentoC600B(codreginstitucion, "223", "3");

        if (dat5 != null)
        {
            txtEfectosPlanesMejoramientoTICS.Text = dat6["comentario"].ToString();
        }


    }

    protected void btnAgregarDisponibilidad_OnClick(Object sender, EventArgs e)
    {
        
            if (lblCodSedeinsAsesor.Text != "")
            {
                if (lb.eliminarRespuestasInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1")) { } //CodregInstitución, codinstrumento, codpregunta
                
                if(txtAdminPCConConexion.Text == ""){ txtAdminPCConConexion.Text = "0"; }
                if (txtAdminPCSinConexion.Text == "") { txtAdminPCSinConexion.Text = "0"; }
                if (txtAdminPortatilesConConexion.Text == "") { txtAdminPortatilesConConexion.Text = "0"; }
                if (txtAdminPortatilesSinConexion.Text == "") { txtAdminPortatilesSinConexion.Text = "0"; }
                if (txtAdminTabletsConConexion.Text == "") { txtAdminTabletsConConexion.Text = "0"; }
                if (txtAdminTabletsSinConexion.Text == "") { txtAdminTabletsSinConexion.Text = "0"; }
                if (txtAdminTablerosConConexion.Text == "") { txtAdminTablerosConConexion.Text = "0"; }
                if (txtAdminTablerosSinConexion.Text == "") { txtAdminTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1", "Administración", txtAdminPCConConexion.Text, txtAdminPCSinConexion.Text, txtAdminPortatilesConConexion.Text, txtAdminPortatilesSinConexion.Text, txtAdminTabletsConConexion.Text, txtAdminTabletsSinConexion.Text, txtAdminTablerosConConexion.Text, txtAdminTablerosSinConexion.Text)) { }

                if (txtDocentePCConConexion.Text == "") { txtDocentePCConConexion.Text = "0"; }
                if (txtDocentePCSinConexion.Text == "") { txtDocentePCSinConexion.Text = "0"; }
                if (txtDocentePortatilesConConexion.Text == "") { txtDocentePortatilesConConexion.Text = "0"; }
                if (txtDocentePortatilesSinConexion.Text == "") { txtDocentePortatilesSinConexion.Text = "0"; }
                if (txtDocenteTabletsConConexion.Text == "") { txtDocenteTabletsConConexion.Text = "0"; }
                if (txtDocenteTabletsSinConexion.Text == "") { txtDocenteTabletsSinConexion.Text = "0"; }
                if (txtDocenteTablerosConConexion.Text == "") { txtDocenteTablerosConConexion.Text = "0"; }
                if (txtDocenteTablerosSinConexion.Text == "") { txtDocenteTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1", "Docentes", txtDocentePCConConexion.Text, txtDocentePCSinConexion.Text, txtDocentePortatilesConConexion.Text, txtDocentePortatilesSinConexion.Text, txtDocenteTabletsConConexion.Text, txtDocenteTabletsSinConexion.Text, txtDocenteTablerosConConexion.Text, txtDocenteTablerosSinConexion.Text)) { }


                if (txtEstudiantesPCConConexion.Text == "") { txtEstudiantesPCConConexion.Text = "0"; }
                if (txtEstudiantesPCSinConexion.Text == "") { txtEstudiantesPCSinConexion.Text = "0"; }
                if (txtEstudiantesPortatilesConConexion.Text == "") { txtEstudiantesPortatilesConConexion.Text = "0"; }
                if (txtEstudiantesPortatilesSinConexion.Text == "") { txtEstudiantesPortatilesSinConexion.Text = "0"; }
                if (txtEstudiantesTabletsConConexion.Text == "") { txtEstudiantesTabletsConConexion.Text = "0"; }
                if (txtEstudiantesTabletsSinConexion.Text == "") { txtEstudiantesTabletsSinConexion.Text = "0"; }
                if (txtEstudiantesTablerosConConexion.Text == "") { txtEstudiantesTablerosConConexion.Text = "0"; }
                if (txtEstudiantesTablerosSinConexion.Text == "") { txtEstudiantesTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1", "Estudiantes", txtEstudiantesPCConConexion.Text, txtEstudiantesPCSinConexion.Text, txtEstudiantesPortatilesConConexion.Text, txtEstudiantesPortatilesSinConexion.Text, txtEstudiantesTabletsConConexion.Text, txtEstudiantesTabletsSinConexion.Text, txtEstudiantesTablerosConConexion.Text, txtEstudiantesTablerosSinConexion.Text)) { }


                //1.1.1

                if (lb.eliminarRespuestasInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111")) { } //CodregInstitución, codinstrumento, codpregunta


                if (txtPreescolarPCConConexion.Text == "") { txtPreescolarPCConConexion.Text = "0"; }
                if (txtPreescolarPCSinConexion.Text == "") { txtPreescolarPCSinConexion.Text = "0"; }
                if (txtPreescolarPortatilesConConexion.Text == "") { txtPreescolarPortatilesConConexion.Text = "0"; }
                if (txtPreescolarPortatilesSinConexion.Text == "") { txtPreescolarPortatilesSinConexion.Text = "0"; }
                if (txtPreescolarTabletsConConexion.Text == "") { txtPreescolarTabletsConConexion.Text = "0"; }
                if (txtPreescolarTabletsSinConexion.Text == "") { txtPreescolarTabletsSinConexion.Text = "0"; }
                if (txtPreescolarTablerosConConexion.Text == "") { txtPreescolarTablerosConConexion.Text = "0"; }
                if (txtPreescolarTablerosSinConexion.Text == "") { txtPreescolarTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Preescolar", txtPreescolarPCConConexion.Text, txtPreescolarPCSinConexion.Text, txtPreescolarPortatilesConConexion.Text, txtPreescolarPortatilesSinConexion.Text, txtPreescolarTabletsConConexion.Text, txtPreescolarTabletsSinConexion.Text, txtPreescolarTablerosConConexion.Text, txtPreescolarTablerosSinConexion.Text)) { }


                if (txtBasicaprimariaPCConConexion.Text == "") { txtBasicaprimariaPCConConexion.Text = "0"; }
                if (txtBasicaprimariaPCSinConexion.Text == "") { txtBasicaprimariaPCSinConexion.Text = "0"; }
                if (txtBasicaprimariaPortatilesConConexion.Text == "") { txtBasicaprimariaPortatilesConConexion.Text = "0"; }
                if (txtBasicaprimariaPortatilesSinConexion.Text == "") { txtBasicaprimariaPortatilesSinConexion.Text = "0"; }
                if (txtBasicaprimariaTabletsConConexion.Text == "") { txtBasicaprimariaTabletsConConexion.Text = "0"; }
                if (txtBasicaprimariaTabletsSinConexion.Text == "") { txtBasicaprimariaTabletsSinConexion.Text = "0"; }
                if (txtBasicaprimariaTablerosConConexion.Text == "") { txtBasicaprimariaTablerosConConexion.Text = "0"; }
                if (txtBasicaprimariaTablerosSinConexion.Text == "") { txtBasicaprimariaTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Básica primaria", txtBasicaprimariaPCConConexion.Text, txtBasicaprimariaPCSinConexion.Text, txtBasicaprimariaPortatilesConConexion.Text, txtBasicaprimariaPortatilesSinConexion.Text, txtBasicaprimariaTabletsConConexion.Text, txtBasicaprimariaTabletsSinConexion.Text, txtBasicaprimariaTablerosConConexion.Text, txtBasicaprimariaTablerosSinConexion.Text)) { }


                if (txtBasicasecundariaPCConConexion.Text == "") { txtBasicasecundariaPCConConexion.Text = "0"; }
                if (txtBasicasecundariaPortatilesConConexion.Text == "") { txtBasicasecundariaPortatilesConConexion.Text = "0"; }
                if (txtBasicasecundariaPortatilesSinConexion.Text == "") { txtBasicasecundariaPortatilesSinConexion.Text = "0"; }
                if (txtBasicaprimariaPortatilesSinConexion.Text == "") { txtBasicaprimariaPortatilesSinConexion.Text = "0"; }
                if (txtBasicasecundariaTabletsConConexion.Text == "") { txtBasicasecundariaTabletsConConexion.Text = "0"; }
                if (txtBasicasecundariaTabletsSinConexion.Text == "") { txtBasicasecundariaTabletsSinConexion.Text = "0"; }
                if (txtBasicasecundariaTablerosConConexion.Text == "") { txtBasicasecundariaTablerosConConexion.Text = "0"; }
                if (txtBasicasecundariaTablerosSinConexion.Text == "") { txtBasicasecundariaTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Básica secundaria", txtBasicasecundariaPCConConexion.Text, txtBasicasecundariaPCSinConexion.Text, txtBasicasecundariaPortatilesConConexion.Text, txtBasicasecundariaPortatilesSinConexion.Text, txtBasicasecundariaTabletsConConexion.Text, txtBasicasecundariaTabletsSinConexion.Text, txtBasicasecundariaTablerosConConexion.Text, txtBasicasecundariaTablerosSinConexion.Text)) { }

                if (txtMediaPCConConexion.Text == "") { txtMediaPCConConexion.Text = "0"; }
                if (txtMediaPCSinConexion.Text == "") { txtMediaPCSinConexion.Text = "0"; }
                if (txtMediaPortatilesConConexion.Text == "") { txtMediaPortatilesConConexion.Text = "0"; }
                if (txtMediaPortatilesSinConexion.Text == "") { txtMediaPortatilesSinConexion.Text = "0"; }
                if (txtMediaTabletsConConexion.Text == "") { txtMediaTabletsConConexion.Text = "0"; }
                if (txtMediaTabletsSinConexion.Text == "") { txtMediaTabletsSinConexion.Text = "0"; }
                if (txtMediaTablerosConConexion.Text == "") { txtMediaTablerosConConexion.Text = "0"; }
                if (txtMediaTablerosSinConexion.Text == "") { txtMediaTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Media", txtMediaPCConConexion.Text, txtMediaPCSinConexion.Text, txtMediaPortatilesConConexion.Text, txtMediaPortatilesSinConexion.Text, txtMediaTabletsConConexion.Text, txtMediaTabletsSinConexion.Text, txtMediaTablerosConConexion.Text, txtMediaTablerosSinConexion.Text)) { }

                if (txtNormalSuperiorPCConConexion.Text == "") { txtNormalSuperiorPCConConexion.Text = "0"; }
                if (txtNormalSuperiorPCSinConexion.Text == "") { txtNormalSuperiorPCSinConexion.Text = "0"; }
                if (txtNormalSuperiorPortatilesConConexion.Text == "") { txtNormalSuperiorPortatilesConConexion.Text = "0"; }
                if (txtNormalSuperiorPortatilesSinConexion.Text == "") { txtNormalSuperiorPortatilesSinConexion.Text = "0"; }
                if (txtNormalSuperiorTabletsConConexion.Text == "") { txtNormalSuperiorTabletsConConexion.Text = "0"; }
                if (txtNormalSuperiorTabletsSinConexion.Text == "") { txtNormalSuperiorTabletsSinConexion.Text = "0"; }
                if (txtNormalSuperiorTablerosConConexion.Text == "") { txtNormalSuperiorTablerosConConexion.Text = "0"; }
                if (txtNormalSuperiorTablerosSinConexion.Text == "") { txtNormalSuperiorTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Normal Superior", txtNormalSuperiorPCConConexion.Text, txtNormalSuperiorPCSinConexion.Text, txtNormalSuperiorPortatilesConConexion.Text, txtNormalSuperiorPortatilesSinConexion.Text, txtNormalSuperiorTabletsConConexion.Text, txtNormalSuperiorTabletsSinConexion.Text, txtNormalSuperiorTablerosConConexion.Text, txtNormalSuperiorTablerosSinConexion.Text)) { }

                if (txtEducaciondiscapacidadPCConConexion.Text == "") { txtEducaciondiscapacidadPCConConexion.Text = "0"; }
                if (txtEducaciondiscapacidadPCSinConexion.Text == "") { txtEducaciondiscapacidadPCSinConexion.Text = "0"; }
                if (txtEducaciondiscapacidadPortatilesConConexion.Text == "") { txtEducaciondiscapacidadPortatilesConConexion.Text = "0"; }
                if (txtEducaciondiscapacidadPortatilesSinConexion.Text == "") { txtEducaciondiscapacidadPortatilesSinConexion.Text = "0"; }
                if (txtEducaciondiscapacidadTabletsConConexion.Text == "") { txtEducaciondiscapacidadTabletsConConexion.Text = "0"; }
                if (txtEducaciondiscapacidadTabletsSinConexion.Text == "") { txtEducaciondiscapacidadTabletsSinConexion.Text = "0"; }
                if (txtEducaciondiscapacidadTablerosConConexion.Text == "") { txtEducaciondiscapacidadTablerosConConexion.Text = "0"; }
                if (txtEducaciondiscapacidadTablerosSinConexion.Text == "") { txtEducaciondiscapacidadTablerosSinConexion.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Educación discapacidad", txtEducaciondiscapacidadPCConConexion.Text, txtEducaciondiscapacidadPCSinConexion.Text, txtEducaciondiscapacidadPortatilesConConexion.Text, txtEducaciondiscapacidadPortatilesSinConexion.Text, txtEducaciondiscapacidadTabletsConConexion.Text, txtEducaciondiscapacidadTabletsSinConexion.Text, txtEducaciondiscapacidadTablerosConConexion.Text, txtEducaciondiscapacidadTablerosSinConexion.Text)) { }
               

                //Pregunta 1.1.2

                if (lb.eliminarRespuestasInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112")) { } //CodregInstitución, codinstrumento, codpregunta

                if (txtPreescolarPCConConexionFuera.Text == "") { txtPreescolarPCConConexionFuera.Text = "0"; }
                if (txtPreescolarPCSinConexionFuera.Text == "") { txtPreescolarPCSinConexionFuera.Text = "0"; }
                if (txtPreescolarPortatilesConConexionFuera.Text == "") { txtPreescolarPortatilesConConexionFuera.Text = "0"; }
                if (txtPreescolarPortatilesSinConexionFuera.Text == "") { txtPreescolarPortatilesSinConexionFuera.Text = "0"; }
                if (txtPreescolarTabletsConConexionFuera.Text == "") { txtPreescolarTabletsConConexionFuera.Text = "0"; }
                if (txtPreescolarTabletsSinConexionFuera.Text == "") { txtPreescolarTabletsSinConexionFuera.Text = "0"; }
                if (txtPreescolarTablerosConConexionFuera.Text == "") { txtPreescolarTablerosConConexionFuera.Text = "0"; }
                if (txtPreescolarTablerosSinConexionFuera.Text == "") { txtPreescolarTablerosSinConexionFuera.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Preescolar", txtPreescolarPCConConexionFuera.Text, txtPreescolarPCSinConexionFuera.Text, txtPreescolarPortatilesConConexionFuera.Text, txtPreescolarPortatilesSinConexionFuera.Text, txtPreescolarTabletsConConexionFuera.Text, txtPreescolarTabletsSinConexionFuera.Text, txtPreescolarTablerosConConexionFuera.Text, txtPreescolarTablerosSinConexionFuera.Text)) { }

                if (txtBasicaprimariaPCConConexionFuera.Text == "") { txtBasicaprimariaPCConConexionFuera.Text = "0"; }
                if (txtBasicaprimariaPCSinConexionFuera.Text == "") { txtBasicaprimariaPCSinConexionFuera.Text = "0"; }
                if (txtBasicaprimariaPortatilesConConexionFuera.Text == "") { txtBasicaprimariaPortatilesConConexionFuera.Text = "0"; }
                if (txtBasicaprimariaPortatilesSinConexionFuera.Text == "") { txtBasicaprimariaPortatilesSinConexionFuera.Text = "0"; }
                if (txtBasicaprimariaTabletsConConexionFuera.Text == "") { txtBasicaprimariaTabletsConConexionFuera.Text = "0"; }
                if (txtBasicaprimariaTabletsSinConexionFuera.Text == "") { txtBasicaprimariaTabletsSinConexionFuera.Text = "0"; }
                if (txtBasicaprimariaTablerosConConexionFuera.Text == "") { txtBasicaprimariaTablerosConConexionFuera.Text = "0"; }
                if (txtBasicaprimariaTablerosSinConexionFuera.Text == "") { txtBasicaprimariaTablerosSinConexionFuera.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Básica primaria", txtBasicaprimariaPCConConexionFuera.Text, txtBasicaprimariaPCSinConexionFuera.Text, txtBasicaprimariaPortatilesConConexionFuera.Text, txtBasicaprimariaPortatilesSinConexionFuera.Text, txtBasicaprimariaTabletsConConexionFuera.Text, txtBasicaprimariaTabletsSinConexionFuera.Text, txtBasicaprimariaTablerosConConexionFuera.Text, txtBasicaprimariaTablerosSinConexionFuera.Text)) { }

                if (txtBasicasecundariaPCConConexionFuera.Text == "") { txtBasicasecundariaPCConConexionFuera.Text = "0"; }
                if (txtBasicasecundariaPCSinConexionFuera.Text == "") { txtBasicasecundariaPCSinConexionFuera.Text = "0"; }
                if (txtBasicasecundariaPortatilesConConexionFuera.Text == "") { txtBasicasecundariaPortatilesConConexionFuera.Text = "0"; }
                if (txtBasicasecundariaPortatilesSinConexionFuera.Text == "") { txtBasicasecundariaPortatilesSinConexionFuera.Text = "0"; }
                if (txtBasicasecundariaTabletsConConexionFuera.Text == "") { txtBasicasecundariaTabletsConConexionFuera.Text = "0"; }
                if (txtBasicasecundariaTabletsSinConexionFuera.Text == "") { txtBasicasecundariaTabletsSinConexionFuera.Text = "0"; }
                if (txtBasicasecundariaTablerosConConexionFuera.Text == "") { txtBasicasecundariaTablerosConConexionFuera.Text = "0"; }
                if (txtBasicasecundariaTablerosSinConexionFuera.Text == "") { txtBasicasecundariaTablerosSinConexionFuera.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Básica secundaria", txtBasicasecundariaPCConConexionFuera.Text, txtBasicasecundariaPCSinConexionFuera.Text, txtBasicasecundariaPortatilesConConexionFuera.Text, txtBasicasecundariaPortatilesSinConexionFuera.Text, txtBasicasecundariaTabletsConConexionFuera.Text, txtBasicasecundariaTabletsSinConexionFuera.Text, txtBasicasecundariaTablerosConConexionFuera.Text, txtBasicasecundariaTablerosSinConexionFuera.Text)) { }

                if (txtMediaPCConConexionFuera.Text == "") { txtMediaPCConConexionFuera.Text = "0"; }
                if (txtMediaPCSinConexionFuera.Text == "") { txtMediaPCSinConexionFuera.Text = "0"; }
                if (txtMediaPortatilesConConexionFuera.Text == "") { txtMediaPortatilesConConexionFuera.Text = "0"; }
                if (txtMediaPortatilesSinConexionFuera.Text == "") { txtMediaPortatilesSinConexionFuera.Text = "0"; }
                if (txtMediaTabletsConConexionFuera.Text == "") { txtMediaTabletsConConexionFuera.Text = "0"; }
                if (txtMediaTabletsSinConexionFuera.Text == "") { txtMediaTabletsSinConexionFuera.Text = "0"; }
                if (txtMediaTablerosConConexionFuera.Text == "") { txtMediaTablerosConConexionFuera.Text = "0"; }
                if (txtMediaTablerosSinConexionFuera.Text == "") { txtMediaTablerosSinConexionFuera.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Media", txtMediaPCConConexionFuera.Text, txtMediaPCSinConexionFuera.Text, txtMediaPortatilesConConexionFuera.Text, txtMediaPortatilesSinConexionFuera.Text, txtMediaTabletsConConexionFuera.Text, txtMediaTabletsSinConexionFuera.Text, txtMediaTablerosConConexionFuera.Text, txtMediaTablerosSinConexionFuera.Text)) { }

                if (txtNormalSuperiorPCConConexionFuera.Text == "") { txtNormalSuperiorPCConConexionFuera.Text = "0"; }
                if (txtNormalSuperiorPCSinConexionFuera.Text == "") { txtNormalSuperiorPCSinConexionFuera.Text = "0"; }
                if (txtNormalSuperiorPortatilesConConexionFuera.Text == "") { txtNormalSuperiorPortatilesConConexionFuera.Text = "0"; }
                if (txtNormalSuperiorPortatilesSinConexionFuera.Text == "") { txtNormalSuperiorPortatilesSinConexionFuera.Text = "0"; }
                if (txtNormalSuperiorTabletsConConexionFuera.Text == "") { txtNormalSuperiorTabletsConConexionFuera.Text = "0"; }
                if (txtNormalSuperiorTabletsSinConexionFuera.Text == "") { txtNormalSuperiorTabletsSinConexionFuera.Text = "0"; }
                if (txtNormalSuperiorTablerosConConexionFuera.Text == "") { txtNormalSuperiorTablerosConConexionFuera.Text = "0"; }
                if (txtNormalSuperiorTablerosSinConexionFuera.Text == "") { txtNormalSuperiorTablerosSinConexionFuera.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Normal Superior", txtNormalSuperiorPCConConexionFuera.Text, txtNormalSuperiorPCSinConexionFuera.Text, txtNormalSuperiorPortatilesConConexionFuera.Text, txtNormalSuperiorPortatilesSinConexionFuera.Text, txtNormalSuperiorTabletsConConexionFuera.Text, txtNormalSuperiorTabletsSinConexionFuera.Text, txtNormalSuperiorTablerosConConexionFuera.Text, txtNormalSuperiorTablerosSinConexionFuera.Text)) { }

                if (txtEducaciondiscapacidadPCConConexionFuera.Text == "") { txtEducaciondiscapacidadPCConConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadPCSinConexionFuera.Text == "") { txtEducaciondiscapacidadPCSinConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadPortatilesConConexionFuera.Text == "") { txtEducaciondiscapacidadPortatilesConConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadPortatilesSinConexionFuera.Text == "") { txtEducaciondiscapacidadPortatilesSinConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadTabletsConConexionFuera.Text == "") { txtEducaciondiscapacidadTabletsConConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadTabletsSinConexionFuera.Text == "") { txtEducaciondiscapacidadTabletsSinConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadTablerosConConexionFuera.Text == "") { txtEducaciondiscapacidadTablerosConConexionFuera.Text = "0"; }
                if (txtEducaciondiscapacidadTablerosSinConexionFuera.Text == "") { txtEducaciondiscapacidadTablerosSinConexionFuera.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Educación discapacidad", txtEducaciondiscapacidadPCConConexionFuera.Text, txtEducaciondiscapacidadPCSinConexionFuera.Text, txtEducaciondiscapacidadPortatilesConConexionFuera.Text, txtEducaciondiscapacidadPortatilesSinConexionFuera.Text, txtEducaciondiscapacidadTabletsConConexion.Text, txtEducaciondiscapacidadTabletsSinConexionFuera.Text, txtEducaciondiscapacidadTablerosConConexionFuera.Text, txtEducaciondiscapacidadTablerosSinConexionFuera.Text)) { }

                ValidarGridPreguntasIntrumento03(lblCodSedeinsAsesor.Text);


                //Pregunta 1.2
                if (lb.eliminarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2")) { }

                if (txtLudotecasPC.Text == "") { txtLudotecasPC.Text = "0"; }
                if (txtBibliotecaPC.Text == "") { txtBibliotecaPC.Text = "0"; }
                if (txtSalonesPC.Text == "") { txtSalonesPC.Text = "0"; }
                if (txtAulasPC.Text == "") { txtAulasPC.Text = "0"; }
                if (txtOtrosPC.Text == "") { txtOtrosPC.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "PC", txtLudotecasPC.Text, txtBibliotecaPC.Text, txtSalonesPC.Text, txtAulasPC.Text, txtOtrosPC.Text)) { }

                if (txtLudotecaPortatil.Text == "") { txtLudotecaPortatil.Text = "0"; }
                if (txtBibliotecaPortatil.Text == "") { txtBibliotecaPortatil.Text = "0"; }
                if (txtSalonesPortatil.Text == "") { txtSalonesPortatil.Text = "0"; }
                if (txtAulasPortatil.Text == "") { txtAulasPortatil.Text = "0"; }
                if (txtOtrosPortatil.Text == "") { txtOtrosPortatil.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "Portátil", txtLudotecaPortatil.Text, txtBibliotecaPortatil.Text, txtSalonesPortatil.Text, txtAulasPortatil.Text, txtOtrosPortatil.Text)) { }

                if (txtLudotecaTablet.Text == "") { txtLudotecaTablet.Text = "0"; }
                if (txtBibliotecaTablet.Text == "") { txtBibliotecaTablet.Text = "0"; }
                if (txtSalonesTablet.Text == "") { txtSalonesTablet.Text = "0"; }
                if (txtAulasTablet.Text == "") { txtAulasTablet.Text = "0"; }
                if (txtOtrosTablet.Text == "") { txtOtrosTablet.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "Tablet", txtLudotecaTablet.Text, txtBibliotecaTablet.Text, txtSalonesTablet.Text, txtAulasTablet.Text, txtOtrosTablet.Text)) { }

                if (txtLudotecaTableros.Text == "") { txtLudotecaTableros.Text = "0"; }
                if (txtBibliotecaTableros.Text == "") { txtBibliotecaTableros.Text = "0"; }
                if (txtSalonesTableros.Text == "") { txtSalonesTableros.Text = "0"; }
                if (txtAulasTableros.Text == "") { txtAulasTableros.Text = "0"; }
                if (txtOtrosTableros.Text == "") { txtOtrosTableros.Text = "0"; }
                if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "Tableros", txtLudotecaTableros.Text, txtBibliotecaTableros.Text, txtSalonesTableros.Text, txtAulasTableros.Text, txtOtrosTableros.Text)) { }

                //1.3
                AgregarSoftEducativo(lblCodSedeinsAsesor.Text);

                //1.4
                AgregarHerramientasDisponeIE(lblCodSedeinsAsesor.Text);

                //2
                //2.1
                AgregarPregunta2_1Instrumento03(lblCodSedeinsAsesor.Text);

                //2.2
                AgregarPregunta2_2Instrumento03(lblCodSedeinsAsesor.Text);

                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }
            else
            {
                mostrarmensaje("error","Dede seleccionar una sede");
            }
    

       
    }

    protected void btnPrimerGuardar_OnClick(Object sender, EventArgs e)
    {

        if (lblCodSedeinsAsesor.Text != "")
        {
            if (lb.eliminarRespuestasInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1")) { } //CodregInstitución, codinstrumento, codpregunta

            if (txtAdminPCConConexion.Text == "") { txtAdminPCConConexion.Text = "0"; }
            if (txtAdminPCSinConexion.Text == "") { txtAdminPCSinConexion.Text = "0"; }
            if (txtAdminPortatilesConConexion.Text == "") { txtAdminPortatilesConConexion.Text = "0"; }
            if (txtAdminPortatilesSinConexion.Text == "") { txtAdminPortatilesSinConexion.Text = "0"; }
            if (txtAdminTabletsConConexion.Text == "") { txtAdminTabletsConConexion.Text = "0"; }
            if (txtAdminTabletsSinConexion.Text == "") { txtAdminTabletsSinConexion.Text = "0"; }
            if (txtAdminTablerosConConexion.Text == "") { txtAdminTablerosConConexion.Text = "0"; }
            if (txtAdminTablerosSinConexion.Text == "") { txtAdminTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1", "Administración", txtAdminPCConConexion.Text, txtAdminPCSinConexion.Text, txtAdminPortatilesConConexion.Text, txtAdminPortatilesSinConexion.Text, txtAdminTabletsConConexion.Text, txtAdminTabletsSinConexion.Text, txtAdminTablerosConConexion.Text, txtAdminTablerosSinConexion.Text)) { }

            if (txtDocentePCConConexion.Text == "") { txtDocentePCConConexion.Text = "0"; }
            if (txtDocentePCSinConexion.Text == "") { txtDocentePCSinConexion.Text = "0"; }
            if (txtDocentePortatilesConConexion.Text == "") { txtDocentePortatilesConConexion.Text = "0"; }
            if (txtDocentePortatilesSinConexion.Text == "") { txtDocentePortatilesSinConexion.Text = "0"; }
            if (txtDocenteTabletsConConexion.Text == "") { txtDocenteTabletsConConexion.Text = "0"; }
            if (txtDocenteTabletsSinConexion.Text == "") { txtDocenteTabletsSinConexion.Text = "0"; }
            if (txtDocenteTablerosConConexion.Text == "") { txtDocenteTablerosConConexion.Text = "0"; }
            if (txtDocenteTablerosSinConexion.Text == "") { txtDocenteTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1", "Docentes", txtDocentePCConConexion.Text, txtDocentePCSinConexion.Text, txtDocentePortatilesConConexion.Text, txtDocentePortatilesSinConexion.Text, txtDocenteTabletsConConexion.Text, txtDocenteTabletsSinConexion.Text, txtDocenteTablerosConConexion.Text, txtDocenteTablerosSinConexion.Text)) { }


            if (txtEstudiantesPCConConexion.Text == "") { txtEstudiantesPCConConexion.Text = "0"; }
            if (txtEstudiantesPCSinConexion.Text == "") { txtEstudiantesPCSinConexion.Text = "0"; }
            if (txtEstudiantesPortatilesConConexion.Text == "") { txtEstudiantesPortatilesConConexion.Text = "0"; }
            if (txtEstudiantesPortatilesSinConexion.Text == "") { txtEstudiantesPortatilesSinConexion.Text = "0"; }
            if (txtEstudiantesTabletsConConexion.Text == "") { txtEstudiantesTabletsConConexion.Text = "0"; }
            if (txtEstudiantesTabletsSinConexion.Text == "") { txtEstudiantesTabletsSinConexion.Text = "0"; }
            if (txtEstudiantesTablerosConConexion.Text == "") { txtEstudiantesTablerosConConexion.Text = "0"; }
            if (txtEstudiantesTablerosSinConexion.Text == "") { txtEstudiantesTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "1.1", "Estudiantes", txtEstudiantesPCConConexion.Text, txtEstudiantesPCSinConexion.Text, txtEstudiantesPortatilesConConexion.Text, txtEstudiantesPortatilesSinConexion.Text, txtEstudiantesTabletsConConexion.Text, txtEstudiantesTabletsSinConexion.Text, txtEstudiantesTablerosConConexion.Text, txtEstudiantesTablerosSinConexion.Text)) { }

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            mostrarmensaje("error", "Dede seleccionar una sede");
        }
            

    }

    protected void btnSegundoGuardar_OnClick(Object sender, EventArgs e)
    {

        if (lblCodSedeinsAsesor.Text != "")
        {
           


            //1.1.1

            if (lb.eliminarRespuestasInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111")) { } //CodregInstitución, codinstrumento, codpregunta


            if (txtPreescolarPCConConexion.Text == "") { txtPreescolarPCConConexion.Text = "0"; }
            if (txtPreescolarPCSinConexion.Text == "") { txtPreescolarPCSinConexion.Text = "0"; }
            if (txtPreescolarPortatilesConConexion.Text == "") { txtPreescolarPortatilesConConexion.Text = "0"; }
            if (txtPreescolarPortatilesSinConexion.Text == "") { txtPreescolarPortatilesSinConexion.Text = "0"; }
            if (txtPreescolarTabletsConConexion.Text == "") { txtPreescolarTabletsConConexion.Text = "0"; }
            if (txtPreescolarTabletsSinConexion.Text == "") { txtPreescolarTabletsSinConexion.Text = "0"; }
            if (txtPreescolarTablerosConConexion.Text == "") { txtPreescolarTablerosConConexion.Text = "0"; }
            if (txtPreescolarTablerosSinConexion.Text == "") { txtPreescolarTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Preescolar", txtPreescolarPCConConexion.Text, txtPreescolarPCSinConexion.Text, txtPreescolarPortatilesConConexion.Text, txtPreescolarPortatilesSinConexion.Text, txtPreescolarTabletsConConexion.Text, txtPreescolarTabletsSinConexion.Text, txtPreescolarTablerosConConexion.Text, txtPreescolarTablerosSinConexion.Text)) { }


            if (txtBasicaprimariaPCConConexion.Text == "") { txtBasicaprimariaPCConConexion.Text = "0"; }
            if (txtBasicaprimariaPCSinConexion.Text == "") { txtBasicaprimariaPCSinConexion.Text = "0"; }
            if (txtBasicaprimariaPortatilesConConexion.Text == "") { txtBasicaprimariaPortatilesConConexion.Text = "0"; }
            if (txtBasicaprimariaPortatilesSinConexion.Text == "") { txtBasicaprimariaPortatilesSinConexion.Text = "0"; }
            if (txtBasicaprimariaTabletsConConexion.Text == "") { txtBasicaprimariaTabletsConConexion.Text = "0"; }
            if (txtBasicaprimariaTabletsSinConexion.Text == "") { txtBasicaprimariaTabletsSinConexion.Text = "0"; }
            if (txtBasicaprimariaTablerosConConexion.Text == "") { txtBasicaprimariaTablerosConConexion.Text = "0"; }
            if (txtBasicaprimariaTablerosSinConexion.Text == "") { txtBasicaprimariaTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Básica primaria", txtBasicaprimariaPCConConexion.Text, txtBasicaprimariaPCSinConexion.Text, txtBasicaprimariaPortatilesConConexion.Text, txtBasicaprimariaPortatilesSinConexion.Text, txtBasicaprimariaTabletsConConexion.Text, txtBasicaprimariaTabletsSinConexion.Text, txtBasicaprimariaTablerosConConexion.Text, txtBasicaprimariaTablerosSinConexion.Text)) { }


            if (txtBasicasecundariaPCConConexion.Text == "") { txtBasicasecundariaPCConConexion.Text = "0"; }
            if (txtBasicasecundariaPortatilesConConexion.Text == "") { txtBasicasecundariaPortatilesConConexion.Text = "0"; }
            if (txtBasicasecundariaPortatilesSinConexion.Text == "") { txtBasicasecundariaPortatilesSinConexion.Text = "0"; }
            if (txtBasicaprimariaPortatilesSinConexion.Text == "") { txtBasicaprimariaPortatilesSinConexion.Text = "0"; }
            if (txtBasicasecundariaTabletsConConexion.Text == "") { txtBasicasecundariaTabletsConConexion.Text = "0"; }
            if (txtBasicasecundariaTabletsSinConexion.Text == "") { txtBasicasecundariaTabletsSinConexion.Text = "0"; }
            if (txtBasicasecundariaTablerosConConexion.Text == "") { txtBasicasecundariaTablerosConConexion.Text = "0"; }
            if (txtBasicasecundariaTablerosSinConexion.Text == "") { txtBasicasecundariaTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Básica secundaria", txtBasicasecundariaPCConConexion.Text, txtBasicasecundariaPCSinConexion.Text, txtBasicasecundariaPortatilesConConexion.Text, txtBasicasecundariaPortatilesSinConexion.Text, txtBasicasecundariaTabletsConConexion.Text, txtBasicasecundariaTabletsSinConexion.Text, txtBasicasecundariaTablerosConConexion.Text, txtBasicasecundariaTablerosSinConexion.Text)) { }

            if (txtMediaPCConConexion.Text == "") { txtMediaPCConConexion.Text = "0"; }
            if (txtMediaPCSinConexion.Text == "") { txtMediaPCSinConexion.Text = "0"; }
            if (txtMediaPortatilesConConexion.Text == "") { txtMediaPortatilesConConexion.Text = "0"; }
            if (txtMediaPortatilesSinConexion.Text == "") { txtMediaPortatilesSinConexion.Text = "0"; }
            if (txtMediaTabletsConConexion.Text == "") { txtMediaTabletsConConexion.Text = "0"; }
            if (txtMediaTabletsSinConexion.Text == "") { txtMediaTabletsSinConexion.Text = "0"; }
            if (txtMediaTablerosConConexion.Text == "") { txtMediaTablerosConConexion.Text = "0"; }
            if (txtMediaTablerosSinConexion.Text == "") { txtMediaTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Media", txtMediaPCConConexion.Text, txtMediaPCSinConexion.Text, txtMediaPortatilesConConexion.Text, txtMediaPortatilesSinConexion.Text, txtMediaTabletsConConexion.Text, txtMediaTabletsSinConexion.Text, txtMediaTablerosConConexion.Text, txtMediaTablerosSinConexion.Text)) { }

            if (txtNormalSuperiorPCConConexion.Text == "") { txtNormalSuperiorPCConConexion.Text = "0"; }
            if (txtNormalSuperiorPCSinConexion.Text == "") { txtNormalSuperiorPCSinConexion.Text = "0"; }
            if (txtNormalSuperiorPortatilesConConexion.Text == "") { txtNormalSuperiorPortatilesConConexion.Text = "0"; }
            if (txtNormalSuperiorPortatilesSinConexion.Text == "") { txtNormalSuperiorPortatilesSinConexion.Text = "0"; }
            if (txtNormalSuperiorTabletsConConexion.Text == "") { txtNormalSuperiorTabletsConConexion.Text = "0"; }
            if (txtNormalSuperiorTabletsSinConexion.Text == "") { txtNormalSuperiorTabletsSinConexion.Text = "0"; }
            if (txtNormalSuperiorTablerosConConexion.Text == "") { txtNormalSuperiorTablerosConConexion.Text = "0"; }
            if (txtNormalSuperiorTablerosSinConexion.Text == "") { txtNormalSuperiorTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Normal Superior", txtNormalSuperiorPCConConexion.Text, txtNormalSuperiorPCSinConexion.Text, txtNormalSuperiorPortatilesConConexion.Text, txtNormalSuperiorPortatilesSinConexion.Text, txtNormalSuperiorTabletsConConexion.Text, txtNormalSuperiorTabletsSinConexion.Text, txtNormalSuperiorTablerosConConexion.Text, txtNormalSuperiorTablerosSinConexion.Text)) { }

            if (txtEducaciondiscapacidadPCConConexion.Text == "") { txtEducaciondiscapacidadPCConConexion.Text = "0"; }
            if (txtEducaciondiscapacidadPCSinConexion.Text == "") { txtEducaciondiscapacidadPCSinConexion.Text = "0"; }
            if (txtEducaciondiscapacidadPortatilesConConexion.Text == "") { txtEducaciondiscapacidadPortatilesConConexion.Text = "0"; }
            if (txtEducaciondiscapacidadPortatilesSinConexion.Text == "") { txtEducaciondiscapacidadPortatilesSinConexion.Text = "0"; }
            if (txtEducaciondiscapacidadTabletsConConexion.Text == "") { txtEducaciondiscapacidadTabletsConConexion.Text = "0"; }
            if (txtEducaciondiscapacidadTabletsSinConexion.Text == "") { txtEducaciondiscapacidadTabletsSinConexion.Text = "0"; }
            if (txtEducaciondiscapacidadTablerosConConexion.Text == "") { txtEducaciondiscapacidadTablerosConConexion.Text = "0"; }
            if (txtEducaciondiscapacidadTablerosSinConexion.Text == "") { txtEducaciondiscapacidadTablerosSinConexion.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "111", "Educación discapacidad", txtEducaciondiscapacidadPCConConexion.Text, txtEducaciondiscapacidadPCSinConexion.Text, txtEducaciondiscapacidadPortatilesConConexion.Text, txtEducaciondiscapacidadPortatilesSinConexion.Text, txtEducaciondiscapacidadTabletsConConexion.Text, txtEducaciondiscapacidadTabletsSinConexion.Text, txtEducaciondiscapacidadTablerosConConexion.Text, txtEducaciondiscapacidadTablerosSinConexion.Text)) { }

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
           
        }
        else
        {
            mostrarmensaje("error", "Dede seleccionar una sede");
        }



    }

    protected void btnTercerGuardar_OnClick(Object sender, EventArgs e)
    {

        if (lblCodSedeinsAsesor.Text != "")
        {
           

            //Pregunta 1.1.2

            if (lb.eliminarRespuestasInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112")) { } //CodregInstitución, codinstrumento, codpregunta

            if (txtPreescolarPCConConexionFuera.Text == "") { txtPreescolarPCConConexionFuera.Text = "0"; }
            if (txtPreescolarPCSinConexionFuera.Text == "") { txtPreescolarPCSinConexionFuera.Text = "0"; }
            if (txtPreescolarPortatilesConConexionFuera.Text == "") { txtPreescolarPortatilesConConexionFuera.Text = "0"; }
            if (txtPreescolarPortatilesSinConexionFuera.Text == "") { txtPreescolarPortatilesSinConexionFuera.Text = "0"; }
            if (txtPreescolarTabletsConConexionFuera.Text == "") { txtPreescolarTabletsConConexionFuera.Text = "0"; }
            if (txtPreescolarTabletsSinConexionFuera.Text == "") { txtPreescolarTabletsSinConexionFuera.Text = "0"; }
            if (txtPreescolarTablerosConConexionFuera.Text == "") { txtPreescolarTablerosConConexionFuera.Text = "0"; }
            if (txtPreescolarTablerosSinConexionFuera.Text == "") { txtPreescolarTablerosSinConexionFuera.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Preescolar", txtPreescolarPCConConexionFuera.Text, txtPreescolarPCSinConexionFuera.Text, txtPreescolarPortatilesConConexionFuera.Text, txtPreescolarPortatilesSinConexionFuera.Text, txtPreescolarTabletsConConexionFuera.Text, txtPreescolarTabletsSinConexionFuera.Text, txtPreescolarTablerosConConexionFuera.Text, txtPreescolarTablerosSinConexionFuera.Text)) { }

            if (txtBasicaprimariaPCConConexionFuera.Text == "") { txtBasicaprimariaPCConConexionFuera.Text = "0"; }
            if (txtBasicaprimariaPCSinConexionFuera.Text == "") { txtBasicaprimariaPCSinConexionFuera.Text = "0"; }
            if (txtBasicaprimariaPortatilesConConexionFuera.Text == "") { txtBasicaprimariaPortatilesConConexionFuera.Text = "0"; }
            if (txtBasicaprimariaPortatilesSinConexionFuera.Text == "") { txtBasicaprimariaPortatilesSinConexionFuera.Text = "0"; }
            if (txtBasicaprimariaTabletsConConexionFuera.Text == "") { txtBasicaprimariaTabletsConConexionFuera.Text = "0"; }
            if (txtBasicaprimariaTabletsSinConexionFuera.Text == "") { txtBasicaprimariaTabletsSinConexionFuera.Text = "0"; }
            if (txtBasicaprimariaTablerosConConexionFuera.Text == "") { txtBasicaprimariaTablerosConConexionFuera.Text = "0"; }
            if (txtBasicaprimariaTablerosSinConexionFuera.Text == "") { txtBasicaprimariaTablerosSinConexionFuera.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Básica primaria", txtBasicaprimariaPCConConexionFuera.Text, txtBasicaprimariaPCSinConexionFuera.Text, txtBasicaprimariaPortatilesConConexionFuera.Text, txtBasicaprimariaPortatilesSinConexionFuera.Text, txtBasicaprimariaTabletsConConexionFuera.Text, txtBasicaprimariaTabletsSinConexionFuera.Text, txtBasicaprimariaTablerosConConexionFuera.Text, txtBasicaprimariaTablerosSinConexionFuera.Text)) { }

            if (txtBasicasecundariaPCConConexionFuera.Text == "") { txtBasicasecundariaPCConConexionFuera.Text = "0"; }
            if (txtBasicasecundariaPCSinConexionFuera.Text == "") { txtBasicasecundariaPCSinConexionFuera.Text = "0"; }
            if (txtBasicasecundariaPortatilesConConexionFuera.Text == "") { txtBasicasecundariaPortatilesConConexionFuera.Text = "0"; }
            if (txtBasicasecundariaPortatilesSinConexionFuera.Text == "") { txtBasicasecundariaPortatilesSinConexionFuera.Text = "0"; }
            if (txtBasicasecundariaTabletsConConexionFuera.Text == "") { txtBasicasecundariaTabletsConConexionFuera.Text = "0"; }
            if (txtBasicasecundariaTabletsSinConexionFuera.Text == "") { txtBasicasecundariaTabletsSinConexionFuera.Text = "0"; }
            if (txtBasicasecundariaTablerosConConexionFuera.Text == "") { txtBasicasecundariaTablerosConConexionFuera.Text = "0"; }
            if (txtBasicasecundariaTablerosSinConexionFuera.Text == "") { txtBasicasecundariaTablerosSinConexionFuera.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Básica secundaria", txtBasicasecundariaPCConConexionFuera.Text, txtBasicasecundariaPCSinConexionFuera.Text, txtBasicasecundariaPortatilesConConexionFuera.Text, txtBasicasecundariaPortatilesSinConexionFuera.Text, txtBasicasecundariaTabletsConConexionFuera.Text, txtBasicasecundariaTabletsSinConexionFuera.Text, txtBasicasecundariaTablerosConConexionFuera.Text, txtBasicasecundariaTablerosSinConexionFuera.Text)) { }

            if (txtMediaPCConConexionFuera.Text == "") { txtMediaPCConConexionFuera.Text = "0"; }
            if (txtMediaPCSinConexionFuera.Text == "") { txtMediaPCSinConexionFuera.Text = "0"; }
            if (txtMediaPortatilesConConexionFuera.Text == "") { txtMediaPortatilesConConexionFuera.Text = "0"; }
            if (txtMediaPortatilesSinConexionFuera.Text == "") { txtMediaPortatilesSinConexionFuera.Text = "0"; }
            if (txtMediaTabletsConConexionFuera.Text == "") { txtMediaTabletsConConexionFuera.Text = "0"; }
            if (txtMediaTabletsSinConexionFuera.Text == "") { txtMediaTabletsSinConexionFuera.Text = "0"; }
            if (txtMediaTablerosConConexionFuera.Text == "") { txtMediaTablerosConConexionFuera.Text = "0"; }
            if (txtMediaTablerosSinConexionFuera.Text == "") { txtMediaTablerosSinConexionFuera.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Media", txtMediaPCConConexionFuera.Text, txtMediaPCSinConexionFuera.Text, txtMediaPortatilesConConexionFuera.Text, txtMediaPortatilesSinConexionFuera.Text, txtMediaTabletsConConexionFuera.Text, txtMediaTabletsSinConexionFuera.Text, txtMediaTablerosConConexionFuera.Text, txtMediaTablerosSinConexionFuera.Text)) { }

            if (txtNormalSuperiorPCConConexionFuera.Text == "") { txtNormalSuperiorPCConConexionFuera.Text = "0"; }
            if (txtNormalSuperiorPCSinConexionFuera.Text == "") { txtNormalSuperiorPCSinConexionFuera.Text = "0"; }
            if (txtNormalSuperiorPortatilesConConexionFuera.Text == "") { txtNormalSuperiorPortatilesConConexionFuera.Text = "0"; }
            if (txtNormalSuperiorPortatilesSinConexionFuera.Text == "") { txtNormalSuperiorPortatilesSinConexionFuera.Text = "0"; }
            if (txtNormalSuperiorTabletsConConexionFuera.Text == "") { txtNormalSuperiorTabletsConConexionFuera.Text = "0"; }
            if (txtNormalSuperiorTabletsSinConexionFuera.Text == "") { txtNormalSuperiorTabletsSinConexionFuera.Text = "0"; }
            if (txtNormalSuperiorTablerosConConexionFuera.Text == "") { txtNormalSuperiorTablerosConConexionFuera.Text = "0"; }
            if (txtNormalSuperiorTablerosSinConexionFuera.Text == "") { txtNormalSuperiorTablerosSinConexionFuera.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Normal Superior", txtNormalSuperiorPCConConexionFuera.Text, txtNormalSuperiorPCSinConexionFuera.Text, txtNormalSuperiorPortatilesConConexionFuera.Text, txtNormalSuperiorPortatilesSinConexionFuera.Text, txtNormalSuperiorTabletsConConexionFuera.Text, txtNormalSuperiorTabletsSinConexionFuera.Text, txtNormalSuperiorTablerosConConexionFuera.Text, txtNormalSuperiorTablerosSinConexionFuera.Text)) { }

            if (txtEducaciondiscapacidadPCConConexionFuera.Text == "") { txtEducaciondiscapacidadPCConConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadPCSinConexionFuera.Text == "") { txtEducaciondiscapacidadPCSinConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadPortatilesConConexionFuera.Text == "") { txtEducaciondiscapacidadPortatilesConConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadPortatilesSinConexionFuera.Text == "") { txtEducaciondiscapacidadPortatilesSinConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadTabletsConConexionFuera.Text == "") { txtEducaciondiscapacidadTabletsConConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadTabletsSinConexionFuera.Text == "") { txtEducaciondiscapacidadTabletsSinConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadTablerosConConexionFuera.Text == "") { txtEducaciondiscapacidadTablerosConConexionFuera.Text = "0"; }
            if (txtEducaciondiscapacidadTablerosSinConexionFuera.Text == "") { txtEducaciondiscapacidadTablerosSinConexionFuera.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICS(lblCodSedeinsAsesor.Text, "3", "112", "Educación discapacidad", txtEducaciondiscapacidadPCConConexionFuera.Text, txtEducaciondiscapacidadPCSinConexionFuera.Text, txtEducaciondiscapacidadPortatilesConConexionFuera.Text, txtEducaciondiscapacidadPortatilesSinConexionFuera.Text, txtEducaciondiscapacidadTabletsConConexion.Text, txtEducaciondiscapacidadTabletsSinConexionFuera.Text, txtEducaciondiscapacidadTablerosConConexionFuera.Text, txtEducaciondiscapacidadTablerosSinConexionFuera.Text)) { }

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
          
        }
        else
        {
            mostrarmensaje("error", "Dede seleccionar una sede");
        }



    }

    protected void btnCuartoGuardar_OnClick(Object sender, EventArgs e)
    {

        if (lblCodSedeinsAsesor.Text != "")
        {
            //Pregunta 1.2
            if (lb.eliminarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2")) { }

            if (txtLudotecasPC.Text == "") { txtLudotecasPC.Text = "0"; }
            if (txtBibliotecaPC.Text == "") { txtBibliotecaPC.Text = "0"; }
            if (txtSalonesPC.Text == "") { txtSalonesPC.Text = "0"; }
            if (txtAulasPC.Text == "") { txtAulasPC.Text = "0"; }
            if (txtOtrosPC.Text == "") { txtOtrosPC.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "PC", txtLudotecasPC.Text, txtBibliotecaPC.Text, txtSalonesPC.Text, txtAulasPC.Text, txtOtrosPC.Text)) { }

            if (txtLudotecaPortatil.Text == "") { txtLudotecaPortatil.Text = "0"; }
            if (txtBibliotecaPortatil.Text == "") { txtBibliotecaPortatil.Text = "0"; }
            if (txtSalonesPortatil.Text == "") { txtSalonesPortatil.Text = "0"; }
            if (txtAulasPortatil.Text == "") { txtAulasPortatil.Text = "0"; }
            if (txtOtrosPortatil.Text == "") { txtOtrosPortatil.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "Portátil", txtLudotecaPortatil.Text, txtBibliotecaPortatil.Text, txtSalonesPortatil.Text, txtAulasPortatil.Text, txtOtrosPortatil.Text)) { }

            if (txtLudotecaTablet.Text == "") { txtLudotecaTablet.Text = "0"; }
            if (txtBibliotecaTablet.Text == "") { txtBibliotecaTablet.Text = "0"; }
            if (txtSalonesTablet.Text == "") { txtSalonesTablet.Text = "0"; }
            if (txtAulasTablet.Text == "") { txtAulasTablet.Text = "0"; }
            if (txtOtrosTablet.Text == "") { txtOtrosTablet.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "Tablet", txtLudotecaTablet.Text, txtBibliotecaTablet.Text, txtSalonesTablet.Text, txtAulasTablet.Text, txtOtrosTablet.Text)) { }

            if (txtLudotecaTableros.Text == "") { txtLudotecaTableros.Text = "0"; }
            if (txtBibliotecaTableros.Text == "") { txtBibliotecaTableros.Text = "0"; }
            if (txtSalonesTableros.Text == "") { txtSalonesTableros.Text = "0"; }
            if (txtAulasTableros.Text == "") { txtAulasTableros.Text = "0"; }
            if (txtOtrosTableros.Text == "") { txtOtrosTableros.Text = "0"; }
            if (lb.agregarRespuestaInstrumento03TICSPregunta1_2(lblCodSedeinsAsesor.Text, "3", "1.2", "Tableros", txtLudotecaTableros.Text, txtBibliotecaTableros.Text, txtSalonesTableros.Text, txtAulasTableros.Text, txtOtrosTableros.Text)) { }

            ValidarGridPreguntasIntrumento03(lblCodSedeinsAsesor.Text);

            //1.3
            AgregarSoftEducativo(lblCodSedeinsAsesor.Text);

            //1.4
            AgregarHerramientasDisponeIE(lblCodSedeinsAsesor.Text);

            //2
            //2.1
            AgregarPregunta2_1Instrumento03(lblCodSedeinsAsesor.Text);

            //2.2
            AgregarPregunta2_2Instrumento03(lblCodSedeinsAsesor.Text);

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            mostrarmensaje("error", "Dede seleccionar una sede");
        }



    }

    //Intermedia

    [WebMethod(EnableSession = true)]
    public static string cargarinfoinstitucion()
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataRow datoie = inst.buscarInstitucionxNitTodo(HttpContext.Current.Session["dane"].ToString());

        if (datoie != null)
        {
            ca = "true&" + datoie["codigo"].ToString() + "&";
            ca += "<tr><td>" + datoie["dane"].ToString() + "</td>";
            ca += "<td>" + datoie["nombre"].ToString() + "</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarasesores()
    {
        string ca = "";

        Asesores ase = new Asesores();
        DataTable datos = ase.cargarAsesores();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "true&";
            ca += "<option value='0' disabled selected>Seleccione asesor</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarasesor(string codinstitucion)
    {
        string ca = "";
        string val = "0";
        Asesores ase = new Asesores();
        DataTable datos = ase.cargarAsesores();
        DataRow datoie = ase.buscarasesorlineabase(HttpContext.Current.Session["dane"].ToString());

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione asesor</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datoie != null)
                {
                    if (datos.Rows[i]["codigo"].ToString() == datoie["codasesor"].ToString())
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "' selected>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                        val = "1";
                    }
                    else
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                    }
                }
            }
        }

        if (val == "1")
        {
            ca += "&true";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarsedes(string codinstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataTable datose = inst.cargarSedesInstitucion(codinstitucion);

        if (datose != null && datose.Rows.Count > 0)
        {
            ca = "true&";
            for (int i = 0; i < datose.Rows.Count; i++)
            {
                ca += "<tr><td>" + datose.Rows[i]["nit"].ToString() + "</td>";
                ca += "<td>" + datose.Rows[i]["consesede"].ToString() + "</td>";
                ca += "<td>" + datose.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td><br /><a onclick='disponibilidad(" + datose.Rows[i]["cod"].ToString() + ")' class='btn btn-success' >Disponibilidad</a><br /><br /></td></tr>";
            }
           
        }

        return ca;
    }

     [WebMethod(EnableSession = true)]
    public static string cargarsedesxcod(string codsede)
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataRow datose = inst.cargarSedesInstitucionxCodSede(codsede);

        if (datose != null )
        {
            ca += "true&";
            ca += "<tr><td>" + datose["nit"].ToString() + "</td>";
            ca += "<td>" + datose["consesede"].ToString() + "</td>";
            ca += "<td>" + datose["nombre"].ToString() + "</td>";
            ca += "</tr>";
        }

        return ca;
    }

     [WebMethod(EnableSession = true)]
     public static string cargarequipamientoxsede(string codsede)
     {
         string ca = "";

         LineaBase lb = new LineaBase();

         DataRow sede = lb.buscarSedexInsasesor(codsede);

         if (sede != null)
         {
             ca = "true&";
             DataTable equipamiento = lb.RespuestaInstrumento03TICS_Fase(sede["codigo"].ToString(), "3", "1.1","intermedia");

             if (equipamiento != null && equipamiento.Rows.Count > 0)
             {
                 for (int i = 0; i < equipamiento.Rows.Count; i++)
                 {
                     switch (equipamiento.Rows[i]["nombre"].ToString()){
                         case "Docentes":
                             ca += equipamiento.Rows[i]["conpc"].ToString() + "&";//1
                             ca += equipamiento.Rows[i]["sinpc"].ToString() + "&";//2
                             ca += equipamiento.Rows[i]["conportatil"].ToString() + "&";//3
                             ca += equipamiento.Rows[i]["sinportatil"].ToString() + "&";//4
                             ca += equipamiento.Rows[i]["contablet"].ToString() + "&";//5
                             ca += equipamiento.Rows[i]["sintablet"].ToString() + "&";//6
                             ca += equipamiento.Rows[i]["contableros"].ToString() + "&";//7
                             ca += equipamiento.Rows[i]["sintableros"].ToString() + "&";//8
                         break;

                         case "Estudiantes":
                              ca += equipamiento.Rows[i]["conpc"].ToString() + "&";//9
                             ca += equipamiento.Rows[i]["sinpc"].ToString() + "&";//10
                             ca += equipamiento.Rows[i]["conportatil"].ToString() + "&";//11
                             ca += equipamiento.Rows[i]["sinportatil"].ToString() + "&";//12
                             ca += equipamiento.Rows[i]["contablet"].ToString() + "&";//13
                             ca += equipamiento.Rows[i]["sintablet"].ToString() + "&";//14
                             ca += equipamiento.Rows[i]["contableros"].ToString() + "&";//15
                             ca += equipamiento.Rows[i]["sintableros"].ToString() + "&";//16
                         break;
                     }
                 }
                 ca += sede["codigo"].ToString() + "&";//17
             }

             DataRow preg6 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "6", "0", "intermedia");
             if (preg6 != null)
             {
                 ca += preg6["respuesta"].ToString() + "&";//18
             }

             DataRow preg7 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "7", "1", "intermedia");
             if (preg7 != null)
             {
                 ca += preg7["respuesta"].ToString() + "&";//19
             }

             DataRow preg8 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "8", "0", "intermedia");
             if (preg8 != null)
             {
                 ca += preg8["respuesta"].ToString() + "&";//20
             }

             DataRow preg9 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "9", "1", "intermedia");
             if (preg9 != null)
             {
                 ca += preg9["respuesta"].ToString() + "&";//21
             }

             DataRow preg12 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "1", "2", "intermedia");
             if (preg12 != null)
             {
                 ca += preg12["respuesta"].ToString() + "&";//22
             }

             DataRow preg21 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "2", "1", "intermedia");
             if (preg21 != null)
             {
                 ca += preg21["respuesta"].ToString() + "&";//23
             }

             DataRow preg22 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "2", "2", "intermedia");
             if (preg22 != null)
             {
                 ca += preg22["respuesta"].ToString() + "&";//24
             }

             //Pregunta 1.2

             DataTable resp12 = lb.RespuestasInstrumento03HerramientasDispone_Fase(sede["codigo"].ToString(), "3", "1.2", "intermedia");
             if (resp12 != null && resp12.Rows.Count > 0)
             {
                 for (int i = 0; i < resp12.Rows.Count; i++)
                 {
                     //Desde el 25 hasta el 34
                     ca += resp12.Rows[i]["tipo"].ToString() + "&";
                     ca += resp12.Rows[i]["direccion"].ToString() + "&";
                 }
             }

             //Preguntas abiertas

             DataTable resp12abierta = lb.cargarRespuestaAbierta_Fase(sede["codigo"].ToString(), "1.2", "3", "intermedia");
             if (resp12abierta != null && resp12abierta.Rows.Count > 0)
             {
                 for (int i = 0; i < resp12abierta.Rows.Count; i++)
                 {
                     ca += resp12abierta.Rows[i]["comentario"].ToString() + "&";//35
                 }
             }

             DataTable resp21abierta = lb.cargarRespuestaAbierta_Fase(sede["codigo"].ToString(), "2.1", "3", "intermedia");
             if (resp21abierta != null && resp21abierta.Rows.Count > 0)
             {
                 for (int i = 0; i < resp21abierta.Rows.Count; i++)
                 {
                     ca += resp21abierta.Rows[i]["comentario"].ToString() + "&";//36, 37, 38
                 }
             }

             DataTable resp22abierta = lb.cargarRespuestaAbierta_Fase(sede["codigo"].ToString(), "2.2", "3", "intermedia");
             if (resp22abierta != null && resp22abierta.Rows.Count > 0)
             {
                 for (int i = 0; i < resp22abierta.Rows.Count; i++)
                 {
                     ca += resp22abierta.Rows[i]["comentario"].ToString() + "&";//39, 40, 41
                 }
             }

             DataRow preg7_2 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "7", "2", "intermedia");
             if (preg7_2 != null)
             {
                 ca += preg7_2["respuesta"].ToString() + "&";//42
             }

             DataRow preg7_3 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "7", "3", "intermedia");
             if (preg7_3 != null)
             {
                 ca += preg7_3["respuesta"].ToString() + "&";//43
             }

             DataRow preg9_2 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "9", "2", "intermedia");
             if (preg9_2 != null)
             {
                 ca += preg9_2["respuesta"].ToString() + "&";//44
             }

             DataRow preg9_3 = lb.cargarRespuestasCerradasInstrumento03_Fase(sede["codigo"].ToString(), "3", "9", "3", "intermedia");
             if (preg9_3 != null)
             {
                 ca += preg9_3["respuesta"].ToString() + "&";//45
             }

         }
         else
         {
             ca = "false&Error, esta sede debe diligenciar el instrumento C600B de la Linea Base";
         }

         return ca;
     }

     [WebMethod(EnableSession = true)]
     public static string guardardatos(string tipo, string codinsasesor, string codsede, string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8)
     {
         string ca = "";

         LineaBase lb = new LineaBase();

         DataRow sedeasesor = lb.buscarSedexInsasesor(codsede);

            if (txt1 == "") { txt1 = "0"; }
            if (txt2 == "") { txt2 = "0"; }
            if (txt3 == "") { txt3 = "0"; }
            if (txt4 == "") { txt4 = "0"; }
            if (txt5 == "") { txt5 = "0"; }
            if (txt6 == "") { txt6 = "0"; }
            if (txt7 == "") { txt7 = "0"; }
            if (txt8 == "") { txt8 = "0"; }

         

            switch (tipo)
            {
                case "docentes":

                    if (sedeasesor != null)
                    {
                        lb.editarsedeasesor(codinsasesor, codsede);
                        lb.eliminarRespuestasInstrumento03TICS_Fase(sedeasesor["codigo"].ToString(), "3", "1.1", "intermedia");
                        if (lb.agregarRespuestaInstrumento03TICS_Fase(sedeasesor["codigo"].ToString(), "3", "1.1", "Docentes", txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, "intermedia")) { }
                    }
                    else
                    {
                        DataRow insert = lb.agregarSedeInsasesor(codsede, codinsasesor);
                        if (lb.agregarRespuestaInstrumento03TICS_Fase(insert["codigo"].ToString(), "3", "1.1", "Docentes", txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, "intermedia")) { }
                    }

                    break;
                case "estudiantes":

                    if (sedeasesor != null)
                    {
                        lb.editarsedeasesor(codinsasesor, codsede);
                        if (lb.agregarRespuestaInstrumento03TICS_Fase(sedeasesor["codigo"].ToString(), "3", "1.1", "Estudiantes", txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, "intermedia")) { }
                    }
                    else
                    {
                        DataRow insert = lb.agregarSedeInsasesor(codsede, codinsasesor);
                        if (lb.agregarRespuestaInstrumento03TICS_Fase(insert["codigo"].ToString(), "3", "1.1", "Estudiantes", txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, "intermedia")) { }
                    }

                    break;
            }

         

        

         return ca;
     }

     [WebMethod(EnableSession = true)]
     public static string guardardatospreguntascerradas(string codinsasesor, string codsede, string dotaciontablet, string usodotaciontabletg, string usodotaciontabletr, string usodotaciontabletm, string conectividad, string funconectividadg, string funconectividadr, string funconectividadm, string platapedago, string proceformtic, string planmejortic)
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         DataRow sedeasesor = lb.buscarSedexInsasesor(codsede);

         if (sedeasesor != null)
         {
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "6", "3", "0", "intermedia");
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "7", "3", "0", "intermedia");
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "8", "3", "0", "intermedia");
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "9", "3", "0", "intermedia");
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "1", "3", "2", "intermedia");
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "2", "3", "1", "intermedia");
             lb.eliminarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "2", "3", "2", "intermedia");

             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "6", dotaciontablet, "3", "0","intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "7", usodotaciontabletg, "3", "1", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "7", usodotaciontabletr, "3", "2", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "7", usodotaciontabletm, "3", "3", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "8", conectividad, "3", "0", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "9", funconectividadg, "3", "1", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "9", funconectividadr, "3", "2", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "9", funconectividadm, "3", "3", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "1", platapedago, "3", "2", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "2", proceformtic, "3", "1", "intermedia");
             lb.AgregarRespuestaCerradaSede_Fase(sedeasesor["codigo"].ToString(), "2", planmejortic, "3", "2", "intermedia");
         }

         return ca;
     }

     [WebMethod(EnableSession = true)]
     public static string guardardatosherramientasdispoie(string codinsasesor, string codsede, string herramientas1, string direccion1, string herramientas2, string direccion2, string herramientas3, string direccion3, string herramientas4, string direccion4, string herramientas5, string direccion5)
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         DataRow sedeasesor = lb.buscarSedexInsasesor(codsede);

         if (sedeasesor != null)
         {
             lb.eliminarRespuestaInstrumento03HerramientasDisponibles_Fase(sedeasesor["codigo"].ToString(), "3", "1.2", "intermedia");

             lb.AgregarRespuestaInstrumento03HerramientasDisponibles_Fase(sedeasesor["codigo"].ToString(), "1.2", "3", herramientas1, direccion1, "intermedia");
             lb.AgregarRespuestaInstrumento03HerramientasDisponibles_Fase(sedeasesor["codigo"].ToString(), "1.2", "3", herramientas2, direccion2, "intermedia");
             lb.AgregarRespuestaInstrumento03HerramientasDisponibles_Fase(sedeasesor["codigo"].ToString(), "1.2", "3", herramientas3, direccion3, "intermedia");
             lb.AgregarRespuestaInstrumento03HerramientasDisponibles_Fase(sedeasesor["codigo"].ToString(), "1.2", "3", herramientas4, direccion4, "intermedia");
             lb.AgregarRespuestaInstrumento03HerramientasDisponibles_Fase(sedeasesor["codigo"].ToString(), "1.2", "3", herramientas5, direccion5, "intermedia");

            
         }

         return ca;
     }

     [WebMethod(EnableSession = true)]
     public static string guardardatospreguntasabiertas(string codinsasesor, string codsede, string textplatapedago, string nomproceform, string duraproceform, string totalproceform, string incluplanmejortic, string desaplanmejortic, string efectplanmejortic)
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         DataRow sedeasesor = lb.buscarSedexInsasesor(codsede);

         if (sedeasesor != null)
         {
             lb.eliminarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "1.2", "3", "intermedia");
             lb.eliminarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.1", "3", "intermedia");
             lb.eliminarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.2", "3", "intermedia");


             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(),"1.2",textplatapedago,"3", "intermedia");
             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.1", nomproceform, "3", "intermedia");
             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.1", duraproceform, "3", "intermedia");
             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.1", totalproceform, "3", "intermedia");
             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.2", incluplanmejortic, "3", "intermedia");
             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.2", desaplanmejortic, "3", "intermedia");
             lb.AgregarRespuestaAbiertaSede_Fase(sedeasesor["codigo"].ToString(), "2.2", efectplanmejortic, "3", "intermedia");

         }

         return ca;
     }
}