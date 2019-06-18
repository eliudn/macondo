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

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string descarEvi(){
    	string ca="";
    	LineaBase desEvi= new LineaBase();
    	DataTable prue =desEvi.evidenciaDescarga();

    	 if (prue != null && prue.Rows.Count > 0){
    	 	ca= "true&";
    	 	ca+=	"<script>alert('si hay dato')</script>";
    	 }else{
    	 	ca+=  "<script>alert('no hay dato')</script>";
    	 }
    	 
    	 return ca;
    }
}