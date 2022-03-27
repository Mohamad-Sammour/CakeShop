using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Cart
    {
        public Cart()
        {
            Orders = new HashSet<Order>();
        }

        public decimal CartId { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
