using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class OrderLog
    {
        OrderDat objCat = new OrderDat();
        // Método para mostrar todos los pedidos
        public DataSet showPedidos()
        {
            
            return objCat.showPedidos();
        }

        // Método DDL
        public DataSet showPedidosDLL()
        {
            
            return objCat.showPedidosDLL();
        }
        // Método para guardar un nuevo pedido
        public bool savePedido(string _fecha, string _estado, int _total, int _fkclient)
        {
            
            return objCat.savePedido(_fecha,_estado,_total,_fkclient);
        }

        // Método para actualizar un pedido
        public bool updatePedido(int _idPedido, string _fecha, string _estado, int _total, int _idCliente)
        {
            
            return objCat.updatePedido(_idPedido,_fecha,_estado,_total,_idCliente);

        }

        // Método para borrar un pedido
        public bool deletePedido(int _idPedido)
        {
            
            return objCat.deletePedido(_idPedido);
        }
    }
}