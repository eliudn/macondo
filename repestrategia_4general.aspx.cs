using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;

public partial class repestrategia_4general : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession=true)]
    public static string cargarAsesoriasRealizadas()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow asesorias = estra.numeroAsesoriasRealizadas();

        if (asesorias != null)
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Asesorias realizadas</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td>Número de asesorías al grupo en la sesión Conformación de la comunidad de estudiantes que se gozan la ciencia en todas las sedes</td>";
            ca += "<td>" + asesorias["asesorias"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</table>";
        }
        else
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Asesorias realizadas</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td>Número de asesorías al grupo en la sesión Conformación de la comunidad de estudiantes que se gozan la ciencia en todas las sedes</td>";
            ca += "<td>Ninguna</td>";
            ca += "</tr>";
            ca += "</table>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarAsesoriasEvaluadas()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow asesorias = estra.numeroAsesoriasEvaluadas();

        if (asesorias != null)
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Sesiones evaluadas y subidas a la plataforma de Ciclón</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td>Número de asesorías evaluadas por el grupo en todas las sedes</td>";
            ca += "<td>" + asesorias["evalasesoria"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</table>";
        }
        else
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Sesiones evaluadas y subidas a la plataforma de Ciclón</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td>Número de asesorías evaluadas por el grupo en todas las sedes</td>";
            ca += "<td>Ninguna</td>";
            ca += "</tr>";
            ca += "</table>";
        }

        return ca;
    }
}