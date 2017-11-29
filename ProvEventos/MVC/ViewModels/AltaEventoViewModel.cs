﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels
{
    public class AltaEventoViewModel
    {

        [Display(Name = "Nombre del Organizador")]
        public string NombreOrganizador { set; get; }

        [Display(Name = "Fecha")]
        public DateTime FechaEvento { set; get; }

        [Display(Name = "Direccion")]
        public string Direccion { set; get; }

        [Display(Name = "Tipo de Evento")]
        public IEnumerable<SelectListItem> TipoEvento { set; get; }

        [Display(Name = "Tipo de Evento Seleccionado")]
        public String TipoEventoSeleccionado { set; get; }
        public Evento AltaEvento { set; get; }

        // proba de cambiar esto a un array de string
        //Para por?
        public AltaEventoViewModel(Evento evento, IEnumerable<SelectListItem> tiposDeEvento) {
            this.AltaEvento = evento;
            this.TipoEvento = new SelectList(tiposDeEvento, "nombre", "nombre");
        }

        public AltaEventoViewModel() { }
    }
}