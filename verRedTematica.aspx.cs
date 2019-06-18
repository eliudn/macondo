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

public partial class verRedTematica : System.Web.UI.Page
{

    LineaBase lb = new LineaBase();
    Institucion inst = new Institucion();
    Estrategias est = new Estrategias();
    Asesores ase = new Asesores();
    Estudiantes estu = new Estudiantes();
    Funciones fun = new Funciones();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            ddAnio(dropAnio);
            ddAsesores(dropAsesor);
            //cargarGruposxAsesor();
           
        }
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = inst.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAsesores(DropDownList drop)
    {
        DataTable asesores = est.listarAsesores("4");
        drop.DataSource = asesores;
        drop.DataTextField = "asesor";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void dropAsesor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddAsesorxGrupo(dropAsesor.SelectedValue, dropAnio.SelectedItem.ToString());

//        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
//            </script>";

//        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    private void ddAsesorxGrupo(string codasesor, string anio)
    {
        DataTable datos = est.cargarRedTematicaxAsesorAnio(codasesor,anio);
        GridRedTematica.DataSource = datos;
        GridRedTematica.DataBind();
    }

    private void cargarGruposxAsesor()
    {
      
        DataTable datos = est.cargarRedTematicaxAsesor();
        GridRedTematica.DataSource = datos;
        GridRedTematica.DataBind();
    

        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    ca += "<b>Total Grupos de Investigación: </b>" + datos.Rows.Count;
        //    ca += "<table  class='mGridTesoreria'>";
        //    ca += "<tr>";
        //    ca += "<th>Asesor</th>";
        //    ca += "<th>Nombre Grupo</th>";
        //    ca += "<th>Integrantes</th>";
        //    ca += "<th>Docentes acompañantes</th>";
        //    ca += "<th>Área</th>";
        //    ca += "<th>Línea de Investigación</th>";
        //    ca += "</tr>";
        //    for (int j = 0; j < datos.Rows.Count; j++)
        //    {

        //        ca += "<tr>";
        //        ca += "<td>" + datos.Rows[j]["nomasesor"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[j]["nombregrupo"].ToString() + "</td>";
        //        ca += "<td><a href='#' onclick='btnVerEstudiantes'><img src='Imagenes/ver.png' /></a></td>";
        //        ca += "<td>" + cargarDocentesGrupo(datos.Rows[j]["codproyectosede"].ToString()) + "</td>";
        //        ca += "<td>" + datos.Rows[j]["nomarea"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[j]["nomlinea"].ToString() + "</td>";
        //        ca += "</tr>";

        //    }
        //}

  

    }

    protected void imgVerEstudiantes_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematica = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        string script = @"<script type='text/javascript'> $('#dialog-formEstudiantes').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
            </script>";

        string ca = "";

        DataTable datos = estu.cargarEstudiantesxRedTematica(codredtematica);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table  class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Nro</th>";
            ca += "<th>Estudiantes</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "</tr>";
            }

        }
        lblDocentes.Text = "";
        lblEstudiantes.Text = ca;
      
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void imgVerDocentes_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematica = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        string script = @"<script type='text/javascript'> $('#dialog-formDocentes').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
            </script>";

        string ca = "";

        DataTable datos = estu.cargarDocentesxRedTematica(codredtematica);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table  class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Nro</th>";
            ca += "<th>Docentes</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "</tr>";
            }

        }
        lblEstudiantes.Text = "";
        lblDocentes.Text = ca;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void btnEstudiantes_Click(object sender, EventArgs e)
    {
       

        
       

    }

    private string cargarDocentesGrupo(string codproyectosede)
    {
        string ca = "";


      

        //DataTable datos = estu.cargarDocentesxGrupoInvestigacion(codproyectosede);

        //if (datos != null && datos.Rows.Count > 0)
        //{
          
        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        ca += "- " + datos.Rows[i]["nombre"].ToString() + "<br />";
        //    }
            
        //}
        return ca;
       
    }
    protected void VerDocentesGrupo_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'> $('#dialog-formaEstudiantes').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    protected void btnModeloEducativoCurriculo_Click(object sender, EventArgs e)
    {

    }

}