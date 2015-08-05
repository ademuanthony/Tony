using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Data.Repository;

namespace Tony.Accounting.Repositories
{
    public interface IIncomeRepository : IGenericRepository<Income, long>
    {
    }

    public class IncomeRepository : GenericRepository<Income, long>, IIncomeRepository
    {
        public IncomeRepository(DbContext context) : base(context)
        {
            
        }
        
        public new IQueryable<Income> GetAll()
        {
            return Dbset.Include(i => i.Account);
        }
    }
}
