using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Dominio;

namespace MVC.Models.contexto
{
    public class MiContextoContext : DbContext
    {
        public DbSet<Organizador> Organizadores { set; get; }
        public DbSet<Evento> Eventos { set; get; }
        public DbSet<EventoProveedor> EventoProveedores { set; get; }
        public DbSet<Proveedor> Proveedores { set; get; }
        public DbSet<ProveedorServicio> ProveedorServicios { set; get; }
        public DbSet<Servicio> Servicio { set; get; }
        public DbSet<TipoEvento> TipoEventos { set; get; }
        public DbSet<Usuario> Usuarios { set; get; }

        public MiContextoContext() : base("conexionProvEvento") {}
    }
}