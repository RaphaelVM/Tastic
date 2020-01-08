using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class WalletSQL
    {
        private Wallet newWallet(MySqlDataReader r)
        {
            return new Wallet(Convert.ToInt32(r["wID"]), Convert.ToDouble(r["Amount"]));
        }

        public bool retractFromWallet(int uID, float retractAmount)
        {
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "UPDATE wallet w1 SET w1.Amount = (Amount - @retractAmount) WHERE w1.uID = @uid";
                    cmd.Parameters.AddWithValue("@uid", uID);
                    cmd.Parameters.AddWithValue("@retractAmount", retractAmount);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public Wallet getWallet(int uID)
        {
            Wallet wallet = new Wallet();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM wallet WHERE uID = @uid";
                    cmd.Parameters.AddWithValue("@uid", uID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wallet = newWallet(reader);
                        }
                    }

                }

                return wallet;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return wallet;
            }
        }
    }
}