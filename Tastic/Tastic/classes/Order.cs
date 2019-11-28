using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Order
    {
        public int oID;
        public int uID;
        public List<OrderLines> OrderLines;
        public DateTime DateAdded;

        public Order() { }

        public Order(int oid, int uid, List<OrderLines> orderlines, DateTime dateadded)
        {
            oID = oid;
            uID = uid;
            OrderLines = orderlines;
            DateAdded = dateadded;
        }
    }
}