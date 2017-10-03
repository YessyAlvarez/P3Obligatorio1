using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dominio;
using InterfazWeb.ServiceReference1;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EditarProveedor : System.Web.UI.Page
    {
        ServiceClient miServicio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                PanelBuscadorPorID.Visible = true;
                PanelResultadoProveedor.Visible = false;
                PanelMensaje.Visible = false;
            }
        }

        protected void ButtonBuscarProveedor_Click(object sender, EventArgs e)
        {
            string idProveedor = TextBoxIdBuscadorProveedor.Text;
            Proveedor proveedor = miServicio.WCFShowProveedorPorRUT(idProveedor);
            if (proveedor != null){
                //Muestro los paneles
                PanelBuscadorPorID.Visible = true;
                PanelResultadoProveedor.Visible = true;
                PanelMensaje.Visible = false;
                //Cargo los datos
                cargarDatosProveedor(proveedor);
            }
            else{
                //Muestro los paneles
                PanelBuscadorPorID.Visible = true;
                PanelResultadoProveedor.Visible = false;
                PanelMensaje.Visible = true;
                //Cargo el mensaje
                string mensaje = "No existe un proveedor con ese RUT.";
                showMensaje(mensaje);
            }
        }

        protected void cargarDatosProveedor(Proveedor proveedor)
        {
            TextBoxNombreCompleto.Text = proveedor.NombreApellido;
            TextBoxNameFantasia.Text = proveedor.NombreFantasia;
            TextBoxEmail.Text = proveedor.Email;
            LabelFechaIngreso.Text = proveedor.FechaRegistro.ToShortDateString();
            TextBoxTelefono.Text = proveedor.Telefono;
            LabelActivo.Text = proveedor.Activo ? "Si" : "No";
            DropDownListVIP.SelectedValue = proveedor.VIP?"Si":"No";
            if (proveedor.VIP)
            {
                PanelArancelVIP.Visible = true;
                TextBoxArancelVIP.Text = proveedor.ArancelVIP.ToString();
            }
            else
            {
                PanelArancelVIP.Visible = false;
            }
        }


        protected void showMensaje(string mensaje)
        {
            PanelMensaje.Visible = true;
            LabelMensaje.Text = mensaje;

            PanelResultadoProveedor.Visible = false;

        }

        protected void ButtonGuardarCambiosProveedor_Click(object sender, EventArgs e)
        {
            //Obtengo los datos
			string idProveedor = TextBoxIdBuscadorProveedor.Text;
            string nombreCompleto = TextBoxNombreCompleto.Text;
            string nombreFantasia = TextBoxNameFantasia.Text;
            string telefono = TextBoxTelefono.Text;
            string email = TextBoxEmail.Text;
            bool esVIP = DropDownListVIP.SelectedValue.Equals("Si")?true:false;
            double arancelVIP = -100;
            if (esVIP)
            {
                arancelVIP = Convert.ToDouble(TextBoxArancelVIP.Text);
            }
            bool exito = miServicio.WCFChangeDatosProveedor(idProveedor, nombreCompleto, nombreFantasia, email, telefono, esVIP, arancelVIP);
            if (exito)
            {
                //Muestro los paneles
                PanelResultadoProveedor.Visible = false;
                PanelBuscadorPorID.Visible = true;
                PanelMensaje.Visible = true;
                //Muestro el mensaje
                LabelMensaje.Text = "Proveedor modificado con éxito.";
            }
            else
            {
                //Muestro los paneles
                PanelResultadoProveedor.Visible = false;
                PanelBuscadorPorID.Visible = true;
                PanelMensaje.Visible = true;
                //Muestro el mensaje
                LabelMensaje.Text = "ERROR. No se pudo modificar al Proveedor. Intente nuevamente.";
            }
        }

        protected void DropDownListVIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esVIP = DropDownListVIP.SelectedValue.Equals("Si") ? true : false;
            if (esVIP)
            {
                PanelArancelVIP.Visible = true;
            }
            else{
                PanelArancelVIP.Visible = false;
            }
        }

        protected void ButtonSeleccionarVIP_Click(object sender, EventArgs e)
        {
            bool esVIP = DropDownListVIP.SelectedValue.Equals("Si") ? true : false;
            if (esVIP)
            {
                PanelArancelVIP.Visible = true;
            }
            else
            {
                PanelArancelVIP.Visible = false;
            }
        }
    }
}