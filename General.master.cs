using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class General : System.Web.UI.MasterPage
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["datos"] = true;
        if (!IsPostBack)
        {
    
            if (Session["codperfil"] != null)
            {
                Usuario user = new Usuario();
                //lblRegistrado.Text = "Bienvenido: <b>" + Session["nombre"].ToString() + "</b>";
                lblRegistrado.Text = "" + Session["nombre"].ToString() + "";
                cssmenu.InnerHtml = cargarMenu();
                try
                {
                   // lblcargarFoto.Text = buscarImagenUsuario();
                    buscarImagenUsuario();

                }
                catch (Exception) { }
                //if (Session["codtipousuario"].ToString() == "1")
                //{
                //   // PanelAyuda.Visible = true;
                //}
                //else
                //{
                //   // PanelAyuda.Visible = false;
                //}
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }
        }
    }
    private string cargarMenu()
    {
       
        string linkpagina = Request.Url.Segments[Request.Url.Segments.Length - 1];
        string cadena = "";
        string codmenu = ""; string nombremenu = ""; string link = ""; string target = "";
        Menu men = new Menu();
        DataTable datos = men.cargarMenuSuperior(Session["codperfil"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            //cadena += "<ul class='collapsible' data-collapsible='accordion'>";
            //cadena += "<ul>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                codmenu = datos.Rows[i]["cod"].ToString();
                nombremenu = datos.Rows[i]["nombre"].ToString();
                link = datos.Rows[i]["link"].ToString();
                DataTable datos2 = men.cargarMenu2Nivel(codmenu, Session["codperfil"].ToString());
                if (datos2 != null && datos2.Rows.Count > 0)//Si tiene submenu
                {
                    string activo = "no";
                    for (int j = 0; j < datos2.Rows.Count; j++)
                    {
                        if (datos2.Rows[j]["link"].ToString() == linkpagina || datos2.Rows[j]["link"].ToString() == linkpagina + ".aspx")
                        {
                            activo = "si";
                        }
                    }

                    if (activo == "no")
                    {

                        cadena += "<li ><div class='link'><i class='fa fa-user'></i><img class='imgMenu' src='" + datos.Rows[i]["imagen"].ToString() + "' />" + nombremenu + "<i class='fa fa-chevron-down'></i></div>";
                        //cadena += "<li class='bold'><a href='" + link + "' class='waves-effect waves-teal' ><span><img class='imgMenu' src='" + datos.Rows[i]["imagen"].ToString() + "' />" + nombremenu + "</span></a>";
                        cadena += "<ul class='submenu'>";
                    }
                    else
                    {
                        cadena += "<li class='open'><div class='link'><i class=''></i><img class='imgMenu' src='" + datos.Rows[i]["imagen"].ToString() + "' />" + nombremenu + "<i class='fa fa-chevron-down'></i></div>";
                        //cadena += "<li class='bold active'><a href='" + link + "' class='waves-effect waves-teal'><span><img class='imgMenu' src='" + datos.Rows[i]["imagen"].ToString() + "' />" + nombremenu + "</span></a>";
                        cadena += "<ul class='submenu' style='display:block'>";
                    }

                    for (int j = 0; j < datos2.Rows.Count; j++)
                    {
                        codmenu = datos2.Rows[j]["cod"].ToString();
                        nombremenu = datos2.Rows[j]["nombre"].ToString();
                        link = datos2.Rows[j]["link"].ToString();
                        target = datos2.Rows[j]["target"].ToString();
                        if (datos2.Rows[j]["link"].ToString() == linkpagina || datos2.Rows[j]["link"].ToString() == linkpagina + ".aspx")
                        {
                            cadena += "<li><a class='active' target='" + target + "' href='" + link + "'><span>" + nombremenu + "</span></a></li>";
                        }
                        else
                        {
                            cadena += "<li ><a  target='" + target + "' href='" + link + "'><span>" + nombremenu + "</span></a></li>";
                        }
                    }
                    cadena += "</ul>";
                }
                else
                {
                    cadena += "<li ><a class='link' target='" + datos.Rows[i]["target"].ToString() + "' title='" + datos.Rows[i]["alt"].ToString() + "' href='" + link + "'><span><img class='imgMenu' src='" + datos.Rows[i]["imagen"].ToString() + "' />" + nombremenu + "</span></a>";
                }
            }
           // cadena += "</ul>";
        }
        return cadena;
    }

  
    
    
    
    
    
    
    
    
    protected void btnSesion_Click(object sender, EventArgs e)
    {        
        Session.RemoveAll();
        Response.Redirect("default.aspx");
    }
    private string buscarImagenUsuario()
    {
        string ca = "";

        imgPerfilGeneral.ImageUrl = "~/Imagenes/login/perfil/gobernacion.png";

        //if (Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador y asesor CUC
        //{
        //    imgPerfilGeneral.ImageUrl = "~/Imagenes/login/perfil/cuc.png";
        //}
        //else if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "11")//Coordinador y asesor UniMag
        //{
        //    imgPerfilGeneral.ImageUrl = "~/Imagenes/login/perfil/unimag.png";
        //}
        //else if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "13")//Coordinador y asesor Funtics
        //{
        //    imgPerfilGeneral.ImageUrl = "~/Imagenes/login/perfil/funtics.png";
        //    //ca = "<img src='Imagenes/login/perfil/funtics.png' style='width:100px;height:100px;margin:0;border-radius:100px;' />";
        //}


        //Usuario usu = new Usuario();
        //DataRow dr = usu.buscarImagenUsuario(Session["codusuario"].ToString());
        //if (dr != null)
        //{
        //    //string cadena = dr["path"].ToString();
        //    //string resultado = cadena.Replace("~", "");
        //    //ca = "<img src='" + resultado + "' style='width:100px;height:100px;margin:0;border-radius:100px;' />";
        //    imgPerfilGeneral.ImageUrl = dr["path"].ToString();
            
        //}
        //else
        //{
        //    ca = "<img src='Imagenes/img-default.png' style='width:100px;height:100px;margin:0;border-radius:100px;' />";
        //    //imgPerfilGeneral.ImageUrl = "~/Imagenes/img-default.png";
            
        //}
        return ca;
    }
 /*   protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        if (menuizq.Attributes["class"].Equals("cm-sidebar"))
        {
            menuizq.Attributes.Add("class", "left2");
            contenido.Attributes.Add("class", "content content-sin-menu");
        }
        else
        {
            menuizq.Attributes.Add("class", "cm-sidebar");
            contenido.Attributes.Add("class", "content content-con-menu");
        }

    }*/

   }
