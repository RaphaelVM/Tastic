using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tastic.classes
{
    public class Role
    {
        public int rID;
        public string Rolename;
        public string Description;

        public Role() { }

        public Role(int rid, string rolename, string description)
        {
            rID = rid;
            Rolename = rolename;
            Description = description;
        }
    }
}