using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CakeShop.Model
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }

       
        public decimal? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
