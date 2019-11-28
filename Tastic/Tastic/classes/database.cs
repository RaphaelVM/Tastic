using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class database
    {
        public static readonly string GeneralConnectionString =
            "Server=" + Properties.Settings.Default.sql_host + ";" +
            "Database=" + Properties.Settings.Default.sql_db + ";" +
            "User Id=" + Properties.Settings.Default.sql_user + ";" +
            "Password=" + Properties.Settings.Default.sql_pass + ";";

        public static MySqlConnection GeneralConnection = new MySqlConnection();

        public static bool OpenGeneralConnection()
        {
            CloseGeneralConnection();
            try
            {
                GeneralConnection.ConnectionString = GeneralConnectionString;
                GeneralConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static bool CloseGeneralConnection()
        {
            try
            {
                GeneralConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}