using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class RoleSQL
    {
        private Role newRole(MySqlDataReader r)
        {
            return new Role(Convert.ToInt32(r["rID"]), r["Rolename"].ToString(), 
                            r["Description"].ToString());
        }

        /// <summary>
        /// SQL method for getting a role by it's rID
        /// </summary>
        /// <param name="rID"></param>
        /// <returns></returns>
        public Role getRole(int rID)
        {
            Role role = new Role();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM roles WHERE rID = @rid";
                    cmd.Parameters.AddWithValue("@rid", rID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            role = newRole(reader);
                        }
                    }

                }

                return role;
            } catch (Exception err)
            {
                Console.WriteLine(err);
                return role;
            }
        }

        /// <summary>
        /// Gets the role from the user using its uID
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public Role getRoleFromUser(int uID)
        {
            Role role = new Role();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM roles WHERE rID = (SELECT rID FROM users WHERE uID = @uid)";
                    cmd.Parameters.AddWithValue("@uid", uID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            role = newRole(reader);
                        }
                    }

                }

                return role;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return role;
            }
        }
    }
}