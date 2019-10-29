using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLHelpers.Models
{
    public class Product
    {
        static int count = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Id = count++;
        }
    }
}