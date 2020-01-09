using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;
using Tastic.common;

namespace Tastic
{
    public partial class users : System.Web.UI.Page
    {
        User user = new User();
        List<User> userList = new List<User>();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            walletAmount.Text = $"&euro; {user.Wallet.Amount.ToString("F2")}";
            itemsAmount.InnerText = ShoppingCart.items.Count().ToString();

            extraOptions.Controls.Add(new LiteralControl(Common.checkRoles(user.Role)));

            getUserList();

            createUserList();
        }

        private void getUserList()
        {
            userList = user.getUsers();

            user.getCompaniesFromUsers(userList);

            user.getWalletsFromUsers(userList);
        }

        private void createUserList()
        {
            string html = "";

            foreach (User user in userList)
            {

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