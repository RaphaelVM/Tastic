using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;

namespace Tastic.classes
{
    public class ShoppingCartItem
    {
        private ShoppingCartItemSQL shoppingCartItemSQL = new ShoppingCartItemSQL();
        
        public int? sciID;
        public Product Product;
        public int Amount;

        public ShoppingCartItem() { }

        public ShoppingCartItem(int? sciid, Product product, int amount = 1)
        {
            sciID = ShoppingCart.items.Count;
            Product = product;
            Amount = amount;
        }

        public ShoppingCartItem getShoppingCartItem(int pID)
        {
            return shoppingCartItemSQL.getShoppingCartItem(pID);
        }
    }
}