using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class OrderLines
    {
        public int olID;
        public int oID;
        public Product Product;
        public int Amount;
        public DateTime DateAdded;

        public OrderLines() { }

        public OrderLines(int olid, int oid, Product product, int amount, DateTime dateadded)
        {
            olID = olid;
            oID = oid;
            Product = product;
            Amount = amount;
            DateAdded = dateadded;
        }
    }
}