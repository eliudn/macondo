using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;

public partial class estrag006_estrategia1 : System.Web.UI.Page
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
            //obtenerGET();
            //if (Session["e"] != null)
            //{
                if (Session["identificacion"] != null)
                {
                    DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                    if (dato != null)
                    {
                        Session["CodEstraAsesorCoordinador"] = dato["codigo"].ToString();
                      
                    }
                }
         
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"].ToString() == "1")
            Response.Redirect("estramomentos.aspx?m=" + lblMomento.Text);
        else if (Session["e"].ToString() == "2")
            Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text + "&s=" + lblSesion.Text);
    }
   
    [WebMethod(EnableSession = true)]
    public static string cargarListadoMaterialesAsesor()
    {
        string ca = "";

        Institucion inst = new Institucion();

        //int pagint = Convert.ToInt32(page);
        //int rowsint = Convert.ToInt32(rows);
        //int offset = (pagint - 1) * rowsint;

        DataTable datosmateriales = inst.cargarListadoMaterialesxAsesorEstra1(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString(), "0", "1000");

        if (datosmateriales != null && datosmateriales.Rows.Count > 0)
        {
            DataTable datosCount = inst.cargarListadoMaterialesxAsesorCountEstra1(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString());

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

            for (int i = 0; i < datosmateriales.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["asesor"].ToString() + "</td>";
                //ca += "<td>" + datosmateriales.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td align=\"center\"><br /><a class='btn btn-success' onclick=\"$('#listTable').hide(), $('#formTable').fadeIn(500), loadInstrumento(" + datosmateriales.Rows[i]["codigo"].ToString() + ")\">Editar</a><br/ ><br /><a href=\"estrag006Evidencia_estra1.aspx?cod=" + datosmateriales.Rows[i]["codigo"].ToString() + "\" class=\"btn btn-primary\">Evidencias</a><br/ ><br /><a onclick=\" eliminar(" + datosmateriales.Rows[i]["codigo"].ToString() + ") \" class=\"btn btn-danger\">Eliminar</a><br/ ><br /></td>";
                ca += "</tr>";
            }

            //ca += "@";
            //for (int j = 0; j < val; j++)
            //{
            //    if (pagint == (j + 1))
            //    {
            //        ca += " <span id='span" + (j + 1) + "' class=\"item current\" onclick='cargarListadoMemorias(\"" + (j + 1) + "\",\"10\")'>" + (j + 1) + "</span>";
            //    }
            //    else
            //    {
            //        ca += " <span id='span" + (j + 1) + "' class=\"item\" onclick='cargarListadoMemorias(\"" + (j + 1) + "\",\"10\")'>" + (j + 1) + "</span>";
            //    }
            //}
        }
        else
        {
            ca += "<tr><td colspan='11' align='center'>No se encontraron registros de materiales por parte del asesor.</td></tr>";
        }
     
        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectInstrumentog006Estra1(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            //ca += "<option value='" + dato["codigoredtematica"].ToString() + "'>" + dato["redtematica"].ToString() + "</option>";
        }
        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "departamento@";
            ca += "<option value='' disabled selected>Seleccione departamento</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipioMagdalena(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' disabled selected>Seleccione municipio</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codmunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();
     
        DataTable datos = inst.cargarInstitucionxMunicipio(codmunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institución</option>";
            
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarsedes(string codigoins)
    {
        string ca = "";

        Institucion inst = new Institucion();
        
  
        DataTable datos = inst.cargarSedesInstitucion(codigoins);
       
        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sedes@";
            ca += "<option value='' disabled selected>Seleccione sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string datosSedes(string codigosede)
    {
        string ca = "";

        Institucion inst = new Institucion();

       
        DataRow datossede = inst.cargarDatosSede(codigosede);

        if (datossede != null)
        {
            ca = "datossede&";
            ca += "<option value='0' disabled>Seleccione departamento...</option>"
                + "<option value = '" + datossede["coddepartamento"].ToString() + "' selected>" + datossede["nombredepartamento"].ToString() + "</option>"
                + "&<option value='0' disabled>Seleccione municipio...</option>"
                + "<option value = '" + datossede["codmunicipio"].ToString() + "' selected>" + datossede["nombremunicipio"].ToString() + "</option>"
                + "&" + datossede["telefono"].ToString()
                + "&" + datossede["email"].ToString()
                + "&" + datossede["direccion"].ToString();

        }

        return ca;
    }

    // [WebMethod(EnableSession = true)]
    // public static string grupoInvestigacion(string codigosede)
    // {

        // //Funciones fun = new Funciones();

        // //fun.convertFechaAño();

        // string ca = "";

        // Institucion inst = new Institucion();

        // estrag006 est = new estrag006();

        // DataTable gruposinvestigacion = inst.cargarGruposInvestigacion(codigosede);

        // if (gruposinvestigacion != null && gruposinvestigacion.Rows.Count > 0)
        // {
            // ca = "gruposinvestigacion@";
            // ca += "<option value='' disabled selected>Seleccione grupo investigación...</option>";
            // for (int i = 0; i < gruposinvestigacion.Rows.Count; i++)
            // {
                // ca += "<option value='" + gruposinvestigacion.Rows[i]["codigo"].ToString() + "'>" + gruposinvestigacion.Rows[i]["nombregrupo"].ToString() + "</option>";
                // HttpContext.Current.Session["codProyectoSede"] = gruposinvestigacion.Rows[i]["codigo"].ToString();
            // }
        // }
        // else
        // {
            // ca = "vacio@<option value='sin' disabled selected>Sin grupos de investigación</option>";
        // }

        // return ca;
    // }

   
    [WebMethod(EnableSession = true)]
    public static string updateDatosSede(string codigo, string telefono,string email, string direccion)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        Institucion inst = new Institucion();
        string ca = "";
        
        long update = inst.updateSede(codigo, telefono, email, direccion);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de sedes@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertInstrumento(string fechaentregamaterial1, string codsede, string nombrequienrecibe1)
    {


        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

        string coord = HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString();


        DataRow insert = inst.procinsertIntrumentoEstra1(fun.convertFechaAño(fechaentregamaterial1), codsede, nombrequienrecibe1, coord);
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
            HttpContext.Current.Session["codProyectoSede"] = codsede;
        }
        else
        {
            ca = "Ocurrio un error al insertar datos de instrumento_g006@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.cargarDatosInstrumentoEstra1(codigo);
        HttpContext.Current.Session["codProyectoSede"] = codigo;
        if (datosinstrumento != null)
        {
            ca = "true@";
            ca += datosinstrumento["codasesorcoordinador"].ToString()
                + "@" + datosinstrumento["codsede"].ToString()
                + "@" + datosinstrumento["nombrequienrecibe"].ToString()
                + "@" + datosinstrumento["fechaentregamaterial"].ToString()
                + "@" + datosinstrumento["codigo"].ToString();
            
            
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateInstrumento(string fechaentregamaterial, string nombrequienrecibe,string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.updateInstrumentoEstra1(fun.convertFechaAño(fechaentregamaterial), nombrequienrecibe, codigoinstrumento);
        if (update != -1)
        {
            ca = "true@";


        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de instrumento@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertMaterial(string codigoinstrumento, string nombrematerial, string cantidad, string estado)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.insertMaterialEstra1(codigoinstrumento, nombrematerial, cantidad, estado);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar material@";
        }
        
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deleteMaterial(string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.deleteMaterialEstra1(codigoinstrumento);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar materiales@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadMaterial(string codigoinstrumento,int total)
    {
        string ca = "";
        
        Institucion inst = new Institucion();

        DataTable datos = inst.procloadMaterialEstra1(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "mat@";
            ca += "<tr><th> Nombre del material</th>";
            ca += "<th> Cantidad </th>";
            ca += "<th> Estado <br>";
            ca += "<table width=\"100%\" >";
            ca += "<tr>";
            ca += "<td width =\"30%\"> Si </td>";
            ca += "<td width =\"30%\"> No </td>";
            ca += "</tr>";
            ca += "</table>";
            ca += "</th>";
            ca += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox\" id =\"nombrematerial" + total + "\" name =\"nombrematerial" + total + "\" class=\"width-100\" value=\""+ datos.Rows[i]["nombrematerial"].ToString() + "\" style=\"width:350px;\" disabled></td>";
                ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox\" id =\"cantidad" + total + "\" name =\"cantidad" + total + "\"  onkeypress=\"return valideKey(event);\" class=\"width-100\" value=\"" + datos.Rows[i]["cantidad"].ToString() + "\" style=\"width:50px;\" ></td>";

                ca += "<td><table width=\"100%\" ><tr id=\"radiotr" + total + "\" >";
                ca += "<td width=\"30%\" style =\" text -align: center;\" align =\"center\" >";
                
                
                if(datos.Rows[i]["estado"].ToString() == "Si")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"Si\" ></td>";
                    ca += "<td width=\"30%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"No\"></td>";
                    ca += "<td width=\"40%\" style =\" text-align: center;\" align =\"center\" >";
                }
                else if (datos.Rows[i]["estado"].ToString() == "No")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"Si\" ></td>";
                    ca += "<td width=\"30%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"No\"></td>";
                    ca += "<td width=\"40%\" style =\" text-align: center;\" align =\"center\" >";
                }
                else{

                }

                if (i == datos.Rows.Count-1)
                {
                    //ca += "<td><button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > -</button></td>";
                }
                else
                {
                    //ca += "<td></td>";
                    total = total + 1;
                }
                ca += "</tr></table></td>";

               
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            ca += "<td>";
            ca += "<table width=\"100%\"> ";
            ca += " <tr>";
            ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"Si\" ></td>";
            ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"No\" ></td>";
            ca += "</tr>";
            ca += "</table>";
            ca += "</td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deleteestrag006(string codigo)
    {
        string ca = "";
        Institucion inst = new Institucion();

        if (inst.eliminarEncabezadoEntregaMaterialEstra1(codigo))
        {

            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string eliminarEvidenciasEntregaMaterial(string codigo)
    {
        string ca = "";
        Institucion inst = new Institucion();

        if (inst.eliminarEvidenciasEntregaMaterialEstra1(codigo))
        {

            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

}

tMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        
        //function finsertInstrumento(fechaentregamaterial1, fechaentregamaterial2, fechaentregamaterial3, fechaentregamaterial4, codsede, nombrequienrecibe1, nombrequienrecibe2, nombrequienrecibe3, nombrequienrecibe4) {
        //    //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
        //    var jsonData = '{ "fechaentregamaterial1":"' + fechaentregamaterial1 + '","fechaentregamaterial2":"' + fechaentregamaterial2 + '","fechaentregamaterial3":"' + fechaentregamaterial3 + '","fechaentregamaterial4":"' + fechaentregamaterial4 + '", "codsede": "' + codsede + '", "nombrequienrecibe1": "' + nombrequienrecibe1 + '", "nombrequienrecibe2": "' + nombrequienrecibe2 + '", "nombrequienrecibe3": "' + nombrequienrecibe3 + '", "nombrequienrecibe4": "' + nombrequienrecibe4 + '"}';
        //    $.ajax({
        //        type: 'POST',
        //        url: 'estrag006_estrategia1.aspx/insertInstrumento',
        //        data: jsonData,
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (data) {
        //            console.log(data);
        //            var resp = data.d.split("@");
        //            if (resp[0] === "true") {
        //                console.log("instrumento insertado exitosamente" + resp[1]);
        //                codigoinstrumento = resp[1];
        //                //alert("instrumento insertado exitosamente " + codigoinstrumento);

        //                finsertMaterial();
        //            } else {
        //                alert(data.d);
        //                console.error(data.d);
        //            }
        //        }
        //    });
        //}

        function fupdateInstrumento(fechaentregamaterial1, fechaentregamaterial2, fechaentregamaterial3, fechaentregamaterial4, codsede, nombrequienrecibe1, nombrequienrecibe2, nombrequienrecibe3, nombrequienrecibe4) {
            //console.log(fechaentregamaterial + ' ' + codproyectsede + ' ' + nombrequienrecibe);
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "fechaentregamaterial1":"' + fechaentregamaterial1 + '","fechaentregamaterial2":"' + fechaentregamaterial2 + '","fechaentregamaterial3":"' + fechaentregamaterial3 + '","fechaentregamaterial4":"' + fechaentregamaterial4 + '",  "nombrequienrecibe1": "' + nombrequienrecibe1 + '", "nombrequienrecibe2": "' + nombrequienrecibe2 + '", "nombrequienrecibe3": "' + nombrequienrecibe3 + '", "nombrequienrecibe4": "' + nombrequienrecibe4 + '"}';
            
            $.ajax({
                type: 'POST',
                url: 'estrag006_estrategia1.aspx/updateInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        alert("instrumento actualizado exitosamente " + codigoinstrumento);

                        finsertMaterial();
                    } else {
                        alert(data.d);
                        console.error(data.d);
                    }
                }
            });
        }

        function loadInstrumento(codigogrupo) {
            
            var jsonData = '{ "codigo":"' + codigogrupo + '"}';
            $.ajax({
                type: 'POST',
                url: 'estrag006_estrategia1.aspx/loadInstrumento',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {
                        codigoinstrumento = resp[5];
                        loadSelectInstrumento(codigogrupo);
                        floadMaterial(codigoinstrumento);
                        
                        $("#nombre").val(resp[3]);

                        $('input[type=date]').each(function () {
                            this.type = "text";
                        });
                        $('input[type=date]').datepicker({ dateFormat: 'yy-mm-dd' });

                        $("#fechaentrega1").val(resp[4]);
                        $("#fechaentrega2").val(resp[4]);
                        $("#fechaentrega3").val(resp[4]);
                        $("#fechaentrega4").val(resp[4]);
                        $('#btn-guardar').attr('value', 'Actualizar');
                        $('#btn-guardar').attr('onclick', 'enviarestrag006_estrategia1(\'update\')');

                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        $("#fechaentrega1").val('');
                        $("#fechaentrega2").val('');
                        $("#fechaentrega3").val('');
                        $("#fechaentrega4").val('');
                        $("#nombre1").val('');
                        $("#nombre2").val('');
                        $("#nombre3").val('');
                        $("#nombre4").val('');
                        $('#btn-guardar').attr('onclick', 'enviarestrag006_estrategia1(\'insert\')');
                        html = '<tr>';
                        html += '<th>Nombre del material</th>';
                        html += '<th>Cantidad</th>';
                        html += '<th>Estado<br>';
                        html += '<table width="100%">';
                        html += '<tr>';
                        html += '<td width="30%">Si</td>';
                        html += '<td width="30%">No</td>';
                        html += '</tr>';
                        html += '</table>';
                        html += '</th>';
                        html += '</tr>';
                        html += '<tr >';
                        html += '<td align="center"><input type="text" class="TextBox" width="350" id="nombrematerial2" name="nombrematerial2" class="width-100"></td>';
                        html += '<td align="center"><input type="text" class="TextBox" id="cantidad8" name="cantidad8" onkeypress="return valideKey(event);" class="width-100"></td>';
                        html += '<td>';
                        html += '<table width="100%">';
                        html += '<tr>';
                        html += '<td width="50%" style=" text-align: center;"><input type="radio" name="estado8" value="Si"></td>';
                        html += '<td width="50%" style=" text-align: center;"><input type="radio" name="estado8" value="No"></td>';
                        html += '</tr>';
                        html += '</table>';
                        html += '</td>';
                        html += '</tr>';
                        $("#tablecampus").html(html);
                        total = 1;
                        //alert(data.d);
                        //console.error(data.d);
                    }
                }
            });
        }

        //funcion para insertar los materiales
        function finsertMaterial() {
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '"}';
            $.ajax({
                type: 'POST',
                url: 'estrag006_estrategia1.aspx/deleteMaterial',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var resp = data.d.split("@");
                    if (resp[0] === "true") {

                        for (var i = 1; i <= 8; i++) {
                            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "nombrematerial":"' + $("#nombrematerial" + i).val() + '", "cantidad":"' + $("#cantidad" + i).val() + '", "estado":"' + $("input[name='estado" + i + "']:checked").val() + '"}';
                            $.ajax({
                                type: 'POST',
                                url: 'estrag006_estrategia1.aspx/insertMaterial',
                                data: jsonData,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    var resp = data.d.split("@");
                                    if (resp[0] === "true") {
                                        console.log("instrumento insertado exitosamente " + i);
                                    } else {
                                        console.error(data.d + " " + i);
                                        //console.error(data.d);
                                    }
                                }
                            });
                        }

                    } else {
                        alert(data.d);
                    }
                },
                complete: function () {
                    alert("registro guardado exitosamente");
                    cargarListadoMateriales();
                    $('#listTable').fadeIn(500); $('#formTable').hide()
                    //$('#btn-guardar').attr('value', 'Actualizar');
                    //$('#btn-guardar').attr('onclick', 'enviarestrag006_estrategia1(\'update\')');

                }
            });
        }

        //funcion para traer todo los materiales
        function floadMaterial(codigoinstrumento) {
            total = 1;
            var jsonData = '{ "codigoinstrumento":"' + codigoinstrumento + '", "total":' + total + '}';
            $.ajax({
                type: 'POST',
                url: 'estrag006_estrategia1.aspx/loadMaterial',
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var resp = data.d.split("@");
                    if (resp[0] === "mat") {
                        $("#tablecampus").html(resp[1]);
                        total = resp[2];
                        //console.log("instrumento insertado exitosamente" + resp[1]);
                    } else {
                        $('#btn-guardar').val('Guardar');
                        $("#tablecampus").html(resp[1]);
                        //alert(data.d);
                        //console.error(data.d);
                    }
                }
            });
        }

        function valideKey(evt) {
            var code = (evt.which) ? evt.which : evt.keyCode;
            if (code == 8) {
                //backspace
                return true;
            }
            else if (code >= 48 && code <= 57) {
                //is a number
                return true;
            }
            else {
                return false;
            }
        }

        function loadSelectInstrumento(codigo) {
            var jsondata = "{'codigo':'" + codigo + "'}";
            $.ajax({
                type: 'POST',
                url: 'estrag006_estrategia1.aspx/loadSelectInstrumento',
                data: jsondata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = response.d.split("@");
                    if (resp[0] === "loadSelect") {
                        $("#departamento").html(resp[1]);
                        $("#municipio").html(resp[2]);
                        $("#institucion").html(resp[3]);
                        $("#sede").html(resp[4]);
                    }
                }
            });
        }

        function resetSelect() {
            cargarDepartamento();
            //$("#departamento").val("");
            $("#municipio").val("Seleccione municipio");
            $("#institucion").val("Seleccione institución");
            $("#sede").val("Seleccione sede");
           

            $('#btn-guardar').attr('value', 'Guardar todo');
            $('#btn-guardar').attr('onclick', 'enviarestrag006_estrategia1(\'insert\')');
        }

        function eliminar(codigo) {
            if (confirm('¿Estás seguro de eliminar este registro? Recuerde que perderá las evidencias que tenga cargadas')) {
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estrag006_estrategia1.aspx/deleteestrag006',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData,
                    success: function (json) {
                        var resp = json.d.split("@");
                        if (resp[0] === "delete") {
                            eliminarEvidencias(codigo);
                            alert('Registro eliminado correctamente.');
                            cargarListadoMateriales();
                        }
                    }
                });
            }

        }

        function eliminarEvidencias(codigo) {
           
                var jsonData = "{ 'codigo':'" + codigo + "'}";
                $.ajax({
                    type: 'POST',
                    url: 'estrag006_estrategia1.aspx/eliminarEvidenciasEntregaMaterial',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: jsonData
                });
  
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div>
    <br />
    <br />
    <h2 >Estrategia No. 1  - G006: Entrega de material pedagógico</h2>
    <asp:Label runat="server" ID="lblEstrategia" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCodEstraCoordinador" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>
    <div id="formTable" style="display:none;">
    <!-- DATOS DE LA INSTITUCIÓN -->
    <fieldset>
        <legend>DATOS DE LA INSTITUCIÓN</legend>
        <table >
             <tr>
            <td>Departamento </td>
                        <td >
                            <select class="TextBox width-100" name="departamento" id="departamento">
                                <option value="">Seleccione departamento</option>
                            </select></td>
        </tr>
         <tr>
            <td >Municipio </td>
                        <td >
                            <select class="TextBox width-100" name="municipio" id="municipio"> 
                                <option value="">Seleccione municipio</option>
                            </select></td>
        </tr>
            <tr>
                <td>Institución Educativa:</td>
                            <td>
                                <select class="TextBox" name="institucion" id="institucion" style="width: 300px;">
                                    <option value="">Seleccione...</option>
                                </select></td>
            </tr>
            <tr>
                 <td >Sede: </td>
                            <td>
                                <select class="TextBox" name="sede" id="sede" style="width: 300px;">
                                    <option value='' selected>Seleccione sede...</option>
                                </select></td>
                            <td>
            </tr>
          
             <%-- <tr>
                <td width="50%">Teléfono: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="telefono" name="telefono" /></td>
                </tr>
          <tr>
                <td width="50%">
                    <table>
                        <tr>
                            <td width="50%">Email: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="email" name="email" /></td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <%--<tr>--%>
                <%--<td width="50%">
                    <table>
                        <tr>
                            <td width="50%">Dirección: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="direccion" name="direccion" /></td>
                        </tr>
                    </table>
                </td>--%>
                <%--<td width="50%">
                    <table>
                        <tr>
                            <td width="50%">Jornada: </td>
                            <td width="50%">
                                <input type="text" class="TextBox" id="jornada" name="jornada" /></td>
                        </tr>
                    </table>
                </td>--%>
           <%-- </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td width="27%">Nombre del grupo de investigación: </td>
                            <td width="50%">
                                <select class="TextBox" name="grupoinvestigacion" id="grupoinvestigacion" style="width: 270px;">
                                    <option value="">Seleccione grupo investigación...</option>
                                </select></td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </fieldset>
    <!-- FIN DATOS DE LA INSTITUCIÓN -->
    <br>
    <fieldset>
        <legend>RELLENE LA INFORMACIÓN</legend>

          <table class="mGridTesoreria" id="tablecampus">
            <tr>
                <th>Nombre del material</th>
                <th>Cantidad</th>
                <th>Fecha entrega</th>
                <th>Nombre de quien recibe</th>
                    <br/>
                   <%-- <table >
                       <%-- <tr>
                            <td >Si</td>
                            <td >No</td>
<%--                            <td >No estado</td>--%>
                        <%--</tr>--%>
                   <%-- </table>--%>
                </th>
            </tr>

               <tr>

                <td align="center">
                     <input type="text" class="TextBox" style="width:350px;" id="nombrematerial2" name="nombrematerial2" value="Navegantes Fuentes Hídricas" class="width-100" disabled><br />
                   
                </td>
                <td align="center">
                    <input type="text" class="TextBox" style="width:50px;" id="cantidad2" name="cantidad2"  onkeypress="return valideKey(event);" class="width-100">
                </td>
                <td>
                    <table width="100%">
                         <tr>
<%--                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado2" value="Si" /></td>
                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado2" value="No" /></td>--%>
<%--                            <td width="40%" style="text-align: center;">
                                <input type="radio" name="estado2" value="noestado" /></td>--%>
                             <td> <input type="date" class="TextBox" class="width-100" name="fechaentrega1" id="fechaentrega1"></td>
                        </tr>
                    </table>
                </td>
                <td align="center">
                    <input type="text" class="TextBox" name="nombre1" id="nombre1" class="width-100">
                </td>
            </tr>
        
        <tr>
        <td align="center">
                <input type="text" class="TextBox" style="width:350px;" id="nombrematerial4" name="nombrematerial4" value="La Pola, Toño y sus amigos" class="width-100" disabled><br />
        </td>
        <td align="center">
            <input type="text" class="TextBox" style="width:50px;" id="cantidad4" name="cantidad4"  onkeypress="return valideKey(event);" class="width-100">
        </td>
        <td>
            <table width="100%">
                 <tr>
<%--                    <td width="30%" style="text-align: center;">
                        <input type="radio" name="estado4" value="Si" /></td>
                    <td width="30%" style="text-align: center;">
                        <input type="radio" name="estado4" value="No" /></td>--%>
<%--                    <td width="40%" style="text-align: center;">
                        <input type="radio" name="estado4" value="noestado" /></td>--%>
                     <td> <input type="date" class="TextBox" class="width-100" name="fechaentrega2" id="fechaentrega2"></td>
                </tr>
            </table>
        </td>

             <td align="center">
                    <input type="text" class="TextBox" name="nombre2" id="nombre2" class="width-100">
                </td>
    </tr>
     <tr>
        <td align="center">
                <input type="text" class="TextBox" style="width:350px;" id="nombrematerial5" name="nombrematerial5" value="Sofía, Inti y sus amigos" class="width-100" disabled><br />
        </td>
        <td align="center">
            <input type="text" class="TextBox" style="width:50px;" id="cantidad5" name="cantidad5"  onkeypress="return valideKey(event);" class="width-100">
        </td>
        <td>
            <table width="100%">
                 <tr>
<%--                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado5" value="Si" /></td>
                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado5" value="No" /></td>--%>
<%--                            <td width="40%" style="text-align: center;">
                                <input type="radio" name="estado5" value="noestado" /></td--%>
                     <td> <input type="date" class="TextBox" class="width-100" name="fechaentrega3" id="fechaentrega3"></td>
                        </tr>
            </table>
        </td>
          <td align="center">
                    <input type="text" class="TextBox" name="nombre3" id="nombre3" class="width-100">
                </td>
    </tr>
    <tr>
        <td align="center">
                <input type="text" class="TextBox" style="width:350px;" id="nombrematerial6" name="nombrematerial6" value="Nacho derecho en la Onda de los derechos" class="width-100" disabled><br />
        </td>
        <td align="center">
            <input type="text" class="TextBox" style="width:50px;" id="cantidad6" name="cantidad6"  onkeypress="return valideKey(event);" class="width-100">
        </td>
        <td>
            <table width="100%">
                 <tr>
<%--                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado6" value="Si" /></td>
                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado6" value="No" /></td>
                            <td width="60%">--%>
                           <td> <input type="date" class="TextBox" class="width-100" name="fechaentrega4" id="fechaentrega4"></td>
 <%--                           <td width="40%" style="text-align: center;">
                                <input type="radio" name="estado6" value="noestado" /></td>--%>
                        </tr>
            </table>
        </td>

        <td align="center">
               <input type="text" class="TextBox" name="nombre4" id="nombre4" class="width-100">
                </td>
<%--     <tr>
        <td align="center">
              <input type="text" class="TextBox" style="width:350px;" id="nombrematerial8" name="nombrematerial8" value="Guías de investigación rediseñadas" class="width-100" disabled>
        </td>
        <td align="center">
            <input type="text" class="TextBox" style="width:50px;" id="cantidad8" name="cantidad8"  onkeypress="return valideKey(event);" class="width-100"> 
        </td>
        <td>
            <table width="100%">
                 <tr>
                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado8" value="Si" /></td>
                            <td width="30%" style="text-align: center;">
                                <input type="radio" name="estado8" value="No" /></td>
<%--                            <td width="40%" style="text-align: center;">
                                <input type="radio" name="estado8" value="noestado" /></td>--%>
          <%--              </tr>
            </table>
        </td>
    </tr>--%>

        </table>
      <%--  <table width="100%">
            <tr>
                <td colspan="3" align="right">
                    <button id="add" class="btn btn-primary" type="button">+</button></td>
            </tr>
        </table>--%>
    </fieldset>
    <br>
    <fieldset>
        <!-- <legend>RELLENE LA INFORMACIÓN</legend> -->
<%--        <table width="100%" class="border">
            <tr>
                <td width="40%">Fecha de entrega del material pedagógico
                </td>
                <td width="60%">
                    <input type="date" class="TextBox" class="width-100" name="fechaentrega" id="fechaentrega">
                </td>
            </tr>
            <tr>
                <td>Nombre y Firma de quien recibe el material pedagógico.</td>
                <td>
                    <table width="100%">
                        <tr>
                            <td > </td>
                            <td >
                                <input type="text" class="TextBox" name="nombre" id="nombre" class="width-100"></td>
                        </tr>
                      <%--  <tr>
                            <td>Firma: </td>
                            <td>
                                <input type="text" class="TextBox" name="firma" id="firma" class="width-100"></td>
                        </tr>--%>
<%--                    </table>
                </td>
            </tr>--%>
            <tr>
                <td colspan="2" align="right">
                    <input type="button" id="btn-guardar" value="Guardar" onclick="enviarestrag006_estrategia1('insert')" class="btn btn-success">
                    <input type="button" id="btn-volver" value="Volver" onclick="$('#formTable').hide(); $('#listTable').fadeIn(500); reset(); " class="btn btn-primary">
                   
                </td>
            </tr>
        </table>
    </fieldset>
</div>

    <!-- Listar entrega de materiales -->

    <div id="listTable">
         <a class="btn btn-primary" style="float:right" onclick="$('#listTable').hide(), $('#formTable').fadeIn(500), resetSelect(), reset(), resetSelect()">Nuevo registro</a>
         <br /><br /><br />
         <table class="mGridTesoreria" id="infoListTable">
            <thead>
                <tr>
                    <th>
                        Nro.
                    </th>
                    <th>
                        Asesor
                    </th>
                    <th>
                        Municipio
                    </th>
                    <th>
                        Institución
                    </th>
                    <th>
                        Sede
                    </th>
                     <th></th>
                </tr>
            </thead>
            <tbody >
                <tr><td colspan='11' style='padding:10px;text-align:center;'><img src='images/loader.gif'></td></tr>
            </tbody>
        </table>
         <div id="paginacion" class="pagination"></div>
    </div>


</asp:Content>

