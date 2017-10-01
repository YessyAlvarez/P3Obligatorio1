using System;
using Dominio;
//using ServiciosWCF;
using InterfazWeb.ServiceReference1;


namespace InterfazWeb.PerfilAdmin
{
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                PanelAltaProveedor.Visible = true;
                PanelMensajeAlta.Visible = false;
            }
        }

        protected void ButtonAltaProveedor_Click(object sender, EventArgs e)
        {
            //Obtengo los datos
            string usuario = TextBoxAltaUsuario.Text;
            string password = TextBoxAltaPass.Text;
            string nombreCompleto = TextBoxAltaNombreCompleto.Text;
            string nombreFantasia = TextBoxNombreFantasia.Text;
            string email = TextBoxEmail.Text;
            string telefono = TextBoxTelefono.Text;
            bool esVIP = DropDownListAltaVIP.SelectedValue.Equals("Si") ? true : false;
            double arancelVIP = Convert.ToDouble(TextBoxAltaArancelVIP.Text);
            if (esVIP)
            {
                arancelVIP = Convert.ToDouble(TextBoxAltaArancelVIP.Text);
            }
            else
            {
                arancelVIP = 0;
            }
            ServiceClient mio = new ServiceClient();
            bool exito = mio.WCFAddProveedor(nombreCompleto, usuario, password, nombreFantasia, email, telefono, esVIP, arancelVIP);
            if (exito)
            {
                //Limpio los campos
                limpiarCampos();
                //Muestro los paneles
                PanelAltaProveedor.Visible = false;
                PanelMensajeAlta.Visible = true;
                LabelMensaje.Text = "Proveedor agregado exitosamente";
            }
            else
            {
                //Limpio los campos
                limpiarCampos();
                //Muestro los paneles
                PanelAltaProveedor.Visible = false;
                PanelMensajeAlta.Visible = true;
                LabelMensaje.Text = "Intente nuevamente. El Proveedor no fue ingresado al sistema.";
            }
        }

        protected void DropDownListAltaVIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esVIP = DropDownListAltaVIP.SelectedValue.Equals("Si") ? true : false;
            if (!esVIP)
            {
                PanelArancelVIP.Visible = false;
            }
        }

        protected void ButtonNewAddProveedor_Click(object sender, EventArgs e)
        {
            //Limpio los campos
            limpiarCampos();
            //Muestro los paneles
            PanelAltaProveedor.Visible = true;
            PanelMensajeAlta.Visible = false;
        }


        protected void limpiarCampos()
        {
            TextBoxAltaUsuario.Text = "";
            TextBoxAltaPass.Text = "";
            TextBoxAltaNombreCompleto.Text = "";
            TextBoxAltaArancelVIP.Text = "";
        }
    }
}