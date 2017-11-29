using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio;
using MVC.Models.contexto;
using System.IO;

namespace MVC.Controllers
{
    public class ProveedorsController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        // GET: Proveedors
        public ActionResult Index()
        {
            //List<Proveedor>db.Proveedores.ToList();
            return View(db.Proveedores.ToList());
        }

        // GET: Proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioLogin,Password,TipoPerfil,NombreApellido,RUT,NombreFantasia,Email,FechaRegistro,Telefono,VIP,ArancelVIP,Activo")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        // POST: Servicios/CreateFromTxt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromTxt()
        {
            string path = @"C:\Users\Diseño\Desktop\proveedores.txt";
            if (System.IO.File.Exists(path))
            {
                TextReader tr = new StreamReader(path);
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    Proveedor p = new Proveedor();
                    string[] separadores = new string[] { "#", "|" };
                    string[] prov = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                    if (db.Proveedores.Find(prov[0]) == null)
                    {
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
                        for (int i = 4; i < prov.Length; i++)
                        {
                            string[] separadores2 = new string[] { "#", "|" };
                            string[] provServ = prov[i].Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                            if (db.Servicio.Find(prov[0]) != null)
                            {
                                ProveedorServicio ps = new ProveedorServicio();
                                ps.NombreServicio = provServ[0];
                                ps.Proveedor = p.Rut;
                                ps.Imagen = provServ[2];
                                ps.Descripcion = provServ[1];
                                ps.Activo = true;

                                p.ListaServicios.Add(ps);
                                db.ProveedorServicios.Add(ps);
                            }
                        }
                        db.Proveedores.Add(p);
                    }
                }
            }

            return View(db.Servicio.ToList());
        }

        // GET: Proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioLogin,Password,TipoPerfil,NombreApellido,RUT,NombreFantasia,Email,FechaRegistro,Telefono,VIP,ArancelVIP,Activo")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Usuarios.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ListarMasUsado() {
            List<Proveedor> proveedores = db.Proveedores.ToList();
            List<KeyValuePair<int, int>> provUsado = new List<KeyValuePair<int, int>>();
            foreach (Proveedor pr in proveedores)
            {
                int rut = Convert.ToInt32(pr.Rut);
                var listaEventos = from e in db.EventoProveedores
                                   orderby e.ProveedorRUT
                                   where e.ProveedorRUT == rut
                                   select e;
                List<EventoProveedor> eventosProveedor = listaEventos.ToList();
                int uso = eventosProveedor.Count();

                provUsado.Add(new KeyValuePair<int, int>(pr.Id, uso));
            }
            provUsado.Sort((x, y) => x.Value.CompareTo(y.Value));
            List<Proveedor> ordenadoUsado = new List<Proveedor>();
            foreach (KeyValuePair<int, int> kvp in provUsado)
            {
                ordenadoUsado.Add(db.Proveedores.Find(kvp.Key));
            }
            return View(ordenadoUsado);
        }

        public ActionResult ListarMasPuntaje()
        {
            List<Proveedor> proveedores = db.Proveedores.ToList();
            List<KeyValuePair<int, int>> provPuntaje = new List<KeyValuePair<int, int>>();

            foreach (Proveedor pr in proveedores) {
                int rut = Convert.ToInt32(pr.Rut);
                var listaEventos = from e in db.EventoProveedores
                                   orderby e.ProveedorRUT
                                   where e.ProveedorRUT == rut
                                   select e;
                List<EventoProveedor> eventosProveedor = listaEventos.ToList();
                int puntaje = 0;
                foreach (EventoProveedor ep in eventosProveedor) {
                    puntaje += ep.Puntaje;
                }
                puntaje = puntaje / eventosProveedor.Count();
                provPuntaje.Add(new KeyValuePair<int, int>(pr.Id, puntaje));
            }
            provPuntaje.Sort((x,y) => x.Value.CompareTo(y.Value));
            List<Proveedor> ordenadoPuntaje = new List<Proveedor>();
            foreach (KeyValuePair<int, int> kvp in provPuntaje) {
                ordenadoPuntaje.Add(db.Proveedores.Find(kvp.Key));
            }
            return View(ordenadoPuntaje);
        }
    }
}
