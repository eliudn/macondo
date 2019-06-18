using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class evalfinalins6 : System.Web.UI.Page
{
    string codrol = "";
    string validarIntentos = "true";
    Institucion inst = new Institucion();
    LineaBase lb = new LineaBase();
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
  
    //IMPACTO

  
    [WebMethod(EnableSession = true)]
    public static string cargarinfoinstitucion()
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataRow datoie = inst.buscarInstitucionxNitTodo(HttpContext.Current.Session["dane"].ToString());

        if (datoie != null)
        {
            ca = "true&";
            ca += datoie["codigo"].ToString();
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
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datoie != null)
                {
                    if (datos.Rows[i]["codigo"].ToString() == datoie["codasesor"].ToString())
                    {
                        ca += datoie["codigo"].ToString();
                        val = "1";
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
    public static string insertarevaluacion(string codasesor, string codinstitucion, string respuesta, string pregunta, string subpregunta)
    {
        string ca = "";

        Asesores ase = new Asesores();
        LineaBase lb = new LineaBase();

         DataRow dato = ase.buscarinsasesor(codinstitucion);

         if (dato != null)
         {
             lb.AgregarRespuestaCerradaInstitucional_Fase(dato["codigo"].ToString(), pregunta, subpregunta, respuesta, "6", "impacto");
         }

        

        return ca;
    }

   
}