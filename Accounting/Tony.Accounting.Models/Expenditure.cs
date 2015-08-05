using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Expenditure:Entity,IAuditableEntity
    {
        public string Payee { get; set; }

        public int OwnerId { get; set; }

        //[ForeignKey("OwnerId")]
        //public Owner Owner { get; set; }

        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public ExpenditureCategory Category { get; set; }

        public decimal Amount { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public string Notes { get; set; }


        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string DateString { get { return CreatedDate.ToShortDateString(); } }
    }
}
