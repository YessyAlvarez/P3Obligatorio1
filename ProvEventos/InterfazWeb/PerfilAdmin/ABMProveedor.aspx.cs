using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilAdmin
{
    public partial class ABMProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAltaProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaProveedor.aspx");
        }

        protected void ButtonEditarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarProveedor.aspx");
        }

        protected void ButtonEliminarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarProveedor.aspx");
        }

        protected void ButtonModArancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarArancel.aspx");
        }
    }
}