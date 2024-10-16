using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class ClienteDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los clientes
        public DataSet showClients()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proSelectClients";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo cliente
        public bool saveClient(string _nombre, string _telefono, string _direccion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proInsertClient"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarString).Value = _telefono;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarString).Value = _direccion;

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

        // Método para actualizar un cliente
        public bool updateClient(int _clien_id, string _nombre, string _telefono, string _direccion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proUpdateClient"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_clien_id", MySqlDbType.Int32).Value = _clien_id;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarString).Value = _telefono;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarString).Value = _direccion;

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

        // Método para borrar un cliente
        public bool deleteClient(int _clien_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proDeleteClient"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_clien_id", MySqlDbType.Int32).Value = _clien_id;

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