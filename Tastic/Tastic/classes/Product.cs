using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Product
    {
        public int pID;
        public string Name;
        public int Amount;
        public string Productimage;
        public bool Active;
        public Categorie Categorie;

        public Product() { }

        public Product(int pid, string name, int amount, string productimage,
                        bool active, Categorie categorie)
        {
            pID = pid;
            Name = name;
            Amount = amount;
            Productimage = productimage;
            Active = active;
            Categorie = categorie;
        }
    }
}