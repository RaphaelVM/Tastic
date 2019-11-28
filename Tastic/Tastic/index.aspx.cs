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
            if (database.OpenGeneralConnection())
            {
                lblConn.Text = "Connection made";
            } else
            {
                lblConn.Text = "Connection failed";
            }
        }
    }
}