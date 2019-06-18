using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class lineabaseSede : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Institucion ins = new Institucion();
    LineaBase lb = new LineaBase();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
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
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            if (Session["codrol"].ToString() == "7")
            {
                obtenerGet();
                string co = "";

                if (lblCodSede.Text != "" && lblCodAsesor.Text != "" && lblCodInstitucion.Text != "")
                {
                    DataRow sede = ins.buscarSedexInstitucion(lblCodSede.Text);
                    if(sede != null)
                    {
                        
                    }
                    co += "<table style='background-color: #ECECEC; padding: 10px; border-radius: 5px;'>";
                    co += "<tr><td><b>Institución: </b>" + sede["nominstitucion"].ToString() + "</td>";
                    co += "<td> / <b>Sede:</b> " + sede["nomsede"].ToString() + " </td>";
                    co += "</tr>";
                    co += "</table>";

                    lblDatoInstitucional.Text = co;

                    CargarInformacionRespuestas(lblCodSede.Text);
                }
                else
                {
                    mostrarmensaje("error","No se recibieron los parámetros de la Sede.");
                }
            }
            else if (Session["codrol"].ToString() == "9")
            {
              
            }
        }
    }
    private void obtenerGet()
    {
        try
        {
            lblCodInstitucion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ci"]);
            lblCodSede.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cs"]);
            lblCodAsesor.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ca"]);
            lblCodInstAsesor.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cia"]);
        }
        catch
        {
            throw new HttpException(500, "Error Interno");
        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("lineabaseregistroinst.aspx?ci=" + lblCodInstitucion.Text + "&ca=" + lblCodAsesor.Text +"&lbs=true&cia=" + lblCodInstAsesor.Text);
    }

    protected void btnGuardarSede_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
            //EliminarGeneroPoblacionAtendida(sedeasesor["codigo"].ToString());
            //AgregarGeneroPoblacionAtendida(sedeasesor["codigo"].ToString(), chkGeneroPoblacionAtendida);

            //EliminarEtnias(sedeasesor["codigo"].ToString());
            //AgregarEtnias(sedeasesor["codigo"].ToString(), rbtEtnias);

            //EliminarEspecialidad(sedeasesor["codigo"].ToString());
            //AgregarEspecialidad(sedeasesor["codigo"].ToString(), chkEspecialidad);

            //EliminarGrados(sedeasesor["codigo"].ToString());
            //AgregarGrados(sedeasesor["codigo"].ToString(), chkGradosSede);

            //EliminarNumeroEstudiantes(sedeasesor["codigo"].ToString());
            //AgregarNumeroEstudiantes(sedeasesor["codigo"].ToString());

            //EliminarNumeroEtnias(sedeasesor["codigo"].ToString());
            //AgregarNumeroEtnias(sedeasesor["codigo"].ToString());

            //EliminarMetodologias(sedeasesor["codigo"].ToString());
            //AgregarMetodologias(sedeasesor["codigo"].ToString(), chkMetodologia);

            //EliminarMetodologiasEstudiantes(sedeasesor["codigo"].ToString());
            //AgregarMetodologiasEstudiantes(sedeasesor["codigo"].ToString());

            //EliminarVictimasConflicto(sedeasesor["codigo"].ToString());
            //AgregarVictimasConflicto(sedeasesor["codigo"].ToString(), chkPoblacion);

            //EliminarNroVictimasConflicto(sedeasesor["codigo"].ToString());
            //AgregarNroVictimasConflicto(sedeasesor["codigo"].ToString());

            //EliminarNivelesEducacion(sedeasesor["codigo"].ToString());
            //AgregarNivelesEducacion(sedeasesor["codigo"].ToString(), chkNivelEducativo);

            //EliminarFuncionario(sedeasesor["codigo"].ToString());
            //AgregarFuncionario(sedeasesor["codigo"].ToString(), chkFuncionarios);

            //EliminarNroFuncionarios(sedeasesor["codigo"].ToString());
            //AgregarNroFuncionarios(sedeasesor["codigo"].ToString());

            //EliminarUltimoNivelAprobado(sedeasesor["codigo"].ToString());
            //AgregarUltimoNivelAprobado(sedeasesor["codigo"].ToString(), chkUltimoNivelEducativo);

            //EliminarNumeroDocentes(sedeasesor["codigo"].ToString());
            //AgregarNumeroDocentes(sedeasesor["codigo"].ToString());

            //EliminarEstrato(sedeasesor["codigo"].ToString());
            //AgregarEstrato(sedeasesor["codigo"].ToString(), chkEstudiante);

            //EliminarSisben(sedeasesor["codigo"].ToString());
            //AgregarSisben(sedeasesor["codigo"].ToString(), chkSisben);

            //EliminarDiscapacidad(sedeasesor["codigo"].ToString());
            //AgregarDiscapacidad(sedeasesor["codigo"].ToString(), chkDiscapacidad);

            EliminarTipoEtnias(sedeasesor["codigo"].ToString());
            AgregarTipoEtnias(sedeasesor["codigo"].ToString(), chkTipoEtnias);

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
                //if (validarPoblacionAtendida(chkGeneroPoblacionAtendida))
                //{
                //    if (rbtEtnias.SelectedIndex != 0 || rbtEtnias.SelectedIndex != 1)
                //    {
                //        if (validarEspecialidad(chkEspecialidad))
                //        {
                //            if (validarGradosSedes(chkGradosSede))
                //            {
                //                if (validarNivelEducativo(chkNivelEducativo))
                //                {
                //                    if (validarSisben(chkSisben))
                //                    {
                //                        if (validarDiscapacidad(chkSisben))
                //                        {
                //                            EliminarGeneroPoblacionAtendida(dat["codigo"].ToString());
                //                            AgregarGeneroPoblacionAtendida(dat["codigo"].ToString(), chkGeneroPoblacionAtendida);

                //                            EliminarEtnias(dat["codigo"].ToString());
                //                            AgregarEtnias(dat["codigo"].ToString(), rbtEtnias);

                //                            EliminarEspecialidad(dat["codigo"].ToString());
                //                            AgregarEspecialidad(dat["codigo"].ToString(), chkEspecialidad);

                //                            EliminarGrados(dat["codigo"].ToString());
                //                            AgregarGrados(dat["codigo"].ToString(), chkGradosSede);

                //                            EliminarNumeroEstudiantes(dat["codigo"].ToString());
                //                            AgregarNumeroEstudiantes(dat["codigo"].ToString());

                //                            EliminarNumeroEtnias(dat["codigo"].ToString());
                //                            AgregarNumeroEtnias(dat["codigo"].ToString());

                //                            EliminarMetodologias(dat["codigo"].ToString());
                //                            AgregarMetodologias(dat["codigo"].ToString(), chkMetodologia);

                //                            EliminarMetodologiasEstudiantes(dat["codigo"].ToString());
                //                            AgregarMetodologiasEstudiantes(dat["codigo"].ToString());

                //                            EliminarVictimasConflicto(dat["codigo"].ToString());
                //                            AgregarVictimasConflicto(dat["codigo"].ToString(), chkPoblacion);

                //                            EliminarNroVictimasConflicto(dat["codigo"].ToString());
                //                            AgregarNroVictimasConflicto(dat["codigo"].ToString());

                //                            EliminarNivelesEducacion(dat["codigo"].ToString());
                //                            AgregarNivelesEducacion(dat["codigo"].ToString(), chkNivelEducativo);

                //                            EliminarFuncionario(dat["codigo"].ToString());
                //                            AgregarFuncionario(dat["codigo"].ToString(),chkFuncionarios);

                //                            EliminarNroFuncionarios(dat["codigo"].ToString());
                //                            AgregarNroFuncionarios(dat["codigo"].ToString());

                //                            EliminarUltimoNivelAprobado(dat["codigo"].ToString());
                //                            AgregarUltimoNivelAprobado(dat["codigo"].ToString(), chkUltimoNivelEducativo);

                //                            EliminarNumeroDocentes(dat["codigo"].ToString());
                //                            AgregarNumeroDocentes(dat["codigo"].ToString());

                //                            EliminarEstrato(dat["codigo"].ToString());
                //                            AgregarEstrato(dat["codigo"].ToString(),chkEstudiante);

                //                            EliminarSisben(dat["codigo"].ToString());
                //                            AgregarSisben(dat["codigo"].ToString(), chkSisben);

                //                            EliminarDiscapacidad(dat["codigo"].ToString());
                //                            AgregarDiscapacidad(dat["codigo"].ToString(),chkDiscapacidad);

                                            EliminarTipoEtnias(dat["codigo"].ToString());
                                            AgregarTipoEtnias(dat["codigo"].ToString(), chkTipoEtnias);

                                            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                //                        }
                //                        else
                //                        {
                //                            mostrarmensaje("error", "Dede seleccionar tipo de discapacidad de la IE.");
                //                        }
                //                    }
                //                    else
                //                    {
                //                        mostrarmensaje("error", "Dede seleccionar un nivel de sisben de la IE.");
                //                    }
                //                }
                //                else
                //                {
                //                    mostrarmensaje("error", "Dede seleccionar un nivel educativo de la IE.");
                //                }
                //            }
                //            else
                //            {
                //                mostrarmensaje("error", "Dede seleccionar un grado de la IE.");
                //            }
                //        }
                //        else
                //        {
                //            mostrarmensaje("error", "Dede seleccionar una especialidad de la IE.");
                //        } 
                        
                //    }
                //    else
                //    {
                //        mostrarmensaje("error", "Dede seleccionar si la Sede atiende población de grupos étnicos.");
                //    }
                //}
                //else
                //{
                //    mostrarmensaje("error","Debe seleccionar el género de la población atendida.");
                //}
            }
        }
    }

    private bool validarPoblacionAtendida(CheckBoxList combo)
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
    private bool validarEspecialidad(CheckBoxList combo)
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
    private bool validarGradosSedes(CheckBoxList combo)
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
    private bool validarNivelEducativo(CheckBoxList combo)
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
    private bool validarSisben(CheckBoxList combo)
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
    private bool validarDiscapacidad(CheckBoxList combo)
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

    private void EliminarGeneroPoblacionAtendida(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "1", "01", "0");
    }
    private void AgregarGeneroPoblacionAtendida(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "1", combo.Items[i].Value, "01", "0");
            }
        }
    }
    private void EliminarEtnias(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "2", "01", "0");
    }
    private void AgregarEtnias(string codsedeasesor, RadioButtonList rbt)
    {
        lb.AgregarRespuestaCerradaSede(codsedeasesor, "2", rbt.SelectedValue, "01", "0");
    }
    private void EliminarEspecialidad(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "3", "01", "0");
    }
    private void AgregarEspecialidad(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "3", combo.Items[i].Value, "01", "0");
            }
        }
    }
    private void EliminarGrados(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "4", "01", "0");
    }
    private void AgregarGrados(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "4", combo.Items[i].Value, "01", "0");
            }
        }
    }

    private void EliminarNumeroEstudiantes(string codsedeasesor)
    {
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.1", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.2", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.3", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.4", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.5", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.6", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.7", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.8", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.9", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.10", "01");
    }
    private void AgregarNumeroEstudiantes(string codsedeasesor)
    {
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.1", txtNroEstudiantesH.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.2", txtNroEstudiantesF.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.3", txtNroHomDiscapacidadPreescolar.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.4", txtNroFemDiscapacidadPreescolar.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.5", txtNroHomDiscapacidadPrimaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.6", txtNroFemDiscapacidadPrimaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.7", txtNroHomDiscapacidadSecundaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.8", txtNroFemDiscapacidadSecundaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.9", txtNroHomDiscapacidadMedia.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.10", txtNroFemDiscapacidadMedia.Text, "01");
    }

    private void EliminarNumeroEtnias(string codsedeasesor)
    {
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.1", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.2", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.3", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.4", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.5", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.6", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.7", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "6.8", "01");
    }
    private void AgregarNumeroEtnias(string codsedeasesor)
    {
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.1", txtNroMasEtniaPreescolar.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.2", txtNroFemEtniaPreescolar.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.3", txtNroMasEtniaPrimaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.4", txtNroFemEtniaPrimaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.5", txtNroMasEtniaSecundaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.6", txtNroFemEtniaSecundaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.7", txtNroMasEtniaMedia.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "6.8", txtNroFemEtniaMedia.Text, "01");

    }

    private void EliminarMetodologias(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "7", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "7", "01");
    }
    private void AgregarMetodologias(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "7", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtOtraMetodologia.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "7", txtOtraMetodologia.Text, "01");
        }
    }
    private void EliminarMetodologiasEstudiantes(string codsedeasesor)
    {
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "7.1", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "7.2", "01");
    }
    private void AgregarMetodologiasEstudiantes(string codsedeasesor)
    {
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "7.1", txtNroMasMetodologia.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "7.2", txtNroFemMetodologia.Text, "01");
    }
    private void EliminarVictimasConflicto(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "8", "01", "0");
    }
    private void AgregarVictimasConflicto(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "8", combo.Items[i].Value, "01", "0");
            }
        }
       
    }
    private void EliminarNroVictimasConflicto(string codsedeasesor)
    {
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "8.1", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "8.2", "01");
    }
    private void AgregarNroVictimasConflicto(string codsedeasesor)
    {
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "8.1", txtMasPoblacionVictima.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "8.2", txtFemPoblacionVictima.Text, "01");
    }
    private void EliminarNivelesEducacion(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "9", "01", "0");
    }
    private void AgregarNivelesEducacion(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "9", combo.Items[i].Value, "01", "0");
            }
        }

    }
    private void EliminarFuncionario(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "10", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "10", "01");
    }
    private void AgregarFuncionario(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "10", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtFuncionario.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "10", txtFuncionario.Text, "01");
        }
    }
    private void EliminarNroFuncionarios(string codsedeasesor)
    {
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "10.1", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "10.2", "01");
    }
    private void AgregarNroFuncionarios(string codsedeasesor)
    {
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "10.1", txtDocentesHom.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "10.2", txtDocentesMuj.Text, "01");
    }

    private void EliminarUltimoNivelAprobado(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "11", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11", "01");
    }
    private void AgregarUltimoNivelAprobado(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "11", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtUltimoNivelEducativo.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11", txtUltimoNivelEducativo.Text, "01");
        }
    }

    private void EliminarNumeroDocentes(string codsedeasesor)
    {
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11.1", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11.2", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11.3", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11.4", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11.5", "01");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "11.6", "01");
     
    }
    private void AgregarNumeroDocentes(string codsedeasesor)
    {
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11.1", txtNroDocentesMasPreescolar.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11.2", txtNroDocentesFemPreescolar.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11.3", txtNroDocentesMasPrimaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11.4", txtNroDocentesFemPrimaria.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11.5", txtNroDocentesMasSecundariaMedia.Text, "01");
        lb.AgregarRespuestaAbiertaSede(codsedeasesor, "11.6", txtNroDocentesFemSecundariaMedia.Text, "01");
  
    }
    private void EliminarEstrato(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "12", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "12", "01");
    }
    private void AgregarEstrato(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "12", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtEstudiante.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "12", txtEstudiante.Text, "01");
        }
    }
    private void EliminarSisben(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "13", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "13", "01");
    }
    private void AgregarSisben(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "13", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtEstudiante.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "13", txtEstudiante.Text, "01");
        }
    }
    private void EliminarDiscapacidad(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "14", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "14", "01");
    }
    private void AgregarDiscapacidad(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "14", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtDiscapacidad.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "14", txtDiscapacidad.Text, "01");
        }
    }
    private void EliminarTipoEtnias(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "15", "01", "0");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "15", "01");
    }
    private void AgregarTipoEtnias(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "15", combo.Items[i].Value, "01", "0");
            }
        }
        if (txtOtrasEtnias.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "15", txtOtrasEtnias.Text, "01");
        }
    }

    private void CargarInformacionRespuestas(string codsede)
    {
        DataRow dat = lb.buscarSedexInsasesor(codsede);

        if (dat != null)
        {
            cargarGeneroPoblacionAtentida(dat["codigo"].ToString(), chkGeneroPoblacionAtendida);
            cargarEtniasSINO(dat["codigo"].ToString(), rbtEtnias);
            cargarEspecialidad(dat["codigo"].ToString(), chkEspecialidad);
            cargarGrados(dat["codigo"].ToString(), chkGradosSede);
            cargarNroEstudiantes(dat["codigo"].ToString());
            cargarEtnias(dat["codigo"].ToString());
            cargarMetodologia(dat["codigo"].ToString(),chkMetodologia);
            cargarVictimasConflicto(dat["codigo"].ToString(),chkPoblacion);
            cargarNivelEducacion(dat["codigo"].ToString(),chkNivelEducativo);
            cargarFuncionario(dat["codigo"].ToString(), chkFuncionarios);
            cargarUltimoNivelAprobado(dat["codigo"].ToString(), chkUltimoNivelEducativo);
            cargarEstrato(dat["codigo"].ToString(), chkEstudiante);
            cargarSisben(dat["codigo"].ToString(), chkSisben);
            cargarDiscapacidad(dat["codigo"].ToString(), chkDiscapacidad);
            cargarEtnias(dat["codigo"].ToString(), chkTipoEtnias);
        }
    }
    private void cargarGeneroPoblacionAtentida(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "1", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
    }
    private void cargarEtniasSINO(string codsedeasesor, RadioButtonList rbt)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "2", "0", "01");

        if (escogido != null & escogido.Rows.Count > 0)
        {
            rbt.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }
    }
    private void cargarEspecialidad(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "3", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
    }
    private void cargarGrados(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "4", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
    }

    private void cargarNroEstudiantes(string codsedeasesor)
    {
        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.1", "01");
        if (dat != null){ txtNroEstudiantesH.Text = dat["comentario"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.2", "01");
        if (dat2 != null){ txtNroEstudiantesF.Text = dat2["comentario"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.3", "01");
        if (dat3 != null) { txtNroHomDiscapacidadPreescolar.Text = dat3["comentario"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.4", "01");
        if (dat4 != null) { txtNroFemDiscapacidadPreescolar.Text = dat4["comentario"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.5", "01");
        if (dat5 != null) { txtNroHomDiscapacidadPrimaria.Text = dat5["comentario"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.6", "01");
        if (dat6 != null) { txtNroFemDiscapacidadPrimaria.Text = dat6["comentario"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.7", "01");
        if (dat7 != null) { txtNroHomDiscapacidadSecundaria.Text = dat7["comentario"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.8", "01");
        if (dat8 != null) { txtNroFemDiscapacidadSecundaria.Text = dat8["comentario"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.9", "01");
        if (dat9 != null) { txtNroHomDiscapacidadMedia.Text = dat9["comentario"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.10", "01");
        if (dat10 != null) { txtNroFemDiscapacidadMedia.Text = dat10["comentario"].ToString(); }


    }

    private void cargarEtnias(string codsedeasesor)
    {
        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.1", "01");
        if (dat != null) { txtNroMasEtniaPreescolar.Text = dat["comentario"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.2", "01");
        if (dat2 != null) { txtNroFemEtniaPreescolar.Text = dat2["comentario"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.3", "01");
        if (dat3 != null) { txtNroMasEtniaPrimaria.Text = dat3["comentario"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.4", "01");
        if (dat4 != null) { txtNroFemEtniaPrimaria.Text = dat4["comentario"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.5", "01");
        if (dat5 != null) { txtNroMasEtniaSecundaria.Text = dat5["comentario"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.6", "01");
        if (dat6 != null) { txtNroFemEtniaSecundaria.Text = dat6["comentario"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.7", "01");
        if (dat7 != null) { txtNroMasEtniaMedia.Text = dat7["comentario"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "6.8", "01");
        if (dat8 != null) { txtNroFemEtniaMedia.Text = dat8["comentario"].ToString(); }
    }

    private void cargarMetodologia(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "7", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
        DataRow dat8 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "7", "01");
        if (dat8 != null) { txtOtraMetodologia.Text = dat8["comentario"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "7.1", "01");
        if (dat9 != null) { txtNroMasMetodologia.Text = dat9["comentario"].ToString(); }

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "7.2", "01");
        if (dat != null) { txtNroFemMetodologia.Text = dat["comentario"].ToString(); }
    }

    private void cargarVictimasConflicto(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "8", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

        DataRow dat9 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "8.1", "01");
        if (dat9 != null) { txtMasPoblacionVictima.Text = dat9["comentario"].ToString(); }

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "8.2", "01");
        if (dat != null) { txtFemPoblacionVictima.Text = dat["comentario"].ToString(); }
    }

    private void cargarNivelEducacion(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "9", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

       
    }

    private void cargarFuncionario(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "10", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }

       
        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "10", "01");
        if (dat != null) { txtFuncionario.Text = dat["comentario"].ToString(); }

        DataRow dat1 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "10.1", "01");
        if (dat1 != null) { txtDocentesHom.Text = dat1["comentario"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "10.2", "01");
        if (dat2 != null) { txtDocentesMuj.Text = dat2["comentario"].ToString(); }
    }

    private void cargarUltimoNivelAprobado(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "11", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }


        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11", "01");
        if (dat != null) { txtUltimoNivelEducativo.Text = dat["comentario"].ToString(); }

        DataRow dat1 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11.1", "01");
        if (dat1 != null) { txtNroDocentesMasPreescolar.Text = dat1["comentario"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11.2", "01");
        if (dat2 != null) { txtNroDocentesFemPreescolar.Text = dat2["comentario"].ToString(); }

        DataRow dat11 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11.3", "01");
        if (dat11 != null) { txtNroDocentesMasPrimaria.Text = dat11["comentario"].ToString(); }

        DataRow dat22 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11.4", "01");
        if (dat22 != null) { txtNroDocentesFemPrimaria.Text = dat22["comentario"].ToString(); }

        DataRow dat13 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11.5", "01");
        if (dat13 != null) { txtNroDocentesMasSecundariaMedia.Text = dat13["comentario"].ToString(); }

        DataRow dat24 = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "11.6", "01");
        if (dat24 != null) { txtNroDocentesFemSecundariaMedia.Text = dat24["comentario"].ToString(); }
    }

    private void cargarEstrato(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "12", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }


        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "13", "01");
        if (dat != null) { txtEstudiante.Text = dat["comentario"].ToString(); }
    }

    private void cargarSisben(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "13", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
    }
    private void cargarDiscapacidad(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "14", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }


        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "14", "01");
        if (dat != null) { txtDiscapacidad.Text = dat["comentario"].ToString(); }
    }
    private void cargarEtnias(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "15", "0", "01");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "15", "01");
        if (dat != null) { txtOtrasEtnias.Text = dat["comentario"].ToString(); }
    }

    protected void btnPrimerGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
            EliminarGeneroPoblacionAtendida(sedeasesor["codigo"].ToString());
            AgregarGeneroPoblacionAtendida(sedeasesor["codigo"].ToString(), chkGeneroPoblacionAtendida);

            EliminarEtnias(sedeasesor["codigo"].ToString());
            AgregarEtnias(sedeasesor["codigo"].ToString(), rbtEtnias);

            EliminarEspecialidad(sedeasesor["codigo"].ToString());
            AgregarEspecialidad(sedeasesor["codigo"].ToString(), chkEspecialidad);

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
                if (validarPoblacionAtendida(chkGeneroPoblacionAtendida))
                {
                    if (rbtEtnias.SelectedIndex != 0 || rbtEtnias.SelectedIndex != 1)
                    {
                        if (validarEspecialidad(chkEspecialidad))
                        {
                           
                            EliminarGeneroPoblacionAtendida(dat["codigo"].ToString());
                            AgregarGeneroPoblacionAtendida(dat["codigo"].ToString(), chkGeneroPoblacionAtendida);

                            EliminarEtnias(dat["codigo"].ToString());
                            AgregarEtnias(dat["codigo"].ToString(), rbtEtnias);

                            EliminarEspecialidad(dat["codigo"].ToString());
                            AgregarEspecialidad(dat["codigo"].ToString(), chkEspecialidad);

                            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");     
                                      
                        }
                        else
                        {
                            mostrarmensaje("error", "Dede seleccionar una especialidad de la IE.");
                        }

                    }
                    else
                    {
                        mostrarmensaje("error", "Dede seleccionar si la Sede atiende población de grupos étnicos.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar el género de la población atendida.");
                }
            }
        }
    }

    protected void btnSegundoGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
           

            EliminarGrados(sedeasesor["codigo"].ToString());
            AgregarGrados(sedeasesor["codigo"].ToString(), chkGradosSede);

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
              
                if (validarGradosSedes(chkGradosSede))
                {
                   
                        EliminarGrados(dat["codigo"].ToString());
                        AgregarGrados(dat["codigo"].ToString(), chkGradosSede);
                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                            
                }
                else
                {
                    mostrarmensaje("error", "Dede seleccionar un grado de la IE.");
                }
                     
            }
        }
    }

    protected void btnTercerGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
      
            EliminarNumeroEstudiantes(sedeasesor["codigo"].ToString());
            AgregarNumeroEstudiantes(sedeasesor["codigo"].ToString());
            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
       
                EliminarNumeroEstudiantes(dat["codigo"].ToString());
                AgregarNumeroEstudiantes(dat["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");     
            }
        }
    }

    protected void btnCuartoGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
           
            EliminarNumeroEtnias(sedeasesor["codigo"].ToString());
            AgregarNumeroEtnias(sedeasesor["codigo"].ToString());

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
                if (validarPoblacionAtendida(chkGeneroPoblacionAtendida))
                {
                    if (rbtEtnias.SelectedIndex != 0 || rbtEtnias.SelectedIndex != 1)
                    {
                        if (validarEspecialidad(chkEspecialidad))
                        {
                            if (validarGradosSedes(chkGradosSede))
                            {
                                if (validarNivelEducativo(chkNivelEducativo))
                                {
                                    if (validarSisben(chkSisben))
                                    {
                                        if (validarDiscapacidad(chkSisben))
                                        {
                                           

                                            EliminarNumeroEtnias(dat["codigo"].ToString());
                                            AgregarNumeroEtnias(dat["codigo"].ToString());

                                            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                                        }
                                        else
                                        {
                                            mostrarmensaje("error", "Dede seleccionar tipo de discapacidad de la IE.");
                                        }
                                    }
                                    else
                                    {
                                        mostrarmensaje("error", "Dede seleccionar un nivel de sisben de la IE.");
                                    }
                                }
                                else
                                {
                                    mostrarmensaje("error", "Dede seleccionar un nivel educativo de la IE.");
                                }
                            }
                            else
                            {
                                mostrarmensaje("error", "Dede seleccionar un grado de la IE.");
                            }
                        }
                        else
                        {
                            mostrarmensaje("error", "Dede seleccionar una especialidad de la IE.");
                        }

                    }
                    else
                    {
                        mostrarmensaje("error", "Dede seleccionar si la Sede atiende población de grupos étnicos.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar el género de la población atendida.");
                }
            }
        }
    }

    protected void btnQuintoGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
           

            EliminarMetodologias(sedeasesor["codigo"].ToString());
            AgregarMetodologias(sedeasesor["codigo"].ToString(), chkMetodologia);

            EliminarMetodologiasEstudiantes(sedeasesor["codigo"].ToString());
            AgregarMetodologiasEstudiantes(sedeasesor["codigo"].ToString());

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
          
                EliminarMetodologias(dat["codigo"].ToString());
                AgregarMetodologias(dat["codigo"].ToString(), chkMetodologia);

                EliminarMetodologiasEstudiantes(dat["codigo"].ToString());
                AgregarMetodologiasEstudiantes(dat["codigo"].ToString());

                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");                  
            }
        }
    }

    protected void btnSextoGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
          

            EliminarVictimasConflicto(sedeasesor["codigo"].ToString());
            AgregarVictimasConflicto(sedeasesor["codigo"].ToString(), chkPoblacion);

            EliminarNroVictimasConflicto(sedeasesor["codigo"].ToString());
            AgregarNroVictimasConflicto(sedeasesor["codigo"].ToString());

            EliminarNivelesEducacion(sedeasesor["codigo"].ToString());
            AgregarNivelesEducacion(sedeasesor["codigo"].ToString(), chkNivelEducativo);

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
               
                if (validarNivelEducativo(chkNivelEducativo))
                {
         
                        EliminarVictimasConflicto(dat["codigo"].ToString());
                        AgregarVictimasConflicto(dat["codigo"].ToString(), chkPoblacion);

                        EliminarNroVictimasConflicto(dat["codigo"].ToString());
                        AgregarNroVictimasConflicto(dat["codigo"].ToString());

                        EliminarNivelesEducacion(dat["codigo"].ToString());
                        AgregarNivelesEducacion(dat["codigo"].ToString(), chkNivelEducativo);

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }
                else
                {
                    mostrarmensaje("error", "Dede seleccionar un nivel educativo de la IE.");
                }
                          
                   
            
            }
        }
    }

    protected void btnSeptimoGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
           

            EliminarFuncionario(sedeasesor["codigo"].ToString());
            AgregarFuncionario(sedeasesor["codigo"].ToString(), chkFuncionarios);

            EliminarNroFuncionarios(sedeasesor["codigo"].ToString());
            AgregarNroFuncionarios(sedeasesor["codigo"].ToString());

            EliminarUltimoNivelAprobado(sedeasesor["codigo"].ToString());
            AgregarUltimoNivelAprobado(sedeasesor["codigo"].ToString(), chkUltimoNivelEducativo);

            EliminarNumeroDocentes(sedeasesor["codigo"].ToString());
            AgregarNumeroDocentes(sedeasesor["codigo"].ToString());

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
           
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
     
                    EliminarFuncionario(dat["codigo"].ToString());
                    AgregarFuncionario(dat["codigo"].ToString(), chkFuncionarios);

                    EliminarNroFuncionarios(dat["codigo"].ToString());
                    AgregarNroFuncionarios(dat["codigo"].ToString());

                    EliminarUltimoNivelAprobado(dat["codigo"].ToString());
                    AgregarUltimoNivelAprobado(dat["codigo"].ToString(), chkUltimoNivelEducativo);

                    EliminarNumeroDocentes(dat["codigo"].ToString());
                    AgregarNumeroDocentes(dat["codigo"].ToString());

                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");               
                                      
            }
        }
    }

    protected void btnOctavoGuardar_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);
        if (sedeasesor != null)
        {
           

            EliminarEstrato(sedeasesor["codigo"].ToString());
            AgregarEstrato(sedeasesor["codigo"].ToString(), chkEstudiante);

            EliminarSisben(sedeasesor["codigo"].ToString());
            AgregarSisben(sedeasesor["codigo"].ToString(), chkSisben);

            EliminarDiscapacidad(sedeasesor["codigo"].ToString());
            AgregarDiscapacidad(sedeasesor["codigo"].ToString(), chkDiscapacidad);

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
               
                if (validarSisben(chkSisben))
                {
                    if (validarDiscapacidad(chkSisben))
                    {
                                           
                        EliminarEstrato(dat["codigo"].ToString());
                        AgregarEstrato(dat["codigo"].ToString(), chkEstudiante);

                        EliminarSisben(dat["codigo"].ToString());
                        AgregarSisben(dat["codigo"].ToString(), chkSisben);

                        EliminarDiscapacidad(dat["codigo"].ToString());
                        AgregarDiscapacidad(dat["codigo"].ToString(), chkDiscapacidad);

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");       
                    }
                    else
                    {
                        mostrarmensaje("error", "Dede seleccionar tipo de discapacidad de la IE.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Dede seleccionar un nivel de sisben de la IE.");
                }
                               
            }
        }
    }

}