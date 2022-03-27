using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CakeShop.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Logins = new HashSet<Login>();
            Testimoials = new HashSet<Testimoial>();
        }

        public decimal CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Testimoial> Testimoials { get; set; }
        //public string CustomerImagepath { get; internal set; }
    }
}
