using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Dominio;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

    [OperationContract]
    List<Servicio> WCFAllServiciosWhitTipoEvento();

    [OperationContract]
    bool WCFAddProveedor(string nombreCompletoProv, string nombreUsuario, string passw, string nombreFantasia, string email, string telefono, bool esVIP, double valorArancelVIP, List<ProveedorServicio> listaServicios);

    [OperationContract]
    List<Proveedor> WCFShowAllProveedores();

    [OperationContract]
    Proveedor WCFShowProveedorPorRUT(string nombreRUT);

    [OperationContract]
    bool WCFChangeDatosProveedor(string idProveedor, DateTime fechaIngreso, bool esVIP, double valorArncelVIP);

    [OperationContract]
    bool WCFChangeArancelAnualProveedor(int arancel);

    [OperationContract]
    int WCFObtenerArancelAnualProveedor();

    [OperationContract]
    bool WCFDesactivarProveedor(string rutProveedor);

    [OperationContract]
    bool WCFGuardarTxtProveedores();


    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class CompositeType
{
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }
}
