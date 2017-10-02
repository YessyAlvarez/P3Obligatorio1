using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.Master
{
    public partial class PerfilAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfilUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["nombreUsuario"] != null)
            {
                PanelOnlyLoginTrue.Visible = true;
                lblNombreUsuario.Text = Session["nombreUsuario"].ToString();
            }
            else
            {
                PanelOnlyLoginTrue.Visible = false;
            }
        }

        protected void LinkButtonSalir_Click(object sender, EventArgs e)
        {
            //Dejo las variables de sesion en null 
            Session["perfilUsuario"] = null;
            Session["nombreUsuario"] = null;
            //Redirecciono al login
            Response.Redirect("~/Login.aspx");
        }

        protected void LinkButtonABMOrganizador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ABMOrganizador.aspx");
        }

        protected void LinkButtonABMEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ABMEvento.aspx");
        }

        protected void LinkButtonABMServicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ABMServicio.aspx");
        }

        protected void LinkButtonABMProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ABMProveedor.aspx");
        }

        protected void LinkButtonListadoProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ListadoProveedores.aspx");
        }

        protected void LinkButtonObtenerProveedorPorRUT_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ObtenerProveedorPorRUT.aspx");
        }

        protected void LinkButtonListadoOrganizadores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ListadoOrganizadores.aspx");
        }

        protected void LinkButtonEventosPorOrganizador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/EventosPorOrganizador.aspx");
        }

        protected void LinkButtonCatalogoServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/CatalogoServicios.aspx");

        }

        protected void LinkButtonGrabarProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/GuardarEnTxt.aspx");
        }
    }
}