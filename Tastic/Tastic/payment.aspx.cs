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

namespace Tastic
{
    public partial class payment : System.Web.UI.Page
    {
        User user = new User();
        string[] paymentOptions = new string[] { "Kies een methode", "iDEAL", "bankoverboeking", "bitcoin" };

        protected void Page_Load(object sender, EventArgs e)
        {
            user = user.getUser(Convert.ToInt32(Properties.Settings.Default.user_id));

            walletAmount.Text = $"&euro;{user.Wallet.Amount.ToString("F2")}";
            itemsAmount.InnerText = ShoppingCart.items.Count().ToString();

            showCartProducts();
            createPaymentType();
            showTotalAmount();
            showWalletCheckbox();
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

        private void createPaymentType()
        {
            foreach (string option in paymentOptions)
            {
                if (option == "Kies een methode")
                {
                    paymentMethod.Items.Add(new ListItem(option, option));
                }
                else
                {
                    paymentMethod.Items.Add(new ListItem(option, option));
                }
            }
        }

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

        private void showWalletCheckbox()
        {
            string checkbox = $"<input type=\"checkbox\" onclick=\"retractWallet({user.Wallet.Amount})\" id=\"useWallet\" />";
            checkboxPlaceholder.Controls.Add(new LiteralControl(checkbox));
        }

        [WebMethod]
        public static void createOrder(Boolean useWallet)
        {
            System.Diagnostics.Debug.WriteLine(useWallet);
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

        protected void paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Yeet");

            if (paymentMethod.SelectedValue != "Kies een methode")
            {
                paymentMethod.Items.Remove("Kies een methode");
            }
        }
    }
}