using System;
using Dominio;
using System.Collections.Generic;
using System.IO;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public bool WCFAddProveedor(string nombreCompletoProv, string nombreUsuario, string passw, string nombreFantasia, string email, string telefono, bool esVIP, double valorArancelVIP, List<ProveedorServicio> listadoServicios)
    {
        Proveedor p = new Proveedor
        {
            NombreApellido = nombreCompletoProv,
            RUT = nombreUsuario,
            UsuarioLogin = nombreUsuario,
            Password = passw,
            NombreFantasia = nombreFantasia,
            Email = email, 
            Telefono = telefono,
            TipoPerfil = EnumPerfil.Proveedor,
            FechaRegistro = DateTime.Now,
            VIP = esVIP,
            ArancelVIP = valorArancelVIP,
            ListaServicios = listadoServicios
        };

        return p.InsertarProveedor();
    }

    public bool WCFChangeArancelAnualProveedor(int arancel)
    {
        return Proveedor.ChangeArancel(arancel);
    }

    public int WCFObtenerArancelAnualProveedor()
    {
        return Proveedor.ObtenerArancel();
    }

    public List<Servicio> WCFAllServiciosWhitTipoEvento()
    {
        List<Servicio> all = Servicio.ObtenerServiciosConTipoEvento();
        return all;
    }


    public List<Proveedor> WCFShowAllProveedores()
    {
        List<Proveedor> all = Proveedor.ObtenerAllProveedores();
        return all;
    }

    public Proveedor WCFShowProveedorPorRUT(string nombreRUT)
    {
        Proveedor proveedor = Proveedor.ObtenerProveedorPorRUT(nombreRUT);
        return proveedor;
    }

    public bool WCFChangeDatosProveedor(string idProveedor, DateTime fechaIngreso, bool esVIP, double valorArncelVIP)
    {
        /**
         * 1º - Mando a guardar los datos modificados (todos con/sin modificar) a la base
         * retorno true o false dependiendo el éxito de la operación
         * **/
        return Proveedor.CambiarDatosProveedor(idProveedor, fechaIngreso, esVIP, valorArncelVIP);
    }
    
    public bool WCFDesactivarProveedor(string rutProveedor)
    {
        return Proveedor.DesactivarProveedor(rutProveedor);
    }

    public bool WCFGuardarTxtProveedores() {
        bool ret = false;
        ProvEventos.generarTxtProveedores();
        if (File.Exists(@"C:\Users\IEUser\Desktop\proveedores.txt"))
        {
            ret = true;
        }
        return ret;
    }
    public bool WCFGuardarTxtServicios() {
        bool ret = false;
        ProvEventos.generarTxtProveedores();
        if (File.Exists(@"C:\Users\IEUser\Desktop\servicios.txt"))
        {
            ret = true;
        }
        return ret;
    }
}
