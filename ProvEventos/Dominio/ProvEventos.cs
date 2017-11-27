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
        public static ICollection<Proveedor> leerTxtProveedores(string path) {
            List<Proveedor> proveedores = new List<Proveedor>();
            if (File.Exists(path))
            {
                TextReader tr = new StreamReader(path);
                string linea;
                while ((linea = tr.ReadLine()) != null) {
                    proveedores.Add(cargarProveedor(linea));
                }
            }
            return proveedores;
        }

        public static Proveedor cargarProveedor(string linea)
        {
            return null;
        }
    }
}
