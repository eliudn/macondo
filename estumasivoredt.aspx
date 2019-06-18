<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estumasivoredt.aspx.cs" Inherits="estumasivoredt" %>

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
    <h2>Creación de Estudiantes masivos</h2>
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
                    <asp:Button ID="btnActualizarPagos" runat="server" Text="Registrar Datos" ValidationGroup="Agregar" CssClass="btn btn-success" Width="140px" OnClick="btnActualizarPagos_Click" />
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
          <p>* Los datos <b style="background-color:#e4ed76">opcionales</b> que no tengan datos deben ir con un valor de cero (0).</p>
          <p>* Los datos en <b>FECHA DE NACIMIENTO</b> debe tener la siguiente estructura DD/MM/AAAA. </p>
          <p>* Los datos de <b>GENERO</b> debe tener la siguiente estructura: M si es masculino y F si es femenino.</p>
           <p>* Los datos de <b>GRADO</b> debe tener la siguiente estructura: PRIMERO, SEGUNDO, TERCERO, CUARTO... DECIMO, UNDECIMO.</p>
          <p>* Los datos de <b>ETNIA</b> debe tener la siguiente estructura:<br /> - Indígenas. <br /> - Rom (gitanos). <br /> - Afrocolombianos, afrodecendientes, negro o mulato. <br /> - Raizal del archipiélago de San Andrés, Providencia y Santa Catalina. <br /> - Palenquero de San Basilio.</p>
          <p>* Los datos de <b>TIPO DE GRUPO</b> debe tener la siguiente estructura: <br />Grupo de Investigación: 1 - Red Temática: 2</p>
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
                <td class="obligatorio">DANE Sede
                </td>
                 <td class="obligatorio">TIPO ID. 
                </td>
                <td class="obligatorio">ID. ESTUDIANTE
                </td>
                <td class="obligatorio">NOMBRE ESTUDIANTE
                </td>
                <td class="obligatorio">APELLIDO ESTUDIANTE
                </td>
                <td class="opcional">SEXO
                </td>
                <td class="obligatorio">FECHA DE NACIMIENTO
                </td>
                <td class="opcional">TELÉFONO
                </td>
                <td class="opcional">DIRECCIÓN
                </td>
                <td class="opcional">EMAIL
                </td>
                <td class="obligatorio">GRADO
                </td>
                 <td class="obligatorio">ETNIA
                </td>
                <%-- <td class="obligatorio">ID DOCENTE
                </td>--%>
                 <td class="obligatorio">TIPO DE GRUPO
                </td>
                  <td class="obligatorio">ID AÑO LECTIVO
                </td>
                <td class="obligatorio">GRUPO DEL GRADO
                </td>
              <td class="obligatorio">COD. RED TEMÁTICA
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
            <asp:BoundField DataField="0" HeaderText="Dane Sede">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="1" HeaderText="Tipo Id">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="2" HeaderText="Id Estudiante">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="3" HeaderText="Nombre estudiante">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:BoundField DataField="4" HeaderText="Apellido estudiante">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="5" HeaderText="Sexo">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="6" HeaderText="Fecha de nacimiento">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="7" HeaderText="Teléfono">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="8" HeaderText="Dirección">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="9" HeaderText="Email">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="10" HeaderText="Grado">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="11" HeaderText="Etnia">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="12" HeaderText="Tipo de Grupo">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
              <asp:BoundField DataField="13" HeaderText="ID AÑO LECTIVO">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="14" HeaderText="GRUPO DEL GRADO">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="15" HeaderText="COD. RED TEMÁTICA">
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

