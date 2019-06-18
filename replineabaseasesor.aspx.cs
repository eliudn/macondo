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

public partial class replineabaseasesor : System.Web.UI.Page
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
        co += "<th>Nro.</th>";
        co += "<th>Asesores</th>";
        co += "<th>Total Rectores</th>";
        co += "<th>Total Coordinadores</th>";
        co += "<th>Total Docentes</th>";

        co += "</tr>";
        co += "<thead>";

        co += cargarDatos();

        co += "</table>";

        lblResultado.Text = co;
    }

    private string cargarDatos()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable asesor = lb.cargarAsesores();
        int contrectores = 0;
        int contcoord = 0;
        int contdocentes = 0;

        int tdocentes = 0;
        int trectores = 0;
        int tcoord = 0;
        if(asesor != null && asesor.Rows.Count > 0)
        {
            for(int i = 0; i < asesor.Rows.Count; i++)
            {
                DataRow rectores = lb.contarRectoresInvolucradosxAsesor(asesor.Rows[i]["codigo"].ToString());

                DataTable coord = lb.cargarSedesxInstitucionxAsesor(asesor.Rows[i]["codigo"].ToString());

                if(coord != null && coord.Rows.Count > 0 )
                {
                    for (int j = 0; j < coord.Rows.Count; j++ )
                    {
                        DataRow datocoord = lb.cargarSedexInsAsesor(coord.Rows[j]["codigo"].ToString());

                        if (datocoord != null) { contcoord = Convert.ToInt32(datocoord["count"].ToString()); tcoord += contcoord; } else { contcoord = 0; }
                    }
                }

                //DataRow coord = lb.contarCoordinadoresInvolucradosxAsesor(asesor.Rows[i]["codigo"].ToString());
                
                DataRow docentes = lb.contarDocentesInvolucradosxAsesor(asesor.Rows[i]["codigo"].ToString());

                if (rectores != null) { contrectores = Convert.ToInt32(rectores["count"].ToString()); trectores += Convert.ToInt32(rectores["count"].ToString()); } else { contrectores = 0; }
                //if (coord != null) { contcoord = Convert.ToInt32(rectores["count"].ToString()); } else { contcoord = 0; }
                if (docentes != null) { contdocentes = Convert.ToInt32(docentes["count"].ToString()); tdocentes += Convert.ToInt32(docentes["count"].ToString()); } else { contdocentes = 0; }

                ca += "<tr><td>" + (i + 1) + "</td><td >" + asesor.Rows[i]["nombre"].ToString() + " " + asesor.Rows[i]["apellido"].ToString() + "</td><td align='center'>" + contrectores + "</td><td align='center'>" + contcoord + "</td><td align='center'>" + contdocentes + "</td></tr>";
            }
            ca += "<tr><td colspan='2' align='center'><b>TOTAL</b></td><td align='center'><b>" + trectores + "</b></td><td align='center'><b>" + tcoord + "</b></td><td align='center'><b>" + tdocentes + "</b></td></tr>";
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