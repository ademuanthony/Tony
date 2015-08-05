using System.Data.Entity;
using Tony.Accounting.Models;
using Tony.Data;
using Tony.Data.EF;

namespace Tony.Accounting
{
    public class EfRepository:IRepository
    {
        private readonly DbContext _context;
        public EfRepository(DbContext context)
        {
            _context = context;
        }
        

        public IGenericRepository<Account> Account
        {
            get { return new GenericRepository<Account>(_context); }
        }

        public IGenericRepository<IncomeCategory> Category
        {
            get { return new GenericRepository<IncomeCategory>(_context);}
        }

        public IGenericRepository<Expenditure> Expenditure
        {
            get { return new GenericRepository<Expenditure>(_context); }
        }

        public IGenericRepository<Income, long> Income
        {
            get { return new GenericRepository<Income, long>(_context); }
        }

        public IGenericRepository<Invoice> Invoice
        {
            get { return new GenericRepository<Invoice>(_context); }
        }

        public IGenericRepository<Owner> Owner
        {
            get { return new GenericRepository<Owner>(_context); }
        }

        public IGenericRepository<Recurrence> Recurrence
        {
            get { return new GenericRepository<Recurrence>(_context); }
        }

        public IGenericRepository<Transfer> Transfer
        {
            get { return new GenericRepository<Transfer>(_context); }
        }
    }
}
