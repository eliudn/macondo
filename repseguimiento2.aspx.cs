using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class repseguimiento2 : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Institucion inst = new Institucion();
    Usuario usu = new Usuario();

    int totals004;
    int totalfotos;
    int totallistado;
    int totalevaluacion;
    int totalrelatoria;
    int totalgrupos;
    int totalmesas;
    int totalmaterial;
    

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            ddDepartamentos(dropDepartamento);
            //ddMomentos(dropMomentos);
            ddAnio(dropAnio);
        }
    }

    private void ddInstituciones(DropDownList drop, string codmunicipio)
    {
        drop.DataSource = inst.cargarInstitucionxMunicipio(codmunicipio);
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddDepartamentos(DropDownList drop)
    {
        drop.DataSource = inst.cargarDepartamentoMagdalena();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

    }
    private void ddMunicipios(DropDownList drop, string coddepartamento)
    {
        drop.DataSource = inst.cargarciudadxDepartamento(coddepartamento);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void dropDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddMunicipios(dropMunicipio, dropDepartamento.SelectedValue);
        
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);
       
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);
      
    }
    private void ddSedes(DropDownList drop, string codinstitucion)
    {
        drop.DataSource = inst.cargarSedesInstitucion(codinstitucion);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }

    //protected void dropMomento_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddSesiones(dropMomentos.SelectedValue, dropSesion);
    //}

    //protected void dropSesion_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddJornadas(dropSesion.SelectedValue, dropJornada);
    //}

  
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = inst.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void ddMomentos(DropDownList drop)
    {
        drop.DataSource = est.cargarMomentosEstra1();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void ddSesiones(string momento, DropDownList drop)
    {
        ListItemCollection collection = new ListItemCollection();

        if (momento == "1")
        {
            collection.Add(new ListItem("1"));
        }

        if (momento == "3")
        {
            collection.Add(new ListItem("2"));
        }

        if (momento == "4")
        {
            collection.Add(new ListItem("3"));
            collection.Add(new ListItem("4"));
            collection.Add(new ListItem("5"));
            collection.Add(new ListItem("6"));
        }

        if (momento == "5")
        {
            collection.Add(new ListItem("7"));
        }

        if (momento == "6")
        {
            collection.Add(new ListItem("8"));
        }
        //Pass ListItemCollection as datasource
        drop.DataSource = collection;
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }


    private void ddJornadas(string sesion, DropDownList drop)
    {
        ListItemCollection collection = new ListItemCollection();

        if(sesion == "1")
        {
            collection.Add(new ListItem("1"));
            collection.Add(new ListItem("2"));
        }

        if (sesion == "2")
        {
            collection.Add(new ListItem("3"));
            collection.Add(new ListItem("4"));
        }

        if (sesion == "3")
        {
            collection.Add(new ListItem("5"));
            collection.Add(new ListItem("6"));
        }

       if (sesion == "4")
        {
            collection.Add(new ListItem("7"));
            collection.Add(new ListItem("8"));
        }

       if (sesion == "5")
       {
           collection.Add(new ListItem("9"));
           collection.Add(new ListItem("10"));
       }

       if (sesion == "6")
       {
           collection.Add(new ListItem("11"));
           collection.Add(new ListItem("12"));
       }

       if (sesion == "7")
       {
           collection.Add(new ListItem("13"));
           collection.Add(new ListItem("14"));
       }
       

       if (sesion == "8")
       {
           collection.Add(new ListItem("15"));
           collection.Add(new ListItem("16"));
       }
        //Pass ListItemCollection as datasource
        drop.DataSource = collection;
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void lnkBuscar_Click(object sender, EventArgs e)
    {
        //cargarSeguimiento(dropAnio.SelectedItem.ToString(), dropMomentos.SelectedValue, dropSesion.SelectedValue, dropJornada.SelectedValue);
        cargarSeguimiento(dropAnio.SelectedItem.ToString(), dropSedes.SelectedValue);
    }

    private void cargarSeguimiento(string codanio, string codsede)
    //private void cargarSeguimiento(string codanio, string codmomento, string codsesion, string codjornada)
    {
        string ca = "";

        DataRow anio = est.buscarCodAnioxNombre(codanio);

        //DataTable asesores = est.listarAsesoresSeguimientoxAnio("2", anio["codigo"].ToString());
        //DataTable asesores = est.listarAsesoresSeguimiento("2");
        //DataTable sedes = inst.cargarSedesInstitucion(codsede);

        //if (sedes != null && sedes.Rows.Count > 0)
        //{
            ca += lineaEncabezado();
            ca += "<tbody>";
            //for (int i = 0; i < sedes.Rows.Count; i++)
            //{
               
                //ca += "<td>" + sedes.Rows[i]["asesor"].ToString() + "</td>";
                //ca += "<td align='center'>" + dropMomentos.SelectedItem.ToString() + "</td>";
                //ca += "<td align='center'>" + dropSesion.SelectedItem.ToString() + "</td>";
                //ca += "<td align='center'>" + dropJornada.SelectedItem.ToString() + "</td>";
                //ca +=  memoriasS004(asesores.Rows[i]["codigo"].ToString(), dropMomentos.SelectedValue, dropSesion.SelectedValue, dropJornada.SelectedValue, codanio);
                ca += memoriasS004(codsede, codanio);

                //ca += "<td align='center'>" + usuariolog(sedes.Rows[i]["identificacion"].ToString()) + "</td>";
            //}
              
           

            ca += "<tr style='font-weight:bold;'>";
            ca += "<td colspan='3' align='center'>TOTAL:</td>";
            ca += "<td align='center'>" + totals004 + "</td>";
            ca += "<td align='center'>" + totalfotos + "</td>";
            ca += "<td align='center'>" + totallistado + "</td>";
            ca += "<td align='center'>" + totalevaluacion + "</td>";
            ca += "<td align='center'>" + totalrelatoria + "</td>";
            ca += "<td align='center'>" + totalgrupos + "</td>";
            ca += "<td align='center'>" + totalmesas + "</td>";
            //ca += "<td align='center'>" + totalmaterial + "</td>";
            ca += "</tr>";
            ca += "</tbody>";
            ca += "</table>";

        //}
        lblResultado.Text = ca;
    }

    private string lineaEncabezado()
    {
        string ca = "";

        ca += "<table class='mGridTesoreria'><tr>";
        ca += "<thead>";
        ca += "<th>Municipio</th>";
        ca += "<th>Institución</th>";
        ca += "<th>Sede</th>";
        //ca += "<th>Asesor</th>";
        ca += "<th>Memorias de sesión S004</th>";
        ca += "<th>Evidencias de la memoria (Fotos)</th>";
        ca += "<th>Listado de asistencia</th>";
        ca += "<th>Formato de evaluación</th>";
        ca += "<th>Relatoria institucional</th>";
        ca += "<th>Grupo de investigación</th>";
        ca += "<th>Mesa de trabajo</th>";
        //ca += "<th>Entrega de materiales</th>";
        //ca += "<th>Fecha ultimo ingreso</th>";

        //ca += "<th>Total </th>";
        //ca += "<th>Sesión de formación</th>";
        //ca += "<th>Jornada desarrollada</th>";
       
        //ca += "<th>Evidencias de la memoria (Fotos)</th>";
        //ca += "<th>Listado de asistencia</th>";
        //ca += "<th>Formato de evaluación</th>";
        //ca += "<th>Relatoria institucional</th>";
        //
        
        ca += "</thead>";
        ca += "</tr>";

        return ca;
    }

    private string usuariolog(string id)
    {
        string ca = "";

        DataRow usuario = usu.buscarUltimoAccesoUsuarioLog(id);

        if (usuario != null)
        {
            ca = usuario["fecha"].ToString();
        }



        return ca;
    }
    int contador = 0;
    //private string memoriasS004(string codasesorcoordinador,string momento, string sesion, string jornada, string anio)
    private string memoriasS004(string codsede, string anio)
    {
        string ca = "";

        //DataTable count = est.cargarListadoMemoriasS004SedesSeguimiento(codasesorcoordinador,"2",momento,sesion,jornada, anio);
        DataTable count = est.cargarListadoMemoriasS004SedesSeguimiento("2", codsede, anio);

        if (count != null && count.Rows.Count > 0)
        {
            //ca = "<td align='center'>" + count.Rows.Count.ToString() + "</td>";
            int val = 0;   
            for(int i = 0; i < count.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td >" + count.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td >" + count.Rows[i]["nombreinstitucion"].ToString() + "</td>";
                ca += "<td >" + count.Rows[i]["nombresede"].ToString() + "</td>";
                //ca += "<td >" + count.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td align='center'>" + count.Rows[i]["total"].ToString() + "</td>";
                //ca += "<td align='center'>" + count.Rows[i]["momento"].ToString() + "</td>";
                //ca += "<td align='center'>" + count.Rows[i]["sesion"].ToString() + "</td>";
                //ca += "<td align='center'>" + count.Rows[i]["jornada"].ToString() + "</td>";
                //if (val == 0)
                //{
                if (codsede == "Todos")
                {
                    ca += evidenciasmemoriasS004(count.Rows[i]["codsede"].ToString(), "Fotos");
                    ca += evidenciasmemoriasS004(count.Rows[i]["codsede"].ToString(), "Lista de Asistencia");
                    ca += evidenciasmemoriasS004(count.Rows[i]["codsede"].ToString(), "Formato de evaluación");
                    ca += evidenciasmemoriasS004(count.Rows[i]["codsede"].ToString(), "Relatoria institucional");
                    ca += "<td align='center'>" + grupoinvestigacion(count.Rows[i]["codsede"].ToString(), anio) + "</td>";
                    ca += "<td align='center'>" + mesadetrabajo(count.Rows[i]["codsede"].ToString(), anio) + "</td>";
                }
                else
                {
                    ca += evidenciasmemoriasS004(codsede, "Fotos");
                    ca += evidenciasmemoriasS004(codsede, "Lista de Asistencia");
                    ca += evidenciasmemoriasS004(codsede, "Formato de evaluación");
                    ca += evidenciasmemoriasS004(codsede, "Relatoria institucional");
                    ca += "<td align='center'>" + grupoinvestigacion(codsede, anio) + "</td>";
                    ca += "<td align='center'>" + mesadetrabajo(codsede, anio) + "</td>";
                }
                    

                    //ca += evidenciasmemoriasS004(count.Rows[i]["codigo"].ToString(), "Lista de Asistencia");

                    //ca += evidenciasmemoriasS004(count.Rows[i]["codigo"].ToString(), "Formato de evaluación");
 
                    //ca += evidenciasmemoriasS004(count.Rows[i]["codigo"].ToString(), "Relatoria institucional");
                   
                //    val++;
                //}
                   
                    //ca += "<td align='center'>" + entregamaterial(codsede, anio) + "</td>";
                    
                ca += "</tr>";
                totals004 += Convert.ToInt32(count.Rows[i]["total"].ToString());
            }
            
        }
        else
        {
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
        }

        

        return ca;
    }

    private string evidenciasmemoriasS004(string codsede, string actividad)
    {
        string ca = "";

        DataTable count = est.cargarEvidenciasEstrategiaS004SedesxCodInstrumentoxActividad(codsede, actividad);

            if (count != null && count.Rows.Count > 0)
            {
                int evidencia = 0;
                evidencia = count.Rows.Count;
                contador += evidencia;
                ca += "<td align='center'>";
                ca += count.Rows[0]["total"].ToString();
                ca += "</td>";

                if (actividad == "Fotos")
                    totalfotos += Convert.ToInt32(count.Rows[0]["total"].ToString());

                if (actividad == "Lista de Asistencia")
                    totallistado += Convert.ToInt32(count.Rows[0]["total"].ToString());

                if (actividad == "Formato de evaluación")
                    totalevaluacion += Convert.ToInt32(count.Rows[0]["total"].ToString());

                if (actividad == "Relatoria institucional")
                    totalrelatoria += Convert.ToInt32(count.Rows[0]["total"].ToString());
            }
            else
            {
                ca += "<td align='center'>";
                ca += "0";
                ca += "</td>";
            }
           
      
        return ca;
    }

    private string grupoinvestigacion(string codsede, string anio)
    {
        string ca = "";
       
        DataTable count = est.cargarGruposInvestigacionDocentexSedexAnio(codsede, anio);

        if (count != null && count.Rows.Count > 0)
        {
            for (int i = 0; i < count.Rows.Count; i++)
            {
                if (codsede == "Todos")
                {
                    ca = count.Rows[i]["total"].ToString();
                    totalgrupos += count.Rows.Count;
                }
                else
                {
                    ca = count.Rows.Count.ToString();
                    totalgrupos = count.Rows.Count;
                }
                
                
            }
                
        }
        else
        {
            ca = "0";
        }
        


        return ca;
    }

    private string mesadetrabajo(string codsede, string anio)
    {
        string ca = "";

        DataTable count = est.cargarMesadeTrabajoxSedexAnio(codsede, anio);

        if (count != null && count.Rows.Count > 0)
        {
            for (int i = 0; i < count.Rows.Count; i++)
            {
                if (codsede == "Todos")
                {
                    ca = count.Rows[i]["total"].ToString();
                    totalmesas += count.Rows.Count;
                }
                else
                {
                    ca = count.Rows.Count.ToString();
                    totalmesas += count.Rows.Count;
                }
            }
            
           
        }
        else
        {
            ca = "0";
        }
        


        return ca;
    }

    private string entregamaterial(string codsede, string anio)
    {
        string ca = "";

        DataTable count = inst.cargarListadoMaterialesxSedexAnio(codsede, anio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
           
        }
        else
        {
            ca = "0";
        }
         totalmaterial += count.Rows.Count;
        

        return ca;
    }

   
}