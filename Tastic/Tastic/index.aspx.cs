using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;
using Tastic.sql;
using Tastic.common;
using System.Windows;
using System.Security.Cryptography;

namespace Tastic
{
    public partial class index : System.Web.UI.Page
    {
        public Common Common = new Common();
        private UserSQL UserSQL = new UserSQL();

        protected void btnRegistreren_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx", true);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string hash = Common.Hash(password);

            User user = UserSQL.getUserFromEmail(email);

            bool ok = allowLogin(user.Password, hash);

            MessageBox.Show(ok.ToString());
        }

        private bool allowLogin(string uPass, string lPass)
        {
            byte[] uHashBytes = Convert.FromBase64String(uPass);

            byte[] salt = new byte[16];
            Array.Copy(uHashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(lPass, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            bool success = true;
            for (int i = 0; i < 20; i++)
            {
                if (uHashBytes[i + 16] != hash[i])
                {
                    success = false;
                }
            }

            return success;
        }
    }
}