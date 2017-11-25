using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoEvento
    {
        public string IdNombre { set; get; }
        public string Descripcion { set; get; }
        
        #region TOSTRING
        public override string ToString()
        {
            return this.IdNombre;
        }
        public string ToString2() {
            return this.IdNombre + ":";
        }
        #endregion
    }
}
