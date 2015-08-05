using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using Tony.Accounting.Models;

namespace Tony.Accounting
{
    [InheritedExport]
    public interface IAccountService
    {
        //operations on account entity
        void AddAccount(Account account);

        void UpdateAccount(Account account);

        void DeleteAccount(Account account);

        Account FindAccount(int id);

        IQueryable<Account> GetAccounts(Expression<Func<Account, bool>> match = null);

        IQueryable<Account> GetAccounts(string username);

        IQueryable<Account> GetAccounts(int ownerId);

        AccountSummary GetSummary(DateTime startDate, DateTime endDate, string username);
        

        //operations on category entity 
        void AddCategory(IncomeCategory category);

        void UpdateCategory(IncomeCategory category);

        void DeleteCategory(IncomeCategory category);

        IncomeCategory FindCategory(int id); 

        IQueryable<IncomeCategory> GetCategories(Expression<Func<IncomeCategory, bool>> match = null);
        
        IQueryable<IncomeCategory> GetCategories(int ownerId);


        //operations on expenditure entity 
        void AddExpenditure(Expenditure expenditure);

        void UpdateExpenditure(Expenditure expenditure);

        void DeleteExpenditure(Expenditure expenditure);

        Expenditure FindExpenditure(int id);

        IQueryable<Expenditure> GetExpenditures(Expression<Func<Expenditure, bool>> match = null);

        IQueryable<Expenditure> GetExpenditures(string username);

        IQueryable<Expenditure> GetExpenditures(int accountId);
        

        //operations on account entity
        void AddIncome(Income income);

        void UpdateIncome(Income income);

        void DeleteIncome(Income income);

        Income FindIncome(long id);

        IQueryable<Income> GetIncomes(Expression<Func<Income, bool>> match = null);

        IQueryable<Income> GetIncomes(string username);

        IQueryable<Income> GetIncomes(int accountId);

        

        //operations on invoice entity
        void AddInvoice(Invoice invoice);

        void UpdateInvoice(Invoice invoice);

        void DeleteInvoice(Invoice invoice);

        Invoice FindInvoice(int id);

        IQueryable<Invoice> GetInvoices(Expression<Func<Invoice, bool>> match = null);

        IQueryable<Invoice> GetInvoices(string username);

        IQueryable<Invoice> GetInvoices(int ownerId);

        IQueryable<Invoice> GetUpComingInvoices();
        
        //operations on owner entity
        IQueryable<Owner> GetOwners(Expression<Func<Owner, bool>> match = null);

        void AddOwner(Owner owner);

        void UpdateOwner(Owner owner);

        void DeleteOwner(Owner owner);

        Owner FindOwner(string username);

        Owner FindOwner(int id);



        //operations on recurrence entity
        void AddRecurrence(Recurrence recurrence);

        void UpdateRecurrence(Recurrence recurrence);

        void DeleteRecurrence(Recurrence recurrence);

        Recurrence FindRecurrence(int id);

        IQueryable<Recurrence> GetRecurrences(Expression<Func<Recurrence, bool>> match = null);

        IQueryable<Recurrence> GetRecurrences(string username, RecurrenceType recurrenceType);

        IQueryable<Recurrence> GetRecurrences(int ownerId, RecurrenceType recurrenceType);



        //operations on transfer entity 
        void AddTransfer(Transfer transfer);

        void UpdateTransfer(Transfer transfer);

        void DeleteTransfer(Transfer transfer);

        Transfer FindTransfer(int id);

        IQueryable<Transfer> GetTransfers(Expression<Func<Transfer, bool>> match = null);

        IQueryable<Transfer> GetTransfers(string username);
         
        IQueryable<Transfer> GetTransfers(int ownerId);

    }
}
