using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class ProductSQL
    {
        private Product newProduct(MySqlDataReader r)
        {
            return new Product(Convert.ToInt32(r["pID"]), r["Name"].ToString(),
                Convert.ToInt32(r["Amount"]), r["Productimage"].ToString(),
                Convert.ToBoolean(r["Active"]), r["Description"].ToString(),
                Convert.ToDouble(r["Price"]), Convert.ToInt32(r["cID"]));
        }

        /// <summary>
        /// Get the products the company has access to
        /// </summary>
        /// <param name="coID"></param>
        /// <returns></returns>
        public List<Product> getProducts(int coID)
        {
            List<Product> products = new List<Product>();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT pro.*, ptc.Price as Price, ptc.Description as Description " +
                                      "FROM products pro " +
                                      "INNER JOIN producttocomp ptc ON pro.pID = ptc.pID " +
                                      "WHERE ptc.coID = @coid ";
                    cmd.Parameters.AddWithValue("@coid", coID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(newProduct(reader));
                        }
                    }
                }

                return products;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return products;
            }
        }
    }
}