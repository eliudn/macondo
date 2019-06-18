using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;

public partial class confiredtematicalistado : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Institucion ins = new Institucion();
    Estudiantes estu = new Estudiantes();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                ddAsesores(dropAsesores);
                ddAnio(dropAnio);
                if(Session["codrol"].ToString() == "13")//Asesor FUNTICS
                {
                    DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                    if (dato != null)
                    {
                       
                        Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
                        dropAsesores.SelectedValue = Session["CodAsesorEstraCoordinador"].ToString();
                        dropAsesores.Enabled = false;
                        //dropAsesores_OnSelectedIndexChanged(null, null);
                    }                    
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
    private void ddAsesores(DropDownList drop)
    {
        drop.DataSource = est.listarAsesores("4");
        drop.DataTextField = "asesor";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gvCargarRedesTematicas(dropAsesores.SelectedValue, dropAnio.SelectedItem.ToString());

        if(Session["CodAsesorEstraCoordinador"] == null)
        {
            string script = "cargarDataTable();";
            if (ScriptManager1.IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            }
        }
        
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }


    
    private void gvCargarRedesTematicas(string codasesor, string codanio)
    {
        DataTable datos = est.cargarNombresRedesTematicas(codasesor, codanio);
        GridRedesTematicas.DataSource = datos;
        GridRedesTematicas.DataBind();

        if (datos != null && datos.Rows.Count > 0)
        {
            GridRedesTematicas.UseAccessibleHeader = true;
            if (GridRedesTematicas.HeaderRow != null)
            {
                GridRedesTematicas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GridRedesTematicas.ShowFooter)
                GridRedesTematicas.FooterRow.TableSection = TableRowSection.TableFooter;


        }
    }
   
    protected void lnkAgregarRedTematica_Click(object sender, EventArgs e)
    {
        Response.Redirect("confiredtematicaagregar.aspx");
    }

    [WebMethod(EnableSession = true)]
    public static string vergrados(string codredtematicasede)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarGradosxRedTematica(codredtematicasede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "lleno@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td><img src='Imagenes/delete.png' style='cursor:pointer' onclick='eliminargrado(" + datos.Rows[i]["codigo"].ToString() + ")' /></td>";
                ca += "</tr>";
            }

        }
      
        return ca;
    }

    protected void imgVerGradosRedTematica_Click(object sender, EventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        string script = @"<script type='text/javascript'> $('#dialog-formgrados').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
            </script>";

        string ca = "";

        DataTable datos = est.cargarGradosxRedTematica(codredtematicasede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table  class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Nro</th>";
            ca += "<th>Grado</th>";
            ca += "<th></th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td><img src='Imagenes/delete.png' style='cursor:pointer' onclick='eliminargrado(" + datos.Rows[i]["codigo"].ToString() + ")' /></td>";
                ca += "</tr>";
            }

        }
        else
        {
            ca = "No se cargó ningún grado para visualizar";
        }
        lblGrados.Text = ca;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void imgEliminarRedTematica_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = GridRedesTematicas.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        borrarRedTematica(codredtematicasede);

    }

    private void borrarRedTematica(string codigo)
    {
         DataTable datos = estu.buscarDatoS004(codigo);

        if(datos != null && datos.Rows.Count > 0)
        {
            string script = @"<script type='text/javascript'>alert('Error al eliminar, existen memorias asociadas a esta Red Temática.')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            est.deleteEstudianteRedTematicaSede(codigo);
            est.deleteDocenteRedTematicaSede(codigo);
            est.deleteRedTematicaSede(codigo);
            est.deleteRedTematicaGrados(codigo);

            string script2 = "cargarDataTable();";
            if (ScriptManager1.IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script2, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script2, true);
            }
            gvCargarRedesTematicas(dropAsesores.SelectedValue, dropAnio.SelectedValue);
            string script = @"<script type='text/javascript'>alert('Red Temática eliminada con éxito.')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


           
           
        }
    }

    [WebMethod(EnableSession = true)]
    public static string deletegrado(string codigo)
    {
        Estrategias est = new Estrategias();
        string ca = "";

        est.eliminarGradoGrupo(codigo);

        return ca;
    }

    protected void addGradosRedTematica_Click(object sender, EventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = GridRedesTematicas.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        string coddepartamento = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        string codmunicipio = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
        string codinstitucion = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);
        string anio = HttpUtility.HtmlDecode(gvrow.Cells[14].Text);

        Response.Redirect("confiredtematicaagregar.aspx?cr=" + codredtematicasede + "&cd=" + coddepartamento + "&cm=" + codmunicipio + "&ci=" + codinstitucion + "&cs=" + codsede + "&a=" + anio);
    }
}