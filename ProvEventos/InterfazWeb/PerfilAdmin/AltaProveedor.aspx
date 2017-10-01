<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.AltaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Alta Proveedor
         <br />-----------------
    </p>
    <p>
        </p>
    <asp:Panel ID="PanelAltaProveedor" runat="server">
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
        <asp:DropDownList ID="DropDownListAltaVIP" runat="server" OnSelectedIndexChanged="DropDownListAltaVIP_SelectedIndexChanged">
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
        <asp:Button ID="ButtonAltaProveedor" runat="server" OnClick="ButtonAltaProveedor_Click" Text="Agregar nuevo Proveedor" />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
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
