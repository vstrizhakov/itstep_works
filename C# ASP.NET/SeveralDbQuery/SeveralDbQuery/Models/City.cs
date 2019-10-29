using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeveralDbQuery.Models
{
    public class City
    {
        static private int _id = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public City() { }

        public City(string name, int countryId)
        {
            Id = _id++;
            Name = name;
            CountryId = countryId;
        }
    }
}