using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class CartDat
    {
        //CRUD
        Persistence objPer = new Persistence();

        //Metodo para mostrar Carrito de compras
        public DataSet showCart()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proSelectCart";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para insertar un carrito de compras
        public bool saveCart(int _cantidad, int _pro_Id, int _cli_Id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proInsertCart"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("v_pro_id", MySqlDbType.Int32).Value = _pro_Id;
            objSelectCmd.Parameters.Add("v_cli_id", MySqlDbType.Int32).Value = _cli_Id;

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

        //Metodo para actualizar el carrito de compras
        public bool updateCart(int _idCart, int _cantidad, int _pro_Id, int _cli_Id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proUpdateCart"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idCart;
            objSelectCmd.Parameters.Add("v_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("v_pro_id", MySqlDbType.Int32).Value = _pro_Id;
            objSelectCmd.Parameters.Add("v_cli_id", MySqlDbType.Int32).Value = _cli_Id;
  

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

        //Metodo para eliminar un carrito de compras
        public bool deleteCatrt(int _idCart)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proDeleteCart"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idCart;

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