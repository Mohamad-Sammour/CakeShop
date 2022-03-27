using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Login
    {
        public decimal LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? CustomerId { get; set; }
        public decimal? EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
