using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;
using Tastic.sql;
using Tastic.common;
using System.Windows;
using System.Windows.Controls;
using System.Web.Services;

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

            switch (Request.QueryString.ToString())
            {
                case "broodjes":
                    productList = productList.Where(pL => pL.Categorie.Name == "Broodjes").ToList();
                    break;
                case "soepen":
                    productList = productList.Where(pL => pL.Categorie.Name == "Soepen").ToList();
                    break;
                case "snacks":
                    productList = productList.Where(pL => pL.Categorie.Name == "Snacks").ToList();
                    break;
                case "dranken":
                    productList = productList.Where(pL => pL.Categorie.Name == "Dranken").ToList();
                    break;
                default:
                    break;
            }

            // Create the basic html
            createProductList();

            walletAmount.Text = $"&euro;{user.Wallet.Amount.ToString("F2")}";

            itemsAmount.InnerHtml = ShoppingCart.items.Count.ToString();
        }

        private void createProductList()
        {
            int ii = 0;
            foreach (Product product in productList)
            {
                string id = $"{product.pID}";
                string html = 
                        "<div class=\"products-product-container\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                                "<div class=\"product-image\">" + // image
                                    $"<img src=\"loadImage.ashx?image={product.Productimage}\" alt=\"{product.Productimage}\" />" +
                                "</div>" +
                                "" +
                                "<div class=\"product-description\">" + // Main body
                                    $"<b>{product.Name}</b> <br />" +
                                    $"<span>&euro;{product.Price.ToString("F2").Replace(".", ",")}</span> <br />" +
                                    $"<span>{product.Description}</span>" +
                                "</div>" +
                                "" +
                                "<div class=\"product-addtocart text-center\">" +
                                    $"<div class=\"product-addtocart-icon product-addtocart-icon align-items-center justify-content-center\" Onclick=\"addToCart({id})\">" +
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

                productsContainer.Controls.Add(new LiteralControl(html));
            }
        }

        [WebMethod]
        public static string addToCart(int pID)
        {
            ShoppingCartItem shoppingCartItem = new ShoppingCartItem();
            ShoppingCart.addItem(shoppingCartItem.getShoppingCartItem(pID));

            List<ShoppingCartItem> items = ShoppingCart.Items;

            return items.Count.ToString();
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

        #region
        /* Redirect buttons */
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

        protected void linkProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx", true);
        }

        protected void linkSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings.aspx", true);
        }

        #endregion
    }
}