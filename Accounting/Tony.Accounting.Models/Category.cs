using System.ComponentModel.DataAnnotations.Schema;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class IncomeCategory:Entity
    {
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public string Name { get; set; }
    }

    public class ExpenditureCategory : Entity
    {
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public string Name { get; set; }
    }

    public class InvoiceCategory : Entity
    {
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")] 
        public Owner Owner { get; set; }

        public string Name { get; set; }
    }

    
}
