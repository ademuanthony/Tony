using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Recurrence:Entity
    {
        //public int OwnerId { get; set; }

        //[ForeignKey("OwnerId")]
        //public Owner Owner { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public ExpenditureCategory Category { get; set; }

        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Notes { get; set; }

        public RecurrenceCircle Circle { get; set; }

        public RecurrenceType Type { get; set; }

        public bool AutoSave { get; set; }
    }
}
