using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class ProductsSQL
    {
        private Product newProduct(MySqlDataReader r)
        {
            return new Product(Convert.ToInt32(r["pID"]), r["Name"].ToString(),
                Convert.ToInt32(r["Amount"]), r["Productimage"].ToString(),
                Convert.ToBoolean(r["Active"]), new Categorie());
        }

        public List<Product> getProducts(int coID)
        {
            List<Product> products = new List<Product>();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT pro.*, ptc.Price FROM products pro " +
                                      "INNER JOIN producttocomp ptc "+
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