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
        public int Id { set; get; }
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

        #region cambiar arancel anual
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

        #endregion

        #region obtener arancel
        public static int ObtenerArancel()
        {
            int arancel = 0;
            string consulta = @"SELECT arancel FROM ArancelAnualProveedor WHERE id=1;";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    arancel = Convert.ToInt32(dr["arancel"]);
                }
                dr.Close();
                return arancel;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return arancel;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
        #endregion

        #region agregar proveedor
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
                for (int i = 0; i < this.ListaServicios.Count; i++)
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

        #endregion

        #region Obtener todos los proveedores activos
        public static List<Proveedor> ObtenerAllProveedores()
        {

            string consulta = @"SELECT * FROM Proveedor p, Usuario u WHERE p.idProveedor = u.nombreUsuario";

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
                    p.ListaServicios = ProveedorServicio.traerServiciosProveedor(p.RUT);
                    lista.Add(p);
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
        #endregion

        #region cargar datos Proveedor desde la base
        protected static Proveedor CargarDatosDesdeReader(IDataRecord fila)
        {
            Proveedor proveedor = null;
            if (fila != null)
            {
                proveedor = new Proveedor
                {
                    RUT = fila["idProveedor"].ToString(),
                    Email = fila["email"].ToString(),
                    FechaRegistro = Convert.ToDateTime(fila["fechaIngreso"]),
                    Telefono = fila["telefono"].ToString(),
                    VIP = fila["VIP"].Equals("1") ? true : false,
                    ArancelVIP = Convert.ToDouble(fila["arancelVIP"]),
                    Activo = fila["activo"].Equals("1") ? true : false,
                    NombreApellido = fila["nombreUsuario"].ToString(),
                    Password = fila["password"].ToString(),
                    NombreFantasia = fila["nombreFantasia"].ToString(),
                    TipoPerfil = EnumPerfil.Proveedor,
                };
            }
            return proveedor;
        }

        #endregion
        
        #region Obtener proveedor por su RUT
        public static Proveedor ObtenerProveedorPorRUT(string unRUT)
        {
            string consulta = @"SELECT * FROM Proveedor p, Usuario u WHERE u.nombreUsuario='" + unRUT + "' AND u.nombreUsuario=p.idProveedor;";

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
                    p.ListaServicios = ProveedorServicio.traerServiciosProveedor(p.RUT);
                    unProveedor = p;
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
        #endregion
        
        #region desactivar proveedor
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
                cmd.ExecuteNonQuery();

                //Debo verificar que al dar de baja un proveedor debo de dar de baja tambien todos los servicios que este ofrece
                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE Proveedor_Servicios SET activo=0 WHERE idProveedor=@idProv;";
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
        #endregion
        
        #region modificar datos proveedor
        public static bool CambiarDatosProveedor(string idProveedor, string nombreCompleto, string nombreFantasia, string email, string telefono, bool esVIP, double arancelVIP)
        {

            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"UPDATE Usuario SET nombreCompleto=@nombreCompleto  WHERE nombreUsuario=@idProv";
            cmd.Parameters.AddWithValue("@idProv", idProveedor);
            cmd.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                //Modifico la tabla proveedor con los cambios
                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE Proveedor SET nombreFantasia=@fantasia, email=@email, telefono=@telefono, VIP=@VIP, arancelVIP=@arancel WHERE idProveedor=@idProv;";
                cmd.Parameters.Add(new SqlParameter("@idProv", idProveedor));
                cmd.Parameters.Add(new SqlParameter("@fantasia", nombreFantasia));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                cmd.Parameters.Add(new SqlParameter("@VIP", esVIP));
                cmd.Parameters.Add(new SqlParameter("@arancel", arancelVIP));

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
        public string ToString2()
        {
            return this.RUT + "#" + this.NombreFantasia + "#" + this.Email + "#" + this.Telefono + "|";
        }
        #endregion
        
    }
}