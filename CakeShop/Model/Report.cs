using System;
using System.Collections.Generic;

#nullable disable

namespace CakeShop.Model
{
    public partial class Report
    {
        public decimal ReportId { get; set; }
        public string ReportType { get; set; }
        public DateTime? DateOut { get; set; }
        public decimal? SalaryProfits { get; set; }
        public decimal? SalaryLosses { get; set; }
        public decimal? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
