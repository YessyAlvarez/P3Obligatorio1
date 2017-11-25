using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Dominio
{
    public class Usuario
    {
        public int Id { set; get; }
        public string UsuarioLogin { set; get; }
        public string Password { set; get; }
        public EnumPerfil TipoPerfil { set; get; }
        public string NombreApellido { set; get; }

        
    }
}
