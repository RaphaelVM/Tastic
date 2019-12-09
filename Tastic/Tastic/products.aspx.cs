﻿using System;
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

            walletAmount.InnerHtml = $"&euro;{user.Wallet.Amount.ToString("F2")}";
        }

        private string createProductList()
        {
            string html = "";
            int ii = 0;
            foreach (Product product in productList)
            {
                html += "<div class=\"products-product-container\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
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
                                "<div class=\"product-addtocart text-center\">" +
                                    "<div class=\"product-addtocart-icon product-addtocart-icon  align-items-center justify-content-center\">" +
                                        "+" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                ii++;

                // if it's equal we have reached the end of the list so we don't need a spacer anymore
                if (ii != productList.Count)
                {
                    html += "<div class=\"spacer-products\"></div>";
                }
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

        protected void btnLogout_Click(object sender, EventArgs e)
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
    }
}