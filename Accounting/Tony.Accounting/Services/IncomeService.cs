using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Accounting.Repositories;
using Tony.Data.Repository;
using Tony.Data.Services;

namespace Tony.Accounting.Services
{
    public interface IIncomeService : IEntityService<Income, long>
    {
    }

    public class IncomeService:EntityService<Income,long>, IIncomeService
    {
        public IncomeService(IUnitOfWork unitOfWork, IIncomeRepository repository)
            : base(unitOfWork, repository)
        {
            
        }

    }
}
