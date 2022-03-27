using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CakeShop.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Logins = new HashSet<Login>();
            Reports = new HashSet<Report>();
        }

        public decimal EmployeeId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? PhoneNumber { get; set; }
        public DateTime? HairedDate { get; set; }
        public decimal? Salary { get; set; }
        public string Image { get; set; }
        public decimal? Roleid { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
