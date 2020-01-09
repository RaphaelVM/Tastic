using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tastic.classes;
using Tastic.Properties;
using Tastic.common;
using System.Web.Services;
using System.Windows;

namespace Tastic
{
    public partial class payment : System.Web.UI.Page
    {
        User user = new User();
        // Basic payment options, add more options to the array if needed
        string[] paymentOptions = new string[] { "Kies een methode", "iDEAL", "bankoverboeking", "bitcoin" };

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the basic stuff like the user
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            // Change the texts
            walletAmount.Text = $"&euro; {user.Wallet.Amount.ToString("F2")}";
            itemsAmount.InnerText = ShoppingCart.items.Count().ToString();

            // All HTML related things
            showCartProducts();
            createPaymentType();
            showTotalAmount();
            showWalletCheckbox();

            // Add more options to the burgermenu if the role allows for it
            extraOptions.Controls.Add(new LiteralControl(Common.checkRoles(user.Role)));
        }

        /// <summary>
        /// Show the products which are in the cart
        /// </summary>
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

                productContainer.Controls.Add(new LiteralControl(html));
            }

            foreach (ShoppingCartItem shoppingCartItem in ShoppingCart.items)
            {
                string html =
                        $"<div class=\"products-product-container\" id=\"item_{shoppingCartItem.sciID}\">" +
                            "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                                "<div class=\"payment-product-description\">" + // Main body
                                    $"<b>{shoppingCartItem.Product.Name}</b> <br />" +
                                    $"<span>{shoppingCartItem.Product.Description}</span>" +
                                "</div>" +
                                "" +
                                "<div class=\"payment-product-amount\">" +
                                    $"&euro; {(shoppingCartItem.Amount * shoppingCartItem.Product.Price).ToString("F2").Replace(".", ",")} (<b>&euro; {shoppingCartItem.Amount}</b> x <b>{shoppingCartItem.Product.Price.ToString("F2").Replace(".", ",")})</b>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                ii++;

                // if it's equal we have reached the end of the list so we don't need a spacer anymore
                if (ii != ShoppingCart.items.Count)
                {
                    html += "<div class=\"spacer-products\"></div>";
                }

                productContainer.Controls.Add(new LiteralControl(html));
            }
        }

        /// <summary>
        /// Put all the payment options in the dropdown list
        /// </summary>
        private void createPaymentType()
        {
            foreach (string option in paymentOptions)
            {
                paymentMethod.Items.Add(new ListItem(option, option));
            }
        }

        /// <summary>
        /// Show the total amount the user has to pay for his/her order
        /// </summary>
        private void showTotalAmount()
        {
            double totalPrice = 0.00;
            foreach (ShoppingCartItem cartItem in ShoppingCart.items)
            {
                totalPrice += cartItem.Amount * cartItem.Product.Price;
            }

            subtotalAmount.Text = $"Subtotaal: &euro; {totalPrice.ToString("F2").Replace(".", ",")}";
            totalAmount.Text = $"Totaal: &euro; {totalPrice.ToString("F2").Replace(".", ",")}";
        }

        /// <summary>
        /// Create the checkbox here because we need C# class data as a javascript function parameter
        /// </summary>
        private void showWalletCheckbox()
        {
            string checkbox = $"<input type=\"checkbox\" onclick=\"retractWallet({user.Wallet.Amount})\" id=\"useWallet\" />";
            checkboxPlaceholder.Controls.Add(new LiteralControl(checkbox));
        }

        /// <summary>
        /// Create the order
        /// </summary>
        /// <param name="useWallet"></param>
        /// <param name="walletAmountPaid"></param>
        /// <returns></returns>
        [WebMethod]
        public static bool createOrder(bool useWallet, float walletAmountPaid)
        {
            // We have to initialise a new class because it's a static
            Order order = new Order();

            // Create the order
            if (order.createOrder(useWallet, walletAmountPaid))
            {
                // If the order has been created clear the shoppingcart
                ShoppingCart.items.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 
        /* Redirect buttons */

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

        #endregion
    }
}