using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;
using Tastic.common;

namespace Tastic.sql
{
    public class CategorieSQL
    {
        private Categorie newCategorie(MySqlDataReader r)
        {
            return new Categorie(Convert.ToInt32(r["cID"]), r["Name"].ToString(),
                                r["Description"].ToString());
        }

        public Categorie GetCategorie(int cID)
        {
            Categorie categorie = new Categorie();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM categories WHERE cID = @cid";
                    cmd.Parameters.AddWithValue("@cid", cID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorie = newCategorie(reader);
                        }
                    }

                }

                return categorie;

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return categorie;
            }
        }
    }
}