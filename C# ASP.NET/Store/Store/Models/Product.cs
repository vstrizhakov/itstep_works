using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Category Category { get; set; }
        
        public Product() { }

        public Product(int categroyid, string name, string description, string photopath, double weight, double price, int quantity)
        {
            CategoryId = categroyid;
            Name = name;
            Description = description;
            PhotoPath = photopath;
            Weight = weight;
            Price = price;
            Quantity = quantity;
        }
    }
}