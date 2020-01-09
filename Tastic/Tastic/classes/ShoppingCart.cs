using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.sql;
using Tastic.classes;

namespace Tastic.classes
{
    public static class ShoppingCart
    {
        static public List<ShoppingCartItem> items { get; set; }

        static ShoppingCart()
        {
            items = new List<ShoppingCartItem>();
        }

        public static List<ShoppingCartItem> Items
        {
            get { return items; }
        }

        /// <summary>
        /// Add an item to the shoppingcart
        /// </summary>
        /// <param name="shoppingCartItem"></param>
        public static void addItem(ShoppingCartItem shoppingCartItem)
        {
            items.Add(shoppingCartItem);
        }
    }
}