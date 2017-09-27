using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ServicioProveedor
    {
        public Servicio Servicio { set; get; }
        public string Imagen { set; get; }
        public string Descripcion { set; get; }
        public bool Activo { set; get; }

    }
}
