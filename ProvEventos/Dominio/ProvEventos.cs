using System;
using System.Collections.Generic;
using System.IO;
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

        public static void generarTxtProveedores() {
            //Cargar la lista de Proveedores
            List<Proveedor> proveedores = Proveedor.ObtenerAllProveedores();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\Diseño\Desktop\proveedores.txt";
            if (File.Exists(path)) {
                File.Delete(path);
            }
            File.Create(path).Close();

            //Cargar Servicios al proveedor
            foreach (Proveedor p in proveedores) {
                p.ListaServicios = ProveedorServicio.traerServiciosProveedor(p.RUT);
            }
            //Crear string
            
            TextWriter tw = new StreamWriter(path);
            foreach (Proveedor p in proveedores) {
                string textoArchivo = null;
                textoArchivo += p.ToString2();

                foreach (ProveedorServicio s in p.ListaServicios) {
                    textoArchivo += s.ToString2();
                }
                tw.WriteLine(textoArchivo);
            }
            tw.Close();
        }
        public static void generarTxtServicios() {
            List<Servicio> servicios = Servicio.ObtenerServiciosConTipoEvento();
            //Crear o reemplazar el archivo
            string path = @"C:\Users\Diseño\Desktop\servicios.txt";
            if (File.Exists(path)) 
            {
                File.Delete(path);
            }
            File.Create(path).Close();
            TextWriter tw = new StreamWriter(path);
            foreach (Servicio s in servicios) {
                string textoArchivo = null;
                textoArchivo += s.ToString2();
                foreach (TipoEvento e in s.ListaEventos) {
                    textoArchivo += e.ToString2();
                }
                tw.WriteLine(textoArchivo);
            }
            tw.Close();
        }
        public static void leerTxtProveedores() {
            List<Proveedor> proveedores = new List<Proveedor>();
            string path = @"C:\Users\Diseño\Desktop\proveedores.txt";
            if (File.Exists(path))
            {
                TextReader tr = new StreamReader(path);
                string linea;
                while ((linea = tr.ReadLine()) != null) {
                    Proveedor p = new Proveedor();
                }
            }
        }
    }
}
