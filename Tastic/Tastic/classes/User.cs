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
        private CompanySQL companySQL = new CompanySQL();

        public int uID;
        public string Email;
        public string Password;
        public string Firstname;
        public string Lastname;
        public string Sex;
        public Role Role;
        public Wallet Wallet;

        public Company company = new Company();

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
        }

        /// <summary>
        /// Get a user by its uID
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public User getUser(int uID)
        {
            // To prevent reader closed error when getting multiple users
            User user = userSQL.getUser(uID);
            user.Role = roleSQL.getRoleFromUser(uID);
            user.Wallet = walletSQL.getWallet(uID);

            return user;
        }

        /// <summary>
        /// Gets ALL users
        /// </summary>
        /// <returns></returns>
        public List<User> getUsers()
        {
            return userSQL.getUsers();
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool updateUser(int uID, string email, string password)
        {
            return userSQL.updateUser(uID, email, password);
        }

        /// <summary>
        /// Fills the company for each user
        /// </summary>
        /// <param name="users"></param>
        public void getCompaniesFromUsers(List<User> users)
        {
            foreach (User user in users)
            {
                user.company = companySQL.getCompanyFromUser(user.uID);
            }
        }

        /// <summary>
        /// Fills the wallet for each user
        /// </summary>
        /// <param name="users"></param>
        public void getWalletsFromUsers(List<User> users)
        {
            foreach (User user in users)
            {
                user.Wallet = walletSQL.getWallet(user.uID);
            }
        }
    }
}