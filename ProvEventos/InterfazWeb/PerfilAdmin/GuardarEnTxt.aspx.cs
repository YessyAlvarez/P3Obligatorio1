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
            miServicio.WCFGuardarTxtProveedores();
        }

        protected void ButtonEven_Click(object sender, EventArgs e)
        {

        }
    }
}