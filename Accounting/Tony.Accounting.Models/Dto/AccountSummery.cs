using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony.Accounting.Models.Dto
{
    public class AccountSummery
    {
        public Account Account { get; set; }
        public decimal Income { get; set; }
        public decimal Expenditure { get; set; } 
        public decimal OutGoinggTransfer { get; set; }
        public decimal InComingTransfer { get; set; }
    }
}
