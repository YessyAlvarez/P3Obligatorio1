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
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class EventosController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        // GET: Eventos
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Evento nuevo = new Evento();
            //IEnumerable<SelectListItem> tiposDeEventos = db.TipoEventos.ToList();

            AltaEventoViewModel avm = new AltaEventoViewModel();
            avm.TipoEvento = new SelectList(db.TipoEventos.Select(e => e.Nombre).Distinct());
                      
            return View(avm);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaEventoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Organizador = (Organizador)Session["Usuario"];
                /*
                vm.AltaEvento.TipoEvento = db.TipoEventos.Find(vm.TipoEventoSeleccionado);

                db.Eventos.Add(vm.AltaEvento);
                db.SaveChanges();

                */
                
                vm.TipoEventoSeleccionado = "Casamiento";

                return RedirectToAction("Create2", "Eventos", vm);
                
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Create2(AltaEventoViewModel vm)
        {

            ViewBag.OrganizadorId = new SelectList(db.Organizadores, "Id", "NombreApellido");

            return View(vm);
        }


        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Direccion")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
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
