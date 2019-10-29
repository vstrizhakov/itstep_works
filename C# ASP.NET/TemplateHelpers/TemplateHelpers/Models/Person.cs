using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateHelpers.Models
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public bool IsProgrammer { get; set; }
        public string Password { get; set; }
    }
}