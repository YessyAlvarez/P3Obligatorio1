using Dominio;
using MVC.Models.contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            MiContextoContext db = new MiContextoContext();
            string archivoEventos = System.Configuration.ConfigurationManager.AppSettings["archivoEventos"];
            if (System.IO.File.Exists(archivoEventos)) {
                Servicio primero = ProvEventos.primeraLineaTxtEventos(archivoEventos);
                if (db.Servicio.Find(primero.Id) != primero) { // cambiar el find para busqueda linq por nombre 
                    List<Servicio> servicios = ProvEventos.leerTxtEventos(archivoEventos);
                    foreach (Servicio s in servicios)
                    {
                        foreach (TipoEvento t in s.ListaEventos) {
                            if (db.TipoEventos.Find(t.Id) != t) { //cambiar el find para busqueda linq por nombre
                                db.TipoEventos.Add(t);
                            }
                        }
                    }
                    db.Servicio.AddRange(servicios);
                }
            }
            string archivoProveedores = System.Configuration.ConfigurationManager.AppSettings["archivoProveedores"];
            if (System.IO.File.Exists(archivoProveedores)) {
                Proveedor primero  = ProvEventos.primeraLineaTxtProveedores(archivoProveedores);
                if (db.Proveedores.Count() != 0) // cambiar el find para busqueda linq por nombre
                {
                    List<Proveedor> proveedores = ProvEventos.leerTxtProveedores(archivoProveedores);
                    foreach (Proveedor p in proveedores)
                    {
                        foreach (ProveedorServicio ps in p.ListaServicios)
                        {
                            if (db.Servicio.Find(ps.NombreServicio).NombreServicio == ps.NombreServicio)
                            { //cambiar el find para busqueda linq por nombre
                                db.ProveedorServicios.Add(ps);
                            }
                            else {
                                p.ListaServicios.Remove(ps);
                            }
                        }
                    }
                    db.Proveedores.AddRange(proveedores);
                }
            }
             
        }
    }
}
