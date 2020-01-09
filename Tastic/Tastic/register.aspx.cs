using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Drawing;
using System.Text.RegularExpressions;
using Tastic.classes;
using Tastic.sql;
using Tastic.common;

namespace Tastic
{
    public partial class register : System.Web.UI.Page
    {
        public static List<Translation> Translations = new List<Translation>();

        private UserSQL UserSQL = new UserSQL();
        private TranslationSQL TranslationSQL = new TranslationSQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the translations
            Translations = TranslationSQL.getAllTranslations();

            // Set the translations 
            SetTranslations.setRegisterTranslations(this);
        }

        /// <summary>
        /// Register the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Get the data
            string firstname = txtVoornaam.Text;
            string lastname = txtAchternaam.Text;
            string email = txtEmail.Text;

            string passHash = Common.Hash(txtWachtwoord.Text, 10000);

            // Check if the email actually matches what we want an email to look like
            Match emailMatch = Regex.Match(txtEmail.Text, @".+[@].+[.].{2,6}", RegexOptions.IgnoreCase);

            // Check if the first- and lastname are not empty and the email matches a few things
            if (firstname != "" && lastname != "" && emailMatch.Success)
            {
                // Create the user using the data he/she filled in
                if (UserSQL.createNewUser(firstname, lastname, passHash, email))
                {
                    createERRPar.Attributes.CssStyle.Add("display", "block");
                    createERRPar.Attributes["class"] += " alert";
                    createERRPar.Attributes["class"] += " alert-success";
                    lblCreateERR.Text =
                        (Properties.Settings.Default.lang == "NL")
                        ? "Account was succesvol aangemaakt!"
                        : "Account was created succesfully";
                }
                else // Something went wrong
                {
                    createERRPar.Attributes.CssStyle.Add("display", "block");
                    createERRPar.Attributes["class"] += " alert";
                    createERRPar.Attributes["class"] += " alert-danger";
                    lblCreateERR.Text = (Properties.Settings.Default.lang == "NL")
                        ? "Er is iets misgegaan met het toevoegen van de gebruiker. Probeer het opnieuw?"
                        : "Something went wrong when creating the user. Please try again.";
                }
            }
            else // First- or lastname are not filled in or the way the email is constructed is not correct
            {
                createERRPar.Attributes.CssStyle.Add("display", "block");
                createERRPar.Attributes["class"] += " alert";
                createERRPar.Attributes["class"] += " alert-danger";
                lblCreateERR.Text = (Properties.Settings.Default.lang == "NL")
                    ? "De voor- of achternaam is niet ingevuld. Mogelijk is het email adres ook niet conform aan de eisen van een email adres."
                    : "The first or last name is not filled in. The email adress may also not be in the correct format.";
            }
        }

        #region

        public string Firstname
        {
            get { return txtVoornaam.Text; }
            set { txtVoornaam.Attributes.Add("placeholder", value); }
        }

        public string Lastname
        {
            get { return txtAchternaam.Text; }
            set { txtAchternaam.Attributes.Add("placeholder", value); }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Attributes.Add("placeholder", value); }
        }

        public string Password
        {
            get { return txtWachtwoord.Text; }
            set { txtWachtwoord.Attributes.Add("placeholder", value); }
        }

        public string PasswordRepeat
        {
            get { return txtWachtwoordHerh.Text; }
            set { txtWachtwoordHerh.Attributes.Add("placeholder", value); }
        }

        public string Register
        {
            get { return btnRegister.Text; }
            set { btnRegister.Text = value; }
        }

        public string Cancel
        {
            get { return btnCancel.Text; }
            set { btnCancel.Text = value; }
        }

        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", true);
        }
    }
}