using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.Services;

public partial class bitacora4_1reporte : System.Web.UI.Page
{
    Estrategias est = new Estrategias();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            obtenerGET();
           
        }
    }
    public void obtenerGET()
    {
        Session["d"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["d"]);

        switch(Session["d"].ToString()){
            case "1":
                lblDesembolso.Text = "primer";
                break;
            case "2":
                lblDesembolso.Text = "segundo";
                break;
            case "3":
                lblDesembolso.Text = "tercer";
                break;
        }

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    //protected void btnRegresar_Click(object sender, EventArgs e)
    //{
    //    if (Session["e"].ToString() == "1")
    //        Response.Redirect("estramomentos.aspx?m=" + Session["m"].ToString());
    //    else if(Session["e"].ToString() == "2")
    //        Response.Redirect("estradosmomentos.aspx?m=" + Session["m"].ToString());
    //}




    //Cargar Departamento
    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "departamento@";
            //ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option selected value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' selected>Seleccione</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar instituciones
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='' selected>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar sedes
    [WebMethod(EnableSession = true)]
    public static string cargarSedesxInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sede@";
            ca += "<option value='' selected>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar grupos de investigación
    [WebMethod(EnableSession = true)]
    public static string cargarGruposInvestigacionxSede(string codSede)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        DataTable datos = est.cargarProyectoSedexSedesxAsesor(codSede, HttpContext.Current.Session["CodAsesorCoordinador"].ToString());

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "grupoinvestigacion@";
            ca += "<option value='' selected>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar grupos de investigación
    [WebMethod(EnableSession = true)]
    public static string cargarLineasInvestigacionxGrupoInvestigacion(string codGrupoinvestigacion)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        DataTable datos = est.cargarLineasInvestigacionxGrupoInvestigacion(codGrupoinvestigacion);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "lineainvestigacion@";
            ca += "<option value='' selected>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }
    
    
    [WebMethod(EnableSession = true)]
    public static string insertbitacora4_1(string grupoinvestigacion, string firmamaestro, string firmanino, string fechadiligenciamiento, string firmaasesor)
    {
        Funciones fun = new Funciones();
        Institucion inst = new Institucion();
        string ca = "";
        DataRow insert = inst.procinsertbitacora4_1(grupoinvestigacion, firmamaestro, firmanino, fun.convertFechaAño(fechadiligenciamiento), firmaasesor, HttpContext.Current.Session["d"].ToString(),"");
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar bitacora4_1@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updatebitacora4_1(string codigoinstrumento, string firmamaestro, string firmanino, string fechadiligenciamiento, string firmaasesor)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdatebitacora4_1(codigoinstrumento, firmamaestro, firmanino, fun.convertFechaAño(fechadiligenciamiento), firmaasesor);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de instrumento bitacora4_1@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string listarBitacora4_1reporte(string codasesorcoordinador)
    {
        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        string ca = "";

        DataTable datos = inst.proclistarBitacora4_1(codasesorcoordinador, HttpContext.Current.Session["d"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            var j = datos.Rows.Count+1;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                j = j - 1;
                ca += "<tr>";
                ca += "<td>" + j + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["desembolso"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaAño(datos.Rows[i]["fechadiligenciamiento"].ToString()) + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500), cargarbitacora4_1reporte(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a></td>"; //,  loadSelectBitacoraTres(" + datos.Rows[i]["codProyecto"].ToString() + "), traerPreguntasTres(" + datos.Rows[i]["codigo"].ToString() + "
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron Bitacoras 4.1 registradas por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codigoinstrumento)
    {
        string ca = "";

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        DataRow datosinstrumento = inst.procloadBitacora4_1(codigoinstrumento);

        if (datosinstrumento != null)
        {
            ca = "true@";//0
            ca += datosinstrumento["codigo"].ToString()//1
                + "@" + fun.convertFechaAño(datosinstrumento["fechadiligenciamiento"].ToString())//2
                + "@" + datosinstrumento["firmamaestro"].ToString()//3
                + "@" + datosinstrumento["firmanino"].ToString()//4
                + "@" + datosinstrumento["firmaasesor"].ToString()//5
                + "@" + datosinstrumento["codigomunicipio"].ToString()//6
                + "@" + datosinstrumento["nombremunicipio"].ToString()//7

                + "@" + datosinstrumento["codigosede"].ToString()//8
                + "@" + datosinstrumento["nombresede"].ToString()//9


                + "@" + datosinstrumento["codigoinstitucion"].ToString()//10
                + "@" + datosinstrumento["nombreins"].ToString()//11

                + "@" + datosinstrumento["codproyectosede"].ToString()//12
                + "@" + datosinstrumento["nombregrupo"].ToString();//13
                    
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string deleteRubrosbitacora4_1(string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procDeleteRubrosInsumos(codigoinstrumento);
        long delete2 = inst.procDeleteRubrosPapeleria(codigoinstrumento);
        long delete3 = inst.procDeleteRubrosTransporte(codigoinstrumento);
        long delete4 = inst.procDeleteRubrosCorreo(codigoinstrumento);
        long delete5 = inst.procDeleteRubrosMaterial(codigoinstrumento);
        long delete6 = inst.procDeleteRubrosRefrigerios(codigoinstrumento);
        if (delete != -1)
        {
            if (delete != -1)
            {
                if (delete != -1)
                {
                    if (delete != -1)
                    {
                        if (delete != -1)
                        {
                            if (delete != -1)
                            {
                                ca = "true@";
                            }
                            else
                            {
                                ca = "Ocurrio un error al eliminar rubros Refrigerios@";
                            }
                        }
                        else
                        {
                            ca = "Ocurrio un error al eliminar rubros Material@";
                        }
                    }
                    else
                    {
                        ca = "Ocurrio un error al eliminar rubros Correo@";
                    }
                }
                else
                {
                    ca = "Ocurrio un error al eliminar rubros Transporte@";
                }
            }
            else
            {
                ca = "Ocurrio un error al eliminar rubros Papeleria@";
            }
        }
        else
        {
            ca = "Ocurrio un error al eliminar rubros Insumos@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertRubrobitacora4_1(string rubro, string codigoinstrumento, string fechagasto, string nombreproveedor, string ccnit, string cantidad, string descripciongasto, string valorunitario, string valortotal)
    {

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        string ca = "";

        switch (rubro)
        {
            case "insumos":
                DataRow insert = inst.procInsertRubro("est_estra1bitacora4punto1_insumos", codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, ccnit, cantidad, descripciongasto, valorunitario, valortotal);
                if (insert != null)
                {
                    ca = "true@";
                }
                else
                {
                    ca = "Ocurrio un error al insertar rubro@";

                }
                break;
            case "papeleria":
                DataRow insert2 = inst.procInsertRubro("est_estra1bitacora4punto1_papeleria", codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, ccnit, cantidad, descripciongasto, valorunitario, valortotal);
                if (insert2 != null)
                {
                    ca = "true@";
                }
                else
                {
                    ca = "Ocurrio un error al insertar rubro@";

                }
                break;
            case "transporte":
                DataRow insert3 = inst.procInsertRubro("est_estra1bitacora4punto1_transporte", codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, ccnit, cantidad, descripciongasto, valorunitario, valortotal);
                if (insert3 != null)
                {
                    ca = "true@";
                }
                else
                {
                    ca = "Ocurrio un error al insertar rubro@";

                }
                break;
            case "correo":
                DataRow insert4 = inst.procInsertRubro("est_estra1bitacora4punto1_correointernet", codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, ccnit, cantidad, descripciongasto, valorunitario, valortotal);
                if (insert4 != null)
                {
                    ca = "true@";
                }
                else
                {
                    ca = "Ocurrio un error al insertar rubro@";

                }
                break;
            case "materialdivulgacion":
                DataRow insert5 = inst.procInsertRubro("est_estra1bitacora4punto1_materialdivulgacion", codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, ccnit, cantidad, descripciongasto, valorunitario, valortotal);
                if (insert5 != null)
                {
                    ca = "true@";
                }
                else
                {
                    ca = "Ocurrio un error al insertar rubro@";

                }
                break;

            case "refrigerios":
                DataRow insert6 = inst.procInsertRubro("est_estra1bitacora4punto1_refrigerios", codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, ccnit, cantidad, descripciongasto, valorunitario, valortotal);
                if (insert6 != null)
                {
                    ca = "true@";
                }
                else
                {
                    ca = "Ocurrio un error al insertar rubro@";

                }
                break;
            default:
                break;
        }
        

        

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadRubrosbitacora4_1reporte(string rubro, string codigoinstrumento, int total)
    {
        //string ca = "";

        //Institucion inst = new Institucion();

        //DataTable datos = inst.procloadMaterialestrag008(codigoinstrumento);

        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    ca = "mat@";
        //    ca += "<tr><th> Fecha del gasto</th>";
        //    ca += "<th> Nombre del proveedor </th>";
        //    ca += "<th> Descripción del gasto </th>";
        //    ca += "<th> Valor unitario </th>";
        //    ca += "<th> Valor total </th>";
        //    ca += "</tr> ";
        //    //ca += "@" + datoUsuario["cod"].ToString();
        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        ca += "<tr id=\"campus" + total + "\">";
        //        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"fechagasto" + total + "\" name =\"fechagasto" + total + "\"  value=\"" + datos.Rows[i]["fechagasto"].ToString() + "\"></td>";
        //        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor" + total + "\" name =\"nombreproveedor" + total + "\"  value=\"" + datos.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
        //        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto" + total + "\" name =\"descripciongasto" + total + "\" value=\"" + datos.Rows[i]["descripciongasto"].ToString() + "\"></td>";
        //        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario" + total + "\" name =\"valorunitario" + total + "\" onkeypress=\"return valideKey(event);\" value=\"" + datos.Rows[i]["valorunitario"].ToString() + "\"></td>";

        //        ca += "<td><table width=\"100%\"><tr id=\"radiotr" + total + "\"><td><input type=\"text\" id =\"valortotal" + total + "\" name =\"valortotal" + total + "\"  onkeypress =\"return valideKey(event);\" value=\"" + datos.Rows[i]["valortotal"].ToString() + "\" /></td>";

        //        if (i == datos.Rows.Count - 1)
        //        {
        //            ca += "<td><button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > -</button></td>";
        //        }
        //        else
        //        {
        //            ca += "<td></td>";
        //            total = total + 1;
        //        }
        //        ca += "</tr></table></td>";


        //    }
        //    ca += "@" + total;
        //}
        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        string ca = "";

        switch (rubro)
        {
            case "insumos":
                //DataRow insert = inst.procloadRubro("est_estra1bitacora4punto1_insumos", codigoinstrumento);
                DataTable datos = inst.procloadRubro("est_estra1bitacora4punto1_insumos", codigoinstrumento);

                if (datos != null && datos.Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<tr id=\"campus1_" + total + "\">";
                        ca += "<td align=\"center\" ><input type=\"datetime\" class=\"TextBox width-100\" id =\"fechagasto1_" + total + "\" name =\"fechagasto1_" + total + "\"  value=\"" + fun.convertFechaAño(datos.Rows[i]["fechagasto"].ToString()) + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor1_" + total + "\" name =\"nombreproveedor1_" + total + "\"  value=\"" + datos.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"ccnit1_" + total + "\" name =\"ccnit1_" + total + "\"  value=\"" + datos.Rows[i]["ccnit"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"cantidad1_" + total + "\" name =\"cantidad1_" + total + "\"  value=\"" + datos.Rows[i]["cantidad"].ToString() + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(1," + total + ")\" \"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto1_" + total + "\" name =\"descripciongasto1_" + total + "\"  value=\"" + datos.Rows[i]["descripcion"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario1_" + total + "\" name =\"valorunitario1_" + total + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(1," + total + ")\" value=\"" + datos.Rows[i]["valorunitario"].ToString() + "\"></td>";

                        ca += "<td><table width=\"100%\"><tr id=\"radiotr1_" + total + "\"><td><input type=\"text\" id =\"valortotal1_" + total + "\" name =\"valortotal1_" + total + "\"  disabled value=\"" + datos.Rows[i]["valortotal"].ToString() + "\"  class=\"TextBox\"/></td>";

                        if (datos.Rows.Count != 1)
                        {
                            if (i == datos.Rows.Count - 1)
                            {
                                ca += "<td><button id=\"remove1\" class=\"btn btn-danger\" onclick=\"fRemove(1," + total + ")\" > -</button></td>";
                            }
                            else
                            {
                                ca += "<td></td>";
                                total = total + 1;
                            }
                        }
                        else
                        {
                            ca += "<td></td>";
                            //total = total + 1;
                        }
                        
                        ca += "</tr></table></td>";
                    }
                    ca += "@" + total;
                }
                else
                {
                    ca += "<tr><td><input type=\"datetime\" id=\"fechagasto1_1\" name=\"fechagasto1_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"nombreproveedor1_1\" name=\"nombreproveedor1_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"ccnit1_1\" name=\"ccnit1_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"cantidad1_1\" onblur=\"valortotal(1,1)\" name=\"cantidad1_1\" onkeypress=\"return valideKey(event);\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"descripciongasto1_1\" name=\"descripciongasto1_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valorunitario1_1\" name=\"valorunitario1_1\"  onkeypress=\"return valideKey(event);\" onblur=\"valortotal(1,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valortotal1_1\" name=\"valortotal1_1\" class=\"width-100 TextBox\" disabled /></td></tr>";
                    ca += "@" + total;
                }
                break;
            case "papeleria":
                DataTable datos2 = inst.procloadRubro("est_estra1bitacora4punto1_papeleria", codigoinstrumento);

                if (datos2 != null && datos2.Rows.Count > 0)
                {
                    for (int i = 0; i < datos2.Rows.Count; i++)
                    {
                        ca += "<tr id=\"campus2_" + total + "\">";
                        ca += "<td align=\"center\" ><input type=\"datetime\" class=\"TextBox width-100\" id =\"fechagasto2_" + total + "\" name =\"fechagasto2_" + total + "\"  value=\"" + fun.convertFechaAño(datos2.Rows[i]["fechagasto"].ToString()) + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor2_" + total + "\" name =\"nombreproveedor2_" + total + "\"  value=\"" + datos2.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"ccnit2_" + total + "\" name =\"ccnit2_" + total + "\"  value=\"" + datos2.Rows[i]["ccnit"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"cantidad2_" + total + "\" name =\"cantidad2_" + total + "\"  value=\"" + datos2.Rows[i]["cantidad"].ToString() + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(2," + total + ")\" \"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto2_" + total + "\" name =\"descripciongasto2_" + total + "\"  value=\"" + datos2.Rows[i]["descripcion"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario2_" + total + "\" name =\"valorunitario2_" + total + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(2," + total + ")\" value=\"" + datos2.Rows[i]["valorunitario"].ToString() + "\"></td>";

                        ca += "<td><table width=\"100%\"><tr id=\"radiotr2_" + total + "\"><td><input type=\"text\" id =\"valortotal2_" + total + "\" name =\"valortotal2_" + total + "\"  disabled value=\"" + datos2.Rows[i]["valortotal"].ToString() + "\" class=\"TextBox\"/></td>";

                        if (datos2.Rows.Count != 1)
                        {
                            if (i == datos2.Rows.Count - 1)
                            {
                                ca += "<td><button id=\"remove2\" class=\"btn btn-danger\" onclick=\"fRemove(2," + total + ")\" > -</button></td>";
                            }
                            else
                            {
                                ca += "<td></td>";
                                total = total + 1;
                            }
                        }
                        else
                        {
                            ca += "<td></td>";
                        }
                        ca += "</tr></table></td>";
                    }
                    ca += "@" + total;

                }
                else
                {
                    ca += "<tr><td><input type=\"datetime\" id=\"fechagasto2_1\" name=\"fechagasto2_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"nombreproveedor2_1\" name=\"nombreproveedor2_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"ccnit2_1\" name=\"ccnit2_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"cantidad2_1\" name=\"cantidad2_1\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(2,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"descripciongasto2_1\" name=\"descripciongasto2_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valorunitario2_1\" name=\"valorunitario2_1\"  onkeypress=\"return valideKey(event);\" onblur=\"valortotal(2,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valortotal2_1\" name=\"valortotal2_1\" class=\"width-100 TextBox\" disabled/></td></tr>";
                    ca += "@" + total;
                }
                break;
            case "transporte":
                DataTable datos3 = inst.procloadRubro("est_estra1bitacora4punto1_transporte", codigoinstrumento);

                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        ca += "<tr id=\"campus3_" + total + "\">";
                        ca += "<td align=\"center\" ><input type=\"datetime\" class=\"TextBox width-100\" id =\"fechagasto3_" + total + "\" name =\"fechagasto3_" + total + "\"  value=\"" + fun.convertFechaAño(datos3.Rows[i]["fechagasto"].ToString()) + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor3_" + total + "\" name =\"nombreproveedor3_" + total + "\"  value=\"" + datos3.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"ccnit3_" + total + "\" name =\"ccnit3_" + total + "\"  value=\"" + datos3.Rows[i]["ccnit"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"cantidad3_" + total + "\" name =\"cantidad3_" + total + "\"  value=\"" + datos3.Rows[i]["cantidad"].ToString() + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(3," + total + ")\" \"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto3_" + total + "\" name =\"descripciongasto3_" + total + "\"  value=\"" + datos3.Rows[i]["descripcion"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario3_" + total + "\" name =\"valorunitario3_" + total + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(3," + total + ")\" value=\"" + datos3.Rows[i]["valorunitario"].ToString() + "\"></td>";

                        ca += "<td><table width=\"100%\"><tr id=\"radiotr3_" + total + "\"><td><input type=\"text\" id =\"valortotal3_" + total + "\" name =\"valortotal3_" + total + "\"  disabled value=\"" + datos3.Rows[i]["valortotal"].ToString() + "\" class=\"TextBox\" /></td>";

                        if (datos3.Rows.Count != 1)
                        {
                            if (i == datos3.Rows.Count - 1)
                            {
                                ca += "<td><button id=\"remove3\" class=\"btn btn-danger\" onclick=\"fRemove(3," + total + ")\" > -</button></td>";
                            }
                            else
                            {
                                ca += "<td></td>";
                                total = total + 1;
                            }
                        }
                        else
                        {
                            ca += "<td></td>";
                        }
                        ca += "</tr></table></td>";
                    }
                    ca += "@" + total;

                }
                else
                {
                    ca += "<tr><td><input type=\"datetime\" id=\"fechagasto3_1\" name=\"fechagasto3_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"nombreproveedor3_1\" name=\"nombreproveedor3_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"ccnit3_1\" name=\"ccnit3_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"cantidad3_1\" name=\"cantidad3_1\" onkeypress=\"return valideKey(event);\"  onblur=\"valortotal(3,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"descripciongasto3_1\" name=\"descripciongasto3_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valorunitario3_1\" name=\"valorunitario3_1\"  onkeypress=\"return valideKey(event);\" onblur=\"valortotal(3,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valortotal3_1\" name=\"valortotal3_1\" class=\"width-100 TextBox\" disabled/></td></tr>";
                    ca += "@" + total;
                }
                break;
            case "correo":
                DataTable datos4 = inst.procloadRubro("est_estra1bitacora4punto1_correointernet", codigoinstrumento);

                if (datos4 != null && datos4.Rows.Count > 0)
                {
                    for (int i = 0; i < datos4.Rows.Count; i++)
                    {
                        ca += "<tr id=\"campus4_" + total + "\">";
                        ca += "<td align=\"center\" ><input type=\"datetime\" class=\"TextBox width-100\" id =\"fechagasto4_" + total + "\" name =\"fechagasto4_" + total + "\"  value=\"" + fun.convertFechaAño(datos4.Rows[i]["fechagasto"].ToString()) + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor4_" + total + "\" name =\"nombreproveedor4_" + total + "\"  value=\"" + datos4.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"ccnit4_" + total + "\" name =\"ccnit4_" + total + "\"  value=\"" + datos4.Rows[i]["ccnit"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"cantidad4_" + total + "\" name =\"cantidad4_" + total + "\"  value=\"" + datos4.Rows[i]["cantidad"].ToString() + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(4," + total + ")\" \"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto4_" + total + "\" name =\"descripciongasto4_" + total + "\"  value=\"" + datos4.Rows[i]["descripcion"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario4_" + total + "\" name =\"valorunitario4_" + total + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(4," + total + ")\" value=\"" + datos4.Rows[i]["valorunitario"].ToString() + "\"></td>";

                        ca += "<td><table width=\"100%\"><tr id=\"radiotr4_" + total + "\"><td><input type=\"text\" id =\"valortotal4_" + total + "\" name =\"valortotal4_" + total + "\"  disabled value=\"" + datos4.Rows[i]["valortotal"].ToString() + "\" class=\"TextBox\" /></td>";

                        if (datos4.Rows.Count != 1)
                        {
                            if (i == datos4.Rows.Count - 1)
                            {
                                ca += "<td><button id=\"remove4\" class=\"btn btn-danger\" onclick=\"fRemove(4," + total + ")\" > -</button></td>";
                            }
                            else
                            {
                                ca += "<td></td>";
                                total = total + 1;
                            }
                        }
                        else
                        {
                            ca += "<td></td>";
                        }
                        ca += "</tr></table></td>";
                    }
                    ca += "@" + total;

                }
                else
                {
                    ca += "<tr><td><input type=\"datetime\" id=\"fechagasto4_1\" name=\"fechagasto4_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"nombreproveedor4_1\" name=\"nombreproveedor4_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"ccnit4_1\" name=\"ccnit4_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"cantidad4_1\" name=\"cantidad4_1\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(4,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"descripciongasto4_1\" name=\"descripciongasto4_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valorunitario4_1\" name=\"valorunitario4_1\"  onkeypress=\"return valideKey(event);\" onblur=\"valortotal(4,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valortotal4_1\" name=\"valortotal4_1\" class=\"width-100 TextBox\" disabled/></td></tr>";
                    ca += "@" + total;
                }
                break;
            case "materialdivulgacion":
                DataTable datos5 = inst.procloadRubro("est_estra1bitacora4punto1_materialdivulgacion", codigoinstrumento);

                if (datos5 != null && datos5.Rows.Count > 0)
                {
                    for (int i = 0; i < datos5.Rows.Count; i++)
                    {
                        ca += "<tr id=\"campus5_" + total + "\">";
                        ca += "<td align=\"center\" ><input type=\"datetime\" class=\"TextBox width-100\" id =\"fechagasto5_" + total + "\" name =\"fechagasto5_" + total + "\"  value=\"" + fun.convertFechaAño(datos5.Rows[i]["fechagasto"].ToString()) + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor5_" + total + "\" name =\"nombreproveedor5_" + total + "\"  value=\"" + datos5.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"ccnit5_" + total + "\" name =\"ccnit5_" + total + "\"  value=\"" + datos5.Rows[i]["ccnit"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"cantidad5_" + total + "\" name =\"cantidad5_" + total + "\"  value=\"" + datos5.Rows[i]["cantidad"].ToString() + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(5," + total + ")\" \"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto5_" + total + "\" name =\"descripciongasto5_" + total + "\"  value=\"" + datos5.Rows[i]["descripcion"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario5_" + total + "\" name =\"valorunitario5_" + total + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(5," + total + ")\" value=\"" + datos5.Rows[i]["valorunitario"].ToString() + "\"></td>";

                        ca += "<td><table width=\"100%\"><tr id=\"radiotr5_" + total + "\"><td><input type=\"text\" id =\"valortotal5_" + total + "\" name =\"valortotal5_" + total + "\"  disabled value=\"" + datos5.Rows[i]["valortotal"].ToString() + "\" class=\"TextBox\" /></td>";

                        if (datos5.Rows.Count != 1)
                        {
                            if (i == datos5.Rows.Count - 1)
                            {
                                ca += "<td><button id=\"remove5\" class=\"btn btn-danger\" onclick=\"fRemove(5," + total + ")\" > -</button></td>";
                            }
                            else
                            {
                                ca += "<td></td>";
                                total = total + 1;
                            }
                        }
                        else
                        {
                            ca += "<td></td>";
                        }
                        ca += "</tr></table></td>";
                    }
                    ca += "@" + total;

                }
                else
                {
                    ca += "<tr><td><input type=\"datetime\" id=\"fechagasto5_1\" name=\"fechagasto5_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"nombreproveedor5_1\" name=\"nombreproveedor5_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"ccnit5_1\" name=\"ccnit5_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"cantidad5_1\" name=\"cantidad5_1\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(5,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"descripciongasto5_1\" name=\"descripciongasto5_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valorunitario5_1\" name=\"valorunitario5_1\"  onkeypress=\"return valideKey(event);\" onblur=\"valortotal(5,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valortotal5_1\" name=\"valortotal5_1\" class=\"width-100 TextBox\" disabled/></td></tr>";
                    ca += "@" + total;
                }
                break;

            case "refrigerios":
                DataTable datos6 = inst.procloadRubro("est_estra1bitacora4punto1_refrigerios", codigoinstrumento);

                if (datos6 != null && datos6.Rows.Count > 0)
                {
                    for (int i = 0; i < datos6.Rows.Count; i++)
                    {
                        ca += "<tr id=\"campus6_" + total + "\">";
                        ca += "<td align=\"center\" ><input type=\"datetime\" class=\"TextBox width-100\" id =\"fechagasto6_" + total + "\" name =\"fechagasto6_" + total + "\"  value=\"" + fun.convertFechaAño(datos6.Rows[i]["fechagasto"].ToString()) + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor6_" + total + "\" name =\"nombreproveedor6_" + total + "\"  value=\"" + datos6.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"ccnit6_" + total + "\" name =\"ccnit6_" + total + "\"  value=\"" + datos6.Rows[i]["ccnit"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"cantidad6_" + total + "\" name =\"cantidad6_" + total + "\"  value=\"" + datos6.Rows[i]["cantidad"].ToString() + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(6," + total + ")\" \"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto6_" + total + "\" name =\"descripciongasto6_" + total + "\"  value=\"" + datos6.Rows[i]["descripcion"].ToString() + "\"></td>";
                        ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario6_" + total + "\" name =\"valorunitario6_" + total + "\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(6," + total + ")\" value=\"" + datos6.Rows[i]["valorunitario"].ToString() + "\"></td>";

                        ca += "<td><table width=\"100%\"><tr id=\"radiotr6_" + total + "\"><td><input type=\"text\" id =\"valortotal6_" + total + "\" name =\"valortotal6_" + total + "\"  disabled value=\"" + datos6.Rows[i]["valortotal"].ToString() + "\" class=\"TextBox\" /></td>";

                        if (datos6.Rows.Count != 1)
                        {
                            if (i == datos6.Rows.Count - 1)
                            {
                                ca += "<td><button id=\"remove6\" class=\"btn btn-danger\" onclick=\"fRemove(6," + total + ")\" > -</button></td>";
                            }
                            else
                            {
                                ca += "<td></td>";
                                total = total + 1;
                            }
                        }
                        else
                        {
                            ca += "<td></td>";

                        }
                        ca += "</tr></table></td>";
                    }
                    ca += "@" + total;

                }
                else
                {
                    ca += "<tr><td><input type=\"datetime\" id=\"fechagasto6_1\" name=\"fechagasto6_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"nombreproveedor6_1\" name=\"nombreproveedor6_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"ccnit6_1\" name=\"ccnit6_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"cantidad6_1\" name=\"cantidad6_1\" onkeypress=\"return valideKey(event);\" onblur=\"valortotal(6,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"descripciongasto6_1\" name=\"descripciongasto6_1\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valorunitario6_1\" name=\"valorunitario6_1\"  onkeypress=\"return valideKey(event);\" onblur=\"valortotal(6,1)\" class=\"width-100 TextBox\"/></td><td><input type=\"text\" id=\"valortotal6_1\" name=\"valortotal6_1\" class=\"width-100 TextBox\" disabled/></td></tr>";
                    ca += "@" + total;
                }
                break;
            default:
                break;
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletebitacora4_1(string codigo)
    {
        string ca = "";
        Institucion inst = new Institucion();

      
            inst.eliminarDetalleBitacora4punto1_correo(codigo);
            inst.eliminarDetalleBitacora4punto1_insumos(codigo);
            inst.eliminarDetalleBitacora4punto1_materialdivulgacion(codigo);
            inst.eliminarDetalleBitacora4punto1_papeleria(codigo);
            inst.eliminarDetalleBitacora4punto1_refrigerios(codigo);
            inst.eliminarDetalleBitacora4punto1_transporte(codigo);
            inst.eliminarEncabezadoBitacora4punto1(codigo);
            ca = "delete@";
     
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistasesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesoresSeguimiento("1");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor...</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }

}