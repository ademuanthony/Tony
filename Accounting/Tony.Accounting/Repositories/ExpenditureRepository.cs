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
    public interface IExpenditureRepository:IGenericRepository<Expenditure>
    {
        
    }
    public class ExpenditureRepository:GenericRepository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(DbContext context) : base(context)
        {
        }

        public new IQueryable<Expenditure> GetAll()
        {
            return Dbset.Include(i => i.Account);
        }
    }
}
