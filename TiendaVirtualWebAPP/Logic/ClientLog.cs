using Data;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.Remoting;

namespace Logic
{
    public class ClientLog
    {
        ClientDat objCat = new ClientDat();

        // Método para mostrar todos los clientes
        public DataSet showClients()
        {
            
            return objCat.showClients();
        }

        // Método para mostrar todos los clientes con la direccion
        public DataSet showClientsDDL()
        {
            
            return objCat.showClientsDDL();
        }

        // Método para guardar un nuevo cliente
        public bool saveClient(string _nombre, string _telefono, string _direccion)
        {
            
            return objCat.saveClient(_nombre,_telefono,_direccion);
        }

        // Método para actualizar un cliente
        public bool updateClient(int _clien_id, string _nombre, string _telefono, string _direccion)
        {
            
            return objCat.updateClient(_clien_id,_nombre,_telefono,_direccion);

        }

        // Método para borrar un cliente
        public bool deleteClient(int _clien_id)
        {
            
            return objCat.deleteClient(_clien_id);
        }
    }
}