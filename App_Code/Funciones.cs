using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Descripción breve de Funciones
/// </summary>
public class Funciones
{
	public Funciones()
	{
		
	}
    public string colocarPalabraenMayuscula(string palabra)
    {
        palabra = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palabra.ToLower());
        return palabra;
    }

    //Funciones de Fecha y Hora
    public string getHoraActual()
    {
        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("HH:mm:ss");
        return horares;
    }
    public string getFechaAñoHoraActual()
    {
        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        return horares;
    }
    public string getFechaAñoActual()
    {       
        string fecha = String.Format("{0:yyyy-MM-dd}", DateTime.Now.Date);
        return fecha;
    }
    public string getAñoActual()
    {
        string fecha = String.Format("{0:yyyy}", DateTime.Now.Date);
        return fecha;
    }
    public string getFechaDiaActual()
    {
        string fecha = String.Format("{0:dd-MM-yyyy}", DateTime.Now.Date);
        return fecha;
    }
    public string convertFechaAño(string fechadia)
    {
        string fecha = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(fechadia));
        return fecha;
    }
    public string convertFechaDia(string fechaaño)
    {
        if (fechaaño != "")
        {
            string fecha = String.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(fechaaño));
            return fecha;
        }
        else
        {
            return fechaaño = "";
        }
    }
    public string convertFechaHoraDia(string fechahoraaño)
    {
        if (fechahoraaño != "")
        {
            string fecha = String.Format("{0:dd-MM-yyyy HH:mm:ss}", Convert.ToDateTime(fechahoraaño));
            return fecha;
        }
        else
        {
            return fechahoraaño = "";
        }
    }
    public string convertFechaAñoMesDiaHora(string fechahoraaño)
    {
        if (fechahoraaño != "")
        {
            string fecha = String.Format("{0:yyyy-MM-dd HH:mm:ss}", Convert.ToDateTime(fechahoraaño));
            return fecha;
        }
        else
        {
            return fechahoraaño = "";
        }
    }
    public string enletras(string num)
    {
        string res, dec = "";
        Int64 entero;
        int decimales;
        double nro;
        try
        {
            nro = Convert.ToDouble(num);
        }
        catch
        {
            return "";
        }
        entero = Convert.ToInt64(Math.Truncate(nro));
        decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
        if (decimales > 0)
        {
            dec = " CON " + decimales.ToString() + "/100";
        }
        res = toText(Convert.ToDouble(entero)) + dec;
        return res;
    }
    private string toText(double value)
    {
        string Num2Text = "";
        value = Math.Truncate(value);
        if (value == 0) Num2Text = "CERO";
        else if (value == 1) Num2Text = "uno";
        else if (value == 2) Num2Text = "dos";
        else if (value == 3) Num2Text = "tres";
        else if (value == 4) Num2Text = "cuatro";
        else if (value == 5) Num2Text = "cinco";
        else if (value == 6) Num2Text = "seis";
        else if (value == 7) Num2Text = "siete";
        else if (value == 8) Num2Text = "ocho";
        else if (value == 9) Num2Text = "nueve";
        else if (value == 10) Num2Text = "diez";
        else if (value == 11) Num2Text = "once";
        else if (value == 12) Num2Text = "doce";
        else if (value == 13) Num2Text = "trece";
        else if (value == 14) Num2Text = "catorce";
        else if (value == 15) Num2Text = "quince";
        else if (value < 20) Num2Text = "dieci" + toText(value - 10);
        else if (value == 20) Num2Text = "veinte";
        else if (value < 30) Num2Text = "veinti" + toText(value - 20);
        else if (value == 30) Num2Text = "treinta";
        else if (value == 40) Num2Text = "cuarenta";
        else if (value == 50) Num2Text = "cincuenta";
        else if (value == 60) Num2Text = "sesenta";
        else if (value == 70) Num2Text = "setenta";
        else if (value == 80) Num2Text = "ochenta";
        else if (value == 90) Num2Text = "noventa";
        else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " y " + toText(value % 10);
        else if (value == 100) Num2Text = "cien";
        else if (value < 200) Num2Text = "ciento " + toText(value - 100);
        else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "cientos";
        else if (value == 500) Num2Text = "quinientos";
        else if (value == 700) Num2Text = "setecientos";
        else if (value == 900) Num2Text = "novecientos";
        else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
        else if (value == 1000) Num2Text = "mil";
        else if (value < 2000) Num2Text = "mil " + toText(value % 1000);
        else if (value < 1000000)
        {
            Num2Text = toText(Math.Truncate(value / 1000)) + " mil";
            if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
        }
        else if (value == 1000000) Num2Text = "un millon";
        else if (value < 2000000) Num2Text = "un millon " + toText(value % 1000000);
        else if (value < 1000000000000)
        {
            Num2Text = toText(Math.Truncate(value / 1000000)) + " millones ";
            if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
        }
        else if (value == 1000000000000) Num2Text = "un billon";
        else if (value < 2000000000000) Num2Text = "un billon " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
        else
        {
            Num2Text = toText(Math.Truncate(value / 1000000000000)) + " billones";
            if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
        }
        return Num2Text;
    }
    public static long insertarVisita(string codusuario, string codrol)
    {
        Usuario usu = new Usuario();
        return usu.agregarVisita(codusuario, codrol);
    }
    public static void regitrarVisita(string codsession, string url)
    {
        Usuario usu = new Usuario();
        usu.agregarVisitaPagina(codsession, url);
    }  
    public Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}