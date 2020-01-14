using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;

namespace Tastic.sql
{
    public class CompanySQL
    {
        private Company newCompany(MySqlDataReader r)
        {
            return new Company(Convert.ToInt32(r["coID"]), r["Name"].ToString(),
                        r["Street"].ToString(), r["Postalcode"].ToString(), r["Streetnumber"].ToString(),
                        r["City"].ToString(), r["Phonenumber"].ToString(), r["Emailadress"].ToString(),
                        new Catering());
        }

        /// <summary>
        /// Get the company to which a user is linked to using the uID
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public Company getCompanyFromUser(int uID)
        {
            Company company = new Company();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM company WHERE coID = " +
                                      "(SELECT coID FROM usertocomp WHERE uID = @uid)";
                    cmd.Parameters.AddWithValue("@uid", uID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                company = newCompany(reader);
                            }
                        } else
                        {
                            company = new Company();
                        }
                    }

                }

                return company;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return company;
            }
        }

        /// <summary>
        /// Get all companies we have
        /// </summary>
        /// <returns></returns>
        public List<Company> getAllCompanies()
        {
            List<Company> companies = new List<Company>();
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM company";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            companies.Add(newCompany(reader));
                        }
                    }

                }

                return companies;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return companies;
            }
        }

        public bool updateUserCompany(int uID, int cID, int oldCID)
        {
            try
            {
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "UPDATE usertocomp SET coID = @coid WHERE uID = @uid AND coID = @oldcid";
                    cmd.Parameters.AddWithValue("@coid", cID);
                    cmd.Parameters.AddWithValue("@uid", uID);
                    cmd.Parameters.AddWithValue("@oldcid", oldCID);

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