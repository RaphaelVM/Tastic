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

            User user = UserSQL.getUserFromEmail(email);

            bool ok = allowLogin(user.Password, password);

            MessageBox.Show(ok.ToString());
        }

        private bool allowLogin(string uPass, string lPass)
        {
            if (Common.Verify(lPass, uPass))
            {
                return true;
            }

            return false;
        }
    }
}