using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Evento
    {
        public int Id { set; get; }
        public TipoEvento TipoEvento { set; get; }
        public List<EventoProveedor> ListaServiciosProveedor { set; get; }
        public DateTime Fecha { set; get; }
        public string Direccion { set; get; }
        public Organizador Organizador { set; get; }
       
        
        public override string ToString()
        {
            return "TipoEvento: " + this.TipoEvento.Nombre + " - Fecha: " + Fecha.ToShortDateString() + " - Organizador: " + Organizador.NombreApellido;
        }
    





    }
}
