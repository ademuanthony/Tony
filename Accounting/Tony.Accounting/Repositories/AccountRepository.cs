using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Common.DependencyInjection.Locator;
using Tony.Data.Repository;

namespace Tony.Accounting.Repositories
{
    public interface IAccountReposity : IGenericRepository<Account>
    {
        List<AccountSummary> GetSummaries(DateTime startDate, DateTime endDate);
    }

    public class AccountRepository:GenericRepository<Account>, IAccountReposity
    {
        private IIncomeRepository _incomeRepository;
        private IExpenditureRepository _expendetuRepository;
        private ITransferRepository _transferRepository;

        public AccountRepository(DbContext context, IServiceLocator serviceLocator) : base(context)
        {
            _incomeRepository = serviceLocator.Get<IIncomeRepository>();
            _expendetuRepository = serviceLocator.Get<IExpenditureRepository>();
            _transferRepository = serviceLocator.Get<ITransferRepository>();
        }

        public List<AccountSummary> GetSummaries(DateTime startDate, DateTime endDate)
        {
            return null;
        } 
    }
}
