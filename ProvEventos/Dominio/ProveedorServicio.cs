using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Dominio
{
    public class ProveedorServicio
    {
        public string IdProveedor { set; get; }
        public string IdNombreServicio { set; get; }
        public string Imagen { set; get; }
        public string Descripcion { set; get; }
        public bool Activo { set; get; }
        
        public string ToString2() {
            return this.IdNombreServicio + ":" + this.Descripcion + ":" + this.Imagen + "#";
        }
    }
}
