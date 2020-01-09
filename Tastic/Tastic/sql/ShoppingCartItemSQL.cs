using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;
using Tastic.common;

namespace Tastic.sql
{
    public class ShoppingCartItemSQL
    {
        private ShoppingCartItem newShoppingCartItem(MySqlDataReader r)
        {
            return new ShoppingCartItem(null,
                                        new Product(Convert.ToInt32(r["pID"]), r["Name"].ToString(),
                                            Convert.ToInt32(r["Amount"]), r["Productimage"].ToString(),
                                            Convert.ToBoolean(r["Active"]), r["Description"].ToString(),
                                            Convert.ToDouble(r["Price"]), Convert.ToInt32(r["cID"])));
        }

        /// <summary>
        /// Use the pID to get all the data to fill a ShoppingCartItem object
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public ShoppingCartItem getShoppingCartItem(int pID)
        {
            ShoppingCartItem shoppingCartItem = new ShoppingCartItem();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT pro.*, ptc.Price as Price, ptc.Description as Description " +
                                      "FROM products pro " +
                                      "INNER JOIN producttocomp ptc ON pro.pID = ptc.pID " +
                                      "WHERE ptc.pID = @pid ";
                    cmd.Parameters.AddWithValue("@pid", pID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shoppingCartItem = newShoppingCartItem(reader);
                        }
                    }
                }

                return shoppingCartItem;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return shoppingCartItem;
            }
        }
    }
}