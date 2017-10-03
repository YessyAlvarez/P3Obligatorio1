using InterfazWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using Dominio;

namespace InterfazWeb.PerfilAdmin
{
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        ServiceClient mio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                PanelSeleccionProveedor.Visible = true;
                PanelDatosProveedorSeleccionado.Visible = false;
                ObtenerTodosLosProveedores();
            }
        }


        protected void ObtenerTodosLosProveedores()
        {
            //Muestro los datos correspondientes
            DropDownListAllProveedores.Items.Clear();
            DropDownListAllProveedores.DataSource = mio.WCFShowAllProveedores();
            DropDownListAllProveedores.DataBind();
        }

        protected void ButtonProveedorSeleccionado_Click(object sender, EventArgs e)
        {
            string RUTseleccionado = DropDownListAllProveedores.SelectedValue;
            cargarDatosProveedor(RUTseleccionado);
            //Muestro los paneles
            PanelSeleccionProveedor.Visible = true;
            PanelDatosProveedorSeleccionado.Visible = true;
        }



        protected void cargarDatosProveedor(string RUTseleccionado) {
            Proveedor p = mio.WCFShowProveedorPorRUT(RUTseleccionado);
            //Cargo los datos
            LabelRUT.Text = p.RUT;
            LabelNombreFantasia.Text = p.NombreFantasia;
            LabelEmail.Text = p.Email;
            LabelFechaIngreso.Text = p.FechaRegistro.ToShortDateString();
            LabelTelefono.Text = p.Telefono;
            LabelVIP.Text = p.VIP ? "Si" : "No";
            LabelArancelVIP.Text = p.ArancelVIP.ToString();
            LabelActivo.Text = p.Activo ? "Si" : "No";

            //Cargo los datos de Servicios del proveedor
            if (p.ListaServicios.Count > 0)
            {
                GridViewServiciosProveedor.DataSource = p.ListaServicios;
                GridViewServiciosProveedor.DataBind();
                LabelSinServicios.Text = "";
            }
            else{
                LabelSinServicios.Text = "El proveedor no cuenta con servicios asociados.";
            }
            
        }



    }
}