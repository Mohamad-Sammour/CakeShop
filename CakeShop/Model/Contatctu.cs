using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Contatctu
    {
        public Contatctu()
        {
            Homes = new HashSet<Home>();
        }

        public decimal ContatcusId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int? PhoneNumber { get; set; }
        public string Message { get; set; }

        public virtual ICollection<Home> Homes { get; set; }
    }
}
