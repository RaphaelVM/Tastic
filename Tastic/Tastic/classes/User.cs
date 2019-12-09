using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;

namespace Tastic.classes
{
    public class User
    {
        private UserSQL userSQL = new UserSQL();
        private RoleSQL roleSQL = new RoleSQL();
        private WalletSQL walletSQL = new WalletSQL();

        public int uID;
        public string Email;
        public string Password;
        public string Firstname;
        public string Lastname;
        public string Sex;
        public Role Role;
        public Wallet Wallet;

        public User() { }

        public User(int uid, string email, string password, string firstname,
                    string lastname, string sex, int roleid)
        {
            uID = uid;
            Email = email;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Sex = sex;
            Role = roleSQL.getRole(roleid);
            Wallet = walletSQL.getWallet(uid);
        }

        public User getUser(int uID)
        {
            return userSQL.getUser(uID);
        }
    }
}