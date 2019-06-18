using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class repseguimiento3 : System.Web.UI.Page
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
    int totalninios;
 
    int totalgrupos;
   
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
            //ddMomentos(dropMomentos);
            ddAnio(dropAnio);
        }
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
        if(rbtFormacion.SelectedValue == "Presencial")
            cargarSeguimiento(dropAnio.SelectedItem.ToString(), dropSesion.SelectedValue);
        else
            cargarSeguimientoVirtual(dropAnio.SelectedItem.ToString(), dropSesion.SelectedValue);
    }

    private void cargarSeguimiento(string codanio, string codsesion)
    {
        string ca = "";
        DataTable asesores = est.listarAsesores("4");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += lineaEncabezado();
            ca += "<tbody>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + asesores.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td align='center'>" + dropSesion.SelectedItem.ToString() + "</td>";

                ca += redestematicas(asesores.Rows[i]["codigo"].ToString(), codanio);

                if(codanio == "2016")
                {
                    ca +=  memoriasS004_2016(asesores.Rows[i]["codigo"].ToString(),  dropSesion.SelectedValue, codanio);
                }
                else
                {
                    ca +=  memoriasS004(asesores.Rows[i]["codigo"].ToString(),  dropSesion.SelectedValue, codanio);
                }

                ca += "<td align='center'>" + usuariolog(asesores.Rows[i]["identificacion"].ToString()) + "</td>";
                ca += "</tr>";
            }
              
           

            ca += "<tr style='font-weight:bold;'>";
            ca += "<td colspan='2' align='center'>TOTAL:</td>";
            ca += "<td align='center'>" + totalgrupos + "</td>";
            ca += "<td align='center'>" + totalninios + "</td>";
            ca += "<td align='center'>" + totals004 + "</td>";
            ca += "<td align='center'>" + totalfotos + "</td>";
            ca += "<td align='center'>" + totallistado + "</td>";
            ca += "<td align='center'>" + totalevaluacion + "</td>";
            ca += "</tr>";
            ca += "</tbody>";
            ca += "</table>";

        }
        lblResultado.Text = ca;
    }

    private void cargarSeguimientoVirtual(string codanio, string codsesion)
    {
        string ca = "";
        DataTable asesores = est.listarAsesores("4");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += lineaEncabezado();
            ca += "<tbody>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + asesores.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td align='center'>" + dropSesion.SelectedItem.ToString() + "</td>";

                ca += redestematicas(asesores.Rows[i]["codigo"].ToString(), codanio);

                ca += memoriasS004Virtuales(asesores.Rows[i]["codigo"].ToString(), dropSesion.SelectedValue, codanio);

                ca += "<td align='center'>" + usuariolog(asesores.Rows[i]["identificacion"].ToString()) + "</td>";
                ca += "</tr>";
            }



            ca += "<tr style='font-weight:bold;'>";
            ca += "<td colspan='2' align='center'>TOTAL:</td>";
            ca += "<td align='center'>" + totalgrupos + "</td>";
            ca += "<td align='center'>" + totalninios + "</td>";
            ca += "<td align='center'>" + totals004 + "</td>";
            ca += "<td align='center'>" + totalfotos + "</td>";
            ca += "<td align='center'>" + totallistado + "</td>";
            ca += "<td align='center'>" + totalevaluacion + "</td>";
            ca += "</tr>";
            ca += "</tbody>";
            ca += "</table>";

        }
        lblResultado.Text = ca;
    }

    private string lineaEncabezado()
    {
        string ca = "";

        ca += "<table class='mGridTesoreria'><tr>";
        ca += "<thead>";
        ca += "<th>Nombre Asesor</th>";
        ca += "<th>Sesión de Formación</th>";
        ca += "<th>Redes temáticas conformadas</th>";
        ca += "<th>Niños en redes temáticas</th>";
        ca += "<th>Memorias de sesión S004</th>";
        ca += "<th>Evidencias de la memoria (Fotos)</th>";
        ca += "<th>Listado de asistencia</th>";
        ca += "<th>Formatos de evaluación</th>";
        ca += "<th>Fecha ultimo ingreso</th>";
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

    private string memoriasS004_2016(string codasesorcoordinador, string sesion, string anio)
    {
        string ca = "";

        DataTable count = est.cargarListadoMemoriasS004_2016Seguimiento(codasesorcoordinador, "4", "1", sesion, anio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = "<td align='center'>" + count.Rows.Count.ToString() + "</td>";
            int val = 0;   
            for(int i = 0; i < count.Rows.Count; i++)
            {
                if (val == 0)
                {
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004(count, "Fotos", sesion);
                    ca += "</td>";
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004(count, "Lista de Asistencia", sesion);
                    ca += "</td>";
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004(count, "Formatos de evaluación", sesion);
                    ca += "</td>";
 
                    val++;
                }
                    
                
            }
            
        }
        else
        {
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
        }
      
        totals004 += count.Rows.Count;

        return ca;
    }

    private string evidenciasmemoriasS004(DataTable instrumento, string actividad, string sesion)
    {
        string ca = "";
        int evidencias = 0;
        for (int i = 0; i < instrumento.Rows.Count; i++)
        {
            DataTable count = est.cargarEvidenciasEstrategia4AsesorRedTematicaSeguimiento(instrumento.Rows[i]["codigo"].ToString(), actividad, sesion);

            if (count != null && count.Rows.Count > 0)
            {
                evidencias += count.Rows.Count;
               
                if (actividad == "Fotos")
                {
                    ca = evidencias.ToString();
                    totalfotos += count.Rows.Count;
                }


                if (actividad == "Lista de Asistencia")
                {
                    ca = evidencias.ToString();
                    totallistado += count.Rows.Count;
                }
                    

                if (actividad == "Formatos de evaluación")
                {
                    ca = evidencias.ToString();
                    totalevaluacion += count.Rows.Count;
                }
            }
            else
            {
                evidencias += count.Rows.Count;
            }
        }

        if (evidencias == 0)
            ca = "0";

        return ca;
    }

    private string evidenciasmemoriasS004Virtuales(DataTable instrumento, string actividad, string sesion)
    {
        string ca = "";
        int evidencias = 0;
        for (int i = 0; i < instrumento.Rows.Count; i++)
        {
            DataTable count = est.cargarEvidenciasEstrategia4AsesorRedTematicaSeguimientoVirtuales(instrumento.Rows[i]["codigo"].ToString(), actividad);

            if (count != null && count.Rows.Count > 0)
            {
                evidencias += count.Rows.Count;

                if (actividad == "Fotos")
                {
                    ca = evidencias.ToString();
                    totalfotos += count.Rows.Count;
                }


                if (actividad == "Lista de Asistencia")
                {
                    ca = evidencias.ToString();
                    totallistado += count.Rows.Count;
                }


                if (actividad == "Formatos de evaluación")
                {
                    ca = evidencias.ToString();
                    totalevaluacion += count.Rows.Count;
                }
            }
            else
            {
                if (count != null && count.Rows.Count > 0)
                {
                    evidencias += count.Rows.Count;
                }
                else
                {
                    evidencias += 0;
                }
                
            }
        }

        if (evidencias == 0)
            ca = "0";

        return ca;
    }

    private string memoriasS004(string codasesorcoordinador, string sesion, string anio)
    {
        string ca = "";

        DataTable count = est.cargarListadoMemoriasS004Seguimiento(codasesorcoordinador, "4", "1", sesion, anio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = "<td align='center'>" + count.Rows.Count.ToString() + "</td>";
            int val = 0;
            for (int i = 0; i < count.Rows.Count; i++)
            {
                if (val == 0)
                {
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004(count, "Fotos", sesion);
                    ca += "</td>";
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004(count, "Lista de Asistencia", sesion);
                    ca += "</td>";
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004(count, "Formatos de evaluación", sesion);
                    ca += "</td>";

                    val++;
                }


            }

        }
        else
        {
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
        }

        totals004 += count.Rows.Count;

        return ca;
    }

    private string memoriasS004Virtuales(string codasesorcoordinador, string sesion, string anio)
    {
        string ca = "";

        DataTable count = est.cargarListadoMemoriasS004SeguimientoVirtual(codasesorcoordinador, "4", "1", sesion, anio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = "<td align='center'>" + count.Rows.Count.ToString() + "</td>";
            int val = 0;
            for (int i = 0; i < count.Rows.Count; i++)
            {
                if (val == 0)
                {
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004Virtuales(count, "Fotos", sesion);
                    ca += "</td>";
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004Virtuales(count, "Lista de Asistencia", sesion);
                    ca += "</td>";
                    ca += "<td align='center'>";
                    ca += evidenciasmemoriasS004Virtuales(count, "Formatos de evaluación", sesion);
                    ca += "</td>";

                    val++;
                }


            }

        }
        else
        {
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
        }

        totals004 += count.Rows.Count;

        return ca;
    }

    private string redestematicas(string codasesorcoordinador, string anio)
    {
        string ca = "";

        DataTable count = est.cargarRedesTematicasxAsesorSeguimiento(codasesorcoordinador, anio);

        if (count != null && count.Rows.Count > 0)
        {
            ca += "<td align='center'>";
            ca += count.Rows.Count.ToString();
            ca += "</td>";

            ca += "<td align='center'>" + niniosxred(count) + "</td>";
           
        }
        else
        {
            ca += "<td align='center'>0</td>";
            ca += "<td align='center'>0</td>";
        }
        totalgrupos += count.Rows.Count;


        return ca;
    }

    

    private string niniosxred(DataTable redtematica)
    {
        string ca = "";
        int ninios = 0;
        for (int i = 0; i < redtematica.Rows.Count; i++)
        {
            DataTable count = est.cargarEstudianteRedesTematicas(redtematica.Rows[i]["codredtematicasede"].ToString());

            if (count != null && count.Rows.Count > 0)
            {
                ninios += count.Rows.Count;

            }
            else
            {
                ninios += count.Rows.Count;
            }
            totalninios += count.Rows.Count; 
        }

        if (ninios == 0)
            ca = "0";
        else
            ca = ninios.ToString();

       

        return ca;
    }
  
   
}