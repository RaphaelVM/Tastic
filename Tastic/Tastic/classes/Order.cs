using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;
using Tastic.classes;

namespace Tastic.classes
{
    public class Order
    {
        private OrderSQL orderSQL = new OrderSQL();
        private WalletSQL walletSQL = new WalletSQL();

        public int oID;
        public int uID;
        public List<OrderLines> OrderLines;
        public DateTime DateAdded;

        public Order() { }

        public Order(int oid, int uid, DateTime dateadded)
        {
            oID = oid;
            uID = uid;
            DateAdded = dateadded;
        }

        public Order(int oid, int uid, List<OrderLines> orderlines, DateTime dateadded)
        {
            oID = oid;
            uID = uid;
            OrderLines = orderlines;
            DateAdded = dateadded;
        }

        public bool createOrder(bool useWallet, float retractAmount)
        {
            // If the option has been selected to use wallet credit take it out of the wallet too.
            if (useWallet)
            {
                walletSQL.retractFromWallet(Convert.ToInt32(Properties.Settings.Default.user_id), retractAmount);
            }

            return orderSQL.createOrder(Convert.ToInt32(Properties.Settings.Default.user_id), ShoppingCart.items);
        }
    }
}