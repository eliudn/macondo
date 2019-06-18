<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="sedesmasivo.aspx.cs" Inherits="sedesmasivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .obligatorio {
            background-color: #91dd69;
            border: 1px solid black;
        }

        .opcional {
            background-color: #e4ed76;
            border: 1px solid black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="mensaje" runat="server"></div><br /><br />
    <h2>Creación de Instituciones/Sedes masivas</h2>
    <hr />
    <br />
    <br />
    <div style="background-color: #efefef; padding: 8px;  float:left;">
        <table>
            <tr>
                <td>&nbsp;1.
                    Primer Paso:
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;2.
                    Segundo Paso:
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir Archivo" CssClass="botones" Width="135px" />
                </td>
            </tr>
            <tr>
                <td>3.
                    Delimitado por:
                </td>
                <td>
                    <asp:DropDownList ID="dropDelimitador" runat="server" CssClass="TextBox">
                        <asp:ListItem Selected="True" Value=";">punto y coma</asp:ListItem>
                        <asp:ListItem Value=",">coma</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>4. Cuarto Paso:
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Cargar Datos-Tabla" OnClick="Button2_Click" CssClass="btn btn-primary" Width="135px" />
                </td>
            </tr>
            <tr>
                <td>5. Quinto Paso:
                </td>
                <td>
                    <asp:Button ID="btnActualizarPagos" runat="server" Text="Registrar Instituciones" ValidationGroup="Agregar" CssClass="btn btn-success" Width="150px" OnClick="btnActualizarPagos_Click" />
                </td>
            </tr>
        </table>

        <div>
            <table>
            </table>
        </div>

    </div>
      <div style="background-color: #efefef; padding: 8px;  float:left;max-width:600px;margin-left:10px;">
        <p style="font-weight:bold;">Para tener en cuenta en el cargue masivo</p>
          <p>* Los datos <b style="background-color:#e4ed76">opcionales</b> que no tengan datos deben ir con un valor de cero (0)</p>
          <p>* Los datos en <b>TIPO INSTITUCIÓN</b> debe contener una de estas opciones: Empresarial, Gobierno, Institución o Infraestructura</p>
          <p>* Los datos de <b>CLASE DE INSTITUCIÓN</b> debe contener una de estas opciones:  Pública o Privada</p>
          <p>* Los datos de <b>ZONA</b> debe contener una de estas opciones: Urbana, Rural o Urbana y Rural</p>
          <p>* Los datos de <b>PROPIEDAD JURÍDICA</b> debe contener una de estas opciones: Oficial, Educación misional contratada o Régimen especial</p>
          <p><b>Si no está seguro en alguna de las columnas por favor digitar el Nro cero (0)</b></p>
          <p>* El documento .csv debe contener la siguiente estructura</p>
          <p>
            <table>
            <tr>
                <td style="background-color:#91dd69">Obligatorio</td>
                <td style="background-color:#e4ed76">Opcional</td>
            </tr>
           
           </table>
          </p>
        </div>
    <asp:Label ID="lblOculto" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblNumero" runat="server"  Text="0" Visible="false"></asp:Label>
    <br />
   
            
         
        <table border="1" cellpadding="4" style="border-collapse: collapse; border-spacing: 5px;" align="center">
            <tr>
                <td class="obligatorio">NIT O DANE
                </td>
                <td class="obligatorio">NOMBRE DE LA INSTITUCIÓN
                </td>
                <td class="obligatorio">IDENTIFICACIÓN DEL RECTOR
                </td>
                <td class="obligatorio">TIPO INSTITUCIÓN
                </td>
                <td class="opcional">TELÉFONO
                </td>
                <td class="opcional">FAX
                </td>
                <td class="opcional">EMAIL
                </td>
                <td class="obligatorio">CLASE DE INSTITUCIÓN
                </td>

                 <td class="opcional">DIRECCIÓN
                </td>
                 <td class="opcional">WEB
                </td>
                 <td class="obligatorio">MUNICIPIO INSTITUCIÓN
                </td>
                 <td class="obligatorio">ZONA INSTITUCIÓN
                </td>
                <td class="opcional">SEDES ACTIVAS
                </td>
                <td class="opcional">SEDES INACTIVAS
                </td>
                 <td class="obligatorio">PROPIEDAD JURÍDICA
                </td>


                <td class="obligatorio">NOMBRE DE LA SEDE
                </td>
                <td class="obligatorio">DANE SEDE	
                </td>
                <td class="obligatorio">CONSECUTIVO SEDE
                </td>
                <td class="opcional">DIRECCIÓN SEDE
                </td>
                 <td class="obligatorio">ZONA 
                </td>
                <td class="obligatorio">MUNICIPIO
                </td>
                 <td class="obligatorio">PRINCIPAL o SEDE
                </td>

            </tr>
        </table>
   
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       

    <div style="margin: 0 auto; text-align: center">
        <asp:Label ID="lblNroEnTabla" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMensajeMalos" Visible="false" runat="server"></asp:Label>
    </div>
    <asp:GridView ID="GridView1" runat="server" Height="251px" Width="420px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="0" HeaderText="Nit O Dane">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="1" HeaderText="Nombre de la institución">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="2" HeaderText="Identificación del rector">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:BoundField DataField="3" HeaderText="Tipo institución">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="4" HeaderText="Teléfono">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="5" HeaderText="Fax">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="6" HeaderText="Email">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="7" HeaderText="Clase de Institución">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>


             <asp:BoundField DataField="8" HeaderText="Dirección de la Institución">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="9" HeaderText="Web">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="10" HeaderText="Municipio Institución">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="11" HeaderText="Zona Institución">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
            <asp:BoundField DataField="12" HeaderText="Nro Sedes Activas">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="13" HeaderText="Nro Sedes Inactivas">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="14" HeaderText="Propiedad Jurídica">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="15" HeaderText="Nombre de la Sede">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="16" HeaderText="DANE">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="17" HeaderText="Consecutivo S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="18" HeaderText="Direccion S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="19" HeaderText="Zona S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
              <asp:BoundField DataField="20" HeaderText="Municipio S.">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="21" HeaderText="Principal/Sede">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>

