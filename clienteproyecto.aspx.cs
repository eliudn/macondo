using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class clienteproyecto : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
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
            ddProyectos(DropProyecto);
        }
    }
    private void ddProyectos(DropDownList drop)
    {
        drop.DataSource = pro.cargarProyectos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnSeleccioneProyecto_Click(object sender, EventArgs e)
    {
        if (DropProyecto.SelectedIndex > 0)
        {
            DataRow datoProyecto = pro.buscarProyecto(DropProyecto.SelectedValue);
            if (datoProyecto != null)
            {
                lblCodDepartamento.Text = datoProyecto["coddepartamento"].ToString();
                txtFechaIni.Text = fun.convertFechaDia(datoProyecto["fechaini"].ToString());
                txtFechaFin.Text = fun.convertFechaDia(datoProyecto["fechafin"].ToString());
                gvCargarClientesInProyecto(DropProyecto.SelectedValue);
                gvCargarClientesOutProyecto(DropProyecto.SelectedValue, lblCodDepartamento.Text);
                PanelPerfiles.Visible = true;
            }
            else
                mostrarmensaje("error", "ERROR: No se encontro el proyecto.");
            
        }
    }
    private void gvCargarClientesInProyecto(string codproyecto)
    {
          GridClienteProyecto.DataSource= pro.cargarClienteInProyecto(codproyecto);
          GridClienteProyecto.DataBind();
    }
    private void gvCargarClientesOutProyecto(string codproyecto, string coddepartamento)
    {
        GridClientes.DataSource = pro.cargarClienteOUTProyecto(codproyecto, coddepartamento);
        GridClientes.DataBind();
    }
    protected void btnPasar_Click(object sender, EventArgs e)
    {
        if(validarFechas(txtFechaIni.Text,txtFechaFin.Text))
        {
                bool eligio = false;
                int cont = 0;
                foreach (GridViewRow gvr in GridClientes.Rows)   //loop through GridView
                {
                    CheckBox chkPasar = (gvr.FindControl("cbDisponibles") as CheckBox);
                    if (chkPasar.Checked == true)
                    {
                        eligio = true;
                        string codsel = HttpUtility.HtmlDecode(GridClientes.Rows[gvr.RowIndex].Cells[1].Text);
                        if (pro.agregarClientexProyecto(codsel,DropProyecto.SelectedValue,fun.convertFechaAño(txtFechaIni.Text),fun.convertFechaAño(txtFechaFin.Text)))
                        {
                            cont++;
                        }
             
                    }
                }
            if (eligio == false)
            {
                mostrarmensaje("error", "No hay ningún item Seleccionado");
            }
            else
            {
                  if (cont>0)
                  {
                    mostrarmensaje("exito", "Se asignaron "+cont+" clientes correctamente.");
                    gvCargarClientesInProyecto(DropProyecto.SelectedValue);
                    gvCargarClientesOutProyecto(DropProyecto.SelectedValue,lblCodDepartamento.Text);
                  }
                  else
                  {
                      mostrarmensaje("error", "ERROR: No se agregó ningún cliente al proyecto.");
                  }
            }
          
        }
        else
        {
            mostrarmensaje("error","ERROR: La fecha de cierre debe ser menor a la de inicio");
        }
     
    }
    private bool validarFechas(string fechaini,string fechafin)
    {
        bool valido = false;
        DateTime fechai = Convert.ToDateTime(fechaini);
        DateTime fechaf = Convert.ToDateTime(fechafin);
        int res = DateTime.Compare(fechai, fechaf);
        if (res < 0)
        {
            valido = true;
        }
        return valido;
    }
    protected void btnQuitar_Click(object sender, EventArgs e)
    {
        int cont = 0;
        bool eligio = false;
        foreach (GridViewRow gvr in GridClienteProyecto.Rows)   //loop through GridView
        {
            CheckBox chkPasar = (gvr.FindControl("cbItem") as CheckBox);
            if (chkPasar.Checked == true)
            {
                eligio = true;
                string codsel = HttpUtility.HtmlDecode(GridClienteProyecto.Rows[gvr.RowIndex].Cells[1].Text);
                if (pro.eliminarClientexProyecto(codsel, DropProyecto.SelectedValue))
                    cont++;
            }
        }
        if (eligio == false)
            mostrarmensaje("error", "No hay ningún item Seleccionado");
        else
        {
            if (cont>0)
            {
              mostrarmensaje("exito", "Se han Quitado " + cont + " clientes Correctamente");
              gvCargarClientesInProyecto(DropProyecto.SelectedValue);
              gvCargarClientesOutProyecto(DropProyecto.SelectedValue,lblCodDepartamento.Text);
            }
            else
               mostrarmensaje("error", "ERROR: No se logró quitar nigún cliente de este proyecto.");
        }
      
    }
}