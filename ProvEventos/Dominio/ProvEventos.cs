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
        public static List<Proveedor> leerTxtProveedores(string path)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            TextReader tr = new StreamReader(path);
            string linea;
            while ((linea = tr.ReadLine()) != null)
            {
                proveedores.Add(cargarProveedor(linea));
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

        public static Proveedor primeraLineaTxtProveedores(string archivoProveedores)
        {
            TextReader tr = new StreamReader(archivoProveedores);
            return cargarProveedor(tr.ReadLine());
        }

        public static Servicio primeraLineaTxtEventos(string archivoEventos)
        {
            TextReader tr = new StreamReader(archivoEventos);
            return cargarServicio(tr.ReadLine());
        }

        public static List<Servicio> leerTxtEventos(string path)
        {
            List<Servicio> servicios = new List<Servicio>();
            TextReader tr = new StreamReader(path);
            string linea;
            while ((linea = tr.ReadLine()) != null)
            {
                servicios.Add(cargarServicio(linea));
            }
            return servicios;
        }
        public static Servicio cargarServicio(string linea) {
            Servicio s = new Servicio();
            string[] separadores = new string[] { "#", ":" };
            string[] serv = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            s.NombreServicio = serv[0];
            for (int i = 1; i < serv.Length; i++)
            {
                TipoEvento e = new TipoEvento();
                e.Nombre = serv[i];
                s.ListaEventos.Add(e);
            }
            return s;
        }
    }
}

