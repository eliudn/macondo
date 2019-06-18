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

public partial class replineabasejornadas : System.Web.UI.Page
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
        co += "<th>Instrumento</th>";
        co += "<th >Nro de Sedes involucradas</th>";
        co += "<th>Tipo de Jornadas</th>";

        co += "</tr>";
        co += "<thead>";

        co += "<tr>";
        co += "<td align='center'>01 Información básica IE</td>";
        co += "<td align='center'>" + NumSedesInvolucradas() + "</td>";
        co += "<td >" + NumJornadasSedes() + "</td>";

        co += "</table>";

        lblResultado.Text = co;
    }

    private string NumSedesInvolucradas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow dato = lb.contarSedesIntrumento01();

       if(dato != null)
       {
           ca = dato["contsedes"].ToString();
       }
       else
       {
           ca = "0";
       }

       return ca;
    }

    private string NumJornadasSedes()
   {
       string ca = "";
       LineaBase lb = new LineaBase();

       DataTable datos = lb.cargarSedesxJornadaEscolar();

       if(datos != null && datos.Rows.Count>0)
       {
           int cont = 0; int cont1 = 0; int cont2= 0; int cont3 = 0; int cont4 = 0; int cont5 = 0; int cont6 = 0; int cont7 = 0;
           int cont8 = 0; int cont9 = 0; int cont10 = 0; int cont11 = 0; int cont12 = 0; int cont13 = 0; int cont14 = 0; int cont15 = 0;
           int cont16 = 0; int cont17 = 0; int cont18 = 0; int cont19 = 0; int cont20 = 0; int cont21 = 0; int cont22 = 0; int cont23 = 0;
           int cont24 = 0; int cont25 = 0; int cont26 = 0;
           for(int i = 0; i < datos.Rows.Count; i++)
           {
               if(datos.Rows[i]["respuesta"].ToString() == "Pre-jardín")
               {
                   cont++;
               }
               else if(datos.Rows[i]["respuesta"].ToString() == "Jardín I o A o Kínder")
               {
                   cont1++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Jardín II o B, Transición o Grado 0")
               {
                   cont2++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Primero")
               {
                   cont3++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Segundo")
               {
                   cont4++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Tercero")
               {
                   cont5++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Cuarto")
               {
                   cont6++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Quinto")
               {
                   cont7++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Sexto")
               {
                   cont8++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Séptimo")
               {
                   cont9++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Octavo")
               {
                   cont10++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Noveno")
               {
                   cont11++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Décimo")
               {
                   cont12++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Once")
               {
                   cont13++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Doce - Normal Superior")
               {
                   cont14++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Trece - Normal Superior")
               {
                   cont15++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Educación discapacidad cognitiva no integrada")
               {
                   cont16++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Educación discapacidad auditiva no integrada")
               {
                   cont17++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Educación discapacidad visual no integrada")
               {
                   cont18++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Educación discapacidad motora no integrada")
               {
                   cont19++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Educación discapacidad múltiple no integrada")
               {
                   cont20++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Ciclo 1 Adultos")
               {
                   cont21++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Ciclo 2 Adultos")
               {
                   cont22++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Ciclo 3 Adultos")
               {
                   cont23++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Ciclo 4 Adultos")
               {
                   cont24++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Ciclo 5 Adultos")
               {
                   cont25++;
               }
               else if (datos.Rows[i]["respuesta"].ToString() == "Ciclo 6 Adultos")
               {
                   cont26++;
               }
           }
           ca += "<ul style='list-style-type: disc;'>";
           ca += "<li>Pre-jardín: " + cont + "</li>";
           ca += "<li>Jardín I o A o Kínder: " + cont1 + "</li>";
           ca += "<li>Jardín II o B, Transición o Grado 0: " + cont2 + "</li>";
           ca += "<li>Primero: " + cont3 + "</li>";
           ca += "<li>Segundo: " + cont4 + "</li>";
           ca += "<li>Tercero: " + cont5 + "</li>";
           ca += "<li>Cuarto: " + cont6 + "</li>";
           ca += "<li>Quinto: " + cont7 + "</li>";
           ca += "<li>Sexto: " + cont8 + "</li>";
           ca += "<li>Séptimo: " + cont9 + "</li>";
           ca += "<li>Octavo: " + cont10 + "</li>";
           ca += "<li>Noveno: " + cont11 + "</li>";
           ca += "<li>Décimo: " + cont12 + "</li>";
           ca += "<li>Once: " + cont13 + "</li>";
           ca += "<li>Doce - Normal Superior: " + cont14 + "</li>";
           ca += "<li>Trece - Normal Superior: " + cont15 + "</li>";
           ca += "<li>Educación discapacidad cognitiva no integrada: " + cont16 + "</li>";
           ca += "<li>Educación discapacidad auditiva no integrada: " + cont17 + "</li>";
           ca += "<li>Educación discapacidad visual no integrada: " + cont18 + "</li>";
           ca += "<li>Educación discapacidad motora no integrada: " + cont19 + "</li>";
           ca += "<li>Educación discapacidad múltiple no integrada: " + cont20 + "</li>";
           ca += "<li>Ciclo 1 Adultos: " + cont21 + "</li>";
           ca += "<li>Ciclo 2 Adultos: " + cont22 + "</li>";
           ca += "<li>Ciclo 3 Adultos: " + cont23 + "</li>";
           ca += "<li>Ciclo 4 Adultos: " + cont24 + "</li>";
           ca += "<li>Ciclo 5 Adultos: " + cont25 + "</li>";
           ca += "<li>Ciclo 6 Adultos: " + cont26 + "</li>";
           ca += "</ul>";
       }
      
       return ca;
   }

}