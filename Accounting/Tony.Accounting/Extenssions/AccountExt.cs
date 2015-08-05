using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Accounting.Models.Dto;

namespace Tony.Accounting.Extenssions
{
    public static class AccountExt
    {
        public static TransferInfo ToTransferInfo(this Transfer transfer, IEnumerable<Account> accounts)
        {
            var account = accounts.FirstOrDefault(accont => accont.Id == transfer.ToAccountId);
            return new TransferInfo
            {
                ToAccount = account,
                Transfer = transfer
            };
        }

        public static TransferInfo ToTransferInfo(this Transfer transfer, Account account)
        {
            return new TransferInfo
            {
                ToAccount = account,
                Transfer = transfer
            };
        }
    }
}
