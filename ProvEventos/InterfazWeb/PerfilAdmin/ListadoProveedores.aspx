<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ListadoProveedores.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.ListadoProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Listado de Proveedores<br />-------------------------</p>
    <asp:Panel ID="PanelSeleccionProveedor" runat="server">
        <br />
        Seleccione un proveedor para visualizar todos sus datos<br />
        <asp:DropDownList ID="DropDownListAllProveedores" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="ButtonProveedorSeleccionado" runat="server" Text="Seleccionar" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelDatosProveedorSeleccionado" runat="server">
        <br />
        Datos del Proveedor:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        idProveedor&nbsp;
        <br />
        nombreFantasia
        <br />
        email
        <br />
        fechaIngreso
        <br />
        telefono
        <br />
        VIP
        <br />
        arancelVIP
        <br />
        activo
        <br />
        <br />
        Listado de Servicios que ofrece:<br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>






</asp:Content>
