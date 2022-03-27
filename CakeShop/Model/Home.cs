using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Home
    {
        public decimal HomeId { get; set; }
        public string Logo { get; set; }
        public string Slider { get; set; }
        public decimal? AboutusId { get; set; }
        public decimal? ContactusId { get; set; }

        public virtual Aboutu Aboutus { get; set; }
        public virtual Contatctu Contactus { get; set; }
    }
}
