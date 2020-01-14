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
using System.Threading.Tasks;

namespace Tastic
{
    public partial class edituser : System.Web.UI.Page
    {
        private Company company = new Company();
        private User user = new User();
        private Role role = new Role();
        
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

            List<Company> companies = company.getAllCompanies();

            foreach (Company company in companies)
            {
                ddlCompanies.Items.Add(new ListItem(company.Name, company.coID.ToString()));
            }

            List<Role> roles = role.getAllRoles();

            foreach (Role role in roles)
            {
                ddlRoles.Items.Add(new ListItem($"{role.Rolename} - {role.Description}", role.rID.ToString()));
            }

            // Set defualts
            if (editUser.Sex != null)
            {
                ddlGeslacht.SelectedValue = editUser.Sex;
            }

            ddlCompanies.SelectedValue = editUser.company.Name;

            ddlRoles.SelectedIndex =
                ddlRoles.Items.IndexOf(ddlRoles.Items.FindByText($"{editUser.Role.Rolename} - {editUser.Role.Description}"));

            saveButtonPlaceholder.Controls.Add(new LiteralControl($"<button type=\"button\" id=\"btnSave\" class=\"btn btn-primary buttonStyle float-right\" onclick=\"updateUser({editUser.uID})\">Opslaan</button>"));
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("users.aspx", true);
        }

        #endregion

        /// <summary>
        /// save the user, needs to be async so we can do a delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [WebMethod]
        public static bool adminEditUser(string uid, string firstname, string lastname, string sex, string walletamount, string companyid, string roleid)
        {
            User user = new User();

            int uID = Convert.ToInt32(uid);
            User editUser = user.getUser(uID);
            string firstName = firstname;
            string lastName = lastname;
            string Sex = sex;
            double walletAmount = Convert.ToDouble(walletamount);
            int companyID = Convert.ToInt32(companyid);
            int roleID = Convert.ToInt32(roleid);

            if (user.updateUserAdmin(editUser.uID, editUser.company.coID, firstName, lastName, Sex, walletAmount, companyID, roleID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}