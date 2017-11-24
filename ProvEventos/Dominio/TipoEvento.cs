using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoEvento
    {

        public static int Numero = 100;
        //public int Id { set; get; }
        public string IdNombre { set; get; }
        public string Descripcion { set; get; }
        
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
