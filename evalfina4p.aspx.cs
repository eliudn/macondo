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

public partial class evalfina4p : System.Web.UI.Page
{
    string codrol = "";
    string validarIntentos = "true";
    Institucion inst = new Institucion();
    LineaBase lb = new LineaBase();
    Funciones fun = new Funciones();
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
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        PanelAgregarSede.Attributes.Add("style", "display:none");
        PanelEditarSede.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
           
            lblCodRol.Text = Session["codrol"].ToString();
            lblCodDANE.Text = Session["dane"].ToString();

            ddZona(dropZonaEdit);
            ddCiudad(dropMunicipio);
            ddRectores(dropNomRector);

            //Instrumento 02
            ddCargarPreguntas();

            obtenerGet();

            if(lblBack.Text == "true")
            {
                //Response.Redirect("lineabaseregistroinst.aspx");
                PanelFormularioC600B.Visible = true;
                cargarSedesC600B(lblCodInstitucion.Text);
               
            }

            if (lblLineaBaseSede.Text == "true")
            {
                PanelInstrumento01.Visible = true;
                cargarSedes(lblCodInstitucion.Text);
            }


        }
    }
    protected void btnSumarTotales_Click(object sender, EventArgs e)
    {
        sumarTotales();
    }
    private void sumarTotales()
    {
        //Preescolar
        int totalHomPreescolar = 0;
        totalHomPreescolar = Convert.ToInt32(txtBachiHomPreescolar.Text) + Convert.ToInt32(txtSuperiorHomPreescolar.Text) + Convert.ToInt32(txtOtroBachiHomPreescolar.Text) + Convert.ToInt32(txtTecPedagoHomPreescolar.Text) + Convert.ToInt32(txtOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtProfPedagoHomPreescolar.Text) + Convert.ToInt32(txtProfOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtPosPedagoHomPreescolar.Text) + Convert.ToInt32(txtPosOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtOtroCualHomPreescolar.Text);
        txtTotalTotalHomPreescolar.Text = Convert.ToString(totalHomPreescolar);

        int totalMujPreescolar = 0;
        totalMujPreescolar = Convert.ToInt32(txtBachiMujPreescolar.Text) + Convert.ToInt32(txtSuperiorMujPreescolar.Text) + Convert.ToInt32(txtOtroBachiMujPreescolar.Text) + Convert.ToInt32(txtTecPedagoMujPreescolar.Text) + Convert.ToInt32(txtOtroPedagoMujPreescolar.Text) + Convert.ToInt32(txtProfPedagoMujPreescolar.Text) + Convert.ToInt32(txtProfOtroPedagoMujPreescolar.Text) + Convert.ToInt32(txtPosPedagoMujPreescolar.Text) + Convert.ToInt32(txtPosOtroPedagoMujPreescolar.Text) + Convert.ToInt32(txtOtroCualMujPreescolar.Text);
        txtTotalTotalMujPreescolar.Text = Convert.ToString(totalMujPreescolar);

        //Primaria
        int totalHomPrimaria = 0;
        totalHomPrimaria = Convert.ToInt32(txtBachiHomPrimaria.Text) + Convert.ToInt32(txtSuperiorHomPrimaria.Text) + Convert.ToInt32(txtOtroBachiHomPrimaria.Text) + Convert.ToInt32(txtTecPedagoHomPrimaria.Text) + Convert.ToInt32(txtOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtProfPedagoHomPrimaria.Text) + Convert.ToInt32(txtProfOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtPosPedagoHomPrimaria.Text) + Convert.ToInt32(txtPosOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtOtroCualHomPrimaria.Text);
        txtTotalTotalMujPrimaria.Text = Convert.ToString(totalHomPrimaria);

        int totalMujPrimaria = 0;
        totalMujPrimaria = Convert.ToInt32(txtBachiMujPrimaria.Text) + Convert.ToInt32(txtSuperiorMujPrimaria.Text) + Convert.ToInt32(txtOtroBachiMujPrimaria.Text) + Convert.ToInt32(txtTecPedagoMujPrimaria.Text) + Convert.ToInt32(txtOtroPedagoMujPrimaria.Text) + Convert.ToInt32(txtProfPedagoMujPrimaria.Text) + Convert.ToInt32(txtProfOtroPedagoMujPrimaria.Text) + Convert.ToInt32(txtPosPedagoMujPrimaria.Text) + Convert.ToInt32(txtPosOtroPedagoMujPrimaria.Text) + Convert.ToInt32(txtOtroCualMujPrimaria.Text);
        txtTotalTotalTotalHomPrimaria.Text = Convert.ToString(totalMujPrimaria);

        //Secundaria
        int totalHomSecundaria = 0;
        totalHomSecundaria = Convert.ToInt32(txtBachiHomSecundaria.Text) + Convert.ToInt32(txtSuperiorHomSecundaria.Text) + Convert.ToInt32(txtOtroBachiHomSecundaria.Text) + Convert.ToInt32(txtTecPedagoHomSecundaria.Text) + Convert.ToInt32(txtOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtProfPedagoHomSecundaria.Text) + Convert.ToInt32(txtProfOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtPosPedagoHomSecundaria.Text) + Convert.ToInt32(txtPosOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtOtroCualHomSecundaria.Text);
        txtTotalTotalMujSecundaria.Text = Convert.ToString(totalHomSecundaria);

        int totalMujSecundaria = 0;
        totalMujSecundaria = Convert.ToInt32(txtBachiMujSecundaria.Text) + Convert.ToInt32(txtSuperiorMujSecundaria.Text) + Convert.ToInt32(txtOtroBachiMujSecundaria.Text) + Convert.ToInt32(txtTecPedagoMujSecundaria.Text) + Convert.ToInt32(txtOtroPedagoMujSecundaria.Text) + Convert.ToInt32(txtProfPedagoMujSecundaria.Text) + Convert.ToInt32(txtProfOtroPedagoMujSecundaria.Text) + Convert.ToInt32(txtPosPedagoMujSecundaria.Text) + Convert.ToInt32(txtPosOtroPedagoMujSecundaria.Text) + Convert.ToInt32(txtOtroCualMujSecundaria.Text);
        txtTotalTotalTotalSecundaria.Text = Convert.ToString(totalMujSecundaria);

        //Media
        int totalHomMedia = 0;
        totalHomMedia = Convert.ToInt32(txtBachiHomMedia.Text) + Convert.ToInt32(txtSuperiorHomMedia.Text) + Convert.ToInt32(txtOtroBachiHomMedia.Text) + Convert.ToInt32(txtTecPedagoHomMedia.Text) + Convert.ToInt32(txtOtroPedagoHomMedia.Text) + Convert.ToInt32(txtProfPedagoHomMedia.Text) + Convert.ToInt32(txtProfOtroPedagoHomMedia.Text) + Convert.ToInt32(txtPosPedagoHomMedia.Text) + Convert.ToInt32(txtPosOtroPedagoHomMedia.Text) + Convert.ToInt32(txtOtroCualHomMedia.Text);
        txtTotalTotalMujMedia.Text = Convert.ToString(totalHomMedia);

        int totalMujMedia = 0;
        totalMujMedia = Convert.ToInt32(txtBachiMujMedia.Text) + Convert.ToInt32(txtSuperiorMujMedia.Text) + Convert.ToInt32(txtOtroBachiMujMedia.Text) + Convert.ToInt32(txtTecPedagoMujMedia.Text) + Convert.ToInt32(txtOtroPedagoMujMedia.Text) + Convert.ToInt32(txtProfPedagoMujMedia.Text) + Convert.ToInt32(txtProfOtroPedagoMujMedia.Text) + Convert.ToInt32(txtPosPedagoMujMedia.Text) + Convert.ToInt32(txtPosOtroPedagoMujMedia.Text) + Convert.ToInt32(txtOtroCualMujMedia.Text);
        txtTotalTotalTotalMedia.Text = Convert.ToString(totalMujMedia);

        //Bachillerato - Preescolar
        int totalBachiPreescolar = 0;
        totalBachiPreescolar = Convert.ToInt32(txtBachiHomPreescolar.Text) + Convert.ToInt32(txtBachiMujPreescolar.Text);
        txtBachiTotalPreescolar.Text = Convert.ToString(totalBachiPreescolar);
        
        //Superior - Preescolar
        int totalSuperiorPreescolar = 0;
        totalBachiPreescolar = Convert.ToInt32(txtSuperiorHomPreescolar.Text) + Convert.ToInt32(txtSuperiorMujPreescolar.Text);
        txtSuperiorTotalPreescolar.Text = Convert.ToString(totalSuperiorPreescolar);

        //Superior - Preescolar
        int totalOtroPreescolar = 0;
        totalOtroPreescolar = Convert.ToInt32(txtOtroBachiHomPreescolar.Text) + Convert.ToInt32(txtOtroBachiMujPreescolar.Text);
        txtOtroBachiTotalPreescolar.Text = Convert.ToString(totalOtroPreescolar);

        //Tecnico Pedagogico - Preescolar
        int totalTecPedagoPreescolar = 0;
        totalTecPedagoPreescolar = Convert.ToInt32(txtTecPedagoHomPreescolar.Text) + Convert.ToInt32(txtTecPedagoMujPreescolar.Text);
        txtTecPedagoTotalPreescolar.Text = Convert.ToString(totalTecPedagoPreescolar);

        //Tecnica otro - Preescolar
        int totalOtroPedagoPreescolar = 0;
        totalOtroPedagoPreescolar = Convert.ToInt32(txtOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtOtroPedagoMujPreescolar.Text);
        txtOtroPedagoTotalPreescolar.Text = Convert.ToString(totalOtroPedagoPreescolar);

        //Profesional Pedagogico - Preescolar
        int totalOtroProfPreescolar = 0;
        totalOtroProfPreescolar = Convert.ToInt32(txtProfPedagoHomPreescolar.Text) + Convert.ToInt32(txtProfPedagoMujPreescolar.Text);
        txtProfPedagoTotalPreescolar.Text = Convert.ToString(totalOtroProfPreescolar);

        //Profesional otro - Preescolar
        int totalProfOtroPreescolar = 0;
        totalProfOtroPreescolar = Convert.ToInt32(txtProfOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtProfOtroPedagoMujPreescolar.Text);
        txtProfOtroPedagoTotalPreescolar.Text = Convert.ToString(totalProfOtroPreescolar);

        //Pos Peda - Preescolar
        int totalPosPedaPreescolar = 0;
        totalPosPedaPreescolar = Convert.ToInt32(txtPosOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtPosOtroPedagoMujPreescolar.Text);
        txtPosPedagoTotalPreescolar.Text = Convert.ToString(totalPosPedaPreescolar);

        //Otro - Preescolar
        int totalOtrototalPreescolar = 0;
        totalOtrototalPreescolar = Convert.ToInt32(txtOtroCualHomPreescolar.Text) + Convert.ToInt32(txtOtroCualMujPreescolar.Text);
        txtPosOtroPedagoTotalPreescolar.Text = Convert.ToString(totalOtrototalPreescolar);

        //Bachillerato - Primaria
        int totalBachiPrimaria = 0;
        totalBachiPrimaria = Convert.ToInt32(txtBachiHomPrimaria.Text) + Convert.ToInt32(txtBachiMujPrimaria.Text);
        txtBachiTotalPrimaria.Text = Convert.ToString(totalBachiPrimaria);

        //Superior - Primaria
        int totalSuperiorPrimaria = 0;
        totalSuperiorPrimaria = Convert.ToInt32(txtSuperiorHomPrimaria.Text) + Convert.ToInt32(txtSuperiorMujPrimaria.Text);
        txtSuperiorTotalPrimaria.Text = Convert.ToString(totalSuperiorPrimaria);

        //Superior - Primaria
        int totalOtroPrimaria = 0;
        totalOtroPrimaria = Convert.ToInt32(txtOtroBachiHomPrimaria.Text) + Convert.ToInt32(txtOtroBachiMujPrimaria.Text);
        txtOtroBachiTotalPrimaria.Text = Convert.ToString(totalOtroPrimaria);

        //Tecnico Pedagogico - Primaria
        int totalTecPedagoPrimaria = 0;
        totalTecPedagoPrimaria = Convert.ToInt32(txtTecPedagoHomPrimaria.Text) + Convert.ToInt32(txtTecPedagoMujPrimaria.Text);
        txtTecPedagoTotalPrimaria.Text = Convert.ToString(totalTecPedagoPrimaria);

        //Tecnica otro - Primaria
        int totalOtroPedagoPrimaria = 0;
        totalOtroPedagoPrimaria = Convert.ToInt32(txtOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtOtroPedagoMujPrimaria.Text);
        txtOtroPedagoTotalPrimaria.Text = Convert.ToString(totalOtroPedagoPrimaria);

        //Profesional Pedagogico - Primaria
        int totalOtroProfPrimaria = 0;
        totalOtroProfPrimaria = Convert.ToInt32(txtProfPedagoHomPrimaria.Text) + Convert.ToInt32(txtProfPedagoMujPrimaria.Text);
        txtProfPedagoTotalPrimaria.Text = Convert.ToString(totalOtroProfPrimaria);

        //Profesional otro - Primaria
        int totalProfOtroPrimaria = 0;
        totalProfOtroPrimaria = Convert.ToInt32(txtProfOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtProfOtroPedagoMujPrimaria.Text);
        txtProfOtroPedagoTotalPrimaria.Text = Convert.ToString(totalProfOtroPrimaria);

        //Pos Peda - Primaria
        int totalPosPedaPrimaria = 0;
        totalPosPedaPrimaria = Convert.ToInt32(txtPosPedagoHomPrimaria.Text) + Convert.ToInt32(txtPosPedagoHomPrimaria.Text);
        txtPosPedagoTotalPrimaria.Text = Convert.ToString(totalPosPedaPrimaria);

        //Pos otro - Primaria
        int totalPosPedaOtroPrimaria = 0;
        totalPosPedaOtroPrimaria = Convert.ToInt32(txtPosOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtPosOtroPedagoMujPrimaria.Text);
        txtPosOtroPedagoTotalPrimaria.Text = Convert.ToString(totalPosPedaOtroPrimaria);

        //Otro - Primaria
        int totalOtrototalPrimaria = 0;
        totalOtrototalPrimaria = Convert.ToInt32(txtOtroCualHomPrimaria.Text) + Convert.ToInt32(txtOtroCualMujPrimaria.Text);
        txtOtroCualTotalPrimaria.Text = Convert.ToString(totalOtrototalPrimaria);

        //Bachillerato - Secundaria
        int totalBachiSecundaria = 0;
        totalBachiSecundaria = Convert.ToInt32(txtBachiHomSecundaria.Text) + Convert.ToInt32(txtBachiMujSecundaria.Text);
        txtBachiTotalSecundaria.Text = Convert.ToString(totalBachiSecundaria);

        //Superior - Secundaria
        int totalSuperiorSecundaria = 0;
        totalSuperiorSecundaria = Convert.ToInt32(txtSuperiorHomSecundaria.Text) + Convert.ToInt32(txtSuperiorMujSecundaria.Text);
        txtSuperiorTotalSecundaria.Text = Convert.ToString(totalSuperiorSecundaria);

        //Superior - Secundaria
        int totalOtroSecundaria = 0;
        totalOtroSecundaria = Convert.ToInt32(txtOtroBachiHomSecundaria.Text) + Convert.ToInt32(txtOtroBachiMujSecundaria.Text);
        txtOtroBachiTotalSecundaria.Text = Convert.ToString(totalOtroSecundaria);

        //Tecnico Pedagogico - Secundaria
        int totalTecPedagoSecundaria = 0;
        totalTecPedagoSecundaria = Convert.ToInt32(txtTecPedagoHomSecundaria.Text) + Convert.ToInt32(txtTecPedagoMujSecundaria.Text);
        txtTecPedagoTotalSecundaria.Text = Convert.ToString(totalTecPedagoSecundaria);

        //Tecnica otro - Secundaria
        int totalOtroPedagoSecundaria = 0;
        totalOtroPedagoSecundaria = Convert.ToInt32(txtOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtOtroPedagoMujSecundaria.Text);
        txtOtroPedagoTotalSecundaria.Text = Convert.ToString(totalOtroPedagoSecundaria);

        //Profesional Pedagogico - Secundaria
        int totalOtroProfSecundaria = 0;
        totalOtroProfSecundaria = Convert.ToInt32(txtProfPedagoHomSecundaria.Text) + Convert.ToInt32(txtProfPedagoMujSecundaria.Text);
        txtProfPedagoTotalSecundaria.Text = Convert.ToString(totalOtroProfSecundaria);

        //Profesional otro - Secundaria
        int totalProfOtroSecundaria = 0;
        totalProfOtroSecundaria = Convert.ToInt32(txtProfOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtProfOtroPedagoMujSecundaria.Text);
        txtProfOtroPedagoTotalSecundaria.Text = Convert.ToString(totalProfOtroSecundaria);

        //Pos Peda - Secundaria
        int totalPosPedaSecundaria = 0;
        totalPosPedaSecundaria = Convert.ToInt32(txtPosPedagoHomSecundaria.Text) + Convert.ToInt32(txtPosPedagoHomSecundaria.Text);
        txtPosPedagoTotalSecundaria.Text = Convert.ToString(totalPosPedaSecundaria);

        //Pos otro - Secundaria
        int totalPosPedaOtroSecundaria = 0;
        totalPosPedaOtroSecundaria = Convert.ToInt32(txtPosOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtPosOtroPedagoMujSecundaria.Text);
        txtPosOtroPedagoTotalSecundaria.Text = Convert.ToString(totalPosPedaOtroSecundaria);

        //Otro - Secundaria
        int totalOtrototalSecundaria = 0;
        totalOtrototalSecundaria = Convert.ToInt32(txtOtroCualHomSecundaria.Text) + Convert.ToInt32(txtOtroCualMujSecundaria.Text);
        txtOtroCualTotalSecundaria.Text = Convert.ToString(totalOtrototalSecundaria);

        //Bachillerato - Media
        int totalBachiMedia = 0;
        totalBachiMedia = Convert.ToInt32(txtBachiHomMedia.Text) + Convert.ToInt32(txtBachiMujMedia.Text);
        txtBachiTotalMedia.Text = Convert.ToString(totalBachiMedia);

        //Superior - Media
        int totalSuperiorMedia = 0;
        totalSuperiorMedia = Convert.ToInt32(txtSuperiorHomMedia.Text) + Convert.ToInt32(txtSuperiorMujMedia.Text);
        txtSuperiorTotalMedia.Text = Convert.ToString(totalSuperiorMedia);

        //Superior - Media
        int totalOtroMedia = 0;
        totalOtroMedia = Convert.ToInt32(txtOtroBachiHomMedia.Text) + Convert.ToInt32(txtOtroBachiMujMedia.Text);
        txtOtroBachiTotalMedia.Text = Convert.ToString(totalOtroMedia);

        //Tecnico Pedagogico - Media
        int totalTecPedagoMedia = 0;
        totalTecPedagoMedia = Convert.ToInt32(txtTecPedagoHomMedia.Text) + Convert.ToInt32(txtTecPedagoMujMedia.Text);
        txtTecPedagoTotalMedia.Text = Convert.ToString(totalTecPedagoMedia);

        //Tecnica otro - Media
        int totalOtroPedagoMedia = 0;
        totalOtroPedagoMedia = Convert.ToInt32(txtOtroPedagoHomMedia.Text) + Convert.ToInt32(txtOtroPedagoMujMedia.Text);
        txtOtroPedagoTotalMedia.Text = Convert.ToString(totalOtroPedagoMedia);

        //Profesional Pedagogico - Media
        int totalOtroProfMedia = 0;
        totalOtroProfMedia = Convert.ToInt32(txtProfPedagoHomMedia.Text) + Convert.ToInt32(txtProfPedagoMujMedia.Text);
        txtProfPedagoTotalMedia.Text = Convert.ToString(totalOtroProfMedia);

        //Profesional otro - Media
        int totalProfOtroMedia = 0;
        totalProfOtroMedia = Convert.ToInt32(txtProfOtroPedagoHomMedia.Text) + Convert.ToInt32(txtProfOtroPedagoMujMedia.Text);
        txtProfOtroPedagoTotalMedia.Text = Convert.ToString(totalProfOtroMedia);

        //Pos Peda - Media
        int totalPosPedaMedia = 0;
        totalPosPedaMedia = Convert.ToInt32(txtPosPedagoHomMedia.Text) + Convert.ToInt32(txtPosPedagoHomMedia.Text);
        txtPosPedagoTotalMedia.Text = Convert.ToString(totalPosPedaMedia);

        //Pos otro - Media
        int totalPosPedaOtroMedia = 0;
        totalPosPedaOtroMedia = Convert.ToInt32(txtPosOtroPedagoHomMedia.Text) + Convert.ToInt32(txtPosOtroPedagoMujMedia.Text);
        txtPosOtroPedagoTotalMedia.Text = Convert.ToString(totalPosPedaOtroMedia);

        //Otro - Media
        int totalOtrototalMedia = 0;
        totalOtrototalMedia = Convert.ToInt32(txtOtroCualHomMedia.Text) + Convert.ToInt32(txtOtroCualMujMedia.Text);
        txtOtroCualTotalMedia.Text = Convert.ToString(totalOtrototalMedia);
        
        //TOTALES Bachi
        int totalHombreBachi = 0;
        totalHombreBachi = Convert.ToInt32(txtBachiHomPreescolar.Text) + Convert.ToInt32(txtBachiHomPrimaria.Text) + Convert.ToInt32(txtBachiHomSecundaria.Text) + Convert.ToInt32(txtBachiHomMedia.Text);
        txtBachiHomTotal.Text = Convert.ToString(totalHombreBachi);

        int totalMujeresBachi = 0;
        totalMujeresBachi = Convert.ToInt32(txtBachiMujPreescolar.Text) + Convert.ToInt32(txtBachiMujPrimaria.Text) + Convert.ToInt32(txtBachiMujSecundaria.Text) + Convert.ToInt32(txtBachiMujMedia.Text);
        txtBachiMujTotal.Text = Convert.ToString(totalMujeresBachi);

        int totalBachi = 0;
        totalBachi = totalHombreBachi + totalMujeresBachi;
        txtBachiTotalTotal.Text = Convert.ToString(totalBachi);

        //TOTALES Superior
        int totalHombreSuperior = 0;
        totalHombreSuperior = Convert.ToInt32(txtSuperiorHomPreescolar.Text) + Convert.ToInt32(txtSuperiorHomPrimaria.Text) + Convert.ToInt32(txtSuperiorHomSecundaria.Text) + Convert.ToInt32(txtSuperiorHomMedia.Text);
        txtSuperiorHomTotal.Text = Convert.ToString(totalHombreSuperior);

        int totalMujeresSuperior = 0;
        totalMujeresSuperior = Convert.ToInt32(txtSuperiorMujPreescolar.Text) + Convert.ToInt32(txtSuperiorMujPrimaria.Text) + Convert.ToInt32(txtSuperiorMujSecundaria.Text) + Convert.ToInt32(txtSuperiorMujMedia.Text);
        txtSuperiorMujTotal.Text = Convert.ToString(totalMujeresSuperior);

        int totalSuperior = 0;
        totalSuperior = totalHombreSuperior + totalMujeresSuperior;
        txtSuperiorTotalTotal.Text = Convert.ToString(totalSuperior);

             //TOTALES Otro Bachillerato
        int totalHombreOtroBachi = 0;
        totalHombreOtroBachi = Convert.ToInt32(txtOtroBachiHomPreescolar.Text) + Convert.ToInt32(txtOtroBachiHomPrimaria.Text) + Convert.ToInt32(txtOtroBachiHomSecundaria.Text) + Convert.ToInt32(txtOtroBachiHomMedia.Text);
        txtOtroBachiHomTotal.Text = Convert.ToString(totalHombreOtroBachi);

        int totalMujeresOtroBachi = 0;
        totalMujeresOtroBachi = Convert.ToInt32(txtOtroBachiMujPreescolar.Text) + Convert.ToInt32(txtOtroBachiMujPrimaria.Text) + Convert.ToInt32(txtOtroBachiMujSecundaria.Text) + Convert.ToInt32(txtOtroBachiMujMedia.Text);
        txtOtroBachiMujTotal.Text = Convert.ToString(totalMujeresOtroBachi);

        int totalOtroBachi = 0;
        totalOtroBachi = totalHombreOtroBachi + totalMujeresOtroBachi;
        txtOtroBachiTotalTotal.Text = Convert.ToString(totalOtroBachi);

        //TOTALES Tecnico Pedagogico
        int totalHombreTecPedago = 0;
        totalHombreTecPedago = Convert.ToInt32(txtTecPedagoHomPreescolar.Text) + Convert.ToInt32(txtTecPedagoHomPrimaria.Text) + Convert.ToInt32(txtTecPedagoHomSecundaria.Text) + Convert.ToInt32(txtTecPedagoHomMedia.Text);
        txtTecPedagoHomTotal.Text = Convert.ToString(totalHombreTecPedago);

        int totalMujeresTecPedago = 0;
        totalMujeresTecPedago = Convert.ToInt32(txtTecPedagoMujPreescolar.Text) + Convert.ToInt32(txtTecPedagoMujPrimaria.Text) + Convert.ToInt32(txtTecPedagoMujSecundaria.Text) + Convert.ToInt32(txtTecPedagoMujMedia.Text);
        txtTecPedagoMujTotal.Text = Convert.ToString(totalMujeresTecPedago);

        int totalTecPedago = 0;
        totalTecPedago = totalHombreTecPedago + totalMujeresTecPedago;
        txtTecPedagoTotalTotal.Text = Convert.ToString(totalTecPedago);

        //TOTALES Tecnico Otro
        int totalHombreOtroPedago = 0;
        totalHombreOtroPedago = Convert.ToInt32(txtOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtOtroPedagoHomMedia.Text);
        txtOtroPedagoHomTotal.Text = Convert.ToString(totalHombreOtroPedago);

        int totalMujeresOtroPedago = 0;
        totalMujeresOtroPedago = Convert.ToInt32(txtOtroPedagoMujPreescolar.Text) + Convert.ToInt32(txtOtroPedagoMujPrimaria.Text) + Convert.ToInt32(txtOtroPedagoMujSecundaria.Text) + Convert.ToInt32(txtOtroPedagoMujMedia.Text);
        txtOtroPedagoMujTotal.Text = Convert.ToString(totalMujeresOtroPedago);

        int totalOtroPedago = 0;
        totalOtroPedago = totalHombreOtroPedago + totalMujeresOtroPedago;
        txtOtroPedagoTotalTotal.Text = Convert.ToString(totalOtroPedago);

        //TOTALES Prof Pedagogia
        int totalHombreProfPedago = 0;
        totalHombreProfPedago = Convert.ToInt32(txtProfPedagoHomPreescolar.Text) + Convert.ToInt32(txtProfPedagoHomPrimaria.Text) + Convert.ToInt32(txtProfPedagoHomSecundaria.Text) + Convert.ToInt32(txtProfPedagoHomMedia.Text);
        txtProfPedagoHomTotal.Text = Convert.ToString(totalHombreProfPedago);

        int totalMujeresProfPedago = 0;
        totalMujeresProfPedago = Convert.ToInt32(txtProfPedagoMujPreescolar.Text) + Convert.ToInt32(txtProfPedagoMujPrimaria.Text) + Convert.ToInt32(txtProfPedagoMujSecundaria.Text) + Convert.ToInt32(txtProfPedagoMujMedia.Text);
        txtProfPedagoMujTotal.Text = Convert.ToString(totalMujeresProfPedago);

        int totalProfPedago = 0;
        totalProfPedago = totalHombreProfPedago + totalMujeresProfPedago;
        txtProfPedagoTotalTotal.Text = Convert.ToString(totalProfPedago);

            //TOTALES Prof Otro
        int totalHombreProfOtro = 0;
        totalHombreProfOtro = Convert.ToInt32(txtProfOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtProfOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtProfOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtProfOtroPedagoHomMedia.Text);
        txtProfOtroPedagoHomTotal.Text = Convert.ToString(totalHombreProfOtro);

        int totalMujeresProfOtro = 0;
        totalMujeresProfOtro = Convert.ToInt32(txtProfOtroPedagoMujPreescolar.Text) + Convert.ToInt32(txtProfOtroPedagoMujPrimaria.Text) + Convert.ToInt32(txtProfOtroPedagoMujSecundaria.Text) + Convert.ToInt32(txtProfOtroPedagoMujMedia.Text);
        txtProfOtroPedagoMujTotal.Text = Convert.ToString(totalMujeresProfOtro);

        int totalProfOtro = 0;
        totalProfOtro = totalHombreProfOtro + totalMujeresProfOtro;
        txtProfOtroPedagoTotalTotal.Text = Convert.ToString(totalProfOtro);

        //TOTALES Posgrado peda
        int totalHombrePosPedago = 0;
        totalHombrePosPedago = Convert.ToInt32(txtPosPedagoHomPreescolar.Text) + Convert.ToInt32(txtPosPedagoHomPrimaria.Text) + Convert.ToInt32(txtPosPedagoHomSecundaria.Text) + Convert.ToInt32(txtPosPedagoHomMedia.Text);
        txtPosPedagoHomTotal.Text = Convert.ToString(totalHombrePosPedago);

        int totalMujeresPosPedago = 0;
        totalMujeresPosPedago = Convert.ToInt32(txtPosPedagoMujPreescolar.Text) + Convert.ToInt32(txtPosPedagoMujPrimaria.Text) + Convert.ToInt32(txtPosPedagoMujSecundaria.Text) + Convert.ToInt32(txtPosPedagoMujMedia.Text);
        txtPosPedagoMujTotal.Text = Convert.ToString(totalMujeresPosPedago);

        int totalPosPedago = 0;
        totalPosPedago = totalHombrePosPedago + totalMujeresPosPedago;
        txtPosPedagoTotalTotal.Text = Convert.ToString(totalPosPedago);

        //TOTALES Posgrado Otro
        int totalHombrePosOtro = 0;
        totalHombrePosOtro = Convert.ToInt32(txtPosOtroPedagoHomPreescolar.Text) + Convert.ToInt32(txtPosOtroPedagoHomPrimaria.Text) + Convert.ToInt32(txtPosOtroPedagoHomSecundaria.Text) + Convert.ToInt32(txtPosOtroPedagoHomMedia.Text);
        txtPosOtroPedagoHomTotal.Text = Convert.ToString(totalHombrePosOtro);

        int totalMujeresPosOtro = 0;
        totalMujeresPosOtro = Convert.ToInt32(txtPosOtroPedagoMujPreescolar.Text) + Convert.ToInt32(txtPosOtroPedagoMujPrimaria.Text) + Convert.ToInt32(txtPosOtroPedagoMujSecundaria.Text) + Convert.ToInt32(txtPosOtroPedagoMujMedia.Text);
        txtPosOtroPedagoMujTotal.Text = Convert.ToString(totalMujeresPosOtro);

        int totalPoOtro = 0;
        totalPoOtro = totalHombrePosOtro + totalMujeresPosOtro;
        txtPosOtroPedagoTotalTotal.Text = Convert.ToString(totalPoOtro);

        //TOTALES Otro
        int totalOtro = 0;
        totalOtro = Convert.ToInt32(txtOtroCualHomPreescolar.Text) + Convert.ToInt32(txtOtroCualHomPrimaria.Text) + Convert.ToInt32(txtOtroCualHomSecundaria.Text) + Convert.ToInt32(txtOtroCualHomMedia.Text);
        txtOtroCualHomTotal.Text = Convert.ToString(totalOtro);

        int totalMujeresOtro = 0;
        totalMujeresOtro = Convert.ToInt32(txtOtroCualMujPreescolar.Text) + Convert.ToInt32(txtOtroCualMujPrimaria.Text) + Convert.ToInt32(txtOtroCualMujSecundaria.Text) + Convert.ToInt32(txtOtroCualMujMedia.Text);
        txtOtroCualMujTotal.Text = Convert.ToString(totalMujeresOtro);

        int totalTotalOtro = 0;
        totalTotalOtro = totalOtro + totalMujeresOtro;
        txtOtroCualTotalTotal.Text = Convert.ToString(totalTotalOtro);


        //Total Total
        int total = 0;
        total = totalOtro + totalHombrePosOtro + totalHombrePosPedago + totalHombreProfOtro + totalHombreProfPedago + totalHombreOtroPedago + totalHombreTecPedago + totalHombreOtroBachi + totalHombreSuperior + totalHombreBachi;
        txtTotalTotalMujTotal.Text = Convert.ToString(total);

        int totalMuj = 0;
        totalMuj = totalMujeresOtro + totalMujeresPosOtro + totalMujeresPosPedago + totalMujeresProfOtro + totalMujeresProfPedago + totalMujeresOtroPedago + totalMujeresTecPedago + totalMujeresOtroBachi + totalMujeresSuperior + totalMujeresBachi;
        txtTotalTotalTotalTotal.Text = Convert.ToString(totalMuj);

    }
    private void obtenerGet()
    {
        try
        {
            lblBack.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["back"]);
            lblCodInstitucion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ci"]);
            lblCodAsesor.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ca"]);
            lblLineaBaseSede.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["lbs"]);
            lblCodInstAsesor.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cia"]);
        }
        catch
        {
            throw new HttpException(500, "Error Interno");
        }
    }
    private void ddCiudad(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarciudad();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

      
    }

   
    private void ddCiudadxDepartamento(DropDownList drop, string coddepartamento)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarciudadxDepartamento(coddepartamento);
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));


    }

    private void ddDepartamentos(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarDepartamento();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));


    }
    protected void dropCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropDepartamento.SelectedIndex > 0)
        {
            ddCiudadxDepartamento(dropCiudad, dropDepartamento.SelectedValue);
        }
    }
    private void ddZona(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarZonas();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));


    }

    private void ddPropiedad(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarPropiedadJuridica();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));


    }

    private void ddAsesores(DropDownList drop)
    {
        Asesores usu = new Asesores();
        DataTable datos = usu.cargarAsesores();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddRectores(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarRectores();
        drop.DataSource = datos;
        drop.DataTextField = "nombrecompleto";
        drop.DataValueField = "identificacion";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void cargarInfoIE(string dane, DataRow datoinsasesor)
    {
       

        DataRow datoie = inst.buscarInstitucionxNitTodo(dane);

        if(datoie != null)
        {
            txtDANE.Text = datoie["dane"].ToString();
            txtNomInstitucion.Text = datoie["nombre"].ToString();

            DataRow datrector = inst.buscarDatosRector(datoie["idrector"].ToString());
            if(datrector != null)
            {
                dropNomRector.SelectedValue = datrector["identificacion"].ToString(); 
            }

           
            txtDireccion.Text = datoie["direccion"].ToString();
            txtTelefono.Text = datoie["telefono"].ToString();
            txtFax.Text = datoie["fax"].ToString();
            txtemail.Text = datoie["email"].ToString();
            txtWeb.Text = datoie["web"].ToString();

            dropCiudad.SelectedValue =  datoie["codmunicipio"].ToString();

            DataRow dpto = inst.buscarDepartamentoxCiudad(datoie["codmunicipio"].ToString());
            if(dpto != null)
                dropDepartamento.SelectedValue = dpto["cod"].ToString();

            dropZona.SelectedValue = datoie["codzona"].ToString();
            dropPropiedadJuridica.SelectedValue = datoie["codpropiedadjuridica"].ToString();
            txtActivas.Text = datoie["nrosedesactivas"].ToString();
            txtInactivas.Text = datoie["nrosedesinactivas"].ToString();

            if(datoinsasesor != null)
                dropAsesor.SelectedValue = datoinsasesor["codasesor"].ToString();
        }
        else
        {
            mostrarmensaje("error","El Usuario institucional no registra relación con alguna IE");
        }

    }
    protected void btnGuardarInfoBasica_Click(object sender, EventArgs e)
    {

    

        if (lblCodRol.Text == "7")
        {
            DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);
            if (datoie != null)
            {
                DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                if (dato != null)
                {
                    if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                    {
                        if (validarchkJornadas(chkJornadas))
                        {

                            //EliminarNivelesEnsenanza(dato["codigo"].ToString());
                            //AgregarNivelesEnsenanza(dato["codigo"].ToString(), chkNivelesEnsenaza);

                            //EliminarProgramaEstrategiaModelosPreescolar(dato["codigo"].ToString());
                            //AgregarProgramaEstrategiaModelosPreescolar(dato["codigo"].ToString(), chkProgramaEstrategiaModeloPreescolar);

                            //EliminarProgramaEstrategiaModelosPrimaria(dato["codigo"].ToString());
                            //AgregarProgramaEstrategiaModelosPrimaria(dato["codigo"].ToString(), chkProgramaEstrategiaModeloPrimaria);

                            //EliminarProgramaEstrategiaModelosSecundaria(dato["codigo"].ToString());
                            //AgregarProgramaEstrategiaModelosSecundaria(dato["codigo"].ToString(), chkProgramaEstrategiaModeloSecundaria);

                            //EliminarProgramaEstrategiaModelosMedia(dato["codigo"].ToString());
                            //AgregarProgramaEstrategiaModelosMedia(dato["codigo"].ToString(), chkProgramaEstrategiaModeloMedia);

                            //EliminarProgramaEstrategiaModelosMedia(dato["codigo"].ToString());
                            //AgregarProgramaEstrategiaModelosMedia(dato["codigo"].ToString(), chkProgramaEstrategiaModeloMedia);

                            //EliminarJornadas(dato["codigo"].ToString());
                            //AgregarJornadas(dato["codigo"].ToString(), chkJornadas);

                            //EliminarRecursosHumanos(dato["codigo"].ToString());
                            //AgregarRecursosHumanos(dato["codigo"].ToString());

                            //EliminarDocentexNivel(dato["codigo"].ToString());
                            //AgregarDocentexNivelEnsenianza(dato["codigo"].ToString());

                            //AgregarDocentexCaracterAcademico(dato["codigo"].ToString());Se quita por que ya está en el botón 04

                            EliminarDocentexCaracterTecnico(dato["codigo"].ToString());
                            AgregarDocentexCaracterTecnico(dato["codigo"].ToString());

                            PanelFormularioC600B.Visible = true;
                            PanelInstrumento001A.Visible = false;
                            btnGuardarInfoBasica.Visible = false;

                            cargarSedesC600B(datoie["codigo"].ToString());
                            lblCodInstitucion.Text = datoie["codigo"].ToString();

                            lblCodAsesor.Text = dato["codasesor"].ToString();
                            Session["codinsasesor"] = dato["codigo"].ToString();
                            lblCodInstAsesor.Text = Session["codinsasesor"].ToString();

                        }
                        else
                        {
                            mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                        }
                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                    }
                }
                else
                {
                    if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                    {
                        if (validarchkJornadas(chkJornadas))
                        {
                            DataRow codinstasesor = lb.AgregarDatoInstitucionAsesorLineaBase(datoie["codigo"].ToString(), dropAsesor.SelectedValue);
                            if (codinstasesor != null)
                            {
                                lblCodInstAsesor.Text = codinstasesor["codigo"].ToString();
                            }

                            //EliminarNivelesEnsenanza(lblCodInstAsesor.Text);
                            //AgregarNivelesEnsenanza(lblCodInstAsesor.Text, chkNivelesEnsenaza);

                            //EliminarProgramaEstrategiaModelosPreescolar(lblCodInstAsesor.Text);
                            //AgregarProgramaEstrategiaModelosPreescolar(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloPreescolar);

                            //EliminarProgramaEstrategiaModelosPrimaria(lblCodInstAsesor.Text);
                            //AgregarProgramaEstrategiaModelosPrimaria(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloPrimaria);

                            //EliminarProgramaEstrategiaModelosSecundaria(lblCodInstAsesor.Text);
                            //AgregarProgramaEstrategiaModelosSecundaria(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloSecundaria);

                            //EliminarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text);
                            //AgregarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloMedia);

                            //EliminarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text);
                            //AgregarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloMedia);

                            //EliminarJornadas(lblCodInstAsesor.Text);
                            //AgregarJornadas(lblCodInstAsesor.Text, chkJornadas);

                            //EliminarRecursosHumanos(lblCodInstAsesor.Text);
                            //AgregarRecursosHumanos(lblCodInstAsesor.Text);

                            //EliminarDocentexNivel(lblCodInstAsesor.Text);
                            //AgregarDocentexNivelEnsenianza(lblCodInstAsesor.Text);

                            //AgregarDocentexCaracterAcademico(lblCodInstAsesor.Text);Se quita por que ya está en el botón 04
                            EliminarDocentexCaracterTecnico(dato["codigo"].ToString());
                            AgregarDocentexCaracterTecnico(lblCodInstAsesor.Text);

                            PanelFormularioC600B.Visible = true;
                            PanelInstrumento001A.Visible = false;
                            btnGuardarInfoBasica.Visible = false;

                            cargarSedesC600B(datoie["codigo"].ToString());

                            //DateTime localDateTime = DateTime.Now;
                            //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                            //string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                            //lb.agregarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), horares, "001A");
                        }
                        else
                        {
                            mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                        }
                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                    }
                }


            }
        }
        else if (lblCodRol.Text == "9")
        {

            PanelInstrumento001A.Visible = false;
            PanelInstrumento01.Visible = false;
            PanelFormularioC600B.Visible = true;
            PanelCaracterizacion.Visible = false;
        }

       
        
    }
    private bool validarchkNivelesEnsenaza(CheckBoxList combo)
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
    private bool validarchkJornadas(CheckBoxList combo)
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
    private void EliminarNivelesEnsenanza(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "1", "001", "0")) { }
    }
    private void AgregarNivelesEnsenanza(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "1", combo.Items[i].Value, "001","0");
            }
        }
    }
    private void EliminarProgramaEstrategiaModelosPreescolar(string id)
     {
            LineaBase user = new LineaBase();
            if (user.eliminarRespuestaCerradaInstitucional(id, "2", "001", "1")) { }
             if(user.eliminarRespuestaAbiertaInstitucional(id,"2.1","001")){}
     }
    private void AgregarProgramaEstrategiaModelosPreescolar(string id, CheckBoxList combo)
    {
            LineaBase user = new LineaBase();
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i].Selected)
                {
                    user.AgregarRespuestaCerradaInstitucional(id, "2", combo.Items[i].Value, "001","1");
                }
            }

        if(txtCualProgramaEstrategiaModeloPreescolar.Text != null)
        {
            user.AgregarRespuestaAbiertaInstitucional(id,"2.1",txtCualProgramaEstrategiaModeloPreescolar.Text,"001");
        }
     }
    private void EliminarProgramaEstrategiaModelosPrimaria(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "2", "001", "2")) { }
        if (user.eliminarRespuestaAbiertaInstitucional(id, "2.2", "001")) { }
    }
    private void AgregarProgramaEstrategiaModelosPrimaria(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "2", combo.Items[i].Value, "001", "2");
            }
        }

        if (txtCualProgramaEstrategiaModeloPrimaria.Text != null)
        {
            user.AgregarRespuestaAbiertaInstitucional(id, "2.2", txtCualProgramaEstrategiaModeloPrimaria.Text, "001");
        }
    }
    private void EliminarProgramaEstrategiaModelosSecundaria(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "2", "001", "3")) { }
        if (user.eliminarRespuestaAbiertaInstitucional(id, "2.3", "001")) { }
    }
    private void AgregarProgramaEstrategiaModelosSecundaria(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "2", combo.Items[i].Value, "001", "3");
            }
        }

        if (txtCualProgramaEstrategiaModeloSecundaria.Text != null)
        {
            user.AgregarRespuestaAbiertaInstitucional(id, "2.3", txtCualProgramaEstrategiaModeloSecundaria.Text, "001");
        }
    }
    private void EliminarProgramaEstrategiaModelosMedia(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "2", "001", "4")) { }
        if (user.eliminarRespuestaAbiertaInstitucional(id, "2.4", "001")) { }
    }
    private void AgregarProgramaEstrategiaModelosMedia(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "2", combo.Items[i].Value, "001", "4");
            }
        }

        if (txtCualProgramaEstrategiaModeloMedia.Text != null)
        {
            user.AgregarRespuestaAbiertaInstitucional(id, "2.4", txtCualProgramaEstrategiaModeloMedia.Text, "001");
        }
    }
    private void EliminarJornadas(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "3", "001", "0")) { }
    }
    private void AgregarJornadas(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "3", combo.Items[i].Value, "001", "0");
            }
        }

     
    }

    private void EliminarRecursosHumanos(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "1")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "2")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "3")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "4")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "5")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "6")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "7")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "8")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "9")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "10")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "11")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "4", "001", "12")) { }

    }
    private void AgregarRecursosHumanos(string id)
    {
        LineaBase user = new LineaBase();

        if(txtDirectivoDocente.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtDirectivoDocente.Text, "001", "1");
        }
        else
        {
             user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "1");
        }
        if(txtDocentes.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtDocentes.Text, "001", "2");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "2");
        }
        if(txtDocenteEspecial.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtDocenteEspecial.Text, "001", "3");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "3");
        }
        if(txtDocentesEtno.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtDocentesEtno.Text, "001", "4");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "4");
        }
        if(txtDirectivos.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtDirectivos.Text, "001", "5");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "5");
        }
        if(txtConsejeros.Text != "")
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", txtConsejeros.Text, "001", "6");
        }
        else
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "6");
        }
        if(txtMedicos.Text != "")
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", txtMedicos.Text, "001", "7");
        }
        else
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "7");
        }
        if(txtAdministrativos.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtAdministrativos.Text, "001", "8");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "8");
        }
        if(txtProfesionales.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtProfesionales.Text, "001", "9");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "9");
        }
        if(txtTutores.Text != "")
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", txtTutores.Text, "001", "10");
        }
        else
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "10");
        }
        if(txtAula.Text != "")
        {
                user.AgregarRespuestaCerradaInstitucional(id, "4", txtAula.Text, "001", "11");
        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "11");
        }
        if(txtOtros.Text != "")
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", txtOtros.Text, "001", "12");

        }
        else
        {
            user.AgregarRespuestaCerradaInstitucional(id, "4", "0", "001", "12");
        }
                                              

    }
    private void EliminarDocentexNivel(string id)
    {
        LineaBase user = new LineaBase();
        ////if (user.eliminarRespuestasPreguntasInstrumento001A(id, "5", "001A", "1")) { }
        if (lb.eliminarRespuestasPreguntasInstrumento001A(id,"001A","5")) { }//Elimina todas las respuestas de lbase_respuestarecursoshumano total h, total m
      

    }
    private void AgregarDocentexNivelEnsenianza(string id)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Bachillerato pedagógico", "Preescolar", txtBachiHomPreescolar.Text, txtBachiMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Bachillerato pedagógico", "Básica primaria", txtBachiHomPrimaria.Text, txtBachiMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Bachillerato pedagógico", "Básica secundaria", txtBachiHomSecundaria.Text, txtBachiMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Bachillerato pedagógico", "Media", txtBachiHomMedia.Text, txtBachiMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Normalista superior", "Preescolar", txtSuperiorHomPreescolar.Text, txtSuperiorMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Normalista superior", "Básica primaria", txtSuperiorHomPrimaria.Text, txtSuperiorMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Normalista superior", "Básica secundaria", txtSuperiorHomSecundaria.Text, txtSuperiorMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Normalista superior", "Media", txtSuperiorHomMedia.Text, txtSuperiorMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro bachillerato", "Preescolar", txtOtroBachiHomPreescolar.Text, txtOtroBachiMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro bachillerato", "Básica primaria", txtOtroBachiHomPrimaria.Text, txtOtroBachiMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro bachillerato", "Básica secundaria", txtOtroBachiHomSecundaria.Text, txtOtroBachiMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro bachillerato", "Media", txtOtroBachiHomMedia.Text, txtOtroBachiMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Pedagógico", "Preescolar", txtTecPedagoHomPreescolar.Text, txtTecPedagoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Pedagógico", "Básica primaria", txtTecPedagoHomPrimaria.Text, txtTecPedagoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Pedagógico", "Básica secundaria", txtTecPedagoHomSecundaria.Text, txtTecPedagoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Pedagógico", "Media", txtTecPedagoHomMedia.Text, txtTecPedagoMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Otro", "Preescolar", txtOtroPedagoHomPreescolar.Text, txtOtroPedagoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Otro", "Básica primaria", txtOtroPedagoHomPrimaria.Text, txtOtroPedagoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Otro", "Básica secundaria", txtOtroPedagoHomSecundaria.Text, txtOtroPedagoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Técnico o tecnológico Otro", "Media", txtOtroPedagoHomMedia.Text, txtOtroPedagoMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Pedagógico", "Preescolar", txtProfPedagoHomPreescolar.Text, txtProfPedagoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Pedagógico", "Básica primaria", txtProfPedagoHomPrimaria.Text, txtProfPedagoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Pedagógico", "Básica secundaria", txtProfPedagoHomSecundaria.Text, txtProfPedagoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Pedagógico", "Media", txtProfPedagoHomMedia.Text, txtProfPedagoMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Otro", "Preescolar", txtProfOtroPedagoHomPreescolar.Text, txtProfOtroPedagoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Otro", "Básica primaria", txtProfOtroPedagoHomPrimaria.Text, txtProfOtroPedagoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Otro", "Básica secundaria", txtProfOtroPedagoHomSecundaria.Text, txtProfOtroPedagoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Profesional Otro", "Media", txtProfOtroPedagoHomMedia.Text, txtProfOtroPedagoMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Pedagógico", "Preescolar", txtPosPedagoHomPreescolar.Text, txtPosPedagoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Pedagógico", "Básica primaria", txtPosPedagoHomPrimaria.Text, txtPosPedagoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Pedagógico", "Básica secundaria", txtPosPedagoHomSecundaria.Text, txtPosPedagoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Pedagógico", "Media", txtPosPedagoHomMedia.Text, txtPosPedagoMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Otro", "Preescolar", txtPosOtroPedagoHomPreescolar.Text, txtPosOtroPedagoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Otro", "Básica primaria", txtPosOtroPedagoHomPrimaria.Text, txtPosOtroPedagoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Otro", "Básica secundaria", txtPosOtroPedagoHomSecundaria.Text, txtPosOtroPedagoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Posgrado Otro", "Media", txtPosOtroPedagoHomMedia.Text, txtPosOtroPedagoMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro", "Preescolar", txtOtroCualMujPreescolar.Text, txtOtroCualHomPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro", "Básica primaria", txtOtroCualHomPrimaria.Text, txtOtroCualMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro", "Básica secundaria", txtOtroCualHomSecundaria.Text, txtOtroCualMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "5", "001A", "Otro", "Media", txtOtroCualHomMedia.Text, txtOtroCualMujMedia.Text);
        
    }

    private void EliminarDocentexCaracterAcademico(string id)
    {
        if (lb.eliminarRespuestasPreguntasInstrumento001A(id, "001A", "6.1")) { }//Elimina todas las respuestas de lbase_respuestarecursoshumano total h, total m
    }
    
    private void AgregarDocentexCaracterAcademico(string id)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Todas las áreas", "Preescolar", txtTodasAreasHomPreescolar.Text, txtTodasAreasMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Todas las áreas", "Básica primaria", txtTodasAreasHomPrimaria.Text, txtTodasAreasMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Todas las áreas", "Básica secundaria", txtTodasAreasHomSecundaria.Text, txtTodasAreasMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Todas las áreas", "Media", txtTodasAreasHomMedia.Text, txtTodasAreasMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias naturales y educación ambiental", "Preescolar", txtNaturalesHomPreescolar.Text, txtNaturalesMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias naturales y educación ambiental", "Básica primaria", txtNaturalesHomPrimaria.Text, txtNaturalesMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias naturales y educación ambiental", "Básica secundaria", txtNaturalesHomSecundaria.Text, txtNaturalesMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias naturales y educación ambiental", "Media", txtNaturalesHomMedia.Text, txtNaturalesMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Preescolar", txtSocialesHomPreescolar.Text, txtSocialesMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Básica primaria", txtSocialesHomPrimaria.Text, txtSocialesMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Básica secundaria", txtSocialesHomSecundaria.Text, txtSocialesMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Media", txtSocialesHomMedia.Text, txtSocialesMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación artística", "Preescolar", txtArtisticaHomPreescolar.Text, txtArtisticaMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación artística", "Básica primaria", txtArtisticaHomPrimaria.Text, txtArtisticaMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación artística", "Básica secundaria", txtArtisticaHomSecundaria.Text, txtArtisticaMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación artística", "Media", txtArtisticaHomMedia.Text, txtArtisticaMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación ética y en valores humanos", "Preescolar", txtEticaHomPreescolar.Text, txtEticaMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación ética y en valores humanos", "Básica primaria", txtEticaHomPrimaria.Text, txtEticaMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación ética y en valores humanos", "Básica secundaria", txtEticaHomSecundaria.Text, txtEticaMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación ética y en valores humanos", "Media", txtEticaHomMedia.Text, txtEticaMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación física, recreación y deportes", "Preescolar", txtDeportesHomPreescolar.Text, txtDeportesMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación física, recreación y deportes", "Básica primaria", txtDeportesHomPrimaria.Text, txtDeportesMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación física, recreación y deportes", "Básica secundaria", txtDeportesHomSecundaria.Text, txtDeportesMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación física, recreación y deportes", "Media", txtDeportesHomMedia.Text, txtDeportesMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación religiosa", "Preescolar", txtReligiosaHomPreescolar.Text, txtReligiosaMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación religiosa", "Básica primaria", txtReligiosaHomPrimaria.Text, txtReligiosaMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación religiosa", "Básica secundaria", txtReligiosaHomSecundaria.Text, txtReligiosaMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Educación religiosa", "Media", txtReligiosaHomMedia.Text, txtReligiosaMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Preescolar", txtCastellanaHomPreescolar.Text, txtCastellanaMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Básica primaria", txtCastellanaHomPrimaria.Text, txtCastellanaMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Básica secundaria", txtCastellanaHomSecundaria.Text, txtCastellanaMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Media", txtCastellanaHomMedia.Text, txtCastellanaMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Matemáticas", "Preescolar", txtMatematicasHomPreescolar.Text, txtMatematicasMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Matemáticas", "Básica primaria", txtMatematicasHomPrimaria.Text, txtMatematicasMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Matemáticas", "Básica secundaria", txtMatematicasHomSecundaria.Text, txtMatematicasMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Matemáticas", "Media", txtMatematicasHomMedia.Text, txtMatematicasMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Tecnología e informática", "Preescolar", txtInformaticaHomPreescolar.Text, txtInformaticaMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Tecnología e informática", "Básica primaria", txtInformaticaHomPrimaria.Text, txtInformaticaMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Tecnología e informática", "Básica secundaria", txtInformaticaHomSecundaria.Text, txtInformaticaMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Tecnología e informática", "Media", txtInformaticaHomMedia.Text, txtInformaticaMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias económicas", "Preescolar", txtEconomicasHomPreescolar.Text, txtEconomicasMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias económicas", "Básica primaria", txtEconomicasHomPrimaria.Text, txtEconomicasMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias económicas", "Básica secundaria", txtEconomicasHomSecundaria.Text, txtEconomicasMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias económicas", "Media", txtEconomicasHomMedia.Text, txtEconomicasMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias políticas", "Preescolar", txtPoliticasHomPreescolar.Text, txtPoliticasMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias políticas", "Básica primaria", txtPoliticasHomPrimaria.Text, txtPoliticasMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias políticas", "Básica secundaria", txtPoliticasHomSecundaria.Text, txtPoliticasMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Ciencias políticas", "Media", txtPoliticasHomMedia.Text, txtPoliticasMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Filosofía", "Preescolar", txtFilosofiaHomPreescolar.Text, txtFilosofiaMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Filosofía", "Básica primaria", txtFilosofiaHomPrimaria.Text, txtFilosofiaMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Filosofía", "Básica secundaria", txtFilosofiaHomSecundaria.Text, txtFilosofiaMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Filosofía", "Media", txtFilosofiaHomMedia.Text, txtFilosofiaMujMedia.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Otra académico", "Preescolar", txtOtraAcademicoHomPreescolar.Text, txtOtraAcademicoMujPreescolar.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Otra académico", "Básica primaria", txtOtraAcademicoHomPrimaria.Text, txtOtraAcademicoMujPrimaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Otra académico", "Básica secundaria", txtOtraAcademicoHomSecundaria.Text, txtOtraAcademicoMujSecundaria.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.1", "001A", "Otra académico", "Media", txtOtraAcademicoHomMedia.Text, txtOtraAcademicoMujMedia.Text);

    }
    private void EliminarDocentexCaracterTecnico(string id)
    {
        if (lb.eliminarRespuestasPreguntasInstrumento001A(id, "001A", "6.2")) { }//Elimina todas las respuestas de lbase_respuestarecursoshumano total h, total m
    }
    private void AgregarDocentexCaracterTecnico(string id)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Agrícola", "", txtAgricolaHom.Text, txtAgricolaMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Pecuario", "", txtPecuarioHom.Text, txtPecuarioMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Otra académico", "", txtAgroOtraHom.Text, txtAgroOtraMuj.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Contabilidad", "", txtContablidadHom.Text, txtContablidadMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Finanzas", "", txtFinanzasHom.Text, txtFinanzasMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Administración y gestión", "", txtAdminGestionHom.Text, txtAdminGestionMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Administración", "", txtAdministracionHom.Text, txtAdministracionMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Salud", "", txtSaludHom.Text, txtSaludMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Ambiental", "", txtAmbientalHom.Text, txtAmbientalMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Otra comercial", "", txtOtraComercialHom.Text, txtOtraComercialMuj.Text);

        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Electricidad", "", txtElectridadHom.Text, txtElectridadMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Electrónica", "", txtElectronicaHom.Text, txtElectronicaMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Mecánica industrial", "", txtMecaIndustrialHom.Text, txtMecaIndustrialMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Mecánica automotriz", "", txtMecaAutomotrizHom.Text, txtMecaAutomotrizMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Metalistería", "", txtMetalisteriaHom.Text, txtMetalisteriaMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Metalmecánica", "", txtMetalmecanicaHom.Text, txtMetalmecanicaMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Ebanistería", "", txtEbanisterHom.Text, txtEbanisteriaMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Fundición", "", txtFundicionHom.Text, txtFundicionMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Construcciones civiles", "", txtCivilesHom.Text, txtCivilesMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Diseño mecánico", "", txtDisMecanicoHom.Text, txtDisMecanicoMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Diseño gráfico", "", txtDisGraficaHom.Text, txtDisGraficaMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Diseño arquitectónico", "", txtDisArquitectonicoHom.Text, txtDisArquitectonicoMuj.Text);
        user.AgregarRespuestaPreguntasIntrumento001A(id, "6.2", "001A", "Otra industrial", "", txtOtraIndustrialHom.Text, txtOtraIndustrialMuj.Text);



    }
    protected void btnIniciarInfoBasica_Click(object sender, EventArgs e)
    {

            if (lblCodRol.Text == "7")
            {
                 DateTime localDateTime = DateTime.Now;
                DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                string horares = utcDateTime.ToString("yyyy-MM-dd");
                //DataRow fecha = lb.buscarFechaInstrumento("0", horares);//Valida la fecha de ingreso de los instrumentos

                ddCiudad(dropCiudad);
                ddDepartamentos(dropDepartamento);
                ddZona(dropZona);
                ddPropiedad(dropPropiedadJuridica);
                ddAsesores(dropAsesor);

                //if (fecha != null)
                //{
                    DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);
                    if (datoie != null)
                    {
                        DataRow datoInsAsesor = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                        if (datoInsAsesor != null)
                        {
                            cargarInfoIE(lblCodDANE.Text, datoInsAsesor);
                            cargarInformacionInstrumento001A(datoie["codigo"].ToString());
                            

                            //mostrarmensaje("error", "Ya los datos fueron ingresados");
                            btnGuardarInfoBasica.Visible = true;
                            PanelInstrumento001A.Visible = true;

                            PanelInstrumento01.Visible = false;
                          
                            PanelCaracterizacion.Visible = false;
                            btnGuardar.Visible = false;

                        }
                        else
                        {
                           

                            btnGuardarInfoBasica.Visible = true;
                            PanelInstrumento001A.Visible = true;

                            PanelInstrumento01.Visible = false;
                            PanelCaracterizacion.Visible = false;

                            //Cargar información de la institución
                            cargarInfoIE(lblCodDANE.Text, datoInsAsesor);
                        }
                    }
                    else
                    {
                        mostrarmensaje("error", "El usuario no está asociado a una Institución");
                    }
                //}
                //else
                //{
                //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
                //}
   
            }
            else if (lblCodRol.Text == "9")
            {
                PanelInstrumento001A.Visible = true;
                btnGuardarInfoBasica.Visible = true;
                PanelInstrumento01.Visible = false;
                PanelFormularioC600B.Visible = false;
                PanelCaracterizacion.Visible = false;
            }
     
    }

    private void cargarInformacionInstrumento001A(string codinstitucion)
    {
        DataRow datasesor = lb.buscarInstitucionxAsesor(codinstitucion);
        if(datasesor != null)
        {
            dropAsesor.SelectedValue = datasesor["codasesor"].ToString();
            cargarNivelesEnsenianza(datasesor["codigo"].ToString(), chkNivelesEnsenaza);
            cargarProgramaEstrategiaModeloPreescolar(datasesor["codigo"].ToString(), chkProgramaEstrategiaModeloPreescolar);
            cargarProgramaEstrategiaModeloPrimaria(datasesor["codigo"].ToString(), chkProgramaEstrategiaModeloPrimaria);
            cargarProgramaEstrategiaModeloSecundaria(datasesor["codigo"].ToString(), chkProgramaEstrategiaModeloSecundaria);
            cargarProgramaEstrategiaModeloMedia(datasesor["codigo"].ToString(), chkProgramaEstrategiaModeloMedia);
            cargarJornadasInstitucion(datasesor["codigo"].ToString(), chkJornadas);
            cargarInfoRecursosHumanos(datasesor["codigo"].ToString());
            cargarPersonalUltimoNivelEducativo(datasesor["codigo"].ToString());
            cargarAreasDeEnsenianza6_1(datasesor["codigo"].ToString());
            cargarAreasDeEnsenianza6_2(datasesor["codigo"].ToString());
        }
      

    }

    private void cargarNivelesEnsenianza(string codinsasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor,"1","0","001");

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
    private void cargarProgramaEstrategiaModeloPreescolar(string codinsasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "2", "1", "001");

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
        DataRow comentario = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "2.1", "001");
        if (comentario != null)
        {
            txtCualProgramaEstrategiaModeloPreescolar.Text = comentario["comentario"].ToString();
        }

    }
    private void cargarProgramaEstrategiaModeloPrimaria(string codinsasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "2", "2", "001");

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
        DataRow comentario = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "2.2", "001");
        if (comentario != null)
        {
            txtCualProgramaEstrategiaModeloPrimaria.Text = comentario["comentario"].ToString();
        }

    }
    private void cargarProgramaEstrategiaModeloSecundaria(string codinsasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "2", "3", "001");

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

        DataRow comentario = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor,"2.3","001");
        if(comentario != null)
        {
            txtCualProgramaEstrategiaModeloSecundaria.Text = comentario["comentario"].ToString();
        }

    }
    private void cargarProgramaEstrategiaModeloMedia(string codinsasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "2", "4", "001");

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
        DataRow comentario = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "2.4", "001");
        if (comentario != null)
        {
            txtCualProgramaEstrategiaModeloMedia.Text = comentario["comentario"].ToString();
        }

    }
    private void cargarJornadasInstitucion(string codinsasesor, CheckBoxList chk)
    {
        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "3", "0", "001");

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
    private void cargarInfoRecursosHumanos(string codinsasesor)
    {
        DataTable escogido1 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "1", "001");
        if (escogido1 != null && escogido1.Rows.Count > 0) { txtDirectivoDocente.Text = escogido1.Rows[0]["respuesta"].ToString(); }
        else{ txtDirectivoDocente.Text = "0"; }

        DataTable escogido2 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "2", "001");
        if (escogido2 != null && escogido2.Rows.Count > 0) { txtDocentes.Text = escogido2.Rows[0]["respuesta"].ToString(); }
        else { txtDocentes.Text = "0"; }

        DataTable escogido3 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "3", "001");
        if (escogido3 != null && escogido3.Rows.Count > 0) { txtDocenteEspecial.Text = escogido3.Rows[0]["respuesta"].ToString(); }
        else { txtDocenteEspecial.Text = "0"; }

        DataTable escogido4 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "4", "001");
        if (escogido4 != null && escogido4.Rows.Count > 0) { txtDocentesEtno.Text = escogido4.Rows[0]["respuesta"].ToString(); }
        else { txtDocentesEtno.Text = "0"; }

        DataTable escogido5 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "5", "001");
        if (escogido5 != null && escogido5.Rows.Count > 0) { txtDirectivos.Text = escogido5.Rows[0]["respuesta"].ToString(); }
        else { txtDirectivos.Text = "0"; }

        DataTable escogido6 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "6", "001");
        if (escogido6 != null && escogido6.Rows.Count > 0) { txtConsejeros.Text = escogido6.Rows[0]["respuesta"].ToString(); }
        else { txtConsejeros.Text = "0"; }

        DataTable escogido7 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "7", "001");
        if (escogido7 != null && escogido7.Rows.Count > 0) { txtMedicos.Text = escogido7.Rows[0]["respuesta"].ToString(); }
        else { txtMedicos.Text = "0"; }

        DataTable escogido8 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "8", "001");
        if (escogido8 != null && escogido8.Rows.Count > 0) { txtAdministrativos.Text = escogido8.Rows[0]["respuesta"].ToString(); }
        else { txtAdministrativos.Text = "0"; }

        DataTable escogido9 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "9", "001");
        if (escogido9 != null && escogido9.Rows.Count > 0) { txtProfesionales.Text = escogido9.Rows[0]["respuesta"].ToString(); }
        else { txtProfesionales.Text = "0"; }

        DataTable escogido10 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "10", "001");
        if (escogido10 != null && escogido10.Rows.Count > 0) { txtTutores.Text = escogido10.Rows[0]["respuesta"].ToString(); }
        else { txtTutores.Text = "0"; }

        DataTable escogido11 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "11", "001");
        if (escogido11 != null && escogido11.Rows.Count > 0) { txtAula.Text = escogido11.Rows[0]["respuesta"].ToString(); }
        else { txtAula.Text = "0"; }

        DataTable escogido12 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "4", "12", "001");
        if (escogido12 != null && escogido12.Rows.Count > 0) { txtOtros.Text = escogido12.Rows[0]["respuesta"].ToString(); }
        else { txtOtros.Text = "0"; }
   
    }

    private void cargarPersonalUltimoNivelEducativo(string codinsasesor)
    {
        //Bachillerato pedagógico
        DataRow pedagoPre =  lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Bachillerato pedagógico", "Preescolar");
        if (pedagoPre != null) { txtBachiHomPreescolar.Text = pedagoPre["thombre"].ToString(); txtBachiMujPreescolar.Text = pedagoPre["tmujer"].ToString(); }

        DataRow pedagopri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Bachillerato pedagógico", "Básica primaria");
        if (pedagopri != null) { txtBachiHomPrimaria.Text = pedagopri["thombre"].ToString(); txtBachiMujPrimaria.Text = pedagopri["tmujer"].ToString(); }

        DataRow pedagosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Bachillerato pedagógico", "Básica secundaria");
        if (pedagosecun != null) { txtBachiHomSecundaria.Text = pedagosecun["thombre"].ToString(); txtBachiMujSecundaria.Text = pedagosecun["tmujer"].ToString(); }

        DataRow pedagoMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Bachillerato pedagógico", "Media");
        if (pedagoMedia != null) { txtBachiHomMedia.Text = pedagoMedia["thombre"].ToString(); txtBachiMujMedia.Text = pedagoMedia["tmujer"].ToString(); }

        //Normalista superior
        DataRow normalPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Normalista superior", "Preescolar");
        if (normalPre != null) { txtSuperiorHomPreescolar.Text = normalPre["thombre"].ToString(); txtSuperiorMujPreescolar.Text = normalPre["tmujer"].ToString(); }

        DataRow normalpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Normalista superior", "Básica primaria");
        if (normalpri != null) { txtSuperiorHomPrimaria.Text = normalpri["thombre"].ToString(); txtSuperiorMujPrimaria.Text = normalpri["tmujer"].ToString(); }

        DataRow normalsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Normalista superior", "Básica secundaria");
        if (normalsecun != null) { txtSuperiorHomSecundaria.Text = normalsecun["thombre"].ToString(); txtSuperiorMujSecundaria.Text = normalsecun["tmujer"].ToString(); }

        DataRow normalMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Normalista superior", "Media");
        if (normalMedia != null) { txtSuperiorHomMedia.Text = normalMedia["thombre"].ToString(); txtSuperiorMujMedia.Text = normalMedia["tmujer"].ToString(); }

        //Otro bachillerato
        DataRow otroPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro bachillerato", "Preescolar");
        if (otroPre != null) { txtOtroBachiHomPreescolar.Text = otroPre["thombre"].ToString(); txtOtroBachiMujPreescolar.Text = otroPre["tmujer"].ToString(); }

        DataRow otropri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro bachillerato", "Básica primaria");
        if (otropri != null) { txtOtroBachiHomPrimaria.Text = otropri["thombre"].ToString(); txtOtroBachiMujPrimaria.Text = otropri["tmujer"].ToString(); }

        DataRow otrosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro bachillerato", "Básica secundaria");
        if (otrosecun != null) { txtOtroBachiHomSecundaria.Text = otrosecun["thombre"].ToString(); txtOtroBachiMujSecundaria.Text = otrosecun["tmujer"].ToString(); }

        DataRow otroMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro bachillerato", "Media");
        if (otroMedia != null) { txtOtroBachiHomMedia.Text = otroMedia["thombre"].ToString(); txtOtroBachiMujMedia.Text = otroMedia["tmujer"].ToString(); }

        //Técnico o tecnológico Pedagógico
        DataRow tecPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Pedagógico", "Preescolar");
        if (tecPre != null) { txtTecPedagoHomPreescolar.Text = tecPre["thombre"].ToString(); txtTecPedagoMujPreescolar.Text = tecPre["tmujer"].ToString(); }

        DataRow tecpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Pedagógico", "Básica primaria");
        if (tecpri != null) { txtTecPedagoHomPrimaria.Text = tecpri["thombre"].ToString(); txtTecPedagoMujPrimaria.Text = tecpri["tmujer"].ToString(); }

        DataRow tecsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Pedagógico", "Básica secundaria");
        if (tecsecun != null) { txtTecPedagoHomSecundaria.Text = tecsecun["thombre"].ToString(); txtTecPedagoMujSecundaria.Text = tecsecun["tmujer"].ToString(); }

        DataRow tecMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Pedagógico", "Media");
        if (tecMedia != null) { txtTecPedagoHomMedia.Text = tecMedia["thombre"].ToString(); txtTecPedagoMujMedia.Text = tecMedia["tmujer"].ToString(); }

        //Técnico o tecnológico Otro
        DataRow tecotroPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Otro", "Preescolar");
        if (tecotroPre != null) { txtOtroPedagoHomPreescolar.Text = tecotroPre["thombre"].ToString(); txtOtroPedagoMujPreescolar.Text = tecotroPre["tmujer"].ToString(); }

        DataRow tecotropri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Otro", "Básica primaria");
        if (tecotropri != null) { txtOtroPedagoHomPrimaria.Text = tecotropri["thombre"].ToString(); txtOtroPedagoMujPrimaria.Text = tecotropri["tmujer"].ToString(); }

        DataRow tecotrosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Otro", "Básica secundaria");
        if (tecotrosecun != null) { txtOtroPedagoHomSecundaria.Text = tecotrosecun["thombre"].ToString(); txtOtroPedagoMujSecundaria.Text = tecotrosecun["tmujer"].ToString(); }

        DataRow tecotroMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Técnico o tecnológico Otro", "Media");
        if (tecotroMedia != null) { txtOtroPedagoHomMedia.Text = tecotroMedia["thombre"].ToString(); txtOtroPedagoMujMedia.Text = tecotroMedia["tmujer"].ToString(); }

        //Profesional Pedagógico
        DataRow proPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Pedagógico", "Preescolar");
        if (proPre != null) { txtProfPedagoHomPreescolar.Text = proPre["thombre"].ToString(); txtProfPedagoMujPreescolar.Text = proPre["tmujer"].ToString(); }

        DataRow propri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Pedagógico", "Básica primaria");
        if (propri != null) { txtProfPedagoHomPrimaria.Text = propri["thombre"].ToString(); txtProfPedagoMujPrimaria.Text = propri["tmujer"].ToString(); }

        DataRow prosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Pedagógico", "Básica secundaria");
        if (prosecun != null) { txtProfPedagoHomSecundaria.Text = prosecun["thombre"].ToString(); txtProfPedagoMujSecundaria.Text = prosecun["tmujer"].ToString(); }

        DataRow proMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Pedagógico", "Media");
        if (proMedia != null) { txtProfPedagoHomMedia.Text = proMedia["thombre"].ToString(); txtProfPedagoMujMedia.Text = proMedia["tmujer"].ToString(); }

        //Profesional Otro
        DataRow proOtroPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Otro", "Preescolar");
        if (proOtroPre != null) { txtProfOtroPedagoHomPreescolar.Text = proOtroPre["thombre"].ToString(); txtProfOtroPedagoMujPreescolar.Text = proOtroPre["tmujer"].ToString(); }

        DataRow proOtropri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Otro", "Básica primaria");
        if (proOtropri != null) { txtProfOtroPedagoHomPrimaria.Text = proOtropri["thombre"].ToString(); txtProfOtroPedagoMujPrimaria.Text = proOtropri["tmujer"].ToString(); }

        DataRow proOtrosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Otro", "Básica secundaria");
        if (proOtrosecun != null) { txtProfOtroPedagoHomSecundaria.Text = proOtrosecun["thombre"].ToString(); txtProfOtroPedagoMujSecundaria.Text = proOtrosecun["tmujer"].ToString(); }

        DataRow proOtroMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Profesional Otro", "Media");
        if (proOtroMedia != null) { txtProfOtroPedagoHomMedia.Text = proOtroMedia["thombre"].ToString(); txtProfOtroPedagoMujMedia.Text = proOtroMedia["tmujer"].ToString(); }

        //Posgrado Pedagógico
        DataRow posPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Pedagógico", "Preescolar");
        if (posPre != null) { txtPosPedagoHomPreescolar.Text = posPre["thombre"].ToString(); txtPosPedagoMujPreescolar.Text = posPre["tmujer"].ToString(); }

        DataRow pospri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Pedagógico", "Básica primaria");
        if (pospri != null) { txtPosPedagoHomPrimaria.Text = pospri["thombre"].ToString(); txtPosPedagoMujPrimaria.Text = pospri["tmujer"].ToString(); }

        DataRow possecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Pedagógico", "Básica secundaria");
        if (possecun != null) { txtPosPedagoHomSecundaria.Text = possecun["thombre"].ToString(); txtPosPedagoMujSecundaria.Text = possecun["tmujer"].ToString(); }

        DataRow posMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Pedagógico", "Media");
        if (posMedia != null) { txtPosPedagoHomMedia.Text = posMedia["thombre"].ToString(); txtPosPedagoMujMedia.Text = posMedia["tmujer"].ToString(); }

        //Posgrado Otro
        DataRow posOtroPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Otro", "Preescolar");
        if (posOtroPre != null) { txtPosOtroPedagoHomPreescolar.Text = posOtroPre["thombre"].ToString(); txtPosOtroPedagoMujPreescolar.Text = posOtroPre["tmujer"].ToString(); }

        DataRow posotropri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Otro", "Básica primaria");
        if (posotropri != null) { txtPosOtroPedagoHomPrimaria.Text = posotropri["thombre"].ToString(); txtPosOtroPedagoMujPrimaria.Text = posotropri["tmujer"].ToString(); }

        DataRow posotrosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Otro", "Básica secundaria");
        if (posotrosecun != null) { txtPosOtroPedagoHomSecundaria.Text = posotrosecun["thombre"].ToString(); txtPosOtroPedagoMujSecundaria.Text = posotrosecun["tmujer"].ToString(); }

        DataRow posotroMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Posgrado Otro", "Media");
        if (posotroMedia != null) { txtPosOtroPedagoHomMedia.Text = posotroMedia["thombre"].ToString(); txtPosOtroPedagoMujMedia.Text = posotroMedia["tmujer"].ToString(); }

        // Otro Cual
        DataRow OtrocualPre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro", "Preescolar");
        if (OtrocualPre != null) { txtOtroCualHomPreescolar.Text = OtrocualPre["thombre"].ToString(); txtOtroCualMujPreescolar.Text = OtrocualPre["tmujer"].ToString(); }

        DataRow otrocualpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro", "Básica primaria");
        if (otrocualpri != null) { txtOtroCualHomPrimaria.Text = otrocualpri["thombre"].ToString(); txtOtroCualMujPrimaria.Text = otrocualpri["tmujer"].ToString(); }

        DataRow otrocualsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro", "Básica secundaria");
        if (otrocualsecun != null) { txtOtroCualHomSecundaria.Text = otrocualsecun["thombre"].ToString(); txtOtroCualMujSecundaria.Text = otrocualsecun["tmujer"].ToString(); }

        DataRow otrocualMedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "5", "001A", "Otro", "Media");
        if (otrocualMedia != null) { txtOtroCualHomMedia.Text = otrocualMedia["thombre"].ToString(); txtOtroCualMujMedia.Text = otrocualMedia["tmujer"].ToString(); }
    }

    private void cargarAreasDeEnsenianza6_1(string codinsasesor)
    {
        //Todas las áreas
        DataRow areaspre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Todas las áreas", "Preescolar");
        if (areaspre != null) { txtTodasAreasHomPreescolar.Text = areaspre["thombre"].ToString(); txtTodasAreasMujPreescolar.Text = areaspre["tmujer"].ToString(); }

        DataRow areaspri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Todas las áreas", "Básica primaria");
        if (areaspri != null) { txtTodasAreasHomPrimaria.Text = areaspri["thombre"].ToString(); txtTodasAreasMujPrimaria.Text = areaspri["tmujer"].ToString(); }

        DataRow areassecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Todas las áreas", "Básica secundaria");
        if (areassecun != null) { txtTodasAreasHomSecundaria.Text = areassecun["thombre"].ToString(); txtTodasAreasMujSecundaria.Text = areassecun["tmujer"].ToString(); }

        DataRow areasmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Todas las áreas", "Media");
        if (areasmedia != null) { txtTodasAreasHomMedia.Text = areasmedia["thombre"].ToString(); txtTodasAreasMujMedia.Text = areasmedia["tmujer"].ToString(); }

        //Ciencias naturales y educación ambiental
        DataRow natupre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias naturales y educación ambiental", "Preescolar");
        if (natupre != null) { txtNaturalesHomPreescolar.Text = natupre["thombre"].ToString(); txtNaturalesMujPreescolar.Text = natupre["tmujer"].ToString(); }

        DataRow natupri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias naturales y educación ambiental", "Básica primaria");
        if (natupri != null) { txtNaturalesHomPrimaria.Text = natupri["thombre"].ToString(); txtNaturalesMujPrimaria.Text = natupri["tmujer"].ToString(); }

        DataRow natusecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias naturales y educación ambiental", "Básica secundaria");
        if (natusecun != null) { txtNaturalesHomSecundaria.Text = natusecun["thombre"].ToString(); txtNaturalesMujSecundaria.Text = natusecun["tmujer"].ToString(); }

        DataRow natumedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias naturales y educación ambiental", "Media");
        if (natumedia != null) { txtNaturalesHomMedia.Text = natumedia["thombre"].ToString(); txtNaturalesMujMedia.Text = natumedia["tmujer"].ToString(); }

        //Ciencias sociales, historia, geografía, constitución política y democracia
        DataRow socpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Preescolar");
        if (socpre != null) { txtSocialesHomPreescolar.Text = socpre["thombre"].ToString(); txtSocialesMujPreescolar.Text = socpre["tmujer"].ToString(); }

        DataRow socpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Básica primaria");
        if (socpri != null) { txtSocialesHomPrimaria.Text = socpri["thombre"].ToString(); txtSocialesMujPrimaria.Text = socpri["tmujer"].ToString(); }

        DataRow socisecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Básica secundaria");
        if (socisecun != null) { txtSocialesHomSecundaria.Text = socisecun["thombre"].ToString(); txtSocialesMujSecundaria.Text = socisecun["tmujer"].ToString(); }

        DataRow socimedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias sociales, historia, geografía, constitución política y democracia", "Media");
        if (socimedia != null) { txtSocialesHomMedia.Text = socimedia["thombre"].ToString(); txtSocialesMujMedia.Text = socimedia["tmujer"].ToString(); }

        //Educación artística
        DataRow artpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación artística", "Preescolar");
        if (artpre != null) { txtArtisticaHomPreescolar.Text = artpre["thombre"].ToString(); txtArtisticaMujPreescolar.Text = artpre["tmujer"].ToString(); }

        DataRow artpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación artística", "Básica primaria");
        if (artpri != null) { txtArtisticaHomPrimaria.Text = artpri["thombre"].ToString(); txtArtisticaMujPrimaria.Text = artpri["tmujer"].ToString(); }

        DataRow artsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación artística", "Básica secundaria");
        if (artsecun != null) { txtArtisticaHomSecundaria.Text = artsecun["thombre"].ToString(); txtArtisticaMujSecundaria.Text = artsecun["tmujer"].ToString(); }

        DataRow artmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación artística", "Media");
        if (artmedia != null) { txtArtisticaHomMedia.Text = artmedia["thombre"].ToString(); txtArtisticaMujMedia.Text = artmedia["tmujer"].ToString(); }

        //Educación ética y en valores humanos
        DataRow etipre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación ética y en valores humanos", "Preescolar");
        if (etipre != null) { txtEticaHomPreescolar.Text = etipre["thombre"].ToString(); txtEticaMujPreescolar.Text = etipre["tmujer"].ToString(); }

        DataRow etipri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación ética y en valores humanos", "Básica primaria");
        if (etipri != null) { txtEticaHomPrimaria.Text = etipri["thombre"].ToString(); txtEticaMujPrimaria.Text = etipri["tmujer"].ToString(); }

        DataRow etisecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación ética y en valores humanos", "Básica secundaria");
        if (etisecun != null) { txtEticaHomSecundaria.Text = etisecun["thombre"].ToString(); txtEticaMujSecundaria.Text = etisecun["tmujer"].ToString(); }

        DataRow etimedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación ética y en valores humanos", "Media");
        if (etimedia != null) { txtEticaHomMedia.Text = etimedia["thombre"].ToString(); txtEticaMujMedia.Text = etimedia["tmujer"].ToString(); }

        //Educación física, recreación y deportes
        DataRow fispre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación física, recreación y deportes", "Preescolar");
        if (fispre != null) { txtDeportesHomPreescolar.Text = fispre["thombre"].ToString(); txtDeportesMujPreescolar.Text = fispre["tmujer"].ToString(); }

        DataRow fispri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación física, recreación y deportes", "Básica primaria");
        if (fispri != null) { txtDeportesHomPrimaria.Text = fispri["thombre"].ToString(); txtDeportesMujPrimaria.Text = fispri["tmujer"].ToString(); }

        DataRow fissecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación física, recreación y deportes", "Básica secundaria");
        if (fissecun != null) { txtDeportesHomSecundaria.Text = fissecun["thombre"].ToString(); txtDeportesMujSecundaria.Text = fissecun["tmujer"].ToString(); }

        DataRow fismedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación física, recreación y deportes", "Media");
        if (fismedia != null) { txtDeportesHomMedia.Text = fismedia["thombre"].ToString(); txtDeportesMujMedia.Text = fismedia["tmujer"].ToString(); }

        //Educación religiosa
        DataRow relpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación religiosa", "Preescolar");
        if (relpre != null) { txtReligiosaHomPreescolar.Text = relpre["thombre"].ToString(); txtReligiosaMujPreescolar.Text = relpre["tmujer"].ToString(); }

        DataRow relpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación religiosa", "Básica primaria");
        if (relpri != null) { txtReligiosaHomPrimaria.Text = relpri["thombre"].ToString(); txtReligiosaMujPrimaria.Text = relpri["tmujer"].ToString(); }

        DataRow relsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación religiosa", "Básica secundaria");
        if (relsecun != null) { txtReligiosaHomSecundaria.Text = relsecun["thombre"].ToString(); txtReligiosaMujSecundaria.Text = relsecun["tmujer"].ToString(); }

        DataRow relmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Educación religiosa", "Media");
        if (relmedia != null) { txtReligiosaHomMedia.Text = relmedia["thombre"].ToString(); txtReligiosaMujMedia.Text = relmedia["tmujer"].ToString(); }

        //Humanidades, lengua castellana e idiomas extranjeros
        DataRow caspre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Preescolar");
        if (caspre != null) { txtCastellanaHomPreescolar.Text = caspre["thombre"].ToString(); txtCastellanaMujPreescolar.Text = caspre["tmujer"].ToString(); }

        DataRow caspri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Básica primaria");
        if (caspri != null) { txtCastellanaHomPrimaria.Text = caspri["thombre"].ToString(); txtCastellanaMujPrimaria.Text = caspri["tmujer"].ToString(); }

        DataRow cassecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Básica secundaria");
        if (cassecun != null) { txtCastellanaHomSecundaria.Text = cassecun["thombre"].ToString(); txtCastellanaMujSecundaria.Text = cassecun["tmujer"].ToString(); }

        DataRow casmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Humanidades, lengua castellana e idiomas extranjeros", "Media");
        if (casmedia != null) { txtCastellanaHomMedia.Text = casmedia["thombre"].ToString(); txtCastellanaMujMedia.Text = casmedia["tmujer"].ToString(); }

        //Matemáticas
        DataRow matpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Matemáticas", "Preescolar");
        if (matpre != null) { txtMatematicasHomPreescolar.Text = matpre["thombre"].ToString(); txtMatematicasMujPreescolar.Text = matpre["tmujer"].ToString(); }

        DataRow matpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Matemáticas", "Básica primaria");
        if (matpri != null) { txtMatematicasHomPrimaria.Text = matpri["thombre"].ToString(); txtMatematicasMujPrimaria.Text = matpri["tmujer"].ToString(); }

        DataRow matsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Matemáticas", "Básica secundaria");
        if (matsecun != null) { txtMatematicasHomSecundaria.Text = matsecun["thombre"].ToString(); txtMatematicasMujSecundaria.Text = matsecun["tmujer"].ToString(); }

        DataRow matmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Matemáticas", "Media");
        if (matmedia != null) { txtMatematicasHomMedia.Text = matmedia["thombre"].ToString(); txtMatematicasMujMedia.Text = matmedia["tmujer"].ToString(); }

        //Tecnología e informática
        DataRow tecpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Tecnología e informática", "Preescolar");
        if (tecpre != null) { txtInformaticaHomPreescolar.Text = tecpre["thombre"].ToString(); txtInformaticaMujPreescolar.Text = tecpre["tmujer"].ToString(); }

        DataRow tecpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Tecnología e informática", "Básica primaria");
        if (tecpri != null) { txtInformaticaHomPrimaria.Text = tecpri["thombre"].ToString(); txtInformaticaMujPrimaria.Text = tecpri["tmujer"].ToString(); }

        DataRow tecsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Tecnología e informática", "Básica secundaria");
        if (tecsecun != null) { txtInformaticaHomSecundaria.Text = tecsecun["thombre"].ToString(); txtInformaticaMujSecundaria.Text = tecsecun["tmujer"].ToString(); }

        DataRow tecmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Tecnología e informática", "Media");
        if (tecmedia != null) { txtInformaticaHomMedia.Text = tecmedia["thombre"].ToString(); txtInformaticaMujMedia.Text = tecmedia["tmujer"].ToString(); }

        //Ciencias económicas
        DataRow ecopre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias económicas", "Preescolar");
        if (ecopre != null) { txtEconomicasHomPreescolar.Text = ecopre["thombre"].ToString(); txtEconomicasMujPreescolar.Text = ecopre["tmujer"].ToString(); }

        DataRow ecopri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias económicas", "Básica primaria");
        if (ecopri != null) { txtEconomicasHomPrimaria.Text = ecopri["thombre"].ToString(); txtEconomicasMujPrimaria.Text = ecopri["tmujer"].ToString(); }

        DataRow ecosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias económicas", "Básica secundaria");
        if (ecosecun != null) { txtEconomicasHomSecundaria.Text = ecosecun["thombre"].ToString(); txtEconomicasMujSecundaria.Text = ecosecun["tmujer"].ToString(); }

        DataRow ecomedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias económicas", "Media");
        if (ecomedia != null) { txtEconomicasHomMedia.Text = ecomedia["thombre"].ToString(); txtEconomicasMujMedia.Text = ecomedia["tmujer"].ToString(); }

        //Ciencias políticas
        DataRow polpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias políticas", "Preescolar");
        if (polpre != null) { txtPoliticasHomPreescolar.Text = polpre["thombre"].ToString(); txtPoliticasMujPreescolar.Text = polpre["tmujer"].ToString(); }

        DataRow polpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias políticas", "Básica primaria");
        if (polpri != null) { txtPoliticasHomPrimaria.Text = polpri["thombre"].ToString(); txtPoliticasMujPrimaria.Text = polpri["tmujer"].ToString(); }

        DataRow polsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias políticas", "Básica secundaria");
        if (polsecun != null) { txtPoliticasHomSecundaria.Text = polsecun["thombre"].ToString(); txtPoliticasMujSecundaria.Text = polsecun["tmujer"].ToString(); }

        DataRow polmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Ciencias políticas", "Media");
        if (polmedia != null) { txtPoliticasHomMedia.Text = polmedia["thombre"].ToString(); txtPoliticasMujMedia.Text = polmedia["tmujer"].ToString(); }

        //Filosofía
        DataRow filpre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Filosofía", "Preescolar");
        if (filpre != null) { txtFilosofiaHomPreescolar.Text = filpre["thombre"].ToString(); txtFilosofiaMujPreescolar.Text = filpre["tmujer"].ToString(); }

        DataRow filpri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Filosofía", "Básica primaria");
        if (filpri != null) { txtFilosofiaHomPrimaria.Text = filpri["thombre"].ToString(); txtFilosofiaMujPrimaria.Text = filpri["tmujer"].ToString(); }

        DataRow filsecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Filosofía", "Básica secundaria");
        if (filsecun != null) { txtFilosofiaHomSecundaria.Text = filsecun["thombre"].ToString(); txtFilosofiaMujSecundaria.Text = filsecun["tmujer"].ToString(); }

        DataRow filmedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Filosofía", "Media");
        if (filmedia != null) { txtFilosofiaHomMedia.Text = filmedia["thombre"].ToString(); txtFilosofiaMujMedia.Text = filmedia["tmujer"].ToString(); }

        //Otra académico
        DataRow otropre = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Otra académico", "Preescolar");
        if (otropre != null) { txtOtraAcademicoHomPreescolar.Text = otropre["thombre"].ToString(); txtOtraAcademicoMujPreescolar.Text = otropre["tmujer"].ToString(); }

        DataRow otropri = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Otra académico", "Básica primaria");
        if (otropri != null) { txtOtraAcademicoHomPrimaria.Text = otropri["thombre"].ToString(); txtOtraAcademicoMujPrimaria.Text = otropri["tmujer"].ToString(); }

        DataRow otrosecun = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Otra académico", "Básica secundaria");
        if (otrosecun != null) { txtOtraAcademicoHomSecundaria.Text = otrosecun["thombre"].ToString(); txtOtraAcademicoMujSecundaria.Text = otrosecun["tmujer"].ToString(); }

        DataRow otromedia = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.1", "001A", "Otra académico", "Media");
        if (otromedia != null) { txtOtraAcademicoHomMedia.Text = otromedia["thombre"].ToString(); txtOtraAcademicoMujMedia.Text = otromedia["tmujer"].ToString(); }
    }
    private void cargarAreasDeEnsenianza6_2(string codinsasesor)
    {
        //Agrícola
        DataRow Agrícola = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Agrícola", "");
        if (Agrícola != null) { txtAgricolaHom.Text = Agrícola["thombre"].ToString(); txtAgricolaMuj.Text = Agrícola["tmujer"].ToString(); }

        //Pecuario
        DataRow Pecuario = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Pecuario", "");
        if (Pecuario != null) { txtPecuarioHom.Text = Pecuario["thombre"].ToString(); txtPecuarioMuj.Text = Pecuario["tmujer"].ToString(); }

        //Otra académico
        DataRow otra = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Otra académico", "");
        if (otra != null) { txtAgroOtraHom.Text = otra["thombre"].ToString(); txtAgroOtraMuj.Text = otra["tmujer"].ToString(); }

        //Contabilidad
        DataRow Contabilidad = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Contabilidad", "");
        if (Contabilidad != null) { txtContablidadHom.Text = Contabilidad["thombre"].ToString(); txtContablidadMuj.Text = Contabilidad["tmujer"].ToString(); }

         //Finanzas
        DataRow Finanzas = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Finanzas", "");
        if (Finanzas != null) { txtFinanzasHom.Text = Finanzas["thombre"].ToString(); txtFinanzasMuj.Text = Finanzas["tmujer"].ToString(); }

        //Administración y gestión
        DataRow gestión = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Administración y gestión", "");
        if (gestión != null) { txtAdminGestionHom.Text = gestión["thombre"].ToString(); txtAdminGestionMuj.Text = gestión["tmujer"].ToString(); }

        //Administración
        DataRow Administración = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Administración", "");
        if (Administración != null) { txtAdministracionHom.Text = Administración["thombre"].ToString(); txtAdministracionMuj.Text = Administración["tmujer"].ToString(); }

        //Salud
        DataRow Salud = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Salud", "");
        if (Salud != null) { txtSaludHom.Text = Salud["thombre"].ToString(); txtSaludMuj.Text = Salud["tmujer"].ToString(); }

        //Ambiental
        DataRow Ambiental = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Ambiental", "");
        if (Ambiental != null) { txtAmbientalHom.Text = Ambiental["thombre"].ToString(); txtAmbientalMuj.Text = Ambiental["tmujer"].ToString(); }

        //Otra comercial
        DataRow comercial = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Otra comercial", "");
        if (comercial != null) { txtOtraComercialHom.Text = comercial["thombre"].ToString(); txtOtraComercialMuj.Text = comercial["tmujer"].ToString(); }

        //Electricidad
        DataRow Electricidad = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Electricidad", "");
        if (Electricidad != null) { txtElectridadHom.Text = Electricidad["thombre"].ToString(); txtElectridadMuj.Text = Electricidad["tmujer"].ToString(); }

        //Electrónica
        DataRow Electrónica = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Electrónica", "");
        if (Electrónica != null) { txtElectronicaHom.Text = Electrónica["thombre"].ToString(); txtElectronicaMuj.Text = Electrónica["tmujer"].ToString(); }

        //Mecánica industrial
        DataRow MecInd = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Mecánica industrial", "");
        if (MecInd != null) { txtMecaIndustrialHom.Text = MecInd["thombre"].ToString(); txtMecaIndustrialMuj.Text = MecInd["tmujer"].ToString(); }

        //Mecánica automotriz
        DataRow automotriz = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Mecánica automotriz", "");
        if (automotriz != null) { txtMecaAutomotrizHom.Text = automotriz["thombre"].ToString(); txtMecaAutomotrizMuj.Text = automotriz["tmujer"].ToString(); }

        //Metalistería
        DataRow Metalistería = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Metalistería", "");
        if (Metalistería != null) { txtMetalisteriaHom.Text = Metalistería["thombre"].ToString(); txtMetalisteriaMuj.Text = Metalistería["tmujer"].ToString(); }

        //Metalmecánica
        DataRow Metalmecánica = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Metalmecánica", "");
        if (Metalmecánica != null) { txtMetalmecanicaHom.Text = Metalmecánica["thombre"].ToString(); txtMetalmecanicaMuj.Text = Metalmecánica["tmujer"].ToString(); }

        //Ebanistería
        DataRow Ebanistería = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Ebanistería", "");
        if (Ebanistería != null) { txtEbanisterHom.Text = Ebanistería["thombre"].ToString(); txtEbanisteriaMuj.Text = Ebanistería["tmujer"].ToString(); }

        //Fundición
        DataRow Fundición = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Fundición", "");
        if (Fundición != null) { txtFundicionHom.Text = Fundición["thombre"].ToString(); txtFundicionMuj.Text = Fundición["tmujer"].ToString(); }

        //Construcciones civiles
        DataRow Construcciones = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Construcciones civiles", "");
        if (Construcciones != null) { txtCivilesHom.Text = Construcciones["thombre"].ToString(); txtCivilesMuj.Text = Construcciones["tmujer"].ToString(); }

        //Diseño mecánico
        DataRow dismeca = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Diseño mecánico", "");
        if (dismeca != null) { txtDisMecanicoHom.Text = dismeca["thombre"].ToString(); txtDisMecanicoMuj.Text = dismeca["tmujer"].ToString(); }

        //Diseño gráfico
        DataRow gráfico = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Diseño gráfico", "");
        if (gráfico != null) { txtDisGraficaHom.Text = gráfico["thombre"].ToString(); txtDisGraficaMuj.Text = gráfico["tmujer"].ToString(); }

        //Diseño arquitectónico
        DataRow arquitectónico = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Diseño arquitectónico", "");
        if (arquitectónico != null) { txtDisArquitectonicoHom.Text = arquitectónico["thombre"].ToString(); txtDisArquitectonicoMuj.Text = arquitectónico["tmujer"].ToString(); }

        //Otra industrial
        DataRow oindu = lb.cargarRespuestaInstitucionalRecursosH(codinsasesor, "6.2", "001A", "Otra industrial", "");
        if (oindu != null) { txtOtraIndustrialHom.Text = oindu["thombre"].ToString(); txtOtraIndustrialMuj.Text = oindu["tmujer"].ToString(); }



     
    }

    protected void btnIniciarInfoBasica2_Click(object sender, EventArgs e)
    {

        if (lblCodRol.Text == "7")
        {
            DateTime localDateTime = DateTime.Now;
            DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
            string horares = utcDateTime.ToString("yyyy-MM-dd");
            //DataRow fecha = lb.buscarFechaInstrumento("1", horares);

            
            //if (fecha != null)
            //{
               
                DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);
                if (datoie != null)
                {
                    //DataRow intentos = lb.buscarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), "001A");

                    //if (intentos != null)
                    //{
                        DataRow ase = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                        if (ase != null)
                        {
                            DataTable fusion = lb.cargarRespuestasCerradasInstrumento001A(ase["codigo"].ToString(), "1", "0", "01");
                            if(fusion != null && fusion.Rows.Count>0)
                            {
                                txtNroSedesenFusion.Text = fusion.Rows[0]["respuesta"].ToString();
                            }
                            cargarSedes(ase["codinstitucion"].ToString());
                            lblCodInstitucion.Text = ase["codinstitucion"].ToString();
                            lblCodAsesor.Text = ase["codasesor"].ToString();
                            lblCodInstAsesor.Text = ase["codigo"].ToString();

                            PanelInstrumento01.Visible = true;
                            

                            PanelInstrumento001A.Visible = false;
                            PanelCaracterizacion.Visible = false;

                            PanelFormularioC600B.Visible = false;

                        }
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "Debes diligenciar el instrumento 001A");
                    //}
                   
                }
                else
                {
                    mostrarmensaje("error", "El usuario no está asociado a una Institución");
                }
            //}
            //else
            //{
            //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
            //}
 
        }
        else if (lblCodRol.Text == "9")
        {

            PanelInstrumento001A.Visible = false;
            Response.Redirect("lineabaseSede.aspx");
            //PanelInstrumento01.Visible = true;
            PanelFormularioC600B.Visible = false;
            PanelCaracterizacion.Visible = false;
        }
    }

    private void cargarSedes(string codcliente)
    {
        GridSedes.DataSource = inst.cargarSedesInstitucion(codcliente);
        GridSedes.DataBind();
        if (GridSedes.Rows.Count > 0)
        {
            //btnAgregarSede1.Visible = false;
        }
        else
        {
            //btnAgregarSede1.Visible = true;
        }
    }
    private void cargarSedesC600B(string codcliente)
    {
        GridSedesC600B.DataSource = inst.cargarSedesInstitucion(codcliente);
        GridSedesC600B.DataBind();
      
    }

    protected void imgVer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nit = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string conseSede = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string nombresede = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        string direccion = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
        string codmunicipio = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
        string codzona = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
        string sede = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);
        string codinstitucion = HttpUtility.HtmlDecode(gvrow.Cells[11].Text);

        lblCodSede.Text = codsede;
        txtNitSede.Text = nit;
        txtNombreSede.Text = nombresede;
        txtConseSede.Text = conseSede;
        txtDireccionSede.Text = direccion;

        lblCodInstitucion.Text = codinstitucion;


        dropMunicipio.SelectedValue = codmunicipio;
        dropTipoSede.SelectedValue = sede;
        dropZonaEdit.SelectedValue = codzona;

        this.PanelVerDependencias_ModalPopupExtender.Show();
        txtNitSede.Enabled = false;
        txtConseSede.Enabled = false;
        txtNombreSede.Enabled = false;
        txtDireccionSede.Enabled = false;
        dropZonaEdit.Enabled = false;
        dropMunicipio.Enabled = false;
        dropTipoSede.Enabled = false;
        btnEditarSede.Visible = false;
 
    }

    protected void btnAgregarSede_Click(object sender, EventArgs e)
    {
        ddZona(DropZonaAdd);
        ddCiudad(dropMunicipioAddSede);
        this.PanelAgregarSede_ModalPopupExtender.Show();
    }

    protected void GridSedes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //string cod = GridSedes.Rows[e.RowIndex].Cells[1].Text;
        //client.eliminarSedeProyecto(cod);//Eliminamos la relacion de la sede con el proyecto.
        //if (client.eliminarSedeCliente(cod))
        //{
        //    cargarSedes(lblCodCliente.Text);
        //    mostrarmensaje("exito", "Eliminado Correctamente");
        //}
        //else
        //{
        //    mostrarmensaje("error", "ERROR: Esta sede tiene información relacionada.");
        //}
    }

    protected void btnEditarSede_Click(object sender, EventArgs e)
    {
        if (inst.editarSedeInstitucion(txtConseSede.Text, txtNitSede.Text,txtNombreSede.Text, dropZonaEdit.SelectedValue, txtDireccionSede.Text, dropMunicipio.SelectedValue,dropTipoSede.SelectedValue, lblCodSede.Text))
        {
            cargarSedesC600B(lblCodInstitucion.Text);
            mostrarmensaje("exito", "Editado correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro editar");
            this.PanelVerDependencias_ModalPopupExtender.Show();
        }
    }

    protected void btnAddSede_Click(object sender, EventArgs e)
    {
        if (inst.agregarSedeInstitucionBool(txtNitAddSede.Text, lblCodInstitucion.Text, txtNombreAddSede.Text.ToUpper(), DropZonaAdd.SelectedValue, txtDireccionAddSede.Text, dropMunicipioAddSede.SelectedValue, txtConseSedeAdd.Text, dropTipoAddSede.SelectedValue))
        {
            mostrarmensaje("exito", "Agregado correctamente");
            cargarSedes(lblCodInstitucion.Text);
            txtNitAddSede.Text = string.Empty;
            txtNombreAddSede.Text = string.Empty;
            txtConseSedeAdd.Text = string.Empty;
            DropZonaAdd.SelectedIndex = 0;
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

    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nit = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string conseSede = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string nombresede = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        string direccion = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
        string codmunicipio = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
        string codzona = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
        string sede = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);

        lblCodSede.Text = codsede;
        txtNitSede.Text = nit;
        txtNombreSede.Text = nombresede;
        txtConseSede.Text = conseSede;
        txtDireccionSede.Text = direccion;

            
            dropMunicipio.SelectedValue = codmunicipio;
            dropTipoSede.SelectedValue = sede;
            dropZonaEdit.SelectedValue = codzona;
      
        this.PanelVerDependencias_ModalPopupExtender.Show();
        btnEditarSede.Visible = true;
        txtNitSede.Enabled = true;
        txtConseSede.Enabled = true;
        txtNombreSede.Enabled = true;
        txtDireccionSede.Enabled = true;
        dropZonaEdit.Enabled = true;
        dropMunicipio.Enabled = true;
        dropTipoSede.Enabled = true;
        btnEditarSede.Visible = true;

    }

    protected void imgInfoxSedeC600B_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string codinstitucion = HttpUtility.HtmlDecode(gvrow.Cells[11].Text);

        Response.Redirect("lineabaseSedeC600B.aspx?cs=" + codsede + "&ca=" + lblCodAsesor.Text + "&ci=" + codinstitucion + "&cia=" + lblCodInstAsesor.Text);

    }

    protected void imgInfoxSede_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codusuario = GridSedes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string codinstitucion = HttpUtility.HtmlDecode(gvrow.Cells[11].Text);

        Response.Redirect("lineabaseSede.aspx?cs=" + codsede + "&ca=" + lblCodAsesor.Text + "&ci=" + codinstitucion + "&cia=" + lblCodInstAsesor.Text);

    }

    protected void btnAgregarInfoSede_Click(object sender, EventArgs e)
    {
       DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);



       if (datoie != null)
       {
           DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
           if (dato != null)
           {
               if (lb.AgregarRespuestaCerradaInstitucional(dato["codigo"].ToString(), "1", txtNroSedesenFusion.Text, "01", "0"))
               {
                   //DateTime localDateTime = DateTime.Now;
                   //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                   //string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                   // DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);

                   // if (datoie != null)
                   // {
                   //     DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                   //     if (dato != null)
                   //     {
                   //         lb.agregarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), horares, "02");
                   //     }
                   // }

                   mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
               }
           }
       }
       
    }

    //Instrumento 02
    int numero = 8;
    string[] pregunta;
    private void ddCargarPreguntas()
    {
        lblCodPregunta1.Text = "1";
        lblPregunta1.Text = ". Cuál es el énfasis formativo del Proyecto Educativo Institucional – PEI?";
        lblCodPregunta2.Text = "2";
        lblPregunta2.Text = ". Cuál es el modelo educativo de la sede beneficiada, teniendo en cuenta la clasificación del Ministerio de Educación Nacional –MEN- :";
        lblCodPregunta3.Text = "3";
        lblPregunta3.Text = ". En el PEI y/o en los procesos institucionales se considera alguno de los siguientes aspectos:";
        lblCodPregunta4.Text = "4";
        lblPregunta4.Text = ". Cuáles son las principales prácticas de innovación educativa que se realizan en la sede beneficiada?.";
        lblCodPregunta5.Text = "5";
        lblPregunta5.Text = " . En el PEI se promueve la investigación dentro de las prácticas institucionales?";
        lblCodPregunta6.Text = "6";
        lblPregunta6.Text = ". En el PEI se promueve el uso de las TICs como parte de las prácticas institucionales?";
        lblCodPregunta7.Text = "7";
        lblPregunta7.Text = " . El PEI pretende formar en competencias para el uso y apropiación de la TIC?";
        lblCodPregunta8.Text = "8";
        lblPregunta8.Text = ". ¿Cuáles competencias en apropiación de TIC pretende formar el currículo, según la propuesta del MEN?";

        lblCodSubPregunta1.Text = "1";
        lblSubPregunta1.Text = ". La investigación docente";
        lblCodSubPregunta2.Text = "2";
        lblSubPregunta2.Text = ". La investigación de los estudiantes";
        lblCodSubPregunta3.Text = "3";
        lblSubPregunta3.Text = ". Uso de Las TIC de los Docentes";
        lblCodSubPregunta4.Text = "4";
        lblSubPregunta4.Text = ". Uso de Las TIC de los Estudiantes";

        pregunta = new string[numero];

        pregunta[0] = lblCodPregunta1.Text;
        pregunta[1] = lblCodPregunta2.Text;
        pregunta[2] = lblCodPregunta3.Text;
        pregunta[3] = lblCodPregunta4.Text;
        pregunta[4] = lblCodPregunta5.Text;
        pregunta[5] = lblCodPregunta6.Text;
        pregunta[6] = lblCodPregunta7.Text;
        pregunta[7] = lblCodPregunta8.Text;
    }

    protected void btnIniciarCaracterizacion_Click(Object sender, EventArgs e)
    {
        LineaBase lb = new LineaBase();

        if (lblCodRol.Text == "7")
        {


            //DateTime localDateTime = DateTime.Now;
            //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
            //string horares = utcDateTime.ToString("yyyy-MM-dd");
            //DataRow fecha = lb.buscarFechaInstrumento("1", horares);


            //if (fecha != null)
            //{

            DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);
            if (datoie != null)
            {
                //    DataRow intentos = lb.buscarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), "01");

                //    if (intentos != null)
                //    {
                        PanelCaracterizacion.Visible = true;
                        btnGuardar.Visible = true;

                        PanelInstrumento001A.Visible = false;
                        PanelInstrumento01.Visible = false;
                        
                DataRow ase = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                if (ase != null)
                {
                    cargarInformacionPreguntasIntrumento02(ase["codigo"].ToString());
                }
                        
                        //ddAsesores(dropAsesor02);


                        //Instrumento 02
                        ddCargarPreguntas();

                        //DataRow confitime = lb.buscarconfiSINOTiempo();

                        //if (confitime != null)
                        //{
                        //    if (confitime["tiempoenlineabase"].ToString() == "Si")
                        //    {
                        //        //Tiempo de ejecución
                        //        DataRow datime = lb.buscarConfiTiempo();

                        //        if (datime != null)
                        //        {
                        //            int time = Convert.ToInt32(datime["tiempo"].ToString()) * 60;
                        //            Session["tiempo"] = time;
                        //            ////Paneltime.Visible = true;
                        //        }
                        //    }
                        //}
                    //}
                    //else
                    //{
                    //    mostrarmensaje("error", "Debes diligenciar el instrumento 01");
                    //}

                }
                else
                {
                    mostrarmensaje("error", "El usuario no está asociado a una Institución");
                }
            //}
            //else
            //{
            //    mostrarmensaje("error", "El Administrador no ha configurado la fecha de diligenciamiento de este instrumento.");
            //}


        }
        else if (lblCodRol.Text == "9")
        {

            PanelInstrumento001A.Visible = false;
            PanelInstrumento01.Visible = false;
            PanelFormularioC600B.Visible = false;
            PanelCaracterizacion.Visible = true;
        }

    }

    private void cargarRespuestasEnfasisPEI(string codinsasesor, CheckBoxList chk)
    {
         

        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor,"1","0","02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

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
    private void cargarRespuestasModeloEducativo(string codinsasesor, CheckBoxList chk)
    {


        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "2", "0", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

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

        DataRow escogido2 = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "2", "02");//codreginstitucion,codpregunta,codinstrumento

        if (escogido2 != null)
        {
            txtDescripcionIEP.Text = escogido2["comentario"].ToString();
        }

    }

    private void cargarProcesosInstitucionalesPEI(string codinsasesor)
    {


        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "3", "1", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataTable escogido2 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "3", "2", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataTable escogido3 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "3", "3", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        DataTable escogido4 = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "3", "4", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        if(escogido != null && escogido.Rows.Count > 0)
        {
            rbInvestigacionDocente.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }
         if(escogido2 != null && escogido2.Rows.Count > 0)
        {
            rbInvestigacionEstudiante.SelectedValue = escogido2.Rows[0]["respuesta"].ToString();
        }
        if(escogido3 != null && escogido3.Rows.Count > 0)
        {
            rbticDocente.SelectedValue = escogido3.Rows[0]["respuesta"].ToString();
        }
        if(escogido4 != null && escogido4.Rows.Count > 0)
        {
            rbticEstudiante.SelectedValue = escogido4.Rows[0]["respuesta"].ToString();
        }
        
        
       
    }


    private void cargarPrincipalesPracticas(string codinsasesor)
    {


        DataRow escogido2 = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "4", "02");//codreginstitucion,codpregunta,codinstrumento

        if (escogido2 != null)
        {
            txtPrincipalesPracticas.Text = escogido2["comentario"].ToString();
        }

    }

    private void cargarInvestigacionPEI(string codinsasesor)
    {


        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "5", "0", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento
        if(escogido != null && escogido.Rows.Count > 0)
        {
            rbinvestigacionPEI.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }
        
    }
    private void cargarUsoTIC(string codinsasesor, CheckBoxList chk)
    {


        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "6", "0", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

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

        DataRow escogido2 = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "6", "02");//codreginstitucion,codpregunta,codinstrumento

        if (escogido2 != null)
        {
            txtUsoTIC.Text = escogido2["comentario"].ToString();
        }

    }

    private void cargarCompetenciasTIC(string codinsasesor)
    {


        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "7", "0", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

        if (escogido != null && escogido.Rows.Count > 0)
        {
           rbCompetenciaTIC.SelectedValue = escogido.Rows[0]["respuesta"].ToString();
        }
        
    }

    private void cargarAreaCurriculo(string codinsasesor, CheckBoxList chk)
    {


        DataTable escogido = lb.cargarRespuestasCerradasInstrumento001A(codinsasesor, "8", "0", "02");//codreginstitucion,codpregunta,codsubpregunta,codinstrumento

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

        DataRow escogido2 = lb.buscarRespuestaAbiertaInstrumento001A(codinsasesor, "8", "02");//codreginstitucion,codpregunta,codinstrumento

        if (escogido2 != null)
        {
            txtAreaCurriculo.Text = escogido2["comentario"].ToString();
        }

    }
    /* Guardar respuestas del Instrumento Nro 2 */
    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        //if (validarChkEnfasisPEI(chkEnfasisPEI))
        //{
        //    if (validarChkModeloEducativo(chkModeloEducativo))
        //    {
                if (validarChkUsoTIC(chkUsoTIC))
                {
                    if (validarchkAreaCurriculo(chkAreaCurriculo))
                    {
                        //if (validarRBInvDocente())
                        //{
                        //    if (validarRBInvEstudiante())
                        //    {
                        //        if (validarRBTICdocente())
                        //        {
                        //            if (validarRBTICestudiante())
                        //            {
                                        if (validarRBTICInvPEI())
                                        {
                                            if (validarRBCompeTIC())
                                            {

                                                LineaBase lb = new LineaBase();

                                                  DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);

                                                  if (datoie != null)
                                                  {
                                                      DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                                                      if (dato != null)
                                                      {
                                                          //EliminarEnfasisPEI(dato["codigo"].ToString());
                                                          //AgregarEnfasisPEI(dato["codigo"].ToString(), chkEnfasisPEI);

                                                          //EliminarModeloEducativo(dato["codigo"].ToString());
                                                          //AgregarModeloEducativo(dato["codigo"].ToString(), chkModeloEducativo);

                                                          //EliminarAspectoPEI(dato["codigo"].ToString());
                                                          //ArgregarAspectosPEI(dato["codigo"].ToString());

                                                          //EliminarPrincipalesPracticas(dato["codigo"].ToString());
                                                          //AgregarPrincipalesPracticas(dato["codigo"].ToString(), txtPrincipalesPracticas.Text);


                                                          EliminarInvestigacionPEI(dato["codigo"].ToString());
                                                          AgregarinvestigacionPEI(dato["codigo"].ToString(), rbinvestigacionPEI.SelectedValue);

                                                          EliminarUsoTIC(dato["codigo"].ToString());
                                                          AgregarUsoTIC(dato["codigo"].ToString(), chkUsoTIC);

                                                          EliminarCompetenciaTIC(dato["codigo"].ToString());
                                                          AgregarCompetenciasTIC(dato["codigo"].ToString());

                                                          EliminarAreaCurriculo(dato["codigo"].ToString());
                                                          AgregarAreaCurriculo(dato["codigo"].ToString(), chkAreaCurriculo);

                                                          //cargarPreguntasInstrumento04(dato["codigo"].ToString());

                                                          //btnGuardarAutopercepcion.Visible = true;
                                                          //btnRegresarCaracterizacion.Visible = true;
                                                          //PanelAutopercepcionDocentes.Visible = true;
                                                          mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                                                          PanelCaracterizacion.Visible = true;
                                                          btnGuardar.Visible = true;

                                                          //Paneltime.Visible = false;
                                                      }
                                                      else
                                                      {
                                                          mostrarmensaje("error","Debe Diligenciar en primera instancia el Instrumento 001A");
                                                      }
                                                  }
                                
                                            }
                                        }

                        //            }

                        //        }

                        //    }
                        //}
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 8: Área de Curriculo.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 6: Uso de las TIC.");
                }
        //    }
        //    else
        //    {
        //        mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 2: Modelo Educativo del MEN.");
        //    }
        //}
        //else
        //{
        //    mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 1: Énfasis formativo del Proyecto Educativo Institucional - PEI.");
        //}

     
    }
    protected void btnPrimerGuardar02_Click(object sender, EventArgs e)
    {

        if (validarChkEnfasisPEI(chkEnfasisPEI))
        {
            if (validarChkModeloEducativo(chkModeloEducativo))
            {
         
                        if (validarRBInvDocente())
                        {
                            if (validarRBInvEstudiante())
                            {
                                if (validarRBTICdocente())
                                {
                                    if (validarRBTICestudiante())
                                    {
                                       
                                         
                                                LineaBase lb = new LineaBase();

                                                DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);

                                                if (datoie != null)
                                                {
                                                    DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
                                                    if (dato != null)
                                                    {

                                                        EliminarEnfasisPEI(dato["codigo"].ToString());
                                                        AgregarEnfasisPEI(dato["codigo"].ToString(), chkEnfasisPEI);

                                                        EliminarModeloEducativo(dato["codigo"].ToString());
                                                        AgregarModeloEducativo(dato["codigo"].ToString(), chkModeloEducativo);

                                                        EliminarAspectoPEI(dato["codigo"].ToString());
                                                        ArgregarAspectosPEI(dato["codigo"].ToString());

                                                        EliminarPrincipalesPracticas(dato["codigo"].ToString());
                                                        AgregarPrincipalesPracticas(dato["codigo"].ToString(), txtPrincipalesPracticas.Text);

                                                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

                                                        //cargarPreguntasInstrumento04(dato["codigo"].ToString());

                                                        //btnGuardarAutopercepcion.Visible = true;
                                                        //btnRegresarCaracterizacion.Visible = true;
                                                        //PanelAutopercepcionDocentes.Visible = true;

                                                        PanelCaracterizacion.Visible = true;
                                                        btnGuardar.Visible = true;

                                                        //Paneltime.Visible = false;
                                                    }
                                                    else
                                                    {
                                                        mostrarmensaje("error", "Debe Diligenciar en primera instancia el Instrumento 001A");
                                                    }
                                                }

                                    }

                                }

                            }
                        }
                  
            }
            else
            {
                mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 2: Modelo Educativo del MEN.");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir minimo 1 en el ítem # 1: Énfasis formativo del Proyecto Educativo Institucional - PEI.");
        }

       
    }

    public bool guardaRegistroInstitucion(string codinstitucion, string nomcoordinador, string cargo, string codsede, string codasesor, string codgradodocente)
    {
        Institucion ins = new Institucion();
        string fecha = fun.convertFechaAño(fun.getFechaAñoActual());
        DataRow codregistro = ins.agregarRegistroInstitucionalLineaBase(codinstitucion, nomcoordinador, cargo, fecha, codsede, codasesor, codgradodocente);
        if (codregistro != null)
        {
            //lblCodRegInstitucion.Text = codregistro["codigo"].ToString();
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool validarRBInvDocente()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbInvestigacionDocente.Items.Count; i++)
        {
            if (rbInvestigacionDocente.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 3: Línea de investigación Docente.");
            return false;
        }
    }
    public bool validarRBInvEstudiante()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbInvestigacionEstudiante.Items.Count; i++)
        {
            if (rbInvestigacionEstudiante.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 3: Línea de investigación Investigación.");
            return false;
        }
    }
    public bool validarRBTICdocente()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbticDocente.Items.Count; i++)
        {
            if (rbticDocente.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 3: TIC de los Docentes.");
            return false;
        }
    }
    public bool validarRBTICestudiante()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbticEstudiante.Items.Count; i++)
        {
            if (rbticEstudiante.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 3: TIC de los Estudiantes.");
            return false;
        }
    }
    public bool validarRBTICInvPEI()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbinvestigacionPEI.Items.Count; i++)
        {
            if (rbinvestigacionPEI.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 5.");
            return false;
        }
    }
    public bool validarRBCompeTIC()
    {
        bool rbchecked = false;
        for (int i = 0; i < rbCompetenciaTIC.Items.Count; i++)
        {
            if (rbCompetenciaTIC.Items[i].Selected == true)
            {
                rbchecked = true;
            }
        }
        if (rbchecked == true)
        {
            return true;
        }
        else
        {
            mostrarmensaje("error", "Seleccione Si o No en el ítem # 7.");
            return false;
        }
    }
    private bool validarChkEnfasisPEI(CheckBoxList combo)
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
    private bool validarChkModeloEducativo(CheckBoxList combo)
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
    private bool validarChkUsoTIC(CheckBoxList combo)
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
    private bool validarchkAreaCurriculo(CheckBoxList combo)
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

    private void ActualizarDatoInstitucional(string id, string nomcoordinador, string cargo)
    {
        LineaBase user = new LineaBase();
        if (user.editarNomCargoCoordinador(id, nomcoordinador, cargo)) { }
    }
    private void EliminarEnfasisPEI(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "1", "02", "0")) { }
    }
    private void AgregarEnfasisPEI(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "1", combo.Items[i].Value, "02", "0");
            }
        }
    }
    private void EliminarModeloEducativo(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaAbiertaInstitucional(id, "2", "02")) { }
    }
    private void AgregarModeloEducativo(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "2", combo.Items[i].Value, "02", "0");
            }
        }
        user.AgregarRespuestaAbiertaInstitucional(id, "2", txtDescripcionIEP.Text, "02");
    }
    private void EliminarAspectoPEI(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "3", "02", "1")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "3", "02", "2")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "3", "02", "3")) { }
        if (user.eliminarRespuestaCerradaInstitucional(id, "3", "02", "4")) { }
    }
    private void ArgregarAspectosPEI(string id)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaCerradaInstitucional(id, "3", rbInvestigacionDocente.SelectedValue, "02", "1");
        user.AgregarRespuestaCerradaInstitucional(id, "3", rbInvestigacionEstudiante.SelectedValue, "02", "2");
        user.AgregarRespuestaCerradaInstitucional(id, "3", rbticDocente.SelectedValue, "02", "3");
        user.AgregarRespuestaCerradaInstitucional(id, "3", rbticEstudiante.SelectedValue, "02", "4");
    }
    private void EliminarPrincipalesPracticas(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaAbiertaInstitucional(id, "4", "02")) { }
    }
    private void AgregarPrincipalesPracticas(string id, string comentario)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaAbiertaInstitucional(id, "4", comentario, "02");
    }
    private void EliminarInvestigacionPEI(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "5", "02", "0")) { }
    }
    private void AgregarinvestigacionPEI(string id, string respuesta)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaCerradaInstitucional(id, "5", respuesta,"02" , "0");
    }
    private void EliminarUsoTIC(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "6", "02", "0")) { }
        if (user.eliminarRespuestaAbiertaInstitucional(id, "6", "02")) { }
    }
    private void AgregarUsoTIC(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "6", combo.Items[i].Value, "02", "0");
            }
        }
        if (txtUsoTIC.Text != "")
        {
            user.AgregarRespuestaAbiertaInstitucional(id, "6", txtUsoTIC.Text, "02");
        }
    }
    private void EliminarCompetenciaTIC(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "7", "02", "0")) { }
    }
    private void AgregarCompetenciasTIC(string id)
    {
        LineaBase user = new LineaBase();
        user.AgregarRespuestaCerradaInstitucional(id, "7", rbCompetenciaTIC.SelectedValue,"02", "0");
    }
    private void EliminarAreaCurriculo(string id)
    {
        LineaBase user = new LineaBase();
        if (user.eliminarRespuestaCerradaInstitucional(id, "8", "02", "0")) { }
        if (user.eliminarRespuestaAbiertaInstitucional(id, "8", "02")) { }
    }
    private void AgregarAreaCurriculo(string id, CheckBoxList combo)
    {
        LineaBase user = new LineaBase();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.AgregarRespuestaCerradaInstitucional(id, "8", combo.Items[i].Value, "02", "0");
            }
        }
        if (txtAreaCurriculo.Text != "")
        {
            user.AgregarRespuestaAbiertaInstitucional(id, "8", txtAreaCurriculo.Text, "02");
        }
    }

    private void limpiardatosInstrumento02()
    {
        chkEnfasisPEI.ClearSelection();
        chkModeloEducativo.ClearSelection();
        txtDescripcionIEP.Text = "";
        rbInvestigacionEstudiante.ClearSelection();
        rbInvestigacionDocente.ClearSelection();
        rbticDocente.ClearSelection();
        rbticEstudiante.ClearSelection();
        txtPrincipalesPracticas.Text = "";
        rbinvestigacionPEI.ClearSelection();
        chkUsoTIC.ClearSelection();
        txtUsoTIC.Text = "";
        chkAreaCurriculo.ClearSelection();
        txtAreaCurriculo.Text = "";
    }

    private void cargarInformacionPreguntasIntrumento02(string codinsasesor)
    {
        cargarRespuestasEnfasisPEI(codinsasesor,chkEnfasisPEI);
        cargarRespuestasModeloEducativo(codinsasesor, chkModeloEducativo);
        cargarProcesosInstitucionalesPEI(codinsasesor);
        cargarPrincipalesPracticas(codinsasesor);
        cargarInvestigacionPEI(codinsasesor);
        cargarUsoTIC(codinsasesor,chkUsoTIC);
        cargarCompetenciasTIC(codinsasesor);
        cargarAreaCurriculo(codinsasesor, chkAreaCurriculo);
    }

    protected void btnPrimerGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);



        if (datoie != null)
        {
            DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
            if (dato != null)
            {
              

                        lblCodInstitucion.Text = datoie["codigo"].ToString();

                        lblCodAsesor.Text = dato["codasesor"].ToString();
                        Session["codinsasesor"] = dato["codigo"].ToString();
                        lblCodInstAsesor.Text = Session["codinsasesor"].ToString();

                        if (inst.actualizarDatosInstitucion(txtDANE.Text, txtNomInstitucion.Text, dropNomRector.SelectedValue, txtDireccion.Text, txtTelefono.Text, txtFax.Text, txtemail.Text, txtWeb.Text, dropCiudad.SelectedValue, dropZona.SelectedValue, dropPropiedadJuridica.SelectedValue, txtActivas.Text, txtInactivas.Text))
                        {
                            mostrarmensaje("exito", "Datos Actualizados exitosamente.");
                        }
                        else
                        {
                            mostrarmensaje("error", "Error al actualizar");
                        }
            }
            else
            {
                
                        DataRow codinstasesor = lb.AgregarDatoInstitucionAsesorLineaBase(datoie["codigo"].ToString(), dropAsesor.SelectedValue);
                        if (codinstasesor != null)
                        {
                            lblCodInstAsesor.Text = codinstasesor["codigo"].ToString();
                            if (inst.actualizarDatosInstitucion(txtDANE.Text, txtNomInstitucion.Text, dropNomRector.SelectedValue, txtDireccion.Text, txtTelefono.Text, txtFax.Text, txtemail.Text, txtWeb.Text,dropMunicipio.SelectedValue,dropZona.SelectedValue,dropPropiedadJuridica.SelectedValue,txtActivas.Text,txtInactivas.Text))
                            {
                                mostrarmensaje("exito", "Datos Actualizados exitosamente.");
                            }
                            else
                            {
                                mostrarmensaje("error", "Error al actualizar");
                            }
                        }

            }


        }
    }

    protected void btnSegundoGuardado_Onclick(object sender, EventArgs e)
    {
        DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);



        if (datoie != null)
        {
            DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
            if (dato != null)
            {
                if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                {
                    if (validarchkJornadas(chkJornadas))
                    {

                        EliminarNivelesEnsenanza(dato["codigo"].ToString());
                        AgregarNivelesEnsenanza(dato["codigo"].ToString(), chkNivelesEnsenaza);

                        EliminarProgramaEstrategiaModelosPreescolar(dato["codigo"].ToString());
                        AgregarProgramaEstrategiaModelosPreescolar(dato["codigo"].ToString(), chkProgramaEstrategiaModeloPreescolar);

                        EliminarProgramaEstrategiaModelosPrimaria(dato["codigo"].ToString());
                        AgregarProgramaEstrategiaModelosPrimaria(dato["codigo"].ToString(), chkProgramaEstrategiaModeloPrimaria);

                        EliminarProgramaEstrategiaModelosSecundaria(dato["codigo"].ToString());
                        AgregarProgramaEstrategiaModelosSecundaria(dato["codigo"].ToString(), chkProgramaEstrategiaModeloSecundaria);

                        EliminarProgramaEstrategiaModelosMedia(dato["codigo"].ToString());
                        AgregarProgramaEstrategiaModelosMedia(dato["codigo"].ToString(), chkProgramaEstrategiaModeloMedia);

                        EliminarProgramaEstrategiaModelosMedia(dato["codigo"].ToString());
                        AgregarProgramaEstrategiaModelosMedia(dato["codigo"].ToString(), chkProgramaEstrategiaModeloMedia);

                        EliminarJornadas(dato["codigo"].ToString());
                        AgregarJornadas(dato["codigo"].ToString(), chkJornadas);

                        EliminarRecursosHumanos(dato["codigo"].ToString());
                        AgregarRecursosHumanos(dato["codigo"].ToString());

                        PanelInstrumento001A.Visible = true;
                        btnGuardarInfoBasica.Visible = true;

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                }
            }
            else
            {
                if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                {
                    if (validarchkJornadas(chkJornadas))
                    {
                        DataRow codinstasesor = lb.AgregarDatoInstitucionAsesorLineaBase(datoie["codigo"].ToString(), dropAsesor.SelectedValue);
                        if (codinstasesor != null)
                        {
                            lblCodInstAsesor.Text = codinstasesor["codigo"].ToString();
                        }

                        EliminarNivelesEnsenanza(lblCodInstAsesor.Text);
                        AgregarNivelesEnsenanza(lblCodInstAsesor.Text, chkNivelesEnsenaza);

                        EliminarProgramaEstrategiaModelosPreescolar(lblCodInstAsesor.Text);
                        AgregarProgramaEstrategiaModelosPreescolar(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloPreescolar);

                        EliminarProgramaEstrategiaModelosPrimaria(lblCodInstAsesor.Text);
                        AgregarProgramaEstrategiaModelosPrimaria(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloPrimaria);

                        EliminarProgramaEstrategiaModelosSecundaria(lblCodInstAsesor.Text);
                        AgregarProgramaEstrategiaModelosSecundaria(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloSecundaria);

                        EliminarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text);
                        AgregarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloMedia);

                        EliminarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text);
                        AgregarProgramaEstrategiaModelosMedia(lblCodInstAsesor.Text, chkProgramaEstrategiaModeloMedia);

                        EliminarJornadas(lblCodInstAsesor.Text);
                        AgregarJornadas(lblCodInstAsesor.Text, chkJornadas);

                        EliminarRecursosHumanos(lblCodInstAsesor.Text);
                        AgregarRecursosHumanos(lblCodInstAsesor.Text);
                        
                        PanelInstrumento001A.Visible = true;
                        btnGuardarInfoBasica.Visible = true;

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

                        //DateTime localDateTime = DateTime.Now;
                        //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        //string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                        //lb.agregarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), horares, "001A");
                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                }
            }


        }
    }

    protected void btnTercerGuardar_Onclick(object sender, EventArgs e)
    {
        DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);



        if (datoie != null)
        {
            DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
            if (dato != null)
            {

                EliminarDocentexNivel(dato["codigo"].ToString());
                AgregarDocentexNivelEnsenianza(dato["codigo"].ToString());

                mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
                PanelInstrumento001A.Visible = true;
                btnGuardarInfoBasica.Visible = true;

                  
            }
            else
            {
                if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                {
                    if (validarchkJornadas(chkJornadas))
                    {
                        DataRow codinstasesor = lb.AgregarDatoInstitucionAsesorLineaBase(datoie["codigo"].ToString(), dropAsesor.SelectedValue);
                        if (codinstasesor != null)
                        {
                            lblCodInstAsesor.Text = codinstasesor["codigo"].ToString();
                        }

                        EliminarDocentexNivel(lblCodInstAsesor.Text);
                        AgregarDocentexNivelEnsenianza(lblCodInstAsesor.Text);

                        EliminarRecursosHumanos(lblCodInstAsesor.Text);
                        AgregarRecursosHumanos(lblCodInstAsesor.Text);

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");
               
                        PanelInstrumento001A.Visible = true;
                        btnGuardarInfoBasica.Visible = true;

          
                        //DateTime localDateTime = DateTime.Now;
                        //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        //string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                        //lb.agregarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), horares, "001A");
                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                }
            }


        }
        
    }

    protected void btnCuartoguardar_Onclick(object sender, EventArgs e)
    {

        DataRow datoie = inst.buscarInstitucionxNitTodo(lblCodDANE.Text);



        if (datoie != null)
        {
            DataRow dato = lb.buscarInstitucionxAsesor(datoie["codigo"].ToString());
            if (dato != null)
            {
                if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                {
                    if (validarchkJornadas(chkJornadas))
                    {
                        EliminarDocentexCaracterAcademico(dato["codigo"].ToString());
                        AgregarDocentexCaracterAcademico(dato["codigo"].ToString());
                       
                        PanelFormularioC600B.Visible = true;

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                }
            }
            else
            {
                if (validarchkNivelesEnsenaza(chkNivelesEnsenaza))
                {
                    if (validarchkJornadas(chkJornadas))
                    {
                        DataRow codinstasesor = lb.AgregarDatoInstitucionAsesorLineaBase(datoie["codigo"].ToString(), dropAsesor.SelectedValue);
                        if (codinstasesor != null)
                        {
                            lblCodInstAsesor.Text = codinstasesor["codigo"].ToString();
                        }
                        EliminarDocentexCaracterAcademico(lblCodInstAsesor.Text);
                        AgregarDocentexCaracterAcademico(lblCodInstAsesor.Text);

                        mostrarmensaje("exito", "Respuestas agregadas exitosamente.");

                        //DateTime localDateTime = DateTime.Now;
                        //DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        //string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                        //lb.agregarIntentosDocente(datoie["codigo"].ToString(), Session["identificacion"].ToString(), horares, "001A");
                    }
                    else
                    {
                        mostrarmensaje("error", "Debe seleccionar una Jornada de la institución educativa.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Debe seleccionar un nivel de enseñanza.");
                }
            }


        }

    }




    //impacto DOCENTES

[WebMethod(EnableSession = true)]

    public static string guardarpreguntascerradas(string codasesor2,string codasesor, string respuesta, string pregunta, string subpregunta, string accion)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();
        Docentes doc = new Docentes();
        evalfina4p efd = new evalfina4p();
        //DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());
        DataRow coddocenteasesor = efd.codDocenteAsesor( HttpContext.Current.Session["identificacion"].ToString(),codasesor);
        DataRow coddocenteasesor2 = efd.codDocenteAsesor( HttpContext.Current.Session["identificacion"].ToString(),codasesor2);
        if (coddocenteasesor != null)
        {

             if (coddocenteasesor2 != null)
            {
                lb.eliminarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, subpregunta, "4", "impacto");
            }
            //lb.eliminarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, subpregunta, "4", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), pregunta, subpregunta, respuesta, "4", "impacto");
           
        }
        // else//Asesor es cambio o nuevo para ingresar
        // {
        //     DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

        //     if (docente != null)
        //     {
        //         DataRow docenteasesor = lb.buscarCodDocenteAsesorxDocente(docente["cod"].ToString());
        //         if (docenteasesor != null)
        //         {
        //             lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), pregunta, subpregunta, "2.1", "impacto");
        //             lb.AgregarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), pregunta, subpregunta, respuesta, "2.1", "impacto");
                     
        //         }
        //         else
        //         {
        //             DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
        //             if (coddocenteasesor2 != null)
        //             {

        //                 lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, subpregunta, respuesta, "2.1", "impacto");
        //             }
        //         }
        //     }
        // }

        return ca;
    }
   
    //Esta funciómn no se está usando
    [WebMethod(EnableSession = true)]
    public static string guardardatoscerradas(string codasesor, string preg2_1, string preg2_2, string preg2_3, string preg2_4, string preg2_5, string preg2_6, string preg2_7, string preg2_8, string preg3, string preg4, string preg5, string preg6, string preg8, string preg10, string preg7_1, string preg7_2, string preg7_3, string preg7_4, string preg7_5, string preg7_6, string preg7_7, string preg7_8, string preg9_1, string preg9_2, string preg9_3, string preg9_4, string preg9_5, string preg9_6, string preg9_7, string preg9_8)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();
        Docentes doc = new Docentes();
        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "1", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "2", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "3", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "4", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "5", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "6", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "7", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "8", "5", "impacto");

            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "1", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "2", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "3", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "4", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "5", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "6", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "7", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "8", "5", "impacto");

            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "1", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "2", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "3", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "4", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "5", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "6", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "7", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "8", "5", "impacto");

            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "3", "0", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "4", "0", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "5", "0", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "6", "0", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "8", "0", "5", "impacto");
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "10", "0", "5", "impacto");

            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "1", preg2_1, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "2", preg2_2, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "3", preg2_3, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "4", preg2_4, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "5", preg2_5, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "6", preg2_6, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "7", preg2_7, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "8", preg2_8, "5", "impacto");

            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "3", "0", preg3, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "4", "0", preg4, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "5", "0", preg5, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "6", "0", preg6, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "8", "0", preg8, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "10", "0", preg10, "5", "impacto");

            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "1", preg7_1, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "2", preg7_2, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "3", preg7_3, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "4", preg7_4, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "5", preg7_5, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "6", preg7_6, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "7", preg7_7, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "8", preg7_8, "5", "impacto");

            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "1", preg9_1, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "2", preg9_2, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "3", preg9_3, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "4", preg9_4, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "5", preg9_5, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "6", preg9_6, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "7", preg9_7, "5", "impacto");
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "9", "8", preg9_8, "5", "impacto");
        }
        else//Asesor es cambio o nuevo para ingresar
        {
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow docenteasesor = lb.buscarCodDocenteAsesorxDocente(docente["cod"].ToString());
                if (docenteasesor != null)
                {
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "1", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "2", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "3", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "4", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "5", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "6", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "7", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "2", "8", "5", "impacto");

                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "1", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "2", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "3", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "4", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "5", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "6", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "7", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "7", "8", "5", "impacto");

                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "1", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "2", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "3", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "4", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "5", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "6", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "7", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "9", "8", "5", "impacto");

                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "3", "0", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "4", "0", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "5", "0", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "6", "0", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "8", "0", "5", "impacto");
                    lb.eliminarRespuestaCerrada_Fase(docenteasesor["codigo"].ToString(), "10", "0", "5", "impacto");

                    DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                    if (coddocenteasesor2 != null)
                    {

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "1", preg2_1, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "2", preg2_2, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "3", preg2_3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "4", preg2_4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "5", preg2_5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "6", preg2_6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "7", preg2_7, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "8", preg2_8, "5", "impacto");

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "3", "0", preg3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "4", "0", preg4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "5", "0", preg5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "6", "0", preg6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "8", "0", preg8, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "10", "0", preg10, "5", "impacto");

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "1", preg7_1, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "2", preg7_2, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "3", preg7_3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "4", preg7_4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "5", preg7_5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "6", preg7_6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "7", preg7_7, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "8", preg7_8, "5", "impacto");

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "1", preg9_1, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "2", preg9_2, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "3", preg9_3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "4", preg9_4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "5", preg9_5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "6", preg9_6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "7", preg9_7, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "8", preg9_8, "5", "impacto");
                    }
                }
                else
                {
                    DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                    if (coddocenteasesor2 != null)
                    {

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "1", preg2_1, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "2", preg2_2, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "3", preg2_3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "4", preg2_4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "5", preg2_5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "6", preg2_6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "7", preg2_7, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "8", preg2_8, "5", "impacto");

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "3", "0", preg3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "4", "0", preg4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "5", "0", preg5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "6", "0", preg6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "8", "0", preg8, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "10", "0", preg10, "5", "impacto");

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "1", preg7_1, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "2", preg7_2, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "3", preg7_3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "4", preg7_4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "5", preg7_5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "6", preg7_6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "7", preg7_7, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "8", preg7_8, "5", "impacto");

                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "1", preg9_1, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "2", preg9_2, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "3", preg9_3, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "4", preg9_4, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "5", preg9_5, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "6", preg9_6, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "7", preg9_7, "5", "impacto");
                        lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "9", "8", preg9_8, "5", "impacto");
                    }
                }
                
            }
        }

        return ca;
    }

    //Esta función ya no esta siendo usada
    [WebMethod(EnableSession = true)]
    public static string guardardatosabiertas(string codasesor, string preg2_nombre_1, string preg2_duracion_1, string preg2_anio_1, string preg2_nombre_2, string preg2_duracion_2, string preg2_anio_2, string preg2_nombre_3, string preg2_duracion_3, string preg2_anio_3, string preg2_nombre_4, string preg2_duracion_4, string preg2_anio_4, string txtpedago, string txtpromueve, string txtparticipado, string txtinvestiga, string preg7nombre_1, string preg7duracion_1, string preg7anio_1, string preg7nombre_2, string preg7duracion_2, string preg7anio_2, string preg7nombre_3, string preg7duracion_3, string preg7anio_3, string preg7nombre_4, string preg7duracion_4, string preg7anio_4, string preg9nombre_1, string preg9duracion_1, string preg9anio_1, string preg9nombre_2, string preg9duracion_2, string preg9anio_2, string preg9nombre_3, string preg9duracion_3, string preg9anio_3, string preg9nombre_4, string preg9duracion_4, string preg9anio_4, string preg8rbforma, string preg10rbforma, string preg11_1, string preg11_2, string preg11_3, string preg11_4, string preg11_5, string preg11_6, string preg11_7, string preg11_8, string preg11_9, string preg11_10, string preg11_11, string preg11_12)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();
        Docentes doc = new Docentes();

         DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

         if (coddocenteasesor != null)
         {
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", "5", "impacto");

             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", "5", "impacto");

             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", "5", "impacto");

             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "3", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "4", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "5", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "6", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "8", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "10", "5", "impacto");

             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.1", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.2", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.3", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.4", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.5", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.6", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.7", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.8", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.9", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.10", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.11", "5", "impacto");
             lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.12", "5", "impacto");

             if (preg2_nombre_1 == "") { preg2_nombre_1 = ""; }
             if (preg2_duracion_1 == "") { preg2_duracion_1 = ""; }
             if (preg2_anio_1 == "") { preg2_anio_1 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", preg2_nombre_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", preg2_duracion_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", preg2_anio_1, "5", "impacto");

             if (preg2_nombre_2 == "") { preg2_nombre_2 = ""; }
             if (preg2_duracion_2 == "") { preg2_duracion_2 = ""; }
             if (preg2_anio_2 == "") { preg2_anio_2 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", preg2_nombre_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", preg2_duracion_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", preg2_anio_2, "5", "impacto");

             if (preg2_nombre_3 == "") { preg2_nombre_3 = ""; }
             if (preg2_duracion_3 == "") { preg2_duracion_3 = ""; }
             if (preg2_anio_3 == "") { preg2_anio_3 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", preg2_nombre_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", preg2_duracion_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", preg2_anio_3, "5", "impacto");

             if (preg2_nombre_4 == "") { preg2_nombre_4 = ""; }
             if (preg2_duracion_4 == "") { preg2_duracion_4 = ""; }
             if (preg2_anio_4 == "") { preg2_anio_4 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", preg2_nombre_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", preg2_duracion_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", preg2_anio_4, "5", "impacto");

             //preg 7
             if (preg7nombre_1 == "") { preg7nombre_1 = ""; }
             if (preg7duracion_1 == "") { preg7duracion_1 = ""; }
             if (preg7anio_1 == "") { preg7anio_1 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", preg7nombre_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", preg7duracion_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", preg7anio_1, "5", "impacto");

             if (preg7nombre_2 == "") { preg7nombre_2 = ""; }
             if (preg7duracion_2 == "") { preg7duracion_2 = ""; }
             if (preg7anio_2 == "") { preg7anio_2 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", preg7nombre_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", preg7duracion_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", preg7anio_2, "5", "impacto");

             if (preg7nombre_3 == "") { preg7nombre_3 = ""; }
             if (preg7duracion_3 == "") { preg7duracion_3 = ""; }
             if (preg7anio_3 == "") { preg7anio_3 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", preg7nombre_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", preg7duracion_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", preg7anio_3, "5", "impacto");

             if (preg7nombre_4 == "") { preg7nombre_4 = ""; }
             if (preg7duracion_4 == "") { preg7duracion_4 = ""; }
             if (preg7anio_4 == "") { preg7anio_4 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", preg7nombre_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", preg7duracion_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", preg7anio_4, "5", "impacto");

             //Preg 9
             if (preg9nombre_1 == "") { preg9nombre_1 = ""; }
             if (preg9duracion_1 == "") { preg9duracion_1 = ""; }
             if (preg9anio_1 == "") { preg9anio_1 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", preg9nombre_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", preg9duracion_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", preg9anio_1, "5", "impacto");

             if (preg9nombre_2 == "") { preg9nombre_2 = ""; }
             if (preg9duracion_2 == "") { preg9duracion_2 = ""; }
             if (preg9anio_2 == "") { preg9anio_2 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", preg9nombre_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", preg9duracion_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", preg9anio_2, "5", "impacto");

             if (preg9nombre_3 == "") { preg9nombre_3 = ""; }
             if (preg9duracion_3 == "") { preg9duracion_3 = ""; }
             if (preg9anio_3 == "") { preg9anio_3 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", preg9nombre_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", preg9duracion_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", preg9anio_3, "5", "impacto");

             if (preg9nombre_4 == "") { preg9nombre_4 = ""; }
             if (preg9duracion_4 == "") { preg9duracion_4 = ""; }
             if (preg9anio_4 == "") { preg9anio_4 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", preg9nombre_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", preg9duracion_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", preg9anio_4, "5", "impacto");

             if (txtpedago == "") { txtpedago = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "3", txtpedago, "5", "impacto");

             if (txtpromueve == "") { txtpromueve = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "4", txtpromueve, "5", "impacto");

             if (txtparticipado == "") { txtparticipado = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "5", txtparticipado, "5", "impacto");

             if (txtinvestiga == "") { txtinvestiga = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "6", txtinvestiga, "5", "impacto");

             if (preg8rbforma == "") { preg8rbforma = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "8", preg8rbforma, "5", "impacto");

             if (preg10rbforma == "") { preg10rbforma = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "10", preg10rbforma, "5", "impacto");

             //Preg 11
             if (preg11_1 == "") { preg11_1 = ""; }
             if (preg11_2 == "") { preg11_2 = ""; }
             if (preg11_3 == "") { preg11_3 = ""; }
             if (preg11_4 == "") { preg11_4 = ""; }
             if (preg11_5 == "") { preg11_5 = ""; }
             if (preg11_6 == "") { preg11_6 = ""; }
             if (preg11_7 == "") { preg11_7 = ""; }
             if (preg11_8 == "") { preg11_8 = ""; }
             if (preg11_9 == "") { preg11_9 = ""; }
             if (preg11_10 == "") { preg11_10 = ""; }
             if (preg11_11 == "") { preg11_11 = ""; }
             if (preg11_12 == "") { preg11_12 = ""; }
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.1", preg11_1, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.2", preg11_2, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.3", preg11_3, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.4", preg11_4, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.5", preg11_5, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.6", preg11_6, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.7", preg11_7, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.8", preg11_8, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.9", preg11_9, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.10", preg11_10, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.11", preg11_11, "5", "impacto");
             lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.12", preg11_12, "5", "impacto");
         }
         else//Asesor es cambio o nuevo para ingresar
         {
             DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

             if (docente != null)
             {
                 DataRow docenteasesor = lb.buscarCodDocenteAsesorxDocente(docente["cod"].ToString());
                 if (docenteasesor != null)
                 {
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.1", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.3", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.4", "5", "impacto");

                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "7.1", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "7.2", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "7.3", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "7.4", "5", "impacto");

                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "9.1", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "9.2", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "9.3", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "9.4", "5", "impacto");

                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "3", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "4", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "5", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "6", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "8", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "10", "5", "impacto");

                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.1", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.2", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.3", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.4", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.5", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.6", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.7", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.8", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.9", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.10", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.11", "5", "impacto");
                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "11.12", "5", "impacto");
                 }
                 else
                 {
                     DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                     if (coddocenteasesor2 != null)
                     {

                         if (preg2_nombre_1 == "") { preg2_nombre_1 = ""; }
                         if (preg2_duracion_1 == "") { preg2_duracion_1 = ""; }
                         if (preg2_anio_1 == "") { preg2_anio_1 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.1", preg2_nombre_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.1", preg2_duracion_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.1", preg2_anio_1, "5", "impacto");

                         if (preg2_nombre_2 == "") { preg2_nombre_2 = ""; }
                         if (preg2_duracion_2 == "") { preg2_duracion_2 = ""; }
                         if (preg2_anio_2 == "") { preg2_anio_2 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", preg2_nombre_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", preg2_duracion_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", preg2_anio_2, "5", "impacto");

                         if (preg2_nombre_3 == "") { preg2_nombre_3 = ""; }
                         if (preg2_duracion_3 == "") { preg2_duracion_3 = ""; }
                         if (preg2_anio_3 == "") { preg2_anio_3 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.3", preg2_nombre_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.3", preg2_duracion_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.3", preg2_anio_3, "5", "impacto");

                         if (preg2_nombre_4 == "") { preg2_nombre_4 = ""; }
                         if (preg2_duracion_4 == "") { preg2_duracion_4 = ""; }
                         if (preg2_anio_4 == "") { preg2_anio_4 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.4", preg2_nombre_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.4", preg2_duracion_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.4", preg2_anio_4, "5", "impacto");

                         //preg 7
                         if (preg7nombre_1 == "") { preg7nombre_1 = ""; }
                         if (preg7duracion_1 == "") { preg7duracion_1 = ""; }
                         if (preg7anio_1 == "") { preg7anio_1 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.1", preg7nombre_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.1", preg7duracion_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.1", preg7anio_1, "5", "impacto");

                         if (preg7nombre_2 == "") { preg7nombre_2 = ""; }
                         if (preg7duracion_2 == "") { preg7duracion_2 = ""; }
                         if (preg7anio_2 == "") { preg7anio_2 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.2", preg7nombre_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.2", preg7duracion_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.2", preg7anio_2, "5", "impacto");

                         if (preg7nombre_3 == "") { preg7nombre_3 = ""; }
                         if (preg7duracion_3 == "") { preg7duracion_3 = ""; }
                         if (preg7anio_3 == "") { preg7anio_3 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.3", preg7nombre_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.3", preg7duracion_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.3", preg7anio_3, "5", "impacto");

                         if (preg7nombre_4 == "") { preg7nombre_4 = ""; }
                         if (preg7duracion_4 == "") { preg7duracion_4 = ""; }
                         if (preg7anio_4 == "") { preg7anio_4 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.4", preg7nombre_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.4", preg7duracion_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "7.4", preg7anio_4, "5", "impacto");

                         //Preg 9
                         if (preg9nombre_1 == "") { preg9nombre_1 = ""; }
                         if (preg9duracion_1 == "") { preg9duracion_1 = ""; }
                         if (preg9anio_1 == "") { preg9anio_1 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.1", preg9nombre_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.1", preg9duracion_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.1", preg9anio_1, "5", "impacto");

                         if (preg9nombre_2 == "") { preg9nombre_2 = ""; }
                         if (preg9duracion_2 == "") { preg9duracion_2 = ""; }
                         if (preg9anio_2 == "") { preg9anio_2 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.2", preg9nombre_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.2", preg9duracion_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.2", preg9anio_2, "5", "impacto");

                         if (preg9nombre_3 == "") { preg9nombre_3 = ""; }
                         if (preg9duracion_3 == "") { preg9duracion_3 = ""; }
                         if (preg9anio_3 == "") { preg9anio_3 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.3", preg9nombre_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.3", preg9duracion_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.3", preg9anio_3, "5", "impacto");

                         if (preg9nombre_4 == "") { preg9nombre_4 = ""; }
                         if (preg9duracion_4 == "") { preg9duracion_4 = ""; }
                         if (preg9anio_4 == "") { preg9anio_4 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.4", preg9nombre_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.4", preg9duracion_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "9.4", preg9anio_4, "5", "impacto");

                         if (txtpedago == "") { txtpedago = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "3", txtpedago, "5", "impacto");

                         if (txtpromueve == "") { txtpromueve = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "4", txtpromueve, "5", "impacto");

                         if (txtparticipado == "") { txtparticipado = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "5", txtparticipado, "5", "impacto");

                         if (txtinvestiga == "") { txtinvestiga = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "6", txtinvestiga, "5", "impacto");

                         if (preg8rbforma == "") { preg8rbforma = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "8", preg8rbforma, "5", "impacto");

                         if (preg10rbforma == "") { preg10rbforma = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "10", preg10rbforma, "5", "impacto");

                         //Preg 11
                         if (preg11_1 == "") { preg11_1 = ""; }
                         if (preg11_2 == "") { preg11_2 = ""; }
                         if (preg11_3 == "") { preg11_3 = ""; }
                         if (preg11_4 == "") { preg11_4 = ""; }
                         if (preg11_5 == "") { preg11_5 = ""; }
                         if (preg11_6 == "") { preg11_6 = ""; }
                         if (preg11_7 == "") { preg11_7 = ""; }
                         if (preg11_8 == "") { preg11_8 = ""; }
                         if (preg11_9 == "") { preg11_9 = ""; }
                         if (preg11_10 == "") { preg11_10 = ""; }
                         if (preg11_11 == "") { preg11_11 = ""; }
                         if (preg11_12 == "") { preg11_12 = ""; }
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.1", preg11_1, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.2", preg11_2, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.3", preg11_3, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.4", preg11_4, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.5", preg11_5, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.6", preg11_6, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.7", preg11_7, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.8", preg11_8, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.9", preg11_9, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.10", preg11_10, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.11", preg11_11, "5", "impacto");
                         lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "11.12", preg11_12, "5", "impacto");
                        
                     }
                 }
             }
         }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarchk1(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "1", "1_1", "4", "impacto");
        }
       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarchk4(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "4", "1", "5", "impacto");
        }
        

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarchk5(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "5", "1", "5", "impacto");
        }
        

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarchk6(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "6", "1", "5", "impacto");
        }

        

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarchk11(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.eliminarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "11", "0", "5", "impacto");
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk1(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        
         Asesores ase = new Asesores();

         DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

         if (coddocenteasesor != null)
         {
             lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "1", "1,1", chk, "4", "impacto");
         }
         else
         {
             Docentes doc = new Docentes();
              DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

              if (docente != null)
              {
                  DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                  if (coddocenteasesor2 != null)
                  {
                      lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "1", "1", chk, "4", "impacto");
                  }
              }
            
         }

       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk4(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "2", "1", chk, "5", "impacto");
        }
        else
        {
            Docentes doc = new Docentes();
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                if (coddocenteasesor2 != null)
                {
                    lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "2", "1", chk, "5", "impacto");
                }
            }

        }

        

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk5(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "3", "1", chk, "5", "impacto");
        }
        else
        {
            Docentes doc = new Docentes();
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                if (coddocenteasesor2 != null)
                {
                    lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "3", "1", chk, "5", "impacto");
                }
            }

        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk6(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "4", "1", chk, "5", "impacto");
        }
        else
        {
            Docentes doc = new Docentes();
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                if (coddocenteasesor2 != null)
                {
                    lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "4", "1", chk, "5", "impacto");
                }
            }

        }
       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk11(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();

        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "6", "1", chk, "5", "impacto");
        }
        else
        {
            Docentes doc = new Docentes();
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                if (coddocenteasesor2 != null)
                {
                    lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "6", "1", chk, "5", "impacto");
                }
            }

        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk12(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();

        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "1", chk, "5", "impacto");
        }
        else
        {
            Docentes doc = new Docentes();
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                if (coddocenteasesor2 != null)
                {
                    lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "1", chk, "5", "impacto");
                }
            }

        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardatoschk13(string chk, string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();

        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            lb.AgregarRespuestaCerrada_Fase(coddocenteasesor["codigo"].ToString(), "7", "2", chk, "5", "impacto");
        }
        else
        {
            Docentes doc = new Docentes();
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                if (coddocenteasesor2 != null)
                {
                    lb.AgregarRespuestaCerrada_Fase(coddocenteasesor2["codigo"].ToString(), "7", "2", chk, "5", "impacto");
                }
            }

        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestaspregunta(string codasesor, string pregunta, string numero)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (numero == "")
        {
            if (coddocenteasesor != null)
            {
                DataTable datos = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "true_load@";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += datos.Rows[i]["comentario"].ToString() + "_load@";
                    }
                }
            }
        }
        else
        {
            if (coddocenteasesor != null)
            {
                DataTable datos = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), pregunta + "." + numero, "5", "impacto");

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "true_load@";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += datos.Rows[i]["comentario"].ToString() + "_load@";//1, 2, 3
                    }
                }
            }
        }

        
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestaspreguntacerrada_2(string codasesor, string pregunta, string subpregunta)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

           DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

           if (coddocenteasesor != null)
           {
               DataTable dat7 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), pregunta, subpregunta, "4", "impacto");
               if (dat7 != null && dat7.Rows.Count > 0)
               {
                   ca = "true_load@";
                   ca += dat7.Rows[0]["respuesta"].ToString();//7
               }
           }

       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradasyabiertas(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "3", "0", "5", "impacto");
            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                ca += dat.Rows[0]["respuesta"].ToString() + "@";//1
            }

            DataTable dat2 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "4", "0", "5", "impacto");
            if (dat2 != null && dat2.Rows.Count > 0)
            {
                ca += dat2.Rows[0]["respuesta"].ToString() + "@";//2
            }

            DataTable dat3 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "5", "0", "5", "impacto");
            if (dat3 != null && dat3.Rows.Count > 0)
            {
                ca += dat3.Rows[0]["respuesta"].ToString() + "@";//3
            }

            DataTable dat4 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "5", "0", "5", "impacto");
            if (dat4 != null && dat4.Rows.Count > 0)
            {
                ca += dat4.Rows[0]["respuesta"].ToString() + "@";//4
            }

            DataTable dat5 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "8", "0", "5", "impacto");
            if (dat5 != null && dat5.Rows.Count > 0)
            {
                ca += dat5.Rows[0]["respuesta"].ToString() + "@";//5
            }

            DataTable dat6 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "10", "0", "5", "impacto");
            if (dat6 != null && dat6.Rows.Count > 0)
            {
                ca += dat6.Rows[0]["respuesta"].ToString() + "@";//6
            }

            DataTable dat7 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "1", "5", "impacto");
            if (dat7 != null && dat7.Rows.Count > 0)
            {
                ca += dat7.Rows[0]["respuesta"].ToString() + "@";//7
            }

            DataTable dat8 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "2", "5", "impacto");
            if (dat8 != null && dat8.Rows.Count > 0)
            {
                ca += dat8.Rows[0]["respuesta"].ToString() + "@";//8
            }

            DataTable dat9 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "3", "5", "impacto");
            if (dat9 != null && dat9.Rows.Count > 0)
            {
                ca += dat9.Rows[0]["respuesta"].ToString() + "@";//9
            }

            DataTable dat10 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "4", "5", "impacto");
            if (dat10 != null && dat10.Rows.Count > 0)
            {
                ca += dat10.Rows[0]["respuesta"].ToString() + "@";//10
            }

            DataTable dat11 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "5", "5", "impacto");
            if (dat11 != null && dat11.Rows.Count > 0)
            {
                ca += dat11.Rows[0]["respuesta"].ToString() + "@";//11
            }

            DataTable dat12 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "6", "5", "impacto");
            if (dat12 != null && dat12.Rows.Count > 0)
            {
                ca += dat12.Rows[0]["respuesta"].ToString() + "@";//12
            }

            DataTable dat13 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "7", "5", "impacto");
            if (dat13 != null && dat13.Rows.Count > 0)
            {
                ca += dat13.Rows[0]["respuesta"].ToString() + "@";//13
            }

            DataTable dat14 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "8", "5", "impacto");
            if (dat14 != null && dat14.Rows.Count > 0)
            {
                ca += dat14.Rows[0]["respuesta"].ToString() + "@";//14
            }

            DataTable datos = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2.1", "5", "impacto");

            if (datos != null && datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    ca += datos.Rows[i]["comentario"].ToString() + "@";//15, 16, 17
                }
            }

            DataTable datos2 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2.2", "5", "impacto");

            if (datos2 != null && datos2.Rows.Count > 0)
            {
                for (int i = 0; i < datos2.Rows.Count; i++)
                {
                    ca += datos2.Rows[i]["comentario"].ToString() + "@";//18, 19, 20
                }
            }

            DataTable datos3 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2.3", "5", "impacto");

            if (datos3 != null && datos3.Rows.Count > 0)
            {
                for (int i = 0; i < datos3.Rows.Count; i++)
                {
                    ca += datos3.Rows[i]["comentario"].ToString() + "@";//21, 22, 23
                }
            }

            DataTable datos4 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2.4", "5", "impacto");

            if (datos4 != null && datos4.Rows.Count > 0)
            {
                for (int i = 0; i < datos4.Rows.Count; i++)
                {
                    ca += datos4.Rows[i]["comentario"].ToString() + "@";//24, 25, 26
                }
            }

            DataTable datos5 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7.1", "5", "impacto");

            if (datos5 != null && datos5.Rows.Count > 0)
            {
                for (int i = 0; i < datos5.Rows.Count; i++)
                {
                    ca += datos5.Rows[i]["comentario"].ToString() + "@";//27, 28, 29
                }
            }

            DataTable datos6 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7.2", "5", "impacto");

            if (datos6 != null && datos6.Rows.Count > 0)
            {
                for (int i = 0; i < datos6.Rows.Count; i++)
                {
                    ca += datos6.Rows[i]["comentario"].ToString() + "@";//30, 31, 32
                }
            }

            DataTable datos7 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7.3", "5", "impacto");

            if (datos7 != null && datos6.Rows.Count > 0)
            {
                for (int i = 0; i < datos7.Rows.Count; i++)
                {
                    ca += datos7.Rows[i]["comentario"].ToString() + "@";//33, 34, 35
                }
            }

            DataTable datos8 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7.4", "5", "impacto");

            if (datos8 != null && datos6.Rows.Count > 0)
            {
                for (int i = 0; i < datos8.Rows.Count; i++)
                {
                    ca += datos8.Rows[i]["comentario"].ToString() + "@";//36, 37, 38
                }
            }

            DataTable datos9 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9.1", "5", "impacto");

            if (datos9 != null && datos9.Rows.Count > 0)
            {
                for (int i = 0; i < datos9.Rows.Count; i++)
                {
                    ca += datos9.Rows[i]["comentario"].ToString() + "@";//39, 40, 41
                }
            }

            DataTable datos10 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9.2", "5", "impacto");

            if (datos10 != null && datos10.Rows.Count > 0)
            {
                for (int i = 0; i < datos10.Rows.Count; i++)
                {
                    ca += datos10.Rows[i]["comentario"].ToString() + "@";//42, 43, 44
                }
            }

            DataTable datos11 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9.3", "5", "impacto");

            if (datos11 != null && datos11.Rows.Count > 0)
            {
                for (int i = 0; i < datos11.Rows.Count; i++)
                {
                    ca += datos11.Rows[i]["comentario"].ToString() + "@";//45, 46, 47
                }
            }

            DataTable datos12 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9.4", "5", "impacto");

            if (datos12 != null && datos12.Rows.Count > 0)
            {
                for (int i = 0; i < datos12.Rows.Count; i++)
                {
                    ca += datos12.Rows[i]["comentario"].ToString() + "@";//48, 49, 50
                }
            }

            DataTable dat15 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "1", "5", "impacto");
            if (dat15 != null && dat15.Rows.Count > 0)
            {
                ca += dat15.Rows[0]["respuesta"].ToString() + "@";//51
            }

            DataTable dat16 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "2", "5", "impacto");
            if (dat16 != null && dat16.Rows.Count > 0)
            {
                ca += dat16.Rows[0]["respuesta"].ToString() + "@";//52
            }

            DataTable dat17 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "3", "5", "impacto");
            if (dat17 != null && dat17.Rows.Count > 0)
            {
                ca += dat17.Rows[0]["respuesta"].ToString() + "@";//53
            }

            DataTable dat18 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "4", "5", "impacto");
            if (dat18 != null && dat18.Rows.Count > 0)
            {
                ca += dat18.Rows[0]["respuesta"].ToString() + "@";//54
            }

            DataTable dat19 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "5", "5", "impacto");
            if (dat19 != null && dat19.Rows.Count > 0)
            {
                ca += dat19.Rows[0]["respuesta"].ToString() + "@";//55
            }

            DataTable dat20 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "6", "5", "impacto");
            if (dat20 != null && dat20.Rows.Count > 0)
            {
                ca += dat20.Rows[0]["respuesta"].ToString() + "@";//56
            }

            DataTable dat21 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "7", "5", "impacto");
            if (dat21 != null && dat21.Rows.Count > 0)
            {
                ca += dat21.Rows[0]["respuesta"].ToString() + "@";//57
            }

            DataTable dat22 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "8", "5", "impacto");
            if (dat22 != null && dat14.Rows.Count > 0)
            {
                ca += dat22.Rows[0]["respuesta"].ToString() + "@";//58
            }

            DataTable dat23 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "1", "5", "impacto");
            if (dat23 != null && dat23.Rows.Count > 0)
            {
                ca += dat15.Rows[0]["respuesta"].ToString() + "@";//59
            }

            DataTable dat24 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "2", "5", "impacto");
            if (dat24 != null && dat24.Rows.Count > 0)
            {
                ca += dat24.Rows[0]["respuesta"].ToString() + "@";//60
            }

            DataTable dat25 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "3", "5", "impacto");
            if (dat25 != null && dat25.Rows.Count > 0)
            {
                ca += dat25.Rows[0]["respuesta"].ToString() + "@";//61
            }

            DataTable dat26 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "4", "5", "impacto");
            if (dat26 != null && dat26.Rows.Count > 0)
            {
                ca += dat26.Rows[0]["respuesta"].ToString() + "@";//62
            }

            DataTable dat27 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "5", "5", "impacto");
            if (dat27 != null && dat27.Rows.Count > 0)
            {
                ca += dat27.Rows[0]["respuesta"].ToString() + "@";//63
            }

            DataTable dat28 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "6", "5", "impacto");
            if (dat28 != null && dat28.Rows.Count > 0)
            {
                ca += dat28.Rows[0]["respuesta"].ToString() + "@";//64
            }

            DataTable dat29 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "7", "5", "impacto");
            if (dat29 != null && dat29.Rows.Count > 0)
            {
                ca += dat29.Rows[0]["respuesta"].ToString() + "@";//65
            }

            DataTable dat30 = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "9", "8", "5", "impacto");
            if (dat30 != null && dat30.Rows.Count > 0)
            {
                ca += dat30.Rows[0]["respuesta"].ToString() + "@";//66
            }

            DataTable datos13 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "3", "5", "impacto");

            if (datos13 != null && datos13.Rows.Count > 0)
            {
                for (int i = 0; i < datos13.Rows.Count; i++)
                {
                    ca += datos13.Rows[i]["comentario"].ToString() + "@";//67
                }
            }

            DataTable datos14 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "4", "5", "impacto");

            if (datos14 != null && datos14.Rows.Count > 0)
            {
                for (int i = 0; i < datos14.Rows.Count; i++)
                {
                    ca += datos14.Rows[i]["comentario"].ToString() + "@";//67
                }
            }

            DataTable datos15 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "5", "5", "impacto");

            if (datos15 != null && datos15.Rows.Count > 0)
            {
                for (int i = 0; i < datos15.Rows.Count; i++)
                {
                    ca += datos15.Rows[i]["comentario"].ToString() + "@";//67
                }
            }

            DataTable datos16 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "6", "5", "impacto");

            if (datos16 != null && datos16.Rows.Count > 0)
            {
                for (int i = 0; i < datos16.Rows.Count; i++)
                {
                    ca += datos16.Rows[i]["comentario"].ToString() + "@";//67
                }
            }

            DataTable datos17 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "8", "5", "impacto");

            if (datos17 != null && datos17.Rows.Count > 0)
            {
                for (int i = 0; i < datos17.Rows.Count; i++)
                {
                    ca += datos17.Rows[i]["comentario"].ToString() + "@";//67
                }
            }

            DataTable datos18 = lb.cargarRespuestasAbiertasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "10", "5", "impacto");

            if (datos18 != null && datos18.Rows.Count > 0)
            {
                for (int i = 0; i < datos18.Rows.Count; i++)
                {
                    ca += datos18.Rows[i]["comentario"].ToString() + "@";//67
                }
            }
        }


        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk1(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
         Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "1", "0", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }

       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk4(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "2", "1", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }



        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk5(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "3", "1", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }



        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk6(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "4", "1", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }



        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk11(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "6", "1", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }



        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk12(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "1", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }



        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarrespuestascerradaschk13(string codasesor)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
            DataTable dat = lb.cargarRespuestasCerradasxInstrumento02_Fase(coddocenteasesor["codigo"].ToString(), "7", "2", "5", "impacto");

            if (dat != null && dat.Rows.Count > 0)
            {
                ca += "true@";
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    ca += dat.Rows[i]["respuesta"].ToString() + "@";//1
                }
            }
        }



        return ca;
    }












    [WebMethod(EnableSession = true)]
    public static string cargarinfoinstitucion()
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataRow datoie = inst.buscarInstitucionxNitTodo(HttpContext.Current.Session["dane"].ToString());

        if (datoie != null)
        {
            ca = "true&";
            ca += datoie["nombre"].ToString() + "&";
            ca += datoie["telefono"].ToString() + "&";
            ca += datoie["fax"].ToString() + "&";
            ca += datoie["email"].ToString() + "&";
            ca += datoie["direccion"].ToString() + "&";
            ca += datoie["web"].ToString() + "&";
            ca += datoie["codigo"].ToString();
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarasesores()
    {
        string ca = "";

        Asesores ase = new Asesores();
        DataTable datos = ase.cargarAsesores();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "true&";
            ca += "<option value='0' disabled selected>Seleccione asesor</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarasesor()
    {
        string ca = "";
        string val = "0";
        Asesores ase = new Asesores();
        LineaBase lb = new LineaBase();
        DataTable datos = ase.cargarAsesores();
        DataRow datoie = lb.buscarDocenteAsesorPorIdDocente(HttpContext.Current.Session["identificacion"].ToString());
        

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione asesor</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datoie != null)
                {
                    if (datos.Rows[i]["codigo"].ToString() == datoie["codasesor"].ToString())
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "' selected>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                        val = "1";
                    }
                    else
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                    }
                }
            }
        }

        if (val == "1")
        {
            ca += "&true";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardarpreguntasabiertas(string codasesor, string respuesta, string pregunta, string accion)
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        Asesores ase = new Asesores();
        Docentes doc = new Docentes();

        DataRow coddocenteasesor = ase.buscarCodDocenteAsesor(codasesor, HttpContext.Current.Session["identificacion"].ToString());

        if (coddocenteasesor != null)
        {
           
            switch (pregunta)
            {
                case "2":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "2.2":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "2.3":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "2.4":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "7.1":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "7.2":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "7.3":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "7.4":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "9.1":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "9.2":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "9.3":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "9.4":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "3":
                    if (respuesta == "") { respuesta = ""; }
                     lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                     lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    break;
                case "4":
                    if (respuesta == "") { respuesta = ""; }
                    lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                    lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    break;
                case "5":
                    if (respuesta == "") { respuesta = ""; }
                    lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                    lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    break;
                case "6":
                    if (respuesta == "") { respuesta = ""; }
                    lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                    lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    break;
                case "8":
                    if (respuesta == "") { respuesta = ""; }
                    lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                    lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    break;
                case "10":
                    if (respuesta == "") { respuesta = ""; }
                    lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                    lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    break;
                case "11.1":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.2":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.3":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.4":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.5":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.6":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.7":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.8":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.9":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.10":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.11":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
                case "11.12":
                    if (accion == "delete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    else if (accion == "nodelete")
                    {
                        if (respuesta == "") { respuesta = ""; }
                        lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                    }
                    break;
            }
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", "5", "impacto");

            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", "5", "impacto");

            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", "5", "impacto");

            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "3", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "4", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "5", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "6", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "8", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "10", "5", "impacto");

            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.1", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.2", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.3", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.4", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.5", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.6", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.7", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.8", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.9", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.10", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.11", "5", "impacto");
            //lb.eliminarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.12", "5", "impacto");

            //if (preg2_nombre_1 == "") { preg2_nombre_1 = ""; }
            //if (preg2_duracion_1 == "") { preg2_duracion_1 = ""; }
            //if (preg2_anio_1 == "") { preg2_anio_1 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", preg2_nombre_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", preg2_duracion_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.1", preg2_anio_1, "5", "impacto");

            //if (preg2_nombre_2 == "") { preg2_nombre_2 = ""; }
            //if (preg2_duracion_2 == "") { preg2_duracion_2 = ""; }
            //if (preg2_anio_2 == "") { preg2_anio_2 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", preg2_nombre_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", preg2_duracion_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.2", preg2_anio_2, "5", "impacto");

            //if (preg2_nombre_3 == "") { preg2_nombre_3 = ""; }
            //if (preg2_duracion_3 == "") { preg2_duracion_3 = ""; }
            //if (preg2_anio_3 == "") { preg2_anio_3 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", preg2_nombre_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", preg2_duracion_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.3", preg2_anio_3, "5", "impacto");

            //if (preg2_nombre_4 == "") { preg2_nombre_4 = ""; }
            //if (preg2_duracion_4 == "") { preg2_duracion_4 = ""; }
            //if (preg2_anio_4 == "") { preg2_anio_4 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", preg2_nombre_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", preg2_duracion_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "2.4", preg2_anio_4, "5", "impacto");

            ////preg 7
            //if (preg7nombre_1 == "") { preg7nombre_1 = ""; }
            //if (preg7duracion_1 == "") { preg7duracion_1 = ""; }
            //if (preg7anio_1 == "") { preg7anio_1 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", preg7nombre_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", preg7duracion_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.1", preg7anio_1, "5", "impacto");

            //if (preg7nombre_2 == "") { preg7nombre_2 = ""; }
            //if (preg7duracion_2 == "") { preg7duracion_2 = ""; }
            //if (preg7anio_2 == "") { preg7anio_2 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", preg7nombre_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", preg7duracion_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.2", preg7anio_2, "5", "impacto");

            //if (preg7nombre_3 == "") { preg7nombre_3 = ""; }
            //if (preg7duracion_3 == "") { preg7duracion_3 = ""; }
            //if (preg7anio_3 == "") { preg7anio_3 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", preg7nombre_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", preg7duracion_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.3", preg7anio_3, "5", "impacto");

            //if (preg7nombre_4 == "") { preg7nombre_4 = ""; }
            //if (preg7duracion_4 == "") { preg7duracion_4 = ""; }
            //if (preg7anio_4 == "") { preg7anio_4 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", preg7nombre_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", preg7duracion_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "7.4", preg7anio_4, "5", "impacto");

            ////Preg 9
            //if (preg9nombre_1 == "") { preg9nombre_1 = ""; }
            //if (preg9duracion_1 == "") { preg9duracion_1 = ""; }
            //if (preg9anio_1 == "") { preg9anio_1 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", preg9nombre_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", preg9duracion_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.1", preg9anio_1, "5", "impacto");

            //if (preg9nombre_2 == "") { preg9nombre_2 = ""; }
            //if (preg9duracion_2 == "") { preg9duracion_2 = ""; }
            //if (preg9anio_2 == "") { preg9anio_2 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", preg9nombre_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", preg9duracion_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.2", preg9anio_2, "5", "impacto");

            //if (preg9nombre_3 == "") { preg9nombre_3 = ""; }
            //if (preg9duracion_3 == "") { preg9duracion_3 = ""; }
            //if (preg9anio_3 == "") { preg9anio_3 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", preg9nombre_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", preg9duracion_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.3", preg9anio_3, "5", "impacto");

            //if (preg9nombre_4 == "") { preg9nombre_4 = ""; }
            //if (preg9duracion_4 == "") { preg9duracion_4 = ""; }
            //if (preg9anio_4 == "") { preg9anio_4 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", preg9nombre_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", preg9duracion_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "9.4", preg9anio_4, "5", "impacto");

            //if (txtpedago == "") { txtpedago = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "3", txtpedago, "5", "impacto");

            //if (txtpromueve == "") { txtpromueve = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "4", txtpromueve, "5", "impacto");

            //if (txtparticipado == "") { txtparticipado = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "5", txtparticipado, "5", "impacto");

            //if (txtinvestiga == "") { txtinvestiga = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "6", txtinvestiga, "5", "impacto");

            //if (preg8rbforma == "") { preg8rbforma = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "8", preg8rbforma, "5", "impacto");

            //if (preg10rbforma == "") { preg10rbforma = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "10", preg10rbforma, "5", "impacto");

            ////Preg 11
            //if (preg11_1 == "") { preg11_1 = ""; }
            //if (preg11_2 == "") { preg11_2 = ""; }
            //if (preg11_3 == "") { preg11_3 = ""; }
            //if (preg11_4 == "") { preg11_4 = ""; }
            //if (preg11_5 == "") { preg11_5 = ""; }
            //if (preg11_6 == "") { preg11_6 = ""; }
            //if (preg11_7 == "") { preg11_7 = ""; }
            //if (preg11_8 == "") { preg11_8 = ""; }
            //if (preg11_9 == "") { preg11_9 = ""; }
            //if (preg11_10 == "") { preg11_10 = ""; }
            //if (preg11_11 == "") { preg11_11 = ""; }
            //if (preg11_12 == "") { preg11_12 = ""; }
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.1", preg11_1, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.2", preg11_2, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.3", preg11_3, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.4", preg11_4, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.5", preg11_5, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.6", preg11_6, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.7", preg11_7, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.8", preg11_8, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.9", preg11_9, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.10", preg11_10, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.11", preg11_11, "5", "impacto");
            //lb.AgregarRespuestaAbierta_Fase(coddocenteasesor["codigo"].ToString(), "11.12", preg11_12, "5", "impacto");
        }
        else//Si existe Asesor hace el cambio
        {
            DataRow docente = doc.buscarDocenteMatriculadoxID(HttpContext.Current.Session["identificacion"].ToString());

            if (docente != null)
            {
                DataRow docenteasesor = lb.buscarCodDocenteAsesorxDocente(docente["cod"].ToString());
                if (docenteasesor != null)
                {
                    lb.actualizarCodDocenteAsesorxDocente(docenteasesor["codigo"].ToString(), codasesor);
                     //DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                     //if (coddocenteasesor2 != null)
                     //{
                         if (respuesta == "") { respuesta = ""; }
                         switch (pregunta)
                         {
                             case "2.1":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.1", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.1", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.1", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "2.2":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "2.3":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.3", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.3", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.3", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "2.4":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.4", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.4", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.4", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "7.1":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "7.2":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "7.3":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "7.4":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "9.1":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "9.2":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "9.3":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "9.4":
                                 if (accion == "delete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 else if (accion == "nodelete")
                                 {
                                     if (respuesta == "") { respuesta = ""; }
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 }
                                 break;
                             case "3":
                                 if (respuesta == "") { respuesta = ""; }
                                 lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                 lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 break;
                             case "4":
                                 if (respuesta == "") { respuesta = ""; }
                                 lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                 lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 break;
                             case "5":
                                 if (respuesta == "") { respuesta = ""; }
                                 lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                 lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 break;
                             case "6":
                                 if (respuesta == "") { respuesta = ""; }
                                 lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                 lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 break;
                             case "8":
                                 if (respuesta == "") { respuesta = ""; }
                                 lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                 lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 break;
                             case "10":
                                 if (respuesta == "") { respuesta = ""; }
                                 lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, "5", "impacto");
                                 lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                 break;
                             case "11.1":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.2":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.3":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.4":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.5":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.6":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.7":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.8":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.9":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.10":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.11":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                             case "11.12":
                                 if (accion == "delete")
                                 {
                                     lb.eliminarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", "5", "impacto");
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 else
                                 {
                                     lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                 }
                                 break;
                         }
                     //}
                }
                else//Si no existe agrega
                {
                    if (respuesta == "") { respuesta = ""; }
                    DataRow coddocenteasesor2 = lb.AgregarDatoDocenteAsesorLineaBase(codasesor, docente["cod"].ToString());
                    if (coddocenteasesor2 != null)
                    {
                        switch (pregunta)
                        {
                            case "2.1":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.1", respuesta, "5", "impacto");
                                break;
                            case "2.2":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "2.3":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.3", respuesta, "5", "impacto");
                                break;
                            case "2.4":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.4", respuesta, "5", "impacto");
                                break;
                            case "7.1":
                                lb.AgregarRespuestaAbierta_Fase(docenteasesor["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "7.2":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "7.3":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "7.4":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "9.1":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "9.2":
                               lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "9.3":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "9.4":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "3":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "4":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "5":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "6":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "8":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "10":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), pregunta, respuesta, "5", "impacto");
                                break;
                            case "11.1":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.2":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.3":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.4":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.5":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.6":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.7":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.8":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.9":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.10":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.11":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                            case "11.12":
                                lb.AgregarRespuestaAbierta_Fase(coddocenteasesor2["codigo"].ToString(), "2.2", respuesta, "5", "impacto");
                                break;
                        }
                    }
                }
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string validarsesion()
    {
        string ca = "";

        HttpContext.Current.Session["valor@sesion"] = "validate";

        return ca;
    }

    //Metodo nuevo

    [WebMethod(EnableSession = true)]
     public static string asesorescarg(){
          string ca = "";

        Asesores ase = new Asesores();
        DataTable datos = ase.cargarAsesores();
        DataRow datos2 = ase.cargarAsesorInstrumento2(HttpContext.Current.Session["identificacion"].ToString(),"impacto","4");

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "true&";
            ca += "<option value='0' disabled selected>Seleccione asesor.</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if(datos2 != null){
                    if (datos.Rows[i]["codigo"].ToString() == datos2["codigo"].ToString())
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'selected>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                    }
                    else
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                    }
                }
                else
                {
                    ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
               
            }
        }

        return ca;
     }

     public   DataRow codDocenteAsesor(string identificacion , string codasesor ){
        LineaBase lb = new LineaBase();
        DataRow coddoas =lb.cargarDatoCasCodDocenteAsesor(identificacion, codasesor);
        
        if(coddoas != null){
            return coddoas;
        }else{
            coddoas= lb.agregarDocenteAsesor(identificacion, codasesor);
            if(coddoas != null){
                return coddoas;
            }else{
                return null;
            }
         return coddoas;
        }

    }

     [WebMethod(EnableSession = true)]
    public static string cargaAsesorActual1()
    {
        string ca = "";

       Asesores ase = new Asesores();
        DataRow datos = ase.cargarAsesorInstrumento2(HttpContext.Current.Session["identificacion"].ToString(),"impacto","4");
           if (datos != null)
        {
            ca = "true&"; 
            ca += "<option value='" + datos["codigo"].ToString() + "' selected>" + datos["nombre"].ToString() + "</option>";
   
        }else{
             ca = "true&"; 
            ca += "<option value='0'>Asesor</option>";
        }
          
    //    if (datos != null )
    //     {    ca = "true&";
    //        ca+="<lable id='asesoractual' value='"+datos.Rows[0]["codigo"].ToString()+"'> "+datos.Rows[0]["nombre"].ToString()+"</label>";
    //     atos.Rows[i]["nombre"].ToString() + "</option>";
    //          }else{
    //              ca = "true&";
    //          ca+="<lable id='asesoractual'>ERROR  "+HttpContext.Current.Session["identificacion"].ToString()+"</label>"; 
    //          }
   

        return ca;
    }
  

}