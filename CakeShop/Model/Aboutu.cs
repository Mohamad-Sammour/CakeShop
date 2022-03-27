using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Aboutu
    {
        public Aboutu()
        {
            Homes = new HashSet<Home>();
        }

        public decimal AboutusId { get; set; }
        public string Message { get; set; }

        public virtual ICollection<Home> Homes { get; set; }
    }
}
