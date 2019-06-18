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

public partial class lineabaseSedeC600B : System.Web.UI.Page
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

                if (lblCodSede.Text != "" && lblCodAsesor.Text != "" && lblCodInstitucion.Text != "" && lblCodInstAsesor.Text != "")
                {
                    DataRow sede = ins.buscarSedexInstitucion(lblCodSede.Text);
                    if(sede != null)
                    {
                        co += "<table style='background-color: #ECECEC; padding: 10px; border-radius: 5px;'>";
                        co += "<tr><td><b>Institución: </b>" + sede["nominstitucion"].ToString() + "</td>";
                        co += "<td> / <b>Sede:</b> " + sede["nomsede"].ToString() + " </td>";
                        co += "</tr>";
                        co += "</table>";

                        lblDatoInstitucional.Text = co;

                        CargarInformacionRespuestas(lblCodSede.Text,lblCodInstAsesor.Text);
                    }
                   

                    
                }
                else
                {
                    mostrarmensaje("error","No se recibieron los parámetros de la Sede.");
                }
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
        Response.Redirect("lineabaseregistroinst.aspx?back=true&ci=" + lblCodInstitucion.Text + "&ca=" + lblCodAsesor.Text + "&cia=" + lblCodInstAsesor.Text);
    }

    protected void btnGuardarSede_Click(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if(sedeasesor != null )
        {
            EliminarJornadas(sedeasesor["codigo"].ToString());
            AgregarJornadas(sedeasesor["codigo"].ToString(), chkJornadas);

            EliminarGeneros(sedeasesor["codigo"].ToString());
            AgregarGeneros(sedeasesor["codigo"].ToString(), rbtGeneroPoblacionAtendida);

            EliminarNivelesEnsenianza(sedeasesor["codigo"].ToString());
            AgregarNivelesEnsenianza(sedeasesor["codigo"].ToString(), chkNivelesEnsenianza);

            EliminarCaracterAcademico(sedeasesor["codigo"].ToString());
            EliminarCaracterTecnico(sedeasesor["codigo"].ToString());
            if (chkNivelesEnsenianza.SelectedValue == "Media")
            {
                AgregarCaracterAcademico(sedeasesor["codigo"].ToString(), chkCaracterAcademico);
                AgregarCaracterTecnico(sedeasesor["codigo"].ToString(), chkCaracterTecnico);
            }
           
           

            EliminarAtiendeEtnia(sedeasesor["codigo"].ToString());
            AgregarAtiendeEtnia(sedeasesor["codigo"].ToString(), rbtEtnias);

            EliminarProgramaEstrategiaPreescolar(sedeasesor["codigo"].ToString());
            AgregarProgramaEstrategiaPreescolar(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosPreescolar);

            EliminarProgramaEstrategiaPrimaria(sedeasesor["codigo"].ToString());
            AgregarProgramaEstrategiaPrimaria(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosPrimaria);

            EliminarProgramaEstrategiaSecundaria(sedeasesor["codigo"].ToString());
            AgregarProgramaEstrategiaSecundaria(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosSecundaria);

            EliminarProgramaEstrategiaMedia(sedeasesor["codigo"].ToString());
            AgregarProgramaEstrategiaMedia(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosMedia);

            EliminarUltimoNivelEducativo(sedeasesor["codigo"].ToString());
            AgregarUltimoNivelEducativo(sedeasesor["codigo"].ToString());

            EliminarPoblacionConDiscapacidad(sedeasesor["codigo"].ToString());
            if (rbdiscapacidadexcepcional.SelectedIndex == 0)
            {
                AgregarPoblacionConDiscapacidad(sedeasesor["codigo"].ToString());
            }

            EliminarIntegradosNoIntegrados(sedeasesor["codigo"].ToString());
            AgregarIntegradosNoIntegrados(sedeasesor["codigo"].ToString());

            EliminarPoblacionEtnia(sedeasesor["codigo"].ToString());
            if (rbGrupoEtnico.SelectedIndex == 0)
            {
                AgregarPoblacionEtnia(sedeasesor["codigo"].ToString());
            }

            EliminarPoblacionVictimaConflicto(sedeasesor["codigo"].ToString());
            if (rbVictimaConflicto.SelectedIndex == 0)
            {
                AgregarPoblacionVictimaConflicto(sedeasesor["codigo"].ToString());
            }
            EliminarNivelesPreescolaryPrimaria(sedeasesor["codigo"].ToString());

            AgregarNivelesPreescolaryPrimaria(sedeasesor["codigo"].ToString());

            EliminarAceleracionAprendizaje(sedeasesor["codigo"].ToString());
            AgregarAceleracionAprendizaje(sedeasesor["codigo"].ToString());

            EliminarSecundariayMedia(sedeasesor["codigo"].ToString());
            AgregarSecundariayMedia(sedeasesor["codigo"].ToString());

            EliminarEducacionMedia(sedeasesor["codigo"].ToString());
            AgregarEducacionMedia(sedeasesor["codigo"].ToString());

            EliminarNivelEducativoCiclos(sedeasesor["codigo"].ToString());
            EliminarGeneroCiclo(sedeasesor["codigo"].ToString());
            EliminarModelosCiclos(sedeasesor["codigo"].ToString());
            if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
            {
                AgregarNivelEducativoCiclos(sedeasesor["codigo"].ToString());
                AgregarGeneroCiclo(sedeasesor["codigo"].ToString());
                AgregarModelosCiclo(sedeasesor["codigo"].ToString());
            }
  
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text,lblCodInstAsesor.Text);

            if(dat != null)
            {
                if (validarJornadas(chkJornadas))
                {
                    if(rbtGeneroPoblacionAtendida.SelectedIndex != 0 || rbtGeneroPoblacionAtendida.SelectedIndex != 1 || rbtGeneroPoblacionAtendida.SelectedIndex != 2 )
                    {
                        if (validarNivelesEnsenianza(chkNivelesEnsenianza))
                        {
                            if(rbtEtnias.SelectedIndex != 0 || rbtEtnias.SelectedIndex != 1)
                            {
                                EliminarJornadas(dat["codigo"].ToString());
                                AgregarJornadas(dat["codigo"].ToString(),chkJornadas);

                                EliminarGeneros(dat["codigo"].ToString());
                                AgregarGeneros(dat["codigo"].ToString(),rbtGeneroPoblacionAtendida);

                                EliminarNivelesEnsenianza(dat["codigo"].ToString());
                                AgregarNivelesEnsenianza(dat["codigo"].ToString(), chkNivelesEnsenianza);

                                EliminarCaracterAcademico(sedeasesor["codigo"].ToString());
                                EliminarCaracterTecnico(sedeasesor["codigo"].ToString());
                                if (chkNivelesEnsenianza.SelectedValue == "Media")
                                {
                                    AgregarCaracterAcademico(sedeasesor["codigo"].ToString(), chkCaracterAcademico);
                                    AgregarCaracterTecnico(sedeasesor["codigo"].ToString(), chkCaracterTecnico);
                                }

                                EliminarAtiendeEtnia(dat["codigo"].ToString());
                                AgregarAtiendeEtnia(dat["codigo"].ToString(),rbtEtnias);

                                EliminarProgramaEstrategiaPreescolar(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaPreescolar(dat["codigo"].ToString(), chkEstrategiaModelosEducativosPreescolar);

                                EliminarProgramaEstrategiaPrimaria(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaPrimaria(dat["codigo"].ToString(), chkEstrategiaModelosEducativosPrimaria);

                                EliminarProgramaEstrategiaSecundaria(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaSecundaria(dat["codigo"].ToString(), chkEstrategiaModelosEducativosSecundaria);

                                EliminarProgramaEstrategiaMedia(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaMedia(dat["codigo"].ToString(), chkEstrategiaModelosEducativosMedia);

                                EliminarUltimoNivelEducativo(dat["codigo"].ToString());
                                AgregarUltimoNivelEducativo(dat["codigo"].ToString());

                                EliminarPoblacionConDiscapacidad(dat["codigo"].ToString());
                                if(rbdiscapacidadexcepcional.SelectedIndex == 0)
                                {
                                    AgregarPoblacionConDiscapacidad(dat["codigo"].ToString());
                                }

                                EliminarIntegradosNoIntegrados(dat["codigo"].ToString());
                                AgregarIntegradosNoIntegrados(dat["codigo"].ToString());

                                EliminarPoblacionEtnia(dat["codigo"].ToString());
                                if(rbGrupoEtnico.SelectedIndex == 0)
                                {
                                    AgregarPoblacionEtnia(dat["codigo"].ToString());
                                }

                                EliminarPoblacionVictimaConflicto(dat["codigo"].ToString());
                                if (rbVictimaConflicto.SelectedIndex == 0)
                                {
                                    AgregarPoblacionVictimaConflicto(dat["codigo"].ToString());
                                }

                                EliminarNivelesPreescolaryPrimaria(dat["codigo"].ToString());
                                AgregarNivelesPreescolaryPrimaria(dat["codigo"].ToString());

                                EliminarAceleracionAprendizaje(dat["codigo"].ToString());
                                AgregarAceleracionAprendizaje(dat["codigo"].ToString());

                                EliminarSecundariayMedia(dat["codigo"].ToString());
                                AgregarSecundariayMedia(dat["codigo"].ToString());

                                EliminarEducacionMedia(dat["codigo"].ToString());
                                AgregarEducacionMedia(dat["codigo"].ToString());

                                EliminarNivelEducativoCiclos(dat["codigo"].ToString());
                                EliminarGeneroCiclo(dat["codigo"].ToString());
                                EliminarModelosCiclos(dat["codigo"].ToString());
                                if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
                                {
                                    AgregarNivelEducativoCiclos(dat["codigo"].ToString());
                                    AgregarGeneroCiclo(dat["codigo"].ToString());
                                    AgregarModelosCiclo(dat["codigo"].ToString());
                                }

                            }
                            else
                            {
                                mostrarmensaje("error", "Dede seleccionar si la Sede atiende población de grupos étnicos.");
                            }
                        }
                        else
                        {
                            mostrarmensaje("error", "Dede seleccionar un Nivel de enseñanza que ofrece la Sede.");
                        }
                    }
                    else
                    {
                        mostrarmensaje("error", "Dede seleccionar un Genero de la población atendida por la Sede.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Dede seleccionar una jornada para la Sede.");
                }
            }
            else
            {
                mostrarmensaje("error","Error al guardar");
            }
        }
        

    }
    private bool validarJornadas(CheckBoxList combo)
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
    private bool validarNivelesEnsenianza(CheckBoxList combo)
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
    private void EliminarJornadas(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "1", "C600B", "0");
    }
    private void AgregarJornadas(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "1", combo.Items[i].Value, "C600B", "0");
            }
        }
    }
    private void EliminarGeneros(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "2", "C600B", "0");
    }
    private void AgregarGeneros(string codsedeasesor, RadioButtonList rbt)
    {
        lb.AgregarRespuestaCerradaSede(codsedeasesor,"2",rbt.SelectedValue,"C600B","0");
    }
    private void EliminarNivelesEnsenianza(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "3", "C600B", "0");
    }
    private void AgregarNivelesEnsenianza(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "3", combo.Items[i].Value, "C600B", "0");
            }
        }
    }
    private void EliminarCaracterAcademico(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "3", "C600B", "1");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "3.1", "C600B");
    }
    private void AgregarCaracterAcademico(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "3", combo.Items[i].Value, "C600B", "1");
            }
        }

        if(txtOtroAcademico.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "3.1", txtOtroAcademico.Text, "C600B");
        }
    }
    private void EliminarCaracterTecnico(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "3", "C600B", "2");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "3.2", "C600B");
    }
    private void AgregarCaracterTecnico(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "3", combo.Items[i].Value, "C600B", "2");
            }
        }
        if (txtOtroAcademico.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "3.2", txtOtroTecnico.Text, "C600B");
        }
    }
    private void EliminarAtiendeEtnia(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "4", "C600B", "0");
     }
    private void AgregarAtiendeEtnia(string codsedeasesor, RadioButtonList rbt)
    {
        lb.AgregarRespuestaCerradaSede(codsedeasesor, "4", rbt.SelectedValue, "C600B", "0");
    }
    private void EliminarProgramaEstrategiaPreescolar(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "5", "C600B", "1");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.1", "C600B");
    }
    private void AgregarProgramaEstrategiaPreescolar(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "5", combo.Items[i].Value, "C600B", "1");
            }
        }
        if (txtOtroPreescolar.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.1", txtOtroPreescolar.Text, "C600B");
        }
    }
    private void EliminarProgramaEstrategiaPrimaria(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "5", "C600B", "2");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.2", "C600B");
    }
    private void AgregarProgramaEstrategiaPrimaria(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "5", combo.Items[i].Value, "C600B", "2");
            }
        }
        if (txtOtroPrimaria.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.2", txtOtroPrimaria.Text, "C600B");
        }
    }
    private void EliminarProgramaEstrategiaSecundaria(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "5", "C600B", "3");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.3", "C600B");
    }
    private void AgregarProgramaEstrategiaSecundaria(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "5", combo.Items[i].Value, "C600B", "3");
            }
        }
        if (txtOtroSecundaria.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.3", txtOtroSecundaria.Text, "C600B");
        }
    }
    private void EliminarProgramaEstrategiaMedia(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSede(codsedeasesor, "5", "C600B", "4");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "5.4", "C600B");
    }
    private void AgregarProgramaEstrategiaMedia(string codsedeasesor, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                lb.AgregarRespuestaCerradaSede(codsedeasesor, "5", combo.Items[i].Value, "C600B", "4");
            }
        }
        if (txtOtroMedia.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "5.4", txtOtroMedia.Text, "C600B");
        }
    }
    private void EliminarUltimoNivelEducativo(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "6", "C600B");
    }
    private void AgregarUltimoNivelEducativo(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Preescolar", txtBachiHomPreescolar.Text, txtBachiMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Primaria", txtBachiHomPrimaria.Text, txtBachiMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Secundaria", txtBachiHomSecundaria.Text, txtBachiMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Media", txtBachiHomMedia.Text, txtBachiMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Normalista superior", "Preescolar", txtSuperiorHomPreescolar.Text, txtSuperiorMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Normalista superior", "Primaria", txtSuperiorHomPrimaria.Text, txtSuperiorMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Normalista superior", "Secundaria", txtSuperiorHomSecundaria.Text, txtSuperiorMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Normalista superior", "Media", txtSuperiorHomMedia.Text, txtSuperiorMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro bachillerato", "Preescolar", txtOtroBachiHomPreescolar.Text, txtOtroBachiMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro bachillerato", "Primaria", txtOtroBachiHomPrimaria.Text, txtOtroBachiMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro bachillerato", "Secundaria", txtOtroBachiHomSecundaria.Text, txtOtroBachiMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro bachillerato", "Media", txtOtroBachiHomMedia.Text, txtOtroBachiMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Preescolar", txtTecPedagoHomPreescolar.Text, txtTecPedagoMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Primaria", txtTecPedagoHomPrimaria.Text, txtTecPedagoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Secundaria", txtTecPedagoHomSecundaria.Text, txtTecPedagoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Media", txtTecPedagoHomMedia.Text, txtTecPedagoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Preescolar", txtOtroPedagoHomPreescolar.Text, txtOtroPedagoMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Primaria", txtOtroPedagoHomPrimaria.Text, txtOtroPedagoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Secundaria", txtOtroPedagoHomSecundaria.Text, txtOtroPedagoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Media", txtOtroPedagoHomMedia.Text, txtOtroPedagoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Preescolar", txtProfPedagoHomPreescolar.Text, txtProfPedagoMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Primaria", txtProfPedagoHomPrimaria.Text, txtProfPedagoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Secundaria", txtProfPedagoHomSecundaria.Text, txtProfPedagoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Media", txtProfPedagoHomMedia.Text, txtProfPedagoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Otro", "Preescolar", txtProfOtroPedagoHomPreescolar.Text, txtProfOtroPedagoHomPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Otro", "Primaria", txtProfOtroPedagoHomPrimaria.Text, txtProfOtroPedagoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Otro", "Secundaria", txtProfOtroPedagoHomSecundaria.Text, txtProfOtroPedagoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Profesional Otro", "Media", txtProfOtroPedagoHomMedia.Text, txtProfOtroPedagoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Preescolar", txtPosPedagoHomPreescolar.Text, txtPosPedagoMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Primaria", txtPosPedagoHomPrimaria.Text, txtPosPedagoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Secundaria", txtPosPedagoHomSecundaria.Text, txtPosPedagoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Media", txtPosPedagoHomMedia.Text, txtPosPedagoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Otro", "Preescolar", txtPosOtroPedagoHomPreescolar.Text, txtPosOtroPedagoMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Otro", "Primaria", txtPosOtroPedagoHomPrimaria.Text, txtPosOtroPedagoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Otro", "Secundaria", txtPosOtroPedagoHomSecundaria.Text, txtPosOtroPedagoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Posgrado Otro", "Media", txtPosOtroPedagoHomMedia.Text, txtPosOtroPedagoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro", "Preescolar", txtOtroCualHomPreescolar.Text, txtOtroCualMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro", "Primaria", txtOtroCualHomPrimaria.Text, txtOtroCualMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro", "Secundaria", txtOtroCualHomSecundaria.Text, txtOtroCualMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "6", "C600B", "Otro", "Media", txtOtroCualHomMedia.Text, txtOtroCualMujMedia.Text);
    }
    private void EliminarPoblacionConDiscapacidad(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "7", "C600B");
    }
    private void AgregarPoblacionConDiscapacidad(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con discapacidad", "Preescolar", txtDiscapacidadHomPreescolar.Text, txtDiscapacidadMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con discapacidad", "Primaria", txtDiscapacidadHomPrimaria.Text, txtDiscapacidadMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con discapacidad", "Secundaria", txtDiscapacidadHomSecundaria.Text, txtDiscapacidadMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con discapacidad", "Media", txtDiscapacidadHomMedia.Text, txtDiscapacidadMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Preescolar", txtCapacidadExcepHomPreescolar.Text, txtCapacidadExcepMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Primaria", txtCapacidadExcepHomPrimaria.Text, txtCapacidadExcepMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Secundaria", txtCapacidadExcepHomSecundaria.Text, txtCapacidadExcepMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Media", txtCapacidadExcepHomMedia.Text, txtCapacidadExcepMujMedia.Text);
    }
    private void EliminarIntegradosNoIntegrados(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "8", "C600B");
    }
    private void AgregarIntegradosNoIntegrados(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Auditiva", "Integrados", txtAuditivaHomInte.Text, txtAuditivaMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Auditiva", "No Integrados", txtAuditivaHomNoInte.Text, txtAuditivaMujNoInte.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Visual", "Integrados", txtVisualHomInte.Text, txtVisualMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Visual", "No Integrados", txtVisualHomNoInte.Text, txtVisualMujNoInte.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Motora", "Integrados", txtMotoraHomInte.Text, txtMotoraMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Motora", "No Integrados", txtMotoraHomNoInte.Text, txtMotoraMujNoInte.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Cognitiva", "Integrados", txtCognitivaHomInte.Text, txtCognitivaMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Cognitiva", "No Integrados", txtCognitivaHomNoInte.Text, txtCognitivaMujNoInte.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Autismo", "Integrados", txtAutismoHomInte.Text, txtAutismoMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Autismo", "No Integrados", txtAutismoHomNoInte.Text, txtAutismoMujNoInte.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Múltiple", "Integrados", txtMultipleHomInte.Text, txtMultipleMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Múltiple", "No Integrados", txtMultipleHomNoInte.Text, txtMultipleMujNoInte.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Otra", "Integrados", txtOtraHomInte.Text, txtOtraMujInte.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "8", "C600B", "Otra", "No Integrados", txtOtraHomNoInte.Text, txtOtraMujNoInte.Text);


    }
    private void EliminarPoblacionEtnia(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "9", "C600B");
        lb.eliminarRespuestaAbiertaSede(codsedeasesor, "9", "C600B");
    }
    private void AgregarPoblacionEtnia(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Indígenas", "Preescolar", txtIndigenaHomPreescolar.Text, txtIndigenaMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Indígenas", "Primaria", txtIndigenaHomPrimaria.Text, txtIndigenaMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Indígenas", "Secundaria", txtIndigenaHomSecundaria.Text, txtIndigenaMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Indígenas", "Media", txtIndigenaHomMedia.Text, txtIndigenaMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Preescolar", txtRomHomPreescolar.Text, txtRomMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Primaria", txtRomHomPrimaria.Text, txtRomMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Secundaria", txtRomHomSecundaria.Text, txtRomMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Media", txtRomHomMedia.Text, txtRomMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Preescolar", txtAfroHomPreescolar.Text, txtAfroMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Primaria", txtAfroHomPrimaria.Text, txtAfroMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Secundaria", txtAfroHomSecundaria.Text, txtAfroMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Media", txtAfroHomMedia.Text, txtAfroMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Preescolar", txtRaizaHomPreescolar.Text, txtRaizaMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Primaria", txtRaizaHomPrimaria.Text, txtRaizaMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Secundaria", txtRaizaHomSecundaria.Text, txtRaizaMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Media", txtRaizaHomMedia.Text, txtRaizaMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Preescolar", txtPalenqueroHomPreescolar.Text, txtPalenqueroMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Primaria", txtPalenqueroHomPrimaria.Text, txtPalenqueroMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Secundaria", txtPalenqueroHomSecundaria.Text, txtPalenqueroMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Media", txtPalenqueroHomMedia.Text, txtPalenqueroMujMedia.Text);

        if(txtNomGrupoIndigena.Text != "")
        {
            lb.AgregarRespuestaAbiertaSede(codsedeasesor, "9", txtNomGrupoIndigena.Text, "C600B");
        }
    }
    private void EliminarPoblacionVictimaConflicto(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "10", "C600B");
    }
    private void AgregarPoblacionVictimaConflicto(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Preescolar", txtDesplazamientoHomPreescolar.Text, txtDesplazamientoMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Primaria", txtDesplazamientoHomPrimaria.Text, txtDesplazamientoMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Secundaria", txtDesplazamientoHomSecundaria.Text, txtDesplazamientoMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Media", txtDesplazamientoHomMedia.Text, txtDesplazamientoMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Preescolar", txtAlMargenHomPreescolar.Text, txtAlMargenMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Primaria", txtAlMargenHomPrimaria.Text, txtAlMargenMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Secundaria", txtAlMargenHomSecundaria.Text, txtAlMargenMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Media", txtAlMargenHomMedia.Text, txtAlMargenMujMedia.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Preescolar", txtDesmovilizadosHomPreescolar.Text, txtDesmovilizadosMujPreescolar.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Primaria", txtDesmovilizadosHomPrimaria.Text, txtDesmovilizadosMujPrimaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Secundaria", txtDesmovilizadosHomSecundaria.Text, txtDesmovilizadosMujSecundaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Media", txtDesmovilizadosHomMedia.Text, txtDesmovilizadosMujMedia.Text);
    }
    private void EliminarNivelesPreescolaryPrimaria(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "11", "C600B");
    }
    private void AgregarNivelesPreescolaryPrimaria(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Pre jardín", txtEdad3HomPrejardin.Text, txtEdad3MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Jardín", txtEdad3HomJardin.Text, txtEdad3MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Transición", txtEdad3HomTransicion.Text, txtEdad3MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Primero", txtEdad3HomPrimero.Text, txtEdad3MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Segundo", txtEdad3HomSegundo.Text, txtEdad3MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Tercero", txtEdad3HomTercero.Text, txtEdad3MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Cuarto", txtEdad3HomCuarto.Text, txtEdad3MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "3", "Quinto", txtEdad3HomQuinto.Text, txtEdad3MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Pre jardín", txtEdad4HomPrejardin.Text, txtEdad4MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Jardín", txtEdad4HomJardin.Text, txtEdad4MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Transición", txtEdad4HomTransicion.Text, txtEdad4MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Primero", txtEdad4HomPrimero.Text, txtEdad4MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Segundo", txtEdad4HomSegundo.Text, txtEdad4MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Tercero", txtEdad4HomTercero.Text, txtEdad4MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Cuarto", txtEdad4HomCuarto.Text, txtEdad4MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "4", "Quinto", txtEdad4HomQuinto.Text, txtEdad4MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Pre jardín", txtEdad5HomPrejardin.Text, txtEdad5MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Jardín", txtEdad5HomJardin.Text, txtEdad5MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Transición", txtEdad5HomTransicion.Text, txtEdad5MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Primero", txtEdad5HomPrimero.Text, txtEdad5MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Segundo", txtEdad5HomSegundo.Text, txtEdad5MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Tercero", txtEdad5HomTercero.Text, txtEdad5MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Cuarto", txtEdad5HomCuarto.Text, txtEdad5MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "5", "Quinto", txtEdad5HomQuinto.Text, txtEdad5MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Pre jardín", txtEdad6HomPrejardin.Text, txtEdad6MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Jardín", txtEdad6HomJardin.Text, txtEdad6MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Transición", txtEdad6HomTransicion.Text, txtEdad6MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Primero", txtEdad6HomPrimero.Text, txtEdad6MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Segundo", txtEdad6HomSegundo.Text, txtEdad6MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Tercero", txtEdad6HomTercero.Text, txtEdad6MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Cuarto", txtEdad6HomCuarto.Text, txtEdad6MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "6", "Quinto", txtEdad6HomQuinto.Text, txtEdad6MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Pre jardín", txtEdad7HomPrejardin.Text, txtEdad7MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Jardín", txtEdad7HomJardin.Text, txtEdad7MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Transición", txtEdad7HomTransicion.Text, txtEdad7MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Primero", txtEdad7HomPrimero.Text, txtEdad7MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Segundo", txtEdad7HomSegundo.Text, txtEdad7MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Tercero", txtEdad7HomTercero.Text, txtEdad7MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Cuarto", txtEdad7HomCuarto.Text, txtEdad7MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "7", "Quinto", txtEdad7HomQuinto.Text, txtEdad7MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Pre jardín", txtEdad8HomPrejardin.Text, txtEdad8MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Jardín", txtEdad8HomJardin.Text, txtEdad8MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Transición", txtEdad8HomTransicion.Text, txtEdad8MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Primero", txtEdad8HomPrimero.Text, txtEdad8MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Segundo", txtEdad8HomSegundo.Text, txtEdad8MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Tercero", txtEdad8HomTercero.Text, txtEdad8MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Cuarto", txtEdad8HomCuarto.Text, txtEdad8MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "8", "Quinto", txtEdad8HomQuinto.Text, txtEdad8MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Pre jardín", txtEdad9HomPrejardin.Text, txtEdad9MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Jardín", txtEdad9HomJardin.Text, txtEdad9MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Transición", txtEdad9HomTransicion.Text, txtEdad9MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Primero", txtEdad9HomPrimero.Text, txtEdad9MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Segundo", txtEdad9HomSegundo.Text, txtEdad9MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Tercero", txtEdad9HomTercero.Text, txtEdad9MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Cuarto", txtEdad9HomCuarto.Text, txtEdad9MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "9", "Quinto", txtEdad9HomQuinto.Text, txtEdad9MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Pre jardín", txtEdad10HomPrejardin.Text, txtEdad10MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Jardín", txtEdad10HomJardin.Text, txtEdad10MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Transición", txtEdad10HomTransicion.Text, txtEdad10MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Primero", txtEdad10HomPrimero.Text, txtEdad10MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Segundo", txtEdad10HomSegundo.Text, txtEdad10MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Tercero", txtEdad10HomTercero.Text, txtEdad10MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Cuarto", txtEdad10HomCuarto.Text, txtEdad10MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "10", "Quinto", txtEdad10HomQuinto.Text, txtEdad10MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Pre jardín", txtEdad11HomPrejardin.Text, txtEdad11MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Jardín", txtEdad11HomJardin.Text, txtEdad11MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Transición", txtEdad11HomTransicion.Text, txtEdad11MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Primero", txtEdad11HomPrimero.Text, txtEdad11MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Segundo", txtEdad11HomSegundo.Text, txtEdad11MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Tercero", txtEdad11HomTercero.Text, txtEdad11MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Cuarto", txtEdad11HomCuarto.Text, txtEdad11MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "11", "Quinto", txtEdad11HomQuinto.Text, txtEdad11MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Pre jardín", txtEdad12HomPrejardin.Text, txtEdad12MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Jardín", txtEdad12HomJardin.Text, txtEdad12MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Transición", txtEdad12HomTransicion.Text, txtEdad12MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Primero", txtEdad12HomPrimero.Text, txtEdad12MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Segundo", txtEdad12HomSegundo.Text, txtEdad12MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Tercero", txtEdad12HomTercero.Text, txtEdad12MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Cuarto", txtEdad12HomCuarto.Text, txtEdad12MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "12", "Quinto", txtEdad12HomQuinto.Text, txtEdad12MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Pre jardín", txtEdad13HomPrejardin.Text, txtEdad13MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Jardín", txtEdad13HomJardin.Text, txtEdad13MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Transición", txtEdad13HomTransicion.Text, txtEdad13MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Primero", txtEdad13HomPrimero.Text, txtEdad13MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Segundo", txtEdad13HomSegundo.Text, txtEdad13MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Tercero", txtEdad13HomTercero.Text, txtEdad13MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Cuarto", txtEdad13HomCuarto.Text, txtEdad13MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "13", "Quinto", txtEdad13HomQuinto.Text, txtEdad13MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Pre jardín", txtEdad14HomPrejardin.Text, txtEdad14MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Jardín", txtEdad14HomJardin.Text, txtEdad14MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Transición", txtEdad14HomTransicion.Text, txtEdad14MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Primero", txtEdad14HomPrimero.Text, txtEdad14MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Segundo", txtEdad14HomSegundo.Text, txtEdad14MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Tercero", txtEdad14HomTercero.Text, txtEdad14MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Cuarto", txtEdad14HomCuarto.Text, txtEdad14MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "14", "Quinto", txtEdad14HomQuinto.Text, txtEdad14MujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Pre jardín", txtEdad15HomPrejardin.Text, txtEdad15MujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Jardín", txtEdad15HomJardin.Text, txtEdad15MujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Transición", txtEdad15HomTransicion.Text, txtEdad15MujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Primero", txtEdad15HomPrimero.Text, txtEdad15MujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Segundo", txtEdad15HomSegundo.Text, txtEdad15MujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Tercero", txtEdad15HomTercero.Text, txtEdad15MujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Cuarto", txtEdad15HomCuarto.Text, txtEdad15MujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "15", "Quinto", txtEdad15HomQuinto.Text, txtEdad15MujQuinto.Text);

        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Pre jardín", txtEdadGeneralHomPrejardin.Text, txtEdadGeneralMujPrejardin.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Jardín", txtEdadGeneralHomJardin.Text, txtEdadGeneralMujJardin.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Transición", txtEdadGeneralHomTransicion.Text, txtEdadGeneralMujTransicion.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Primero", txtEdadGeneralHomPrimero.Text, txtEdadGeneralMujPrimero.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Segundo", txtEdadGeneralHomSegundo.Text, txtEdadGeneralMujSegundo.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Tercero", txtEdadGeneralHomTercero.Text, txtEdadGeneralMujTercero.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Cuarto", txtEdadGeneralHomCuarto.Text, txtEdadGeneralMujCuarto.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Total General", "Quinto", txtEdadGeneralHomQuinto.Text, txtEdadGeneralMujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Pre jardín", txtEdadRepitentesHomPrejardin.Text, txtEdadRepitentesMujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Jardín", txtEdadRepitentesHomJardin.Text, txtEdadRepitentesMujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Transición", txtEdadRepitentesHomTransicion.Text, txtEdadRepitentesMujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Primero", txtEdadRepitentesHomPrimero.Text, txtEdadRepitentesMujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Segundo", txtEdadRepitentesHomSegundo.Text, txtEdadRepitentesMujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Tercero", txtEdadRepitentesHomTercero.Text, txtEdadRepitentesMujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Cuarto", txtEdadRepitentesHomCuarto.Text, txtEdadRepitentesMujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Quinto", txtEdadRepitentesHomQuinto.Text, txtEdadRepitentesMujQuinto.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Pre jardín", txtEdadGruposPorGradoHomPrejardin.Text, txtEdadGruposPorGradoMujPrejardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Jardín", txtEdadGruposPorGradoHomJardin.Text, txtEdadGruposPorGradoMujJardin.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Transición", txtEdadGruposPorGradoHomTransicion.Text, txtEdadGruposPorGradoMujTransicion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Primero", txtEdadGruposPorGradoHomPrimero.Text, txtEdadGruposPorGradoMujPrimero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Segundo", txtEdadGruposPorGradoHomSegundo.Text, txtEdadGruposPorGradoMujSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Tercero", txtEdadGruposPorGradoHomTercero.Text, txtEdadGruposPorGradoMujTercero.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Cuarto", txtEdadGruposPorGradoHomCuarto.Text, txtEdadGruposPorGradoMujCuarto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Quinto", txtEdadGruposPorGradoHomQuinto.Text, txtEdadGruposPorGradoMujQuinto.Text);


     
    }

    private void EliminarAceleracionAprendizaje(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "12", "C600B");
    }
    private void AgregarAceleracionAprendizaje(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "10", "", txtHom10Primaria.Text, txtMuj10Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "11", "", txtHom11Primaria.Text, txtMuj11Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "12", "", txtHom12Primaria.Text, txtMuj12Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "13", "", txtHom13Primaria.Text, txtMuj13Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "14", "", txtHom14Primaria.Text, txtMuj14Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "15", "", txtHom15Primaria.Text, txtMuj15Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "16", "", txtHom16Primaria.Text, txtMuj16Primaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "12", "C600B", "17", "", txtHom17Primaria.Text, txtMuj17Primaria.Text);

      
    }
    private void EliminarSecundariayMedia(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "13", "C600B");
    }
    private void AgregarSecundariayMedia(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Sexto", txt9HomSexto.Text, txt9MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Séptimo", txt9HomSeptimo.Text, txt9MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Octavo", txt9HomOctavo.Text, txt9MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Noveno", txt9HomNoveno.Text, txt9MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Décimo", txt9HomDecimo.Text, txt9MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Décimo Primero", txt9HomUnDecimo.Text, txt9MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Décimo Segundo", txt9HomDecimoSegundo.Text, txt9MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "9", "Décimo Tercero", txt9HomDecimoTercero.Text, txt9MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Sexto", txt10HomSexto.Text, txt10MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Séptimo", txt10HomSeptimo.Text, txt10MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Octavo", txt10HomOctavo.Text, txt10MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Noveno", txt10HomNoveno.Text, txt10MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Décimo", txt10HomDecimo.Text, txt10MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Décimo Primero", txt10HomUnDecimo.Text, txt10MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Décimo Segundo", txt10HomDecimoSegundo.Text, txt10MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "10", "Décimo Tercero", txt10HomDecimoTercero.Text, txt10MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Sexto", txt11HomSexto.Text, txt11MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Séptimo", txt11HomSeptimo.Text, txt11MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Octavo", txt11HomOctavo.Text, txt11MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Noveno", txt11HomNoveno.Text, txt11MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Décimo", txt11HomDecimo.Text, txt11MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Décimo Primero", txt11HomUnDecimo.Text, txt11MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Décimo Segundo", txt11HomDecimoSegundo.Text, txt11MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "11", "Décimo Tercero", txt11HomDecimoTercero.Text, txt11MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Sexto", txt12HomSexto.Text, txt12MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Séptimo", txt12HomSeptimo.Text, txt12MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Octavo", txt12HomOctavo.Text, txt12MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Noveno", txt12HomNoveno.Text, txt12MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Décimo", txt12HomDecimo.Text, txt12MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Décimo Primero", txt12HomUnDecimo.Text, txt12MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Décimo Segundo", txt12HomDecimoSegundo.Text, txt12MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "12", "Décimo Tercero", txt12HomDecimoTercero.Text, txt12MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Sexto", txt13HomSexto.Text, txt13MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Séptimo", txt13HomSeptimo.Text, txt13MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Octavo", txt13HomOctavo.Text, txt13MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Noveno", txt13HomNoveno.Text, txt13MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Décimo", txt13HomDecimo.Text, txt13MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Décimo Primero", txt13HomUnDecimo.Text, txt13MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Décimo Segundo", txt13HomDecimoSegundo.Text, txt13MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "13", "Décimo Tercero", txt13HomDecimoTercero.Text, txt13MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Sexto", txt14HomSexto.Text, txt14MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Séptimo", txt14HomSeptimo.Text, txt14MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Octavo", txt14HomOctavo.Text, txt14MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Noveno", txt14HomNoveno.Text, txt14MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Décimo", txt14HomDecimo.Text, txt14MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Décimo Primero", txt14HomUnDecimo.Text, txt14MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Décimo Segundo", txt14HomDecimoSegundo.Text, txt14MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "14", "Décimo Tercero", txt14HomDecimoTercero.Text, txt14MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Sexto", txt15HomSexto.Text, txt15MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Séptimo", txt15HomSeptimo.Text, txt15MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Octavo", txt15HomOctavo.Text, txt15MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Noveno", txt15HomNoveno.Text, txt15MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Décimo", txt15HomDecimo.Text, txt15MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Décimo Primero", txt15HomUnDecimo.Text, txt15MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Décimo Segundo", txt15HomDecimoSegundo.Text, txt15MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "15", "Décimo Tercero", txt15HomDecimoTercero.Text, txt15MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Sexto", txt16HomSexto.Text, txt16MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Séptimo", txt16HomSeptimo.Text, txt16MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Octavo", txt16HomOctavo.Text, txt16MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Noveno", txt16HomNoveno.Text, txt16MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Décimo", txt16HomDecimo.Text, txt16MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Décimo Primero", txt16HomUnDecimo.Text, txt16MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Décimo Segundo", txt16HomDecimoSegundo.Text, txt16MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "16", "Décimo Tercero", txt16HomDecimoTercero.Text, txt16MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Sexto", txt17HomSexto.Text, txt17MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Séptimo", txt17HomSeptimo.Text, txt17MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Octavo", txt17HomOctavo.Text, txt17MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Noveno", txt17HomNoveno.Text, txt17MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Décimo", txt17HomDecimo.Text, txt17MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Décimo Primero", txt17HomUnDecimo.Text, txt17MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Décimo Segundo", txt17HomDecimoSegundo.Text, txt17MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "17", "Décimo Tercero", txt17HomDecimoTercero.Text, txt17MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Sexto", txt18HomSexto.Text, txt18MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Séptimo", txt18HomSeptimo.Text, txt18MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Octavo", txt18HomOctavo.Text, txt18MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Noveno", txt18HomNoveno.Text, txt18MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Décimo", txt18HomDecimo.Text, txt18MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Décimo Primero", txt18HomUnDecimo.Text, txt18MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Décimo Segundo", txt18HomDecimoSegundo.Text, txt18MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "18", "Décimo Tercero", txt18HomDecimoTercero.Text, txt18MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Sexto", txt19HomSexto.Text, txt19MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Séptimo", txt19HomSeptimo.Text, txt19MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Octavo", txt19HomOctavo.Text, txt19MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Noveno", txt19HomNoveno.Text, txt19MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Décimo", txt19HomDecimo.Text, txt19MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Décimo Primero", txt19HomUnDecimo.Text, txt19MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Décimo Segundo", txt19HomDecimoSegundo.Text, txt19MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "19", "Décimo Tercero", txt19HomDecimoTercero.Text, txt19MujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Sexto", txt20HomSexto.Text, txt20MujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Séptimo", txt20HomSeptimo.Text, txt20MujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Octavo", txt20HomOctavo.Text, txt20MujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Noveno", txt20HomNoveno.Text, txt20MujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Décimo", txt20HomDecimo.Text, txt20MujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Décimo Primero", txt20HomUnDecimo.Text, txt20MujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Décimo Segundo", txt20HomDecimoSegundo.Text, txt20MujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "20", "Décimo Tercero", txt20HomDecimoTercero.Text, txt20MujDecimoTercero.Text);

        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Sexto", txtGeneralHomSexto.Text, txtGeneralMujSexto.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Séptimo", txtGeneralHomSeptimo.Text, txtGeneralMujSeptimo.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Octavo", txtGeneralHomOctavo.Text, txtGeneralMujOctavo.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Noveno", txtGeneralHomNoveno.Text, txtGeneralMujNoveno.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Décimo", txtGeneralHomDecimo.Text, txtGeneralMujDecimo.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Décimo Primero", txtGeneralHomUnDecimo.Text, txtGeneralMujUnDecimo.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Décimo Segundo", txtGeneralHomDecimoSegundo.Text, txtGeneralMujUnDecimoSegundo.Text);
        //lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Total General", "Décimo Tercero", txtGeneralHomDecimoTercero.Text, txtGeneralMujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Sexto", txtRepitentesHomSexto.Text, txtRepitentesMujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Séptimo", txtRepitentesHomSeptimo.Text, txtRepitentesMujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Octavo", txtRepitentesHomOctavo.Text, txtRepitentesMujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Noveno", txtRepitentesHomNoveno.Text, txtRepitentesMujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo", txtRepitentesHomDecimo.Text, txtRepitentesMujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo Primero", txtRepitentesHomUnDecimo.Text, txtRepitentesMujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo Segundo", txtRepitentesHomDecimoSegundo.Text, txtRepitentesMujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo Tercero", txtRepitentesHomDecimoTercero.Text, txtRepitentesMujDecimoTercero.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Sexto", txtGruposPorGradosHomSexto.Text, txtGruposPorGradosMujSexto.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Séptimo", txtGruposPorGradosHomSeptimo.Text, txtGruposPorGradosMujSeptimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Octavo", txtGruposPorGradosHomOctavo.Text, txtGruposPorGradosMujOctavo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Noveno", txtGruposPorGradosHomNoveno.Text, txtGruposPorGradosMujNoveno.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo", txtGruposPorGradosHomDecimo.Text, txtGruposPorGradosMujDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo Primero", txtGruposPorGradosHomUnDecimo.Text, txtGruposPorGradosMujUnDecimo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo Segundo", txtGruposPorGradosHomDecimoSegundo.Text, txtGruposPorGradosMujUnDecimoSegundo.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo Tercero", txtGruposPorGradosHomDecimoTercero.Text, txtGruposPorGradosMujDecimoTercero.Text);
    }
    private void EliminarEducacionMedia(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "14", "C600B");
    }
    private void AgregarEducacionMedia(string codsedeasesor)
    {

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Académica", "Décimo", txt10HomAcademica.Text, txt10MujAcademica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Académica", "Décimo Primero", txt11HomAcademica.Text, txt11MujAcademica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Académica", "Décimo Segundo", txt12HomAcademica.Text, txt12MujAcademica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Académica", "Décimo Tercero", txt13HomAcademica.Text, txt13MujAcademica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Académica", "Repitentes", txtRepitentesHomAcademica.Text, txtRepitentesMujAcademica.Text);


        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo", txt10HomAgropecuaria.Text, txt10MujAgropecuaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo Primero", txt11HomAgropecuaria.Text, txt11MujAgropecuaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo Segundo", txt12HomAgropecuaria.Text, txt12MujAgropecuaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo Tercero", txt13HomAgropecuaria.Text, txt13MujAgropecuaria.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Agropecuaria", "Repitentes", txtRepitentesHomAgropecuaria.Text, txtRepitentesMujAgropecuaria.Text);


        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo", txt10HomComercial.Text, txt10MujComercial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo Primero", txt11HomComercial.Text, txt11MujComercial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo Segundo", txt12HomComercial.Text, txt12MujComercial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo Tercero", txt13HomComercial.Text, txt13MujComercial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Repitentes", txtRepitentesHomComercial.Text, txtRepitentesMujComercial.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Industrial", "Décimo", txt10HomIndustrial.Text, txt10MujIndustrial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Industrial", "Décimo Primero", txt11HomIndustrial.Text, txt11MujIndustrial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Industrial", "Décimo Segundo", txt12HomIndustrial.Text, txt12MujIndustrial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Industrial", "Décimo Tercero", txt13HomIndustrial.Text, txt13MujIndustrial.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Industrial", "Repitentes", txtRepitentesHomIndustrial.Text, txtRepitentesMujIndustrial.Text);


        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo", txt10HomPedagogica.Text, txt10MujPedagogica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo Primero", txt11HomPedagogica.Text, txt11MujPedagogica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo Segundo", txt12HomPedagogica.Text, txt12MujPedagogica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo Tercero", txt13HomPedagogica.Text, txt13MujPedagogica.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Pedagógica", "Repitentes", txtRepitentesHomPedagogica.Text, txtRepitentesMujPedagogica.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo", txt10HomPromocion.Text, txt10MujPromocion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo Primero", txt11HomPromocion.Text, txt11MujPromocion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo Segundo", txt12HomPromocion.Text, txt12MujPromocion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo Tercero", txt13HomPromocion.Text, txt13MujPromocion.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Promoción Social", "Repitentes", txtRepitentesHomPromocion.Text, txtRepitentesMujPromocion.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Otra", "Décimo", txt10HomOtra.Text, txt10MujOtra.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Otra", "Décimo Primero", txt11HomOtra.Text, txt11MujOtra.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Otra", "Décimo Segundo", txt12HomOtra.Text, txt12MujOtra.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Otra", "Décimo Tercero", txt13HomOtra.Text, txt13MujOtra.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "14", "C600B", "Otra", "Repitentes", txtRepitentesHomOtra.Text, txtRepitentesMujOtra.Text);
    }
    private void EliminarNivelEducativoCiclos(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "15", "C600B");
    }
    private void AgregarNivelEducativoCiclos(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Aprobados", txtHomCicloIAprobado.Text, txtMujCicloIAprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Reprobados", txtHomCicloIReprobado.Text, txtMujCicloIReprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Desertores*", txtHomCicloIDesertores.Text, txtMujCicloIDesertores.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Transferidos/Trasladados*", txtHomCicloITranferidos.Text, txtMujCicloITranferidos.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Aprobados", txtHomCicloIIAprobado.Text, txtMujCicloIIAprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Reprobados", txtHomCicloIIReprobado.Text, txtMujCicloIIReprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Desertores*", txtHomCicloIIDesertores.Text, txtMujCicloIIDesertores.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Transferidos/Trasladados*", txtHomCicloIITranferidos.Text, txtMujCicloIITranferidos.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Aprobados", txtHomCicloIIIAprobado.Text, txtMujCicloIIIAprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Reprobados", txtHomCicloIIIReprobado.Text, txtMujCicloIIIReprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Desertores*", txtHomCicloIIIDesertores.Text, txtMujCicloIIIDesertores.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Transferidos/Trasladados*", txtHomCicloIIITranferidos.Text, txtMujCicloIIITranferidos.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Aprobados", txtHomCicloIVAprobado.Text, txtMujCicloIVAprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Reprobados", txtHomCicloIVReprobado.Text, txtMujCicloIVReprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Desertores*", txtHomCicloIVDesertores.Text, txtMujCicloIVDesertores.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Transferidos/Trasladados*", txtHomCicloIVTranferidos.Text, txtMujCicloIVTranferidos.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo V", "Aprobados", txtHomCicloVAprobado.Text, txtMujCicloVAprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo V", "Reprobados", txtHomCicloVReprobado.Text, txtMujCicloVReprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo V", "Desertores*", txtHomCicloVDesertores.Text, txtMujCicloVDesertores.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo V", "Transferidos/Trasladados*", txtHomCicloVTranferidos.Text, txtMujCicloVTranferidos.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Aprobados", txtHomCicloVIAprobado.Text, txtMujCicloVIAprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Reprobados", txtHomCicloVIReprobado.Text, txtMujCicloVIReprobado.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Desertores*", txtHomCicloVIDesertores.Text, txtMujCicloVIDesertores.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Transferidos/Trasladados*", txtHomCicloVITranferidos.Text, txtMujCicloVITranferidos.Text);
    }
    private void EliminarGeneroCiclo(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "16", "C600B");
    }
    private void AgregarGeneroCiclo(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "13", "Ciclo I", txt13HomCicloI.Text, txt13MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "13", "Ciclo II", txt13HomCicloII.Text, txt13MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "13", "Ciclo III", txt13HomCicloIII.Text, txt13MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "13", "Ciclo IV", txt13HomCicloIV.Text, txt13MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "13", "Ciclo V", txt13HomCicloV.Text, txt13MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "13", "Ciclo VI", txt13HomCicloVI.Text, txt13MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "14", "Ciclo I", txt14HomCicloI.Text, txt14MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "14", "Ciclo II", txt14HomCicloII.Text, txt14MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "14", "Ciclo III", txt14HomCicloIII.Text, txt14MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "14", "Ciclo IV", txt14HomCicloIV.Text, txt14MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "14", "Ciclo V", txt14HomCicloV.Text, txt14MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "14", "Ciclo VI", txt14HomCicloVI.Text, txt14MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "15", "Ciclo I", txt15HomCicloI.Text, txt15MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "15", "Ciclo II", txt15HomCicloII.Text, txt15MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "15", "Ciclo III", txt15HomCicloIII.Text, txt15MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "15", "Ciclo IV", txt15HomCicloIV.Text, txt15MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "15", "Ciclo V", txt15HomCicloV.Text, txt15MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "15", "Ciclo VI", txt15HomCicloVI.Text, txt15MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "16", "Ciclo I", txt16HomCicloI.Text, txt16MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "16", "Ciclo II", txt16HomCicloII.Text, txt16MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "16", "Ciclo III", txt16HomCicloIII.Text, txt16MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "16", "Ciclo IV", txt16HomCicloIV.Text, txt16MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "16", "Ciclo V", txt16HomCicloV.Text, txt16MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "16", "Ciclo VI", txt16HomCicloVI.Text, txt16MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "17", "Ciclo I", txt17HomCicloI.Text, txt17MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "17", "Ciclo II", txt17HomCicloII.Text, txt17MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "17", "Ciclo III", txt17HomCicloIII.Text, txt17MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "17", "Ciclo IV", txt17HomCicloIV.Text, txt17MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "17", "Ciclo V", txt17HomCicloV.Text, txt17MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "17", "Ciclo VI", txt17HomCicloVI.Text, txt17MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "18", "Ciclo I", txt18HomCicloI.Text, txt18MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "18", "Ciclo II", txt18HomCicloII.Text, txt18MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "18", "Ciclo III", txt18HomCicloIII.Text, txt18MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "18", "Ciclo IV", txt18HomCicloIV.Text, txt18MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "18", "Ciclo V", txt18HomCicloV.Text, txt18MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "18", "Ciclo VI", txt18HomCicloVI.Text, txt18MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "19", "Ciclo I", txt19HomCicloI.Text, txt19MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "19", "Ciclo II", txt19HomCicloII.Text, txt19MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "19", "Ciclo III", txt19HomCicloIII.Text, txt19MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "19", "Ciclo IV", txt19HomCicloIV.Text, txt19MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "19", "Ciclo V", txt19HomCicloV.Text, txt19MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "19", "Ciclo VI", txt19HomCicloVI.Text, txt19MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "20", "Ciclo I", txt20HomCicloI.Text, txt20MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "20", "Ciclo II", txt20HomCicloII.Text, txt20MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "20", "Ciclo III", txt20HomCicloIII.Text, txt20MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "20", "Ciclo IV", txt20HomCicloIV.Text, txt20MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "20", "Ciclo V", txt20HomCicloV.Text, txt20MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "20", "Ciclo VI", txt20HomCicloVI.Text, txt20MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "21", "Ciclo I", txt21HomCicloI.Text, txt21MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "21", "Ciclo II", txt21HomCicloII.Text, txt21MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "21", "Ciclo III", txt21HomCicloIII.Text, txt21MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "21", "Ciclo IV", txt21HomCicloIV.Text, txt21MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "21", "Ciclo V", txt21HomCicloV.Text, txt21MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "21", "Ciclo VI", txt21HomCicloVI.Text, txt21MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "22", "Ciclo I", txt22HomCicloI.Text, txt22MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "22", "Ciclo II", txt22HomCicloII.Text, txt22MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "22", "Ciclo III", txt22HomCicloIII.Text, txt22MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "22", "Ciclo IV", txt22HomCicloIV.Text, txt22MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "22", "Ciclo V", txt22HomCicloV.Text, txt22MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "22", "Ciclo VI", txt22HomCicloVI.Text, txt22MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "23", "Ciclo I", txt23HomCicloI.Text, txt23MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "23", "Ciclo II", txt23HomCicloII.Text, txt23MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "23", "Ciclo III", txt23HomCicloIII.Text, txt23MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "23", "Ciclo IV", txt23HomCicloIV.Text, txt23MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "23", "Ciclo V", txt23HomCicloV.Text, txt23MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "23", "Ciclo VI", txt23HomCicloVI.Text, txt23MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "24", "Ciclo I", txt24HomCicloI.Text, txt24MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "24", "Ciclo II", txt24HomCicloII.Text, txt24MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "24", "Ciclo III", txt24HomCicloIII.Text, txt24MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "24", "Ciclo IV", txt24HomCicloIV.Text, txt24MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "24", "Ciclo V", txt24HomCicloV.Text, txt24MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "24", "Ciclo VI", txt24HomCicloVI.Text, txt24MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "25", "Ciclo I", txt25HomCicloI.Text, txt25MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "25", "Ciclo II", txt25HomCicloII.Text, txt25MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "25", "Ciclo III", txt25HomCicloIII.Text, txt25MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "25", "Ciclo IV", txt25HomCicloIV.Text, txt25MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "25", "Ciclo V", txt25HomCicloV.Text, txt25MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "25", "Ciclo VI", txt25HomCicloVI.Text, txt25MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "26", "Ciclo I", txt26HomCicloI.Text, txt26MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "26", "Ciclo II", txt26HomCicloII.Text, txt26MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "26", "Ciclo III", txt26HomCicloIII.Text, txt26MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "26", "Ciclo IV", txt26HomCicloIV.Text, txt26MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "26", "Ciclo V", txt26HomCicloV.Text, txt26MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "26", "Ciclo VI", txt26HomCicloVI.Text, txt26MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "27", "Ciclo I", txt27HomCicloI.Text, txt27MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "27", "Ciclo II", txt27HomCicloII.Text, txt27MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "27", "Ciclo III", txt27HomCicloIII.Text, txt27MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "27", "Ciclo IV", txt27HomCicloIV.Text, txt27MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "27", "Ciclo V", txt27HomCicloV.Text, txt27MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "27", "Ciclo VI", txt27HomCicloVI.Text, txt27MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "28", "Ciclo I", txt28HomCicloI.Text, txt28MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "28", "Ciclo II", txt28HomCicloII.Text, txt28MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "28", "Ciclo III", txt28HomCicloIII.Text, txt28MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "28", "Ciclo IV", txt28HomCicloIV.Text, txt28MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "28", "Ciclo V", txt28HomCicloV.Text, txt28MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "28", "Ciclo VI", txt28HomCicloVI.Text, txt28MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "29", "Ciclo I", txt29HomCicloI.Text, txt29MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "29", "Ciclo II", txt29HomCicloII.Text, txt29MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "29", "Ciclo III", txt29HomCicloIII.Text, txt29MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "29", "Ciclo IV", txt29HomCicloIV.Text, txt29MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "29", "Ciclo V", txt29HomCicloV.Text, txt29MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "29", "Ciclo VI", txt29HomCicloVI.Text, txt29MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "30", "Ciclo I", txt30HomCicloI.Text, txt30MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "30", "Ciclo II", txt30HomCicloII.Text, txt30MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "30", "Ciclo III", txt30HomCicloIII.Text, txt30MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "30", "Ciclo IV", txt30HomCicloIV.Text, txt30MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "30", "Ciclo V", txt30HomCicloV.Text, txt30MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "30", "Ciclo VI", txt30HomCicloVI.Text, txt30MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "31", "Ciclo I", txt31HomCicloI.Text, txt31MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "31", "Ciclo II", txt31HomCicloII.Text, txt31MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "31", "Ciclo III", txt31HomCicloIII.Text, txt31MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "31", "Ciclo IV", txt31HomCicloIV.Text, txt31MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "31", "Ciclo V", txt31HomCicloV.Text, txt31MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "31", "Ciclo VI", txt31HomCicloVI.Text, txt31MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "32", "Ciclo I", txt32HomCicloI.Text, txt32MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "32", "Ciclo II", txt32HomCicloII.Text, txt32MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "32", "Ciclo III", txt32HomCicloIII.Text, txt32MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "32", "Ciclo IV", txt32HomCicloIV.Text, txt32MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "32", "Ciclo V", txt32HomCicloV.Text, txt32MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "32", "Ciclo VI", txt32HomCicloVI.Text, txt32MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "33", "Ciclo I", txt33HomCicloI.Text, txt33MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "33", "Ciclo II", txt33HomCicloII.Text, txt33MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "33", "Ciclo III", txt33HomCicloIII.Text, txt33MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "33", "Ciclo IV", txt33HomCicloIV.Text, txt33MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "33", "Ciclo V", txt33HomCicloV.Text, txt33MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "33", "Ciclo VI", txt33HomCicloVI.Text, txt33MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "34", "Ciclo I", txt34HomCicloI.Text, txt34MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "34", "Ciclo II", txt34HomCicloII.Text, txt34MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "34", "Ciclo III", txt34HomCicloIII.Text, txt34MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "34", "Ciclo IV", txt34HomCicloIV.Text, txt34MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "34", "Ciclo V", txt34HomCicloV.Text, txt34MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "34", "Ciclo VI", txt34HomCicloVI.Text, txt34MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "35", "Ciclo I", txt35HomCicloI.Text, txt35MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "35", "Ciclo II", txt35HomCicloII.Text, txt35MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "35", "Ciclo III", txt35HomCicloIII.Text, txt35MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "35", "Ciclo IV", txt35HomCicloIV.Text, txt35MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "35", "Ciclo V", txt35HomCicloV.Text, txt35MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "35", "Ciclo VI", txt35HomCicloVI.Text, txt35MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "36", "Ciclo I", txt36HomCicloI.Text, txt36MujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "36", "Ciclo II", txt36HomCicloII.Text, txt36MujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "36", "Ciclo III", txt36HomCicloIII.Text, txt36MujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "36", "Ciclo IV", txt36HomCicloIV.Text, txt36MujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "36", "Ciclo V", txt36HomCicloV.Text, txt36MujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "36", "Ciclo VI", txt36HomCicloVI.Text, txt36MujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Total General", "Ciclo I", txtTotalGeneralHomCicloI.Text, txtTotalGeneralMujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Total General", "Ciclo II", txtTotalGeneralHomCicloII.Text, txtTotalGeneralMujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Total General", "Ciclo III", txtTotalGeneralHomCicloIII.Text, txtTotalGeneralMujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Total General", "Ciclo IV", txtTotalGeneralHomCicloIV.Text, txtTotalGeneralMujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Total General", "Ciclo V", txtTotalGeneralHomCicloV.Text, txtTotalGeneralMujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Total General", "Ciclo VI", txtTotalGeneralHomCicloVI.Text, txtTotalGeneralMujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo I", txtRepitentesHomCicloI.Text, txtRepitentesMujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo II", txtRepitentesHomCicloII.Text, txtRepitentesMujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo III", txtRepitentesHomCicloIII.Text, txtRepitentesMujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo IV", txtRepitentesHomCicloIV.Text, txtRepitentesMujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo V", txtRepitentesHomCicloV.Text, txtRepitentesMujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo VI", txtRepitentesHomCicloVI.Text, txtRepitentesMujCicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo I", txtGruposPorCiclosHomCicloI.Text, txtGruposPorCiclosMujCicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo II", txtGruposPorCiclosHomCicloII.Text, txtGruposPorCiclosMujCicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo III", txtGruposPorCiclosHomCicloIII.Text, txtGruposPorCiclosMujCicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo IV", txtGruposPorCiclosHomCicloIV.Text, txtGruposPorCiclosMujCicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo V", txtGruposPorCiclosHomCicloV.Text, txtGruposPorCiclosMujCicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo VI", txtGruposPorCiclosHomCicloVI.Text, txtGruposPorCiclosMujCicloVI.Text);
    }
    private void EliminarModelosCiclos(string codsedeasesor)
    {
        lb.eliminarRespuestaCerradaSedeGeneros(codsedeasesor, "17", "C600B");
    }
    private void AgregarModelosCiclo(string codsedeasesor)
    {
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo I", txtExtredadHomClicloI.Text, txtExtredadMujClicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo II", txtExtredadHomClicloII.Text, txtExtredadMujClicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo III", txtExtredadHomClicloIII.Text, txtExtredadMujClicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo IV", txtExtredadHomClicloIV.Text, txtExtredadMujClicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo V", txtExtredadHomClicloV.Text, txtExtredadMujClicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo VI", txtExtredadHomClicloVI.Text, txtExtredadMujClicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SAT", "Ciclo I", txtSATHomClicloI.Text, txtSATMujClicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SAT", "Ciclo II", txtSATHomClicloII.Text, txtSATMujClicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SAT", "Ciclo III", txtSATHomClicloIII.Text, txtSATMujClicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SAT", "Ciclo IV", txtSATHomClicloIV.Text, txtSATMujClicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SAT", "Ciclo V", txtSATHomClicloV.Text, txtSATMujClicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SAT", "Ciclo VI", txtSATHomClicloVI.Text, txtSATMujClicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SER", "Ciclo I", txtSERHomClicloI.Text, txtSERMujClicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SER", "Ciclo II", txtSERHomClicloII.Text, txtSERMujClicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SER", "Ciclo III", txtSERHomClicloIII.Text, txtSERMujClicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SER", "Ciclo IV", txtSERHomClicloIV.Text, txtSERMujClicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SER", "Ciclo V", txtSERHomClicloV.Text, txtSERMujClicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "SER", "Ciclo VI", txtSERHomClicloVI.Text, txtSERMujClicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo I", txtCAFAMHomClicloI.Text, txtCAFAMMujClicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo II", txtCAFAMHomClicloII.Text, txtCAFAMMujClicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo III", txtCAFAMHomClicloIII.Text, txtCAFAMMujClicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo IV", txtCAFAMHomClicloIV.Text, txtCAFAMMujClicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo V", txtCAFAMHomClicloV.Text, txtCAFAMMujClicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo VI", txtCAFAMHomClicloVI.Text, txtCAFAMMujClicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo I", txtTransformemosHomClicloI.Text, txtTransformemosMujClicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo II", txtTransformemosHomClicloII.Text, txtTransformemosMujClicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo III", txtTransformemosHomClicloIII.Text, txtTransformemosMujClicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo IV", txtTransformemosHomClicloIV.Text, txtTransformemosMujClicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo V", txtTransformemosHomClicloV.Text, txtTransformemosMujClicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo VI", txtTransformemosHomClicloVI.Text, txtTransformemosMujClicloVI.Text);

        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Otro", "Ciclo I", txtOtroHomClicloI.Text, txtOtroMujClicloI.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Otro", "Ciclo II", txtOtroHomClicloII.Text, txtOtroMujClicloII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Otro", "Ciclo III", txtOtroHomClicloIII.Text, txtOtroMujClicloIII.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Otro", "Ciclo IV", txtOtroHomClicloIV.Text, txtOtroMujClicloIV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Otro", "Ciclo V", txtOtroHomClicloV.Text, txtOtroMujClicloV.Text);
        lb.AgregarRespuestaPreguntasIntrumentoC600B(codsedeasesor, "17", "C600B", "Otro", "Ciclo VI", txtOtroHomClicloVI.Text, txtOtroMujClicloVI.Text);
    }
    protected void chkNivelesEnsenianza_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkNivelesEnsenianza.SelectedValue == "Media")
       {
           PanelCaracteryespecialidadparaMedia.Visible = true;
       }
       else
       {
           PanelCaracteryespecialidadparaMedia.Visible = false;
       }

    }
    protected void rbdiscapacidadexcepcional_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbdiscapacidadexcepcional.SelectedIndex == 0)
        {
            Paneldiscapacidadexcepcional.Visible = true;
        }
        else
        {
            Paneldiscapacidadexcepcional.Visible = false;
          
        }
    }
    protected void rbGrupoEtnico_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbGrupoEtnico.SelectedIndex == 0)
        {
            PanelGrupoEtnicos.Visible = true;
        }
        else
        {
            PanelGrupoEtnicos.Visible = false;

        }
    }
    protected void rtbEducacionFormalExtraedad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
        {
            PanelEducacionFormalExtraedad.Visible = true;
        }
        else
        {
            PanelEducacionFormalExtraedad.Visible = false;

        }
    }
    protected void btnValidarSumInvDiscapacidad_Click(object sender, EventArgs e)
    {
        //int discapacidad = Convert.ToInt32(txtDiscapacidadHom.Text) + Convert.ToInt32(txtDiscapacidadMuj.Text);
        //int capacidadExp = Convert.ToInt32(txtCapacidadExcepHom.Text) + Convert.ToInt32(txtCapacidadExcepMuj.Text);

        //int discapacidadHom = Convert.ToInt32(txtDiscapacidadHom.Text) + Convert.ToInt32(txtCapacidadExcepHom.Text);
        //int capacidadExpMuj = Convert.ToInt32(txtDiscapacidadMuj.Text) + Convert.ToInt32(txtCapacidadExcepMuj.Text);

        //txtTotalDiscapacidad.Text = Convert.ToString(discapacidad);
        //txtTotalCapacidadExcep.Text = Convert.ToString(capacidadExp);

    //    txtTotalHom.Text = Convert.ToString(discapacidadHom);
    //    txtTotalMuj.Text = Convert.ToString(capacidadExpMuj);
    }

    protected void rbVictimaConflicto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbVictimaConflicto.SelectedIndex == 0)
        {
            PanelVictimaConflicto.Visible = true;
        }
        else
        {
            PanelVictimaConflicto.Visible = false;

        }
    }

    private void CargarInformacionRespuestas(string codsede, string codinsasesor)
    {
        DataRow dat = lb.buscarSedexInsasesor(codsede);

        if(dat != null)
        {
            cargarJornadas(dat["codigo"].ToString(),chkJornadas);
            cargarGeneroPoblacion(dat["codigo"].ToString(),rbtGeneroPoblacionAtendida);
            cargarNivelesEnsenianza(dat["codigo"].ToString(),chkNivelesEnsenianza);
            cargarNivelesEnsenianzaCaracterAcademico(dat["codigo"].ToString(), chkCaracterAcademico);
            cargarNivelesEnsenianzaCaracterTecnico(dat["codigo"].ToString(), chkCaracterTecnico);
            cargarAtiendePoblacionEtnia(dat["codigo"].ToString(), rbtEtnias);
            cargarProgramasModelosEducativosPreescolar(dat["codigo"].ToString(), chkEstrategiaModelosEducativosPreescolar);
            cargarProgramasModelosEducativosPrimaria(dat["codigo"].ToString(), chkEstrategiaModelosEducativosPrimaria);
            cargarProgramasModelosEducativosSecundaria(dat["codigo"].ToString(), chkEstrategiaModelosEducativosSecundaria);
            cargarProgramasModelosEducativosMedia(dat["codigo"].ToString(), chkEstrategiaModelosEducativosMedia);
            cargarUltimoNivelEducativoDocente(dat["codigo"].ToString());
            cargarPoblacionConDiscapacidad(dat["codigo"].ToString());
            cargarIntegradosNoIntegrados(dat["codigo"].ToString());
            cargarGrupoEtnico(dat["codigo"].ToString());
            cargarPoblacionVicitmaConflicto(dat["codigo"].ToString());

            cargarNivelesPreescolaryPrimaria3(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria4(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria5(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria6(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria7(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria8(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria9(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria10(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria11(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria12(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria13(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria14(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimaria15(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimariaRepitentes(dat["codigo"].ToString());
            cargarNivelesPreescolaryPrimariaGruposxGrados(dat["codigo"].ToString());

            cargarAceleracionAprendizaje(dat["codigo"].ToString());

            cargarNivelesSecundariayMedia9(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia10(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia11(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia12(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia13(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia14(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia15(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia16(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia17(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia18(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia19(dat["codigo"].ToString());
            cargarNivelesSecundariayMedia20(dat["codigo"].ToString());
            cargarNivelesSecundariayMediaRepitentes(dat["codigo"].ToString());
            cargarNivelesSecundariayMediaGruposPorGrados(dat["codigo"].ToString());

            cargarEducacionMediaOtra(dat["codigo"].ToString());
            cargarEducacionMediaPromocion(dat["codigo"].ToString());
            cargarEducacionMediaPedagogica(dat["codigo"].ToString());
            cargarEducacionMediaIndustrial(dat["codigo"].ToString());
            cargarEducacionMediaComercial(dat["codigo"].ToString());
            cargarEducacionMediaAgropecuaria(dat["codigo"].ToString());
            cargarEducacionMediaAcademica(dat["codigo"].ToString());

            cargarEducacionExtraedad(dat["codigo"].ToString());

            cargarModelosCiclosOtro(dat["codigo"].ToString());
            cargarModelosCiclosTransformemos(dat["codigo"].ToString());
            cargarModelosCiclosCAFAM(dat["codigo"].ToString());
            cargarModelosCiclosSER(dat["codigo"].ToString());
            cargarModelosCiclosSAT(dat["codigo"].ToString());
            cargarModelosCiclosExtraedad(dat["codigo"].ToString());
            cargarGeneroEdadCicloGruposPorCiclos(dat["codigo"].ToString());
            cargarGeneroEdadCicloRepitentes(dat["codigo"].ToString());

            cargarGeneroEdadCiclo13(dat["codigo"].ToString());
            cargarGeneroEdadCiclo14(dat["codigo"].ToString());
            cargarGeneroEdadCiclo15(dat["codigo"].ToString());
            cargarGeneroEdadCiclo16(dat["codigo"].ToString());
            cargarGeneroEdadCiclo17(dat["codigo"].ToString());
            cargarGeneroEdadCiclo18(dat["codigo"].ToString());
            cargarGeneroEdadCiclo19(dat["codigo"].ToString());
            cargarGeneroEdadCiclo20(dat["codigo"].ToString());
            cargarGeneroEdadCiclo21(dat["codigo"].ToString());
            cargarGeneroEdadCiclo22(dat["codigo"].ToString());
            cargarGeneroEdadCiclo23(dat["codigo"].ToString());
            cargarGeneroEdadCiclo24(dat["codigo"].ToString());
            cargarGeneroEdadCiclo25(dat["codigo"].ToString());
            cargarGeneroEdadCiclo26(dat["codigo"].ToString());
            cargarGeneroEdadCiclo27(dat["codigo"].ToString());
            cargarGeneroEdadCiclo28(dat["codigo"].ToString());
            cargarGeneroEdadCiclo29(dat["codigo"].ToString());
            cargarGeneroEdadCiclo30(dat["codigo"].ToString());
            cargarGeneroEdadCiclo31(dat["codigo"].ToString());
            cargarGeneroEdadCiclo32(dat["codigo"].ToString());
            cargarGeneroEdadCiclo33(dat["codigo"].ToString());
            cargarGeneroEdadCiclo34(dat["codigo"].ToString());
            cargarGeneroEdadCiclo35(dat["codigo"].ToString());
            cargarGeneroEdadCiclo36(dat["codigo"].ToString());
            

            
        }
    }

    private void cargarJornadas(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "1", "0", "C600B");

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
    private void cargarGeneroPoblacion(string codsedeasesor, RadioButtonList rbt)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "2", "0", "C600B");

        if(escogido != null & escogido.Rows.Count >0)
        {
            rbt.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }
    }
    private void cargarNivelesEnsenianza(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "3", "0", "C600B");

        for (int i = 0; i < chk.Items.Count; i++)
        {
            for (int j = 0; j < escogido.Rows.Count; j++)
            {
                if (chk.Items[i].Value == escogido.Rows[j]["respuesta"].ToString())
                {
                    chk.Items[i].Selected = true;
                    if(escogido.Rows[j]["respuesta"].ToString() == "Media")
                    {
                        PanelCaracteryespecialidadparaMedia.Visible = true;
                    }
                }
            }
        }
    }
    private void cargarNivelesEnsenianzaCaracterAcademico(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "3", "1", "C600B");

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

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "3.1", "C600B");

        if(dat != null)
        {
            txtOtroAcademico.Text = dat["comentario"].ToString();
        }
    }

    private void cargarNivelesEnsenianzaCaracterTecnico(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "3", "2", "C600B");

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

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "3.2", "C600B");

        if (dat != null)
        {
            txtOtroTecnico.Text = dat["comentario"].ToString();
        }
    }

    private void cargarAtiendePoblacionEtnia(string codsedeasesor, RadioButtonList rbt)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "4", "0", "C600B");

        if (escogido != null & escogido.Rows.Count > 0)
        {
            rbt.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }
    }

    private void cargarProgramasModelosEducativosPreescolar(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "5", "1", "C600B");

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

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.1", "C600B");

        if (dat != null)
        {
            txtOtroPreescolar.Text = dat["comentario"].ToString();
        }
    }

    private void cargarProgramasModelosEducativosPrimaria(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "5", "2", "C600B");

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

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.2", "C600B");

        if (dat != null)
        {
            txtOtroPrimaria.Text = dat["comentario"].ToString();
        }
    }

    private void cargarProgramasModelosEducativosSecundaria(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "5", "3", "C600B");

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

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.3", "C600B");

        if (dat != null)
        {
            txtOtroSecundaria.Text = dat["comentario"].ToString();
        }
    }

    private void cargarProgramasModelosEducativosMedia(string codsedeasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumentoC600B(codsedeasesor, "5", "4", "C600B");

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

        DataRow dat = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "5.4", "C600B");

        if (dat != null)
        {
            txtOtroMedia.Text = dat["comentario"].ToString();
        }
    }

    private void cargarUltimoNivelEducativoDocente(string codsedeasesor)
    {
        DataRow dat = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Preescolar");
        if(dat != null){ txtBachiHomPreescolar.Text = dat["thombre"].ToString(); txtBachiMujPreescolar.Text = dat["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Primaria");
        if (dat2 != null) { txtBachiHomPrimaria.Text = dat2["thombre"].ToString(); txtBachiMujPrimaria.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Secundaria");
        if (dat3 != null) { txtBachiHomSecundaria.Text = dat3["thombre"].ToString(); txtBachiMujSecundaria.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Media");
        if (dat4 != null) { txtBachiHomMedia.Text = dat4["thombre"].ToString(); txtBachiMujMedia.Text = dat4["tmujer"].ToString(); }

        //Normalista Superior
        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Preescolar");
        if (dat5 != null) { txtSuperiorHomPreescolar.Text = dat5["thombre"].ToString(); txtSuperiorMujPreescolar.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Primaria");
        if (dat6 != null) { txtSuperiorHomPrimaria.Text = dat6["thombre"].ToString(); txtSuperiorMujPrimaria.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Secundaria");
        if (dat7 != null) { txtSuperiorHomSecundaria.Text = dat7["thombre"].ToString(); txtSuperiorMujSecundaria.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Bachillerato pedagógico", "Media");
        if (dat8 != null) { txtSuperiorHomMedia.Text = dat8["thombre"].ToString(); txtSuperiorMujMedia.Text = dat8["tmujer"].ToString(); }

        //Otro Bachillerato
        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro bachillerato", "Preescolar");
        if (dat9 != null) { txtOtroBachiHomPreescolar.Text = dat9["thombre"].ToString(); txtOtroBachiMujPreescolar.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro bachillerato", "Primaria");
        if (dat10 != null) { txtOtroBachiHomPrimaria.Text = dat10["thombre"].ToString(); txtOtroBachiMujPrimaria.Text = dat10["tmujer"].ToString(); }

        DataRow dat11 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro bachillerato", "Secundaria");
        if (dat11 != null) { txtOtroBachiHomSecundaria.Text = dat11["thombre"].ToString(); txtOtroBachiMujSecundaria.Text = dat11["tmujer"].ToString(); }

        DataRow dat12 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro bachillerato", "Media");
        if (dat12 != null) { txtOtroBachiHomMedia.Text = dat12["thombre"].ToString(); txtOtroBachiMujMedia.Text = dat12["tmujer"].ToString(); }

        //Técnico o tecnológico Pedagógico
        DataRow dat13 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Preescolar");
        if (dat13 != null) { txtTecPedagoHomPreescolar.Text = dat13["thombre"].ToString(); txtTecPedagoMujPreescolar.Text = dat13["tmujer"].ToString(); }

        DataRow dat14 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Primaria");
        if (dat14 != null) { txtTecPedagoHomPrimaria.Text = dat14["thombre"].ToString(); txtTecPedagoMujPrimaria.Text = dat14["tmujer"].ToString(); }

        DataRow dat15 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Secundaria");
        if (dat15 != null) { txtTecPedagoHomSecundaria.Text = dat15["thombre"].ToString(); txtTecPedagoMujSecundaria.Text = dat15["tmujer"].ToString(); }

        DataRow dat16 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Pedagógico", "Media");
        if (dat16 != null) { txtTecPedagoHomMedia.Text = dat16["thombre"].ToString(); txtTecPedagoMujMedia.Text = dat16["tmujer"].ToString(); }

        //Técnico o tecnológico Otro
        DataRow dat17 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Preescolar");
        if (dat17 != null) { txtOtroPedagoHomPreescolar.Text = dat17["thombre"].ToString(); txtOtroPedagoMujPreescolar.Text = dat17["tmujer"].ToString(); }

        DataRow dat18 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Primaria");
        if (dat18 != null) { txtOtroPedagoHomPrimaria.Text = dat18["thombre"].ToString(); txtOtroPedagoMujPrimaria.Text = dat18["tmujer"].ToString(); }

        DataRow dat19 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Secundaria");
        if (dat19 != null) { txtOtroPedagoHomSecundaria.Text = dat19["thombre"].ToString(); txtOtroPedagoMujSecundaria.Text = dat19["tmujer"].ToString(); }

        DataRow dat20 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Técnico o tecnológico Otro", "Media");
        if (dat20 != null) { txtOtroPedagoHomMedia.Text = dat20["thombre"].ToString(); txtOtroPedagoMujMedia.Text = dat20["tmujer"].ToString(); }

        //Profesional Pedagógico
        DataRow dat21 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Preescolar");
        if (dat21 != null) { txtProfPedagoHomPreescolar.Text = dat21["thombre"].ToString(); txtProfPedagoMujPreescolar.Text = dat21["tmujer"].ToString(); }

        DataRow dat22 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Primaria");
        if (dat22 != null) { txtProfPedagoHomPrimaria.Text = dat22["thombre"].ToString(); txtProfPedagoMujPrimaria.Text = dat22["tmujer"].ToString(); }

        DataRow dat23 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Secundaria");
        if (dat23 != null) { txtProfPedagoHomSecundaria.Text = dat23["thombre"].ToString(); txtProfPedagoMujSecundaria.Text = dat23["tmujer"].ToString(); }

        DataRow dat24 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Pedagógico", "Media");
        if (dat24 != null) { txtProfPedagoHomMedia.Text = dat24["thombre"].ToString(); txtProfPedagoMujMedia.Text = dat24["tmujer"].ToString(); }

        //Profesional Otro
        DataRow dat25 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Otro", "Preescolar");
        if (dat25 != null) { txtProfOtroPedagoHomPreescolar.Text = dat25["thombre"].ToString(); txtProfOtroPedagoMujPreescolar.Text = dat25["tmujer"].ToString(); }

        DataRow dat26 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Otro", "Primaria");
        if (dat26 != null) { txtProfOtroPedagoHomPrimaria.Text = dat26["thombre"].ToString(); txtProfOtroPedagoMujPrimaria.Text = dat26["tmujer"].ToString(); }

        DataRow dat27 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Otro", "Secundaria");
        if (dat27 != null) { txtProfOtroPedagoHomSecundaria.Text = dat27["thombre"].ToString(); txtProfOtroPedagoMujSecundaria.Text = dat27["tmujer"].ToString(); }

        DataRow dat28 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Profesional Otro", "Media");
        if (dat28 != null) { txtProfOtroPedagoHomMedia.Text = dat28["thombre"].ToString(); txtProfOtroPedagoMujMedia.Text = dat28["tmujer"].ToString(); }

        //Posgrado Pedagógico
        DataRow dat29 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Preescolar");
        if (dat29 != null) { txtPosPedagoHomPreescolar.Text = dat29["thombre"].ToString(); txtPosPedagoMujPreescolar.Text = dat29["tmujer"].ToString(); }

        DataRow dat30 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Primaria");
        if (dat30 != null) { txtPosPedagoHomPrimaria.Text = dat30["thombre"].ToString(); txtPosPedagoMujPrimaria.Text = dat30["tmujer"].ToString(); }

        DataRow dat31 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Secundaria");
        if (dat31 != null) { txtPosPedagoHomSecundaria.Text = dat31["thombre"].ToString(); txtPosPedagoMujSecundaria.Text = dat31["tmujer"].ToString(); }

        DataRow dat32 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Pedagógico", "Media");
        if (dat32 != null) { txtPosPedagoHomMedia.Text = dat32["thombre"].ToString(); txtPosPedagoMujMedia.Text = dat32["tmujer"].ToString(); }

        //Posgrado Otro
        DataRow dat33 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Otro", "Preescolar");
        if (dat33 != null) { txtPosOtroPedagoHomPreescolar.Text = dat33["thombre"].ToString(); txtPosOtroPedagoMujPreescolar.Text = dat33["tmujer"].ToString(); }

        DataRow dat34 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Otro", "Primaria");
        if (dat34 != null) { txtPosOtroPedagoHomPrimaria.Text = dat34["thombre"].ToString(); txtPosOtroPedagoMujPrimaria.Text = dat34["tmujer"].ToString(); }

        DataRow dat35 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Otro", "Secundaria");
        if (dat35 != null) { txtPosOtroPedagoHomSecundaria.Text = dat35["thombre"].ToString(); txtPosOtroPedagoMujSecundaria.Text = dat35["tmujer"].ToString(); }

        DataRow dat36 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Posgrado Otro", "Media");
        if (dat36 != null) { txtPosOtroPedagoHomMedia.Text = dat36["thombre"].ToString(); txtPosOtroPedagoMujMedia.Text = dat36["tmujer"].ToString(); }

        //Otro
        DataRow dat37 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro", "Preescolar");
        if (dat37 != null) { txtOtroCualHomPreescolar.Text = dat37["thombre"].ToString(); txtOtroCualMujPreescolar.Text = dat37["tmujer"].ToString(); }

        DataRow dat38 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro", "Primaria");
        if (dat38 != null) { txtOtroCualHomPrimaria.Text = dat38["thombre"].ToString(); txtOtroCualMujPrimaria.Text = dat38["tmujer"].ToString(); }

        DataRow dat39 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro", "Secundaria");
        if (dat39 != null) { txtOtroCualHomSecundaria.Text = dat39["thombre"].ToString(); txtOtroCualMujSecundaria.Text = dat39["tmujer"].ToString(); }

        DataRow dat40 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "6", "C600B", "Otro", "Media");
        if (dat40 != null) { txtOtroCualHomMedia.Text = dat40["thombre"].ToString(); txtOtroCualMujMedia.Text = dat40["tmujer"].ToString(); }


    }

    private void cargarPoblacionConDiscapacidad(string codsedeasesor)
    {
        //Con discapacidad
        int val =0;
        DataRow dat37 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con discapacidad", "Preescolar");
        if (dat37 != null) { txtDiscapacidadHomPreescolar.Text = dat37["thombre"].ToString(); txtDiscapacidadMujPreescolar.Text = dat37["tmujer"].ToString(); val++; }

        DataRow dat38 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con discapacidad", "Primaria");
        if (dat38 != null) { txtDiscapacidadHomPrimaria.Text = dat38["thombre"].ToString(); txtDiscapacidadMujPrimaria.Text = dat38["tmujer"].ToString(); val++; }

        DataRow dat39 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con discapacidad", "Secundaria");
        if (dat39 != null) { txtDiscapacidadHomSecundaria.Text = dat39["thombre"].ToString(); txtDiscapacidadMujSecundaria.Text = dat39["tmujer"].ToString(); }

        DataRow dat40 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con discapacidad", "Media");
        if (dat40 != null) { txtDiscapacidadHomMedia.Text = dat40["thombre"].ToString(); txtDiscapacidadMujMedia.Text = dat40["tmujer"].ToString(); val++; }

        //Con capacidades excepcionales	
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Preescolar");
        if (dat3 != null) { txtCapacidadExcepHomPreescolar.Text = dat3["thombre"].ToString(); txtCapacidadExcepMujPreescolar.Text = dat3["tmujer"].ToString(); val++; }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Primaria");
        if (dat4 != null) { txtCapacidadExcepHomPrimaria.Text = dat4["thombre"].ToString(); txtCapacidadExcepMujPrimaria.Text = dat4["tmujer"].ToString(); val++; }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Secundaria");
        if (dat5 != null) { txtCapacidadExcepHomSecundaria.Text = dat5["thombre"].ToString(); txtCapacidadExcepMujSecundaria.Text = dat5["tmujer"].ToString(); val++; }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "7", "C600B", "Con capacidades excepcionales	", "Media");
        if (dat6 != null) { txtCapacidadExcepHomMedia.Text = dat6["thombre"].ToString(); txtCapacidadExcepMujMedia.Text = dat6["tmujer"].ToString(); val++; }

        if(val > 0)
        {
            rbdiscapacidadexcepcional.SelectedIndex = 0;
            Paneldiscapacidadexcepcional.Visible = true;
        }
        
    }

    private void cargarIntegradosNoIntegrados(string codsedeasesor)
    {
        //Auditiva
        DataRow dat40 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Auditiva", "Integrados");
        if (dat40 != null) { txtAuditivaHomInte.Text = dat40["thombre"].ToString(); txtAuditivaMujInte.Text = dat40["tmujer"].ToString(); }

        DataRow dat41 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Auditiva", "No Integrados");
        if (dat41 != null) { txtAuditivaHomNoInte.Text = dat41["thombre"].ToString(); txtAuditivaMujNoInte.Text = dat41["tmujer"].ToString(); }

        //Visual
        DataRow dat42 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Visual", "Integrados");
        if (dat42 != null) { txtVisualHomInte.Text = dat42["thombre"].ToString(); txtVisualMujInte.Text = dat42["tmujer"].ToString(); }

        DataRow dat43 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Visual", "No Integrados");
        if (dat43 != null) { txtVisualHomNoInte.Text = dat43["thombre"].ToString(); txtVisualMujNoInte.Text = dat43["tmujer"].ToString(); }

        //Motora
        DataRow dat44 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Motora", "Integrados");
        if (dat44 != null) { txtMotoraHomInte.Text = dat44["thombre"].ToString(); txtMotoraMujInte.Text = dat44["tmujer"].ToString(); }

        DataRow dat45 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Motora", "No Integrados");
        if (dat45 != null) { txtMotoraHomNoInte.Text = dat45["thombre"].ToString(); txtMotoraMujNoInte.Text = dat45["tmujer"].ToString(); }

        //Cognitiva
        DataRow dat46 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Motora", "Integrados");
        if (dat46 != null) { txtCognitivaHomInte.Text = dat46["thombre"].ToString(); txtCognitivaMujInte.Text = dat46["tmujer"].ToString(); }

        DataRow dat47 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Motora", "No Integrados");
        if (dat47 != null) { txtCognitivaHomNoInte.Text = dat47["thombre"].ToString(); txtCognitivaMujNoInte.Text = dat47["tmujer"].ToString(); }

        //Autismo
        DataRow dat48 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Autismo", "Integrados");
        if (dat48 != null) { txtAutismoHomInte.Text = dat48["thombre"].ToString(); txtAutismoMujInte.Text = dat48["tmujer"].ToString(); }

        DataRow dat49 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Autismo", "No Integrados");
        if (dat49 != null) { txtAutismoHomNoInte.Text = dat49["thombre"].ToString(); txtAutismoMujNoInte.Text = dat49["tmujer"].ToString(); }

        //Múltiple
        DataRow dat50 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Autismo", "Integrados");
        if (dat50 != null) { txtMultipleHomInte.Text = dat50["thombre"].ToString(); txtMultipleMujInte.Text = dat50["tmujer"].ToString(); }

        DataRow dat51 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Autismo", "No Integrados");
        if (dat51 != null) { txtMultipleHomNoInte.Text = dat51["thombre"].ToString(); txtMultipleMujNoInte.Text = dat51["tmujer"].ToString(); }

        //Otra
        DataRow dat52 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Otra", "Integrados");
        if (dat52 != null) { txtOtraHomInte.Text = dat52["thombre"].ToString(); txtOtraMujInte.Text = dat52["tmujer"].ToString(); }

        DataRow dat53 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "8", "C600B", "Otra", "No Integrados");
        if (dat53 != null) { txtOtraHomNoInte.Text = dat53["thombre"].ToString(); txtOtraMujNoInte.Text = dat53["tmujer"].ToString(); }
    }

    private void cargarGrupoEtnico(string codsedeasesor)
    {
        int val = 0;
        //Indígenas
        DataRow dat37 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Indígenas", "Preescolar");
        if (dat37 != null) { txtIndigenaHomPreescolar.Text = dat37["thombre"].ToString(); txtIndigenaMujPreescolar.Text = dat37["tmujer"].ToString(); val++; }

        DataRow dat38 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Indígenas", "Primaria");
        if (dat38 != null) { txtIndigenaHomPrimaria.Text = dat38["thombre"].ToString(); txtIndigenaMujPrimaria.Text = dat38["tmujer"].ToString(); val++; }

        DataRow dat39 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Indígenas", "Secundaria");
        if (dat39 != null) { txtIndigenaHomSecundaria.Text = dat39["thombre"].ToString(); txtIndigenaMujSecundaria.Text = dat39["tmujer"].ToString(); val++; }

        DataRow dat40 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Indígenas", "Media");
        if (dat40 != null) { txtIndigenaHomMedia.Text = dat40["thombre"].ToString(); txtIndigenaMujMedia.Text = dat40["tmujer"].ToString(); val++; }

        //Rom (gitanos)
        DataRow dat41 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Preescolar");
        if (dat41 != null) { txtRomHomPreescolar.Text = dat41["thombre"].ToString(); txtRomMujPreescolar.Text = dat41["tmujer"].ToString(); val++; }

        DataRow dat42 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Primaria");
        if (dat42 != null) { txtRomHomPrimaria.Text = dat42["thombre"].ToString(); txtRomMujPrimaria.Text = dat42["tmujer"].ToString(); val++; }

        DataRow dat43 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Secundaria");
        if (dat43 != null) { txtRomHomSecundaria.Text = dat43["thombre"].ToString(); txtRomMujSecundaria.Text = dat43["tmujer"].ToString(); val++; }

        DataRow dat44 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Rom (gitanos)", "Media");
        if (dat44 != null) { txtRomHomMedia.Text = dat40["thombre"].ToString(); txtRomMujMedia.Text = dat40["tmujer"].ToString(); val++; }

        //Afrocolombianos, afrodecendientes, negro o mulato
        DataRow dat45 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Preescolar");
        if (dat45 != null) { txtAfroHomPreescolar.Text = dat45["thombre"].ToString(); txtAfroMujPreescolar.Text = dat45["tmujer"].ToString(); val++; }

        DataRow dat46 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Primaria");
        if (dat46 != null) { txtAfroHomPrimaria.Text = dat46["thombre"].ToString(); txtAfroMujPrimaria.Text = dat46["tmujer"].ToString(); val++; }

        DataRow dat47 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Secundaria");
        if (dat47 != null) { txtAfroHomSecundaria.Text = dat47["thombre"].ToString(); txtAfroMujSecundaria.Text = dat47["tmujer"].ToString(); val++; }

        DataRow dat48 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Afrocolombianos, afrodecendientes, negro o mulato", "Media");
        if (dat48 != null) { txtAfroHomMedia.Text = dat48["thombre"].ToString(); txtAfroMujMedia.Text = dat48["tmujer"].ToString(); val++; }

        //Raizal del archipiélago de San Andrés, Providencia y Santa Catalina
        DataRow dat49 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Preescolar");
        if (dat49 != null) { txtRaizaHomPreescolar.Text = dat49["thombre"].ToString(); txtRaizaMujPreescolar.Text = dat49["tmujer"].ToString(); val++; }

        DataRow dat50 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Primaria");
        if (dat50 != null) { txtRaizaHomPrimaria.Text = dat50["thombre"].ToString(); txtRaizaMujPrimaria.Text = dat50["tmujer"].ToString(); val++; }

        DataRow dat51 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Secundaria");
        if (dat51 != null) { txtRaizaHomSecundaria.Text = dat51["thombre"].ToString(); txtRaizaMujSecundaria.Text = dat51["tmujer"].ToString(); val++; }

        DataRow dat52 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina", "Media");
        if (dat52 != null) { txtRaizaHomMedia.Text = dat52["thombre"].ToString(); txtRaizaMujMedia.Text = dat52["tmujer"].ToString(); val++; }

        //Palenquero de San Basilio
        DataRow dat53 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Preescolar");
        if (dat53 != null) { txtPalenqueroHomPreescolar.Text = dat53["thombre"].ToString(); txtPalenqueroMujPreescolar.Text = dat53["tmujer"].ToString(); val++; }

        DataRow dat54 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Primaria");
        if (dat54 != null) { txtPalenqueroHomPrimaria.Text = dat54["thombre"].ToString(); txtPalenqueroMujPrimaria.Text = dat54["tmujer"].ToString(); val++; }

        DataRow dat55 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Secundaria");
        if (dat55 != null) { txtPalenqueroHomSecundaria.Text = dat55["thombre"].ToString(); txtPalenqueroMujSecundaria.Text = dat51["tmujer"].ToString(); val++; }

        DataRow dat56 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "9", "C600B", "Palenquero de San Basilio", "Media");
        if (dat56 != null) { txtPalenqueroHomMedia.Text = dat56["thombre"].ToString(); txtPalenqueroMujMedia.Text = dat56["tmujer"].ToString(); val++; }

        DataRow respuesta = lb.cargarRespuestaAbiertaInstrumentoC600B(codsedeasesor, "9", "C600B");
        if(respuesta != null)
        {
            txtNomGrupoIndigena.Text = respuesta["comentario"].ToString();
        }

        if(val > 0)
        {
            rbGrupoEtnico.SelectedIndex = 0;
            PanelGrupoEtnicos.Visible = true;
        }
    }

    private void cargarPoblacionVicitmaConflicto(string codsedeasesor)
    {
        //En situación de desplazamiento
        int val = 0;
        DataRow dat37 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Preescolar");
        if (dat37 != null) { txtDesplazamientoHomPreescolar.Text = dat37["thombre"].ToString(); txtDesplazamientoMujPreescolar.Text = dat37["tmujer"].ToString(); val++; }

        DataRow dat38 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Primaria");
        if (dat38 != null) { txtDesplazamientoHomPrimaria.Text = dat38["thombre"].ToString(); txtDesplazamientoMujPrimaria.Text = dat38["tmujer"].ToString(); val++; }

        DataRow dat39 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Secundaria");
        if (dat39 != null) { txtDesplazamientoHomSecundaria.Text = dat39["thombre"].ToString(); txtDesplazamientoMujSecundaria.Text = dat39["tmujer"].ToString(); val++; }

        DataRow dat40 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "En situación de desplazamiento", "Media");
        if (dat40 != null) { txtDesplazamientoHomMedia.Text = dat40["thombre"].ToString(); txtDesplazamientoMujMedia.Text = dat40["tmujer"].ToString(); val++; }

        //Desvinculados de organizaciones armadas al margen de la Ley	
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Preescolar");
        if (dat3 != null) { txtAlMargenHomPreescolar.Text = dat3["thombre"].ToString(); txtAlMargenMujPreescolar.Text = dat3["tmujer"].ToString(); val++; }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Primaria");
        if (dat4 != null) { txtAlMargenHomPrimaria.Text = dat4["thombre"].ToString(); txtAlMargenMujPrimaria.Text = dat4["tmujer"].ToString(); val++; }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Secundaria");
        if (dat5 != null) { txtAlMargenHomSecundaria.Text = dat5["thombre"].ToString(); txtAlMargenMujSecundaria.Text = dat5["tmujer"].ToString(); val++; }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Desvinculados de organizaciones armadas al margen de la Ley", "Media");
        if (dat6 != null) { txtAlMargenHomMedia.Text = dat6["thombre"].ToString(); txtAlMargenMujMedia.Text = dat6["tmujer"].ToString(); val++; }

        //Hijos de adultos desmovilizados	
        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Preescolar");
        if (dat7 != null) { txtDesmovilizadosHomPreescolar.Text = dat7["thombre"].ToString(); txtDesmovilizadosMujPreescolar.Text = dat7["tmujer"].ToString(); val++; }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Primaria");
        if (dat8 != null) { txtDesmovilizadosHomPrimaria.Text = dat8["thombre"].ToString(); txtDesmovilizadosMujPrimaria.Text = dat8["tmujer"].ToString(); val++; }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Secundaria");
        if (dat9 != null) { txtDesmovilizadosHomSecundaria.Text = dat9["thombre"].ToString(); txtDesmovilizadosMujSecundaria.Text = dat9["tmujer"].ToString(); val++; }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "10", "C600B", "Hijos de adultos desmovilizados", "Media");
        if (dat10 != null) { txtDesmovilizadosHomMedia.Text = dat10["thombre"].ToString(); txtDesmovilizadosMujMedia.Text = dat10["tmujer"].ToString(); val++; }

        if (val > 0)
        {
            rbVictimaConflicto.SelectedIndex = 0;
            PanelVictimaConflicto.Visible = true;
        }

    }

    private void cargarNivelesPreescolaryPrimaria3(string codsedeasesor)
    {
        //3 
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Pre jardín");
        if (dat3 != null) { txtEdad3HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad3MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Jardín");
        if (dat4 != null) { txtEdad3HomJardin.Text = dat4["thombre"].ToString(); txtEdad3MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Transición");
        if (dat5 != null) { txtEdad3HomTransicion.Text = dat5["thombre"].ToString(); txtEdad3MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Primero");
        if (dat6 != null) { txtEdad3HomPrimero.Text = dat6["thombre"].ToString(); txtEdad3MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Segundo");
        if (dat7 != null) { txtEdad3HomSegundo.Text = dat7["thombre"].ToString(); txtEdad3MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Tercero");
        if (dat8 != null) { txtEdad3HomTercero.Text = dat8["thombre"].ToString(); txtEdad3MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Cuarto");
        if (dat9 != null) { txtEdad3HomCuarto.Text = dat9["thombre"].ToString(); txtEdad3MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "3", "Quinto");
        if (dat10 != null) { txtEdad3HomQuinto.Text = dat10["thombre"].ToString(); txtEdad3MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria4(string codsedeasesor)
    {
        //4 
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Pre jardín");
        if (dat3 != null) { txtEdad4HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad4MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Jardín");
        if (dat4 != null) { txtEdad4HomJardin.Text = dat4["thombre"].ToString(); txtEdad4MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Transición");
        if (dat5 != null) { txtEdad4HomTransicion.Text = dat5["thombre"].ToString(); txtEdad4MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Primero");
        if (dat6 != null) { txtEdad4HomPrimero.Text = dat6["thombre"].ToString(); txtEdad4MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Segundo");
        if (dat7 != null) { txtEdad4HomSegundo.Text = dat7["thombre"].ToString(); txtEdad4MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Tercero");
        if (dat8 != null) { txtEdad4HomTercero.Text = dat8["thombre"].ToString(); txtEdad4MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Cuarto");
        if (dat9 != null) { txtEdad4HomCuarto.Text = dat9["thombre"].ToString(); txtEdad4MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "4", "Quinto");
        if (dat10 != null) { txtEdad4HomQuinto.Text = dat10["thombre"].ToString(); txtEdad4MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria5(string codsedeasesor)
    {
        //5
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Pre jardín");
        if (dat3 != null) { txtEdad5HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad5MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Jardín");
        if (dat4 != null) { txtEdad5HomJardin.Text = dat4["thombre"].ToString(); txtEdad5MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Transición");
        if (dat5 != null) { txtEdad5HomTransicion.Text = dat5["thombre"].ToString(); txtEdad5MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Primero");
        if (dat6 != null) { txtEdad5HomPrimero.Text = dat6["thombre"].ToString(); txtEdad5MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Segundo");
        if (dat7 != null) { txtEdad5HomSegundo.Text = dat7["thombre"].ToString(); txtEdad5MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Tercero");
        if (dat8 != null) { txtEdad5HomTercero.Text = dat8["thombre"].ToString(); txtEdad5MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Cuarto");
        if (dat9 != null) { txtEdad5HomCuarto.Text = dat9["thombre"].ToString(); txtEdad5MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "5", "Quinto");
        if (dat10 != null) { txtEdad5HomQuinto.Text = dat10["thombre"].ToString(); txtEdad5MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria6(string codsedeasesor)
    {
        //6
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Pre jardín");
        if (dat3 != null) { txtEdad6HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad6MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Jardín");
        if (dat4 != null) { txtEdad6HomJardin.Text = dat4["thombre"].ToString(); txtEdad6MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Transición");
        if (dat5 != null) { txtEdad6HomTransicion.Text = dat5["thombre"].ToString(); txtEdad6MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Primero");
        if (dat6 != null) { txtEdad6HomPrimero.Text = dat6["thombre"].ToString(); txtEdad6MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Segundo");
        if (dat7 != null) { txtEdad6HomSegundo.Text = dat7["thombre"].ToString(); txtEdad6MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Tercero");
        if (dat8 != null) { txtEdad6HomTercero.Text = dat8["thombre"].ToString(); txtEdad6MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Cuarto");
        if (dat9 != null) { txtEdad6HomCuarto.Text = dat9["thombre"].ToString(); txtEdad6MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "6", "Quinto");
        if (dat10 != null) { txtEdad6HomQuinto.Text = dat10["thombre"].ToString(); txtEdad6MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria7(string codsedeasesor)
    {
        //7
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Pre jardín");
        if (dat3 != null) { txtEdad7HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad7MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Jardín");
        if (dat4 != null) { txtEdad7HomJardin.Text = dat4["thombre"].ToString(); txtEdad7MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Transición");
        if (dat5 != null) { txtEdad7HomTransicion.Text = dat5["thombre"].ToString(); txtEdad7MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Primero");
        if (dat6 != null) { txtEdad7HomPrimero.Text = dat6["thombre"].ToString(); txtEdad7MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Segundo");
        if (dat7 != null) { txtEdad7HomSegundo.Text = dat7["thombre"].ToString(); txtEdad7MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Tercero");
        if (dat8 != null) { txtEdad7HomTercero.Text = dat8["thombre"].ToString(); txtEdad7MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Cuarto");
        if (dat9 != null) { txtEdad7HomCuarto.Text = dat9["thombre"].ToString(); txtEdad7MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "7", "Quinto");
        if (dat10 != null) { txtEdad7HomQuinto.Text = dat10["thombre"].ToString(); txtEdad7MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria8(string codsedeasesor)
    {
        //8
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Pre jardín");
        if (dat3 != null) { txtEdad8HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad8MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Jardín");
        if (dat4 != null) { txtEdad8HomJardin.Text = dat4["thombre"].ToString(); txtEdad8MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Transición");
        if (dat5 != null) { txtEdad8HomTransicion.Text = dat5["thombre"].ToString(); txtEdad8MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Primero");
        if (dat6 != null) { txtEdad8HomPrimero.Text = dat6["thombre"].ToString(); txtEdad8MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Segundo");
        if (dat7 != null) { txtEdad8HomSegundo.Text = dat7["thombre"].ToString(); txtEdad8MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Tercero");
        if (dat8 != null) { txtEdad8HomTercero.Text = dat8["thombre"].ToString(); txtEdad8MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Cuarto");
        if (dat9 != null) { txtEdad8HomCuarto.Text = dat9["thombre"].ToString(); txtEdad8MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "8", "Quinto");
        if (dat10 != null) { txtEdad8HomQuinto.Text = dat10["thombre"].ToString(); txtEdad8MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria9(string codsedeasesor)
    {
        //9
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Pre jardín");
        if (dat3 != null) { txtEdad9HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad9MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Jardín");
        if (dat4 != null) { txtEdad9HomJardin.Text = dat4["thombre"].ToString(); txtEdad9MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Transición");
        if (dat5 != null) { txtEdad9HomTransicion.Text = dat5["thombre"].ToString(); txtEdad9MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Primero");
        if (dat6 != null) { txtEdad9HomPrimero.Text = dat6["thombre"].ToString(); txtEdad9MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Segundo");
        if (dat7 != null) { txtEdad9HomSegundo.Text = dat7["thombre"].ToString(); txtEdad9MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Tercero");
        if (dat8 != null) { txtEdad9HomTercero.Text = dat8["thombre"].ToString(); txtEdad9MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Cuarto");
        if (dat9 != null) { txtEdad9HomCuarto.Text = dat9["thombre"].ToString(); txtEdad9MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "9", "Quinto");
        if (dat10 != null) { txtEdad9HomQuinto.Text = dat10["thombre"].ToString(); txtEdad9MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria10(string codsedeasesor)
    {
        //10
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Pre jardín");
        if (dat3 != null) { txtEdad10HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad10MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Jardín");
        if (dat4 != null) { txtEdad10HomJardin.Text = dat4["thombre"].ToString(); txtEdad10MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Transición");
        if (dat5 != null) { txtEdad10HomTransicion.Text = dat5["thombre"].ToString(); txtEdad10MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Primero");
        if (dat6 != null) { txtEdad10HomPrimero.Text = dat6["thombre"].ToString(); txtEdad10MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Segundo");
        if (dat7 != null) { txtEdad10HomSegundo.Text = dat7["thombre"].ToString(); txtEdad10MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Tercero");
        if (dat8 != null) { txtEdad10HomTercero.Text = dat8["thombre"].ToString(); txtEdad10MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Cuarto");
        if (dat9 != null) { txtEdad10HomCuarto.Text = dat9["thombre"].ToString(); txtEdad10MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "10", "Quinto");
        if (dat10 != null) { txtEdad10HomQuinto.Text = dat10["thombre"].ToString(); txtEdad10MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria11(string codsedeasesor)
    {
        //11
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Pre jardín");
        if (dat3 != null) { txtEdad11HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad11MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Jardín");
        if (dat4 != null) { txtEdad11HomJardin.Text = dat4["thombre"].ToString(); txtEdad11MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Transición");
        if (dat5 != null) { txtEdad11HomTransicion.Text = dat5["thombre"].ToString(); txtEdad11MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Primero");
        if (dat6 != null) { txtEdad11HomPrimero.Text = dat6["thombre"].ToString(); txtEdad11MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Segundo");
        if (dat7 != null) { txtEdad11HomSegundo.Text = dat7["thombre"].ToString(); txtEdad11MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Tercero");
        if (dat8 != null) { txtEdad11HomTercero.Text = dat8["thombre"].ToString(); txtEdad11MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Cuarto");
        if (dat9 != null) { txtEdad11HomCuarto.Text = dat9["thombre"].ToString(); txtEdad11MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "11", "Quinto");
        if (dat10 != null) { txtEdad11HomQuinto.Text = dat10["thombre"].ToString(); txtEdad11MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria12(string codsedeasesor)
    {
        //12
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Pre jardín");
        if (dat3 != null) { txtEdad12HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad12MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Jardín");
        if (dat4 != null) { txtEdad12HomJardin.Text = dat4["thombre"].ToString(); txtEdad12MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Transición");
        if (dat5 != null) { txtEdad12HomTransicion.Text = dat5["thombre"].ToString(); txtEdad12MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Primero");
        if (dat6 != null) { txtEdad12HomPrimero.Text = dat6["thombre"].ToString(); txtEdad12MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Segundo");
        if (dat7 != null) { txtEdad12HomSegundo.Text = dat7["thombre"].ToString(); txtEdad12MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Tercero");
        if (dat8 != null) { txtEdad12HomTercero.Text = dat8["thombre"].ToString(); txtEdad12MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Cuarto");
        if (dat9 != null) { txtEdad12HomCuarto.Text = dat9["thombre"].ToString(); txtEdad12MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "12", "Quinto");
        if (dat10 != null) { txtEdad12HomQuinto.Text = dat10["thombre"].ToString(); txtEdad12MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria13(string codsedeasesor)
    {
        //13
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Pre jardín");
        if (dat3 != null) { txtEdad13HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad13MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Jardín");
        if (dat4 != null) { txtEdad13HomJardin.Text = dat4["thombre"].ToString(); txtEdad13MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Transición");
        if (dat5 != null) { txtEdad13HomTransicion.Text = dat5["thombre"].ToString(); txtEdad13MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Primero");
        if (dat6 != null) { txtEdad13HomPrimero.Text = dat6["thombre"].ToString(); txtEdad13MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Segundo");
        if (dat7 != null) { txtEdad13HomSegundo.Text = dat7["thombre"].ToString(); txtEdad13MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Tercero");
        if (dat8 != null) { txtEdad13HomTercero.Text = dat8["thombre"].ToString(); txtEdad13MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Cuarto");
        if (dat9 != null) { txtEdad13HomCuarto.Text = dat9["thombre"].ToString(); txtEdad13MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "13", "Quinto");
        if (dat10 != null) { txtEdad13HomQuinto.Text = dat10["thombre"].ToString(); txtEdad13MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria14(string codsedeasesor)
    {
        //14
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Pre jardín");
        if (dat3 != null) { txtEdad14HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad14MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Jardín");
        if (dat4 != null) { txtEdad14HomJardin.Text = dat4["thombre"].ToString(); txtEdad14MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Transición");
        if (dat5 != null) { txtEdad14HomTransicion.Text = dat5["thombre"].ToString(); txtEdad14MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Primero");
        if (dat6 != null) { txtEdad14HomPrimero.Text = dat6["thombre"].ToString(); txtEdad14MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Segundo");
        if (dat7 != null) { txtEdad14HomSegundo.Text = dat7["thombre"].ToString(); txtEdad14MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Tercero");
        if (dat8 != null) { txtEdad14HomTercero.Text = dat8["thombre"].ToString(); txtEdad14MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Cuarto");
        if (dat9 != null) { txtEdad14HomCuarto.Text = dat9["thombre"].ToString(); txtEdad14MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "14", "Quinto");
        if (dat10 != null) { txtEdad14HomQuinto.Text = dat10["thombre"].ToString(); txtEdad14MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimaria15(string codsedeasesor)
    {
        //15
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Pre jardín");
        if (dat3 != null) { txtEdad15HomPrejardin.Text = dat3["thombre"].ToString(); txtEdad15MujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Jardín");
        if (dat4 != null) { txtEdad15HomJardin.Text = dat4["thombre"].ToString(); txtEdad15MujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Transición");
        if (dat5 != null) { txtEdad15HomTransicion.Text = dat5["thombre"].ToString(); txtEdad15MujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Primero");
        if (dat6 != null) { txtEdad15HomPrimero.Text = dat6["thombre"].ToString(); txtEdad15MujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Segundo");
        if (dat7 != null) { txtEdad15HomSegundo.Text = dat7["thombre"].ToString(); txtEdad15MujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Tercero");
        if (dat8 != null) { txtEdad15HomTercero.Text = dat8["thombre"].ToString(); txtEdad15MujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Cuarto");
        if (dat9 != null) { txtEdad15HomCuarto.Text = dat9["thombre"].ToString(); txtEdad15MujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "15", "Quinto");
        if (dat10 != null) { txtEdad15HomQuinto.Text = dat10["thombre"].ToString(); txtEdad15MujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarNivelesPreescolaryPrimariaRepitentes(string codsedeasesor)
    {
        //Núm. Repitentes o re iniciantes
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Pre jardín");
        if (dat3 != null) { txtEdadRepitentesHomPrejardin.Text = dat3["thombre"].ToString(); txtEdadRepitentesMujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Jardín");
        if (dat4 != null) { txtEdadRepitentesHomJardin.Text = dat4["thombre"].ToString(); txtEdadRepitentesMujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Transición");
        if (dat5 != null) { txtEdadRepitentesHomTransicion.Text = dat5["thombre"].ToString(); txtEdadRepitentesMujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Primero");
        if (dat6 != null) { txtEdadRepitentesHomPrimero.Text = dat6["thombre"].ToString(); txtEdadRepitentesMujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Segundo");
        if (dat7 != null) { txtEdadRepitentesHomSegundo.Text = dat7["thombre"].ToString(); txtEdadRepitentesMujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Tercero");
        if (dat8 != null) { txtEdadRepitentesHomTercero.Text = dat8["thombre"].ToString(); txtEdadRepitentesMujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Cuarto");
        if (dat9 != null) { txtEdadRepitentesHomCuarto.Text = dat9["thombre"].ToString(); txtEdadRepitentesMujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. Repitentes o re iniciantes", "Quinto");
        if (dat10 != null) { txtEdadRepitentesHomQuinto.Text = dat10["thombre"].ToString(); txtEdadRepitentesMujQuinto.Text = dat10["tmujer"].ToString(); }
    }
    private void cargarNivelesPreescolaryPrimariaGruposxGrados(string codsedeasesor)
    {
        //Núm. De grupos por grado*
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Pre jardín");
        if (dat3 != null) { txtEdadGruposPorGradoHomPrejardin.Text = dat3["thombre"].ToString(); txtEdadGruposPorGradoMujPrejardin.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Jardín");
        if (dat4 != null) { txtEdadGruposPorGradoHomJardin.Text = dat4["thombre"].ToString(); txtEdadGruposPorGradoMujJardin.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Transición");
        if (dat5 != null) { txtEdadGruposPorGradoHomTransicion.Text = dat5["thombre"].ToString(); txtEdadGruposPorGradoMujTransicion.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Primero");
        if (dat6 != null) { txtEdadGruposPorGradoHomPrimero.Text = dat6["thombre"].ToString(); txtEdadGruposPorGradoMujPrimero.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Segundo");
        if (dat7 != null) { txtEdadGruposPorGradoHomSegundo.Text = dat7["thombre"].ToString(); txtEdadGruposPorGradoMujSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Tercero");
        if (dat8 != null) { txtEdadGruposPorGradoHomTercero.Text = dat8["thombre"].ToString(); txtEdadGruposPorGradoMujTercero.Text = dat8["tmujer"].ToString(); }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Cuarto");
        if (dat9 != null) { txtEdadGruposPorGradoHomCuarto.Text = dat9["thombre"].ToString(); txtEdadGruposPorGradoMujCuarto.Text = dat9["tmujer"].ToString(); }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "11", "C600B", "Núm. De grupos por grado*", "Quinto");
        if (dat10 != null) { txtEdadGruposPorGradoHomQuinto.Text = dat10["thombre"].ToString(); txtEdadGruposPorGradoMujQuinto.Text = dat10["tmujer"].ToString(); }
    }

    private void cargarAceleracionAprendizaje(string codsedeasesor)
    {
        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "10", "");
        if (dat10 != null) { txtHom10Primaria.Text = dat10["thombre"].ToString(); txtMuj10Primaria.Text = dat10["tmujer"].ToString(); }

        DataRow dat11 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "11", "");
        if (dat11 != null) { txtHom11Primaria.Text = dat11["thombre"].ToString(); txtMuj11Primaria.Text = dat11["tmujer"].ToString(); }

        DataRow dat12 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "12", "");
        if (dat12 != null) { txtHom12Primaria.Text = dat12["thombre"].ToString(); txtMuj12Primaria.Text = dat12["tmujer"].ToString(); }

        DataRow dat13 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "13", "");
        if (dat13 != null) { txtHom13Primaria.Text = dat13["thombre"].ToString(); txtMuj13Primaria.Text = dat13["tmujer"].ToString(); }

        DataRow dat14 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "14", "");
        if (dat14 != null) { txtHom14Primaria.Text = dat14["thombre"].ToString(); txtMuj14Primaria.Text = dat14["tmujer"].ToString(); }

        DataRow dat15 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "15", "");
        if (dat15 != null) { txtHom15Primaria.Text = dat15["thombre"].ToString(); txtMuj15Primaria.Text = dat15["tmujer"].ToString(); }

        DataRow dat16 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "16", "");
        if (dat16 != null) { txtHom16Primaria.Text = dat16["thombre"].ToString(); txtMuj16Primaria.Text = dat16["tmujer"].ToString(); }

        DataRow dat17 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "12", "C600B", "17", "");
        if (dat17 != null) { txtHom17Primaria.Text = dat17["thombre"].ToString(); txtMuj17Primaria.Text = dat17["tmujer"].ToString(); }
    }

    private void cargarNivelesSecundariayMedia9(string codsedeasesor)
    {
       //9
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Sexto");
        if (dat1 != null) { txt9HomSexto.Text = dat1["thombre"].ToString(); txt9MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Séptimo");
        if (dat2 != null) { txt9HomSeptimo.Text = dat2["thombre"].ToString(); txt9MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Octavo");
        if (dat3 != null) { txt9HomOctavo.Text = dat3["thombre"].ToString(); txt9MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Noveno");
        if (dat4 != null) { txt9HomNoveno.Text = dat4["thombre"].ToString(); txt9MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Décimo");
        if (dat5 != null) { txt9HomDecimo.Text = dat5["thombre"].ToString(); txt9MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Décimo Primero");
        if (dat6 != null) { txt9HomUnDecimo.Text = dat6["thombre"].ToString(); txt9MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Décimo Segundo");
        if (dat7 != null) { txt9HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt9MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "9", "Décimo Tercero");
        if (dat8 != null) { txt9HomDecimoTercero.Text = dat8["thombre"].ToString(); txt9MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia10(string codsedeasesor)
    {
        //10
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Sexto");
        if (dat1 != null) { txt10HomSexto.Text = dat1["thombre"].ToString(); txt10MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Séptimo");
        if (dat2 != null) { txt10HomSeptimo.Text = dat2["thombre"].ToString(); txt10MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Octavo");
        if (dat3 != null) { txt10HomOctavo.Text = dat3["thombre"].ToString(); txt10MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Noveno");
        if (dat4 != null) { txt10HomNoveno.Text = dat4["thombre"].ToString(); txt10MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Décimo");
        if (dat5 != null) { txt10HomDecimo.Text = dat5["thombre"].ToString(); txt10MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Décimo Primero");
        if (dat6 != null) { txt10HomUnDecimo.Text = dat6["thombre"].ToString(); txt10MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Décimo Segundo");
        if (dat7 != null) { txt10HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt10MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "10", "Décimo Tercero");
        if (dat8 != null) { txt10HomDecimoTercero.Text = dat8["thombre"].ToString(); txt10MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }

    private void cargarNivelesSecundariayMedia11(string codsedeasesor)
    {
        //11
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Sexto");
        if (dat1 != null) { txt11HomSexto.Text = dat1["thombre"].ToString(); txt11MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Séptimo");
        if (dat2 != null) { txt11HomSeptimo.Text = dat2["thombre"].ToString(); txt11MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Octavo");
        if (dat3 != null) { txt11HomOctavo.Text = dat3["thombre"].ToString(); txt11MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Noveno");
        if (dat4 != null) { txt11HomNoveno.Text = dat4["thombre"].ToString(); txt11MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Décimo");
        if (dat5 != null) { txt11HomDecimo.Text = dat5["thombre"].ToString(); txt11MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Décimo Primero");
        if (dat6 != null) { txt11HomUnDecimo.Text = dat6["thombre"].ToString(); txt11MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Décimo Segundo");
        if (dat7 != null) { txt11HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt11MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "11", "Décimo Tercero");
        if (dat8 != null) { txt11HomDecimoTercero.Text = dat8["thombre"].ToString(); txt11MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia12(string codsedeasesor)
    {
        //12
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Sexto");
        if (dat1 != null) { txt12HomSexto.Text = dat1["thombre"].ToString(); txt12MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Séptimo");
        if (dat2 != null) { txt12HomSeptimo.Text = dat2["thombre"].ToString(); txt12MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Octavo");
        if (dat3 != null) { txt12HomOctavo.Text = dat3["thombre"].ToString(); txt12MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Noveno");
        if (dat4 != null) { txt12HomNoveno.Text = dat4["thombre"].ToString(); txt12MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Décimo");
        if (dat5 != null) { txt12HomDecimo.Text = dat5["thombre"].ToString(); txt12MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Décimo Primero");
        if (dat6 != null) { txt12HomUnDecimo.Text = dat6["thombre"].ToString(); txt12MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Décimo Segundo");
        if (dat7 != null) { txt12HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt12MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "12", "Décimo Tercero");
        if (dat8 != null) { txt12HomDecimoTercero.Text = dat8["thombre"].ToString(); txt12MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia13(string codsedeasesor)
    {
        //13
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Sexto");
        if (dat1 != null) { txt13HomSexto.Text = dat1["thombre"].ToString(); txt13MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Séptimo");
        if (dat2 != null) { txt13HomSeptimo.Text = dat2["thombre"].ToString(); txt13MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Octavo");
        if (dat3 != null) { txt13HomOctavo.Text = dat3["thombre"].ToString(); txt13MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Noveno");
        if (dat4 != null) { txt13HomNoveno.Text = dat4["thombre"].ToString(); txt13MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Décimo");
        if (dat5 != null) { txt13HomDecimo.Text = dat5["thombre"].ToString(); txt13MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Décimo Primero");
        if (dat6 != null) { txt13HomUnDecimo.Text = dat6["thombre"].ToString(); txt13MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Décimo Segundo");
        if (dat7 != null) { txt13HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt13MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "13", "Décimo Tercero");
        if (dat8 != null) { txt13HomDecimoTercero.Text = dat8["thombre"].ToString(); txt13MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia14(string codsedeasesor)
    {
        //14
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Sexto");
        if (dat1 != null) { txt14HomSexto.Text = dat1["thombre"].ToString(); txt14MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Séptimo");
        if (dat2 != null) { txt14HomSeptimo.Text = dat2["thombre"].ToString(); txt14MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Octavo");
        if (dat3 != null) { txt14HomOctavo.Text = dat3["thombre"].ToString(); txt14MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Noveno");
        if (dat4 != null) { txt14HomNoveno.Text = dat4["thombre"].ToString(); txt14MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Décimo");
        if (dat5 != null) { txt14HomDecimo.Text = dat5["thombre"].ToString(); txt14MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Décimo Primero");
        if (dat6 != null) { txt14HomUnDecimo.Text = dat6["thombre"].ToString(); txt14MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Décimo Segundo");
        if (dat7 != null) { txt14HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt14MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "14", "Décimo Tercero");
        if (dat8 != null) { txt14HomDecimoTercero.Text = dat8["thombre"].ToString(); txt14MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia15(string codsedeasesor)
    {
        //15
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Sexto");
        if (dat1 != null) { txt15HomSexto.Text = dat1["thombre"].ToString(); txt15MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Séptimo");
        if (dat2 != null) { txt15HomSeptimo.Text = dat2["thombre"].ToString(); txt15MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Octavo");
        if (dat3 != null) { txt15HomOctavo.Text = dat3["thombre"].ToString(); txt15MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Noveno");
        if (dat4 != null) { txt15HomNoveno.Text = dat4["thombre"].ToString(); txt15MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Décimo");
        if (dat5 != null) { txt15HomDecimo.Text = dat5["thombre"].ToString(); txt15MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Décimo Primero");
        if (dat6 != null) { txt15HomUnDecimo.Text = dat6["thombre"].ToString(); txt15MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Décimo Segundo");
        if (dat7 != null) { txt15HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt15MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "15", "Décimo Tercero");
        if (dat8 != null) { txt15HomDecimoTercero.Text = dat8["thombre"].ToString(); txt15MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia16(string codsedeasesor)
    {
        //16
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Sexto");
        if (dat1 != null) { txt16HomSexto.Text = dat1["thombre"].ToString(); txt16MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Séptimo");
        if (dat2 != null) { txt16HomSeptimo.Text = dat2["thombre"].ToString(); txt16MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Octavo");
        if (dat3 != null) { txt16HomOctavo.Text = dat3["thombre"].ToString(); txt16MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Noveno");
        if (dat4 != null) { txt16HomNoveno.Text = dat4["thombre"].ToString(); txt16MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Décimo");
        if (dat5 != null) { txt16HomDecimo.Text = dat5["thombre"].ToString(); txt16MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Décimo Primero");
        if (dat6 != null) { txt16HomUnDecimo.Text = dat6["thombre"].ToString(); txt16MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Décimo Segundo");
        if (dat7 != null) { txt16HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt16MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "16", "Décimo Tercero");
        if (dat8 != null) { txt16HomDecimoTercero.Text = dat8["thombre"].ToString(); txt16MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia17(string codsedeasesor)
    {
        //17
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Sexto");
        if (dat1 != null) { txt17HomSexto.Text = dat1["thombre"].ToString(); txt17MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Séptimo");
        if (dat2 != null) { txt17HomSeptimo.Text = dat2["thombre"].ToString(); txt17MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Octavo");
        if (dat3 != null) { txt17HomOctavo.Text = dat3["thombre"].ToString(); txt17MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Noveno");
        if (dat4 != null) { txt17HomNoveno.Text = dat4["thombre"].ToString(); txt17MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Décimo");
        if (dat5 != null) { txt17HomDecimo.Text = dat5["thombre"].ToString(); txt17MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Décimo Primero");
        if (dat6 != null) { txt17HomUnDecimo.Text = dat6["thombre"].ToString(); txt17MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Décimo Segundo");
        if (dat7 != null) { txt17HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt17MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "17", "Décimo Tercero");
        if (dat8 != null) { txt17HomDecimoTercero.Text = dat8["thombre"].ToString(); txt17MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia18(string codsedeasesor)
    {
        //18
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Sexto");
        if (dat1 != null) { txt18HomSexto.Text = dat1["thombre"].ToString(); txt18MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Séptimo");
        if (dat2 != null) { txt18HomSeptimo.Text = dat2["thombre"].ToString(); txt18MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Octavo");
        if (dat3 != null) { txt18HomOctavo.Text = dat3["thombre"].ToString(); txt18MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Noveno");
        if (dat4 != null) { txt18HomNoveno.Text = dat4["thombre"].ToString(); txt18MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Décimo");
        if (dat5 != null) { txt18HomDecimo.Text = dat5["thombre"].ToString(); txt18MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Décimo Primero");
        if (dat6 != null) { txt18HomUnDecimo.Text = dat6["thombre"].ToString(); txt18MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Décimo Segundo");
        if (dat7 != null) { txt18HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt18MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "18", "Décimo Tercero");
        if (dat8 != null) { txt18HomDecimoTercero.Text = dat8["thombre"].ToString(); txt18MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia19(string codsedeasesor)
    {
        //19
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Sexto");
        if (dat1 != null) { txt19HomSexto.Text = dat1["thombre"].ToString(); txt19MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Séptimo");
        if (dat2 != null) { txt19HomSeptimo.Text = dat2["thombre"].ToString(); txt19MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Octavo");
        if (dat3 != null) { txt19HomOctavo.Text = dat3["thombre"].ToString(); txt19MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Noveno");
        if (dat4 != null) { txt19HomNoveno.Text = dat4["thombre"].ToString(); txt19MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Décimo");
        if (dat5 != null) { txt19HomDecimo.Text = dat5["thombre"].ToString(); txt19MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Décimo Primero");
        if (dat6 != null) { txt19HomUnDecimo.Text = dat6["thombre"].ToString(); txt19MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Décimo Segundo");
        if (dat7 != null) { txt19HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt19MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "19", "Décimo Tercero");
        if (dat8 != null) { txt19HomDecimoTercero.Text = dat8["thombre"].ToString(); txt19MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMedia20(string codsedeasesor)
    {
        //20
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Sexto");
        if (dat1 != null) { txt20HomSexto.Text = dat1["thombre"].ToString(); txt20MujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Séptimo");
        if (dat2 != null) { txt20HomSeptimo.Text = dat2["thombre"].ToString(); txt20MujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Octavo");
        if (dat3 != null) { txt20HomOctavo.Text = dat3["thombre"].ToString(); txt20MujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Noveno");
        if (dat4 != null) { txt20HomNoveno.Text = dat4["thombre"].ToString(); txt20MujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Décimo");
        if (dat5 != null) { txt20HomDecimo.Text = dat5["thombre"].ToString(); txt20MujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Décimo Primero");
        if (dat6 != null) { txt20HomUnDecimo.Text = dat6["thombre"].ToString(); txt20MujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Décimo Segundo");
        if (dat7 != null) { txt20HomDecimoSegundo.Text = dat7["thombre"].ToString(); txt20MujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "20", "Décimo Tercero");
        if (dat8 != null) { txt20HomDecimoTercero.Text = dat8["thombre"].ToString(); txt20MujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMediaRepitentes(string codsedeasesor)
    {
        //Repitentes
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Sexto");
        if (dat1 != null) { txtRepitentesHomSexto.Text = dat1["thombre"].ToString(); txtRepitentesMujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Séptimo");
        if (dat2 != null) { txtRepitentesHomSeptimo.Text = dat2["thombre"].ToString(); txtRepitentesMujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Octavo");
        if (dat3 != null) { txtRepitentesHomOctavo.Text = dat3["thombre"].ToString(); txtRepitentesMujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Noveno");
        if (dat4 != null) { txtRepitentesHomNoveno.Text = dat4["thombre"].ToString(); txtRepitentesMujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo");
        if (dat5 != null) { txtRepitentesHomDecimo.Text = dat5["thombre"].ToString(); txtRepitentesMujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo Primero");
        if (dat6 != null) { txtRepitentesHomUnDecimo.Text = dat6["thombre"].ToString(); txtRepitentesMujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo Segundo");
        if (dat7 != null) { txtRepitentesHomDecimoSegundo.Text = dat7["thombre"].ToString(); txtRepitentesMujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. Repitentes o re iniciantes", "Décimo Tercero");
        if (dat8 != null) { txtRepitentesHomDecimoTercero.Text = dat8["thombre"].ToString(); txtRepitentesMujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }
    private void cargarNivelesSecundariayMediaGruposPorGrados(string codsedeasesor)
    {
        //GruposPorGrados
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Sexto");
        if (dat1 != null) { txtGruposPorGradosHomSexto.Text = dat1["thombre"].ToString(); txtGruposPorGradosMujSexto.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Séptimo");
        if (dat2 != null) { txtGruposPorGradosHomSeptimo.Text = dat2["thombre"].ToString(); txtGruposPorGradosMujSeptimo.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Octavo");
        if (dat3 != null) { txtGruposPorGradosHomOctavo.Text = dat3["thombre"].ToString(); txtGruposPorGradosMujOctavo.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Noveno");
        if (dat4 != null) { txtGruposPorGradosHomNoveno.Text = dat4["thombre"].ToString(); txtGruposPorGradosMujNoveno.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo");
        if (dat5 != null) { txtGruposPorGradosHomDecimo.Text = dat5["thombre"].ToString(); txtGruposPorGradosMujDecimo.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo Primero");
        if (dat6 != null) { txtGruposPorGradosHomUnDecimo.Text = dat6["thombre"].ToString(); txtGruposPorGradosMujUnDecimo.Text = dat6["tmujer"].ToString(); }

        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo Segundo");
        if (dat7 != null) { txtGruposPorGradosHomDecimoSegundo.Text = dat7["thombre"].ToString(); txtGruposPorGradosMujUnDecimoSegundo.Text = dat7["tmujer"].ToString(); }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "13", "C600B", "Núm. De grupos por grado*", "Décimo Tercero");
        if (dat8 != null) { txtGruposPorGradosHomDecimoTercero.Text = dat8["thombre"].ToString(); txtGruposPorGradosMujDecimoTercero.Text = dat8["tmujer"].ToString(); }
    }

    private void cargarEducacionMediaAcademica(string codsedeasesor)
    {
       
        //Académica
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Académica", "Décimo");
        if (dat1 != null) { txt10HomAcademica.Text = dat1["thombre"].ToString(); txt10MujAcademica.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Académica", "Décimo Primero");
        if (dat2 != null) { txt11HomAcademica.Text = dat2["thombre"].ToString(); txt11MujAcademica.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Académica", "Décimo Segundo");
        if (dat3 != null) { txt12HomAcademica.Text = dat3["thombre"].ToString(); txt12MujAcademica.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Académica", "Décimo Tercero");
        if (dat4 != null) { txt13HomAcademica.Text = dat4["thombre"].ToString(); txt13MujAcademica.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Académica", "Repitentes");
        if (dat5 != null) { txtRepitentesHomAcademica.Text = dat5["thombre"].ToString(); txtRepitentesMujAcademica.Text = dat5["tmujer"].ToString(); }

       
    }
    private void cargarEducacionMediaAgropecuaria(string codsedeasesor)
    {

        //Agropecuaria
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo");
        if (dat1 != null) { txt10HomAgropecuaria.Text = dat1["thombre"].ToString(); txt10MujAgropecuaria.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo Primero");
        if (dat2 != null) { txt11HomAgropecuaria.Text = dat2["thombre"].ToString(); txt11MujAgropecuaria.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo Segundo");
        if (dat3 != null) { txt12HomAgropecuaria.Text = dat3["thombre"].ToString(); txt12MujAgropecuaria.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Agropecuaria", "Décimo Tercero");
        if (dat4 != null) { txt13HomAgropecuaria.Text = dat4["thombre"].ToString(); txt13MujAgropecuaria.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Agropecuaria", "Repitentes");
        if (dat5 != null) { txtRepitentesHomAgropecuaria.Text = dat5["thombre"].ToString(); txtRepitentesMujAgropecuaria.Text = dat5["tmujer"].ToString(); }


    }

    private void cargarEducacionMediaComercial(string codsedeasesor)
    {
        //Comercial
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo");
        if (dat1 != null) { txt10HomComercial.Text = dat1["thombre"].ToString(); txt10MujComercial.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo Primero");
        if (dat2 != null) { txt11HomComercial.Text = dat2["thombre"].ToString(); txt11MujComercial.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo Segundo");
        if (dat3 != null) { txt12HomComercial.Text = dat3["thombre"].ToString(); txt12MujComercial.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Décimo Tercero");
        if (dat4 != null) { txt13HomComercial.Text = dat4["thombre"].ToString(); txt13MujComercial.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Comercial y Servicios", "Repitentes");
        if (dat5 != null) { txtRepitentesHomComercial.Text = dat5["thombre"].ToString(); txtRepitentesMujComercial.Text = dat5["tmujer"].ToString(); }

    }
    private void cargarEducacionMediaIndustrial(string codsedeasesor)
    {
        //Industrial
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Industrial", "Décimo");
        if (dat1 != null) { txt10HomIndustrial.Text = dat1["thombre"].ToString(); txt10MujIndustrial.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Industrial", "Décimo Primero");
        if (dat2 != null) { txt11HomIndustrial.Text = dat2["thombre"].ToString(); txt11MujIndustrial.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Industrial", "Décimo Segundo");
        if (dat3 != null) { txt12HomIndustrial.Text = dat3["thombre"].ToString(); txt12MujIndustrial.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Industrial", "Décimo Tercero");
        if (dat4 != null) { txt13HomIndustrial.Text = dat4["thombre"].ToString(); txt13MujIndustrial.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Industrial", "Repitentes");
        if (dat5 != null) { txtRepitentesHomIndustrial.Text = dat5["thombre"].ToString(); txtRepitentesMujIndustrial.Text = dat5["tmujer"].ToString(); }

    }
    private void cargarEducacionMediaPedagogica(string codsedeasesor)
    {
        //Pedagógica
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo");
        if (dat1 != null) { txt10HomPedagogica.Text = dat1["thombre"].ToString(); txt10MujPedagogica.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo Primero");
        if (dat2 != null) { txt11HomPedagogica.Text = dat2["thombre"].ToString(); txt11MujPedagogica.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo Segundo");
        if (dat3 != null) { txt12HomPedagogica.Text = dat3["thombre"].ToString(); txt12MujPedagogica.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Pedagógica", "Décimo Tercero");
        if (dat4 != null) { txt13HomPedagogica.Text = dat4["thombre"].ToString(); txt13MujPedagogica.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Pedagógica", "Repitentes");
        if (dat5 != null) { txtRepitentesHomPedagogica.Text = dat5["thombre"].ToString(); txtRepitentesMujPedagogica.Text = dat5["tmujer"].ToString(); }

    }
    private void cargarEducacionMediaPromocion(string codsedeasesor)
    {
        //Promocion
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo");
        if (dat1 != null) { txt10HomPromocion.Text = dat1["thombre"].ToString(); txt10MujPromocion.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo Primero");
        if (dat2 != null) { txt11HomPromocion.Text = dat2["thombre"].ToString(); txt11MujPromocion.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo Segundo");
        if (dat3 != null) { txt12HomPromocion.Text = dat3["thombre"].ToString(); txt12MujPromocion.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Promoción Social", "Décimo Tercero");
        if (dat4 != null) { txt13HomPromocion.Text = dat4["thombre"].ToString(); txt13MujPromocion.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Promoción Social", "Repitentes");
        if (dat5 != null) { txtRepitentesHomPromocion.Text = dat5["thombre"].ToString(); txtRepitentesMujPromocion.Text = dat5["tmujer"].ToString(); }

    }

    private void cargarEducacionMediaOtra(string codsedeasesor)
    {
        //Otra
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Otra", "Décimo");
        if (dat1 != null) { txt10HomOtra.Text = dat1["thombre"].ToString(); txt10MujOtra.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Otra", "Décimo Primero");
        if (dat2 != null) { txt11HomOtra.Text = dat2["thombre"].ToString(); txt11MujOtra.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Otra", "Décimo Segundo");
        if (dat3 != null) { txt12HomOtra.Text = dat3["thombre"].ToString(); txt12MujOtra.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Otra", "Décimo Tercero");
        if (dat4 != null) { txt13HomOtra.Text = dat4["thombre"].ToString(); txt13MujOtra.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "14", "C600B", "Otra", "Repitentes");
        if (dat5 != null) { txtRepitentesHomOtra.Text = dat5["thombre"].ToString(); txtRepitentesMujOtra.Text = dat5["tmujer"].ToString(); }

    }

    private void cargarEducacionExtraedad(string codsedeasesor)
    {
      
        //Básica primaria Ciclo I
        int val = 0;
        DataRow dat37 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Aprobados");
        if (dat37 != null) { txtHomCicloIAprobado.Text = dat37["thombre"].ToString(); txtMujCicloIAprobado.Text = dat37["tmujer"].ToString(); val++; }

        DataRow dat38 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Reprobados");
        if (dat38 != null) { txtHomCicloIReprobado.Text = dat38["thombre"].ToString(); txtMujCicloIReprobado.Text = dat38["tmujer"].ToString(); val++; }

        DataRow dat39 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Desertores*");
        if (dat39 != null) { txtHomCicloIDesertores.Text = dat39["thombre"].ToString(); txtMujCicloIDesertores.Text = dat39["tmujer"].ToString(); val++; }

        DataRow dat40 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo I", "Transferidos/Trasladados*");
        if (dat40 != null) { txtHomCicloITranferidos.Text = dat40["thombre"].ToString(); txtMujCicloITranferidos.Text = dat40["tmujer"].ToString(); val++; }

        //Básica primaria Ciclo II	
        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Aprobados");
        if (dat3 != null) { txtHomCicloIIAprobado.Text = dat3["thombre"].ToString(); txtMujCicloIIAprobado.Text = dat3["tmujer"].ToString(); val++; }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Reprobados");
        if (dat4 != null) { txtHomCicloIIReprobado.Text = dat4["thombre"].ToString(); txtMujCicloIIReprobado.Text = dat4["tmujer"].ToString(); val++; }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Desertores*");
        if (dat5 != null) { txtHomCicloIIDesertores.Text = dat5["thombre"].ToString(); txtMujCicloIIDesertores.Text = dat5["tmujer"].ToString(); val++; }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica primaria Ciclo II", "Transferidos/Trasladados*");
        if (dat6 != null) { txtHomCicloIITranferidos.Text = dat6["thombre"].ToString(); txtMujCicloIITranferidos.Text = dat6["tmujer"].ToString(); val++; }

        //Básica secundaria Ciclo III	
        DataRow dat7 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Aprobados");
        if (dat7 != null) { txtHomCicloIIIAprobado.Text = dat7["thombre"].ToString(); txtMujCicloIIIAprobado.Text = dat7["tmujer"].ToString(); val++; }

        DataRow dat8 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Reprobados");
        if (dat8 != null) { txtHomCicloIIIReprobado.Text = dat8["thombre"].ToString(); txtMujCicloIIIReprobado.Text = dat8["tmujer"].ToString(); val++; }

        DataRow dat9 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Desertores*");
        if (dat9 != null) { txtHomCicloIIIDesertores.Text = dat9["thombre"].ToString(); txtMujCicloIIIDesertores.Text = dat9["tmujer"].ToString(); val++; }

        DataRow dat10 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo III", "Transferidos/Trasladados*");
        if (dat10 != null) { txtHomCicloIIITranferidos.Text = dat10["thombre"].ToString(); txtMujCicloIIITranferidos.Text = dat10["tmujer"].ToString(); val++; }

        //Básica secundaria Ciclo IV	
        DataRow dat11 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Aprobados");
        if (dat11 != null) { txtHomCicloIVAprobado.Text = dat11["thombre"].ToString(); txtMujCicloIVAprobado.Text = dat11["tmujer"].ToString(); val++; }

        DataRow dat12 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Reprobados");
        if (dat12 != null) { txtHomCicloIVReprobado.Text = dat12["thombre"].ToString(); txtMujCicloIVReprobado.Text = dat12["tmujer"].ToString(); val++; }

        DataRow dat13 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Desertores*");
        if (dat13 != null) { txtHomCicloIVDesertores.Text = dat13["thombre"].ToString(); txtMujCicloIVDesertores.Text = dat13["tmujer"].ToString(); val++; }

        DataRow dat14 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Básica secundaria Ciclo IV", "Transferidos/Trasladados*");
        if (dat14 != null) { txtHomCicloIVTranferidos.Text = dat14["thombre"].ToString(); txtMujCicloIVTranferidos.Text = dat14["tmujer"].ToString(); val++; }

        //Básica secundaria Ciclo V	
        DataRow dat111 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo V", "Aprobados");
        if (dat111 != null) { txtHomCicloVAprobado.Text = dat111["thombre"].ToString(); txtMujCicloVAprobado.Text = dat111["tmujer"].ToString(); val++; }

        DataRow dat121 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo V", "Reprobados");
        if (dat121 != null) { txtHomCicloVReprobado.Text = dat121["thombre"].ToString(); txtMujCicloVReprobado.Text = dat121["tmujer"].ToString(); val++; }

        DataRow dat131 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo V", "Desertores*");
        if (dat131 != null) { txtHomCicloVDesertores.Text = dat131["thombre"].ToString(); txtMujCicloVDesertores.Text = dat131["tmujer"].ToString(); val++; }

        DataRow dat141 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo V", "Transferidos/Trasladados*");
        if (dat141 != null) { txtHomCicloVTranferidos.Text = dat141["thombre"].ToString(); txtMujCicloVTranferidos.Text = dat141["tmujer"].ToString(); val++; }

        //Básica secundaria Ciclo VI	
        DataRow dat1112 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Aprobados");
        if (dat1112 != null) { txtHomCicloVIAprobado.Text = dat1112["thombre"].ToString(); txtMujCicloVIAprobado.Text = dat1112["tmujer"].ToString(); val++; }

        DataRow dat1212 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Reprobados");
        if (dat1212 != null) { txtHomCicloVIReprobado.Text = dat1212["thombre"].ToString(); txtMujCicloVIReprobado.Text = dat1212["tmujer"].ToString(); val++; }

        DataRow dat1312 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Desertores*");
        if (dat1312 != null) { txtHomCicloVIDesertores.Text = dat1312["thombre"].ToString(); txtMujCicloVIDesertores.Text = dat1312["tmujer"].ToString(); val++; }

        DataRow dat1412 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "15", "C600B", "Media Ciclo VI", "Transferidos/Trasladados*");
        if (dat1412 != null) { txtHomCicloVITranferidos.Text = dat1412["thombre"].ToString(); txtMujCicloVITranferidos.Text = dat1412["tmujer"].ToString(); val++; }

        if (val > 0)
        {
            rtbEducacionFormalExtraedad.SelectedIndex = 0;
            PanelEducacionFormalExtraedad.Visible = true;
        }

    }

    private void cargarGeneroEdadCiclo13(string codsedeasesor)
    {
        //13
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "13", "Ciclo I");
        if (dat1 != null) { txt13HomCicloI.Text = dat1["thombre"].ToString(); txt13MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "13", "Ciclo II");
        if (dat2 != null) { txt13HomCicloII.Text = dat2["thombre"].ToString(); txt13MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "13", "Ciclo III");
        if (dat3 != null) { txt13HomCicloIII.Text = dat3["thombre"].ToString(); txt13MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "13", "Ciclo IV");
        if (dat4 != null) { txt13HomCicloIV.Text = dat4["thombre"].ToString(); txt13MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "13", "Ciclo V");
        if (dat5 != null) { txt13HomCicloV.Text = dat5["thombre"].ToString(); txt13MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "13", "Ciclo VI");
        if (dat6 != null) { txt13HomCicloVI.Text = dat6["thombre"].ToString(); txt13MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }

    private void cargarGeneroEdadCiclo14(string codsedeasesor)
    {
        //14
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "14", "Ciclo I");
        if (dat1 != null) { txt14HomCicloI.Text = dat1["thombre"].ToString(); txt14MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "14", "Ciclo II");
        if (dat2 != null) { txt14HomCicloII.Text = dat2["thombre"].ToString(); txt14MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "14", "Ciclo III");
        if (dat3 != null) { txt14HomCicloIII.Text = dat3["thombre"].ToString(); txt14MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "14", "Ciclo IV");
        if (dat4 != null) { txt14HomCicloIV.Text = dat4["thombre"].ToString(); txt14MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "14", "Ciclo V");
        if (dat5 != null) { txt14HomCicloV.Text = dat5["thombre"].ToString(); txt14MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "14", "Ciclo VI");
        if (dat6 != null) { txt14HomCicloVI.Text = dat6["thombre"].ToString(); txt14MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo15(string codsedeasesor)
    {
        //15
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "15", "Ciclo I");
        if (dat1 != null) { txt15HomCicloI.Text = dat1["thombre"].ToString(); txt15MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "15", "Ciclo II");
        if (dat2 != null) { txt15HomCicloII.Text = dat2["thombre"].ToString(); txt15MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "15", "Ciclo III");
        if (dat3 != null) { txt15HomCicloIII.Text = dat3["thombre"].ToString(); txt15MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "15", "Ciclo IV");
        if (dat4 != null) { txt15HomCicloIV.Text = dat4["thombre"].ToString(); txt15MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "15", "Ciclo V");
        if (dat5 != null) { txt15HomCicloV.Text = dat5["thombre"].ToString(); txt15MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "15", "Ciclo VI");
        if (dat6 != null) { txt15HomCicloVI.Text = dat6["thombre"].ToString(); txt15MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo16(string codsedeasesor)
    {
        //16
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "16", "Ciclo I");
        if (dat1 != null) { txt16HomCicloI.Text = dat1["thombre"].ToString(); txt16MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "16", "Ciclo II");
        if (dat2 != null) { txt16HomCicloII.Text = dat2["thombre"].ToString(); txt16MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "16", "Ciclo III");
        if (dat3 != null) { txt16HomCicloIII.Text = dat3["thombre"].ToString(); txt16MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "16", "Ciclo IV");
        if (dat4 != null) { txt16HomCicloIV.Text = dat4["thombre"].ToString(); txt16MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "16", "Ciclo V");
        if (dat5 != null) { txt16HomCicloV.Text = dat5["thombre"].ToString(); txt16MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "16", "Ciclo VI");
        if (dat6 != null) { txt16HomCicloVI.Text = dat6["thombre"].ToString(); txt16MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo17(string codsedeasesor)
    {
        //17
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "17", "Ciclo I");
        if (dat1 != null) { txt17HomCicloI.Text = dat1["thombre"].ToString(); txt17MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "17", "Ciclo II");
        if (dat2 != null) { txt17HomCicloII.Text = dat2["thombre"].ToString(); txt17MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "17", "Ciclo III");
        if (dat3 != null) { txt17HomCicloIII.Text = dat3["thombre"].ToString(); txt17MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "17", "Ciclo IV");
        if (dat4 != null) { txt17HomCicloIV.Text = dat4["thombre"].ToString(); txt17MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "17", "Ciclo V");
        if (dat5 != null) { txt17HomCicloV.Text = dat5["thombre"].ToString(); txt17MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "17", "Ciclo VI");
        if (dat6 != null) { txt17HomCicloVI.Text = dat6["thombre"].ToString(); txt17MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }

    private void cargarGeneroEdadCiclo18(string codsedeasesor)
    {
        //18
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "18", "Ciclo I");
        if (dat1 != null) { txt18HomCicloI.Text = dat1["thombre"].ToString(); txt18MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "18", "Ciclo II");
        if (dat2 != null) { txt18HomCicloII.Text = dat2["thombre"].ToString(); txt18MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "18", "Ciclo III");
        if (dat3 != null) { txt18HomCicloIII.Text = dat3["thombre"].ToString(); txt18MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "18", "Ciclo IV");
        if (dat4 != null) { txt18HomCicloIV.Text = dat4["thombre"].ToString(); txt18MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "18", "Ciclo V");
        if (dat5 != null) { txt18HomCicloV.Text = dat5["thombre"].ToString(); txt18MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "18", "Ciclo VI");
        if (dat6 != null) { txt18HomCicloVI.Text = dat6["thombre"].ToString(); txt18MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo19(string codsedeasesor)
    {
        //19
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "19", "Ciclo I");
        if (dat1 != null) { txt19HomCicloI.Text = dat1["thombre"].ToString(); txt19MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "19", "Ciclo II");
        if (dat2 != null) { txt19HomCicloII.Text = dat2["thombre"].ToString(); txt19MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "19", "Ciclo III");
        if (dat3 != null) { txt19HomCicloIII.Text = dat3["thombre"].ToString(); txt19MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "19", "Ciclo IV");
        if (dat4 != null) { txt19HomCicloIV.Text = dat4["thombre"].ToString(); txt19MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "19", "Ciclo V");
        if (dat5 != null) { txt19HomCicloV.Text = dat5["thombre"].ToString(); txt19MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "19", "Ciclo VI");
        if (dat6 != null) { txt19HomCicloVI.Text = dat6["thombre"].ToString(); txt19MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo20(string codsedeasesor)
    {
        //20
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "20", "Ciclo I");
        if (dat1 != null) { txt20HomCicloI.Text = dat1["thombre"].ToString(); txt20MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "20", "Ciclo II");
        if (dat2 != null) { txt20HomCicloII.Text = dat2["thombre"].ToString(); txt20MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "20", "Ciclo III");
        if (dat3 != null) { txt20HomCicloIII.Text = dat3["thombre"].ToString(); txt20MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "20", "Ciclo IV");
        if (dat4 != null) { txt20HomCicloIV.Text = dat4["thombre"].ToString(); txt20MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "20", "Ciclo V");
        if (dat5 != null) { txt20HomCicloV.Text = dat5["thombre"].ToString(); txt20MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "20", "Ciclo VI");
        if (dat6 != null) { txt20HomCicloVI.Text = dat6["thombre"].ToString(); txt20MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo21(string codsedeasesor)
    {
        //21
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "21", "Ciclo I");
        if (dat1 != null) { txt21HomCicloI.Text = dat1["thombre"].ToString(); txt21MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "21", "Ciclo II");
        if (dat2 != null) { txt21HomCicloII.Text = dat2["thombre"].ToString(); txt21MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "21", "Ciclo III");
        if (dat3 != null) { txt21HomCicloIII.Text = dat3["thombre"].ToString(); txt21MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "21", "Ciclo IV");
        if (dat4 != null) { txt21HomCicloIV.Text = dat4["thombre"].ToString(); txt21MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "21", "Ciclo V");
        if (dat5 != null) { txt21HomCicloV.Text = dat5["thombre"].ToString(); txt21MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "21", "Ciclo VI");
        if (dat6 != null) { txt21HomCicloVI.Text = dat6["thombre"].ToString(); txt21MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo22(string codsedeasesor)
    {
        //22
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "22", "Ciclo I");
        if (dat1 != null) { txt22HomCicloI.Text = dat1["thombre"].ToString(); txt22MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "22", "Ciclo II");
        if (dat2 != null) { txt22HomCicloII.Text = dat2["thombre"].ToString(); txt22MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "22", "Ciclo III");
        if (dat3 != null) { txt22HomCicloIII.Text = dat3["thombre"].ToString(); txt22MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "22", "Ciclo IV");
        if (dat4 != null) { txt22HomCicloIV.Text = dat4["thombre"].ToString(); txt22MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "22", "Ciclo V");
        if (dat5 != null) { txt22HomCicloV.Text = dat5["thombre"].ToString(); txt22MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "22", "Ciclo VI");
        if (dat6 != null) { txt22HomCicloVI.Text = dat6["thombre"].ToString(); txt22MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo23(string codsedeasesor)
    {
        //23
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "23", "Ciclo I");
        if (dat1 != null) { txt23HomCicloI.Text = dat1["thombre"].ToString(); txt23MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "23", "Ciclo II");
        if (dat2 != null) { txt23HomCicloII.Text = dat2["thombre"].ToString(); txt23MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "23", "Ciclo III");
        if (dat3 != null) { txt23HomCicloIII.Text = dat3["thombre"].ToString(); txt23MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "23", "Ciclo IV");
        if (dat4 != null) { txt23HomCicloIV.Text = dat4["thombre"].ToString(); txt23MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "23", "Ciclo V");
        if (dat5 != null) { txt23HomCicloV.Text = dat5["thombre"].ToString(); txt23MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "23", "Ciclo VI");
        if (dat6 != null) { txt23HomCicloVI.Text = dat6["thombre"].ToString(); txt23MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    
    private void cargarGeneroEdadCiclo24(string codsedeasesor)
    {
        //24
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "24", "Ciclo I");
        if (dat1 != null) { txt24HomCicloI.Text = dat1["thombre"].ToString(); txt24MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "24", "Ciclo II");
        if (dat2 != null) { txt24HomCicloII.Text = dat2["thombre"].ToString(); txt24MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "24", "Ciclo III");
        if (dat3 != null) { txt24HomCicloIII.Text = dat3["thombre"].ToString(); txt24MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "24", "Ciclo IV");
        if (dat4 != null) { txt24HomCicloIV.Text = dat4["thombre"].ToString(); txt24MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "24", "Ciclo V");
        if (dat5 != null) { txt24HomCicloV.Text = dat5["thombre"].ToString(); txt24MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "24", "Ciclo VI");
        if (dat6 != null) { txt24HomCicloVI.Text = dat6["thombre"].ToString(); txt24MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo25(string codsedeasesor)
    {
        //25
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "25", "Ciclo I");
        if (dat1 != null) { txt25HomCicloI.Text = dat1["thombre"].ToString(); txt25MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "25", "Ciclo II");
        if (dat2 != null) { txt25HomCicloII.Text = dat2["thombre"].ToString(); txt25MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "25", "Ciclo III");
        if (dat3 != null) { txt25HomCicloIII.Text = dat3["thombre"].ToString(); txt25MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "25", "Ciclo IV");
        if (dat4 != null) { txt25HomCicloIV.Text = dat4["thombre"].ToString(); txt25MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "25", "Ciclo V");
        if (dat5 != null) { txt25HomCicloV.Text = dat5["thombre"].ToString(); txt25MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "25", "Ciclo VI");
        if (dat6 != null) { txt25HomCicloVI.Text = dat6["thombre"].ToString(); txt25MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo26(string codsedeasesor)
    {
        //26
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "26", "Ciclo I");
        if (dat1 != null) { txt26HomCicloI.Text = dat1["thombre"].ToString(); txt26MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "26", "Ciclo II");
        if (dat2 != null) { txt26HomCicloII.Text = dat2["thombre"].ToString(); txt26MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "26", "Ciclo III");
        if (dat3 != null) { txt26HomCicloIII.Text = dat3["thombre"].ToString(); txt26MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "26", "Ciclo IV");
        if (dat4 != null) { txt26HomCicloIV.Text = dat4["thombre"].ToString(); txt26MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "26", "Ciclo V");
        if (dat5 != null) { txt26HomCicloV.Text = dat5["thombre"].ToString(); txt26MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "26", "Ciclo VI");
        if (dat6 != null) { txt26HomCicloVI.Text = dat6["thombre"].ToString(); txt26MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo27(string codsedeasesor)
    {
        //27
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "27", "Ciclo I");
        if (dat1 != null) { txt27HomCicloI.Text = dat1["thombre"].ToString(); txt27MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "27", "Ciclo II");
        if (dat2 != null) { txt27HomCicloII.Text = dat2["thombre"].ToString(); txt27MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "27", "Ciclo III");
        if (dat3 != null) { txt27HomCicloIII.Text = dat3["thombre"].ToString(); txt27MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "27", "Ciclo IV");
        if (dat4 != null) { txt27HomCicloIV.Text = dat4["thombre"].ToString(); txt27MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "27", "Ciclo V");
        if (dat5 != null) { txt27HomCicloV.Text = dat5["thombre"].ToString(); txt27MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "27", "Ciclo VI");
        if (dat6 != null) { txt27HomCicloVI.Text = dat6["thombre"].ToString(); txt27MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo28(string codsedeasesor)
    {
        //28
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "28", "Ciclo I");
        if (dat1 != null) { txt28HomCicloI.Text = dat1["thombre"].ToString(); txt28MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "28", "Ciclo II");
        if (dat2 != null) { txt28HomCicloII.Text = dat2["thombre"].ToString(); txt28MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "28", "Ciclo III");
        if (dat3 != null) { txt28HomCicloIII.Text = dat3["thombre"].ToString(); txt28MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "28", "Ciclo IV");
        if (dat4 != null) { txt28HomCicloIV.Text = dat4["thombre"].ToString(); txt28MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "28", "Ciclo V");
        if (dat5 != null) { txt28HomCicloV.Text = dat5["thombre"].ToString(); txt28MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "28", "Ciclo VI");
        if (dat6 != null) { txt28HomCicloVI.Text = dat6["thombre"].ToString(); txt28MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo29(string codsedeasesor)
    {
        //29
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "29", "Ciclo I");
        if (dat1 != null) { txt29HomCicloI.Text = dat1["thombre"].ToString(); txt29MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "29", "Ciclo II");
        if (dat2 != null) { txt29HomCicloII.Text = dat2["thombre"].ToString(); txt29MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "29", "Ciclo III");
        if (dat3 != null) { txt29HomCicloIII.Text = dat3["thombre"].ToString(); txt29MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "29", "Ciclo IV");
        if (dat4 != null) { txt29HomCicloIV.Text = dat4["thombre"].ToString(); txt29MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "29", "Ciclo V");
        if (dat5 != null) { txt29HomCicloV.Text = dat5["thombre"].ToString(); txt29MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "29", "Ciclo VI");
        if (dat6 != null) { txt29HomCicloVI.Text = dat6["thombre"].ToString(); txt29MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo30(string codsedeasesor)
    {
        //30
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "30", "Ciclo I");
        if (dat1 != null) { txt30HomCicloI.Text = dat1["thombre"].ToString(); txt30MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "30", "Ciclo II");
        if (dat2 != null) { txt30HomCicloII.Text = dat2["thombre"].ToString(); txt30MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "30", "Ciclo III");
        if (dat3 != null) { txt30HomCicloIII.Text = dat3["thombre"].ToString(); txt30MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "30", "Ciclo IV");
        if (dat4 != null) { txt30HomCicloIV.Text = dat4["thombre"].ToString(); txt30MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "30", "Ciclo V");
        if (dat5 != null) { txt30HomCicloV.Text = dat5["thombre"].ToString(); txt30MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "30", "Ciclo VI");
        if (dat6 != null) { txt30HomCicloVI.Text = dat6["thombre"].ToString(); txt30MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo31(string codsedeasesor)
    {
        //31
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "31", "Ciclo I");
        if (dat1 != null) { txt31HomCicloI.Text = dat1["thombre"].ToString(); txt31MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "31", "Ciclo II");
        if (dat2 != null) { txt31HomCicloII.Text = dat2["thombre"].ToString(); txt31MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "31", "Ciclo III");
        if (dat3 != null) { txt31HomCicloIII.Text = dat3["thombre"].ToString(); txt31MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "31", "Ciclo IV");
        if (dat4 != null) { txt31HomCicloIV.Text = dat4["thombre"].ToString(); txt31MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "31", "Ciclo V");
        if (dat5 != null) { txt31HomCicloV.Text = dat5["thombre"].ToString(); txt31MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "31", "Ciclo VI");
        if (dat6 != null) { txt31HomCicloVI.Text = dat6["thombre"].ToString(); txt31MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo32(string codsedeasesor)
    {
        //32
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "32", "Ciclo I");
        if (dat1 != null) { txt32HomCicloI.Text = dat1["thombre"].ToString(); txt32MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "32", "Ciclo II");
        if (dat2 != null) { txt32HomCicloII.Text = dat2["thombre"].ToString(); txt32MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "32", "Ciclo III");
        if (dat3 != null) { txt32HomCicloIII.Text = dat3["thombre"].ToString(); txt32MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "32", "Ciclo IV");
        if (dat4 != null) { txt32HomCicloIV.Text = dat4["thombre"].ToString(); txt32MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "32", "Ciclo V");
        if (dat5 != null) { txt32HomCicloV.Text = dat5["thombre"].ToString(); txt32MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "32", "Ciclo VI");
        if (dat6 != null) { txt32HomCicloVI.Text = dat6["thombre"].ToString(); txt32MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo33(string codsedeasesor)
    {
        //33
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "33", "Ciclo I");
        if (dat1 != null) { txt33HomCicloI.Text = dat1["thombre"].ToString(); txt33MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "33", "Ciclo II");
        if (dat2 != null) { txt33HomCicloII.Text = dat2["thombre"].ToString(); txt33MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "33", "Ciclo III");
        if (dat3 != null) { txt33HomCicloIII.Text = dat3["thombre"].ToString(); txt33MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "33", "Ciclo IV");
        if (dat4 != null) { txt33HomCicloIV.Text = dat4["thombre"].ToString(); txt33MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "33", "Ciclo V");
        if (dat5 != null) { txt33HomCicloV.Text = dat5["thombre"].ToString(); txt33MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "33", "Ciclo VI");
        if (dat6 != null) { txt33HomCicloVI.Text = dat6["thombre"].ToString(); txt33MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo34(string codsedeasesor)
    {
        //34
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "34", "Ciclo I");
        if (dat1 != null) { txt34HomCicloI.Text = dat1["thombre"].ToString(); txt34MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "34", "Ciclo II");
        if (dat2 != null) { txt34HomCicloII.Text = dat2["thombre"].ToString(); txt34MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "34", "Ciclo III");
        if (dat3 != null) { txt34HomCicloIII.Text = dat3["thombre"].ToString(); txt34MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "34", "Ciclo IV");
        if (dat4 != null) { txt34HomCicloIV.Text = dat4["thombre"].ToString(); txt34MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "34", "Ciclo V");
        if (dat5 != null) { txt34HomCicloV.Text = dat5["thombre"].ToString(); txt34MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "34", "Ciclo VI");
        if (dat6 != null) { txt34HomCicloVI.Text = dat6["thombre"].ToString(); txt34MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo35(string codsedeasesor)
    {
        //35
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "35", "Ciclo I");
        if (dat1 != null) { txt35HomCicloI.Text = dat1["thombre"].ToString(); txt35MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "35", "Ciclo II");
        if (dat2 != null) { txt35HomCicloII.Text = dat2["thombre"].ToString(); txt35MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "35", "Ciclo III");
        if (dat3 != null) { txt35HomCicloIII.Text = dat3["thombre"].ToString(); txt35MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "35", "Ciclo IV");
        if (dat4 != null) { txt35HomCicloIV.Text = dat4["thombre"].ToString(); txt35MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "35", "Ciclo V");
        if (dat5 != null) { txt35HomCicloV.Text = dat5["thombre"].ToString(); txt35MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "35", "Ciclo VI");
        if (dat6 != null) { txt35HomCicloVI.Text = dat6["thombre"].ToString(); txt35MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCiclo36(string codsedeasesor)
    {
        //36
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "36", "Ciclo I");
        if (dat1 != null) { txt36HomCicloI.Text = dat1["thombre"].ToString(); txt36MujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "36", "Ciclo II");
        if (dat2 != null) { txt36HomCicloII.Text = dat2["thombre"].ToString(); txt36MujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "36", "Ciclo III");
        if (dat3 != null) { txt36HomCicloIII.Text = dat3["thombre"].ToString(); txt36MujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "36", "Ciclo IV");
        if (dat4 != null) { txt36HomCicloIV.Text = dat4["thombre"].ToString(); txt36MujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "36", "Ciclo V");
        if (dat5 != null) { txt36HomCicloV.Text = dat5["thombre"].ToString(); txt36MujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "36", "Ciclo VI");
        if (dat6 != null) { txt36HomCicloVI.Text = dat6["thombre"].ToString(); txt36MujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCicloRepitentes(string codsedeasesor)
    {
        //Repitentes
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo I");
        if (dat1 != null) { txtRepitentesHomCicloI.Text = dat1["thombre"].ToString(); txtRepitentesMujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo II");
        if (dat2 != null) { txtRepitentesHomCicloII.Text = dat2["thombre"].ToString(); txtRepitentesMujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo III");
        if (dat3 != null) { txtRepitentesHomCicloIII.Text = dat3["thombre"].ToString(); txtRepitentesMujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo IV");
        if (dat4 != null) { txtRepitentesHomCicloIV.Text = dat4["thombre"].ToString(); txtRepitentesMujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo V");
        if (dat5 != null) { txtRepitentesHomCicloV.Text = dat5["thombre"].ToString(); txtRepitentesMujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De Repitentes o reiniciantes", "Ciclo VI");
        if (dat6 != null) { txtRepitentesHomCicloVI.Text = dat6["thombre"].ToString(); txtRepitentesMujCicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarGeneroEdadCicloGruposPorCiclos(string codsedeasesor)
    {
        //GruposPorCiclos
        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo I");
        if (dat1 != null) { txtGruposPorCiclosHomCicloI.Text = dat1["thombre"].ToString(); txtGruposPorCiclosMujCicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo II");
        if (dat2 != null) { txtGruposPorCiclosHomCicloII.Text = dat2["thombre"].ToString(); txtGruposPorCiclosMujCicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo III");
        if (dat3 != null) { txtGruposPorCiclosHomCicloIII.Text = dat3["thombre"].ToString(); txtGruposPorCiclosMujCicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo IV");
        if (dat4 != null) { txtGruposPorCiclosHomCicloIV.Text = dat4["thombre"].ToString(); txtGruposPorCiclosMujCicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo V");
        if (dat5 != null) { txtGruposPorCiclosHomCicloV.Text = dat5["thombre"].ToString(); txtGruposPorCiclosMujCicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "16", "C600B", "Núm. De grupos por ciclo", "Ciclo VI");
        if (dat6 != null) { txtGruposPorCiclosHomCicloVI.Text = dat6["thombre"].ToString(); txtGruposPorCiclosMujCicloVI.Text = dat6["tmujer"].ToString(); }
    }

    private void cargarModelosCiclosExtraedad(string codsedeasesor)
    {
        //Programa para jóvenes en extraedad y adultos

        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo I");
        if (dat1 != null) { txtExtredadHomClicloI.Text = dat1["thombre"].ToString(); txtExtredadMujClicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo II");
        if (dat2 != null) { txtExtredadHomClicloII.Text = dat2["thombre"].ToString(); txtExtredadMujClicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo III");
        if (dat3 != null) { txtExtredadHomClicloIII.Text = dat3["thombre"].ToString(); txtExtredadMujClicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo IV");
        if (dat4 != null) { txtExtredadHomClicloIV.Text = dat4["thombre"].ToString(); txtExtredadMujClicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo V");
        if (dat5 != null) { txtExtredadHomClicloV.Text = dat5["thombre"].ToString(); txtExtredadMujClicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Programa para jóvenes en extraedad y adultos", "Ciclo VI");
        if (dat6 != null) { txtExtredadHomClicloVI.Text = dat6["thombre"].ToString(); txtExtredadMujClicloVI.Text = dat6["tmujer"].ToString(); }
    }

    private void cargarModelosCiclosSAT(string codsedeasesor)
    {
        //SAT

        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SAT", "Ciclo I");
        if (dat1 != null) { txtSATHomClicloI.Text = dat1["thombre"].ToString(); txtSATMujClicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SAT", "Ciclo II");
        if (dat2 != null) { txtSATHomClicloII.Text = dat2["thombre"].ToString(); txtSATMujClicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SAT", "Ciclo III");
        if (dat3 != null) { txtSATHomClicloIII.Text = dat3["thombre"].ToString(); txtSATMujClicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SAT", "Ciclo IV");
        if (dat4 != null) { txtSATHomClicloIV.Text = dat4["thombre"].ToString(); txtSATMujClicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SAT", "Ciclo V");
        if (dat5 != null) { txtSATHomClicloV.Text = dat5["thombre"].ToString(); txtSATMujClicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SAT", "Ciclo VI");
        if (dat6 != null) { txtSATHomClicloVI.Text = dat6["thombre"].ToString(); txtSATMujClicloVI.Text = dat6["tmujer"].ToString(); }
    }

    private void cargarModelosCiclosSER(string codsedeasesor)
    {
        //SER

        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SER", "Ciclo I");
        if (dat1 != null) { txtSERHomClicloI.Text = dat1["thombre"].ToString(); txtSERMujClicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SER", "Ciclo II");
        if (dat2 != null) { txtSERHomClicloII.Text = dat2["thombre"].ToString(); txtSERMujClicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SER", "Ciclo III");
        if (dat3 != null) { txtSERHomClicloIII.Text = dat3["thombre"].ToString(); txtSERMujClicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SER", "Ciclo IV");
        if (dat4 != null) { txtSERHomClicloIV.Text = dat4["thombre"].ToString(); txtSERMujClicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SER", "Ciclo V");
        if (dat5 != null) { txtSERHomClicloV.Text = dat5["thombre"].ToString(); txtSERMujClicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "SER", "Ciclo VI");
        if (dat6 != null) { txtSERHomClicloVI.Text = dat6["thombre"].ToString(); txtSERMujClicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarModelosCiclosCAFAM(string codsedeasesor)
    {
        //CAFAM

        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo I");
        if (dat1 != null) { txtCAFAMHomClicloI.Text = dat1["thombre"].ToString(); txtCAFAMMujClicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo II");
        if (dat2 != null) { txtCAFAMHomClicloII.Text = dat2["thombre"].ToString(); txtCAFAMMujClicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo III");
        if (dat3 != null) { txtCAFAMHomClicloIII.Text = dat3["thombre"].ToString(); txtCAFAMMujClicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo IV");
        if (dat4 != null) { txtCAFAMHomClicloIV.Text = dat4["thombre"].ToString(); txtCAFAMMujClicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo V");
        if (dat5 != null) { txtCAFAMHomClicloV.Text = dat5["thombre"].ToString(); txtCAFAMMujClicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "CAFAM", "Ciclo VI");
        if (dat6 != null) { txtCAFAMHomClicloVI.Text = dat6["thombre"].ToString(); txtCAFAMMujClicloVI.Text = dat6["tmujer"].ToString(); }
    }

    private void cargarModelosCiclosTransformemos(string codsedeasesor)
    {
        //Transformemos

        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo I");
        if (dat1 != null) { txtTransformemosHomClicloI.Text = dat1["thombre"].ToString(); txtTransformemosMujClicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo II");
        if (dat2 != null) { txtTransformemosHomClicloII.Text = dat2["thombre"].ToString(); txtTransformemosMujClicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo III");
        if (dat3 != null) { txtTransformemosHomClicloIII.Text = dat3["thombre"].ToString(); txtTransformemosMujClicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo IV");
        if (dat4 != null) { txtTransformemosHomClicloIV.Text = dat4["thombre"].ToString(); txtTransformemosMujClicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo V");
        if (dat5 != null) { txtTransformemosHomClicloV.Text = dat5["thombre"].ToString(); txtTransformemosMujClicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Transformemos", "Ciclo VI");
        if (dat6 != null) { txtTransformemosHomClicloVI.Text = dat6["thombre"].ToString(); txtTransformemosMujClicloVI.Text = dat6["tmujer"].ToString(); }
    }
    private void cargarModelosCiclosOtro(string codsedeasesor)
    {
        //Otro

        DataRow dat1 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Otro", "Ciclo I");
        if (dat1 != null) { txtOtroHomClicloI.Text = dat1["thombre"].ToString(); txtOtroMujClicloI.Text = dat1["tmujer"].ToString(); }

        DataRow dat2 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Otro", "Ciclo II");
        if (dat2 != null) { txtOtroHomClicloII.Text = dat2["thombre"].ToString(); txtOtroMujClicloII.Text = dat2["tmujer"].ToString(); }

        DataRow dat3 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Otro", "Ciclo III");
        if (dat3 != null) { txtOtroHomClicloIII.Text = dat3["thombre"].ToString(); txtOtroMujClicloIII.Text = dat3["tmujer"].ToString(); }

        DataRow dat4 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Otro", "Ciclo IV");
        if (dat4 != null) { txtOtroHomClicloIV.Text = dat4["thombre"].ToString(); txtOtroMujClicloIV.Text = dat4["tmujer"].ToString(); }

        DataRow dat5 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Otro", "Ciclo V");
        if (dat5 != null) { txtOtroHomClicloV.Text = dat5["thombre"].ToString(); txtOtroMujClicloV.Text = dat5["tmujer"].ToString(); }

        DataRow dat6 = lb.cargarRespuestaSedesGeneros(codsedeasesor, "17", "C600B", "Otro", "Ciclo VI");
        if (dat6 != null) { txtOtroHomClicloVI.Text = dat6["thombre"].ToString(); txtOtroMujClicloVI.Text = dat6["tmujer"].ToString(); }
    }

    protected void btnPrimerGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
             if (validarJornadas(chkJornadas))
                {
                    if (rbtGeneroPoblacionAtendida.SelectedIndex != 0 || rbtGeneroPoblacionAtendida.SelectedIndex != 1 || rbtGeneroPoblacionAtendida.SelectedIndex != 2)
                    {
                        if (validarNivelesEnsenianza(chkNivelesEnsenianza))
                        {
                            if (rbtEtnias.SelectedIndex != 0 || rbtEtnias.SelectedIndex != 1)
                            {
                                EliminarJornadas(sedeasesor["codigo"].ToString());
                                AgregarJornadas(sedeasesor["codigo"].ToString(), chkJornadas);

                                EliminarGeneros(sedeasesor["codigo"].ToString());
                                AgregarGeneros(sedeasesor["codigo"].ToString(), rbtGeneroPoblacionAtendida);

                                EliminarNivelesEnsenianza(sedeasesor["codigo"].ToString());
                                AgregarNivelesEnsenianza(sedeasesor["codigo"].ToString(), chkNivelesEnsenianza);

                                EliminarCaracterAcademico(sedeasesor["codigo"].ToString());
                                EliminarCaracterTecnico(sedeasesor["codigo"].ToString());
                                if (chkNivelesEnsenianza.SelectedValue == "Media")
                                {
                                    AgregarCaracterAcademico(sedeasesor["codigo"].ToString(), chkCaracterAcademico);
                                    AgregarCaracterTecnico(sedeasesor["codigo"].ToString(), chkCaracterTecnico);
                                }



                                EliminarAtiendeEtnia(sedeasesor["codigo"].ToString());
                                AgregarAtiendeEtnia(sedeasesor["codigo"].ToString(), rbtEtnias);

                                EliminarProgramaEstrategiaPreescolar(sedeasesor["codigo"].ToString());
                                AgregarProgramaEstrategiaPreescolar(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosPreescolar);

                                EliminarProgramaEstrategiaPrimaria(sedeasesor["codigo"].ToString());
                                AgregarProgramaEstrategiaPrimaria(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosPrimaria);

                                EliminarProgramaEstrategiaSecundaria(sedeasesor["codigo"].ToString());
                                AgregarProgramaEstrategiaSecundaria(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosSecundaria);

                                EliminarProgramaEstrategiaMedia(sedeasesor["codigo"].ToString());
                                AgregarProgramaEstrategiaMedia(sedeasesor["codigo"].ToString(), chkEstrategiaModelosEducativosMedia);

                                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

                            }
                            else
                            {
                                mostrarmensaje("error", "Dede seleccionar si la Sede atiende población de grupos étnicos.");
                            }
                        }
                        else
                        {
                            mostrarmensaje("error", "Dede seleccionar un Nivel de enseñanza que ofrece la Sede.");
                        }
                    }
                    else
                    {
                        mostrarmensaje("error", "Dede seleccionar un Genero de la población atendida por la Sede.");
                    }
                }
             else
             {
                 mostrarmensaje("error", "Dede seleccionar una jornada para la Sede.");
             }

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
                if (validarJornadas(chkJornadas))
                {
                    if (rbtGeneroPoblacionAtendida.SelectedIndex != 0 || rbtGeneroPoblacionAtendida.SelectedIndex != 1 || rbtGeneroPoblacionAtendida.SelectedIndex != 2)
                    {
                        if (validarNivelesEnsenianza(chkNivelesEnsenianza))
                        {
                            if (rbtEtnias.SelectedIndex != 0 || rbtEtnias.SelectedIndex != 1)
                            {
                                EliminarJornadas(dat["codigo"].ToString());
                                AgregarJornadas(dat["codigo"].ToString(), chkJornadas);

                                EliminarGeneros(dat["codigo"].ToString());
                                AgregarGeneros(dat["codigo"].ToString(), rbtGeneroPoblacionAtendida);

                                EliminarNivelesEnsenianza(dat["codigo"].ToString());
                                AgregarNivelesEnsenianza(dat["codigo"].ToString(), chkNivelesEnsenianza);

                                EliminarCaracterAcademico(dat["codigo"].ToString());
                                EliminarCaracterTecnico(dat["codigo"].ToString());
                                if (chkNivelesEnsenianza.SelectedValue == "Media")
                                {
                                    AgregarCaracterAcademico(dat["codigo"].ToString(), chkCaracterAcademico);
                                    AgregarCaracterTecnico(dat["codigo"].ToString(), chkCaracterTecnico);
                                }

                                EliminarAtiendeEtnia(dat["codigo"].ToString());
                                AgregarAtiendeEtnia(dat["codigo"].ToString(), rbtEtnias);

                                EliminarProgramaEstrategiaPreescolar(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaPreescolar(dat["codigo"].ToString(), chkEstrategiaModelosEducativosPreescolar);

                                EliminarProgramaEstrategiaPrimaria(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaPrimaria(dat["codigo"].ToString(), chkEstrategiaModelosEducativosPrimaria);

                                EliminarProgramaEstrategiaSecundaria(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaSecundaria(dat["codigo"].ToString(), chkEstrategiaModelosEducativosSecundaria);

                                EliminarProgramaEstrategiaMedia(dat["codigo"].ToString());
                                AgregarProgramaEstrategiaMedia(dat["codigo"].ToString(), chkEstrategiaModelosEducativosMedia);

                                EliminarUltimoNivelEducativo(dat["codigo"].ToString());
                                AgregarUltimoNivelEducativo(dat["codigo"].ToString());

                                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

                            }
                            else
                            {
                                mostrarmensaje("error", "Dede seleccionar si la Sede atiende población de grupos étnicos.");
                            }
                        }
                        else
                        {
                            mostrarmensaje("error", "Dede seleccionar un Nivel de enseñanza que ofrece la Sede.");
                        }
                    }
                    else
                    {
                        mostrarmensaje("error", "Dede seleccionar un Genero de la población atendida por la Sede.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Dede seleccionar una jornada para la Sede.");
                }
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


        //if(lb.AgregarRespuestaCerradaSede(lblCodSede.Text,'´'ññ´ñ"1","","01","0"))
        //{

        //}
    }

    protected void btnSegundoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarUltimoNivelEducativo(sedeasesor["codigo"].ToString());
            AgregarUltimoNivelEducativo(sedeasesor["codigo"].ToString());

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
       
                EliminarUltimoNivelEducativo(dat["codigo"].ToString());
                AgregarUltimoNivelEducativo(dat["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }

    }

    protected void btnTercerGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
       
            EliminarPoblacionConDiscapacidad(sedeasesor["codigo"].ToString());
            if (rbdiscapacidadexcepcional.SelectedIndex == 0)
            {
                AgregarPoblacionConDiscapacidad(sedeasesor["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }

           

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
              
                EliminarPoblacionConDiscapacidad(dat["codigo"].ToString());
                if (rbdiscapacidadexcepcional.SelectedIndex == 0)
                {
                    AgregarPoblacionConDiscapacidad(dat["codigo"].ToString());
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }
  
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }

    }

    protected void btnCuartoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarIntegradosNoIntegrados(sedeasesor["codigo"].ToString());
            AgregarIntegradosNoIntegrados(sedeasesor["codigo"].ToString());

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
               
                             
                EliminarIntegradosNoIntegrados(dat["codigo"].ToString());
                AgregarIntegradosNoIntegrados(dat["codigo"].ToString());

                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");               
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }
    protected void btnQuintoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarPoblacionEtnia(sedeasesor["codigo"].ToString());
            if (rbGrupoEtnico.SelectedIndex == 0)
            {
                AgregarPoblacionEtnia(sedeasesor["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }

          

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
      
                EliminarPoblacionEtnia(dat["codigo"].ToString());
                if (rbGrupoEtnico.SelectedIndex == 0)
                {
                    AgregarPoblacionEtnia(dat["codigo"].ToString());
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }
                          
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }

    protected void btnSextoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarPoblacionVictimaConflicto(sedeasesor["codigo"].ToString());
            if (rbVictimaConflicto.SelectedIndex == 0)
            {
                AgregarPoblacionVictimaConflicto(sedeasesor["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }
           

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
                            
                EliminarPoblacionVictimaConflicto(dat["codigo"].ToString());
                if (rbVictimaConflicto.SelectedIndex == 0)
                {
                    AgregarPoblacionVictimaConflicto(dat["codigo"].ToString());
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }
                           
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }

    protected void btnSeptimoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarNivelesPreescolaryPrimaria(sedeasesor["codigo"].ToString());

            AgregarNivelesPreescolaryPrimaria(sedeasesor["codigo"].ToString());
            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
               
                               
                EliminarNivelesPreescolaryPrimaria(dat["codigo"].ToString());
                AgregarNivelesPreescolaryPrimaria(dat["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                              
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }
    protected void btnOctavoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarAceleracionAprendizaje(sedeasesor["codigo"].ToString());
            AgregarAceleracionAprendizaje(sedeasesor["codigo"].ToString());

            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
          

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {

                EliminarAceleracionAprendizaje(dat["codigo"].ToString());
                AgregarAceleracionAprendizaje(dat["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");     
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }
    protected void btnNovenoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
            

            EliminarSecundariayMedia(sedeasesor["codigo"].ToString());
            AgregarSecundariayMedia(sedeasesor["codigo"].ToString());
            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
         
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
      
                EliminarSecundariayMedia(dat["codigo"].ToString());
                AgregarSecundariayMedia(dat["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }
    protected void btnDecimoGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarEducacionMedia(sedeasesor["codigo"].ToString());
            AgregarEducacionMedia(sedeasesor["codigo"].ToString());
            mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
       
                EliminarEducacionMedia(dat["codigo"].ToString());
                AgregarEducacionMedia(dat["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                              
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }

    protected void btnDecimoPrimero_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {
           

            EliminarNivelEducativoCiclos(sedeasesor["codigo"].ToString());
            
            if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
            {
                AgregarNivelEducativoCiclos(sedeasesor["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {
              

                EliminarNivelEducativoCiclos(dat["codigo"].ToString());
              
                if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
                {
                    AgregarNivelEducativoCiclos(dat["codigo"].ToString());
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }

                           
              
            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }

    protected void btnDecimoSegundo_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {


         
            EliminarGeneroCiclo(sedeasesor["codigo"].ToString());
          
            if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
            {
              
                AgregarGeneroCiclo(sedeasesor["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {


              
                EliminarGeneroCiclo(dat["codigo"].ToString());
             
                if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
                {
                   
                    AgregarGeneroCiclo(dat["codigo"].ToString());
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }



            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }

    protected void btnDecimoTercero_Onclick(object sender, EventArgs e)
    {
        DataRow sedeasesor = lb.buscarSedexInsasesor(lblCodSede.Text);

        if (sedeasesor != null)
        {


        
            EliminarModelosCiclos(sedeasesor["codigo"].ToString());
            if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
            {
              
                AgregarModelosCiclo(sedeasesor["codigo"].ToString());
                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
            }

        }
        else
        {
            DataRow dat = lb.agregarSedeInsasesor(lblCodSede.Text, lblCodInstAsesor.Text);

            if (dat != null)
            {


             
                EliminarModelosCiclos(dat["codigo"].ToString());
                if (rtbEducacionFormalExtraedad.SelectedIndex == 0)
                {
                  
                    AgregarModelosCiclo(dat["codigo"].ToString());
                    mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                }



            }
            else
            {
                mostrarmensaje("error", "Error al guardar");
            }
        }


    }
}
