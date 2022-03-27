using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Testimoial
    {
        public decimal TestimoialId { get; set; }
        public DateTime? TestimoialDate { get; set; }
        public string Message { get; set; }
        public decimal? Ratting { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
