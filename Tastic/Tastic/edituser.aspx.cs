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
using System.Windows.Controls;
using System.Web.Services;

namespace Tastic
{
    public partial class edituser : System.Web.UI.Page
    {
        private Company company = new Company();
        private User user = new User();
        private User editUser = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));
            if (Request.QueryString.ToString() == "")
            {
                Response.Redirect("index.aspx", true);
            }

            int uID = Convert.ToInt32(Request.QueryString["uID"]);

            editUser = user.getUser(uID);

            setInputs();
        }

        /// <summary>
        /// Sets the inputs when the page loads
        /// </summary>
        private void setInputs()
        {
            txtFirstname.Text = editUser.Firstname;
            txtLastname.Text = editUser.Lastname;
            txtWalletAmount.Text = editUser.Wallet.Amount.ToString();
            
            if (editUser.Sex != null)
            {
                ddlGeslacht.SelectedValue = editUser.Sex;
            }

            List<Company> companies = company.getAllCompanies();

            foreach (Company company in companies)
            {
                ddlCompanies.Items.Add(new ListItem(company.Name, company.coID.ToString()));
            }
        }

        #region 
        /* Default buttons */

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
            // Clear properties
            Properties.Settings.Default.user_fName = "";
            Properties.Settings.Default.user_id = "";
            Properties.Settings.Default.user_lName = "";
            Properties.Settings.Default.user_sex = "";

            Properties.Settings.Default.Save();

            // Redirect to login
            Response.Redirect("index.aspx");
        }

        #endregion
    }
}