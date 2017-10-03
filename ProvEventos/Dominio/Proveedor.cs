using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AccesosDB;
using System.Diagnostics;
using System.Data;

namespace Dominio
{
    public class Proveedor : Usuario
    {
        #region ATRIBUTOS
        public static double ArancelAnual { set; get; }
        public string RUT { set; get; }
        public string NombreFantasia { set; get; }
        public string Email { set; get; }
        public DateTime FechaRegistro { set; get; }
        public string Telefono { set; get; }
        public bool VIP { set; get; }
        public double ArancelVIP { set; get; }
        public bool Activo { set; get; }
        public List<ProveedorServicio> ListaServicios { set; get; }
        #endregion

        #region MÉTODOS
        public static bool ChangeArancel(int nuevoArancel)
        {

            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE ArancelAnualProveedor SET arancel=@newArancel WHERE id=1;";
            cmd.Parameters.AddWithValue("@newArancel", nuevoArancel);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;

                //Ejecuto la consulta
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }

        }


        public bool InsertarProveedor()
        {
            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"INSERT INTO Usuario VALUES(@usuario,@passw,@nombre,@perfil);";
            cmd.Parameters.AddWithValue("@usuario", this.UsuarioLogin);
            cmd.Parameters.AddWithValue("@passw", Usuario.MD5Hash(this.Password));
            cmd.Parameters.AddWithValue("@nombre", this.NombreApellido);
            cmd.Parameters.AddWithValue("@perfil", 2);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();
                //int ultimoId = (int)cmd.ExecuteScalar();

                cmd.Parameters.Clear();
                cmd.CommandText = @"INSERT INTO Proveedor VALUES(@rut,@nombreFantasia,@email,@fecha,@telefono,@vip,@arancelVIP,@activo)";

                cmd.Parameters.Add(new SqlParameter("@rut", RUT));
                cmd.Parameters.Add(new SqlParameter("@nombreFantasia", NombreFantasia));
                cmd.Parameters.Add(new SqlParameter("@email", Email));
                cmd.Parameters.Add(new SqlParameter("@fecha", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@telefono", Telefono));
                cmd.Parameters.Add(new SqlParameter("@vip", this.VIP));
                cmd.Parameters.Add(new SqlParameter("@arancelVIP", this.ArancelVIP));
                cmd.Parameters.Add(new SqlParameter("@activo", 1));

                cmd.ExecuteNonQuery();
                int filasAfectadas = 0;
                for (int i=0; i<this.ListaServicios.Count; i++)
                {
                    ProveedorServicio ps = ListaServicios[i];
                    if (ps != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"INSERT INTO Proveedor_Servicios VALUES(@idprov,@idServ,@foto,@desc,@activo)";

                        cmd.Parameters.Add(new SqlParameter("@idprov", ps.IdProveedor));
                        cmd.Parameters.Add(new SqlParameter("@idServ", ps.IdServicio));
                        cmd.Parameters.Add(new SqlParameter("@foto", ps.Imagen));
                        cmd.Parameters.Add(new SqlParameter("@desc", ps.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@activo", 1));
                        filasAfectadas += cmd.ExecuteNonQuery();
                    }
                }
                

                if (filasAfectadas == this.ListaServicios.Count)
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }


        public static List<Proveedor> ObtenerAllProveedores()
        {

            string consulta = @"SELECT idProveedor, fechaIngreso, VIP, arancelVIP, activo FROM Proveedor";

            SqlConnection cn = Conexion.CrearConexion();

            List<Proveedor> lista = new List<Proveedor>();

            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Proveedor p = CargarDatosDesdeReader(dr);
                    if (p.Activo)
                    {
                        lista.Add(p);
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
                Conexion.CerrarConexion(cn);
            }

        }



        protected static Proveedor CargarDatosDesdeReader(IDataRecord fila)
        {
            Proveedor proveedor = null;
            if (fila != null)
            {
                proveedor = new Proveedor
                {
                    NombreApellido = fila.IsDBNull(fila.GetOrdinal("nombreCompleto")).ToString(),
                    FechaRegistro = DateTime.Now,//fila.IsDBNull(fila.GetOrdinal("fechaIngreso")) ? DateTime.MinValue : fila.GetDateTime(fila.GetOrdinal("fechaIngreso")).Date,
                    VIP = true,//fila.IsDBNull(fila.GetOrdinal("VIP")).Equals("1") ? true : false,
                    ArancelVIP = 12, //fila.IsDBNull(fila.GetOrdinal("arancelVIP")) ? 0 : fila.GetDouble(fila.GetOrdinal("arancelVIP")),
                    Activo = true, //fila.IsDBNull(fila.GetOrdinal("activo")) ? true : false,
                    TipoPerfil = EnumPerfil.Proveedor,
                };
            }
            return proveedor;
        }

        public static Proveedor ObtenerProveedorPorRUT(string unRUT)
        {
            string consulta = @"SELECT Usuario.nombreCompleto, Proveedor.fechaIngreso, Proveedor.VIP, Proveedor.arancelVIP, Proveedor.activo 
                                FROM Proveedor, Usuario WHERE Usuario.nombreUsuario='" + unRUT + "' AND Usuario.idUsuario=Proveedor.idProveedor;";

            SqlConnection cn = Conexion.CrearConexion();
            Proveedor unProveedor = null;
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Proveedor p = CargarDatosDesdeReader(dr);
                    if (p.Activo)
                    {
                        unProveedor = p;
                    }

                }
                dr.Close();
                return unProveedor;
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


        public static bool DesactivarProveedor(string rutProveedor)
        {

            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE Proveedor SET activo=0 WHERE idProveedor=@idProv;";
            cmd.Parameters.AddWithValue("@idProv", rutProveedor);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                int ultimoId = (int)cmd.ExecuteScalar();

                //Debo verificar que al dar de baja un proveedor debo de dar de baja tambien todos los servicios que este ofrece
                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE ProveedorServicios SET activo=0 WHERE idProveedor=@idProv;";
                cmd.Parameters.Add(new SqlParameter("@idProv", rutProveedor));

                //Ejecuto la consulta
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas >= 1)
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }



        }




        public static bool CambiarDatosProveedor(string idProveedor, DateTime fechaIngreso, bool esVIP, double valorArncelVIP)
        {

            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE Proveedor SET fechaIngreso=@fecha, VIP=@vip, arancelVIP=@arancel  WHERE idProveedor=@idProv";
            cmd.Parameters.AddWithValue("@idProv", idProveedor);
            cmd.Parameters.AddWithValue("@fecha", fechaIngreso);
            cmd.Parameters.AddWithValue("@vip", esVIP ? "1" : "0");
            cmd.Parameters.AddWithValue("@arancel", valorArncelVIP);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;

                //Ejecuto la consulta
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }





        #endregion

        #region TOSTRING
        public override string ToString()
        {
            return "Nombre: " + this.NombreApellido + " - Fecha Ingreso: " + FechaRegistro.ToShortDateString() + " - es VIP: " + (this.VIP ? "Sí" : "No");
        }
        public string ToString2() {
            return this.RUT + "#" + this.NombreFantasia + "#" + this.Email + "#" + this.Telefono + "|";
        }

        #endregion


    }
}