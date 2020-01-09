using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;

namespace Tastic.classes
{
    public class Company
    {
        private CompanySQL companySQL = new CompanySQL();
        private ProductSQL productSQL = new ProductSQL();
        private CategorieSQL categorieSQL = new CategorieSQL();

        public int coID;
        public string Name;
        public string Street;
        public string Postalcode;
        public string Streetnumber;
        public string City;
        public string Phonenumber;
        public string Emailadress;
        public Catering Catering;
        public List<Product> products = new List<Product>();

        public Company() { }

        public Company(int coid, string name, string street, string postalcode,
                        string streetnumber, string city, string phonenumber,
                        string emailadress, Catering catering)
        {
            coID = coid;
            Name = name;
            Street = street;
            Streetnumber = streetnumber;
            City = city;
            Phonenumber = phonenumber;
            Emailadress = emailadress;
            Catering = catering;
        }

        /// <summary>
        /// Get all the products a company has access to
        /// </summary>
        /// <param name="coID"></param>
        /// <returns></returns>
        public List<Product> getProducts(int coID)
        {
            List<Product> products = productSQL.getProducts(coID);

            // We set the categories here. Problems arose when doing it in the constructor
            foreach (Product product in products)
            {
                product.Categorie = categorieSQL.GetCategorieFromProduct(product.pID);
            }

            return products;
        }

        /// <summary>
        /// Use a uID to get the company the user is linked to
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Company getCompanyFromUser(int uid)
        {
            return companySQL.getCompanyFromUser(uid);
        }
    }
}