using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class editcliente : System.Web.UI.Page
{
    Cliente client = new Cliente();
    Usuario user = new Usuario();
    Localidad local = new Localidad();
    Equipo equ = new Equipo();
    Proyecto pro = new Proyecto();

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
    private void ocultarPaneles()
    {
        PanelEditarSede.Attributes.Add("style", "display:none");
        PanelAgregarSede.Attributes.Add("style", "display:none");
        PanelAddContacto.Attributes.Add("style", "display:none");
        PanelEditContacto.Attributes.Add("style", "display:none");
        PanelAgregaEquipo.Attributes.Add("style", "display:none");
        PanelEditEquipo.Attributes.Add("style", "display:none");
        PanelDocumentoAdd.Attributes.Add("style", "display:none");
        PanelDescripcionEquipo.Attributes.Add("style", "display:none");
        PanelAgregarTickets.Attributes.Add("style", "display:none");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");

        if (!IsPostBack)
        {
            ocultarPaneles();
            obtenerGET();
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();

            if (lblCodCliente.Text != string.Empty)
            {
                ddTipoCLiente(dropTipoCliente);

                ddMunicipio(dropMunicipio);
                ddMunicipio(dropMunicipioAddSede);

                ddCargos(dropCargoContacto);
                ddCargos(dropCargoContactoEdit);

                ddEquipos(dropEquipo);
                ddEquipos(dropEquipoEditar);

                buscarCliente(lblCodCliente.Text);

                cargarSedes(lblCodCliente.Text);

                ddSolicitudes(dropSolicitudAdd, true);
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se recibieron los parametros");
            }
        }
        lblTipoUsuario.Text = Session["codrol"].ToString();
        if (lblTipoUsuario.Text == "3")
        {
            GridSedes.Columns[12].Visible = false;
        }
    }
    private void obtenerGET()
    {
        try
        {
            lblCodCliente.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cc"]);
            lblCodProyecto.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cp"]);       
        }
        catch
        {
            throw new HttpException(500, "Error Interno");
        }
    }
    private void buscarCliente(string codcliente)
    {
        llenarDatos(client.buscarClienteCompleto(codcliente));
    }
    private void ddSolicitudes(DropDownList drop, bool add)
    {
        Cliente cli = new Cliente();
        DataTable datosSolicitudes = cli.cargarSolicitudes();
        drop.DataSource = datosSolicitudes;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        if (add)
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
        else
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void cargarSedes(string codcliente)
    {
       GridSedes.DataSource= client.cargarSedesCliente(codcliente);
       GridSedes.DataBind();
       if (GridSedes.Rows.Count > 0)
       {
           btnAgregarSede1.Visible = false;
       }
       else
       {
           btnAgregarSede1.Visible = true;
       }
    }
    private void llenarDatos(DataRow datoCliente)
    {
        if (datoCliente != null)
        {
            lblCodCliente.Text = datoCliente["cod"].ToString();
            lblCodUsuario.Text = datoCliente["codusuario"].ToString();
            txtNit.Text = datoCliente["nit"].ToString();
            try { dropTipoCliente.SelectedValue = datoCliente["codtipocliente"].ToString();  } catch { }
            txtNombre.Text = datoCliente["pnombre"].ToString();
            txtSNombre.Text = datoCliente["snombre"].ToString();
            txtApellido.Text = datoCliente["papellido"].ToString();
            txtSApellido.Text = datoCliente["sapellido"].ToString();
            txtCelular.Text = datoCliente["celular"].ToString();
            txtTelefono.Text = datoCliente["telefono"].ToString();
            txtEmail.Text = datoCliente["email"].ToString();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se enontro el cliente.");
        }
    }
    private void ddTipoCLiente(DropDownList drop)
    {
        drop.DataSource = client.cargarTiposCliente();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddEquipos(DropDownList drop)
    {
        drop.DataSource = equ.cargarEquipos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddDocumentos(DropDownList drop)
    {
        drop.DataSource = pro.cargarDocumentoDeUnProyecto(lblCodClienteProyectoDocumento.Text);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddLlenarDrop(DropDownList drop,DataTable datos)
    {
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";//Cod de la tabla pro_clienteproyecto
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddMunicipio(DropDownList drop)
    {
        drop.DataSource = local.cargarMunicipios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddCargos(DropDownList drop)
    {
        drop.DataSource = user.cargarCargos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnEditarCliente_Click(object sender, EventArgs e)
    {
        //if(client.editarCliente(txtNit.Text,txtNombre.Text,txtSNombre.Text,txtApellido.Text,txtSApellido.Text,dropTipoCliente.Text,lblCodCliente.Text))
        if (client.editarCliente(txtNit.Text, txtNombre.Text, txtApellido.Text, dropTipoCliente.Text, lblCodCliente.Text))
        {
            if(user.editarUsuario(txtNit.Text,txtNombre.Text,txtSNombre.Text,txtApellido.Text,txtSApellido.Text,txtEmail.Text,txtTelefono.Text,txtCelular.Text,lblCodUsuario.Text))
            {
                mostrarmensaje("exito", "Cliente editado Correctamente.");
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se logró editar los datos de usuario.");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró editar el cliente.");
        }
    }
    protected void imgVer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codclisede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// Codigo de la sede
        PanelDatosSede.Visible = true;
        cargarContactos(lblCodCliente.Text);
        //Los Contactos se cargan con el codigo del cliente.
        //Los demas items se cargan con el codigo de la sede del cliente
        cargarEquipos(codclisede);
        cargarDocumentos(codclisede);
    }
    private void cargarContactos(string codcliente)
    {
        GridContacto.DataSource = client.cargarContactosxCliente(codcliente);
        GridContacto.DataBind();
        if (GridContacto.Rows.Count > 0)
        {
            btnAgregarContacto1.Visible = false;
        }
        else
        {
            btnAgregarContacto1.Visible = true;
        }
    }
    private void cargarEquipos(string codclisede)
    {
        DataTable datosProyectos = client.cargarProyectosxCliente(codclisede);
        if (datosProyectos != null && datosProyectos.Rows.Count > 0)
        {
            ddLlenarDrop(dropProyectoEquipos, datosProyectos);
          
            if (datosProyectos.Rows.Count == 1)
            {
                dropProyectoEquipos.SelectedIndex = 1;
                dropProyectoEquipos.Enabled = false;
                dropProyectoEquipos_SelectedIndexChanged(null, null);
            }
            else
            {
                dropProyectoEquipos.Visible = true;
            }

        }
        else
        {
            //No tiene ningun proyecto por ende no tiene Equipos, Documentos y etc..
            GridEquipos.DataBind();//Para Vaciarlo
        }
  
    }
    private void cargarDocumentos(string codclisede)
    {
        DataTable datosProyectos = client.cargarProyectosxCliente(codclisede);
        if (datosProyectos != null && datosProyectos.Rows.Count > 0)
        {
            ddLlenarDrop(dropProyectoDocumento, datosProyectos);

            if (datosProyectos.Rows.Count == 1)
            {
                dropProyectoDocumento.SelectedIndex = 1;
                dropProyectoDocumento.Enabled = false;
                dropProyectoDocumento_SelectedIndexChanged(null, null);
            }
            else
            {
                dropProyectoDocumento.Visible = true;
            }

        }
        else
        {
            //No tiene ningun proyecto por ende no tiene Equipos, Documentos y etc..
            GridDocumentos.DataBind();//Para Vaciarlo
        }

    }
    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nit = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string nombresede = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string telefono = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        string direccion = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
        string codmunicipio = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
        string sede = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);

        lblCodSede.Text = codsede;
        txtNitSede.Text = nit;
        txtNombreSede.Text = nombresede;
        txtTelefonoSede.Text = telefono;
        txtDireccionSede.Text = direccion;
        
        try
        {
            dropMunicipio.SelectedValue = codmunicipio;
            dropTipoSede.SelectedValue = sede;
        }
        catch { }
        this.PanelVerDependencias_ModalPopupExtender.Show();

    }
    protected void GridSedes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string cod = GridSedes.Rows[e.RowIndex].Cells[1].Text;
        client.eliminarSedeProyecto(cod);//Eliminamos la relacion de la sede con el proyecto.
        if (client.eliminarSedeCliente(cod))
        {
            cargarSedes(lblCodCliente.Text);
            mostrarmensaje("exito", "Eliminado Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: Esta sede tiene información relacionada.");
        }
    }
    protected void btnEditarSede_Click(object sender, EventArgs e)
    {
        if (client.editarSedeCliente(txtNitSede.Text,txtNombreSede.Text, txtTelefonoSede.Text, txtDireccionSede.Text, dropMunicipio.SelectedValue, dropTipoSede.SelectedValue, lblCodSede.Text))
        {
            cargarSedes(lblCodCliente.Text);
            mostrarmensaje("exito", "Editado correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro editar");
            this.PanelVerDependencias_ModalPopupExtender.Show();
        }
    }
    protected void btnAgregarSede_Click(object sender, EventArgs e)
    {
        this.PanelAgregarSede_ModalPopupExtender.Show();
    }
    protected void btnAddSede_Click(object sender, EventArgs e)
    {
        if (client.agregarSedeCliente(txtNitAddSede.Text, lblCodCliente.Text, txtNombreAddSede.Text.ToUpper(), txtTelefonoAddSede.Text, txtDireccionAddSede.Text, dropMunicipioAddSede.SelectedValue, dropTipoAddSede.SelectedValue) != -1)
        {
            mostrarmensaje("exito", "Agregado correctamente");
            cargarSedes(lblCodCliente.Text);
            txtNitAddSede.Text = string.Empty;
            txtNombreAddSede.Text = string.Empty;
            txtTelefonoAddSede.Text = string.Empty;
            txtDireccionAddSede.Text = string.Empty;
            dropMunicipioAddSede.SelectedIndex = 0;
            dropTipoAddSede.SelectedIndex = 0;
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró Agregar");
            this.PanelAgregarSede_ModalPopupExtender.Show();
        }
    }
    protected void GridContacto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string cod = GridContacto.Rows[e.RowIndex].Cells[1].Text;
        if (client.eliminarContacto(cod))
        {
            cargarContactos(lblCodCliente.Text);
            mostrarmensaje("exito", "Eliminado Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar el contacto.");
        }
    }
    protected void btnAgregarContacto_Click(object sender, EventArgs e)
    {
        this.PanelAddContacto_ModalPopupExtender.Show();
    }
    protected void imgEditarContacto_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codcontacto = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string identificacion = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string nombres = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string apellidos = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        string telefono = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
        string celular = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
        string codcargo = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
        string email = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);
        string descricpcion = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);

        lblCodContacto.Text = codcontacto;
        txtIdContactoEdit.Text = identificacion;
        txtNombreContactoEdit.Text = nombres;
        txtApellidosContactoEdit.Text = apellidos;
        txtTelefonoContactoEdit.Text = telefono;
        txtCelularContactoEdit.Text = celular;
        txtEmailContactoEdit.Text = email;
        txtDescripcionContactoEdit.Text = descricpcion;
        try
        {
            dropCargoContactoEdit.SelectedValue = codcargo;
        }
        catch { }
        this.PanelEditContacto_ModalPopupExtender.Show();
    
    }
    protected void btnAddContacto_Click(object sender, EventArgs e)
    {
        if (client.agregarContacto(lblCodCliente.Text, txtIdContacto.Text, txtNombreContacto.Text, txtApellidosContacto.Text, txtTelefonoContacto.Text, txtCelularContacto.Text, txtEmailContacto.Text, dropCargoContacto.SelectedValue,txtDescripcionContacto.Text)!=-1)
        {
            mostrarmensaje("exito", "Agregado Correctamente.");
            cargarContactos(lblCodCliente.Text);
            txtIdContacto.Text = string.Empty;
            txtIdContacto.Text = string.Empty;
            txtNombreContacto.Text = string.Empty;
            txtApellidosContacto.Text = string.Empty;
            txtTelefonoContacto.Text = string.Empty;
            txtCelularContacto.Text = string.Empty;
            txtEmailContacto.Text = string.Empty;
            dropCargoContacto.SelectedIndex = 0;

            string open = "abrir(2);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró agregar");
            this.PanelAddContacto_ModalPopupExtender.Show();
        }
    }
    protected void btnEditContacto_Click(object sender, EventArgs e)
    {
        if (client.editarContacto(txtIdContactoEdit.Text, txtNombreContactoEdit.Text, txtApellidosContactoEdit.Text, txtTelefonoContactoEdit.Text, txtCelularContactoEdit.Text, txtEmailContactoEdit.Text, dropCargoContactoEdit.SelectedValue, txtDescripcionContactoEdit.Text, lblCodContacto.Text))
        {
            mostrarmensaje("exito", "Editado Correctamente");
            cargarContactos(lblCodCliente.Text);
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro editar");
            this.PanelEditContacto_ModalPopupExtender.Show();
        }
    }
    protected void btnAgregarEquipo_Click(object sender, EventArgs e)
    {

        this.PanelAgregaEquipo_ModalPopupExtender.Show();
    }
    protected void GridEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string codcliequipo = GridEquipos.Rows[e.RowIndex].Cells[1].Text;
        if (equ.eliminarEquipoCliente(codcliequipo))
        {
            dropProyectoEquipos_SelectedIndexChanged(null, null);
            mostrarmensaje("exito", "Eliminado Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar el equipo.");
        }
    }
    protected void dropProyectoEquipos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropProyectoEquipos.SelectedIndex > 0)
        {
            lblCodClienteProyectoEquipo.Text = dropProyectoEquipos.SelectedValue;
            GridEquipos.DataSource = equ.cargarEquiposxCliEquipo(lblCodClienteProyectoEquipo.Text);
            GridEquipos.DataBind();
            if (GridEquipos.Rows.Count > 0)
            {
                btnAgregarEquipo.Visible = false;
            }
            else
            {
                btnAgregarEquipo.Visible = true;
            }
        }
    }
    protected void imgEditarEquipo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codcliequipo = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// Codigo de la sede
        string codquipo = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);// Codigo del equipo
        string serial = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);// Codigo del equipo
        string router = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);// Codigo del equipo
        string antena = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);// Codigo del equipo
        string observacion = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);// Codigo del equipo
        lblCodClienteProyectoEquipoEditar.Text = codcliequipo;
        txtSerialEdit.Text = serial;
        txtIpRouteEdit.Text = router;
        txtIpAntenaEdit.Text = antena;
        txtDescripcionEdit.Text = observacion;
        try {dropEquipoEditar.SelectedValue = codquipo; } catch { }
        this.PanelEditEquipo_ModalPopupExtender.Show();
    }
    protected void btnAddEquipo_Click(object sender, EventArgs e)
    {
        string router = chbIpRouteAdd.Checked ? "NO APLICA" : txtIpRouterAdd.Text;
        string antena = chbIpAntenaAdd.Checked ? "NO APLICA" : txtIpAntenaAdd.Text;
        if (equ.agregarEquipoCliente(lblCodClienteProyectoEquipo.Text, dropEquipo.SelectedValue, txtSerial.Text, router, antena, txtDescripcionEquipoAdd.Text))
        {
            mostrarmensaje("exito", "Equipo Agregado correctamente");
            dropProyectoEquipos_SelectedIndexChanged(null, null);
            dropEquipo.SelectedIndex = 0;
            txtSerial.Text = string.Empty;
            txtIpRouterAdd.Text = string.Empty;
            txtIpAntenaAdd.Text = string.Empty;
            txtDescripcionEquipoAdd.Text = string.Empty;
            string open = "abrir(0);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro agregar, Verifique si existe.");
            this.PanelAgregaEquipo_ModalPopupExtender.Show();
        }
    }
    protected void btnEditarEquipo_Click(object sender, EventArgs e)
    {
        string router = cbIpRouterEdit.Checked ? "NO APLICA" : txtIpRouteEdit.Text;
        string antena = cbIpAntenaEdit.Checked ? "NO APLICA" : txtIpAntenaEdit.Text;
        if (equ.editarEquipoCliente(dropEquipoEditar.SelectedValue, txtSerialEdit.Text, lblCodClienteProyectoEquipoEditar.Text,router,antena,txtDescripcionEdit.Text))
        {
            mostrarmensaje("exito", "Editado Correctamente");
            dropProyectoEquipos_SelectedIndexChanged(null, null);
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro editar el equipo del cliente.");
            this.PanelEditEquipo_ModalPopupExtender.Show();
        }
    }
    protected void btnAgregarDocumento_Click(object sender, EventArgs e)
    {
        this.PanelDocumentoAdd_ModalPopupExtender.Show();
    }
    protected void dropProyectoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropProyectoDocumento.SelectedIndex > 0)
        {
            lblCodClienteProyectoDocumento.Text = dropProyectoDocumento.SelectedValue;
            GridDocumentos.DataSource = pro.cargarDocumentoProyectosxClienteSede(lblCodClienteProyectoDocumento.Text);
            GridDocumentos.DataBind();
            ddDocumentos(dropDocumentoAdd);
            if (GridDocumentos.Rows.Count > 0)
            {
             
                btnAgregarDocumento.Visible = false;
            }
            else
            {
                btnAgregarDocumento.Visible = true;
            }
        }
    }
    protected void GridDocumentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string codclidocumento = GridDocumentos.Rows[e.RowIndex].Cells[1].Text;
        string savename = GridDocumentos.Rows[e.RowIndex].Cells[4].Text;

        if (pro.eliminarDocumentoCliente(codclidocumento))
        {
            if (System.IO.File.Exists(savename))
            {
                try
                {
                    System.IO.File.Delete(savename);
                    dropProyectoDocumento_SelectedIndexChanged(null, null);
                    mostrarmensaje("exito", "Eliminado Correctamente");
                }
                catch (System.IO.IOException ex)
                {
                    mostrarmensaje("error", ex.Message);
                }
            }
            else
            {
                dropProyectoDocumento_SelectedIndexChanged(null, null);
                mostrarmensaje("exito", "Eliminado Correctamente");
            }
          
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar el documento.");
        }
    }
    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string id = GridArchivos.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row 
        string filepath = Server.MapPath(HttpUtility.HtmlDecode(gvrow.Cells[5].Text));
        string filename = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        if (!File.Exists(filepath))
        {
            mostrarmensaje("error", "Lo sentimos el archivo: " + filename + " no existe");
        }
        else
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.WriteFile(filepath);
            Response.End();
        }
    }
 
    protected void btnAddDocumento_Click(object sender, EventArgs e)
    {
            string[] variables = subirArchivo(trepador);
            if (variables[0] == "error")
            {
                mostrarmensaje(variables[0], variables[1]);
                this.PanelDocumentoAdd_ModalPopupExtender.Show();
            }
            else if (variables[0] == "exito")
            {
                if (pro.agregarDocumentoCliente(dropDocumentoAdd.SelectedValue, lblCodClienteProyectoDocumento.Text, variables[2], variables[3], variables[4], variables[5], variables[7], variables[8]))
                {
                    trepador.PostedFile.SaveAs(variables[6]);
                    dropProyectoDocumento_SelectedIndexChanged(null, null);
                    mostrarmensaje("exito", "Documento agregado correctamente.");
                    string open = "abrir(1);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logró agregar el documento.");
                    this.PanelDocumentoAdd_ModalPopupExtender.Show();
                }
            }
    }
    private string[] subirArchivo(FileUpload trepador)
    {
        string[] variables = new string[9];
        variables[0] = string.Empty; //estado mensaje
        variables[1] = string.Empty; //mensaje 
        variables[2] = string.Empty; //fileName    
        variables[3] = string.Empty; //fileNameSave
        variables[4] = string.Empty; //fileExtension
        variables[5] = string.Empty; //contentType
        variables[6] = string.Empty; //pathSave
        variables[7] = string.Empty; //pathsinmapSave
        variables[8] = string.Empty; //ContentLength

        //Calculadora de bytes: http://es.calcuworld.com/informatica/calculadora-de-bytes/
        int tamanofile;
        long tamanopermitido = 5242880;//Este dato está en bytes. 5242880 es 5MB, revisar el tamaño en el web.config (maxRequestLength) (kb). 31.700.160KB

        string contentType;
        string pathsinmap = "~/Documentos/";
        string path = Server.MapPath(pathsinmap);
        if (trepador.HasFile)
        {
            try
            {
                bool directorio = false;
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        directorio = true;
                    }
                    catch (Exception exd)
                    {
                        variables[0] = "error"; // estado mensaje
                        variables[1] = "Error : " + exd.Message; //mensaje  
                        return variables;
                        //mostrarmensaje("error", "Error : " + exd.Message);    
                    }
                }
                else
                    directorio = true; //Ya existe el directorio                

                if (directorio == true)
                {
                    tamanofile = trepador.PostedFile.ContentLength;
                    contentType = trepador.PostedFile.ContentType;

                    if (tamanofile > 0 && tamanofile < tamanopermitido)
                    {
                        DateTime localDateTime = DateTime.Now;
                        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

                        string fileExtension = System.IO.Path.GetExtension(trepador.FileName).ToLower();
                        string fileName = System.IO.Path.GetFileName(trepador.PostedFile.FileName).Replace(",", " ");
                        string fileNameSave = horares + "_" + lblCodUsuario.Text + fileExtension;
                        string pathSave = path + fileNameSave;
                        string pathsinmapSave = pathsinmap + fileNameSave;

                        String[] allowedExtensions = funallowedExtensions();
                        bool extOK = false;
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                extOK = true;
                                //para quitar el punto "." de la extension
                                string exte = trepador.PostedFile.FileName;
                                fileExtension = (exte.Substring(exte.LastIndexOf(".") + 1).ToLower());
                            }
                        }


                        if (extOK == false)
                        {
                            variables[0] = "error"; // estado mensaje
                            variables[1] = "Error: No se permite el formato " + fileExtension; //mensaje  
                            return variables;
                            //mostrarmensaje("error", "Error: No se permite el formato " + fileExtension);
                        }
                        else
                        {
                            variables[0] = "exito"; // estado mensaje
                            variables[1] = ""; //mensaje  
                            variables[2] = fileName;  //fileName    
                            variables[3] = fileNameSave; //fileNameSave
                            variables[4] = fileExtension; //fileExtension
                            variables[5] = contentType; //contentType
                            variables[6] = pathSave; //pathSave
                            variables[7] = pathsinmapSave; //pathsinmapSave
                            variables[8] = trepador.PostedFile.ContentLength.ToString(); //ContentLength

                            return variables;

                        }

                    }
                    else
                    {
                        long tan = (tamanopermitido / 1024) / 1024;
                        mostrarmensaje("error", "Tamaño no permitido, solo se aceptan: " + tan.ToString() + " MB");
                    }
                }
            }
            catch (Exception ex)
            {
                mostrarmensaje("error", "Error : " + ex.Message);
            }
        }
        else
        {
            variables[0] = "error"; // estado mensaje
            variables[1] = "Error: Debes seleccionar un archivo"; //mensaje  
            return variables;
            //mostrarmensaje("error", "Error: Debes seleccionar un archivo");
        }
        return variables;
    }
    private String[] funallowedExtensions()
    {
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".docx", "xlsx", "xls", ".rar", ".txt", ".pdf" };
        return allowedExtensions;
    }

    protected void imgVerEquipo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string router = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);// IP router
        string Antena = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);// IP Antena
        string descripcion = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);// IP router
        lblDescripcionEquipo.Text = armarTablaDescripcionEquipo(router, Antena, descripcion);
        PanelDescripcionEquipo_ModalPopupExtender1.Show();
    }
    private string armarTablaDescripcionEquipo(string router,string antena,string descripcion)
    {
        string ca = "";
     ca+="  <center>";
       ca+=" <table class='mGridTesoreria'>";
        ca+="    <tr>";
         ca+="       <th>Ip Router</th>";
         ca+="       <td>"+router+"</td>";
        ca+="    </tr>";
       ca+="     <tr>";
        ca+="        <th>Ip Antena</th>";
        ca+="        <td>"+antena+"</td>";
        ca+="    </tr>";
       ca+="     <tr>";
       ca += "        <td colspan='2' style='max-width: 240px;'>";
        ca += descripcion;
         ca+="       </td>";
       ca+="     </tr>";
      ca+="  </table>";
      ca+="  <center>";
        return ca;
    }
    protected void imgAgregarTicket_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codsede = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row 
        lblCodSede.Text = codsede;

        this.PanelAgregarTickets_Modalpopupextender.Show();
    }

    protected void btnAddTickets_Click(object sender, EventArgs e)
    {
        Tickets tic = new Tickets();

        DataRow TicCliente = tic.CargarTicketAbiertoxCliente(lblCodSede.Text);

        if (TicCliente == null)
        {
            long codticket = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripciónAdd.Text, "1", lblCodProyecto.Text, lblCodSede.Text);
            if (codticket != -1)
            {
                int time = 1;
                Response.AppendHeader("Refresh", time + "; Url=ticdetalle.aspx?ct=" + codticket.ToString() + "");
            }
            else
            {
                mostrarmensaje("error", "Error al Guardar.");
            }
        }
        else
        {
            mostrarmensaje("error", "Este cliente ya cuenta con un Ticket abierto.");
        }
    }

}