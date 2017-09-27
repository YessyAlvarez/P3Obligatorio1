﻿using System;
using Dominio;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServiceReference1;


namespace InterfazWeb.PerfilAdmin
{
    public partial class EliminarProveedor : System.Web.UI.Page
    {
        ServiceClient miServicio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscarProveedor_Click(object sender, EventArgs e)
        {
            string idProveedor = TextBoxIdBuscadorProveedor.Text;
            Proveedor proveedor = miServicio.WCFShowProveedorPorRUT(idProveedor);
            if (proveedor != null)
            {
                cargarDatosProveedor(proveedor);
            }
            else
            {
                string mensaje = "No existe un proveedor con ese RUT.";
                showMensaje(mensaje);
            }
        }

        protected void cargarDatosProveedor(Proveedor proveedor)
        {
            LabelNombre.Text = proveedor.NombreApellido;
            LabelFechaIngreso.Text = proveedor.FechaRegistro.ToShortDateString();
            LabelVIP.Text = proveedor.VIP ? "Si" : "No";
            if (proveedor.VIP)
            {
                LabelArancel.Text = proveedor.ArancelVIP.ToString();
            }
            else
            {
                LabelArancel.Text = "No tiene arancel";
            }
        }


        protected void showMensaje(string mensaje)
        {
            PanelMensaje.Visible = true;
            LabelMensaje.Text = mensaje;

            PanelMensaje.Visible = false;

        }
    }
}