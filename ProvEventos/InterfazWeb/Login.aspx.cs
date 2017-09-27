using System;
using Dominio;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class Login : System.Web.UI.Page
    {
        ProvEventos prov = new ProvEventos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string usuario = LoginInicio.UserName;
            string password = LoginInicio.Password;
            EnumPerfil perfilUsuario = prov.ValidarUsuario(usuario, password);
            if (perfilUsuario != EnumPerfil.NoAutorizado)
            {
                //Asigno a la sesion el tipo
                Session["perfilUsuario"] = perfilUsuario;
                //Asigno a la sesión el Nombre y Apellido
                Session["nombreUsuario"] = prov.GetNombreCompleto(usuario);
                //Asigno el usuario a la sesión
                Session["usuarioLogueado"] = usuario;
                //Autenticación exitosa
                e.Authenticated = true;
                //Re-dirijo a la home de cada perfil
                if (perfilUsuario == EnumPerfil.Admin)
                {
                    Response.Redirect("Bienvenidos/BienvenidoAdmin.aspx");
                }
                else if (perfilUsuario == EnumPerfil.Proveedor)
                {
                    Response.Redirect("Bienvenidos/BienvenidoProveedor.aspx");
                }
                else
                {
                    Response.Redirect("Bienvenidos/BienvenidoOrganizador.aspx");
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}