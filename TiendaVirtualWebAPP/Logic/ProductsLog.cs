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
    public class ProductsLog
    {
        ProductsDat objProdu = new ProductsDat();
        public DataSet showProducts()
        {
            return objProdu.showProducts();
        }
        public DataSet showProductsDDL()
        {
            return objProdu.showProductsDDL();

        }
        public bool saveProducts(string _nombre, string _descripcion, double _precio, int _stock, string _imagen, int _fkcategoria, int _fkproveedor)
        {
            return objProdu.saveProducts(_nombre, _descripcion, _precio, _stock, _imagen, _fkcategoria, _fkproveedor);
        }
        public bool updateProducts(int _idProducts, string _nombre, string _descripcion, double _precio, int _stock, string _imagen, int _fkcategoria, int _fkproveedor)
        {
            return objProdu.updateProducts( _idProducts,  _nombre,  _descripcion,  _precio,  _stock,  _imagen,  _fkcategoria,  _fkproveedor);
        }
        public bool deleteProducts(int _idProducts)
        {
            return objProdu.deleteProducts(_idProducts);
        }
    }
}