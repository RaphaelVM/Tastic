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
            // Get the user
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            // Change some stuff
            walletAmount.Text = $"&euro; {user.Wallet.Amount.ToString("F2")}";
            itemsAmount.InnerText = ShoppingCart.items.Count().ToString();

            // Add more options if they are there for that role
            extraOptions.Controls.Add(new LiteralControl(Common.checkRoles(user.Role)));

            getUserList();

            createUserList();
        }

        /// <summary>
        /// Get ALL the users
        /// </summary>
        private void getUserList()
        {
            userList = user.getAllUsers();

            user.getCompaniesFromUsers(userList);

            user.getWalletsFromUsers(userList);

            user.GetRolesFromUsers(userList);
        }

        /// <summary>
        /// Format the userlist into html and show it
        /// </summary>
        private void createUserList()
        {
            string html =
                "<table class=\"table\">" +
                    "<tr>" +
                        "<th>Naam</th>" +
                        "<th>Naam bedrijf</th>" +
                        "<th>Wallet amount</th>" +
                        "<th>Geslacht</th>" +
                        "<th>Rol</th>" +
                    "</tr>";

            foreach (User user in userList)
            {
                string sex = (user.Sex == null) ? "" : user.Sex;

                html +=
                    "<tr>" +
                        $"<td>{user.Lastname}, {user.Firstname}</td>" +
                        $"<td>{user.company.Name}</td>" +
                        $"<td>&euro; {user.Wallet.Amount.ToString("F2").Replace(",", ".")}</td>" +
                        $"<td>{sex}</td>" +
                        $"<td>{user.Role.Rolename}</td>" +
                        $"<td><i class=\"fas fa-user-edit\" style=\"cursor: pointer\" onclick=\"editUser({user.uID})\"></i></td>" +
                    "</tr>";
            }

            html += "</table>";

            userPlaceholder.Controls.Add(new LiteralControl(html));
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