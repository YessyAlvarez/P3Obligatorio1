using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class EventoProveedor
    {
        public int Id { set; get; }
        public int Puntaje { set; get; }
        public string Comentario { set; get; }
        public int ProveedorRUT { set; get; }
        public List<ProveedorServicio> ListaServicios { set; get; }
        public Organizador Organizador { set; get; }
        public Evento Evento { set; get; }

    }
}
