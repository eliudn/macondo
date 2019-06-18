using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class estraregigrupoinves : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Funciones fun = new Funciones();
    Usuario user = new Usuario();
    Proyecto pro = new Proyecto();
    
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
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
           
        }
 
    }

    protected void btnBuscarDocente_Click(object sender, EventArgs e)
    {


        if (txtBusqNomDocente.Text != "")
        {
            //Institucion ins = new Institucion();
            //DataTable datos = ins.cargarEstudiantexDocente(txtBusqNomDocente.Text);
            //GridEstudiantexDocente.DataSource = datos;
            //GridEstudiantexDocente.DataBind();
        }
        else
        {
            mostrarmensaje("error", "Digite la cédula del docente.");
        }

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
   
}