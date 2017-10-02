using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProveedorServicio
    {
        public string IdProveedor { set; get; }
        public int IdServicio { set; get; }
        public string Imagen { set; get; }
        public string Descripcion { set; get; }
        public bool Activo { set; get; }

    }
}
