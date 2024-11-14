using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class OrderDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los pedidos
        public DataSet showPedidos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proSelectOrder";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método DDL
        public DataSet showPedidosDLL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPedidosDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        // Método para guardar un nuevo pedido
        public bool savePedido(string _fecha, string _estado, int _total, int _fkclient)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proInsertOrder"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_ped_fecha", MySqlDbType.VarString).Value = _fecha;
            objSelectCmd.Parameters.Add("v_ped_estado", MySqlDbType.VarString).Value = _estado;
            objSelectCmd.Parameters.Add("v_ped_total", MySqlDbType.Int32).Value = _total;
            objSelectCmd.Parameters.Add("v_tbl_clientes_cli_id", MySqlDbType.Int32).Value = _fkclient;

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

        // Método para actualizar un pedido
        public bool updatePedido(int _idPedido, string _fecha, string _estado, int _total, int _idCliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proUpdateOrder"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_ped_id", MySqlDbType.Int32).Value = _idPedido;
            objSelectCmd.Parameters.Add("v_ped_fecha", MySqlDbType.VarString).Value = _fecha;
            objSelectCmd.Parameters.Add("v_ped_estado", MySqlDbType.VarString).Value = _estado;
            objSelectCmd.Parameters.Add("v_ped_total", MySqlDbType.Int32).Value = _total;
            objSelectCmd.Parameters.Add("v_tbl_clientes_cli_id", MySqlDbType.Int32).Value = _idCliente;

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

        // Método para borrar un pedido
        public bool deletePedido(int _idPedido)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proDeleteOrder"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_ped_id", MySqlDbType.Int32).Value = _idPedido;

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