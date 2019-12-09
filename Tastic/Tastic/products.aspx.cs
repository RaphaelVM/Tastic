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

            productsContainer.Controls.Add(new LiteralControl(createProductList()));
        }

        private string createProductList()
        {
            string html = "";
            foreach (Product product in productList)
            {
                html += "<div class=\"products-product-container\">" +
                            "<div class=\"product\">" +
                                "<div class=\"product-image\">" + // image
                                    $"<img src=\"{product.Productimage}\" alt=\"{product.Productimage}\" />" +
                                "</div>" +
                                "" +
                                "<div class=\"product-description\">" + // Main body
                                    $"<b>{product.Name}</b> <br />" +
                                    $"<span>&euro;{product.Price.ToString().Replace(".", ",")}</span> <br />" +
                                    $"<span>{product.Description}</span>" +
                                "</div>" +
                                "" +
                                "<div class=\"product-addtocart\">" +
                                    "<div class=\"product-addtocart-icon\">" +
                                    "</div>" +
                                "<div>" +
                            "</div>" +
                        "</div>";
            }

            return html;
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