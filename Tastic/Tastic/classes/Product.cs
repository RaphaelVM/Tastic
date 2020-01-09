using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;

namespace Tastic.classes
{
    public class Product
    {
        private CategorySQL CategorySQL = new CategorySQL();
        private ShoppingCartItemSQL shoppingCartItemSQL = new ShoppingCartItemSQL();

        public int pID;
        public string Name;
        public int Amount;
        public string Productimage;
        public bool Active;
        public double Price;
        public string Description;
        public Category Category;

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
        }

        // Don't do this for now.
        //public Category getCategory(int cid)
        //{
        //    return CategorySQL.GetCategory(cid);
        //}

        public ShoppingCartItem getShoppingCartItem(int pID)
        {
            return shoppingCartItemSQL.getShoppingCartItem(pID);
        }
    }
}