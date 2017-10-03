using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServiceReference1;

namespace InterfazWeb.PerfilAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceClient miServicio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void ButtonProv_Click(object sender, EventArgs e)
        { 
            bool exito = miServicio.WCFGuardarTxtProveedores();
            if (exito)
            {
                LabelMensaje.Text = "Archivo de Proveedores guardado con éxito.";
            }
            else
            {
                LabelMensaje.Text = "ERROR! No se pudo guardar el archivo de Proveedores.";
            }
        }

        protected void ButtonEven_Click(object sender, EventArgs e)
        {
            bool exito = miServicio.WCFGuardarTxtServicios();
            if (exito)
            {
                LabelMensaje.Text = "Archivo de Servicios guardado con éxito.";
            }
            else
            {
                LabelMensaje.Text = "ERROR! No se pudo guardar el archivo de Servicios.";
            }
        }
    }
}