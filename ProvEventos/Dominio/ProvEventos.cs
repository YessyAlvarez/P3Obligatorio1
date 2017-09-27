using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProvEventos
    {

        #region USUARIO

        public void AddUsuario(string usuario, string NombreCompleto, EnumPerfil rol)
        {
            /* Usuario user = new Usuario(usuario, NombreCompleto, rol);
             ListaUsuarios.Add(user);
             ClinicaMedica.Serializar();*/
        }

        public EnumPerfil ValidarUsuario(string usuario, string password)
        {
            return Usuario.ObtenerPerfil(usuario, password); ;
        }


        public string GetNombreCompleto(string usuarioIngresado)
        {
            string nombrecompleto = "";
            /*if (ListaUsuarios.Count > 0)
            {
                foreach (Usuario usuario in ListaUsuarios)
                {
                    if (usuario.User == usuarioIngresado)
                    {
                        nombrecompleto = usuario.NombreCompleto;
                    }
                }
            }*/
            return nombrecompleto;
        }

        #endregion


    }
}
