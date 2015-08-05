using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Account : Entity, IAuditableEntity
    {
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public string Name { get; set; }

        public AccountType Type { get; set; }

        public decimal OpeningBalance { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum AccountType
    {
        Bank = 0,

        Cash = 1
    }
}
