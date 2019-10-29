using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeveralDbQuery.Models
{
    public class Country
    {
        static private int _id = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        
        public Country() { }

        public Country(string name)
        {
            Id = _id++;
            Name = name;
            Cities = new List<City>();
        }
    }
}