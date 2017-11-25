
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Servicio
    {
        public string IdNombreServicio { set; get; }
        public List<TipoEvento> ListaEventos { set; get; }

       

        #region TOSTRING
        public override string ToString()
        {
            return this.IdNombreServicio;
        }

        #endregion

        public string ToString2() {
            return this.IdNombreServicio + "#";
        }
    }
}
