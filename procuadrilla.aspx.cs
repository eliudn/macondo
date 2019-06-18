using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class procuadrilla : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Usuario user = new Usuario();
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
            PanelCoordinadorAdd.Attributes.Add("style", "display:none");
            PanelCoordinadorEditar.Attributes.Add("style", "display:none");
            PanelCoordinadorEliminar.Attributes.Add("style", "display:none");
            ddProyectos(dropProyecto);
            ddProyectos2(dropProyectoAdd);
            ddProyectos2(dropProyectoEditar);
            ddProyectos2(dropProyectoEliminar);
            ddCoordiandores(dropCoordinadorAdd);
            ddCoordiandoresEditar(dropCoordinadorEditar);
            ddCoordiandoresEditar(dropCoordinadorEliminar);
            rblTecnicos(cblTecnicos);
            rblTecnicos2(cblTecnicosEditar);
            
        }
    }
    private void ddProyectos(DropDownList drop)
    {
        drop.DataSource = pro.cargarProyectos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Ver Todos"));
    }
    private void rblTecnicos(CheckBoxList rbl)
    {
        rbl.DataSource = user.cargarTecnicos();
        rbl.DataTextField = "nombre";
        rbl.DataValueField = "cod";
        rbl.DataBind();
    }
    private void rblTecnicos2(CheckBoxList rbl)
    {
        DataTable datec = user.cargarTecnicos();
        DataTable dacor = user.cargarTecnicosxCoordinador(dropCoordinadorEditar.SelectedValue, dropProyectoEditar.SelectedValue);
        if (datec != null && datec.Rows.Count > 0)
        {
            rbl.DataSource = datec;
            rbl.DataTextField = "nombre";
            rbl.DataValueField = "cod";
            rbl.DataBind();
            if (dacor != null && dacor.Rows.Count > 0)
            {
                for (int i = 0; i < rbl.Items.Count; i++)
                {
                    for (int j = 0; j < dacor.Rows.Count; j++)
                    {
                        if (rbl.Items[i].Value == dacor.Rows[j]["cod"].ToString())
                        {
                            rbl.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
    }
    private void ddCoordiandores(DropDownList drop)
    {
        drop.DataSource = user.cargarCoordinadores();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddCoordiandoresEditar(DropDownList drop)
    {
        drop.DataSource = user.cargarCoordinadores();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddProyectos2(DropDownList drop)
    {
        drop.DataSource = pro.cargarProyectos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnSeleccioneProyecto_Click(object sender, EventArgs e)
    {
        if (dropProyecto.SelectedIndex > 0)
        {
            gvCargarCuadrilla();

        }
        else
        {
            //Cargar todos los proyectos
            gvCargarCuadrilla();
        }
    }
    private void gvCargarCuadrilla()
    {
        armarTabla(pro.cargarTecnicosProyecto(llenarWhere(false)));
        btnAgregar.Visible = true;
    }
    private void armarTabla(DataTable datoTecnicos)
    {
        string ca = "";
        
            //detectar las categorias

        
        int sumar = 0;
        if (datoTecnicos != null && datoTecnicos.Rows.Count>0)
        {
            DataTable dtProyectos = new DataTable();
            dtProyectos.Columns.AddRange(new DataColumn[2] { new DataColumn("codproyecto"), new DataColumn("nombreproyecto") });
            string[] proyectos = new string[datoTecnicos.Rows.Count];
            for (int i = 0; i < datoTecnicos.Rows.Count; i++)
            {
                if (i == 0)
                {
                    dtProyectos.Rows.Add(datoTecnicos.Rows[i]["codproyecto"].ToString(), datoTecnicos.Rows[i]["nombre"].ToString());
                    proyectos[sumar] = datoTecnicos.Rows[i]["codproyecto"].ToString();
                    sumar += 1;
                }
                else
                {
                    if (proyectos[sumar - 1] != datoTecnicos.Rows[i]["codproyecto"].ToString())
                    {
                        dtProyectos.Rows.Add(datoTecnicos.Rows[i]["codproyecto"].ToString(), datoTecnicos.Rows[i]["nombre"].ToString());
                        proyectos[sumar] = datoTecnicos.Rows[i]["codproyecto"].ToString();
                        sumar += 1;
                    }
                }
            }

            //hacer un .Select buscando por codcategoria obtenido en el String[]
            if (dtProyectos != null && dtProyectos.Rows.Count > 0)
            {
                ca += "<table class='gridBoletin'>";
                ca += "<tr><th>Proyecto</th>";
                //ca+="<th>hhh</th>";
                ca+="<th>Coordinadores</th>";
                ca += "<th>Técnicos</th></tr>";
                for (int i = 0; i < dtProyectos.Rows.Count; i++)
                {
                    string codproyecto = dtProyectos.Rows[i]["codproyecto"].ToString();
                    string nombreproyecto = dtProyectos.Rows[i]["nombreproyecto"].ToString();

                    
                    DataRow[] foundRowsPro = datoTecnicos.Select("codproyecto = '" + codproyecto + "'");
                    if (foundRowsPro != null && foundRowsPro.Length > 0)
                    {
                        ca += "<tr style='border-top:2px solid #000'>";
                        ca += "<td rowspan='" + foundRowsPro.Length + "'>" + nombreproyecto + "</td>";                        
                        //ca += "<td rowspan='" + foundRowsPro.Length + "' style='background-color:#ccc;'>" + foundRowsPro.Length + "</td>";

                        //cargar los Tecnicos, pero primero debemos saber los coordinadores
                        int sw = 0;
                        for (int t = 0; t < foundRowsPro.Length; t++)
                        {
                            //ahora necesito saber los coordinadores, cuantos ténicos hay por coordinador
                            DataTable dtCoord = new DataTable(); dtCoord.Columns.AddRange(new DataColumn[2] { new DataColumn("codusuario"), new DataColumn("nombrecoord") });

                            if (sw == 0)
                            {
                                int sumarc = 0;
                                string[] coordinadores = new string[foundRowsPro.Length];
                                for (int c = 0; c < foundRowsPro.Length; c++)
                                {
                                    if (c == 0)
                                    {
                                        dtCoord.Rows.Add(foundRowsPro[c]["codusuario"].ToString(), foundRowsPro[c]["nombrecoord"].ToString());
                                        coordinadores[sumarc] = foundRowsPro[c]["codusuario"].ToString();
                                        sumarc += 1;
                                    }
                                    else
                                    {
                                        if (coordinadores[sumarc - 1] != foundRowsPro[c]["codusuario"].ToString())
                                        {
                                            dtCoord.Rows.Add(foundRowsPro[c]["codusuario"].ToString(), foundRowsPro[c]["nombrecoord"].ToString());
                                            coordinadores[sumarc] = foundRowsPro[c]["codusuario"].ToString();
                                            sumarc += 1;
                                        }
                                    }
                                }


                                sw = 1;//esto es para que no se repita el coordinador (ya sabemos cuantos coordinadores hay en X proyecto)

                                for (int co = 0; co < dtCoord.Rows.Count; co++)
                                {
                                    string codcoordinador = dtCoord.Rows[co]["codusuario"].ToString();
                                    string nombrecoordinador = dtCoord.Rows[co]["nombrecoord"].ToString();
                                    //ahora buscar cuantos tecnicos tiene ese coordinador
                                    DataRow[] foundRowsTecnicos = datoTecnicos.Select("codproyecto='" + codproyecto + "' AND codusuario='" + codcoordinador + "'");
                                    if (foundRowsTecnicos != null && foundRowsTecnicos.Length > 0)
                                    {
                                        if (foundRowsTecnicos.Length > 1)
                                        {
                                            ca += "<td rowspan='" + foundRowsTecnicos.Length + "' style='background-color:#FFE9E9;'>" + nombrecoordinador + "</td>";

                                            //el primer tecnico se coloca aqui
                                            ca += "<td>" + foundRowsTecnicos[0]["tecnicos"].ToString() + "</td>";

                                            ca += "</tr>";

                                            //el 2do en adelante dentro del for
                                            for (int tec = 1; tec < foundRowsTecnicos.Length; tec++)
                                            {
                                                ca += "<tr><td>" + foundRowsTecnicos[tec]["tecnicos"].ToString() + "</td></tr>";
                                            }
                                        }
                                        else
                                        {
                                            ca += "<td rowspan='" + foundRowsTecnicos.Length + "' style='background-color:#FFE9E9;'>" +  nombrecoordinador + "</td>";
                                            //el primer y unico tecnico se coloca aqui
                                            ca += "<td>" + foundRowsTecnicos[0]["tecnicos"].ToString() + "</td>"; ;
                                        }
                                    }
                                }
                                
                            }
                    
                        }

                    }                    
                }
                ca += "</table>";
            }

            
        
        }
        else
        {
            ca = "No se encontraron cuadrillas en este proyecto";
        }

        lblImpresion.Text =ca;
    }
    private bool buscarProyecto(string[,] matriz, string proyecto)
    {
        int i = 0;
        bool seguir = true;
        while (i < matriz.GetLength(0) && seguir)
        {
            if (matriz[i, 0] != null)
            {
                if (matriz[i, 0].ToString() == proyecto)
                {
                    seguir = false;
                }
            }
            i++;
        }
        return !seguir;
    }
    private bool buscarCoordinador(string[,] matriz, string coordinador)
    {
        int i = 0;
        bool seguir = true;
        while (i < matriz.GetLength(0) && seguir)
        {
            if (matriz[i, 0] != null)
            {
                if (matriz[i, 0].ToString() == coordinador)
                {
                    seguir = false;
                }
            }
            i++;
        }
        return !seguir;
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        this.PanelCoordinadorAdd_ModalPopupExtender.Show();
    }
    protected void btnAddCuadrilla_Click(object sender, EventArgs e)
    {
        bool eligio = false;
        int j = 0, r = 0;
        for (int i = 0; i < cblTecnicos.Items.Count; i++)
        {
            if (cblTecnicos.Items[i].Selected)
            {
                eligio = true;
                if (pro.agregarTecnicoCuadrilla(dropCoordinadorAdd.SelectedValue, cblTecnicos.Items[i].Value, dropProyectoAdd.SelectedValue))
                {
                    j++;
                }
                else
                {
                    r++;
                }
            }
        }
        if (eligio)
        {
            if (j > 0 && r==0)
            {
                mostrarmensaje("exito", "Se agraron "+j+" tecnicos al proyecto "+dropProyectoAdd.SelectedItem.Text);
                gvCargarCuadrilla();
                dropProyectoAdd.SelectedIndex = 0;
                dropCoordinadorAdd.SelectedIndex = 0;
                rblTecnicos(cblTecnicos);
            }
            else if (j > 0 && r > 0)
            {
                mostrarmensaje("exito", "Se agraron " + j + "  y se rechazaron "+r+" tecnicos");
                gvCargarCuadrilla();
                dropProyectoAdd.SelectedIndex = 0;
                dropCoordinadorAdd.SelectedIndex = 0;
                rblTecnicos(cblTecnicos);
            }
            else if(r>0)
            {
                mostrarmensaje("error", "ERROR: No se agrego ningún TECNICO");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe seleccionar minimo un TECNICO");
            this.PanelCoordinadorAdd_ModalPopupExtender.Show();
        }
    }
    private string llenarWhere(bool tecnico)
    {
        int numero = 2;
        string[] cond;
        cond = new string[numero];

         cond[0] = string.Empty;  //codrol
         cond[1] = string.Empty;  //codproyecto
         if (tecnico)
         {
             cond[0] = "asig.`codrolsub`='5'"; // Se cargar por defecto los tecnicos
         }
         else
         {
             cond[0] = "asig.`codrol`='2'"; // Se cargar por defecto los coordinadores
         }
      
        if (dropProyecto.SelectedIndex > 0)
        {
            cond[1] = "asig.`codproyecto`='" + dropProyecto.SelectedValue + "'";
        }
        string where = "";
        int primero = 0;
        for (int i = 0; i < numero; i++)
        {
            if (cond[i] != string.Empty)
            {
                if (primero == 0)
                {
                    where += "WHERE " + cond[i];
                }
                if (primero > 0)
                {
                    where += " AND " + cond[i];
                }
                if (primero == 0)
                {
                    primero = 1;
                }
            }
        }
        return where;
    }

    protected void dropCoordEditar_SelectedIndexChanged(object sender, EventArgs e)
    {
        rblTecnicos2(cblTecnicosEditar);
        this.PanelCoordinadorEditar_ModalPopupExtender.Show();

    }
    protected void btnEditarCuadrilla_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnEditarCuadrilla2_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        
        bool eligio = false;
        int j = 0, r = 0, d = 0, a = 0;
        for (int i = 0; i < cblTecnicosEditar.Items.Count; i++)
        {
            if (cblTecnicosEditar.Items[i].Selected)
            {
                DataRow dat = usu.buscarTecnicoxCoordinador(cblTecnicosEditar.Items[i].Value, dropCoordinadorEditar.SelectedValue, dropProyectoEditar.SelectedValue);
                if(dat != null)
                {
                    a++;
                }
                else
                {
                    eligio = true;
                    if (pro.agregarTecnicoCuadrilla(dropCoordinadorEditar.SelectedValue, cblTecnicosEditar.Items[i].Value, dropProyectoEditar.SelectedValue))
                    {
                        j++;
                    }
                    else
                    {
                        r++;
                    }
                }

            }
            else
            {
                DataRow dat = usu.buscarTecnicoxCoordinador(cblTecnicosEditar.Items[i].Value,dropCoordinadorEditar.SelectedValue,dropProyectoEditar.SelectedValue);
                if (dat != null)
                {
                    if (usu.EliminarTecnicoxCordinador(dat["cod"].ToString()))
                    {
                        d++;
                    }
                }
            }
        }
        if (eligio)
        {
            if (j > 0 && r == 0 )
            {
                mostrarmensaje("exito", "Se agregaron " + j + " técnicos, Se restaron " + d + " técnicos y quedaron " + a + " antiguos en el proyecto " + dropProyectoEditar.SelectedItem.Text);
                gvCargarCuadrilla();
                dropProyectoEditar.SelectedIndex = 0;
                dropCoordinadorEditar.SelectedIndex = 0;
                rblTecnicos(cblTecnicosEditar);
            }
            else if (j > 0 && r > 0)
            {
                mostrarmensaje("exito", "Se agraron " + j + "  y se rechazaron " + r + " tecnicos");
                gvCargarCuadrilla();
                dropProyectoEditar.SelectedIndex = 0;
                dropCoordinadorEditar.SelectedIndex = 0;
                rblTecnicos(cblTecnicosEditar);
            }
            else if (r > 0)
            {
                mostrarmensaje("error", "ERROR: No se agrego ningún TECNICO");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe seleccionar minimo un TECNICO");
            this.PanelCoordinadorEditar_ModalPopupExtender.Show();
        }
    }

    protected void btnEliminarCoordinador_Click(object sender, EventArgs e)
    {

    }

    protected void btnEliminarCoordinador2_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();

        if(dropCoordinadorEliminar.SelectedIndex > 0 && dropProyectoEliminar.SelectedIndex > 0)
        {
            if(usu.eliminarCoordinadoryProyecto(dropProyectoEliminar.SelectedValue, dropCoordinadorEliminar.SelectedValue))
            {
                mostrarmensaje("exito","Acción realizada con éxito");
                gvCargarCuadrilla();
            }
            else
            {
                mostrarmensaje("error", "Error al eliminar.");
                gvCargarCuadrilla();
            }
        }
        else
        {
            mostrarmensaje("error","Escoja una opción.");
            gvCargarCuadrilla();
        }
    }
 
}