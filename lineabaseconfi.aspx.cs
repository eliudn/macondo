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

public partial class lineabaseconfi : System.Web.UI.Page
{
    Funciones fun = new Funciones();
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
            if (Session["codrol"].ToString() != "1")
            {
                  Response.Redirect("Default.aspx");
            }
            else
            {
                buscarConfiGeneral();
            }
          
        }
    }

    private void buscarConfiGeneral()
    {
        LineaBase lb = new LineaBase();

        DataRow dat = lb.buscarconfiSINOTiempo();

        if(dat != null)
        {
            if (dat["tiempoenlineabase"].ToString() == "Si")
                chkActivarTiempo.Checked = true;
        }
    }
    protected void btnGuardarConfi_Click(object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();


        DataRow dat = lb.buscarConfiIntrumento(dropInstrumento.SelectedValue);

        if(dat != null)
        {

            if (lb.ActualizarFechaInstrumento(dropInstrumento.SelectedValue, fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text), Session["usuario"].ToString()))
            {
                mostrarmensaje("exito", "Configuración editada éxitosamente");
            }
        }
        else
        {
            if (lb.agregarFechaInstrumento (dropInstrumento.SelectedValue, fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text), Session["usuario"].ToString()))
            {
                mostrarmensaje("exito", "Configuración guardada éxitosamente");
            }
        }
    }

    protected void btnGuardarConfiTiempo_Click(object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();

        DataRow dat = lb.buscarConfiTiempo();

        if(dat != null)
        {
            if(lb.ActualizarTiempoEjecucion(txtTiempoejecucion.Text, Session["usuario"].ToString()))
            {
                mostrarmensaje("exito", "Configuración editada éxitosamente");
            }
        }
        else
        {
            if (lb.agregarTiempoEjecucion(txtTiempoejecucion.Text, Session["usuario"].ToString()))
            {
                mostrarmensaje("exito", "Configuración guardada éxitosamente");
            }
        }
    }

    [WebMethod]
    public static string ActualizarEstadoTiempoEjecucion(string tiempoenlineabase)
    {
        string ca = "";

        LineaBase lb = new LineaBase();

        if(lb.ActualizarEstadoTiempoLineaBase(tiempoenlineabase))
        {
            ca = "Actualizado correctamente.";
        }
        else
        {
            ca = "Error al actualizar correctamente.";
        }

        return ca;
    }
  
}