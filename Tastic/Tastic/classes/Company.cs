﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;

namespace Tastic.classes
{
    public class Company
    {
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
            products = this.getProducts(coid);
        }

        private List<Product> getProducts(int coID)
        {
            ProductSQL productSQL = new ProductSQL();

            return productSQL.getProducts(coID);
        }
    }
}