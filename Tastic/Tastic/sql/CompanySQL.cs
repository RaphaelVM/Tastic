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

        public Company getCompany(int uID)
        {
            Company company = new Company();
            try
            { 
                database.OpenGeneralConnection();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = database.GeneralConnection;
                    cmd.CommandText = "SELECT * FROM company WHERE coID = " +
                                      " (SELECT coID FROM usertocompany WHERE uID = @uid)";
                    cmd.Parameters.AddWithValue("@uid", uID);

                    using (var comReader = cmd.ExecuteReader())
                    {
                        while (comReader.Read())
                        {
                            company = newCompany(comReader);
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
                        while (reader.Read())
                        {
                            company = newCompany(reader);
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
    }
}