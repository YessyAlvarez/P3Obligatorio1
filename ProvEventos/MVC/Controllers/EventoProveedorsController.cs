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

namespace MVC.Controllers
{
    public class EventoProveedorsController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        // GET: EventoProveedors
        public ActionResult Index()
        {
            return View(db.EventoProveedores.ToList());
        }

        // GET: EventoProveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoProveedor eventoProveedor = db.EventoProveedores.Find(id);
            if (eventoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(eventoProveedor);
        }

        // GET: EventoProveedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventoProveedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Puntaje,Comentario,ProveedorRUT")] EventoProveedor eventoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.EventoProveedores.Add(eventoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventoProveedor);
        }

        // GET: EventoProveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoProveedor eventoProveedor = db.EventoProveedores.Find(id);
            if (eventoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(eventoProveedor);
        }

        // POST: EventoProveedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Puntaje,Comentario,ProveedorRUT")] EventoProveedor eventoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventoProveedor);
        }

        // GET: EventoProveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoProveedor eventoProveedor = db.EventoProveedores.Find(id);
            if (eventoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(eventoProveedor);
        }

        // POST: EventoProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventoProveedor eventoProveedor = db.EventoProveedores.Find(id);
            db.EventoProveedores.Remove(eventoProveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CalificarProveedores(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var eventos = from e in db.EventoProveedores
                          where e.Evento.Id == id
                          select e;


            List<EventoProveedor> lista = eventos.ToList();
            return View(lista);
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
