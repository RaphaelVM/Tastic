using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tastic
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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