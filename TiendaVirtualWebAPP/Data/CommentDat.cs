using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class CommentDat
    {
        //CRUD
        Persistence objPer = new Persistence();

        //Metodo para mostrar todos los comentarios
        public DataSet showComment()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proSelectComments";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para insertar una nuevo comentario
        public bool saveComment(string _comentario, string _fecha, int _pro_id, int _cli_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proInsertComments"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_comentario", MySqlDbType.VarString).Value = _comentario;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.VarString).Value = _fecha;
            objSelectCmd.Parameters.Add("v_pro_id", MySqlDbType.Int32).Value = _pro_id;
            objSelectCmd.Parameters.Add("v_cli_id", MySqlDbType.Int32).Value = _cli_id;

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

        //Metodo para actualizar una Comentario
        public bool updateComment(int _idComment, string _comentario, string _fecha, int _pro_id, int _cli_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proUpdateComments"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idComment;
            objSelectCmd.Parameters.Add("v_comentario", MySqlDbType.VarString).Value = _comentario;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.VarString).Value = _fecha;
            objSelectCmd.Parameters.Add("v_pro_id", MySqlDbType.Int32).Value = _pro_id;
            objSelectCmd.Parameters.Add("v_cli_id", MySqlDbType.Int32).Value = _cli_id;


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

        //Metodo para eliminar una Comentario
        public bool deleteComment(int _idComment)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "proDeleteComments"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idComment;

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