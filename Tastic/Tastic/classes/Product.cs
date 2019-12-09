using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;

namespace Tastic.classes
{
    public class Product
    {
        private CategorieSQL categorieSQL = new CategorieSQL();

        public int pID;
        public string Name;
        public int Amount;
        public string Productimage;
        public bool Active;
        public double Price;
        public string Description;
        public Categorie Categorie;

        public Product() { }

        public Product(int pid, string name, int amount, string productimage,
                        bool active, string description, double price, int cid)
        {
            pID = pid;
            Name = name;
            Amount = amount;
            Productimage = productimage;
            Active = active;
            Description = description;
            Price = price;
            Categorie = this.getCategorie(cid);
        }

        public Categorie getCategorie(int cid)
        {
            return categorieSQL.GetCategorie(cid);
        }
    }
}