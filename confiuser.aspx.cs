using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confiuser : System.Web.UI.Page
{
    
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx",true);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Focus();
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            PanelVerDependencias.Attributes.Add("style", "display:none");
            //gvCargarUsuario();
            //cblRoles2(cblRoles);
            //cblRoles2(cblRol2);

            ddRoles(dropRoles);
            ddRoles(DropRolesAdd);
            ddRoles(DropRolesEdit);

            ddEstrategias(dropEstrategias);
            ddEstrategias(dropEstrategia2);

		

         
        }
    }
    private void ddEstrategias(DropDownList rol)
    {
        Estrategias usu = new Estrategias();
        DataTable datos = usu.cargarEstrategias();
        rol.DataSource = datos;
        rol.DataTextField = "nombre";
        rol.DataValueField = "codigo";
        rol.DataBind();
        rol.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void cblRoles2(CheckBoxList rol)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        rol.DataSource = datos;
        rol.DataTextField = "nombre";
        rol.DataValueField = "cod";
        rol.DataBind();
        rol.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddRoles(DropDownList drop)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void gvCargarUsuario()
    {
        Usuario usu = new Usuario();
        DataTable datos = new DataTable ();
        if (dropRoles.SelectedIndex > 0)
        {
           datos =  usu.cargarUsuariosxRol(dropRoles.SelectedValue);
        }
        else if (DropRolesAdd.SelectedIndex > 0)
        {
            datos = usu.cargarUsuariosxRol(DropRolesAdd.SelectedValue);
        }
        else
        {
            datos = usu.cargarUsuarios();
        }
 
            GridUsuarios.Visible = true;
            GridUsuarios.DataSource = datos;
            GridUsuarios.DataBind();
            lblNoDatos.Text ="Numero de registro: "+ GridUsuarios.Rows.Count.ToString();
           
     
    }

    protected void dropEstrategias_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        EstrategiaxCoordinador(dropEstrategias.SelectedValue, dropCoordinador);
    }
    private void EstrategiaxCoordinador(string codestrategia, DropDownList drop)
    {
        Asesores ase = new Asesores();

        DataTable datos = ase.cargarCoordinadoresxEstrategia(codestrategia);
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

    }

    protected void DropRolesAdd_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //Asesores
        //CUC: 15, UniMag: 11, FUNTICS: 13
        if (DropRolesAdd.SelectedValue == "15" || DropRolesAdd.SelectedValue == "11" || DropRolesAdd.SelectedValue == "13")
        {
            PanelEstraCoordinador.Visible = true;
            PanelEstrategias.Visible = false;
            dropEstrategia2.SelectedIndex = 0;

        }
        //Coordinadores
        //CUC: 2, UniMag: 10, FUNTICS: 12, MAFERPI: 17
        else if (DropRolesAdd.SelectedValue == "2" || DropRolesAdd.SelectedValue == "10" || DropRolesAdd.SelectedValue == "12" || DropRolesAdd.SelectedValue == "17")
        {
            PanelEstraCoordinador.Visible = false;
            PanelEstrategias.Visible = true;
            dropCoordinador.Items.Clear();
            dropEstrategias.SelectedIndex = 0;
        }
        else
        {
            PanelEstraCoordinador.Visible = false;
            PanelEstrategias.Visible = false;
             dropCoordinador.Items.Clear();
            dropEstrategias.SelectedIndex = 0;
            dropEstrategia2.SelectedIndex = 0;
        }
    }
 
    protected void GridUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridUsuarios.SelectedRow;
        string coduser = Convert.ToString(GridUsuarios.DataKeys[e.RowIndex].Value);
        string usuarioadmin = Convert.ToString(GridUsuarios.Rows[e.RowIndex].Cells[1].Text);
        string nit = Convert.ToString(GridUsuarios.Rows[e.RowIndex].Cells[4].Text);
        if (usuarioadmin != "superadmin" && coduser!="1")
        {
            Usuario usu = new Usuario();
            Cliente cli = new Cliente();
            DataTable datosRoles = usu.cargarRolesUsuarios(coduser);
            if (datosRoles != null && datosRoles.Rows.Count > 0)
            {
                for (int i = 0; i < datosRoles.Rows.Count; i++)
                {
                    usu.eliminarRolesUsuario(datosRoles.Rows[i]["cod"].ToString());
                }
                if (usu.eliminarUsuario(coduser) && cli.eliminarClientexUsuario(nit))
                {
                    
                    mostrarmensaje("exito", "Operacion Realizada");
                    //gvCargarUsuario();
                }
                else
                {
                    mostrarmensaje("error", "No puede eliminar este Usuario");
                }
            }
            else
            {
                if (usu.eliminarUsuario(coduser))
                {
                    mostrarmensaje("exito", "Operacion Realizada");
                    //gvCargarUsuario();
                }
                else
                {
                    mostrarmensaje("error", "No puede eliminar este Usuario");
                }
            }
          
        }
        else
        {
            mostrarmensaje("error", "No Puede Eliminar Este Usuario");
        }
    }
    protected void GridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (ImageButton button in e.Row.Cells[9].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el usuario " + item + "?')){ return false; };";
                }
            }
        }
    }
 
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        Asesores ase = new Asesores();
     
            if (GridImplicados.Rows.Count > 0)
            {
                if (usu.editarUsuario(txtUsuario2.Text, txtIdentificacion2.Text, txtNombre2.Text, txtSNombre2.Text, txtApellido2.Text, txtSApellido2.Text, txtEmail2.Text, txtTelefono2.Text, txtCelular2.Text, dropEstado.SelectedValue, lblCodUsuario.Text))
                {
                    //relacionarUsuarioRoles(lblCodUsuario.Text, DropRolesEdit.SelectedValue);
                    //relacionarUsuarioRoles(lblCodUsuario.Text, cblRol2);
                    
                    //Asesores
                    //CUC: 15, UniMag: 11, FUNTICS: 13
                    if (DropRolesEdit.SelectedValue == "15" || DropRolesEdit.SelectedValue == "11" || DropRolesEdit.SelectedValue == "13"){
                        if (ase.editarDatosAsesor(txtIdentificacion2.Text, (txtNombre2.Text + " " + txtSNombre2.Text), (txtApellido2.Text + " " + txtSApellido2.Text), txtTelefono2.Text, txtEmail2.Text, lblID.Text))
                        {
                            
                        }
                    }
                   

                    //Coordinadores
                    //CUC: 2, UniMag: 10, FUNTICS: 12, MAFERPI: 17
                    if (DropRolesEdit.SelectedValue == "2" || DropRolesEdit.SelectedValue == "10" || DropRolesEdit.SelectedValue == "12" || DropRolesEdit.SelectedValue == "17")
                    {
                        if (ase.editarDatosCoordinador(txtIdentificacion2.Text, (txtNombre2.Text + " " + txtSNombre2.Text), (txtApellido2.Text + " " + txtSApellido2.Text), txtTelefono2.Text, txtEmail2.Text, lblID.Text))
                        {

                        }
                    }
                    mostrarmensaje("exito", "Editado Correctamente");
                    limpiarCampos("editar");
                }
                else
                {
                    mostrarmensaje("error", "No se pudo editar");
                }
            }
            else
            {
                //if (validarRoles(cblRol2))
                //{
                    if (usu.editarUsuario(txtUsuario2.Text, txtIdentificacion2.Text, txtNombre2.Text, txtSNombre2.Text, txtApellido2.Text, txtSApellido2.Text, txtEmail2.Text, txtTelefono2.Text, txtCelular2.Text, dropEstado.SelectedValue, lblCodUsuario.Text))
                    {
                        //relacionarUsuarioRoles(lblCodUsuario.Text, DropRolesEdit.SelectedValue);
                        //relacionarUsuarioRoles(lblCodUsuario.Text, cblRol2);
                        limpiarCampos("editar");

                        mostrarmensaje("exito", "Editado Correctamente");

                    }
                    else
                    {
                        mostrarmensaje("error", "No se pudo editar");
                    }
                //}
                //else
                //{
                //    mostrarmensaje("error", "ERROR: Debe elegir minimo 1 Rol.");
                //}
            }
            gvCargarUsuario();
    
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        PanelVerDependencias_ModalPopupExtender.Hide();
    }
    protected void lnkReestablecerContra_Click(object sender, EventArgs e)
    {
        lblerrorcontra.Visible = false;
        PanelVerDependencias_ModalPopupExtender.Show();
        PanelNuevaContra.Visible = true;
        txtNuevaContra.Text = "";
        txtNuevaContra2.Text = "";
        txtNuevaContra.Focus();
    }
    protected void btnGuardarcontra_Click(object sender, EventArgs e)
    {
        if (txtNuevaContra.Text == txtNuevaContra2.Text)
        {
            Usuario usu = new Usuario();
            if (usu.editarPass(lblCodUsuario.Text, txtNuevaContra.Text))
            {
                mostrarmensaje("exito", "Editado Correctamente");
                PanelNuevaContra.Visible = false;
                txtNuevaContra.Text = "";
                txtNuevaContra2.Text = "";
            }
            else
            {
                mostrarmensaje("error", "Error al Guardar Contraseña");
            }
        }
        else
        {
            lblerrorcontra.Visible = true;
        }
    }
    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        PanelVerDependencias_ModalPopupExtender.Hide();
    }
    protected void btnAgregarUsuario_Click(object sender, EventArgs e)
    {
            Usuario usu = new Usuario();
            Asesores ase = new Asesores();

            //if (validarRoles(cblRoles))
            //{
                DataRow codusuario = null;
                if(txtEmail.Text != "")
                {
                    codusuario = usu.agregarUsuarioPG(txtUser.Text, txtPass.Text, txtIdentificacion.Text, txtNombre.Text, txtSNombre.Text, txtApellidos.Text, txtSApellido.Text, txtTelefono.Text, txtCelular.Text, txtEmail.Text,"On","");
                }
                else
                {
                    codusuario = usu.agregarUsuarioPG(txtUser.Text, txtPass.Text, txtIdentificacion.Text, txtNombre.Text, txtSNombre.Text, txtApellidos.Text, txtSApellido.Text, txtTelefono.Text, txtCelular.Text, "0","On","");
                }
                
                if(codusuario != null)
                {
                    relacionarUsuarioRoles(codusuario["cod"].ToString(), DropRolesAdd.SelectedValue);
                    if (txtTelefono.Text == "") { txtTelefono.Text = "0"; }
                    if (txtEmail.Text == "") { txtEmail.Text = "0"; }
                    //Asesores
                    //CUC: 15, UniMag: 11, FUNTICS: 13
                    if (DropRolesAdd.SelectedValue == "15" || DropRolesAdd.SelectedValue == "11" || DropRolesAdd.SelectedValue == "13")
                    {
                       DataRow asesor = ase.agregarAsesor(txtIdentificacion.Text, (txtNombre.Text + " " + txtSNombre.Text), (txtApellidos.Text + " " + txtSApellido.Text) , txtTelefono.Text, txtEmail.Text);

                        if(asesor != null)
                        {
                            ase.agregarAsesorcoordinador(asesor["codigo"].ToString(), dropCoordinador.SelectedValue);
                        }
                    }
                    //Coordinadores
                    //CUC: 2, UniMag: 10, FUNTICS: 12, MAFERPI: 17
                    else if (DropRolesAdd.SelectedValue == "2" || DropRolesAdd.SelectedValue == "10" || DropRolesAdd.SelectedValue == "12" || DropRolesAdd.SelectedValue == "17")
                    {
                        DataRow coordinador = ase.agregarCoordinador(txtIdentificacion.Text, (txtNombre.Text + " " + txtSNombre.Text), (txtApellidos.Text + " " + txtSApellido.Text), txtTelefono.Text, txtEmail.Text);

                        if (coordinador != null)
                        {
                            ase.agregarEstraCoordinador(dropEstrategia2.SelectedValue, coordinador["codigo"].ToString());
                        }
                       
                    }

                    //relacionarUsuarioRoles(codusuario["cod"].ToString(), cblRoles);
                    limpiarCampos("Agregar");
                    mostrarmensaje("exito", "Usuario Creado Exitosamente");

                    PanelEstraCoordinador.Visible = false;
                    PanelEstrategias.Visible = false;
                    dropCoordinador.Items.Clear();
                    dropEstrategias.SelectedIndex = 0;
                    dropEstrategia2.SelectedIndex = 0;
                    //gvCargarUsuario();
                }
                else
                {
                    mostrarmensaje("error", "Error Al Crear Usuario");
                }
            //}
            //else
            //{
            //    mostrarmensaje("error", "ERROR: Debe elegir minimo un ROL.");
            //}
    
       
       
    }
   
    private bool validarRoles(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
    }
    //private void relacionarUsuarioRoles(string id,CheckBoxList combo)
    private void relacionarUsuarioRoles(string id, string drop)
    {
        Usuario user = new Usuario();
        user.relacionarUsuarioRol(id, drop);
        //for (int i = 0; i < combo.Items.Count; i++)
        //{
        //    if (combo.Items[i].Selected)
        //    {
        //        user.relacionarUsuarioRol(id, combo.Items[i].Value);
        //    }
        //}
    }
    private void limpiarCampos(string tipo)
    {
        if (tipo == "Agregar")
        {
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtSNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtSApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            DropRolesAdd.SelectedIndex = 0;
            //cblRoles2(cblRoles);
        }
        else
        {
            txtUsuario2.Text = string.Empty;
            txtNombre2.Text = string.Empty;
            txtSNombre2.Text = string.Empty;
            txtApellido2.Text=string.Empty;
            txtSApellido2.Text=string.Empty;
            txtIdentificacion2.Text=string.Empty;
            txtTelefono2.Text=string.Empty;
            txtEmail2.Text=string.Empty;
            txtCelular2.Text=string.Empty;
            //cblRoles2(cblRol2);
            DropRolesEdit.SelectedIndex = 0;
            GridImplicados.DataBind();
        }
      
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codusuario = GridUsuarios.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string id = Convert.ToString(GridUsuarios.Rows[gvrow.RowIndex].Cells[4].Text);
        lblID.Text = id; 
        lblCodUsuario.Text = codusuario;
        llenarCampos(codusuario);
      
       
        this.PanelVerDependencias_ModalPopupExtender.Show();
    }
    private void llenarCampos(string codusuario)
    {
        Usuario user = new Usuario();
        DataRow datoUsuario = user.buscarUsuario(codusuario);
        if (datoUsuario != null)
        {
            txtUsuario2.Text = datoUsuario["usuario"].ToString();
            txtNombre2.Text = datoUsuario["pnombre"].ToString();
            txtSNombre2.Text = datoUsuario["snombre"].ToString();
            txtApellido2.Text = datoUsuario["papellido"].ToString();
            txtSApellido2.Text = datoUsuario["sapellido"].ToString();
            txtIdentificacion2.Text = datoUsuario["identificacion"].ToString();
            dropEstado.SelectedValue = datoUsuario["estado"].ToString();
            txtEmail2.Text = datoUsuario["email"].ToString(); ;
            txtTelefono2.Text = datoUsuario["telefono"].ToString();
            txtCelular2.Text = datoUsuario["celular"].ToString();
            cargarRolesDeusuaario();
            txtNombre2.Focus();
            DataRow rol = user.buscarRolxCod(codusuario);
            if (rol != null)
            {
                DropRolesEdit.SelectedValue = rol["codrol"].ToString();
            }
        }
        
    }
    private void cargarRolesDeusuaario()
    {
        Usuario user = new Usuario();
        GridImplicados.DataSource = user.cargarRolesUsuarios(lblCodUsuario.Text);
        GridImplicados.DataBind();
    }
  
    protected void imgEliminarRol_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
        Usuario usu = new Usuario();
        if (usu.eliminarRolesUsuario(cod))
        {
            mostrarmensaje("exito", "Operación Realizada");
            cargarRolesDeusuaario();
            this.PanelVerDependencias_ModalPopupExtender.Show();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro eliminar el rol");
        }
    }
    protected void dropRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvCargarUsuario();
    }
}