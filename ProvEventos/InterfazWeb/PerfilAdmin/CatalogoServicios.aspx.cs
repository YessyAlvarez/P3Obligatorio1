using InterfazWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using Dominio;

namespace InterfazWeb.PerfilAdmin
{
    public partial class CatalogoServicios : System.Web.UI.Page
    {
        ServiceClient mio = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelSeleccionTipoEvento.Visible = true;
                PanelServiciosDelEvento.Visible = false;
                cargarTiposEvento();
                ListBoxServicios.Visible = true;
            }
        }

        protected void cargarTiposEvento()
        {
            //Cargo el combo del buscador de tipo de eventos
            DropDownListServicios.Items.Clear();
            DropDownListServicios.DataSource = mio.WCFAllServiciosWhitTipoEvento();
            DropDownListServicios.DataBind();
        }

        protected void ButtonShowServicios_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(DropDownListServicios.SelectedValue);

            //Muestro los paneles correctos
            PanelServiciosDelEvento.Visible = true;

            //Cargo los datos a mostrar
            LabelTipoEvento.Text = DropDownListServicios.SelectedItem.ToString();
            if (Servicio.FindTipoEventoFroServicio(idSeleccionado).Count > 0)
            {
                ListBoxServicios.Visible = true;
                ListBoxServicios.Items.Clear();
                ListBoxServicios.DataSource = Servicio.FindTipoEventoFroServicio(idSeleccionado);
                ListBoxServicios.DataBind();
                LabelVacioTipoEvento.Text = "";
            }
            else
            {
                ListBoxServicios.Visible = false;
                LabelVacioTipoEvento.Text = "No tiene Tipos de Evento asociado.";
            }
        }

        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            PanelSeleccionTipoEvento.Visible = true;
            PanelServiciosDelEvento.Visible = false;
        }
    }
}