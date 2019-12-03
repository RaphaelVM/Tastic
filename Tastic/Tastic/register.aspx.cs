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
        private UserSQL UserSQL = new UserSQL();
        private Common Common = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstname = txtVoornaam.Text;
            string lastname = txtAchternaam.Text;
            string email = txtEmail.Text;

            string passHash = Common.Hash(txtWachtwoord.Text, 10000);

            Match emailMatch = Regex.Match(txtEmail.Text, @".+[@].+[.].{2,6}", RegexOptions.IgnoreCase);

            // Check if the first- and lastname are not empty and the email matches a few things
            if (firstname != "" && lastname != "" && emailMatch.Success)
            {
                if (UserSQL.createNewUser(firstname, lastname, passHash, email))
                {
                    createERRPar.Attributes.CssStyle.Add("display", "none");
                    createERRPar.Attributes["class"] = "";
                    lblCreateERR.Text = "";
                } else
                {
                    createERRPar.Attributes.CssStyle.Add("display", "block");
                    createERRPar.Attributes["class"] += " alert";
                    createERRPar.Attributes["class"] += " alert-danger";
                    lblCreateERR.Text = "Er is iets misgegaan met het toevoegen van de gebruiker. Probeer het opnieuw?";
                }
            } else
            {
                createERRPar.Attributes.CssStyle.Add("display", "block");
                createERRPar.Attributes["class"] += " alert";
                createERRPar.Attributes["class"] += " alert-danger";
                lblCreateERR.Text = "De voor- of achternaam is niet ingevuld. Mogelijk is is email adres ook niet conform aan de eisen van een email adres."; ;
            }
        }
    }
}