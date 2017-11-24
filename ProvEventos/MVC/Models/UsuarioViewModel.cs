using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "El usuario es un campo requerido.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El usuario es un campo requerido.")]
        public string Password { get; set; }
    }
}