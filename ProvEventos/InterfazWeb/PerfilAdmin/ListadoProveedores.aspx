<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ListadoProveedores.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.ListadoProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Listado de Proveedores<br />-------------------------</p>
    <asp:Panel ID="PanelSeleccionProveedor" runat="server">
        <br />
        Seleccione un proveedor para visualizar todos sus datos<br />
        <asp:DropDownList ID="DropDownListAllProveedores" runat="server" DataTextField="NombreFantasia" DataValueField="RUT">
        </asp:DropDownList>
        <br />
        <asp:Button ID="ButtonProveedorSeleccionado" runat="server" Text="Seleccionar" OnClick="ButtonProveedorSeleccionado_Click" />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    
    <asp:Panel ID="PanelDatosProveedorSeleccionado" runat="server">
        <div class="seleccionadoProveedor">
        <br />
        Datos del Proveedor:
        <asp:Label ID="LabelRUT" runat="server"></asp:Label>
        <br />
        <br />
        Nombre Fantasía:&nbsp;
        <asp:Label ID="LabelNombreFantasia" runat="server"></asp:Label>
        <br />
        Email :
        <asp:Label ID="LabelEmail" runat="server"></asp:Label>
        <br />
        Fecha de Ingreso:
        <asp:Label ID="LabelFechaIngreso" runat="server"></asp:Label>
        <br />
        Teléfono:
        <asp:Label ID="LabelTelefono" runat="server"></asp:Label>
        <br />
        VIP:
        <asp:Label ID="LabelVIP" runat="server"></asp:Label>
        <br />
        Arancel VIP:&nbsp;
        <asp:Label ID="LabelArancelVIP" runat="server"></asp:Label>
        <br />
        Activo:
        <asp:Label ID="LabelActivo" runat="server"></asp:Label>
        <br />
        <br />
        Listado de Servicios que ofrece:<br />
        <asp:GridView ID="GridViewServiciosProveedor" runat="server">
        </asp:GridView>
        <asp:Label ID="LabelSinServicios" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonCerrar" runat="server" Text="Cerrar" OnClick="ButtonCerrar_Click" />
        <br />
        <br />
        </div>
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
