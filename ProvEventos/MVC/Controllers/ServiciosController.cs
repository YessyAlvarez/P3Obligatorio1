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
    public class ServiciosController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        // GET: Servicios
        public ActionResult Index()
        {
            return View(db.Servicio.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdServicio,NombreServicio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult CreateFromTxt()
        {
            return View();
        }

        // POST: Servicios/CreateFromTxt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromTxt(bool bandera)
        {
                string path = @"C:\Users\Diseño\Desktop\servicios.txt";
                if (System.IO.File.Exists(path))
                {
                    TextReader tr = new StreamReader(path);
                    string linea;
                    while ((linea = tr.ReadLine()) != null)
                    {
                        Servicio s = new Servicio();
                        string[] separadores = new string[] { "#", ":" };
                        string[] serv = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                        s.IdNombreServicio = serv[0];
                        for (int i = 1; i < serv.Length; i++)
                        {
                            TipoEvento e = db.TipoEventos.Find(serv[i]);
                            if (e != null) {
                                s.ListaEventos.Add(e);
                            }
                        }
                        db.Servicio.Add(s);
                    }
                }
            
            return View(db.Servicio.ToList());
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdServicio,NombreServicio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = db.Servicio.Find(id);
            db.Servicio.Remove(servicio);
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
    }
}
