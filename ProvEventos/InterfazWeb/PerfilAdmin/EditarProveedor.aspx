<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EditarProveedor.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EditarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Editar proveedor<br />
        -----------------
    </p>
    <asp:Panel ID="PanelBuscadorPorID" runat="server">
        Ingrese usuario proveedor<br />
        <asp:TextBox ID="TextBoxIdBuscadorProveedor" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonBuscarProveedor" runat="server" OnClick="ButtonBuscarProveedor_Click" Text="Buscar" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelResultadoProveedor" runat="server">
        <br />
        Nombre completo<br />
        <asp:TextBox ID="TextBoxNombreCompleto" runat="server"></asp:TextBox>
        <br />
        Contraseña<br />
        <asp:TextBox ID="TextBoxContrasenia" runat="server"></asp:TextBox>
        <br />
        <br />
        Fecha de ingreso<br />
        <asp:TextBox ID="TextBoxFechaIngreso" runat="server"></asp:TextBox>
        <br />
        <br />
        VIP<br />
        <asp:DropDownList ID="DropDownListVIP" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Panel ID="PanelArancelVIP" runat="server">
            <br />
            Arancel VIP<br />
            <asp:TextBox ID="TextBoxArancelVIP" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="ButtonGuardarCambiosProveedor" runat="server" OnClick="ButtonGuardarCambiosProveedor_Click" Text="Guardar" />
        <br />
        <br />
    </asp:Panel>
    <p>
        &nbsp;</p>
    <asp:Panel ID="PanelMensaje" runat="server">
        <br />
        <br />
        <asp:Label ID="LabelMensaje" runat="server" Text="Label"></asp:Label>
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
