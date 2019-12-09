using System;
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
    public partial class products : System.Web.UI.Page
    {
        private List<Product> productList = new List<Product>();
        private Company company = new Company();
        private User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the needed classes
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));
            company = company.getCompanyFromUser(Convert.ToInt32(Properties.Settings.Default.user_id));
            productList = company.products;
        }


        #region
        /* Category buttons */
        protected void btnAlles_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?all");
        }

        protected void btnbroodjes_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?broodjes");
        }

        protected void btnSoepen_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?soepen");
        }

        protected void btnSnacks_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?snacks");
        }

        protected void btnDranken_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?dranken");
        }

        #endregion
    }
}