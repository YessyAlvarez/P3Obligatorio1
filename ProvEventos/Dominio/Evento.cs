using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Evento
    {
        #region ATRIBUTOS
        public TipoEvento TipoEvento { set; get; }
        public List<EventoProveedor> ListaServiciosProveedor { set; get; }
        public DateTime Fecha { set; get; }
        public string Direccion { set; get; }
        public Organizador Organizador { set; get; }
        #endregion


        #region CONSUTRCUTOR

        #endregion


        #region MÉTODOS

        #endregion

        #region TOSTRING()

        public override string ToString()
        {
            return "TipoEvento: " + this.TipoEvento.Nombre + " - Fecha: " + Fecha.ToShortDateString() + " - Organizador: " + Organizador.NombreApellido;
        }
        #endregion





    }
}
