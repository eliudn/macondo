using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;

public partial class confiredtematicaagregar : System.Web.UI.Page
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
                obtenerGET();

                if (lblCodDepartamento.Text != "" && lblCodRed.Text != "" && lblCodMunicipio.Text != "" && lblCodInstitucion.Text != "" && lblCodSede.Text != "" && lblCodAnio.Text != "")
                {
                    ddDepartamentos(dropDepartamento);
                    dropDepartamento.Enabled = false;
                    dropDepartamento.SelectedValue = lblCodDepartamento.Text;

                    ddMunicipiosSolo(dropMunicipio);
                    dropMunicipio.Enabled = false;
                    dropMunicipio.SelectedValue = lblCodMunicipio.Text;

                    ddInstitucionesSolo(dropInstituciones);
                    dropInstituciones.Enabled = false;
                    dropInstituciones.SelectedValue = lblCodInstitucion.Text;

                    ddSedesSolo(dropSedes);
                    dropSedes.Enabled = false;
                    dropSedes.SelectedValue = lblCodSede.Text;

                    ddRedTematicaTodo(dropRedTematica);
                    dropRedTematica.Enabled = false;
                    dropRedTematica.SelectedValue = lblCodRed.Text;

                    ddAnioRed(dropAniored);
                    dropAniored.Enabled = false;
                    dropAniored.SelectedValue = lblCodAnio.Text;
                    gridGrados();
                    ddAsesores(dropAsesor);

                }
                else
                {
                    ddDrops();
                    ddAnioRed(dropAniored);
                }

                DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                if (dato != null)
                {
                    if (Session["codrol"] != "12")
                    {
                        dropAsesor.SelectedValue = dato["codigo"].ToString();
                        dropAsesor.Enabled = false;
                    }
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
    public void obtenerGET()
    {
        lblCodRed.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cr"]);
        lblCodDepartamento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cd"]);
        lblCodMunicipio.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cm"]);
        lblCodInstitucion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ci"]);
        lblCodSede.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cs"]);
        lblCodAnio.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    private void ddAnioRed(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "nombre";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddDrops()
    {
        ddDepartamentos(dropDepartamento);
        ddAsesores(dropAsesor);
        ddRedTematica(dropRedTematica);
        gridGrados();

    }

    private void gridGrados()
    {
        DataTable datos = ins.cargarGrados();
        GridGrados.DataSource = datos;
        GridGrados.DataBind();
    }
    private void ddRedTematica(DropDownList drop)
    {
        drop.DataSource = est.cargarTablaRedTematica();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddRedTematicaTodo(DropDownList drop)
    {
        drop.DataSource = est.cargarTablaRedTematicaTodo();
        drop.DataTextField = "red";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddInstituciones(DropDownList drop, string codmunicipio)
    {
        drop.DataSource = ins.cargarInstitucionxMunicipio(codmunicipio);
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddInstitucionesSolo(DropDownList drop)
    {
        drop.DataSource = ins.cargarInstitucion();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddDepartamentos(DropDownList drop)
    {
        drop.DataSource = ins.cargarDepartamentoMagdalena();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

    }
    private void ddMunicipios(DropDownList drop, string coddepartamento)
    {
        drop.DataSource = ins.cargarciudadxDepartamento(coddepartamento);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddMunicipiosSolo(DropDownList drop)
    {
        drop.DataSource = ins.cargarciudad();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAsesores(DropDownList drop)
    {
        drop.DataSource = est.listarAsesores("4");
        drop.DataTextField = "asesor";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

       protected void dropDepartamento_SelectedIndexChanged(object sender, EventArgs e)
       {
           ddMunicipios(dropMunicipio, dropDepartamento.SelectedValue);

           string script = @"<script type='text/javascript'>$('#agregar').show(),$('#listado').hide();</script>";
           ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
       }
       protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
       {
           ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);

           string script = @"<script type='text/javascript'>$('#agregar').show(),$('#listado').hide();</script>";
           ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
       }
       protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
       {
           ddSedes(dropSedes, dropInstituciones.SelectedValue);

           string script = @"<script type='text/javascript'>$('#agregar').show(),$('#listado').hide();</script>";
           ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
       }
       private void ddSedes(DropDownList drop, string codinstitucion)
       {
           drop.DataSource = ins.cargarSedesInstitucion(codinstitucion);
           drop.DataTextField = "nombre";
           drop.DataValueField = "cod";
           drop.DataBind();
           drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
       }
       private void ddSedesSolo(DropDownList drop)
       {
           drop.DataSource = ins.cargarSedesInstitucionTodo();
           drop.DataTextField = "nombrecompleto";
           drop.DataValueField = "cod";
           drop.DataBind();
           drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
       }
   
    protected void lnkVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("confiredtematicalistado.aspx");
    }

   
    protected void lnkAgregar_Click(object sender, EventArgs e)
    {
        int guardo = 0, noguardo = 0;
        if (lblCodDepartamento.Text != "" && lblCodRed.Text != "" && lblCodMunicipio.Text != "" && lblCodInstitucion.Text != "" && lblCodSede.Text != "" && lblCodAnio.Text != "")
        {
            foreach (GridViewRow row in GridGrados.Rows)
            {
                string codgrado = GridGrados.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
                CheckBoxList chk = (row.FindControl("chkGrupos") as CheckBoxList);


                foreach (ListItem li in chk.Items)
                {
                    if (li.Selected)
                    {
                        if (est.agregarGradoRedTematica(lblCodRed.Text, codgrado, li.Value))
                        {
                            guardo++;
                        }
                    }
                }

            }
        }
        else
        {
            string script = @"<script type='text/javascript'>$('#agregar').show(),$('#listado').hide();</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
           
            //for(int i = 0; i < Convert.ToInt32(dropCantidad.SelectedValue); i++)
            //{
            DataRow dat = estu.buscarUltimaRedTematicaxSede(dropRedTematica.SelectedValue, dropSedes.SelectedValue, fun.getAñoActual());//buscar el último creado

            if (dat == null)//si no existe red temática en la base de datos
            {
                DataRow redtem = estu.agregarRedTematicaxSede(dropRedTematica.SelectedValue, dropSedes.SelectedValue, "1", dropAsesor.SelectedValue, dropAniored.SelectedValue);

                if (redtem != null)
                {

                    foreach (GridViewRow row in GridGrados.Rows)
                    {
                        string codgrado = GridGrados.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
                        CheckBoxList chk = (row.FindControl("chkGrupos") as CheckBoxList);


                        foreach (ListItem li in chk.Items)
                        {
                            if (li.Selected)
                            {
                                if (est.agregarGradoRedTematica(redtem["codigo"].ToString(), codgrado, li.Value))
                                {
                                    guardo++;
                                }
                            }
                        }

                    }
                }
                else
                {
                    noguardo++;
                }
            }
            else
            {
                int consecutivogrupo = Convert.ToInt32(dat["consecutivogrupo"].ToString()) + 1;
                DataRow redtem = estu.agregarRedTematicaxSede(dropRedTematica.SelectedValue, dropSedes.SelectedValue, Convert.ToString(consecutivogrupo), dropAsesor.SelectedValue, dropAniored.SelectedValue);

                if (redtem != null)
                {
                    foreach (GridViewRow row in GridGrados.Rows)
                    {
                        string codgrado = GridGrados.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
                        CheckBoxList chk = (row.FindControl("chkGrupos") as CheckBoxList);


                        foreach (ListItem li in chk.Items)
                        {
                            if (li.Selected)
                            {
                                if (est.agregarGradoRedTematica(redtem["codigo"].ToString(), codgrado, li.Value))
                                {
                                    guardo++;
                                }
                            }
                        }

                    }
                }
                else
                {
                    noguardo++;
                }
            }
            //}

        }
        if (guardo > 0 && noguardo == 0)
        {
            lblResultado.Text = "<b><center>Red y grupos creadados exitosamente.</center></b>";
        }
        else if (guardo == 0 && noguardo > 0)
        {
            lblResultado.Text = "<b><center>No Se crearon " + noguardo + " Redes Temáticas.</center></b>";
        }
        //lnkVolver.Visible = true;
    }


}