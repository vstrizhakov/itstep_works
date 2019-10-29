using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public User() { }

        public User(string firstname, string lastname, string email, string password, int roleid)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            RoleId = roleid;
        }
    }
}