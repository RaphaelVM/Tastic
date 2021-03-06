﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using Tastic.classes;

namespace Tastic.common
{
    public class Common
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;

        /// <summary>
        /// Creates a hash from a password
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="iterations">number of iterations</param>
        /// <returns>the hash</returns>
        public static string Hash(string password, int iterations = 10000)
        {
            //create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            //create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            //combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            //convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            //format hash with extra information
            return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
        }

        /// <summary>
        /// Creates a hash from a password with 10000 iterations
        /// </summary>
        /// <param name="password">the password</param>
        /// <returns>the hash</returns>
        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        /// <summary>
        /// Check if hash is supported
        /// </summary>
        /// <param name="hashString">the hash</param>
        /// <returns>is supported?</returns>
        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$MYHASH$V1$");
        }

        /// <summary>
        /// verify a password against a hash
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="hashedPassword">the hash</param>
        /// <returns>could be verified?</returns>
        public static bool Verify(string password, string hashedPassword)
        {
            //check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            //extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            //get hashbytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            //get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            //create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            //get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void setUser(User user)
        {
            Properties.Settings.Default.user_id = user.uID.ToString();
            Properties.Settings.Default.user_fName = user.Firstname;
            Properties.Settings.Default.user_lName = user.Lastname;
            Properties.Settings.Default.user_sex = user.Sex;

            Properties.Settings.Default.Save();
        }

        public static string checkRoles(Role role)
        {
            string html = "";
            switch (role.rID)
            {
                case 1: // User
                    html = "";
                    break;
                case 2: // Admin
                    html =
                        "<div class=\"spacer\"></div>" +
                        "<a href=\"companies.aspx\">Bedrijven</a>" +
                        "<div class=\"spacer\"></div>" +
                        "<a href=\"caterings.aspx\">Cateringen</a>" +
                        "<div class=\"spacer\"></div>" +
                        "<a href=\"productadmin.aspx\">Product Admin</a>" +
                        "<div class=\"spacer\"></div>" +
                        "<a href=\"users.aspx\">Gebruikers</a>";
                    break;
                case 3: // Bedrijfsadmin
                    html =
                       "<div class=\"spacer\"></div>" +
                       "<a href=\"users.aspx\">Gebruikers</a>";
                    break;
                case 4: // Cateraar
                    html =
                       "<div class=\"spacer\"></div>" +
                       "<a href=\"productadmin.aspx\">Product Admin</a>";
                    break;
                default:
                    html = "";
                    break;
            }

            return html;
        }
    }
}