using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Tastic.common;
using Tastic.classes;

namespace Tastic
{
    public partial class Cart : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            showCartProducts();
        }

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

        private void showCartProducts()
        {
            int ii = 0;

            foreach (ShoppingCartItem shoppingCartItem in ShoppingCart.items)
            {
                string html = 
                        "<div class=\"products-product-container\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                                "<div class=\"product-image\">" + // image
                                    $"<img src=\"{shoppingCartItem.Product.Productimage}\" alt=\"{shoppingCartItem.Product.Productimage}\" />" +
                                "</div>" +
                                "" +
                                "<div class=\"product-description\">" + // Main body
                                    $"<b>{shoppingCartItem.Product.Name}</b> <br />" +
                                    $"<span>&euro;{shoppingCartItem.Product.Price.ToString("F2").Replace(".", ",")}</span> <br />" +
                                    $"<span>{shoppingCartItem.Amount}</span>" +
                                "</div>" +
                                "" +
                                "<div class=\"product-addtocart text-center\">" +
                                    $"<div class=\"product-addtocart-icon product-addtocart-icon align-items-center justify-content-center\">" +
                                        "+" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                ii++;

                // if it's equal we have reached the end of the list so we don't need a spacer anymore
                if (ii != ShoppingCart.items.Count)
                {
                    html += "<div class=\"spacer-products\"></div>";
                }

                cartContainer.Controls.Add(new LiteralControl(html));
            }
        }
    }
}