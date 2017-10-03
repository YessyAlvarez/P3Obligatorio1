using System;
using Dominio;
using InterfazWeb.ServiceReference1;

namespace InterfazWeb.PerfilAdmin
{
    public partial class ObtenerProveedorPorRUT : System.Web.UI.Page
    {
        ServiceClient miServicio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestro los paneles
                PanelBuscadorPorID.Visible = true;
                PanelDatosProveedor.Visible = false;
                PanelMensaje.Visible = false;
            }
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

        protected void showMensaje(string mensaje)
        {
            //Muestro los paneles
            PanelBuscadorPorID.Visible = true;
            PanelDatosProveedor.Visible = false;
            PanelMensaje.Visible = true;
            //Asigno el mensaje
            LabelMensaje.Text = mensaje;
        }


        protected void cargarDatosProveedor(Proveedor proveedor)
        {
            //Muestro los paneles
            PanelDatosProveedor.Visible = true;
            PanelMensaje.Visible = false;

            //Cargo los datos
            LabelRUT.Text = proveedor.RUT;
            LabelNombreFantasia.Text = proveedor.NombreFantasia;
            LabelNombreCompleto.Text = proveedor.NombreApellido;
            LabelEmail.Text = proveedor.Email;
            LabelFechaIngreso.Text = proveedor.FechaRegistro.ToShortDateString();
            LabelTelefono.Text = proveedor.Telefono;
            LabelVIP.Text = proveedor.VIP ? "Si" : "No";
            if (proveedor.VIP)
            {
                LabelArancel.Text = proveedor.ArancelVIP.ToString();
            }
            else
            {
                LabelArancel.Text = "No tiene arancel";
            }
            LabelActivo.Text = proveedor.Activo ? "Si" : "No";
        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            PanelBuscadorPorID.Visible = true;
            PanelDatosProveedor.Visible = false;
            PanelMensaje.Visible = false;
        }
    }
}