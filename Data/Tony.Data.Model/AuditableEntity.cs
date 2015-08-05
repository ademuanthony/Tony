using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony.Data.Model
{

    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
         

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }

    //public abstract class AuditableEntity : AuditableEntity<int>
    //{
    //}
}
