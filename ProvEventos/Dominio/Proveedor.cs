using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Proveedor : Usuario
    {
        public static double ArancelAnual { set; get; }
        public string Rut { set; get; }
        public string NombreFantasia { set; get; }
        public string Email { set; get; }
        public DateTime FechaRegistro { set; get; }
        public string Telefono { set; get; }
        public bool VIP { set; get; }
        public double ArancelVIP { set; get; }
        public bool Activo { set; get; }
        public List<ProveedorServicio> ListaServicios { set; get; }
       
        
        public override string ToString()
        {
            return "Nombre: " + this.NombreApellido + " - Fecha Ingreso: " + FechaRegistro.ToShortDateString() + " - es VIP: " + (this.VIP ? "Sí" : "No");
        }
        public string ToString2()
        {
            return this.Rut + "#" + this.NombreFantasia + "#" + this.Email + "#" + this.Telefono + "|";
        }
    }
}