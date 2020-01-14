using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tastic.classes;
using Tastic.sql;

namespace Tastic.classes
{
    public class Role
    {
        private RoleSQL roleSQL = new RoleSQL();

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

        public List<Role> getAllRoles()
        {
            return roleSQL.getAllRoles();
        }
    }
}