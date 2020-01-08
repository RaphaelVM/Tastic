using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;
using Tastic.common;

namespace Tastic.sql
{
    public class OrderSQL
    {
        private Order newOrder(MySqlDataReader r)
        {
            return new Order(Convert.ToInt32(r["oID"]), Convert.ToInt32(r["uID"]), Convert.ToDateTime(r["dateAdded"]));
        }

        public bool createOrder(int uID, List<ShoppingCartItem> cartItems)
        {
            Int32 oID = 0;
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "INSERT INTO orders (uID) VALUES (@uid);" +
                                        "SELECT MAX(oID) FROM orders;";
                    cmd.Parameters.AddWithValue("@uid", uID);

                    oID = (Int32)cmd.ExecuteScalar();
                }

                return createOrderLines(oID);

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public bool createOrderLines(int oID)
        {
            try
            {
                database.OpenGeneralConnection();
                foreach (ShoppingCartItem shoppingCartItem in ShoppingCart.items)
                {
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = database.GeneralConnection;
                        cmd.CommandText = "INSERT INTO orderlines (oID, pID, Amount) VALUES (@oid, @pid, @amount)";
                        cmd.Parameters.AddWithValue("@oid", oID);
                        cmd.Parameters.AddWithValue("@pid", shoppingCartItem.Product.pID);
                        cmd.Parameters.AddWithValue("@amount", shoppingCartItem.Amount);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }
    }
}