<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="GuardarEnTxt.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    Guardar en .txt 
    <br />
    ----------------
    <br />
    <br />
    <asp:Button ID="ButtonProv" runat="server" Text="Guardar Proveedores" OnClick="ButtonProv_Click" />
    <br />
    <br />
    <asp:Button ID="ButtonEven" runat="server" Text="Guardar Eventos" OnClick="ButtonEven_Click" />
   <p>
     <asp:Label ID="LabelMensaje" runat="server"></asp:Label>
       </p>
</asp:Content>
