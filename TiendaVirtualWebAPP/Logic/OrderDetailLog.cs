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
    public class OrderDetailLog
    {
        OrderDetailDat objDet = new OrderDetailDat();
        public DataSet showOrderDetail()
        {
            return objDet.showOrderDetail();
        }
        public DataSet showOrderDetailDDL()
        {
            return objDet.showOrderDetailDDL();
        }
        public bool saveOrderDetail(int _cantidad, decimal _precio, int _fkproducto, int _fkpedido)
        {
            return objDet.saveOrderDetail(_cantidad, _precio, _fkproducto, _fkpedido);
        }
        public bool updateOrderDetail(int _idOrderDetail, int _cantidad, decimal _precio, int _fkproducto, int _fkpedido)
        {
            return objDet.updateOrderDetail(_idOrderDetail, _cantidad,  _precio,  _fkproducto,  _fkpedido);
        }

        public bool deleteOrderDetail(int _idOrderDetail)
        {
            return objDet.deleteOrderDetail(_idOrderDetail);
        }
    }
}