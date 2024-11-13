using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class ProvidersLog
    {
        ProvidersDat objProv = new ProvidersDat();

        public DataSet showProviders()
        {
            return objProv.showProviders();
        }

        public DataSet showProvidersDDL()
        {
            return objProv.showProvidersDDL();
        }

        public bool saveProviders(string _nit, string _nombre, string _contacto)
        {
            return objProv.saveProviders(_nit, _nombre, _contacto);
        }

        public bool updateProviders(int _idProviders, string _nit, string _nombre, string _contacto)
        {
            return objProv.updateProviders(_idProviders, _nit, _nombre, _contacto);
        }

        public bool deleteProviders(int _idProviders)
        {
            return objProv.deleteProviders(_idProviders);
        }
    }
}