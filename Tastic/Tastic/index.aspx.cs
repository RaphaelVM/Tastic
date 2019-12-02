using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;

namespace Tastic
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (database.OpenGeneralConnection())
                {
                    lblConn.Text = "Connection made";
                }
                else
                {
                    lblConn.Text = "Connection failed";
                }
            }
        }

        protected void testBtn_Click(object sender, EventArgs e)
        {
            lblConn.Text = "Test";

            //Page.Response.Redirect(Page.Request.Url.AbsoluteUri);
        }
    }
}