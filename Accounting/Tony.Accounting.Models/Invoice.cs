using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Invoice:Entity,IAuditableEntity
    {
        //public int OwnerId { get; set; }

        //[ForeignKey("OwnerId")]
        //public Owner Owner { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public InvoiceCategory Category { get; set; }

        public decimal Amount { get; set; }

        public string Notes { get; set; }

        public bool Paid { get; set; }


        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
