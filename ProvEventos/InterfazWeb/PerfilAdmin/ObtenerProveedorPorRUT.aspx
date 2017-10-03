<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ObtenerProveedorPorRUT.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.ObtenerProveedorPorRUT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .seleccionadoProveedor {
            width: 90%;
            border: 1px solid #eeeeee;
            padding: 1%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Obtener Proveedor por RUT
        <br />
        ------------------------------
    </p>
    <asp:Panel ID="PanelBuscadorPorID" runat="server">
        Ingrese RUT de Proveedor<br />
        <asp:TextBox ID="TextBoxIdBuscadorProveedor" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonBuscarProveedor" runat="server" OnClick="ButtonBuscarProveedor_Click" Text="Buscar" />
        <br />
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="PanelDatosProveedor" runat="server">
        <div class="seleccionadoProveedor">
            RUT:
            <asp:Label ID="LabelRUT" runat="server"></asp:Label>
            <br />
            Nombre fantasia:
            <asp:Label ID="LabelNombreFantasia" runat="server"></asp:Label>
            <br />
            Nombre Persona Física:
            <asp:Label ID="LabelNombreCompleto" runat="server"></asp:Label>
            <br />
            Email:
            <asp:Label ID="LabelEmail" runat="server"></asp:Label>
            <br />
            Fecha Ingreso:
            <asp:Label ID="LabelFechaIngreso" runat="server"></asp:Label>
            <br />
            Telefono:
            <asp:Label ID="LabelTelefono" runat="server"></asp:Label>
            <br />
            VIP:
            <asp:Label ID="LabelVIP" runat="server"></asp:Label>
            <br />
            Arancel VIP:
            <asp:Label ID="LabelArancel" runat="server"></asp:Label>
            <br />
            Activo:
            <asp:Label ID="LabelActivo" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonCerrar" runat="server" Text="Cerrar" OnClick="ButtonCerrar_Click" />
            <br />
        </div>
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
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>



       <style>
        .seleccionadoProveedor {
            width: 90%;
            border: 1px solid #eeeeee;
            padding: 1%;
        }
    </style>


</asp:Content>
