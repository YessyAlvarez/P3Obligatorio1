using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesosDB;
using System.Diagnostics;

namespace Dominio
{
    public class ProveedorServicio
    {
        public string IdProveedor { set; get; }
        public int IdServicio { set; get; }
        public string Imagen { set; get; }
        public string Descripcion { set; get; }
        public bool Activo { set; get; }

        public static List<ProveedorServicio> traerServiciosProveedor(string rut) {

            List<ProveedorServicio> ret = new List<ProveedorServicio>();
            string consulta = @"SELECT * FROM Proveedor_Servicios where idProveedor = '" + rut + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProveedorServicio s = new ProveedorServicio();
                    s.IdProveedor = dr["idProveedor"].ToString();
                    s.IdServicio = Convert.ToInt32(dr["idServicio"]);
                    s.Imagen = dr["foto"].ToString();
                    s.Descripcion = dr["descripcion"].ToString();
                    s.Activo = dr["Activo"].Equals("1") ? true : false;
                    ret.Add(s);
                }
                dr.Close();
                return ret;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
        public string NombreServicio() {
            string ret = null;
            string consulta = @"SELECT nombreServicio FROM Servicio where idServicio = " + this.IdServicio;
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    ret = (string)dr["nombreServicio"];
                }
                dr.Close();
                return ret;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
        public string ToString2() {
            return this.NombreServicio() + ":" + this.Descripcion + ":" + this.Imagen + "#";
        }
    }
}
