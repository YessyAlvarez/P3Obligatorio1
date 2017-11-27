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

            string archivoProveedores = System.Configuration.ConfigurationManager.AppSettings["archivoProveedores"];
            ICollection<Proveedor> proveedores = ProvEventos.leerTxtProveedores(archivoProveedores);

            //db.ProveedorServicios.AddRange();
            db.Proveedores.AddRange(proveedores);

            db.SaveChanges();


            //Session["nombreUsuario"] = null;
            //Session["perfilUsuario"] = null;
        }
    }
}
