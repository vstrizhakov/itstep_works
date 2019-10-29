using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class OrderUnit
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }

        public OrderUnit() { }

        public OrderUnit(int productId, int count)
        {
            ProductId = productId;
            Count = count;
        }
    }
}