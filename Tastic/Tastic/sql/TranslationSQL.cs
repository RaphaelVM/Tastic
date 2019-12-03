using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class TranslationSQL
    {
        public Translation newTranslation(MySqlDataReader r)
        {
            return new Translation(Convert.ToInt32(r["tID"]), r["Description"].ToString(), 
                                    r["NL"].ToString(), r["EN"].ToString());
        }

        public List<Translation> getAllTranslations()
        {
            List<Translation> Translations = new List<Translation>();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM translations";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Translations.Add(newTranslation(reader));
                        }
                    }
                }

                return Translations;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Translations;
            }
        }
    }
}