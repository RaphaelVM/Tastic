using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class User
    {
        public int uID;
        public string Email;
        private string Password;
        public string Firstname;
        public string Lastname;
        public string Sex;
        public Role Role;
        public Wallet Wallet;

        public User() { }

        public User(int uid, string email, string password, string firstname,
                    string lastname, string sex, Role role, Wallet wallet)
        {
            uID = uid;
            Email = email;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Sex = sex;
            Role = role;
            Wallet = wallet;
        }
    }
}