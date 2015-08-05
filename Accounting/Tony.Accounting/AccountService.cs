using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Tony.Accounting.Models;

namespace Tony.Accounting
{
    [Export(typeof(IAccountService))]
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        public AccountService()
        {
            //get the context class from appsettings in web.config
            var dbContextTypeName = ConfigurationManager.AppSettings["DbContext"];
            if (dbContextTypeName == null)
                throw new ArgumentException("DbContext is not registered in the appsettings of the web.config");

            var dbContextTypeAssembly = ConfigurationManager.AppSettings["DbContextAssembly"] ?? dbContextTypeName;

            var dbContextType = Type.GetType(string.Format("{0}, {1}", dbContextTypeName, dbContextTypeAssembly));
            if (dbContextType == null)
                throw new ArgumentException("Unable to create an instance of " + dbContextTypeName);
            var context = Activator.CreateInstance(dbContextType) as DbContext;

            if(!(context is IAccountDbContext))
                throw new InvalidOperationException(string.Format("{0} must implement {1} serve as DbContext for Accounting",
                    dbContextTypeName, "Tony.Accounting.Models.IAccountDbContext"));
             
            _repository = new EfRepository(context);
        }

        //[ImportingConstructor]
        //public AccountService(DbContext context)
        //{
        //    _repository = new EfRepository(context);
        //}


        //account
        public void AddAccount(Account account)
        {
            _repository.Account.Add(account);
        }

        public void UpdateAccount(Account account)
        {
            _repository.Account.Update(account);
        }

        public void DeleteAccount(Account account)
        {
            _repository.Account.Delete(account);
        }

        public Account FindAccount(int id)
        {
            return _repository.Account.Find(a => a.Id == id);
        }

        public IQueryable<Account> GetAccounts(Expression<Func<Account, bool>> match = null)
        {
            return _repository.Account.FindAll(match);
        }

        public IQueryable<Account> GetAccounts(string username)
        {
            return _repository.Account.FindAll(a => a.Owner.Username == username);
        }

        public IQueryable<Account> GetAccounts(int ownerId)
        {
            return _repository.Account.FindAll(a => a.OwnerId == ownerId);
        }

        public AccountSummary GetSummary(DateTime startDate, DateTime endDate, string username)
        {
            var income = (from inc in _repository.Income.FindAll(i => i.Account.Owner.Username == username
                                                                      && i.Date >= startDate && i.Date <= endDate)
                select inc.Amount).Sum();
            var expenditure = (from ex in _repository.Expenditure.FindAll(i => i.Account.Owner.Username == username
                                                                               && i.Date >= startDate &&
                                                                               i.Date <= endDate)
                select ex.Amount).Sum();
            return new AccountSummary {TotalIncome = income, TotalExpenditure = expenditure};
        }


        //Category
        public void AddCategory(IncomeCategory category)
        {
            _repository.Category.Add(category);
        }

        public void UpdateCategory(IncomeCategory category)
        {
            _repository.Category.Update(category);
        }

        public void DeleteCategory(IncomeCategory category)
        {
            _repository.Category.Delete(category);
        }

        public IncomeCategory FindCategory(int id)
        {
            return _repository.Category.Find(c => c.Id == id);
        }

        public IQueryable<IncomeCategory> GetCategories(Expression<Func<IncomeCategory, bool>> match = null)
        {
            return _repository.Category.FindAll(match);
        }

        public IQueryable<IncomeCategory> GetCategories(int ownerId)
        {
            return GetCategories(c => c.OwnerId == ownerId);
        }


        //Expenditure
        public void AddExpenditure(Expenditure expenditure)
        {
            _repository.Expenditure.Add(expenditure);
        }

        public void UpdateExpenditure(Expenditure expenditure)
        {
            _repository.Expenditure.Update(expenditure);
        }

        public void DeleteExpenditure(Expenditure expenditure)
        {
            _repository.Expenditure.Delete(expenditure);
        }

        public Expenditure FindExpenditure(int id)
        {
            return _repository.Expenditure.Find(ex => ex.Id == id);
        }

        public IQueryable<Expenditure> GetExpenditures(Expression<Func<Expenditure, bool>> match = null)
        {
            return _repository.Expenditure.FindAll(match);
        }

        public IQueryable<Expenditure> GetExpenditures(string username)
        {
            return GetExpenditures(ex => ex.Account.Owner.Username == username);
        }

        public IQueryable<Expenditure> GetExpenditures(int accountId)
        {
            return GetExpenditures(ex => ex.AccountId == accountId);
        }

        //Income
        public void AddIncome(Income income)
        {
            _repository.Income.Add(income);
        }

        public void UpdateIncome(Income income)
        {
            _repository.Income.Update(income);
        }

        public void DeleteIncome(Income income)
        {
            _repository.Income.Delete(income);
        }

        public Income FindIncome(long id)
        {
            return _repository.Income.Find(i => i.Id == id);
        }

        public IQueryable<Income> GetIncomes(Expression<Func<Income, bool>> match = null)
        {
            return _repository.Income.FindAll(match);
        }

        public IQueryable<Income> GetIncomes(string username)
        {
            return GetIncomes(i => i.Account.Owner.Username == username);
        }

        public IQueryable<Income> GetIncomes(int accountId)
        {
            return GetIncomes(i => i.AccountId == accountId);
        }

        //Invoice
        public void AddInvoice(Invoice invoice)
        {
             _repository.Invoice.Add(invoice);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _repository.Invoice.Update(invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _repository.Invoice.Delete(invoice);
        }

        public Invoice FindInvoice(int id)
        {
            return _repository.Invoice.Find(i => i.Id == id);
        }

        public IQueryable<Invoice> GetInvoices(Expression<Func<Invoice, bool>> match = null)
        {
            return _repository.Invoice.FindAll(match);
        }

        public IQueryable<Invoice> GetInvoices(string username)
        {
            return GetInvoices(c => c.Category.Owner.Username == username);
        }

        public IQueryable<Invoice> GetInvoices(int ownerId)
        {
            return GetInvoices(c => c.Category.OwnerId == ownerId);
        }

        public IQueryable<Invoice> GetUpComingInvoices()
        {
            return GetInvoices(inv => inv.Date >= DateTime.Now && inv.Paid);
        } 

        //owners
        public IQueryable<Owner> GetOwners(Expression<Func<Owner, bool>> match = null)
        {
            return _repository.Owner.FindAll(match);
        }

        public void AddOwner(Owner owner)
        {
            _repository.Owner.AddAndGetId(owner);
           
        }

        public void UpdateOwner(Owner owner)
        {
            _repository.Owner.Update(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            _repository.Owner.Delete(owner);
        }

        public Owner FindOwner(string username)
        {
            return _repository.Owner.Find(o => o.Username == username);
        }

        public Owner FindOwner(int id)
        {
            return _repository.Owner.Find(o => o.Id == id);
        }

        //recurrence
        public void AddRecurrence(Recurrence recurrence)
        {
            _repository.Recurrence.Add(recurrence);
        }

        public void UpdateRecurrence(Recurrence recurrence)
        {
            _repository.Recurrence.Update(recurrence);
        }

        public void DeleteRecurrence(Recurrence recurrence)
        {
            _repository.Recurrence.Delete(recurrence);
        }

        public Recurrence FindRecurrence(int id)
        {
            return _repository.Recurrence.Find(r => r.Id == id);
        }

        public IQueryable<Recurrence> GetRecurrences(Expression<Func<Recurrence, bool>> match = null)
        {
            return _repository.Recurrence.FindAll(match);
        }

        public IQueryable<Recurrence> GetRecurrences(string username, RecurrenceType recurrenceType)
        {
            return GetRecurrences(r => r.Category.Owner.Username == username && r.Type == recurrenceType);
        }

        public IQueryable<Recurrence> GetRecurrences(int ownerId, RecurrenceType recurrenceType)
        {
            return GetRecurrences(r => r.Category.OwnerId == ownerId && r.Type == recurrenceType);
        }

        //transfer
        public void AddTransfer(Transfer transfer)
        {
            _repository.Transfer.Add(transfer);
        }

        public void UpdateTransfer(Transfer transfer)
        {
            _repository.Transfer.Update(transfer);
        }

        public void DeleteTransfer(Transfer transfer)
        {
          _repository.Transfer.Delete(transfer);
        }

        public Transfer FindTransfer(int id)
        {
            return _repository.Transfer.Find(t => t.Id == id);
        }

        public IQueryable<Transfer> GetTransfers(Expression<Func<Transfer, bool>> match = null)
        {
            return _repository.Transfer.FindAll(match);
        }

        public IQueryable<Transfer> GetTransfers(string username)
        {
            return GetTransfers(t => t.FromAccount.Owner.Username == username);
        }

        public IQueryable<Transfer> GetTransfers(int ownerId)
        {
            return GetTransfers(t => t.FromAccount.OwnerId == ownerId);
        }
    }
}
