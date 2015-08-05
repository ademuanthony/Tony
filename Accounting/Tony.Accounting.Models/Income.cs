using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Income:Entity<long>, IAuditableEntity
    {
        public int CategoryId { get; set; }

        public long SourceId { get; set; }

        public string SourceName { get; set; }

        public decimal Amount { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public string Notes { get; set; }


        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
