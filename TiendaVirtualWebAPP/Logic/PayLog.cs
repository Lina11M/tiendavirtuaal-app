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
    public class PayLog
    {
        PayDat objCat = new PayDat();

        // Método para mostrar todos los pagos
        public DataSet showPagos()
        {
            
            return objCat.showPagos();
        }

        // Método DLL
        public DataSet showPagosDDL()
        {
            
            return objCat.showPagosDDL();
        }

        // Método para guardar un nuevo pago
        public bool savePago(double _monto, string _fecha, string _metodoPago, int _fkpedidos)
        {
            
            return objCat.savePago(_monto, _fecha,_metodoPago,_fkpedidos);
        }

        // Método para actualizar un pago
        public bool updatePago(int _idPago, double _monto, string _fecha, string _metodoPago, int _fkpedidos)
        {
            return objCat.updatePago(_idPago,_monto,_fecha,_metodoPago,_fkpedidos);

        }

        // Método para borrar un pago
        public bool deletePago(int _idPago)
        {
            
            return objCat.deletePago(_idPago);
        }
    }
}
