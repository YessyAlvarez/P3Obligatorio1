<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="CatalogoServicios.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.CatalogoServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Catálogo de Servicios
        <br />
        -----------------------
    </p>
    <asp:Panel ID="PanelSeleccionTipoEvento" runat="server">
        Tipo de Servicio:
        <asp:DropDownList ID="DropDownListServicios" runat="server" DataTextField="NombreServicio" DataValueField="IdServicio">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="ButtonShowServicios" runat="server" OnClick="ButtonShowServicios_Click" Text="Mostrar Tipos de Evento" />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="PanelServiciosDelEvento" runat="server">
        <div class="seleccionadoProveedor">
            Tipo de servicio:
            <asp:Label ID="LabelTipoEvento" runat="server"></asp:Label>
            <br />
            <br />
            Tipos de evento para el servicio seleccionado:<br />
            <asp:ListBox ID="ListBoxServicios" runat="server"></asp:ListBox>
            <br />
            <asp:Label ID="LabelVacioTipoEvento" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonClose" runat="server" Text="Cerrar" OnClick="ButtonClose_Click" />
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
