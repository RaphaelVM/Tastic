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
        public static List<Translation> Translations = new List<Translation>();

        public Common Common = new Common();
        private UserSQL UserSQL = new UserSQL();
        private TranslationSQL TranslationSQL = new TranslationSQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Translations = TranslationSQL.getAllTranslations();

            SetTranslations.setIndexTranslations(this);
        }

        protected void btnRegistreren_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx", true);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User user = UserSQL.getUserFromEmail(email);

            bool allowedLogin = allowLogin(user.Password, password);

            MessageBox.Show(allowedLogin.ToString());

            if (allowedLogin)
            {
                Response.Redirect("products.aspx", true);
            }
        }

        private bool allowLogin(string uPass, string lPass)
        {
            if (Common.Verify(lPass, uPass))
            {
                return true;
            }

            return false;
        }

        #region 
        /* Used to set text for translations */

        public string Login
        {
            get { return btnLogin.Text; }
            set { btnLogin.Text = value; }
        }

        public string Register
        {
            get { return btnRegistreren.Text; }
            set { btnRegistreren.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Attributes.Add("placeholder", value); }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Attributes.Add("placeholder", value); }
        }
        #endregion
    }
}