using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;
using System.Drawing;

public partial class inv_almacen_listado2 : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Bodegas bod = new Bodegas();
    Equipo equi = new Equipo();
    protected void Page_Load(object sender, EventArgs e)
    {
        //GridListProd.UseAccessibleHeader = true;
        //if (GridListProd.HeaderRow != null)
        //{
        //    GridListProd.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                if (Session["codrol"].ToString() == "8")
                {
                    gvCargarListado();
                    //ddProyecto(dropProyecto);
                }
                else
                {
                    string script = @"<script type='text/javascript'>alert('No tiene acceso a este módulo.');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
    private void ddProyecto(DropDownList drop)
    {
        DataTable proyectos = bod.cargarProyectosActivosxCoordinador(fun.getFechaAñoActual(),Session["codusuario"].ToString());
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataSource = proyectos;
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
    }
    protected void dropProyecto_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //gvCargarListado(dropProyecto.SelectedValue);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    private void gvCargarListado()
    {
        DataTable listado = equi.cargarListadoInventarioAlmacen();


        //Mostrar los inventarios del coordinador teniendo en cuenta que los campos codequipodetalle y codmovtecnico_coordinador_equipodetalle



        //GridListProd.DataSource = listado;
        //GridListProd.DataBind();

        //if (listado != null && listado.Rows.Count > 0)
        //{
        //    GridListProd.UseAccessibleHeader = true;
        //    if (GridListProd.HeaderRow != null)
        //    {
        //        GridListProd.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
    }

    protected void GridListProd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string cantidad;
            string cantmetros_max;
          
            cantidad = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "cantidad"));
            //cantmetros_max = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "cantmetros_max"));
            //if (cantidad == "0" && cantmetros_max == "0")
            if (cantidad == "0")
            {
                e.Row.BackColor = Color.LightCoral; // verde
                e.Row.ForeColor = Color.White;
            }

            //string ffin = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fechafingarantia"));

            //if (ffin != "")
            //{
            //    DateTime fechafin;

            //    fechafin = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "fechafingarantia"));

            //    DateTime localDateTime = DateTime.Now;

            //    if (fechafin <= localDateTime)
            //    {
            //        e.Row.Cells[11].BackColor = Color.FromName("#5A9986");
            //        e.Row.Cells[12].BackColor = Color.FromName("#5A9986");
            //    }
            //}
        }
    }


    protected void lnkCargarEvidencia_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        //string codfacturaproveedor = GridListProdCoorAlmacen.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codmovcoord_almacen = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Response.Redirect("inv_entregaalma_coord_evi.aspx?codmovcoord_almacen=" + codmovcoord_almacen);
    }

    [WebMethod(EnableSession = true)]
    public static string verrecorrido(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarProductoDeAlmacenACoordinador(codigo);

        if(detalle != null)
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th colspan='3'>SALIDA DE BODEGA PRINCIPAL</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Entregado por</th>";
            ca += "<th>Recibido por</th>";
            ca += "<th>Fecha de entrega</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>" + detalle["envia"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["recibe"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["fecha"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</tbody>";

            ca += "@" + detalle["codigo"].ToString();
         
        }
       

      
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarProductoCoordinadorTecnico(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarProductoDeCoordinadorATecnico(codigo);

        if (detalle != null)
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th colspan='3'>SALIDA DE BODEGA COORDINADOR</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Coordinador que Envía</th>";
            ca += "<th>Técnico que Recibe</th>";
            ca += "<th>Fecha</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>" + detalle["envia"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["recibe"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["fecha"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</tbody>";

            ca += "@" + detalle["codigo"].ToString();

        }
        else
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th>SALIDA DE BODEGA COORDINADOR</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>No hay información disponible</td>";
            ca += "</tr>";
            ca += "</tbody>";
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarProductoTecnicoCliente(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarProductoDeTecnicoACliente(codigo);

        if (detalle != null)
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th colspan='6'>SALIDA DE BODEGA TÉCNICO</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Proyecto</th>";
            ca += "<th>Técnico que Envía</th>";
            ca += "<th>Cliente que Recibe</th>";
            ca += "<th>Nro Actividad</th>";
            ca += "<th>Nro Ticket</th>";
            ca += "<th>Fecha</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>" + detalle["proyecto"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["envia"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["recibe"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["actividad"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["ticket"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["fecha"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</tbody>";

            ca += "@" + detalle["codigo"].ToString();

        }
        else
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th>SALIDA DE BODEGA TÉCNICO</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>No hay información disponible</td>";
            ca += "</tr>";
            ca += "</tbody>";
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarProductoClienteTecnico(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarProductoDeClienteATecnico(codigo);

        if (detalle != null)
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th colspan='6'>SALIDA DE BODEGA CLIENTE</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Cliente que Envía</th>";
            ca += "<th>Técnico que Recibe</th>";
            ca += "<th>Fecha</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>" + detalle["envia"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["recibe"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["fecha"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</tbody>";

            ca += "@" + detalle["codigo"].ToString();

        }
        else
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th>SALIDA DE BODEGA CLIENTE</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>No hay información disponible</td>";
            ca += "</tr>";
            ca += "</tbody>";
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarProductoTecnicoCoordinador(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarProductoDeTecnicoACoordinador(codigo);

        if (detalle != null)
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th colspan='6'>SALIDA DE BODEGA TÉCNICO</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Cliente que Envía</th>";
            ca += "<th>Técnico que Recibe</th>";
            ca += "<th>Fecha</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>" + detalle["envia"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["recibe"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["fecha"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</tbody>";

            ca += "@" + detalle["codigo"].ToString();

        }
        else
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th>SALIDA DE BODEGA TÉCNICO</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>No hay información disponible</td>";
            ca += "</tr>";
            ca += "</tbody>";
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarProductoCoordinadorAlmacen(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = null;

        if (detalle != null)
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th colspan='6'>SALIDA DE SEDE A BODEGA PRINCIPAL</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Cliente que Envía</th>";
            ca += "<th>Técnico que Recibe</th>";
            ca += "<th>Fecha</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>" + detalle["envia"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["recibe"].ToString() + "</td>";
            ca += "<td align='center'>" + detalle["fecha"].ToString() + "</td>";
            ca += "</tr>";
            ca += "</tbody>";

            ca += "@" + detalle["codigo"].ToString();

        }
        else
        {
            ca += "true@";
            ca += "<thead>";
            ca += "<tr>";
            ca += "<th>SALIDA DE BODEGA COORDINADOR</th>";
            ca += "</tr>";
            ca += "</thead>";

            ca += "<tbody>";
            ca += "<tr>";
            ca += "<td align='center'>No hay información disponible</td>";
            ca += "</tr>";
            ca += "</tbody>";
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarproducto(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarEquipoDetalleEnInventario(codigo);

        if (detalle != null)
        {
            ca += "encontro@";
            if(detalle["unidad"].ToString() == "Mts")
            {
                ca += detalle["serial"].ToString() + "@";
                ca += detalle["cantmetros_max"].ToString() + "@";
                ca += detalle["unidad"].ToString();
            }
            else if (detalle["unidad"].ToString() == "Und")
            {
                ca += detalle["serial"].ToString() + "@";
                ca += detalle["cantidad"].ToString() + "@";
                ca += detalle["unidad"].ToString();
            }
            else
            {
                ca = "noencontro";
            }
           
        }

      


        return ca;
    }

   
    [WebMethod(EnableSession = true)]
    public static string editarproducto(string codigo, string cantactual, string cantingresar, string codoperacion, string unidad)
    {
        int total = 0;
        int validar = 0;
        string ca = "";

        if (codoperacion == "s")
        {
            total = Convert.ToInt32(cantactual) + Convert.ToInt32(cantingresar);
        }
        else
        {
            if (Convert.ToInt32(cantactual) < Convert.ToInt32(cantingresar))
            {
                ca = "false@";
                validar = 1;
            }
            else
            {
                total = Convert.ToInt32(cantactual) - Convert.ToInt32(cantingresar);

            }
            
        }

        if (validar == 0)
        {
            Equipo equi = new Equipo();

            if (unidad == "Mts")
            {
                if (equi.editarCantidadEquipoDetalleAlmacenMts(codigo, Convert.ToString(total), unidad))
                {
                    ca = "true@";
                }
                else
                {
                    ca = "false2@";
                }
            }
            else
            {
                if (equi.editarCantidadEquipoDetalleAlmacenUnd(codigo, Convert.ToString(total), unidad))
                {
                    ca = "true@";
                }
                else
                {
                    ca = "false2@";
                }
            }
        }

        return ca;
    }

    protected void btnBusqCodFactura_Click(object sender, EventArgs e)
    {
        Proveedores prov = new Proveedores();
        DataRow dato = prov.buscarProveedorFacturaporAutoCompleter(txtBusqFactura.Text);
        if (dato != null)
        {
            lblCodFacturaProoveedor.Text = dato["codigo"].ToString();

            string open = "abrirventanaeditar();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
           
        }
    }

    protected void lnkEditar_Click(object sender, EventArgs e)
    {
        //LinkButton btndetails = sender as LinkButton;
        //GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codquipodetalle = GridListProd.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  


        //Response.Redirect("inv_almaceneditpro.aspx?codquipodetalle=" + codquipodetalle);
    }

    [WebMethod(EnableSession = true)]
    public static string buscarproductodebaja(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow detalle = equi.buscarEquipoDetalleEnInventario(codigo);

        if (detalle != null)
        {
            ca += "encontro@";
            ca += detalle["serial"].ToString() + "@";
            ca += detalle["estado"].ToString();
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string dardebajaproducto(string codigo, string comentario)
    {
        string ca = "";
        Equipo equi = new Equipo();

        if (equi.agregarBajadeProducto(codigo, HttpContext.Current.Session["codusuariorol"].ToString(), comentario))
        {
            ca = "true@";
        }
        else
        {
            ca = "false";
        }

       
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarproducto(string codigo)
    {
        string ca = "";
        Equipo equi = new Equipo();

        DataRow dat = equi.buscarEquipoDetalleEnCoordinador(codigo);

        if (dat == null)
        {
            equi.eliminarProducto(codigo);
            //Falta el procedimiento de eliminar las evidencias
            ca = "true@";
        }
        else
        {
            ca = "false@";
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistado()
    {
        string ca = "";
        Equipo equi = new Equipo();


        DataTable listado = equi.cargarListadoInventarioAlmacen();

        if (listado != null && listado.Rows.Count > 0)
        {
            ca = "true@";
            for(int i = 0; i < listado.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + listado.Rows[i]["usuario"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["codfamilia"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["familia"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["codproducto"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["producto"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["serial"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["rotulo"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["oficina"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["codbarra"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["descripcion"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["cantidad"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["estado"].ToString() + "</td>";
                ca += "<td><a href='equipocodbarra.aspx?co=" + listado.Rows[i]["codoficina"].ToString() + "&cp=" + listado.Rows[i]["codproducto"].ToString() + "&r=" + listado.Rows[i]["rotulo"].ToString() + "&pag=nprod' ><img src='Imagenes/codbarra.png' width='20' title='Generar Código de Barra' /></a></td>";
                ca += "<td><a href='inv_almacen_editpro.aspx?codequipodetalle=" + listado.Rows[i]["codigo"].ToString() + "' ><img src='Imagenes/edit.png' width='20' title='Editar Producto' /></a></td>";
                ca += "<td><a href='javascript:void(0)' onclick='verrecorrido(" + listado.Rows[i]["codigo"].ToString() + ");'><img src='Imagenes/ojo.png' width='20' title='Ver recorrido de entrega' /></a></td>";
                ca += "<td><a class='zoom' href='Evidencias_Almacen/storealcaldiasoledad/" + listado.Rows[i]["evidencia"].ToString() + "'><img  src='Imagenes/img.png' width='20' alt='" + listado.Rows[i]["evidencia"].ToString() + "' title='Ver evidencia' /></a></td>";
                ca += "<td><a href='javascript:void(0)' onclick='dardebaja(" + listado.Rows[i]["codigo"].ToString() + ");'><img src='Imagenes/down_pro.png' width='20' title='Dar de Bajar' /></a></td>";
                ca += "<td><a href='javascript:void(0)' onclick='eliminarpro(" + listado.Rows[i]["codigo"].ToString() + ");'><img src='Imagenes/icon-delete.png' width='20' title='Eliminar Producto' /></a></td>";
                ca += "</tr>";
            }
        }

       
        return ca;
    }

}