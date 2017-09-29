<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EliminarProveedor.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EliminarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Eliminar un Proveedor<br />-----------------------</p>
    <p>
    </p>
    <asp:Panel ID="PanelBuscarProveedor" runat="server">
        <br />
        Ingrese RUT del proveedor<br />
        <asp:TextBox ID="TextBoxIdBuscadorProveedor" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonBuscarProveedor" runat="server" OnClick="ButtonBuscarProveedor_Click" Text="Buscar" style="height: 26px" />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelDatosProveedor" runat="server">
        <br />
        Nombre completo:
        <asp:Label ID="LabelNombre" runat="server" Text="Label"></asp:Label>
        <br />
        Fecha Ingreso:
        <asp:Label ID="LabelFechaIngreso" runat="server" Text="Label"></asp:Label>
        <br />
        VIP:
        <asp:Label ID="LabelVIP" runat="server" Text="Label"></asp:Label>
        <br />
        Arancel VIP:
        <asp:Label ID="LabelArancel" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        ¿Seguro decea eliminar este proveedor?<br />
        <br />
        <asp:Button ID="ButtonEliminarProveedor" runat="server" Text="Eliminar" OnClick="ButtonEliminarProveedor_Click" />
        <br />
        <br />
        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="PanelMensaje" runat="server">
        <br />
        <br />
        <asp:Label ID="LabelMensaje" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
