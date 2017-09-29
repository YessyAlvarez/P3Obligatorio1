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
                cargarDatosProveedor(proveedor);
            }
            else{
                string mensaje = "No existe un proveedor con ese RUT.";
                showMensaje(mensaje);
            }
        }

        protected void cargarDatosProveedor(Proveedor proveedor)
        {
            TextBoxNombreCompleto.Text = proveedor.NombreApellido;
            TextBoxContrasenia.Text = proveedor.Password;
            TextBoxFechaIngreso.Text = proveedor.FechaRegistro.ToShortDateString();
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
            string contrasenia = TextBoxContrasenia.Text;
            DateTime fechaIngreso = new DateTime(Convert.ToInt32(TextBoxFechaIngreso.Text));
            bool esVIP = DropDownListVIP.SelectedIndex.Equals("Si")?true:false;
            double arancelVIP = -100;
            if (esVIP)
            {
                arancelVIP = Convert.ToDouble(TextBoxArancelVIP.Text);
            }
            bool exito = miServicio.WCFChangeDatosProveedor(idProveedor, fechaIngreso, esVIP, arancelVIP);
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
    }
}