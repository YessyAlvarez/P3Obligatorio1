using AccesosDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string UsuarioLogin { set; get; }
        public string Password { set; get; }
        public EnumPerfil TipoPerfil { set; get; }
        public string NombreApellido { set; get; }


        /*   public Usuario(string unNombreApellido, string nombreUsuario, string passw, EnumPerfil tipoPerfl)
           {
               this.NombreApellido = unNombreApellido;
               this.UsuarioLogin = nombreUsuario;
               this.Password = passw;
               this.TipoPerfil = tipoPerfl;
           }
           */


        #region BUSCAR USUARIO

        public static EnumPerfil ObtenerPerfil(string usuario, string password)
        {
            EnumPerfil perfilUsuario = EnumPerfil.NoAutorizado;

            string consulta = @"SELECT tipoPerfil FROM Usuario WHERE nombreUsuario='" + usuario + "' AND contrasenia='" + password + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string perfil = dr.IsDBNull(dr.GetOrdinal("tipoPerfil")) ? "" : dr.GetString(dr.GetOrdinal("tipoPerfil"));
                    if (perfil.Equals("1"))
                    {
                        perfilUsuario = EnumPerfil.Admin;
                    }
                    else if (perfil.Equals("2"))
                    {
                        perfilUsuario = EnumPerfil.Proveedor;
                    }
                    else if (perfil.Equals("3"))
                    {
                        perfilUsuario = EnumPerfil.Organizador;
                    }
                }
                dr.Close();
                return perfilUsuario;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return perfilUsuario;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        #endregion



    }
}
