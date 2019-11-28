using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Wallet
    {
        public int wID;
        public double Amount;

        public Wallet() { }

        public Wallet(int wid, double amount)
        {
            wID = wid;
            Amount = amount;
        }
    }
}