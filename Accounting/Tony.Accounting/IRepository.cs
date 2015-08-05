using Tony.Accounting.Models;
using Tony.Data;

namespace Tony.Accounting
{
    public interface IRepository
    {
        IGenericRepository<Account> Account { get; }

        IGenericRepository<IncomeCategory> Category { get; }

        IGenericRepository<Expenditure> Expenditure { get; }

        IGenericRepository<Income, long> Income { get; }

        IGenericRepository<Invoice> Invoice { get; }
        
        IGenericRepository<Owner> Owner { get; }

        IGenericRepository<Recurrence> Recurrence { get; }

        IGenericRepository<Transfer> Transfer { get; }
    }
}
