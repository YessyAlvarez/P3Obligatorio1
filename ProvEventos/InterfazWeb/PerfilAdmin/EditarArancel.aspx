<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EditarArancel.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EditarArancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Arancel Proveedores<br />
    --------------------<asp:Panel ID="PanelValorActual" runat="server">
        <p>
            &nbsp;</p>
        <p>
            El calor actual del arancel para proveedores es de&nbsp;
            <asp:TextBox ID="TextBoxValorArancel" runat="server"></asp:TextBox>
        </p>
        <br />
        <asp:Button ID="ButtonGuardarArancel" runat="server" OnClick="ButtonGuardarArancel_Click" Text="Guardar cambios" />
        <br />
    </asp:Panel>
    <p></p>
    <asp:Panel ID="PanelMensaje" runat="server">
        <br />
        <asp:Label ID="LabelMensaje" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonVolver" runat="server" OnClick="ButtonVolver_Click" Text="Modificar arancel" />
        <br />
    </asp:Panel>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
   



</asp:Content>
