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
