using System;
using Dominio;
using InterfazWeb.ServiceReference1;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace InterfazWeb.PerfilAdmin
{
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                PanelStep1.Visible = true;
                PanelStep2.Visible = false;
                PanelMensajeAlta.Visible = false;
            }
        }


        protected List<ProveedorServicio> ObtenerListaServiciosProveedor()
        {
            List<ProveedorServicio> resultado = new List<ProveedorServicio>();
            bool seleccion = DropDownList1.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 1;
                ps.Descripcion = TextBox1.Text;
                if (FileUpload1.HasFile)
                {
                    ps.Imagen = FileUpload1.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload1.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList2.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 2;
                ps.Descripcion = TextBox2.Text;
                if (FileUpload2.HasFile)
                {
                    ps.Imagen = FileUpload2.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload2.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList3.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 3;
                ps.Descripcion = TextBox3.Text;
                if (FileUpload3.HasFile)
                {
                    ps.Imagen = FileUpload3.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload3.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList4.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 4;
                ps.Descripcion = TextBox4.Text;
                if (FileUpload4.HasFile)
                {
                    ps.Imagen = FileUpload4.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload4.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList5.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 5;
                ps.Descripcion = TextBox5.Text;
                if (FileUpload5.HasFile)
                {
                    ps.Imagen = FileUpload5.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload5.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList6.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 6;
                ps.Descripcion = TextBox6.Text;
                if (FileUpload6.HasFile)
                {
                    ps.Imagen = FileUpload6.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload6.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList7.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 7;
                ps.Descripcion = TextBox7.Text;
                if (FileUpload7.HasFile)
                {
                    ps.Imagen = FileUpload7.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload7.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList8.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 8;
                ps.Descripcion = TextBox8.Text;
                if (FileUpload8.HasFile)
                {
                    ps.Imagen = FileUpload8.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload8.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList9.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 9;
                ps.Descripcion = TextBox9.Text;
                if (FileUpload9.HasFile)
                {
                    ps.Imagen = FileUpload9.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload9.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList10.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 10;
                ps.Descripcion = TextBox10.Text;
                if (FileUpload10.HasFile)
                {
                    ps.Imagen = FileUpload10.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload10.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList11.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 11;
                ps.Descripcion = TextBox11.Text;
                if (FileUpload11.HasFile)
                {
                    ps.Imagen = FileUpload11.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload11.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList12.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 12;
                ps.Descripcion = TextBox12.Text;
                if (FileUpload12.HasFile)
                {
                    ps.Imagen = FileUpload12.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload12.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList13.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 13;
                ps.Descripcion = TextBox13.Text;
                if (FileUpload13.HasFile)
                {
                    ps.Imagen = FileUpload13.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload13.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList14.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 14;
                ps.Descripcion = TextBox14.Text;
                if (FileUpload14.HasFile)
                {
                    ps.Imagen = FileUpload14.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload14.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList15.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 15;
                ps.Descripcion = TextBox15.Text;
                if (FileUpload15.HasFile)
                {
                    ps.Imagen = FileUpload15.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload15.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList16.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 16;
                ps.Descripcion = TextBox16.Text;
                if (FileUpload16.HasFile)
                {
                    ps.Imagen = FileUpload16.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload16.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            seleccion = DropDownList17.SelectedValue.Equals("Si") ? true : false;
            if (seleccion)
            {
                ProveedorServicio ps = new ProveedorServicio();
                ps.IdProveedor = TextBoxAltaUsuario.Text;
                ps.IdServicio = 17;
                ps.Descripcion = TextBox17.Text;
                if (FileUpload17.HasFile)
                {
                    ps.Imagen = FileUpload17.FileName;
                    string ruta = "~/ImagenesProveedorServicio/" + ps.Imagen;
                    FileUpload17.SaveAs(Server.MapPath(ruta));
                }
                ps.Activo = true;
                //Cargo el Objeto a la lista
                resultado.Add(ps);
            }
            return resultado;
        }

        protected void ButtonAltaProveedor_Click(object sender, EventArgs e)
        {
            //Obtengo los datos del proveedor
            string usuario = TextBoxAltaUsuario.Text;
            string password = TextBoxAltaPass.Text;
            string nombreCompleto = TextBoxAltaNombreCompleto.Text;
            string nombreFantasia = TextBoxNombreFantasia.Text;
            string email = TextBoxEmail.Text;
            string telefono = TextBoxTelefono.Text;
            bool esVIP = DropDownListAltaVIP.SelectedValue.Equals("Si") ? true : false;
            double arancelVIP = 0;
            if (esVIP)
            {
                arancelVIP = Convert.ToDouble(TextBoxAltaArancelVIP.Text);
            }
            //Obtengo los datos de los servicios
            List<ProveedorServicio> listaServicios = ObtenerListaServiciosProveedor();
            //Llamo al WCF
            ServiceClient mio = new ServiceClient();
            bool exito = mio.WCFAddProveedor(nombreCompleto, usuario, password, nombreFantasia, email, telefono, esVIP, arancelVIP, listaServicios.ToArray());
            if (exito)
            {
                //Limpio los campos
                limpiarCampos();
                //Muestro los paneles
                PanelStep1.Visible = false;
                PanelStep2.Visible = false;
                PanelMensajeAlta.Visible = true;
                LabelMensaje.Text = "Proveedor agregado exitosamente";
            }
            else
            {
                //Limpio los campos
                limpiarCampos();
                //Muestro los paneles
                PanelStep1.Visible = false;
                PanelStep2.Visible = false;
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
            PanelStep1.Visible = true;
            PanelStep2.Visible = false;
            PanelMensajeAlta.Visible = false;
        }


        protected void limpiarCampos()
        {
            TextBoxAltaUsuario.Text = "";
            TextBoxAltaPass.Text = "";
            TextBoxAltaNombreCompleto.Text = "";
            TextBoxAltaArancelVIP.Text = "";
        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            PanelStep2.Visible = true;
            PanelStep1.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            PanelStep1.Visible = false;
            PanelStep2.Visible = true;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            PanelStep1.Visible = true;
            PanelStep2.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            PanelStep1.Visible = true;
            PanelStep2.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            PanelStep2.Visible = true;
            PanelStep1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelStep1.Visible = true;
            PanelStep2.Visible = false;
        }
    }
}