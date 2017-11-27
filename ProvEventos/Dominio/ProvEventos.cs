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
        public static ICollection<Proveedor> leerTxtProveedores(string path)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            if (File.Exists(path))
            {
                TextReader tr = new StreamReader(path);
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    proveedores.Add(cargarProveedor(linea));
                }
            }
            return proveedores;
        }

        public static Proveedor cargarProveedor(string linea)
        {
            Proveedor p = new Proveedor();
            string[] separadores = new string[] { "#", "|" };
            string[] prov = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            p.Rut = prov[0];
            p.NombreFantasia = prov[1];
            p.Email = prov[2];
            p.Telefono = prov[3];
            p.UsuarioLogin = p.Rut;
            p.NombreApellido = p.NombreFantasia;
            p.TipoPerfil = EnumPerfil.Proveedor;
            p.VIP = false;
            p.Activo = true;
            p.FechaRegistro = DateTime.Today;
            p.ListaServicios = new List<ProveedorServicio>();
            for (int i = 4; i < prov.Length; i++)
            {
                string[] separadores2 = new string[] { ":" };
                string[] provServ = prov[i].Split(separadores2, StringSplitOptions.RemoveEmptyEntries);
                ProveedorServicio ps = new ProveedorServicio();
                ps.NombreServicio = provServ[0];
                ps.Proveedor = p.Rut;
                ps.Imagen = provServ[2];
                ps.Descripcion = provServ[1];
                ps.Activo = true;
                p.ListaServicios.Add(ps);
            }

            return p;
        }
    }
}

