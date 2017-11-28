using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class ProveedorServicio
    {
        public int Id { set; get; }
        public string Proveedor { set; get; }
        public string NombreServicio { set; get; }
        public string Imagen { set; get; }
        public string Descripcion { set; get; }
        public bool Activo { set; get; }
        
        public string ToString2() {
            return this.NombreServicio + ":" + this.Descripcion + ":" + this.Imagen + "#";
        }
    }
}
