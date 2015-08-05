using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Transfer:Entity, IAuditableEntity
    {
        //public int OwnerId { get; set; }

        //[ForeignKey("OwnerId")]
        //public Owner Owner { get; set; }

        public int FromAccountId { get; set; }

        [ForeignKey("FromAccountId")]
        public Account FromAccount { get; set; }

        public int ToAccountId { get; set; }

        //[ForeignKey("ToAccountId")]
        //public Account ToAccount { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }


        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string DateString { get { return CreatedDate.ToShortDateString(); } }
    }
}
