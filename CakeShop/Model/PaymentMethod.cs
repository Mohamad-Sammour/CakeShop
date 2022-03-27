using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class PaymentMethod
    {
        public decimal VisaId { get; set; }
        public decimal? Cvv { get; set; }
        public decimal? Amount { get; set; }
        public decimal? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
