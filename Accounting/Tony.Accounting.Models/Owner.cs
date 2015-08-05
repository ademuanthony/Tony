using System;
using Tony.Data.Model;

namespace Tony.Accounting.Models
{
    public class Owner:Entity, IAuditableEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; } 

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
