using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class PayDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los pagos
        public DataSet showPagos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proSelectPay";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método DLL
        public DataSet showPagosDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPayDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo pago
        public bool savePago(double _monto, string _fecha, string _metodoPago, int _fkpedidos)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proInsertPay"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_pag_monto", MySqlDbType.Double).Value = _monto;
            objSelectCmd.Parameters.Add("v_pag_fecha", MySqlDbType.Text).Value = _fecha;
            objSelectCmd.Parameters.Add("v_pag_met_pago", MySqlDbType.VarString).Value = _metodoPago;
            objSelectCmd.Parameters.Add("v_tbl_pedidos_ped_id", MySqlDbType.Int32).Value = _fkpedidos;

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

        // Método para actualizar un pago
        public bool updatePago(int _idPago, double _monto, string _fecha, string _metodoPago, int _fkpedidos)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proUpdatePay"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_pag_id", MySqlDbType.Int32).Value = _idPago;
            objSelectCmd.Parameters.Add("v_pag_monto", MySqlDbType.Double).Value = _monto;
            objSelectCmd.Parameters.Add("v_pag_fecha", MySqlDbType.Text).Value = _fecha;
            objSelectCmd.Parameters.Add("v_pag_met_pago", MySqlDbType.VarString).Value = _metodoPago;
            objSelectCmd.Parameters.Add("v_tbl_pedidos_ped_id", MySqlDbType.Int32).Value = _fkpedidos;

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

        // Método para borrar un pago
        public bool deletePago(int _idPago)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proDeletePay"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_pag_id", MySqlDbType.Int32).Value = _idPago;

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