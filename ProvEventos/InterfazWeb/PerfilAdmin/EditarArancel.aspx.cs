using InterfazWeb.ServiceReference1;
using System;
using Dominio;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EditarArancel : System.Web.UI.Page
    {
        ServiceClient mio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                PanelValorActual.Visible = true;
                PanelMensaje.Visible = false;
                
                Proveedor.ArancelAnual = mio.WCFObtenerArancelAnualProveedor();
            }
            else
            {
                ObtenerArancel();
            }
        }


        protected void ObtenerArancel() {
            TextBoxValorArancel.Text = Proveedor.ArancelAnual.ToString();
        }

        protected void ButtonGuardarArancel_Click(object sender, EventArgs e)
        {
            int nuevoValor = Convert.ToInt32(TextBoxValorArancel.Text);
            bool exito = mio.WCFChangeArancelAnualProveedor(nuevoValor);
            if (exito)
            {
                PanelValorActual.Visible = false;
                PanelMensaje.Visible = true;
                LabelMensaje.Text = "Arancel modificado con exito.";
            }
            else
            {
                PanelValorActual.Visible = false;
                PanelMensaje.Visible = true;
                LabelMensaje.Text = "ERROR! Intente nuevamente.";
            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            PanelValorActual.Visible = true;
            PanelMensaje.Visible = false;
            LabelMensaje.Text = "";
        }
    }
}