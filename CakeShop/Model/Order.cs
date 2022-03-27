using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Order
    {
        public Order()
        {
            PaymentMethods = new HashSet<PaymentMethod>();
        }

        public decimal OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? CartId { get; set; }
        public decimal? ProductId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
