﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;
using Tastic.sql;
using Tastic.common;

namespace Tastic
{
    public partial class settings : System.Web.UI.Page
    {

        private User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            //  Set user settings
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            // Fill forms with logged-in user info
            txtEmail.Text = user.Email;
            txtPassword.Text = user.Password;
            ddlLanguage.SelectedValue = Properties.Settings.Default.lang;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int uID = Convert.ToInt32(Properties.Settings.Default.user_id);
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string language = ddlLanguage.SelectedValue;

            Properties.Settings.Default.lang = language;

            user.updateUser(uID, email, password);
        }

        protected void linkProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx", true);
        }

        protected void linkSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings.aspx", true);
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", true);
        }
    }
}