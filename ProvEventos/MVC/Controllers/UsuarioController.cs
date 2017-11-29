using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.contexto;
using Dominio;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        [HttpGet]
        public ActionResult Login()
        {
            UsuarioViewModel uvm = new UsuarioViewModel();
            return View(uvm);
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usuario)
        {
            Usuario u = db.Usuarios.Find(usuario.Usuario);
            if (u != null && u.Password == usuario.Password) {
                Session["idUsuario"] = u.Id;
                Session["nombreUsuario"] = u.NombreApellido;
                Session["perfilUsuario"] = u.TipoPerfil;
                //redirigir
            } else {
                //Devolver mensaje: Usuario o contraseña incorrecta
            }
            return View(usuario);
        }

    }
}