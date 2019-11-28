using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class database
    {
        public static readonly string GeneralConnectionString = "Server=mysql.feddema.dev;" +
            "Database=tastic;User Id=tastic;Password=Tg8VTSxqPgi616907pf21Dd5;";

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