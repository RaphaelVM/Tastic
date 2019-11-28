using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Categorie
    {
        public int cID;
        public string Name;
        public string Description;

        public Categorie() { }

        public Categorie(int cid, string name, string description)
        {
            cID = cid;
            Name = name;
            Description = description;
        }
    }
}