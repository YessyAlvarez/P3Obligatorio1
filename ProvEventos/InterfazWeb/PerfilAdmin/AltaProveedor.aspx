<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.AltaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Alta Proveedor
         <br />-----------------
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <asp:Panel ID="PanelStep1" runat="server">
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">1. Datos del Proveedor</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">2. Servicios del Proveedor</asp:LinkButton>
        <br />
        <br />
        <br />
        Ingrese los datos del proveedor:<br />
        <br />
        <br />
        <br />
        RUT:<br />
        <asp:TextBox ID="TextBoxAltaUsuario" runat="server"></asp:TextBox>
        <br />
        Password:<br />
        <asp:TextBox ID="TextBoxAltaPass" runat="server"></asp:TextBox>
        <br />
        Nombre de Fantasia<br />
        <asp:TextBox ID="TextBoxNombreFantasia" runat="server"></asp:TextBox>
        <br />
        <br />
        ---<br />
        <br />
        Nombre Completo Persona Fisica<br />
        <asp:TextBox ID="TextBoxAltaNombreCompleto" runat="server"></asp:TextBox>
        <br />
        Email<br />
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <br />
        Telefono<br />
        <asp:TextBox ID="TextBoxTelefono" runat="server"></asp:TextBox>
        <br />
        Es VIP<br />
        <asp:DropDownList ID="DropDownListAltaVIP" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListAltaVIP_SelectedIndexChanged">
            <asp:ListItem>Si</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Panel ID="PanelArancelVIP" runat="server">
            Arancel VIP<br />
            <asp:TextBox ID="TextBoxAltaArancelVIP" runat="server"></asp:TextBox>
            <br />
            <br />
        </asp:Panel>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonSiguiente" runat="server" Text="Siguiente" OnClick="ButtonSiguiente_Click" />
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <asp:Panel ID="PanelStep2" runat="server">
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">1. Datos del Proveedor</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">2. Servicios del Proveedor</asp:LinkButton>
        <br />
        <br />
        <br />
        <br />
        Ingrese los servicios que ofrece el proveedor:<br />
        <br />
        <table id="Servicios">
            <tr>
                <td>Nombre Servicio</td>
                <td>Descripcion</td>
                <td>Adjuntar Imagen</td>
                <td>Activar</td>
            </tr>
            <tr>
                <td>Decoracion</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Salon de fiestas</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Mobiliario</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Banquetes</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Candy Bar</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload5" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Cupcakes</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload6" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList6" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Fuente de chocolate</td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload7" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList7" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Fuente de queso</td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload8" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList8" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Mesa de dulces</td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload9" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList9" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Pasteles</td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload10" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList10" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Inflables</td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload11" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList11" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Globos</td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload12" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList12" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Invitaciones</td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload13" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList13" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Musica en vivo </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload14" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList14" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Magos</td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload15" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList15" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Payasos</td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload16" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList16" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Si</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Menage</td>
                <td>
                    <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload17" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList17" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Anterior" OnClick="Button2_Click" />
        <br />
        <asp:Button ID="ButtonAltaProveedor" runat="server" OnClick="ButtonAltaProveedor_Click" Text="Agregar nuevo Proveedor" />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelMensajeAlta" runat="server">
        <br />
        <asp:Label ID="LabelMensaje" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonNewAddProveedor" runat="server" OnClick="ButtonNewAddProveedor_Click" Text="Agregar otro proveedor" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
