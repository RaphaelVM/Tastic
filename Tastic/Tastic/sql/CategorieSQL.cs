using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;
using Tastic.common;

namespace Tastic.sql
{
    public class CategorySQL
    {
        private Category newCategory(MySqlDataReader r)
        {
            return new Category(Convert.ToInt32(r["cID"]), r["Name"].ToString(),
                                r["Description"].ToString());
        }

        /// <summary>
        /// Get the category data from the cID
        /// </summary>
        /// <param name="cID"></param>
        /// <returns></returns>
        public Category GetCategory(int cID)
        {
            Category Category = new Category();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM Categorys WHERE cID = @cid";
                    cmd.Parameters.AddWithValue("@cid", cID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category = newCategory(reader);
                        }
                    }

                }

                return Category;

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Category;
            }
        }

        /// <summary>
        /// Use the pID to get the Category which it's linked with
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public Category GetCategoryFromProduct(int pID)
        {
            Category Category = new Category();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM categories WHERE cID = " +
                                        "(SELECT cID FROM products WHERE pID = @pid)";
                    cmd.Parameters.AddWithValue("@pid", pID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category = newCategory(reader);
                        }
                    }
                }

                return Category;

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Category;
            }
        }
    }
}