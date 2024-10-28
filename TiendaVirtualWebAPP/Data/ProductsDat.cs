using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class ProductsDat
    {

        Persistence objPer = new Persistence();

        // Método para mostrar todos los productos
        public DataSet showProducts()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectProducto"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public DataSet showProductsDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectProductoDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo producto
        public bool saveProducts(string _nombre, string _descripcion, double _precio, int _stock, string _imagen, int _fkcategoria, int _fkproveedor)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertProducto"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("v_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("v_precio", MySqlDbType.Double).Value = _precio;
            objSelectCmd.Parameters.Add("v_stock", MySqlDbType.Int32).Value = _stock;
            objSelectCmd.Parameters.Add("v_imagen", MySqlDbType.VarString).Value = _imagen;
            objSelectCmd.Parameters.Add("v_categoria_id", MySqlDbType.Int32).Value = _fkcategoria;
            objSelectCmd.Parameters.Add("v_proveedor_id", MySqlDbType.Int32).Value = _fkproveedor;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar un producto
        public bool updateProducts(int _idProducts, string _nombre, string _descripcion, double _precio, int _stock, string _imagen, int _fkcategoria, int _fkproveedor)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateProducto"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idProducts;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("v_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("v_precio", MySqlDbType.Double).Value = _precio;
            objSelectCmd.Parameters.Add("v_stock", MySqlDbType.Int32).Value = _stock;
            objSelectCmd.Parameters.Add("v_imagen", MySqlDbType.VarString).Value = _imagen;
            objSelectCmd.Parameters.Add("v_categoria_id", MySqlDbType.Int32).Value = _fkcategoria;
            objSelectCmd.Parameters.Add("v_proveedor_id", MySqlDbType.Int32).Value = _fkproveedor;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para eliminar un producto
        public bool deleteProducts(int _idProducts)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteProducto"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idProducts;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}