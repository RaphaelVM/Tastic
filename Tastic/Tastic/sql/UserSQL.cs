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

        /// <summary>
        /// Get the user using his/her uID
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool createNewUser(string firstname, string lastname, string password, string email)
        {
            int uID;
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "INSERT INTO users (Email, Firstname, Lastname, Password)" +
                                      "VALUES (@email, @firstname, @lastname, @password);" +
                                      "SELECT MAX(uID) FROM users;";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@password", password);

                    // We need the uID we just created
                    uID = (int)cmd.ExecuteScalar();
                }

                // Return the bool result of the createUserWallet function
                return createUserWallet(uID);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        /// <summary>
        /// Create a wallet for when a user gets registered
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        private bool createUserWallet(int uID)
        {
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "INSERT INTO wallet (uID, amount) VALUES (@uid, 0.00)";
                    cmd.Parameters.AddWithValue("@uid", uID);

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

        /// <summary>
        /// Get the user from the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update the user using the parameters provided
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get ALL the users
        /// </summary>
        /// <returns></returns>
        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM users";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(newUser(reader));
                        }
                    }
                }

                return users;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return users;
            }
        }

        /// <summary>
        /// Update user from the admin page
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="sex"></param>
        /// <param name="walletAmount"></param>
        /// <param name="companyID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool updateUserAdmin(int uID, string firstName, string lastName, string sex, int roleID)
        {
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "UPDATE users SET Firstname = @firstname, Lastname = @lastname, Sex = @sex, rID = @rid WHERE uID = @uid";
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@rid", roleID);
                    cmd.Parameters.AddWithValue("@uid", uID);

                    cmd.ExecuteReader();
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