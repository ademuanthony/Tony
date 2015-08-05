using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Accounting.Models.Dto;
using Tony.Data.Model;

namespace Tony.Accounting.Events
{
    public class AccountChangedEvent
    {
        public Account Account { get; set; }
        public EntityChangeType ChangeType { get; set; }
    }

    public class IncomeChangedEvent
    {
        public Income Income { get; set; }
        public EntityChangeType ChangeType { get; set; }
    }

    public class ExpenditureChangedEvent
    {
        public Expenditure Expenditure { get; set; }
        public EntityChangeType ChangeType { get; set; }
    }

    public class TransferChangedEvent
    {
        public TransferInfo TransferInfo { get; set; }
        public EntityChangeType ChangeType { get; set; }
    }
}
