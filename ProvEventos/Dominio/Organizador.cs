using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Organizador : Usuario
    {
        public string Telefono { set; get; }
        public List<Evento> EventosOrganizados { set; get; }



    }
}
