﻿using System;
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
    public class OrganizadorController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        

        // GET: Organizador
        public ActionResult Index()
        {
            return View(db.Organizadores.ToList());
            //return View();
        }

        // GET: Organizador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // GET: Organizador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioLogin,Password,TipoPerfil,NombreApellido,Telefono")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(organizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizador);
        }

        // GET: Organizador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // POST: Organizador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioLogin,Password,TipoPerfil,NombreApellido,Telefono")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizador);
        }

        // GET: Organizador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // POST: Organizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizador organizador = db.Organizadores.Find(id);
            db.Usuarios.Remove(organizador);
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
