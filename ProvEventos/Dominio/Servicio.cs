using AccesosDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Servicio
    {
        public int IdServicio { set; get; }
        public string NombreServicio { set; get; }
        public List<TipoEvento> ListaEventos { set; get; }

        public static List<Servicio> ObtenerServiciosConTipoEvento()
        {
            string consulta = @"SELECT idServicio, nombreServicio FROM Servicio";

            SqlConnection cn = Conexion.CrearConexion();

            List<Servicio> listaServiciosCompleta = new List<Servicio>();

            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Servicio servicio = CargarDatosDesdeReader(dr);
                    servicio.ListaEventos = FindTipoEventoFroServicio(servicio.IdServicio);
                    listaServiciosCompleta.Add(servicio);
                }
                dr.Close();
                return listaServiciosCompleta;
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



        protected static Servicio CargarDatosDesdeReader(IDataRecord fila)
        {
            Servicio servicio = null;
            if (fila != null)
            {
                servicio = new Servicio
                {
                    IdServicio = fila.IsDBNull(fila.GetOrdinal("idServicio")) ? 0 : fila.GetInt32(fila.GetOrdinal("idServicio")),
                    NombreServicio = fila.IsDBNull(fila.GetOrdinal("nombreServicio")) ? "" : fila.GetString(fila.GetOrdinal("nombreServicio")),
                };
            }
            return servicio;
        }




        public static List<TipoEvento> FindTipoEventoFroServicio(int idServicio)
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand("SELECT te.idEvento, te.nombreEvento, te.descripcion FROM ServicioTipoEvento ste ,TipoEvento te WHERE ste.idServicio=" + idServicio + " AND ste.idEvento=te.idEvento", cn);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<TipoEvento> lista = new List<TipoEvento>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoEvento
                        {
                            Id = (int)dr["idEvento"],
                            Nombre = dr["nombreEvento"].ToString(),
                            Descripcion = dr["descripcion"].ToString()
                        });
                    }
                }
                dr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }

        #region TOSTRING
        public override string ToString()
        {
            return this.NombreServicio;
        }

        #endregion

        public string ToString2() {
            return "";
        }
    }
}
