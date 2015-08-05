using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony.Accounting.Models
{
    public interface IAccountDbContext 
    {
        DbSet<Account> AccountingAccounts { get; set; }
        DbSet<AccountSummary> AccountingAccountSummaries { get; set; }
        DbSet<IncomeCategory> AccountingIncomeCategories { get; set; }
        DbSet<Income> AccountingIncomes { get; set; }
        DbSet<ExpenditureCategory> AccountingExpenditureCategories { get; set; }
        DbSet<Expenditure> AccountingExpenditures { get; set; }
        DbSet<Invoice> AccountingInvoices { get; set; }
        DbSet<Owner> AccountingOwners { get; set; }
        DbSet<Recurrence> AccountingRecurrences { get; set; }
        DbSet<Transfer> AccountingTransfers { get; set; } 
    }
}
