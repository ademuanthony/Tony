using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Data.Repository;
using Tony.Data.Services;

namespace Tony.Accounting.Services
{
    public interface IAccountService : IEntityService<Account>
    {
        int CreateAccount(Account account);
        //long SaveIncome(Income income);
        //void DeleteIncome(Income income);
    }

    public class AccountService:EntityService<Account>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IGenericRepository<Account> repository) :
            base(unitOfWork, repository)
        {
            
        }

        public int CreateAccount(Account account)
        {
            try
            {
                return Create(account);
            }
            catch
            {
                return 0;
            }
        }

        //public long SaveIncome(Income income)
        //{
        //    income.Id = income.Id == 0?Create(income)
        //}
    }
}
