<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ABMProveedor.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.ABMProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        <asp:Button ID="ButtonAltaProveedor" runat="server" OnClick="ButtonAltaProveedor_Click" Text="Alta Proveedor" />
    </p>
    <p>
        <asp:Button ID="ButtonEditarProveedor" runat="server" OnClick="ButtonEditarProveedor_Click" Text="Editar Proveedor" />
    </p>
    <p>
        <asp:Button ID="ButtonEliminarProveedor" runat="server" OnClick="ButtonEliminarProveedor_Click" Text="Eliminar Proveedor" />
    </p>
    <p>
        <asp:Button ID="ButtonModArancel" runat="server" OnClick="ButtonModArancel_Click" Text="Modificar arancel" />
    </p>
    <p>
    </p>
    <p>
    </p>


</asp:Content>
