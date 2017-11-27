using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class AltaOrganizadorViewModel
    {
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { set; get; }

        [Display(Name = "Contraseña")]
        public string Password { set; get; }

        [Display(Name = "Nombre y Apellido")]
        public string NombreCompleto { set; get; }

        [Display(Name = "Telefono")]
        public string Telefono { set; get; }
    }
}