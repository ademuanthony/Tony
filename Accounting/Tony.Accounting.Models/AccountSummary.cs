using System;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class AccountSummary:Entity
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpenditure { get; set; }

        public DateTime Date { get; set; }

    }
}
