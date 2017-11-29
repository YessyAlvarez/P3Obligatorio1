using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class ProvEventos
    {
        public static List<Usuario> datosPruebaUsuarios()
        {
            List<Usuario> ret = new List<Usuario>();
            ret.Add(new Usuario { Id = 1, UsuarioLogin = "admin1", Password = "password", NombreApellido = "Heber Gonzalez", TipoPerfil = EnumPerfil.Admin });
            ret.Add(new Usuario { Id = 2, UsuarioLogin = "admin2", Password = "password", NombreApellido = "Pinion Arturo Fijo", TipoPerfil = EnumPerfil.Admin });
            return ret;
        }
        public static List<Organizador> datosPruebaOrganizadores()
        {
            List<Organizador> ret = new List<Organizador>();
            ret.Add(new Organizador { Id = 3, UsuarioLogin = "aalvarez", Password = "password", NombreApellido = "Andres Alvarez", TipoPerfil = EnumPerfil.Organizador, Telefono = "111111" });
            ret.Add(new Organizador { Id = 4, UsuarioLogin = "bbermudez", Password = "password", NombreApellido = "Bruno Bermudez", TipoPerfil = EnumPerfil.Organizador, Telefono = "222222" });
            ret.Add(new Organizador { Id = 5, UsuarioLogin = "ccastanio", Password = "password", NombreApellido = "Carlos Castanio", TipoPerfil = EnumPerfil.Organizador, Telefono = "333333" });
            ret.Add(new Organizador { Id = 6, UsuarioLogin = "ddiaz", Password = "password", NombreApellido = "Diego Diaz", TipoPerfil = EnumPerfil.Organizador, Telefono = "444444" });
            ret.Add(new Organizador { Id = 7, UsuarioLogin = "eestoli", Password = "password", NombreApellido = "Ernesto Estoli", TipoPerfil = EnumPerfil.Organizador, Telefono = "555555" });
            ret.Add(new Organizador { Id = 8, UsuarioLogin = "ffernandez", Password = "password", NombreApellido = "Fernando Fernandez", TipoPerfil = EnumPerfil.Organizador, Telefono = "666666" });
            return ret;
        }
        public static List<Evento> datosPruebaEventos(List<TipoEvento> e, List<Organizador> o)
        {
            List<Evento> ret = new List<Evento>();
            ret.Add(new Evento { Id = 1, TipoEvento = e[0], Fecha = new DateTime(2017, 1, 1), Direccion = "Alemania 1234", Organizador = o[1] });
            ret.Add(new Evento { Id = 2, TipoEvento = e[1], Fecha = new DateTime(2017, 2, 2), Direccion = "Barbados 1234", Organizador = o[1] });
            ret.Add(new Evento { Id = 3, TipoEvento = e[2], Fecha = new DateTime(2017, 3, 3), Direccion = "Costa Rica 1234", Organizador = o[1] });
            ret.Add(new Evento { Id = 4, TipoEvento = e[3], Fecha = new DateTime(2017, 4, 4), Direccion = "Dinamarca 1234", Organizador = o[1] });
            ret.Add(new Evento { Id = 5, TipoEvento = e[4], Fecha = new DateTime(2017, 5, 5), Direccion = "Escocia 1234", Organizador = o[2] });
            ret.Add(new Evento { Id = 6, TipoEvento = e[5], Fecha = new DateTime(2017, 6, 6), Direccion = "Francia 1234", Organizador = o[2] });
            ret.Add(new Evento { Id = 7, TipoEvento = e[6], Fecha = new DateTime(2017, 7, 7), Direccion = "Grecia 1234", Organizador = o[3] });
            ret.Add(new Evento { Id = 8, TipoEvento = e[7], Fecha = new DateTime(2017, 8, 8), Direccion = "Holanda 1234", Organizador = o[3] });
            ret.Add(new Evento { Id = 9, TipoEvento = e[8], Fecha = new DateTime(2017, 9, 9), Direccion = "Inglaterra 1234", Organizador = o[4] });
            ret.Add(new Evento { Id = 10, TipoEvento = e[9], Fecha = new DateTime(2017, 10, 10), Direccion = "Jamaica 1234", Organizador = o[4] });
            ret.Add(new Evento { Id = 11, TipoEvento = e[10], Fecha = new DateTime(2017, 11, 11), Direccion = "Kenia 1234", Organizador = o[5] });
            ret.Add(new Evento { Id = 12, TipoEvento = e[11], Fecha = new DateTime(2017, 12, 12), Direccion = "Lituania 1234", Organizador = o[5] });
            return ret;
        }
        public static List<EventoProveedor> datosPruebaEventosProveedor(List<Proveedor> p, List<Organizador> o)
        {
            List<EventoProveedor> ret = new List<EventoProveedor>();
            ret.Add(new EventoProveedor { Id = 1, Puntaje = 5, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 2, Puntaje = 5, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 3, Puntaje = 3, Comentario = "Aceptable", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 4, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 5, Puntaje = 5, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 6, Puntaje = 5, Comentario = "Muy Buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 7, Puntaje = 4, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 8, Puntaje = 3, Comentario = "Aceptable", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 9, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 10, Puntaje = 1, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 11, Puntaje = 5, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 12, Puntaje = 4, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 13, Puntaje = 3, Comentario = "Aceptable", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 14, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 15, Puntaje = 1, Comentario = "Muy buen Trabajo", ProveedorRUT = Convert.ToInt32(p[0].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 16, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[1].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 17, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[1].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 18, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[1].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 19, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[1].Rut), Organizador = o[0] });
            ret.Add(new EventoProveedor { Id = 20, Puntaje = 2, Comentario = "Malo", ProveedorRUT = Convert.ToInt32(p[1].Rut), Organizador = o[0] });

            return ret;
        }
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
            p.Password = "password";
            p.NombreApellido = p.NombreFantasia;
            p.TipoPerfil = EnumPerfil.Proveedor;
            p.VIP = (prov[4] == "1") ? true : false;
            p.Activo = true;
            p.FechaRegistro = DateTime.Today;
            p.ListaServicios = new List<ProveedorServicio>();
            for (int i = 5; i < prov.Length; i++)
            {
                string[] separadores2 = new string[] { ":" };
                string[] provServ = prov[i].Split(separadores2, StringSplitOptions.RemoveEmptyEntries);
                ProveedorServicio ps = new ProveedorServicio();
                ps.NombreServicio = provServ[0];
                ps.Proveedor = p.Rut;
                ps.Descripcion = provServ[1];
                ps.Imagen = provServ[2];
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
            s.ListaEventos = new List<TipoEvento>();
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

