using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<OrderUnit> Units { get; set; }

        public Order() { }

        public Order(int userid, DateTime createdat)
        {
            UserId = userid;
            CreatedAt = createdat;
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (OrderUnit unit in Units)
            {
                totalPrice += unit.Product.Price * unit.Count;
            }
            return totalPrice;
        }
    }
}