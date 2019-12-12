using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class UserSQL
    {
        private User newUser(MySqlDataReader r)
        {
            return new User(Convert.ToInt32(r["uID"]), r["Email"].ToString(), r["Password"].ToString(),
                            r["Firstname"].ToString(), r["Lastname"].ToString(), r["Sex"].ToString(),
                            Convert.ToInt32(r["rID"]));
        }

        public User getUser(int uID)
        {
            User user = new User();
            try
            {
                database.OpenGeneralConnection();

                using(var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM users WHERE uID = @uid";
                    cmd.Parameters.AddWithValue("@uid", uID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = newUser(reader);
                        }
                    }

                }

                return user;

            } catch (Exception err)
            {
                Console.WriteLine(err);
                return user;
            }
        }

        public bool createNewUser(string firstname, string lastname, string password, string email)
        {
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "INSERT INTO users (Email, Firstname, Lastname, Password)" +
                                      "VALUES (@email, @firstname, @lastname, @password)";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public User getUserFromEmail(string email)
        {
            User user = new User();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM users WHERE Email = @email";
                    cmd.Parameters.AddWithValue("@email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = newUser(reader);
                        }
                    }
                }

                return user;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return user;
            }
        }

        public bool updateUser(int uID, string email, string password)
        {
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "UPDATE users SET Email = @email, Password = @password " + 
                                      "WHERE uID = @uid";
                    cmd.Parameters.AddWithValue("@uid", uID);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }
}