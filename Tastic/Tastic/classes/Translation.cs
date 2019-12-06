using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Translation
    {
        public int tID;
        public string Description;
        public string NL;
        public string EN;

        public Translation() { }

        public Translation(int tid, string description, string nl, string en)
        {
            tID = tid;
            Description = description;
            NL = nl;
            EN = en;
        }
    }
}