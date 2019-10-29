using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Role
    {
        public enum Type
        {
            User, Admin
        }

        public int Id { get; set; }
        public Type RoleType { get; set; }

        public Role() { }

        public Role(Type roletype)
        {
            RoleType = roletype;
        }
    }
}