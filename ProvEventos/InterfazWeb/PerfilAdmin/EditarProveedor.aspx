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
        Ingrese RUT de Proveedor<br />
        <asp:TextBox ID="TextBoxIdBuscadorProveedor" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonBuscarProveedor" runat="server" OnClick="ButtonBuscarProveedor_Click" Text="Buscar" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelResultadoProveedor" runat="server">
        <div class="seleccionadoProveedor">
            <br />
            Nombre completo<br />
            <asp:TextBox ID="TextBoxNombreCompleto" runat="server"></asp:TextBox>
            <br />
            Nombre Fantasía<br />
            <asp:TextBox ID="TextBoxNameFantasia" runat="server"></asp:TextBox>
            <br />
            Email<br />
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <br />
            Fecha de ingreso:
            <asp:Label ID="LabelFechaIngreso" runat="server"></asp:Label>
            <br />
            Telefono<br />
            <asp:TextBox ID="TextBoxTelefono" runat="server"></asp:TextBox>
            <br />
            VIP<br />
            <asp:DropDownList ID="DropDownListVIP" runat="server" OnSelectedIndexChanged="DropDownListVIP_SelectedIndexChanged">
                <asp:ListItem>Si</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="ButtonSeleccionarVIP" runat="server" OnClick="ButtonSeleccionarVIP_Click" Text="Seleccionar" />
            <br />
            <asp:Panel ID="PanelArancelVIP" runat="server">
                Arancel VIP<br />
                <asp:TextBox ID="TextBoxArancelVIP" runat="server"></asp:TextBox>
            </asp:Panel>
            Activo:
            <asp:Label ID="LabelActivo" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonGuardarCambiosProveedor" runat="server" OnClick="ButtonGuardarCambiosProveedor_Click" Text="Guardar" />
            <br />
            <br />
        </div>
    </asp:Panel>
    <p>
        &nbsp;</p>
    <asp:Panel ID="PanelMensaje" runat="server">
        <br />
        <br />
        <asp:Label ID="LabelMensaje" runat="server" Text=" "></asp:Label>
        <br />
        <br />
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
