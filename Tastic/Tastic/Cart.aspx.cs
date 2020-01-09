using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Tastic.common;
using Tastic.classes;
using System.Web.Services;

namespace Tastic
{
    public partial class Cart : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            walletAmount.Text = $"&euro; {user.Wallet.Amount.ToString("F2")}";
            itemsAmount.InnerText = ShoppingCart.items.Count().ToString();

            showCartProducts();

            extraOptions.Controls.Add(new LiteralControl(Common.checkRoles(user.Role)));
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

            // No items in the shopping cart
            if (ShoppingCart.items.Count == 0)
            {
                string html = 
                        "<div class=\"products-product-container\" id=\"noproducts\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                                 "<span class=\"noProducts\">" +
                                    "Er zitten geen producten in de winkelwagen" +
                                "</span>" +
                        "</div>";

                cartContainer.Controls.Add(new LiteralControl(html));
            }

            // Foreach item in the cart create some html
            foreach (ShoppingCartItem shoppingCartItem in ShoppingCart.items)
            {
                string html = 
                        $"<div class=\"products-product-container\" id=\"item_{shoppingCartItem.sciID}\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                                "<div class=\"product-image\">" + // image
                                    $"<img src=\"loadImage.ashx?image={shoppingCartItem.Product.Productimage}\" alt=\"{shoppingCartItem.Product.Productimage}\" class=\"product-image-image\" />" +
                                "</div>" +
                                "" +
                                "<div class=\"cart-product-description\">" + // Main body
                                    $"<b>{shoppingCartItem.Product.Name}</b> <br />" +
                                    $"<span>&euro;{shoppingCartItem.Product.Price.ToString("F2").Replace(".", ",")}</span> <br />" +
                                    $"<span>{shoppingCartItem.Product.Description}</span>" +
                                "</div>" +
                                "" +
                                "<div class=\"cart-product-addtocart text-center\">" +
                                    $"<input type=\"number\" id=\"{shoppingCartItem.sciID}\" onchange=\"changeAmount({shoppingCartItem.sciID})\" class=\"form-control formStyle cart-change-amount\" value=\"{shoppingCartItem.Amount}\" /> " +
                                    "<div>" +
                                        $"<i class=\"fas fa-trash remove-product\" onclick=\"removeItem({shoppingCartItem.sciID})\"></i>" +
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

        /// <summary>
        /// Update the amount of a product in the shopping cart
        /// </summary>
        /// <param name="sciID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [WebMethod]
        public static bool updateAmount(int sciID, int amount)
        {
            try
            {
                // Get the item we are talking about
                ShoppingCartItem shoppingCartItem = ShoppingCart.items.First(sci => sci.sciID == sciID);

                ShoppingCart.items[sciID].Amount = amount;

                return true;
            } catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        [WebMethod]
        public static int removeItem(int sciID)
        {
            try
            {
                ShoppingCart.items.Remove(ShoppingCart.items[sciID]);

                return ShoppingCart.items.Count;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return ShoppingCart.items.Count;
            }
        }

        protected void btnBestel_Click(object sender, EventArgs e)
        {
            Response.Redirect("payment.aspx");
        }

        protected void btnAnnuleren_Click(object sender, EventArgs e)
        {
            // Clear the shoppingcart
            ShoppingCart.items = new List<ShoppingCartItem>();

            itemsAmount.InnerText = ShoppingCart.items.Count.ToString();

            // Clear the html
            cartContainer.Controls.Clear();

            // Create and insert the string in the panel
            string html =
                        "<div class=\"products-product-container\" id=\"noproducts\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                                 "<span class=\"noProducts\">" +
                                    "Er zitten geen producten in de winkelwagen" +
                                "</span>" +
                        "</div>";

            cartContainer.Controls.Add(new LiteralControl(html));
        }

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
    }
}