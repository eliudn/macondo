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

public partial class replineabasecantidades : System.Web.UI.Page
{
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
            cargarTabla();
        }
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    private void cargarTabla()
    {
        string co = "";

        co += "<table class='mGridTesoreria'>";
        co += "<thead>";
        co += "<tr>";
        co += "<th>Descripción</th>";
        co += "<th>Total</th>";

        co += "</tr>";
        co += "<thead>";

        co += "<tr>";
        co += "<td >Nro de Rectores involucrados</td>";
        co += "<td align='center'>" + NumRectoresInvolucrados() + "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td >Nro de Coordinadores involucradas</td>";
        co += "<td align='center'>" + NumCoordinadoresInvolucrados() + "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td >Nro de Docentes involucrados</td>";
        co += "<td align='center'>" + NumDocentesInvolucrados() + "</td>";
        co += "</tr>";

        co += "</table>";

        lblResultado.Text = co;
    }

    private string NumRectoresInvolucrados()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow dato = lb.contarRectoresInvolucrados();

       if(dato != null)
       {
           ca = dato["count"].ToString();
       }
       else
       {
           ca = "0";
       }

       return ca;
    }

    private string NumCoordinadoresInvolucrados()
   {
       string ca = "";
       LineaBase lb = new LineaBase();
       DataRow dato = lb.contarCoordinadoresInvolucradas();

       if (dato != null)
       {
           ca = dato["count"].ToString();
       }
       else
       {
           ca = "0";
       }

       return ca;
   }

    private string NumDocentesInvolucrados()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow dato = lb.contarDocentesInvolucrados();

        if (dato != null)
        {
            ca = dato["count"].ToString();
        }
        else
        {
            ca = "0";
        }

        return ca;
    }

}