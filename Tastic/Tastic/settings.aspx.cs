using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;

namespace Tastic
{
    public partial class settings : System.Web.UI.Page
    {
        private Company company = new Company();
        private User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));
            company = company.getCompanyFromUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            walletAmount.InnerHtml = $"&euro;{user.Wallet.Amount.ToString()}";
        }
    }
}