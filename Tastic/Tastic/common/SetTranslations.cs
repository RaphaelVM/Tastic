using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;
using Tastic.sql;
using Tastic.common;
using Tastic;

namespace Tastic.common
{
    public class SetTranslations
    {

        public static void setIndexTranslations(Tastic.index index)
        {
            List<Translation> translations = index.Translations;
            if (Properties.Settings.Default.lang == "NL")
            {
                foreach (Translation translation in translations)
                {
                    switch (translation.Description)
                    {
                        case "loginKnop":
                            index.Login = translation.NL;
                            break;
                        case "registerKnop":
                            index.Register = translation.NL;
                            break;
                        case "passwordInput":
                            index.Password = translation.NL;
                            break;
                        case "emailInput":
                            index.Email = translation.NL;
                            break;
                        default:
                            break;
                    }
                }
            } else if (Properties.Settings.Default.lang == "EN")
            {
                foreach (Translation translation in translations)
                {
                    switch (translation.Description)
                    {
                        case "loginKnop":
                            index.Login = translation.EN;
                            break;
                        case "registerKnop":
                            index.Register = translation.EN;
                            break;
                        case "passwordInput":
                            index.Password = translation.EN;
                            break;
                        case "emailInput":
                            index.Email = translation.EN;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void setRegisterTranslations(Tastic.register register)
        {
            List<Translation> translations = register.Translations;
            if (Properties.Settings.Default.lang == "NL")
            {
                foreach (Translation translation in translations)
                {
                    switch (translation.Description)
                    {
                        case "cancelKnop":
                            register.Cancel = translation.NL;
                            break;
                        case "registerKnop":
                            register.Register = translation.NL;
                            break;
                        case "firstnameInput":
                            register.Firstname = translation.NL;
                            break;
                        case "lastnameInput":
                            register.Lastname = translation.NL;
                            break;
                        case "passwordInput":
                            register.Password = translation.NL;
                            break;
                        case "passwordInputRepeat":
                            register.PasswordRepeat = translation.NL;
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (Properties.Settings.Default.lang == "EN")
            {
                foreach (Translation translation in translations)
                {
                    switch (translation.Description)
                    {
                        case "cancelKnop":
                            register.Cancel = translation.EN;
                            break;
                        case "registerKnop":
                            register.Register = translation.EN;
                            break;
                        case "firstnameInput":
                            register.Firstname = translation.EN;
                            break;
                        case "lastnameInput":
                            register.Lastname = translation.EN;
                            break;
                        case "passwordInput":
                            register.Password = translation.EN;
                            break;
                        case "passwordInputRepeat":
                            register.PasswordRepeat = translation.EN;
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }
}