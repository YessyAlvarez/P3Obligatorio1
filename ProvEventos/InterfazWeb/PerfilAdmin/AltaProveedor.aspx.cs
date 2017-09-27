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

        }

        protected void ButtonAltaProveedor_Click(object sender, EventArgs e)
        {
            //Obtengo los datos
            string usuario = TextBoxAltaUsuario.Text;
            string password = TextBoxAltaPass.Text;
            string nombreCompleto = TextBoxAltaNombreCompleto.Text;
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
            mio.WCFAddProveedor(nombreCompleto, usuario, password, esVIP, arancelVIP);
            
        }

        protected void DropDownListAltaVIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esVIP = DropDownListAltaVIP.SelectedValue.Equals("Si") ? true : false;
            if (!esVIP)
            {
                PanelArancelVIP.Visible = false;
            }
        }
    }
}