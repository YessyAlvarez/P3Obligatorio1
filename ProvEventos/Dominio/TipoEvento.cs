using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class TipoEvento
    {
        
        public int Id { set; get; }
        
        [Display(Name = "Nombre del evento")]
        public string Nombre { set; get; }
      //public string Descripcion { set; get; }
        
        #region TOSTRING
        public override string ToString()
        {
            return this.Nombre;
        }
        public string ToString2() {
            return this.Nombre + ":";
        }
        #endregion
    }
}
