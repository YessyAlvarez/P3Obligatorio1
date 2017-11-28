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
               
                if (db.Servicio.Count() == 0) { 
                    List<Servicio> servicios = ProvEventos.leerTxtEventos(archivoEventos);
                    foreach (Servicio s in servicios)
                    {
                        foreach (TipoEvento t in s.ListaEventos) {
                            var tipoId = from te in db.TipoEventos
                                         where te.Nombre == t.Nombre
                                         select te.Id;
                            if (db.TipoEventos.Count() != 0 && tipoId!=null && db.TipoEventos.Find(Convert.ToInt32(tipoId.FirstOrDefault())) != t) {
                                db.TipoEventos.Add(t);
                            }
                        }
                    }
                    db.Servicio.AddRange(servicios);
                    db.SaveChanges();
                }
            }
            string archivoProveedores = System.Configuration.ConfigurationManager.AppSettings["archivoProveedores"];
            if (System.IO.File.Exists(archivoProveedores)) {
                 if (db.Proveedores.Count() == 0)
                {
                    List<Proveedor> proveedores = ProvEventos.leerTxtProveedores(archivoProveedores);
                    foreach (Proveedor p in proveedores)
                    {
                        foreach (ProveedorServicio ps in p.ListaServicios)
                        {
                            var serv = from s in db.Servicio
                                       where s.NombreServicio == ps.NombreServicio
                                       select s.Id;

                            if (db.Servicio.Count() != 0 && serv!=null && db.Servicio.Find(Convert.ToInt32(serv.FirstOrDefault())).NombreServicio == ps.NombreServicio)
                            //(db.TipoEventos.Count() != 0 && tipoId!=null && db.TipoEventos.Find(Convert.ToInt32(tipoId.FirstOrDefault())) != t)
                            {
                                db.ProveedorServicios.Add(ps);
                            }
                            else {
                                p.ListaServicios.Remove(ps);
                            }
                        }
                    }
                    db.Proveedores.AddRange(proveedores);
                    db.SaveChanges();
                }
            }
             
        }
    }
}
