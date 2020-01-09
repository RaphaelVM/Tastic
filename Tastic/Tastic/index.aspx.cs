using System;
using System.Collections.Generic;
using Tastic.Properties;
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
            // Get all the translations
            Translations = TranslationSQL.getAllTranslations();

            // Set the translations for the index page, send "this" as parameter so we can edit the elements
            SetTranslations.setIndexTranslations(this);
        }

        /// <summary>
        /// Login check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email == "" || password == "")
            {
                // TODO: Error message
                return;
            }
            else
            {
                // Get the user from the email he/she wants to login with
                User user = UserSQL.getUserFromEmail(email);

                bool allowedLogin = allowLogin(user.Password, password);

                if (allowedLogin)
                {
                    // Set user related settings
                    Common.setUser(user);

                    // Redirect to the products page
                    Response.Redirect("products.aspx", true);
                } else
                {
                    MessageBox.Show(allowedLogin.ToString());
                }
            }
        }

        /// <summary>
        /// Are the passwords the same when they are compared
        /// </summary>
        /// <param name="uPass"></param>
        /// <param name="lPass"></param>
        /// <returns></returns>
        private bool allowLogin(string uPass, string lPass)
        {
            if (Common.Verify(lPass, uPass))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Redirects to the register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistreren_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx", true);
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