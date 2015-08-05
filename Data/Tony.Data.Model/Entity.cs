using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony.Data.Model
{
   
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        protected Entity()
        {
            RowVersionString = RowVersion != null ? Convert.ToBase64String(RowVersion) : string.Empty;
        }

        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public string RowVersionString { get; set; }

        public virtual TKey Id { get; set; }
    }

    public abstract class Entity : Entity<int> { }
}
