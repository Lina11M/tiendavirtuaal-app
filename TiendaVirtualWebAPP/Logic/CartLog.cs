using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using Data;

namespace Logic
{
    public class CartLog
    {
        CartDat objCart = new CartDat();


        public DataSet showCart()
        {
            return objCart.showCart();
        }


        public bool saveCart(int _cantidad, int _pro_Id, int _cli_Id)
        {
            return objCart.saveCart(_cantidad, _pro_Id, _cli_Id);

        }


        public bool updateCart(int _idCart, int _cantidad, int _pro_Id, int _cli_Id)
        {
            return objCart.updateCart(_idCart, _cantidad, _pro_Id, _cli_Id);
        }


        public bool deleteCatrt(int _idCart)
        {
            return objCart.deleteCatrt(_idCart);

        }
    }
}